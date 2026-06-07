using System;

namespace Assets.Scripts.Terrain.Events
{
	public class CreateQuadDataEventArgs : EventArgs
	{
		private QuadSphereScript _quadSphere;

		public CreateQuadData Data { get; }

		public QuadSphereScript QuadSphere => _quadSphere;

		public CreateQuadDataEventArgs(CreateQuadData data)
		{
			Data = data;
		}

		public void Initialize(QuadSphereScript quadSphere)
		{
			_quadSphere = quadSphere;
		}

		public void Reset()
		{
			_quadSphere = null;
		}
	}
}
