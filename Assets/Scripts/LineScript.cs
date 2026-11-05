using UnityEngine;

public class LineScript : MonoBehaviour
{
    LineRenderer liney;

    public Vector3 position;

    public Vector3 steering;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        liney = GetComponent<LineRenderer>();
        liney.startWidth = 0.1f;
        liney.endWidth = 0.1f;
        liney.material = new Material(Shader.Find("Sprites/Default"));
        liney.startColor = Color.blue;
        liney.endColor = Color.blue;
        liney.sortingOrder = 0;
        liney.sortingLayerName = "Default";

        position = Vector3.zero;
        steering = Vector3.zero;
    }

    public void SetColor(Color color)
    {
        liney.startColor = color;
        liney.endColor = color;
    }

    // Update is called once per frame
    void Update()
    {
        liney.positionCount = 2;
        liney.SetPosition(0, position);
        liney.SetPosition(1, position + steering);
    
    }
}
