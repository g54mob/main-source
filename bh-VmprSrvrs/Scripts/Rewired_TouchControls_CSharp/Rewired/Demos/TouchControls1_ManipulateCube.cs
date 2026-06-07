using UnityEngine;

namespace Rewired.Demos
{
	[AddComponentMenu(null)]
	public class TouchControls1_ManipulateCube : MonoBehaviour
	{
		public float rotateSpeed;

		public float moveSpeed;

		private int currentColorIndex;

		private Color[] colors;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnMoveReceivedX(InputActionEventData data)
		{
		}

		private void OnMoveReceivedY(InputActionEventData data)
		{
		}

		private void OnRotationReceivedX(InputActionEventData data)
		{
		}

		private void OnRotationReceivedY(InputActionEventData data)
		{
		}

		private void OnCycleColor(InputActionEventData data)
		{
		}

		private void OnCycleColorReverse(InputActionEventData data)
		{
		}

		private void OnMoveReceived(Vector2 move)
		{
		}

		private void OnRotationReceived(Vector2 rotate)
		{
		}

		private void OnCycleColor()
		{
		}

		private void OnCycleColorReverse()
		{
		}
	}
}
