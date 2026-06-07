using Noesis;
using UnityEngine;

namespace Loaf
{
	public class HexEditorWindow : UserControl
	{
		private TranslateTransform translate;

		private Vector2 dragStart;

		private Vector2 startPos;

		private Vector2 delta;

		private HexEntryLine[] hels;

		private byte[] _data;

		private int currentAdr;

		private int prevAdr;

		public Button DragHandle;

		public ScrollViewer scrollview;

		public Grid EntryContainer;

		public Button CloseButton;

		public Button NewButton;

		public Button SaveButton;

		public Button OpenButton;

		public Button ApplyButton;

		public HexEditorWindow()
		{
		}

		private void DragHandle_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs args)
		{
		}

		public void Update()
		{
		}

		public HexEditorWindow(byte[] data)
		{
		}

		private void scrollview_ScrollChanged(object sender, ScrollChangedEventArgs e)
		{
		}

		private void Shift(int adr)
		{
		}

		private void ApplyButton_Click(object sender, RoutedEventArgs e)
		{
		}

		private void NewButton_Click(object sender, RoutedEventArgs e)
		{
		}

		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{
		}

		private void OpenButton_Click(object sender, RoutedEventArgs e)
		{
		}

		private void WriteDataToFile(string fileName)
		{
		}

		private void LoadDataFromFile(string filename)
		{
		}

		private void InitializeComponent()
		{
		}
	}
}
