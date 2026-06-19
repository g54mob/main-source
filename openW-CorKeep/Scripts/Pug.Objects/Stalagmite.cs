using Pug.Sprite;
using Pug.UnityExtensions;
using UnityEngine;

public class Stalagmite : EntityMonoBehaviour
{
	public SpriteObject stalagmiteSpriteObject;

	public override void OnOccupied()
	{
		base.OnOccupied();
		if (base.variation == 7)
		{
			int hashCode = base.WorldPosition.GetHashCode();
			float num = PugRandom.Range(0f, 0.5f, hashCode);
			if (stalagmiteSpriteObject != null)
			{
				stalagmiteSpriteObject.emissiveColor = new Color(1f, 1f, 1f, 1f) * num;
			}
		}
	}
}
