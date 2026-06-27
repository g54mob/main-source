using Restory.ObjectPools;
using Restory.Utils.Observers;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Notifications
{
	public sealed class GUI_MoneyNotificationPool : ConcreteGameObjectPool
	{
		public GUI_MoneyNotificationPool(DiContainer diContainer, ApplicationQuitStartObserver applicationQuitStartObserver, GameObject prefab)
			: base(diContainer, applicationQuitStartObserver, prefab)
		{
		}
	}
}
