using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Style : BaseComponent
	{
		public Type TargetType
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Style BasedOn
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ResourceDictionary Resources
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public SetterBaseCollection Setters => null;

		public TriggerCollection Triggers => null;

		public bool CanSeal => false;

		public bool IsSealed => false;

		internal new static Style CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Style(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Style obj)
		{
			return default(HandleRef);
		}

		public Style()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public void Seal()
		{
		}
	}
}
