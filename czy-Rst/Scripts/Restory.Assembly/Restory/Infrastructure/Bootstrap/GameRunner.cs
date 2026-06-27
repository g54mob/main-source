using Restory.AssetManagement.References;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.Bootstrap
{
	public class GameRunner : MonoBehaviour
	{
		[SerializeField]
		private GameBootstrapper bootstrapperPrefab;

		[SerializeField]
		private GameScenesAssetRef scenesListRef;

		public GameScenesAssetRef ScenesListRef => scenesListRef;

		private void Awake()
		{
			if (!ProjectContext.HasInstance)
			{
				Initialize();
			}
		}

		private void Initialize()
		{
			ProjectContext instance = ProjectContext.Instance;
			GameBootstrapper gameBootstrapper = Object.FindAnyObjectByType<GameBootstrapper>();
			if (gameBootstrapper == null)
			{
				gameBootstrapper = instance.Container.InstantiatePrefabForComponent<GameBootstrapper>(bootstrapperPrefab.gameObject);
			}
			gameBootstrapper.BootPreset(scenesListRef);
		}
	}
}
