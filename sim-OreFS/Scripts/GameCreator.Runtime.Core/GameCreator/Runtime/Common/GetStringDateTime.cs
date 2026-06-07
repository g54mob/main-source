using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Date Time")]
	[Category("Time/Date Time")]
	[Image(typeof(IconClock), ColorTheme.Type.Yellow)]
	[Description("Returns the current time in the specified format")]
	public class GetStringDateTime : PropertyTypeGetString
	{
		[SerializeField]
		private string m_Format = "f";

		public static PropertyGetString Create => new PropertyGetString(new GetStringDateTime());

		public override string String => "Time";

		public override string Get(Args args)
		{
			return GetTime();
		}

		public override string Get(GameObject gameObject)
		{
			return GetTime();
		}

		private string GetTime()
		{
			return DateTime.Now.ToString(m_Format);
		}
	}
}
