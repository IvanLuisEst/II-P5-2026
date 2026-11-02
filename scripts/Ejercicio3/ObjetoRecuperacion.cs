using UnityEngine;

public class ObjetoRecuperacion : MonoBehaviour
{
    public delegate void mensaje();
    public event mensaje EventoMovimiento;

    public float distanciaRecogida = 2f;
    private Transform camara;

    public void Start()
    {
        if (Camera.main != null)
        {
            camara = Camera.main.transform;
        }
    }

    public void OnPointerEnter()
    {
        float distancia = Vector3.Distance(
            camara.position,
            transform.position
        );
        Debug.Log(distancia);

        if (EventoMovimiento != null && distancia <= distanciaRecogida)
        {
            Debug.Log("lol");
            EventoMovimiento();
        }
    }
}
