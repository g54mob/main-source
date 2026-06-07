using System.Runtime.CompilerServices;
using UnityEngine;

public static class TransformUtils
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static (Vector3 targetPosition, Quaternion targetRotation) CalculateAlignmentTargets(Transform transform, Transform matchTo, Transform anchor)
	{
		return CalculateAlignmentTargets(transform, matchTo.position, matchTo.rotation, anchor);
	}

	public static (Vector3 targetPosition, Quaternion targetRotation) CalculateAlignmentTargets(Transform transform, Vector3 matchToPos, Quaternion matchToRot, Transform anchor)
	{
		Vector3 item;
		Quaternion item2;
		if (!(anchor == null) && !(anchor == transform))
		{
			(item, item2) = CalculateAlignmentTargets(transform.position, transform.rotation, matchToPos, matchToRot, anchor.position, anchor.rotation);
		}
		else
		{
			item2 = matchToRot;
			item = matchToPos;
		}
		return (targetPosition: item, targetRotation: item2);
	}

	public static (Vector3 targetPosition, Quaternion targetRotation) CalculateAlignmentTargets(Vector3 parentPos, Quaternion parentRot, Vector3 matchToPos, Quaternion matchToRot, Vector3 anchorPos, Quaternion anchorRot)
	{
		Quaternion quaternion = Quaternion.Inverse(parentRot);
		Quaternion quaternion2 = matchToRot * Quaternion.Inverse(quaternion * anchorRot);
		return (targetPosition: matchToPos + quaternion2 * quaternion * (parentPos - anchorPos), targetRotation: quaternion2);
	}

	public static void SetPositionAndRotation(this Transform transform, (Vector3 position, Quaternion rotation) positionAndRotation)
	{
		transform.SetPositionAndRotation(positionAndRotation.position, positionAndRotation.rotation);
	}

	public static void AlignToPositionAndRotation(this Transform transform, Transform target, Transform anchor)
	{
		transform.SetPositionAndRotation(CalculateAlignmentTargets(transform, target, anchor));
	}

	public static void AlignPosition(this Transform transform, Transform target, Transform anchor)
	{
		if (anchor == null || anchor == transform)
		{
			transform.position = target.position;
		}
		else
		{
			transform.position = target.position + (transform.position - anchor.position);
		}
	}

	public static void AlignRotation(this Transform transform, Transform target, Transform anchor)
	{
		if (anchor == null || anchor == transform)
		{
			transform.rotation = target.rotation;
		}
		else
		{
			transform.rotation = target.rotation * Quaternion.Inverse(Quaternion.Inverse(transform.rotation) * anchor.rotation);
		}
	}

	public static Vector3 TransformPointUnscaled(this Transform transform, Vector3 position)
	{
		return Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one).MultiplyPoint3x4(position);
	}

	public static Vector3 InverseTransformPointUnscaled(this Transform transform, Vector3 position)
	{
		return Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one).inverse.MultiplyPoint3x4(position);
	}
}
