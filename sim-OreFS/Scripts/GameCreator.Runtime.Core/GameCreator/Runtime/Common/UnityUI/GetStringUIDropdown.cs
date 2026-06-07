using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Runtime.Common.UnityUI
{
	[Serializable]
	[Title("Dropdown")]
	[Category("UI/Dropdown")]
	[Description("Gets the Dropdown or TextMeshPro Dropdown text value")]
	[Image(typeof(IconUIDropdown), ColorTheme.Type.TextLight)]
	[HideLabelsInEditor(true)]
	public class GetStringUIDropdown : PropertyTypeGetString
	{
		[SerializeField]
		private PropertyGetGameObject m_Dropdown = GetGameObjectInstance.Create();

		public static PropertyGetString Create => new PropertyGetString(new GetStringUIDropdown());

		public override string String => m_Dropdown.ToString();

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
