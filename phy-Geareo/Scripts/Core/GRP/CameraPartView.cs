using UnityEngine;

namespace GRP
{
	public class CameraPartView : PartView<CameraPartViewable>
	{
		public Transform camTransform;

		public LineRenderer distanceLine;

		public Camera cam;

		private RenderTexture texture;

		protected override void OnViewCreated()
		{
		}

		protected override void OnViewOpen()
		{
		}

		private void Render()
		{
		}

		protected override void OnRender()
		{
		}

		protected override void LateUpdate()
		{
		}
	}
}
