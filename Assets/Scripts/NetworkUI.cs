using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class NetworkUI : MonoBehaviour
{
    [SerializeField] private Button host;
    [SerializeField] private Button client;

    void Awake()
    {
        host.onClick.AddListener(() => NetworkManager.Singleton.StartHost());
        client.onClick.AddListener(() => NetworkManager.Singleton.StartClient());
    }
}
