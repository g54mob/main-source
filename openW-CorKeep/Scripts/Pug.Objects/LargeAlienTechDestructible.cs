#define PUG_RGB_ENABLED
using UnityEngine;

public class LargeAlienTechDestructible : EntityMonoBehaviour
{
	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -1533413595)
		{
			Manager.effects.PlayPuff(PuffID.PotDebris, base.transform.position + Vector3.up * 0.25f, 8);
			Manager.effects.PlayPuff(PuffID.StoneBlockDebrisBox, base.transform.position + Vector3.up * 0.25f);
		}
		if (animID == -414722770)
		{
			Vector3 vector = center - Vector3.up * 0.25f;
			Vector3 vector2 = new Vector3(0f, 5f, -5f);
			Manager.effects.ExploDisc(vector + vector2 + Vector3.up * 0.25f, 0.8f);
			Manager.effects.PlayPuff(PuffID.SmallAncientEnergy, vector);
			Manager.effects.PlayPuff(PuffID.PotDebris, vector, 30);
			Manager.effects.PlayPuff(PuffID.StoneBlockDebrisBox, vector, 40);
			Manager.effects.PlayPuff(PuffID.AncientSparks, vector, 40);
			Manager.effects.PlayPuff(PuffID.AncientSmoke, vector, 80);
			Manager.effects.PlayPuff(PuffID.AncientFlashingSparks, vector, 4);
			Manager.rgb.TriggerEvent(RGBManager.Event.DestroyAncientDestructible);
		}
	}
}
