using Pug.UnityExtensions;

public class WallDesertExplosiveBlock : EntityMonoBehaviour
{
	private TimerSimple _wobbleTimer = new TimerSimple(0.8f);

	private readonly float[] _flashTimings = new float[4] { 0f, 0.3f, 0.5f, 0.7f };

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
				AudioManager.Sfx(SfxTableID.explodingWallDesertBlockDamage, base.RenderPosition, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: true);
				AudioManager.Sfx(SfxTableID.explodingWallDesertBlockCountDown, base.RenderPosition, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: true);
				m_wasActivated = true;
				Manager.effects.PlayPuff(PuffID.Parry, base.transform.position, 1);
				Manager.effects.PlayPuff(PuffID.FireEmber, base.transform.position, 15);
			}
			if (_flashIndex < _flashTimings.Length && _wobbleTimer.elapsedTime > _flashTimings[_flashIndex])
			{
				Manager.effects.WobbleAtPosition(base.RenderPosition.RoundToInt(), 1f, isGround: false, flashRed: true);
				AudioManager.SfxFollowTransform(SfxTableID.explodingWallDesertBlockWobble, base.transform, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: true);
				_flashIndex++;
			}
		}
	}
}
