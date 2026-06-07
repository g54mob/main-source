using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service;
using VampireSurvivors.App.Scripts.UI;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class AccountPage : ProgrammaticUI
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass14_0
		{
			public RememberMeService rememberMeService;

			internal void _003COnShowStart_003Eb__0()
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CDoLogout_003Ed__23 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public AccountPage _003C_003E4__this;

			private RememberMeService _003CrememberMeService_003E5__2;

			private TaskAwaiter<bool> _003C_003Eu__1;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003COnShowStart_003Ed__14 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public AccountPage _003C_003E4__this;

			public GameObject g;

			private _003C_003Ec__DisplayClass14_0 _003C_003E8__1;

			private TaskAwaiter<string> _003C_003Eu__1;

			private TaskAwaiter<ILoginResult> _003C_003Eu__2;

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
		private TextMeshProUGUI _AccountStatus;

		[SerializeField]
		private Button _SpecialButton;

		[SerializeField]
		private Image _SpecialButtonIcon;

		[SerializeField]
		private Sprite _showHideSprite;

		[SerializeField]
		private Sprite _infoSprite;

		private PlayerOptions _playerOptions;

		private AccountPageState accountPageState;

		private AchievementManager _achievementManager;

		private bool _backBeingBlockedByInput;

		private const bool ACCOUNT_VERIFICATION_REQUIRED = true;

		[Inject]
		private void Construct(PlayerOptions player, AchievementManager achievementManager)
		{
		}

		protected override void Awake()
		{
		}

		private void ClearAndBuild()
		{
		}

		private void Build()
		{
		}

		[AsyncStateMachine(typeof(_003COnShowStart_003Ed__14))]
		protected override void OnShowStart(GameObject g)
		{
		}

		protected override void OnHideStart(GameObject g)
		{
		}

		public void LateUpdate()
		{
		}

		public void AddBackButtonListener()
		{
		}

		public bool GetFlag(string key)
		{
			return false;
		}

		public void SetFlag(string key, bool value)
		{
		}

		private void BackButtonPress()
		{
		}

		private void ClearHistory()
		{
		}

		public void AddLogoutButton()
		{
		}

		[AsyncStateMachine(typeof(_003CDoLogout_003Ed__23))]
		public Task DoLogout()
		{
			return null;
		}

		public void ChangeStateTo(UIState uiState)
		{
		}

		public void GoHome()
		{
		}

		public void SetTitle(string title)
		{
		}

		public void HideLoggedInStatus()
		{
		}

		public static bool IsAccountVerificationRequired()
		{
			return false;
		}

		public void SetLoggedInStatus()
		{
		}

		public void SetGenericUnverifiedStatus()
		{
		}

		public void SetGenericLoggedInStatus()
		{
		}

		private void SetLoggedOutStatus()
		{
		}

		private BaseAccountPagePanel GetPanelForState(UIState state)
		{
			return null;
		}

		public static string GetTranslation(string key)
		{
			return null;
		}

		public static string GetAccountTranslation(string key)
		{
			return null;
		}

		public static string GetAccountTranslation(string key, params string[] args)
		{
			return null;
		}

		public void ShowSpecialButtonForShowHide(Action action)
		{
		}

		public void ShowSpecialButtonForInformation(Action action)
		{
		}

		public void DisableSpecialButton()
		{
		}

		private void EnableSpecialButton(Action action, Sprite sprite)
		{
		}

		public void ReAddSpecialButtonNavigation()
		{
		}

		public override void Clear()
		{
		}

		public override void SelectFirstSelectable()
		{
		}
	}
}
