using Restory.Data.Elements.Condition;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public class DefaultElementConditionsInstaller : MonoInstaller
	{
		[SerializeField]
		private DefaultElementConditions defaultElementConditions;

		public override void InstallBindings()
		{
			base.Container.Bind<DefaultElementConditions>().FromInstance(defaultElementConditions).AsSingle();
		}
	}
}
