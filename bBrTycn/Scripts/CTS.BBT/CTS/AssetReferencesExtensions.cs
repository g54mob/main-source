using System;
using System.Collections.Generic;
using CTS.Core.Utilities;
using ES3Internal;
using ES3Types;
using UnityEngine;

namespace CTS
{
	public static class AssetReferencesExtensions
	{
		public static void WriteAssetReference(this ES3Writer writer, string propName, UnityEngine.Object obj)
		{
			writer.WriteProperty(propName, AssetReferences.GetOrCreateReferenceId(obj), ES3Type_long.Instance);
		}

		public static TObject ReadAssetReference<TObject>(this ES3Reader reader) where TObject : UnityEngine.Object
		{
			return AssetReferences.GetReference<TObject>(reader.Read<long>());
		}

		public static UnityEngine.Object ReadAssetReference(this ES3Reader reader)
		{
			return AssetReferences.GetReference(reader.Read<long>());
		}

		public static void WriteList<T>(this ES3Writer writer, string key, IList<T> list, ES3.ReferenceMode refMode) where T : UnityEngine.Object
		{
			for (int i = 0; i < list.Count; i++)
			{
				writer.WriteProperty(key + i, list[i], refMode);
			}
		}

		public static void WriteList<T>(this ES3Writer writer, string key, ReadOnlyList<T> list, ES3.ReferenceMode refMode) where T : UnityEngine.Object
		{
			for (int i = 0; i < list.Count; i++)
			{
				writer.WriteProperty(key + i, list[i], refMode);
			}
		}

		public static bool TryReadIntoList<T>(this ES3Reader reader, string propertyName, string key, List<T> list) where T : UnityEngine.Object
		{
			if (propertyName.StartsWith(key) && int.TryParse(propertyName.Substring(key.Length, propertyName.Length - key.Length), out var result) && result.IsCorrectArrayIndex(list))
			{
				reader.ReadInto<T>(list[result]);
				return true;
			}
			return false;
		}

		public static bool TryReadIntoList<T>(this ES3Reader reader, string propertyName, string key, ReadOnlyList<T> list) where T : UnityEngine.Object
		{
			if (propertyName.StartsWith(key) && int.TryParse(propertyName.Substring(key.Length, propertyName.Length - key.Length), out var result) && IsCorrectArrayIndex(result, list))
			{
				reader.ReadInto<T>(list[result]);
				return true;
			}
			return false;
		}

		public static bool TryReadIntoArray<T>(this ES3Reader reader, string propertyName, string key, T[] list) where T : UnityEngine.Object
		{
			if (propertyName.StartsWith(key) && int.TryParse(propertyName.Substring(key.Length, propertyName.Length - key.Length), out var result) && result.IsCorrectArrayIndex(list))
			{
				reader.ReadInto<T>(list[result]);
				return true;
			}
			return false;
		}

		private static bool IsCorrectArrayIndex<T>(int index, ReadOnlyList<T> collection)
		{
			if (collection.Count <= 0)
			{
				return false;
			}
			return Math.Clamp(index, 0, Math.Max(0, collection.Count - 1)) == index;
		}

		public static object GetPrivateField(this ES3Writer writer, string name, object objectContainingField)
		{
			ES3Reflection.ES3ReflectedMember eS3ReflectedMember = ES3Reflection.GetES3ReflectedMember(objectContainingField.GetType(), name);
			if (eS3ReflectedMember.IsNull)
			{
				throw new MissingMemberException("A private field named " + name + " does not exist in the type " + objectContainingField.GetType());
			}
			return eS3ReflectedMember.GetValue(objectContainingField);
		}
	}
}
