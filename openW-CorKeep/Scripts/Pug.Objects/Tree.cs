using System.Collections.Generic;
using UnityEngine;

public class Tree : EntityMonoBehaviour
{
	public List<SpriteRenderer> spritesToRandomlyOffsetSlightlyOnZ;

	private List<Vector3> defaultSpritePositions;

	public override void UpdateGraphicsFromObjectInfo(ObjectInfo info)
	{
		base.UpdateGraphicsFromObjectInfo(info);
		UpdateRandomOffsetOnSprites();
	}

	private void UpdateRandomOffsetOnSprites()
	{
		if (spritesToRandomlyOffsetSlightlyOnZ.Count > 0 && defaultSpritePositions == null)
		{
			defaultSpritePositions = new List<Vector3>();
			for (int i = 0; i < spritesToRandomlyOffsetSlightlyOnZ.Count; i++)
			{
				defaultSpritePositions.Add(spritesToRandomlyOffsetSlightlyOnZ[i].transform.localPosition);
			}
		}
		for (int j = 0; j < spritesToRandomlyOffsetSlightlyOnZ.Count; j++)
		{
			spritesToRandomlyOffsetSlightlyOnZ[j].transform.localPosition = new Vector3(defaultSpritePositions[j].x, defaultSpritePositions[j].y, defaultSpritePositions[j].z + Random.Range(-0.03f, 0.03f));
		}
	}
}
