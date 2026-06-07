using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Linq;

namespace Jundroo.ModTools.Serialization.Xml
{
	public abstract class UnityXmlAttributeSerializer<T> : IUnityXmlAttributeSerializer
	{
		private static char[] _collectionValuesSeparator = new char[1] { ',' };

		public virtual bool SupportsCollections => false;

		object IUnityXmlAttributeSerializer.ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return ReadValue(attribute, type, context);
		}

		public abstract T ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context);

		object IUnityXmlAttributeSerializer.ReadValues(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			if (!SupportsCollections)
			{
				throw new NotSupportedException();
			}
			return ReadValues(attribute, type, context);
		}

		public virtual IEnumerable<T> ReadValues(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			throw new NotImplementedException();
		}

		void IUnityXmlAttributeSerializer.WriteValue(XAttribute attribute, object value, UnityXmlSerializerContext context)
		{
			WriteValue(attribute, (T)value, context);
		}

		public abstract void WriteValue(XAttribute attribute, T value, UnityXmlSerializerContext context);

		void IUnityXmlAttributeSerializer.WriteValues(XAttribute attribute, object values, UnityXmlSerializerContext context)
		{
			if (!SupportsCollections)
			{
				throw new NotSupportedException();
			}
			WriteValues(attribute, (IEnumerable<T>)values, context);
		}

		public virtual void WriteValues(XAttribute attribute, IEnumerable<T> values, UnityXmlSerializerContext context)
		{
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = true;
			foreach (T value in values)
			{
				if (!flag)
				{
					stringBuilder.Append(',');
				}
				else
				{
					flag = false;
				}
				stringBuilder.Append(value);
			}
			attribute.SetValue(stringBuilder.ToString());
		}

		protected IEnumerable<TValue> ReadValues<TValue>(Func<string, IFormatProvider, TValue> convertType, XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			StringSplitOptions options = (((context.MemberSerializationOptions & XmlSerializationFlags.KeepEmptyEntries) != XmlSerializationFlags.KeepEmptyEntries) ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);
			string[] array = attribute.Value.Split(_collectionValuesSeparator, options);
			if (type.IsArray)
			{
				TValue[] array2 = new TValue[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array2[i] = convertType(array[i], CultureInfo.InvariantCulture);
				}
				return array2;
			}
			ICollection<TValue> collection = (ICollection<TValue>)Activator.CreateInstance(type);
			string[] array3 = array;
			foreach (string arg in array3)
			{
				collection.Add(convertType(arg, CultureInfo.InvariantCulture));
			}
			return collection;
		}
	}
}
