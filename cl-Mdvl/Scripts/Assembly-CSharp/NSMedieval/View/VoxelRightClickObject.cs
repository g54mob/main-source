using System;
using NSMedieval.Goap;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.View
{
	public class VoxelRightClickObject : MonoBehaviour, IAdditionalMenuOwner, IGameDisposable, IDisposable
	{
		public bool HasDisposed { get; private set; }

		public event Action<IGameDisposable> OnDisposedEvent;

		public void Dispose()
		{
			HasDisposed = true;
			this.OnDisposedEvent?.Invoke(this);
			this.OnDisposedEvent = null;
		}

		public string GetAdditionalMenuId()
		{
			return "voxel";
		}

		public IGoapTargetable GetAsTarget()
		{
			return null;
		}

		public Transform GetGuiOverlayHookTransform()
		{
			return base.transform;
		}

		public bool ShouldMenuFollowHookTransform()
		{
			return true;
		}
	}
}
