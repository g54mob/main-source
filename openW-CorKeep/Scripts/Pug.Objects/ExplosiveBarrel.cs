using Pug.UnityExtensions;
using UnityEngine;

public class ExplosiveBarrel : EntityMonoBehaviour
{
	private TimerSimple _wobbleTimer = new TimerSimple(2f);

	private readonly float[] _flashTimings = new float[12]
	{
		0f, 0.5f, 1f, 1.25f, 1.5f, 1.75f, 2f, 2.1f, 2.2f, 2.3f,
		2.4f, 2.5f
	};

	private int _flashIndex;

	private bool _activated;

	public override void OnOccupied()
	{
		base.OnOccupied();
		if (EntityUtility.IsNewlyCreatedObject(base.entity, base.world))
		{
			_flashIndex = 0;
			_activated = false;
		}
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		if (animID == -1533413595)
		{
			_wobbleTimer.Start();
			WobbleOnce();
		}
		else
		{
			base.HandleAnimationTrigger(animID);
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (base.variation == 1 && _wobbleTimer.isRunning)
		{
			WobbleOnce();
		}
	}

	private void WobbleOnce()
	{
		if (!base.isHidden)
		{
			if (!_activated)
			{
				AudioManager.Sfx(SfxTableID.metalDamage, base.RenderPosition, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: true);
				_activated = true;
				Manager.effects.PlayPuff(PuffID.Parry, base.transform.position, 1);
			}
			if (_flashIndex < _flashTimings.Length && _wobbleTimer.elapsedTime >= _flashTimings[_flashIndex])
			{
				spriteObjects[0].PlayTransformAnimation(-1838420484);
				AudioManager.SfxFollowTransform(SfxTableID.explodingWallBlockWobble, base.transform, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: true);
				flashable.FlashLinearNoCurve(Color.red, 0.4f);
				_flashIndex++;
			}
			if (_flashIndex >= _flashTimings.Length)
			{
				_wobbleTimer.Stop();
			}
		}
	}
}
