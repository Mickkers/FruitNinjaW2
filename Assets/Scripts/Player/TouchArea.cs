using System;
using UnityEngine;

public class TouchArea : MonoBehaviour
{
    private Collider col;
    private TrailRenderer trail;

    [SerializeField] private float slicePower;

    private Vector3 pos;
    private Vector3 lastPos;

    public Vector3 direction { get; private set; }
    private float velocity;

    private bool firstUpdate;
    private bool isClicked;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
        trail = GetComponentInChildren<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove())
        {
            BladeEnabled();
        }
        else
        {
            BladeDisabled();
        }
    }

    private void BladeDisabled()
    {
        col.enabled = false;
        trail.enabled = false;
        firstUpdate = true;
    }

    private void BladeEnabled()
    {
        transform.position = Camera.main.ScreenToWorldPoint(pos);
        col.enabled = true;
        trail.enabled = true;
        if (firstUpdate)
        {
            firstUpdate = false;
            trail.Clear();
        }
    }

    private bool CanMove()
    {
        return isClicked && velocity >= 0;
    }

    public void SetValues(Vector3 position, bool val)
    {
        lastPos = pos;
        pos = position;
        isClicked = val;
        pos.z = 13;

        direction = pos - lastPos;
        velocity = direction.magnitude / Time.deltaTime;
    }

    public float GetSlicePower()
    {
        return slicePower;
    }
}
