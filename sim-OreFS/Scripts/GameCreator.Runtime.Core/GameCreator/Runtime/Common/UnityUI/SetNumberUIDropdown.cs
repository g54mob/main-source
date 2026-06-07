using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Runtime.Common.UnityUI
{
	[Serializable]
	[Title("Dropdown")]
	[Category("UI/Dropdown")]
	[Description("Sets the Dropdown or TextMeshPro Dropdown selected index option")]
	[Image(typeof(IconUIDropdown), ColorTheme.Type.TextLight)]
	[HideLabelsInEditor(true)]
	public class SetNumberUIDropdown : PropertyTypeSetNumber
	{
		[SerializeField]
		private PropertyGetGameObject m_Dropdown = GetGameObjectInstance.Create();

		public static PropertySetNumber Create => new PropertySetNumber(new SetNumberUIDropdown());

		public override string String => m_Dropdown.ToString();

		public override void Set(double value, Args args)
		{
			GameObject gameObject = m_Dropdown.Get(args);
			if (gameObject == null)
			{
				return;
			}
			Dropdown dropdown = gameObject.Get<Dropdown>();
			if (dropdown != null)
			{
				dropdown.value = (int)Math.Floor(value);
				return;
			}
			TMP_Dropdown tMP_Dropdown = gameObject.Get<TMP_Dropdown>();
			if (tMP_Dropdown != null)
			{
				tMP_Dropdown.value = (int)Math.Floor(value);
			}
		}

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
			TMP_Dropdown tMP_Dropdown = gameObject.Get<TMP_Dropdown>();
			return (tMP_Dropdown != null) ? ((float)tMP_Dropdown.value) : 0f;
		}
	}
}
