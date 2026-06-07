using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MeshGridSplitter
{
	public class MeshSplit : MonoBehaviour
	{
		public List<MeshFilter> meshesToSplit;

		public bool drawGrid;

		public float gridSize = 16f;

		public bool axisX = true;

		public bool axisY = true;

		public bool axisZ = true;

		[Tooltip("If enabled, each split gameobject's pivot will be placed at its grid coordinates, otherwise they'll all have the same pivot based on their source object's pivot")]
		public bool rebaseToGrid;

		[Tooltip("If rebaseToGrid is enabled, this transform's position will be used as grid origin (or Vector3.zero if not set)")]
		public Transform originTransform;

		public bool wrapInParentObject = true;

		public bool allow32bitIndices = true;

		[HideInInspector]
		public bool populateIncludeDisabled;

		public void Split()
		{
			Vector3 origin = (originTransform ? originTransform.position : Vector3.zero);
			List<List<GameObject>> splits = meshesToSplit.Select((MeshFilter mf) => Splitter.Split(mf, gridSize, axisX, axisY, axisZ, rebaseToGrid, origin, allow32bitIndices)).ToList();
			if (wrapInParentObject)
			{
				Wrap(splits);
			}
		}

		private static void Wrap(List<List<GameObject>> splits)
		{
			List<GameObject> list = splits.SelectMany((List<GameObject> go) => go).ToList();
			List<Vector3> list2 = list.Select((GameObject go) => (!(go.transform.localPosition == Vector3.zero)) ? go.transform.localPosition : go.GetComponent<MeshFilter>().sharedMesh.bounds.center).ToList();
			Bounds bounds = new Bounds(list2[0], Vector3.zero);
			foreach (Vector3 item in list2)
			{
				bounds.Encapsulate(item);
			}
			GameObject gameObject = new GameObject("[split meshes]");
			gameObject.transform.position = bounds.center;
			foreach (GameObject item2 in list)
			{
				item2.transform.SetParent(gameObject.transform, worldPositionStays: true);
			}
		}

		private Bounds GlobalBounds(MeshFilter mf)
		{
			Bounds bounds = mf.sharedMesh.bounds;
			bounds.center += mf.transform.position;
			return bounds;
		}

		private void OnDrawGizmosSelected()
		{
			if (!drawGrid || meshesToSplit == null || meshesToSplit.Count <= 0)
			{
				return;
			}
			Bounds bounds = GlobalBounds(meshesToSplit[0]);
			foreach (MeshFilter item in meshesToSplit)
			{
				bounds.Encapsulate(GlobalBounds(item));
			}
			float num = Mathf.Ceil(bounds.extents.x) + gridSize;
			float num2 = Mathf.Ceil(bounds.extents.y) + gridSize;
			float num3 = Mathf.Ceil(bounds.extents.z) + gridSize;
			for (float num4 = 0f - num3; num4 <= num3; num4 += gridSize)
			{
				for (float num5 = 0f - num2; num5 <= num2; num5 += gridSize)
				{
					for (float num6 = 0f - num; num6 <= num; num6 += gridSize)
					{
						Gizmos.DrawWireCube(bounds.center + new Vector3(num6, num5, num4), gridSize * Vector3.one);
					}
				}
			}
		}
	}
}
