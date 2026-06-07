using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Runtime.Common.UnityUI
{
	[Serializable]
	[Title("Input Field")]
	[Category("UI/Input Field")]
	[Description("Sets the Input Field text value")]
	[Image(typeof(IconUIInputField), ColorTheme.Type.TextLight)]
	[HideLabelsInEditor(true)]
	public class SetStringUIInputField : PropertyTypeSetString
	{
		[SerializeField]
		private PropertyGetGameObject m_InputField = GetGameObjectInstance.Create();

		public static PropertySetString Create => new PropertySetString(new SetStringUIInputField());

		public override string String => m_InputField.ToString();

		public override void Set(string value, Args args)
		{
			GameObject gameObject = m_InputField.Get(args);
			if (gameObject == null)
			{
				return;
			}
			InputField inputField = gameObject.Get<InputField>();
			if (inputField != null)
			{
				inputField.text = value;
				return;
			}
			TMP_InputField tMP_InputField = gameObject.Get<TMP_InputField>();
			if (tMP_InputField != null)
			{
				tMP_InputField.text = value;
			}
		}

		public override string Get(Args args)
		{
			GameObject gameObject = m_InputField.Get(args);
			if (gameObject == null)
			{
				return null;
			}
			string result = string.Empty;
			InputField inputField = gameObject.Get<InputField>();
			if (inputField != null)
			{
				result = inputField.text;
			}
			TMP_InputField tMP_InputField = gameObject.Get<TMP_InputField>();
			if (tMP_InputField != null)
			{
				result = tMP_InputField.text;
			}
			return result;
		}
	}
}
