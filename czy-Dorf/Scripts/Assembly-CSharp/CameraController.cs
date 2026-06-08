using UnityEngine;

public class CameraController : MonoBehaviour
{
	private CameraMovement cameraMovement;

	private CameraRotator cameraRotator;

	private CameraZoom cameraZoom;

	[SerializeField]
	private float panningBoundsRadius = 10f;

	[SerializeField]
	private WorldBounds worldBounds;

	[SerializeField]
	private InputRouter inputRouter;

	private void Awake()
	{
		cameraMovement = GetComponent<CameraMovement>();
		cameraRotator = GetComponent<CameraRotator>();
		cameraZoom = GetComponent<CameraZoom>();
	}

	public Vector3 ClampToWorldBounds(Vector3 targetPos, out float distanceToPanningBounds)
	{
		if (!worldBounds)
		{
			distanceToPanningBounds = 0f;
			return targetPos;
		}
		Vector3 vector = targetPos;
		Vector2 vector2 = new Vector2(targetPos.x, targetPos.z);
		Vector2 vector3 = MathUtility.ClosestPointInRect(vector2, worldBounds.Bounds);
		float num = Vector2.Distance(vector2, vector3);
		if (num > panningBoundsRadius)
		{
			vector2 = vector3 + (vector2 - vector3).normalized * panningBoundsRadius;
		}
		distanceToPanningBounds = panningBoundsRadius - num;
		return new Vector3(vector2.x, vector.y, vector2.y);
	}
}
