using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Runtime.Common.UnityUI
{
	[Serializable]
	[Title("Text")]
	[Category("UI/Text")]
	[Description("Sets the Text or TextMeshPro Text value")]
	[Image(typeof(IconUIText), ColorTheme.Type.TextLight)]
	[HideLabelsInEditor(true)]
	public class SetStringUIText : PropertyTypeSetString
	{
		[SerializeField]
		private PropertyGetGameObject m_Text = GetGameObjectInstance.Create();

		public static PropertySetString Create => new PropertySetString(new SetStringUIText());

		public override string String => m_Text.ToString();

		public override void Set(string value, Args args)
		{
			GameObject gameObject = m_Text.Get(args);
			if (gameObject == null)
			{
				return;
			}
			Text text = gameObject.Get<Text>();
			if (text != null)
			{
				text.text = value;
				return;
			}
			TMP_Text tMP_Text = gameObject.Get<TMP_Text>();
			if (tMP_Text != null)
			{
				tMP_Text.text = value;
			}
		}

		public override string Get(Args args)
		{
			GameObject gameObject = m_Text.Get(args);
			if (gameObject == null)
			{
				return null;
			}
			Text text = gameObject.Get<Text>();
			if (text != null)
			{
				return text.text;
			}
			TMP_Text tMP_Text = gameObject.Get<TMP_Text>();
			if (!(tMP_Text != null))
			{
				return string.Empty;
			}
			return tMP_Text.text;
		}
	}
}
