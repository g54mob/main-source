using System;
using System.Runtime.CompilerServices;

namespace Rhizomatic.UI
{
	public abstract class InputFieldAdapter : UIAdapter<string>
	{
		public event Action onSubmit
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public abstract void Focus();

		protected void Submit()
		{
		}
	}
}
