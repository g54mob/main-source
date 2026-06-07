using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Structures
{
	public class PumpjackWirelineScript : MonoBehaviour
	{
		[SerializeField]
		private float _multiplier = 0.9f;

		[SerializeField]
		private Transform _wireline;

		[SerializeField]
		private Transform _wirelineAnchor;

		[SerializeField]
		private Vector3 _wirelineScaleAxis = Vector3.forward;

		[SerializeField]
		private float _wirelineZeroDistance;

		protected void LateUpdate()
		{
			float wirelineDistance = GetWirelineDistance();
			_wireline.localScale = Vector3.one + _wirelineScaleAxis * (wirelineDistance / _wirelineZeroDistance * _multiplier);
		}

		private float GetWirelineDistance()
		{
			Vector3 vector = _wireline.localPosition - base.transform.InverseTransformPoint(_wirelineAnchor.position);
			vector.Scale(_wirelineScaleAxis);
			return vector.magnitude - _wirelineZeroDistance;
		}

		[ContextMenu("SetZeroDistance")]
		private void SetWirelineZeroDistance()
		{
			_wirelineZeroDistance = 0f;
			_wirelineZeroDistance = GetWirelineDistance();
		}
	}
}
