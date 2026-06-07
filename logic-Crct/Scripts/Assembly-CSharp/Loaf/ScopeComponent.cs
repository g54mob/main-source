using System;
using System.Collections.Generic;
using Noesis;

namespace Loaf
{
	public class ScopeComponent : UserControl
	{
		public Guid compID;

		public BaseComponent component;

		private ScopeWindow scopeWindow;

		private List<double> voltRecording;

		private List<double> currentRecording;

		public int recordingFrames;

		public double maxV;

		public double minV;

		public double maxA;

		public double minA;

		public PathGeometry voltPg;

		private PathFigure voltPf;

		public PathGeometry curPg;

		private PathFigure curPf;

		public Button CloseButton;

		public Noesis.Label ComponentName;

		public CheckBox VoltageCheck;

		public CheckBox CurrentCheck;

		public Noesis.Label VoltageLabel;

		public Noesis.Label CurrentLabel;

		public Line CurrentLine;

		public Line VoltageLine;

		public ScopeComponent()
		{
		}

		private void CloseButton_Click(object sender, RoutedEventArgs args)
		{
		}

		public ScopeComponent(BaseComponent comp, ScopeWindow sc)
		{
		}

		public void Record()
		{
		}

		public void Compute(float maxV, float minV, float maxA, float minA, float h, float w)
		{
		}

		public void SetColor(Brush vBrush, Brush cBrush)
		{
		}

		private void InitializeComponent()
		{
		}
	}
}
