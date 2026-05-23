using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Localization.Settings;

namespace SaveData
{
	[Serializable]
	public class SettingData
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CChangeLocale_003Ed__45 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public SettingData _003C_003E4__this;

			private TaskAwaiter<LocalizationSettings> _003C_003Eu__1;

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

		public string localizeString;

		public int cursorSpeed;

		public int cameraDistance;

		public int cameraSpeed;

		public bool visibleDamage;

		public bool isInheritFavoritePalette;

		public bool enableRemoveTimer;

		public bool enableRemoveFavoriteConfirm;

		public bool forceSetDefaultSpeedInBattleStart;

		public bool enablePortPrioArrow;

		public int masterVolume;

		public int bgmVolume;

		public int seVolume;

		public bool isFullScreen;

		public bool isLowLoadMode;

		public int resolutionWidth;

		public int resolutionHeight;

		public int targetFps;

		public bool cameraShake;

		public bool isVsync;

		public bool isEnlargementUI;

		public int configChangePage;

		public int configHoldMenu;

		public int configCameraControl;

		public int configMachineRotation;

		private static readonly Vector2Int DefaultSteamDeckResolution;

		public bool IsEnlargementUI => false;

		public Action<float, float, bool> PostChangeResolutionProcess { get; set; }

		public Action<float, float, bool> PostChangeFullScreenProcess { get; set; }

		public void ApplySetting()
		{
		}

		public void ApplySteamDeckDefaultSetting()
		{
		}

		public void ChangeGameOptions()
		{
		}

		public void ChangeResolution()
		{
		}

		public void ChangeFullScreen()
		{
		}

		public void ChangeLowLoadMode()
		{
		}

		public void ChangeVSync()
		{
		}

		public void ChangeFPS()
		{
		}

		[AsyncStateMachine(typeof(_003CChangeLocale_003Ed__45))]
		public void ChangeLocale()
		{
		}

		public void ChangeVolume()
		{
		}

		public void InitControllerConfig()
		{
		}
	}
}
