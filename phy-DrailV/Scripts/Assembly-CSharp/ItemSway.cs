using System.Collections;
using DV;
using DV.Player;
using DV.UI;
using DV.UI.Inventory;
using DV.Utils;
using UnityEngine;

[ExecuteBefore(typeof(ItemPositionController))]
public class ItemSway : MonoBehaviour, ItemPositionController.IPositionProvider
{
	private const string X_AXIS = "Mouse X";

	private const string Y_AXIS = "Mouse Y";

	[Tooltip("X is FOV")]
	public AnimationCurve positionIntensity;

	[Tooltip("X is FOV")]
	public AnimationCurve rotationIntensity;

	[Tooltip("X is FOV")]
	public AnimationCurve itemDistance;

	public Vector2 itemOffsetXY;

	public CameraZoom zoom;

	public float smoothing;

	private Vector3 targetPosition;

	private HotbarController hotbarController;

	private float sensitivity;

	private float fov;

	private Vector3 desiredLocalPosition;

	private Quaternion desiredLocalRotation = Quaternion.identity;

	private float fovOffset;

	private ItemPositionController itemPositionController;

	public int Priority => 0;

	public (Vector3 pos, Quaternion rot, float overridePreviousPerc) GetPose(Vector3 pos, Quaternion rot)
	{
		pos += desiredLocalPosition;
		rot *= desiredLocalRotation;
		pos += rot * new Vector3(itemOffsetXY.x, itemOffsetXY.y, fovOffset);
		return (pos: pos, rot: rot, overridePreviousPerc: 1f);
	}

	private IEnumerator Start()
	{
		GamePreferences.RegisterToPreferenceUpdated(Preferences.MouseSensitivity, OnMouseSensChanged);
		GamePreferences.RegisterToPreferenceUpdated(Preferences.FieldOfView, OnFieldOfViewChanged);
		itemPositionController = GetComponentInParent<ItemPositionController>();
		itemPositionController.Add(this);
		OnMouseSensChanged();
		OnFieldOfViewChanged();
		while (SingletonBehaviour<HotbarController>.Instance == null || !SingletonBehaviour<HotbarController>.Instance.LoadingFinished)
		{
			yield return null;
		}
		hotbarController = SingletonBehaviour<HotbarController>.Instance;
	}

	private void OnMouseSensChanged()
	{
		sensitivity = GamePreferences.Get<float>(Preferences.MouseSensitivity);
	}

	private void OnFieldOfViewChanged()
	{
		fov = GamePreferences.Get<float>(Preferences.FieldOfView);
		fovOffset = itemDistance.Evaluate(fov);
	}

	private void Update()
	{
		if (!(hotbarController == null) && !SingletonBehaviour<AppUtil>.Instance.IsTimePaused && !SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Blockers))
		{
			float num = Input.GetAxis("Mouse X") * sensitivity;
			float num2 = Input.GetAxis("Mouse Y") * sensitivity;
			int num3 = ((!SingletonBehaviour<ScreenspaceMouse>.Instance.on && !zoom.IsMouseZoomedIn && !hotbarController.IsOpen && !hotbarController.provider.IsBigInventoryOpen) ? 1 : 0);
			float num4 = positionIntensity.Evaluate(fov);
			float num5 = rotationIntensity.Evaluate(fov);
			targetPosition.x = (0f - num) * num4 * (float)num3;
			targetPosition.y = (0f - num2) * num4 * (float)num3;
			Quaternion quaternion = Quaternion.AngleAxis((0f - num5) * num * (float)num3, Vector3.up);
			Quaternion quaternion2 = Quaternion.AngleAxis(num5 * num2 * (float)num3, Vector3.right);
			Quaternion b = quaternion * quaternion2;
			float t = Time.deltaTime * smoothing;
			desiredLocalPosition = Vector3.Lerp(desiredLocalPosition, targetPosition, t);
			desiredLocalRotation = Quaternion.Lerp(desiredLocalRotation, b, t);
		}
	}

	private void OnDestroy()
	{
		if (itemPositionController != null)
		{
			itemPositionController.Remove(this);
		}
		GamePreferences.UnregisterFromPreferenceUpdated(Preferences.MouseSensitivity, OnMouseSensChanged);
		GamePreferences.UnregisterFromPreferenceUpdated(Preferences.FieldOfView, OnFieldOfViewChanged);
	}
}
