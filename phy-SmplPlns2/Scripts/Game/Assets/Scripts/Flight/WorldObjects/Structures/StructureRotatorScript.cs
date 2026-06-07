using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Structures
{
	public class StructureRotatorScript : MonoBehaviour
	{
		[SerializeField]
		private float _range = -1f;

		[SerializeField]
		private float _speed = 1f;

		[SerializeField]
		private float _startOffset;

		[SerializeField]
		private Vector3 _axis = Vector3.up;

		private Quaternion _localRotation;

		protected virtual void Start()
		{
			_localRotation = base.transform.localRotation;
		}

		protected virtual void FixedUpdate()
		{
			float num = _startOffset + _speed * (FlightSceneScript.Instance?.FlightSceneNetwork?.PhysicsTime ?? Time.timeSinceLevelLoad);
			if (_range > 0f)
			{
				num = Mathf.PingPong(num, 2f * _range) - _range;
			}
			base.transform.localRotation = _localRotation * Quaternion.AngleAxis(num, _axis);
		}
	}
}
