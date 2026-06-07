using UnityEngine;

namespace RLD
{
	public class SceneGizmoCamPrjSwitchLabel
	{
		private SceneGizmo _sceneGizmo;

		private GizmoHandle _handle;

		private QuadShape2D _labelQuad = new QuadShape2D();

		public GizmoHandle Handle => _handle;

		public int Id => _handle.Id;

		public SceneGizmoCamPrjSwitchLabel(SceneGizmo sceneGizmo)
		{
			_sceneGizmo = sceneGizmo;
			_handle = _sceneGizmo.Gizmo.CreateHandle(GizmoHandleId.SceneGizmoCamPrjSwitchLabel);
			_handle.Add2DShape(_labelQuad);
			sceneGizmo.Gizmo.PreUpdateBegin += OnGizmoPreUpdateBegin;
			sceneGizmo.Gizmo.PreHandlePicked += OnGizmoHandlePicked;
		}

		public void OnGUI()
		{
			SceneGizmoLookAndFeel lookAndFeel = _sceneGizmo.LookAndFeel;
			Camera camera = _sceneGizmo.SceneGizmoCamera.Camera;
			if (!lookAndFeel.IsCamPrjSwitchLabelVisible)
			{
				return;
			}
			if (_sceneGizmo.SceneGizmoCamera.SceneCamera != MonoSingleton<RTFocusCamera>.Get.TargetCamera || !MonoSingleton<RTFocusCamera>.Get.IsDoingProjectionSwitch)
			{
				Texture2D texture2D = (camera.orthographic ? lookAndFeel.CamOrthoModeLabelTexture : lookAndFeel.CamPerspModeLabelTexture);
				GUIEx.PushColor(lookAndFeel.CamPrjSwitchLabelTint);
				Rect position = RectEx.FromTexture2D(texture2D).PlaceBelowCenterHrz(camera.pixelRect).InvertScreenY();
				position.center = new Vector2(position.center.x, (float)(Screen.height - 1) - _labelQuad.Center.y);
				GUI.DrawTexture(position, texture2D);
				GUIEx.PopColor();
				return;
			}
			Texture2D texture2D2 = lookAndFeel.CamOrthoModeLabelTexture;
			Texture2D texture2D3 = lookAndFeel.CamPerspModeLabelTexture;
			if (MonoSingleton<RTFocusCamera>.Get.PrjSwitchTransitionType == CameraPrjSwitchTransition.Type.ToPerspective)
			{
				texture2D2 = lookAndFeel.CamPerspModeLabelTexture;
				texture2D3 = lookAndFeel.CamOrthoModeLabelTexture;
			}
			AnimationCurve animationCurve = AnimationCurve.EaseInOut(0f, lookAndFeel.CamPrjSwitchLabelTint.a, 1f, 0f);
			float newAlpha = AnimationCurve.EaseInOut(0f, 0f, 1f, lookAndFeel.CamPrjSwitchLabelTint.a).Evaluate(MonoSingleton<RTFocusCamera>.Get.PrjSwitchProgress);
			float newAlpha2 = animationCurve.Evaluate(MonoSingleton<RTFocusCamera>.Get.PrjSwitchProgress);
			GUIEx.PushColor(lookAndFeel.CamPrjSwitchLabelTint.KeepAllButAlpha(newAlpha2));
			Rect position2 = RectEx.FromTexture2D(texture2D3).PlaceBelowCenterHrz(camera.pixelRect).InvertScreenY();
			position2.center = new Vector2(position2.center.x, (float)(Screen.height - 1) - _labelQuad.Center.y);
			GUI.DrawTexture(position2, texture2D3);
			GUIEx.PopColor();
			GUIEx.PushColor(lookAndFeel.CamPrjSwitchLabelTint.KeepAllButAlpha(newAlpha));
			position2 = RectEx.FromTexture2D(texture2D2).PlaceBelowCenterHrz(camera.pixelRect).InvertScreenY();
			position2.center = new Vector2(position2.center.x, (float)(Screen.height - 1) - _labelQuad.Center.y);
			GUI.DrawTexture(position2, texture2D2);
			GUIEx.PopColor();
		}

		private void OnGizmoPreUpdateBegin(Gizmo gizmo)
		{
			_handle.Is2DVisible = _sceneGizmo.LookAndFeel.IsCamPrjSwitchLabelVisible;
			UpdateTransform();
		}

		private void UpdateTransform()
		{
			SceneGizmoLookAndFeel lookAndFeel = _sceneGizmo.LookAndFeel;
			Rect rect = RectEx.FromTexture2D(_sceneGizmo.SceneGizmoCamera.Camera.orthographic ? lookAndFeel.CamOrthoModeLabelTexture : lookAndFeel.CamPerspModeLabelTexture);
			rect.size = lookAndFeel.CalculateMaxPrjSwitchLabelRectSize();
			rect = rect.PlaceBelowCenterHrz(_sceneGizmo.SceneGizmoCamera.Camera.pixelRect);
			_labelQuad.Center = rect.center;
			_labelQuad.Size = rect.size;
		}

		private void OnGizmoHandlePicked(Gizmo gizmo, int handleId)
		{
			if (handleId == _handle.Id)
			{
				MonoSingleton<RTFocusCamera>.Get.PerformProjectionSwitch();
			}
		}
	}
}
