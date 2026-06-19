using System;
using System.Collections.Generic;
using Pug.Automation;
using Pug.Sprite;
using Pug.UnityExtensions;
using PugTilemap;
using UnityEngine;

public class KinematicDynamo : EntityMonoBehaviour
{
	private enum State
	{
		Uninitialized = 0,
		On = 1,
		Off = 2
	}

	[Serializable]
	public struct ElectricityEmissiveSprites
	{
		public SpriteObject sprite;

		[HideInInspector]
		public Color initialEmissiveColor;
	}

	public List<ElectricityEmissiveSprites> electricityEmissiveSprites;

	public Transform stickTransform;

	public AnimationCurve tempStickMoveCurve;

	private float _animationTimer;

	private float _randomSign;

	private State _state;

	protected override void Awake()
	{
		base.Awake();
		for (int i = 0; i < electricityEmissiveSprites.Count; i++)
		{
			ElectricityEmissiveSprites value = electricityEmissiveSprites[i];
			value.initialEmissiveColor = value.sprite.emissiveColor;
			electricityEmissiveSprites[i] = value;
		}
	}

	protected override void OnShow()
	{
		Manager.multiMap.SetHiddenTile(base.WorldPosition.RoundToInt2(), 4, TileType.circuitPlate, 0);
		base.OnShow();
	}

	protected override void OnHide()
	{
		Manager.multiMap.ClearHiddenTileOfType(base.WorldPosition.RoundToInt2(), TileType.circuitPlate);
		base.OnHide();
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		_animationTimer = tempStickMoveCurve.keys[^1].time + 1f;
		stickTransform.localRotation = Quaternion.identity;
		_state = State.Uninitialized;
		foreach (ElectricityEmissiveSprites electricityEmissiveSprite in electricityEmissiveSprites)
		{
			electricityEmissiveSprite.sprite.emissiveColor = Color.black;
		}
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		if (animID == -1533413595)
		{
			_animationTimer = 0f;
			_randomSign = UnityEngine.Random.Range(0, 2) * 2 - 1;
			AudioManager.Sfx(SfxTableID.switchClickGenericSfx, base.transform.position);
		}
		else
		{
			base.HandleAnimationTrigger(animID);
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		UpdateElectricityState();
		UpdateStickAnimation();
	}

	private void UpdateElectricityState()
	{
		EntityUtility.TryGetComponentData<ElectricityCD>(base.entity, base.world, out var value);
		State state = ((!value.blocksElectricity) ? State.On : State.Off);
		if (state == _state)
		{
			return;
		}
		_state = state;
		foreach (ElectricityEmissiveSprites electricityEmissiveSprite in electricityEmissiveSprites)
		{
			electricityEmissiveSprite.sprite.emissiveColor = ((_state == State.On) ? electricityEmissiveSprite.initialEmissiveColor : Color.black);
		}
	}

	private void UpdateStickAnimation()
	{
		if (!(_animationTimer > tempStickMoveCurve.keys[^1].time))
		{
			_animationTimer += Time.deltaTime;
			stickTransform.localRotation = Quaternion.Euler(0f, 0f, _randomSign * tempStickMoveCurve.Evaluate(_animationTimer));
		}
	}
}
