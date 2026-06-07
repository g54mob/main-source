using UnityEngine;

namespace Gilzoide.UpdateManager
{
	public abstract class AManagedBehaviour : MonoBehaviour, IManagedObject
	{
		protected virtual void OnEnable()
		{
			this.RegisterInManager();
		}

		protected virtual void OnDisable()
		{
			this.UnregisterInManager();
		}
	}
}
