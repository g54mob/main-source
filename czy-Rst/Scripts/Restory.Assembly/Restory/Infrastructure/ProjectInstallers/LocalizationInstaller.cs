using Restory.Data.Localization;
using Restory.UserInterface;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.ProjectInstallers
{
	public class LocalizationInstaller : MonoInstaller
	{
		[SerializeField]
		private SpecifiedLocalizationKeysDatabase specifiedLocalizationKeysDatabase;

		public override void InstallBindings()
		{
			base.Container.FindAndBindInterfacesAndSelfTo<GUI_LocalisedText>();
			if ((bool)specifiedLocalizationKeysDatabase)
			{
				base.Container.Bind<SpecifiedLocalizationKeysDatabase>().FromInstance(specifiedLocalizationKeysDatabase).AsSingle();
			}
		}
	}
}
