using UnityEngine;

namespace RLD
{
	public class SceneGizmoCamViewportUpdater : ISceneGizmoCamViewportUpdater
	{
		private SceneGizmo _sceneGizmo;

		public SceneGizmoCamViewportUpdater(SceneGizmo sceneGizmo)
		{
			_sceneGizmo = sceneGizmo;
		}

		public void Update(RTSceneGizmoCamera sceneGizmoCamera)
		{
			SceneGizmoLookAndFeel lookAndFeel = _sceneGizmo.LookAndFeel;
			Vector2 screenOffset = lookAndFeel.ScreenOffset;
			Rect pixelRect = sceneGizmoCamera.SceneCamera.pixelRect;
			Vector2 vector = lookAndFeel.CalculateMaxPrjSwitchLabelRectSize();
			bool isCamPrjSwitchLabelVisible = lookAndFeel.IsCamPrjSwitchLabelVisible;
			float num = SceneGizmoLookAndFeel.ScreenSize;
			if (lookAndFeel.ScreenCorner == SceneGizmoScreenCorner.TopRight)
			{
				sceneGizmoCamera.Camera.pixelRect = new Rect(pixelRect.xMax - num + screenOffset.x, pixelRect.yMax - num + screenOffset.y, num, num);
			}
			else if (lookAndFeel.ScreenCorner == SceneGizmoScreenCorner.TopLeft)
			{
				sceneGizmoCamera.Camera.pixelRect = new Rect(pixelRect.xMin + screenOffset.x, pixelRect.yMax - num + screenOffset.y, num, num);
			}
			else if (lookAndFeel.ScreenCorner == SceneGizmoScreenCorner.BottomRight)
			{
				sceneGizmoCamera.Camera.pixelRect = new Rect(pixelRect.xMax - num + screenOffset.x, pixelRect.yMin + (isCamPrjSwitchLabelVisible ? (vector.y + 1f) : 0f) + screenOffset.y, num, num);
			}
			else
			{
				sceneGizmoCamera.Camera.pixelRect = new Rect(pixelRect.xMin + screenOffset.x, pixelRect.yMin + (isCamPrjSwitchLabelVisible ? (vector.y + 1f) : 0f) + screenOffset.y, num, num);
			}
		}
	}
}
