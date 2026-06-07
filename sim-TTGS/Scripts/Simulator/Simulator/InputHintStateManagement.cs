using System;
using System.Collections.Generic;
using UnityEngine;

namespace Simulator
{
	public class InputHintStateManagement<T> : InputHint where T : Enum
	{
		[SerializeField]
		private EnumValues<T, int> m_inputHintIndex;

		[SerializeField]
		private T m_flags;

		public override Data[] GetDatas()
		{
			List<T> valuesFromBitField = m_flags.GetValuesFromBitField();
			Data[] array = new Data[valuesFromBitField.Count];
			for (int i = 0; i < array.Length; i++)
			{
				int index = m_inputHintIndex[valuesFromBitField[i]];
				array[i] = base.Datas[index];
			}
			return array;
		}

		public void AddFlags(T flags)
		{
			m_flags = (T)Enum.ToObject(typeof(T), Convert.ToInt32(flags) | Convert.ToInt32(m_flags));
		}

		public void AddFlagsAndRefreshInputHint(T flags)
		{
			AddFlags(flags);
			Refresh();
		}

		public void RemoveFlags(T flags)
		{
			m_flags = (T)Enum.ToObject(typeof(T), Convert.ToInt32(m_flags) & ~Convert.ToInt32(flags));
		}

		public void RemoveFlagsAndRefreshInputHint(T flags)
		{
			RemoveFlags(flags);
			Refresh();
		}

		public bool HasFlags()
		{
			return Convert.ToInt32(m_flags) != 0;
		}
	}
}
