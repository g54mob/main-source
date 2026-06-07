using UnityEngine;

public class PassageSpout : MonoBehaviour
{
	public GameObject bridgeRoot;

	public GameObject tunnelRoot;

	public MeshFilter dryingTunnelMesh;

	public MeshRenderer dryingTunnelRenderer;

	public void ShowBridge()
	{
		bridgeRoot.SetActive(value: true);
		tunnelRoot.SetActive(value: false);
		dryingTunnelRenderer.enabled = false;
	}

	public void ShowTunnel()
	{
		bridgeRoot.SetActive(value: false);
		tunnelRoot.SetActive(value: true);
		dryingTunnelRenderer.enabled = false;
	}

	public void ShowDryingTunnel(MaterialPropertyBlock propertyBlock)
	{
		dryingTunnelRenderer.enabled = true;
		dryingTunnelRenderer.SetPropertyBlock(propertyBlock);
	}

	public void HideDryingTunnel()
	{
		dryingTunnelRenderer.enabled = false;
	}
}
