using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class VirtualizingPanel : Panel
	{
		public IItemContainerGenerator ItemContainerGenerator => null;

		public static DependencyProperty CacheLengthProperty => null;

		public static DependencyProperty CacheLengthUnitProperty => null;

		public static DependencyProperty IsContainerVirtualizableProperty => null;

		public static DependencyProperty IsVirtualizingProperty => null;

		public static DependencyProperty ScrollUnitProperty => null;

		public static DependencyProperty VirtualizationModeProperty => null;

		internal new static VirtualizingPanel CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal VirtualizingPanel(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(VirtualizingPanel obj)
		{
			return default(HandleRef);
		}

		protected VirtualizingPanel()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public void BringIndexIntoViewPublic(int index)
		{
		}

		protected virtual void BringIndexIntoView(int index)
		{
		}

		public static VirtualizationCacheLength GetCacheLength(DependencyObject element)
		{
			return default(VirtualizationCacheLength);
		}

		public static void SetCacheLength(DependencyObject element, VirtualizationCacheLength len)
		{
		}

		public static VirtualizationCacheLengthUnit GetCacheLengthUnit(DependencyObject element)
		{
			return default(VirtualizationCacheLengthUnit);
		}

		public static void SetCacheLengthUnit(DependencyObject element, VirtualizationCacheLengthUnit unit)
		{
		}

		public static bool GetIsContainerVirtualizable(DependencyObject element)
		{
			return false;
		}

		public static void SetIsContainerVirtualizable(DependencyObject element, bool isVirtualizable)
		{
		}

		public static bool GetIsVirtualizing(DependencyObject element)
		{
			return false;
		}

		public static void SetIsVirtualizing(DependencyObject element, bool isVirtualizing)
		{
		}

		public static ScrollUnit GetScrollUnit(DependencyObject element)
		{
			return default(ScrollUnit);
		}

		public static void SetScrollUnit(DependencyObject element, ScrollUnit unit)
		{
		}

		public static VirtualizationMode GetVirtualizationMode(DependencyObject element)
		{
			return default(VirtualizationMode);
		}

		public static void SetVirtualizationMode(DependencyObject element, VirtualizationMode mode)
		{
		}

		private object GetGeneratorHelper()
		{
			return null;
		}
	}
}
