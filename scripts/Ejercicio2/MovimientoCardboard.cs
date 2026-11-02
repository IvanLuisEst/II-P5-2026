using UnityEngine;

public class MovimientoCardboard : MonoBehaviour
{
    public float distanciaMinima = 4f;
    public float distanciaMaxima = 10f;
    public float tiempoSeleccion = 2f;
    public float velocidad = 2f;

    private Transform camara;
    private Rigidbody rb;
    private CapsuleCollider col;

    private Vector3 puntoSeleccionado;
    private Vector3 destino;

    private float tiempoMirada = 0f;

    private bool seleccionando = false;
    private bool moviendo = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();

        Camera cam = Camera.main;

        if (cam == null)
            cam = GetComponentInChildren<Camera>();

        if (cam != null)
            camara = cam.transform;
        else
            Debug.LogError("No se encontró la cámara.");
    }

    void Update()
    {
        if (camara == null)
            return;

        if (!moviendo)
            ComprobarMirada();
    }

    void FixedUpdate()
    {
        if (moviendo)
            MoverPersonaje();
    }

    void ComprobarMirada()
    {
        Ray rayo = new Ray(camara.position, camara.forward);
        RaycastHit impacto;

        if (Physics.Raycast(rayo, out impacto, distanciaMaxima))
        {
            if (impacto.collider is TerrainCollider)
            {
                float distancia = Vector3.Distance(
                    camara.position, impacto.point
                );

                if (distancia >= distanciaMinima &&
                    distancia <= distanciaMaxima)
                {
                    if (!seleccionando ||
                        Vector3.Distance(
                            puntoSeleccionado, impacto.point
                        ) > 0.5f)
                    {
                        puntoSeleccionado = impacto.point;
                        tiempoMirada = 0f;
                        seleccionando = true;
                    }

                    tiempoMirada += Time.deltaTime;

                    if (tiempoMirada >= tiempoSeleccion)
                    {
                        destino = puntoSeleccionado;
                        moviendo = true;
                        seleccionando = false;

                        Debug.Log("Destino seleccionado: " + destino);
                    }

                    return;
                }
            }
        }

        seleccionando = false;
        tiempoMirada = 0f;
    }

    void MoverPersonaje()
    {
        Vector3 destinoHorizontal = new Vector3(
            destino.x,
            rb.position.y,
            destino.z
        );

        Vector3 nuevaPosicion = Vector3.MoveTowards(
            rb.position,
            destinoHorizontal,
            velocidad * Time.fixedDeltaTime
        );

        rb.MovePosition(nuevaPosicion);

        if (Vector3.Distance(
            rb.position, destinoHorizontal
        ) < 0.05f)
        {
            moviendo = false;
        }
    }
}
