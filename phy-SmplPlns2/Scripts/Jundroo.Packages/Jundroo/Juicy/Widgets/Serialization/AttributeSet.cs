using System;
using System.Collections.Generic;
using Jundroo.Juicy.Widgets.Extra;
using UnityEngine;
using UnityEngine.UI;

namespace Jundroo.Juicy.Widgets.Serialization
{
	public class AttributeSet
	{
		public Dictionary<string, Attribute> Attributes { get; private set; } = new Dictionary<string, Attribute>();

		public void AddAnimation<T>(string name, Action<T, AnimationData> setter) where T : class
		{
			AnimationAttribute<T> animationAttribute = new AnimationAttribute<T>(name);
			animationAttribute.Setter = setter;
			SetAttribute(name, animationAttribute);
		}

		public void AddBool<T>(string name, Action<T, bool> setter) where T : class
		{
			BoolAttribute<T> boolAttribute = new BoolAttribute<T>(name);
			boolAttribute.Setter = setter;
			SetAttribute(name, boolAttribute);
		}

		public void AddColor<T>(string name, Action<T, Color> setter, Func<T, Color> getter) where T : class
		{
			ColorAttribute<T> colorAttribute = new ColorAttribute<T>(name);
			colorAttribute.Getter = getter;
			colorAttribute.Setter = setter;
			SetAttribute(name, colorAttribute);
		}

		public void AddColorBlock<T>(string name, Action<T, ColorBlock> setter) where T : class
		{
			ColorBlockAttribute<T> colorBlockAttribute = new ColorBlockAttribute<T>(name);
			colorBlockAttribute.Setter = setter;
			SetAttribute(name, colorBlockAttribute);
		}

		public void AddEnum<T, TEnum>(string name, Action<T, TEnum> setter, bool combineList = false) where T : class where TEnum : Enum
		{
			EnumAttribute<T, TEnum> enumAttribute = new EnumAttribute<T, TEnum>(name);
			enumAttribute.Setter = setter;
			enumAttribute.CombineList = combineList;
			SetAttribute(name, enumAttribute);
		}

		public void AddFloat<T>(string name, Action<T, float> setter, Func<T, float> getter = null) where T : class
		{
			FloatAttribute<T> floatAttribute = new FloatAttribute<T>(name);
			floatAttribute.Setter = setter;
			floatAttribute.Getter = getter;
			SetAttribute(name, floatAttribute);
		}

		public void AddInt<T>(string name, Action<T, int> setter) where T : class
		{
			IntAttribute<T> intAttribute = new IntAttribute<T>(name);
			intAttribute.Setter = setter;
			SetAttribute(name, intAttribute);
		}

		public void AddRectOffset<T>(string name, Action<T, RectOffset> setter) where T : class
		{
			RectOffsetAttribute<T> rectOffsetAttribute = new RectOffsetAttribute<T>(name);
			rectOffsetAttribute.Setter = setter;
			SetAttribute(name, rectOffsetAttribute);
		}

		public void AddSound<T>(string name, Action<T, SoundData> setter) where T : class
		{
			SoundAttribute<T> soundAttribute = new SoundAttribute<T>(name);
			soundAttribute.Setter = setter;
			SetAttribute(name, soundAttribute);
		}

		public void AddString<T>(string name, Action<T, string> setter) where T : class
		{
			StringAttribute<T> stringAttribute = new StringAttribute<T>(name);
			stringAttribute.Setter = setter;
			SetAttribute(name, stringAttribute);
		}

		public void AddVector2<T>(string name, Action<T, Vector2> setter, Func<T, Vector2> getter = null) where T : class
		{
			Vector2Attribute<T> vector2Attribute = new Vector2Attribute<T>(name);
			vector2Attribute.Setter = setter;
			vector2Attribute.Getter = getter;
			SetAttribute(name, vector2Attribute);
		}

		public bool ApplyAttribute(Widget widget, string name, string value)
		{
			if (Attributes.TryGetValue(name, out var value2))
			{
				value2.Apply(widget, value);
				return true;
			}
			return false;
		}

		public void SetAttribute(string name, Attribute attribute)
		{
			Attributes[name] = attribute;
		}
	}
}
