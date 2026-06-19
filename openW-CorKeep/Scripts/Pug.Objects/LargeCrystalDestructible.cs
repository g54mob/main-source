#define PUG_RGB_ENABLED
using UnityEngine;

public class LargeCrystalDestructible : EntityMonoBehaviour
{
	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -1533413595)
		{
			Manager.effects.PlayPuff(PuffID.CrystalSolariteSmallDebris, base.transform.position + Vector3.up * 0.25f);
		}
		if (animID == -414722770)
		{
			Manager.rgb.TriggerEvent(RGBManager.Event.DestroyAncientDestructible);
		}
	}
}
