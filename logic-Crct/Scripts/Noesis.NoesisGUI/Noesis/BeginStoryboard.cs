using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class BeginStoryboard : TriggerAction
	{
		public static DependencyProperty StoryboardProperty => null;

		public HandoffBehavior HandoffBehavior
		{
			get
			{
				return default(HandoffBehavior);
			}
			set
			{
			}
		}

		public string Name
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Storyboard Storyboard
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static BeginStoryboard CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal BeginStoryboard(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(BeginStoryboard obj)
		{
			return default(HandleRef);
		}

		public BeginStoryboard()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
