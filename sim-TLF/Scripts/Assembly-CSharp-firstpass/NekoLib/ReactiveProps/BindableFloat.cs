using System;

namespace NekoLib.ReactiveProps
{
	[Serializable]
	public class BindableFloat : BindableProp<float>
	{
		public BindableFloat()
			: this(0f)
		{
		}

		public BindableFloat(float value)
			: base(value)
		{
		}
	}
}
