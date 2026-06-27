using System;
using FullSerializer;
using Restory.Data.ReadWriteServices;
using UnityEngine;

namespace Restory.Data.SaveLoad.FullSerializerWrappers
{
	public abstract class FullSerializerWrapperBase : IFullSerializer
	{
		protected readonly fsSerializer FsSerializer;

		protected FullSerializerWrapperBase()
		{
			FsSerializer = new fsSerializer();
		}

		public string ToJson(object value, Action onFailed = null)
		{
			string result = string.Empty;
			try
			{
				FsSerializer.TrySerialize(value, out var data).AssertSuccessWithoutWarnings();
				result = fsJsonPrinter.CompressedJson(data);
			}
			catch (Exception exception)
			{
				onFailed?.Invoke();
				Debug.LogException(exception);
			}
			return result;
		}

		public string ToPrettyJson(object value)
		{
			FsSerializer.TrySerialize(value, out var data).AssertSuccessWithoutWarnings();
			return fsJsonPrinter.PrettyJson(data);
		}

		public T FromJson<T>(string serializedState, FileType fileType, Action<FileType> onFailedCallback = null) where T : class
		{
			try
			{
				return FromJsonUnsafe<T>(serializedState);
			}
			catch (Exception ex)
			{
				int num = serializedState?.Length ?? 0;
				Debug.LogException(new Exception("Deserialization failed." + $" FileType={fileType}, TargetType={typeof(T).Name}, len={num}, {ex}"));
				onFailedCallback?.Invoke(fileType);
				return null;
			}
		}

		public T FromJsonUnsafe<T>(string serializedState) where T : class
		{
			fsData data = fsJsonParser.Parse(serializedState);
			T instance = null;
			FsSerializer.TryDeserialize(data, ref instance).AssertSuccessWithoutWarnings();
			return instance;
		}
	}
}
