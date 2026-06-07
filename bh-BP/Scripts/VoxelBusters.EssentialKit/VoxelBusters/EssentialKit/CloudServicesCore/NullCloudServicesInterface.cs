using System;
using System.Collections;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.CloudServicesCore
{
	public class NullCloudServicesInterface : NativeCloudServicesInterfaceBase, INativeCloudServicesInterface, INativeFeatureInterface, INativeObject, IDisposable
	{
		public NullCloudServicesInterface()
			: base(isAvailable: false)
		{
		}

		private static void LogNotSupported()
		{
		}

		public override bool GetBool(string key)
		{
			return false;
		}

		public override long GetLong(string key)
		{
			return 0L;
		}

		public override double GetDouble(string key)
		{
			return 0.0;
		}

		public override string GetString(string key)
		{
			return null;
		}

		public override byte[] GetByteArray(string key)
		{
			return null;
		}

		public override bool HasKey(string key)
		{
			return false;
		}

		public override void SetBool(string key, bool value)
		{
		}

		public override void SetLong(string key, long value)
		{
		}

		public override void SetDouble(string key, double value)
		{
		}

		public override void SetString(string key, string value)
		{
		}

		public override void SetByteArray(string key, byte[] value)
		{
		}

		public override void RemoveKey(string key)
		{
		}

		public override void Synchronize(SynchronizeInternalCallback callback)
		{
		}

		public override IDictionary GetSnapshot()
		{
			return null;
		}
	}
}
