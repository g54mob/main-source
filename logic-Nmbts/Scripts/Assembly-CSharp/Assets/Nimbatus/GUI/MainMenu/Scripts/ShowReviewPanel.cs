using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using UnityEngine;
using UnityEngine.Analytics;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class ShowReviewPanel : MonoBehaviour
	{
		public float MinPlayTime;

		public TweenPosition Tween;

		public void Start()
		{
			if (SaveManager.GetTotalPlaytime() >= MinPlayTime && !RuntimeGlobals.Settings.HideReviewDisplay)
			{
				Analytics.CustomEvent("Show Review Popup");
				Tween.Play(true);
			}
			else
			{
				Tween.Play(false);
			}
		}

		public void HideReviewDisplay()
		{
			RuntimeGlobals.Settings.HideReviewDisplay = true;
			Tween.Play(false);
		}

		public void VisitReviewPage()
		{
			Application.OpenURL("https://store.steampowered.com/recommended/recommendgame/383840");
			RuntimeGlobals.Settings.HideReviewDisplay = true;
			Tween.Play(false);
		}
	}
}
