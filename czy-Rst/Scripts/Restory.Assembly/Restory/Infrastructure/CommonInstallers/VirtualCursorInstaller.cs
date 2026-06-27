using Restory.UserInterface;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.CommonInstallers
{
	public class VirtualCursorInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject virtualCursorCanvasPrefab;

		public override void InstallBindings()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(virtualCursorCanvasPrefab);
			base.Container.Bind<VirtualCursorView>().FromInstance(gameObject.GetComponentInChildren<VirtualCursorView>()).AsTransient();
		}
	}
}
