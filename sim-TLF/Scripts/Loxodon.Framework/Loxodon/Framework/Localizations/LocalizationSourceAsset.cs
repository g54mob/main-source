using UnityEngine;

namespace Loxodon.Framework.Localizations
{
	[CreateAssetMenu(fileName = "New Localization Module", menuName = "Loxodon/LocalizationSource", order = 1)]
	public class LocalizationSourceAsset : ScriptableObject
	{
		public MonolingualSource Source = new MonolingualSource();
	}
}
