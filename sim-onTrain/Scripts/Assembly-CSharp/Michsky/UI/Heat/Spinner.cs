using UnityEngine;

namespace Michsky.UI.Heat
{
	[AddComponentMenu("Heat UI/Animation/Spinner")]
	public class Spinner : MonoBehaviour
	{
		public enum Direction
		{
			Clockwise = 0,
			CounterClockwise = 1
		}

		[Header("Resources")]
		[SerializeField]
		private RectTransform objectToSpin;

		[Header("Settings")]
		[SerializeField]
		[Range(0.1f, 50f)]
		private float speed = 10f;

		[SerializeField]
		private Direction direction;

		private float currentPos;

		private void Awake()
		{
			if (objectToSpin == null)
			{
				base.enabled = false;
			}
		}

		private void Update()
		{
			if (direction == Direction.Clockwise)
			{
				currentPos -= speed * 100f * Time.unscaledDeltaTime;
				if (currentPos >= 360f)
				{
					currentPos = 0f;
				}
			}
			else if (direction == Direction.CounterClockwise)
			{
				currentPos += speed * 100f * Time.unscaledDeltaTime;
				if (currentPos <= -360f)
				{
					currentPos = 0f;
				}
			}
			objectToSpin.localRotation = Quaternion.Euler(0f, 0f, currentPos);
		}
	}
}
