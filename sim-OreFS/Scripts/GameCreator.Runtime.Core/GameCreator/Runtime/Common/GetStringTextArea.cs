using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Text Area")]
	[Category("Constants/Text Area")]
	[Image(typeof(IconTextArea), ColorTheme.Type.Yellow)]
	[Description("A string of characters which includes line breaks")]
	[Keywords(new string[] { "String", "Value" })]
	[HideLabelsInEditor(true)]
	public class GetStringTextArea : PropertyTypeGetString
	{
		[SerializeField]
		protected TextAreaField m_Text = new TextAreaField();

		public override string String
		{
			get
			{
				string text = m_Text.Text.Replace('\n', ' ');
				if (!string.IsNullOrEmpty(text))
				{
					return text;
				}
				return "<empty>";
			}
		}

		public override string EditorValue => m_Text.Text.Replace('\n', ' ');

		public override string Get(Args args)
		{
			return m_Text.Text;
		}

		public override string Get(GameObject gameObject)
		{
			return m_Text.Text;
		}

		public GetStringTextArea()
		{
		}

		public GetStringTextArea(string text = "")
			: this()
		{
			m_Text = new TextAreaField(text);
		}

		public static PropertyGetString Create(string content = "")
		{
			return new PropertyGetString(new GetStringTextArea(content));
		}
	}
}
