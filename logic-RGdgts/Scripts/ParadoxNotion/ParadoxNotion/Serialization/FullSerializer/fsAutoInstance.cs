using System;

namespace ParadoxNotion.Serialization.FullSerializer
{
	public sealed class fsAutoInstance : Attribute
	{
		public readonly bool makeInstance;

		public fsAutoInstance(bool makeInstance = true)
		{
		}
	}
}
