using System;
using System.Xml.Linq;
using UnityEngine;

namespace ModApi.Craft.Parts
{
	[Serializable]
	public class PartTypeMirrorConfig
	{
		[SerializeField]
		[Tooltip("A value indicating if a rotation offset should be applied when mirroring a part.")]
		private bool _hasRotationOffset;

		[SerializeField]
		[Tooltip("The rotation offset (in euler angles) to use when mirroring a part.")]
		private Vector3 _rotationOffsetEuler = Vector3.zero;

		private Quaternion? _rotationOffsetQuaternion;

		private Quaternion? _rotationOffsetQuaternionInverse;

		public bool HasRotationOffset
		{
			get
			{
				return _hasRotationOffset;
			}
			set
			{
				_hasRotationOffset = value;
			}
		}

		public Quaternion RotationOffset
		{
			get
			{
				if (!_rotationOffsetQuaternion.HasValue)
				{
					_rotationOffsetQuaternion = Quaternion.Euler(_rotationOffsetEuler);
				}
				return _rotationOffsetQuaternion.Value;
			}
			set
			{
				_rotationOffsetQuaternion = value;
				_rotationOffsetQuaternionInverse = Quaternion.Inverse(value);
				_rotationOffsetEuler = value.eulerAngles;
			}
		}

		public Quaternion RotationOffsetInverse
		{
			get
			{
				if (!_rotationOffsetQuaternionInverse.HasValue)
				{
					_rotationOffsetQuaternionInverse = Quaternion.Inverse(RotationOffset);
				}
				return _rotationOffsetQuaternionInverse.Value;
			}
		}

		public PartTypeMirrorConfig()
		{
		}

		public PartTypeMirrorConfig(XElement xml)
		{
			_rotationOffsetEuler = Utilities.GetVectorAttribute(xml, "mirrorRotationOffset", Vector3.zero);
			HasRotationOffset = !Utilities.CompareVector3s(_rotationOffsetEuler, Vector3.zero);
			RotationOffset = Quaternion.Euler(_rotationOffsetEuler);
		}

		public void Save(XElement xml)
		{
			if (HasRotationOffset)
			{
				xml.SetAttributeValue("mirrorRotationOffset", Utilities.Vector3ToString(RotationOffset.eulerAngles));
			}
		}
	}
}
