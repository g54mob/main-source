using UnityEngine;

namespace VisualDesignCafe.Nature
{
	internal class NotificationBox
	{
		private readonly GUIContent _title;

		private readonly GUIContent _text;

		private readonly GUIContent _buttonContent;

		private readonly string _buttonUrl;

		private bool _stylesLoaded;

		private GUIStyle _backgroundStyle;

		private GUIStyle _textStyle;

		private GUIStyle _titleStyle;

		private GUIStyle _buttonStyle;

		public bool IsSceneView { get; set; }

		public float MarginBottom { get; set; }

		public NotificationBox(string title, string text)
		{
		}

		public NotificationBox(string title, string text, string button, string url)
		{
		}

		private void LoadStyles()
		{
		}

		public void Draw()
		{
		}
	}
}
