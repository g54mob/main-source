using System;

namespace FluffyUnderware.Curvy.Generator
{
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class InputSlotInfo : SlotInfo
	{
		public bool RequestDataOnly;

		public bool Optional;

		public bool ModifiesData;

		public InputSlotInfo(string name, params Type[] type)
			: base((string)null, (Type[])null)
		{
		}

		public InputSlotInfo(params Type[] type)
			: base((string)null, (Type[])null)
		{
		}

		public bool IsValidFrom(Type outType)
		{
			return false;
		}
	}
}
