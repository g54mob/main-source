using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class PaintingToolInteractionSystemsInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject prefab;

		public override void InstallBindings()
		{
			base.Container.InstantiateAndQueueForInject(prefab);
		}
	}
}
