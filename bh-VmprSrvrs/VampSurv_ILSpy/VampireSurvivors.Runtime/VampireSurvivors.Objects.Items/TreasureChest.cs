using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using Newtonsoft.Json;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Cursors;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Items;

public class TreasureChest : NetworkPickup
{
	private sealed class _003C_003Ec__DisplayClass29_0
	{
		public TreasureChest _003C_003E4__this;

		public CoherenceSync openingPlayer;

		public CoherenceSync winningPlayer;

		internal void _003CPerformTreasureTake_003Eb__0()
		{
			//IL_0035: Expected I4, but got O
			_globalTakeAssigned = false;
			TreasureChest treasureChest = _003C_003E4__this;
			(string, object)[] args = new(string, object)[1];
			VampireSurvivors.Objects.Characters.CharacterController component = openingPlayer.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
			object obj = default(object);
			object item = (CharacterType)obj;
			(string, object) tuple = ("Opener", item);
			_ = 0;
			treasureChest._logger.Info("Performing treasure take", args);
			TreasureChest treasureChest2 = _003C_003E4__this;
			VampireSurvivors.Objects.Characters.CharacterController component2 = openingPlayer.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
			treasureChest2._targetPlayer = component2;
			TreasureChest treasureChest3 = _003C_003E4__this;
			Treasure treasure = treasureChest3._treasure;
			VampireSurvivors.Objects.Characters.CharacterController component3 = winningPlayer.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
			treasure.winningPlayer = component3;
			_003C_003E4__this.GetTaken();
		}
	}

	public byte[] SerializedTreasure;

	private Treasure _treasure;

	private bool _hasArcana;

	private bool _hasEvo;

	private bool _hasRandoms;

	private bool _hasSpecial;

	private static bool _globalTakeAssigned;

	private int _003CblessedTimes_003Ek__BackingField;

	public bool HasArcana
	{
		get
		{
			return _hasArcana;
		}
		set
		{
			_hasArcana = value;
		}
	}

	protected override bool UsesOrderedCommand => true;

	public Treasure TreasureData => _treasure;

	public bool HasSpecial => _hasSpecial;

	public int blessedTimes
	{
		get
		{
			return _003CblessedTimes_003Ek__BackingField;
		}
		set
		{
			_003CblessedTimes_003Ek__BackingField = value;
		}
	}

	protected override void Awake()
	{
		//IL_0016: Expected O, but got I4
		base.Awake();
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		((Pickup)this)._003CIsStationary_003Ek__BackingField = true;
	}

	public void SetData(ItemType itemType, Treasure treasure)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		base.SetData(itemType);
		BaseBody baseBody = body.setCircle(16f, (float?)(object)1, (float?)(object)1);
		_treasure = treasure;
		_hasArcana = false;
		AddDefaultCursor();
		CheckMinMaxStageValues();
		GameManager core = GM.Core;
		if (core._arcanaManager != null)
		{
			Treasure treasure2 = _treasure;
			ArcanaManager arcanaManager = core._arcanaManager;
			if (arcanaManager._003CMinTreasureChestLevel_003Ek__BackingField > treasure2._003Clevel_003Ek__BackingField)
			{
				GameManager core2 = GM.Core;
				ArcanaManager arcanaManager2 = core2._arcanaManager;
				Treasure treasure3 = _treasure;
				treasure3._003Clevel_003Ek__BackingField = arcanaManager2._003CMinTreasureChestLevel_003Ek__BackingField;
			}
		}
		GameManager core3 = GM.Core;
		if (core3._multiplayer.IsOnlineMultiplayer && _coherenceSync.HasStateAuthority)
		{
			string s = JsonConvert.SerializeObject(_treasure);
			Encoding uTF = Encoding.UTF8;
			byte[] bytes = uTF.GetBytes(s);
			SerializedTreasure = bytes;
		}
	}

	private void UpdateSerializedTreasureData()
	{
		string s = JsonConvert.SerializeObject(_treasure);
		Encoding uTF = Encoding.UTF8;
		byte[] bytes = uTF.GetBytes(s);
		SerializedTreasure = bytes;
	}

	public void SetArcana(bool hasArcana)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5000]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (hasArcana)
		{
			_hasArcana = true;
			SetFrame("BoxArcana");
			RemoveCursor();
			AddArcanaCursor();
		}
	}

	public void SetWithEvo()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5001]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PlayerOptionsData config = _playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				_hasEvo = true;
				SetFrame("BoxOpen2");
			}
		}
	}

	public void SetDarkVFX(bool hasRandoms)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5002]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (hasRandoms)
		{
			_hasRandoms = true;
			SetFrame("BoxOpen4");
		}
	}

	public void SetSpecial()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5003]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_hasSpecial = true;
		SetFrame("BoxOpen3");
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float2 float5 = SafeXY();
		base.position = float5;
		if (!_hasArcana)
		{
			return;
		}
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		GameManager core2 = GM.Core;
		ArcanaManager arcanaManager2 = core2._arcanaManager;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 < (nint)arcanaManager2._003CMaxArcanasPerRun_003Ek__BackingField)
		{
			return;
		}
		_hasArcana = false;
		RemoveCursor();
		AddDefaultCursor();
		if (!_hasRandoms)
		{
			if (!_hasEvo)
			{
				if (!_hasSpecial)
				{
					SetFrame("BoxOpen");
				}
				else
				{
					SetFrame("BoxOpen3");
				}
			}
			else
			{
				SetFrame("BoxOpen2");
			}
		}
		else
		{
			SetFrame("BoxOpen4");
		}
	}

	public unsafe void RequestTreasureTake(CoherenceSync openingPlayer)
	{
		//IL_0020: Expected I4, but got O
		//IL_0045: Expected O, but got Ref
		//IL_01ed: Expected O, but got I
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_0262: Expected O, but got I
		//IL_02e6: Expected O, but got I4
		//IL_02ad: Expected I4, but got O
		//IL_02ad: Expected I4, but got O
		//IL_024d: Expected O, but got I8
		if (_takeAssigned)
		{
			return;
		}
		VampireSurvivors.Objects.Characters.CharacterController component = openingPlayer.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
		object obj = default(object);
		object arg = (CharacterType)obj;
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj2 = default(object);
		string log = string.FormatHelper((IFormatProvider)null, "Accepted treasure take. Opener: {0}", (System.ParamsArray)(&obj2));
		(string, object)[] args = Array.Empty<(string, object)>();
		_logger.Info(log, args);
		_takeAssigned = true;
		_globalTakeAssigned = true;
		if (component.OnTreasureCollected(this))
		{
			string s = JsonConvert.SerializeObject(_treasure);
			Encoding uTF = Encoding.UTF8;
			byte[] bytes = uTF.GetBytes(s);
		}
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		VampireSurvivors.Objects.Characters.CharacterController characterController = GM.Core.PullRandomChestWinner();
		Treasure treasure = _treasure;
		treasure.winningPlayer = characterController;
		GM.Core.PostManipulateLevelUpOptionsForSpecialWeapons();
		GameManager core = GM.Core;
		List<TreasurePrizeTypePair> list = core._treasureFactory.GenerateNewPrizes(_treasure);
		byte[] param = SerializationUtils.SerializeTreasurePrizePairs(list);
		GameManager core2 = GM.Core;
		TreasureFactory treasureFactory = core2._treasureFactory;
		byte[] array = SerializationUtils.SerializeEnum(treasureFactory._accumulatedWeaponPrizes);
		bool flag = GM.Core.CanPlayQuickTreasureAnim(list);
		Action<long, CoherenceSync, CoherenceSync, byte[], byte[], int, bool, byte[]> action = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ r10_v4 (Il2CppMethodInfo)+8]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ r10_v4 (Il2CppMethodInfo)+4C]");
		object obj3 = (nint)0 >> 4;
		object obj4 = obj3 & 1;
		object obj5;
		if (obj4 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ r10_v4 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 8)
			{
				obj5 = 6447857392L;
				goto IL_02dd;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v666 @ rax_v27 (System.Action`8<System.Int64, Coherence.Toolkit.CoherenceSync, Coherence.Toolkit.CoherenceSync, System.Byte[], System.Byte[], System.Int32, System.Boolean, System.Byte[]>)+10]");
		obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v666 @ rax_v27 (System.Action`8<System.Int64, Coherence.Toolkit.CoherenceSync, Coherence.Toolkit.CoherenceSync, System.Byte[], System.Byte[], System.Int32, System.Boolean, System.Byte[]>)+20]");
		_ = 0;
		goto IL_02dd;
		IL_02dd:
		object obj6 = 24;
		_ = 6447857152L;
		object param2 = default(object);
		object param3 = default(object);
		object param4 = default(object);
		object param5 = default(object);
		bool flag2 = _coherenceSync.SendOrderedCommand((Action<long, object, object, object, object, int, bool, object>)action, MessageTarget.All, startingOnlineClientFrame, param2, param3, param4, param5, (int)openingPlayer, (byte)(int)characterController._coherenceSync != 0, param);
	}

	public void PerformTreasureTake(long startingSimFrame, CoherenceSync openingPlayer, CoherenceSync winningPlayer, byte[] serializedPrizePairs, byte[] serializedWeaponPrizes, int coins, bool quickTreasureAnim, byte[] serializedTreasure)
	{
		//IL_0047: Expected I4, but got O
		//IL_0120: Expected O, but got I
		_003C_003Ec__DisplayClass29_0 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass29_0();
		CS_0024_003C_003E8__locals11._003C_003E4__this = this;
		CoherenceSync openingPlayer2 = default(CoherenceSync);
		CS_0024_003C_003E8__locals11.openingPlayer = openingPlayer2;
		CS_0024_003C_003E8__locals11.winningPlayer = winningPlayer;
		(string, object)[] args = new(string, object)[1];
		VampireSurvivors.Objects.Characters.CharacterController component = CS_0024_003C_003E8__locals11.openingPlayer.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
		object obj = default(object);
		object item = (CharacterType)obj;
		(string, object) tuple = ("Opener", item);
		_ = 0;
		_logger.Info("Firing sync timer for treasure take", args);
		byte[] array = default(byte[]);
		if (array != null && array.Length != 0)
		{
			SerializedTreasure = array;
			Encoding uTF = Encoding.UTF8;
			string value = uTF.GetString(array);
			Treasure treasure = JsonConvert.DeserializeObject<Treasure>(value);
			_treasure = treasure;
		}
		_performingTake = true;
		IntPtr intPtr = default(IntPtr);
		List<TreasurePrizeTypePair> argPrizes = SerializationUtils.DeserializeTreasurePrizePairs((byte[])(nint)intPtr);
		byte[] buffer = default(byte[]);
		List<WeaponType> argAccumulatedWeaponPrizes = SerializationUtils.DeserializeEnum<WeaponType>(buffer);
		int argAccumulatedCoinPrize = default(int);
		List<WeaponType> argAccumulatedWorldSpacePrizes = default(List<WeaponType>);
		_treasure.AddPrizes(argPrizes, argAccumulatedWeaponPrizes, argAccumulatedCoinPrize, argAccumulatedWorldSpacePrizes);
		Treasure treasure2 = _treasure;
		bool quickTreasureAnim2 = default(bool);
		treasure2.QuickTreasureAnim = quickTreasureAnim2;
		Action onSyncedTimer = delegate
		{
			//IL_0035: Expected I4, but got O
			_globalTakeAssigned = false;
			TreasureChest treasureChest = CS_0024_003C_003E8__locals11._003C_003E4__this;
			(string, object)[] args2 = new(string, object)[1];
			VampireSurvivors.Objects.Characters.CharacterController component2 = CS_0024_003C_003E8__locals11.openingPlayer.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
			object obj2 = default(object);
			object item2 = (CharacterType)obj2;
			(string, object) tuple2 = ("Opener", item2);
			_ = 0;
			treasureChest._logger.Info("Performing treasure take", args2);
			TreasureChest treasureChest2 = CS_0024_003C_003E8__locals11._003C_003E4__this;
			VampireSurvivors.Objects.Characters.CharacterController component3 = CS_0024_003C_003E8__locals11.openingPlayer.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
			treasureChest2._targetPlayer = component3;
			TreasureChest treasureChest3 = CS_0024_003C_003E8__locals11._003C_003E4__this;
			Treasure treasure3 = treasureChest3._treasure;
			VampireSurvivors.Objects.Characters.CharacterController component4 = CS_0024_003C_003E8__locals11.winningPlayer.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
			treasure3.winningPlayer = component4;
			CS_0024_003C_003E8__locals11._003C_003E4__this.GetTaken();
		};
		OnlineStageManager._instance.FireSyncTimer(startingSimFrame, onSyncedTimer, canBePaused: false);
	}

	public override void GetOnlineTaken()
	{
		if (!_requestedTake && !_performingTake && !((Pickup)this)._003CDisableGet_003Ek__BackingField && !_globalTakeAssigned)
		{
			VampireSurvivors.Objects.Characters.CharacterController targetPlayer = _targetPlayer;
			if (targetPlayer._coherenceSync.HasStateAuthority)
			{
				_requestedTake = true;
				(string, object)[] args = Array.Empty<(string, object)>();
				_logger.Info("Requesting treasure take", args);
				Action<CoherenceSync> action = RequestTreasureTake;
				VampireSurvivors.Objects.Characters.CharacterController targetPlayer2 = _targetPlayer;
				bool flag = _coherenceSync.SendCommand((Action<object>)action, MessageTarget.AuthorityOnly, targetPlayer2._coherenceSync);
			}
		}
	}

	public override void GetTaken()
	{
		if (!((Pickup)this)._003CDisableGet_003Ek__BackingField)
		{
			RemoveCursor();
			base.SetHasSeenItem();
			base.AddToRunPickups();
			Treasure treasure = _treasure;
			treasure.openingPlayer = _targetPlayer;
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				bool flag = _targetPlayer.OnTreasureCollected(this);
			}
			GM.Core.AddTreasureToQueue(_treasure);
			if (!_taken)
			{
				((Pickup)this).GetTaken();
				_taken = true;
			}
		}
	}

	private void SpawnSpecial()
	{
	}

	public void RemoveCursor()
	{
		GameObject gameObject = base.gameObject;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4A10");
	}

	public override void Despawn()
	{
		GameObject gameObject = base.gameObject;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4A10");
		base.Despawn();
	}

	public override void Bless(float value, HitVfxType hitVFXType = HitVfxType.Prism)
	{
		//IL_0083: Expected I4, but got I8
		//IL_0105: Expected O, but got I
		//IL_0260: Expected O, but got F4
		//IL_0268: Invalid comparison between F4 and O
		//IL_0286: Invalid comparison between F4 and I4
		//IL_02af: Expected O, but got I4
		//IL_01cd: Expected I4, but got O
		int num = _003CblessedTimes_003Ek__BackingField + 1;
		_003CblessedTimes_003Ek__BackingField = num;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		bool flag = !config._003CFlashingVFXEnabled_003Ek__BackingField;
		ParticleSystem playerOptions = (ParticleSystem)(object)core._playerOptions;
		Vector2 vector = default(Vector2);
		if (!flag)
		{
			GameManager core2 = GM.Core;
			float2 float5 = base.position;
			RenderingExtensions.EmitParticleAt(core2._pickupVfx, vector, -1);
			playerOptions = core2._pickupVfx;
		}
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			playerOptions = (ParticleSystem)(object)networkEntityState._003CAuthorityType_003Ek__BackingField;
			bool flag2 = (byte)(nint)((UnityEngine.Object)playerOptions).m_CachedPtr != 0;
			if (((UnityEngine.Object)playerOptions).m_CachedPtr != (IntPtr)1)
			{
				object obj = (nint)((UnityEngine.Object)playerOptions).m_CachedPtr - 3;
				bool flag3 = obj == null;
				flag2 = flag3;
			}
			if (!flag2)
			{
				return;
			}
		}
		if (!_performingTake)
		{
			float num2 = ((_003CblessedTimes_003Ek__BackingField < 10) ? 0.1f : 1f);
			object obj2 = UnityEngine.Random.value;
			bool flag4 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) < System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector);
			float num3 = num2 - (float)vector;
			bool flag5 = num3 == 0f;
			bool flag6 = !flag4;
			bool flag7 = !flag5;
			object obj3 = flag7 & flag6;
			if (obj3 != null)
			{
				Treasure treasure = _treasure;
				List<PrizeType?> list = treasure._003CprizeTypes_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdx_v7 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
				int num4 = UnityEngine.Random.Range(0, 0);
				Action<int> action = null;
				((TreasureChest)(object)action).DoBless((int)this);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F6CDA0");
			}
		}
	}

	public void DoBless(int changedIndex)
	{
		//IL_0168: Expected O, but got I
		//IL_00f5: Expected O, but got I
		Treasure treasure = _treasure;
		_003CblessedTimes_003Ek__BackingField = 0;
		if (treasure._003Clevel_003Ek__BackingField >= 3)
		{
			if (_hasArcana || _hasRandoms)
			{
				return;
			}
			if (_hasEvo)
			{
				if (_hasSpecial)
				{
					return;
				}
				List<PrizeType?> list = treasure._003CprizeTypes_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdx_v7 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
				if ((nint)changedIndex < (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdx_v7 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
					object obj = 0;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdx_v7 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
					_ = (nint)0 + (nint)1;
					SetSpecial();
					return;
				}
			}
			else
			{
				List<PrizeType?> list2 = treasure._003CprizeTypes_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v5 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
				if ((nint)changedIndex < (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v5 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
					object obj2 = 0;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v5 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
					_ = (nint)0 + (nint)1;
					SetWithEvo();
					return;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
		else
		{
			int num = treasure._003Clevel_003Ek__BackingField + 1;
			treasure._003Clevel_003Ek__BackingField = num;
		}
	}

	private void AdjustTreasureLevelFromArcana()
	{
		GameManager core = GM.Core;
		if (core._arcanaManager != null)
		{
			Treasure treasure = _treasure;
			ArcanaManager arcanaManager = core._arcanaManager;
			if (arcanaManager._003CMinTreasureChestLevel_003Ek__BackingField > treasure._003Clevel_003Ek__BackingField)
			{
				GameManager core2 = GM.Core;
				ArcanaManager arcanaManager2 = core2._arcanaManager;
				Treasure treasure2 = _treasure;
				treasure2._003Clevel_003Ek__BackingField = arcanaManager2._003CMinTreasureChestLevel_003Ek__BackingField;
			}
		}
	}

	private void AddDefaultCursor()
	{
		CursorData cursorData = new CursorData();
		cursorData.IconAlpha = 1f;
		cursorData._cursorProportionOfScreenFromCenter = 0.45f;
		cursorData.AnimationName = "arrow_0";
		cursorData.AnimationStartingFrame = 1;
		cursorData.AnimationFramesCount = 8;
		cursorData.AnimationFrameRate = 16;
		Sprite sprite = SpriteManager.GetSprite("arrow_01", "UI");
		cursorData.CursorSprite = sprite;
		cursorData.CursorScale = 2f;
		cursorData.CursorAlpha = 0.75f;
		cursorData.OnScreenPointAt = true;
		GameObject gameObject = base.gameObject;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4920");
	}

	private void AddArcanaCursor()
	{
		CursorData cursorData = new CursorData();
		cursorData.IconAlpha = 1f;
		cursorData._cursorProportionOfScreenFromCenter = 0.45f;
		cursorData.AnimationName = "arrowNeutral_0";
		cursorData.AnimationStartingFrame = 1;
		cursorData.AnimationFramesCount = 8;
		cursorData.AnimationFrameRate = 16;
		Sprite sprite = SpriteManager.GetSprite("arrowNeutral_01", "UI");
		cursorData.CursorSprite = sprite;
		cursorData.CursorScale = 2f;
		cursorData.CursorAlpha = 0.75f;
		cursorData.CursorColorHex = "#5f37c8";
		cursorData.OnScreenPointAt = true;
		GameObject gameObject = base.gameObject;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4920");
	}

	protected override void TrackItemPickup(bool trackRunPickup = true)
	{
		//IL_0018: Expected O, but got I4
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		Treasure treasure = _treasure;
		bool flag = _treasure == null;
		object obj = treasure._003Clevel_003Ek__BackingField - 1;
		if (!flag)
		{
			object obj2 = obj - 1;
			if (!flag)
			{
				if ((nint)obj2 == 1)
				{
					PlayerOptionsData config = _playerOptions.Config;
					_playerOptions.TrackItemPickup(ItemType.STATS_TREASURE_3, config);
					PlayerOptionsData config2 = _playerOptions.Config;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
				}
			}
			else
			{
				PlayerOptionsData config3 = _playerOptions.Config;
				_playerOptions.TrackItemPickup(ItemType.STATS_TREASURE_2, config3);
				PlayerOptionsData config4 = _playerOptions.Config;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
			}
		}
		else
		{
			PlayerOptionsData config5 = _playerOptions.Config;
			_playerOptions.TrackItemPickup(ItemType.STATS_TREASURE_1, config5);
			PlayerOptionsData config6 = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
		}
	}

	private void CheckMinMaxStageValues()
	{
		//IL_0093: Expected O, but got I4
		//IL_00bf: Expected O, but got I4
		//IL_013d: Expected O, but got I4
		//IL_0233: Expected O, but got I4
		//IL_025f: Expected O, but got I4
		//IL_02dd: Expected O, but got I4
		float2 float5 = base.position;
		float2 float6 = base.position;
		GameManager core = GM.Core;
		Stage stage = core._stage;
		float? num = stage._003CMinTreasureY_003Ek__BackingField;
		if ((object)stage._003CMinTreasureY_003Ek__BackingField == null)
		{
			goto IL_0197;
		}
		object obj = default(object);
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
		object obj2 = obj - obj;
		bool flag2 = obj2 == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj3 = flag4 & flag3;
		object obj4 = (object?)stage._003CMinTreasureY_003Ek__BackingField & obj3;
		bool flag5 = obj4 == null;
		object obj5 = !flag5;
		if (obj5 == null)
		{
			GameManager core2 = GM.Core;
			Stage stage2 = core2._stage;
			num = stage2._003CMaxTreasureY_003Ek__BackingField;
			bool flag6 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
			object obj6 = obj - obj;
			bool flag7 = obj6 == null;
			bool flag8 = !flag6;
			bool flag9 = !flag7;
			object obj7 = flag9 & flag8;
			object obj8 = (object?)stage2._003CMaxTreasureY_003Ek__BackingField & obj7;
			if (obj8 == null)
			{
				goto IL_0197;
			}
		}
		GameManager core3;
		if ((object)num != null)
		{
			core3 = GM.Core;
			goto IL_01a5;
		}
		goto IL_034b;
		IL_0351:
		float2 float7 = default(float2);
		base.position = float7;
		return;
		IL_034b:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		return;
		IL_0197:
		core3 = GM.Core;
		goto IL_01a5;
		IL_01a5:
		Stage stage3 = core3._stage;
		float? num2 = stage3._003CMinTreasureX_003Ek__BackingField;
		if ((object)stage3._003CMinTreasureX_003Ek__BackingField != null)
		{
			bool flag10 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5);
			object obj9 = obj - (object)float5;
			bool flag11 = obj9 == null;
			bool flag12 = !flag10;
			bool flag13 = !flag11;
			object obj10 = flag13 & flag12;
			object obj11 = (object?)stage3._003CMinTreasureX_003Ek__BackingField & obj10;
			bool flag14 = obj11 == null;
			object obj12 = !flag14;
			if (obj12 == null)
			{
				GameManager core4 = GM.Core;
				Stage stage4 = core4._stage;
				num2 = stage4._003CMaxTreasureX_003Ek__BackingField;
				bool flag15 = System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
				object obj13 = (object)float5 - obj;
				bool flag16 = obj13 == null;
				bool flag17 = !flag15;
				bool flag18 = !flag16;
				object obj14 = flag18 & flag17;
				object obj15 = (object?)stage4._003CMaxTreasureX_003Ek__BackingField & obj14;
				if (obj15 == null)
				{
					goto IL_0351;
				}
			}
			if ((object)num2 == null)
			{
				goto IL_034b;
			}
		}
		goto IL_0351;
	}
}
