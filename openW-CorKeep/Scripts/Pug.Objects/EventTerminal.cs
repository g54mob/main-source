using System.Collections;
using System.Collections.Generic;
using Pug.Sprite;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class EventTerminal : EntityMonoBehaviour
{
	public PugText clockText;

	public Transform progressBarPivot;

	public RestrictedZoneEffect restrictedZoneEffect;

	public ScanZoneEffect scanZoneEffect;

	public SpriteObject spriteObjectMain;

	private Color _spriteObjectMainEmissiveColor;

	public SpriteObject spriteObjectClock;

	public SpriteObject spriteObjectClockNextTick;

	public List<SpriteObject> wireSpriteObjects;

	[ColorUsage(true, true)]
	public Color clockGoodColor;

	[ColorUsage(true, true)]
	public Color clockMediumColor;

	[ColorUsage(true, true)]
	public Color clockBadGolor;

	private int previousSeconds = -1;

	private bool hasPlayedCompleteSound;

	private int endAnim = Animator.StringToHash("end");

	private int inactiveAnim = Animator.StringToHash("inactive");

	private int activeAnim = Animator.StringToHash("active");

	private int m_prevVariation;

	private float m_localTimer;

	private bool canPlayTerminalZoneTurnRedSound;

	protected override void Awake()
	{
		_spriteObjectMainEmissiveColor = spriteObjectMain.emissiveColor;
		base.Awake();
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		hasPlayedCompleteSound = false;
		previousSeconds = -1;
		m_prevVariation = base.objectData.variation;
		if (m_prevVariation == 1)
		{
			FinalizeSequence();
		}
		m_localTimer = EntityUtility.GetComponentData<EventTerminalCD>(base.entity, base.world).timer;
	}

	protected override void OnShow()
	{
		int2 int5 = base.WorldPosition.RoundToInt2();
		Manager.multiMap.SetHiddenTile(int5 + new int2(-1, -1), 4, TileType.circuitPlate, 0);
		Manager.multiMap.SetHiddenTile(int5 + new int2(1, -1), 4, TileType.circuitPlate, 0);
		Manager.multiMap.SetHiddenTile(int5 + new int2(1, 1), 4, TileType.circuitPlate, 0);
		Manager.multiMap.SetHiddenTile(int5 + new int2(-1, 1), 4, TileType.circuitPlate, 0);
		base.OnShow();
	}

	protected override void OnHide()
	{
		int2 int5 = base.WorldPosition.RoundToInt2();
		Manager.multiMap.ClearHiddenTileOfType(int5 + new int2(-1, -1), TileType.circuitPlate);
		Manager.multiMap.ClearHiddenTileOfType(int5 + new int2(1, -1), TileType.circuitPlate);
		Manager.multiMap.ClearHiddenTileOfType(int5 + new int2(1, 1), TileType.circuitPlate);
		Manager.multiMap.ClearHiddenTileOfType(int5 + new int2(-1, 1), TileType.circuitPlate);
		base.OnHide();
	}

	public void Use()
	{
		PlayerController player = Manager.main.player;
		if (!(player == null))
		{
			player.playerCommandSystem.ActivateTerminal(base.entity);
			AudioManager.Sfx(SfxTableID.eventTerminalStart, base.RenderPosition);
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (!EntityUtility.HasComponentData<EventTerminalCD>(base.entity, base.world))
		{
			return;
		}
		EventTerminalCD componentData = EntityUtility.GetComponentData<EventTerminalCD>(base.entity, base.world);
		float num = componentData.radius * 2f;
		scanZoneEffect.transform.localScale = new Vector3(num, 1f, num);
		int num2 = base.objectData.variation;
		scanZoneEffect.scanIsVisible = componentData.terminalIsActive && num2 != 0;
		if (EntityUtility.HasComponentData<ImmunityZoneCD>(base.entity, base.world))
		{
			num = EntityUtility.GetComponentData<ImmunityZoneCD>(base.entity, base.world).radius * 2f;
			restrictedZoneEffect.transform.localScale = new Vector3(num, 1f, num);
		}
		if (num2 == 1)
		{
			if (m_prevVariation != 1)
			{
				StartCoroutine(EndSequence());
			}
			m_prevVariation = num2;
			return;
		}
		restrictedZoneEffect.Activate();
		m_prevVariation = num2;
		restrictedZoneEffect.gameObject.SetActive(value: true);
		spriteObjectMain.PlayAnimation(inactiveAnim);
		UpdateWires();
		float x = componentData.timer - m_localTimer;
		bool flag = math.abs(x) > 1f && math.abs(x) < componentData.duration * 0.5f && componentData.terminalIsActive;
		if (flag)
		{
			float num3 = math.sign(x);
			m_localTimer += Time.deltaTime * 20f * num3;
		}
		else if (componentData.terminalIsActive)
		{
			m_localTimer = componentData.timer;
		}
		else
		{
			m_localTimer = componentData.duration;
		}
		float num4 = (componentData.terminalIsActive ? Mathf.Clamp01(1f - m_localTimer / componentData.duration) : 0f);
		spriteObjectClock.gameObject.SetActive(componentData.terminalIsActive);
		spriteObjectClockNextTick.gameObject.SetActive(componentData.terminalIsActive);
		spriteObjectClock.animationTime = num4 * 15f;
		spriteObjectClock.emissiveColor = ((!componentData.terminalIsActive) ? Color.white : ((!componentData.anyPlayerIsInsideZone) ? clockBadGolor : ((componentData.timerSpeed > 0.7f) ? clockGoodColor : clockMediumColor)));
		spriteObjectClockNextTick.animationTime = num4 * 15f + 1f;
		spriteObjectClockNextTick.emissiveColor = ((flag || !componentData.anyPlayerIsInsideZone) ? Color.black : Color.Lerp(Color.black, Color.Lerp(spriteObjectClock.emissiveColor, Color.black, 0.5f), math.abs(math.sin(Time.time * 4f * componentData.timerSpeed)) * -1f + 1f));
		if (canPlayTerminalZoneTurnRedSound && componentData.terminalIsActive && !componentData.anyPlayerIsInsideZone)
		{
			canPlayTerminalZoneTurnRedSound = false;
			AudioManager.Sfx(SfxTableID.eventTerminalTurnRed, base.RenderPosition);
		}
		else if (!componentData.terminalIsActive || componentData.anyPlayerIsInsideZone)
		{
			canPlayTerminalZoneTurnRedSound = true;
		}
		scanZoneEffect.progressSpeed = ((componentData.terminalIsActive && componentData.anyPlayerIsInsideZone) ? componentData.timerSpeed : 0f);
		spriteObjectMain.emissiveColor = (componentData.terminalIsActive ? Color.black : _spriteObjectMainEmissiveColor);
		int num5 = (int)m_localTimer;
		if (componentData.terminalIsActive && num5 <= 10)
		{
			if (previousSeconds != num5)
			{
				previousSeconds = num5;
				AudioManager.Sfx(SfxTableID.eventTerminalBeep, base.RenderPosition, 1f, 1.2f - (float)num5 / 30f);
				flashable.FlashLinearNoCurve();
			}
			if (m_localTimer < 0.1f && !hasPlayedCompleteSound)
			{
				hasPlayedCompleteSound = true;
				AudioManager.Sfx(SfxTableID.eventTerminalComplete, base.RenderPosition);
			}
		}
		else
		{
			previousSeconds = -1;
		}
	}

	private IEnumerator EndSequence()
	{
		spriteObjectMain.PlayAnimation(activeAnim);
		restrictedZoneEffect.Kill(showRing: true);
		yield return new WaitForSeconds(restrictedZoneEffect.killWindupDuration);
		AudioManager.Sfx(SfxTableID.eventTerminalShockwave, base.RenderPosition);
		FinalizeSequence();
	}

	private void FinalizeSequence()
	{
		spriteObjectMain.PlayAnimation(endAnim);
		spriteObjectClock.gameObject.SetActive(value: false);
		spriteObjectClockNextTick.gameObject.SetActive(value: false);
	}

	private void UpdateWires()
	{
		DynamicBuffer<EventTerminalElectricityEntityBuffer> buffer = EntityUtility.GetBuffer<EventTerminalElectricityEntityBuffer>(base.entity, base.world);
		if (buffer.Length >= 8)
		{
			for (int i = 0; i < 4; i++)
			{
				int electricityVariant = GetElectricityVariant(buffer[i * 2], buffer[i * 2 + 1]);
				wireSpriteObjects[i].SetVariantByIndex(electricityVariant);
			}
		}
	}

	private int GetElectricityVariant(EventTerminalElectricityEntityBuffer electricity1, EventTerminalElectricityEntityBuffer electricity2)
	{
		if (electricity1.isActive && electricity2.isActive)
		{
			return 3;
		}
		if (electricity2.isActive)
		{
			return 2;
		}
		if (electricity1.isActive)
		{
			return 1;
		}
		return 0;
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		ExplosionEffect.Play(base.transform.position + new Vector3(1f, 0f, 1f));
	}
}
