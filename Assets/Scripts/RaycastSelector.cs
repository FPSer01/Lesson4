using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSelector : MonoBehaviour
{
    public float length;

    GameObject obj;
    InteractableHelper obj_help;

    public Transform direction;
    RaycastHit hit;

    [SerializeField] bool isHit; // Debug

    void Update()
    {
        if (Physics.Raycast(direction.position, direction.forward, out hit, Mathf.Infinity)) 
        {
            if (hit.collider != null) // If ray hits
            {
                if (hit.collider.GetComponent<InteractableHelper>() != null) // If hit object has component InteractableHelper
                {
                    if (hit.collider.gameObject != obj && obj != null) // If old obj and current obj have that component
                    {
                        obj_help.enableHelp = false;
                    }

                    // Save hit object and reveal help GUI
                    obj = hit.collider.gameObject;
                    obj_help = obj.GetComponent<InteractableHelper>();
                    obj_help.enableHelp = true;
                }
                else
                {
                    // Hide help GUI on already saved hit object if it exists
                    if (obj != null && obj_help != null)
                    {
                        obj_help.enableHelp = false;
                    }
                }
            }
        }

        isHit = hit.collider != null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(direction.position, direction.position + direction.forward * length);
    }
}
