using UnityEngine;

namespace RLD
{
	public class RLDApp : MonoSingleton<RLDApp>, IRLDApplication
	{
		[SerializeField]
		[HideInInspector]
		private DynamicConvertSettings _dynamicConvertSettings = new DynamicConvertSettings();

		public DynamicConvertSettings DynamicConvertSettings => _dynamicConvertSettings;

		public event RLDAppInitializedHandler Initialized;

		private void OnSceneCanRenderCameraIcon(Camera camera, YesNoAnswer answer)
		{
			if (camera == MonoSingleton<RTFocusCamera>.Get.TargetCamera || MonoSingleton<RTGizmosEngine>.Get.IsSceneGizmoCamera(camera))
			{
				answer.No();
			}
		}

		private void OnCanCameraUseScrollWheel(YesNoAnswer answer)
		{
			if (MonoSingleton<RTScene>.Get.IsAnyUIElementHovered())
			{
				answer.No();
			}
			else
			{
				answer.Yes();
			}
		}

		private void OnCanCameraProcessInput(YesNoAnswer answer)
		{
			if (MonoSingleton<RTGizmosEngine>.Get.DraggedGizmo != null)
			{
				answer.No();
			}
			else
			{
				answer.Yes();
			}
		}

		private void OnCanUndoRedo(UndoRedoOpType undoRedoOpType, YesNoAnswer answer)
		{
			if (MonoSingleton<RTGizmosEngine>.Get.DraggedGizmo == null && !MonoSingleton<RTObjectSelection>.Get.IsMultiSelectShapeVisible)
			{
				answer.Yes();
			}
			else
			{
				answer.No();
			}
			if (!MonoSingleton<RTObjectSelection>.Get.IsManipSessionActive)
			{
				answer.Yes();
			}
			else
			{
				answer.No();
			}
		}

		private void OnCanDoGizmoHoverUpdate(YesNoAnswer answer)
		{
			if (MonoSingleton<RTObjectSelection>.Get != null && MonoSingleton<RTObjectSelection>.Get.IsMultiSelectShapeVisible)
			{
				answer.No();
			}
			else
			{
				answer.Yes();
			}
		}

		private void OnCanObjectSelectionClickAndMultiSelectDeselect(YesNoAnswer answer)
		{
			if (MonoSingleton<RTSceneGrid>.Get.Hotkeys.SnapToCursorPickPoint.IsActive())
			{
				answer.No();
			}
			else
			{
				answer.Yes();
			}
		}

		private void OnViewportsCameraAdded(Camera camera)
		{
			MonoSingleton<RTGizmosEngine>.Get.AddRenderCamera(camera);
		}

		private void OnViewportCameraRemoved(Camera camera)
		{
			MonoSingleton<RTGizmosEngine>.Get.RemoveRenderCamera(camera);
		}

		private void Start()
		{
			MonoSingleton<RTUndoRedo>.Get.CanUndoRedo += OnCanUndoRedo;
			MonoSingleton<RTFocusCamera>.Get.CanProcessInput += OnCanCameraProcessInput;
			MonoSingleton<RTFocusCamera>.Get.CanUseScrollWheel += OnCanCameraUseScrollWheel;
			Singleton<RTCameraViewports>.Get.CameraAdded += OnViewportsCameraAdded;
			Singleton<RTCameraViewports>.Get.CameraRemoved += OnViewportCameraRemoved;
			MonoSingleton<RTScene>.Get.RegisterHoverableSceneEntityContainer(MonoSingleton<RTGizmosEngine>.Get);
			MonoSingleton<RTSceneGrid>.Get.Initialize_SystemCall();
			MonoSingleton<RTGizmosEngine>.Get.CanDoHoverUpdate += OnCanDoGizmoHoverUpdate;
			MonoSingleton<RTGizmosEngine>.Get.CreateSceneGizmo(MonoSingleton<RTFocusCamera>.Get.TargetCamera);
			MonoSingleton<RTGizmosEngine>.Get.AddRenderCamera(MonoSingleton<RTFocusCamera>.Get.TargetCamera);
			if (MonoSingleton<RTObjectSelection>.Get != null)
			{
				Singleton<ObjectSelectEntireHierarchy>.Get.SetActive(isActive: true);
				MonoSingleton<RTObjectSelection>.Get.CanClickSelectDeselect += OnCanObjectSelectionClickAndMultiSelectDeselect;
				MonoSingleton<RTObjectSelection>.Get.CanMultiSelectDeselect += OnCanObjectSelectionClickAndMultiSelectDeselect;
				MonoSingleton<RTObjectSelection>.Get.Initialize_SystemCall();
				if (MonoSingleton<RTObjectSelectionGizmos>.Get != null)
				{
					MonoSingleton<RTObjectSelection>.Get.AttachGizmoController(MonoSingleton<RTObjectSelectionGizmos>.Get);
					MonoSingleton<RTObjectSelectionGizmos>.Get.Initialize_SystemCall();
				}
			}
			RTMeshCompiler.CompileEntireScene();
			if (this.Initialized != null)
			{
				this.Initialized();
			}
		}

		private void Update()
		{
			MonoSingleton<RTInputDevice>.Get.Update_SystemCall();
			MonoSingleton<RTFocusCamera>.Get.Update_SystemCall();
			MonoSingleton<RTScene>.Get.Update_SystemCall();
			MonoSingleton<RTSceneGrid>.Get.Update_SystemCall();
			MonoSingleton<RTGizmosEngine>.Get.Update_SystemCall();
			if (MonoSingleton<RTObjectSelection>.Get != null)
			{
				MonoSingleton<RTObjectSelection>.Get.Update_SystemCall();
			}
			if (MonoSingleton<RTObjectSelectionGizmos>.Get != null)
			{
				MonoSingleton<RTObjectSelectionGizmos>.Get.Update_SystemCall();
			}
			MonoSingleton<RTUndoRedo>.Get.Update_SystemCall();
		}

		private void OnRenderObject()
		{
			if (MonoSingleton<RTGizmosEngine>.Get.IsSceneGizmoCamera(Camera.current))
			{
				MonoSingleton<RTGizmosEngine>.Get.Render_SystemCall();
				return;
			}
			if (MonoSingleton<RTCameraBackground>.Get != null)
			{
				MonoSingleton<RTCameraBackground>.Get.Render_SystemCall();
			}
			MonoSingleton<RTSceneGrid>.Get.Render_SystemCall();
			MonoSingleton<RTScene>.Get.Render_SystemCall();
			if (MonoSingleton<RTObjectSelection>.Get != null)
			{
				MonoSingleton<RTObjectSelection>.Get.Render_SystemCall();
			}
			MonoSingleton<RTGizmosEngine>.Get.Render_SystemCall();
		}
	}
}
