using UnityEngine;

public class SteamVR_Teleporter : MonoBehaviour
{
	public enum TeleportType
	{
		TeleportTypeUseTerrain = 0,
		TeleportTypeUseCollider = 1,
		TeleportTypeUseZeroY = 2
	}

	public bool teleportOnClick;

	public TeleportType teleportType = TeleportType.TeleportTypeUseZeroY;

	private Transform reference
	{
		get
		{
			SteamVR_Camera steamVR_Camera = SteamVR_Render.Top();
			if (!(steamVR_Camera != null))
			{
				return null;
			}
			return steamVR_Camera.origin;
		}
	}

	private void Start()
	{
		SteamVR_TrackedController steamVR_TrackedController = GetComponent<SteamVR_TrackedController>();
		if (steamVR_TrackedController == null)
		{
			steamVR_TrackedController = base.gameObject.AddComponent<SteamVR_TrackedController>();
		}
		steamVR_TrackedController.TriggerClicked += DoClick;
		if (teleportType == TeleportType.TeleportTypeUseTerrain)
		{
			Transform transform = reference;
			if (transform != null)
			{
				transform.position = new Vector3(transform.position.x, Terrain.activeTerrain.SampleHeight(transform.position), transform.position.z);
			}
		}
	}

	private void DoClick(object sender, ClickedEventArgs e)
	{
		if (!teleportOnClick)
		{
			return;
		}
		Transform transform = reference;
		if (!(transform == null))
		{
			float y = transform.position.y;
			Plane plane = new Plane(Vector3.up, 0f - y);
			Ray ray = new Ray(base.transform.position, base.transform.forward);
			bool flag = false;
			float enter = 0f;
			if (teleportType == TeleportType.TeleportTypeUseTerrain)
			{
				flag = Terrain.activeTerrain.GetComponent<TerrainCollider>().Raycast(ray, out var hitInfo, 1000f);
				enter = hitInfo.distance;
			}
			else if (teleportType == TeleportType.TeleportTypeUseCollider)
			{
				flag = Physics.Raycast(ray, out var hitInfo2);
				enter = hitInfo2.distance;
			}
			else
			{
				flag = plane.Raycast(ray, out enter);
			}
			if (flag)
			{
				Vector3 vector = new Vector3(SteamVR_Render.Top().head.position.x, y, SteamVR_Render.Top().head.position.z);
				transform.position = transform.position + (ray.origin + ray.direction * enter) - vector;
			}
		}
	}
}
