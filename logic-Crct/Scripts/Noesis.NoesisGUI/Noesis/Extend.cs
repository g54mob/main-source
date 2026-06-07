using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Noesis
{
	internal class Extend
	{
		public enum NativeTypeKind
		{
			Basic = 0,
			Boxed = 1,
			Component = 2,
			Extended = 3
		}

		public class NativeTypeInfo
		{
			public NativeTypeKind Kind { get; private set; }

			public Type Type { get; private set; }

			public NativeTypeInfo(NativeTypeKind kind, Type type)
			{
			}
		}

		public class NativeTypeComponentInfo : NativeTypeInfo
		{
			public Func<IntPtr, bool, BaseComponent> Creator { get; private set; }

			public NativeTypeComponentInfo(NativeTypeKind kind, Type type, Func<IntPtr, bool, BaseComponent> creator)
				: base(default(NativeTypeKind), null)
			{
			}
		}

		public interface INativeTypeExtended
		{
		}

		public class NativeTypeEnumInfo : NativeTypeInfo, INativeTypeExtended
		{
			public NativeTypeEnumInfo(NativeTypeKind kind, Type type)
				: base(default(NativeTypeKind), null)
			{
			}
		}

		public class NativeTypeExtendedInfo : NativeTypeInfo, INativeTypeExtended
		{
			public Func<object> Creator { get; private set; }

			public NativeTypeExtendedInfo(NativeTypeKind kind, Type type, Func<object> creator)
				: base(default(NativeTypeKind), null)
			{
			}
		}

		public class NativeTypePropsInfo : NativeTypeExtendedInfo
		{
			public List<PropertyAccessor> Properties { get; private set; }

			public NativeTypePropsInfo(NativeTypeKind kind, Type type, Func<object> creator)
				: base(default(NativeTypeKind), null, null)
			{
			}
		}

		public class NativeTypeIndexerInfo : NativeTypePropsInfo
		{
			public IndexerAccessor Indexer { get; private set; }

			public NativeTypeIndexerInfo(NativeTypeKind kind, Type type, Func<object> creator, IndexerAccessor indexer)
				: base(default(NativeTypeKind), null, null)
			{
			}
		}

		private struct ExtendTypeData
		{
			public long type;

			public long baseType;

			public long typeConverter;

			public long contentProperty;

			public int overrides;
		}

		[Flags]
		private enum ExtendTypeOverrides
		{
			None = 0,
			Object_ToString = 1,
			Object_Equals = 2,
			Visual_GetChildrenCount = 4,
			Visual_GetChild = 8,
			UIElement_OnRender = 0x10,
			FrameworkElement_ConnectEvent = 0x20,
			FrameworkElement_Measure = 0x40,
			FrameworkElement_Arrange = 0x80,
			FrameworkElement_ApplyTemplate = 0x100,
			ItemsControl_GetContainer = 0x200,
			ItemsControl_IsContainer = 0x400,
			Adorner_GetTransform = 0x800,
			Freezable_Clone = 0x1000
		}

		private struct ExtendPropertyData
		{
			public long name;

			public long type;

			public long typeConverter;

			public int extendType;

			public int readOnly;
		}

		private delegate void Callback_FreeString(IntPtr strPtr);

		private delegate void Callback_RegisterType(string typeName);

		private delegate IntPtr Callback_ToString(IntPtr cPtr);

		private delegate bool Callback_Equals(IntPtr cPtr, IntPtr cPtrOtherType, IntPtr cPtrOther);

		private delegate int Callback_VisualChildrenCount(IntPtr cPtr, Visual.ChildrenCountBaseCallback callback);

		private delegate IntPtr Callback_VisualGetChild(IntPtr cPtr, int index, Visual.ChildrenCountBaseCallback countCallback, Visual.GetChildBaseCallback childCallback);

		private delegate void Callback_UIElementRender(IntPtr cPtr, IntPtr contextType, IntPtr context, UIElement.RenderBaseCallback callback);

		private delegate bool Callback_FrameworkElementConnectEvent(IntPtr cPtr, IntPtr cPtrSourceType, IntPtr cPtrSource, string eventName, string handlerName);

		private delegate void Callback_FrameworkElementMeasure(IntPtr cPtr, ref Size availableSize, ref Size desiredSize, FrameworkElement.LayoutBaseCallback callback);

		private delegate void Callback_FrameworkElementArrange(IntPtr cPtr, ref Size finalSize, ref Size renderSize, FrameworkElement.LayoutBaseCallback callback);

		private delegate void Callback_FrameworkElementApplyTemplate(IntPtr cPtr);

		private delegate IntPtr Callback_ItemsControlGetContainer(IntPtr cPtr, ItemsControl.GetContainerForItemBaseCallback callback);

		private delegate bool Callback_ItemsControlIsContainer(IntPtr cPtr, IntPtr itemTypePtr, IntPtr itemPtr, ItemsControl.IsItemItsOwnContainerBaseCallback callback);

		private delegate void Callback_AdornerGetTransform(IntPtr cPtr, ref Matrix4 transform, ref Matrix4 desiredTransform);

		private delegate void Callback_FreezableClone(IntPtr cPtrType, IntPtr cPtrClone, IntPtr cPtrSource);

		private delegate bool Callback_CommandCanExecute(IntPtr cPtr, IntPtr paramType, IntPtr paramPtr);

		private delegate void Callback_CommandExecute(IntPtr cPtr, IntPtr paramType, IntPtr paramPtr);

		private delegate bool Callback_ConverterConvert(IntPtr cPtr, IntPtr valType, IntPtr valPtr, IntPtr targetTypePtr, IntPtr paramType, IntPtr paramPtr, out IntPtr result);

		private delegate bool Callback_ConverterConvertBack(IntPtr cPtr, IntPtr valType, IntPtr valPtr, IntPtr targetTypePtr, IntPtr paramType, IntPtr paramPtr, out IntPtr result);

		private delegate bool Callback_MultiConverterConvert(IntPtr cPtr, int numSources, IntPtr valTypes, IntPtr valPtrs, IntPtr targetTypePtr, IntPtr paramType, IntPtr paramPtr, out IntPtr result);

		private delegate bool Callback_MultiConverterConvertBack(IntPtr cPtr, int numSources, IntPtr valType, IntPtr valPtr, IntPtr targetTypePtrs, IntPtr paramType, IntPtr paramPtr, IntPtr results);

		private delegate uint Callback_ListCount(IntPtr cPtr);

		private delegate IntPtr Callback_ListGet(IntPtr cPtr, uint index);

		private delegate void Callback_ListSet(IntPtr cPtr, uint index, IntPtr itemType, IntPtr item);

		private delegate uint Callback_ListAdd(IntPtr cPtr, IntPtr itemType, IntPtr item);

		private delegate int Callback_ListIndexOf(IntPtr cPtr, IntPtr itemType, IntPtr item);

		private delegate bool Callback_DictionaryFind(IntPtr cPtr, string key, ref IntPtr item);

		private delegate void Callback_DictionarySet(IntPtr cPtr, string key, IntPtr itemType, IntPtr item);

		private delegate void Callback_DictionaryAdd(IntPtr cPtr, string key, IntPtr itemType, IntPtr item);

		private delegate bool Callback_ListIndexerTryGet(IntPtr cPtrType, IntPtr cPtr, uint index, ref IntPtr item);

		private delegate bool Callback_ListIndexerTrySet(IntPtr cPtrType, IntPtr cPtr, uint index, IntPtr itemType, IntPtr item);

		private delegate bool Callback_DictionaryIndexerTryGet(IntPtr cPtrType, IntPtr cPtr, string key, ref IntPtr item);

		private delegate bool Callback_DictionaryIndexerTrySet(IntPtr cPtrType, IntPtr cPtr, string key, IntPtr itemType, IntPtr item);

		private delegate IntPtr Callback_SelectTemplate(IntPtr cPtr, IntPtr itemType, IntPtr item, IntPtr containerType, IntPtr container);

		private delegate void Callback_StreamSetPosition(IntPtr cPtr, uint pos);

		private delegate uint Callback_StreamGetPosition(IntPtr cPtr);

		private delegate uint Callback_StreamGetLength(IntPtr cPtr);

		private delegate uint Callback_StreamRead(IntPtr cPtr, IntPtr buffer, uint bufferSize);

		private delegate void Callback_StreamClose(IntPtr cPtr);

		private delegate IntPtr Callback_ProviderLoadXaml(IntPtr cPtr, IntPtr filename);

		private delegate void Callback_ProviderTextureInfo(IntPtr cPtr, IntPtr filename, ref uint width, ref uint height);

		private delegate IntPtr Callback_ProviderTextureLoad(IntPtr cPtr, IntPtr filename);

		private delegate IntPtr Callback_ProviderTextureOpen(IntPtr cPtr, IntPtr filename);

		private delegate IntPtr Callback_ProviderMatchFont(IntPtr cPtr, IntPtr baseUri, IntPtr familyName, ref int weight, ref int stretch, ref int style, ref uint index);

		private delegate bool Callback_ProviderFamilyExists(IntPtr cPtr, IntPtr baseUri, IntPtr familyName);

		private delegate void Callback_ProviderScanFolder(IntPtr cPtr, IntPtr folder);

		private delegate IntPtr Callback_ProviderOpenFont(IntPtr cPtr, IntPtr folder, IntPtr id);

		private delegate void Callback_ScrollInfoBringIntoView(IntPtr cPtr, int index);

		private delegate bool Callback_ScrollInfoGetCanHorizontalScroll(IntPtr cPtr);

		private delegate void Callback_ScrollInfoSetCanHorizontalScroll(IntPtr cPtr, bool canScroll);

		private delegate bool Callback_ScrollInfoGetCanVerticalScroll(IntPtr cPtr);

		private delegate void Callback_ScrollInfoSetCanVerticalScroll(IntPtr cPtr, bool canScroll);

		private delegate float Callback_ScrollInfoGetExtentWidth(IntPtr cPtr);

		private delegate float Callback_ScrollInfoGetExtentHeight(IntPtr cPtr);

		private delegate float Callback_ScrollInfoGetViewportWidth(IntPtr cPtr);

		private delegate float Callback_ScrollInfoGetViewportHeight(IntPtr cPtr);

		private delegate float Callback_ScrollInfoGetHorizontalOffset(IntPtr cPtr);

		private delegate float Callback_ScrollInfoGetVerticalOffset(IntPtr cPtr);

		private delegate IntPtr Callback_ScrollInfoGetScrollOwner(IntPtr cPtr);

		private delegate void Callback_ScrollInfoSetScrollOwner(IntPtr cPtr, IntPtr typeOwner, IntPtr cPtrOwner);

		private delegate void Callback_ScrollInfoLineLeft(IntPtr cPtr);

		private delegate void Callback_ScrollInfoLineRight(IntPtr cPtr);

		private delegate void Callback_ScrollInfoLineUp(IntPtr cPtr);

		private delegate void Callback_ScrollInfoLineDown(IntPtr cPtr);

		private delegate void Callback_ScrollInfoPageLeft(IntPtr cPtr);

		private delegate void Callback_ScrollInfoPageRight(IntPtr cPtr);

		private delegate void Callback_ScrollInfoPageUp(IntPtr cPtr);

		private delegate void Callback_ScrollInfoPageDown(IntPtr cPtr);

		private delegate void Callback_ScrollInfoMouseWheelLeft(IntPtr cPtr, float delta);

		private delegate void Callback_ScrollInfoMouseWheelRight(IntPtr cPtr, float delta);

		private delegate void Callback_ScrollInfoMouseWheelUp(IntPtr cPtr, float delta);

		private delegate void Callback_ScrollInfoMouseWheelDown(IntPtr cPtr, float delta);

		private delegate void Callback_ScrollInfoSetHorizontalOffset(IntPtr cPtr, float offset);

		private delegate void Callback_ScrollInfoSetVerticalOffset(IntPtr cPtr, float offset);

		private delegate void Callback_ScrollInfoMakeVisible(IntPtr cPtr, IntPtr visualType, IntPtr visualPtr, ref Rect rectangle, ref Rect result);

		private delegate IntPtr Callback_MarkupExtensionProvideValue(IntPtr cPtr, IntPtr provider);

		private enum NativePropertyType
		{
			Bool = 0,
			Float = 1,
			Double = 2,
			Int = 3,
			UInt = 4,
			Short = 5,
			UShort = 6,
			Color = 7,
			Point = 8,
			Rect = 9,
			Int32Rect = 10,
			Size = 11,
			Thickness = 12,
			CornerRadius = 13,
			TimeSpan = 14,
			Duration = 15,
			KeyTime = 16,
			NullableBool = 17,
			NullableFloat = 18,
			NullableDouble = 19,
			NullableInt = 20,
			NullableUInt = 21,
			NullableShort = 22,
			NullableUShort = 23,
			NullableColor = 24,
			NullablePoint = 25,
			NullableRect = 26,
			NullableInt32Rect = 27,
			NullableSize = 28,
			NullableThickness = 29,
			NullableCornerRadius = 30,
			NullableTimeSpan = 31,
			NullableDuration = 32,
			NullableKeyTime = 33,
			Enum = 34,
			String = 35,
			Uri = 36,
			Type = 37,
			BaseComponent = 38,
			Event = 39
		}

		private delegate bool Callback_GetPropertyValue_Bool(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref bool isNull);

		private delegate float Callback_GetPropertyValue_Float(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref bool isNull);

		private delegate double Callback_GetPropertyValue_Double(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref bool isNull);

		private delegate int Callback_GetPropertyValue_Int(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref bool isNull);

		private delegate uint Callback_GetPropertyValue_UInt(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref bool isNull);

		private delegate short Callback_GetPropertyValue_Short(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref bool isNull);

		private delegate ushort Callback_GetPropertyValue_UShort(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref bool isNull);

		private delegate IntPtr Callback_GetPropertyValue_String(IntPtr nativeType, int propertyIndex, IntPtr cPtr);

		private delegate IntPtr Callback_GetPropertyValue_Uri(IntPtr nativeType, int propertyIndex, IntPtr cPtr);

		private delegate void Callback_GetPropertyValue_Color(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref Color value, ref bool isNull);

		private delegate void Callback_GetPropertyValue_Point(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref Point value, ref bool isNull);

		private delegate void Callback_GetPropertyValue_Rect(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref Rect value, ref bool isNull);

		private delegate void Callback_GetPropertyValue_Int32Rect(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref Int32Rect value, ref bool isNull);

		private delegate void Callback_GetPropertyValue_Size(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref Size value, ref bool isNull);

		private delegate void Callback_GetPropertyValue_Thickness(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref Thickness value, ref bool isNull);

		private delegate void Callback_GetPropertyValue_CornerRadius(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref CornerRadius value, ref bool isNull);

		private delegate void Callback_GetPropertyValue_TimeSpan(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref TimeSpanStruct value, ref bool isNull);

		private delegate void Callback_GetPropertyValue_Duration(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref Duration value, ref bool isNull);

		private delegate void Callback_GetPropertyValue_KeyTime(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref KeyTime value, ref bool isNull);

		private delegate IntPtr Callback_GetPropertyValue_Type(IntPtr nativeType, int propertyIndex, IntPtr cPtr);

		private delegate IntPtr Callback_GetPropertyValue_BaseComponent(IntPtr nativeType, int propertyIndex, IntPtr cPtr);

		private delegate void Callback_SetPropertyValue_Bool(IntPtr nativeType, int propertyIndex, IntPtr cPtr, bool val, bool isNull);

		private delegate void Callback_SetPropertyValue_Float(IntPtr nativeType, int propertyIndex, IntPtr cPtr, float val, bool isNull);

		private delegate void Callback_SetPropertyValue_Double(IntPtr nativeType, int propertyIndex, IntPtr cPtr, double val, bool isNull);

		private delegate void Callback_SetPropertyValue_Int(IntPtr nativeType, int propertyIndex, IntPtr cPtr, int val, bool isNull);

		private delegate void Callback_SetPropertyValue_UInt(IntPtr nativeType, int propertyIndex, IntPtr cPtr, uint val, bool isNull);

		private delegate void Callback_SetPropertyValue_Short(IntPtr nativeType, int propertyIndex, IntPtr cPtr, short val, bool isNull);

		private delegate void Callback_SetPropertyValue_UShort(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ushort val, bool isNull);

		private delegate void Callback_SetPropertyValue_String(IntPtr nativeType, int propertyIndex, IntPtr cPtr, IntPtr val);

		private delegate void Callback_SetPropertyValue_Uri(IntPtr nativeType, int propertyIndex, IntPtr cPtr, IntPtr val);

		private delegate void Callback_SetPropertyValue_Color(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref Color val, bool isNull);

		private delegate void Callback_SetPropertyValue_Point(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref Point val, bool isNull);

		private delegate void Callback_SetPropertyValue_Rect(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref Rect val, bool isNull);

		private delegate void Callback_SetPropertyValue_Int32Rect(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref Int32Rect val, bool isNull);

		private delegate void Callback_SetPropertyValue_Size(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref Size val, bool isNull);

		private delegate void Callback_SetPropertyValue_Thickness(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref Thickness val, bool isNull);

		private delegate void Callback_SetPropertyValue_CornerRadius(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref CornerRadius val, bool isNull);

		private delegate void Callback_SetPropertyValue_TimeSpan(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref TimeSpanStruct val, bool isNull);

		private delegate void Callback_SetPropertyValue_Duration(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref Duration val, bool isNull);

		private delegate void Callback_SetPropertyValue_KeyTime(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref KeyTime val, bool isNull);

		private delegate void Callback_SetPropertyValue_Type(IntPtr nativeType, int propertyIndex, IntPtr cPtr, IntPtr val);

		private delegate void Callback_SetPropertyValue_BaseComponent(IntPtr nativeType, int propertyIndex, IntPtr cPtr, IntPtr valType, IntPtr val);

		private delegate void Callback_CreateInstance(IntPtr nativeType, IntPtr cPtr);

		private delegate void Callback_DeleteInstance(IntPtr cPtr);

		private delegate void Callback_GrabInstance(IntPtr cPtr, bool grab);

		private class ExtendInfo
		{
			public object instance;

			public WeakReference weak;
		}

		private struct WeakInfo
		{
			public int hash;

			public long ptr;

			public WeakReference weak;
		}

		private delegate IntPtr BoxDelegate(object val);

		private class Boxed<T>
		{
		}

		private delegate object UnboxDelegate(IntPtr cPtr);

		public class PropertyAccessor
		{
			private PropertyInfo _property;

			public PropertyInfo Property => null;

			public virtual bool IsNullable => false;

			public PropertyAccessor(PropertyInfo p)
			{
			}
		}

		public abstract class PropertyAccessorT<PropertyT> : PropertyAccessor
		{
			public PropertyAccessorT(PropertyInfo p)
				: base(null)
			{
			}

			public abstract PropertyT Get(object instance);

			public virtual void Set(object instance, PropertyT value)
			{
			}
		}

		public class PropertyAccessorCastRW<PropertyT, SourceT> : PropertyAccessorT<PropertyT>
		{
			private PropertyAccessorT<SourceT> _prop;

			private Func<SourceT, PropertyT> _castTo;

			private Func<PropertyT, SourceT> _castFrom;

			public PropertyAccessorCastRW(PropertyInfo p, PropertyAccessorT<SourceT> prop, Func<SourceT, PropertyT> castTo, Func<PropertyT, SourceT> castFrom)
				: base((PropertyInfo)null)
			{
			}

			public override PropertyT Get(object instance)
			{
				return default(PropertyT);
			}

			public override void Set(object instance, PropertyT value)
			{
			}
		}

		public class PropertyAccessorCastRO<PropertyT, SourceT> : PropertyAccessorT<PropertyT>
		{
			private PropertyAccessorT<SourceT> _prop;

			private Func<SourceT, PropertyT> _castTo;

			public PropertyAccessorCastRO(PropertyInfo p, PropertyAccessorT<SourceT> prop, Func<SourceT, PropertyT> castTo)
				: base((PropertyInfo)null)
			{
			}

			public override PropertyT Get(object instance)
			{
				return default(PropertyT);
			}
		}

		public class PropertyAccessorNullableCastRW<PropertyT, SourceT> : PropertyAccessorCastRW<PropertyT, SourceT>
		{
			public override bool IsNullable => false;

			public PropertyAccessorNullableCastRW(PropertyInfo p, PropertyAccessorT<SourceT> prop, Func<SourceT, PropertyT> castTo, Func<PropertyT, SourceT> castFrom)
				: base((PropertyInfo)null, (PropertyAccessorT<SourceT>)null, (Func<SourceT, PropertyT>)null, (Func<PropertyT, SourceT>)null)
			{
			}
		}

		public class PropertyAccessorNullableCastRO<PropertyT, SourceT> : PropertyAccessorCastRO<PropertyT, SourceT>
		{
			public override bool IsNullable => false;

			public PropertyAccessorNullableCastRO(PropertyInfo p, PropertyAccessorT<SourceT> prop, Func<SourceT, PropertyT> castTo)
				: base((PropertyInfo)null, (PropertyAccessorT<SourceT>)null, (Func<SourceT, PropertyT>)null)
			{
			}
		}

		public class PropertyAccessorPropRW<PropertyT> : PropertyAccessorT<PropertyT>
		{
			private Func<object, PropertyT> _getter;

			private Action<object, PropertyT> _setter;

			public PropertyAccessorPropRW(PropertyInfo p)
				: base((PropertyInfo)null)
			{
			}

			public override PropertyT Get(object instance)
			{
				return default(PropertyT);
			}

			public override void Set(object instance, PropertyT value)
			{
			}
		}

		public class PropertyAccessorPropRO<PropertyT> : PropertyAccessorT<PropertyT>
		{
			private Func<object, PropertyT> _getter;

			public PropertyAccessorPropRO(PropertyInfo p)
				: base((PropertyInfo)null)
			{
			}

			public override PropertyT Get(object instance)
			{
				return default(PropertyT);
			}
		}

		public class PropertyAccessorNullablePropRW<PropertyT> : PropertyAccessorPropRW<PropertyT>
		{
			public override bool IsNullable => false;

			public PropertyAccessorNullablePropRW(PropertyInfo p)
				: base((PropertyInfo)null)
			{
			}
		}

		public class PropertyAccessorNullablePropRO<PropertyT> : PropertyAccessorPropRO<PropertyT>
		{
			public override bool IsNullable => false;

			public PropertyAccessorNullablePropRO(PropertyInfo p)
				: base((PropertyInfo)null)
			{
			}
		}

		public abstract class IndexerAccessor
		{
		}

		public abstract class IndexerAccessorT<IndexT> : IndexerAccessor
		{
			public abstract object Get(object instance, IndexT index);

			public virtual void Set(object instance, IndexT index, object value)
			{
			}
		}

		public abstract class IndexerAccessorPropT<IndexT> : IndexerAccessorT<IndexT>
		{
			private object[] _index;

			protected object[] Index(IndexT index)
			{
				return null;
			}
		}

		public class IndexerAccessorPropRW<IndexT> : IndexerAccessorPropT<IndexT>
		{
			private Func<object, IndexT, object> _getter;

			private Action<object, IndexT, object> _setter;

			public IndexerAccessorPropRW(PropertyInfo p)
			{
			}

			public override object Get(object instance, IndexT index)
			{
				return null;
			}

			public override void Set(object instance, IndexT index, object value)
			{
			}
		}

		public class IndexerAccessorPropRO<IndexT> : IndexerAccessorPropT<IndexT>
		{
			private Func<object, IndexT, object> _getter;

			public IndexerAccessorPropRO(PropertyInfo p)
			{
			}

			public override object Get(object instance, IndexT index)
			{
				return null;
			}
		}

		private delegate ExtendPropertyData AddPropertyDelegate(NativeTypePropsInfo info, PropertyInfo p, bool usePropertyInfo);

		private static Dictionary<long, NativeTypeInfo> _nativeTypes;

		private static Dictionary<Type, IntPtr> _managedTypes;

		private static readonly Assembly BclAssembly;

		private static HashSet<Type> _constructedTypes;

		private static Callback_FreeString _freeString;

		private static Callback_RegisterType _registerType;

		private static List<Assembly> _assemblies;

		private static Callback_ToString _toString;

		private static Callback_Equals _equals;

		private static Callback_VisualChildrenCount _visualChildrenCount;

		private static Callback_VisualGetChild _visualGetChild;

		private static Callback_UIElementRender _uiElementRender;

		private static Callback_FrameworkElementConnectEvent _frameworkElementConnectEvent;

		private static Callback_FrameworkElementMeasure _frameworkElementMeasure;

		private static Callback_FrameworkElementArrange _frameworkElementArrange;

		private static Callback_FrameworkElementApplyTemplate _frameworkElementApplyTemplate;

		private static Callback_ItemsControlGetContainer _itemsControlGetContainer;

		private static Callback_ItemsControlIsContainer _itemsControlIsContainer;

		private static Callback_AdornerGetTransform _adornerGetTransform;

		private static Callback_FreezableClone _freezableClone;

		private static Callback_CommandCanExecute _commandCanExecute;

		private static Callback_CommandExecute _commandExecute;

		private static Callback_ConverterConvert _converterConvert;

		private static Callback_ConverterConvertBack _converterConvertBack;

		private static Callback_MultiConverterConvert _multiConverterConvert;

		private static Callback_MultiConverterConvertBack _multiConverterConvertBack;

		private static Callback_ListCount _listCount;

		private static Callback_ListGet _listGet;

		private static Callback_ListSet _listSet;

		private static Callback_ListAdd _listAdd;

		private static Callback_ListIndexOf _listIndexOf;

		private static Callback_DictionaryFind _dictionaryFind;

		private static Callback_DictionarySet _dictionarySet;

		private static Callback_DictionaryAdd _dictionaryAdd;

		private static Callback_ListIndexerTryGet _listIndexerTryGet;

		private static Callback_ListIndexerTrySet _listIndexerTrySet;

		private static Callback_DictionaryIndexerTryGet _dictionaryIndexerTryGet;

		private static Callback_DictionaryIndexerTrySet _dictionaryIndexerTrySet;

		private static Callback_SelectTemplate _selectTemplate;

		private static Callback_StreamSetPosition _streamSetPosition;

		private static Callback_StreamGetPosition _streamGetPosition;

		private static Callback_StreamGetLength _streamGetLength;

		private static Callback_StreamRead _streamRead;

		private static Callback_StreamClose _streamClose;

		private static Callback_ProviderLoadXaml _providerLoadXaml;

		private static Callback_ProviderTextureInfo _providerTextureInfo;

		private static Callback_ProviderTextureLoad _providerTextureLoad;

		private static Callback_ProviderTextureOpen _providerTextureOpen;

		private static Callback_ProviderMatchFont _providerMatchFont;

		private static Callback_ProviderFamilyExists _providerFamilyExists;

		private static Callback_ProviderScanFolder _providerScanFolder;

		private static Callback_ProviderOpenFont _providerOpenFont;

		private static Callback_ScrollInfoBringIntoView _scrollInfoBringIntoView;

		private static Callback_ScrollInfoGetCanHorizontalScroll _scrollInfoGetCanHorizontalScroll;

		private static Callback_ScrollInfoSetCanHorizontalScroll _scrollInfoSetCanHorizontalScroll;

		private static Callback_ScrollInfoGetCanVerticalScroll _scrollInfoGetCanVerticalScroll;

		private static Callback_ScrollInfoSetCanVerticalScroll _scrollInfoSetCanVerticalScroll;

		private static Callback_ScrollInfoGetExtentWidth _scrollInfoGetExtentWidth;

		private static Callback_ScrollInfoGetExtentHeight _scrollInfoGetExtentHeight;

		private static Callback_ScrollInfoGetViewportWidth _scrollInfoGetViewportWidth;

		private static Callback_ScrollInfoGetViewportHeight _scrollInfoGetViewportHeight;

		private static Callback_ScrollInfoGetHorizontalOffset _scrollInfoGetHorizontalOffset;

		private static Callback_ScrollInfoGetVerticalOffset _scrollInfoGetVerticalOffset;

		private static Callback_ScrollInfoGetScrollOwner _scrollInfoGetScrollOwner;

		private static Callback_ScrollInfoSetScrollOwner _scrollInfoSetScrollOwner;

		private static Callback_ScrollInfoLineLeft _scrollInfoLineLeft;

		private static Callback_ScrollInfoLineRight _scrollInfoLineRight;

		private static Callback_ScrollInfoLineUp _scrollInfoLineUp;

		private static Callback_ScrollInfoLineDown _scrollInfoLineDown;

		private static Callback_ScrollInfoPageLeft _scrollInfoPageLeft;

		private static Callback_ScrollInfoPageRight _scrollInfoPageRight;

		private static Callback_ScrollInfoPageUp _scrollInfoPageUp;

		private static Callback_ScrollInfoPageDown _scrollInfoPageDown;

		private static Callback_ScrollInfoMouseWheelLeft _scrollInfoMouseWheelLeft;

		private static Callback_ScrollInfoMouseWheelRight _scrollInfoMouseWheelRight;

		private static Callback_ScrollInfoMouseWheelUp _scrollInfoMouseWheelUp;

		private static Callback_ScrollInfoMouseWheelDown _scrollInfoMouseWheelDown;

		private static Callback_ScrollInfoSetHorizontalOffset _scrollInfoSetHorizontalOffset;

		private static Callback_ScrollInfoSetVerticalOffset _scrollInfoSetVerticalOffset;

		private static Callback_ScrollInfoMakeVisible _scrollInfoMakeVisible;

		private static Callback_MarkupExtensionProvideValue _markupExtensionProvideValue;

		private static Callback_GetPropertyValue_Bool _getPropertyValue_Bool;

		private static Callback_GetPropertyValue_Float _getPropertyValue_Float;

		private static Callback_GetPropertyValue_Double _getPropertyValue_Double;

		private static Callback_GetPropertyValue_Int _getPropertyValue_Int;

		private static Callback_GetPropertyValue_UInt _getPropertyValue_UInt;

		private static Callback_GetPropertyValue_Short _getPropertyValue_Short;

		private static Callback_GetPropertyValue_UShort _getPropertyValue_UShort;

		private static Callback_GetPropertyValue_String _getPropertyValue_String;

		private static Callback_GetPropertyValue_Uri _getPropertyValue_Uri;

		private static Callback_GetPropertyValue_Color _getPropertyValue_Color;

		private static Callback_GetPropertyValue_Point _getPropertyValue_Point;

		private static Callback_GetPropertyValue_Rect _getPropertyValue_Rect;

		private static Callback_GetPropertyValue_Int32Rect _getPropertyValue_Int32Rect;

		private static Callback_GetPropertyValue_Size _getPropertyValue_Size;

		private static Callback_GetPropertyValue_Thickness _getPropertyValue_Thickness;

		private static Callback_GetPropertyValue_CornerRadius _getPropertyValue_CornerRadius;

		private static Callback_GetPropertyValue_TimeSpan _getPropertyValue_TimeSpan;

		private static Callback_GetPropertyValue_Duration _getPropertyValue_Duration;

		private static Callback_GetPropertyValue_KeyTime _getPropertyValue_KeyTime;

		private static Callback_GetPropertyValue_Type _getPropertyValue_Type;

		private static Callback_GetPropertyValue_BaseComponent _getPropertyValue_BaseComponent;

		private static Callback_SetPropertyValue_Bool _setPropertyValue_Bool;

		private static Callback_SetPropertyValue_Float _setPropertyValue_Float;

		private static Callback_SetPropertyValue_Double _setPropertyValue_Double;

		private static Callback_SetPropertyValue_Int _setPropertyValue_Int;

		private static Callback_SetPropertyValue_UInt _setPropertyValue_UInt;

		private static Callback_SetPropertyValue_Short _setPropertyValue_Short;

		private static Callback_SetPropertyValue_UShort _setPropertyValue_UShort;

		private static Callback_SetPropertyValue_String _setPropertyValue_String;

		private static Callback_SetPropertyValue_Uri _setPropertyValue_Uri;

		private static Callback_SetPropertyValue_Color _setPropertyValue_Color;

		private static Callback_SetPropertyValue_Point _setPropertyValue_Point;

		private static Callback_SetPropertyValue_Rect _setPropertyValue_Rect;

		private static Callback_SetPropertyValue_Int32Rect _setPropertyValue_Int32Rect;

		private static Callback_SetPropertyValue_Size _setPropertyValue_Size;

		private static Callback_SetPropertyValue_Thickness _setPropertyValue_Thickness;

		private static Callback_SetPropertyValue_CornerRadius _setPropertyValue_CornerRadius;

		private static Callback_SetPropertyValue_TimeSpan _setPropertyValue_TimeSpan;

		private static Callback_SetPropertyValue_Duration _setPropertyValue_Duration;

		private static Callback_SetPropertyValue_KeyTime _setPropertyValue_KeyTime;

		private static Callback_SetPropertyValue_Type _setPropertyValue_Type;

		private static Callback_SetPropertyValue_BaseComponent _setPropertyValue_BaseComponent;

		[ThreadStatic]
		private static IntPtr _cPtr;

		[ThreadStatic]
		private static Type _extendType;

		private static Callback_CreateInstance _createInstance;

		private static Callback_DeleteInstance _deleteInstance;

		private static Callback_GrabInstance _grabInstance;

		private static Dictionary<long, ExtendInfo> _extends;

		private static List<WeakInfo> _weakExtends;

		private static Dictionary<int, List<WeakInfo>> _weakExtendsHash;

		private static int _weakExtendsIndex;

		private static Dictionary<long, WeakReference> _proxies;

		private static List<IntPtr> _pendingRelease;

		private static Dictionary<Type, BoxDelegate> _boxFunctions;

		private static Dictionary<Type, UnboxDelegate> _unboxFunctions;

		private static Dictionary<Type, AddPropertyDelegate> _addPropertyFunctions;

		public static bool Initialized { get; internal set; }

		public static void Init()
		{
		}

		public static void Shutdown()
		{
		}

		public static void RegisterCallbacks()
		{
		}

		public static void UnregisterCallbacks()
		{
		}

		private static void ClearTables()
		{
		}

		private static void AddNativeType(IntPtr nativeType, NativeTypeInfo info)
		{
		}

		public static IntPtr TryGetNativeType(Type type)
		{
			return (IntPtr)0;
		}

		public static IntPtr GetNativeType(Type type)
		{
			return (IntPtr)0;
		}

		public static NativeTypeInfo GetNativeTypeInfo(IntPtr nativeType)
		{
			return null;
		}

		internal static object GetProxy(IntPtr nativeType, IntPtr cPtr, bool ownMemory)
		{
			return null;
		}

		public static object GetProxy(IntPtr cPtr, bool ownMemory)
		{
			return null;
		}

		public static object Initialize(object instance)
		{
			return null;
		}

		public static void RegisterNativeTypes()
		{
		}

		public static void UnregisterNativeTypes()
		{
		}

		private static PropertyInfo[] GetPublicProperties(Type type)
		{
			return null;
		}

		private static EventInfo[] GetPublicEvents(Type type)
		{
			return null;
		}

		private static PropertyInfo FindIndexer(Type type, Type paramType)
		{
			return null;
		}

		private static PropertyInfo FindListIndexer(Type type)
		{
			return null;
		}

		private static PropertyInfo FindDictIndexer(Type type)
		{
			return null;
		}

		public static IntPtr RegisterNativeType(Type type)
		{
			return (IntPtr)0;
		}

		public static IntPtr RegisterNativeType(Type type, bool registerDP)
		{
			return (IntPtr)0;
		}

		private static string TypeFullName(Type type)
		{
			return null;
		}

		private static Func<object> TypeCreator(Type type)
		{
			return null;
		}

		private static NativeTypeInfo CreateNativeTypeInfo(Type type, IndexerAccessor indexer, PropertyInfo[] props)
		{
			return null;
		}

		private static bool IsOverride(MethodInfo m)
		{
			return false;
		}

		private static bool ParametersMatch(MethodInfo m, Type[] types)
		{
			return false;
		}

		public static MethodInfo FindMethod(Type type, string name, Type[] types)
		{
			return null;
		}

		public static PropertyInfo FindProperty(Type type, string name)
		{
			return null;
		}

		private static ExtendTypeData CreateNativeTypeData(Type type, IntPtr nativeType)
		{
			return default(ExtendTypeData);
		}

		private static bool IsIndexerProperty(PropertyInfo p)
		{
			return false;
		}

		private static bool HasTypeConverter(PropertyInfo p)
		{
			return false;
		}

		private static bool IsDependencyProperty(Type type, PropertyInfo prop)
		{
			return false;
		}

		private static IntPtr CreateNativePropsData(Type type, PropertyInfo[] props, NativeTypeInfo info, out int numProps)
		{
			numProps = default(int);
			return (IntPtr)0;
		}

		private static IntPtr CreateNativeEnumsData(Type type, out int numEnums)
		{
			numEnums = default(int);
			return (IntPtr)0;
		}

		public static IntPtr EnsureNativeType(Type type)
		{
			return (IntPtr)0;
		}

		public static IntPtr EnsureNativeType(Type type, bool registerDP)
		{
			return (IntPtr)0;
		}

		private static void RegisterDependencyProperties(Type type)
		{
		}

		private static bool HasDependencyProperties(Type type)
		{
			return false;
		}

		private static void RunClassConstructor(Type type)
		{
		}

		private static MethodInfo FindExtendMethod(Type type)
		{
			return null;
		}

		private static MethodInfo GetExtendMethod(Type type)
		{
			return null;
		}

		[MonoPInvokeCallback(typeof(Callback_FreeString))]
		private static void FreeString(IntPtr strPtr)
		{
		}

		public static string StringFromNativeUtf8(IntPtr nativeUtf8)
		{
			return null;
		}

		[MonoPInvokeCallback(typeof(Callback_RegisterType))]
		private static void RegisterType(string typeName)
		{
		}

		public static Type FindType(string name)
		{
			return null;
		}

		private static void AddLoadedAssembly(object sender, AssemblyLoadEventArgs e)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_ToString))]
		private static IntPtr ToStringEx(IntPtr cPtr)
		{
			return (IntPtr)0;
		}

		[MonoPInvokeCallback(typeof(Callback_Equals))]
		private static bool EqualsEx(IntPtr cPtr, IntPtr cPtrOtherType, IntPtr cPtrOther)
		{
			return false;
		}

		[MonoPInvokeCallback(typeof(Callback_VisualChildrenCount))]
		private static int VisualChildrenCount(IntPtr cPtr, Visual.ChildrenCountBaseCallback callback)
		{
			return 0;
		}

		[MonoPInvokeCallback(typeof(Callback_VisualGetChild))]
		private static IntPtr VisualGetChild(IntPtr cPtr, int index, Visual.ChildrenCountBaseCallback countCallback, Visual.GetChildBaseCallback childCallback)
		{
			return (IntPtr)0;
		}

		[MonoPInvokeCallback(typeof(Callback_UIElementRender))]
		private static void UIElementRender(IntPtr cPtr, IntPtr contextType, IntPtr context, UIElement.RenderBaseCallback callback)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_FrameworkElementConnectEvent))]
		private static bool FrameworkElementConnectEvent(IntPtr cPtr, IntPtr cPtrSourceType, IntPtr cPtrSource, string eventName, string handlerName)
		{
			return false;
		}

		[MonoPInvokeCallback(typeof(Callback_FrameworkElementMeasure))]
		private static void FrameworkElementMeasure(IntPtr cPtr, ref Size availableSize, ref Size desiredSize, FrameworkElement.LayoutBaseCallback callback)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_FrameworkElementArrange))]
		private static void FrameworkElementArrange(IntPtr cPtr, ref Size finalSize, ref Size renderSize, FrameworkElement.LayoutBaseCallback callback)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_FrameworkElementApplyTemplate))]
		private static void FrameworkElementApplyTemplate(IntPtr cPtr)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_ItemsControlGetContainer))]
		private static IntPtr ItemsControlGetContainer(IntPtr cPtr, ItemsControl.GetContainerForItemBaseCallback callback)
		{
			return (IntPtr)0;
		}

		[MonoPInvokeCallback(typeof(Callback_ItemsControlIsContainer))]
		private static bool ItemsControlIsContainer(IntPtr cPtr, IntPtr itemTypePtr, IntPtr itemPtr, ItemsControl.IsItemItsOwnContainerBaseCallback callback)
		{
			return false;
		}

		[MonoPInvokeCallback(typeof(Callback_AdornerGetTransform))]
		private static void AdornerGetTransform(IntPtr cPtr, ref Matrix4 transform, ref Matrix4 desiredTransform)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_FreezableClone))]
		private static void FreezableClone(IntPtr cPtrType, IntPtr cPtrClone, IntPtr cPtrSource)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_CommandCanExecute))]
		private static bool CommandCanExecute(IntPtr cPtr, IntPtr paramType, IntPtr paramPtr)
		{
			return false;
		}

		[MonoPInvokeCallback(typeof(Callback_CommandExecute))]
		private static void CommandExecute(IntPtr cPtr, IntPtr paramType, IntPtr paramPtr)
		{
		}

		private static bool IsNullableType(Type type)
		{
			return false;
		}

		private static bool AreCompatibleTypes(object source, Type targetType)
		{
			return false;
		}

		[MonoPInvokeCallback(typeof(Callback_ConverterConvert))]
		private static bool ConverterConvert(IntPtr cPtr, IntPtr valType, IntPtr valPtr, IntPtr targetTypePtr, IntPtr paramType, IntPtr paramPtr, out IntPtr result)
		{
			result = default(IntPtr);
			return false;
		}

		[MonoPInvokeCallback(typeof(Callback_ConverterConvertBack))]
		private static bool ConverterConvertBack(IntPtr cPtr, IntPtr valType, IntPtr valPtr, IntPtr targetTypePtr, IntPtr paramType, IntPtr paramPtr, out IntPtr result)
		{
			result = default(IntPtr);
			return false;
		}

		[MonoPInvokeCallback(typeof(Callback_MultiConverterConvert))]
		private static bool MultiConverterConvert(IntPtr cPtr, int numSources, IntPtr valTypes, IntPtr valPtrs, IntPtr targetTypePtr, IntPtr paramType, IntPtr paramPtr, out IntPtr result)
		{
			result = default(IntPtr);
			return false;
		}

		[MonoPInvokeCallback(typeof(Callback_MultiConverterConvertBack))]
		private static bool MultiConverterConvertBack(IntPtr cPtr, int numSources, IntPtr valType, IntPtr valPtr, IntPtr targetTypePtrs, IntPtr paramType, IntPtr paramPtr, IntPtr results)
		{
			return false;
		}

		[MonoPInvokeCallback(typeof(Callback_ListCount))]
		private static uint ListCount(IntPtr cPtr)
		{
			return 0u;
		}

		[MonoPInvokeCallback(typeof(Callback_ListGet))]
		private static IntPtr ListGet(IntPtr cPtr, uint index)
		{
			return (IntPtr)0;
		}

		[MonoPInvokeCallback(typeof(Callback_ListSet))]
		private static void ListSet(IntPtr cPtr, uint index, IntPtr itemType, IntPtr item)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_ListAdd))]
		private static uint ListAdd(IntPtr cPtr, IntPtr itemType, IntPtr item)
		{
			return 0u;
		}

		[MonoPInvokeCallback(typeof(Callback_ListIndexOf))]
		private static int ListIndexOf(IntPtr cPtr, IntPtr itemType, IntPtr item)
		{
			return 0;
		}

		[MonoPInvokeCallback(typeof(Callback_DictionaryFind))]
		private static bool DictionaryFind(IntPtr cPtr, string key, ref IntPtr item)
		{
			return false;
		}

		[MonoPInvokeCallback(typeof(Callback_DictionarySet))]
		private static void DictionarySet(IntPtr cPtr, string key, IntPtr itemType, IntPtr item)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_DictionaryAdd))]
		private static void DictionaryAdd(IntPtr cPtr, string key, IntPtr itemType, IntPtr item)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_ListIndexerTryGet))]
		private static bool ListIndexerTryGet(IntPtr cPtrType, IntPtr cPtr, uint index, ref IntPtr item)
		{
			return false;
		}

		[MonoPInvokeCallback(typeof(Callback_ListIndexerTrySet))]
		private static bool ListIndexerTrySet(IntPtr cPtrType, IntPtr cPtr, uint index, IntPtr itemType, IntPtr item)
		{
			return false;
		}

		[MonoPInvokeCallback(typeof(Callback_DictionaryIndexerTryGet))]
		private static bool DictionaryIndexerTryGet(IntPtr cPtrType, IntPtr cPtr, string key, ref IntPtr item)
		{
			return false;
		}

		[MonoPInvokeCallback(typeof(Callback_DictionaryIndexerTrySet))]
		private static bool DictionaryIndexerTrySet(IntPtr cPtrType, IntPtr cPtr, string key, IntPtr itemType, IntPtr item)
		{
			return false;
		}

		[MonoPInvokeCallback(typeof(Callback_SelectTemplate))]
		private static IntPtr SelectTemplate(IntPtr cPtr, IntPtr itemType, IntPtr item, IntPtr containerType, IntPtr container)
		{
			return (IntPtr)0;
		}

		[MonoPInvokeCallback(typeof(Callback_StreamSetPosition))]
		private static void StreamSetPosition(IntPtr cPtr, uint pos)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_StreamGetPosition))]
		private static uint StreamGetPosition(IntPtr cPtr)
		{
			return 0u;
		}

		[MonoPInvokeCallback(typeof(Callback_StreamGetLength))]
		private static uint StreamGetLength(IntPtr cPtr)
		{
			return 0u;
		}

		[MonoPInvokeCallback(typeof(Callback_StreamRead))]
		private static uint StreamRead(IntPtr cPtr, IntPtr buffer, uint bufferSize)
		{
			return 0u;
		}

		[MonoPInvokeCallback(typeof(Callback_StreamClose))]
		private static void StreamClose(IntPtr cPtr)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_ProviderLoadXaml))]
		private static IntPtr ProviderLoadXaml(IntPtr cPtr, IntPtr filename)
		{
			return (IntPtr)0;
		}

		[MonoPInvokeCallback(typeof(Callback_ProviderTextureInfo))]
		private static void ProviderTextureInfo(IntPtr cPtr, IntPtr filename, ref uint width, ref uint height)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_ProviderTextureLoad))]
		private static IntPtr ProviderTextureLoad(IntPtr cPtr, IntPtr filename)
		{
			return (IntPtr)0;
		}

		[MonoPInvokeCallback(typeof(Callback_ProviderTextureOpen))]
		private static IntPtr ProviderTextureOpen(IntPtr cPtr, IntPtr filename)
		{
			return (IntPtr)0;
		}

		[MonoPInvokeCallback(typeof(Callback_ProviderMatchFont))]
		private static IntPtr ProviderMatchFont(IntPtr cPtr, IntPtr baseUri, IntPtr familyName, ref int weight, ref int stretch, ref int style, ref uint index)
		{
			return (IntPtr)0;
		}

		[MonoPInvokeCallback(typeof(Callback_ProviderFamilyExists))]
		private static bool ProviderFamilyExists(IntPtr cPtr, IntPtr baseUri, IntPtr familyName)
		{
			return false;
		}

		[MonoPInvokeCallback(typeof(Callback_ProviderScanFolder))]
		private static void ProviderScanFolder(IntPtr cPtr, IntPtr folder)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_ProviderOpenFont))]
		private static IntPtr ProviderOpenFont(IntPtr cPtr, IntPtr folder, IntPtr filename)
		{
			return (IntPtr)0;
		}

		[MonoPInvokeCallback(typeof(Callback_ScrollInfoBringIntoView))]
		private static void ScrollInfoBringIntoView(IntPtr cPtr, int index)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_ScrollInfoGetCanHorizontalScroll))]
		private static bool ScrollInfoGetCanHorizontalScroll(IntPtr cPtr)
		{
			return false;
		}

		[MonoPInvokeCallback(typeof(Callback_ScrollInfoSetCanHorizontalScroll))]
		private static void ScrollInfoSetCanHorizontalScroll(IntPtr cPtr, bool canScroll)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_ScrollInfoGetCanVerticalScroll))]
		private static bool ScrollInfoGetCanVerticalScroll(IntPtr cPtr)
		{
			return false;
		}

		[MonoPInvokeCallback(typeof(Callback_ScrollInfoSetCanVerticalScroll))]
		private static void ScrollInfoSetCanVerticalScroll(IntPtr cPtr, bool canScroll)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_ScrollInfoGetExtentWidth))]
		private static float ScrollInfoGetExtentWidth(IntPtr cPtr)
		{
			return 0f;
		}

		[MonoPInvokeCallback(typeof(Callback_ScrollInfoGetExtentHeight))]
		private static float ScrollInfoGetExtentHeight(IntPtr cPtr)
		{
			return 0f;
		}

		[MonoPInvokeCallback(typeof(Callback_ScrollInfoGetViewportWidth))]
		private static float ScrollInfoGetViewportWidth(IntPtr cPtr)
		{
			return 0f;
		}

		[MonoPInvokeCallback(typeof(Callback_ScrollInfoGetViewportHeight))]
		private static float ScrollInfoGetViewportHeight(IntPtr cPtr)
		{
			return 0f;
		}

		[MonoPInvokeCallback(typeof(Callback_ScrollInfoGetHorizontalOffset))]
		private static float ScrollInfoGetHorizontalOffset(IntPtr cPtr)
		{
			return 0f;
		}

		[MonoPInvokeCallback(typeof(Callback_ScrollInfoGetVerticalOffset))]
		private static float ScrollInfoGetVerticalOffset(IntPtr cPtr)
		{
			return 0f;
		}

		[MonoPInvokeCallback(typeof(Callback_ScrollInfoGetScrollOwner))]
		private static IntPtr ScrollInfoGetScrollOwner(IntPtr cPtr)
		{
			return (IntPtr)0;
		}

		[MonoPInvokeCallback(typeof(Callback_ScrollInfoSetScrollOwner))]
		private static void ScrollInfoSetScrollOwner(IntPtr cPtr, IntPtr typeOwner, IntPtr cPtrOwner)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_ScrollInfoLineLeft))]
		private static void ScrollInfoLineLeft(IntPtr cPtr)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_ScrollInfoLineRight))]
		private static void ScrollInfoLineRight(IntPtr cPtr)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_ScrollInfoLineUp))]
		private static void ScrollInfoLineUp(IntPtr cPtr)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_ScrollInfoLineDown))]
		private static void ScrollInfoLineDown(IntPtr cPtr)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_ScrollInfoPageLeft))]
		private static void ScrollInfoPageLeft(IntPtr cPtr)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_ScrollInfoPageRight))]
		private static void ScrollInfoPageRight(IntPtr cPtr)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_ScrollInfoPageUp))]
		private static void ScrollInfoPageUp(IntPtr cPtr)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_ScrollInfoPageDown))]
		private static void ScrollInfoPageDown(IntPtr cPtr)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_ScrollInfoMouseWheelLeft))]
		private static void ScrollInfoMouseWheelLeft(IntPtr cPtr, float delta)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_ScrollInfoMouseWheelRight))]
		private static void ScrollInfoMouseWheelRight(IntPtr cPtr, float delta)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_ScrollInfoMouseWheelUp))]
		private static void ScrollInfoMouseWheelUp(IntPtr cPtr, float delta)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_ScrollInfoMouseWheelDown))]
		private static void ScrollInfoMouseWheelDown(IntPtr cPtr, float delta)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_ScrollInfoSetHorizontalOffset))]
		private static void ScrollInfoSetHorizontalOffset(IntPtr cPtr, float offset)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_ScrollInfoSetVerticalOffset))]
		private static void ScrollInfoSetVerticalOffset(IntPtr cPtr, float offset)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_ScrollInfoMakeVisible))]
		private static void ScrollInfoMakeVisible(IntPtr cPtr, IntPtr visualType, IntPtr visualPtr, ref Rect rectangle, ref Rect result)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_MarkupExtensionProvideValue))]
		private static IntPtr MarkupExtensionProvideValue(IntPtr cPtr, IntPtr provider)
		{
			return (IntPtr)0;
		}

		internal static int GetNativePropertyType(Type type)
		{
			return 0;
		}

		private static PropertyAccessor GetProperty(IntPtr nativeType, int propertyIndex)
		{
			return null;
		}

		private static T GetPropertyValue<T>(PropertyAccessor prop, object instance)
		{
			return default(T);
		}

		private static T GetPropertyValueNullable<T>(PropertyAccessor prop, object instance, out bool isNull) where T : struct
		{
			isNull = default(bool);
			return default(T);
		}

		[MonoPInvokeCallback(typeof(Callback_GetPropertyValue_Bool))]
		private static bool GetPropertyValue_Bool(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref bool isNull)
		{
			return false;
		}

		[MonoPInvokeCallback(typeof(Callback_GetPropertyValue_Float))]
		private static float GetPropertyValue_Float(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref bool isNull)
		{
			return 0f;
		}

		[MonoPInvokeCallback(typeof(Callback_GetPropertyValue_Double))]
		private static double GetPropertyValue_Double(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref bool isNull)
		{
			return 0.0;
		}

		[MonoPInvokeCallback(typeof(Callback_GetPropertyValue_Int))]
		private static int GetPropertyValue_Int(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref bool isNull)
		{
			return 0;
		}

		[MonoPInvokeCallback(typeof(Callback_GetPropertyValue_UInt))]
		private static uint GetPropertyValue_UInt(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref bool isNull)
		{
			return 0u;
		}

		[MonoPInvokeCallback(typeof(Callback_GetPropertyValue_Short))]
		private static short GetPropertyValue_Short(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref bool isNull)
		{
			return 0;
		}

		[MonoPInvokeCallback(typeof(Callback_GetPropertyValue_UShort))]
		private static ushort GetPropertyValue_UShort(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref bool isNull)
		{
			return 0;
		}

		[MonoPInvokeCallback(typeof(Callback_GetPropertyValue_String))]
		private static IntPtr GetPropertyValue_String(IntPtr nativeType, int propertyIndex, IntPtr cPtr)
		{
			return (IntPtr)0;
		}

		[MonoPInvokeCallback(typeof(Callback_GetPropertyValue_Uri))]
		private static IntPtr GetPropertyValue_Uri(IntPtr nativeType, int propertyIndex, IntPtr cPtr)
		{
			return (IntPtr)0;
		}

		[MonoPInvokeCallback(typeof(Callback_GetPropertyValue_Color))]
		private static void GetPropertyValue_Color(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref Color value, ref bool isNull)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_GetPropertyValue_Point))]
		private static void GetPropertyValue_Point(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref Point value, ref bool isNull)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_GetPropertyValue_Rect))]
		private static void GetPropertyValue_Rect(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref Rect value, ref bool isNull)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_GetPropertyValue_Int32Rect))]
		private static void GetPropertyValue_Int32Rect(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref Int32Rect value, ref bool isNull)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_GetPropertyValue_Size))]
		private static void GetPropertyValue_Size(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref Size value, ref bool isNull)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_GetPropertyValue_Thickness))]
		private static void GetPropertyValue_Thickness(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref Thickness value, ref bool isNull)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_GetPropertyValue_CornerRadius))]
		private static void GetPropertyValue_CornerRadius(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref CornerRadius value, ref bool isNull)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_GetPropertyValue_TimeSpan))]
		private static void GetPropertyValue_TimeSpan(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref TimeSpanStruct value, ref bool isNull)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_GetPropertyValue_Duration))]
		private static void GetPropertyValue_Duration(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref Duration value, ref bool isNull)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_GetPropertyValue_KeyTime))]
		private static void GetPropertyValue_KeyTime(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref KeyTime value, ref bool isNull)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_GetPropertyValue_Type))]
		private static IntPtr GetPropertyValue_Type(IntPtr nativeType, int propertyIndex, IntPtr cPtr)
		{
			return (IntPtr)0;
		}

		[MonoPInvokeCallback(typeof(Callback_GetPropertyValue_BaseComponent))]
		private static IntPtr GetPropertyValue_BaseComponent(IntPtr nativeType, int propertyIndex, IntPtr cPtr)
		{
			return (IntPtr)0;
		}

		private static void SetPropertyValue<T>(PropertyAccessor prop, object instance, T value)
		{
		}

		private static void SetPropertyValueNullable<T>(PropertyAccessor prop, object instance, T value, bool isNull) where T : struct
		{
		}

		[MonoPInvokeCallback(typeof(Callback_SetPropertyValue_Bool))]
		private static void SetPropertyValue_Bool(IntPtr nativeType, int propertyIndex, IntPtr cPtr, bool val, bool isNull)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_SetPropertyValue_Float))]
		private static void SetPropertyValue_Float(IntPtr nativeType, int propertyIndex, IntPtr cPtr, float val, bool isNull)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_SetPropertyValue_Double))]
		private static void SetPropertyValue_Double(IntPtr nativeType, int propertyIndex, IntPtr cPtr, double val, bool isNull)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_SetPropertyValue_Int))]
		private static void SetPropertyValue_Int(IntPtr nativeType, int propertyIndex, IntPtr cPtr, int val, bool isNull)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_SetPropertyValue_UInt))]
		private static void SetPropertyValue_UInt(IntPtr nativeType, int propertyIndex, IntPtr cPtr, uint val, bool isNull)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_SetPropertyValue_Short))]
		private static void SetPropertyValue_Short(IntPtr nativeType, int propertyIndex, IntPtr cPtr, short val, bool isNull)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_SetPropertyValue_UShort))]
		private static void SetPropertyValue_UShort(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ushort val, bool isNull)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_SetPropertyValue_String))]
		private static void SetPropertyValue_String(IntPtr nativeType, int propertyIndex, IntPtr cPtr, IntPtr val)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_SetPropertyValue_Uri))]
		private static void SetPropertyValue_Uri(IntPtr nativeType, int propertyIndex, IntPtr cPtr, IntPtr val)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_SetPropertyValue_Color))]
		private static void SetPropertyValue_Color(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref Color val, bool isNull)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_SetPropertyValue_Point))]
		private static void SetPropertyValue_Point(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref Point val, bool isNull)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_SetPropertyValue_Rect))]
		private static void SetPropertyValue_Rect(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref Rect val, bool isNull)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_SetPropertyValue_Int32Rect))]
		private static void SetPropertyValue_Int32Rect(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref Int32Rect val, bool isNull)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_SetPropertyValue_Size))]
		private static void SetPropertyValue_Size(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref Size val, bool isNull)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_SetPropertyValue_Thickness))]
		private static void SetPropertyValue_Thickness(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref Thickness val, bool isNull)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_SetPropertyValue_CornerRadius))]
		private static void SetPropertyValue_CornerRadius(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref CornerRadius val, bool isNull)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_SetPropertyValue_TimeSpan))]
		private static void SetPropertyValue_TimeSpan(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref TimeSpanStruct val, bool isNull)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_SetPropertyValue_Duration))]
		private static void SetPropertyValue_Duration(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref Duration val, bool isNull)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_SetPropertyValue_KeyTime))]
		private static void SetPropertyValue_KeyTime(IntPtr nativeType, int propertyIndex, IntPtr cPtr, ref KeyTime val, bool isNull)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_SetPropertyValue_Type))]
		private static void SetPropertyValue_Type(IntPtr nativeType, int propertyIndex, IntPtr cPtr, IntPtr val)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_SetPropertyValue_BaseComponent))]
		private static void SetPropertyValue_BaseComponent(IntPtr nativeType, int propertyIndex, IntPtr cPtr, IntPtr valType, IntPtr val)
		{
		}

		public static bool NeedsCreateCPtr(Type extendType)
		{
			return false;
		}

		public static IntPtr GetCPtr(BaseComponent instance, Type extendType)
		{
			return (IntPtr)0;
		}

		public static IntPtr NewCPtr(Type type)
		{
			return (IntPtr)0;
		}

		[MonoPInvokeCallback(typeof(Callback_CreateInstance))]
		private static void CreateInstance(IntPtr nativeType, IntPtr cPtr)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_DeleteInstance))]
		private static void DeleteInstance(IntPtr cPtr)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_GrabInstance))]
		private static void GrabInstance(IntPtr cPtr, bool grab)
		{
		}

		public static bool IsGrabbed(object o)
		{
			return false;
		}

		public static void RegisterExtendInstance(BaseComponent instance)
		{
		}

		public static object GetExtendInstance(IntPtr cPtr)
		{
			return null;
		}

		public static object GetExtendInstance(IntPtr cPtr, bool ownMemory)
		{
			return null;
		}

		private static ExtendInfo GetExtendInfo(IntPtr cPtr)
		{
			return null;
		}

		private static void AddExtendInfo(IntPtr cPtr, object instance)
		{
		}

		private static void RemoveExtendInfo(IntPtr cPtr)
		{
		}

		private static void AddDestroyedExtends()
		{
		}

		private static BaseComponent GetProxyInstance(IntPtr cPtr, bool ownMemory, NativeTypeInfo info)
		{
			return null;
		}

		public static BaseComponent AddProxy(BaseComponent instance)
		{
			return null;
		}

		public static void RemoveProxy(IntPtr cPtr)
		{
		}

		public static HandleRef GetInstanceHandle(object instance)
		{
			return default(HandleRef);
		}

		private static IntPtr FindInstancePtr(object instance)
		{
			return (IntPtr)0;
		}

		private static IntPtr FindWeakInstancePtr(object instance)
		{
			return (IntPtr)0;
		}

		public static void AddPendingRelease(IntPtr cPtr)
		{
		}

		private static void ReleasePending()
		{
		}

		public static void Update()
		{
		}

		public static void RegisterInterfaces(object instance)
		{
		}

		private static void NotifyPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
		}

		private static void NotifyCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
		}

		private static void NotifyCanExecuteChanged(object sender, System.EventArgs e)
		{
		}

		private static Dictionary<Type, BoxDelegate> CreateBoxFunctions()
		{
			return null;
		}

		public static IntPtr Box(object val)
		{
			return (IntPtr)0;
		}

		private static IntPtr RegisterPendingRelease(IntPtr cPtr)
		{
			return (IntPtr)0;
		}

		private static Dictionary<Type, UnboxDelegate> CreateUnboxFunctions()
		{
			return null;
		}

		public static object Unbox(IntPtr cPtr, bool ownMemory, NativeTypeInfo info)
		{
			return null;
		}

		[PreserveSig]
		private static extern int Noesis_GetNativeTypes(IntPtr[] types, int capacity);

		[PreserveSig]
		private static extern IntPtr Noesis_RegisterEnumType(string typeName, int numEnums, IntPtr enumsData);

		[PreserveSig]
		private static extern void Noesis_FillExtendType(ref ExtendTypeData typeData, int numProps, IntPtr propsData);

		[PreserveSig]
		private static extern IntPtr Noesis_InstantiateExtend(IntPtr nativeType);

		[PreserveSig]
		private static extern void Noesis_LaunchPropertyChangedEvent(IntPtr nativeType, IntPtr cPtr, string propertyName);

		[PreserveSig]
		private static extern void Noesis_LaunchCollectionChangedEvent(IntPtr nativeType, IntPtr cPtr, int action, IntPtr newItem, IntPtr oldItem, int newIndex, int oldIndex);

		[PreserveSig]
		private static extern void Noesis_LaunchCanExecuteChangedEvent(IntPtr nativeType, IntPtr cPtr);

		[PreserveSig]
		private static extern void Noesis_EnableExtend(bool enable);

		[PreserveSig]
		private static extern void Noesis_ClearExtendTypes();

		[PreserveSig]
		private static extern void Noesis_RegisterReflectionCallbacks(Callback_FreeString callback_FreeString, Callback_RegisterType callback_RegisterType, Callback_ToString callback_ToString, Callback_Equals callback_Equals, Callback_VisualChildrenCount callback_VisualChildrenCount, Callback_VisualGetChild callback_VisualGetChild, Callback_UIElementRender callback_UIElementRender, Callback_FrameworkElementConnectEvent callback_FrameworkElementConnectEvent, Callback_FrameworkElementMeasure callback_FrameworkElementMeasure, Callback_FrameworkElementArrange callback_FrameworkElementArrange, Callback_FrameworkElementApplyTemplate callback_FrameworkElementApplyTemplate, Callback_ItemsControlGetContainer callback_ItemsControlGetContainer, Callback_ItemsControlIsContainer callback_ItemsControlIsContainer, Callback_AdornerGetTransform callback_AdornerGetTransform, Callback_FreezableClone callback_FreezableClone, Callback_CommandCanExecute callback_CommandCanExecute, Callback_CommandExecute callback_CommandExecute, Callback_ConverterConvert callback_ConverterConvert, Callback_ConverterConvertBack callback_ConverterConvertBack, Callback_MultiConverterConvert callback_MultiConverterConvert, Callback_MultiConverterConvertBack callback_MultiConverterConvertBack, Callback_ListCount callback_ListCount, Callback_ListGet callback_ListGet, Callback_ListSet callback_ListSet, Callback_ListAdd callback_ListAdd, Callback_ListIndexOf callback_ListIndexOf, Callback_DictionaryFind callback_DictionaryFind, Callback_DictionarySet callback_DictionarySet, Callback_DictionaryAdd callback_DictionaryAdd, Callback_ListIndexerTryGet callback_ListIndexerTryGet, Callback_ListIndexerTrySet callback_ListIndexerTrySet, Callback_DictionaryIndexerTryGet callback_DictionaryIndexerTryGet, Callback_DictionaryIndexerTrySet callback_DictionaryIndexerTrySet, Callback_SelectTemplate callback_SelectTemplate, Callback_StreamSetPosition callback_StreamSetPosition, Callback_StreamGetPosition callback_StreamGetPosition, Callback_StreamGetLength callback_StreamGetLength, Callback_StreamRead callback_StreamRead, Callback_StreamClose callback_StreamClose, Callback_ProviderLoadXaml callback_ProviderLoadXaml, Callback_ProviderTextureInfo callback_ProviderTextureInfo, Callback_ProviderTextureLoad callback_ProviderTextureLoad, Callback_ProviderTextureOpen callback_ProviderTextureOpen, Callback_ProviderMatchFont callback_ProviderMatchFont, Callback_ProviderFamilyExists callback_ProviderFamilyExists, Callback_ProviderScanFolder callback_ProviderScanFolder, Callback_ProviderOpenFont callback_ProviderOpenFont, Callback_ScrollInfoBringIntoView callback_ScrollInfoBringIntoView, Callback_ScrollInfoGetCanHorizontalScroll callback_ScrollInfoGetCanHorizontalScroll, Callback_ScrollInfoSetCanHorizontalScroll callback_ScrollInfoSetCanHorizontalScroll, Callback_ScrollInfoGetCanVerticalScroll callback_ScrollInfoGetCanVerticalScroll, Callback_ScrollInfoSetCanVerticalScroll callback_ScrollInfoSetCanVerticalScroll, Callback_ScrollInfoGetExtentWidth callback_ScrollInfoGetExtentWidth, Callback_ScrollInfoGetExtentHeight callback_ScrollInfoGetExtentHeigth, Callback_ScrollInfoGetViewportWidth callback_ScrollInfoGetViewportWidth, Callback_ScrollInfoGetViewportHeight callback_ScrollInfoGetViewportHeight, Callback_ScrollInfoGetHorizontalOffset callback_ScrollInfoGetHorizontalOffset, Callback_ScrollInfoGetVerticalOffset callback_ScrollInfoGetVerticalOffset, Callback_ScrollInfoGetScrollOwner callback_ScrollInfoGetScrollOwner, Callback_ScrollInfoSetScrollOwner callback_ScrollInfoSetScrollOwner, Callback_ScrollInfoLineLeft callback_ScrollInfoLineLeft, Callback_ScrollInfoLineRight callback_ScrollInfoLineRight, Callback_ScrollInfoLineUp callback_ScrollInfoLineUp, Callback_ScrollInfoLineDown callback_ScrollInfoLineDown, Callback_ScrollInfoPageLeft callback_ScrollInfoPageLeft, Callback_ScrollInfoPageRight callback_ScrollInfoPageRight, Callback_ScrollInfoPageUp callback_ScrollInfoPageUp, Callback_ScrollInfoPageDown callback_ScrollInfoPageDown, Callback_ScrollInfoMouseWheelLeft callback_ScrollInfoMouseWheelLeft, Callback_ScrollInfoMouseWheelRight callback_ScrollInfoMouseWheelRight, Callback_ScrollInfoMouseWheelUp callback_ScrollInfoMouseWheelUp, Callback_ScrollInfoMouseWheelDown callback_ScrollInfoMouseWheelDown, Callback_ScrollInfoSetHorizontalOffset callback_ScrollInfoSetHorizontalOffset, Callback_ScrollInfoSetVerticalOffset callback_ScrollInfoSetVerticalOffset, Callback_ScrollInfoMakeVisible callback_ScrollInfoMakeVisible, Callback_MarkupExtensionProvideValue callback_MarkupExtensionProvideValue, Callback_GetPropertyValue_Bool callback_GetPropertyValue_Bool, Callback_GetPropertyValue_Float callback_GetPropertyValue_Float, Callback_GetPropertyValue_Double callback_GetPropertyValue_Double, Callback_GetPropertyValue_Int callback_GetPropertyValue_Int, Callback_GetPropertyValue_UInt callback_GetPropertyValue_UInt, Callback_GetPropertyValue_Short callback_GetPropertyValue_Short, Callback_GetPropertyValue_UShort callback_GetPropertyValue_UShort, Callback_GetPropertyValue_String callback_GetPropertyValue_String, Callback_GetPropertyValue_Uri callback_GetPropertyValue_Uri, Callback_GetPropertyValue_Color callback_GetPropertyValue_Color, Callback_GetPropertyValue_Point callback_GetPropertyValue_Point, Callback_GetPropertyValue_Rect callback_GetPropertyValue_Rect, Callback_GetPropertyValue_Int32Rect callback_GetPropertyValue_Int32Rect, Callback_GetPropertyValue_Size callback_GetPropertyValue_Size, Callback_GetPropertyValue_Thickness callback_GetPropertyValue_Thickness, Callback_GetPropertyValue_CornerRadius callback_GetPropertyValue_CornerRadius, Callback_GetPropertyValue_TimeSpan callback_GetPropertyValue_TimeSpan, Callback_GetPropertyValue_Duration callback_GetPropertyValue_Duration, Callback_GetPropertyValue_KeyTime callback_GetPropertyValue_KeyTime, Callback_GetPropertyValue_Type callback_GetPropertyValue_Type, Callback_GetPropertyValue_BaseComponent callback_GetPropertyValue_BaseComponent, Callback_SetPropertyValue_Bool callback_SetPropertyValue_Bool, Callback_SetPropertyValue_Float callback_SetPropertyValue_Float, Callback_SetPropertyValue_Double callback_SetPropertyValue_Double, Callback_SetPropertyValue_Int callback_SetPropertyValue_Int, Callback_SetPropertyValue_UInt callback_SetPropertyValue_UInt, Callback_SetPropertyValue_Short callback_SetPropertyValue_Short, Callback_SetPropertyValue_UShort callback_SetPropertyValue_UShort, Callback_SetPropertyValue_String callback_SetPropertyValue_String, Callback_SetPropertyValue_Uri callback_SetPropertyValue_Uri, Callback_SetPropertyValue_Color callback_SetPropertyValue_Color, Callback_SetPropertyValue_Point callback_SetPropertyValue_Point, Callback_SetPropertyValue_Rect callback_SetPropertyValue_Rect, Callback_SetPropertyValue_Int32Rect callback_SetPropertyValue_Int32Rect, Callback_SetPropertyValue_Size callback_SetPropertyValue_Size, Callback_SetPropertyValue_Thickness callback_SetPropertyValue_Thickness, Callback_SetPropertyValue_CornerRadius callback_SetPropertyValue_CornerRadius, Callback_SetPropertyValue_TimeSpan callback_SetPropertyValue_TimeSpan, Callback_SetPropertyValue_Duration callback_SetPropertyValue_Duration, Callback_SetPropertyValue_KeyTime callback_SetPropertyValue_KeyTime, Callback_SetPropertyValue_Type callback_SetPropertyValue_Type, Callback_SetPropertyValue_BaseComponent callback_SetPropertyValue_BaseComponent, Callback_CreateInstance callback_CreateInstance, Callback_DeleteInstance callback_DeleteInstance, Callback_GrabInstance callback_GrabInstance);

		private static Dictionary<Type, AddPropertyDelegate> AddPropertyFunctions()
		{
			return null;
		}

		private static ExtendPropertyData AddProperty(NativeTypePropsInfo info, PropertyInfo p, bool usePropertyInfo)
		{
			return default(ExtendPropertyData);
		}

		private static void AddPropertyAccessor<PropertyT>(NativeTypePropsInfo info, PropertyInfo p, bool usePropertyInfo)
		{
		}

		private static void AddPropertyAccessorNullable<PropertyT>(NativeTypePropsInfo info, PropertyInfo p, bool usePropertyInfo)
		{
		}

		private static void AddPropertyAccessor<PropertyT, SourceT>(NativeTypePropsInfo info, PropertyInfo p, Func<SourceT, PropertyT> castTo, Func<PropertyT, SourceT> castFrom, bool usePropertyInfo)
		{
		}

		private static void AddPropertyAccessorNullable<PropertyT, SourceT>(NativeTypePropsInfo info, PropertyInfo p, Func<SourceT, PropertyT> castTo, Func<PropertyT, SourceT> castFrom, bool usePropertyInfo)
		{
		}

		private static void AddPropertyAccessor(NativeTypePropsInfo info, PropertyInfo p, Func<PropertyAccessor> creatorRW, Func<PropertyAccessor> creatorRO)
		{
		}

		private static IndexerAccessor CreateIndexerAccessor<IndexT>(PropertyInfo p)
		{
			return null;
		}

		private static ExtendPropertyData CreatePropertyData(PropertyInfo p, NativePropertyType extendType)
		{
			return default(ExtendPropertyData);
		}

		private static ExtendPropertyData CreatePropertyData(PropertyInfo p, NativePropertyType extendType, IntPtr propertyType)
		{
			return default(ExtendPropertyData);
		}
	}
}
