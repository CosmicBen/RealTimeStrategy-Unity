using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourcesDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text resourcesText = null;

    private RtsPlayer player = null;

    private void Start()
    {
        player = NetworkClient.connection.identity.GetComponent<RtsPlayer>();
        ClientHandleResourcesUpdated(player.GetResources());
        player.ClientOnResourcesUpdate += ClientHandleResourcesUpdated;
    }

    private void OnDestroy()
    {
        player.ClientOnResourcesUpdate -= ClientHandleResourcesUpdated;
    }

    private void ClientHandleResourcesUpdated(int resources)
    {
        resourcesText.text = $"Resources: {resources}";
    }
}
