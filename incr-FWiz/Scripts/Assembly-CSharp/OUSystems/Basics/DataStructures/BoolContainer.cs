using System;
using System.Runtime.CompilerServices;

namespace OUSystems.Basics.DataStructures
{
	[Serializable]
	public class BoolContainer : ValueContainer<bool>
	{
		public override bool Value
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public event Action AnnounceTrue
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

		public event Action AnnounceFalse
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

		public BoolContainer()
		{
		}

		public BoolContainer(bool value)
		{
		}

		public void DoubleSubscribe(Action on, Action off, bool initialTrigger)
		{
		}

		public void DoubleUnsubscribe(Action on, Action off)
		{
		}
	}
}
