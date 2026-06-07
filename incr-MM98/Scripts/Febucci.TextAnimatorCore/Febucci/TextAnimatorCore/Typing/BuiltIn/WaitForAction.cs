using System;
using System.Globalization;
using Febucci.Parsing;

namespace Febucci.TextAnimatorCore.Typing.BuiltIn
{
	[Serializable]
	internal class WaitForAction : ITypewriterAction, ITagProvider
	{
		public string TagID => "waitfor";

		public IActionState CreateActionFrom(ActionMarker marker, object typewriter)
		{
			float result = 1f;
			if (marker.parameters != null && marker.parameters.Length != 0 && !float.TryParse(marker.parameters[0], NumberStyles.Float, CultureInfo.InvariantCulture, out result))
			{
				result = 1f;
			}
			return new WaitForActionState(result);
		}
	}
}
