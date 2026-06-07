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
	public class GetStringUIButton : PropertyTypeGetString
	{
		[SerializeField]
		private PropertyGetGameObject m_Button = GetGameObjectInstance.Create();

		public static PropertyGetString Create => new PropertyGetString(new GetStringUIButton());

		public override string String => m_Button.ToString();

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
