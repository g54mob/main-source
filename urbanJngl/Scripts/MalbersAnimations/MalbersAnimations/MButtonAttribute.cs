using UnityEngine;

namespace MalbersAnimations
{
	public class MButtonAttribute : PropertyAttribute
	{
		public bool OnlyPlayMode;

		public string displayName;

		public string MethodName { get; }

		public MButtonAttribute(string methodName)
		{
			MethodName = methodName;
			OnlyPlayMode = false;
			displayName = methodName;
		}

		public MButtonAttribute(string methodName, bool inplaymode)
		{
			MethodName = methodName;
			OnlyPlayMode = inplaymode;
			displayName = methodName;
		}

		public MButtonAttribute(string methodName, string display, bool inplaymode)
		{
			MethodName = methodName;
			OnlyPlayMode = inplaymode;
			displayName = display;
		}
	}
}
