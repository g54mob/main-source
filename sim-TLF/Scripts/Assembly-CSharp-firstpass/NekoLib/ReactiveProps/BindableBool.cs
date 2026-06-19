using System;

namespace NekoLib.ReactiveProps
{
	[Serializable]
	public class BindableBool : BindableProp<bool>
	{
		public BindableBool()
			: this(value: false)
		{
		}

		public BindableBool(bool value)
			: base(value)
		{
		}
	}
}
