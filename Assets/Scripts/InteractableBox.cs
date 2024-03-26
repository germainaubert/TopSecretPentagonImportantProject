using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class InteracatableBox : MonoBehaviour
{
    [SerializeField] private bool inRange;
    [SerializeField] private KeyCode interactKey;
    [SerializeField] private UnityEvent interacAction;

    // Update is called once per frame
    void Update()
    {
        if(inRange && Input.GetKeyDown(interactKey))
        {
            interacAction.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inRange = collision.gameObject.CompareTag("Player");
    }
}
