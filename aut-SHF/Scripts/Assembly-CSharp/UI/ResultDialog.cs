using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Battle;
using InputControl;
using SaveData;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public class ResultDialog : BaseDialog
	{
		public enum NodeState
		{
			Normal = 0,
			Start = 1,
			Boss = 2,
			Endless = 3
		}

		[Serializable]
		private struct StateSprite
		{
			public eClearState state;

			public Sprite sprite;
		}

		private class DivisionWaveLog
		{
			public int division;

			public List<WaveLog> logs;

			public bool isEndless;
		}

		[SerializeField]
		private TMP_Text date;

		[SerializeField]
		private GameObject challengeTitleObj;

		[SerializeField]
		private TMP_Text challengeTitleText;

		[SerializeField]
		private Image resultImage;

		[SerializeField]
		private GameObject resultEndless;

		[SerializeField]
		private GameObject resultBackground;

		[SerializeField]
		private GameObject scorePlate;

		[SerializeField]
		private TMP_Text scoreText;

		[SerializeField]
		private Image scoreRankImage;

		[SerializeField]
		private ScoreDetailPanel scoreDetailPanel;

		[SerializeField]
		private Image writerImage;

		[SerializeField]
		private GameObject ascensionObj;

		[SerializeField]
		private TMP_Text ascensionCount;

		[SerializeField]
		private TMP_Text lastWaveText;

		[SerializeField]
		private TMP_Text lastLvText;

		[SerializeField]
		private TMP_Text useTotalMana;

		[SerializeField]
		private TMP_Text useTotalResearch;

		[SerializeField]
		private TMP_Text useTotalRedResearch;

		[SerializeField]
		private TMP_Text useTotalKeen;

		[SerializeField]
		private TMP_Text getKnowledgePoint;

		[SerializeField]
		private Image screenShot;

		[SerializeField]
		private Button expansionImageButton;

		[SerializeField]
		private Button saveImageButton;

		[SerializeField]
		private Image saveSuccessImage;

		[SerializeField]
		private Image saveFailedImage;

		[SerializeField]
		private TMP_Text returnFactoryText;

		[SerializeField]
		private TMP_Text expansionScreenShotText;

		[SerializeField]
		private GameObject screenShotTextArrowObj;

		[SerializeField]
		private ResultRouteEvent routeEventPrefab;

		[SerializeField]
		private ResultRouteNode routeNodePrefab;

		[SerializeField]
		private RectTransform routeContents;

		[SerializeField]
		private int maxRouteRawContent;

		[SerializeField]
		private RectTransform routeRawPrefab;

		[SerializeField]
		private ResultLuggageBar luggageBarPrefab;

		[SerializeField]
		private RectTransform productCountBarContent;

		[SerializeField]
		private RectTransform battleDamageBarContent;

		[SerializeField]
		private ResultResearchGroup researchGroupPrefab;

		[SerializeField]
		private RectTransform researchContent;

		[SerializeField]
		private ChoiceMenuButtonBase relicImagePrefab;

		[SerializeField]
		private RectTransform relicContent;

		[SerializeField]
		private TMP_Text versionText;

		[SerializeField]
		private GameObject commentGroup;

		[SerializeField]
		private TMP_Text commentText;

		[SerializeField]
		private List<StateSprite> stateSprites;

		[SerializeField]
		private CanvasGroup resultCanvasGroup;

		[SerializeField]
		private Image screenShotViewer;

		[SerializeField]
		private List<Transform> ignoreDestroyObjList;

		[SerializeField]
		private PadInputConfigure padInputConfigure;

		private bool isReference;

		private InGameData inGameData;

		private Texture2D captureTexture;

		private Texture2D captureTextureLarge;

		private List<RectTransform> routeRaws;

		private static readonly string DisplayDateFormat;

		[SerializeField]
		private Button nextButton;

		[SerializeField]
		private GameObject closeButtonGroup;

		[SerializeField]
		private UnlockContentsController unlockContentsController;

		private event UnityAction OnOkClickAction
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public override void Init()
		{
		}

		public override void Init<T>(T args)
		{
		}

		public override void Open()
		{
		}

		public override void Open<T>(T args)
		{
		}

		private void ClearAllChildren()
		{
		}

		public void DisplayUI()
		{
		}

		private List<DivisionWaveLog> GetWaveLogPerDivision(List<WaveLog> historyList)
		{
			return null;
		}

		private void ClearChildren(Transform parent)
		{
		}

		[Conditional("TRIAL")]
		private void TrialMessage()
		{
		}

		public void BackTitle()
		{
		}

		public void ReturnFactory()
		{
		}

		public void SaveLargeScreenShot()
		{
		}

		private void SetSaveResultImage(bool? result)
		{
		}

		public void DeleteLargeScreenShot()
		{
		}

		public void OpenScreenShotViewer()
		{
		}

		public void CloseScreenShotViewer()
		{
		}

		public override void SetInFront()
		{
		}

		public override void PushEscape()
		{
		}

		public void OnClickNextButton()
		{
		}

		public void OnPadBack()
		{
		}

		public void OnFinishUnlockEffect()
		{
		}

		public void OnClickScoreDetail()
		{
		}

		public void OnDestroy()
		{
		}
	}
}
