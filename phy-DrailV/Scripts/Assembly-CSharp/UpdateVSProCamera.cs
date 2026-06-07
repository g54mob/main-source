using AwesomeTechnologies.VegetationSystem;
using UnityEngine;

public class UpdateVSProCamera : MonoBehaviour
{
	private Camera prevCamera;

	private void Awake()
	{
		if ((bool)PlayerManager.PlayerCamera)
		{
			Set();
		}
		PlayerManager.PlayerChanged += Set;
	}

	private void OnDestroy()
	{
		PlayerManager.PlayerChanged -= Set;
	}

	private void Set()
	{
		Camera playerCamera = PlayerManager.PlayerCamera;
		if (!playerCamera)
		{
			Debug.LogWarning("UpdateVSProCamera couldn't find player camera!");
			return;
		}
		VegetationSystemPro vegetationSystemPro = Object.FindObjectOfType<VegetationSystemPro>();
		if (!vegetationSystemPro)
		{
			return;
		}
		if (playerCamera == prevCamera)
		{
			Debug.LogWarning("UpdateVSProCamera cameras are the same ('" + prevCamera?.name + "'), not updating", prevCamera);
			return;
		}
		if ((bool)prevCamera)
		{
			Debug.Log("UpdateVSProCamera unassigning old camera '" + prevCamera.name + "'", prevCamera);
			vegetationSystemPro.RemoveCamera(prevCamera);
		}
		if ((bool)playerCamera)
		{
			Debug.Log("UpdateVSProCamera assigning camera '" + playerCamera.name + "'", playerCamera);
			vegetationSystemPro.AddCamera(playerCamera);
		}
		prevCamera = playerCamera;
	}
}
