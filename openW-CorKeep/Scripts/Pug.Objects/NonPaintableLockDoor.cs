using Pug.Sprite;
using UnityEngine;

public class NonPaintableLockDoor : LockedChest
{
	public SpriteObject doorHor;

	public SpriteObject doorVerTop;

	public SpriteObject doorVerSide;

	public GameObject shadowHor;

	public GameObject shadowVer;

	public override void OnOccupied()
	{
		base.OnOccupied();
		doorHor.gameObject.SetActive(value: false);
		doorVerTop.gameObject.SetActive(value: false);
		doorVerSide.gameObject.SetActive(value: false);
		if (shadowHor != null)
		{
			shadowHor.gameObject.SetActive(value: false);
		}
		if (shadowVer != null)
		{
			shadowVer.gameObject.SetActive(value: false);
		}
		switch (base.variation)
		{
		case 0:
			doorHor.gameObject.SetActive(value: true);
			doorHor.SetVariantByIndex(1);
			doorHor.ApplyVisualChange();
			if (shadowHor != null)
			{
				shadowHor.gameObject.SetActive(value: true);
			}
			break;
		case 2:
			doorVerTop.gameObject.SetActive(value: true);
			doorVerTop.SetVariantByIndex(2);
			doorVerTop.ApplyVisualChange();
			doorVerSide.gameObject.SetActive(value: true);
			doorVerSide.SetVariantByIndex(3);
			doorVerSide.ApplyVisualChange();
			if (shadowVer != null)
			{
				shadowVer.gameObject.SetActive(value: true);
			}
			break;
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
	}
}
