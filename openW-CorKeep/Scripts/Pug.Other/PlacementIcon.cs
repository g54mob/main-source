using System.Collections.Generic;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Mathematics;
using UnityEngine;

public class PlacementIcon : MonoBehaviour
{
	public SpriteRenderer SR;

	public Sprite goodSprite;

	public Sprite badSprite;

	[Header("Default")]
	public List<Sprite> goodDirSprites;

	public List<Sprite> badDirSprites;

	[Header("Bidirectional")]
	public List<Sprite> goodBiDirSprites;

	public List<Sprite> badBiDirSprites;

	[Header("Bidirectional")]
	public List<Sprite> goodBiDirWithHintSprites;

	public List<Sprite> badBiDirWithHintSprites;

	[Header("Cross Circuit")]
	public List<Sprite> goodCrossCircuitSprites;

	public List<Sprite> badCrossCircuitSprites;

	[Header("TCircuit")]
	public List<Sprite> goodTCircuitSprites;

	public List<Sprite> badTCircuitSprites;

	[Header("LCircuit")]
	public List<Sprite> goodLCircuitSprites;

	public List<Sprite> badLCircuitSprites;

	[Header("ICircuit")]
	public List<Sprite> goodICircuitSprites;

	public List<Sprite> badICircuitSprites;

	[Header("Padding")]
	public SpriteRenderer paddingSR;

	public Sprite goodSpritePadding;

	public Sprite badSpritePadding;

	public Transform startPosition;

	public Transform targetPosition;

	private TimerSimple moveToPositionTimer = new TimerSimple(0.04f);

	private float currentFadeValue;

	private static readonly int Transparancy = Shader.PropertyToID("_transparancy");

	public void SetState(bool isGood, int variation, bool canChangeVariation, DisplayPlaceableType displayPlaceableType)
	{
		SR.sprite = (isGood ? goodSprite : badSprite);
		paddingSR.sprite = (isGood ? goodSpritePadding : badSpritePadding);
		if (!canChangeVariation)
		{
			return;
		}
		int2 int5 = default(int2);
		if (displayPlaceableType == DisplayPlaceableType.Default || displayPlaceableType == DisplayPlaceableType.Bidirectional || displayPlaceableType == DisplayPlaceableType.BidirectionalWithHint)
		{
			int5 = DirectionBasedOnVariationCD.GetDirectionFromVariation(variation);
			if (math.all(int5 == int2.zero))
			{
				return;
			}
		}
		switch (displayPlaceableType)
		{
		case DisplayPlaceableType.Default:
			SetSpriteDefault(int5, isGood, goodDirSprites, badDirSprites);
			break;
		case DisplayPlaceableType.Bidirectional:
			SetSpriteFromBidirectional(int5, isGood);
			break;
		case DisplayPlaceableType.CrossCircuit:
			SetSpriteFromVariation(variation, isGood, goodCrossCircuitSprites, badCrossCircuitSprites);
			break;
		case DisplayPlaceableType.TCircuit:
			SetSpriteFromVariation(variation, isGood, goodTCircuitSprites, badTCircuitSprites);
			break;
		case DisplayPlaceableType.LCircuit:
			SetSpriteFromVariation(variation, isGood, goodLCircuitSprites, badLCircuitSprites);
			break;
		case DisplayPlaceableType.ICircuit:
			SetSpriteFromVariation(variation, isGood, goodICircuitSprites, badICircuitSprites);
			break;
		case DisplayPlaceableType.BidirectionalWithHint:
			SetSpriteDefault(int5, isGood, goodBiDirWithHintSprites, badBiDirWithHintSprites);
			break;
		}
	}

	private void SetSpriteDefault(int2 direction, bool isGood, List<Sprite> goodSprites, List<Sprite> badSprites)
	{
		List<Sprite> list = (isGood ? goodSprites : badSprites);
		if (math.all(direction == Direction.forward.i2))
		{
			SR.sprite = list[0];
		}
		else if (math.all(direction == Direction.right.i2))
		{
			SR.sprite = list[1];
		}
		else if (math.all(direction == Direction.back.i2))
		{
			SR.sprite = list[2];
		}
		else if (math.all(direction == Direction.left.i2))
		{
			SR.sprite = list[3];
		}
	}

	private void SetSpriteFromBidirectional(int2 direction, bool isGood)
	{
		List<Sprite> list = (isGood ? goodBiDirSprites : badBiDirSprites);
		if (math.all(direction == Direction.forward.i2) || math.all(direction == Direction.back.i2))
		{
			SR.sprite = list[0];
		}
		else if (math.all(direction == Direction.right.i2) || math.all(direction == Direction.left.i2))
		{
			SR.sprite = list[1];
		}
	}

	private void SetSpriteFromVariation(int variation, bool isGood, List<Sprite> goodSprites, List<Sprite> badSprites)
	{
		List<Sprite> list = (isGood ? goodSprites : badSprites);
		SR.sprite = list[variation];
	}

	public void SetSize(int width, int height)
	{
		SR.size = new Vector2(width, height);
	}

	public void SetPosition(Vector3Int position, bool immediate = false)
	{
		if (targetPosition.position != position)
		{
			startPosition.position = base.transform.position;
			targetPosition.position = position;
			if (!immediate)
			{
				moveToPositionTimer.Start();
				return;
			}
			moveToPositionTimer.Stop();
			base.transform.position = position;
		}
	}

	private void LateUpdate()
	{
		if (Time.timeScale == 0f)
		{
			return;
		}
		PlayerController player = Manager.main.player;
		SR.enabled = !Manager.ui.isShowingMap && !Manager.ui.isAnyInventoryShowing && player != null && player.CurrentStateAllowInteractions(isTryingToUseSecondInteract: true) && !player.HeldItemIsBroken();
		Transform transform = base.transform;
		if (moveToPositionTimer.isRunning)
		{
			transform.position = Vector3.Lerp(startPosition.position, targetPosition.position, moveToPositionTimer.elapsedRatio);
		}
		transform.rotation = Quaternion.identity;
		if (player != null && SR.enabled)
		{
			int num = 1;
			if (player.targetMovementVelocity.sqrMagnitude > 0f)
			{
				num = -1;
			}
			currentFadeValue = Mathf.Clamp(currentFadeValue + Time.deltaTime * (float)num * 2f, 0f, 0.5f);
			SR.material.SetFloat(Transparancy, currentFadeValue);
			paddingSR.material.SetFloat(Transparancy, currentFadeValue);
		}
		Vector3 vec = Manager.camera.RenderOrigo + transform.position;
		paddingSR.enabled = SR.enabled && SR.size == Vector2.one && Manager.multiMap.GetTileLayerLookup().HasTile(vec.RoundToInt2(), TileType.wall);
		if (paddingSR.enabled)
		{
			SR.enabled = false;
		}
	}
}
