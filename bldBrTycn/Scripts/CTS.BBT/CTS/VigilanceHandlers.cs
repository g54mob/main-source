using System;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Utilities;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class VigilanceHandlers : MonoSingleton<VigilanceHandlers>, ILockable
	{
		private static Addressable<PrestigeUIStatsSO> _dailyDecreaeseStat = new Addressable<PrestigeUIStatsSO>("Assets/Scriptables/Prestige/StatPrestige/Stats/TimeReduction.asset");

		public static LevelSettingsVigilanceData Data { get; set; }

		public LevelSettingsVigilanceData VigilanceData => Data;

		public int CurrentVigilance { get; private set; }

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		public static int MinVigilance => 0;

		public static int MaxVigilance => Data.VigilanceForRaid;

		public int CurrentMaeveProtectionRestDays { get; private set; }

		public float ProtectionEffect { get; private set; }

		public static event Action<int> VigilanceChanged;

		public static event Action<int> OnMaeveProtectionChanged;

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
			CurrentVigilance = 0;
		}

		private void OnEnable()
		{
			CalendarHandlers.NewDay += DailyDecrease;
			SaveManager.OnLoadingFinished += GameData_OnLoadingFinished;
		}

		private void OnDisable()
		{
			CalendarHandlers.NewDay -= DailyDecrease;
			SaveManager.OnLoadingFinished -= GameData_OnLoadingFinished;
		}

		private int GetValueFromProtection(int value)
		{
			if (value < 0)
			{
				return value;
			}
			return Mathf.FloorToInt((float)value - (float)value * ProtectionEffect);
		}

		private void DailyDecrease()
		{
			if (CurrentMaeveProtectionRestDays > 0)
			{
				CurrentMaeveProtectionRestDays--;
			}
			if (CurrentMaeveProtectionRestDays == 0)
			{
				ProtectionEffect = 0f;
			}
			VigilanceHandlers.OnMaeveProtectionChanged?.Invoke(CurrentMaeveProtectionRestDays);
			if (CurrentVigilance > 0)
			{
				_dailyDecreaeseStat.Value.AddToCurrentValue(Data.ValueToDecreasePerDay);
				ChangeVigilanceBy(Data.ValueToDecreasePerDay);
			}
		}

		private void GameData_OnLoadingFinished()
		{
			VigilanceHandlers.VigilanceChanged?.Invoke(Mathf.RoundToInt(CurrentVigilance));
		}

		public void SetMaeveProtectionDaysCount(int days, float effect, bool fromSave)
		{
			ProtectionEffect = effect;
			if (fromSave)
			{
				CurrentMaeveProtectionRestDays = days;
			}
			else
			{
				CurrentMaeveProtectionRestDays += days;
				SetVigilanceTo(0);
			}
			VigilanceHandlers.OnMaeveProtectionChanged?.Invoke(CurrentMaeveProtectionRestDays);
		}

		public void ChangeVigilanceBy(int value)
		{
			SetVigilanceTo(CurrentVigilance + GetValueFromProtection(value));
		}

		public void ChangeVigilanceBy(int value, Agent agent, EBone bone, Vector3 localOffset = default(Vector3))
		{
			SetVigilanceTo(CurrentVigilance + GetValueFromProtection(value));
			CTSSingleton<VigilanceEmotes>.Instance.Play(agent, bone, value, localOffset);
		}

		public void ChangeVigilanceBy(int value, Vector3 position)
		{
			SetVigilanceTo(CurrentVigilance + GetValueFromProtection(value));
			CTSSingleton<VigilanceEmotes>.Instance.Play(position, value);
		}

		public void SetVigilanceTo(int value)
		{
			if (!ObjectLock.IsLocked())
			{
				value = Math.Clamp(value, 0, this.GetMaxVigilanceWithDifficulty());
				if (CurrentVigilance != value)
				{
					CurrentVigilance = value;
					VigilanceHandlers.VigilanceChanged?.Invoke(CurrentVigilance);
				}
			}
		}

		void ILockable.OnLocked()
		{
		}

		void ILockable.OnUnlocked()
		{
		}

		[Button(null, EButtonEnableMode.Always)]
		private void DebugIncreaseVigilance()
		{
			ChangeVigilanceBy(99);
		}
	}
}
