using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using Pug.Sprite;
using Pug.UnityExtensions;
using PugScan;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class RobotBoss : EntityMonoBehaviour, IMortarShooter
{
	private enum EyeDir
	{
		Center = 0,
		Left = 1,
		Right = 2
	}

	private Unity.Mathematics.Random rng;

	[Header("Dialogue")]
	public List<PugTextEffectEnunciateSyllables> syllables;

	public List<LocalizedString> outroSpeechStrings;

	public List<PugText> speechTextOutlines;

	private readonly List<AudioManager.RunningSfxReference> _parasiteAudioLoop = new List<AudioManager.RunningSfxReference>();

	public SpriteObject parasiteSpriteObject;

	private bool _fadingOut;

	private float _fadeValue = 1f;

	[Header("Body transforms")]
	public Transform shoulderAnchorPoint;

	public Transform leanTransform;

	public Transform voidEffects;

	public Transform fellInLavaEffect;

	private bool _isMoving;

	private Vector3[] _lastLegPositions;

	private bool _fellDownLockAnimations;

	[Header("Body Lean Settings")]
	public float swayMaxY = 8f;

	public float swayMaxZ = 13f;

	public float swayMaxYVoid = 12f;

	public float swayMaxZVoid = 12f;

	public float zSwaySpeed = 3f;

	public float zSwaySpeedVoid = 6f;

	[SerializeField]
	private float returnSpeed = 2f;

	[SerializeField]
	private float yLookSpeed = 2f;

	private List<bool> _prevPlannedStep = new List<bool>();

	public List<RobotBossThighController> thighControllers = new List<RobotBossThighController>();

	public Light screenLightSource;

	[Header("Emote Screen Settings")]
	public SpriteObject emoteScreen;

	[SerializeField]
	private float eyeDeadzone = 3f;

	[SerializeField]
	private bool setManualEyeDirection;

	[SerializeField]
	[Range(-10f, 10f)]
	private float editorEyeX;

	[SerializeField]
	[Range(-1f, 1f)]
	private float editorEyeY;

	[Header("Particles")]
	public ParticleSystem getUpParticles;

	public ParticleSystem rocketShotSmoke;

	public ParticleSystem dyingPops;

	public ParticleSystem finalDeathAnticipationFlare;

	[Header("Range anticipation beams")]
	public RobotBossAnticipationFX anticipationFX;

	[Header("Mortar specific")]
	public List<Transform> mortarLaunchPoints;

	[Header("Lamp colors")]
	public Color defaultLampColor = new Color(0.5f, 0.8f, 1f);

	public Color fireRangeLampColor = new Color(0f, 0f, 0f);

	public Color fireMortarLampColor = new Color(1f, 0.7f, 0.8f);

	private static readonly int EyeLeft = SpriteAsset.StringToHash("left");

	private static readonly int EyeRight = SpriteAsset.StringToHash("right");

	private bool _animateLegsOverride;

	[Header("Shoulders and legs")]
	[FormerlySerializedAs("secondShoulderAnchorOffset")]
	public float shoulderLength = 0.42f;

	[FormerlySerializedAs("secondShoulderAnchorOffsetDown")]
	public float shoulderDownDirection = 0.94f;

	private static readonly int EyeCenter = 0;

	private EyeDir _eyeDir;

	private bool _screenRenderingSomething;

	private bool _isEnraged;

	private bool _isGoingCrazy;

	private bool _isDoneWithActivationPhase;

	[Header("Snapping")]
	public float snapAngle = 5f;

	[Space(20f)]
	private bool _fellInLavaTrigger;

	private bool _wasEnraged;

	public Color normalEmissiveColor = new Color(0f, 0.2588f, 0.749f) * 2f;

	public Color enrageEmissiveColor = new Color(0.35f, 0f, 0.8f) * 2.2f;

	public MeshRenderer bodyMeshRenderer;

	[Tooltip("How many frames to skip between leg updates (0 = update legs every frame)")]
	public int legUpdateSkipFrames = 1;

	private int _legUpdateFrameSkipCounter;

	[Space(20f)]
	private bool idleSfxStarted;

	private float movingTimer;

	private float _idleTimer;

	private AudioManager.RunningSfxReference _moveLoopSfx;

	private bool moveLoopActive;

	private bool moveOneShotPlayed;

	private List<AudioManager.RunningSfxReference> loopingSfx = new List<AudioManager.RunningSfxReference>();

	private List<AudioManager.RunningSfxReference> sfxRef = new List<AudioManager.RunningSfxReference>();

	private List<AudioManager.RunningSfxReference> sfxRef2 = new List<AudioManager.RunningSfxReference>();

	private List<AudioManager.RunningSfxReference> sfxRef3 = new List<AudioManager.RunningSfxReference>();

	private int _nextMortarIndex;

	private static float lastChargeRangeSfxTime = -999f;

	private static float lastChargeRangeSfxTime2 = -999f;

	private static float lastChargeRangeSfxTime3 = -999f;

	private float lastEnrageAnimTime = -999f;

	private const float chargeRangeSfxCooldown = 3.3f;

	private const float chargeRangeSfxCooldown2 = 3.8f;

	private const float chargeRangeSfxCooldown3Laugh = 8f;

	private int mortarRocketsFired;

	private readonly int _animHashStanding = Animator.StringToHash("standingIdle");

	private readonly int _animHashFall = Animator.StringToHash("fallToGround");

	private readonly int _animHashStandUpAfterFall = Animator.StringToHash("standUpAfterFall");

	private readonly int _animHashFirstGetup = Animator.StringToHash("firstGetup");

	private readonly int _animHashDeath = Animator.StringToHash("bossDeath");

	public int leanUpdateInterval = 4;

	private int _leanFrameCounter;

	private int _brokenLegsLeftCount;

	private int _brokenLegsRightCount;

	private int _legParity;

	private const float SnapAngleThreshold = 5f;

	private const float SnapDistanceThreshold = 0.05f;

	[SerializeField]
	private float stopDelay = 0.25f;

	private float _stillTimer;

	private bool _isMovingSmoothed;

	private float _currentZAngle;

	private float _wobbleWeight;

	private float _currentYAngle;

	public float brokenLeanOffset = -4f;

	public float brokenLeanAmount = 10f;

	private int _animateEyePriority = 1;

	private int _currentPrio = -1;

	private Coroutine _overrideScreenRoutine;

	protected override bool hideDirectlyOnDeath => false;

	protected override void Awake()
	{
		base.Awake();
		_currentPrio = -1;
		anticipationFX.Stop();
		_animateLegsOverride = false;
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		ResetRobot();
		rng = PugRandom.GetRng();
	}

	private void ResetRobot()
	{
		if (EntityUtility.TryGetComponentData<HealthCD>(base.entity, base.world, out var value) && value.health > 0)
		{
			leanTransform.gameObject.SetActive(value: true);
			parasiteSpriteObject.gameObject.SetActive(value: false);
			FadeOutSpeechText();
			ResetSpeechText();
			DynamicBuffer<RobotBossLegsBuffer> buffer = EntityUtility.GetBuffer<RobotBossLegsBuffer>(base.entity, base.world);
			_lastLegPositions = new Vector3[buffer.Length];
			for (int i = 0; i < buffer.Length; i++)
			{
				if (Manager.memory.TryGetEntityMono(buffer[i].leg, out RobotBossLeg monoT) && monoT != null)
				{
					_lastLegPositions[i] = monoT.wholeLegRotatorTransform.position;
					monoT.wholeLegRotatorTransform.gameObject.SetActive(value: true);
				}
			}
			_screenRenderingSomething = false;
			_currentPrio = -1;
			OverrideMonitor(15, 0, 4f, defaultLampColor);
		}
		else
		{
			_screenRenderingSomething = false;
			_currentPrio = -1;
			OverrideMonitor(1000, -414722770, 20f, defaultLampColor);
		}
		_prevPlannedStep.Clear();
		_prevPlannedStep.AddRange(new bool[4]);
		_animateLegsOverride = false;
		ResetLegs();
		if (EntityUtility.TryGetComponentData<RobotBossCD>(base.entity, base.world, out var value2) && value2.internalState == RobotBossInternalState.Phase2Walking)
		{
			playAnimation(_animHashStanding);
		}
		ResetBodyLean();
		anticipationFX.Stop();
		_legParity = 0;
		_legUpdateFrameSkipCounter = 0;
	}

	private void ResetBodyLean()
	{
		bodyMeshRenderer.transform.localRotation = quaternion.identity;
	}

	private void FadeOutSpeechText(bool reset = true)
	{
		_fadingOut = true;
		foreach (PugTextEffectEnunciateSyllables syllable in syllables)
		{
			syllable.StopPlaying();
		}
	}

	private void ResetSpeechText()
	{
		speechTextOutlines[0].Render("", rewindEffectAnims: true);
		foreach (PugText speechTextOutline in speechTextOutlines)
		{
			speechTextOutline.Render("");
		}
	}

	private IEnumerator OutroLines_Coroutine()
	{
		parasiteSpriteObject.gameObject.SetActive(value: true);
		parasiteSpriteObject.PlayAnimation(-2007111235, forceResetTime: false, skipTransition: true);
		yield return new WaitForSeconds(0.2f);
		parasiteSpriteObject.PlayAnimation(-1878077465);
		AudioManager.Sfx(SfxTableID.giantCicadaDeathParasiteAppear, base.transform.position);
		AudioManager.SfxFollowTransform(SfxTableID.giantCicadaDeathParasiteLoop, base.transform, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, _parasiteAudioLoop);
		yield return new WaitForSeconds(1.5f);
		for (int i = 0; i < outroSpeechStrings.Count; i++)
		{
			string text = outroSpeechStrings[i].ToString();
			PlayLine(outroSpeechStrings[i]);
			yield return new WaitForSeconds((float)text.Length * 0.1f + 2.2f);
		}
		yield return new WaitForSeconds(1.5f);
		ResetSpeechText();
		yield return new WaitForSeconds(1f);
		parasiteSpriteObject.PlayAnimation(-414722770);
		AudioManager.Sfx(SfxTableID.giantCicadaDeathParasiteExit, base.transform.position);
		_parasiteAudioLoop.ForEach(delegate(AudioManager.RunningSfxReference audioSource)
		{
			audioSource.FadeOutAndStop(2f);
		});
		_parasiteAudioLoop.Clear();
		yield return new WaitForSeconds(3f);
		if ((bool)finalDeathAnticipationFlare)
		{
			finalDeathAnticipationFlare.Play();
			AudioManager.Sfx(SfxID.robot_b_boss_death_build_up_1_01, base.RenderPosition, 0.76f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.ROBOT_BOSS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 40f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: false, isPartOfSfxTableElement: false, 0f, randomStartTime: false, 0, 8f, 0f, 1f, 0.5f);
		}
		yield return new WaitForSeconds(3f);
		AE_BodyExplode();
		ResetSpeechText();
	}

	private void PlayLine(string line)
	{
		speechTextOutlines[0].Render(line, rewindEffectAnims: true);
		foreach (PugText speechTextOutline in speechTextOutlines)
		{
			speechTextOutline.Render(line, rewindEffectAnims: true);
		}
	}

	private void OnEnterEnrage()
	{
		optionalHealthBar.healthColor = new Color(0.627f, 0.157f, 1f);
		bodyMeshRenderer.materials[3].SetColor("_EmissiveColor", enrageEmissiveColor);
		DynamicBuffer<RobotBossLegsBuffer> buffer = EntityUtility.GetBuffer<RobotBossLegsBuffer>(base.entity, base.world);
		for (int i = 0; i < buffer.Length; i++)
		{
			if (Manager.memory.TryGetEntityMono(buffer[i].leg, out RobotBossLeg monoT) && monoT != null)
			{
				monoT.SetLegColor(enrageEmissiveColor);
			}
		}
	}

	private void OnLeaveEnrage()
	{
		optionalHealthBar.healthColor = new Color(1f, 0.239f, 0.239f);
		bodyMeshRenderer.materials[3].SetColor("_EmissiveColor", normalEmissiveColor);
		DynamicBuffer<RobotBossLegsBuffer> buffer = EntityUtility.GetBuffer<RobotBossLegsBuffer>(base.entity, base.world);
		for (int i = 0; i < buffer.Length; i++)
		{
			if (Manager.memory.TryGetEntityMono(buffer[i].leg, out RobotBossLeg monoT) && monoT != null)
			{
				monoT.SetLegColor(normalEmissiveColor);
			}
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (EntityUtility.TryGetComponentData<HealthCD>(base.entity, base.world, out var value))
		{
			_isEnraged = (float)value.health <= (float)value.maxHealth * 0.5f;
			_isGoingCrazy = (float)value.health <= (float)value.maxHealth * 0.25f;
		}
		if (!EntityUtility.TryGetComponentData<RobotBossCD>(base.entity, base.world, out var value2))
		{
			return;
		}
		if (_isEnraged && !_wasEnraged)
		{
			OnEnterEnrage();
		}
		else if (!_isEnraged && _wasEnraged)
		{
			OnLeaveEnrage();
		}
		_wasEnraged = _isEnraged;
		voidEffects.gameObject.SetActive(_isEnraged);
		if (!_fellInLavaTrigger && value2.fellInLava)
		{
			_fellInLavaTrigger = true;
			fellInLavaEffect.gameObject.SetActive(value: true);
			Manager.effects.PlayPuff(PuffID.SmallLavaSplash, base.transform.position, 30);
			Manager.effects.PlayPuff(PuffID.Explosion_FieryLarge, base.transform.position + new Vector3(0f, 0f, -2f), 3);
			Manager.effects.PlayPuff(PuffID.LavaMortarImpact, base.transform.position);
		}
		if (_fellInLavaTrigger && !value2.fellInLava)
		{
			fellInLavaEffect.gameObject.SetActive(value: false);
			_fellInLavaTrigger = false;
		}
		optionalHealthBar.gameObject.SetActive(value2.internalState == RobotBossInternalState.Phase2WalkingButDown);
		if (base.variation == 1 && !_animateLegsOverride)
		{
			screenLightSource.color = fireRangeLampColor;
			return;
		}
		anticipationFX.rangeAttackDirection = value2.rangeAttackDirection;
		if (value2.animateTheLegs || _animateLegsOverride)
		{
			UpdateLegVisuals(value2, value);
			if (_legUpdateFrameSkipCounter <= 0)
			{
				AnimateLegs();
				_legParity ^= 1;
				_legUpdateFrameSkipCounter = legUpdateSkipFrames;
			}
			else
			{
				_legUpdateFrameSkipCounter--;
			}
			if (value2.internalState == RobotBossInternalState.Phase2Walking)
			{
				AnimateEyeOnScreen();
				_leanFrameCounter++;
				if (_leanFrameCounter >= leanUpdateInterval)
				{
					LeanBody();
					_leanFrameCounter = 0;
				}
			}
			else if (value2.internalState == RobotBossInternalState.Phase2WalkingButDown)
			{
				ResetBodyLean();
			}
		}
		if (value2.isActuallyMoving)
		{
			_isMovingSmoothed = true;
			_stillTimer = 0f;
		}
		else
		{
			_stillTimer += Time.deltaTime;
			if (_stillTimer > stopDelay)
			{
				_isMovingSmoothed = false;
			}
		}
		_isMoving = _isMovingSmoothed;
		if (_isMoving)
		{
			movingTimer += Time.deltaTime;
			_idleTimer = 0f;
			if (!moveLoopActive && movingTimer > 0.1f)
			{
				PoolableAudioSource poolableAudioSource = AudioManager.SfxFollowTransform(SfxID.robot_boss_movement_1, base.transform, 0.8f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: true, 55f, 15f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: false, playOnGamepad: false, isPartOfSfxTableElement: false, 0f, randomStartTime: true, 0, 8f, 0f, 0.5f);
				if (poolableAudioSource != null)
				{
					_moveLoopSfx = new AudioManager.RunningSfxReference(poolableAudioSource.validAllocationIndex, poolableAudioSource);
					_moveLoopSfx.FadeIn(0.1f, startVolumeAtZero: true);
					moveLoopActive = true;
				}
			}
		}
		else
		{
			_idleTimer += Time.deltaTime;
			movingTimer = 0f;
			if (moveLoopActive && _idleTimer > 0.15f)
			{
				if (_moveLoopSfx.IsValid)
				{
					_moveLoopSfx.FadeOutAndStop(0.25f);
					_moveLoopSfx = default(AudioManager.RunningSfxReference);
				}
				moveLoopActive = false;
			}
		}
		if (idleSfxStarted)
		{
			return;
		}
		PoolableAudioSource poolableAudioSource2 = AudioManager.SfxFollowTransform(SfxID.robot_boss_idle_2, base.transform, 0.22f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: true, 35f, 5f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: false, isPartOfSfxTableElement: false, 0f, randomStartTime: true);
		if (poolableAudioSource2 != null)
		{
			AudioManager.RunningSfxReference item = new AudioManager.RunningSfxReference(poolableAudioSource2.validAllocationIndex, poolableAudioSource2);
			foreach (AudioManager.RunningSfxReference item2 in loopingSfx)
			{
				item2.FadeOutAndStop();
			}
			loopingSfx.Clear();
			loopingSfx.Add(item);
			item.FadeIn(1f, startVolumeAtZero: true);
		}
		idleSfxStarted = true;
	}

	private void ResetLegs()
	{
		DynamicBuffer<RobotBossLegsBuffer> buffer = EntityUtility.GetBuffer<RobotBossLegsBuffer>(base.entity, base.world);
		for (int i = 0; i < buffer.Length; i++)
		{
			if (Manager.memory.TryGetEntityMono(buffer[i].leg, out RobotBossLeg monoT) && monoT != null)
			{
				monoT.SetBrokenEffectActive(isBroken: false, _isEnraged ? enrageEmissiveColor : normalEmissiveColor, legsAreVulnerable: true);
				monoT.optionalHealthBar.root.SetActive(value: false);
				if (monoT.wholeLegRotatorTransform.parent != null)
				{
					monoT.wholeLegRotatorTransform.localRotation = Quaternion.identity;
				}
				monoT.shinTransform.rotation = Quaternion.identity;
			}
		}
	}

	private void UpdateLegVisuals(RobotBossCD robotBossCD, HealthCD healthCD)
	{
		DynamicBuffer<RobotBossLegsBuffer> buffer = EntityUtility.GetBuffer<RobotBossLegsBuffer>(base.entity, base.world);
		_brokenLegsLeftCount = 0;
		_brokenLegsRightCount = 0;
		for (int i = 0; i < buffer.Length; i++)
		{
			if (!Manager.memory.TryGetEntityMono(buffer[i].leg, out RobotBossLeg monoT) || !(monoT != null))
			{
				continue;
			}
			if (healthCD.health > 0)
			{
				monoT.wholeLegRotatorTransform.gameObject.SetActive(value: true);
				if (_prevPlannedStep[i] && !buffer[i].hasPlannedTarget)
				{
					monoT.PlaySandImpactEffect();
				}
				_prevPlannedStep[i] = buffer[i].hasPlannedTarget;
				bool flag = monoT.currentHealth <= 0;
				monoT.SetBrokenEffectActive(flag, _isEnraged ? enrageEmissiveColor : normalEmissiveColor, robotBossCD.legsAreVulnerable);
				if (flag)
				{
					if (buffer[i].legPosition == RobotBossLegPosition.BackLeft || buffer[i].legPosition == RobotBossLegPosition.FrontLeft)
					{
						_brokenLegsLeftCount++;
					}
					else
					{
						_brokenLegsRightCount++;
					}
				}
			}
			if (!robotBossCD.legsAreVulnerable)
			{
				monoT.optionalHealthBar.root.SetActive(value: false);
				continue;
			}
			monoT.optionalHealthBar.root.SetActive(value: true);
			monoT.UpdateHealthBar((float)monoT.currentHealth / (float)monoT.GetMaxHealth(), buffer[i].brokenTimerValue, robotBossCD.legBrokenTime);
		}
	}

	private void AnimateLegs()
	{
		DynamicBuffer<RobotBossLegsBuffer> buffer = EntityUtility.GetBuffer<RobotBossLegsBuffer>(base.entity, base.world);
		for (int i = 0; i < buffer.Length; i++)
		{
			if (!Manager.memory.TryGetEntityMono(buffer[i].leg, out RobotBossLeg monoT) || !(monoT != null) || (i & 1) != _legParity)
			{
				continue;
			}
			Vector3 position = monoT.wholeLegRotatorTransform.position;
			Vector3 vector = Vector3.Lerp(shoulderAnchorPoint.position - Vector3.down * shoulderDownDirection, position, shoulderLength);
			Vector3 forward = vector - thighControllers[i].transform.position;
			Quaternion rotation = thighControllers[i].transform.rotation;
			Quaternion quaternion2 = Quaternion.LookRotation(forward, Vector3.up);
			float num = Quaternion.Angle(rotation, quaternion2);
			float sqrMagnitude = (thighControllers[i].jointObject.transform.position - vector).sqrMagnitude;
			bool num2 = num >= 5f;
			bool flag = sqrMagnitude >= 0.0025000002f;
			if (num2 || flag)
			{
				thighControllers[i].transform.rotation = quaternion2;
				float magnitude = (vector - thighControllers[i].transform.position).magnitude;
				thighControllers[i].shoulderObject.transform.localScale = new Vector3(1f, 1f, magnitude);
				thighControllers[i].jointObject.transform.position = vector;
				Vector3 forward2 = monoT.pointTightEnd.position - thighControllers[i].jointObject.transform.position;
				if (forward2.sqrMagnitude > 1E-06f)
				{
					Quaternion rotation2 = Quaternion.LookRotation(forward2, Vector3.up) * Quaternion.Euler(0f, 180f, 0f);
					thighControllers[i].thighObject.transform.SetPositionAndRotation(thighControllers[i].jointObject.transform.position, rotation2);
					float z = Vector3.Distance(monoT.pointTightEnd.position, thighControllers[i].thighObject.transform.position);
					thighControllers[i].thighObject.transform.localScale = new Vector3(1f, 1f, z);
				}
				Vector3 vector2 = position - thighControllers[i].transform.position;
				if (vector2.sqrMagnitude > 1E-06f)
				{
					Quaternion quaternion3 = Quaternion.LookRotation(vector2.normalized, Vector3.up);
					monoT.wholeLegRotatorTransform.rotation = quaternion3;
					Quaternion rotation3 = quaternion3 * Quaternion.Euler(12f, 180f, 0f);
					monoT.shinTransform.rotation = rotation3;
				}
			}
		}
	}

	private void LeanBody()
	{
		float num = (_isEnraged ? swayMaxYVoid : swayMaxY);
		float num2 = (_isEnraged ? swayMaxZVoid : swayMaxZ);
		float num3 = (_isEnraged ? zSwaySpeedVoid : zSwaySpeed);
		float b = (_isMoving ? 1f : 0f);
		_wobbleWeight = Mathf.Lerp(_wobbleWeight, b, Time.deltaTime * returnSpeed);
		float currentZAngle = 0f;
		float currentYAngle = 0f;
		if (_isMoving)
		{
			currentZAngle = Mathf.Sin(Time.time * num3) * num2 * _wobbleWeight;
		}
		else
		{
			currentYAngle = Mathf.Sin(Time.time * yLookSpeed) * num;
		}
		_currentZAngle = currentZAngle;
		_currentYAngle = currentYAngle;
		int num4 = _brokenLegsLeftCount + _brokenLegsRightCount;
		float num5 = _brokenLegsRightCount - _brokenLegsLeftCount;
		num5 *= -1f;
		float num6 = ((num4 > 0) ? Mathf.Clamp(num5 / 2f, -1f, 1f) : 0f);
		brokenLeanOffset = num6 * brokenLeanAmount;
		float num7 = _currentZAngle + brokenLeanOffset;
		float y = Mathf.Round(_currentYAngle / snapAngle) * snapAngle;
		float z = Mathf.Round(num7 / snapAngle) * snapAngle;
		bodyMeshRenderer.transform.localRotation = Quaternion.Euler(0f, y, z);
	}

	private static Vector3 SnapPosition(Vector3 v)
	{
		float num = 16f;
		v.x = Mathf.Round(v.x * num) / num;
		v.y = Mathf.Round(v.y * num) / num;
		v.z = Mathf.Round(v.z * num) / num;
		return v;
	}

	private void AnimateEyeOnScreen()
	{
		if (_screenRenderingSomething || _currentPrio > _animateEyePriority)
		{
			return;
		}
		PlayerController playerController = Manager.main?.player;
		if (playerController == null)
		{
			return;
		}
		Vector3 vector = playerController.RenderPosition - base.RenderPosition;
		if (vector.sqrMagnitude > 400f)
		{
			return;
		}
		if (_isEnraged)
		{
			if (vector.x < 0f - eyeDeadzone)
			{
				emoteScreen.PlayAnimation(-97154425);
			}
			else if (vector.x > eyeDeadzone)
			{
				emoteScreen.PlayAnimation(-195583514);
			}
			else
			{
				emoteScreen.PlayAnimation(-232516410);
			}
		}
		else if (vector.x < 0f - eyeDeadzone)
		{
			emoteScreen.PlayAnimation(2063870753);
		}
		else if (vector.x > eyeDeadzone)
		{
			emoteScreen.PlayAnimation(-1144262676);
		}
		else
		{
			emoteScreen.PlayAnimation(842569181);
		}
		screenLightSource.color = defaultLampColor;
	}

	private void UpdateEyeOnScreen(float x)
	{
		EyeDir eyeDir = ((!(Mathf.Abs(x) <= eyeDeadzone)) ? ((x < 0f) ? EyeDir.Left : EyeDir.Right) : EyeDir.Center);
		if (eyeDir != _eyeDir)
		{
			_eyeDir = eyeDir;
			emoteScreen.SetVariant(eyeDir switch
			{
				EyeDir.Right => EyeRight, 
				EyeDir.Left => EyeLeft, 
				_ => EyeCenter, 
			});
		}
	}

	private void OnValidate()
	{
		float x = Mathf.Clamp(editorEyeX, -10f, 10f);
		UpdateEyeOnScreen(x);
	}

	protected override void DeathEffect()
	{
		foreach (AudioManager.RunningSfxReference item in loopingSfx)
		{
			item.FadeOutAndStop();
		}
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		switch (animID)
		{
		case 1354651601:
			OverrideMonitor(100, animID, 6f, Color.red);
			Manager.effects.PlayPuff(PuffID.VoidEnragedPushback, base.RenderPosition, 1);
			AudioManager.Sfx(SfxID.robot_b_boss_enrage_phase_1_01, base.RenderPosition, 1f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.ROBOT_BOSS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 40f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: false, isPartOfSfxTableElement: false, 0f, randomStartTime: false, 0, 8f, 0f, 1f, 0.5f);
			lastEnrageAnimTime = Time.time;
			return;
		case -414722770:
			OverrideMonitor(1000, animID, 20f, Color.red);
			OnDeath();
			playAnimation(_animHashDeath);
			AudioManager.Sfx(SfxID.robot_b_boss_death_2_01, base.RenderPosition, 1f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.ROBOT_BOSS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 40f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: false, isPartOfSfxTableElement: false, 0f, randomStartTime: false, 0, 8f, 0f, 1f, 0.5f);
			return;
		case 436585760:
			_currentPrio = 99;
			_screenRenderingSomething = false;
			OverrideMonitor(100, animID, 10f, defaultLampColor);
			playAnimation(_animHashFirstGetup);
			return;
		case 910517187:
			_fellDownLockAnimations = false;
			playAnimation(_animHashStandUpAfterFall);
			if (Time.time - lastEnrageAnimTime >= 6f)
			{
				AudioManager.Sfx(SfxID.robot_boss_stand_up_1, base.RenderPosition, 1f, 1f, 0.04f, reuse: false, AudioManager.MixerGroupEnum.ROBOT_BOSS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 40f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: false, isPartOfSfxTableElement: false, 0.05f, randomStartTime: false, 0, 4f);
				OverrideMonitor(11, _isEnraged ? (-1831861683) : animID, 6f, defaultLampColor);
			}
			else
			{
				AudioManager.SfxFollowTransform(SfxTableID.robotBossAngrySfx, base.transform);
			}
			return;
		case -78586100:
			_fellDownLockAnimations = true;
			playAnimation(_animHashFall);
			OverrideMonitor(10, animID, 12f, defaultLampColor);
			anticipationFX.Stop();
			return;
		case -1014102059:
		{
			if (!EntityUtility.TryGetComponentData<RobotBossCD>(base.entity, base.world, out var value))
			{
				return;
			}
			anticipationFX.Play(value.rangeAttackPattern, value.rangeAttackDirection, _isEnraged, _isGoingCrazy);
			OverrideMonitor(4, _isEnraged ? 967764602 : animID, 4f, fireRangeLampColor);
			if (Time.time - lastChargeRangeSfxTime2 >= 3.8f)
			{
				sfxRef.Clear();
				AudioManager.SfxFollowTransform(SfxTableID.robotBossAnticipationLongSfx, base.transform, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, sfxRef, 3f, 0f, 0.2f);
				if (sfxRef.Count > 0)
				{
					AudioManager.RunningSfxReference runningSfxReference = sfxRef[sfxRef.Count - 1];
					if (runningSfxReference.IsValid)
					{
						runningSfxReference.FadeIn(0.4f, startVolumeAtZero: true);
					}
				}
				lastChargeRangeSfxTime2 = Time.time;
			}
			if (Time.time - lastChargeRangeSfxTime >= 3.3f)
			{
				sfxRef2.Clear();
				AudioManager.Sfx(SfxTableID.robotBossChargeRangeAttackSfx, base.RenderPosition, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, sfxRef2, forceStackable: false, 3f, 0f, 0.15f);
				if (sfxRef2.Count > 0)
				{
					AudioManager.RunningSfxReference runningSfxReference2 = sfxRef2[sfxRef2.Count - 1];
					if (runningSfxReference2.IsValid)
					{
						runningSfxReference2.FadeIn(0.25f, startVolumeAtZero: true);
					}
				}
				lastChargeRangeSfxTime = Time.time;
			}
			if (!_isEnraged || !(Time.time - lastChargeRangeSfxTime3 >= 8f) || !(Time.time - lastEnrageAnimTime >= 7f))
			{
				return;
			}
			sfxRef3.Clear();
			AudioManager.SfxFollowTransform(SfxTableID.robotBossEnrageLaughSfx, base.transform, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, sfxRef3, 5f, 0f, 0.1f);
			if (sfxRef3.Count > 0)
			{
				AudioManager.RunningSfxReference runningSfxReference3 = sfxRef3[sfxRef3.Count - 1];
				if (runningSfxReference3.IsValid)
				{
					runningSfxReference3.FadeIn(0.15f, startVolumeAtZero: true);
				}
			}
			lastChargeRangeSfxTime3 = Time.time;
			return;
		}
		case 1262804752:
			StartCoroutine(PlaySmallProjectileSfxSequence(_isEnraged));
			return;
		case 120187574:
			if (_isEnraged)
			{
				AudioManager.Sfx(SfxTableID.robotBossEnragedBigProjectileAttackSfx, base.RenderPosition, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, null, forceStackable: false, 8f, 0f, 1f, 0f, 0.6f);
			}
			else
			{
				AudioManager.Sfx(SfxTableID.robotBossBigProjectileAttackSfx, base.RenderPosition, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, null, forceStackable: false, 8f, 0f, 1f, 0f, 0.6f);
			}
			return;
		case 1203776827:
			if (!_fellDownLockAnimations)
			{
				mortarRocketsFired = 0;
				OverrideMonitor(5, _isEnraged ? 57031551 : animID, 2f, fireMortarLampColor);
				AudioManager.SfxFollowTransform(SfxTableID.robotBossAnticipationSfx, base.transform, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, null, 4f);
				return;
			}
			break;
		}
		if (animID == -871297121 && !_fellDownLockAnimations)
		{
			if (mortarRocketsFired == 0)
			{
				animator.SetTrigger("rocketShot");
				rocketShotSmoke.Play();
			}
			if (mortarRocketsFired % 2 == 0)
			{
				AudioManager.SfxFollowTransform(SfxTableID.robotBossMortarAttackLaunchSfx, base.transform, rng.NextFloat(0.78f, 0.96f), 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, null, 4f, 0f, 1f, 0f, 0.6f);
			}
			else
			{
				AudioManager.SfxFollowTransform(SfxTableID.robotBossMortarFireAttackLaunchSfx, base.transform, rng.NextFloat(0.8f, 0.9f), 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, null, 4f, 0f, 1f, 0f, 0.6f);
			}
			mortarRocketsFired++;
		}
	}

	private void playAnimation(int hash)
	{
		animator.Update(0f);
		animator.CrossFade(hash, 0f, 0, 0f);
		animator.Update(0f);
	}

	private void OverrideMonitor(int priority, int hash, float dur, Color screenColor, bool animated = true)
	{
		if (priority > _currentPrio)
		{
			_currentPrio = priority;
			_screenRenderingSomething = true;
			if (animated)
			{
				emoteScreen.PlayAnimation(hash);
			}
			else
			{
				emoteScreen.SetVariant(hash);
			}
			screenLightSource.color = screenColor;
			if (_overrideScreenRoutine == null)
			{
				_overrideScreenRoutine = StartCoroutine(stopOverrideEyeSprite_Coroutine(dur));
				return;
			}
			StopCoroutine(_overrideScreenRoutine);
			_overrideScreenRoutine = StartCoroutine(stopOverrideEyeSprite_Coroutine(dur));
		}
	}

	private void ResetOverrideSettings()
	{
		_screenRenderingSomething = false;
		_currentPrio = -1;
		_overrideScreenRoutine = null;
	}

	private IEnumerator stopOverrideEyeSprite_Coroutine(float dur)
	{
		_screenRenderingSomething = true;
		yield return new WaitForSeconds(dur);
		ResetOverrideSettings();
	}

	private IEnumerator PlaySmallProjectileSfxSequence(bool isEnraged)
	{
		if (isEnraged)
		{
			AudioManager.Sfx(SfxTableID.robotBossEnragedSmallProjectileAttackSfx, base.RenderPosition, 0.9f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.ROBOT_BOSS, reuseSfxs: false, playOnGamepad: false, null, forceStackable: false, 6f, 0f, 1f, 0f, 0.6f);
			yield return new WaitForSeconds(UnityEngine.Random.Range(0.03f, 0.11f));
			AudioManager.Sfx(SfxTableID.robotBossEnragedSmallProjectileAttackSfx, base.RenderPosition, 0.77f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.ROBOT_BOSS, reuseSfxs: false, playOnGamepad: false, null, forceStackable: false, 6f, 0f, 1f, 0f, 0.7f);
			yield return new WaitForSeconds(UnityEngine.Random.Range(0.05f, 0.11f));
			AudioManager.Sfx(SfxTableID.robotBossEnragedSmallProjectileAttackSfx, base.RenderPosition, 0.77f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.ROBOT_BOSS, reuseSfxs: false, playOnGamepad: false, null, forceStackable: false, 6f, 0f, 1f, 0f, 0.7f);
		}
		else
		{
			AudioManager.Sfx(SfxTableID.robotBossSmallProjectileAttackSfx, base.RenderPosition, 0.9f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.ROBOT_BOSS, reuseSfxs: false, playOnGamepad: false, null, forceStackable: false, 8f, 0f, 1f, 0f, 0.6f);
			yield return new WaitForSeconds(UnityEngine.Random.Range(0.03f, 0.11f));
			AudioManager.Sfx(SfxTableID.robotBossSmallProjectileAttackSfx, base.RenderPosition, 0.77f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.ROBOT_BOSS, reuseSfxs: false, playOnGamepad: false, null, forceStackable: false, 8f, 0f, 1f, 0f, 0.7f);
			yield return new WaitForSeconds(UnityEngine.Random.Range(0.05f, 0.11f));
			AudioManager.Sfx(SfxTableID.robotBossSmallProjectileAttackSfx, base.RenderPosition, 0.77f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.ROBOT_BOSS, reuseSfxs: false, playOnGamepad: false, null, forceStackable: false, 8f, 0f, 1f, 0f, 0.7f);
		}
	}

	protected override void OnHide()
	{
		base.OnHide();
		if (loopingSfx != null)
		{
			foreach (AudioManager.RunningSfxReference item in loopingSfx)
			{
				item.FadeOutAndStop();
			}
			loopingSfx.Clear();
		}
		if (sfxRef != null)
		{
			foreach (AudioManager.RunningSfxReference item2 in sfxRef)
			{
				item2.FadeOutAndStop();
			}
			sfxRef.Clear();
		}
		if (sfxRef2 != null)
		{
			foreach (AudioManager.RunningSfxReference item3 in sfxRef2)
			{
				item3.FadeOutAndStop();
			}
			sfxRef2.Clear();
		}
		if (sfxRef3 != null)
		{
			foreach (AudioManager.RunningSfxReference item4 in sfxRef3)
			{
				item4.FadeOutAndStop();
			}
			sfxRef3.Clear();
		}
		if (_moveLoopSfx.IsValid)
		{
			_moveLoopSfx.FadeOutAndStop(0.25f);
			_moveLoopSfx = default(AudioManager.RunningSfxReference);
			moveLoopActive = false;
		}
	}

	public void AE_StartScan()
	{
		emoteScreen.PlayAnimation(-1619438193);
		AudioManager.Sfx(SfxID.robot_d_boss_intro_1_01, base.RenderPosition, 1f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.CINEMATIC_EVENTS_2, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 55f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: false, isPartOfSfxTableElement: false, 0f, randomStartTime: false, 0, 8f, 0f, 1f, 0.4f);
	}

	public void AE_FallDownHitGround()
	{
		AudioManager.Sfx(SfxID.robot_boss_fall_down_1, base.RenderPosition, 1f, 1f, 0.04f, reuse: false, AudioManager.MixerGroupEnum.ROBOT_BOSS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 40f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: false, isPartOfSfxTableElement: false, 0.05f, randomStartTime: false, 0, 4f);
	}

	public void AE_StartParasiteSequence()
	{
		StartCoroutine(OutroLines_Coroutine());
	}

	public void AE_Getup()
	{
		getUpParticles.Play();
		Manager.camera.ShakeCameraNow(2f, 1.5f, 1.5f, null, null, 0, 15f);
		_animateLegsOverride = true;
	}

	public void AE_Scream()
	{
		_animateLegsOverride = true;
	}

	public void AE_GetupStop()
	{
		getUpParticles.Stop();
		AudioManager.Sfx(SfxTableID.robotBossAnticipationLongSfx, base.RenderPosition);
		_animateLegsOverride = false;
	}

	public void AE_BodyExplode()
	{
		leanTransform.gameObject.SetActive(value: false);
		DynamicBuffer<RobotBossLegsBuffer> buffer = EntityUtility.GetBuffer<RobotBossLegsBuffer>(base.entity, base.world);
		for (int i = 0; i < buffer.Length; i++)
		{
			if (Manager.memory.TryGetEntityMono(buffer[i].leg, out RobotBossLeg monoT) && monoT != null)
			{
				monoT.wholeLegRotatorTransform.gameObject.SetActive(value: false);
			}
		}
		Manager.effects.PlayPuff(PuffID.RobotBossDeath, base.RenderPosition, 1);
		AudioManager.Sfx(SfxID.robot_a_boss_death_explosion_1_01, base.RenderPosition, 1f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.ROBOT_BOSS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 40f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: false, isPartOfSfxTableElement: false, 0f, randomStartTime: false, 0, 8f, 0f, 1f, 0.5f);
	}

	public void AE_ScreenShake()
	{
		Manager.camera.ShakeCameraNow(1f, 1.5f, 1.5f, null, null, 0, 15f);
	}

	public void AE_EnableDeathPops()
	{
		dyingPops.Play();
	}

	public void AE_DisableDeathPops()
	{
		dyingPops.Stop();
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		if (Manager.ui.mapUI.IsShowingShrineMarker(ObjectID.ExcavationBossStatue))
		{
			Manager.ui.chatWindow.AddInfoText(ChatWindow.MessageTextType.TalkToTheCore);
			base.world.GetExistingSystemManaged<PugScanClientSystem>().Scan(new ScanRequestCD
			{
				objectToScan = new ObjectDataCD
				{
					objectID = ObjectID.ExcavationBossStatue
				},
				sendResponse = false,
				typeOfRequest = PugScanType.HideMarker
			});
		}
	}

	public Vector3 GetNextMortarStartWorldPosition()
	{
		if (mortarLaunchPoints.Count == 0)
		{
			return base.WorldPosition;
		}
		Vector3 position = mortarLaunchPoints[_nextMortarIndex].position;
		_nextMortarIndex = (_nextMortarIndex + 1) % mortarLaunchPoints.Count;
		return EntityMonoBehaviour.ToWorldFromRender(position);
	}
}
