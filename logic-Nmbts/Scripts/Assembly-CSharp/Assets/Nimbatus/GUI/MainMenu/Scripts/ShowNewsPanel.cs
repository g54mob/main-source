using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class ShowNewsPanel : MonoBehaviour
	{
		public TweenPosition Tween;

		public void Start()
		{
			if (!RuntimeGlobals.Settings.HideNewsDisplay)
			{
				Tween.Play(true);
			}
			else
			{
				Tween.Play(false);
			}
		}

		public void HideNewsDisplay()
		{
			RuntimeGlobals.Settings.HideNewsDisplay = true;
			Tween.Play(false);
		}

		public void VisitNewsPage()
		{
			Application.OpenURL("https://store.steampowered.com/app/1121640/The_Wandering_Village/?utm_source=Nimbatus");
			RuntimeGlobals.Settings.HideNewsDisplay = true;
			Tween.Play(false);
		}
	}
}
