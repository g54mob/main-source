using CTS.BBT;
using CTS.Core;
using CTS.StockInventory;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class BloodLevelNotifications : LockableMonoBehaviour
	{
		[SerializeField]
		[Space(10f)]
		[BoxGroup("Base Settings")]
		private float _feedbackDuration = 5f;

		[SerializeField]
		[BoxGroup("Base Settings")]
		private float _feedbackCooldown = 10f;

		[SerializeField]
		[BoxGroup("Base Settings")]
		private StockItemSO _stockItemToCheck;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Full Feedback Settings")]
		private LocalizedString _fullAlertTitle;

		[SerializeField]
		[BoxGroup("Full Feedback Settings")]
		private LocalizedString _fullAlertContent;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Low Feedback Settings")]
		private int _countForLowStock = 20;

		[SerializeField]
		[BoxGroup("Low Feedback Settings")]
		private LocalizedString _feedbackForLowStock;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Nearly Empty Feedback Settings")]
		private int _countForNearlyEmpty = 10;

		[SerializeField]
		[BoxGroup("Nearly Empty Feedback Settings")]
		private LocalizedString _feedbackForNearlyEmpty;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Empty Feedback Settings")]
		private LocalizedString _feedbackForEmpty;

		[SerializeField]
		[BoxGroup("Empty Feedback Settings")]
		private LocalizedString _emptyAlertTitle;

		[SerializeField]
		[BoxGroup("Empty Feedback Settings")]
		private LocalizedString _emptyAlertContent;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Debug Data")]
		private bool _debugMode;

		private float _nextFeedback;

		private EState _currentState = EState.Empty;

		public static ILockable Instance { get; private set; }

		protected override void Awake()
		{
			Instance = this;
			base.Awake();
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			Stocks.BarStock.RegisterToStockChange(_stockItemToCheck, OnStockChanged);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			Stocks.BarStock.UnregisterToStockChange(_stockItemToCheck, OnStockChanged);
		}

		private void OnStockChanged(StockInventory<StockStack, StockItemSO>.StockItemChangedData changedData)
		{
			int itemCount = changedData.ItemCount;
			int value = changedData.StockChangedData.StockCapacity.MaxCapacity.Value;
			EState eState;
			if (itemCount == 0)
			{
				eState = EState.Empty;
				OnStateChange(eState);
			}
			else if (itemCount == value)
			{
				eState = EState.Full;
				OnStateChange(EState.Full);
			}
			else if (itemCount <= _countForNearlyEmpty)
			{
				eState = EState.NearlyEmptyStock;
				OnStateChange(EState.NearlyEmptyStock);
			}
			else if (itemCount <= _countForLowStock)
			{
				eState = EState.LowStock;
				OnStateChange(EState.LowStock);
			}
			else
			{
				eState = EState.Default;
			}
			_currentState = eState;
		}

		private void OnStateChange(EState state)
		{
			if (_currentState < state)
			{
				_ = _debugMode;
				switch (state)
				{
				case EState.Full:
					MonoSingleton<PushHandlers>.Instance.PushANotification("<sprite=\"Emoji_Notifications\" index=6>", PushColor.Danger, _fullAlertTitle.GetLocalizedString(), _fullAlertContent.GetLocalizedString(), null);
					break;
				case EState.LowStock:
					ShowFeedback(_feedbackForLowStock.GetLocalizedString());
					break;
				case EState.NearlyEmptyStock:
					ShowFeedback(_feedbackForNearlyEmpty.GetLocalizedString());
					break;
				case EState.Empty:
					ShowFeedback(_feedbackForEmpty.GetLocalizedString());
					MonoSingleton<PushHandlers>.Instance.PushANotification("<sprite=\"Emoji_Notifications\" index=0>", PushColor.Danger, _emptyAlertTitle.GetLocalizedString(), _emptyAlertContent.GetLocalizedString(), null, null);
					break;
				case EState.Default:
					break;
				}
			}
		}

		private void ShowFeedback(string text)
		{
			if (!(Time.time < _nextFeedback))
			{
				_nextFeedback = Time.time + _feedbackCooldown;
			}
		}
	}
}
