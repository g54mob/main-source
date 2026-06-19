#define PUG_RGB_ENABLED
using UnityEngine;

public class BossExplosion : PoolableSimple
{
	public Vector3 startPosition = Vector3.zero;

	public float randomOffsetModifier = 2f;

	public float scaleModifier = 1f;

	public override void OnOccupied()
	{
		base.OnOccupied();
		Vector3 vector = Random.insideUnitSphere * randomOffsetModifier;
		Vector3 vector2 = new Vector3(0f, 7f, -7f);
		if (startPosition != Vector3.zero)
		{
			base.transform.position = startPosition + vector + vector2;
		}
		else
		{
			base.transform.position += vector + vector2;
		}
		base.transform.localScale *= scaleModifier;
		AudioManager.SfxFollowTransform(SfxID.bomb2, base.transform, 0.2f, 1f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 50f);
		Manager.camera.ShakeCameraNow(0.1f, 2f, 2f);
		Manager.rgb.TriggerEvent(RGBManager.Event.BossKill);
	}
}
