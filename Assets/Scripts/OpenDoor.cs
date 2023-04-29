using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private LayerMask _doorLayer;
    [SerializeField] private Camera _camera;
    
    void Update()
    {
        var ray = new Ray(_camera.transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 50, Color.green);

        if (Physics.Raycast(ray, out var hitInfo,_doorLayer))
        {
            var door = hitInfo.collider.gameObject.GetComponent<Door>();

            if (door != null && Input.GetKeyDown(KeyCode.E))
            {
                door.SwitchDoorState();
            }
        }
        
    }
}
