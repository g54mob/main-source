using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Editor Version")]
	[Category("Application/Editor Version")]
	[Image(typeof(IconUnity), ColorTheme.Type.Blue)]
	[Description("Returns the current version of the Unity Editor")]
	public class GetStringEditorVersion : PropertyTypeGetString
	{
		public static PropertyGetString Create => new PropertyGetString(new GetStringEditorVersion());

		public override string String => "App Version";

		public override string EditorValue => Application.unityVersion;

		public override string Get(Args args)
		{
			return Application.unityVersion;
		}

		public override string Get(GameObject gameObject)
		{
			return Application.unityVersion;
		}
	}
}
