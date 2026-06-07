using System;
using System.Collections;
using System.Runtime.CompilerServices;
using VoxelBusters.CoreLibrary;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.CloudServicesCore
{
	public abstract class NativeCloudServicesInterfaceBase : NativeFeatureInterfaceBase, INativeCloudServicesInterface, INativeFeatureInterface, INativeObject, IDisposable
	{
		public event UserChangeInternalCallback OnUserChange
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event SavedDataChangeInternalCallback OnSavedDataChange
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected NativeCloudServicesInterfaceBase(bool isAvailable)
			: base(isAvailable: false)
		{
		}

		public abstract bool GetBool(string key);

		public abstract long GetLong(string key);

		public abstract double GetDouble(string key);

		public abstract string GetString(string key);

		public abstract byte[] GetByteArray(string key);

		public abstract bool HasKey(string key);

		public abstract void SetBool(string key, bool value);

		public abstract void SetLong(string key, long value);

		public abstract void SetDouble(string key, double value);

		public abstract void SetString(string key, string value);

		public abstract void SetByteArray(string key, byte[] value);

		public abstract void RemoveKey(string key);

		public abstract void Synchronize(SynchronizeInternalCallback callback);

		public abstract IDictionary GetSnapshot();

		protected void SendUserChangeEvent(CloudUser user, Error error)
		{
		}

		protected void SendSavedDataChangeEvent(CloudSavedDataChangeReasonCode changeReason, string[] changedKeys)
		{
		}
	}
}
