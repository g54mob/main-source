using UnityEngine;

[CreateAssetMenu(fileName = "Character Model Definition", menuName = "Character Models/Definition")]
public class CharacterModelDefinition : ScriptableObject
{
	[SerializeField]
	private GameObject m_ModelPrefab;

	[SerializeField]
	private Avatar m_Avatar;

	public GameObject ModelPrefab => null;

	public Avatar Avatar => null;
}
