using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using InputControl;
using Libs;
using ScriptableObjects.ScriptableObjectScripts.Settings;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public class TutorialCtrl : SingletonMonoBehaviour<TutorialCtrl>
	{
		[Serializable]
		public class TutorialContent
		{
			public eTipsType type;

			public GameObject headGroup;

			public TMP_Text titleText;

			public TMP_Text titleSub;

			public Image image;

			public CanvasGroup buttonImage;

			public TMP_Text buttonText;

			public CursorUIItem trigger;
		}

		private class TutorialInfo
		{
			public bool isOpen;

			public string title;

			public string padTitle;

			public eTipsType tipsType;

			public bool clickCheck;

			public Func<bool> conditionCheck;

			public UnityAction initAction;

			public UnityAction finishAction;

			public ChoiceArrow.initParam choiceParam;

			public string imagePath;

			public string moviePath;

			public bool isBlindfold;

			public RectTransform[] unmaskTarget;

			public float delay;

			public eTutorialId TutorialId;

			public List<eDialog> permissionDialog;

			public bool IsClick { get; set; }

			public TutorialInfo(string title, string padTitle, eTipsType tipsType, eTutorialId tutorialId, Func<bool> conditionCheck = null, UnityAction initAction = null, UnityAction finishAction = null, ChoiceArrow.initParam? choiceParam = null, string imagePath = null, string moviePath = null, bool blindfold = false, RectTransform[] unmaskTarget = null, List<eDialog> permissionDialog = null, float delay = 0f)
			{
			}

			public bool ConditionCheck(InputActionController input)
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CDisplayTutorial_003Ed__59 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TutorialCtrl _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CDisplayTutorial_003Ed__59(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public VideoPlayerCtrl videoPlayer;

		public ChoiceArrow choiceArrow;

		public Image blindfoldPanel;

		public TutorialContent[] tutorialContents;

		public CanvasGroup delayBlocklayCaster;

		[Header("Progress")]
		[SerializeField]
		private TutorialProgress progress;

		[Header("TutorialSection3")]
		public static string Tutorial_CountUp;

		public static string Tutorial_ClearTime;

		public static string Tutorial_TargetTime;

		public static string Tutorial_MinTarget;

		private List<TutorialInfo> _tutorialDatas;

		private MstTutorialSectionEntities _nowSectionData;

		private int _initMana;

		private int _tutorialIndex;

		private TutorialInfo _nowTutorial;

		private int _nowMachineCount;

		private FixTutorialCamera _fixTutorialCamera;

		private const float PalettePosY = -400f;

		private TutorialSetting _tutorialInfo;

		private InputActionController input;

		private Coroutine _conditionCoroutine;

		private eTutorialSectionId _nextSectionId;

		private Tween _clickableTween;

		private Tween _clickableTextTween;

		private double _skipTimer;

		private UnityAction _skipAction;

		private Action<float, float, bool> changeResolution;

		public bool isOpenTutorialTips;

		private float screenHeightRate;

		private bool _isOpenShortCutDialog;

		private bool _isClickDeley;

		public eTutorialId NowTutorialId => default(eTutorialId);

		public bool OpenProgress => false;

		public event UnityAction OnClickAction
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

		public event UnityAction OnFinishAction
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

		public TutorialContent GetTutorialContent(eTipsType type)
		{
			return null;
		}

		private void Awake()
		{
		}

		public void ResetScreenHeightRate(float? width = null, float? height = null)
		{
		}

		public void StartTutorial()
		{
		}

		private void RegisterTutorialSection1Init()
		{
		}

		private void RegisterTutorialSection1()
		{
		}

		private void RegisterTutorialSection2Init()
		{
		}

		private void RegisterTutorialSection2()
		{
		}

		private void RegisterTutorialSection3Init()
		{
		}

		private void RegisterTutorialSection3()
		{
		}

		public void RegisterTutorial(eTutorialId id, Func<bool> conditionCheck = null, UnityAction initAction = null, UnityAction finishAction = null, ChoiceArrow.initParam? choiceParam = null, bool blindfold = false, RectTransform[] unmaskTargets = null, List<eDialog> permissionDialog = null, float delay = 0f)
		{
		}

		public void RegisterEmptyTutorial(Func<bool> conditionCheck = null, UnityAction initAction = null, UnityAction finishAction = null, ChoiceArrow.initParam? choiceParam = null, bool blindfold = false, RectTransform[] unmaskTargets = null, List<eDialog> permissionDialog = null, float delay = 0f)
		{
		}

		public void Open()
		{
		}

		private void ChangeText(eTipsType type, bool isMain, string changeText)
		{
		}

		private void DisplayContents()
		{
		}

		private void SwitchPadTutorial(TutorialContent content)
		{
		}

		private string GetControllerTitle(MstTutorialEntities entity)
		{
			return null;
		}

		private void HiddenPrevTutorial()
		{
		}

		[IteratorStateMachine(typeof(_003CDisplayTutorial_003Ed__59))]
		private IEnumerator DisplayTutorial()
		{
			return null;
		}

		private void UpdateChoicePositionOnPalette(eMachine machineID)
		{
		}

		private void InitChoiceOnPalette(eMachine machineID)
		{
		}

		private void AppendMap(eTutorialId tutorialId, bool renew = false)
		{
		}

		private void AppendMap(string mapPath, bool renew = false)
		{
		}

		private void OpenLargeTips(bool closeable, params eLargeTips[] largeTips)
		{
		}

		private void OpenReward(int choiceCount, List<int> fixRewards, eUpgradePack pack)
		{
		}

		private bool CheckChoiceOnPalette(eMachine machineID)
		{
			return false;
		}

		private bool CheckMoveCamera()
		{
			return false;
		}

		private bool CheckZoomCamera()
		{
			return false;
		}

		private bool CheckDeliveryCount(eLuggage id, int count)
		{
			return false;
		}

		private string CheckClearTime()
		{
			return null;
		}

		public void OnClickTutorial()
		{
		}

		public void HiddenTips()
		{
		}

		public void ShowTips()
		{
		}

		private void MoveFactoryCamera(Vector3 toPosition, float toFieldOfView)
		{
		}

		public void SkipNowTutorial()
		{
		}

		public void RegisterSkipTutorial(double timer, UnityAction skipAction)
		{
		}

		public void UpdateTutorialSkip()
		{
		}

		public void ResetFinishAction()
		{
		}

		private new void OnDestroy()
		{
		}
	}
}
