using System;

namespace NekoLib.ReactiveProps
{
	[Serializable]
	public class BindableDouble : BindableProp<double>
	{
		public BindableDouble()
			: this(0.0)
		{
		}

		public BindableDouble(double value)
			: base(value)
		{
		}
	}
}
