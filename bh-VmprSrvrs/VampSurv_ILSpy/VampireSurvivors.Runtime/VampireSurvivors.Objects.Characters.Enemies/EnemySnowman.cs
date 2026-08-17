using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Loot;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemySnowman : EnemyDiamond
{
	private static WeightedStore WEIGHTEDSTORE;

	private readonly string _defaultFrame_Default = "snowManA_i01";

	private readonly string[] _availableFrames_Default;

	private readonly string _defaultFrame_XL;

	private readonly string[] _availableFrames_XL;

	protected override bool UseStandardLootTable => false;

	protected override float InvulDelay => 250f;

	protected override float ItemChance => 0.1f;

	protected override float Volume_breaking => 0.7f;

	protected override float Volume_gotHit => 0.35f;

	protected override SfxType Sfx_breaking => SfxType.SnowmanHit;

	protected override SfxType Sfx_gotHit => SfxType.SnowmanBreak;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_00b9: Expected O, but got I
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		//IL_011f: Expected O, but got F4
		//IL_014c: Expected O, but got I4
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		object obj = (nint)0 ^ (nint)0;
		object obj2 = 0 & obj;
		bool flag = (nint)obj2 < 0;
		bool flag2 = (nint)0 < (nint)0;
		bool flag3 = (nint)0 == 0;
		object obj3 = UnityEngine.Random.value;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,qword ptr [188A10678h]\"");
		bool flag4 = flag2 == flag;
		object obj4 = !flag3;
		object obj5 = flag4 & obj4;
		if (obj5 == null)
		{
			_defaultFrame = _defaultFrame_XL;
			_availableFrames = _availableFrames_XL;
		}
		else
		{
			_defaultFrame = _defaultFrame_Default;
			_availableFrames = _availableFrames_Default;
		}
		if (WEIGHTEDSTORE == null)
		{
			GameManager gameManager = _gameManager;
			ItemType[] items = new ItemType[7]
			{
				ItemType.CLOVER,
				ItemType.COIN,
				ItemType.COINBAG1,
				ItemType.OROLOGION,
				ItemType.VACUUM,
				ItemType.ROSARY,
				ItemType.SORBETTO
			};
			WeightedStore wEIGHTEDSTORE = gameManager._lootManager.ExportCustomLootTable(items);
			WEIGHTEDSTORE = wEIGHTEDSTORE;
		}
		bool asRemote2 = default(bool);
		base.InitEnemy(enemyType, asRemote2);
	}

	public override void OnSpawnDone()
	{
		//IL_00c3: Expected O, but got F4
		//IL_0061: Expected O, but got F4
		Transform cachedTransform = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
		object obj = UnityEngine.Random.value;
		object obj2 = UnityEngine.Random.value;
		Transform cachedTransform2 = _cachedTransform;
		bool flag2 = (object)_cachedTransform == null;
		bool flag3 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref value);
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		base.UpdateDepth();
	}

	protected override void CustomLoot()
	{
		//IL_02de->IL0215: Incompatible stack heights: 1 vs 0
		//IL_028f->IL0215: Incompatible stack heights: 1 vs 0
		GameManager gameManager = _gameManager;
		if ((object)_gameManager != null && gameManager._lootManager != null)
		{
			ItemType itemFromExportedTable = gameManager._lootManager.GetItemFromExportedTable(WEIGHTEDSTORE);
			if (itemFromExportedTable == ItemType.VOID)
			{
				return;
			}
			Transform transform = base.transform;
			Vector2 pos = default(Vector2);
			Vector3 ret;
			switch (itemFromExportedTable)
			{
			default:
				if ((object)transform != null)
				{
					Vector3 vector2 = transform.position;
					if ((object)_gameManager != null)
					{
						float value = default(float);
						ItemType relicType = default(ItemType);
						bool shouldCallValidatePickups = default(bool);
						bool isRemote = default(bool);
						Pickup pickup = _gameManager.MakePickup(pos, itemFromExportedTable, WeaponType.VOID, value, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
						return;
					}
				}
				break;
			case ItemType.COINBAG1:
				if ((object)transform != null)
				{
					Vector3 vector = transform.position;
					if ((object)_gameManager != null)
					{
						_gameManager.MakeRedCoinBag(pos);
						return;
					}
				}
				break;
			case ItemType.GEM:
				if ((object)transform != null)
				{
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
					if ((object)_gameManager != null)
					{
						_gameManager.MakeGem(pos, 1f);
						return;
					}
				}
				break;
			case ItemType.COIN:
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
					if ((object)_gameManager != null)
					{
						_gameManager.MakeCoin(pos);
						return;
					}
				}
				break;
			}
		}
		throw new NullReferenceException();
	}

	public EnemySnowman()
	{
		string[] availableFrames_Default = new string[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		_availableFrames_Default = availableFrames_Default;
		_defaultFrame_XL = "snowManXLA_i01.png";
		string[] availableFrames_XL = new string[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		_availableFrames_XL = availableFrames_XL;
		base._002Ector();
	}
}
