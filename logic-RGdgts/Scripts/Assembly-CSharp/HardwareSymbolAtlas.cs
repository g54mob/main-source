using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu]
public class HardwareSymbolAtlas : SerializedScriptableObject
{
	public struct Symbol
	{
		public int id;

		public string name;

		public TurnableSprite caseSprite;

		public TurnableSprite cutterSprite;

		public TurnableSprite idleSprite;

		public TurnableSprite pressedSprite;
	}

	public TextAsset atlasTextAsset;

	public Dictionary<int, Symbol> symbols;

	public Dictionary<int, string> GetDataSelectionValues(bool addNoneValue)
	{
		return null;
	}

	public string GetDataSelectionName(int id)
	{
		return null;
	}
}
