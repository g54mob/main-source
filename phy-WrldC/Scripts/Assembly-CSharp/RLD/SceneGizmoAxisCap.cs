using UnityEngine;

namespace RLD
{
	public class SceneGizmoAxisCap : SceneGizmoCap
	{
		private AxisDescriptor _axisDesc;

		private BoxFace _midAxisBoxFace;

		private GizmoTransform _zoomFactorTransform = new GizmoTransform();

		private ColorRef _color = new ColorRef();

		private ColorTransition _colorTransition;

		private Texture2D _labelTexture;

		public SceneGizmoAxisCap(SceneGizmo sceneGizmo, int id, AxisDescriptor gizmoAxisDesc)
			: base(sceneGizmo, id)
		{
			_axisDesc = gizmoAxisDesc;
			_midAxisBoxFace = _axisDesc.GetAssociatedBoxFace();
			_cap.SetZoomFactorTransform(_zoomFactorTransform);
			if (_axisDesc.IsPositive)
			{
				if (_axisDesc.Index == 0)
				{
					_labelTexture = Singleton<TexturePool>.Get.XAxisLabel;
				}
				else if (_axisDesc.Index == 1)
				{
					_labelTexture = Singleton<TexturePool>.Get.YAxisLabel;
				}
				else
				{
					_labelTexture = Singleton<TexturePool>.Get.ZAxisLabel;
				}
			}
			_colorTransition = new ColorTransition(_color);
			_cap.Gizmo.PreUpdateBegin += OnGizmoPreUpdateBegin;
			_cap.Gizmo.PreHandlePicked += OnGizmoHandlePicked;
			_sceneGizmo.LookAndFeel.ConnectAxisCapLookAndFeel(_cap, _axisDesc.Index, _axisDesc.Sign);
		}

		public override void Render(Camera camera)
		{
			SceneGizmoLookAndFeel lookAndFeel = _sceneGizmo.LookAndFeel;
			RTSceneGizmoCamera sceneGizmoCamera = _sceneGizmo.SceneGizmoCamera;
			_cap.Render(camera);
			if (_axisDesc.IsPositive)
			{
				GizmoLabelMaterial get = Singleton<GizmoLabelMaterial>.Get;
				get.SetZWriteEnabled(isEnabled: false);
				get.SetZTestLessEqual();
				get.SetColor(lookAndFeel.AxesLabelTint.KeepAllButAlpha(_color.Value.a));
				get.SetTexture(_labelTexture);
				get.SetPass(0);
				Vector3 axis3D = _sceneGizmo.Gizmo.Transform.GetAxis3D(_axisDesc);
				Vector3 s = Vector3Ex.FromValue(lookAndFeel.GetAxesLabelWorldSize(sceneGizmoCamera.Camera, _cap.Position));
				Vector3 vector = _cap.Position + axis3D * (s.x * 0.5f);
				Vector2 vector2 = sceneGizmoCamera.Camera.WorldToScreenPoint(vector);
				Vector2 vector3 = sceneGizmoCamera.Camera.WorldToScreenPoint(_sceneGizmo.SceneGizmoCamera.LookAtPoint);
				Vector2 normalized = (vector2 - vector3).normalized;
				float num = Mathf.Abs(sceneGizmoCamera.Look.AbsDot(axis3D));
				vector2 += Vector2.Scale(normalized, Vector2Ex.FromValue(SceneGizmoLookAndFeel.AxisLabelScreenSize)) * num;
				vector = sceneGizmoCamera.Camera.ScreenToWorldPoint(new Vector3(vector2.x, vector2.y, (vector - sceneGizmoCamera.WorldPosition).magnitude));
				Quaternion q = Quaternion.LookRotation(sceneGizmoCamera.Look, sceneGizmoCamera.Up);
				Matrix4x4 matrix = Matrix4x4.TRS(vector, q, s);
				Graphics.DrawMeshNow(Singleton<MeshPool>.Get.UnitQuadXY, matrix);
			}
		}

		private void OnGizmoPreUpdateBegin(Gizmo gizmo)
		{
			_sceneGizmo.LookAndFeel.ConnectAxisCapLookAndFeel(_cap, _axisDesc.Index, _axisDesc.Sign);
			UpdateColor();
			UpdateHoverPermission();
			UpdateTransform(gizmo.FocusCamera);
		}

		private void UpdateHoverPermission()
		{
			if (_colorTransition.IsActive || _colorTransition.TransitionState == ColorTransition.State.CompleteFadeOut)
			{
				_cap.SetHoverable(isHoverable: false);
			}
			else
			{
				_cap.SetHoverable(isHoverable: true);
			}
		}

		private void UpdateColor()
		{
			SceneGizmoLookAndFeel lookAndFeel = _sceneGizmo.LookAndFeel;
			Color color = lookAndFeel.GetAxisCapColor(_axisDesc.Index, _axisDesc.Sign);
			if (_cap.IsHovered)
			{
				color = lookAndFeel.HoveredColor;
			}
			ColorTransition.State transitionState = _colorTransition.TransitionState;
			if (_sceneGizmo.Gizmo.Transform.GetAxis3D(_axisDesc).AbsDot(_sceneGizmo.SceneGizmoCamera.Look) > SceneGizmoLookAndFeel.AxisCamAlignFadeOutThreshold)
			{
				if (transitionState != ColorTransition.State.CompleteFadeOut && transitionState != ColorTransition.State.FadingOut)
				{
					_colorTransition.DurationInSeconds = SceneGizmoLookAndFeel.AxisCamAlignFadeOutDuration;
					_colorTransition.FadeOutColor = color.KeepAllButAlpha(SceneGizmoLookAndFeel.AxisCamAlignFadeOutAlpha);
					_colorTransition.BeginFadeOut(startFromCurrentColor: true);
				}
			}
			else if (transitionState != ColorTransition.State.FadingIn && transitionState != ColorTransition.State.CompleteFadeIn && transitionState != ColorTransition.State.Ready)
			{
				_colorTransition.DurationInSeconds = SceneGizmoLookAndFeel.AxisCamAlignFadeOutDuration;
				_colorTransition.FadeInColor = color;
				_colorTransition.BeginFadeIn(startFromCurrentColor: true);
			}
			else
			{
				_color.Value = color;
			}
			_colorTransition.Update(Time.deltaTime);
			_cap.OverrideColor.IsActive = true;
			_cap.OverrideColor.Color = _color.Value;
		}

		private void UpdateTransform(Camera camera)
		{
			Vector3 lookAtPoint = _sceneGizmo.SceneGizmoCamera.LookAtPoint;
			_ = _sceneGizmo.SceneGizmoCamera;
			Vector3 axis3D = _sceneGizmo.Gizmo.Transform.GetAxis3D(_axisDesc);
			_zoomFactorTransform.Position3D = lookAtPoint;
			float zoomFactor = _cap.GetZoomFactor(camera);
			Vector3 boxSize = ((_sceneGizmo.LookAndFeel.MidCapType == GizmoCap3DType.Box) ? Vector3Ex.FromValue(SceneGizmoLookAndFeel.MidCapBoxSize * zoomFactor) : Vector3Ex.FromValue(SceneGizmoLookAndFeel.MidCapSphereRadius * 2f * zoomFactor));
			Vector3 sliderEndPt = BoxMath.CalcBoxFaceCenter(lookAtPoint, boxSize, Quaternion.identity, _midAxisBoxFace);
			_cap.CapSlider3DInvert(axis3D, sliderEndPt);
		}

		private void OnGizmoHandlePicked(Gizmo gizmo, int handleId)
		{
			if (handleId == base.HandleId)
			{
				Quaternion targetRotation = Quaternion.LookRotation(-_sceneGizmo.Gizmo.Transform.GetAxis3D(_axisDesc), Vector3.up);
				MonoSingleton<RTFocusCamera>.Get.PerformRotationSwitch(targetRotation);
			}
		}
	}
}
