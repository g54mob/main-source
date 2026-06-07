using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class DeviceObjectGrabSession
	{
		private enum State
		{
			Inactive = 0,
			ActiveSnapToSurface = 1,
			ActiveRotate = 2,
			ActiveRotateAroundAnchor = 3,
			ActiveScale = 4,
			ActiveOffsetFromSurface = 5,
			ActiveAnchorAdjust = 6,
			ActiveOffsetFromAnchor = 7
		}

		public enum GrabSurfaceType
		{
			Invalid = 0,
			Mesh = 1,
			SphericalMesh = 2,
			UnityTerrain = 3,
			TerrainMesh = 4,
			Grid = 5
		}

		private struct GrabSurfaceInfo
		{
			public GrabSurfaceType SurfaceType;

			public Vector3 AnchorPoint;

			public Vector3 AnchorNormal;

			public Plane AnchorPlane;

			public SceneRaycastHit SceneRaycastHit;
		}

		private class GrabTarget
		{
			private GameObject _gameObject;

			private Transform _transform;

			public Vector3 AnchorVector;

			public Vector3 WorldScaleSnapshot;

			public Vector3 AnchorVectorSnapshot;

			public Plane SittingPlane;

			public Vector3 SittingPoint;

			public float OffsetFromSurface;

			public GameObject GameObject => _gameObject;

			public Transform Transform => _transform;

			public GrabTarget(GameObject parentObject)
			{
				_gameObject = parentObject;
				_transform = _gameObject.transform;
			}
		}

		private State _state;

		private ObjectGrabSettings _sharedSettings;

		private ObjectGrabHotkeys _sharedHotkeys;

		private ObjectGrabLookAndFeel _sharedLookAndFeel;

		private List<GameObject> _targetParents = new List<GameObject>();

		private List<GrabTarget> _grabTargets = new List<GrabTarget>();

		private GrabSurfaceInfo _grabSurfaceInfo;

		private int _deltaCaptureId;

		private TransformAxis[] _possibleAlignmentAxes = new TransformAxis[6]
		{
			TransformAxis.PositiveX,
			TransformAxis.NegativeX,
			TransformAxis.PositiveY,
			TransformAxis.NegativeY,
			TransformAxis.PositiveZ,
			TransformAxis.NegativeZ
		};

		private List<LocalTransformSnapshot> _preTargetTransformSnapshots;

		public ObjectGrabSettings SharedSettings
		{
			get
			{
				return _sharedSettings;
			}
			set
			{
				if (value != null)
				{
					_sharedSettings = value;
				}
			}
		}

		public ObjectGrabHotkeys SharedHotkeys
		{
			get
			{
				return _sharedHotkeys;
			}
			set
			{
				if (value != null)
				{
					_sharedHotkeys = value;
				}
			}
		}

		public ObjectGrabLookAndFeel SharedLookAndFeel
		{
			get
			{
				return _sharedLookAndFeel;
			}
			set
			{
				if (value != null)
				{
					_sharedLookAndFeel = value;
				}
			}
		}

		public bool IsActive => _state != State.Inactive;

		public event ObjectGrabSessionBeginHandler SessionBegin;

		public event ObjectGrabSessionEndHandler SessionEnd;

		public void Render()
		{
			if (SharedLookAndFeel == null || !IsActive || _grabSurfaceInfo.SurfaceType == GrabSurfaceType.Invalid)
			{
				return;
			}
			Material simpleColor = Singleton<MaterialPool>.Get.SimpleColor;
			if (SharedLookAndFeel.DrawAnchorLines)
			{
				List<Vector3> list = new List<Vector3>(_grabTargets.Count * 2);
				foreach (GrabTarget grabTarget in _grabTargets)
				{
					list.Add(grabTarget.Transform.position);
					list.Add(_grabSurfaceInfo.AnchorPoint);
				}
				simpleColor.SetZTestAlways();
				simpleColor.SetColor(_sharedLookAndFeel.AnchorLineColor);
				simpleColor.SetPass(0);
				GLRenderer.DrawLines3D(list);
			}
			if (SharedLookAndFeel.DrawObjectBoxes)
			{
				simpleColor.SetZTestLess();
				simpleColor.SetColor(SharedLookAndFeel.ObjectBoxWireColor);
				simpleColor.SetPass(0);
				ObjectBounds.QueryConfig objectBoundsQConfig = GetObjectBoundsQConfig();
				foreach (GrabTarget grabTarget2 in _grabTargets)
				{
					OBB box = ObjectBounds.CalcHierarchyWorldOBB(grabTarget2.GameObject, objectBoundsQConfig);
					if (box.IsValid)
					{
						GraphicsEx.DrawWireBox(box);
					}
				}
			}
			if (SharedLookAndFeel.DrawObjectPosTicks)
			{
				simpleColor.SetColor(SharedLookAndFeel.ObjectPosTickColor);
				simpleColor.SetPass(0);
				foreach (GrabTarget grabTarget3 in _grabTargets)
				{
					GLRenderer.DrawRect2D(RectEx.FromCenterAndSize(Camera.current.WorldToScreenPoint(grabTarget3.Transform.position), Vector2Ex.FromValue(SharedLookAndFeel.ObjectPosTickSize)), Camera.current);
				}
			}
			if (SharedLookAndFeel.DrawAnchorPosTick)
			{
				simpleColor.SetColor(SharedLookAndFeel.AnchorPosTickColor);
				simpleColor.SetPass(0);
				GLRenderer.DrawRect2D(RectEx.FromCenterAndSize(Camera.current.WorldToScreenPoint(_grabSurfaceInfo.AnchorPoint), Vector2Ex.FromValue(SharedLookAndFeel.AnchorPosTickSize)), Camera.current);
			}
		}

		public void Update(IEnumerable<GameObject> targetObjects)
		{
			if (SharedHotkeys == null || SharedSettings == null)
			{
				return;
			}
			if (_state == State.Inactive)
			{
				if (_sharedHotkeys.ToggleGrab.IsActiveInFrame())
				{
					Begin(targetObjects);
				}
			}
			else if (_sharedHotkeys.ToggleGrab.IsActiveInFrame())
			{
				End();
			}
			if (!IsActive)
			{
				return;
			}
			State state = _state;
			IInputDevice device = MonoSingleton<RTInputDevice>.Get.Device;
			if (SharedHotkeys.EnableOffsetFromAnchor.IsActive())
			{
				if (_state != State.ActiveOffsetFromAnchor && device.CreateDeltaCapture(device.GetPositionYAxisUp(), out _deltaCaptureId))
				{
					StoreGrabTargetsAnchorVectorSnapshots();
					_state = State.ActiveOffsetFromAnchor;
				}
			}
			else if (SharedHotkeys.EnableAnchorAdjust.IsActive())
			{
				_state = State.ActiveAnchorAdjust;
			}
			else if (SharedHotkeys.EnableRotation.IsActive())
			{
				_state = State.ActiveRotate;
			}
			else if (SharedHotkeys.EnableRotationAroundAnchor.IsActive())
			{
				_state = State.ActiveRotateAroundAnchor;
			}
			else if (SharedHotkeys.EnableScaling.IsActive())
			{
				if (_state != State.ActiveScale && device.CreateDeltaCapture(device.GetPositionYAxisUp(), out _deltaCaptureId))
				{
					StoreGrabTargetsWorldScaleSnapshots();
					_state = State.ActiveScale;
				}
			}
			else if (SharedHotkeys.EnableOffsetFromSurface.IsActive())
			{
				_state = State.ActiveOffsetFromSurface;
			}
			else
			{
				_state = State.ActiveSnapToSurface;
			}
			if (_state != State.ActiveScale && _state != State.ActiveOffsetFromAnchor)
			{
				device.RemoveDeltaCapture(_deltaCaptureId);
			}
			if (_state != State.ActiveOffsetFromAnchor && _state != State.ActiveRotateAroundAnchor && !IdentifyGrabSurface())
			{
				return;
			}
			if ((state == State.ActiveOffsetFromAnchor && _state != State.ActiveOffsetFromAnchor) || (state == State.ActiveRotateAroundAnchor && _state != State.ActiveRotateAroundAnchor))
			{
				CalculateGrabTargetsAnchorVectors();
			}
			if (_state == State.ActiveSnapToSurface && SharedHotkeys.NextAlignmentAxis.IsActiveInFrame())
			{
				SwitchToNextAlignmentAxis();
			}
			if (MonoSingleton<RTInputDevice>.Get.Device.WasMoved())
			{
				if (_state == State.ActiveOffsetFromAnchor)
				{
					OffsetTargetsFromAnchor();
				}
				else if (_state == State.ActiveAnchorAdjust)
				{
					CalculateGrabTargetsAnchorVectors();
				}
				else if (_state == State.ActiveSnapToSurface)
				{
					SnapTargetsToSurface();
				}
				else if (_state == State.ActiveRotate)
				{
					RotateTargets();
				}
				else if (_state == State.ActiveRotateAroundAnchor)
				{
					RotateTargetsAroundAnchor();
				}
				else if (_state == State.ActiveScale)
				{
					ScaleTargets();
				}
				else if (_state == State.ActiveOffsetFromSurface)
				{
					OffsetTargetsFromSurface();
				}
			}
		}

		public void End()
		{
			if (_state != State.Inactive)
			{
				_grabTargets.Clear();
				_state = State.Inactive;
				_grabSurfaceInfo.SurfaceType = GrabSurfaceType.Invalid;
				new PostObjectTransformsChangedAction(_preTargetTransformSnapshots, LocalTransformSnapshot.GetSnapshotCollection(_targetParents)).Execute();
				_targetParents.Clear();
				if (this.SessionEnd != null)
				{
					this.SessionEnd();
				}
			}
		}

		private bool Begin(IEnumerable<GameObject> targetObjects)
		{
			if (_state != State.Inactive || SharedSettings == null || _sharedHotkeys == null || targetObjects == null)
			{
				return false;
			}
			if (SharedSettings.SurfaceFlags == (ObjectGrabSurfaceFlags)0)
			{
				return false;
			}
			if (!IdentifyGrabTargets(targetObjects))
			{
				return false;
			}
			if (!IdentifyGrabSurface())
			{
				_grabTargets.Clear();
				return false;
			}
			CalculateGrabTargetsAnchorVectors();
			_state = State.ActiveSnapToSurface;
			_preTargetTransformSnapshots = LocalTransformSnapshot.GetSnapshotCollection(_targetParents);
			SnapTargetsToSurface();
			CalculateGrabTargetsAnchorVectors();
			if (this.SessionBegin != null)
			{
				this.SessionBegin();
			}
			return true;
		}

		private void SnapTargetsToSurface()
		{
			if (_grabSurfaceInfo.SurfaceType == GrabSurfaceType.Invalid)
			{
				return;
			}
			ObjectSurfaceSnap.SnapConfig snapConfig = new ObjectSurfaceSnap.SnapConfig
			{
				SurfaceHitPoint = _grabSurfaceInfo.AnchorPoint,
				SurfaceHitNormal = _grabSurfaceInfo.AnchorNormal,
				SurfaceHitPlane = _grabSurfaceInfo.AnchorPlane,
				SurfaceObject = (_grabSurfaceInfo.SceneRaycastHit.WasAnObjectHit ? _grabSurfaceInfo.SceneRaycastHit.ObjectHit.HitObject : null),
				SurfaceType = ObjectSurfaceSnap.Type.UnityTerrain
			};
			if (_grabSurfaceInfo.SurfaceType == GrabSurfaceType.Mesh)
			{
				snapConfig.SurfaceType = ObjectSurfaceSnap.Type.Mesh;
			}
			else if (_grabSurfaceInfo.SurfaceType == GrabSurfaceType.Grid)
			{
				snapConfig.SurfaceType = ObjectSurfaceSnap.Type.SceneGrid;
			}
			else if (_grabSurfaceInfo.SurfaceType == GrabSurfaceType.SphericalMesh)
			{
				snapConfig.SurfaceType = ObjectSurfaceSnap.Type.SphericalMesh;
			}
			else if (_grabSurfaceInfo.SurfaceType == GrabSurfaceType.TerrainMesh)
			{
				snapConfig.SurfaceType = ObjectSurfaceSnap.Type.TerrainMesh;
			}
			foreach (GrabTarget grabTarget in _grabTargets)
			{
				if (!(grabTarget.GameObject == null))
				{
					grabTarget.Transform.position = _grabSurfaceInfo.AnchorPoint + grabTarget.AnchorVector;
					ObjectLayerGrabSettings layerGrabSettings = SharedSettings.GetLayerGrabSettings(grabTarget.GameObject.layer);
					if (layerGrabSettings.IsActive)
					{
						snapConfig.AlignAxis = layerGrabSettings.AlignAxis;
						snapConfig.AlignmentAxis = layerGrabSettings.AlignmentAxis;
						snapConfig.OffsetFromSurface = layerGrabSettings.DefaultOffsetFromSurface + grabTarget.OffsetFromSurface;
					}
					else
					{
						snapConfig.AlignAxis = SharedSettings.AlignAxis;
						snapConfig.AlignmentAxis = SharedSettings.AlignmentAxis;
						snapConfig.OffsetFromSurface = SharedSettings.DefaultOffsetFromSurface + grabTarget.OffsetFromSurface;
					}
					ObjectSurfaceSnap.SnapResult snapResult = ObjectSurfaceSnap.SnapHierarchy(grabTarget.GameObject, snapConfig);
					if (snapResult.Success)
					{
						grabTarget.SittingPlane = snapResult.SittingPlane;
						grabTarget.SittingPoint = snapResult.SittingPoint;
					}
				}
			}
		}

		private void RotateTargets()
		{
			IInputDevice device = MonoSingleton<RTInputDevice>.Get.Device;
			if (!device.WasMoved())
			{
				return;
			}
			float angle = device.GetFrameDelta().x * SharedSettings.RotationSensitivity;
			foreach (GrabTarget grabTarget in _grabTargets)
			{
				if (grabTarget == null)
				{
					continue;
				}
				ObjectLayerGrabSettings layerGrabSettings = SharedSettings.GetLayerGrabSettings(grabTarget.GameObject.layer);
				if (layerGrabSettings.IsActive)
				{
					if (layerGrabSettings.AlignAxis)
					{
						grabTarget.Transform.Rotate(grabTarget.SittingPlane.normal, angle, Space.World);
					}
					else
					{
						grabTarget.Transform.Rotate(Vector3.up, angle, Space.World);
					}
				}
				else if (SharedSettings.AlignAxis)
				{
					grabTarget.Transform.Rotate(grabTarget.SittingPlane.normal, angle, Space.World);
				}
				else
				{
					grabTarget.Transform.Rotate(Vector3.up, angle, Space.World);
				}
			}
			CalculateGrabTargetsAnchorVectors();
		}

		private void RotateTargetsAroundAnchor()
		{
			IInputDevice device = MonoSingleton<RTInputDevice>.Get.Device;
			if (!device.WasMoved())
			{
				return;
			}
			float angle = device.GetFrameDelta().x * SharedSettings.RotationSensitivity;
			foreach (GrabTarget grabTarget in _grabTargets)
			{
				if (grabTarget == null)
				{
					continue;
				}
				ObjectLayerGrabSettings layerGrabSettings = SharedSettings.GetLayerGrabSettings(grabTarget.GameObject.layer);
				if (layerGrabSettings.IsActive)
				{
					if (layerGrabSettings.AlignAxis)
					{
						Quaternion quaternion = Quaternion.AngleAxis(angle, _grabSurfaceInfo.AnchorNormal);
						grabTarget.Transform.RotateAroundPivot(quaternion, _grabSurfaceInfo.AnchorPoint);
						grabTarget.AnchorVector = quaternion * grabTarget.AnchorVector;
					}
					else
					{
						Quaternion quaternion2 = Quaternion.AngleAxis(angle, Vector3.up);
						grabTarget.Transform.RotateAroundPivot(quaternion2, _grabSurfaceInfo.AnchorPoint);
						grabTarget.AnchorVector = quaternion2 * grabTarget.AnchorVector;
					}
				}
				else if (SharedSettings.AlignAxis)
				{
					Quaternion quaternion3 = Quaternion.AngleAxis(angle, _grabSurfaceInfo.AnchorNormal);
					grabTarget.Transform.RotateAroundPivot(quaternion3, _grabSurfaceInfo.AnchorPoint);
					grabTarget.AnchorVector = quaternion3 * grabTarget.AnchorVector;
				}
				else
				{
					Quaternion quaternion4 = Quaternion.AngleAxis(angle, Vector3.up);
					grabTarget.Transform.RotateAroundPivot(quaternion4, _grabSurfaceInfo.AnchorPoint);
					grabTarget.AnchorVector = quaternion4 * grabTarget.AnchorVector;
				}
			}
			SnapTargetsToSurface();
		}

		private void ScaleTargets()
		{
			IInputDevice device = MonoSingleton<RTInputDevice>.Get.Device;
			if (!device.WasMoved())
			{
				return;
			}
			foreach (GrabTarget grabTarget in _grabTargets)
			{
				if (grabTarget != null && grabTarget.GameObject.layer == LayerNames.LEScalable)
				{
					float value = 1f + device.GetCaptureDelta(_deltaCaptureId).x * SharedSettings.ScaleSensitivity;
					Vector3 worldScale = grabTarget.WorldScaleSnapshot * Mathf.Clamp(value, 0.05f, float.PositiveInfinity);
					grabTarget.GameObject.SetHierarchyWorldScaleByPivot(worldScale, grabTarget.SittingPoint + grabTarget.SittingPlane.normal * grabTarget.OffsetFromSurface);
				}
			}
			CalculateGrabTargetsAnchorVectors();
		}

		private void OffsetTargetsFromSurface()
		{
			IInputDevice device = MonoSingleton<RTInputDevice>.Get.Device;
			if (!device.WasMoved())
			{
				return;
			}
			float num = device.GetFrameDelta().x * SharedSettings.OffsetFromSurfaceSensitivity;
			foreach (GrabTarget grabTarget in _grabTargets)
			{
				if (grabTarget == null)
				{
					continue;
				}
				ObjectLayerGrabSettings layerGrabSettings = SharedSettings.GetLayerGrabSettings(grabTarget.GameObject.layer);
				if (layerGrabSettings.IsActive)
				{
					if (layerGrabSettings.AlignAxis)
					{
						grabTarget.Transform.position += grabTarget.SittingPlane.normal * num;
						grabTarget.OffsetFromSurface += num;
					}
					else
					{
						grabTarget.Transform.position += Vector3.up * num;
						grabTarget.OffsetFromSurface += num;
					}
				}
				else if (SharedSettings.AlignAxis)
				{
					grabTarget.Transform.position += grabTarget.SittingPlane.normal * num;
					grabTarget.OffsetFromSurface += num;
				}
				else
				{
					grabTarget.Transform.position += Vector3.up * num;
					grabTarget.OffsetFromSurface += num;
				}
			}
			CalculateGrabTargetsAnchorVectors();
		}

		private void OffsetTargetsFromAnchor()
		{
			IInputDevice device = MonoSingleton<RTInputDevice>.Get.Device;
			if (!device.WasMoved())
			{
				return;
			}
			float num = 1f + device.GetCaptureDelta(_deltaCaptureId).x * SharedSettings.OffsetFromAnchorSensitivity;
			foreach (GrabTarget grabTarget in _grabTargets)
			{
				if (grabTarget != null)
				{
					grabTarget.Transform.position = _grabSurfaceInfo.AnchorPoint + grabTarget.AnchorVectorSnapshot * num;
				}
			}
			CalculateGrabTargetsAnchorVectors();
			SnapTargetsToSurface();
		}

		private bool IdentifyGrabTargets(IEnumerable<GameObject> targetObjects)
		{
			_targetParents = GameObjectEx.FilterParentsOnly(targetObjects);
			if (_targetParents == null || _targetParents.Count == 0)
			{
				return false;
			}
			_grabTargets.Clear();
			foreach (GameObject targetParent in _targetParents)
			{
				if (!targetParent.HierarchyHasObjectsOfType(GameObjectType.Terrain))
				{
					_grabTargets.Add(new GrabTarget(targetParent));
				}
			}
			return _grabTargets.Count != 0;
		}

		private void CalculateGrabTargetsAnchorVectors()
		{
			foreach (GrabTarget grabTarget in _grabTargets)
			{
				grabTarget.AnchorVector = grabTarget.Transform.position - _grabSurfaceInfo.AnchorPoint;
			}
		}

		private void StoreGrabTargetsWorldScaleSnapshots()
		{
			foreach (GrabTarget grabTarget in _grabTargets)
			{
				grabTarget.WorldScaleSnapshot = grabTarget.Transform.lossyScale;
			}
		}

		private void StoreGrabTargetsAnchorVectorSnapshots()
		{
			foreach (GrabTarget grabTarget in _grabTargets)
			{
				grabTarget.AnchorVectorSnapshot = grabTarget.AnchorVector;
			}
		}

		private bool IdentifyGrabSurface()
		{
			_grabSurfaceInfo.SurfaceType = GrabSurfaceType.Invalid;
			SceneRaycastFilter sceneRaycastFilter = new SceneRaycastFilter();
			sceneRaycastFilter.LayerMask = SharedSettings.SurfaceLayers;
			if ((SharedSettings.SurfaceFlags & ObjectGrabSurfaceFlags.Mesh) != 0)
			{
				sceneRaycastFilter.AllowedObjectTypes.Add(GameObjectType.Mesh);
			}
			if ((SharedSettings.SurfaceFlags & ObjectGrabSurfaceFlags.Terrain) != 0)
			{
				sceneRaycastFilter.AllowedObjectTypes.Add(GameObjectType.Terrain);
			}
			foreach (GrabTarget grabTarget in _grabTargets)
			{
				sceneRaycastFilter.IgnoreObjects.AddRange(grabTarget.GameObject.GetAllChildrenAndSelf());
			}
			IInputDevice device = MonoSingleton<RTInputDevice>.Get.Device;
			SceneRaycastHit sceneRaycastHit = MonoSingleton<RTScene>.Get.Raycast(device.GetRay(MonoSingleton<RTFocusCamera>.Get.TargetCamera), SceneRaycastPrecision.BestFit, sceneRaycastFilter);
			if (!sceneRaycastHit.WasAnythingHit)
			{
				return false;
			}
			_grabSurfaceInfo.SceneRaycastHit = sceneRaycastHit;
			if (sceneRaycastHit.WasAnObjectHit)
			{
				_grabSurfaceInfo.AnchorNormal = sceneRaycastHit.ObjectHit.HitNormal;
				_grabSurfaceInfo.AnchorPoint = sceneRaycastHit.ObjectHit.HitPoint;
				_grabSurfaceInfo.AnchorPlane = sceneRaycastHit.ObjectHit.HitPlane;
				if (sceneRaycastHit.ObjectHit.HitObject.GetGameObjectType() == GameObjectType.Mesh)
				{
					_grabSurfaceInfo.SurfaceType = GrabSurfaceType.Mesh;
					int layer = sceneRaycastHit.ObjectHit.HitObject.layer;
					if (LayerEx.IsLayerBitSet(SharedSettings.SphericalMeshLayers, layer))
					{
						_grabSurfaceInfo.SurfaceType = GrabSurfaceType.SphericalMesh;
					}
					else if (LayerEx.IsLayerBitSet(SharedSettings.TerrainMeshLayers, layer))
					{
						_grabSurfaceInfo.SurfaceType = GrabSurfaceType.TerrainMesh;
					}
				}
				else
				{
					_grabSurfaceInfo.SurfaceType = GrabSurfaceType.UnityTerrain;
				}
			}
			else if (sceneRaycastHit.WasGridHit && (SharedSettings.SurfaceFlags & ObjectGrabSurfaceFlags.Grid) != 0)
			{
				_grabSurfaceInfo.AnchorNormal = sceneRaycastHit.GridHit.HitNormal;
				_grabSurfaceInfo.AnchorPoint = sceneRaycastHit.GridHit.HitPoint;
				_grabSurfaceInfo.AnchorPlane = sceneRaycastHit.GridHit.HitPlane;
				_grabSurfaceInfo.SurfaceType = GrabSurfaceType.Grid;
			}
			return true;
		}

		private void SwitchToNextAlignmentAxis()
		{
			if (!SharedSettings.AlignAxis)
			{
				return;
			}
			int alignmentAxis = (int)SharedSettings.AlignmentAxis;
			if (alignmentAxis + 1 == _possibleAlignmentAxes.Length)
			{
				SharedSettings.AlignmentAxis = _possibleAlignmentAxes[0];
			}
			else
			{
				alignmentAxis++;
				SharedSettings.AlignmentAxis = _possibleAlignmentAxes[alignmentAxis];
			}
			foreach (GrabTarget grabTarget in _grabTargets)
			{
				if (grabTarget.GameObject != null)
				{
					grabTarget.Transform.rotation = Quaternion.identity;
				}
			}
			SnapTargetsToSurface();
			CalculateGrabTargetsAnchorVectors();
		}

		private ObjectBounds.QueryConfig GetObjectBoundsQConfig()
		{
			return new ObjectBounds.QueryConfig
			{
				NoVolumeSize = Vector3.zero,
				ObjectTypes = (GameObjectType.Mesh | GameObjectType.Sprite)
			};
		}
	}
}
