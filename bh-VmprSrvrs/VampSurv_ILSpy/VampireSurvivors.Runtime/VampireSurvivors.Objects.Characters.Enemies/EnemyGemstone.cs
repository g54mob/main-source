using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Loot;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyGemstone : EnemyDiamond
{
	private GameObject _MeshContainer;

	private List<MeshRenderer> _GemMeshes;

	protected Transform gemTransform;

	protected MeshRenderer gemMesh;

	private static WeightedStore WEIGHTEDSTORE;

	private Tween _angleTween;

	private uint[] _initialTints = new uint[24]
	{
		8978176u, 16776960u, 16711935u, 8913151u, 8978176u, 16776960u, 16711935u, 8913151u, 8978176u, 16776960u,
		16711935u, 8913151u, 8978176u, 16776960u, 16711935u, 8913151u, 8978176u, 16776960u, 16711935u, 8913151u,
		65280u, 16711680u, 255u, 65535u
	};

	private TweenerCore<Vector3, Vector3, VectorOptions> _scaleTween;

	private const float MinRotateDuration = 2f;

	private const float MaxRotateDuration = 3f;

	protected override bool UseStandardLootTable => false;

	protected override float InvulDelay => 700f;

	protected override float ItemChance => 0.615f;

	protected override float Volume_breaking => 0.125f;

	protected override float Volume_gotHit => 0.075f;

	protected override SfxType Sfx_breaking => SfxType.Crystal12;

	protected override SfxType Sfx_gotHit => SfxType.Bumper;

	protected override bool ChangeFramesOnHit => false;

	protected override bool DoBaseUpdate => false;

	protected override bool IsImmovable => true;

	protected virtual bool IsAxe => false;

	protected virtual bool IsSnake => false;

	protected virtual uint[] TintProgression => new uint[6] { 16777215u, 16777164u, 16777096u, 16777028u, 16776994u, 16776960u };

	public unsafe void InitRotation()
	{
		//IL_0289: Expected O, but got I
		//IL_003e: Expected O, but got I8
		//IL_00cb: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		EnemyGemstone enemyGemstone = this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			enemyGemstone = (EnemyGemstone)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v50 @ rax_v3 (should have been resolved before IL gen)");
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		float2 float5 = gameSessionData._activeCharacter.position;
		float2 float6 = base.position;
		if (float6 > float5 != 0 || _angleTween != null)
		{
			TweenExtensions.Kill(_angleTween);
		}
		Transform target = gemTransform.transform;
		Vector3 vector = default(Vector3);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(target, (Vector3)(&vector), 2f, RotateMode.FastBeyond360);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 1;
					_ = 0;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 4294967295L;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
					if ((nint)0 == 0)
					{
						_ = 2139095040;
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_angleTween = tweenerCore;
	}

	public unsafe void RandomColor()
	{
		//IL_0076: Expected O, but got I4
		//IL_002b: Expected O, but got Ref
		uint[] initialTints = _initialTints;
		object obj = UnityEngine.Random.RandomRangeInt(0, initialTints.Length);
		Material material = ((Renderer)gemMesh).GetMaterial();
		float num = default(float);
		material.color = (Color)(&num);
		Material material2 = ((Renderer)gemMesh).GetMaterial();
		RenderingExtensions.SetAlpha(material2, 0.9f);
	}

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0825: Expected I, but got O
		//IL_036b: Expected I, but got O
		//IL_0387: Expected I, but got O
		//IL_060e: Expected O, but got Ref
		//IL_062a: Expected O, but got Ref
		//IL_03ab: Expected O, but got I
		//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b9: Expected O, but got Unknown
		//IL_03d4: Expected O, but got I8
		//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e2: Expected O, but got Unknown
		//IL_0c36: Expected O, but got I4
		//IL_0c46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4b: Expected O, but got Unknown
		//IL_066d: Expected I4, but got O
		//IL_0511: Expected O, but got I4
		//IL_0967: Expected I, but got O
		//IL_04be: Expected O, but got I
		//IL_091f: Expected O, but got I4
		//IL_03f6: Expected I, but got O
		//IL_0530: Expected O, but got I4
		//IL_0546: Expected O, but got I
		//IL_055d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0562: Expected O, but got Unknown
		//IL_056a: Unknown result type (might be due to invalid IL or missing references)
		//IL_056f: Expected O, but got Unknown
		//IL_0591: Expected O, but got I
		//IL_05c9: Expected O, but got I
		//IL_0250: Expected O, but got I4
		//IL_026b: Expected O, but got I8
		//IL_027d: Expected O, but got F4
		//IL_0ae9: Expected I4, but got O
		//IL_0a25: Expected I, but got O
		//IL_0b63: Expected I4, but got O
		//IL_0b9c: Expected O, but got I4
		//IL_0709: Expected O, but got Ref
		//IL_078c: Expected I4, but got O
		//IL_0687->IL07b6: Incompatible stack heights: 1 vs 0
		//IL_0aa3->IL07b6: Incompatible stack heights: 2 vs 0
		//IL_0b03->IL07b6: Incompatible stack heights: 3 vs 0
		//IL_0a2a->IL0c7a: Incompatible stack heights: 7 vs 0
		//IL_0b7d->IL07b6: Incompatible stack heights: 4 vs 0
		//IL_06c9->IL07b6: Incompatible stack heights: 5 vs 0
		//IL_06f7->IL07b6: Incompatible stack heights: 5 vs 0
		//IL_0723->IL07b6: Incompatible stack heights: 5 vs 0
		//IL_07a6->IL07b6: Incompatible stack heights: 5 vs 0
		bool asRemote2 = default(bool);
		base.InitEnemy(enemyType, asRemote2);
		selfDuration = 120000f;
		BaseBody baseBody = body;
		bool isImmovable = IsImmovable;
		if (body != null)
		{
			baseBody._immovable = isImmovable;
			((EnemyController)this)._003CIsCullable_003Ek__BackingField = true;
			if (!IsAxe)
			{
				goto IL_080d;
			}
			EnemyData currentEnemyData = _currentEnemyData;
			if (_currentEnemyData != null)
			{
				_defaultSpeed = currentEnemyData._003Cspeed_003Ek__BackingField;
				((EnemyController)this)._003CSpeed_003Ek__BackingField = currentEnemyData._003Cspeed_003Ek__BackingField;
				float2 float5 = base.position;
				GameManager core = GM.Core;
				if ((object)GM.Core != null)
				{
					GameSessionData gameSessionData = core._gameSessionData;
					if (core._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
					{
						float2 float6 = gameSessionData._activeCharacter.position;
						bool flag = (byte)(float5 < float6) != 0;
						object obj = float5 - float6;
						bool flag2 = obj == null;
						bool flag3 = !flag;
						bool flag4 = !flag2;
						bool flag5 = flag4 & flag3;
						ArcadeSprite arcadeSprite = setFlipX(flag5);
						((EnemyController)this)._003CIsCullable_003Ek__BackingField = false;
						float2 float7 = base.position;
						GameManager core2 = GM.Core;
						if ((object)GM.Core != null)
						{
							GameSessionData gameSessionData2 = core2._gameSessionData;
							if (core2._gameSessionData != null && (object)gameSessionData2._activeCharacter != null)
							{
								float2 float8 = gameSessionData2._activeCharacter.position;
								bool flag6 = (byte)(float7 <= float8) != 0;
								object obj2 = 1;
								if (!flag6)
								{
									obj2 = 4294967295L;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,qword ptr [188A10818h]\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm0,qword ptr [188A10958h]\"");
								float num = (float)obj2 * ((float)Math.PI / 180f);
								float num2 = ((EnemyController)this)._003CSpeed_003Ek__BackingField * 0.01f;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
								float num3 = num * num2;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
								float num4 = num * num2;
								BaseBody baseBody2 = body;
								if (body != null)
								{
									baseBody2._velocity = (float2)num3;
									BaseBody baseBody3 = body;
									if (body != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v449 @ rax_v179 (BaseBody)+74]");
										float num5 = 0f * -1f;
										goto IL_080d;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_07b6;
		IL_080d:
		bool flag7 = WEIGHTEDSTORE != null;
		nint num6 = unchecked((nint)null);
		if (!flag7)
		{
			GameManager gameManager = _gameManager;
			if ((object)_gameManager != null)
			{
				ItemType[] items = new ItemType[5]
				{
					ItemType.CLOVER,
					ItemType.COIN,
					ItemType.COINBAG1,
					ItemType.COINBAGMAX,
					ItemType.GILDED
				};
				if (gameManager._lootManager != null)
				{
					WeightedStore wEIGHTEDSTORE = gameManager._lootManager.ExportCustomLootTable(items);
					WEIGHTEDSTORE = wEIGHTEDSTORE;
					nint num7 = (nint)typeof(EnemyGemstone);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
					bool flag8 = (nint)0 == 0;
					num6 = unchecked((nint)null);
					if (!flag8)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v582 @ rax_v157 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyGemstone>)+B8]");
						object obj3 = (nint)0 >> 12;
						object obj4 = obj3 & 0x1FFFFF;
						object obj5 = obj4 >> 6;
						object obj6 = 6603577472L;
						object obj7 = obj4 & 0x3F;
						nint num9;
						do
						{
							object obj8 = 1 << (int)obj7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v670 @ rbx_v28+462E0+v646 @ rdx_v85*8]");
							object obj9 = 0 | obj8;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v670 @ rbx_v28+462E0+v646 @ rdx_v85*8]");
							nint num8 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v670 @ rbx_v28+462E0+v646 @ rdx_v85*8]");
							if (num8 == 0)
							{
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v670 @ rbx_v28+462E0+v646 @ rdx_v85*8]");
							num9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v670 @ rbx_v28+462E0+v646 @ rdx_v85*8]");
						}
						while (num9 != 0);
						num6 = unchecked((nint)null);
					}
					goto IL_08f3;
				}
			}
			goto IL_07b6;
		}
		goto IL_08f3;
		IL_07b6:
		throw new NullReferenceException();
		IL_08f3:
		if ((object)_MeshContainer != null)
		{
			Transform transform = _MeshContainer.transform;
			if ((object)transform != null)
			{
				IEnumerator enumerator = transform.GetEnumerator();
				EnemyType enemyType2 = default(EnemyType);
				object obj10 = default(object);
				object obj18 = default(object);
				EnemyType enemyType3 = default(EnemyType);
				while (true)
				{
					bool flag9 = enemyType2 == EnemyType.BAT1;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					if (obj10 == null)
					{
						break;
					}
					bool flag10 = enemyType2 == EnemyType.BAT1;
					int value__ = ((EnemyType*)(int)enemyType2)->value__;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ r10_v22 (System.Int32)+12E]");
					if ((nint)0 >= (nint)0)
					{
						goto IL_04fe;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ r10_v22 (System.Int32)+B0]");
					object obj11 = 0;
					bool flag11 = false;
					while (true)
					{
						object obj12 = (flag11 ? 1 : 0) + (flag11 ? 1 : 0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ r8_v37+v1264 @ rax_v151*8]");
						if (0 == (nint)typeof(IEnumerator))
						{
							break;
						}
						flag11 = (byte)((flag11 ? 1u : 0u) + 1u) != 0;
						bool num10 = flag11;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ r10_v22 (System.Int32)+12E]");
						if ((nint)(num10 ? 1 : 0) < (nint)0)
						{
							continue;
						}
						goto IL_04fe;
					}
					object obj13 = (flag11 ? 1 : 0) + (flag11 ? 1 : 0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ r8_v37+8+v1319 @ rcx_v131*8]");
					object obj14 = (nint)0 + (nint)1;
					object obj15 = obj14 << 4;
					object obj16 = obj15 + 312;
					object obj17 = obj16 + value__;
					goto IL_094f;
					IL_04fe:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
					obj11 = 1;
					obj17 = obj18;
					goto IL_094f;
					IL_094f:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1326 @ rdx_v68] (should have been resolved before IL gen)");
					nint num11 = (nint)typeof(Transform);
					if (enemyType3 != EnemyType.BAT1)
					{
						int value__2 = ((EnemyType*)(int)enemyType3)->value__;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ rdx_v70 (Il2CppClass<UnityEngine.Transform>)+130]");
						object obj19 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v601 @ r8_v38 (System.Int32)+130]");
						nint num12 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ rdx_v70 (Il2CppClass<UnityEngine.Transform>)+130]");
						bool flag12 = num12 < 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v601 @ r8_v38 (System.Int32)+C8]");
						object obj20 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1116 @ rax_v132+FFFFFFF8+v1115 @ rax_v131*8]");
						bool flag13 = 0 != (nint)typeof(Transform);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v544 @ rax_v130 (VampireSurvivors.Data.EnemyType)+10]");
						bool flag14 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v544 @ rax_v130 (VampireSurvivors.Data.EnemyType)+10]");
						IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
						GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
						bool flag15 = (object)gameObject == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v861 @ rax_v137 (UnityEngine.GameObject)+10]");
						bool flag16 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v861 @ rax_v137 (UnityEngine.GameObject)+10]");
						GameObject.SetActive_Injected((IntPtr)0, false);
						num6 = (nint)typeof(IEnumerator);
						continue;
					}
					throw new NullReferenceException();
				}
				object obj21 = (object)(&enemyType2);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
				object obj22 = (object)(&enemyType2);
				object obj23 = default(object);
				obj22 = obj23;
				if (obj23 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				MeshRenderer meshRenderer = VampireSurvivors.App.Tools.Extensions.PickRnd(_GemMeshes);
				gemMesh = meshRenderer;
				EnemyType enemyType4 = (EnemyType)gemMesh;
				if ((object)gemMesh != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rsi_v24 (VampireSurvivors.Data.EnemyType)+10]");
					bool flag17 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rsi_v24 (VampireSurvivors.Data.EnemyType)+10]");
					IntPtr gcHandlePtr2 = Component.get_gameObject_Injected((IntPtr)0);
					GameObject gameObject2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
					if ((object)gameObject2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ rax_v75 (UnityEngine.GameObject)+10]");
						bool flag18 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ rax_v75 (UnityEngine.GameObject)+10]");
						GameObject.SetActive_Injected((IntPtr)0, true);
						EnemyType enemyType5 = (EnemyType)gemMesh;
						if ((object)gemMesh != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rsi_v26 (VampireSurvivors.Data.EnemyType)+10]");
							bool flag19 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rsi_v26 (VampireSurvivors.Data.EnemyType)+10]");
							Renderer.set_sortingOrder_Injected((IntPtr)0, 2000);
							ArcadeSprite arcadeSprite2 = setVisible(visible: false);
							InitRotation();
							EnemyType enemyType6 = (EnemyType)_initialTints;
							if (_initialTints != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ rsi_v27 (VampireSurvivors.Data.EnemyType)+18]");
								object obj24 = UnityEngine.Random.RandomRangeInt(0, 0);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ rsi_v27 (VampireSurvivors.Data.EnemyType)+18]");
								bool flag20 = (nint)obj24 >= 0;
								if ((object)gemMesh != null)
								{
									Material material = ((Renderer)gemMesh).GetMaterial();
									if ((object)material != null)
									{
										float num13 = default(float);
										material.color = (Color)(&num13);
										if ((object)gemMesh != null)
										{
											Material material2 = ((Renderer)gemMesh).GetMaterial();
											RenderingExtensions.SetAlpha(material2, 0.9f);
											if (_scaleTween != null)
											{
												TweenExtensions.Kill(_scaleTween);
											}
											EnemyType enemyType7 = (EnemyType)gemTransform;
											if ((object)gemTransform != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ rsi_v30 (VampireSurvivors.Data.EnemyType)+10]");
												bool flag21 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ rsi_v30 (VampireSurvivors.Data.EnemyType)+10]");
												IntPtr gcHandlePtr3 = Component.get_transform_Injected((IntPtr)0);
												Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
												TweenerCore<Vector3, Vector3, VectorOptions> scaleTween = ShortcutExtensions.DOScale(target, 1f, 0.2f);
												_scaleTween = scaleTween;
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
		goto IL_07b6;
	}

	public override void OnSpawnDone()
	{
		bool flag = !IsAxe || IsImmovable;
		bool flag2 = !flag;
		bool flag3 = !flag2;
		((EnemyController)this)._003CIsCullable_003Ek__BackingField = flag3;
		selfDuration = 120000f;
	}

	public override void Disappear()
	{
		if (((EnemyController)this)._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		Transform target = gemTransform.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> scaleTween = ShortcutExtensions.DOScale(target, 0.1f, 0.2f);
		_scaleTween = scaleTween;
		if (_selfDestruct)
		{
			_AlertSpriteRenderer.forceRenderingOff = true;
			Tween alertTween = _alertTween;
			if (_alertTween != null && alertTween._003Cactive_003Ek__BackingField)
			{
				TweenExtensions.Kill(_alertTween);
			}
		}
		((EnemyController)this)._003CIsDead_003Ek__BackingField = true;
		_deathStyle = EnemyDeathStyle.Disappear;
		PlayDeathAnimation();
	}

	protected unsafe override void ChangeFrame()
	{
		//IL_0015: Expected O, but got I4
		//IL_015d: Expected O, but got I4
		//IL_058f: Expected O, but got F4
		//IL_006f: Expected O, but got I4
		//IL_028d: Expected O, but got Ref
		//IL_0499: Expected I4, but got F4
		//IL_04b5: Expected I4, but got F4
		//IL_04f5: Expected O, but got Ref
		//IL_0403: Expected O, but got I
		uint[] tintProgression = TintProgression;
		object obj = tintProgression.Length - 1;
		float num = default(float);
		bool canPause;
		if (_hitsTaken < (nint)obj)
		{
			SfxType sfx_gotHit = Sfx_gotHit;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			float volume_gotHit = Volume_gotHit;
			soundConfig.Volume = (float?)(object)1;
			float detune = (float)_hitsTaken * 100f;
			soundConfig.Detune = detune;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(sfx_gotHit, soundConfig, 100f, 4, num);
			uint[] tintProgression2 = TintProgression;
			uint[] tintProgression3 = TintProgression;
			int num2 = _hitsTaken % tintProgression3.Length;
			_saveTint = tintProgression2[num2];
			SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(_EnemyRenderer, tintProgression2[num2]);
			canPause = false;
		}
		else
		{
			SfxType sfx_breaking = Sfx_breaking;
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			soundConfig2.Rate = 1f;
			float volume_breaking = Volume_breaking;
			soundConfig2.Volume = (float?)(object)1;
			object obj2 = UnityEngine.Random.value;
			object obj3 = default(object);
			float detune2 = (float)obj3 * -600f;
			soundConfig2.Detune = detune2;
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(sfx_breaking, soundConfig2, 100f, 4, num);
			if (_scaleTween != null)
			{
				TweenExtensions.Kill(_scaleTween);
			}
			Transform target = gemTransform.transform;
			TweenerCore<Vector3, Vector3, VectorOptions> scaleTween = ShortcutExtensions.DOScale(target, 0.1f, 0.2f);
			_scaleTween = scaleTween;
			Die();
			canPause = false;
		}
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		float2 float5 = gameSessionData._activeCharacter.position;
		float2 float6 = base.position;
		if (float6 > float5 != 0 || _angleTween != null)
		{
			TweenExtensions.Kill(_angleTween);
		}
		Transform target2 = gemTransform.transform;
		Vector3 vector = default(Vector3);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(target2, (Vector3)(&vector), 0.35f, RotateMode.FastBeyond360);
		TweenCallback tweenCallback2;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v806 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v806 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v806 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v806 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v806 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 1;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v806 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v806 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v806 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v806 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+A0]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v806 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+A0]");
						object obj4 = num3 + 0;
					}
					TweenCallback tweenCallback = InitRotation;
					tweenCallback2 = tweenCallback;
					goto IL_0448;
				}
			}
		}
		TweenCallback tweenCallback3 = InitRotation;
		bool flag = tweenerCore == null;
		tweenCallback2 = tweenCallback3;
		if (!flag)
		{
			goto IL_0448;
		}
		goto IL_0477;
		IL_0448:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v806 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_0477;
		IL_0477:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		bool flag2 = (nint)0 != 0;
		bool useRealTime = (byte)(int)num != 0;
		if (!flag2)
		{
			_ = 1;
			useRealTime = (byte)(int)num != 0;
		}
		_angleTween = tweenerCore;
		Material material = ((Renderer)gemMesh).GetMaterial();
		material.color = (Color)(&vector);
		Material material2 = ((Renderer)gemMesh).GetMaterial();
		RenderingExtensions.SetAlpha(material2, 2f);
		Action onComplete = RandomColor;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause);
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		base.UpdateDepth();
	}

	protected override void CustomLoot()
	{
		//IL_03f0: Expected O, but got F4
		//IL_0403: Invalid comparison between F4 and O
		//IL_0422: Invalid comparison between F4 and I4
		//IL_044b: Expected O, but got I4
		//IL_0398: Expected O, but got I
		//IL_02d3: Expected I, but got I8
		//IL_048f->IL02fd: Incompatible stack heights: 1 vs 0
		//IL_02d8->IL046b: Incompatible stack heights: 2 vs 1
		//IL_03e7->IL01c8: Incompatible stack heights: 1 vs 0
		//IL_0353->IL02fd: Incompatible stack heights: 1 vs 0
		//IL_026d->IL01c8: Incompatible stack heights: 1 vs 0
		//IL_01c8->IL03cd: Incompatible stack heights: 0 vs 1
		object obj = UnityEngine.Random.value;
		GameManager gameManager = _gameManager;
		object obj2 = default(object);
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.3f) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
		float num = 0.3f - (float)obj2;
		bool flag2 = num == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj3 = flag4 & flag3;
		Vector2 vector2 = default(Vector2);
		Action<Pickup> callback;
		float xp;
		Vector2 pos;
		GameManager gameManager2;
		Vector3 ret;
		if (obj3 == null)
		{
			if ((object)_gameManager != null && gameManager._lootManager != null)
			{
				ItemType itemFromExportedTable = gameManager._lootManager.GetItemFromExportedTable(WEIGHTEDSTORE);
				if (itemFromExportedTable == ItemType.VOID)
				{
					return;
				}
				Transform transform = base.transform;
				if (itemFromExportedTable != ItemType.COIN)
				{
					if (itemFromExportedTable != ItemType.COINBAG1)
					{
						if (itemFromExportedTable != ItemType.GEM)
						{
							if ((object)transform != null)
							{
								Vector3 vector = transform.position;
								if ((object)_gameManager != null)
								{
									float value = default(float);
									ItemType relicType = default(ItemType);
									bool shouldCallValidatePickups = default(bool);
									bool isRemote = default(bool);
									Pickup pickup = _gameManager.MakePickup(vector2, itemFromExportedTable, WeaponType.VOID, value, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
									return;
								}
							}
						}
						else if ((object)transform != null)
						{
							Vector3 vector3 = transform.position;
							if ((object)_gameManager != null)
							{
								callback = null;
								xp = 1f;
								pos = vector2;
								gameManager2 = _gameManager;
								goto IL_03cd;
							}
						}
					}
					else if ((object)transform != null)
					{
						Vector3 vector4 = transform.position;
						if ((object)_gameManager != null)
						{
							_gameManager.MakeRedCoinBag(vector2);
							return;
						}
					}
				}
				else if ((object)transform != null)
				{
					bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
					if ((object)_gameManager != null)
					{
						_gameManager.MakeCoin(vector2);
						return;
					}
				}
			}
		}
		else
		{
			Transform transform2 = base.transform;
			if ((object)transform2 != null)
			{
				bool flag6 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				bool flag7 = (nint)0 != 0;
				nint cachedPtr = ((UnityEngine.Object)transform2).m_CachedPtr;
				if (!flag7)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					bool flag8 = obj4 == null;
					cachedPtr = unchecked((nint)6573110936L);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v758 @ rax_v23 (should have been resolved before IL gen)");
				if ((object)_gameManager != null)
				{
					callback = null;
					xp = 1f;
					pos = vector2;
					gameManager2 = _gameManager;
					goto IL_03cd;
				}
			}
		}
		throw new NullReferenceException();
		IL_03cd:
		gameManager2.MakeGem(pos, xp, callback);
	}
}
