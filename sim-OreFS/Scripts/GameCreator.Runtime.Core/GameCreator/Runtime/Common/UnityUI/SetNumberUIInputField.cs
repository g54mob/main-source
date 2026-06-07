using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Runtime.Common.UnityUI
{
	[Serializable]
	[Title("Input Field")]
	[Category("UI/Input Field")]
	[Description("Sets the Input Field value")]
	[Image(typeof(IconUIInputField), ColorTheme.Type.TextLight)]
	[HideLabelsInEditor(true)]
	public class SetNumberUIInputField : PropertyTypeSetNumber
	{
		[SerializeField]
		private PropertyGetGameObject m_InputField = GetGameObjectInstance.Create();

		public static PropertySetNumber Create => new PropertySetNumber(new SetNumberUIInputField());

		public override string String => m_InputField.ToString();

		public override void Set(double value, Args args)
		{
			GameObject gameObject = m_InputField.Get(args);
			if (!(gameObject == null))
			{
				InputField inputField = gameObject.Get<InputField>();
				if (!(inputField == null))
				{
					inputField.text = value.ToString(CultureInfo.InvariantCulture);
				}
			}
		}

		public override double Get(Args args)
		{
			GameObject gameObject = m_InputField.Get(args);
			if (gameObject == null)
			{
				return 0.0;
			}
			InputField inputField = gameObject.Get<InputField>();
			return (inputField != null) ? Convert.ToSingle(inputField.text, CultureInfo.InvariantCulture) : 0f;
		}
	}
}
