using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.Feel
{
	[AddComponentMenu("")]
	public class FeelSpringsCellMovementDemo : MonoBehaviour
	{
		protected enum Directions
		{
			Left = 0,
			Right = 1,
			Up = 2,
			Down = 3
		}

		[Header("Spring")]
		public MMSpringPosition MovementSpring;

		public MMSpringRotation RotationSpring;

		public MMSpringScale ScaleSpring;

		[Header("Bindings")]
		public FeelSpringsDemoSlider DampingSlider;

		public FeelSpringsDemoSlider FrequencySlider;

		public MMFeedbacks MoveFeedback;

		protected Vector3 _newPosition;

		protected float _cellWidth = 0.125f;

		protected Vector2 _currentPosition;

		protected Vector3 _movementPosition;

		protected virtual void Update()
		{
			UpdateSliderValues();
			HandleInput();
		}

		public virtual void MoveRandomly()
		{
			int direction = Random.Range(0, 4);
			Move((Directions)direction);
		}

		protected virtual void Move(Directions direction)
		{
			ComputeNewGridPosition(direction);
			_movementPosition.x = _currentPosition.x * _cellWidth;
			_movementPosition.y = _currentPosition.y * _cellWidth;
			_movementPosition.z = MovementSpring.Target.transform.localPosition.z;
			MovementSpring.MoveTo(_movementPosition);
			ScaleSpring.Bump(5f * Vector3.one);
			MoveFeedback?.PlayFeedbacks();
		}

		protected virtual void Bump(Directions direction)
		{
			switch (direction)
			{
			case Directions.Left:
				RotationSpring.Bump(new Vector3(0f, 0f, -900f));
				MovementSpring.Bump(new Vector3(4f, 0f, 0f));
				break;
			case Directions.Right:
				RotationSpring.Bump(new Vector3(0f, 0f, 900f));
				MovementSpring.Bump(new Vector3(-4f, 0f, 0f));
				break;
			case Directions.Up:
				RotationSpring.Bump(new Vector3(0f, 0f, 450f));
				MovementSpring.Bump(new Vector3(0f, -4f, 0f));
				break;
			case Directions.Down:
				RotationSpring.Bump(new Vector3(0f, 0f, -450f));
				MovementSpring.Bump(new Vector3(0f, 4f, 0f));
				break;
			}
		}

		protected virtual void ComputeNewGridPosition(Directions direction)
		{
			switch (direction)
			{
			case Directions.Left:
				_currentPosition.x -= 1f;
				break;
			case Directions.Right:
				_currentPosition.x += 1f;
				break;
			case Directions.Up:
				_currentPosition.y += 1f;
				break;
			case Directions.Down:
				_currentPosition.y -= 1f;
				break;
			}
			if (_currentPosition.x < -3f)
			{
				_currentPosition.x = -3f;
				Bump(Directions.Left);
			}
			else if (_currentPosition.x > 3f)
			{
				_currentPosition.x = 3f;
				Bump(Directions.Right);
			}
			else if (_currentPosition.y < -3f)
			{
				_currentPosition.y = -3f;
				Bump(Directions.Down);
			}
			else if (_currentPosition.y > 3f)
			{
				_currentPosition.y = 3f;
				Bump(Directions.Up);
			}
		}

		protected virtual void HandleInput()
		{
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				Move(Directions.Left);
			}
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				Move(Directions.Right);
			}
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				Move(Directions.Down);
			}
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				Move(Directions.Up);
			}
		}

		protected virtual void UpdateSliderValues()
		{
			MovementSpring.SpringVector3.SetDamping(DampingSlider.value * Vector3.one);
			MovementSpring.SpringVector3.SetFrequency(FrequencySlider.value * Vector3.one);
		}
	}
}
