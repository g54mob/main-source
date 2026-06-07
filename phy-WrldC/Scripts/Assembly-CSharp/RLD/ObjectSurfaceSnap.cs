using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class ObjectSurfaceSnap
	{
		public enum Type
		{
			UnityTerrain = 0,
			Mesh = 1,
			TerrainMesh = 2,
			SphericalMesh = 3,
			SceneGrid = 4
		}

		public struct SnapConfig
		{
			public bool AlignAxis;

			public TransformAxis AlignmentAxis;

			public Type SurfaceType;

			public float OffsetFromSurface;

			public Vector3 SurfaceHitPoint;

			public Vector3 SurfaceHitNormal;

			public Plane SurfaceHitPlane;

			public GameObject SurfaceObject;

			public bool IsSurfaceMesh()
			{
				if (SurfaceType != Type.Mesh && SurfaceType != Type.SphericalMesh)
				{
					return SurfaceType == Type.TerrainMesh;
				}
				return true;
			}
		}

		public struct SnapResult
		{
			public bool Success;

			public Plane SittingPlane;

			public Vector3 SittingPoint;

			public SnapResult(Plane sittingPlane, Vector3 sittingPoint)
			{
				Success = true;
				SittingPlane = sittingPlane;
				SittingPoint = sittingPoint;
			}
		}

		private abstract class SurfaceRaycaster
		{
			protected GameObject _surfaceObject;

			protected bool _raycastReverse;

			public SurfaceRaycaster(GameObject surfaceObject, bool raycastReverse)
			{
				_surfaceObject = surfaceObject;
				_raycastReverse = raycastReverse;
			}

			public abstract GameObjectRayHit Raycast(Ray ray);
		}

		private class MeshSurfaceRaycaster : SurfaceRaycaster
		{
			public MeshSurfaceRaycaster(GameObject surfaceObject, bool raycastReverse)
				: base(surfaceObject, raycastReverse)
			{
			}

			public override GameObjectRayHit Raycast(Ray ray)
			{
				_ = _raycastReverse;
				return MonoSingleton<RTScene>.Get.RaycastMeshObject(ray, _surfaceObject);
			}
		}

		private class TerrainSurfaceRaycaster : SurfaceRaycaster
		{
			private TerrainCollider _terrainCollider;

			public TerrainSurfaceRaycaster(GameObject surfaceObject, bool raycastReverse)
				: base(surfaceObject, raycastReverse)
			{
				_terrainCollider = surfaceObject.GetComponent<TerrainCollider>();
			}

			public override GameObjectRayHit Raycast(Ray ray)
			{
				if (_raycastReverse)
				{
					return MonoSingleton<RTScene>.Get.RaycastTerrainObjectReverseIfFail(ray, _surfaceObject);
				}
				return MonoSingleton<RTScene>.Get.RaycastTerrainObject(ray, _surfaceObject, _terrainCollider);
			}
		}

		public static SnapResult SnapHierarchy(GameObject root, SnapConfig snapConfig)
		{
			bool num = root.HierarchyHasMesh();
			bool flag = root.HierarchyHasSprite();
			if (!num && !flag)
			{
				Transform transform = root.transform;
				transform.position = snapConfig.SurfaceHitPlane.ProjectPoint(transform.position) + snapConfig.OffsetFromSurface * snapConfig.SurfaceHitNormal;
				return new SnapResult(snapConfig.SurfaceHitPlane, transform.position);
			}
			ObjectBounds.QueryConfig queryConfig = new ObjectBounds.QueryConfig
			{
				ObjectTypes = (GameObjectType.Mesh | GameObjectType.Sprite)
			};
			bool flag2 = snapConfig.SurfaceType == Type.SphericalMesh;
			bool flag3 = snapConfig.SurfaceType == Type.UnityTerrain || snapConfig.SurfaceType == Type.TerrainMesh;
			bool flag4 = snapConfig.SurfaceType == Type.UnityTerrain;
			SurfaceRaycaster surfaceRaycaster = CreateSurfaceRaycaster(snapConfig.SurfaceType, snapConfig.SurfaceObject, raycastReverse: true);
			if (snapConfig.SurfaceType != Type.SceneGrid)
			{
				Transform transform2 = root.transform;
				if (snapConfig.AlignAxis)
				{
					if (flag3)
					{
						transform2.Align(Vector3.up, snapConfig.AlignmentAxis);
						OBB oBB = ObjectBounds.CalcHierarchyWorldOBB(root, queryConfig);
						if (!oBB.IsValid)
						{
							return default(SnapResult);
						}
						BoxFace mostAlignedFace = BoxMath.GetMostAlignedFace(oBB.Center, oBB.Size, oBB.Rotation, -Vector3.up);
						List<Vector3> list = ObjectVertexCollect.CollectHierarchyVerts(root, mostAlignedFace, 0.001f, 0.01f);
						if (list.Count != 0)
						{
							Vector3 pointCloudCenter = Vector3Ex.GetPointCloudCenter(list);
							Ray ray = new Ray(pointCloudCenter + Vector3.up * 0.001f, -Vector3.up);
							GameObjectRayHit gameObjectRayHit = surfaceRaycaster.Raycast(ray);
							if (gameObjectRayHit != null)
							{
								Vector3 vector = gameObjectRayHit.HitNormal;
								if (flag4)
								{
									vector = snapConfig.SurfaceObject.GetComponent<Terrain>().GetInterpolatedNormal(gameObjectRayHit.HitPoint);
								}
								Quaternion quat = transform2.Align(vector, snapConfig.AlignmentAxis);
								oBB = ObjectBounds.CalcHierarchyWorldOBB(root, queryConfig);
								quat.RotatePoints(list, transform2.position);
								Vector3 vector2 = CalculateSitOnSurfaceOffset(oBB, new Plane(Vector3.up, gameObjectRayHit.HitPoint), 0.1f);
								transform2.position += vector2;
								oBB.Center += vector2;
								Vector3Ex.OffsetPoints(list, vector2);
								Vector3 vector3 = CalculateEmbedVector(list, snapConfig.SurfaceObject, -Vector3.up, snapConfig.SurfaceType);
								transform2.position += vector3 + vector * snapConfig.OffsetFromSurface;
								return new SnapResult(new Plane(vector, gameObjectRayHit.HitPoint), gameObjectRayHit.HitPoint);
							}
						}
					}
					else
					{
						if (flag2)
						{
							Transform transform3 = snapConfig.SurfaceObject.transform;
							Vector3 position = transform3.position;
							Vector3 normalized = (transform2.position - position).normalized;
							float num2 = transform3.lossyScale.GetMaxAbsComp() * 0.5f;
							transform2.Align(normalized, snapConfig.AlignmentAxis);
							OBB obb = ObjectBounds.CalcHierarchyWorldOBB(root, queryConfig);
							if (!obb.IsValid)
							{
								return default(SnapResult);
							}
							BoxFace mostAlignedFace2 = BoxMath.GetMostAlignedFace(obb.Center, obb.Size, obb.Rotation, -normalized);
							List<Vector3> points = ObjectVertexCollect.CollectHierarchyVerts(root, mostAlignedFace2, 0.001f, 0.01f);
							Vector3 vector4 = position + normalized * num2;
							Plane plane = new Plane(normalized, vector4);
							Vector3 vector5 = CalculateSitOnSurfaceOffset(obb, plane, 0f);
							transform2.position += vector5;
							obb.Center += vector5;
							Vector3Ex.OffsetPoints(points, vector5);
							transform2.position += normalized * snapConfig.OffsetFromSurface;
							return new SnapResult(plane, vector4);
						}
						transform2.Align(snapConfig.SurfaceHitNormal, snapConfig.AlignmentAxis);
						OBB oBB2 = ObjectBounds.CalcHierarchyWorldOBB(root, queryConfig);
						if (!oBB2.IsValid)
						{
							return default(SnapResult);
						}
						BoxFace mostAlignedFace3 = BoxMath.GetMostAlignedFace(oBB2.Center, oBB2.Size, oBB2.Rotation, -snapConfig.SurfaceHitNormal);
						List<Vector3> list2 = ObjectVertexCollect.CollectHierarchyVerts(root, mostAlignedFace3, 0.001f, 0.01f);
						if (list2.Count != 0)
						{
							Vector3 pointCloudCenter2 = Vector3Ex.GetPointCloudCenter(list2);
							float magnitude = ObjectBounds.CalcMeshWorldAABB(snapConfig.SurfaceObject).Extents.magnitude;
							Vector3 origin = pointCloudCenter2 + snapConfig.SurfaceHitNormal * magnitude;
							Ray ray2 = new Ray(origin, -snapConfig.SurfaceHitNormal);
							GameObjectRayHit gameObjectRayHit2 = surfaceRaycaster.Raycast(ray2);
							if (gameObjectRayHit2 != null)
							{
								Vector3 hitNormal = gameObjectRayHit2.HitNormal;
								transform2.Align(hitNormal, snapConfig.AlignmentAxis);
								oBB2 = ObjectBounds.CalcHierarchyWorldOBB(root, queryConfig);
								Vector3 vector6 = CalculateSitOnSurfaceOffset(oBB2, gameObjectRayHit2.HitPlane, 0f);
								transform2.position += vector6;
								transform2.position += hitNormal * snapConfig.OffsetFromSurface;
								return new SnapResult(new Plane(hitNormal, gameObjectRayHit2.HitPoint), gameObjectRayHit2.HitPoint);
							}
							Vector3 surfaceHitNormal = snapConfig.SurfaceHitNormal;
							transform2.Align(surfaceHitNormal, snapConfig.AlignmentAxis);
							oBB2 = ObjectBounds.CalcHierarchyWorldOBB(root, queryConfig);
							Vector3 vector7 = CalculateSitOnSurfaceOffset(oBB2, snapConfig.SurfaceHitPlane, 0f);
							transform2.position += vector7;
							transform2.position += surfaceHitNormal * snapConfig.OffsetFromSurface;
							return new SnapResult(snapConfig.SurfaceHitPlane, snapConfig.SurfaceHitPlane.ProjectPoint(pointCloudCenter2));
						}
					}
				}
				else
				{
					OBB obb2 = ObjectBounds.CalcHierarchyWorldOBB(root, queryConfig);
					if (!obb2.IsValid)
					{
						return default(SnapResult);
					}
					if (flag3 || (!flag2 && snapConfig.SurfaceType == Type.Mesh))
					{
						Ray ray3 = new Ray(obb2.Center, flag3 ? (-Vector3.up) : (-snapConfig.SurfaceHitNormal));
						GameObjectRayHit gameObjectRayHit3 = surfaceRaycaster.Raycast(ray3);
						if (gameObjectRayHit3 != null)
						{
							Vector3 vector8 = CalculateSitOnSurfaceOffset(obb2, gameObjectRayHit3.HitPlane, 0f);
							transform2.position += vector8;
							if (flag3)
							{
								obb2.Center += vector8;
								BoxFace mostAlignedFace4 = BoxMath.GetMostAlignedFace(obb2.Center, obb2.Size, obb2.Rotation, -gameObjectRayHit3.HitNormal);
								Vector3 vector9 = CalculateEmbedVector(ObjectVertexCollect.CollectHierarchyVerts(root, mostAlignedFace4, 0.001f, 0.01f), snapConfig.SurfaceObject, -Vector3.up, snapConfig.SurfaceType);
								transform2.position += vector9;
							}
							transform2.position += gameObjectRayHit3.HitNormal * snapConfig.OffsetFromSurface;
							return new SnapResult(gameObjectRayHit3.HitPlane, gameObjectRayHit3.HitPoint);
						}
						if (!flag2 && snapConfig.SurfaceType == Type.Mesh)
						{
							Vector3 vector10 = CalculateSitOnSurfaceOffset(obb2, snapConfig.SurfaceHitPlane, 0f);
							transform2.position += vector10;
							transform2.position += snapConfig.SurfaceHitNormal * snapConfig.OffsetFromSurface;
							return new SnapResult(snapConfig.SurfaceHitPlane, snapConfig.SurfaceHitPlane.ProjectPoint(obb2.Center));
						}
					}
					else if (flag2)
					{
						Transform transform4 = snapConfig.SurfaceObject.transform;
						Vector3 position2 = transform4.position;
						Vector3 normalized2 = (transform2.position - position2).normalized;
						float num3 = transform4.lossyScale.GetMaxAbsComp() * 0.5f;
						BoxFace mostAlignedFace5 = BoxMath.GetMostAlignedFace(obb2.Center, obb2.Size, obb2.Rotation, -normalized2);
						List<Vector3> points2 = ObjectVertexCollect.CollectHierarchyVerts(root, mostAlignedFace5, 0.001f, 0.01f);
						Vector3 vector11 = position2 + normalized2 * num3;
						Plane plane2 = new Plane(normalized2, vector11);
						Vector3 vector12 = CalculateSitOnSurfaceOffset(obb2, plane2, 0f);
						transform2.position += vector12;
						obb2.Center += vector12;
						Vector3Ex.OffsetPoints(points2, vector12);
						transform2.position += normalized2 * snapConfig.OffsetFromSurface;
						return new SnapResult(plane2, vector11);
					}
				}
			}
			if (snapConfig.SurfaceType == Type.SceneGrid)
			{
				OBB obb3 = ObjectBounds.CalcHierarchyWorldOBB(root, queryConfig);
				if (!obb3.IsValid)
				{
					return default(SnapResult);
				}
				Transform transform5 = root.transform;
				if (snapConfig.AlignAxis)
				{
					transform5.Align(snapConfig.SurfaceHitNormal, snapConfig.AlignmentAxis);
					obb3 = ObjectBounds.CalcHierarchyWorldOBB(root, queryConfig);
				}
				transform5.position += CalculateSitOnSurfaceOffset(obb3, snapConfig.SurfaceHitPlane, snapConfig.OffsetFromSurface);
				return new SnapResult(snapConfig.SurfaceHitPlane, snapConfig.SurfaceHitPlane.ProjectPoint(obb3.Center));
			}
			return default(SnapResult);
		}

		public static Vector3 CalculateSitOnSurfaceOffset(OBB obb, Plane surfacePlane, float offsetFromSurface)
		{
			List<Vector3> cornerPoints = obb.GetCornerPoints();
			int num = surfacePlane.GetFurthestPtBehind(cornerPoints);
			if (num < 0)
			{
				num = surfacePlane.GetClosestPtInFrontOrOnPlane(cornerPoints);
			}
			if (num >= 0)
			{
				Vector3 vector = cornerPoints[num];
				return surfacePlane.ProjectPoint(vector) - vector + surfacePlane.normal * offsetFromSurface;
			}
			return Vector3.zero;
		}

		public static Vector3 CalculateSitOnSurfaceOffset(AABB aabb, Plane surfacePlane, float offsetFromSurface)
		{
			List<Vector3> cornerPoints = aabb.GetCornerPoints();
			int num = surfacePlane.GetFurthestPtBehind(cornerPoints);
			if (num < 0)
			{
				num = surfacePlane.GetClosestPtInFrontOrOnPlane(cornerPoints);
			}
			if (num >= 0)
			{
				Vector3 vector = cornerPoints[num];
				return surfacePlane.ProjectPoint(vector) - vector + surfacePlane.normal * offsetFromSurface;
			}
			return Vector3.zero;
		}

		public static Vector3 CalculateEmbedVector(List<Vector3> embedPoints, GameObject embedSurface, Vector3 embedDirection, Type surfaceType)
		{
			SurfaceRaycaster surfaceRaycaster = CreateSurfaceRaycaster(surfaceType, embedSurface, raycastReverse: false);
			bool flag = false;
			float num = float.MinValue;
			foreach (Vector3 embedPoint in embedPoints)
			{
				Ray ray = new Ray(embedPoint, -embedDirection);
				GameObjectRayHit gameObjectRayHit = surfaceRaycaster.Raycast(ray);
				if (gameObjectRayHit != null)
				{
					continue;
				}
				ray = new Ray(embedPoint, embedDirection);
				gameObjectRayHit = surfaceRaycaster.Raycast(ray);
				if (gameObjectRayHit != null)
				{
					float sqrMagnitude = (embedPoint - gameObjectRayHit.HitPoint).sqrMagnitude;
					if (sqrMagnitude > num)
					{
						num = sqrMagnitude;
						flag = true;
					}
				}
			}
			if (flag)
			{
				return embedDirection * Mathf.Sqrt(num);
			}
			return Vector3.zero;
		}

		private static SurfaceRaycaster CreateSurfaceRaycaster(Type surfaceType, GameObject surfaceObject, bool raycastReverse)
		{
			switch (surfaceType)
			{
			case Type.Mesh:
			case Type.TerrainMesh:
			case Type.SphericalMesh:
				return new MeshSurfaceRaycaster(surfaceObject, raycastReverse);
			case Type.UnityTerrain:
				return new TerrainSurfaceRaycaster(surfaceObject, raycastReverse);
			default:
				return null;
			}
		}
	}
}
