using LaundryBear.Math;
using UnityEngine;

namespace LaundryBear
{
	public static class TransformUtils
	{
		public static void TransferLocalTransform(Transform source, Transform target)
		{
			target.localPosition = source.localPosition;
			target.localRotation = source.localRotation;
			target.localScale = source.localScale;
		}

		public static void TransferWorldTransform(Transform source, Transform target)
		{
			target.position = source.position;
			target.rotation = source.rotation;
			if (target.parent != null)
			{
				target.localScale = VectorUtils.MemberwiseDivide(source.lossyScale, target.parent.lossyScale);
			}
			else
			{
				target.localScale = source.lossyScale;
			}
		}

		public static void CopyLocalValuesTo(this Transform source, Transform target)
		{
			TransferLocalTransform(source, target);
		}

		public static void CopyLocalValuesFrom(this Transform target, Transform source)
		{
			TransferLocalTransform(source, target);
		}

		public static void CopyWorldValuesTo(this Transform source, Transform target)
		{
			TransferWorldTransform(source, target);
		}

		public static void CopyWorldValuesFrom(this Transform target, Transform source)
		{
			TransferWorldTransform(source, target);
		}
	}
}
