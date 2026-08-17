using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class GattiWeapon : Weapon
{
	private Projectile _ExplosionPrefab;

	private Projectile _GattiScratchPrefab;

	private Projectile _GattiScufflePrefab;

	public List<string> _CatBaseFrames;

	private List<float> _randoms;

	private int _randomIndex;

	private BulletPool _explosionPool;

	public BulletPool _scratchPool;

	private BulletPool _scufflePool;

	private int _plusMinusIndex;

	protected List<float> _plusMinus;

	private SfxType[] _sfxArray;

	private int _sfxIndex;

	private float _full;

	private int _chickens;

	private WeaponType _counterWeaponType;

	private Weapon _counterWeapon;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_00b4: Expected O, but got I
		//IL_0120: Expected O, but got I4
		//IL_0143: Expected O, but got I
		//IL_0153: Expected O, but got I
		//IL_01bc: Expected O, but got I
		//IL_021d: Expected O, but got I
		//IL_022d: Expected O, but got I
		//IL_0287: Expected O, but got I
		//IL_04af: Expected O, but got I
		//IL_04bf: Expected O, but got I
		//IL_02f1: Expected O, but got I
		//IL_04e7: Expected O, but got I
		//IL_04f7: Expected O, but got I
		//IL_035b: Expected O, but got I
		//IL_051f: Expected O, but got I
		//IL_052f: Expected O, but got I
		//IL_03c6: Expected O, but got I
		base.InitWeapon(characterController, weaponType);
		_randomIndex = 0;
		List<float> randoms = new List<float>();
		_randoms = randoms;
		int num = 0;
		float item;
		do
		{
			List<float> randoms2 = _randoms;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v7 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v7 (System.Collections.Generic.List`1<System.Single>)+10]");
			nint num2 = 0;
			item = (float)num / 500f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ r8_v7 (Il2CppMethodInfo)+18]");
			if (num3 >= 0)
			{
				randoms2.AddWithResize(item);
				num2 = 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj = (nint)0 + (nint)1;
			}
			num++;
		}
		while (num < 500);
		Extensions.Shuffle(_randoms);
		_plusMinusIndex = 0;
		List<float> list = null;
		list.Add(item);
		_plusMinus = list;
		int num4 = 0;
		do
		{
			List<float> plusMinus = _plusMinus;
			object obj2 = num4 - 250;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rcx_v15 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rcx_v15 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rcx_v15 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj4 = 0;
			float item2 = (float)obj2 / 500f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rcx_v15 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ r8_v10+18]");
			if (num5 >= 0)
			{
				plusMinus.AddWithResize(item2);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rcx_v15 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj5 = (nint)0 + (nint)1;
			}
			num4++;
		}
		while (num4 < 500);
		Extensions.Shuffle(_plusMinus);
		_sfxIndex = 0;
		List<SfxType> list2 = new List<SfxType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rax_v20 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rax_v20 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rax_v20 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rax_v20 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rdx_v15+18]");
		if (num6 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)47);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rax_v20 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 47;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rax_v20 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rax_v20 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rax_v20 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		object obj10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rax_v20 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rdx_v17+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)48);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rax_v20 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj11 = (nint)0 + (nint)1;
			_ = 48;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rax_v20 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rax_v20 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rax_v20 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rax_v20 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rdx_v19+18]");
		if (num8 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)49);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rax_v20 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 49;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rax_v20 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rax_v20 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rax_v20 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		object obj16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rax_v20 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rdx_v21+18]");
		if (num9 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)50);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rax_v20 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj17 = (nint)0 + (nint)1;
			_ = 50;
		}
		SfxType[] sfxArray = new SfxType[120];
		_sfxArray = sfxArray;
		int num10 = 0;
		int num11;
		do
		{
			SfxType[] sfxArray2 = _sfxArray;
			SfxType sfxType = Extensions.PickRnd(list2);
			num11 = 0 + 1;
		}
		while (num11 < 120);
	}

	public float GetRandom()
	{
		//IL_0053: Expected O, but got I
		//IL_0065: Expected F4, but got I
		List<float> randoms = _randoms;
		int randomIndex = _randomIndex + 1;
		_randomIndex = randomIndex;
		int randomIndex2 = _randomIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+18]");
		int num = (int)((nint)randomIndex2 % (nint)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)num < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v7+20+v50 @ rdx_v5 (System.Int32)*4]");
			return 0f;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		float result = default(float);
		return result;
	}

	public float GetPlusMinus()
	{
		//IL_0053: Expected O, but got I
		//IL_0065: Expected F4, but got I
		List<float> plusMinus = _plusMinus;
		int plusMinusIndex = _plusMinusIndex + 1;
		_plusMinusIndex = plusMinusIndex;
		int plusMinusIndex2 = _plusMinusIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+18]");
		int num = (int)((nint)plusMinusIndex2 % (nint)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)num < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v7+20+v50 @ rdx_v5 (System.Int32)*4]");
			return 0f;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		float result = default(float);
		return result;
	}

	public SfxType GetSfx()
	{
		//IL_0076: Expected I4, but got O
		SfxType[] sfxArray = _sfxArray;
		int sfxIndex = _sfxIndex + 1;
		_sfxIndex = sfxIndex;
		int num = _sfxIndex % sfxArray.Length;
		if (num < sfxArray.Length)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ r8_v1 (VampireSurvivors.Data.SfxType[])+20+v19 @ rdx_v4 (System.Int32)*4]");
			return SfxType.None;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (SfxType)ex;
	}

	protected unsafe override void OnStart()
	{
		//IL_0d50: Expected I, but got O
		//IL_0d81: Expected O, but got I
		//IL_00cc: Expected O, but got I
		//IL_00cc: Expected O, but got I
		//IL_00ed: Expected O, but got I
		//IL_0d9d: Expected I, but got O
		//IL_0dce: Expected O, but got I
		//IL_0166: Expected O, but got I
		//IL_01f7: Expected O, but got I
		//IL_01f7: Expected O, but got I
		//IL_0218: Expected O, but got I
		//IL_0dea: Expected I, but got O
		//IL_0e1b: Expected O, but got I
		//IL_0291: Expected O, but got I
		//IL_02d1: Expected I, but got O
		//IL_032d: Expected O, but got I
		//IL_032d: Expected O, but got I
		//IL_033f: Expected I, but got O
		//IL_0367: Expected O, but got I
		//IL_0e37: Expected I, but got O
		//IL_0e68: Expected O, but got I
		//IL_040f: Expected O, but got I
		//IL_0430: Expected O, but got I
		//IL_0e84: Expected I, but got O
		//IL_0eb5: Expected O, but got I
		//IL_04a9: Expected O, but got I
		//IL_053a: Expected O, but got I
		//IL_053a: Expected O, but got I
		//IL_0566: Expected O, but got I
		//IL_05be: Expected O, but got I
		//IL_0fd9: Expected I, but got O
		//IL_100a: Expected O, but got I
		//IL_0987: Expected I, but got O
		//IL_09e3: Expected O, but got I
		//IL_09e3: Expected O, but got I
		//IL_0a04: Expected O, but got I
		//IL_06ba: Expected O, but got I
		//IL_1026: Expected I, but got O
		//IL_1057: Expected O, but got I
		//IL_0755: Expected I, but got O
		//IL_0a7d: Expected O, but got I
		//IL_0abd: Expected I, but got O
		//IL_0b19: Expected O, but got I
		//IL_0b19: Expected O, but got I
		//IL_0b3a: Expected O, but got I
		//IL_1073: Expected I, but got O
		//IL_10a4: Expected O, but got I
		//IL_080e: Expected O, but got Ref
		//IL_0bbe: Expected I, but got O
		//IL_0f3d: Expected O, but got I
		//IL_0f4d: Expected O, but got I
		//IL_0c1a: Expected O, but got I
		//IL_0c1a: Expected O, but got I
		//IL_0c3b: Expected O, but got I
		//IL_0f82: Expected O, but got I
		//IL_10c0: Expected I, but got O
		//IL_10f1: Expected O, but got I
		//IL_0d08: Expected O, but got I
		//IL_0d08: Expected O, but got I
		base.ResetFiringTimer();
		bool flag = (object)GM.Core == null;
		ArcadePhysicsCallback arcadePhysicsCallback = (ArcadePhysicsCallback)(object)this;
		ArcadePhysicsCallback arcadePhysicsCallback3 = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		if (!flag)
		{
			nint num = (nint)typeof(ArcadePhysics);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1034 @ rax_v12 (Il2CppClass<ArcadePhysics>)+B8]");
			nint num2 = 0;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			bool flag2 = ArcadePhysics.s_scene == null;
			arcadePhysicsCallback = (ArcadePhysicsCallback)num2;
			if (!flag2)
			{
				arcadePhysicsCallback = (ArcadePhysicsCallback)(object)s_scene.physics;
				if ((object)s_scene.physics != null)
				{
					arcadePhysicsCallback = (ArcadePhysicsCallback)(object)GM.Core;
					if ((object)GM.Core != null)
					{
						ArcadePhysicsCallback arcadePhysicsCallback2 = OnCatOverlapsEnemy;
						bool flag3 = ((Delegate)arcadePhysicsCallback2).delegate_trampoline == (IntPtr)0;
						arcadePhysicsCallback = arcadePhysicsCallback2;
						if (!flag3)
						{
							IntPtr delegate_trampoline = ((Delegate)arcadePhysicsCallback2).delegate_trampoline;
							BulletPool projectilePool = _projectilePool;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1098 @ rax_v15 (ArcadePhysicsCallback)+3C0]");
							Collider collider = ((Factory)(nint)delegate_trampoline).overlap(projectilePool, (ArcadeColliderType)0, arcadePhysicsCallback2, arcadePhysicsCallback3, callbackContext);
							bool flag4 = (object)GM.Core == null;
							arcadePhysicsCallback = (ArcadePhysicsCallback)(nint)((Delegate)arcadePhysicsCallback2).delegate_trampoline;
							if (!flag4)
							{
								nint num3 = (nint)typeof(ArcadePhysics);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1190 @ rax_v20 (Il2CppClass<ArcadePhysics>)+B8]");
								nint num4 = 0;
								PhaserScene s_scene2 = ArcadePhysics.s_scene;
								bool flag5 = ArcadePhysics.s_scene == null;
								arcadePhysicsCallback = (ArcadePhysicsCallback)num4;
								if (!flag5)
								{
									arcadePhysicsCallback = (ArcadePhysicsCallback)(object)s_scene2.physics;
									if ((object)s_scene2.physics != null)
									{
										arcadePhysicsCallback = (ArcadePhysicsCallback)(object)GM.Core;
										if ((object)GM.Core != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rcx_v4 (ArcadePhysicsCallback)+120]");
											object obj = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rcx_v4 (ArcadePhysicsCallback)+120]");
											if ((nint)0 != 0)
											{
												ArcadePhysicsCallback arcadePhysicsCallback4 = OnCatOverlapsPlayer;
												bool flag6 = ((Delegate)arcadePhysicsCallback4).delegate_trampoline == (IntPtr)0;
												arcadePhysicsCallback = arcadePhysicsCallback4;
												if (!flag6)
												{
													IntPtr delegate_trampoline2 = ((Delegate)arcadePhysicsCallback4).delegate_trampoline;
													BulletPool projectilePool2 = _projectilePool;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rax_v23+10]");
													Collider collider2 = ((Factory)(nint)delegate_trampoline2).overlap(projectilePool2, (ArcadeColliderType)0, arcadePhysicsCallback4, arcadePhysicsCallback3, callbackContext);
													bool flag7 = (object)GM.Core == null;
													arcadePhysicsCallback = (ArcadePhysicsCallback)(nint)((Delegate)arcadePhysicsCallback4).delegate_trampoline;
													if (!flag7)
													{
														nint num5 = (nint)typeof(ArcadePhysics);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1218 @ rax_v29 (Il2CppClass<ArcadePhysics>)+B8]");
														nint num6 = 0;
														PhaserScene s_scene3 = ArcadePhysics.s_scene;
														bool flag8 = ArcadePhysics.s_scene == null;
														arcadePhysicsCallback = (ArcadePhysicsCallback)num6;
														if (!flag8)
														{
															arcadePhysicsCallback = (ArcadePhysicsCallback)(object)s_scene3.physics;
															if ((object)s_scene3.physics != null)
															{
																arcadePhysicsCallback = (ArcadePhysicsCallback)(object)GM.Core;
																if ((object)GM.Core != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rcx_v4 (ArcadePhysicsCallback)+120]");
																	object obj2 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rcx_v4 (ArcadePhysicsCallback)+120]");
																	if ((nint)0 != 0)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1221 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.GattiWeapon>)+3A0]");
																		ArcadePhysicsCallback arcadePhysicsCallback5 = new ArcadePhysicsCallback(this, (IntPtr)0);
																		nint num7 = (nint)this;
																		bool flag9 = ((Delegate)arcadePhysicsCallback5).delegate_trampoline == (IntPtr)0;
																		arcadePhysicsCallback = arcadePhysicsCallback5;
																		if (!flag9)
																		{
																			IntPtr delegate_trampoline3 = ((Delegate)arcadePhysicsCallback5).delegate_trampoline;
																			BulletPool projectilePool3 = _projectilePool;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rax_v32+40]");
																			Collider collider3 = ((Factory)(nint)delegate_trampoline3).overlap(projectilePool3, (ArcadeColliderType)0, arcadePhysicsCallback5, arcadePhysicsCallback3, callbackContext);
																			nint num8 = (nint)typeof(GM);
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ rax_v36 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
																			nint num9 = 0;
																			bool flag10 = (object)GM.Core == null;
																			arcadePhysicsCallback = (ArcadePhysicsCallback)num9;
																			if (!flag10)
																			{
																				nint num10 = (nint)typeof(ArcadePhysics);
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1239 @ rax_v38 (Il2CppClass<ArcadePhysics>)+B8]");
																				nint num11 = 0;
																				PhaserScene s_scene4 = ArcadePhysics.s_scene;
																				bool flag11 = ArcadePhysics.s_scene == null;
																				arcadePhysicsCallback = (ArcadePhysicsCallback)num11;
																				if (!flag11)
																				{
																					arcadePhysicsCallback = (ArcadePhysicsCallback)(object)s_scene4.physics;
																					if ((object)s_scene4.physics != null)
																					{
																						ArcadePhysicsCallback arcadePhysicsCallback6 = OnBulletOverlapsBullet;
																						bool flag12 = ((Delegate)arcadePhysicsCallback6).delegate_trampoline == (IntPtr)0;
																						arcadePhysicsCallback = arcadePhysicsCallback6;
																						if (!flag12)
																						{
																							Collider collider4 = ((Factory)(nint)((Delegate)arcadePhysicsCallback6).delegate_trampoline).overlap(_projectilePool, _projectilePool, arcadePhysicsCallback6, arcadePhysicsCallback3, callbackContext);
																							bool flag13 = (object)GM.Core == null;
																							arcadePhysicsCallback = (ArcadePhysicsCallback)(nint)((Delegate)arcadePhysicsCallback6).delegate_trampoline;
																							if (!flag13)
																							{
																								nint num12 = (nint)typeof(ArcadePhysics);
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1260 @ rax_v45 (Il2CppClass<ArcadePhysics>)+B8]");
																								nint num13 = 0;
																								PhaserScene s_scene5 = ArcadePhysics.s_scene;
																								bool flag14 = ArcadePhysics.s_scene == null;
																								arcadePhysicsCallback = (ArcadePhysicsCallback)num13;
																								if (!flag14)
																								{
																									arcadePhysicsCallback = (ArcadePhysicsCallback)(object)s_scene5.physics;
																									if ((object)s_scene5.physics != null)
																									{
																										arcadePhysicsCallback = (ArcadePhysicsCallback)(object)GM.Core;
																										if ((object)GM.Core != null)
																										{
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rcx_v4 (ArcadePhysicsCallback)+120]");
																											object obj3 = 0;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rcx_v4 (ArcadePhysicsCallback)+120]");
																											if ((nint)0 != 0)
																											{
																												ArcadePhysicsCallback arcadePhysicsCallback7 = OnBulletOverlapsPickup;
																												bool flag15 = ((Delegate)arcadePhysicsCallback7).delegate_trampoline == (IntPtr)0;
																												arcadePhysicsCallback = arcadePhysicsCallback7;
																												if (!flag15)
																												{
																													IntPtr delegate_trampoline4 = ((Delegate)arcadePhysicsCallback7).delegate_trampoline;
																													BulletPool projectilePool4 = _projectilePool;
																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rax_v48+30]");
																													Collider collider5 = ((Factory)(nint)delegate_trampoline4).overlap(projectilePool4, (ArcadeColliderType)0, arcadePhysicsCallback7, arcadePhysicsCallback3, callbackContext);
																													WeaponData currentWeaponData = _currentWeaponData;
																													bool flag16 = _currentWeaponData == null;
																													arcadePhysicsCallback = (ArcadePhysicsCallback)(nint)((Delegate)arcadePhysicsCallback7).delegate_trampoline;
																													if (!flag16)
																													{
																														if (currentWeaponData._003ChitsWalls_003Ek__BackingField)
																														{
																															GameManager gameMan = _gameMan;
																															bool flag17 = (object)_gameMan == null;
																															arcadePhysicsCallback = (ArcadePhysicsCallback)(nint)((Delegate)arcadePhysicsCallback7).delegate_trampoline;
																															if (flag17)
																															{
																																goto IL_0d0d;
																															}
																															Stage stage = gameMan._stage;
																															bool flag18 = (object)gameMan._stage == null;
																															arcadePhysicsCallback3 = arcadePhysicsCallback3;
																															if (!flag18)
																															{
																																bool flag19 = ((UnityEngine.Object)stage).m_CachedPtr == (IntPtr)0;
																																arcadePhysicsCallback3 = arcadePhysicsCallback3;
																																if (!flag19)
																																{
																																	GameManager gameMan2 = _gameMan;
																																	bool flag20 = (object)_gameMan == null;
																																	arcadePhysicsCallback = (ArcadePhysicsCallback)(object)typeof(UnityEngine.Object);
																																	if (!flag20)
																																	{
																																		arcadePhysicsCallback = (ArcadePhysicsCallback)(object)gameMan2._stage;
																																		if ((object)gameMan2._stage != null)
																																		{
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rcx_v4 (ArcadePhysicsCallback)+88]");
																																			bool flag21 = (nint)0 == 0;
																																			arcadePhysicsCallback3 = arcadePhysicsCallback3;
																																			if (flag21)
																																			{
																																				goto IL_0fa7;
																																			}
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rcx_v4 (ArcadePhysicsCallback)+208]");
																																			object obj4 = 0;
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rcx_v4 (ArcadePhysicsCallback)+208]");
																																			if ((nint)0 != 0)
																																			{
																																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184FED160");
																																				object obj5 = default(object);
																																				if (obj5 != null)
																																				{
																																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rax_v127+18]");
																																					if ((nint)0 != 0)
																																					{
																																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185004430");
																																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1655 @ r8_v39 (Il2CppClass<VampireSurvivors.Objects.Weapons.GattiWeapon>)+3B0]");
																																						ArcadePhysicsCallback arcadePhysicsCallback8 = new ArcadePhysicsCallback(this, (IntPtr)0);
																																						nint num14 = (nint)this;
																																						World world = default(World);
																																						ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
																																						CallbackContext callbackContext2 = default(CallbackContext);
																																						TilemapSetCollider tilemapSetCollider = new TilemapSetCollider(world, overlapOnly: false, _projectilePool, (ArcadeColliderType)(object)arcadePhysicsCallback3, (ArcadePhysicsCallback)(object)callbackContext, processCallback, callbackContext2);
																																						bool flag22 = tilemapSetCollider == null;
																																						arcadePhysicsCallback = (ArcadePhysicsCallback)(object)tilemapSetCollider;
																																						if (!flag22)
																																						{
																																							Collider collider6 = tilemapSetCollider.setName("Gatti>Tilemap");
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rax_v126+60]");
																																							bool flag23 = (nint)0 == 0;
																																							arcadePhysicsCallback = (ArcadePhysicsCallback)(object)tilemapSetCollider;
																																							if (!flag23)
																																							{
																																								PhaserTilemap phaserTilemap = null;
																																								ArcadeColliderType projectilePool5 = _projectilePool;
																																								List<PhaserTilemap>.Enumerator enumerator = default(List<PhaserTilemap>.Enumerator);
																																								if (enumerator.MoveNext())
																																								{
																																									PhaserTilemap phaserTilemap2 = null;
																																									List<PhaserTilemap>.Enumerator enumerator2 = (List<PhaserTilemap>.Enumerator)(&enumerator);
																																									throw new NullReferenceException();
																																								}
																																								PhaserScene s_scene6 = ArcadePhysics.s_scene;
																																								bool flag24 = ArcadePhysics.s_scene == null;
																																								arcadePhysicsCallback = (ArcadePhysicsCallback)(object)typeof(ArcadePhysics);
																																								if (!flag24)
																																								{
																																									bool flag25 = (object)s_scene6.physics == null;
																																									arcadePhysicsCallback = (ArcadePhysicsCallback)(object)typeof(ArcadePhysics);
																																									if (!flag25)
																																									{
																																										arcadePhysicsCallback = (ArcadePhysicsCallback)(object)typeof(ArcadePhysics);
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rcx_v4 (ArcadePhysicsCallback)+B8]");
																																										object obj6 = 0;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rax_v143+18]");
																																										object obj7 = 0;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rax_v143+18]");
																																										if ((nint)0 != 0)
																																										{
																																											arcadePhysicsCallback3 = arcadePhysicsCallback3;
																																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rbx_v20+50]");
																																											arcadePhysicsCallback = (ArcadePhysicsCallback)0;
																																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rbx_v20+50]");
																																											if ((nint)0 != 0)
																																											{
																																												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B4520");
																																												goto IL_0fa7;
																																											}
																																										}
																																									}
																																								}
																																							}
																																						}
																																					}
																																				}
																																			}
																																		}
																																	}
																																	goto IL_0d0d;
																																}
																															}
																														}
																														goto IL_0fa7;
																													}
																												}
																											}
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0d0d;
		IL_0d0d:
		throw new NullReferenceException();
		IL_0fa7:
		BulletPool explosionPool = new BulletPool(_ExplosionPrefab);
		_explosionPool = explosionPool;
		BulletPool scratchPool = new BulletPool(_GattiScratchPrefab);
		_scratchPool = scratchPool;
		arcadePhysicsCallback = (ArcadePhysicsCallback)(object)(_scufflePool = new BulletPool(_GattiScufflePrefab));
		if ((object)GM.Core != null)
		{
			nint num15 = (nint)typeof(ArcadePhysics);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1648 @ rax_v65 (Il2CppClass<ArcadePhysics>)+B8]");
			nint num16 = 0;
			PhaserScene s_scene7 = ArcadePhysics.s_scene;
			bool flag26 = ArcadePhysics.s_scene == null;
			arcadePhysicsCallback = (ArcadePhysicsCallback)num16;
			if (!flag26)
			{
				arcadePhysicsCallback = (ArcadePhysicsCallback)(object)s_scene7.physics;
				if ((object)s_scene7.physics != null)
				{
					arcadePhysicsCallback = (ArcadePhysicsCallback)(object)GM.Core;
					if ((object)GM.Core != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1654 @ r8_v20 (Il2CppClass<VampireSurvivors.Objects.Weapons.GattiWeapon>)+350]");
						ArcadePhysicsCallback arcadePhysicsCallback9 = new ArcadePhysicsCallback(this, (IntPtr)0);
						nint num17 = (nint)this;
						bool flag27 = ((Delegate)arcadePhysicsCallback9).delegate_trampoline == (IntPtr)0;
						arcadePhysicsCallback = arcadePhysicsCallback9;
						if (!flag27)
						{
							IntPtr delegate_trampoline5 = ((Delegate)arcadePhysicsCallback9).delegate_trampoline;
							BulletPool explosionPool2 = _explosionPool;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1651 @ rax_v68 (ArcadePhysicsCallback)+3C0]");
							Collider collider7 = ((Factory)(nint)delegate_trampoline5).overlap(explosionPool2, (ArcadeColliderType)0, arcadePhysicsCallback9, arcadePhysicsCallback3, callbackContext);
							bool flag28 = (object)GM.Core == null;
							arcadePhysicsCallback = (ArcadePhysicsCallback)(nint)((Delegate)arcadePhysicsCallback9).delegate_trampoline;
							if (!flag28)
							{
								nint num18 = (nint)typeof(ArcadePhysics);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1681 @ rax_v73 (Il2CppClass<ArcadePhysics>)+B8]");
								nint num19 = 0;
								PhaserScene s_scene8 = ArcadePhysics.s_scene;
								bool flag29 = ArcadePhysics.s_scene == null;
								arcadePhysicsCallback = (ArcadePhysicsCallback)num19;
								if (!flag29)
								{
									arcadePhysicsCallback = (ArcadePhysicsCallback)(object)s_scene8.physics;
									if ((object)s_scene8.physics != null)
									{
										arcadePhysicsCallback = (ArcadePhysicsCallback)(object)GM.Core;
										if ((object)GM.Core != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rcx_v4 (ArcadePhysicsCallback)+120]");
											object obj8 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rcx_v4 (ArcadePhysicsCallback)+120]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1787 @ r8_v23 (Il2CppClass<VampireSurvivors.Objects.Weapons.GattiWeapon>)+3A0]");
												ArcadePhysicsCallback arcadePhysicsCallback10 = new ArcadePhysicsCallback(this, (IntPtr)0);
												nint num20 = (nint)this;
												bool flag30 = ((Delegate)arcadePhysicsCallback10).delegate_trampoline == (IntPtr)0;
												arcadePhysicsCallback = arcadePhysicsCallback10;
												if (!flag30)
												{
													IntPtr delegate_trampoline6 = ((Delegate)arcadePhysicsCallback10).delegate_trampoline;
													BulletPool explosionPool3 = _explosionPool;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rax_v76+40]");
													Collider collider8 = ((Factory)(nint)delegate_trampoline6).overlap(explosionPool3, (ArcadeColliderType)0, arcadePhysicsCallback10, arcadePhysicsCallback3, callbackContext);
													bool flag31 = (object)GM.Core == null;
													arcadePhysicsCallback = (ArcadePhysicsCallback)(nint)((Delegate)arcadePhysicsCallback10).delegate_trampoline;
													if (!flag31)
													{
														nint num21 = (nint)typeof(ArcadePhysics);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1831 @ rax_v82 (Il2CppClass<ArcadePhysics>)+B8]");
														nint num22 = 0;
														PhaserScene s_scene9 = ArcadePhysics.s_scene;
														bool flag32 = ArcadePhysics.s_scene == null;
														arcadePhysicsCallback = (ArcadePhysicsCallback)num22;
														if (!flag32)
														{
															arcadePhysicsCallback = (ArcadePhysicsCallback)(object)s_scene9.physics;
															if ((object)s_scene9.physics != null)
															{
																arcadePhysicsCallback = (ArcadePhysicsCallback)(object)GM.Core;
																if ((object)GM.Core != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1853 @ r8_v26 (Il2CppClass<VampireSurvivors.Objects.Weapons.GattiWeapon>)+350]");
																	ArcadePhysicsCallback arcadePhysicsCallback11 = new ArcadePhysicsCallback(this, (IntPtr)0);
																	nint num23 = (nint)this;
																	bool flag33 = ((Delegate)arcadePhysicsCallback11).delegate_trampoline == (IntPtr)0;
																	arcadePhysicsCallback = arcadePhysicsCallback11;
																	if (!flag33)
																	{
																		IntPtr delegate_trampoline7 = ((Delegate)arcadePhysicsCallback11).delegate_trampoline;
																		BulletPool scratchPool2 = _scratchPool;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1852 @ rax_v85 (ArcadePhysicsCallback)+3C0]");
																		Collider collider9 = ((Factory)(nint)delegate_trampoline7).overlap(scratchPool2, (ArcadeColliderType)0, arcadePhysicsCallback11, arcadePhysicsCallback3, callbackContext);
																		bool flag34 = (object)GM.Core == null;
																		arcadePhysicsCallback = (ArcadePhysicsCallback)(nint)((Delegate)arcadePhysicsCallback11).delegate_trampoline;
																		if (!flag34)
																		{
																			nint num24 = (nint)typeof(ArcadePhysics);
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1872 @ rax_v90 (Il2CppClass<ArcadePhysics>)+B8]");
																			nint num25 = 0;
																			PhaserScene s_scene10 = ArcadePhysics.s_scene;
																			bool flag35 = ArcadePhysics.s_scene == null;
																			arcadePhysicsCallback = (ArcadePhysicsCallback)num25;
																			if (!flag35)
																			{
																				arcadePhysicsCallback = (ArcadePhysicsCallback)(object)s_scene10.physics;
																				if ((object)s_scene10.physics != null)
																				{
																					arcadePhysicsCallback = (ArcadePhysicsCallback)(object)GM.Core;
																					if ((object)GM.Core != null)
																					{
																						ArcadePhysicsCallback collideCallback = OnBulletOverlapsEnemyNoKB;
																						if (((Delegate)arcadePhysicsCallback).delegate_trampoline != (IntPtr)0)
																						{
																							IntPtr delegate_trampoline8 = ((Delegate)arcadePhysicsCallback).delegate_trampoline;
																							BulletPool scufflePool = _scufflePool;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rcx_v4 (ArcadePhysicsCallback)+3C0]");
																							Collider collider10 = ((Factory)(nint)delegate_trampoline8).overlap(scufflePool, (ArcadeColliderType)0, collideCallback, arcadePhysicsCallback3, callbackContext);
																							return;
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0d0d;
	}

	private void ChickenUpgradesOnLevelUp()
	{
		//IL_002b: Expected O, but got I4
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		if (_chickens <= 0)
		{
			return;
		}
		object obj = 0;
		do
		{
			WeaponData currentWeaponData = _currentWeaponData;
			float num = currentWeaponData._003Cchance_003Ek__BackingField * 1.1f;
			currentWeaponData._003Cchance_003Ek__BackingField = num;
			object obj2 = obj + 1;
			float num2 = (float)obj2 / 108f;
			if (num2 > 0.95f)
			{
				num2 = 0.95f;
			}
			WeaponData currentWeaponData2 = _currentWeaponData;
			float num3 = (_full = 1f - num2) * 0.1f;
			obj++;
			float num4 = num3 + currentWeaponData2._003Cpower_003Ek__BackingField;
			currentWeaponData2._003Cpower_003Ek__BackingField = num4;
		}
		while ((nint)obj < _chickens);
	}

	private void ApplyChickenUpgrade(int chickens)
	{
		WeaponData currentWeaponData = _currentWeaponData;
		float num = currentWeaponData._003Cchance_003Ek__BackingField * 1.1f;
		currentWeaponData._003Cchance_003Ek__BackingField = num;
		WeaponData currentWeaponData2 = _currentWeaponData;
		float num2 = (float)chickens / 108f;
		bool flag = !(0.95f > num2);
		float num3 = 0.95f;
		if (!flag)
		{
			num3 = num2;
		}
		float num4 = (_full = 1f - num3) * 0.1f;
		float num5 = num4 + currentWeaponData2._003Cpower_003Ek__BackingField;
		currentWeaponData2._003Cpower_003Ek__BackingField = num5;
	}

	public override bool LevelUp()
	{
		//IL_000e: Expected O, but got I4
		//IL_016b: Expected I4, but got O
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		bool result = LevelUp(skipFire: false);
		if (_chickens <= 0)
		{
			goto IL_00de;
		}
		object obj = 0;
		while (true)
		{
			WeaponData currentWeaponData = _currentWeaponData;
			if (_currentWeaponData == null)
			{
				break;
			}
			float num = currentWeaponData._003Cchance_003Ek__BackingField * 1.1f;
			currentWeaponData._003Cchance_003Ek__BackingField = num;
			object obj2 = obj + 1;
			float num2 = (float)obj2 / 108f;
			if (num2 > 0.95f)
			{
				num2 = 0.95f;
			}
			WeaponData currentWeaponData2 = _currentWeaponData;
			float num3 = (_full = 1f - num2);
			if (_currentWeaponData == null)
			{
				break;
			}
			float num4 = num3 * 0.1f;
			obj++;
			float num5 = num4 + currentWeaponData2._003Cpower_003Ek__BackingField;
			currentWeaponData2._003Cpower_003Ek__BackingField = num5;
			if ((nint)obj < _chickens)
			{
				continue;
			}
			goto IL_00de;
		}
		goto IL_015d;
		IL_015d:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_00de:
		ChangeBmRate(((Equipment)this)._003CLevel_003Ek__BackingField);
		Weapon counterWeapon = _counterWeapon;
		if ((object)_counterWeapon != null && ((UnityEngine.Object)counterWeapon).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_counterWeapon == null)
			{
				goto IL_015d;
			}
			bool flag = _counterWeapon.LevelUp();
		}
		return result;
	}

	public override void CheckArcanas()
	{
		//IL_01a2: Expected I, but got O
		//IL_01b0: Expected I, but got O
		//IL_01c0: Expected O, but got I
		//IL_0240: Expected O, but got I4
		//IL_01fc: Expected O, but got I
		//IL_0232: Expected O, but got I4
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
		GameManager core = GM.Core;
		ArcanaManager arcanaManager2 = core._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj2 = default(object);
		if ((nint)obj2 <= -1)
		{
			goto IL_028a;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(_counterWeaponType, searchHidden: true);
		if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		GameManager core2 = GM.Core;
		bool allowDuplicates = default(bool);
		Weapon weapon = core2._weaponsFacade.AddHiddenWeapon(_counterWeaponType, ((Equipment)this)._003COwner_003Ek__BackingField, removeFromStore: true, allowDuplicates);
		bool flag = (object)weapon == null;
		Weapon weapon2 = null;
		if (flag)
		{
			goto IL_02cb;
		}
		nint num = (nint)weapon;
		nint num2 = (nint)typeof(GattiCounterWeapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.GattiCounterWeapon>)+130]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v498 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.GattiCounterWeapon>)+130]");
		object obj5;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v498 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ rax_v42+FFFFFFF8+v500 @ rax_v38*8]");
			if (0 == (nint)typeof(GattiCounterWeapon))
			{
				obj5 = 1;
				goto IL_02da;
			}
		}
		obj5 = 0;
		goto IL_02da;
		IL_02da:
		bool flag2 = obj5 == null;
		weapon2 = null;
		if (!flag2)
		{
			weapon2 = weapon;
		}
		goto IL_02cb;
		IL_028a:
		CheckBeginningArcana();
		return;
		IL_02cb:
		_counterWeapon = weapon2;
		while (((Equipment)weapon2)._003CLevel_003Ek__BackingField < ((Equipment)this)._003CLevel_003Ek__BackingField)
		{
			bool flag3 = weapon2.LevelUp();
		}
		goto IL_028a;
	}

	public override bool ApplyLimitBreak(WeightedLimitBreak weightedLimitBreak)
	{
		//IL_007b: Expected I4, but got O
		bool result = base.ApplyLimitBreak(weightedLimitBreak);
		Weapon counterWeapon = _counterWeapon;
		if ((object)_counterWeapon != null && ((UnityEngine.Object)counterWeapon).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_counterWeapon == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			bool flag = _counterWeapon.ApplyLimitBreak(weightedLimitBreak);
		}
		return result;
	}

	protected override void MakeLevelOne()
	{
		base.MakeLevelOne();
		ChangeBmRate(1);
	}

	public override void Cleanup()
	{
		base.Cleanup();
		if (_explosionPool != null)
		{
			_explosionPool.Cleanup();
		}
		if (_scratchPool != null)
		{
			_scratchPool.Cleanup();
		}
		if (_scufflePool != null)
		{
			_scufflePool.Cleanup();
		}
	}

	public virtual void ChangeBmRate(int value)
	{
		//IL_0077: Expected O, but got I4
		//IL_0012: Expected O, but got I8
		//IL_002c: Expected O, but got I8
		object obj = value - 1;
		if ((nint)obj <= 7)
		{
			object obj2 = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rdx_v3+7511284+v30 @ rax_v2*4]");
			object obj3 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v50 @ rcx_v13 (should have been resolved before IL gen)");
		}
		else if (SoundManager._003CCurrentBgm_003Ek__BackingField != BgmType.BGM_Gatti)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186CD2D20");
		_ = 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186CD2D20");
		SoundManager.SoundConfig config = default(SoundManager.SoundConfig);
		SoundManager.UpdateCurrentMusicWithConfig(config);
	}

	private bool OnCatOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00a7: Expected O, but got I4
		//IL_015b: Expected I, but got O
		//IL_0163: Expected I, but got O
		//IL_0173: Expected O, but got I
		//IL_01f3: Expected O, but got I4
		//IL_01af: Expected O, but got I
		//IL_01e5: Expected O, but got I4
		//IL_0456: Expected I4, but got O
		//IL_03d1: Expected O, but got I4
		//IL_0520: Expected I, but got O
		IDamageable damageable;
		if (first == null)
		{
			damageable = null;
			goto IL_04a2;
		}
		nint num = (nint)typeof(EnemyController);
		nint num2 = (nint)first;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rdx_v24 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ r8_v11 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rdx_v24 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ r8_v11 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rax_v61+FFFFFFF8+v57 @ rax_v57*8]");
			if (0 == (nint)typeof(EnemyController))
			{
				obj3 = 1;
				goto IL_047b;
			}
		}
		obj3 = 0;
		goto IL_047b;
		IL_04a2:
		Projectile projectile;
		object obj6;
		if (damageable != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdi_v1 (VampireSurvivors.Interfaces.IDamageable)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdi_v1 (VampireSurvivors.Interfaces.IDamageable)+260]");
				if ((nint)0 == 0)
				{
					if (second == null)
					{
						projectile = null;
						goto IL_04f1;
					}
					nint num4 = (nint)typeof(Projectile);
					nint num5 = (nint)second;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ r8_v9 (Il2CppClass<ArcadeColliderType>)+130]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
					if (num6 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ r8_v9 (Il2CppClass<ArcadeColliderType>)+C8]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ rax_v49+FFFFFFF8+v460 @ rax_v45*8]");
						if (0 == (nint)typeof(Projectile))
						{
							obj6 = 1;
							goto IL_04ca;
						}
					}
					obj6 = 0;
					goto IL_04ca;
				}
			}
		}
		goto IL_04bf;
		IL_04ca:
		bool flag = obj6 == null;
		projectile = null;
		if (!flag)
		{
			projectile = (Projectile)second;
		}
		goto IL_04f1;
		IL_04f1:
		if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
		{
			bool flag2 = projectile.HasAlreadyHitObject(damageable);
			if (!flag2)
			{
				if (IsHoming == flag2)
				{
					WeaponData currentWeaponData = _currentWeaponData;
					if (_currentWeaponData == null || (object)((Equipment)this)._003COwner_003Ek__BackingField == null)
					{
						goto IL_0448;
					}
					float num7 = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
					object obj7 = default(object);
					float num8 = (float)obj7 * currentWeaponData._003Cchance_003Ek__BackingField;
					float random = GetRandom();
					if (random > num8)
					{
						projectile.AddObjectHit(damageable);
						goto IL_04bf;
					}
				}
				float2 position = projectile.position;
				if (_scratchPool == null)
				{
					goto IL_0448;
				}
				float2 pos = default(float2);
				Projectile projectile2 = _scratchPool.SpawnAt(pos, this);
				SfxType sfx = GetSfx();
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Rate = 1f;
				float plusMinus = GetPlusMinus();
				float detune = plusMinus * 400f;
				soundConfig.Rate = 1f;
				soundConfig.Detune = detune;
				soundConfig.Volume = (float?)(object)1;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(sfx, soundConfig, 200f, 2, time);
				float num9 = base.PPower();
				WeaponData currentWeaponData2 = _currentWeaponData;
				if (_currentWeaponData != null)
				{
					HitVfxType hitVfxType = currentWeaponData2._003ChitVFX_003Ek__BackingField;
				}
				else
				{
					HitVfxType hitVfxType = HitVfxType.Default;
				}
				float knockback = base.Knockback;
				nint num10 = (nint)damageable;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v791 @ rdx_v14 (Il2CppClass<VampireSurvivors.Interfaces.IDamageable>)+3E8] (should have been resolved before IL gen)");
				float num11 = base.PPower();
				float num12 = knockback + base._003CStatsInflictedDamage_003Ek__BackingField;
				base._003CStatsInflictedDamage_003Ek__BackingField = num12;
			}
		}
		goto IL_04bf;
		IL_0448:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_047b:
		bool flag3 = obj3 == null;
		damageable = null;
		if (!flag3)
		{
			damageable = (IDamageable)first;
		}
		goto IL_04a2;
		IL_04bf:
		return false;
	}

	private bool OnCatOverlapsPlayer(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_003d: Expected I, but got O
		//IL_0045: Expected I, but got O
		//IL_0055: Expected O, but got I
		//IL_00d5: Expected O, but got I4
		//IL_0091: Expected O, but got I
		//IL_00c7: Expected O, but got I4
		//IL_0190: Expected I, but got O
		//IL_0198: Expected I, but got O
		//IL_01a8: Expected O, but got I
		//IL_0228: Expected O, but got I4
		//IL_01e4: Expected O, but got I
		//IL_021a: Expected O, but got I4
		//IL_0461: Expected I4, but got O
		//IL_03e6: Expected O, but got I4
		if (IsHoming)
		{
			goto IL_032d;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController;
		if (first == null)
		{
			characterController = null;
			goto IL_04af;
		}
		nint num = (nint)typeof(VampireSurvivors.Objects.Characters.CharacterController);
		nint num2 = (nint)first;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v9 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v9 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ rax_v58+FFFFFFF8+v271 @ rax_v54*8]");
			if (0 == (nint)typeof(VampireSurvivors.Objects.Characters.CharacterController))
			{
				obj3 = 1;
				goto IL_0488;
			}
		}
		obj3 = 0;
		goto IL_0488;
		IL_0453:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_04af:
		if ((object)characterController == null || ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0 || characterController._isDead || characterController.IsDisconnectedFromOnlinePlay)
		{
			goto IL_032d;
		}
		Projectile projectile;
		if (second == null)
		{
			projectile = null;
			goto IL_04f8;
		}
		nint num4 = (nint)typeof(Projectile);
		nint num5 = (nint)second;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v490 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ r8_v8 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v490 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		object obj6;
		if (num6 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ r8_v8 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v546 @ rax_v47+FFFFFFF8+v492 @ rax_v43*8]");
			if (0 == (nint)typeof(Projectile))
			{
				obj6 = 1;
				goto IL_04d1;
			}
		}
		obj6 = 0;
		goto IL_04d1;
		IL_04f8:
		if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0 && !projectile.HasAlreadyHitObject(characterController))
		{
			WeaponData currentWeaponData = _currentWeaponData;
			if (_currentWeaponData == null || (object)((Equipment)this)._003COwner_003Ek__BackingField == null)
			{
				goto IL_0453;
			}
			float num7 = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
			object obj7 = default(object);
			float num8 = (float)obj7 * currentWeaponData._003Cchance_003Ek__BackingField;
			float random = GetRandom();
			if (!(random > num8))
			{
				projectile.AddObjectHit(characterController);
			}
			else
			{
				float2 position = projectile.position;
				if (_scratchPool == null)
				{
					goto IL_0453;
				}
				float2 pos = default(float2);
				Projectile projectile2 = _scratchPool.SpawnAt(pos, this);
				SfxType sfx = GetSfx();
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Rate = 1f;
				float plusMinus = GetPlusMinus();
				float detune = plusMinus * 400f;
				soundConfig.Rate = 1f;
				soundConfig.Detune = detune;
				soundConfig.Volume = (float?)(object)1;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(sfx, soundConfig, 200f, 2, time);
				float num9 = base.PPower();
				base._003CStatsInflictedDamage_003Ek__BackingField = base._003CStatsInflictedDamage_003Ek__BackingField;
				float num10 = base.PPower();
				float damageAmount = base._003CStatsInflictedDamage_003Ek__BackingField + base._003CStatsInflictedDamage_003Ek__BackingField;
				bool damaged = characterController.GetDamaged(damageAmount);
			}
		}
		goto IL_032d;
		IL_032d:
		return false;
		IL_04d1:
		bool flag = obj6 == null;
		projectile = null;
		if (!flag)
		{
			projectile = (Projectile)second;
		}
		goto IL_04f8;
		IL_0488:
		bool flag2 = obj3 == null;
		characterController = null;
		if (!flag2)
		{
			characterController = (VampireSurvivors.Objects.Characters.CharacterController)first;
		}
		goto IL_04af;
	}

	private bool OnBulletOverlapsBullet(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0013: Expected I, but got O
		//IL_004a: Expected I, but got O
		//IL_005a: Expected O, but got I
		//IL_00da: Expected O, but got I4
		//IL_0096: Expected O, but got I
		//IL_0106: Expected I, but got O
		//IL_0116: Expected O, but got I
		//IL_00cc: Expected O, but got I4
		//IL_0196: Expected O, but got I4
		//IL_0152: Expected O, but got I
		//IL_0188: Expected O, but got I4
		//IL_0750: Expected I4, but got O
		//IL_0335: Expected O, but got I4
		//IL_039e: Expected O, but got I4
		//IL_03fb: Expected I, but got O
		//IL_0403: Expected I, but got O
		//IL_0413: Expected O, but got I
		//IL_044f: Expected O, but got I
		//IL_048c: Expected O, but got I
		//IL_04a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a7: Expected O, but got Unknown
		//IL_050b: Expected I, but got O
		//IL_0530: Expected I, but got O
		//IL_0540: Expected O, but got I
		//IL_057c: Expected O, but got I
		//IL_05c1: Expected I, but got O
		//IL_05c9: Expected I, but got O
		//IL_05d9: Expected O, but got I
		//IL_0615: Expected O, but got I
		if (IsHoming)
		{
			goto IL_0651;
		}
		nint num = (nint)typeof(Projectile);
		IDamageable damageable;
		Projectile projectile;
		if (first == null)
		{
			damageable = null;
			projectile = null;
			goto IL_068d;
		}
		nint num2 = (nint)first;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ r8_v16 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ r8_v16 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v69+FFFFFFF8+v169 @ rax_v65*8]");
			if (0 == (nint)typeof(Projectile))
			{
				obj3 = 1;
				goto IL_06ad;
			}
		}
		obj3 = 0;
		goto IL_06ad;
		IL_0651:
		return false;
		IL_068d:
		Projectile projectile2;
		if (second == null)
		{
			projectile2 = projectile;
			goto IL_0703;
		}
		nint num4 = (nint)second;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ r8_v15 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		object obj6;
		if (num5 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ r8_v15 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ rax_v63+FFFFFFF8+v409 @ rax_v59*8]");
			if (0 == (nint)typeof(Projectile))
			{
				obj6 = 1;
				goto IL_06d9;
			}
		}
		obj6 = 0;
		goto IL_06d9;
		IL_0703:
		if ((object)projectile2 != null && ((UnityEngine.Object)projectile2).m_CachedPtr != (IntPtr)0 && damageable != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rsi_v4 (VampireSurvivors.Interfaces.IDamageable)+10]");
			if ((nint)0 != 0 && !projectile2.HasAlreadyHitObject(damageable))
			{
				((Projectile)damageable).AddObjectHit((IDamageable)projectile2);
				projectile2.AddObjectHit(damageable);
				WeaponData currentWeaponData = _currentWeaponData;
				if (_currentWeaponData != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float num6 = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
					object obj7 = default(object);
					float num7 = (float)obj7 * currentWeaponData._003Cchance_003Ek__BackingField;
					float random = GetRandom();
					if (!(num7 > random))
					{
						goto IL_0750;
					}
					SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
					soundConfig.Rate = 1f;
					float random2 = GetRandom();
					float detune = random2 * 400f;
					soundConfig.Detune = detune;
					soundConfig.Volume = (float?)(object)1;
					float time = default(float);
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.CAT3, soundConfig, 200f, 2, time);
					SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
					soundConfig2.Rate = 1f;
					float random3 = GetRandom();
					float detune2 = random3 * 400f;
					soundConfig2.Volume = (float?)(object)1;
					soundConfig2.Detune = detune2;
					PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.CATE, soundConfig2, 200f, 2, time);
					if (first != null)
					{
						nint num8 = (nint)typeof(Projectile);
						nint num9 = (nint)first;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v690 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
						object obj8 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ r8_v10 (Il2CppClass<ArcadeColliderType>)+130]");
						nint num10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v690 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
						if (num10 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ r8_v10 (Il2CppClass<ArcadeColliderType>)+C8]");
							object obj9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v696 @ rax_v34+FFFFFFF8+v695 @ rax_v33*8]");
							if (0 == (nint)typeof(Projectile))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v690 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
								object obj10 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v696 @ rax_v34+FFFFFFF8+v847 @ rcx_v32*8]");
								object obj11 = 0 - typeof(Projectile);
								bool flag = obj11 == null;
								bool flag2 = !flag;
								ArcadeSprite arcadeSprite = projectile;
								if (!flag2)
								{
									arcadeSprite = (ArcadeSprite)first;
								}
								float2 position = arcadeSprite.position;
								if (_scufflePool != null)
								{
									float2 pos = default(float2);
									Projectile projectile3 = _scufflePool.SpawnAt(pos, this);
									nint num11 = (nint)typeof(Projectile);
									if (second != null)
									{
										nint num12 = (nint)second;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v691 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
										object obj12 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v879 @ r8_v12 (Il2CppClass<ArcadeColliderType>)+130]");
										nint num13 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v691 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
										if (num13 >= 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v879 @ r8_v12 (Il2CppClass<ArcadeColliderType>)+C8]");
											object obj13 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v894 @ rax_v41+FFFFFFF8+v880 @ rax_v38*8]");
											if (0 == (nint)typeof(Projectile))
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v879 @ r8_v12 (Il2CppClass<ArcadeColliderType>)+368] (should have been resolved before IL gen)");
												nint num14 = (nint)typeof(Projectile);
												nint num15 = (nint)first;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
												object obj14 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v793 @ r8_v14 (Il2CppClass<ArcadeColliderType>)+130]");
												nint num16 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
												if (num16 >= 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v793 @ r8_v14 (Il2CppClass<ArcadeColliderType>)+C8]");
													object obj15 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v939 @ rax_v46+FFFFFFF8+v925 @ rax_v43*8]");
													if (0 == (nint)typeof(Projectile))
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v793 @ r8_v14 (Il2CppClass<ArcadeColliderType>)+368] (should have been resolved before IL gen)");
														goto IL_0750;
													}
												}
												throw new InvalidCastException();
											}
										}
										throw new InvalidCastException();
									}
								}
							}
						}
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
		}
		goto IL_0651;
		IL_0750:
		return false;
		IL_06d9:
		bool flag3 = obj6 == null;
		projectile2 = projectile;
		if (!flag3)
		{
			projectile2 = (Projectile)second;
		}
		goto IL_0703;
		IL_06ad:
		bool flag4 = obj3 == null;
		damageable = null;
		projectile = null;
		if (!flag4)
		{
			damageable = (IDamageable)first;
			projectile = null;
		}
		goto IL_068d;
	}

	private unsafe bool OnBulletOverlapsPickup(CallbackContext context, ArcadeColliderType left, ArcadeColliderType right)
	{
		//IL_0022: Expected I, but got O
		//IL_002a: Expected I, but got O
		//IL_003a: Expected O, but got I
		//IL_00ba: Expected O, but got I4
		//IL_0076: Expected O, but got I
		//IL_00ed: Expected I, but got O
		//IL_00f5: Expected I, but got O
		//IL_0105: Expected O, but got I
		//IL_00ac: Expected O, but got I4
		//IL_0185: Expected O, but got I4
		//IL_0141: Expected O, but got I
		//IL_0177: Expected O, but got I4
		//IL_0544: Expected F4, but got O
		//IL_04b1: Expected O, but got I4
		//IL_099c: Expected I4, but got O
		//IL_0578: Expected O, but got I4
		//IL_050e: Expected O, but got I
		//IL_0276: Expected O, but got I4
		//IL_03d3: Expected O, but got I4
		//IL_06ca: Expected O, but got I4
		//IL_02db: Expected O, but got I4
		//IL_0442: Expected I, but got O
		//IL_07d9: Expected O, but got I4
		//IL_0847: Expected O, but got I4
		ArcadeSprite arcadeSprite;
		ArcadeSprite arcadeSprite2;
		if (left == null)
		{
			arcadeSprite = null;
			arcadeSprite2 = null;
			goto IL_08ae;
		}
		nint num = (nint)typeof(Projectile);
		nint num2 = (nint)left;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v48 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ r8_v26 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v48 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ r8_v26 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v112+FFFFFFF8+v60 @ rax_v108*8]");
			if (0 == (nint)typeof(Projectile))
			{
				obj3 = 1;
				goto IL_08ce;
			}
		}
		obj3 = 0;
		goto IL_08ce;
		IL_07ad:
		return false;
		IL_0926:
		ArcadeSprite arcadeSprite3;
		float time = default(float);
		float num8;
		if ((object)arcadeSprite3 != null && ((UnityEngine.Object)arcadeSprite3).m_CachedPtr != (IntPtr)0 && (object)arcadeSprite != null && ((UnityEngine.Object)arcadeSprite).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rdi_v2 (ArcadeSprite)+F8]");
			if ((nint)0 == 12)
			{
				SfxType[] sfxArray = _sfxArray;
				int sfxIndex = _sfxIndex + 1;
				_sfxIndex = sfxIndex;
				int num4 = _sfxIndex % sfxArray.Length;
				if (num4 >= sfxArray.Length)
				{
					goto IL_098e;
				}
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Volume = (float?)(object)1;
				soundConfig.Detune = 1000f;
				soundConfig.Rate = 2f;
				PlaySoundResult playSoundResult = SoundManager.PlaySound((SfxType)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref sfxArray[num4]), soundConfig, 200f, 2, time);
				SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
				soundConfig2.Volume = (float?)(object)1;
				soundConfig2.Rate = 1.7f;
				soundConfig2.Detune = 500f;
				PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Roast, soundConfig2, 0f, 10, time);
				ApplyChickenUpgrade(++_chickens);
				DespawnPickup((Pickup)arcadeSprite3);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rdi_v2 (ArcadeSprite)+F8]");
			float2 float6 = default(float2);
			if ((nint)0 == 17)
			{
				float2 position = arcadeSprite3.position;
				SfxType[] sfxArray2 = _sfxArray;
				int sfxIndex2 = _sfxIndex + 1;
				_sfxIndex = sfxIndex2;
				int num5 = _sfxIndex % sfxArray2.Length;
				if (num5 >= sfxArray2.Length)
				{
					goto IL_098e;
				}
				SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
				soundConfig3.Volume = (float?)(object)1;
				soundConfig3.Detune = 1f;
				soundConfig3.Rate = 2f;
				PlaySoundResult playSoundResult3 = SoundManager.PlaySound((SfxType)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref sfxArray2[num5]), soundConfig3, 200f, 2, time);
				float2 float5 = default(float2);
				Projectile projectile = _explosionPool.SpawnAt(float5, this);
				nint num6 = (nint)arcadeSprite;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1293 @ rax_v69 (Il2CppClass<ArcadeSprite>)+368] (should have been resolved before IL gen)");
				DespawnPickup((Pickup)arcadeSprite3);
				float6 = float5;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rdi_v2 (ArcadeSprite)+F8]");
			if ((nint)0 == 7)
			{
				SfxType sfx = GetSfx();
				SoundManager.SoundConfig soundConfig4 = new SoundManager.SoundConfig();
				soundConfig4.Volume = (float?)(object)1;
				soundConfig4.Detune = 1000f;
				soundConfig4.Rate = 2f;
				PlaySoundResult playSoundResult4 = SoundManager.PlaySound(sfx, soundConfig4, 200f, 2, time);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r14_v1 (ArcadeSprite)+A4]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r14_v1 (ArcadeSprite)+A4]");
				float6 = (float2)(num7 + 0);
				DespawnPickup((Pickup)arcadeSprite3);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rdi_v2 (ArcadeSprite)+F8]");
			bool flag = (nint)0 != 40;
			num8 = (float)float6;
			if (!flag)
			{
				SfxType sfx2 = GetSfx();
				SoundManager.SoundConfig soundConfig5 = new SoundManager.SoundConfig();
				soundConfig5.Volume = (float?)(object)1;
				soundConfig5.Detune = 1000f;
				soundConfig5.Rate = 2f;
				PlaySoundResult playSoundResult5 = SoundManager.PlaySound(sfx2, soundConfig5, 200f, 2, time);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r14_v1 (ArcadeSprite)+A4]");
				float num9 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r14_v1 (ArcadeSprite)+A4]");
				num8 = num9 + 0f;
				DespawnPickup((Pickup)arcadeSprite3);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rdi_v2 (ArcadeSprite)+F8]");
			if ((nint)0 != 9)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rdi_v2 (ArcadeSprite)+F8]");
				if ((nint)0 != 10)
				{
					goto IL_0719;
				}
			}
			WeaponData currentWeaponData = _currentWeaponData;
			float num10 = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
			float num11 = num8 * currentWeaponData._003Cchance_003Ek__BackingField;
			num8 = GetRandom();
			if (!(num8 > num11))
			{
				PhysicsManager.TakePickup((Pickup)arcadeSprite3, ((Equipment)this)._003COwner_003Ek__BackingField);
			}
			else
			{
				SfxType sfx3 = GetSfx();
				SoundManager.SoundConfig soundConfig6 = new SoundManager.SoundConfig();
				soundConfig6.Volume = (float?)(object)1;
				soundConfig6.Detune = -1000f;
				soundConfig6.Rate = 2f;
				PlaySoundResult playSoundResult6 = SoundManager.PlaySound(sfx3, soundConfig6, 200f, 2, time);
				DespawnPickup((Pickup)arcadeSprite3);
			}
			goto IL_0719;
		}
		goto IL_07ad;
		IL_0719:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rdi_v2 (ArcadeSprite)+F8]");
		if ((nint)0 == 11)
		{
			WeaponData currentWeaponData2 = _currentWeaponData;
			float num12 = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
			float num13 = num8 * currentWeaponData2._003Cchance_003Ek__BackingField;
			float random = GetRandom();
			if (!(random > num13))
			{
				PhysicsManager.TakePickup((Pickup)arcadeSprite3, ((Equipment)this)._003COwner_003Ek__BackingField);
			}
			else
			{
				SfxType sfx4 = GetSfx();
				SoundManager.SoundConfig soundConfig7 = new SoundManager.SoundConfig();
				soundConfig7.Volume = (float?)(object)1;
				soundConfig7.Detune = -1000f;
				soundConfig7.Rate = 2f;
				PlaySoundResult playSoundResult7 = SoundManager.PlaySound(sfx4, soundConfig7, 200f, 2, time);
				ArcadeSprite arcadeSprite4 = arcadeSprite.setTint(255u);
				SoundManager.SoundConfig soundConfig8 = new SoundManager.SoundConfig();
				soundConfig8.Volume = (float?)(object)1;
				soundConfig8.Rate = 4f;
				PlaySoundResult playSoundResult8 = SoundManager.PlaySound(SfxType.Orologion, soundConfig8, 0f, 10, time);
				DespawnPickup((Pickup)arcadeSprite3);
			}
		}
		goto IL_07ad;
		IL_098e:
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
		IL_08ce:
		bool flag2 = obj3 == null;
		arcadeSprite = null;
		arcadeSprite2 = null;
		if (!flag2)
		{
			arcadeSprite = (ArcadeSprite)left;
			arcadeSprite2 = null;
		}
		goto IL_08ae;
		IL_08fb:
		object obj4;
		bool flag3 = obj4 == null;
		arcadeSprite3 = arcadeSprite2;
		if (!flag3)
		{
			arcadeSprite3 = (ArcadeSprite)right;
		}
		goto IL_0926;
		IL_08ae:
		if (right == null)
		{
			arcadeSprite3 = arcadeSprite2;
			goto IL_0926;
		}
		nint num14 = (nint)typeof(Pickup);
		nint num15 = (nint)right;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rdx_v47 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ r8_v25 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rdx_v47 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		if (num16 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ r8_v25 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rax_v106+FFFFFFF8+v153 @ rax_v102*8]");
			if (0 == (nint)typeof(Pickup))
			{
				obj4 = 1;
				goto IL_08fb;
			}
		}
		obj4 = 0;
		goto IL_08fb;
	}

	private void DespawnPickup(Pickup pickup)
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0067: Expected O, but got I
		//IL_009d: Expected O, but got I4
		//IL_00ce: Expected O, but got I
		//IL_0113: Expected O, but got I
		nint num = (nint)typeof(NetworkPickup);
		nint num2 = (nint)pickup;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rdx_v2 (Il2CppClass<VampireSurvivors.NetworkPickup>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rdx_v2 (Il2CppClass<VampireSurvivors.NetworkPickup>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v15+FFFFFFF8+v51 @ rax_v4*8]");
			if (0 == (nint)typeof(NetworkPickup))
			{
				obj3 = 1;
				goto IL_0122;
			}
		}
		obj3 = 0;
		goto IL_0122;
		IL_0122:
		bool flag = obj3 == null;
		Pickup pickup2 = null;
		if (!flag)
		{
			pickup2 = pickup;
		}
		if ((object)pickup2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdi_v3 (VampireSurvivors.Objects.Pickups.Pickup)+148]");
			if (!((CoherenceSync)0).HasStateAuthority)
			{
				Action action = ((NetworkPickup)pickup2).OnlineForceDespawn;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdi_v3 (VampireSurvivors.Objects.Pickups.Pickup)+148]");
				bool flag2 = ((CoherenceSync)0).SendCommand(action, MessageTarget.AuthorityOnly);
				return;
			}
		}
		pickup.Despawn();
	}

	private unsafe void OnNftPicked(Vector2 position)
	{
		//IL_0032: Expected O, but got I4
		SfxType[] sfxArray = _sfxArray;
		int sfxIndex = _sfxIndex + 1;
		_sfxIndex = sfxIndex;
		int num = _sfxIndex % sfxArray.Length;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = 1f;
		soundConfig.Rate = 2f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound((SfxType)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref sfxArray[num]), soundConfig, 200f, 2, time);
		float2 pos = default(float2);
		Projectile projectile = _explosionPool.SpawnAt(pos, this);
	}

	private unsafe void OnRoastPicked()
	{
		//IL_004e: Expected O, but got I4
		//IL_0097: Expected O, but got I4
		SfxType[] sfxArray = _sfxArray;
		int sfxIndex = _sfxIndex + 1;
		_sfxIndex = sfxIndex;
		int num = _sfxIndex % sfxArray.Length;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Detune = 1000f;
		soundConfig.Rate = 2f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound((SfxType)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref sfxArray[num]), soundConfig, 200f, 2, time);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 1.7f;
		soundConfig2.Detune = 500f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Roast, soundConfig2, 0f, 10, time);
		ApplyChickenUpgrade(++_chickens);
	}

	private bool OnBulletOverlapsEnemyNoKB(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0022: Expected I, but got O
		//IL_002a: Expected I, but got O
		//IL_003a: Expected O, but got I
		//IL_00ba: Expected O, but got I4
		//IL_0076: Expected O, but got I
		//IL_00ac: Expected O, but got I4
		//IL_0158: Expected I, but got O
		//IL_0160: Expected I, but got O
		//IL_0170: Expected O, but got I
		//IL_01f0: Expected O, but got I4
		//IL_01ac: Expected O, but got I
		//IL_01e2: Expected O, but got I4
		//IL_036f: Expected I, but got O
		IDamageable damageable;
		Projectile projectile;
		if (first == null)
		{
			damageable = null;
			projectile = null;
			goto IL_02f6;
		}
		nint num = (nint)typeof(EnemyController);
		nint num2 = (nint)first;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ r8_v7 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ r8_v7 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v45+FFFFFFF8+v60 @ rax_v41*8]");
			if (0 == (nint)typeof(EnemyController))
			{
				obj3 = 1;
				goto IL_02ca;
			}
		}
		obj3 = 0;
		goto IL_02ca;
		IL_031e:
		object obj4;
		if (obj4 != null)
		{
			projectile = (Projectile)second;
		}
		goto IL_0340;
		IL_0340:
		if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0 && !projectile.HasAlreadyHitObject(damageable))
		{
			float num4 = base.PPower();
			WeaponData currentWeaponData = _currentWeaponData;
			if (_currentWeaponData != null)
			{
				HitVfxType hitVfxType = currentWeaponData._003ChitVFX_003Ek__BackingField;
			}
			else
			{
				HitVfxType hitVfxType = HitVfxType.Default;
			}
			float knockback = base.Knockback;
			nint num5 = (nint)damageable;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v527 @ rdx_v8 (Il2CppClass<VampireSurvivors.Interfaces.IDamageable>)+3E8] (should have been resolved before IL gen)");
			float num6 = base.PPower();
			float num7 = knockback + base._003CStatsInflictedDamage_003Ek__BackingField;
			base._003CStatsInflictedDamage_003Ek__BackingField = num7;
		}
		goto IL_0313;
		IL_02f6:
		if (damageable != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdi_v1 (VampireSurvivors.Interfaces.IDamageable)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdi_v1 (VampireSurvivors.Interfaces.IDamageable)+260]");
				if ((nint)0 == 0)
				{
					if (second != null)
					{
						nint num8 = (nint)typeof(Projectile);
						nint num9 = (nint)second;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ r8_v6 (Il2CppClass<ArcadeColliderType>)+130]");
						nint num10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
						if (num10 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ r8_v6 (Il2CppClass<ArcadeColliderType>)+C8]");
							object obj6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ rax_v34+FFFFFFF8+v368 @ rax_v30*8]");
							if (0 == (nint)typeof(Projectile))
							{
								obj4 = 1;
								goto IL_031e;
							}
						}
						obj4 = 0;
						goto IL_031e;
					}
					goto IL_0340;
				}
			}
		}
		goto IL_0313;
		IL_0313:
		return false;
		IL_02ca:
		bool flag = obj3 == null;
		damageable = null;
		projectile = null;
		if (!flag)
		{
			damageable = (IDamageable)first;
			projectile = null;
		}
		goto IL_02f6;
	}

	public GattiWeapon()
	{
		List<string> list = new List<string>();
		list._version++;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"cat_i0");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"cat3_i0");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"cat2_i0");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_CatBaseFrames = list;
		_full = 1f;
		_counterWeaponType = WeaponType.GATTI_COUNTER;
		base._002Ector();
	}
}
