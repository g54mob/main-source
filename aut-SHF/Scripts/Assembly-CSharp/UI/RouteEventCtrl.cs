using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using InputControl;
using Libs;
using ScriptableObjects.ScriptableObjectScripts.Settings;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

namespace UI
{
	public class RouteEventCtrl : SingletonMonoBehaviour<RouteEventCtrl>
	{
		[Serializable]
		public struct RelicRarityFrame
		{
			public eRelicRarity rarity;

			public Sprite frame;

			public string color;

			public LocalizedString rarityLocalizeText;
		}

		public enum RouteEventProcess
		{
			None = 0,
			WaitChoiceEvent = 1,
			WaitChoiceReward = 2,
			WaitPushNext = 3
		}

		[CompilerGenerated]
		private sealed class _003CDelayCursorSet_003Ed__76 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public RouteEventCtrl _003C_003E4__this;

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
			public _003CDelayCursorSet_003Ed__76(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CDelayCursorSet_003Ed__77 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public RouteEventCtrl _003C_003E4__this;

			public CursorUIGroup group;

			public int index;

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
			public _003CDelayCursorSet_003Ed__77(int _003C_003E1__state)
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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CStartEventSequence_003Ed__67 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public int eventIdx;

			public RouteEventCtrl _003C_003E4__this;

			public bool withSave;

			public int interruptEventId;

			private UniTask<bool>.Awaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[SerializeField]
		private RectTransform _buttonContent;

		[SerializeField]
		private ChoiceMenuButtonBase _choiceButtonPrefab;

		[SerializeField]
		private RouteEventView _routeEventViewPrefab;

		[SerializeField]
		private Vector3[] _routeViewPos;

		[SerializeField]
		private ChoiceMenuButtonBase _nextButton;

		[SerializeField]
		private PadInputConfigure _padInputConfigure;

		[SerializeField]
		private GameObject _padGuide;

		[SerializeField]
		private GameObject _nextButtonCursor;

		[SerializeField]
		private CursorUIGroup _buttonGroup;

		[SerializeField]
		private RectTransform tipTransform;

		[SerializeField]
		private Image relicIcon;

		[SerializeField]
		private Image relicFrame;

		[SerializeField]
		private TMP_Text relicRarityName;

		[SerializeField]
		private TMP_Text relicName;

		[SerializeField]
		private TMP_Text relicDesc;

		[SerializeField]
		private List<RelicRarityFrame> rarityFrames;

		[SerializeField]
		private Vector2 hovorUIOffset;

		[SerializeField]
		private Vector2 tweenOffset;

		public MstRelicDataEntities relicData;

		private UISetting _uiSetting;

		private Tween _tween;

		private Tween _delayTween;

		private int _lastFocusObjID;

		private RouteEventView _routeEventViewBook;

		private List<ChoiceMenuButtonBase> _choiceButtons;

		private CancellationTokenSource _cancelsource;

		private MstRouteEventChoiceEntities _selectedEventChoice;

		private bool _isChoiceReward;

		private bool _isLoopReward;

		private eUpgradeKind _choiceRewardKind;

		private (bool, eUpgradeKind) _selectedChoiceReward;

		private bool _isLastProcess;

		private bool _isSequence;

		private string _resultDesc;

		private bool _pushNextButton;

		public RouteEventProcess NowEventProcess;

		private bool CheckSelectedChoiceReward => false;

		public void GetChoiceReward(eUpgradeKind kind)
		{
		}

		private void Awake()
		{
		}

		public void CreateEvent(eRouteEvent routeEvent)
		{
		}

		private List<MstRouteEventDataEntities> CheckResearchRelics(List<MstRouteEventDataEntities> eventList)
		{
			return null;
		}

		public void CreateInterruptEvent(int id)
		{
		}

		public void ReloadHappeningEvent()
		{
		}

		public void CreateEventButton(MstRouteEventDataEntities data)
		{
		}

		private bool IsRelicChoiceData(MstRouteEventChoiceEntities choiceData)
		{
			return false;
		}

		public RelicRarityFrame GetRarityFrame(eRelicRarity rarity)
		{
			return default(RelicRarityFrame);
		}

		private void DisplayDetail(GameObject target, string title, string subTitle, string desc, string iconPath, Sprite frameSprite = null)
		{
		}

		public bool CheckCost(MstRouteEventChoiceEntities choiceData)
		{
			return false;
		}

		public bool CustomCheckCost(MstRouteEventChoiceEntities choiceData)
		{
			return false;
		}

		public void PaymentCost(MstRouteEventChoiceEntities choiceData)
		{
		}

		private List<MstRouteEventChoiceEntities> CustomEventProcess(MstRouteEventDataEntities data)
		{
			return null;
		}

		private List<MstRouteEventChoiceEntities> GetRouteEventChoicesForRelic(MstRouteEventDataEntities data)
		{
			return null;
		}

		private List<MstRouteEventChoiceEntities> GetRouteEventChoicesForRareRelic(MstRouteEventDataEntities data)
		{
			return null;
		}

		private List<MstRouteEventChoiceEntities> GetRouteEventChoicesForAdvancedResearch(MstRouteEventDataEntities data)
		{
			return null;
		}

		private List<MstRouteEventChoiceEntities> GetRouteEventChoicesForUseHPGetManaLoop(MstRouteEventDataEntities data)
		{
			return null;
		}

		private List<MstRouteEventChoiceEntities> GetRouteEventChoicesForGetRandomStatue(MstRouteEventDataEntities data)
		{
			return null;
		}

		private List<MstRouteEventChoiceEntities> GetFullOpenScrollList(MstRouteEventDataEntities data)
		{
			return null;
		}

		public bool CustomFilter(MstUpgradePackEntities mstPack, MstResearchCategoryEntities data)
		{
			return false;
		}

		private bool CheckHpCost(MstRouteEventChoiceEntities choiceData)
		{
			return false;
		}

		private bool CheckFullOpenMap(MstRouteEventChoiceEntities choiceData)
		{
			return false;
		}

		private bool CheckChoiceReward(eUpgradeKind kind)
		{
			return false;
		}

		public void ClearChoiceButton()
		{
		}

		private void DisableRelicTips()
		{
		}

		public void TurnPage()
		{
		}

		[AsyncStateMachine(typeof(_003CStartEventSequence_003Ed__67))]
		public void StartEventSequence(int eventIdx = 0, int interruptEventId = 0, bool withSave = true)
		{
		}

		private bool CheckInterruptEvent(out int interruptEventId)
		{
			interruptEventId = default(int);
			return false;
		}

		public void ResetFlg()
		{
		}

		public void DisplayNextButton()
		{
		}

		public void OnNextButton()
		{
		}

		public void DisplayToggle(bool value)
		{
		}

		private ChoiceMenuButtonBase CreateChildButton()
		{
			return null;
		}

		private new void OnDestroy()
		{
		}

		private void Update()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayCursorSet_003Ed__76))]
		private IEnumerator DelayCursorSet()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CDelayCursorSet_003Ed__77))]
		private IEnumerator DelayCursorSet(CursorUIGroup group, int index)
		{
			return null;
		}

		public void TrySelectButtonGroup()
		{
		}
	}
}
