using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ES3Internal;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	public class ES3IListGenericType : ES3CollectionType
	{
		public ES3IListGenericType(Type type)
			: base(type)
		{
		}

		public ES3IListGenericType(Type type, ES3Type elementType)
			: base(type, elementType)
		{
		}

		public override void Write(object obj, ES3Writer writer, ES3.ReferenceMode memberReferenceMode)
		{
			if (obj == null)
			{
				writer.WriteNull();
				return;
			}
			IEnumerable<object> enumerable = (obj as IEnumerable).Cast<object>();
			if (elementType == null)
			{
				throw new ArgumentNullException("ES3Type argument cannot be null.");
			}
			int num = 0;
			foreach (object item in enumerable)
			{
				writer.StartWriteCollectionItem(num);
				writer.Write(item, elementType, memberReferenceMode);
				writer.EndWriteCollectionItem(num);
				num++;
			}
		}

		public override object Read<T>(ES3Reader reader)
		{
			return Read(reader);
		}

		public override void ReadInto<T>(ES3Reader reader, object obj)
		{
			ReadICollectionInto(reader, (ICollection)obj, elementType);
		}

		public override object Read(ES3Reader reader)
		{
			IList<object> list = ((IEnumerable)ES3Reflection.CreateInstance(type)).Cast<object>() as IList<object>;
			ES3Reflection.CreateInstance(ES3Reflection.MakeGenericType(type.GetGenericTypeDefinition(), elementType.type));
			if (reader.StartReadCollection())
			{
				return null;
			}
			while (reader.StartReadCollectionItem())
			{
				list.Add(reader.Read<object>(elementType));
				if (reader.EndReadCollectionItem())
				{
					break;
				}
			}
			reader.EndReadCollection();
			return list;
		}

		public override void ReadInto(ES3Reader reader, object obj)
		{
			IList list = (IList)obj;
			if (reader.StartReadCollection())
			{
				throw new NullReferenceException("The Collection we are trying to load is stored as null, which is not allowed when using ReadInto methods.");
			}
			int num = 0;
			foreach (object item in list)
			{
				num++;
				if (!reader.StartReadCollectionItem())
				{
					break;
				}
				reader.ReadInto<object>(item, elementType);
				if (reader.EndReadCollectionItem())
				{
					break;
				}
				if (num == list.Count)
				{
					throw new IndexOutOfRangeException("The collection we are loading is longer than the collection provided as a parameter.");
				}
			}
			if (num != list.Count)
			{
				throw new IndexOutOfRangeException("The collection we are loading is shorter than the collection provided as a parameter.");
			}
			reader.EndReadCollection();
		}
	}
}
