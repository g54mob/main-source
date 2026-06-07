using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DragEventArgs : RoutedEventArgs
	{
		private HandleRef swigCPtr;

		public IDataObject Data => null;

		public DragDropKeyStates KeyStates => default(DragDropKeyStates);

		public DragDropEffects AllowedEffects => default(DragDropEffects);

		public DragDropEffects Effects
		{
			get
			{
				return default(DragDropEffects);
			}
			set
			{
			}
		}

		internal DragEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DragEventArgs obj)
		{
			return default(HandleRef);
		}

		~DragEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		public Point GetPosition(UIElement relativeTo)
		{
			return default(Point);
		}

		private object GetDataHelper()
		{
			return null;
		}

		private DragDropKeyStates GetKeyStatesHelper()
		{
			return default(DragDropKeyStates);
		}

		private DragDropEffects GetAllowedEffectsHelper()
		{
			return default(DragDropEffects);
		}

		private DragDropEffects GetEffectsHelper()
		{
			return default(DragDropEffects);
		}

		private void SetEffectsHelper(DragDropEffects value)
		{
		}
	}
}
