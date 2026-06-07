using System;
using ModApi.Flight.GameView;

namespace ModApi.Planet.Events
{
	public class QuadSphereFrameStateRecalculatedEventArgs : EventArgs
	{
		public IQuadSphere QuadSphere { get; }

		public IReferenceFrame ReferenceFrame { get; }

		public QuadSphereFrameStateRecalculatedEventArgs(IQuadSphere quadSphere, IReferenceFrame referenceFrame)
		{
			QuadSphere = quadSphere;
			ReferenceFrame = referenceFrame;
		}
	}
}
