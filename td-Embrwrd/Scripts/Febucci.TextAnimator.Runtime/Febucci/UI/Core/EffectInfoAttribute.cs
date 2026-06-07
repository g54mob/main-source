using System;

namespace Febucci.UI.Core
{
	[AttributeUsage(AttributeTargets.Class)]
	public class EffectInfoAttribute : TagInfoAttribute
	{
		public readonly EffectCategory category;

		public EffectInfoAttribute(string tagID, EffectCategory category)
			: base(null)
		{
		}
	}
}
