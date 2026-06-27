using UnityEngine;

namespace Restory.Gameplay.Elements
{
	public class PlacementPositionFinder
	{
		private enum Direction
		{
			Up = 0,
			Right = 1,
			Down = 2,
			Left = 3
		}

		private readonly float step = 0.1f;

		private float positionX;

		private float positionY;

		private float positionZ;

		private bool canMoveUp;

		private bool canMoveRight;

		private bool canMoveDown;

		private bool canMoveLeft;

		private float maxReachedPositionX;

		private float minReachedPositionX;

		private float maxReachedPositionZ;

		private float minReachedPositionZ;

		private Direction direction;

		public Vector3 Position => new Vector3(positionX, positionY, positionZ);

		public bool CanContinue
		{
			get
			{
				if (!canMoveUp && !canMoveRight && !canMoveDown)
				{
					return canMoveLeft;
				}
				return true;
			}
		}

		public bool CanMoveDirection => direction switch
		{
			Direction.Up => positionZ <= maxReachedPositionZ, 
			Direction.Right => positionX <= maxReachedPositionX, 
			Direction.Down => positionZ >= minReachedPositionZ, 
			Direction.Left => positionX >= minReachedPositionX, 
			_ => false, 
		};

		public void Reset(Vector3 initialPosition)
		{
			positionX = initialPosition.x;
			positionY = initialPosition.y;
			positionZ = initialPosition.z;
			canMoveUp = true;
			canMoveRight = true;
			canMoveDown = true;
			canMoveLeft = true;
			maxReachedPositionX = initialPosition.x;
			minReachedPositionX = initialPosition.x;
			maxReachedPositionZ = initialPosition.z;
			minReachedPositionZ = initialPosition.z;
			direction = Direction.Left;
			SwitchDirection();
		}

		public void SwitchDirection()
		{
			switch (direction)
			{
			case Direction.Up:
				SwitchRightDirection();
				break;
			case Direction.Right:
				SwitchDownDirection();
				break;
			case Direction.Down:
				SwitchLeftDirection();
				break;
			case Direction.Left:
				SwitchUpDirection();
				break;
			}
		}

		private void SwitchRightDirection()
		{
			direction = Direction.Right;
			positionZ = maxReachedPositionZ;
			if (canMoveRight)
			{
				maxReachedPositionX += step;
			}
			positionX = (canMoveUp ? (positionX + step) : maxReachedPositionX);
		}

		private void SwitchDownDirection()
		{
			direction = Direction.Down;
			positionX = maxReachedPositionX;
			if (canMoveDown)
			{
				minReachedPositionZ -= step;
			}
			positionZ = (canMoveRight ? (positionZ - step) : minReachedPositionZ);
		}

		private void SwitchLeftDirection()
		{
			direction = Direction.Left;
			positionZ = minReachedPositionZ;
			if (canMoveLeft)
			{
				minReachedPositionX -= step;
			}
			positionX = (canMoveDown ? (positionX - step) : minReachedPositionX);
		}

		private void SwitchUpDirection()
		{
			direction = Direction.Up;
			positionX = minReachedPositionX;
			if (canMoveUp)
			{
				maxReachedPositionZ += step;
			}
			positionZ = (canMoveLeft ? (positionZ + step) : maxReachedPositionZ);
		}

		public void MoveDirection()
		{
			switch (direction)
			{
			case Direction.Up:
				positionZ += step;
				break;
			case Direction.Right:
				positionX += step;
				break;
			case Direction.Down:
				positionZ -= step;
				break;
			case Direction.Left:
				positionX -= step;
				break;
			}
		}

		public void BlockDirection()
		{
			switch (direction)
			{
			case Direction.Up:
				canMoveUp = false;
				maxReachedPositionZ -= step;
				break;
			case Direction.Right:
				canMoveRight = false;
				maxReachedPositionX -= step;
				break;
			case Direction.Down:
				canMoveDown = false;
				minReachedPositionZ += step;
				break;
			case Direction.Left:
				canMoveLeft = false;
				minReachedPositionX += step;
				break;
			}
			SwitchDirection();
		}
	}
}
