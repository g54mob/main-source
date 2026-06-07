using Noesis;
using UnityEngine;

namespace Loaf
{
	public class ComponentToolWindow : UserControl
	{
		public Point openSize;

		public Point closedSize;

		private TranslateTransform translate;

		private Vector2 dragStart;

		private Vector2 startPos;

		private Vector2 delta;

		public Button DragHandle;

		public Button CloseButton;

		public Button CloseButtonClosed;

		public Button HideButton;

		public Button ShowButton;

		public Grid TitleBarClosed;

		public Grid TitleBarOpen;

		public Grid MainContent;

		public Border Container;

		public Noesis.Label HeadingLabel;

		public Noesis.Label ClosedHeadingLabel;

		public ComponentToolWindow(UserControl control, string name)
		{
		}

		public ComponentToolWindow()
		{
		}

		private void ShowButton_Click(object sender, RoutedEventArgs args)
		{
		}

		public void Hide()
		{
		}

		private void HideButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void DragHandle_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs args)
		{
		}

		public void Update()
		{
		}

		private void InitializeComponent()
		{
		}
	}
}
