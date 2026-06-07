using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(Graphic))]
public class HotKeyRaycaster : MonoBehaviour
{
	[SerializeField]
	private Transform baseParent;

	private Vector2 screenPos2D;

	private EventSystem eventSystem;

	private Canvas rootCanvas;

	private GraphicRaycaster graphicRaycaster;

	[SerializeField]
	private InputActionReference targetInputActionReference;

	private InputAction targetInputAction;

	[SerializeField]
	private bool _isOnlyDisplay;

	public InputAction GetTargetInputAction()
	{
		return null;
	}

	public void SetAction(string actionMap, string action)
	{
	}

	public void SetAction(InputAction inputAction)
	{
	}

	private void Start()
	{
	}

	private void GetRaycaster()
	{
	}

	private void Update()
	{
	}
}
