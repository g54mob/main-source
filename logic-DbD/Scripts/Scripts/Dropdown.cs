using UnityEngine;
using UnityEngine.InputSystem;

public class Dropdown : MonoBehaviour
{
	private PlayerInput panelInput;

	private Canvas canvas;

	private void Awake()
	{
		panelInput = GetComponent<PlayerInput>();
	}

	private void Start()
	{
		canvas = UIUtils.FindCanvasFromChild(base.transform);
		panelInput.actions["Click"].performed += CheckCloseDropdown;
	}

	private void CheckCloseDropdown(InputAction.CallbackContext context)
	{
		Debug.Log("Clicked");
		Vector2 vector = Mouse.current.position.ReadValue();
		float width = GetWidth();
		float height = GetHeight();
		Vector3 vector2 = Camera.main.WorldToScreenPoint(base.transform.position);
		Vector3 vector3 = vector2 + new Vector3(width, 0f - height) * canvas.scaleFactor;
		if (!(vector.x >= vector2.x) || !(vector.x <= vector3.x) || !(vector.y <= vector2.y) || !(vector.y >= vector3.y))
		{
			DestroyDropdown();
		}
	}

	public void DestroyDropdown()
	{
		panelInput.actions["Click"].performed -= CheckCloseDropdown;
		Object.Destroy(base.gameObject);
	}

	private float GetWidth()
	{
		if (!base.transform || base.transform.childCount <= 0)
		{
			return 0f;
		}
		return ((RectTransform)base.transform.GetChild(0)).rect.width;
	}

	private float GetHeight()
	{
		float num = 0f;
		foreach (RectTransform item in base.transform)
		{
			num += item.rect.height;
		}
		return num;
	}
}
