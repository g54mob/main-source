using System.Collections.Generic;
using UnityEngine;

public class RobotPatroller : EntityMonoBehaviour, IMortarShooter
{
	private enum LightState
	{
		Default = 0,
		Animating = 1,
		InCombat = 2
	}

	[Header("Lights")]
	[ColorUsage(false, true)]
	public Color defaultBulbEmissive;

	[ColorUsage(false, true)]
	public Color combatBulbEmissive;

	public Transform pointLamps;

	public Transform spotLamps;

	public List<Light> animatedLights;

	public Color defaultLightColor;

	public Color combatLightColor;

	public int combatBlinkCount = 3;

	public float combatBlinkTotalDuration = 1f;

	private LightState _lightState;

	public Transform spinTransform;

	public float spinDegBySeconds;

	[Header("Projectile")]
	public List<Transform> mortarLaunchPoints;

	private int _nextMortarIndex;

	private float _currentSpinAngleDeg;

	private Vector3 lastPosition;

	private List<AudioManager.RunningSfxReference> loopingSfx = new List<AudioManager.RunningSfxReference>();

	private float walkSfxFadeInDuration = 0.55f;

	private float walkSfxFadeOutDuration = 0.1f;

	private static float lastAnticipationSfxTime = -999f;

	private const float anticipationSfxCooldown = 1.5f;

	private bool isDisplayingCombatLights;

	private float _animateLightTimer;

	private int _animateLightBlink;

	protected override bool updateAnimOrientation => true;

	protected override bool updateAnimMovement => true;

	public override void OnOccupied()
	{
		base.OnOccupied();
		pointLamps.gameObject.SetActive(value: false);
		spotLamps.gameObject.SetActive(value: true);
		_currentSpinAngleDeg = Random.Range(0f, 180f);
		DisplayCombatLights(value: false);
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		pointLamps.gameObject.SetActive(value: false);
		spotLamps.gameObject.SetActive(value: false);
	}

	public override void OnFree()
	{
		base.OnFree();
		if (loopingSfx == null)
		{
			return;
		}
		foreach (AudioManager.RunningSfxReference item in loopingSfx)
		{
			item.FadeOutAndStop();
		}
		loopingSfx.Clear();
	}

	private void DisplayCombatLights(bool value)
	{
		foreach (Light animatedLight in animatedLights)
		{
			animatedLight.color = (value ? combatLightColor : defaultLightColor);
		}
		spriteObjects[0].emissiveColor = (value ? combatBulbEmissive : defaultBulbEmissive);
		isDisplayingCombatLights = value;
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		UpdateSpinning();
		bool flag = base.WorldPosition != lastPosition;
		if (flag && loopingSfx.Count == 0)
		{
			foreach (AudioManager.RunningSfxReference item in loopingSfx)
			{
				item.FadeOutAndStop();
			}
			loopingSfx.Clear();
			AudioManager.SfxFollowTransform(SfxTableID.robotPatrollerMovementSfx, base.transform, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, loopingSfx, 5f);
			foreach (AudioManager.RunningSfxReference item2 in loopingSfx)
			{
				if (item2.IsValid)
				{
					item2.FadeIn(walkSfxFadeInDuration, startVolumeAtZero: true);
				}
			}
		}
		else if (!flag && loopingSfx.Count > 0)
		{
			foreach (AudioManager.RunningSfxReference item3 in loopingSfx)
			{
				if (item3.IsValid)
				{
					item3.FadeOutAndStop(walkSfxFadeOutDuration);
				}
			}
			loopingSfx.Clear();
		}
		lastPosition = base.WorldPosition;
		UpdateLightColors();
	}

	private void UpdateLightColors()
	{
		CheckForLightStateChange();
		AnimateLightColors();
	}

	private void CheckForLightStateChange()
	{
		EntityUtility.TryGetComponentData<IsInCombatCD>(base.entity, base.world, out var value);
		bool isInCombat = value.isInCombat;
		if (isInCombat && _lightState == LightState.Default)
		{
			_lightState = LightState.Animating;
			_animateLightTimer = 0f;
			_animateLightBlink = 0;
		}
		else if (!isInCombat && _lightState != LightState.Default)
		{
			_lightState = LightState.Default;
		}
	}

	private void AnimateLightColors()
	{
		switch (_lightState)
		{
		case LightState.Default:
			if (isDisplayingCombatLights)
			{
				DisplayCombatLights(value: false);
			}
			break;
		case LightState.Animating:
			_animateLightTimer -= Time.deltaTime;
			if (_animateLightTimer <= 0f)
			{
				DisplayCombatLights(!isDisplayingCombatLights);
				_animateLightBlink++;
				_animateLightTimer = combatBlinkTotalDuration / (float)(combatBlinkCount * 2 + 1);
				if (_animateLightBlink >= combatBlinkCount * 2 + 1)
				{
					_lightState = LightState.InCombat;
				}
			}
			break;
		case LightState.InCombat:
			if (!isDisplayingCombatLights)
			{
				DisplayCombatLights(value: true);
			}
			break;
		}
	}

	private void UpdateSpinning()
	{
		if (!(spinTransform == null))
		{
			_currentSpinAngleDeg += spinDegBySeconds * Time.deltaTime;
			if (_currentSpinAngleDeg > 360f)
			{
				_currentSpinAngleDeg -= 360f;
			}
			if (_currentSpinAngleDeg < -360f)
			{
				_currentSpinAngleDeg += 360f;
			}
			spinTransform.localRotation = Quaternion.AngleAxis(_currentSpinAngleDeg, Vector3.up);
		}
	}

	protected override void OnHide()
	{
		base.OnHide();
		if (loopingSfx == null)
		{
			return;
		}
		foreach (AudioManager.RunningSfxReference item in loopingSfx)
		{
			item.FadeOutAndStop();
		}
		loopingSfx.Clear();
	}

	public Vector3 GetNextMortarStartWorldPosition()
	{
		Vector3 position = mortarLaunchPoints[_nextMortarIndex].position;
		_nextMortarIndex = (_nextMortarIndex + 1) % mortarLaunchPoints.Count;
		return EntityMonoBehaviour.ToWorldFromRender(position);
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -1014102059 && Time.time - lastAnticipationSfxTime >= 1.5f)
		{
			AudioManager.SfxFollowTransform(SfxTableID.robotEnemyAnticipation1Sfx, base.transform);
			lastAnticipationSfxTime = Time.time;
		}
	}
}
