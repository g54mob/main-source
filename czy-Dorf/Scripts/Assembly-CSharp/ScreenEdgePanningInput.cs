using UnityEngine;

public class ScreenEdgePanningInput : MonoBehaviour
{
	[SerializeField]
	private Vector2Event onMouseCursorCloseToBorder;

	[SerializeField]
	private Vector2 screenPanBorder = new Vector2(0.1f, 0.1f);

	[SerializeField]
	private AnimationCurve screenBorderProximityToPanningSpeed;

	private Vector2 screenPanMinBounds;

	private Vector2 screenPanMaxBounds;

	private void Start()
	{
		CalculatePanBounds();
	}

	private void Update()
	{
		Vector2 arg = DeterminePanningDirection();
		if (arg.magnitude > 0f)
		{
			onMouseCursorCloseToBorder?.Invoke(arg);
		}
	}

	private Vector2 DeterminePanningDirection()
	{
		Vector3 mousePosition = Input.mousePosition;
		Vector2 zero = Vector2.zero;
		if (mousePosition.x < screenPanMinBounds.x)
		{
			float time = 1f - mousePosition.x / screenPanMinBounds.x;
			zero += Vector2.left * screenBorderProximityToPanningSpeed.Evaluate(time);
		}
		if (mousePosition.x > screenPanMaxBounds.x)
		{
			float time2 = 1f - ((float)Screen.width - mousePosition.x) / screenPanMinBounds.x;
			zero += Vector2.right * screenBorderProximityToPanningSpeed.Evaluate(time2);
		}
		if (mousePosition.y < screenPanMinBounds.y)
		{
			float time3 = 1f - mousePosition.y / screenPanMinBounds.y;
			zero += Vector2.down * screenBorderProximityToPanningSpeed.Evaluate(time3);
		}
		if (mousePosition.y > screenPanMaxBounds.y)
		{
			float time4 = 1f - ((float)Screen.height - mousePosition.y) / screenPanMinBounds.y;
			zero += Vector2.up * screenBorderProximityToPanningSpeed.Evaluate(time4);
		}
		return zero;
	}

	private void CalculatePanBounds()
	{
		screenPanMinBounds = new Vector2((float)Screen.width * screenPanBorder.x, (float)Screen.height * screenPanBorder.y);
		screenPanMaxBounds = new Vector2((float)Screen.width - (float)Screen.width * screenPanBorder.x, (float)Screen.height - (float)Screen.height * screenPanBorder.y);
	}
}
