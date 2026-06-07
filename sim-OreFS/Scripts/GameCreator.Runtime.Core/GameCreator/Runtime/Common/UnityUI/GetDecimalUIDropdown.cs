using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Runtime.Common.UnityUI
{
	[Serializable]
	[Title("Dropdown")]
	[Category("UI/Dropdown")]
	[Description("Gets the Dropdown or TextMeshPro Dropdown selected index option")]
	[Image(typeof(IconUIDropdown), ColorTheme.Type.TextLight)]
	[HideLabelsInEditor(true)]
	public class GetDecimalUIDropdown : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetGameObject m_Dropdown = GetGameObjectInstance.Create();

		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalUIDropdown());

		public override string String => m_Dropdown.ToString();

		public override double Get(Args args)
		{
			GameObject gameObject = m_Dropdown.Get(args);
			if (gameObject == null)
			{
				return 0.0;
			}
			Dropdown dropdown = gameObject.Get<Dropdown>();
			if (dropdown != null)
			{
				return dropdown.value;
			}
			TMP_Dropdown tMP_Dropdown = dropdown.Get<TMP_Dropdown>();
			return (tMP_Dropdown != null) ? ((float)tMP_Dropdown.value) : 0f;
		}
	}
}
