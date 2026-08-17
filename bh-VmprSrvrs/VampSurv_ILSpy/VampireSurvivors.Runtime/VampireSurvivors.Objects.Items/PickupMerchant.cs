using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Items;

public class PickupMerchant : NetworkPickup
{
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public CoherenceSync openingPlayer;

		public PickupMerchant _003C_003E4__this;

		public VampireSurvivors.Objects.Characters.CharacterController character;

		internal void _003CPerformMerchantTake_003Eb__0()
		{
			string name = ((UnityEngine.Object)openingPlayer).GetName();
			string message = "Performing merchant take. Opener: " + name;
			Debug.Log(message);
			PickupMerchant pickupMerchant = _003C_003E4__this;
			pickupMerchant._targetPlayer = character;
			_003C_003E4__this.GetTaken();
		}
	}

	private ParticleEmitterManager _particleEmitterManager;

	private ParticleSystem _pfxEmitter;

	protected override bool UsesOrderedCommand => true;

	protected override void Awake()
	{
		//IL_0016: Expected O, but got I4
		base.Awake();
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		GenerateParticleSystem();
	}

	public override void SetData(ItemType itemType)
	{
		//IL_003f: Expected O, but got I4
		//IL_003f: Expected O, but got I4
		//IL_015e->IL024b: Incompatible stack heights: 6 vs 0
		//IL_01ae->IL024b: Incompatible stack heights: 6 vs 0
		//IL_01f6->IL024b: Incompatible stack heights: 6 vs 0
		//IL_0224->IL024b: Incompatible stack heights: 6 vs 0
		base.SetData(itemType);
		base.GoToPlayer = true;
		((Pickup)this)._003CIsStationary_003Ek__BackingField = true;
		SetFrame("Pantalone");
		if (body != null)
		{
			BaseBody baseBody = body.setCircle(16f, (float?)(object)0, (float?)(object)0);
			((Pickup)this)._003CResRosary_003Ek__BackingField = 1f;
			RenderingExtensions.Start(_pfxEmitter);
			if ((object)_pfxEmitter != null)
			{
				Transform transform = _pfxEmitter.transform;
				Transform transform2 = base.transform;
				if ((object)transform2 != null)
				{
					bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
					bool flag2 = (object)transform == null;
					bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					GameManager core = GM.Core;
					bool flag4 = (object)GM.Core == null;
					Stage stage = core._stage;
					bool flag5 = (object)core._stage == null;
					StageData stageData = stage._stageData;
					bool flag6 = stage._stageData == null;
					if (!stageData._003CisRacingStage_003Ek__BackingField)
					{
						return;
					}
					if ((object)_spriteAnimation != null)
					{
						_spriteAnimation.CleanAnimations();
						int num = default(int);
						List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("PantaloneRun_0", 1, 2, "items", num);
						if ((object)_spriteAnimation != null)
						{
							bool startRandomFrame = default(bool);
							Action onComplete = default(Action);
							bool autoSetAnimation = default(bool);
							_spriteAnimation.AddAnimation("run", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
							if ((object)_spriteAnimation != null)
							{
								_spriteAnimation.SetAnimation("run");
								if ((object)GM.Core != null)
								{
									bool flag7 = GM.Core.IsStageVisuallyInverted();
									ArcadeSprite arcadeSprite = setFlipX(flag7);
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void RunAway(Vector2 velocity)
	{
		_spriteAnimation.CleanAnimations();
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("PantaloneRun_0", 1, 2, "items", num);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("run", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		_spriteAnimation.SetAnimation("run");
		BaseBody baseBody = body;
		baseBody._velocity = velocity;
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float2 float5 = SafeXY();
		base.position = float5;
	}

	public override void UpdateDepth()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num = default(int);
		if (_ShowAboveAll)
		{
			num = 1990;
		}
		ArcadeSprite arcadeSprite = setDepth(num);
		int num2 = base.Depth;
		int num3 = num2 - 1;
		ParticleEmitterManager particleEmitterManager = _particleEmitterManager.SetDepth(num3);
	}

	public override void GetTaken()
	{
		if (!((Pickup)this)._003CDisableGet_003Ek__BackingField)
		{
			RenderingExtensions.StopEmitting(_pfxEmitter);
			_gameManager.QueueEnterShop(_targetPlayer, MerchantInventoryType.DEFAULT, null);
			if (!_taken)
			{
				((Pickup)this).GetTaken();
				_taken = true;
			}
		}
	}

	public void RequestMerchantTake(CoherenceSync openingPlayer)
	{
		//IL_0139: Expected O, but got I
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected O, but got Unknown
		//IL_01ae: Expected O, but got I
		//IL_0218: Expected O, but got I4
		//IL_0199: Expected O, but got I8
		if (_takeAssigned)
		{
			return;
		}
		string text = ((UnityEngine.Object)openingPlayer).GetName();
		string message = "Accepted merchant take. Opener: " + text;
		Debug.Log(message);
		_takeAssigned = true;
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		GameManager core = GM.Core;
		core._003CMerchantInventory_003Ek__BackingField = MerchantInventoryType.DEFAULT;
		GameManager core2 = GM.Core;
		core2._shopFactory.GenerateShopInventory(_targetPlayer);
		GameManager core3 = GM.Core;
		ShopFactory shopFactory = core3._shopFactory;
		byte[] array = SerializationUtils.SerializeEnum(shopFactory._availableWeapons);
		GameManager core4 = GM.Core;
		ShopFactory shopFactory2 = core4._shopFactory;
		byte[] array2 = SerializationUtils.SerializeEnum(shopFactory2._availableItems);
		Action<long, CoherenceSync, byte[], byte[]> action = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r10_v3 (Il2CppMethodInfo)+8]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r10_v3 (Il2CppMethodInfo)+4C]");
		object obj = (nint)0 >> 4;
		object obj2 = obj & 1;
		object obj3;
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r10_v3 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 4)
			{
				obj3 = 6447794928L;
				goto IL_020f;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ rax_v16 (System.Action`4<System.Int64, Coherence.Toolkit.CoherenceSync, System.Byte[], System.Byte[]>)+10]");
		obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ rax_v16 (System.Action`4<System.Int64, Coherence.Toolkit.CoherenceSync, System.Byte[], System.Byte[]>)+20]");
		_ = 0;
		goto IL_020f;
		IL_020f:
		object obj4 = 24;
		_ = 6447793424L;
		object param = default(object);
		object param2 = default(object);
		object param3 = default(object);
		bool flag = _coherenceSync.SendCommand((Action<long, object, object, object>)action, MessageTarget.All, startingOnlineClientFrame, param, param2, param3);
	}

	public void PerformMerchantTake(long startingSimFrame, CoherenceSync openingPlayer, byte[] serializedWeapons, byte[] serializedItems)
	{
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass11_0();
		CS_0024_003C_003E8__locals9.openingPlayer = openingPlayer;
		CS_0024_003C_003E8__locals9._003C_003E4__this = this;
		string text = ((UnityEngine.Object)CS_0024_003C_003E8__locals9.openingPlayer).GetName();
		string message = "Firing sync timer for merchant take. Opener: " + text;
		Debug.Log(message);
		List<WeaponType> availableWeapons = SerializationUtils.DeserializeEnum<WeaponType>(serializedWeapons);
		byte[] buffer = default(byte[]);
		List<ItemType> availableItems = SerializationUtils.DeserializeEnum<ItemType>(buffer);
		GameManager core = GM.Core;
		ShopFactory shopFactory = core._shopFactory;
		shopFactory._availableWeapons = availableWeapons;
		shopFactory._availableItems = availableItems;
		VampireSurvivors.Objects.Characters.CharacterController component = CS_0024_003C_003E8__locals9.openingPlayer.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
		CS_0024_003C_003E8__locals9.character = component;
		Action onSyncedTimer = delegate
		{
			string text2 = ((UnityEngine.Object)CS_0024_003C_003E8__locals9.openingPlayer).GetName();
			string message2 = "Performing merchant take. Opener: " + text2;
			Debug.Log(message2);
			PickupMerchant pickupMerchant = CS_0024_003C_003E8__locals9._003C_003E4__this;
			pickupMerchant._targetPlayer = CS_0024_003C_003E8__locals9.character;
			CS_0024_003C_003E8__locals9._003C_003E4__this.GetTaken();
		};
		OnlineStageManager._instance.FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public override void GetOnlineTaken()
	{
		if (!_requestedTake)
		{
			_requestedTake = true;
			Debug.Log("Requesting merchant take");
			Action<CoherenceSync> action = RequestMerchantTake;
			VampireSurvivors.Objects.Characters.CharacterController targetPlayer = _targetPlayer;
			bool flag = _coherenceSync.SendCommand((Action<object>)action, MessageTarget.AuthorityOnly, targetPlayer._coherenceSync);
		}
	}

	private unsafe void GenerateParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0060: Expected O, but got I
		//IL_03cd: Expected O, but got I4
		//IL_03f3: Expected O, but got I4
		//IL_041a: Expected O, but got I4
		//IL_0433: Expected O, but got Ref
		//IL_044d: Expected native int or pointer, but got O
		//IL_0467: Expected O, but got I
		//IL_0487: Expected O, but got Ref
		//IL_04a1: Expected native int or pointer, but got O
		//IL_04bb: Expected O, but got I
		//IL_04db: Expected O, but got Ref
		//IL_04f5: Expected native int or pointer, but got O
		//IL_06ba: Expected O, but got I4
		//IL_050d: Expected O, but got Ref
		//IL_0534: Expected O, but got I
		//IL_054e: Expected native int or pointer, but got O
		//IL_06ec: Expected O, but got I
		//IL_0586: Expected O, but got Ref
		//IL_05a0: Expected native int or pointer, but got O
		//IL_0726: Expected O, but got I
		//IL_05f7: Expected O, but got I
		//IL_0618: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = base.gameObject;
		_ = 0;
		ParticleEmitterManager particleEmitterManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 176))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B0]");
			particleEmitterManager = (ParticleEmitterManager)0;
		}
		else
		{
			particleEmitterManager = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_particleEmitterManager = particleEmitterManager;
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		float ret;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		list._002Ector();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"mask1");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"mask2");
		}
		else
		{
			int num2 = list._size + 1;
			list._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"mask3");
		}
		else
		{
			int num3 = list._size + 1;
			list._size = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list._version + 1;
		list._version = version4;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"mask4");
		}
		else
		{
			int num4 = list._size + 1;
			list._size = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list._version + 1;
		list._version = version5;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"mask5");
		}
		else
		{
			int num5 = list._size + 1;
			list._size = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(ret);
		particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		float constant = default(float);
		minMaxCurve = new ParticleSystem.MinMaxCurve(constant);
		particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 40));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(-20f, 20f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-28]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-18]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 8));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(260f, 280f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-8]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 24));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(20f, 50f));
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-80]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 0.75f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+48]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-68]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-58]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+68]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-50]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-30]");
		_ = 0;
		_ = 0;
		_ = 1140457472;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B0]");
		particleSystemConfig._frequency = (float?)(object)0;
		_ = 16777215;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B0]");
		particleSystemConfig._tint = (uint?)(object)0;
		particleSystemConfig._on = true;
		ParticleSystem pfxEmitter = _particleEmitterManager.CreateEmitter(particleSystemConfig);
		_pfxEmitter = pfxEmitter;
	}
}
