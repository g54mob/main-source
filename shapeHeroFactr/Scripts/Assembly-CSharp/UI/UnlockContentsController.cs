using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public class UnlockContentsController : MonoBehaviour
	{
		public enum UnlockContentsType
		{
			Ascension = 0,
			Master = 1,
			Unit = 2,
			Research = 3,
			Feature = 4,
			Challenge = 5,
			Achievement = 6,
			ConsumptionItem = 7
		}

		[Serializable]
		public class UnlockContentsComponent
		{
			public UnlockContentsType type;

			public UnlockContentPanel panel;
		}

		private class UnlockContentData
		{
			public List<string> iconPaths;

			public string text;
		}

		[SerializeField]
		private List<UnlockContentsComponent> unlockContentsComponents;

		[SerializeField]
		private RectTransform unlockContentsParent;

		[SerializeField]
		private Button nextButton;

		private List<UnlockContentPanel> panels;

		private int page;

		private bool isPlayingAnimation;

		private UnityAction finishCallback;

		private bool isFinished;

		private float contentWidth;

		public bool haveContents => false;

		public void Init(UnityAction callback)
		{
		}

		public void AddContents(List<(eArchiveCategory, string)> unlockDatas)
		{
		}

		public void AddAscensionPanel()
		{
		}

		public void AddAchievementPanel(List<eSteamAchivementId> achievementIds)
		{
		}

		public void OnClickNextButton()
		{
		}

		public void NextContents()
		{
		}
	}
}
