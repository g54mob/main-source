using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Empty")]
	[Category("Constants/Empty")]
	[Image(typeof(IconEmpty), ColorTheme.Type.Yellow)]
	[Description("An empty string of characters")]
	[Keywords(new string[] { "String", "None", "Null" })]
	public class GetStringEmpty : PropertyTypeGetString
	{
		public const string DISPLAY = "<empty>";

		public static PropertyGetString Create => new PropertyGetString(new GetStringEmpty());

		public override string String => "<empty>";

		public override string Get(Args args)
		{
			return string.Empty;
		}

		public override string Get(GameObject gameObject)
		{
			return string.Empty;
		}
	}
}
