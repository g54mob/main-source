using System.Collections;
using System.Collections.Generic;
using Pug.Sprite;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class RobotBossLeg : EntityMonoBehaviour
{
	public Transform pointTightEnd;

	public float checkTerrainDistance;

	public MeshRenderer shinRenderer;

	public MeshRenderer elbowRenderer;

	[FormerlySerializedAs("ElbowTransform")]
	public Transform wholeLegRotatorTransform;

	[FormerlySerializedAs("legTransform")]
	public Transform shinTransform;

	private Coroutine _damagedLegSfxCoroutine;

	[Header("Effects")]
	[Tooltip("The particle system for sparks/smoke when the leg is broken.")]
	public ParticleSystem brokenEffectEmitter;

	public ParticleSystem brokenImpactEmitter;

	private readonly List<AudioManager.RunningSfxReference> _loopingElectricitySound = new List<AudioManager.RunningSfxReference>();

	public ParticleSystem sandImpactEmitter;

	[Header("Water")]
	public PlatformFlags disableWaterSimAffectorOnPlatforms;

	public ParticleSystem waterParticles;

	public ParticleSystem lavaSmokeParticles;

	[Header("Health Bar")]
	public Color healthColor = new Color(1f, 0.239f, 0.239f);

	public Color healthBackgroundColor = new Color(0.1f, 0.1f, 0.1f, 0.8f);

	public Color regenerationColor = new Color(0.6f, 0.6f, 0.6f);

	public Color regenerationBackgroundColor = new Color(0.4f, 0f, 0f, 0.8f);

	[Header("Emission")]
	public Color brokenEmissiveColor = new Color(1f, 0f, 0f) * 2.2f;

	private static readonly int EmissiveColorID = Shader.PropertyToID("_EmissiveColor");

	private MaterialPropertyBlock _shinBlock;

	private MaterialPropertyBlock _elbowBlock;

	public SpriteObject lightEmitter;

	private bool _isBroken;

	private bool _isImmune;

	private bool _didResetColor;

	private Coroutine _blinkCoroutine;

	protected override bool hideDirectlyOnDeath => false;

	private bool ShouldBlink
	{
		get
		{
			if (!_isBroken)
			{
				return _isImmune;
			}
			return true;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		if (brokenEffectEmitter != null)
		{
			brokenEffectEmitter.Stop();
		}
		_shinBlock = new MaterialPropertyBlock();
		_elbowBlock = new MaterialPropertyBlock();
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		optionalHealthBar.root.SetActive(value: false);
		wholeLegRotatorTransform.localRotation = Quaternion.identity;
		shinTransform.rotation = Quaternion.identity;
		optionalHealthBar.showHealthBarAtFullHealth = false;
		_didResetColor = false;
	}

	public void UpdateHealthBar(float healthRatio, int legIsBrokenTimeElapsedTime, int legIsBrokenTimeMax)
	{
		float value = healthRatio;
		if (healthRatio <= 0f)
		{
			optionalHealthBar.background.color = regenerationBackgroundColor;
			optionalHealthBar.healthColor = regenerationColor;
			value = (float)legIsBrokenTimeElapsedTime / (float)legIsBrokenTimeMax;
		}
		else
		{
			optionalHealthBar.background.color = healthBackgroundColor;
			optionalHealthBar.healthColor = healthColor;
		}
		optionalHealthBar.UpdateHealthBar(value, 0, 0, overrideShowHealthBar: true);
	}

	public void SetBrokenEffectActive(bool isBroken, Color emissionColor, bool legsAreVulnerable)
	{
		_isBroken = isBroken;
		if (isBroken)
		{
			HandleBrokenEnter();
		}
		else
		{
			HandleBrokenExit(emissionColor, legsAreVulnerable);
		}
		UpdateBlinkState();
	}

	private void HandleBrokenEnter()
	{
		_didResetColor = false;
		_isImmune = false;
		if (!brokenEffectEmitter.isPlaying)
		{
			brokenEffectEmitter.Play();
			brokenImpactEmitter.Play();
			AudioManager.Sfx(SfxTableID.EchoExplosion, base.transform.position);
			_damagedLegSfxCoroutine = StartCoroutine(PlaySpecialSfxTableLoop(SfxTableID.robotBossDamagedLegSfx, 2f, 6f));
			Manager.camera.ShakeCameraNow(0.4f, 3f, 3f, null, null, 0, 0.8f);
			StartBlink(brokenEmissiveColor, 0.5f);
		}
	}

	private void HandleBrokenExit(Color emissionColor, bool legsAreVulnerable)
	{
		brokenEffectEmitter.Stop();
		if (_damagedLegSfxCoroutine != null)
		{
			StopCoroutine(_damagedLegSfxCoroutine);
			_damagedLegSfxCoroutine = null;
		}
		if (_loopingElectricitySound.Count > 0)
		{
			ReleaseAudioLoops();
		}
		if (legsAreVulnerable)
		{
			_isImmune = false;
			if (!_didResetColor)
			{
				_didResetColor = true;
				SetLegColor(emissionColor);
			}
		}
		else if (!_isImmune)
		{
			_isImmune = true;
			StartBlink(emissionColor * 0.6f, 0.3f);
		}
	}

	private void UpdateBlinkState()
	{
		if (!_isBroken && !_isImmune && _blinkCoroutine != null)
		{
			StopCoroutine(_blinkCoroutine);
			_blinkCoroutine = null;
		}
	}

	private void StartBlink(Color blinkColor, float speed)
	{
		if (_blinkCoroutine != null)
		{
			StopCoroutine(_blinkCoroutine);
		}
		_blinkCoroutine = StartCoroutine(BlinkLeg(blinkColor, speed));
	}

	private IEnumerator BlinkLeg(Color blinkColor, float speed)
	{
		while (ShouldBlink)
		{
			SetLegColor(blinkColor);
			yield return new WaitForSeconds(speed);
			SetLegColor(Color.clear);
			yield return new WaitForSeconds(speed);
		}
	}

	public void SetLegColor(Color color)
	{
		if (shinRenderer != null)
		{
			shinRenderer.GetPropertyBlock(_shinBlock);
			_shinBlock.SetColor(EmissiveColorID, color);
			shinRenderer.SetPropertyBlock(_shinBlock);
		}
		if (elbowRenderer != null)
		{
			elbowRenderer.GetPropertyBlock(_elbowBlock);
			_elbowBlock.SetColor(EmissiveColorID, color);
			elbowRenderer.SetPropertyBlock(_elbowBlock);
		}
		lightEmitter.emissiveColor = color * 6.5f;
	}

	public void PlaySandImpactEffect()
	{
		AudioManager.Sfx(SfxTableID.robotBossFootstepLayer1Sfx, base.transform.position);
		SinglePugMap.TileLayerLookup tileLayerLookup = Manager.multiMap.GetTileLayerLookup();
		Vector3 vector = wholeLegRotatorTransform.localRotation * Vector3.forward;
		Vector3 vec = base.WorldPosition + vector * checkTerrainDistance;
		vec.y = 0f;
		int2 worldPosition = vec.RoundToInt2();
		TileInfo topTile = tileLayerLookup.GetTopTile(worldPosition);
		bool flag = false;
		bool flag2 = false;
		if (topTile.tileType != TileType.ground && !disableWaterSimAffectorOnPlatforms.MatchesCurrentPlatform() && topTile.tileType != TileType.bridge)
		{
			flag = topTile.tileType == TileType.water;
			flag2 = topTile.tileType == TileType.pit;
			if (flag)
			{
				AudioManager.Sfx(SfxID.puddle2, lavaSmokeParticles.gameObject.transform.position, 0.6f, 1.1f, 0.1f, reuse: true);
				if (topTile.tileset == 3)
				{
					lavaSmokeParticles.Play();
					Manager.effects.PlayPuff(PuffID.SmallLavaSplash, lavaSmokeParticles.gameObject.transform.position, 30);
					Manager.effects.PlayPuff(PuffID.LavaDrip, lavaSmokeParticles.gameObject.transform.position, 20);
					Manager.effects.PlayTempSprite(SpriteTempEffectID.WaterRippleLava, lavaSmokeParticles.gameObject.transform.position, 1f, 0.42857143f);
					Manager.effects.PlayPuff(PuffID.LavaMortarImpact, base.transform.position);
				}
				else
				{
					AudioManager.Sfx(SfxID.splash, lavaSmokeParticles.gameObject.transform.position, 0.8f, 0.75f, 0.1f, reuse: true);
					Manager.effects.PlayPuff(PuffID.WaterSplash, lavaSmokeParticles.gameObject.transform.position, 20);
					Manager.effects.PlayPuff(PuffID.WaterSplashMist, lavaSmokeParticles.gameObject.transform.position, 20);
				}
				waterParticles.Play();
				AudioManager.Sfx(SfxTableID.hydraBossLavaShotImpact, base.RenderPosition);
			}
		}
		XScaler.localPosition = ((flag || flag2) ? new Vector3(0f, -0.6f, 0f) : Vector3.zero);
		if (!flag2)
		{
			sandImpactEmitter.Play();
		}
		float num = Mathf.Clamp01(Vector3.Distance(Manager.main.player.transform.position, base.transform.position) / 7f);
		float num2 = (1f - num) * 4f;
		if (num2 > 0.1f)
		{
			Manager.camera.ShakeCameraNow(0.4f, num2, num2, null, null, 0, 0.4f);
		}
	}

	protected override void OnHide()
	{
		ReleaseAudioLoops();
		base.OnHide();
	}

	private void ReleaseAudioLoops()
	{
		foreach (AudioManager.RunningSfxReference item in _loopingElectricitySound)
		{
			item.FadeOutAndStop();
		}
		_loopingElectricitySound.Clear();
		foreach (AudioManager.RunningSfxReference item2 in _loopingElectricitySound)
		{
			item2.FadeOutAndStop();
		}
		_loopingElectricitySound.Clear();
	}

	private IEnumerator PlaySpecialSfxTableLoop(int sfxTableID, float minDelay, float maxDelay)
	{
		while (true)
		{
			AudioManager.SfxFollowTransform(sfxTableID, shinTransform, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, _loopingElectricitySound, 1f, 0f, 0.15f);
			float seconds = UnityEngine.Random.Range(minDelay, maxDelay);
			yield return new WaitForSeconds(seconds);
		}
	}
}
