using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class SceneTree
	{
		private SphereTree<GameObject> _objectTree = new SphereTree<GameObject>(2);

		private Dictionary<GameObject, SphereTreeNode<GameObject>> _objectToNode = new Dictionary<GameObject, SphereTreeNode<GameObject>>();

		public GameObjectRayHit RaycastMeshObject(Ray ray, GameObject gameObject)
		{
			Mesh mesh = gameObject.GetMesh();
			RTMesh rTMesh = Singleton<RTMeshDb>.Get.GetRTMesh(mesh);
			if (rTMesh != null)
			{
				MeshRayHit meshRayHit = rTMesh.Raycast(ray, gameObject.transform.localToWorldMatrix);
				if (meshRayHit != null)
				{
					return new GameObjectRayHit(ray, gameObject, meshRayHit);
				}
			}
			else
			{
				MeshCollider component = gameObject.GetComponent<MeshCollider>();
				if (component != null && component.Raycast(ray, out var hitInfo, float.MaxValue))
				{
					return new GameObjectRayHit(ray, hitInfo);
				}
			}
			return null;
		}

		public GameObjectRayHit RaycastSpriteObject(Ray ray, GameObject gameObject)
		{
			OBB oBB = ObjectBounds.CalcSpriteWorldOBB(gameObject);
			if (!oBB.IsValid)
			{
				return null;
			}
			if (BoxMath.Raycast(ray, out var t, oBB.Center, oBB.Size, oBB.Rotation))
			{
				return new GameObjectRayHit(ray, gameObject, oBB.GetPointFaceNormal(ray.GetPoint(t)), t);
			}
			return null;
		}

		public List<GameObjectRayHit> RaycastAll(Ray ray, SceneRaycastPrecision raycastPresicion)
		{
			List<SphereTreeNodeRayHit<GameObject>> list = _objectTree.RaycastAll(ray);
			if (list.Count == 0)
			{
				return new List<GameObjectRayHit>();
			}
			ObjectBounds.QueryConfig queryConfig = new ObjectBounds.QueryConfig
			{
				ObjectTypes = GameObjectTypeHelper.AllCombined,
				NoVolumeSize = Vector3Ex.FromValue(MonoSingleton<RTScene>.Get.Settings.NonMeshObjectSize)
			};
			Vector3 look = MonoSingleton<RTFocusCamera>.Get.Look;
			switch (raycastPresicion)
			{
			case SceneRaycastPrecision.BestFit:
			{
				List<GameObjectRayHit> list3 = new List<GameObjectRayHit>(10);
				{
					foreach (SphereTreeNodeRayHit<GameObject> item3 in list)
					{
						GameObject data2 = item3.HitNode.Data;
						if (data2 == null || !data2.activeInHierarchy)
						{
							continue;
						}
						Renderer component2 = data2.GetComponent<Renderer>();
						if (component2 != null && !component2.isVisible)
						{
							continue;
						}
						switch (data2.GetGameObjectType())
						{
						case GameObjectType.Mesh:
						{
							GameObjectRayHit gameObjectRayHit = RaycastMeshObject(ray, data2);
							if (gameObjectRayHit != null)
							{
								list3.Add(gameObjectRayHit);
							}
							continue;
						}
						case GameObjectType.Terrain:
						{
							TerrainCollider component3 = data2.GetComponent<TerrainCollider>();
							if (component3 != null && component3.Raycast(ray, out var hitInfo, float.MaxValue))
							{
								list3.Add(new GameObjectRayHit(ray, hitInfo));
							}
							continue;
						}
						case GameObjectType.Sprite:
						{
							GameObjectRayHit gameObjectRayHit2 = RaycastSpriteObject(ray, data2);
							if (gameObjectRayHit2 != null)
							{
								list3.Add(gameObjectRayHit2);
							}
							continue;
						}
						}
						OBB oBB2 = ObjectBounds.CalcWorldOBB(data2, queryConfig);
						if (oBB2.IsValid && BoxMath.Raycast(ray, out var t2, oBB2.Center, oBB2.Size, oBB2.Rotation))
						{
							BoxFaceDesc faceClosestToPoint2 = BoxMath.GetFaceClosestToPoint(ray.GetPoint(t2), oBB2.Center, oBB2.Size, oBB2.Rotation, look);
							GameObjectRayHit item2 = new GameObjectRayHit(ray, data2, faceClosestToPoint2.Plane.normal, t2);
							list3.Add(item2);
						}
					}
					return list3;
				}
			}
			case SceneRaycastPrecision.Box:
			{
				List<GameObjectRayHit> list2 = new List<GameObjectRayHit>(10);
				{
					foreach (SphereTreeNodeRayHit<GameObject> item4 in list)
					{
						GameObject data = item4.HitNode.Data;
						if (data == null || !data.activeInHierarchy)
						{
							continue;
						}
						Renderer component = data.GetComponent<Renderer>();
						if (!(component != null) || component.isVisible)
						{
							OBB oBB = ObjectBounds.CalcWorldOBB(data, queryConfig);
							if (oBB.IsValid && BoxMath.Raycast(ray, out var t, oBB.Center, oBB.Size, oBB.Rotation))
							{
								BoxFaceDesc faceClosestToPoint = BoxMath.GetFaceClosestToPoint(ray.GetPoint(t), oBB.Center, oBB.Size, oBB.Rotation, look);
								GameObjectRayHit item = new GameObjectRayHit(ray, data, faceClosestToPoint.Plane.normal, t);
								list2.Add(item);
							}
						}
					}
					return list2;
				}
			}
			default:
				return new List<GameObjectRayHit>();
			}
		}

		public List<GameObject> OverlapBox(OBB obb)
		{
			List<SphereTreeNode<GameObject>> list = _objectTree.OverlapBox(obb);
			if (list.Count == 0)
			{
				return new List<GameObject>();
			}
			ObjectBounds.QueryConfig queryConfig = new ObjectBounds.QueryConfig
			{
				ObjectTypes = GameObjectTypeHelper.AllCombined,
				NoVolumeSize = Vector3Ex.FromValue(MonoSingleton<RTScene>.Get.Settings.NonMeshObjectSize)
			};
			List<GameObject> list2 = new List<GameObject>();
			foreach (SphereTreeNode<GameObject> item in list)
			{
				GameObject data = item.Data;
				if (!(data == null) && data.activeInHierarchy)
				{
					OBB otherOBB = ObjectBounds.CalcWorldOBB(data, queryConfig);
					if (obb.IntersectsOBB(otherOBB))
					{
						list2.Add(data);
					}
				}
			}
			return list2;
		}

		public bool IsObjectRegistered(GameObject gameObject)
		{
			return _objectToNode.ContainsKey(gameObject);
		}

		public void RegisterObject(GameObject gameObject)
		{
			if (CanRegisterObject(gameObject))
			{
				AABB aabb = ObjectBounds.CalcWorldAABB(gameObject, new ObjectBounds.QueryConfig
				{
					ObjectTypes = GameObjectTypeHelper.AllCombined,
					NoVolumeSize = Vector3Ex.FromValue(MonoSingleton<RTScene>.Get.Settings.NonMeshObjectSize)
				});
				Sphere sphere = new Sphere(aabb);
				SphereTreeNode<GameObject> value = _objectTree.AddNode(gameObject, sphere);
				_objectToNode.Add(gameObject, value);
				MonoSingleton<RTFocusCamera>.Get.SetObjectVisibilityDirty();
			}
		}

		public void OnObjectTransformChanged(Transform objectTransform)
		{
			AABB aabb = ObjectBounds.CalcWorldAABB(queryConfig: new ObjectBounds.QueryConfig
			{
				ObjectTypes = GameObjectTypeHelper.AllCombined,
				NoVolumeSize = Vector3Ex.FromValue(MonoSingleton<RTScene>.Get.Settings.NonMeshObjectSize)
			}, gameObject: objectTransform.gameObject);
			Sphere sphere = new Sphere(aabb);
			SphereTreeNode<GameObject> sphereTreeNode = _objectToNode[objectTransform.gameObject];
			sphereTreeNode.Sphere = sphere;
			_objectTree.OnNodeSphereUpdated(sphereTreeNode);
			MonoSingleton<RTFocusCamera>.Get.SetObjectVisibilityDirty();
		}

		public void RemoveNodesWithNullObjects()
		{
			Dictionary<GameObject, SphereTreeNode<GameObject>> dictionary = new Dictionary<GameObject, SphereTreeNode<GameObject>>();
			foreach (KeyValuePair<GameObject, SphereTreeNode<GameObject>> item in _objectToNode)
			{
				if (item.Key == null)
				{
					_objectTree.RemoveNode(item.Value);
				}
				else
				{
					dictionary.Add(item.Key, item.Value);
				}
			}
			_objectToNode.Clear();
			_objectToNode = dictionary;
		}

		public void DebugDraw()
		{
			_objectTree.DebugDraw();
		}

		private bool CanRegisterObject(GameObject gameObject)
		{
			if (gameObject == null || IsObjectRegistered(gameObject))
			{
				return false;
			}
			if (gameObject.IsRLDAppObject())
			{
				return false;
			}
			if (gameObject.GetComponent<RectTransform>() != null)
			{
				return false;
			}
			return true;
		}
	}
}
