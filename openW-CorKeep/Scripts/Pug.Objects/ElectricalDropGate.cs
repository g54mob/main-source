using System.Collections;
using System.Collections.Generic;
using Pug.Automation;
using Pug.RP;
using Pug.Sprite;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class ElectricalDropGate : EntityMonoBehaviour
{
	private static readonly int OpenValue = Animator.StringToHash("isOpen");

	private bool _isOpen;

	public GameObject horizontalGrouping;

	public GameObject verticalGrouping;

	private int activeVariation = -1;

	public List<MeshRenderer> shadowRenderers;

	private bool _wasInTransition;

	private float3 _lastDirection = float3.zero;

	private bool _wasInWater;

	public SpriteObject electricitySprite;

	private Color _baselineElectricityEmission;

	private static readonly int InWaterID = Animator.StringToHash("inWater");

	private static readonly int AnimImmediateID = Animator.StringToHash("triggerImmediate");

	protected override void Awake()
	{
		base.Awake();
		_baselineElectricityEmission = ((electricitySprite != null) ? electricitySprite.emissiveColor : Color.black);
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		_wasInWater = false;
		_isOpen = false;
		_lastDirection = float3.zero;
		activeVariation = -1;
		animator.SetBool(InWaterID, value: false);
		UpdateGraphics();
		UpdateAnimation(initialUpdate: true);
	}

	protected override void OnShow()
	{
		Manager.multiMap.SetHiddenTile(base.WorldPosition.RoundToInt2(), 4, TileType.circuitPlate, 0);
		Manager.multiMap.SetHiddenTile(base.WorldPosition.RoundToInt2(), 34, TileType.thinWall, 0);
		for (int i = 41; i < 52; i++)
		{
			Manager.multiMap.SetHiddenTile(base.WorldPosition.RoundToInt2(), i, TileType.thinWall, 0);
		}
		base.OnShow();
	}

	protected override void OnHide()
	{
		Manager.multiMap.ClearHiddenTileOfType(base.WorldPosition.RoundToInt2(), TileType.circuitPlate);
		Manager.multiMap.ClearHiddenTileOfType(base.WorldPosition.RoundToInt2(), TileType.thinWall);
		base.OnHide();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		UpdateGraphics();
		UpdateAnimation();
		UpdateElectricitySprite();
	}

	public override void UpdateGraphicsFromObjectInfo(ObjectInfo info)
	{
		UpdateGraphics();
	}

	private void UpdateGraphics()
	{
		if (base.entity == Entity.Null)
		{
			return;
		}
		int num = base.variation;
		if (activeVariation != num)
		{
			switch (num)
			{
			case 0:
				horizontalGrouping.SetActive(value: true);
				verticalGrouping.SetActive(value: false);
				break;
			case 1:
				horizontalGrouping.SetActive(value: false);
				verticalGrouping.SetActive(value: true);
				break;
			}
			activeVariation = num;
		}
		if (EntityUtility.TryGetComponentData<DirectionCD>(base.entity, base.world, out var value) && math.any(_lastDirection != value.direction))
		{
			bool flag = value.direction.z != 0f;
			horizontalGrouping.SetActive(flag);
			verticalGrouping.SetActive(!flag);
		}
		bool flag2 = Manager.multiMap.GetTileLayerLookup().GetTopTile(base.WorldPosition.RoundToInt2()).tileType == TileType.water;
		if (flag2 != _wasInWater)
		{
			_wasInWater = flag2;
			animator.SetBool(InWaterID, flag2);
		}
	}

	private void UpdateAnimation(bool initialUpdate = false)
	{
		bool flag = animator.IsInTransition(0);
		if ((flag || _wasInTransition) && shadowRenderers != null && shadowRenderers.Count > 0)
		{
			Bounds bounds = shadowRenderers[0].bounds;
			for (int i = 1; i < shadowRenderers.Count; i++)
			{
				bounds.Encapsulate(shadowRenderers[i].bounds);
			}
			Shadows.MarkAreaDirty(bounds, allowAmortization: true);
		}
		_wasInTransition = flag;
		bool swap = EntityUtility.GetComponentData<SwapColliderCD>(base.entity, base.world).swap;
		if (swap != _isOpen)
		{
			_isOpen = swap;
			animator.SetBool(OpenValue, _isOpen);
			if (!initialUpdate)
			{
				StartCoroutine(PlayGateMoveSfxWithDelay(0.17f));
			}
		}
		if (initialUpdate)
		{
			animator.ResetTrigger(AnimImmediateID);
			animator.SetTrigger(AnimImmediateID);
		}
	}

	private void UpdateElectricitySprite()
	{
		if (!(electricitySprite == null))
		{
			EntityUtility.TryGetComponentData<ElectricityCD>(base.entity, base.world, out var value);
			bool hasEnoughElectricityToPowerStuff = value.hasEnoughElectricityToPowerStuff;
			electricitySprite.emissiveColor = (hasEnoughElectricityToPowerStuff ? _baselineElectricityEmission : Color.black);
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.DirtBlockDust, base.transform.position, 6);
	}

	private IEnumerator PlayGateMoveSfxWithDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		AudioManager.Sfx(SfxTableID.gateMoveSfx, base.transform.position, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, null, forceStackable: false, 1f, 0f, 0.1f);
	}
}
