using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ClickInput : MonoBehaviour
{
	[SerializeField]
	private UnityEvent onClick;

	[SerializeField]
	private UnityEvent onInvertedClick;

	[SerializeField]
	private PointerEventData.InputButton mouseButton;

	[SerializeField]
	private KeyCode invertKey;

	private MouseController mouseController;

	private void Start()
	{
		mouseController = GetComponent<MouseController>();
	}

	private void Update()
	{
		if (Input.GetMouseButtonUp((int)mouseButton) && mouseController.TileRotationAllowed)
		{
			if (Input.GetKey(invertKey))
			{
				onInvertedClick.Invoke();
			}
			else
			{
				onClick.Invoke();
			}
		}
	}
}
