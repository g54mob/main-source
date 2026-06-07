using UnityEngine;

namespace SE.EvilLib.Core
{
	public class VarAsButtonAttribute : PropertyAttribute
	{
		public readonly string methodName;

		public readonly string buttonTitle;

		public readonly bool executeInEditMode;

		public VarAsButtonAttribute(string _methodName)
		{
		}

		public VarAsButtonAttribute(string _methodName, string _buttonTitle)
		{
		}

		public VarAsButtonAttribute(string _methodName, string _buttonTitle, bool _execInEditMode)
		{
		}
	}
}
