using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	[CreateAssetMenu(fileName = "Langs Settings", menuName = "Localization/Langs Settings")]
	public class Langs : ScriptableObject
	{
		public List<Locale> _langsDisabled = new List<Locale>();
	}
}
