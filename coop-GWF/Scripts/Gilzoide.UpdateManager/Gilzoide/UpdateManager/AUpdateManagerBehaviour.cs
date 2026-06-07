using System;
using UnityEngine;

namespace Gilzoide.UpdateManager
{
	[Obsolete("Prefer inheriting AManagedBehaviour and implementing the IUpdatable/ILateUpdatable/IFixedUpdatable interfaces directly.")]
	public abstract class AUpdateManagerBehaviour : MonoBehaviour, IUpdatable, IManagedObject
	{
		protected virtual void OnEnable()
		{
			this.RegisterInManager();
		}

		protected virtual void OnDisable()
		{
			this.UnregisterInManager();
		}

		public abstract void ManagedUpdate();
	}
}
