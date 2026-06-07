using System;

namespace Febucci.TextAnimatorForUnity
{
	[AttributeUsage(AttributeTargets.Class)]
	public class EffectInfoAttribute : TagInfoAttribute
	{
		public readonly EffectCategory category;

		public EffectInfoAttribute(string tagID, EffectCategory category)
			: base(tagID)
		{
			this.category = category;
		}
	}
}
