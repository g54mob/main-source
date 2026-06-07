using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Runtime.Common.UnityUI
{
	[Serializable]
	[Title("Button")]
	[Category("UI/Button")]
	[Description("Gets the Button's Text or TextMeshPro Text value")]
	[Image(typeof(IconUIButton), ColorTheme.Type.TextLight)]
	[HideLabelsInEditor(true)]
	public class GetDecimalUIButton : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetGameObject m_Button = GetGameObjectInstance.Create();

		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalUIButton());

		public override string String => m_Button.ToString();

		public override double Get(Args args)
		{
			GameObject gameObject = m_Button.Get(args);
			if (gameObject == null)
			{
				return 0.0;
			}
			Button button = gameObject.Get<Button>();
			if (button == null)
			{
				return 0.0;
			}
			Text componentInChildren = button.GetComponentInChildren<Text>();
			if (componentInChildren != null)
			{
				return Convert.ToSingle(componentInChildren.text);
			}
			TMP_Text componentInChildren2 = button.GetComponentInChildren<TMP_Text>();
			return (componentInChildren2 != null) ? Convert.ToSingle(componentInChildren2.text) : 0f;
		}
	}
}
