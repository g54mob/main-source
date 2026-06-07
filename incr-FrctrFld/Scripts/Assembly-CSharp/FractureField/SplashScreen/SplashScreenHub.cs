using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FractureField.UI.Components.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace FractureField.SplashScreen
{
	public class SplashScreenHub : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CResetNewGameConfirmation_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SplashScreenHub _003C_003E4__this;

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
			public _003CResetNewGameConfirmation_003Ed__23(int _003C_003E1__state)
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
		private RectTransform _layoutRect;

		[SerializeField]
		private Image _titleImage;

		[SerializeField]
		private LayoutElement _titleImageLayout;

		[SerializeField]
		private RButtonComponent _continueGameButton;

		[SerializeField]
		private RButtonComponent _newGameButton;

		[SerializeField]
		private RButtonComponent _wishlistOnSteamButton;

		[SerializeField]
		private RButtonComponent _discordButton;

		[SerializeField]
		private RButtonComponent _qqButton;

		[SerializeField]
		private GameObject _demoTag;

		[SerializeField]
		private GameObject _languagePopup;

		[SerializeField]
		private GameObject _buttons;

		[Header("Sprites")]
		[SerializeField]
		private Sprite _titleSprite_EN;

		[SerializeField]
		private Sprite _titleSprite_SC;

		[SerializeField]
		private Sprite _titleSprite_TW;

		[SerializeField]
		private Sprite _titleSprite_JA;

		[SerializeField]
		private Sprite _titleSprite_KO;

		private bool _isSetup;

		private bool _isConfirmingNewGame;

		private Coroutine _resetNewGameConfirmationCoroutine;

		private void Awake()
		{
		}

		private void Setup()
		{
		}

		public void ClickedContinueGame()
		{
		}

		public void ClickedNewGame()
		{
		}

		[IteratorStateMachine(typeof(_003CResetNewGameConfirmation_003Ed__23))]
		private IEnumerator ResetNewGameConfirmation()
		{
			return null;
		}

		private void CancelNewGame()
		{
		}

		private void StartNewGame()
		{
		}

		public void ClickedWishlistOnSteam()
		{
		}

		public void ClickedJoinDiscord()
		{
		}

		public void ClickedQQ()
		{
		}

		public void ClickedLanguage()
		{
		}

		public void ClickedHideLanguage()
		{
		}

		public void ClickedLanguage(string code)
		{
		}
	}
}
