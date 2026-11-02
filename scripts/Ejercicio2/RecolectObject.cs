using System.Collections;
using UnityEngine;

public class RecolectObject : MonoBehaviour
{
    public float distanciaRecogida = 2f;
    public float tiempoMirada = 1f;

    private Transform camara;

    private bool mirandoObjeto = false;
    private float tiempoAcumulado = 0f;
    private bool recogido = false;

    public void Start()
    {
        if (Camera.main != null)
        {
            camara = Camera.main.transform;
        }

    }

    public void Update()
    {
        if (!mirandoObjeto || recogido || camara == null)
            return;

        float distancia = Vector3.Distance(
            camara.position,
            transform.position
        );

        if (distancia <= distanciaRecogida)
        {
            tiempoAcumulado += Time.deltaTime;
            if (tiempoAcumulado >= tiempoMirada)
            {
                recogido = true;
            }
        }
        else
        {
            tiempoAcumulado = 0f;
        }
    }

    public void OnPointerEnter()
    {
        mirandoObjeto = true;
    }

    public void OnPointerExit()
    {
        mirandoObjeto = false;
        tiempoAcumulado = 0f;
        if(recogido)
        {
            Destroy(gameObject);
        }
    }
}
