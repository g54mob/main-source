using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.LevelTransition
{
	public class LoadingScreenTipManager : BaseSingleton<LoadingScreenTipManager>
	{
		private List<string> _tips = new List<string>();

		protected override void Awake()
		{
			base.Awake();
			Object.DontDestroyOnLoad(base.gameObject);
		}

		public void Start()
		{
			_tips = LocalizationManager.GetTermsList("LoadingScreenTips");
		}

		public string GetRandomLoadingScreenTip()
		{
			return LocalizationManager.GetTranslation(_tips.RandomItem());
		}
	}
}
