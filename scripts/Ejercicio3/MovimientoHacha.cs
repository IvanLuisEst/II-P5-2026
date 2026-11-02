using UnityEngine;

public class MovimientoHacha : MonoBehaviour
{
    public float velocidad = 3f;
    public ObjetoRecuperacion recuperacion;

    private Transform jugador;
    private Rigidbody rbJugador;
    private bool moviendose = false;
    private bool recogido = false;

    void Start()
    {
        // Obtener al jugador a través de la cámara.
        Camera camara = Camera.main;

        if (camara != null)
        {
            Debug.Log("Cámara encontrada");
            jugador = camara.transform.root;

            // Obtener el Rigidbody del jugador.
            rbJugador = jugador.GetComponent<Rigidbody>();
        }

        if (rbJugador == null)
        {
            Debug.LogError("No se ha encontrado el Rigidbody del jugador.");
            return;
        }

        // Suscribirse al evento del objeto de recuperación.
        if (recuperacion != null)
        {
            recuperacion.EventoMovimiento += IniciarMovimiento;
        }
        else
        {
            Debug.LogError("No se ha asignado el objeto de recuperación.");
        }
    }

    void FixedUpdate()
    {
        if (!moviendose || recogido || jugador == null)
            return;

        // Obtener el destino hacia el jugador.
        Vector3 destino = jugador.position + Vector3.up;

        Debug.Log("Moviendo el hacha");

        // Calcular la dirección hacia el jugador.
        Vector3 direccion = (destino - transform.position).normalized;

        // Desplazar el hacha.
        transform.position += direccion * velocidad * Time.fixedDeltaTime;
    }

    void IniciarMovimiento()
    {
        Debug.Log("¡Atracción activada!");
        moviendose = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (recogido)
            return;

        // Comprobar si hemos chocado con el jugador.
        if (collision.transform.root == jugador)
        {
            recogido = true;


            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        // Cancelar la suscripción al evento.
        if (recuperacion != null)
        {
            recuperacion.EventoMovimiento -= IniciarMovimiento;
        }
    }
}
