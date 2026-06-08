using LaundryBear.PlatformServices;

namespace Platform.IO
{
	public struct ObjectLoadResult<T> : IStorageErrorable<ObjectLoadResult<T>>
	{
		public T content;

		public PlatformIOResult result;

		public ObjectLoadResult(PlatformIOResult result, T content)
		{
			this.result = result;
			this.content = content;
		}

		public static ObjectLoadResult<T> CreateSuccess(T content)
		{
			return new ObjectLoadResult<T>
			{
				content = content
			};
		}

		public static ObjectLoadResult<T> CreateError(StorageResult result, string errorDetails = null)
		{
			return CreateError(new PlatformIOResult(result, errorDetails));
		}

		public static ObjectLoadResult<T> CreateError(PlatformIOResult result)
		{
			return new ObjectLoadResult<T>
			{
				result = result
			};
		}

		public bool WasSuccessful()
		{
			return result.WasSuccessful();
		}

		public ObjectLoadResult<T> ThrowIfFailed()
		{
			result.ThrowIfFailed();
			return this;
		}

		public ObjectLoadResult<T> LogErrorIfFailed()
		{
			result.LogIfErrored();
			return this;
		}

		public override string ToString()
		{
			return result.ToString();
		}
	}
}
