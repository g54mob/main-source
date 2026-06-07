using System.Collections;
using DV.OriginShift;
using DV.Utils;
using UnityEngine;

public static class WorldTeleportTool
{
	public static IEnumerator TeleportToNormalizedCoordinatesNonVR(float x, float z)
	{
		if (VRManager.IsVREnabled())
		{
			Debug.LogError("Teleport to coordinates is only supported in Non-VR.");
			yield break;
		}
		x = Mathf.Clamp01(x);
		z = Mathf.Clamp01(z);
		Transform player = PlayerManager.PlayerTransform;
		CharacterReparenting component = player.GetComponent<CharacterReparenting>();
		if (component != null)
		{
			component.ReparentTo(null);
		}
		else
		{
			Debug.LogWarning("CharacterReparenting not found. This could cause player destruction on teleport!");
		}
		if (SingletonBehaviour<LevelInfo>.Instance == null)
		{
			Debug.LogError("WorldTeleportTool can't find LevelInfo instance, aborting.");
			yield break;
		}
		Vector3 worldSize = SingletonBehaviour<LevelInfo>.Instance.worldSize;
		player.SetAbsolutePosition(new Vector3(x * worldSize.x, player.position.y, z * worldSize.z));
		CustomFirstPersonController ctrl = player.GetComponent<CustomFirstPersonController>();
		CameraSmoothing bob = player.GetComponentInParent<CameraSmoothing>();
		bob.canSmooth = false;
		ctrl.isRepositioning = true;
		int terrainMask = LayerMask.GetMask("Terrain");
		int iterationCounter = 0;
		int maxIteration = 30;
		float sphereRadius = 1f;
		RaycastHit hitInfo;
		while (!Physics.SphereCast(new Vector3(player.position.x, 5000f, player.position.z), sphereRadius, Vector3.down, out hitInfo, 10000f, terrainMask, QueryTriggerInteraction.Ignore) && iterationCounter < maxIteration)
		{
			iterationCounter++;
			yield return null;
		}
		if (iterationCounter < maxIteration)
		{
			if (Physics.SphereCast(new Vector3(player.position.x, 5000f, player.position.z), sphereRadius, Vector3.down, out hitInfo, 10000f, LayerMask.GetMask("Terrain", "Water", "Default"), QueryTriggerInteraction.Ignore))
			{
				Vector3 point = hitInfo.point;
				point.y += 2f;
				player.position = point;
			}
			else
			{
				player.position = new Vector3(player.position.x, 2500f, player.position.z);
			}
		}
		else
		{
			player.position = new Vector3(player.position.x, 2500f, player.position.z);
		}
		yield return null;
		ctrl.isRepositioning = false;
		bob.canSmooth = true;
	}
}
