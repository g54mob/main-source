using Restory.Data.Devices;
using UnityEngine;

namespace Restory.Data.Elements
{
	public interface IElementInfo
	{
		Sprite Icon { get; }

		string NameLocalizationKey { get; }

		int MaxStackCount { get; }

		IDeviceInfo SourceDevice { get; set; }
	}
}
