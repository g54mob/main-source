using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using TMPro;
using UnityEngine;

namespace Restory.UserInterface
{
	[CreateAssetMenu(menuName = "Restory/Localised Font Data", fileName = "LocalisedFontData")]
	public class LocalisedFontData : SerializedScriptableObject
	{
		[OdinSerialize]
		private Dictionary<SystemLanguage, TMP_FontAsset> fontsTMP = new Dictionary<SystemLanguage, TMP_FontAsset>();

		public IReadOnlyDictionary<SystemLanguage, TMP_FontAsset> FontsTMP => fontsTMP;
	}
}
