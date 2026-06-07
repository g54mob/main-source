using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class RTGizmosEngine : MonoSingleton<RTGizmosEngine>, IHoverableSceneEntityContainer
	{
		[SerializeField]
		private EditorToolbar _mainToolbar = new EditorToolbar(new EditorToolbarTab[2]
		{
			new EditorToolbarTab("General", "General gizmo engine settings."),
			new EditorToolbarTab("Scene gizmo", "Scene gizmo specific settings.")
		}, 2, Color.green);

		[SerializeField]
		private GizmoEngineSettings _settings = new GizmoEngineSettings();

		private GizmosEnginePipelineStage _pipelineStage;

		private Gizmo _draggedGizmo;

		private Gizmo _hoveredGizmo;

		private GizmoHoverInfo _gizmoHoverInfo;

		private List<Gizmo> _gizmos = new List<Gizmo>();

		private List<ISceneGizmo> _sceneGizmos = new List<ISceneGizmo>();

		private List<RTSceneGizmoCamera> _sceneGizmoCameras = new List<RTSceneGizmoCamera>();

		private List<Camera> _renderCameras = new List<Camera>();

		[SerializeField]
		private SceneGizmoLookAndFeel _sharedSceneGizmoLookAndFeel = new SceneGizmoLookAndFeel();

		public GizmoEngineSettings Settings => _settings;

		public GizmosEnginePipelineStage PipelineStage => _pipelineStage;

		public Camera RenderStageCamera => Camera.current;

		public bool HasHoveredSceneEntity => IsAnyGizmoHovered;

		public bool IsAnyGizmoHovered => _hoveredGizmo != null;

		public Gizmo HoveredGizmo => _hoveredGizmo;

		public Gizmo DraggedGizmo => _draggedGizmo;

		public int NumRenderCameras => _renderCameras.Count;

		public SceneGizmoLookAndFeel SharedSceneGizmoLookAndFeel => _sharedSceneGizmoLookAndFeel;

		public event GizmoEngineCanDoHoverUpdateHandler CanDoHoverUpdate;

		public void AddRenderCamera(Camera camera)
		{
			if (!IsRenderCamera(camera) && !IsSceneGizmoCamera(camera))
			{
				_renderCameras.Add(camera);
			}
		}

		public bool IsRenderCamera(Camera camera)
		{
			return _renderCameras.Contains(camera);
		}

		public void RemoveRenderCamera(Camera camera)
		{
			_renderCameras.Remove(camera);
		}

		public RTSceneGizmoCamera CreateSceneGizmoCamera(Camera sceneCamera, ISceneGizmoCamViewportUpdater viewportUpdater)
		{
			GameObject obj = new GameObject(typeof(RTSceneGizmoCamera).ToString());
			obj.transform.parent = MonoSingleton<RTGizmosEngine>.Get.transform;
			RTSceneGizmoCamera rTSceneGizmoCamera = obj.AddComponent<RTSceneGizmoCamera>();
			rTSceneGizmoCamera.ViewportUpdater = viewportUpdater;
			rTSceneGizmoCamera.SceneCamera = sceneCamera;
			_sceneGizmoCameras.Add(rTSceneGizmoCamera);
			return rTSceneGizmoCamera;
		}

		public bool IsSceneGizmoCamera(Camera camera)
		{
			int count = _sceneGizmoCameras.Count;
			for (int i = 0; i < count; i++)
			{
				if (_sceneGizmoCameras[i].Camera == camera)
				{
					return true;
				}
			}
			return false;
		}

		public ISceneGizmo GetSceneGizmoByCamera(Camera sceneCamera)
		{
			foreach (ISceneGizmo sceneGizmo in _sceneGizmos)
			{
				if (sceneGizmo.SceneCamera == sceneCamera)
				{
					return sceneGizmo;
				}
			}
			return null;
		}

		public Gizmo CreateGizmo()
		{
			Gizmo gizmo = new Gizmo();
			RegisterGizmo(gizmo);
			return gizmo;
		}

		public SceneGizmo CreateSceneGizmo(Camera sceneCamera)
		{
			if (GetSceneGizmoByCamera(sceneCamera) != null)
			{
				return null;
			}
			Gizmo gizmo = new Gizmo();
			RegisterGizmo(gizmo);
			SceneGizmo sceneGizmo = gizmo.AddBehaviour<SceneGizmo>();
			sceneGizmo.SceneGizmoCamera.SceneCamera = sceneCamera;
			sceneGizmo.SharedLookAndFeel = SharedSceneGizmoLookAndFeel;
			_sceneGizmos.Add(sceneGizmo);
			return sceneGizmo;
		}

		public MoveGizmo CreateMoveGizmo()
		{
			Gizmo gizmo = CreateGizmo();
			MoveGizmo moveGizmo = new MoveGizmo();
			gizmo.AddBehaviour(moveGizmo);
			return moveGizmo;
		}

		public ObjectTransformGizmo CreateObjectMoveGizmo()
		{
			ObjectTransformGizmo objectTransformGizmo = CreateMoveGizmo().Gizmo.AddBehaviour<ObjectTransformGizmo>();
			objectTransformGizmo.SetTransformChannelFlags(ObjectTransformGizmo.Channels.Position);
			return objectTransformGizmo;
		}

		public RotationGizmo CreateRotationGizmo()
		{
			Gizmo gizmo = CreateGizmo();
			RotationGizmo rotationGizmo = new RotationGizmo();
			gizmo.AddBehaviour(rotationGizmo);
			return rotationGizmo;
		}

		public ObjectTransformGizmo CreateObjectRotationGizmo()
		{
			ObjectTransformGizmo objectTransformGizmo = CreateRotationGizmo().Gizmo.AddBehaviour<ObjectTransformGizmo>();
			objectTransformGizmo.SetTransformChannelFlags(ObjectTransformGizmo.Channels.Rotation);
			return objectTransformGizmo;
		}

		public ScaleGizmo CreateScaleGizmo()
		{
			Gizmo gizmo = CreateGizmo();
			ScaleGizmo scaleGizmo = new ScaleGizmo();
			gizmo.AddBehaviour(scaleGizmo);
			return scaleGizmo;
		}

		public ObjectTransformGizmo CreateObjectScaleGizmo()
		{
			ObjectTransformGizmo objectTransformGizmo = CreateScaleGizmo().Gizmo.AddBehaviour<ObjectTransformGizmo>();
			objectTransformGizmo.SetTransformChannelFlags(ObjectTransformGizmo.Channels.Scale);
			objectTransformGizmo.SetTransformSpace(GizmoSpace.Local);
			objectTransformGizmo.MakeTransformSpacePermanent();
			return objectTransformGizmo;
		}

		public UniversalGizmo CreateUniversalGizmo()
		{
			Gizmo gizmo = CreateGizmo();
			UniversalGizmo universalGizmo = new UniversalGizmo();
			gizmo.AddBehaviour(universalGizmo);
			return universalGizmo;
		}

		public ObjectTransformGizmo CreateObjectUniversalGizmo()
		{
			ObjectTransformGizmo objectTransformGizmo = CreateUniversalGizmo().Gizmo.AddBehaviour<ObjectTransformGizmo>();
			objectTransformGizmo.SetTransformChannelFlags(ObjectTransformGizmo.Channels.All);
			return objectTransformGizmo;
		}

		public BoxGizmo CreateBoxGizmo()
		{
			Gizmo gizmo = CreateGizmo();
			BoxGizmo boxGizmo = new BoxGizmo();
			gizmo.AddBehaviour(boxGizmo);
			return boxGizmo;
		}

		public BoxGizmo CreateObjectBoxScaleGizmo()
		{
			BoxGizmo boxGizmo = CreateBoxGizmo();
			boxGizmo.SetUsage(BoxGizmo.Usage.ObjectScale);
			boxGizmo.MakeUsagePermanent();
			return boxGizmo;
		}

		public ObjectExtrudeGizmo CreateObjectExtrudeGizmo()
		{
			Gizmo gizmo = CreateGizmo();
			ObjectExtrudeGizmo objectExtrudeGizmo = new ObjectExtrudeGizmo();
			gizmo.AddBehaviour(objectExtrudeGizmo);
			return objectExtrudeGizmo;
		}

		public void Update_SystemCall()
		{
			foreach (RTSceneGizmoCamera sceneGizmoCamera in _sceneGizmoCameras)
			{
				sceneGizmoCamera.Update_SystemCall();
			}
			_pipelineStage = GizmosEnginePipelineStage.Update;
			IInputDevice device = MonoSingleton<RTInputDevice>.Get.Device;
			bool flag = device.HasPointer();
			Vector3 positionYAxisUp = device.GetPositionYAxisUp();
			bool flag2 = MonoSingleton<RTScene>.Get.IsAnyUIElementHovered();
			bool flag3 = _draggedGizmo == null && !flag2;
			if (flag3)
			{
				YesNoAnswer yesNoAnswer = new YesNoAnswer();
				if (this.CanDoHoverUpdate != null)
				{
					this.CanDoHoverUpdate(yesNoAnswer);
				}
				if (yesNoAnswer.HasNo)
				{
					flag3 = false;
				}
			}
			if (flag3)
			{
				_hoveredGizmo = null;
				_gizmoHoverInfo.Reset();
			}
			bool flag4 = flag && MonoSingleton<RTFocusCamera>.Get.IsViewportHoveredByDevice();
			bool flag5 = IsRenderCamera(MonoSingleton<RTFocusCamera>.Get.TargetCamera);
			List<GizmoHandleHoverData> list = new List<GizmoHandleHoverData>(10);
			foreach (Gizmo gizmo in _gizmos)
			{
				gizmo.OnUpdateBegin_SystemCall();
				if (flag3 && gizmo.IsEnabled && flag4 && flag && flag5)
				{
					GizmoHandleHoverData gizmoHandleHoverData = GetGizmoHandleHoverData(gizmo);
					if (gizmoHandleHoverData != null)
					{
						list.Add(gizmoHandleHoverData);
					}
				}
			}
			GizmoHandleHoverData gizmoHandleHoverData2 = null;
			if (flag3 && list.Count != 0)
			{
				SortHandleHoverDataCollection(list, positionYAxisUp);
				gizmoHandleHoverData2 = list[0];
				_hoveredGizmo = gizmoHandleHoverData2.Gizmo;
				_gizmoHoverInfo.HandleId = gizmoHandleHoverData2.HandleId;
				_gizmoHoverInfo.HandleDimension = gizmoHandleHoverData2.HandleDimension;
				_gizmoHoverInfo.HoverPoint = gizmoHandleHoverData2.HoverPoint;
				_gizmoHoverInfo.IsHovered = true;
			}
			foreach (Gizmo gizmo2 in _gizmos)
			{
				_gizmoHoverInfo.IsHovered = gizmo2 == _hoveredGizmo;
				gizmo2.UpdateHandleHoverInfo_SystemCall(_gizmoHoverInfo);
				gizmo2.HandleInputDeviceEvents_SystemCall();
				gizmo2.OnUpdateEnd_SystemCall();
			}
			_pipelineStage = GizmosEnginePipelineStage.PostUpdate;
		}

		public GizmoHandleHoverData GetGizmoHandleHoverData(Gizmo gizmo)
		{
			Camera focusCamera = gizmo.FocusCamera;
			Ray ray = MonoSingleton<RTInputDevice>.Get.Device.GetRay(focusCamera);
			List<GizmoHandleHoverData> allHandlesHoverData = gizmo.GetAllHandlesHoverData(ray);
			Vector3 screenRayOrigin = focusCamera.WorldToScreenPoint(ray.origin);
			allHandlesHoverData.Sort(delegate(GizmoHandleHoverData h0, GizmoHandleHoverData h1)
			{
				IGizmoHandle handleById_SystemCall = gizmo.GetHandleById_SystemCall(h0.HandleId);
				IGizmoHandle handleById_SystemCall2 = gizmo.GetHandleById_SystemCall(h1.HandleId);
				if (h0.HandleDimension == h1.HandleDimension)
				{
					if (h0.HandleDimension == GizmoDimension.Dim2D)
					{
						if (handleById_SystemCall.HoverPriority2D == handleById_SystemCall2.HoverPriority2D)
						{
							float sqrMagnitude = (screenRayOrigin - h0.HoverPoint).sqrMagnitude;
							float sqrMagnitude2 = (screenRayOrigin - h1.HoverPoint).sqrMagnitude;
							return sqrMagnitude.CompareTo(sqrMagnitude2);
						}
						return handleById_SystemCall.HoverPriority2D.CompareTo(handleById_SystemCall2.HoverPriority2D);
					}
					if (handleById_SystemCall.HoverPriority3D == handleById_SystemCall2.HoverPriority3D)
					{
						return h0.HoverEnter3D.CompareTo(h1.HoverEnter3D);
					}
					return handleById_SystemCall.HoverPriority3D.CompareTo(handleById_SystemCall2.HoverPriority3D);
				}
				return (handleById_SystemCall.GenericHoverPriority == handleById_SystemCall2.GenericHoverPriority) ? ((h0.HandleDimension != GizmoDimension.Dim2D) ? 1 : (-1)) : handleById_SystemCall.GenericHoverPriority.CompareTo(handleById_SystemCall2.GenericHoverPriority);
			});
			if (allHandlesHoverData.Count == 0)
			{
				return null;
			}
			return allHandlesHoverData[0];
		}

		public void Render_SystemCall()
		{
			_pipelineStage = GizmosEnginePipelineStage.Render;
			Camera current = Camera.current;
			if (!IsSceneGizmoCamera(current) && !IsRenderCamera(current))
			{
				_pipelineStage = GizmosEnginePipelineStage.PostRender;
				return;
			}
			if (Settings.EnableGizmoSorting)
			{
				Vector3 camPos = RenderStageCamera.transform.position;
				List<Gizmo> list = new List<Gizmo>(_gizmos);
				list.Sort(delegate(Gizmo g0, Gizmo g1)
				{
					float sqrMagnitude = (g0.Transform.Position3D - camPos).sqrMagnitude;
					return (g1.Transform.Position3D - camPos).sqrMagnitude.CompareTo(sqrMagnitude);
				});
				Plane[] cameraWorldPlanes = CameraViewVolume.GetCameraWorldPlanes(current);
				foreach (Gizmo item in list)
				{
					item.Render_SystemCall(current, cameraWorldPlanes);
				}
			}
			else
			{
				Plane[] cameraWorldPlanes2 = CameraViewVolume.GetCameraWorldPlanes(current);
				foreach (Gizmo gizmo in _gizmos)
				{
					gizmo.Render_SystemCall(current, cameraWorldPlanes2);
				}
			}
			_pipelineStage = GizmosEnginePipelineStage.PostRender;
		}

		private void SortHandleHoverDataCollection(List<GizmoHandleHoverData> hoverDataCollection, Vector3 inputDevicePos)
		{
			if (hoverDataCollection.Count == 0)
			{
				return;
			}
			Ray hoverRay = hoverDataCollection[0].HoverRay;
			hoverDataCollection.Sort(delegate(GizmoHandleHoverData h0, GizmoHandleHoverData h1)
			{
				if (h0.HandleDimension == h1.HandleDimension)
				{
					if (h0.HandleDimension == GizmoDimension.Dim2D)
					{
						if (h0.Gizmo.HoverPriority2D == h1.Gizmo.HoverPriority2D)
						{
							float sqrMagnitude = (inputDevicePos - h0.HoverPoint).sqrMagnitude;
							float sqrMagnitude2 = (inputDevicePos - h1.HoverPoint).sqrMagnitude;
							return sqrMagnitude.CompareTo(sqrMagnitude2);
						}
						return h0.Gizmo.HoverPriority2D.CompareTo(h1.Gizmo.HoverPriority2D);
					}
					if (h0.Gizmo.HoverPriority3D == h1.Gizmo.HoverPriority3D)
					{
						return h0.HoverEnter3D.CompareTo(h1.HoverEnter3D);
					}
					return h0.Gizmo.HoverPriority3D.CompareTo(h1.Gizmo.HoverPriority3D);
				}
				if (h0.Gizmo.GenericHoverPriority == h1.Gizmo.GenericHoverPriority)
				{
					float sqrMagnitude3 = (h0.Gizmo.Transform.Position3D - hoverRay.origin).sqrMagnitude;
					float sqrMagnitude4 = (h1.Gizmo.Transform.Position3D - hoverRay.origin).sqrMagnitude;
					return sqrMagnitude3.CompareTo(sqrMagnitude4);
				}
				return h0.Gizmo.GenericHoverPriority.CompareTo(h1.Gizmo.GenericHoverPriority);
			});
		}

		private void RegisterGizmo(Gizmo gizmo)
		{
			_gizmos.Add(gizmo);
			gizmo.PreDragBegin += OnGizmoDragBegin;
			gizmo.PreDragEnd += OnGizmoDragEnd;
		}

		private void OnGUI()
		{
			_pipelineStage = GizmosEnginePipelineStage.GUI;
			foreach (Gizmo gizmo in _gizmos)
			{
				gizmo.OnGUI_SystemCall();
			}
			_pipelineStage = GizmosEnginePipelineStage.PostGUI;
		}

		private void OnGizmoDragBegin(Gizmo gizmo, int handleId)
		{
			_draggedGizmo = gizmo;
		}

		private void OnGizmoDragEnd(Gizmo gizmo, int handleId)
		{
			_draggedGizmo = null;
		}
	}
}
