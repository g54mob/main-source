using System;

namespace Cainos.LucidEditor
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field, AllowMultiple = true)]
	public class BlockquoteAttribute : Attribute
	{
		public readonly string text;

		public BlockquoteAttribute(string text)
		{
		}
	}
}
