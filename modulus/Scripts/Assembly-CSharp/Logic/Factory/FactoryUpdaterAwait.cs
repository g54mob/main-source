using UnityEngine;

namespace Logic.Factory
{
	public class FactoryUpdaterAwait : MonoBehaviour
	{
		[SerializeField]
		private FactoryUpdater _factoryUpdater;

		private void Update()
		{
			_factoryUpdater.CompleteTasks();
		}
	}
}
