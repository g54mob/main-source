using Rhizomatic.Pooling;
using UnityEngine;

namespace GRP
{
	public class DraggablePhysicsLine : PoolObject
	{
		public RectTransform line;

		public RectTransform a;

		public RectTransform b;

		public CursorConfig cursor;

		public CursorItem cursorItem;

		protected override void OnCreated()
		{
		}

		protected override void OnSpawned()
		{
		}

		protected override void OnPooled()
		{
		}

		public void DrawLine(Vector3 start, Vector3 end)
		{
		}
	}
}
