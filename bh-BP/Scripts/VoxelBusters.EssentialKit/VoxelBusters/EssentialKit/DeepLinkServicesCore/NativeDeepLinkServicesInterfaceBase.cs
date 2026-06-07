using System;
using System.Runtime.CompilerServices;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.DeepLinkServicesCore
{
	public abstract class NativeDeepLinkServicesInterfaceBase : NativeFeatureInterfaceBase, INativeDeepLinkServicesInterface, INativeFeatureInterface, INativeObject, IDisposable
	{
		private CanHandleDynamicLinkInternal m_canHandleCustomSchemeUrl;

		private CanHandleDynamicLinkInternal m_canHandleUniversalLink;

		public event DynamicLinkOpenInternalCallback OnCustomSchemeUrlOpen
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

		public event DynamicLinkOpenInternalCallback OnUniversalLinkOpen
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

		protected NativeDeepLinkServicesInterfaceBase(bool isAvailable)
			: base(isAvailable: false)
		{
		}

		public void SetCanHandleCustomSchemeUrl(CanHandleDynamicLinkInternal handler)
		{
		}

		public void SetCanHandleUniversalLink(CanHandleDynamicLinkInternal handler)
		{
		}

		public abstract void Init();

		protected bool CanHandleCustomSchemeUrl(string url)
		{
			return false;
		}

		protected bool CanHandleUniversalLink(string url)
		{
			return false;
		}

		protected void SendCustomSchemeUrlOpenEvent(string url)
		{
		}

		protected void SendUniversalLinkOpenEvent(string url)
		{
		}
	}
}
