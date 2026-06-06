using UnityEngine;

public interface GUIItemSlot
{
	GameObject gameObject { get; }

	Transform transform { get; }

	void Initialize(ItemProperties itemProperties, int amout, bool showCounter = false);
}
