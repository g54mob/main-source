using UnityEngine;

namespace Gh.Tk.UI
{
	public class ImageBlock3DUIView : BaseBlock3DUIView, BaseBlock3DUIView.ILateColliderResizable
	{
		[SerializeField]
		private SpriteRenderer _renderer;

		public SpriteRenderer frameRenderer;

		public float frameThickness;

		[SerializeField]
		private Texture2D _image;

		public float maxWidth;

		public float maxHeight;

		public bool centerJustify;

		public override void SetBlockData(string imageId)
		{
		}

		[ContextMenu("Update Scale")]
		public void UpdateScale()
		{
		}

		public void ResizeColliderToMaxWidth(float maxWidth)
		{
		}
	}
}
