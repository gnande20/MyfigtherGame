using UnityEngine;
using Unity.Netcode;

public class ArenaManager : NetworkBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform[] spawnPoints;

    public override void OnNetworkSpawn()
    {
        if (IsServer)
        {
            // Quand un joueur rejoint, on le spawn
            NetworkManager.Singleton.OnClientConnectedCallback += SpawnPlayer;
        }
    }

    void SpawnPlayer(ulong clientId)
    {
        Transform spawn = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject player = Instantiate(playerPrefab, spawn.position, spawn.rotation);
        player.GetComponent<NetworkObject>().SpawnAsPlayerObject(clientId);
    }
}
