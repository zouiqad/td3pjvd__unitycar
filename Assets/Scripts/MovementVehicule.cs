using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovementVehicule : MonoBehaviour
{
    private GestionVoiture gestionVoiture;
    public Camera Camera = Camera.main;

    public GameObject m_vehicule;
    

    private GameObject m_vehicule_wheel_fl;
    private GameObject m_vehicule_wheel_fr;

    public float m_velocity = 1.0f;
    public float essence;
    Vector3 cameraOffset;


    // Start is called before the first frame update
    void Start()
    {
        gestionVoiture = new GestionVoiture();




        cameraOffset = new Vector3(0.0f, 10.0f, -20.0f);

        Camera.main.transform.position = cameraOffset;
        Camera.main.transform.rotation = Quaternion.Euler(25, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        moveVehicule();



        Camera.main.transform.position = m_vehicule.transform.position + cameraOffset;
    }


    public void moveVehicule()
    {
        Vector3 direction = new Vector3(0.0f, 0.0f, 0.0f);


        if (gestionVoiture.roule(Time.deltaTime))
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                direction += new Vector3(1.0f, 0.0f, 0.0f);
                m_vehicule_wheel_fl.transform.rotation = Quaternion.Euler(0.0f, 25.0f, 0.0f);
                m_vehicule_wheel_fr.transform.rotation = Quaternion.Euler(0.0f, 25.0f, 0.0f);

            }


            if (Input.GetKey(KeyCode.LeftArrow))
            {
                direction += new Vector3(-1.0f, 0.0f, 0.0f);


            }


            m_velocity += 2 * Time.deltaTime;
            m_vehicule.transform.position += direction * Time.deltaTime * m_velocity;
        }

        essence = gestionVoiture.getEssence();
    }

}
