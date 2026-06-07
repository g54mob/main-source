using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Structures
{
	public class KunimitsuTerminalDoorSectionScript : MonoBehaviour
	{
		private Vector3 _closedPosition;

		private Vector3 _closedRotation;

		private float _openPercentage;

		[SerializeField]
		private Vector3 _openPosition;

		[SerializeField]
		private Vector3 _openRotation;

		public float OpenPercentage
		{
			get
			{
				return _openPercentage;
			}
			set
			{
				_openPercentage = value;
				base.transform.localPosition = Vector3.Lerp(_closedPosition, _openPosition, value);
				base.transform.localRotation = Quaternion.Lerp(Quaternion.Euler(_closedRotation), Quaternion.Euler(_openRotation), value);
			}
		}

		protected void Awake()
		{
			_closedPosition = base.transform.localPosition;
			_closedRotation = base.transform.localEulerAngles;
		}
	}
}
