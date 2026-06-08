using UnityEngine;

public class ScrollWheelInput : MonoBehaviour
{
	[SerializeField]
	private FloatEvent onScrollMouseWheelOverTileSlot;

	[SerializeField]
	private FloatEvent onScrollMouseWheelOverOtherThanTileSlot;

	private MouseController mouseController;

	private void Start()
	{
		mouseController = GetComponent<MouseController>();
	}

	private void Update()
	{
		if (!(Input.mouseScrollDelta.magnitude <= 0.001f))
		{
			float arg = Mathf.Clamp(Input.mouseScrollDelta.y, -1f, 1f);
			if ((bool)mouseController.currentTileSlot)
			{
				onScrollMouseWheelOverTileSlot?.Invoke(arg);
			}
			else
			{
				onScrollMouseWheelOverOtherThanTileSlot?.Invoke(arg);
			}
		}
	}
}
