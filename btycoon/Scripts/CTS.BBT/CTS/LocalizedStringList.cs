using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	[CreateAssetMenu(menuName = "CTS/Localized String List")]
	public class LocalizedStringList : ScriptableObject
	{
		[field: SerializeField]
		public LocalizedString[] Strings { get; private set; }
	}
}
