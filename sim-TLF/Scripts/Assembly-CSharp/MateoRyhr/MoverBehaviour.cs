using UnityEngine;

namespace MateoRyhr
{
	public abstract class MoverBehaviour : MonoBehaviour, IMovementStatus
	{
		[SerializeField]
		private protected GameObject _directionGameObject;

		[SerializeField]
		private protected FloatVariable _maxSpeed;

		private protected IMover _mover;

		private protected IVector2 _direction;

		public bool CanMove { get; set; }

		private protected virtual void Awake()
		{
			_direction = _directionGameObject.GetComponent<IVector2>();
		}
	}
}
