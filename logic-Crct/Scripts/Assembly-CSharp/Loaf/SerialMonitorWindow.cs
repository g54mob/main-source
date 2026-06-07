using System.Text;
using Noesis;
using UnityEngine;

namespace Loaf
{
	public class SerialMonitorWindow : UserControl
	{
		private static SerialMonitorWindow inst;

		private float updateT;

		private StringBuilder sb;

		private TranslateTransform translate;

		private Vector2 dragStart;

		private Vector2 startPos;

		private Vector2 delta;

		public TextBox SerialTextBlock;

		public Button CloseButton;

		public Button ClearButton;

		public Button DragHandle;

		private void DragHandle_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs args)
		{
		}

		public void Update()
		{
		}

		public static void AddText(string text)
		{
		}

		private void InitializeComponent()
		{
		}
	}
}
