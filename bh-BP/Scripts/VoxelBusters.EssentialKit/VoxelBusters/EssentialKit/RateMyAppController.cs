using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace VoxelBusters.EssentialKit
{
	internal class RateMyAppController
	{
		[CompilerGenerated]
		private sealed class _003CCheckForPresentation_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public RateMyAppController _003C_003E4__this;

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
			public _003CCheckForPresentation_003Ed__5(int _003C_003E1__state)
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

		private RateMyAppUnitySettings m_settings;

		private RateMyAppPresenter m_presenter;

		private RateMyAppControllerStateInfo m_stateInfo;

		private Action<RateMyAppConfirmationPromptActionType> m_onConfirmationPromptAction;

		private const string kPrefKey = "rma_state";

		public RateMyAppController(RateMyAppUnitySettings settings, string storeId)
		{
		}

		[IteratorStateMachine(typeof(_003CCheckForPresentation_003Ed__5))]
		private IEnumerator CheckForPresentation()
		{
			return null;
		}

		public void SetConfirmationDialogCallback(Action<RateMyAppConfirmationPromptActionType> onAction)
		{
		}

		public void Show(bool skipConfirmationPrompt = false)
		{
		}

		private void OnConfirmationDialogAction(RateMyAppConfirmationPromptActionType selectedButtonType)
		{
		}

		private void RecordAppLaunch()
		{
		}

		private void SetPromptLastShown(DateTime dateTime, bool incrementPromptCount)
		{
		}

		private bool CheckIfValidatorConditionsAreSatisfied()
		{
			return false;
		}

		private void SetDirty()
		{
		}

		private RateMyAppControllerStateInfo LoadStateInfo()
		{
			return null;
		}

		private void SaveStateInfo(RateMyAppControllerStateInfo stateInfo)
		{
		}

		public bool CanShow()
		{
			return false;
		}
	}
}
