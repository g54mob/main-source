using System;

namespace Assets.Scripts.Terrain.Events
{
	public class UnloadQuadScriptEventArgs : EventArgs
	{
		private QuadScript _quad;

		public QuadScript Quad => _quad;

		public void Initialize(QuadScript quad)
		{
			_quad = quad;
		}

		public void Reset()
		{
			_quad = null;
		}
	}
}
