using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private LayerMask _handsLayer;
    [SerializeField] private Camera _camera;

    private InteractableItem _interactable;
    
    void Update()
    {
        var ray = new Ray(_camera.transform.position, transform.forward);

        if (Physics.Raycast(ray, out var hitInfo, _handsLayer))
        {
                _interactable = hitInfo.collider.gameObject.GetComponent<InteractableItem>();
                if (_interactable != null)
                {
                    _interactable.SetFocus();
                }
            
        }
        else
        {
            if (_interactable != null)
            {
                _interactable.RemoveFocus();
            }
        }
    }
}