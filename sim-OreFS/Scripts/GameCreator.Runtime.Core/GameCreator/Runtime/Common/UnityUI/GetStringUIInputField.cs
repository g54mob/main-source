using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Runtime.Common.UnityUI
{
	[Serializable]
	[Title("Input Field")]
	[Category("UI/Input Field")]
	[Description("Gets the Input Field text value")]
	[Image(typeof(IconUIInputField), ColorTheme.Type.TextLight)]
	[HideLabelsInEditor(true)]
	public class GetStringUIInputField : PropertyTypeGetString
	{
		[SerializeField]
		private PropertyGetGameObject m_InputField = GetGameObjectInstance.Create();

		public static PropertyGetString Create => new PropertyGetString(new GetStringUIInputField());

		public override string String => m_InputField.ToString();

		public override string Get(Args args)
		{
			GameObject gameObject = m_InputField.Get(args);
			if (gameObject == null)
			{
				return null;
			}
			InputField inputField = gameObject.Get<InputField>();
			if (inputField != null)
			{
				return inputField.text;
			}
			TMP_InputField tMP_InputField = gameObject.Get<TMP_InputField>();
			if (!(tMP_InputField != null))
			{
				return string.Empty;
			}
			return tMP_InputField.text;
		}
	}
}
