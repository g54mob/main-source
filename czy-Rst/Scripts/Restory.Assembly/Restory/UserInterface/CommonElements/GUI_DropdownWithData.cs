using UnityEngine;
using UnityEngine.UI;

namespace Restory.UserInterface.CommonElements
{
	public class GUI_DropdownWithData : GUI_Dropdown
	{
		public new class OptionData<T> : OptionData
		{
			public T Data { get; set; }

			public OptionData()
			{
			}

			public OptionData(T data, string text)
				: base(text)
			{
				Data = data;
			}

			public OptionData(T value, Sprite image)
				: base(image)
			{
				Data = value;
			}

			public OptionData(T value, string text, Sprite image)
				: base(text, image)
			{
				Data = value;
			}
		}

		public T GetData<T>(T defaultData)
		{
			if (base.options.Count <= base.value || !(base.options[base.value] is OptionData<T> optionData))
			{
				return defaultData;
			}
			return optionData.Data;
		}

		public T GetData<T>()
		{
			if (base.options.Count <= base.value || !(base.options[base.value] is OptionData<T> optionData))
			{
				return default(T);
			}
			return optionData.Data;
		}

		public void SetValueWithoutNotifyByData<T>(T parData)
		{
			for (int i = 0; i < base.options.Count; i++)
			{
				if (base.options[i] is OptionData<T> optionData && object.Equals(optionData.Data, parData))
				{
					SetValueWithoutNotify(i);
					return;
				}
			}
			SetValueWithoutNotify(-1);
		}

		public void SetValueWithoutNotifyByText(string parText)
		{
			for (int i = 0; i < base.options.Count; i++)
			{
				if (base.options[i].text == parText)
				{
					SetValueWithoutNotify(i);
					return;
				}
			}
			SetValueWithoutNotify(-1);
		}
	}
}
