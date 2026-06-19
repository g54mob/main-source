using UnityEngine;

public class BombScarab : EntityMonoBehaviour
{
	private PoolableAudioSource audioLoop;

	public AnimationCurve movementBob;

	private float curveDeltaTime;

	private Vector3 defaultSpritePos;

	protected override bool updateAnimOrientation => true;

	protected override bool updateAnimMovement => true;

	protected override void Awake()
	{
		base.Awake();
		defaultSpritePos = spriteObjects[0].transform.localPosition;
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		StartAudioLoop();
		spriteObjects[0].transform.localScale = Vector3.one;
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (spriteObjects[0].currentAnimationHash == -281135240 || spriteObjects[0].currentAnimationHash == -601574123)
		{
			curveDeltaTime += Time.deltaTime * 2.5f;
			spriteObjects[0].transform.localPosition = defaultSpritePos - new Vector3(0f, movementBob.Evaluate(curveDeltaTime), -0.125f);
			if (curveDeltaTime >= 1.2f)
			{
				curveDeltaTime = 0f;
			}
		}
		else
		{
			curveDeltaTime = 0f;
			spriteObjects[0].transform.localPosition = defaultSpritePos;
		}
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -1473092350)
		{
			spriteObjects[0].PlayTransformAnimation(1560322550);
			StopAudioLoop();
		}
	}

	protected override void OnDeath()
	{
		StopAudioLoop();
		base.OnDeath();
	}

	protected override void OnHide()
	{
		StopAudioLoop();
		base.OnHide();
	}

	public override void OnFree()
	{
		StopAudioLoop();
		base.OnFree();
	}

	private void StartAudioLoop()
	{
		audioLoop = AudioManager.SfxFollowTransform(SfxID.insectLoop, base.transform, 0.4f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: true, 6f);
	}

	private void StopAudioLoop()
	{
		if (audioLoop != null)
		{
			audioLoop.FadeOutAndStop(0.2f);
			audioLoop = null;
		}
	}
}
