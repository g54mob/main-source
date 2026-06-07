using System;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace Kamgam.UIToolkitComponentsForSettings
{
	public static class UIElementTypes
	{
		public static VisualElement QueryType(this UIDocument document, UIElementType type, string name = null, string className = null, Predicate<VisualElement> predicate = null)
		{
			Type type2 = GetType(type);
			if (type2 != null)
			{
				return document.QueryType(type2, name, className, predicate);
			}
			return null;
		}

		public static VisualElement QueryType(this UIDocument document, Type type, string name = null, string className = null, Predicate<VisualElement> predicate = null)
		{
			if (document == null || document.rootVisualElement == null)
			{
				return null;
			}
			foreach (VisualElement item in document.rootVisualElement.Query<VisualElement>(name, className).Build())
			{
				if ((predicate == null || predicate(item)) && item.GetType() == type)
				{
					return item;
				}
			}
			return null;
		}

		public static List<VisualElement> QueryTypes(this UIDocument document, UIElementType type, string name = null, string className = null, List<VisualElement> list = null, Predicate<VisualElement> predicate = null)
		{
			Type type2 = GetType(type);
			if (type2 != null)
			{
				return document.QueryTypes(type2, name, className, list, predicate);
			}
			return list;
		}

		public static List<VisualElement> QueryTypes(this UIDocument document, Type type, string name = null, string className = null, List<VisualElement> list = null, Predicate<VisualElement> predicate = null)
		{
			if (list == null)
			{
				list = new List<VisualElement>();
			}
			list.Clear();
			if (document == null || document.rootVisualElement == null)
			{
				return list;
			}
			foreach (VisualElement item in document.rootVisualElement.Query<VisualElement>(name, className).Build())
			{
				if ((predicate == null || predicate(item)) && item.GetType() == type)
				{
					list.Add(item);
				}
			}
			return list;
		}

		public static Type GetType(UIElementType type)
		{
			return type switch
			{
				UIElementType.VisualElement => typeof(VisualElement), 
				UIElementType.BindableElement => typeof(BindableElement), 
				UIElementType.Button => typeof(Button), 
				UIElementType.Label => typeof(Label), 
				UIElementType.Scroller => typeof(Scroller), 
				UIElementType.TextField => typeof(TextField), 
				UIElementType.Foldout => typeof(Foldout), 
				UIElementType.Slider => typeof(Slider), 
				UIElementType.SliderInt => typeof(SliderInt), 
				UIElementType.DropdownField => typeof(DropdownField), 
				UIElementType.DropdownMenu => typeof(DropdownMenu), 
				_ => null, 
			};
		}
	}
}
