using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class TransformSettings : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private Vector3 positionOffset;

		[SerializeField]
		private Vector3 rotationOffset;

		[SerializeField]
		private Vector3 scaleOffset;

		public Vector3 PositionOffset => positionOffset;

		public Vector3 RotationOffset => rotationOffset;

		public Vector3 ScaleOffset => scaleOffset;

		public bool IsValid
		{
			get
			{
				if (!(positionOffset != Vector3.zero) && !(rotationOffset != Vector3.zero))
				{
					return scaleOffset != Vector3.zero;
				}
				return true;
			}
		}

		public void ApplyToTransform(Transform t)
		{
			if (IsValid)
			{
				t.localPosition += positionOffset;
				t.localEulerAngles += rotationOffset;
				t.localScale += scaleOffset;
			}
		}

		public override string GetID()
		{
			return id;
		}
	}
}
