using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class Object2ObjectSnapData
	{
		private GameObject _gameObject;

		private AABB[] _snapAreaBounds = new AABB[Enum.GetValues(typeof(BoxFace)).Length];

		private BoxFaceAreaDesc[] _snapAreaDesc = new BoxFaceAreaDesc[Enum.GetValues(typeof(BoxFace)).Length];

		public bool Initialize(GameObject gameObject)
		{
			if (gameObject == null || _gameObject != null)
			{
				return false;
			}
			Mesh mesh = gameObject.GetMesh();
			Sprite sprite = gameObject.GetSprite();
			if (mesh == null && sprite == null)
			{
				return false;
			}
			bool flag = true;
			if (mesh == null)
			{
				flag = false;
			}
			RTMesh rTMesh = null;
			if (flag)
			{
				Renderer meshRenderer = gameObject.GetMeshRenderer();
				if (meshRenderer == null || !meshRenderer.enabled)
				{
					flag = false;
				}
				rTMesh = Singleton<RTMeshDb>.Get.GetRTMesh(mesh);
				if (rTMesh == null)
				{
					flag = false;
				}
			}
			if (rTMesh == null && sprite == null)
			{
				return false;
			}
			List<AABB> list = BuildVertOverlapAABBs(gameObject, flag ? null : sprite, flag ? rTMesh : null);
			if (list.Count == 0)
			{
				return false;
			}
			AABB aABB = (flag ? rTMesh.AABB : ObjectBounds.CalcSpriteModelAABB(gameObject));
			List<BoxFace> allBoxFaces = BoxMath.AllBoxFaces;
			_gameObject = gameObject;
			if (flag)
			{
				foreach (BoxFace item in allBoxFaces)
				{
					AABB modelAABB = list[(int)item];
					List<Vector3> points = rTMesh.OverlapModelVerts(modelAABB);
					points = BoxMath.CalcBoxFacePlane(aABB.Center, aABB.Size, Quaternion.identity, item).ProjectAllPoints(points);
					_snapAreaBounds[(int)item] = new AABB(points);
					_snapAreaDesc[(int)item] = BoxMath.GetBoxFaceAreaDesc(_snapAreaBounds[(int)item].Size, item);
				}
			}
			else
			{
				foreach (BoxFace item2 in allBoxFaces)
				{
					if (item2 != BoxFace.Front && item2 != BoxFace.Back)
					{
						AABB collectAABB = list[(int)item2];
						List<Vector3> points2 = ObjectVertexCollect.CollectModelSpriteVerts(sprite, collectAABB);
						points2 = BoxMath.CalcBoxFacePlane(aABB.Center, aABB.Size, Quaternion.identity, item2).ProjectAllPoints(points2);
						_snapAreaBounds[(int)item2] = new AABB(points2);
						_snapAreaDesc[(int)item2] = BoxMath.GetBoxFaceAreaDesc(_snapAreaBounds[(int)item2].Size, item2);
					}
					else
					{
						_snapAreaBounds[(int)item2] = AABB.GetInvalid();
						_snapAreaDesc[(int)item2] = BoxFaceAreaDesc.GetInvalid();
					}
				}
			}
			return true;
		}

		public BoxFaceAreaDesc GetWorldSnapAreaDesc(BoxFace boxFace)
		{
			return BoxMath.GetBoxFaceAreaDesc(Vector3.Scale(_snapAreaBounds[(int)boxFace].Size, _gameObject.transform.lossyScale.Abs()), boxFace);
		}

		public List<OBB> GetAllWorldSnapAreaBounds()
		{
			if (_gameObject == null)
			{
				return new List<OBB>();
			}
			Transform transform = _gameObject.transform;
			List<OBB> list = new List<OBB>(_snapAreaBounds.Length);
			AABB[] snapAreaBounds = _snapAreaBounds;
			foreach (AABB modelSpaceAABB in snapAreaBounds)
			{
				list.Add(new OBB(modelSpaceAABB, transform));
			}
			return list;
		}

		public OBB GetWorldSnapAreaBounds(BoxFace boxFace)
		{
			if (_gameObject == null)
			{
				return OBB.GetInvalid();
			}
			Transform transform = _gameObject.transform;
			return new OBB(_snapAreaBounds[(int)boxFace], transform);
		}

		private List<AABB> BuildVertOverlapAABBs(GameObject gameObject, Sprite sprite, RTMesh rtMesh)
		{
			if (sprite == null && rtMesh == null)
			{
				return new List<AABB>();
			}
			float num = 0.1f;
			AABB aABB = ((sprite != null) ? ObjectBounds.CalcSpriteModelAABB(gameObject) : rtMesh.AABB);
			Vector3 size = aABB.Size;
			List<BoxFace> allBoxFaces = BoxMath.AllBoxFaces;
			Vector3[] array = new Vector3[allBoxFaces.Count];
			array[2] = new Vector3(0.2f, size.y + 0.001f, size.z + 0.001f);
			array[3] = new Vector3(0.2f, size.y + 0.001f, size.z + 0.001f);
			array[4] = new Vector3(size.x + 0.001f, 0.2f, size.z + 0.001f);
			array[5] = new Vector3(size.x + 0.001f, 0.2f, size.z + 0.001f);
			array[1] = new Vector3(size.x + 0.001f, size.y + 0.001f, 0.2f);
			array[0] = new Vector3(size.x + 0.001f, size.y + 0.001f, 0.2f);
			List<AABB> list = new List<AABB>();
			for (int i = 0; i < allBoxFaces.Count; i++)
			{
				BoxFace boxFace = allBoxFaces[i];
				Vector3 vector = BoxMath.CalcBoxFaceCenter(aABB.Center, aABB.Size, Quaternion.identity, boxFace);
				Vector3 vector2 = BoxMath.CalcBoxFaceNormal(aABB.Center, aABB.Size, Quaternion.identity, boxFace);
				Vector3 center = vector - vector2 * num;
				list.Add(new AABB(center, array[i]));
			}
			return list;
		}
	}
}
