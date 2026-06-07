using System;
using UnityEngine;

namespace Jundroo.Common.Utils
{
	public static class UnityTransformUtility
	{
		public enum TransformAxis
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		public static void DestroyChildren(Transform parent)
		{
			int childCount = parent.childCount;
			for (int i = 0; i < childCount; i++)
			{
				UnityEngine.Object.Destroy(parent.GetChild(i).gameObject);
			}
		}

		public static Transform GetFirstChild(Transform transform)
		{
			if (transform.childCount > 0)
			{
				return transform.GetChild(0);
			}
			return null;
		}

		public static Vector3 GetRotation(TransformAxis axis, float degrees)
		{
			return axis switch
			{
				TransformAxis.X => new Vector3(degrees, 0f, 0f), 
				TransformAxis.Y => new Vector3(0f, degrees, 0f), 
				TransformAxis.Z => new Vector3(0f, 0f, degrees), 
				_ => throw new InvalidOperationException(), 
			};
		}

		public static Matrix4x4 GetTargetToAncestorTransformMatrix(Transform target, Transform ancestor)
		{
			Matrix4x4 matrix4x = Matrix4x4.identity;
			Transform transform = target;
			while (transform != null && transform != ancestor)
			{
				matrix4x = Matrix4x4.TRS(transform.localPosition, transform.localRotation, transform.localScale) * matrix4x;
				transform = transform.parent;
			}
			if (transform == null)
			{
				throw new InvalidOperationException("The target transform must be a descendant of the ancestor transform");
			}
			return matrix4x;
		}

		public static Vector3 GetVector(Transform trans, TransformAxis axis, bool local)
		{
			return axis switch
			{
				TransformAxis.X => local ? trans.right : Vector3.right, 
				TransformAxis.Y => local ? trans.up : Vector3.up, 
				TransformAxis.Z => local ? trans.forward : Vector3.forward, 
				_ => throw new ArgumentException($"TransformAxis type {axis} not currently supported.", "axis"), 
			};
		}

		public static void MoveChildren(Transform from, Transform to)
		{
			Transform firstChild;
			do
			{
				firstChild = GetFirstChild(from);
				if (firstChild != null)
				{
					firstChild.parent = to;
				}
			}
			while (firstChild != null);
		}

		public static void RotateChildrenAround(Transform parent, Vector3 worldPivot, Vector3 worldEulersAngles)
		{
			Transform transform = new GameObject("RotateChildrenAround_TempTransform").transform;
			transform.SetPositionAndRotation(worldPivot, Quaternion.identity);
			MoveChildren(parent, transform);
			transform.Rotate(worldEulersAngles);
			MoveChildren(transform, parent);
			UnityEngine.Object.Destroy(transform.gameObject);
		}

		public static void ScaleAroundPivot(Transform scaleTrans, Transform pivotTrans, Vector3 scale)
		{
			Transform parent = scaleTrans.parent;
			Transform parent2 = pivotTrans.parent;
			pivotTrans.parent = null;
			pivotTrans.localScale = Vector3.one;
			scaleTrans.parent = pivotTrans;
			pivotTrans.localScale = scale;
			scaleTrans.parent = parent;
			pivotTrans.parent = parent2;
		}

		public static void SetLossyWorldScale(Transform trans, Vector3 worldScale)
		{
			Vector3 lossyScale = trans.lossyScale;
			trans.localScale = new Vector3(worldScale.x / lossyScale.x, worldScale.y / lossyScale.y, worldScale.z / lossyScale.z);
		}
	}
}
