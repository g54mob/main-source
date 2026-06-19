using UnityEngine;

public class Trophy : EntityMonoBehaviour
{
	public SpriteRenderer mainRenderer;

	public SpriteRenderer SRShadow;

	public override void UpdateGraphicsFromObjectInfo(ObjectInfo info)
	{
		mainRenderer.sprite = info.icon;
		SRShadow.sprite = info.icon;
		base.UpdateGraphicsFromObjectInfo(info);
	}
}
