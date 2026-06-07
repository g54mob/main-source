using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class SceneGizmo : GizmoBehaviour, ISceneGizmo
	{
		private SceneGizmoCamPrjSwitchLabel _camPrjSwitchLabel;

		private SceneGizmoMidCap _midAxisHandle;

		private SceneGizmoAxisCap[] _axesHandles = new SceneGizmoAxisCap[6];

		private List<SceneGizmoCap> _renderSortedHandles = new List<SceneGizmoCap>(7);

		private RTSceneGizmoCamera _sceneGizmoCamera;

		[SerializeField]
		private SceneGizmoLookAndFeel _lookAndFeel = new SceneGizmoLookAndFeel();

		[SerializeField]
		private SceneGizmoLookAndFeel _sharedLookAndFeel;

		public RTSceneGizmoCamera SceneGizmoCamera => _sceneGizmoCamera;

		public Gizmo OwnerGizmo => base.Gizmo;

		public Camera SceneCamera => _sceneGizmoCamera.SceneCamera;

		public SceneGizmoLookAndFeel LookAndFeel
		{
			get
			{
				if (_sharedLookAndFeel == null)
				{
					return _lookAndFeel;
				}
				return _sharedLookAndFeel;
			}
		}

		public SceneGizmoLookAndFeel SharedLookAndFeel
		{
			get
			{
				return _sharedLookAndFeel;
			}
			set
			{
				_sharedLookAndFeel = value;
			}
		}

		public override void OnAttached()
		{
			_sceneGizmoCamera = MonoSingleton<RTGizmosEngine>.Get.CreateSceneGizmoCamera(MonoSingleton<RTFocusCamera>.Get.TargetCamera, new SceneGizmoCamViewportUpdater(this));
			_midAxisHandle = new SceneGizmoMidCap(this);
			_renderSortedHandles.Add(_midAxisHandle);
			AxisDescriptor[] array = new AxisDescriptor[6]
			{
				new AxisDescriptor(0, AxisSign.Positive),
				new AxisDescriptor(1, AxisSign.Positive),
				new AxisDescriptor(2, AxisSign.Positive),
				new AxisDescriptor(0, AxisSign.Negative),
				new AxisDescriptor(1, AxisSign.Negative),
				new AxisDescriptor(2, AxisSign.Negative)
			};
			int[] array2 = new int[6]
			{
				GizmoHandleId.SceneGizmoPositiveXAxis,
				GizmoHandleId.SceneGizmoPositiveYAxis,
				GizmoHandleId.SceneGizmoPositiveZAxis,
				GizmoHandleId.SceneGizmoNegativeXAxis,
				GizmoHandleId.SceneGizmoNegativeYAxis,
				GizmoHandleId.SceneGizmoNegativeZAxis
			};
			for (int i = 0; i < array.Length; i++)
			{
				_axesHandles[i] = new SceneGizmoAxisCap(this, array2[i], array[i]);
				_renderSortedHandles.Add(_axesHandles[i]);
			}
			_camPrjSwitchLabel = new SceneGizmoCamPrjSwitchLabel(this);
			base.Gizmo.Transform.Position3D = _sceneGizmoCamera.LookAtPoint;
			base.Gizmo.Transform.Rotation3D = Quaternion.identity;
			base.Gizmo.GenericHoverPriority.MakeHighest();
			base.Gizmo.HoverPriority2D.MakeHighest();
			base.Gizmo.HoverPriority3D.MakeHighest();
		}

		public override void OnGUI()
		{
			_camPrjSwitchLabel.OnGUI();
		}

		public override void OnGizmoRender(Camera camera)
		{
			if (camera != _sceneGizmoCamera.Camera)
			{
				return;
			}
			Vector3 cameraPos = _sceneGizmoCamera.WorldPosition;
			_renderSortedHandles.Sort(delegate(SceneGizmoCap h0, SceneGizmoCap h1)
			{
				float sqrMagnitude = (h0.Position - cameraPos).sqrMagnitude;
				return (h1.Position - cameraPos).sqrMagnitude.CompareTo(sqrMagnitude);
			});
			foreach (SceneGizmoCap renderSortedHandle in _renderSortedHandles)
			{
				renderSortedHandle.Render(_sceneGizmoCamera.Camera);
			}
		}
	}
}
