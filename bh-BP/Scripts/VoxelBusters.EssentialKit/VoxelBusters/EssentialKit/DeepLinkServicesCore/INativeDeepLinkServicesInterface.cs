using System;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.DeepLinkServicesCore
{
	public interface INativeDeepLinkServicesInterface : INativeFeatureInterface, INativeObject, IDisposable
	{
		event DynamicLinkOpenInternalCallback OnCustomSchemeUrlOpen;

		event DynamicLinkOpenInternalCallback OnUniversalLinkOpen;

		void Init();

		void SetCanHandleCustomSchemeUrl(CanHandleDynamicLinkInternal handler);

		void SetCanHandleUniversalLink(CanHandleDynamicLinkInternal handler);
	}
}
