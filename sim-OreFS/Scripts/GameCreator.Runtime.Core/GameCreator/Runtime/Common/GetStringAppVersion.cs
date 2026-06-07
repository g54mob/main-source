using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("App Version")]
	[Category("Application/App Version")]
	[Image(typeof(IconApplication), ColorTheme.Type.Blue)]
	[Description("Returns the current version of the Application")]
	public class GetStringAppVersion : PropertyTypeGetString
	{
		public static PropertyGetString Create => new PropertyGetString(new GetStringAppVersion());

		public override string String => "App Version";

		public override string EditorValue => Application.version;

		public override string Get(Args args)
		{
			return Application.version;
		}

		public override string Get(GameObject gameObject)
		{
			return Application.version;
		}
	}
}
