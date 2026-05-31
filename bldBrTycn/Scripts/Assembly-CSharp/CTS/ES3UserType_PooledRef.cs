using System;
using CTS.Core.Pooling;
using ES3Internal;
using ES3Types;
using UnityEngine;
using UnityEngine.Scripting;

namespace CTS
{
	[Preserve]
	public class ES3UserType_PooledRef : ES3GenericType
	{
		public override Type GetGenericType()
		{
			return typeof(PooledRef<>);
		}

		public override Type GetGenericES3Type()
		{
			return typeof(ES3UserType_PooledRef<>);
		}
	}
	[Preserve]
	public class ES3UserType_PooledRef<TObj> : ES3Type where TObj : MonoBehaviour, IPoolable
	{
		public ES3UserType_PooledRef(Type type)
			: base(type)
		{
		}

		public override void Write(object obj, ES3Writer writer)
		{
			PooledRef<TObj> pooledRef = (PooledRef<TObj>)obj;
			TObj value = (pooledRef.IsValid() ? pooledRef.Value : null);
			writer.WritePropertyByRef("Value", value);
		}

		public override object Read<T>(ES3Reader reader)
		{
			TObj poolable = null;
			while (true)
			{
				string text = reader.ReadPropertyName();
				if (text == null)
				{
					break;
				}
				if (text == "Value")
				{
					poolable = reader.Read<TObj>();
				}
				else
				{
					reader.Skip();
				}
			}
			return new PooledRef<TObj>(poolable);
		}
	}
}
