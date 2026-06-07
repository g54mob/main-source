using MalbersAnimations.Utilities;
using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Utilities/Tools/Use (Follow) Transform")]
	public class UseTransform : MonoBehaviour
	{
		public enum UpdateMode
		{
			Update = 1,
			FixedUpdate = 2,
			LateUpdate = 4
		}

		public enum XYZEnum
		{
			X = 1,
			Y = 2,
			Z = 4
		}

		[Tooltip("Transform to use the Position as Reference")]
		public Transform Reference;

		[Tooltip("Use the Reference's Position")]
		public bool position = true;

		[Hide("position")]
		public UpdateMode PositionUpdate = UpdateMode.FixedUpdate;

		[Hide("position")]
		[Flag]
		public XYZEnum posAxis = (XYZEnum)7;

		[Hide("position")]
		[Min(0f)]
		public float lerpPos;

		[Tooltip("Use the Reference's Rotation")]
		public bool rotation = true;

		[Hide("rotation")]
		public UpdateMode RotationUpdate = UpdateMode.LateUpdate;

		[Hide("rotation")]
		[Min(0f)]
		public float lerpRot;

		private void Update()
		{
			if (!(Reference == null))
			{
				if (PositionUpdate == UpdateMode.Update)
				{
					SetPositionReference(Time.deltaTime);
				}
				if (RotationUpdate == UpdateMode.Update)
				{
					SetRotationReference(Time.deltaTime);
				}
			}
		}

		private void LateUpdate()
		{
			if (!(Reference == null))
			{
				if (PositionUpdate == UpdateMode.LateUpdate)
				{
					SetPositionReference(Time.deltaTime);
				}
				if (RotationUpdate == UpdateMode.LateUpdate)
				{
					SetRotationReference(Time.deltaTime);
				}
			}
		}

		private void FixedUpdate()
		{
			if (!(Reference == null))
			{
				if (PositionUpdate == UpdateMode.FixedUpdate)
				{
					SetPositionReference(Time.fixedDeltaTime);
				}
				if (RotationUpdate == UpdateMode.FixedUpdate)
				{
					SetRotationReference(Time.fixedDeltaTime);
				}
			}
		}

		private void SetPositionReference(float delta)
		{
			if (position)
			{
				Vector3 b = base.transform.position;
				if ((posAxis & XYZEnum.X) == XYZEnum.X)
				{
					b.x = Reference.position.x;
				}
				if ((posAxis & XYZEnum.Y) == XYZEnum.Y)
				{
					b.y = Reference.position.y;
				}
				if ((posAxis & XYZEnum.Z) == XYZEnum.Z)
				{
					b.z = Reference.position.z;
				}
				base.transform.position = Vector3.Lerp(base.transform.position, b, (lerpPos == 0f) ? 1f : (delta * lerpPos));
			}
		}

		private void SetRotationReference(float delta)
		{
			if (rotation)
			{
				base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Reference.rotation, (lerpRot == 0f) ? 1f : (delta * lerpRot));
			}
		}
	}
}
