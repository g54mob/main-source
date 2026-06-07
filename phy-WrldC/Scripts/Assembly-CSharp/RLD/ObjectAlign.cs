using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class ObjectAlign
	{
		public enum Result
		{
			Err_NoObjects = 0,
			Success = 1
		}

		public static Result AlignToWorldAxis(IEnumerable<GameObject> gameObjects, Axis axis, Vector3 alignmentPlaneOrigin)
		{
			Vector3 inNormal = Vector3.forward;
			switch (axis)
			{
			case Axis.Y:
				inNormal = Vector3.up;
				break;
			case Axis.Z:
				inNormal = Vector3.right;
				break;
			}
			Plane alignmentPlane = new Plane(inNormal, alignmentPlaneOrigin);
			return AlignToWorldPlane(gameObjects, alignmentPlane);
		}

		public static Result AlignToWorldPlane(IEnumerable<GameObject> gameObjects, Plane alignmentPlane)
		{
			List<GameObject> list = GameObjectEx.FilterParentsOnly(gameObjects);
			if (list.Count == 0)
			{
				return Result.Err_NoObjects;
			}
			AlignRootsToPlane(list, alignmentPlane);
			return Result.Success;
		}

		private static void AlignRootsToPlane(List<GameObject> roots, Plane alignmentPlane)
		{
			ObjectBounds.QueryConfig queryConfig = new ObjectBounds.QueryConfig
			{
				NoVolumeSize = Vector3.zero,
				ObjectTypes = GameObjectTypeHelper.AllCombined
			};
			foreach (GameObject root in roots)
			{
				OBB oBB = ObjectBounds.CalcHierarchyWorldOBB(root, queryConfig);
				if (oBB.IsValid)
				{
					Vector3 vector = alignmentPlane.ProjectPoint(oBB.Center);
					root.transform.position += vector - oBB.Center;
				}
			}
		}
	}
}
