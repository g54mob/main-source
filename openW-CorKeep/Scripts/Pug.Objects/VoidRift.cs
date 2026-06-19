using UnityEngine;

public class VoidRift : EntityMonoBehaviour
{
	public Transform riftEffect;

	public float duration = 2f;

	public bool scalingDone;

	public AnimationCurve scaleCurve = AnimationCurve.Linear(0f, 0f, 1f, 5f);

	private float elapsedTime;

	public override void OnOccupied()
	{
		AudioManager.Sfx(SfxTableID.voidRiftSfx, base.transform.position, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, null, forceStackable: false, 3f);
		base.OnOccupied();
		scalingDone = false;
		elapsedTime = 0f;
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (!scalingDone)
		{
			elapsedTime += Time.deltaTime;
			float time = Mathf.Clamp01(elapsedTime / duration);
			float num = scaleCurve.Evaluate(time);
			riftEffect.localScale = Vector3.one * num;
			if (elapsedTime >= duration)
			{
				scalingDone = true;
				Manager.effects.PlayPuff(PuffID.VoidRiftDeath, base.transform.position, 1);
				AudioManager.Sfx(SfxTableID.voidBombExplode, base.transform.position, 0.5f);
			}
		}
	}
}
