using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmuneZoneEmitter : EntityMonoBehaviour
{
	public RestrictedZoneEffect circularZone;

	public RestrictedZoneEffect rectangularZone;

	private bool isRectangular;

	private int offsetX;

	private int offsetY;

	private int zoneRadius;

	private int zoneWidth;

	private int zoneHeight;

	private bool _wasDestroyed;

	private List<AudioManager.RunningSfxReference> audioLoop;

	private static int LocalScaler(int value)
	{
		return value * 2 + 1;
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		circularZone.gameObject.SetActive(value: false);
		rectangularZone.gameObject.SetActive(value: false);
		if (EntityUtility.TryGetComponentData<ImmunityZoneCD>(base.entity, base.world, out var value) && !value.removeImmunityZone)
		{
			isRectangular = value.useRectangularBounds;
			offsetX = value.offset.x;
			offsetY = value.offset.y;
			RestrictedZoneEffect obj = (isRectangular ? rectangularZone : circularZone);
			obj.gameObject.SetActive(value: true);
			obj.Activate();
			float x = (isRectangular ? LocalScaler(value.rectangularWidth) : LocalScaler((int)value.radius));
			float z = (isRectangular ? LocalScaler(value.rectangularHeight) : LocalScaler((int)value.radius));
			obj.transform.localPosition = new Vector3(offsetX, 0.01f, offsetY);
			obj.transform.localScale = new Vector3(x, 0.1f, z);
			spriteObjects[0].gameObject.SetActive(value: true);
			spriteObjects[0].PlayAnimation(842569181);
			_wasDestroyed = false;
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (EntityUtility.TryGetComponentData<ImmunityZoneCD>(base.entity, base.world, out var value) && value.removeImmunityZone && !_wasDestroyed)
		{
			_wasDestroyed = true;
			AudioManager.Sfx(SfxTableID.coreBossOrbPowerDown, base.RenderPosition);
			StartCoroutine(EndSequence());
			spriteObjects[0].PlayAnimation(2039883312);
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.DirtBlockDust, base.transform.position, 2);
	}

	private IEnumerator EndSequence()
	{
		RestrictedZoneEffect[] array = new RestrictedZoneEffect[2] { circularZone, rectangularZone };
		foreach (RestrictedZoneEffect restrictedZoneEffect in array)
		{
			if (restrictedZoneEffect.gameObject.activeSelf)
			{
				restrictedZoneEffect.Kill(showRing: true);
			}
		}
		yield return new WaitForSeconds(circularZone.killWindupDuration);
		AudioManager.Sfx(SfxTableID.eventTerminalShockwave, base.RenderPosition);
		Manager.effects.PlayPuff(PuffID.Explosion_ImmuneZoneEmitter, base.RenderPosition, 1);
		spriteObjects[0].gameObject.SetActive(value: false);
	}

	protected override void OnShow()
	{
		if (audioLoop == null)
		{
			audioLoop = new List<AudioManager.RunningSfxReference>();
			AudioManager.Sfx(SfxTableID.ImmunityZoneEmitterAudioLoop, base.transform.position, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, audioLoop);
		}
		base.OnShow();
	}

	protected override void OnHide()
	{
		if (audioLoop != null)
		{
			foreach (AudioManager.RunningSfxReference item in audioLoop)
			{
				item.FadeOutAndStop();
			}
			audioLoop.Clear();
			audioLoop = null;
		}
		base.OnHide();
	}
}
