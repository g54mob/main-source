using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Inline : TextElement
	{
		public static DependencyProperty TextDecorationsProperty => null;

		public InlineCollection SiblingInlines => null;

		public Inline PreviousInline => null;

		public Inline NextInline => null;

		public TextDecorations TextDecorations
		{
			get
			{
				return default(TextDecorations);
			}
			set
			{
			}
		}

		internal new static Inline CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Inline(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Inline obj)
		{
			return default(HandleRef);
		}

		public Inline()
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
