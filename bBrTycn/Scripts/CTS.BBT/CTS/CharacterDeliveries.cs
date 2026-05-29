using System;
using System.Collections.Generic;
using CTS.BBT.Handlers.Transactions;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace CTS
{
	[Constructor("Construct")]
	public class CharacterDeliveries : CTSSingleton<CharacterDeliveries>
	{
		[Serializable]
		private struct CharacterMessage
		{
			public Sprite SuccessImage;

			public Sprite FailureImage;

			public LocalizedString SuccessDescription;

			public LocalizedString FailureDescription;
		}

		private class CharacterMessageData : IUIMessage
		{
			public Sprite Icon { get; set; }

			public LocalizedString Title { get; set; }

			public LocalizedString Subtitle { get; set; }

			public LocalizedString Description { get; set; }

			public UnityEvent EndEvent { get; set; } = new UnityEvent();

			public StringKey VisualKey { get; set; }

			public Sprite GetSprite()
			{
				return Icon;
			}

			public LocalizedString GetTitle()
			{
				return Title;
			}

			public LocalizedString GetSubtitle()
			{
				return Subtitle;
			}

			public LocalizedString GetDescription()
			{
				return Description;
			}

			public bool ShouldUseSpecificVisual()
			{
				return true;
			}

			public StringKey GetSpecificVisualKey()
			{
				return VisualKey;
			}

			public UnityEvent GetEndEvent()
			{
				return EndEvent;
			}
		}

		private const string GROUP_MESSAGE = "Message Data";

		private const string GROUP_DEBUG = "Debug";

		[SerializeField]
		private float _baseSuccessMultiplier = 5f;

		[SerializeField]
		private float _baseFailureMultiplier = 0.5f;

		[SerializeField]
		[BoxGroup("Message Data")]
		private LocalizedString _titleSuccessText;

		[SerializeField]
		[BoxGroup("Message Data")]
		private LocalizedString _titleFailureText;

		[SerializeField]
		[BoxGroup("Message Data")]
		private LocalizedString _subtitleSuccessText;

		[SerializeField]
		[BoxGroup("Message Data")]
		private LocalizedString _subtitleFailureText;

		[SerializeField]
		[BoxGroup("Message Data")]
		private StringKey _messageVisual;

		[SerializeField]
		[BoxGroup("Message Data")]
		private SerializableDictionary<MainCharacterData, CharacterMessage> _characterSpecifics = new SerializableDictionary<MainCharacterData, CharacterMessage>();

		private readonly Dictionary<StringKey<MainCharacterData>, CharacterMessage> _characterMessageData = new Dictionary<StringKey<MainCharacterData>, CharacterMessage>();

		private float _successMultiplier = 1f;

		private float _failureMultiplier = 1f;

		private CharacterMessageData _successCharacterMessage;

		private CharacterMessageData _failureCharacterMessage;

		private readonly IntVariable _messageIntVariable = new IntVariable();

		private readonly Dictionary<MissionBasket, StringKey<MainCharacterData>> _currentMissions = new Dictionary<MissionBasket, StringKey<MainCharacterData>>();

		[SerializeField]
		[BoxGroup("Debug")]
		private StockMissionData _debugMissionData;

		[SerializeField]
		[BoxGroup("Debug")]
		private StringKey<MainCharacterData> _debugCharacter;

		private void Construct()
		{
			SetSuccessMultiplier(null);
			SetFailureMultiplier(null);
			foreach (var (mainCharacterData2, value) in _characterSpecifics)
			{
				_characterMessageData[mainCharacterData2] = value;
			}
			_successCharacterMessage = new CharacterMessageData
			{
				Title = _titleSuccessText,
				Subtitle = _subtitleSuccessText,
				VisualKey = _messageVisual
			};
			_failureCharacterMessage = new CharacterMessageData
			{
				Title = _titleFailureText,
				Subtitle = _subtitleFailureText,
				VisualKey = _messageVisual
			};
		}

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
			MissionBasket.MissionEnded -= OnMissionEnded;
		}

		public void SetSuccessMultiplier(float? newMultiplier)
		{
			_successMultiplier = newMultiplier ?? _baseSuccessMultiplier;
		}

		public void SetFailureMultiplier(float? newMultiplier)
		{
			_failureMultiplier = newMultiplier ?? _baseFailureMultiplier;
		}

		public void SetCurrentMission(Dictionary<MissionBasket, StringKey<MainCharacterData>> missionToAssign)
		{
			if (missionToAssign.Count == 0)
			{
				return;
			}
			_currentMissions.Clear();
			foreach (KeyValuePair<MissionBasket, StringKey<MainCharacterData>> item in missionToAssign)
			{
				_currentMissions.Add(item.Key, item.Value);
			}
			MissionBasket.MissionEnded -= OnMissionEnded;
			MissionBasket.MissionEnded += OnMissionEnded;
		}

		public void StartDelivery(MissionBasket basket, StringKey<MainCharacterData> character, StockMissionData missionData)
		{
			if (!_characterMessageData.ContainsKey(character))
			{
				Debug.LogException(new NullReferenceException($"Cannot create delivery mission for {character}"));
				return;
			}
			basket.EndCurrentMission();
			MissionBasket.MissionEnded -= OnMissionEnded;
			MissionBasket.MissionEnded += OnMissionEnded;
			_currentMissions[basket] = character;
			basket.SetMission(missionData);
		}

		public void CancelDelivery(MissionBasket basket)
		{
			if (_currentMissions.ContainsKey(basket))
			{
				MissionBasket.MissionEnded -= OnMissionEnded;
				basket.EndCurrentMission();
				_currentMissions.Remove(basket);
			}
		}

		private void OnMissionEnded(MissionBasket basket, MissionBasket.MissionResult result)
		{
			if (base.gameObject.scene.isLoaded && _currentMissions.Remove(basket, out var value))
			{
				if (_currentMissions.Count <= 0)
				{
					MissionBasket.MissionEnded -= OnMissionEnded;
				}
				int num = 0;
				ReadOnlySpan<MissionBasket.MissionItemCapacity> span = result.SentStock.Span;
				for (int i = 0; i < span.Length; i++)
				{
					MissionBasket.MissionItemCapacity missionItemCapacity = span[i];
					num += Mathf.FloorToInt((float)missionItemCapacity.ItemStack.GetBasePrice() * missionItemCapacity.ItemStack.ItemData.SellPriceMultiplier);
				}
				CTSSingleton<UIMessage>.Instance.ShowMessage(GetMessageData(value, result.Result == MissionBasket.EMissionResult.Full, num));
			}
		}

		private CharacterMessageData GetMessageData(StringKey<MainCharacterData> character, bool success, int price)
		{
			CharacterMessage characterMessage = _characterMessageData[character];
			CharacterMessageData characterMessageData;
			if (success)
			{
				characterMessageData = _successCharacterMessage;
				characterMessageData.Icon = characterMessage.SuccessImage;
				characterMessageData.Description = characterMessage.SuccessDescription;
				price = Mathf.FloorToInt((float)price * _successMultiplier);
			}
			else
			{
				characterMessageData = _failureCharacterMessage;
				characterMessageData.Icon = characterMessage.FailureImage;
				characterMessageData.Description = characterMessage.FailureDescription;
				price = Mathf.FloorToInt((float)price * _failureMultiplier);
			}
			_messageIntVariable.Value = price;
			characterMessageData.Subtitle["dollar-amount"] = _messageIntVariable;
			characterMessageData.EndEvent.RemoveAllListeners();
			characterMessageData.EndEvent.AddListener(delegate
			{
				GiveMoney(price);
			});
			return characterMessageData;
		}

		private static void GiveMoney(int money)
		{
			MonoSingleton<MoneyHandler>.Instance.SetCurrentMoney(MonoSingleton<MoneyHandler>.Instance.CurrentMoney + money);
			MonoSingleton<TransactionsHandlers>.Instance.AddNewData(TransactionType.Income, money, TransactionTag.Mission);
		}

		[Button(null, EButtonEnableMode.Playmode)]
		private void PlayDebugMission()
		{
			StartDelivery(CTSSingleton<StoreBaskets>.Instance.SecondaryMissionBasket, _debugCharacter, _debugMissionData);
		}
	}
}
