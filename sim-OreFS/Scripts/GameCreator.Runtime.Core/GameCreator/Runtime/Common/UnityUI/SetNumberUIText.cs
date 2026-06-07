using System;
using System.Globalization;
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
	public class SetNumberUIText : PropertyTypeSetNumber
	{
		[SerializeField]
		private PropertyGetGameObject m_Text = GetGameObjectInstance.Create();

		public static PropertySetNumber Create => new PropertySetNumber(new SetNumberUIText());

		public override string String => m_Text.ToString();

		public override void Set(double value, Args args)
		{
			GameObject gameObject = m_Text.Get(args);
			if (gameObject == null)
			{
				return;
			}
			Text text = gameObject.Get<Text>();
			if (text != null)
			{
				text.text = value.ToString(CultureInfo.InvariantCulture);
				return;
			}
			TMP_Text tMP_Text = gameObject.Get<TMP_Text>();
			if (tMP_Text != null)
			{
				tMP_Text.text = value.ToString(CultureInfo.InvariantCulture);
			}
		}

		public override double Get(Args args)
		{
			GameObject gameObject = m_Text.Get(args);
			if (gameObject == null)
			{
				return 0.0;
			}
			Text text = gameObject.Get<Text>();
			if (text != null)
			{
				return Convert.ToSingle(text.text);
			}
			TMP_Text tMP_Text = gameObject.Get<TMP_Text>();
			return (tMP_Text != null) ? Convert.ToSingle(tMP_Text.text) : 0f;
		}
	}
}
