using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class InterpolatedPoseScript : MonoBehaviour
	{
		public enum InterpolationMode
		{
			CentralLateral = 0,
			LeftRight = 1
		}

		public class InterpolatedTransform
		{
			public bool InterpolatePosition { get; set; }

			public Vector3 LocalPositionCentral { get; set; }

			public Vector3 LocalPositionLateral { get; set; }

			public Quaternion LocalRotationCentral { get; set; }

			public Quaternion LocalRotationLateral { get; set; }

			public Transform Target { get; set; }
		}

		[SerializeField]
		private Transform _central;

		[SerializeField]
		private Transform _controlTransform;

		[SerializeField]
		private InterpolationMode _interpolationMode;

		private List<InterpolatedTransform> _interpolations = new List<InterpolatedTransform>();

		[SerializeField]
		private float _interpolationScale = 1f;

		[SerializeField]
		private Transform _lateral;

		[SerializeField]
		private Vector3 _localAxis;

		[SerializeField]
		private string _originBoneName = "neck_C0_neck_01_Jnt";

		[SerializeField]
		private Transform _originTransform;

		[SerializeField]
		private Transform _target;

		public string OriginBoneName => _originBoneName;

		public Transform OriginTransform
		{
			get
			{
				return _originTransform;
			}
			set
			{
				_originTransform = value;
			}
		}

		protected virtual void Start()
		{
			BuildInterpolations(_central, _lateral, _target, interpolatePosition: true);
		}

		protected virtual void Update()
		{
			if (!(OriginTransform == null))
			{
				float num = Vector3.Dot(-_controlTransform.InverseTransformPoint(OriginTransform.position), _localAxis) * _interpolationScale;
				if (_interpolationMode == InterpolationMode.LeftRight)
				{
					num = (num + 1f) * 0.5f;
				}
				num = Mathf.Clamp01(num);
				UpdateInterpolations(num);
			}
		}

		private void BuildInterpolations(Transform central, Transform lateral, Transform target, bool interpolatePosition)
		{
			InterpolatedTransform item = new InterpolatedTransform
			{
				InterpolatePosition = interpolatePosition,
				LocalPositionCentral = central.localPosition,
				LocalRotationCentral = central.localRotation,
				LocalPositionLateral = lateral.localPosition,
				LocalRotationLateral = lateral.localRotation,
				Target = target
			};
			_interpolations.Add(item);
			for (int i = 0; i < central.childCount; i++)
			{
				Transform child = central.GetChild(i);
				Transform child2 = lateral.GetChild(i);
				Transform child3 = target.GetChild(i);
				BuildInterpolations(child, child2, child3, interpolatePosition: false);
			}
		}

		private void UpdateInterpolations(float k)
		{
			foreach (InterpolatedTransform interpolation in _interpolations)
			{
				if (interpolation.InterpolatePosition)
				{
					interpolation.Target.localPosition = Vector3.Lerp(interpolation.LocalPositionCentral, interpolation.LocalPositionLateral, k);
				}
				interpolation.Target.localRotation = Quaternion.Lerp(interpolation.LocalRotationCentral, interpolation.LocalRotationLateral, k);
			}
		}
	}
}
