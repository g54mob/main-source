using System;

namespace VoxelBusters.EssentialKit
{
	public interface IDeepLinkServicesDelegate
	{
		bool CanHandleCustomSchemeUrl(Uri link);

		bool CanHandleUniversalLink(Uri link);
	}
}
