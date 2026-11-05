using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour
{


    [Header("Movement parameters")]
    [SerializeField] public Vector3 velocity;
    [SerializeField] float speed;
    [SerializeField] float maxForce;

    [Header("Pursue information")]
    [SerializeField] private float predictionTime;

    [Header("Wander parameters")]
    [SerializeField] private float wanderRadius = 2f;
    [SerializeField] private float wanderDistance = 3f;
    [SerializeField] private float wanderJitter = 1f;

     [Header("Additional parameters")]
    [SerializeField] private float weight;
    [SerializeField] List<Transform> obstacles;

    private GameObject myTarget;
    private Vector3 wanderTarget;
    private Vector3 steering;
    private Vector3 desired;
    private LineRenderer lineyVelocity;
    private LineScript lineSteeringScript;
    private LineScript lineDesiredDirectionScript;

    public bool active = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        GameObject lineSteering = GameObject.Find("LineSteering");
        lineSteeringScript = lineSteering.GetComponent<LineScript>();

        lineSteeringScript.position = transform.position;
        lineSteeringScript.steering = steering;
        lineSteeringScript.SetColor(Color.blue);

        GameObject lineDesired = GameObject.Find("LineDesired");
        lineDesiredDirectionScript = lineDesired.GetComponent<LineScript>();

        lineDesiredDirectionScript.position = transform.position;
        lineDesiredDirectionScript.steering = steering;
        lineDesiredDirectionScript.SetColor(Color.gray);

        myTarget = GameObject.FindWithTag("myTarget");

         //Linerenderer stuff
        lineyVelocity = gameObject.AddComponent<LineRenderer>();
        lineyVelocity.startWidth = 0.1f;
        lineyVelocity.endWidth = 0.1f;
        lineyVelocity.material = new Material(Shader.Find("Sprites/Default"));
        lineyVelocity.startColor = Color.green;
        lineyVelocity.endColor = Color.green;
        lineyVelocity.sortingOrder = 0;
        lineyVelocity.sortingLayerName = "Default";


    }

    // Update is called once per frame
    void Update()
    {
        steering = Vector3.zero;

        if(Keyboard.current.sKey.wasPressedThisFrame){
            active = !active;
        }

        if(active){
            //Compute steering vector
            Debug.Log("Using steering");
            steering = Seek(myTarget.transform.position);
        }
        
        velocity += steering * Time.deltaTime;
        velocity = Vector3.ClampMagnitude(velocity, speed);

        transform.position += velocity * Time.deltaTime;

        if (velocity != Vector3.zero)
            transform.up = velocity;
        
        DrawVelocityAndSteering();
    }

    Vector3 Seek(Vector3 targetPos)
    {
        //TODO
        return Vector3.zero;
    }


    Vector3 Flee(Vector3 targetPos)
    {
        //TODO
        return Vector3.zero;
    }

    Vector3 Pursue(Transform target)
    {
        //TODO
        return Vector3.zero;
    }

    Vector3 Evade(Transform target)
    {
        //TODO
        return Vector3.zero;
    }


    Vector3 Wander()
    {
        //TODO
        return Vector3.zero;
    }

    Vector3 Hide(Transform target, List<Transform> obstacles)
    {
        //TODO
        return Vector3.zero;
    }

     void DrawVelocityAndSteering()
    {

        lineSteeringScript.position = transform.position + velocity;
        lineSteeringScript.steering = steering;
        
        lineDesiredDirectionScript.position = transform.position;
        lineDesiredDirectionScript.steering = desired;

        lineyVelocity.positionCount = 2;
        lineyVelocity.SetPosition(0, transform.position);
        lineyVelocity.SetPosition(1, transform.position + velocity);
    
    }    
}
