using System;
using System.Collections.Generic;
using System.Linq;
using Dhs5.Utility.Settings;
using TMPro;
using UnityEngine;

namespace Simulator.CustomSettings
{
	[Serializable]
	public class UI_DropdownPlayerPrefEnumOptions<T> : UI_BasePlayerPrefMemberOptions<PlayerPrefEnum<T>> where T : struct, Enum
	{
		[SerializeField]
		private TabletopDropdown m_dropdown;

		private Dictionary<int, int> m_indexToEnumObject;

		private bool EnumHasCustomValues => m_indexToEnumObject != null;

		public event Action<T> OnValueChanged
		{
			add
			{
				playerPrefMember.OnValueChanged += value;
			}
			remove
			{
				playerPrefMember.OnValueChanged -= value;
			}
		}

		public override void Awake()
		{
			FillDropdown();
			EnumCustomValuesMapping();
		}

		public override void OnEnable()
		{
			SelectCurrentValue();
			m_dropdown.onValueChanged.AddListener(On_dropdownValueChange_SetValue);
		}

		public override void OnDisable()
		{
			m_dropdown.onValueChanged.RemoveListener(On_dropdownValueChange_SetValue);
		}

		public override void SelectCurrentValue()
		{
			int valueWithoutNotify = m_dropdown.options.FindIndex((TMP_Dropdown.OptionData x) => x.text == playerPrefMember.Value.ToString());
			m_dropdown.SetValueWithoutNotify(valueWithoutNotify);
		}

		private void EnumCustomValuesMapping()
		{
			Array values = Enum.GetValues(typeof(T));
			m_indexToEnumObject = new Dictionary<int, int>(values.Length);
			int num = 0;
			bool flag = false;
			foreach (object item in values)
			{
				if ((int)item != num)
				{
					flag = true;
				}
				m_indexToEnumObject[num] = (int)item;
				num++;
			}
			if (!flag)
			{
				m_indexToEnumObject = null;
			}
		}

		private void FillDropdown()
		{
			m_dropdown.ClearOptions();
			m_dropdown.AddOptions(Enum.GetNames(typeof(T)).ToList());
		}

		private void On_dropdownValueChange_SetValue(int index)
		{
			int value = (EnumHasCustomValues ? m_indexToEnumObject[index] : index);
			T value2 = (T)Enum.ToObject(typeof(T), value);
			playerPrefMember.Value = value2;
		}
	}
}
