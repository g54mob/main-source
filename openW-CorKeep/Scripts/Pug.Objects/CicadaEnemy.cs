using System.Collections;
using System.Collections.Generic;
using Pug.Sprite;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Mathematics;
using UnityEngine;

public class CicadaEnemy : EntityMonoBehaviour
{
	public Color enragedColor;

	public ParticleSystem explodeParticles;

	public Transform bodyTransform;

	public ParticleEffectSpawner emergeEffects;

	public ParticleEffectSpawner moveDust;

	private Vector3 _prevDirectionNormalized;

	private bool _forceUpdateSprites;

	private readonly List<AudioManager.RunningSfxReference> _walkAudioLoop = new List<AudioManager.RunningSfxReference>();

	private readonly List<AudioManager.RunningSfxReference> _chargeAudioLoop = new List<AudioManager.RunningSfxReference>();

	private int _currentVariantHash;

	private bool _isChargingOrAttacking;

	private Vector3 _bodyStartPos;

	private bool _isOverPit;

	private bool _isMoving;

	private bool _isOverPitToggle;

	private readonly int m_bodyUp = SpriteAsset.StringToHash("bodyUp");

	private readonly int m_bodyDown = SpriteAsset.StringToHash("bodyDown");

	private readonly int m_bodyReset = SpriteAsset.StringToHash("bodyReset");

	private readonly int m_stopWingAudio = SpriteAsset.StringToHash("stopWingAudio");

	private readonly int _mRightHash = SpriteAsset.StringToHash("90");

	private readonly int _mRightUp = SpriteAsset.StringToHash("135");

	private readonly int _mUp = SpriteAsset.StringToHash("180");

	private readonly int _mDown;

	private readonly int _mDownRight = SpriteAsset.StringToHash("45");

	protected override bool updateAnimOrientation => true;

	protected override bool updateAnimMovement => true;

	protected override void Awake()
	{
		base.Awake();
		spriteObjects[1].onAnimationEvent += HandleAnimationEvent;
		_bodyStartPos = bodyTransform.position;
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		if ((bool)emergeEffects)
		{
			emergeEffects.enabled = false;
		}
		if ((bool)moveDust)
		{
			moveDust.enabled = false;
		}
		HideSprites();
	}

	public override void OnFree()
	{
		base.OnFree();
		ReleaseAudioLoops();
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		_isMoving = false;
		if (animID == -1878077465)
		{
			StartCoroutine(Spawn_Coroutine());
			return;
		}
		ShowSprites();
		if (animID != -596588359 && animID != 1203776827)
		{
			base.HandleAnimationTrigger(animID);
		}
		if (animID == 1203776827)
		{
			StopWalkAudio();
			spriteObjects[0].PlayAnimation(1203776827);
			spriteObjects[1].PlayAnimation(-1634423587);
			spriteObjects[2].PlayAnimation(1203776827);
			spriteObjects[3].PlayAnimation(1203776827);
			if ((bool)moveDust)
			{
				moveDust.enabled = false;
			}
			Manager.effects.PlayPuff(PuffID.CicadaBuzzPreAttack, bodyTransform.transform.position, 1);
			AudioManager.Sfx(SfxTableID.cicadaBuzzPreAttack, base.transform.position);
			flashable.FlashLinearNoCurve(Color.white, 0.6f);
		}
		if (animID == -596588359)
		{
			PlaySpriteObjectAnimation(198769013);
			_isChargingOrAttacking = true;
		}
		if (animID == -281135240 || animID == 1004185915)
		{
			StopChargeAudio();
			AudioManager.SfxFollowTransform(SfxTableID.cicadaWalk, base.transform, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, _walkAudioLoop);
			_isMoving = true;
			_isChargingOrAttacking = false;
		}
		if (animID == -1634423587)
		{
			StopWalkAudio();
			AudioManager.SfxFollowTransform(SfxTableID.cicadaCharge, base.transform, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, _chargeAudioLoop);
			if ((bool)moveDust)
			{
				moveDust.enabled = false;
			}
			AudioManager.Sfx(SfxTableID.cicadaAnticipateAttack, base.transform.position);
			_isChargingOrAttacking = true;
			flashable.FlashLinearNoCurve(Color.white, 0.6f);
		}
		if (animID == 198769013 || animID == -596588359)
		{
			Manager.camera.ShakeCameraNow(0.4f, 2f, 2f);
			explodeParticles.Play(withChildren: true);
			AudioManager.Sfx(SfxTableID.cicadaChargeAttackLanding, base.transform.position);
			_isChargingOrAttacking = false;
		}
	}

	private void StopWalkAudio()
	{
		_walkAudioLoop.ForEach(delegate(AudioManager.RunningSfxReference audioSource)
		{
			audioSource.FadeOutAndStop();
		});
		_walkAudioLoop.Clear();
	}

	private void StopChargeAudio()
	{
		_chargeAudioLoop.ForEach(delegate(AudioManager.RunningSfxReference audioSource)
		{
			audioSource.FadeOutAndStop();
		});
		_chargeAudioLoop.Clear();
	}

	private void HandleAnimationEvent(int hash)
	{
		if (hash == m_bodyReset)
		{
			bodyTransform.localPosition = _bodyStartPos;
		}
		else if (hash == m_bodyDown)
		{
			bodyTransform.localPosition = _bodyStartPos - new Vector3(0f, 0.0625f, 0f);
		}
		else if (hash == m_bodyUp)
		{
			bodyTransform.localPosition = _bodyStartPos + new Vector3(0f, 0.0625f, 0f);
		}
		else if (hash == m_stopWingAudio)
		{
			ReleaseAudioLoops();
		}
	}

	private void HideSprites()
	{
		spriteObjects[0].transform.localScale = Vector3.zero;
		spriteObjects[1].transform.localScale = Vector3.zero;
		spriteObjects[2].transform.localScale = Vector3.zero;
		spriteObjects[3].transform.localScale = Vector3.zero;
		shadow.SetActive(value: false);
	}

	private void ShowSprites()
	{
		if (!(spriteObjects[0].transform.localScale == Vector3.one))
		{
			spriteObjects[0].transform.localScale = Vector3.one;
			spriteObjects[1].transform.localScale = Vector3.one;
			spriteObjects[2].transform.localScale = Vector3.one;
			spriteObjects[3].transform.localScale = Vector3.one;
			shadow.SetActive(value: true);
		}
	}

	protected override void UpdateSpriteObjectsOrientation()
	{
		if (!EntityUtility.TryGetComponentData<AnimationOrientationCD>(base.entity, base.world, out var value))
		{
			return;
		}
		float angle = value.facingDirection.angle;
		int num;
		if (angle <= 0f)
		{
			if (angle <= -90f)
			{
				if (angle != -135f)
				{
					if (angle != -90f)
					{
						goto IL_00d0;
					}
					num = _mDown;
				}
				else
				{
					num = _mDownRight;
				}
			}
			else if (angle != -45f)
			{
				if (angle != 0f)
				{
					goto IL_00d0;
				}
				num = _mRightHash;
			}
			else
			{
				num = _mDownRight;
			}
		}
		else if (angle <= 90f)
		{
			if (angle != 45f)
			{
				if (angle != 90f)
				{
					goto IL_00d0;
				}
				num = _mUp;
			}
			else
			{
				num = _mRightUp;
			}
		}
		else if (angle != 135f)
		{
			if (angle != 180f)
			{
				goto IL_00d0;
			}
			num = _mRightHash;
		}
		else
		{
			num = _mRightUp;
		}
		goto IL_00d7;
		IL_00d0:
		num = _mDown;
		goto IL_00d7;
		IL_00d7:
		int variant = num;
		for (int i = 0; i < spriteObjects.Count; i++)
		{
			spriteObjects[i].SetVariant(variant);
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (EntityUtility.GetComponentData<EnrageStateCD>(base.entity, base.world).isEnraged)
		{
			spriteObjects.ForEach(delegate(SpriteObject so)
			{
				so.color = enragedColor;
			});
		}
		else
		{
			spriteObjects.ForEach(delegate(SpriteObject so)
			{
				so.color = Color.white;
			});
		}
		if (!((float)currentHealth <= 0f) && lastAnim != -414722770)
		{
			UpdateAudioLoops();
		}
		UpdateSpriteObjectsOrientation();
		if (_isChargingOrAttacking || !_isMoving)
		{
			if ((bool)moveDust)
			{
				moveDust.enabled = false;
			}
			return;
		}
		SinglePugMap.TileLayerLookup tileLayerLookup = Manager.multiMap.GetTileLayerLookup();
		int2 worldPosition = base.WorldPosition.RoundToInt2();
		_isOverPit = tileLayerLookup.HasTile(worldPosition, TileType.pit) || tileLayerLookup.HasTile(worldPosition, TileType.water);
		if (_isOverPit && !_isOverPitToggle)
		{
			_isOverPitToggle = true;
			StopWalkAudio();
			AudioManager.SfxFollowTransform(SfxTableID.cicadaCharge, base.transform, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, _chargeAudioLoop);
			spriteObjects[1].PlayAnimation(1433117748);
			spriteObjects[2].PlayAnimation(-1634423587);
			spriteObjects[3].PlayAnimation(-1634423587);
		}
		if (!_isOverPit && _isOverPitToggle)
		{
			_isOverPitToggle = false;
			StopChargeAudio();
			spriteObjects[1].PlayAnimation(-281135240);
			if ((bool)moveDust)
			{
				moveDust.enabled = true;
			}
			spriteObjects[2].PlayAnimation(-601574123);
			spriteObjects[3].PlayAnimation(-601574123);
			AudioManager.SfxFollowTransform(SfxTableID.cicadaWalk, base.transform, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, _walkAudioLoop);
		}
	}

	private void UpdateAudioLoops()
	{
		if (base.world.GetExistingSystemManaged<WorldInfoSystem>().WorldInfo.simulationDisabled)
		{
			ReleaseAudioLoops();
		}
	}

	private void ReleaseAudioLoops()
	{
		_walkAudioLoop.ForEach(delegate(AudioManager.RunningSfxReference audioSource)
		{
			audioSource.FadeOutAndStop();
		});
		_walkAudioLoop.Clear();
		_chargeAudioLoop.ForEach(delegate(AudioManager.RunningSfxReference audioSource)
		{
			audioSource.FadeOutAndStop();
		});
		_chargeAudioLoop.Clear();
	}

	protected override void OnDeath()
	{
		ReleaseAudioLoops();
		Manager.effects.PlayPuff(PuffID.CicadaDeath, bodyTransform.transform.position);
		StopAllCoroutines();
		if ((bool)emergeEffects)
		{
			emergeEffects.enabled = false;
		}
		base.OnDeath();
	}

	public IEnumerator Spawn_Coroutine()
	{
		AudioManager.SfxFollowTransform(SfxTableID.cicadaEmerge, base.transform);
		if ((bool)emergeEffects)
		{
			emergeEffects.enabled = true;
		}
		yield return new WaitForSeconds(1f);
		ShowSprites();
		if ((bool)emergeEffects)
		{
			emergeEffects.enabled = false;
		}
		spriteObjects[0].PlayAnimation(-1878077465);
		spriteObjects[1].PlayAnimation(-1878077465);
		spriteObjects[2].PlayAnimation(-1878077465);
		spriteObjects[3].PlayAnimation(-1878077465);
	}
}
