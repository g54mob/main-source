using Cheats;
using UnityEngine;
using Zenject;

public class CheatInstaller : MonoInstaller
{
	[SerializeField]
	private CheatSettings _settings;

	[SerializeField]
	private CheatPanelView _viewPrefab;

	public override void InstallBindings()
	{
		base.Container.BindInstance(_settings).AsSingle();
		base.Container.Bind<CheatPanelViewModel>().AsSingle().NonLazy();
		base.Container.Bind<CheatPanelView>().FromComponentInNewPrefab(_viewPrefab).AsSingle()
			.NonLazy();
	}
}
