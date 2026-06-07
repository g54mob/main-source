using System;
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
	public class SetStringUIButton : PropertyTypeSetString
	{
		[SerializeField]
		private PropertyGetGameObject m_Button = GetGameObjectInstance.Create();

		public static PropertySetString Create => new PropertySetString(new SetStringUIButton());

		public override string String => m_Button.ToString();

		public override void Set(string value, Args args)
		{
			GameObject gameObject = m_Button.Get(args);
			if (gameObject == null || gameObject.Get<Button>() == null)
			{
				return;
			}
			Text componentInChildren = gameObject.GetComponentInChildren<Text>();
			if (componentInChildren != null)
			{
				componentInChildren.text = value;
				return;
			}
			TMP_Text componentInChildren2 = gameObject.GetComponentInChildren<TMP_Text>();
			if (componentInChildren2 != null)
			{
				componentInChildren2.text = value;
			}
		}

		public override string Get(Args args)
		{
			GameObject gameObject = m_Button.Get(args);
			if (gameObject == null)
			{
				return null;
			}
			Button button = gameObject.Get<Button>();
			if (button == null)
			{
				return null;
			}
			Text componentInChildren = button.GetComponentInChildren<Text>();
			if (componentInChildren != null)
			{
				return componentInChildren.text;
			}
			TMP_Text componentInChildren2 = button.GetComponentInChildren<TMP_Text>();
			if (!(componentInChildren2 != null))
			{
				return string.Empty;
			}
			return componentInChildren2.text;
		}
	}
}
