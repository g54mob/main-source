using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Runtime.Common.UnityUI
{
	[Serializable]
	[Title("Dropdown")]
	[Category("UI/Dropdown")]
	[Description("Sets the Dropdown or TextMeshPro Dropdown text value")]
	[Image(typeof(IconUIDropdown), ColorTheme.Type.TextLight)]
	[HideLabelsInEditor(true)]
	public class SetStringUIDropdown : PropertyTypeSetString
	{
		[SerializeField]
		private PropertyGetGameObject m_Dropdown = GetGameObjectInstance.Create();

		public static PropertySetString Create => new PropertySetString(new SetStringUIDropdown());

		public override string String => m_Dropdown.ToString();

		public override void Set(string value, Args args)
		{
			GameObject gameObject = m_Dropdown.Get(args);
			if (gameObject == null)
			{
				return;
			}
			Dropdown dropdown = gameObject.Get<Dropdown>();
			if (dropdown != null)
			{
				Dropdown.OptionData item = new Dropdown.OptionData(value);
				int num = dropdown.options.IndexOf(item);
				if (num >= 0)
				{
					dropdown.value = num;
				}
				return;
			}
			TMP_Dropdown tMP_Dropdown = gameObject.Get<TMP_Dropdown>();
			if (tMP_Dropdown != null)
			{
				TMP_Dropdown.OptionData item2 = new TMP_Dropdown.OptionData(value);
				int num2 = tMP_Dropdown.options.IndexOf(item2);
				if (num2 >= 0)
				{
					tMP_Dropdown.value = num2;
				}
			}
		}

		public override string Get(Args args)
		{
			GameObject gameObject = m_Dropdown.Get(args);
			if (gameObject == null)
			{
				return null;
			}
			Dropdown dropdown = gameObject.Get<Dropdown>();
			if (dropdown != null)
			{
				return dropdown.options[dropdown.value].text;
			}
			TMP_Dropdown tMP_Dropdown = gameObject.Get<TMP_Dropdown>();
			if (!(tMP_Dropdown != null))
			{
				return string.Empty;
			}
			return tMP_Dropdown.options[dropdown.value].text;
		}
	}
}
