using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Runtime.Common.UnityUI
{
	[Serializable]
	[Title("Button")]
	[Category("UI/Button")]
	[Description("Sets the Button's Text or TextMeshPro Text value")]
	[Image(typeof(IconUIButton), ColorTheme.Type.TextLight)]
	[HideLabelsInEditor(true)]
	public class SetNumberUIButton : PropertyTypeSetNumber
	{
		[SerializeField]
		private PropertyGetGameObject m_Button = GetGameObjectInstance.Create();

		public static PropertySetNumber Create => new PropertySetNumber(new SetNumberUIButton());

		public override string String => m_Button.ToString();

		public override void Set(double value, Args args)
		{
			GameObject gameObject = m_Button.Get(args);
			if (gameObject == null || gameObject.Get<Button>() == null)
			{
				return;
			}
			Text componentInChildren = gameObject.GetComponentInChildren<Text>();
			if (componentInChildren != null)
			{
				componentInChildren.text = value.ToString(CultureInfo.InvariantCulture);
				return;
			}
			TMP_Text componentInChildren2 = gameObject.GetComponentInChildren<TMP_Text>();
			if (componentInChildren2 != null)
			{
				componentInChildren2.text = value.ToString(CultureInfo.InvariantCulture);
			}
		}

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
