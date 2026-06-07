using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.BladedEngineScripts.Linkages
{
	public class UpperSwashplateAnimatorScript : MonoBehaviour
	{
		[SerializeField]
		private Transform _lowerSwashplate;

		[SerializeField]
		private Transform _neutralReference;

		private Vector3 _targetOffset;

		protected virtual void Start()
		{
			_targetOffset = _lowerSwashplate.InverseTransformPoint(base.transform.position);
		}

		protected virtual void Update()
		{
			base.transform.position = _lowerSwashplate.position + _lowerSwashplate.TransformVector(_targetOffset);
			base.transform.rotation = _neutralReference.rotation;
			Vector3 normalized = Vector3.Cross(base.transform.up - _lowerSwashplate.up, _lowerSwashplate.up).normalized;
			base.transform.Rotate(normalized, Vector3.Angle(_lowerSwashplate.up, base.transform.up), Space.World);
		}
	}
}
