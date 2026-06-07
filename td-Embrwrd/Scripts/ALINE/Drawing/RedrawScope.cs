using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Drawing
{
	public struct RedrawScope : IDisposable
	{
		internal GCHandle gizmos;

		internal int id;

		private static int idCounter;

		public bool isValid => false;

		internal RedrawScope(DrawingData gizmos, int id)
		{
			this.gizmos = default(GCHandle);
			this.id = 0;
		}

		internal RedrawScope(DrawingData gizmos)
		{
			this.gizmos = default(GCHandle);
			id = 0;
		}

		internal void Draw()
		{
		}

		public void Rewind()
		{
		}

		internal void DrawUntilDispose(GameObject associatedGameObject)
		{
		}

		public void Dispose()
		{
		}
	}
}
