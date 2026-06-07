using System;
using System.Collections;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.CloudServicesCore
{
	public interface INativeCloudServicesInterface : INativeFeatureInterface, INativeObject, IDisposable
	{
		event UserChangeInternalCallback OnUserChange;

		event SavedDataChangeInternalCallback OnSavedDataChange;

		bool GetBool(string key);

		long GetLong(string key);

		double GetDouble(string key);

		string GetString(string key);

		byte[] GetByteArray(string key);

		bool HasKey(string key);

		void SetBool(string key, bool value);

		void SetLong(string key, long value);

		void SetDouble(string key, double value);

		void SetString(string key, string value);

		void SetByteArray(string key, byte[] value);

		void RemoveKey(string key);

		void Synchronize(SynchronizeInternalCallback callback);

		IDictionary GetSnapshot();
	}
}
