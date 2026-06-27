using Restory.Infrastructure;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface.TextSizeModifiers
{
	[CreateAssetMenu(fileName = "TextSizeModifiersInstaller", menuName = "Restory/UserInterface/TextSizeModifiersInstaller")]
	public class TextSizeModifiersInstaller : ScriptableObjectInstaller
	{
		[SerializeField]
		private GameObject textSizeModifiersServicePrefab;

		public override void InstallBindings()
		{
			TextSizeModifiersService component = base.Container.InstantiateAndQueueForInject(textSizeModifiersServicePrefab).GetComponent<TextSizeModifiersService>();
			base.Container.BindInterfacesAndSelfTo<TextSizeModifiersService>().FromInstance(component).AsSingle();
			base.Container.BindFactory<TextSizeModifier, TextSizeModifier.Factory>().AsSingle();
		}
	}
}
