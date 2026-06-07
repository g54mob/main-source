using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture
{
	[AddComponentMenu("AVPro Movie Capture/Utils/Render Mouse Cursor", 302)]
	public class MouseCursor : MonoBehaviour
	{
		[SerializeField]
		private Texture2D _texture;

		[SerializeField]
		private Vector2 _hotspotOffset;

		[SerializeField]
		[Range(1f, 16f)]
		private int _sizeScale;

		[SerializeField]
		private int _depth;

		private GUIContent _content;

		private void Start()
		{
		}

		public void SetTexture(Texture2D texture)
		{
		}

		private void OnGUI()
		{
		}
	}
}
