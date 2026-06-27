using Restory.UserInterface;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	[CreateAssetMenu(fileName = "LocalisedFontsMaterialsTableInstaller", menuName = "Restory/UserInterface/FontsLocalisation/LocalisedFontsMaterialsTableInstaller")]
	public class LocalisedFontsMaterialsTableInstaller : ScriptableObjectInstaller
	{
		[SerializeField]
		private LocalisedFontsMaterialsTable localisedFontsMaterialsTable;

		public override void InstallBindings()
		{
			base.Container.Bind<LocalisedFontsMaterialsTable>().FromInstance(localisedFontsMaterialsTable).AsSingle();
		}
	}
}
