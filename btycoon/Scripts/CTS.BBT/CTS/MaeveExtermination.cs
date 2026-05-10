using System;
using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class MaeveExtermination : MonoSingleton<MaeveExtermination>
	{
		[SerializeField]
		private ExterminationPanel _prefab;

		[SerializeField]
		private Transform _content;

		[SerializeField]
		private ExterminationDataSO[] _datas;

		private List<ExterminationPanel> _panels = new List<ExterminationPanel>();

		public float DiscountMultiplier { get; private set; } = 1f;

		public static event Action DiscountChanged;

		protected override void SingletonAwake()
		{
			Populate();
		}

		protected override void OnSingletonDestroy()
		{
		}

		private void Populate()
		{
			for (int i = 0; i < _datas.Length; i++)
			{
				ExterminationPanel exterminationPanel = UnityEngine.Object.Instantiate(_prefab, _content);
				exterminationPanel.Init(_datas[i]);
				_panels.Add(exterminationPanel);
			}
		}

		public void SetDiscount(float discount)
		{
			if (discount != DiscountMultiplier)
			{
				DiscountMultiplier = discount;
				MaeveExtermination.DiscountChanged?.Invoke();
			}
		}

		public MaeveSaveData Save()
		{
			int[] array = new int[_panels.Count];
			int[] array2 = new int[_panels.Count];
			for (int i = 0; i < _panels.Count; i++)
			{
				array[i] = _panels[i].CurrentEffectUsedCount;
				array2[i] = _panels[i].CurrentDaysBeforeReuse;
			}
			return new MaeveSaveData
			{
				buyed = array,
				daysBeforeReuse = array2,
				maeveProtectionPastDay = MonoSingleton<VigilanceHandlers>.Instance.CurrentMaeveProtectionRestDays,
				discountMultiplier = DiscountMultiplier
			};
		}

		public void Load(MaeveSaveData data)
		{
			if (data.daysBeforeReuse.Length == _panels.Count && data.buyed.Length == _panels.Count)
			{
				DiscountMultiplier = data.discountMultiplier;
				for (int i = 0; i < _panels.Count; i++)
				{
					_panels[i].SetSaveData(data.buyed[i], data.daysBeforeReuse[i], data.maeveProtectionPastDay);
				}
			}
		}
	}
}
