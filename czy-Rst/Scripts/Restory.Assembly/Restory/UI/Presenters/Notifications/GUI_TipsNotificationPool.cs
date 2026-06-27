using Restory.ObjectPools;
using Restory.Utils.Observers;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Notifications
{
	public sealed class GUI_TipsNotificationPool : ConcreteGameObjectPool
	{
		public GUI_TipsNotificationPool(DiContainer diContainer, ApplicationQuitStartObserver applicationQuitStartObserver, GameObject prefab)
			: base(diContainer, applicationQuitStartObserver, prefab)
		{
		}
	}
}
