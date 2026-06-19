#define LOG_LEVEL_VERBOSE
using System;
using FullSerializerSave;

namespace TH20
{
	public abstract class MustCallDestroy : fsISerializationCallbacks
	{
		[DontSave]
		private bool _destroyCalled;

		[DontSave]
		private bool _hasBeenConstructed;

		protected MustCallDestroy()
		{
			_hasBeenConstructed = true;
		}

		~MustCallDestroy()
		{
			if (_hasBeenConstructed && (!_destroyCalled && ActuallyNeedsDestroyCalled()))
			{
				ReportError();
			}
		}

		public virtual void RestoreFromSave()
		{
			_hasBeenConstructed = true;
		}

		protected virtual bool ActuallyNeedsDestroyCalled()
		{
			return true;
		}

		private void ReportError()
		{
			string thisAsString = ToString();
			string thisTypeName = GetType().FullName;
			ThreadingUtils.EnqueueActionForMainThreadOrRunRightNow(delegate
			{
				Logging.Error(LogChannels.Debug, "Destroy hasn't been called on {0}: {1}", thisTypeName, thisAsString);
			});
		}

		public virtual void Destroy()
		{
			_destroyCalled = true;
		}

		public bool HasBeenDestroyed()
		{
			return _destroyCalled;
		}

		void fsISerializationCallbacks.OnBeforeSerializeInstance(Type storageType)
		{
			if (_destroyCalled)
			{
				Logging.Error(LogChannels.SaveDebug, "Saving an object that has been destroyed: {0}: {1}", GetType().FullName, ToString());
			}
		}

		void fsISerializationCallbacks.OnBeforeSerialize(Type storageType)
		{
		}

		void fsISerializationCallbacks.OnAfterSerialize(Type storageType, ref fsData data)
		{
		}

		void fsISerializationCallbacks.OnAfterSerializeInstance(Type storageType, ref fsData data)
		{
		}

		void fsISerializationCallbacks.OnBeforeDeserialize(Type storageType, ref fsData data)
		{
		}

		void fsISerializationCallbacks.OnAfterDeserialize(Type storageType)
		{
		}

		void fsISerializationCallbacks.OnAfterDeserializeInstance(Type storageType)
		{
		}
	}
}
