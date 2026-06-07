using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture
{
	public class MouseCursor : MonoBehaviour
	{
		[SerializeField]
		private Texture2D _texture;

		[SerializeField]
		private Vector2 _hotspotOffset;

		[SerializeField]
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
