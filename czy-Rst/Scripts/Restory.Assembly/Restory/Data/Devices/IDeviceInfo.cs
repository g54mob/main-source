using System.Collections.Generic;
using Restory.Data.Elements;
using Restory.Data.Licenses;
using UnityEngine;

namespace Restory.Data.Devices
{
	public interface IDeviceInfo
	{
		string NameLocalizationKey { get; }

		IDeviceCategory Category { get; }

		LicenseInfo License { get; }

		IReadOnlyCollection<IElementInfo> Elements { get; }

		Color DefaultColor { get; }
	}
}
