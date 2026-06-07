using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Battle;
using Libs;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public class TipsCtrl : SingletonMonoBehaviour<TipsCtrl>
	{
		public class TipsInfo
		{
			public eTipsId id;

			public bool isOpen;

			public string title;

			public string padTitle;

			public bool clickCheck;

			public bool showClickHere;

			public ePhase targetPhase;

			public float disableClickTime;

			public Func<bool> showTiming;

			public Func<bool> conditionCheck;

			public UnityAction initAction;

			public UnityAction finishAction;

			public ChoiceArrow.initParam choiceParam;

			public string imagePath;

			public string gifPath;

			public bool isBlindfold;

			public bool isDisplayed;

			private float _disableClickTimer;

			private float _displayTimer;

			public bool EnableClick => false;

			public bool IsClick { get; set; }

			public TipsInfo(eTipsId id, bool clickCheck, ePhase phase, Func<bool> showTiming, float disableClickTime = 0f, Func<bool> conditionCheck = null, UnityAction initAction = null, UnityAction finishAction = null, ChoiceArrow.initParam? choiceParam = null, bool blindfold = true, bool showClickHere = false)
			{
			}

			public TipsInfo(ePhase phase, Func<bool> showTiming, Func<bool> conditionCheck = null, UnityAction initAction = null, UnityAction finishAction = null)
			{
			}

			public bool ConditionCheck(InputActionController input)
			{
				return false;
			}

			public void StartTimer()
			{
			}

			private void UpdateTimer()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CDisplayTips_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TipsCtrl _003C_003E4__this;

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
			public _003CDisplayTips_003Ed__33(int _003C_003E1__state)
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

		public TMP_Text titleText;

		public GameObject tipsGroup;

		public GameObject clickHereText;

		public GameObject padClickHereText;

		public GameObject clickHereParent;

		public Image tipsSampleImage;

		public AnimatedImage gifPlayer;

		public ChoiceArrow choiceArrow;

		public Image blindfoldPanel;

		public static bool enableDisplayTips;

		private List<TipsInfo> _reservedTips;

		private int _tipsIndex;

		private TipsInfo _nowTips;

		private Vector3 _initialScale;

		private InputActionController input;

		public bool isOpenTips;

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

		public eTipsId IsOpenTipsId()
		{
			return default(eTipsId);
		}

		private void Awake()
		{
		}

		public void InitLobbyTips()
		{
		}

		public void InitInGameTips()
		{
		}

		private void RegisterLobbyTips()
		{
		}

		private void RegisterInGameTips()
		{
		}

		public void RegisterChallengeTips()
		{
		}

		private void AddTips(TipsInfo info)
		{
		}

		private void AddLargeTips(eLargeTips largeTips, TipsInfo info, bool hasCheck = true)
		{
		}

		public void UpdateTipsCheck()
		{
		}

		public void Open()
		{
		}

		private void SwitchPadTips()
		{
		}

		private void CloseTips()
		{
		}

		[IteratorStateMachine(typeof(_003CDisplayTips_003Ed__33))]
		private IEnumerator DisplayTips()
		{
			return null;
		}

		public void OnClickTips()
		{
		}

		public void HiddenTips()
		{
		}

		public void ShowTips()
		{
		}

		private new void OnDestroy()
		{
		}

		public void OnPadStart()
		{
		}
	}
}
