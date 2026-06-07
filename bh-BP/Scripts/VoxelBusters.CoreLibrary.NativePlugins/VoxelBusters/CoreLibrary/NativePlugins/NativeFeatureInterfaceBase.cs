using System;

namespace VoxelBusters.CoreLibrary.NativePlugins
{
	public abstract class NativeFeatureInterfaceBase : NativeObjectBase, INativeFeatureInterface, INativeObject, IDisposable
	{
		public bool IsAvailable { get; private set; }

		protected NativeFeatureInterfaceBase(bool isAvailable, NativeObjectRef nativeObjectRef = null)
		{
		}

		~NativeFeatureInterfaceBase()
		{
		}
	}
}
