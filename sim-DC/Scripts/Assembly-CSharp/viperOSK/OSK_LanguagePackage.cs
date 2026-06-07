using System.Collections.Generic;
using UnityEngine;

namespace viperOSK
{
	[CreateAssetMenu(fileName = "viperOSK_LanguagePackage", menuName = "ScriptableObjects/viperOSK_LanguagePackage", order = 1)]
	public class OSK_LanguagePackage : ScriptableObject
	{
		[SerializeField]
		[TextArea(15, 6)]
		public string keyboardLayout;

		[Space]
		[SerializeField]
		[TextArea(15, 6)]
		public string altKeyboardLayout;

		[Space]
		public OSK_AccentAssetObj accentPackage;

		[Space]
		[Tooltip("Culture codes in priority order, e.g., el, ru, hy, ar, en")]
		public List<string> cultures;

		[Header("Case & Canonicalization")]
		[Tooltip("Uppercase and lowercase use the same GLYPH slot")]
		public bool collapseCase;

		[Tooltip("Prefer lowercase as the stored representative when collapsing case")]
		public bool preferLowercase;

		[Tooltip("Map Greek final sigma (ς U+03C2) to σ U+03C3 so they share one glyph slot")]
		public bool unifyGreekFinalSigma;

		[Header("Letter Filtering")]
		[Tooltip("Include uppercase letters where applicable")]
		public bool includeUppercase;

		[Tooltip("Include lowercase letters where applicable")]
		public bool includeLowercase;

		[Header("Custom Ranges (Hex)")]
		[Tooltip("Extra ranges to include (e.g., FB50–FDFF for Arabic Presentation Forms)")]
		public List<HexRange> extraIncludeRanges;

		[Tooltip("Ranges to exclude (e.g., 1F00–1FFF to drop Greek Extended)")]
		public List<HexRange> excludeRanges;
	}
}
