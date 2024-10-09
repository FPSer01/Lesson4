using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class InteractableHelper : MonoBehaviour
{
    public float yOffset;
    public Canvas helpPromptPrefab; // Prefab
    Canvas help; // Current object

    public bool enableHelp = false;

    BoxCollider col;

    void Awake()
    {
        col = GetComponent<BoxCollider>();

        if (transform.localScale.magnitude > 1)
        {

        }

        help = Instantiate(
            helpPromptPrefab,
            transform.position + col.center + new Vector3(
                0,
                yOffset, 
                0),
            Quaternion.Euler(0,0,0));

        help.GetComponentInChildren<TMP_Text>().text = gameObject.name;

        help.enabled = enableHelp; // Turn off canvas
    }

    void Update()
    {
        help.transform.LookAt(Camera.main.transform, Vector3.up);

        help.enabled = enableHelp;
    }
}
