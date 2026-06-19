using I2.Loc;
using UnityEngine;

[CreateAssetMenu(fileName = "GutFlora", menuName = "GutFlora", order = 1)]
public class GutFloraResource : ScriptableObject
{
	public string gutFloraName;

	public LocalizedString floraNameLocalized;

	public LocalizedString floraDescriptionLocalized;

	public Sprite gutFloraPreviewSprite;

	public GameObject gutFloraPrefab;

	public ItemSet associatedItemSet;
}
