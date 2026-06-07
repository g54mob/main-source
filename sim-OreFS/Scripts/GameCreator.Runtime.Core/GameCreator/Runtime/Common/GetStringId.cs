using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("String ID")]
	[Category("Constants/String ID")]
	[Image(typeof(IconID), ColorTheme.Type.Yellow)]
	[Description("Returns an alphanumeric string without any spaces")]
	[HideLabelsInEditor(true)]
	public class GetStringId : PropertyTypeGetString
	{
		[SerializeField]
		private IdString m_Id;

		public override string String
		{
			get
			{
				if (!string.IsNullOrEmpty(m_Id.String))
				{
					return m_Id.String;
				}
				return "<empty>";
			}
		}

		public override string EditorValue => m_Id.String;

		public override string Get(Args args)
		{
			return m_Id.String;
		}

		public override string Get(GameObject gameObject)
		{
			return m_Id.String;
		}

		public GetStringId()
		{
		}

		public GetStringId(string name)
		{
			m_Id = new IdString(name);
		}

		public static PropertyGetString Create(string name)
		{
			return new PropertyGetString(new GetStringId(name));
		}
	}
}
