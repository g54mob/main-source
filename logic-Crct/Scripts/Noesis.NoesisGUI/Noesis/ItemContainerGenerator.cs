using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ItemContainerGenerator : BaseComponent, IRecyclingItemContainerGenerator, IItemContainerGenerator
	{
		public delegate void ItemsChangedHandler(object sender, ItemsChangedEventArgs e);

		internal delegate void RaiseItemsChangedCallback(IntPtr cPtr, IntPtr sender, IntPtr e);

		public delegate void StatusChangedHandler(object sender, EventArgs e);

		internal delegate void RaiseStatusChangedCallback(IntPtr cPtr, IntPtr sender, IntPtr e);

		private struct Generator : IDisposable
		{
			private ItemContainerGenerator _generator;

			internal Generator(ItemContainerGenerator generator)
			{
				_generator = null;
			}

			void IDisposable.Dispose()
			{
			}
		}

		private static RaiseItemsChangedCallback _raiseItemsChanged;

		internal static Dictionary<long, ItemsChangedHandler> _ItemsChanged;

		private static RaiseStatusChangedCallback _raiseStatusChanged;

		internal static Dictionary<long, StatusChangedHandler> _StatusChanged;

		public GeneratorStatus Status => default(GeneratorStatus);

		public event ItemsChangedHandler ItemsChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		public event StatusChangedHandler StatusChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		internal new static ItemContainerGenerator CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ItemContainerGenerator(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ItemContainerGenerator obj)
		{
			return default(HandleRef);
		}

		protected ItemContainerGenerator()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		[MonoPInvokeCallback(typeof(RaiseItemsChangedCallback))]
		private static void RaiseItemsChanged(IntPtr cPtr, IntPtr sender, IntPtr e)
		{
		}

		[MonoPInvokeCallback(typeof(RaiseStatusChangedCallback))]
		private static void RaiseStatusChanged(IntPtr cPtr, IntPtr sender, IntPtr e)
		{
		}

		ItemContainerGenerator IItemContainerGenerator.GetItemContainerGeneratorForPanel(Panel panel)
		{
			return null;
		}

		IDisposable IItemContainerGenerator.StartAt(GeneratorPosition position, GeneratorDirection direction)
		{
			return null;
		}

		IDisposable IItemContainerGenerator.StartAt(GeneratorPosition position, GeneratorDirection direction, bool allowStartAtRealizedItem)
		{
			return null;
		}

		DependencyObject IItemContainerGenerator.GenerateNext()
		{
			return null;
		}

		DependencyObject IItemContainerGenerator.GenerateNext(out bool isNewlyRealized)
		{
			isNewlyRealized = default(bool);
			return null;
		}

		void IItemContainerGenerator.PrepareItemContainer(DependencyObject container)
		{
		}

		void IItemContainerGenerator.RemoveAll()
		{
		}

		void IItemContainerGenerator.Remove(GeneratorPosition position, int count)
		{
		}

		GeneratorPosition IItemContainerGenerator.GeneratorPositionFromIndex(int itemIndex)
		{
			return default(GeneratorPosition);
		}

		int IItemContainerGenerator.IndexFromGeneratorPosition(GeneratorPosition position)
		{
			return 0;
		}

		void IRecyclingItemContainerGenerator.Recycle(GeneratorPosition position, int count)
		{
		}

		public DependencyObject ContainerFromIndex(int index)
		{
			return null;
		}

		public DependencyObject ContainerFromItem(object item)
		{
			return null;
		}

		public int IndexFromContainer(DependencyObject container)
		{
			return 0;
		}

		public object ItemFromContainer(DependencyObject container)
		{
			return null;
		}

		public void StartBatch()
		{
		}

		public void StopBatch()
		{
		}

		private ItemContainerGenerator GetItemContainerGeneratorForPanelHelper(Panel panel)
		{
			return null;
		}

		private void GeneratorPositionFromIndexHelper(int itemIndex, ref GeneratorPosition position)
		{
		}

		private int IndexFromGeneratorPositionHelper(GeneratorPosition position)
		{
			return 0;
		}

		private void StartAtHelper(GeneratorPosition position, GeneratorDirection direction, bool allowStartAtRealizedItem)
		{
		}

		private IntPtr GenerateNextHelper()
		{
			return (IntPtr)0;
		}

		private IntPtr GenerateNextRealizedHelper(ref bool isNewlyRealized)
		{
			return (IntPtr)0;
		}

		private void StopHelper()
		{
		}

		private void PrepareItemContainerHelper(DependencyObject container)
		{
		}

		private void RemoveAllHelper()
		{
		}

		private void RemoveHelper(GeneratorPosition position, int count)
		{
		}

		private void RecycleHelper(GeneratorPosition position, int count)
		{
		}
	}
}
