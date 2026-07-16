using UnityEngine;

public class NewUnlock : MonoBehaviour
{
	public Sprite Icon { get; private set; }

	public string Name { get; private set; }

	public string Type { get; private set; }

	public Rarity Rarity { get; private set; }

	public Enhancement Enhancement { get; private set; }

	public NewUnlock(Sprite icon, string type, string name, Rarity rarity, Enhancement enh = null)
	{
		Icon = icon;
		Type = type;
		Name = name;
		Rarity = rarity;
		Enhancement = enh;
	}
}
