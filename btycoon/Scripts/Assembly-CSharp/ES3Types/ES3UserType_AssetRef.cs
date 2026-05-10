using System;
using CTS;
using ES3Internal;
using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	public class ES3UserType_AssetRef : ES3GenericType
	{
		public override Type GetGenericType()
		{
			return typeof(AssetRef<>);
		}

		public override Type GetGenericES3Type()
		{
			return typeof(ES3UserType_AssetRef<>);
		}
	}
	[Preserve]
	public class ES3UserType_AssetRef<TObj> : ES3Type where TObj : UnityEngine.Object
	{
		public ES3UserType_AssetRef(Type type)
			: base(type)
		{
		}

		public override void Write(object obj, ES3Writer writer)
		{
			writer.WriteAssetReference("Asset", ((AssetRef<TObj>)obj).Asset);
		}

		public override object Read<T>(ES3Reader reader)
		{
			AssetRef<TObj> assetRef = default(AssetRef<TObj>);
			while (true)
			{
				string text = reader.ReadPropertyName();
				if (text == null)
				{
					break;
				}
				if (text == "Asset")
				{
					assetRef = new AssetRef<TObj>(reader.ReadAssetReference<TObj>());
				}
				else
				{
					reader.Skip();
				}
			}
			return assetRef;
		}
	}
}
