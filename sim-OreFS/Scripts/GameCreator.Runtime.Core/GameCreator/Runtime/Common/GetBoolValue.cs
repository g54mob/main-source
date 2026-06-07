using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Value")]
	[Category("Value")]
	[Image(typeof(IconToggleOn), ColorTheme.Type.Red)]
	[Description("Returns true if the checkbox is ticked. False otherwise")]
	[Keywords(new string[] { "Toggle", "Checkbox", "Enable", "Disable", "Active", "Inactive" })]
	[HideLabelsInEditor(true)]
	public class GetBoolValue : PropertyTypeGetBool
	{
		[SerializeField]
		protected bool m_Value = true;

		public override string String
		{
			get
			{
				if (!m_Value)
				{
					return "False";
				}
				return "True";
			}
		}

		public override bool EditorValue => m_Value;

		public override bool Get(Args args)
		{
			return m_Value;
		}

		public override bool Get(GameObject gameObject)
		{
			return m_Value;
		}

		public GetBoolValue()
		{
		}

		public GetBoolValue(bool value = true)
			: this()
		{
			m_Value = value;
		}

		public static PropertyGetBool Create(bool value)
		{
			return new PropertyGetBool(new GetBoolValue(value));
		}
	}
}
