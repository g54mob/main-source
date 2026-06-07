using System;
using System.Reflection;
using ModApi.Planet.Modifiers.Attributes;

namespace ModApi.Planet.Modifiers.VertexData
{
	public class DataSlotField
	{
		private FieldInfo _field;

		private object _instance;

		public DataSlotAttribute Attribute { get; private set; }

		public int DataIndex
		{
			get
			{
				return (int)_field.GetValue(_instance);
			}
			set
			{
				if (value >= -1 && value < 10)
				{
					_field.SetValue(_instance, value);
					return;
				}
				throw new ArgumentException($"Argument is out of range: {value}");
			}
		}

		public bool Visible { get; set; } = true;

		public DataSlotField(object instance, DataSlotAttribute dataSlotAttribute, FieldInfo field)
		{
			Attribute = dataSlotAttribute;
			_instance = instance;
			_field = field;
		}
	}
}
