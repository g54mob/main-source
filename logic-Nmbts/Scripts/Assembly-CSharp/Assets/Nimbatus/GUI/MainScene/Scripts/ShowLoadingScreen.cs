using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainScene.Scripts
{
	public class ShowLoadingScreen : MonoBehaviour
	{
		public UITexture Texture;

		private TweenPosition _tween;

		public bool ShowLoadingScreenTips;

		public UILabel TipLabel;

		public void Awake()
		{
			_tween = GetComponent<TweenPosition>();
			GetComponent<UIPanel>().enabled = true;
			NimbatusSceneManager.LoadingProgress = 0;
			if (ShowLoadingScreenTips)
			{
				TipLabel.text = BaseSingleton<LoadingScreenTipManager>.Instance.GetRandomLoadingScreenTip();
			}
		}

		public void Update()
		{
			if (Texture != null)
			{
				Texture.fillAmount = (float)NimbatusSceneManager.LoadingProgress / 100f;
			}
			_tween.Play(RuntimeGlobals.IsGameLoading || SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.IsLoading);
		}
	}
}
