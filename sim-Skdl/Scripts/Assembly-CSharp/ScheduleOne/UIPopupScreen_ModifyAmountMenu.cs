using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne
{
	public class UIPopupScreen_ModifyAmountMenu : UIPopupScreen
	{
		public enum ModifyAmountMenuMode
		{
			Store = 0
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass41_0
		{
			public UIPopupScreen_ModifyAmountMenu _003C_003E4__this;

			public Action<float> onConfirm;

			public Action onCancel;

			internal void _003CRegisterInput_003Eb__0()
			{
			}

			internal void _003CRegisterInput_003Eb__1()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CRegisterInput_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UIPopupScreen_ModifyAmountMenu _003C_003E4__this;

			public Action<float> onConfirm;

			public Action onCancel;

			private _003C_003Ec__DisplayClass41_0 _003C_003E8__1;

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
			public _003CRegisterInput_003Ed__41(int _003C_003E1__state)
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
		private sealed class _003CSelectInputField_003Ed__39 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UIPopupScreen_ModifyAmountMenu _003C_003E4__this;

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
			public _003CSelectInputField_003Ed__39(int _003C_003E1__state)
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
		private TMP_Text titleText;

		[SerializeField]
		private TMP_Text topMessageText;

		[SerializeField]
		private TMP_Text bottomMessageText;

		[SerializeField]
		private TMP_InputField amountInputField;

		[SerializeField]
		private Image itemImage;

		[SerializeField]
		private TMP_Text itemNameText;

		[SerializeField]
		private TMP_Text itemCostText;

		[SerializeField]
		private UITrigger confirmButton;

		[SerializeField]
		private UITrigger cancelButton;

		[SerializeField]
		private Canvas canvas;

		[SerializeField]
		private Button tier1DecreaseButton;

		[SerializeField]
		private Button tier2DecreaseButton;

		[SerializeField]
		private Button tier3DecreaseButton;

		[SerializeField]
		private Button tier1IncreaseButton;

		[SerializeField]
		private Button tier2IncreaseButton;

		[SerializeField]
		private Button tier3IncreaseButton;

		[SerializeField]
		private TMP_Text tier1DecreaseText;

		[SerializeField]
		private TMP_Text tier2DecreaseText;

		[SerializeField]
		private TMP_Text tier3DecreaseText;

		[SerializeField]
		private TMP_Text tier1IncreaseText;

		[SerializeField]
		private TMP_Text tier2IncreaseText;

		[SerializeField]
		private TMP_Text tier3IncreaseText;

		[SerializeField]
		private float holdThreshold;

		[SerializeField]
		private float repeatInterval;

		private UIInputDetectBehaviour tier1InputDetect;

		private UIInputDetectBehaviour tier2InputDetect;

		private UIInputDetectBehaviour tier3InputDetect;

		private ModifyAmountMenuMode modifyAmountMenuMode;

		private float itemPrice;

		private float minAmount;

		private float tier1Amount;

		private float tier2Amount;

		private float tier3Amount;

		protected override void OnAwake()
		{
		}

		protected override void OnStarted()
		{
		}

		protected override void Update()
		{
		}

		public override void Close()
		{
		}

		private void Open()
		{
		}

		[IteratorStateMachine(typeof(_003CSelectInputField_003Ed__39))]
		private IEnumerator SelectInputField()
		{
			return null;
		}

		public override void Open(params object[] args)
		{
		}

		[IteratorStateMachine(typeof(_003CRegisterInput_003Ed__41))]
		private IEnumerator RegisterInput(Action<float> onConfirm, Action onCancel)
		{
			return null;
		}

		private void UpdateStoreBottomMessage()
		{
		}

		private float GetCurrentAmount()
		{
			return 0f;
		}

		private void ChangeCurrentAmountBasedOnInputDetectTier1(float inputValue)
		{
		}

		private void ChangeCurrentAmountBasedOnInputDetectTier2(float inputValue)
		{
		}

		private void ChangeCurrentAmountBasedOnInputDetectTier3(float inputValue)
		{
		}

		private void ChangeCurrentAmountBasedOnInputDetect(float inputValue, float tierAmount)
		{
		}

		private void ChangeCurrentAmount(float increment)
		{
		}

		private void SetCurrentAmount(float amount)
		{
		}

		private void CapAmount(float amount)
		{
		}
	}
}
