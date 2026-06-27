using Restory.Infrastructure.CommonServices;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.CommonInstallers
{
	public class MenuCursorDetectorInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject cursorDetectorPrefab;

		public override void InstallBindings()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(cursorDetectorPrefab, base.transform);
			base.Container.BindInterfacesAndSelfTo<MenuCursorDetector>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
