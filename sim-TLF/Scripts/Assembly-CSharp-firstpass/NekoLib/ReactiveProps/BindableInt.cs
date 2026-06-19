using System;

namespace NekoLib.ReactiveProps
{
	[Serializable]
	public class BindableInt : BindableProp<int>
	{
		public BindableInt()
			: this(0)
		{
		}

		public BindableInt(int value)
			: base(value)
		{
		}
	}
}
