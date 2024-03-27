using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class InteractableBox : MonoBehaviour
{
    [SerializeField] private bool inRange;
    [SerializeField] private KeyCode interactKey;
    [SerializeField] private UnityEvent interacAction;
    private PlayerController player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(interactKey) && player.isLookingAtInteractable(gameObject))
        {
            Debug.Log("Interaction");
            interacAction.Invoke();
        }
    }
}
