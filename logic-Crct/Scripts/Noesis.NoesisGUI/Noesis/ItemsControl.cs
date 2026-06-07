using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ItemsControl : Control
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate IntPtr GetContainerForItemBaseCallback(HandleRef cPtr);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate bool IsItemItsOwnContainerBaseCallback(HandleRef cPtr, HandleRef item);

		internal GetContainerForItemBaseCallback GetContainerForItemBase;

		internal IsItemItsOwnContainerBaseCallback IsItemItsOwnContainerBase;

		public IEnumerable ItemsSource
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static DependencyProperty AlternationCountProperty => null;

		public static DependencyProperty AlternationIndexProperty => null;

		public static DependencyProperty DisplayMemberPathProperty => null;

		public static DependencyProperty HasItemsProperty => null;

		public static DependencyProperty ItemContainerStyleProperty => null;

		public static DependencyProperty ItemsPanelProperty => null;

		public static DependencyProperty ItemsSourceProperty => null;

		public static DependencyProperty ItemTemplateProperty => null;

		public static DependencyProperty ItemTemplateSelectorProperty => null;

		public int AlternationCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public string DisplayMemberPath
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool HasItems => false;

		public ItemContainerGenerator ItemContainerGenerator => null;

		public Style ItemContainerStyle
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ItemsPanelTemplate ItemsPanel
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DataTemplate ItemTemplate
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DataTemplateSelector ItemTemplateSelector
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ItemCollection Items => null;

		internal new static ItemsControl CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ItemsControl(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ItemsControl obj)
		{
			return default(HandleRef);
		}

		public static int GetAlternationIndex(DependencyObject element)
		{
			return 0;
		}

		private DependencyObject ContainerFromElement(DependencyObject element)
		{
			return null;
		}

		protected internal virtual DependencyObject GetContainerForItemOverride()
		{
			return null;
		}

		protected internal virtual bool IsItemItsOwnContainerOverride(object item)
		{
			return false;
		}

		public ItemsControl()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public static ItemsControl ItemsControlFromItemContainer(DependencyObject container)
		{
			return null;
		}

		public static DependencyObject ContainerFromElement(ItemsControl itemsControl, DependencyObject element)
		{
			return null;
		}

		public static ItemsControl GetItemsOwner(DependencyObject itemsHost)
		{
			return null;
		}

		public bool IsItemItsOwnContainer(object item)
		{
			return false;
		}

		private static int Get_AlternationIndex(DependencyObject element)
		{
			return 0;
		}

		private DependencyObject Get_ContainerFromElement(DependencyObject element)
		{
			return null;
		}

		private object Get_ItemsSource()
		{
			return null;
		}

		private void Set_ItemsSource(object items)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
