using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Vehicule : MonoBehaviour
{
    public GestionVoiture gestionVoiture;

    public GameObject m_vehicule;

    private GameObject[] m_vehicule_children;
    private GameObject m_vehicule_wheel_fl;
    private GameObject m_vehicule_wheel_fr;

    Transform m_transform;
    public float m_velocity = 1.0f;
    public float rotationSpeed = 45.0f; // Degrees per second
    private Quaternion currentRotation;

    public float essence;


    string inputAxis_x = "Horizontal";
    string inputAxis_z = "Vertical";


    float input_x = 0;
    float input_z = 0;

    // Start is called before the first frame update
    void Start()
    {
        gestionVoiture = new GestionVoiture();
        m_vehicule = this.gameObject;
        m_transform = this.transform;


        m_vehicule_children = new GameObject[m_vehicule.transform.childCount];
        for (int i = 0; i < m_vehicule.transform.childCount; i++)
        {
            Transform childTransform = m_vehicule.transform.GetChild(i);
            m_vehicule_children[i] = childTransform.gameObject;
        }

        m_vehicule_wheel_fl = m_vehicule_children[1];
        m_vehicule_wheel_fr = m_vehicule_children[2];

    }

    // Update is called once per frame
    void Update()
    {
        input_x = UnityEngine.Input.GetAxis(inputAxis_x);
        input_z = UnityEngine.Input.GetAxis(inputAxis_z);


        VehiculeMotion();
    }




    private void VehiculeMotion()
    {
        Vector3 direction = new Vector3(0.0f, 0.0f, 0.0f);


        if (gestionVoiture.roule(Time.deltaTime))
        {

            if (input_x != 0 || input_z != 0)
            {
                float translation = input_z;

                currentRotation = Quaternion.RotateTowards(currentRotation, Quaternion.Euler(input_z * 9999999999, input_x * 30, 0), rotationSpeed * Time.deltaTime);
                m_vehicule_wheel_fl.transform.rotation = currentRotation;
                m_vehicule_wheel_fr.transform.rotation = currentRotation;

            }


            m_velocity += 2 * Time.deltaTime;
            m_vehicule.transform.position += direction * Time.deltaTime * m_velocity;
        }

        essence = gestionVoiture.getEssence();
    }
}
