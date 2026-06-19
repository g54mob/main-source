using UnityEngine;

public class CritterPassageFly : Critter, IFlyingVisual
{
	public AnimationCurve movementBob;

	public float bobSpeed = 2.5f;

	private float curveDeltaTime;

	private Vector3 defaultSpritePos;

	private Vector3 _groundedSpritePos = new Vector3(0f, 0.1875f, 0f);

	private bool _isGrounded;

	protected override void Awake()
	{
		base.Awake();
		defaultSpritePos = spriteObjects[0].transform.localPosition;
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		curveDeltaTime += Random.Range(0f, 1f);
		DisplayOnGround(value: false);
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		curveDeltaTime += Time.deltaTime * bobSpeed;
		spriteObjects[0].transform.localPosition = (_isGrounded ? _groundedSpritePos : defaultSpritePos) - new Vector3(0f, movementBob.Evaluate(curveDeltaTime), 0f);
		if (curveDeltaTime >= 1.2f)
		{
			curveDeltaTime = 0f;
		}
	}

	protected override void Squash()
	{
		AudioManager.SfxFollowTransform(soundOptions.deathSfx.value, base.transform);
		Manager.effects.PlayPuff(PuffID.SlimeFootstep, particleOptions.particleSpawnLocations[0].position);
		Manager.effects.PlayTempSprite(SpriteTempEffectID.FootstepSlime, particleOptions.particleSpawnLocations[0].position, 0.4f, 0.5f);
		Manager.effects.PlayTempSprite(SpriteTempEffectID.SmallSlimeSplat, particleOptions.particleSpawnLocations[0].position, 1f, 1.5f);
	}

	public void DisplayOnGround(bool value)
	{
		_isGrounded = value;
		spriteObjects[0].transform.localPosition = (_isGrounded ? _groundedSpritePos : defaultSpritePos) - new Vector3(0f, movementBob.Evaluate(curveDeltaTime), 0f);
	}
}
