using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Doozy.Engine.UI;
using Rewired;
using Rewired.Integration.UnityUI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI
{
	public class BaseUIPage : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CParse_003Ed__47 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BaseUIPage _003C_003E4__this;

			private string _003CignoreTag_003E5__2;

			private TextMeshProUGUI[] _003Cts_003E5__3;

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
			public _003CParse_003Ed__47(int _003C_003E1__state)
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
		private sealed class _003CWaitForPlayersToBeInsideGameplayUi_003Ed__44 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BaseUIPage _003C_003E4__this;

			public int uiPageId;

			private List<Button> _003CdeactivatedButtons_003E5__2;

			private Selectable _003CselectedBtn_003E5__3;

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
			public _003CWaitForPlayersToBeInsideGameplayUi_003Ed__44(int _003C_003E1__state)
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

		[SerializeField]
		private bool _UseScreenSpaceCamera;

		[SerializeField]
		protected bool _hasScrollView;

		[SerializeField]
		protected float _scrollSpeed;

		[SerializeField]
		protected RectTransform _scroll;

		[SerializeField]
		protected RectTransform _content;

		[SerializeField]
		protected Scrollbar _scrollbar;

		[SerializeField]
		protected Slider _Slider;

		[SerializeField]
		protected float _ForceScrollBarSize;

		protected bool _AutoSizeAfterParse;

		[SerializeField]
		private float _OffsetWhenSliderShown;

		[SerializeField]
		protected int ItemsPerPage;

		protected int previouslySelectedItemIndex;

		protected ScrollEnhancer _scrollEnhancer;

		protected RewiredStandaloneInputModule _inputModule;

		protected UIView View;

		private bool ShouldLog;

		protected SignalBus SignalBus;

		protected MultiplayerManager Multiplayer;

		protected Rewired.Player Player;

		protected DataManager Data;

		protected AdventureManager Adventure;

		protected bool _isWaitingForPlayersToEnterUi;

		private float _defaultRepeatDelay;

		private float _defaultInputActionsPerSecond;

		private float _maxInputActionsPerSecond;

		private float _scrollAccelerationSpeed;

		private static float SCROLL_ACTIONS_PER_SEC;

		private static float SCROLL_ACCELERATION;

		private Sprite _defaultPanelSprite;

		private RenderMode? _originalMode;

		private Vector3 _originalCanvasScale;

		private float _originalOrthographicSize;

		protected virtual bool IsOnlineUi => false;

		[Inject]
		private void Construct(SignalBus signalBus, MultiplayerManager _mult, DataManager _data, AdventureManager _adventure)
		{
		}

		protected virtual void Awake()
		{
		}

		protected virtual void OnShowStart(GameObject g)
		{
		}

		protected virtual void OnCharacterDisconnected(OnlineSignals.CharacterDisconnected signal)
		{
		}

		protected void EnterMultiplayerControl(VampireSurvivors.Objects.Characters.CharacterController player, float vibrationMilliseconds = -1f)
		{
		}

		private void SelectPlayerInput(VampireSurvivors.Objects.Characters.CharacterController player, float vibrationMilliseconds)
		{
		}

		protected virtual VampireSurvivors.Objects.Characters.CharacterController GetCharacterControllingUi()
		{
			return null;
		}

		protected bool IsLocalPlayerControllingUi()
		{
			return false;
		}

		protected void ExitMultiplayerControl()
		{
		}

		private void EnterOnlineMultiplayerControl()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForPlayersToBeInsideGameplayUi_003Ed__44))]
		private IEnumerator WaitForPlayersToBeInsideGameplayUi(int uiPageId)
		{
			return null;
		}

		private List<Button> DeactivateButtons(out Selectable selectedBtn)
		{
			selectedBtn = null;
			return null;
		}

		private void ReactivateButtons(List<Button> buttons, Selectable selectedBtn)
		{
		}

		[IteratorStateMachine(typeof(_003CParse_003Ed__47))]
		private IEnumerator Parse()
		{
			return null;
		}

		public void ForceScrollAlignment()
		{
		}

		protected virtual void OnShowFinish(GameObject g)
		{
		}

		protected virtual void OnHideStart(GameObject g)
		{
		}

		protected virtual void OnHideFinish(GameObject g)
		{
		}

		protected virtual void Update()
		{
		}

		private void ScrollSelection(bool up)
		{
		}

		private void ScrollPageWithoutSelectables(bool up)
		{
		}

		protected void ForceBackButtonNavigation(Selectable up, Selectable down, Selectable left, Selectable right)
		{
		}

		protected void ResetBackButtonNavigation()
		{
		}

		protected virtual void OnEnterPressed()
		{
		}

		protected virtual void OnCancelPressed()
		{
		}

		protected void SetNavigationUp(Selectable origin, Selectable target = null)
		{
		}

		protected void SetNavigationDown(Selectable origin, Selectable target = null)
		{
		}

		protected void SetNavigationLeft(Selectable origin, Selectable target = null)
		{
		}

		protected void SetNavigationRight(Selectable origin, Selectable target = null)
		{
		}

		protected void SetNavigationMode(Selectable origin, Navigation.Mode mode)
		{
		}

		protected void ClearNavigationUp(Selectable origin)
		{
		}

		protected void ClearNavigationDown(Selectable origin)
		{
		}

		protected void ClearNavigationLeft(Selectable origin)
		{
		}

		protected void ClearNavigationRight(Selectable origin)
		{
		}

		public void SetScrollAcceleration(float maxSpeed, float acceleration)
		{
		}
	}
}
