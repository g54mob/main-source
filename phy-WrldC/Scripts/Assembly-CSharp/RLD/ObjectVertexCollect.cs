using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class ObjectVertexCollect
	{
		public static List<Vector3> CollectModelSpriteVerts(Sprite sprite, AABB collectAABB)
		{
			Vector2[] vertices = sprite.vertices;
			List<Vector3> list = new List<Vector3>(7);
			Vector2[] array = vertices;
			foreach (Vector2 vector in array)
			{
				if (BoxMath.ContainsPoint(vector, collectAABB.Center, collectAABB.Size, Quaternion.identity))
				{
					list.Add(vector);
				}
			}
			return list;
		}

		public static List<Vector3> CollectWorldSpriteVerts(Sprite sprite, Transform spriteTransform, OBB collectOBB)
		{
			List<Vector3> worldVerts = sprite.GetWorldVerts(spriteTransform);
			List<Vector3> list = new List<Vector3>(7);
			foreach (Vector3 item in worldVerts)
			{
				if (BoxMath.ContainsPoint(item, collectOBB.Center, collectOBB.Size, collectOBB.Rotation))
				{
					list.Add(item);
				}
			}
			return list;
		}

		public static List<Vector3> CollectHierarchyVerts(GameObject root, BoxFace collectFace, float collectBoxScale, float collectEps)
		{
			List<GameObject> meshObjectsInHierarchy = root.GetMeshObjectsInHierarchy();
			List<GameObject> spriteObjectsInHierarchy = root.GetSpriteObjectsInHierarchy();
			if (meshObjectsInHierarchy.Count == 0 && spriteObjectsInHierarchy.Count == 0)
			{
				return new List<Vector3>();
			}
			OBB oBB = ObjectBounds.CalcHierarchyWorldOBB(root, new ObjectBounds.QueryConfig
			{
				ObjectTypes = (GameObjectType.Mesh | GameObjectType.Sprite)
			});
			if (!oBB.IsValid)
			{
				return new List<Vector3>();
			}
			int faceAxisIndex = BoxMath.GetFaceAxisIndex(collectFace);
			Vector3 vector = BoxMath.CalcBoxFaceCenter(oBB.Center, oBB.Size, oBB.Rotation, collectFace);
			Vector3 vector2 = BoxMath.CalcBoxFaceNormal(oBB.Center, oBB.Size, oBB.Rotation, collectFace);
			float num = collectEps * 2f;
			Vector3 size = oBB.Size;
			size[faceAxisIndex] = oBB.Size[faceAxisIndex] * collectBoxScale + num;
			size[(faceAxisIndex + 1) % 3] += num;
			size[(faceAxisIndex + 2) % 3] += num;
			OBB oBB2 = new OBB(vector + vector2 * ((0f - size[faceAxisIndex]) * 0.5f + collectEps), size);
			oBB2.Rotation = oBB.Rotation;
			List<Vector3> list = new List<Vector3>(80);
			foreach (GameObject item in meshObjectsInHierarchy)
			{
				Mesh mesh = item.GetMesh();
				RTMesh rTMesh = Singleton<RTMeshDb>.Get.GetRTMesh(mesh);
				if (rTMesh != null)
				{
					List<Vector3> list2 = rTMesh.OverlapVerts(oBB2, item.transform);
					if (list2.Count != 0)
					{
						list.AddRange(list2);
					}
				}
			}
			foreach (GameObject item2 in spriteObjectsInHierarchy)
			{
				List<Vector3> list3 = CollectWorldSpriteVerts(item2.GetSprite(), item2.transform, oBB2);
				if (list3.Count != 0)
				{
					list.AddRange(list3);
				}
			}
			return list;
		}
	}
}
