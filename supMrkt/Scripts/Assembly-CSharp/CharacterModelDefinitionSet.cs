using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Model Definition Set", menuName = "Character Models/Set")]
public class CharacterModelDefinitionSet : ScriptableObject
{
	[SerializeField]
	private CharacterModelDefinition[] m_Definitions;

	public IReadOnlyList<CharacterModelDefinition> Definitions => null;
}
