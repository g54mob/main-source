using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Restory.UserInterface
{
	[CreateAssetMenu(menuName = "Restory/Localised Sprite Data", fileName = "LocalisedSpriteData")]
	public class LocalisedSpriteData : SerializedScriptableObject
	{
		[OdinSerialize]
		private Dictionary<SystemLanguage, Sprite> sprites = new Dictionary<SystemLanguage, Sprite>();

		public IReadOnlyDictionary<SystemLanguage, Sprite> Sprites => sprites;
	}
}
