```csharp
using UnityEngine;
using Unity.Netcode;

public class NetworkManagerSetup : MonoBehaviour
{
    public GameObject playerPrefab;

    void Awake()
    {
        if (NetworkManager.Singleton != null && playerPrefab != null)
            NetworkManager.Singleton.NetworkConfig.PlayerPrefab = playerPrefab;
    }

    public void StartHost() => NetworkManager.Singleton.StartHost();
    public void StartClient() => NetworkManager.Singleton.StartClient();
    public void StartServer() => NetworkManager.Singleton.StartServer();
}
