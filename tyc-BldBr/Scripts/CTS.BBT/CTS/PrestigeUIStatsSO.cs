using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	[CreateAssetMenu(fileName = "PrestigeUIStatsSO", menuName = "PrestigeUI/PrestigeUIStatsSO")]
	public class PrestigeUIStatsSO : ScriptableObject
	{
		[SerializeField]
		private bool _needSucces;

		[SerializeField]
		[ShowIf("_needSucces")]
		private string _keyToAddTheSucces;

		[SerializeField]
		[ShowIf("_needSucces")]
		private bool _isLevelSucces;

		[SerializeField]
		[ShowIf("_isLevelSucces")]
		private int _howMuchKillNeed;

		[field: SerializeField]
		public LocalizedString Name { get; private set; }

		public List<int> LastMounthValues { get; private set; } = new List<int>();

		public int PreviousMounthValue
		{
			get
			{
				if (LastMounthValues.Count != 0)
				{
					return LastMounthValues[LastMounthValues.Count - 1];
				}
				return 0;
			}
		}

		[field: ShowNonSerializedField]
		public int CurrentValue { get; private set; }

		public event Action<int> OnCurrentValueChanged;

		public event Action<int> OnLastMounthValueChanged;

		public void AddToCurrentValue(int value)
		{
			CurrentValue += value;
			this.OnCurrentValueChanged?.Invoke(CurrentValue);
			if (_needSucces)
			{
				AchievementManager.AddToStats(_keyToAddTheSucces, value);
			}
			if (_isLevelSucces && CurrentValue == _howMuchKillNeed)
			{
				AchievementManager.UnlockAchievement(_keyToAddTheSucces);
			}
		}

		public void SetCurrentValue(int value)
		{
			CurrentValue = value;
			this.OnCurrentValueChanged?.Invoke(CurrentValue);
		}

		public void SetLastMounthValues(int[] values)
		{
			LastMounthValues = new List<int>(values);
			this.OnLastMounthValueChanged?.Invoke(PreviousMounthValue);
		}

		public void SendCurrentValueToLastMounth()
		{
			LastMounthValues.Add(CurrentValue);
			this.OnLastMounthValueChanged?.Invoke(PreviousMounthValue);
			SetCurrentValue(0);
		}
	}
}
