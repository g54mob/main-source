using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class GizmoObjectVertexSnapDrag3D : GizmoDragSession
	{
		private IEnumerable<GameObject> _targetObjects;

		private Vector3 _snapPivot;

		private bool _isActive;

		private List<GameObject> _destinationObjects = new List<GameObject>();

		private GizmoObjectVertexSnapSettings _settings = new GizmoObjectVertexSnapSettings();

		public override bool IsActive => _isActive;

		public override GizmoDragChannel DragChannel => GizmoDragChannel.Offset;

		public Vector3 SnapPivot => _snapPivot;

		public GizmoObjectVertexSnapSettings Settings
		{
			set
			{
				if (value != null)
				{
					_settings = value;
				}
			}
		}

		public void SetTargetObjects(IEnumerable<GameObject> targetObjects)
		{
			if (!IsActive)
			{
				_targetObjects = targetObjects;
			}
		}

		public bool SelectSnapPivotPoint(Gizmo gizmo)
		{
			if (_targetObjects == null || IsActive)
			{
				return false;
			}
			return GetWorldPointClosestToInputDevice(gizmo.FocusCamera, _targetObjects, out _snapPivot);
		}

		protected override bool DoBeginSession()
		{
			if (_targetObjects == null)
			{
				return false;
			}
			_isActive = true;
			return true;
		}

		protected override bool DoUpdateSession()
		{
			GatherDestinationObjects();
			return true;
		}

		protected override void DoEndSession()
		{
			_isActive = false;
			_destinationObjects.Clear();
		}

		protected override void CalculateDragValues()
		{
			Camera targetCamera = MonoSingleton<RTFocusCamera>.Get.TargetCamera;
			_relativeDragOffset = Vector3.zero;
			if (_destinationObjects.Count != 0 && _settings.CanSnapToObjectVerts)
			{
				if (GetWorldPointClosestToInputDevice(targetCamera, _destinationObjects, out var point))
				{
					_relativeDragOffset = point - _snapPivot;
				}
			}
			else if (_settings.CanSnapToGrid)
			{
				Ray ray = MonoSingleton<RTInputDevice>.Get.Device.GetRay(targetCamera);
				XZGridRayHit xZGridRayHit = MonoSingleton<RTScene>.Get.RaycastSceneGridIfVisible(ray);
				if (xZGridRayHit != null)
				{
					List<Vector3> centerAndCorners = MonoSingleton<RTSceneGrid>.Get.CellFromWorldPoint(xZGridRayHit.HitPoint).GetCenterAndCorners();
					int pointClosestToPoint = Vector3Ex.GetPointClosestToPoint(centerAndCorners, xZGridRayHit.HitPoint);
					if (pointClosestToPoint >= 0)
					{
						_relativeDragOffset = centerAndCorners[pointClosestToPoint] - _snapPivot;
					}
				}
			}
			_snapPivot += _relativeDragOffset;
			_totalDragOffset += _relativeDragOffset;
		}

		protected bool GetWorldPointClosestToInputDevice(Camera focusCamera, IEnumerable<GameObject> gameObjects, out Vector3 point)
		{
			point = Vector3.zero;
			if (gameObjects == null)
			{
				return false;
			}
			if (!MonoSingleton<RTInputDevice>.Get.Device.HasPointer())
			{
				return false;
			}
			Vector2 vector = MonoSingleton<RTInputDevice>.Get.Device.GetPositionYAxisUp();
			float num = float.MaxValue;
			bool result = false;
			foreach (GameObject gameObject in gameObjects)
			{
				Mesh mesh = gameObject.GetMesh();
				if (mesh != null)
				{
					MeshVertexChunkCollection meshVertexChunkCollection = Singleton<MeshVertexChunkCollectionDb>.Get[mesh];
					if (meshVertexChunkCollection == null)
					{
						continue;
					}
					Matrix4x4 localToWorldMatrix = gameObject.transform.localToWorldMatrix;
					List<MeshVertexChunk> worldChunksHoveredByPoint = meshVertexChunkCollection.GetWorldChunksHoveredByPoint(vector, localToWorldMatrix, focusCamera);
					if (worldChunksHoveredByPoint.Count == 0)
					{
						MeshVertexChunk worldVertChunkClosestToScreenPt = meshVertexChunkCollection.GetWorldVertChunkClosestToScreenPt(vector, localToWorldMatrix, focusCamera);
						if (worldVertChunkClosestToScreenPt != null && worldVertChunkClosestToScreenPt.VertexCount != 0)
						{
							worldChunksHoveredByPoint.Add(worldVertChunkClosestToScreenPt);
						}
					}
					foreach (MeshVertexChunk item in worldChunksHoveredByPoint)
					{
						Vector3 worldVertClosestToScreenPt = item.GetWorldVertClosestToScreenPt(vector, localToWorldMatrix, focusCamera);
						Vector2 vector2 = focusCamera.WorldToScreenPoint(worldVertClosestToScreenPt);
						float sqrMagnitude = (vector - vector2).sqrMagnitude;
						if (sqrMagnitude < num)
						{
							num = sqrMagnitude;
							point = worldVertClosestToScreenPt;
							result = true;
						}
					}
					continue;
				}
				OBB oBB = ObjectBounds.CalcSpriteWorldOBB(gameObject);
				if (!oBB.IsValid)
				{
					continue;
				}
				List<Vector3> centerAndCornerPoints = oBB.GetCenterAndCornerPoints();
				List<Vector2> list = focusCamera.ConvertWorldToScreenPoints(centerAndCornerPoints);
				int pointClosestToPoint = Vector2Ex.GetPointClosestToPoint(list, vector);
				if (pointClosestToPoint >= 0)
				{
					Vector2 vector3 = list[pointClosestToPoint];
					float sqrMagnitude2 = (vector - vector3).sqrMagnitude;
					if (sqrMagnitude2 < num)
					{
						num = sqrMagnitude2;
						point = centerAndCornerPoints[pointClosestToPoint];
						result = true;
					}
				}
			}
			return result;
		}

		protected bool CanUseObjectAsSnapDestination(GameObject gameObject)
		{
			return _settings.IsLayerSnapDestination(gameObject.layer);
		}

		private void GatherDestinationObjects()
		{
			Camera focusCamera = MonoSingleton<RTFocusCamera>.Get.TargetCamera;
			_destinationObjects.Clear();
			IInputDevice device = MonoSingleton<RTInputDevice>.Get.Device;
			if (!device.HasPointer())
			{
				return;
			}
			Vector2 inputDevicePos = device.GetPositionYAxisUp();
			ObjectBounds.QueryConfig boundsQConfig = default(ObjectBounds.QueryConfig);
			boundsQConfig.ObjectTypes = GameObjectTypeHelper.AllCombined;
			boundsQConfig.NoVolumeSize = Vector3Ex.FromValue(1E-05f);
			List<GameObject> visibleObjects = MonoSingleton<RTFocusCamera>.Get.GetVisibleObjects();
			List<GameObject> targetObjects = new List<GameObject>(_targetObjects);
			visibleObjects.RemoveAll((GameObject a) => targetObjects.Contains(a) || !ObjectBounds.CalcScreenRect(a, focusCamera, boundsQConfig).Contains(inputDevicePos) || targetObjects.FindAll((GameObject b) => a.transform.IsChildOf(b.transform)).Count != 0);
			foreach (GameObject item in visibleObjects)
			{
				if (CanUseObjectAsSnapDestination(item))
				{
					GameObjectType gameObjectType = item.GetGameObjectType();
					if (gameObjectType == GameObjectType.Mesh || gameObjectType == GameObjectType.Sprite)
					{
						_destinationObjects.Add(item);
					}
				}
			}
		}
	}
}
