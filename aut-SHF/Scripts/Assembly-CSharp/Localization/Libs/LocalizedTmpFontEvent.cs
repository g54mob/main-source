using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

namespace Localization.Libs
{
	[AddComponentMenu("Localization/Asset/LocalizedTmpFontEvent")]
	public class LocalizedTmpFontEvent : LocalizedAssetEvent<TMP_FontAsset, LocalizedTmpFont, UnityEventTmpFont>
	{
	}
}
