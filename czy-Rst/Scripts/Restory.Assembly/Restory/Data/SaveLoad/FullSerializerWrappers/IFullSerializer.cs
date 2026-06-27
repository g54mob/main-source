using System;
using Restory.Data.ReadWriteServices;

namespace Restory.Data.SaveLoad.FullSerializerWrappers
{
	public interface IFullSerializer
	{
		string ToJson(object value, Action onFailed = null);

		string ToPrettyJson(object value);

		T FromJson<T>(string serializedState, FileType fileType, Action<FileType> onFailedCallback = null) where T : class;

		T FromJsonUnsafe<T>(string serializedState) where T : class;
	}
}
