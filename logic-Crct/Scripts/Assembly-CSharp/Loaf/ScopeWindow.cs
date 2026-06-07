using System.Collections.Generic;
using Noesis;
using UnityEngine;

namespace Loaf
{
	public class ScopeWindow : UserControl
	{
		private List<ScopeComponent> components;

		private List<Path> paths;

		private TranslateTransform translate;

		private Vector2 dragStart;

		private Vector2 startPos;

		private Vector2 delta;

		private float updateT;

		private PathGeometry voltPg;

		private PathFigure voltPf;

		private PathGeometry curPg;

		private PathFigure curPf;

		private Path[] voltagePaths;

		private Path[] currentPaths;

		public Button CloseButton;

		public Button DragHandle;

		public Noesis.Canvas ScopeCanvas;

		public Path VoltageZeroLine;

		public Path CurrentZeroLine;

		public Path Voltage0;

		public Path Current0;

		public Path Voltage1;

		public Path Current1;

		public Path Voltage2;

		public Path Current2;

		public Path Voltage3;

		public Path Current3;

		public StackPanel CompStack;

		public void AddComponent(BaseComponent comp)
		{
		}

		public void DeleteComponent(ScopeComponent sc)
		{
		}

		public void RemoveComponent(BaseComponent c)
		{
		}

		private void CloseButton_Click(object sender, RoutedEventArgs args)
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
