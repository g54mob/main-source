using Pug.UnityExtensions;

public class WallExplosiveBlock : EntityMonoBehaviour
{
	private TimerSimple _wobbleTimer = new TimerSimple(2f);

	private readonly float[] _flashTimings = new float[12]
	{
		0f, 0.5f, 1f, 1.25f, 1.5f, 1.75f, 2f, 2.1f, 2.2f, 2.3f,
		2.4f, 2.5f
	};

	private int _flashIndex;

	private bool m_wasActivated;

	public override void OnOccupied()
	{
		base.OnOccupied();
		_flashIndex = 0;
		_wobbleTimer.Start();
		m_wasActivated = false;
		Wobble();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		Wobble();
	}

	private void Wobble()
	{
		if (!base.isHidden && (float)currentHealth < (float)GetMaxHealth())
		{
			if (!m_wasActivated)
			{
				AudioManager.Sfx(SfxTableID.explodingWallBlockDamage, base.RenderPosition, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: true);
				AudioManager.Sfx(SfxTableID.explodingWallBlockCountDown, base.RenderPosition, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: true);
				m_wasActivated = true;
				Manager.effects.PlayPuff(PuffID.Parry, base.transform.position, 1);
				Manager.effects.PlayPuff(PuffID.Sparks, base.transform.position, 30);
			}
			if (_flashIndex < _flashTimings.Length && _wobbleTimer.elapsedTime > _flashTimings[_flashIndex])
			{
				Manager.effects.WobbleAtPosition(base.RenderPosition.RoundToInt(), 1f, isGround: false, flashRed: true);
				AudioManager.SfxFollowTransform(SfxTableID.explodingWallBlockWobble, base.transform, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: true);
				_flashIndex++;
			}
		}
	}
}
