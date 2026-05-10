using System;
using JetBrains.Annotations;

namespace FluffyUnderware.Curvy.Generator
{
	[AttributeUsage(AttributeTargets.Field)]
	public class OutputSlotInfo : SlotInfo
	{
		public Type DataType => null;

		public OutputSlotInfo([NotNull] Type type)
			: base((string)null, (Type[])null)
		{
		}

		public OutputSlotInfo(string name, [NotNull] Type type)
			: base((string)null, (Type[])null)
		{
		}
	}
}
