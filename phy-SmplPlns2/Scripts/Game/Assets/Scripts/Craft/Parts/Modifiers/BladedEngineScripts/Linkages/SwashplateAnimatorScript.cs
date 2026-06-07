using System;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.BladedEngineScripts.Linkages
{
	public class SwashplateAnimatorScript : MonoBehaviour
	{
		private class MovementGeometryScalars
		{
			public const float Collective = 0.05f;

			public const float Cyclic = 0.5f;
		}

		[SerializeField]
		private Transform _ballPivot;

		private Vector3 _ballPivotLocalPosition;

		private bool _bladeGripHasNinetyDegreeOffset;

		private Func<float> _collective;

		private int _collectiveGripLeadingEdgeAdjustment;

		private int _cyclicAdjustment;

		private Func<float> _cyclicPitch;

		private float _cyclicPitchDeflectionScalar;

		private Func<float> _cyclicRoll;

		private float _cyclicRollDeflectionScalar;

		private bool _initialized;

		private Vector3 _neutralCollectiveLocalPosition;

		private Quaternion _neutralCyclicLocalRotation;

		private Vector3 _neutralCyclicLocalUp;

		private PartScript _partScript;

		public void Initialize(Func<float> collective, Func<float> cyclicPitch, Func<float> cyclicRoll, float maxCyclicPitchDeflection, float maxCyclicRollDeflection, bool bladeGripLeadingEdge, bool bladeGripHasNinetyDegreeOffset, bool clockwiseRotation)
		{
			_collective = collective;
			_cyclicPitch = cyclicPitch;
			_cyclicRoll = cyclicRoll;
			_cyclicPitchDeflectionScalar = maxCyclicPitchDeflection * 0.5f;
			_cyclicRollDeflectionScalar = maxCyclicRollDeflection * 0.5f;
			_bladeGripHasNinetyDegreeOffset = bladeGripHasNinetyDegreeOffset;
			_collectiveGripLeadingEdgeAdjustment = (bladeGripLeadingEdge ? 1 : (-1));
			_cyclicAdjustment = (bladeGripLeadingEdge ? 1 : (-1)) * (clockwiseRotation ? 1 : (-1));
			_neutralCyclicLocalUp = base.transform.parent.InverseTransformDirection(base.transform.up);
			_neutralCyclicLocalRotation = base.transform.localRotation;
			_neutralCollectiveLocalPosition = base.transform.localPosition;
			_ballPivotLocalPosition = base.transform.InverseTransformPoint(_ballPivot.position);
			_initialized = true;
		}

		protected virtual void Start()
		{
			_partScript = GetComponentInParent<PartScript>();
		}

		protected virtual void Update()
		{
			if (_initialized)
			{
				base.transform.localPosition = _neutralCollectiveLocalPosition + _neutralCyclicLocalUp * (_collective() * (float)_collectiveGripLeadingEdgeAdjustment * 0.05f);
				base.transform.localRotation = _neutralCyclicLocalRotation;
				_ballPivot.position = base.transform.TransformPoint(_ballPivotLocalPosition);
				float num = _cyclicPitch() * _cyclicPitchDeflectionScalar * (float)_cyclicAdjustment;
				float num2 = _cyclicRoll() * _cyclicRollDeflectionScalar * (float)_cyclicAdjustment;
				float angle;
				float angle2;
				if (_bladeGripHasNinetyDegreeOffset)
				{
					angle = num;
					angle2 = 0f - num2;
				}
				else
				{
					angle = num2;
					angle2 = 0f - num;
				}
				Vector3 forward = base.transform.forward;
				Vector3 right = base.transform.right;
				Vector3 vector = base.transform.parent.TransformDirection(_neutralCyclicLocalUp);
				Vector3 vector2 = Quaternion.AngleAxis(angle, forward) * Quaternion.AngleAxis(angle2, right) * vector;
				Vector3 forward2 = Vector3.Cross(vector2, -base.transform.right);
				base.transform.rotation = Quaternion.LookRotation(forward2, vector2);
			}
		}
	}
}
