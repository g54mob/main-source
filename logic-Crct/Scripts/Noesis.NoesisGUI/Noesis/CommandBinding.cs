using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace Noesis
{
	public class CommandBinding : BaseComponent
	{
		public delegate void PreviewCanExecuteHandler(object sender, CanExecuteRoutedEventArgs e);

		internal delegate void RaisePreviewCanExecuteCallback(IntPtr cPtr, IntPtr sender, IntPtr e);

		public delegate void CanExecuteHandler(object sender, CanExecuteRoutedEventArgs e);

		internal delegate void RaiseCanExecuteCallback(IntPtr cPtr, IntPtr sender, IntPtr e);

		public delegate void PreviewExecutedHandler(object sender, ExecutedRoutedEventArgs e);

		internal delegate void RaisePreviewExecutedCallback(IntPtr cPtr, IntPtr sender, IntPtr e);

		public delegate void ExecutedHandler(object sender, ExecutedRoutedEventArgs e);

		internal delegate void RaiseExecutedCallback(IntPtr cPtr, IntPtr sender, IntPtr e);

		private static RaisePreviewCanExecuteCallback _raisePreviewCanExecute;

		internal static Dictionary<long, PreviewCanExecuteHandler> _PreviewCanExecute;

		private static RaiseCanExecuteCallback _raiseCanExecute;

		internal static Dictionary<long, CanExecuteHandler> _CanExecute;

		private static RaisePreviewExecutedCallback _raisePreviewExecuted;

		internal static Dictionary<long, PreviewExecutedHandler> _PreviewExecuted;

		private static RaiseExecutedCallback _raiseExecuted;

		internal static Dictionary<long, ExecutedHandler> _Executed;

		public ICommand Command
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public event PreviewCanExecuteHandler PreviewCanExecute
		{
			add
			{
			}
			remove
			{
			}
		}

		public event CanExecuteHandler CanExecute
		{
			add
			{
			}
			remove
			{
			}
		}

		public event PreviewExecutedHandler PreviewExecuted
		{
			add
			{
			}
			remove
			{
			}
		}

		public event ExecutedHandler Executed
		{
			add
			{
			}
			remove
			{
			}
		}

		internal new static CommandBinding CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal CommandBinding(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(CommandBinding obj)
		{
			return default(HandleRef);
		}

		[MonoPInvokeCallback(typeof(RaisePreviewCanExecuteCallback))]
		private static void RaisePreviewCanExecute(IntPtr cPtr, IntPtr sender, IntPtr e)
		{
		}

		[MonoPInvokeCallback(typeof(RaiseCanExecuteCallback))]
		private static void RaiseCanExecute(IntPtr cPtr, IntPtr sender, IntPtr e)
		{
		}

		[MonoPInvokeCallback(typeof(RaisePreviewExecutedCallback))]
		private static void RaisePreviewExecuted(IntPtr cPtr, IntPtr sender, IntPtr e)
		{
		}

		[MonoPInvokeCallback(typeof(RaiseExecutedCallback))]
		private static void RaiseExecuted(IntPtr cPtr, IntPtr sender, IntPtr e)
		{
		}

		public CommandBinding()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		private object GetCommandHelper()
		{
			return null;
		}

		private void SetCommandHelper(object command)
		{
		}
	}
}
