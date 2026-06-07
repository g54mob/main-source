using System;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public abstract class PartIntersectionReceiver : IDisposable
	{
		private DesignerPartIntersectionManager _manager;

		public abstract bool Enabled { get; }

		public virtual int LayerMask => 2129921;

		public PartIntersectionReceiver(DesignerPartIntersectionManager manager)
		{
			_manager = manager;
			if (manager != null)
			{
				manager.RegisterReceiver(this);
			}
		}

		public virtual void Dispose()
		{
			if (_manager != null)
			{
				_manager.UnregisterReceiver(this);
				_manager = null;
			}
		}

		public abstract (Vector3 Center, Vector3 HalfExtents, Quaternion Rotation) GetBox();

		public abstract void OnAfterRecieveHits();

		public abstract void OnBeforeRecieveHits();

		public virtual void OnUpdate()
		{
		}

		public abstract void RecieveHit(Collider hit);

		public void SetManager(DesignerPartIntersectionManager manager)
		{
			if (_manager != null)
			{
				_manager.UnregisterReceiver(this);
			}
			_manager = manager;
			if (manager != null)
			{
				manager.RegisterReceiver(this);
			}
		}
	}
}
