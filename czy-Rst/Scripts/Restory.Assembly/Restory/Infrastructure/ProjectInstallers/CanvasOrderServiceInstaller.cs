using Restory.UserInterface;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.ProjectInstallers
{
	public class CanvasOrderServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject prefab;

		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<CanvasOrderService>().FromComponentInNewPrefab(prefab).AsSingle();
		}
	}
}
