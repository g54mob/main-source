using Assets.Scripts;
using Shapes;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Dev.Scripts
{
	[ExecuteAlways]
	internal sealed class BoundsDisplayScript : MonoBehaviour
	{
		private void DrawGizmo(ScriptableRenderContext ctx, Camera cam)
		{
			if (!TryGetComponent<Renderer>(out var component))
			{
				return;
			}
			using (Draw.Command(cam))
			{
				Draw.Thickness = 2f;
				Draw.ThicknessSpace = ThicknessSpace.Pixels;
				Draw.SizeSpace = ThicknessSpace.Meters;
				Draw.Matrix = base.transform.localToWorldMatrix;
				Draw.Color = Color.green;
				Utility.DrawCuboid(component.localBounds);
				Draw.Matrix = Matrix4x4.identity;
				Draw.Color = Color.cyan;
				Utility.DrawCuboid(component.bounds);
			}
		}

		private void OnDisable()
		{
			RenderPipelineManager.beginCameraRendering -= DrawGizmo;
		}

		private void OnEnable()
		{
			RenderPipelineManager.beginCameraRendering += DrawGizmo;
		}
	}
}
