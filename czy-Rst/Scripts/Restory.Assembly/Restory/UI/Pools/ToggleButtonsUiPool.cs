using Restory.ObjectPools;
using Restory.Utils.Observers;
using UnityEngine;
using Zenject;

namespace Restory.UI.Pools
{
	public sealed class ToggleButtonsUiPool : ConcreteGameObjectPool
	{
		public ToggleButtonsUiPool(DiContainer diContainer, ApplicationQuitStartObserver applicationQuitStartObserver, GameObject prefab)
			: base(diContainer, applicationQuitStartObserver, prefab)
		{
		}
	}
}
