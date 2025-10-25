using UnityEngine;
using Unity.Netcode;

public class PlayerNetwork : NetworkBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody rb;
    private Vector3 inputVector;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Seul le joueur local contrôle son propre personnage
        if (!IsOwner) return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        inputVector = new Vector3(h, 0, v);
    }

    void FixedUpdate()
    {
        if (!IsOwner) return;
        rb.MovePosition(rb.position + inputVector * moveSpeed * Time.fixedDeltaTime);
    }
}
