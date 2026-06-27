using Restory.AssetManagement.References;
using UnityEngine;

namespace Restory.Data.Locations
{
	[CreateAssetMenu(fileName = "SceneListTransition - NewTransitionName", menuName = "Restory/Data/GameScenesPresetTransition", order = 0)]
	public class GameScenesPresetTransition : ScriptableObject
	{
		[SerializeField]
		private GameScenesAssetRef scenesPreset;

		[SerializeField]
		private FadeScreenTypes fadeScreen = FadeScreenTypes.DefaultFadeScreen;

		[SerializeField]
		private LoadingScreenTypes loadingScreen;

		public GameScenesAssetRef ScenesPreset => scenesPreset;

		public FadeScreenTypes FadeScreen => fadeScreen;

		public LoadingScreenTypes LoadingScreen => loadingScreen;
	}
}
