using UnityEngine;

public class OctopusTeleportLocation : EntityMonoBehaviour
{
	public MeshRenderer rippleRenderer;

	public override void OnOccupied()
	{
		base.OnOccupied();
		rippleRenderer.transform.rotation = Quaternion.Euler(0f, Random.value * 360f, 0f);
	}
}
