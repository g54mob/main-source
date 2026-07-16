using UnityEngine;
using UnityEngine.EventSystems;

public class RayCaster : MonoBehaviour
{
	[SerializeField]
	private LayerMask castMask;

	[SerializeField]
	private float snapping = 1f;

	private static RayCaster instance;

	private GameObject castedObject;

	private void OnDrawGizmos()
	{
		if (GlobalReferences.IsValidated())
		{
			Ray ray = GlobalReferences.GetCameraController().GetCamera().ScreenPointToRay(InputManager.GetPointerPosition());
			if (Physics.Raycast(ray, 3f))
			{
				Gizmos.color = Color.green;
			}
			else
			{
				Gizmos.color = Color.yellow;
			}
			Gizmos.DrawRay(ray.origin, ray.direction * 3f);
		}
	}

	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(this);
		}
		Object.DontDestroyOnLoad(instance);
	}

	public static bool IsValidated()
	{
		return instance != null;
	}

	public static void Activate()
	{
		instance.enabled = true;
	}

	public static void Deactivate()
	{
		instance.enabled = false;
	}

	public static void SetSnap(float snap)
	{
		instance.snapping = snap;
	}

	public static Vector3 GetSnappedPosition(Vector3 position)
	{
		float x = Mathf.Round(position.x / instance.snapping) * instance.snapping;
		Mathf.Round(position.y / instance.snapping);
		_ = instance.snapping;
		return new Vector3(z: Mathf.Round(position.z / instance.snapping) * instance.snapping, x: x, y: position.y);
	}

	public static LayerMask GetDefaultMask()
	{
		return instance.castMask;
	}

	public static GameObject GetCastedFromHitPointed()
	{
		return instance.castedObject;
	}

	public static Vector3 GetHitPointPosition(float length = 100f, bool snapY = false)
	{
		Vector3 result = Vector3.zero;
		Ray ray = GlobalReferences.GetCameraController().GetCamera().ScreenPointToRay(InputManager.GetPointerPosition());
		bool flag = EventSystem.current.IsPointerOverGameObject();
		if (Physics.Raycast(ray, out var hitInfo, length, instance.castMask) && !flag)
		{
			result = hitInfo.point;
		}
		return result;
	}

	public static Vector3 GetHitPointPosition(float length, LayerMask layerMask)
	{
		Vector3 result = Vector3.zero;
		Ray ray = GlobalReferences.GetCameraController().GetCamera().ScreenPointToRay(InputManager.GetPointerPosition());
		bool flag = EventSystem.current.IsPointerOverGameObject();
		if (Physics.Raycast(ray, out var hitInfo, length, layerMask) && !flag)
		{
			result = hitInfo.point;
		}
		return result;
	}

	public static Vector3 GetMouseHitPoint(float length = 1000f, bool snapY = false)
	{
		Vector3 result = Vector3.zero;
		if (Physics.Raycast(CameraManager.GetActiveCamera().ScreenPointToRay(InputManager.GetPointerPosition()), out var hitInfo, length, instance.castMask))
		{
			result = hitInfo.point;
		}
		return result;
	}

	public static GameObject GetHitObject(float length = 3f, int layer = 0)
	{
		if (GameStateManager.GetCurrentCharacterState() == GameStateManager.CharacterState.MenuOpen)
		{
			return null;
		}
		GameObject result = null;
		Ray ray = GlobalReferences.GetCameraController().GetCamera().ScreenPointToRay(InputManager.GetPointerPosition());
		bool flag = InputManager.PointerOverUIElement();
		if (Physics.Raycast(ray, out var hitInfo, length, layer) && !flag)
		{
			result = hitInfo.collider.gameObject;
		}
		return result;
	}

	public static GameObject GetHitObject(float length, LayerMask layerMask)
	{
		if (GameStateManager.GetCurrentCharacterState() == GameStateManager.CharacterState.MenuOpen)
		{
			return null;
		}
		GameObject result = null;
		Ray ray = GlobalReferences.GetCameraController().GetCamera().ScreenPointToRay(InputManager.GetPointerPosition());
		bool flag = InputManager.PointerOverUIElement();
		if (Physics.Raycast(ray, out var hitInfo, length, layerMask) && !flag)
		{
			result = hitInfo.collider.gameObject;
		}
		return result;
	}

	public static RaycastHitPointInfo GetHitInfo(float length, LayerMask layerMask)
	{
		if (GameStateManager.GetCurrentCharacterState() == GameStateManager.CharacterState.MenuOpen)
		{
			return null;
		}
		RaycastHitPointInfo raycastHitPointInfo = new RaycastHitPointInfo();
		Ray ray = GlobalReferences.GetCameraController().GetCamera().ScreenPointToRay(InputManager.GetPointerPosition());
		bool flag = InputManager.PointerOverUIElement();
		if (Physics.Raycast(ray, out var hitInfo, length, layerMask) && !flag)
		{
			raycastHitPointInfo.castedObject = hitInfo.collider.gameObject;
			raycastHitPointInfo.hitPointPosition = hitInfo.point;
			raycastHitPointInfo.hitPointNormal = hitInfo.normal;
		}
		return raycastHitPointInfo;
	}

	public static GameObject GetBoxCastHitObject(Vector3 origin, Vector3 size, Vector3 direction, float length = 10f, int layerMask = 0, GameObject ignore = null)
	{
		if (GameStateManager.GetCurrentCharacterState() == GameStateManager.CharacterState.MenuOpen)
		{
			return null;
		}
		GameObject result = null;
		Color color = Color.green;
		if (Physics.BoxCast(origin, size, direction, out var hitInfo, Quaternion.LookRotation(direction, Vector3.up), length, layerMask))
		{
			result = hitInfo.collider.gameObject;
			color = Color.red;
		}
		ExtDebug.DrawBoxCastBox(origin, size, Quaternion.LookRotation(direction, Vector3.up), direction, length, color);
		return result;
	}

	public static GameObject GetSphereCastHitObject(Vector3 position, float radius, Vector3 direction, float length = 10f, int layerMask = 0)
	{
		if (GameStateManager.GetCurrentCharacterState() == GameStateManager.CharacterState.MenuOpen)
		{
			return null;
		}
		GameObject result = null;
		_ = Color.green;
		if (Physics.SphereCast(position, radius, direction, out var hitInfo, length, layerMask, QueryTriggerInteraction.Collide))
		{
			result = hitInfo.collider.gameObject;
			_ = Color.red;
		}
		return result;
	}
}
