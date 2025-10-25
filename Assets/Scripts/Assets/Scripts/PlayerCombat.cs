using UnityEngine;
using Unity.Netcode;

public class PlayerCombat : NetworkBehaviour
{
    public int maxHealth = 100;
    private NetworkVariable<int> currentHealth = new NetworkVariable<int>(100);

    public GameObject hitEffect;

    void Start()
    {
        if (IsServer)
            currentHealth.Value = maxHealth;
    }

    [ServerRpc]
    public void TakeDamageServerRpc(int damage)
    {
        currentHealth.Value -= damage;
        if (currentHealth.Value <= 0)
        {
            currentHealth.Value = 0;
            Die();
        }
    }

    void Die()
    {
        // Simple effet de mort
        Debug.Log($"{gameObject.name} est K.O !");
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!IsOwner) return;

        if (other.CompareTag("Player"))
        {
            // Frappe l’autre joueur
            PlayerCombat target = other.GetComponent<PlayerCombat>();
            if (target != null)
                target.TakeDamageServerRpc(Random.Range(10, 20));
        }
    }
}
