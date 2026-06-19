using Services.Save;
using UnityEngine;
using Zenject;

namespace Installers
{
	public class SaveInstaller : MonoInstaller
	{
		[SerializeField]
		private string _saveDirectory = "SaveData";

		public override void InstallBindings()
		{
			base.Container.Bind<IJsonFileStorage>().To<JsonFileStorage>().AsSingle()
				.WithArguments(_saveDirectory);
			base.Container.BindInterfacesAndSelfTo<SaveService>().AsSingle();
		}
	}
}
