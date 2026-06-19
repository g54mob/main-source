using System.Collections.Generic;
using Pug.Sprite;
using Pug.UnityExtensions;
using Unity.Mathematics;
using UnityEngine;

public class ConveyorBelt : EntityMonoBehaviour
{
	[ClearOnReload(true)]
	public static Dictionary<int2, ConveyorBelt> posToBelt = new Dictionary<int2, ConveyorBelt>();

	[ClearOnReload(true)]
	public static Dictionary<ConveyorBelt, int2> beltToPos = new Dictionary<ConveyorBelt, int2>();

	private SpriteObject m_spriteObject;

	private int2 m_positionLastUpdate;

	private int m_prevVariation = -1;

	private static readonly int[] m_animationHashes = new int[4]
	{
		SpriteAsset.StringToHash("up"),
		SpriteAsset.StringToHash("right"),
		SpriteAsset.StringToHash("down"),
		SpriteAsset.StringToHash("left")
	};

	private const int VARIANT_HASH_SINGLE = 0;

	private static readonly int VARIANT_HASH_END = SpriteAsset.StringToHash("end");

	private static readonly int VARIANT_HASH_START = SpriteAsset.StringToHash("start");

	private static readonly int VARIANT_HASH_MIDDLE = SpriteAsset.StringToHash("middle");

	private List<AudioManager.RunningSfxReference> loopingSfx = new List<AudioManager.RunningSfxReference>();

	protected override void Awake()
	{
		base.Awake();
		m_spriteObject = spriteObjects[0];
	}

	public static void AddBelt(ConveyorBelt belt)
	{
		int2 int5 = belt.WorldPosition.RoundToInt2();
		if (posToBelt.ContainsKey(int5))
		{
			string[] obj = new string[7] { "Adding conveyor belt ", belt.name, " to ", null, null, null, null };
			int2 int6 = int5;
			obj[3] = int6.ToString();
			obj[4] = " but there is already a conveyor belt ";
			obj[5] = posToBelt[int5].name;
			obj[6] = " placed there, conflict should not happen. Removing old belt and adding new one.";
			Debug.LogError(string.Concat(obj));
			RemoveBelt(posToBelt[int5]);
		}
		posToBelt.Add(int5, belt);
		beltToPos.Add(belt, int5);
		belt.UpdateVisuals(updateAdjacentBelts: true);
	}

	public static void RemoveBelt(ConveyorBelt belt)
	{
		if (beltToPos.ContainsKey(belt))
		{
			int2 key = beltToPos[belt];
			posToBelt.Remove(key);
			beltToPos.Remove(belt);
			belt.UpdateVisuals(updateAdjacentBelts: true);
		}
	}

	public static void UpdateBeltPosition(ConveyorBelt belt)
	{
		RemoveBelt(belt);
		AddBelt(belt);
		belt.UpdateVisuals(updateAdjacentBelts: true);
	}

	public static ConveyorBelt GetBeltAtPosition(int2 position)
	{
		posToBelt.TryGetValue(position, out var value);
		return value;
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		m_prevVariation = -1;
		AddBelt(this);
		AudioManager.Sfx(SfxTableID.conveyorBeltSfx, base.transform.position, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, loopingSfx);
	}

	public override void OnFree()
	{
		RemoveBelt(this);
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

	protected override void OnDeath()
	{
		base.OnDeath();
		RemoveBelt(this);
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

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		int2 int5 = base.WorldPosition.RoundToInt2();
		if (math.any(m_positionLastUpdate != int5))
		{
			UpdateBeltPosition(this);
		}
		if (base.variation != m_prevVariation)
		{
			UpdateVisuals(updateAdjacentBelts: false);
		}
		m_spriteObject.animationTime = Time.time;
	}

	public void UpdateVisuals(bool updateAdjacentBelts)
	{
		if (base.entityExist)
		{
			m_positionLastUpdate = base.WorldPosition.RoundToInt2();
			int directionalVariantHash = GetDirectionalVariantHash(updateAdjacentBelts);
			m_spriteObject.PlayAnimation(m_animationHashes[base.variation], directionalVariantHash);
			m_prevVariation = base.variation;
		}
	}

	private int GetDirectionalVariantHash(bool updateAdjacentBelts)
	{
		int num = base.variation;
		bool flag = false;
		bool flag2 = false;
		int2 adjacentBeltDirection = GetAdjacentBeltDirection(Vector3.forward, updateAdjacentBelts);
		int2 adjacentBeltDirection2 = GetAdjacentBeltDirection(Vector3.back, updateAdjacentBelts);
		int2 adjacentBeltDirection3 = GetAdjacentBeltDirection(Vector3.left, updateAdjacentBelts);
		int2 adjacentBeltDirection4 = GetAdjacentBeltDirection(Vector3.right, updateAdjacentBelts);
		switch (num)
		{
		case 0:
			flag2 = math.all(adjacentBeltDirection == Direction.forward.i2);
			flag = math.all(adjacentBeltDirection2 == Direction.forward.i2);
			break;
		case 1:
			flag2 = math.all(adjacentBeltDirection4 == Direction.right.i2);
			flag = math.all(adjacentBeltDirection3 == Direction.right.i2);
			break;
		case 2:
			flag2 = math.all(adjacentBeltDirection2 == Direction.back.i2);
			flag = math.all(adjacentBeltDirection == Direction.back.i2);
			break;
		case 3:
			flag2 = math.all(adjacentBeltDirection3 == Direction.left.i2);
			flag = math.all(adjacentBeltDirection4 == Direction.left.i2);
			break;
		}
		if (!flag && !flag2)
		{
			return 0;
		}
		if (flag && !flag2)
		{
			return VARIANT_HASH_END;
		}
		if (!flag && flag2)
		{
			return VARIANT_HASH_START;
		}
		return VARIANT_HASH_MIDDLE;
	}

	private int2 GetAdjacentBeltDirection(Vector3 direction, bool updateAdjacentBelt)
	{
		int2 result = int2.zero;
		ConveyorBelt beltAtPosition = GetBeltAtPosition((base.WorldPosition + direction).RoundToInt2());
		if (beltAtPosition != null && !beltAtPosition.isHidden && beltAtPosition.entityExist)
		{
			result = DirectionBasedOnVariationCD.GetDirectionFromVariation(beltAtPosition.variation);
			if (updateAdjacentBelt)
			{
				beltAtPosition.UpdateVisuals(updateAdjacentBelts: false);
			}
		}
		return result;
	}
}
