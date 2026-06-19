using Pug.UnityExtensions;
using UnityEngine;

public class GlowingCoral : EntityMonoBehaviour
{
	protected override void EnableVariation(ObjectVariant objectVariant, uint seed)
	{
		base.EnableVariation(objectVariant, seed);
		foreach (GameObject item in objectVariant.objectsToEnable)
		{
			float y = PugRandom.Range(-2f, 0.25f, (int)seed);
			Transform obj = item.transform;
			Vector3 localPosition = obj.localPosition;
			obj.localPosition = new Vector3(localPosition.x, y, localPosition.z);
		}
		for (int i = 0; i < indirectLightEmitters.Count; i++)
		{
			Vector3 position = indirectLightEmitters[i].transform.position;
			position.y = 0.1f;
			indirectLightEmitters[i].transform.position = position;
		}
	}
}
