using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Characters;

public class TP_Chaos_Character : TP_Character
{
	private PhaserSprite _spriteRing0;

	private PhaserSprite _spriteRing1;

	private PhaserSprite _spriteRing2;

	private PhaserSprite _spriteStatue1;

	private PhaserSprite _spriteStatue2;

	private PhaserSprite _spriteStatue3;

	private PhaserSprite _spriteBackground;

	private float _radius;

	private List<ArcanaType> arcanas;

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		base.MakeLevelOne();
		DamageSound = SfxType.sfx_death_4;
		DamageVolume = 0.5f;
	}

	public override bool ShouldCollideWithWalls()
	{
		return false;
	}

	public unsafe override void AfterFullInitialization()
	{
		//IL_00d3: Expected O, but got I
		//IL_00e3: Expected O, but got I
		//IL_0295: Expected O, but got I4
		//IL_0163: Expected O, but got I
		//IL_032a: Expected O, but got I4
		//IL_0365: Expected I4, but got I8
		//IL_03a1: Expected O, but got I4
		//IL_0443: Expected O, but got I4
		//IL_047e: Expected I4, but got I8
		//IL_04ba: Expected O, but got I4
		//IL_055c: Expected O, but got I4
		//IL_05cf: Expected O, but got I4
		//IL_0671: Expected O, but got I4
		//IL_06e4: Expected O, but got I4
		//IL_0786: Expected O, but got I4
		//IL_07f9: Expected O, but got I4
		//IL_089b: Expected O, but got I4
		//IL_090e: Expected O, but got I4
		//IL_09b0: Expected O, but got I4
		//IL_09eb: Expected I4, but got I8
		//IL_0abe: Expected O, but got Ref
		//IL_0afa: Expected O, but got Ref
		//IL_0bc9: Expected I, but got O
		//IL_0bf1: Expected O, but got I
		//IL_0c20: Expected O, but got I
		//IL_0c3e: Expected O, but got I
		//IL_0c71: Expected I, but got O
		//IL_0c99: Expected O, but got I
		//IL_0cc8: Expected O, but got I
		//IL_0ce6: Expected O, but got I
		//IL_1591: Expected O, but got I
		//IL_0dad: Expected O, but got Ref
		//IL_15f9: Expected O, but got I
		//IL_171d: Expected O, but got Ref
		//IL_17c0: Expected O, but got Ref
		//IL_0fb6: Expected I4, but got O
		//IL_1863: Expected O, but got Ref
		//IL_0b4e->IL106b: Incompatible stack heights: 22 vs 0
		//IL_0b7d->IL106b: Incompatible stack heights: 22 vs 0
		//IL_0bfa->IL106b: Incompatible stack heights: 22 vs 0
		//IL_0c29->IL106b: Incompatible stack heights: 22 vs 0
		//IL_0c5e->IL106b: Incompatible stack heights: 22 vs 0
		//IL_0ca2->IL106b: Incompatible stack heights: 22 vs 0
		//IL_0cd1->IL106b: Incompatible stack heights: 22 vs 0
		//IL_0d06->IL106b: Incompatible stack heights: 22 vs 0
		//IL_1526->IL106b: Incompatible stack heights: 22 vs 0
		//IL_0d65->IL106b: Incompatible stack heights: 22 vs 0
		//IL_0d9b->IL106b: Incompatible stack heights: 22 vs 0
		//IL_159a->IL106b: Incompatible stack heights: 23 vs 0
		//IL_1602->IL106b: Incompatible stack heights: 24 vs 0
		//IL_0e0e->IL106b: Incompatible stack heights: 24 vs 0
		base.AfterFullInitialization();
		SetMaxHistory(0);
		bool flag = arcanas == null;
		CharacterController characterController = this;
		Vector3 value2 = default(Vector3);
		List<System.Int32Enum> accessoriesFacade;
		if (!flag)
		{
			List<ArcanaType>.Enumerator enumerator = default(List<ArcanaType>.Enumerator);
			while (enumerator.MoveNext())
			{
				GameManager core = GM.Core;
				if ((object)GM.Core != null)
				{
					core = (GameManager)(object)core._arcanaManager;
					if (core._arcanaManager != null)
					{
						accessoriesFacade = (List<System.Int32Enum>)(object)core._accessoriesFacade;
						if (core._accessoriesFacade != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v978 @ rcx_v93 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v978 @ rcx_v93 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v978 @ rcx_v93 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v978 @ rcx_v93 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v978 @ rcx_v93 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
								nint num = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v974 @ rdx_v177+18]");
								if (num >= 0)
								{
									((List<System.Int32Enum>)(object)core._accessoriesFacade).AddWithResize((System.Int32Enum)0);
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v978 @ rcx_v93 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
									object obj3 = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v978 @ rcx_v93 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
									nint num2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v974 @ rdx_v177+18]");
									if (num2 >= 0)
									{
										throw new IndexOutOfRangeException();
									}
									_ = 0;
								}
								GameManager core2 = GM.Core;
								if ((object)GM.Core != null)
								{
									if (core2._arcanaManager != null)
									{
										core2._arcanaManager.TriggerArcana(ArcanaType.T00_KILLER);
										continue;
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			bool flag2 = (object)_CharacterRenderer == null;
			characterController = (CharacterController)(object)typeof(RenderingExtensions);
			if (!flag2)
			{
				_CharacterRenderer.enabled = false;
				bool flag3 = (object)GM.Core == null;
				characterController = (CharacterController)(object)GM.Core;
				if (!flag3)
				{
					GM.Core.TogglePlayerHealthBar(visible: false);
					SpriteAnimation spriteAnimation = _spriteAnimation;
					bool flag4 = (object)_spriteAnimation == null;
					characterController = (CharacterController)(object)GM.Core;
					if (!flag4)
					{
						spriteAnimation._originalSpriteSize = (float2)1107296256;
						_ = 1107296256;
						GameObject gameObject = base.gameObject;
						Vector2 vector = default(Vector2);
						PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "character_tp_chaos", "TP_Chaos_i01");
						bool flag5 = (object)phaserSprite == null;
						characterController = (CharacterController)(object)gameObject;
						if (!flag5)
						{
							PhaserSprite phaserSprite2 = phaserSprite.setVisible(visible: true);
							bool flag6 = (object)phaserSprite2 == null;
							characterController = (CharacterController)(object)phaserSprite;
							if (!flag6)
							{
								PhaserSprite phaserSprite3 = phaserSprite2.setScale(2.5f, (float?)(object)0);
								bool flag7 = (object)phaserSprite3 == null;
								characterController = (CharacterController)(object)phaserSprite2;
								if (!flag7)
								{
									PhaserSprite phaserSprite4 = phaserSprite3.setDepth(-1998);
									bool flag8 = (object)phaserSprite4 == null;
									characterController = (CharacterController)(object)phaserSprite3;
									if (!flag8)
									{
										PhaserSprite spriteRing = phaserSprite4.setOrigin(0.5f, (float?)(object)1);
										_spriteRing0 = spriteRing;
										GameObject gameObject2 = base.gameObject;
										PhaserSprite phaserSprite5 = RenderingExtensions.AddPhaserSprite(gameObject2, vector, "character_tp_chaos", "TP_Chaos_i02");
										bool flag9 = (object)phaserSprite5 == null;
										characterController = (CharacterController)(object)gameObject2;
										if (!flag9)
										{
											PhaserSprite phaserSprite6 = phaserSprite5.setVisible(visible: true);
											bool flag10 = (object)phaserSprite6 == null;
											characterController = (CharacterController)(object)phaserSprite5;
											if (!flag10)
											{
												PhaserSprite phaserSprite7 = phaserSprite6.setScale(2.5f, (float?)(object)0);
												bool flag11 = (object)phaserSprite7 == null;
												characterController = (CharacterController)(object)phaserSprite6;
												if (!flag11)
												{
													PhaserSprite phaserSprite8 = phaserSprite7.setDepth(-1997);
													bool flag12 = (object)phaserSprite8 == null;
													characterController = (CharacterController)(object)phaserSprite7;
													if (!flag12)
													{
														PhaserSprite spriteRing2 = phaserSprite8.setOrigin(0.5f, (float?)(object)1);
														_spriteRing1 = spriteRing2;
														GameObject gameObject3 = base.gameObject;
														PhaserSprite phaserSprite9 = RenderingExtensions.AddPhaserSprite(gameObject3, vector, "character_tp_chaos", "TP_Chaos_i03");
														bool flag13 = (object)phaserSprite9 == null;
														characterController = (CharacterController)(object)gameObject3;
														if (!flag13)
														{
															PhaserSprite phaserSprite10 = phaserSprite9.setVisible(visible: true);
															bool flag14 = (object)phaserSprite10 == null;
															characterController = (CharacterController)(object)phaserSprite9;
															if (!flag14)
															{
																PhaserSprite phaserSprite11 = phaserSprite10.setScale(2.5f, (float?)(object)0);
																bool flag15 = (object)phaserSprite11 == null;
																characterController = (CharacterController)(object)phaserSprite10;
																if (!flag15)
																{
																	PhaserSprite phaserSprite12 = phaserSprite11.setDepth(2);
																	bool flag16 = (object)phaserSprite12 == null;
																	characterController = (CharacterController)(object)phaserSprite11;
																	if (!flag16)
																	{
																		PhaserSprite spriteRing3 = phaserSprite12.setOrigin(0.5f, (float?)(object)1);
																		_spriteRing2 = spriteRing3;
																		GameObject gameObject4 = base.gameObject;
																		PhaserSprite phaserSprite13 = RenderingExtensions.AddPhaserSprite(gameObject4, vector, "character_tp_chaos", "TP_Chaos_i04");
																		bool flag17 = (object)phaserSprite13 == null;
																		characterController = (CharacterController)(object)gameObject4;
																		if (!flag17)
																		{
																			PhaserSprite phaserSprite14 = phaserSprite13.setVisible(visible: true);
																			bool flag18 = (object)phaserSprite14 == null;
																			characterController = (CharacterController)(object)phaserSprite13;
																			if (!flag18)
																			{
																				PhaserSprite phaserSprite15 = phaserSprite14.setScale(2f, (float?)(object)0);
																				bool flag19 = (object)phaserSprite15 == null;
																				characterController = (CharacterController)(object)phaserSprite14;
																				if (!flag19)
																				{
																					PhaserSprite phaserSprite16 = phaserSprite15.setDepth(3);
																					bool flag20 = (object)phaserSprite16 == null;
																					characterController = (CharacterController)(object)phaserSprite15;
																					if (!flag20)
																					{
																						PhaserSprite spriteStatue = phaserSprite16.setOrigin(0.5f, (float?)(object)1);
																						_spriteStatue1 = spriteStatue;
																						GameObject gameObject5 = base.gameObject;
																						PhaserSprite phaserSprite17 = RenderingExtensions.AddPhaserSprite(gameObject5, vector, "character_tp_chaos", "TP_Chaos_i04");
																						bool flag21 = (object)phaserSprite17 == null;
																						characterController = (CharacterController)(object)gameObject5;
																						if (!flag21)
																						{
																							PhaserSprite phaserSprite18 = phaserSprite17.setVisible(visible: true);
																							bool flag22 = (object)phaserSprite18 == null;
																							characterController = (CharacterController)(object)phaserSprite17;
																							if (!flag22)
																							{
																								PhaserSprite phaserSprite19 = phaserSprite18.setScale(2f, (float?)(object)0);
																								bool flag23 = (object)phaserSprite19 == null;
																								characterController = (CharacterController)(object)phaserSprite18;
																								if (!flag23)
																								{
																									PhaserSprite phaserSprite20 = phaserSprite19.setDepth(3);
																									bool flag24 = (object)phaserSprite20 == null;
																									characterController = (CharacterController)(object)phaserSprite19;
																									if (!flag24)
																									{
																										PhaserSprite spriteStatue2 = phaserSprite20.setOrigin(0.5f, (float?)(object)1);
																										_spriteStatue2 = spriteStatue2;
																										GameObject gameObject6 = base.gameObject;
																										PhaserSprite phaserSprite21 = RenderingExtensions.AddPhaserSprite(gameObject6, vector, "character_tp_chaos", "TP_Chaos_i04");
																										bool flag25 = (object)phaserSprite21 == null;
																										characterController = (CharacterController)(object)gameObject6;
																										if (!flag25)
																										{
																											PhaserSprite phaserSprite22 = phaserSprite21.setVisible(visible: true);
																											bool flag26 = (object)phaserSprite22 == null;
																											characterController = (CharacterController)(object)phaserSprite21;
																											if (!flag26)
																											{
																												PhaserSprite phaserSprite23 = phaserSprite22.setScale(2f, (float?)(object)0);
																												bool flag27 = (object)phaserSprite23 == null;
																												characterController = (CharacterController)(object)phaserSprite22;
																												if (!flag27)
																												{
																													PhaserSprite phaserSprite24 = phaserSprite23.setDepth(3);
																													bool flag28 = (object)phaserSprite24 == null;
																													characterController = (CharacterController)(object)phaserSprite23;
																													if (!flag28)
																													{
																														PhaserSprite spriteStatue3 = phaserSprite24.setOrigin(0.5f, (float?)(object)1);
																														_spriteStatue3 = spriteStatue3;
																														GameObject gameObject7 = base.gameObject;
																														PhaserSprite phaserSprite25 = RenderingExtensions.AddPhaserSprite(gameObject7, vector, "character_tp_chaos", "TP_Chaos_i05");
																														bool flag29 = (object)phaserSprite25 == null;
																														characterController = (CharacterController)(object)gameObject7;
																														if (!flag29)
																														{
																															PhaserSprite phaserSprite26 = phaserSprite25.setVisible(visible: true);
																															bool flag30 = (object)phaserSprite26 == null;
																															characterController = (CharacterController)(object)phaserSprite25;
																															if (!flag30)
																															{
																																PhaserSprite phaserSprite27 = phaserSprite26.setScale(2.5f, (float?)(object)0);
																																bool flag31 = (object)phaserSprite27 == null;
																																characterController = (CharacterController)(object)phaserSprite26;
																																if (!flag31)
																																{
																																	PhaserSprite spriteBackground = phaserSprite27.setDepth(-1999);
																																	_spriteBackground = spriteBackground;
																																	characterController = (CharacterController)(object)phaserSprite27;
																																	object spriteRing4 = _spriteRing0;
																																	if ((object)_spriteRing0 != null)
																																	{
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ r14_v56 (System.Object)+10]");
																																		bool flag32 = (nint)0 == 0;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ r14_v56 (System.Object)+10]");
																																		IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
																																		Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
																																		bool flag33 = (object)transform == null;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5151 @ rax_v209 (UnityEngine.Transform)+10]");
																																		bool flag34 = (nint)0 == 0;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5151 @ rax_v209 (UnityEngine.Transform)+10]");
																																		Vector3 value = default(Vector3);
																																		Transform.set_localPosition_Injected((IntPtr)0, ref value);
																																		object spriteRing5 = _spriteRing1;
																																		bool flag35 = (object)_spriteRing1 == null;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1635 @ r14_v58 (System.Object)+10]");
																																		bool flag36 = (nint)0 == 0;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1635 @ r14_v58 (System.Object)+10]");
																																		IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
																																		Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
																																		bool flag37 = (object)transform2 == null;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5246 @ rax_v222 (UnityEngine.Transform)+10]");
																																		bool flag38 = (nint)0 == 0;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5246 @ rax_v222 (UnityEngine.Transform)+10]");
																																		Transform.set_localPosition_Injected((IntPtr)0, ref value2);
																																		object spriteRing6 = _spriteRing2;
																																		bool flag39 = (object)_spriteRing2 == null;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1790 @ r14_v60 (System.Object)+10]");
																																		bool flag40 = (nint)0 == 0;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1790 @ r14_v60 (System.Object)+10]");
																																		IntPtr gcHandlePtr3 = Component.get_transform_Injected((IntPtr)0);
																																		Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
																																		bool flag41 = (object)transform3 == null;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5341 @ rax_v234 (UnityEngine.Transform)+10]");
																																		bool flag42 = (nint)0 == 0;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5341 @ rax_v234 (UnityEngine.Transform)+10]");
																																		Transform.set_localPosition_Injected((IntPtr)0, ref value);
																																		object spriteStatue4 = _spriteStatue1;
																																		bool flag43 = (object)_spriteStatue1 == null;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1985 @ r14_v62 (System.Object)+10]");
																																		bool flag44 = (nint)0 == 0;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1985 @ r14_v62 (System.Object)+10]");
																																		IntPtr gcHandlePtr4 = Component.get_transform_Injected((IntPtr)0);
																																		Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr4);
																																		bool flag45 = (object)transform4 == null;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5436 @ rax_v246 (UnityEngine.Transform)+10]");
																																		bool flag46 = (nint)0 == 0;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5436 @ rax_v246 (UnityEngine.Transform)+10]");
																																		Transform.set_localPosition_Injected((IntPtr)0, ref value2);
																																		bool flag47 = (object)_spriteStatue2 == null;
																																		Transform transform5 = _spriteStatue2.transform;
																																		bool flag48 = (object)transform5 == null;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5490 @ rax_v254 (UnityEngine.Transform)+10]");
																																		bool flag49 = (nint)0 == 0;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5490 @ rax_v254 (UnityEngine.Transform)+10]");
																																		Transform.set_localPosition_Injected((IntPtr)0, ref value);
																																		bool flag50 = (object)_spriteStatue3 == null;
																																		Transform transform6 = _spriteStatue3.transform;
																																		bool flag51 = (object)transform6 == null;
																																		transform6.localPosition = (Vector3)(&value2);
																																		bool flag52 = (object)_spriteBackground == null;
																																		Transform transform7 = _spriteBackground.transform;
																																		bool flag53 = (object)transform7 == null;
																																		transform7.localPosition = (Vector3)(&value);
																																		Camera main = Camera.main;
																																		Bounds bounds = CameraExtensions.OrthographicBoundsIgnoringBorders(main);
																																		float num3 = (float)vector * 2f;
																																		characterController = (CharacterController)(object)_spriteBackground;
																																		if ((object)_spriteBackground != null)
																																		{
																																			bool flag54 = characterController.body == null;
																																			characterController = (CharacterController)(object)characterController.body;
																																			if (!flag54)
																																			{
																																				Vector2 vector2 = ((SpriteRenderer)(object)characterController.body).size;
																																				PhaserSprite phaserSprite28 = RenderingExtensions.SetScale(scale: num3 / (float)vector2, component: _spriteBackground);
																																				nint num4 = (nint)typeof(GM);
																																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v925 @ rax_v279 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
																																				nint num5 = 0;
																																				bool flag55 = (object)GM.Core == null;
																																				characterController = (CharacterController)num5;
																																				if (!flag55)
																																				{
																																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184FED160");
																																					object obj4 = default(object);
																																					bool flag56 = obj4 == null;
																																					characterController = (CharacterController)num5;
																																					if (!flag56)
																																					{
																																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v926 @ rax_v280+28]");
																																						characterController = (CharacterController)0;
																																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v926 @ rax_v280+28]");
																																						if ((nint)0 != 0)
																																						{
																																							nint num6 = (nint)typeof(GM);
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v927 @ rax_v281 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
																																							nint num7 = 0;
																																							bool flag57 = (object)GM.Core == null;
																																							characterController = (CharacterController)num7;
																																							if (!flag57)
																																							{
																																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184FED160");
																																								object obj5 = default(object);
																																								bool flag58 = obj5 == null;
																																								characterController = (CharacterController)num7;
																																								if (!flag58)
																																								{
																																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v928 @ rax_v282+28]");
																																									characterController = (CharacterController)0;
																																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v928 @ rax_v282+28]");
																																									if ((nint)0 != 0)
																																									{
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rcx_v99 (VampireSurvivors.Objects.Characters.CharacterController)+14]");
																																										if (0 <= (nint)((UnityEngine.Object)characterController).m_CachedPtr)
																																										{
																																											goto IL_1500;
																																										}
																																										bool flag59 = (object)_spriteBackground == null;
																																										characterController = (CharacterController)(object)typeof(RenderingExtensions);
																																										if (!flag59)
																																										{
																																											Transform transform8 = _spriteBackground.transform;
																																											bool flag60 = (object)transform8 == null;
																																											characterController = (CharacterController)(object)_spriteBackground;
																																											if (!flag60)
																																											{
																																												Vector2 vector3 = default(Vector2);
																																												transform8.localEulerAngles = (Vector3)(&vector3);
																																												goto IL_1500;
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
		goto IL_106b;
		IL_1500:
		Camera main2 = Camera.main;
		bool flag61 = (object)main2 == null;
		characterController = null;
		if (!flag61)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v931 @ rax_v284 (UnityEngine.Camera)+10]");
			bool flag62 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v931 @ rax_v284 (UnityEngine.Camera)+10]");
			IntPtr intPtr = Component.get_transform_Injected((IntPtr)0);
			Transform parent = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(intPtr);
			object spriteBackground2 = _spriteBackground;
			bool flag63 = (object)_spriteBackground == null;
			characterController = (CharacterController)(nint)intPtr;
			if (!flag63)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ r14_v70 (System.Object)+10]");
				bool flag64 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ r14_v70 (System.Object)+10]");
				IntPtr intPtr2 = Component.get_transform_Injected((IntPtr)0);
				Transform transform9 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(intPtr2);
				bool flag65 = (object)transform9 == null;
				characterController = (CharacterController)(nint)intPtr2;
				if (!flag65)
				{
					transform9.SetParent(parent, worldPositionStays: true);
					object spriteBackground3 = _spriteBackground;
					bool flag66 = (object)_spriteBackground == null;
					characterController = (CharacterController)(object)transform9;
					if (!flag66)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ r14_v71 (System.Object)+10]");
						bool flag67 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ r14_v71 (System.Object)+10]");
						IntPtr gcHandlePtr5 = Component.get_transform_Injected((IntPtr)0);
						Transform transform10 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr5);
						bool flag68 = (object)transform10 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5808 @ rax_v300 (UnityEngine.Transform)+10]");
						bool flag69 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5808 @ rax_v300 (UnityEngine.Transform)+10]");
						Transform.set_localPosition_Injected((IntPtr)0, ref value2);
						object spriteRing7 = _spriteRing0;
						bool flag70 = (object)_spriteRing0 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2626 @ r14_v73 (System.Object)+10]");
						bool flag71 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2626 @ r14_v73 (System.Object)+10]");
						IntPtr gcHandlePtr6 = Component.get_transform_Injected((IntPtr)0);
						Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr6);
						Vector2 vector4 = default(Vector2);
						TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DORotate(target, (Vector3)(&vector4), 10f, RotateMode.FastBeyond360);
						if (tweenerCore != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5906 @ rax_v313 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5906 @ rax_v313 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
								if ((nint)0 == 0)
								{
									_ = 4294967295L;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5906 @ rax_v313 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
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
						bool flag72 = tweenerCore == null;
						object spriteRing8 = _spriteRing1;
						bool flag73 = (object)_spriteRing1 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2697 @ r14_v76 (System.Object)+10]");
						bool flag74 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2697 @ r14_v76 (System.Object)+10]");
						IntPtr gcHandlePtr7 = Component.get_transform_Injected((IntPtr)0);
						Transform target2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr7);
						Vector2 vector5 = default(Vector2);
						TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DORotate(target2, (Vector3)(&vector5), 10f, RotateMode.FastBeyond360);
						if (tweenerCore2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6080 @ rax_v322 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6080 @ rax_v322 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
								if ((nint)0 == 0)
								{
									_ = 4294967295L;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6080 @ rax_v322 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
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
						bool flag75 = tweenerCore2 == null;
						System.Int32Enum int32Enum = (System.Int32Enum)_spriteRing2;
						bool flag76 = (object)_spriteRing2 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2807 @ rdi_v53 (System.Int32Enum)+10]");
						bool flag77 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2807 @ rdi_v53 (System.Int32Enum)+10]");
						IntPtr gcHandlePtr8 = Component.get_transform_Injected((IntPtr)0);
						Transform target3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr8);
						Vector2 vector6 = default(Vector2);
						TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore3 = ShortcutExtensions.DORotate(target3, (Vector3)(&vector6), 10f, RotateMode.FastBeyond360);
						if (tweenerCore3 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6254 @ rax_v331 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6254 @ rax_v331 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
								if ((nint)0 == 0)
								{
									_ = 4294967295L;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6254 @ rax_v331 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
									if ((nint)0 == 0)
									{
										_ = 2139095040;
									}
								}
							}
						}
						Tween tween = VampireSurvivors.Tools.TweenExtensions.SetGameId(tweenerCore3);
						return;
					}
				}
			}
		}
		goto IL_106b;
		IL_106b:
		accessoriesFacade = (List<System.Int32Enum>)(object)characterController;
		throw new NullReferenceException();
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		Transform transform = _spriteRing2.transform;
		float num = transform.localEulerAngles.z - 10f;
		float num2 = num * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		Transform transform2 = _spriteStatue1.transform;
		bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
		Transform transform3 = _spriteRing2.transform;
		float num3 = transform3.localEulerAngles.z + 90f;
		float num4 = num3 * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		Transform transform4 = _spriteStatue2.transform;
		bool flag2 = (object)transform4 == null;
		bool flag3 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref value2);
		bool flag4 = (object)_spriteRing2 == null;
		Transform transform5 = _spriteRing2.transform;
		bool flag5 = (object)transform5 == null;
		float num5 = transform5.localEulerAngles.z + 190f;
		float num6 = num5 * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		bool flag6 = (object)_spriteStatue3 == null;
		Transform transform6 = _spriteStatue3.transform;
		bool flag7 = (object)transform6 == null;
		bool flag8 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref value);
		bool flag9 = (object)_CharacterRenderer == null;
		_CharacterRenderer.enabled = false;
		bool flag10 = (object)GM.Core == null;
		GM.Core.TogglePlayerHealthBar(visible: false);
	}

	public TP_Chaos_Character()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0ce2: Expected O, but got I
		//IL_0116: Expected O, but got I
		//IL_0d23: Expected O, but got I
		//IL_01aa: Expected O, but got I
		//IL_0d4b: Expected O, but got I
		//IL_023e: Expected O, but got I
		//IL_0d73: Expected O, but got I
		//IL_02d2: Expected O, but got I
		//IL_0d9b: Expected O, but got I
		//IL_0366: Expected O, but got I
		//IL_0dc3: Expected O, but got I
		//IL_03fa: Expected O, but got I
		//IL_0deb: Expected O, but got I
		//IL_048e: Expected O, but got I
		//IL_0e13: Expected O, but got I
		//IL_0522: Expected O, but got I
		//IL_0e3b: Expected O, but got I
		//IL_05b6: Expected O, but got I
		//IL_0e63: Expected O, but got I
		//IL_064a: Expected O, but got I
		//IL_0e8b: Expected O, but got I
		//IL_06de: Expected O, but got I
		//IL_0eb3: Expected O, but got I
		//IL_0772: Expected O, but got I
		//IL_0edb: Expected O, but got I
		//IL_0806: Expected O, but got I
		//IL_0f03: Expected O, but got I
		//IL_089a: Expected O, but got I
		//IL_0f2b: Expected O, but got I
		//IL_092e: Expected O, but got I
		//IL_0f53: Expected O, but got I
		//IL_09c2: Expected O, but got I
		//IL_0f7b: Expected O, but got I
		//IL_0a56: Expected O, but got I
		//IL_0fa3: Expected O, but got I
		//IL_0aea: Expected O, but got I
		//IL_0fcb: Expected O, but got I
		//IL_0b7e: Expected O, but got I
		//IL_0ff3: Expected O, but got I
		//IL_0c12: Expected O, but got I
		_radius = 1.2f;
		List<ArcanaType> list = new List<ArcanaType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdx_v4+18]");
			if (num2 >= 0)
			{
				goto IL_0ce7;
			}
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdx_v6+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)2);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdx_v6+18]");
			if (num4 >= 0)
			{
				goto IL_0ce7;
			}
			_ = 2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rdx_v8+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)3);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rdx_v8+18]");
			if (num6 >= 0)
			{
				goto IL_0ce7;
			}
			_ = 3;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdx_v10+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)4);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdx_v10+18]");
			if (num8 >= 0)
			{
				goto IL_0ce7;
			}
			_ = 4;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdx_v12+18]");
		if (num9 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)5);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdx_v12+18]");
			if (num10 >= 0)
			{
				goto IL_0ce7;
			}
			_ = 5;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdx_v14+18]");
		if (num11 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)6);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj12 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			nint num12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdx_v14+18]");
			if (num12 >= 0)
			{
				goto IL_0ce7;
			}
			_ = 6;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdx_v16+18]");
		if (num13 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)7);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj14 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			nint num14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdx_v16+18]");
			if (num14 >= 0)
			{
				goto IL_0ce7;
			}
			_ = 7;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdx_v18+18]");
		if (num15 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)8);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj16 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			nint num16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdx_v18+18]");
			if (num16 >= 0)
			{
				goto IL_0ce7;
			}
			_ = 8;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rdx_v20+18]");
		if (num17 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)9);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj18 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			nint num18 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rdx_v20+18]");
			if (num18 >= 0)
			{
				goto IL_0ce7;
			}
			_ = 9;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v22+18]");
		if (num19 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)10);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj20 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			nint num20 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v22+18]");
			if (num20 >= 0)
			{
				goto IL_0ce7;
			}
			_ = 10;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rdx_v24+18]");
		if (num21 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)11);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj22 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			nint num22 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rdx_v24+18]");
			if (num22 >= 0)
			{
				goto IL_0ce7;
			}
			_ = 11;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rdx_v26+18]");
		if (num23 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)12);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj24 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			nint num24 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rdx_v26+18]");
			if (num24 >= 0)
			{
				goto IL_0ce7;
			}
			_ = 12;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdx_v28+18]");
		if (num25 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)13);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj26 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			nint num26 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdx_v28+18]");
			if (num26 >= 0)
			{
				goto IL_0ce7;
			}
			_ = 13;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rdx_v30+18]");
		if (num27 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)14);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj28 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			nint num28 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rdx_v30+18]");
			if (num28 >= 0)
			{
				goto IL_0ce7;
			}
			_ = 14;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rdx_v32+18]");
		if (num29 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)15);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj30 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			nint num30 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rdx_v32+18]");
			if (num30 >= 0)
			{
				goto IL_0ce7;
			}
			_ = 15;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdx_v34+18]");
		if (num31 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)16);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj32 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			nint num32 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdx_v34+18]");
			if (num32 >= 0)
			{
				goto IL_0ce7;
			}
			_ = 16;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdx_v36+18]");
		if (num33 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)17);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj34 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			nint num34 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdx_v36+18]");
			if (num34 >= 0)
			{
				goto IL_0ce7;
			}
			_ = 17;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdx_v38+18]");
		if (num35 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)18);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj36 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			nint num36 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdx_v38+18]");
			if (num36 >= 0)
			{
				goto IL_0ce7;
			}
			_ = 18;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rdx_v40+18]");
		if (num37 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)19);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj38 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			nint num38 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rdx_v40+18]");
			if (num38 >= 0)
			{
				goto IL_0ce7;
			}
			_ = 19;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj39 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num39 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rdx_v42+18]");
		if (num39 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)20);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj40 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			nint num40 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rdx_v42+18]");
			if (num40 >= 0)
			{
				goto IL_0ce7;
			}
			_ = 20;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj41 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num41 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rdx_v44+18]");
		if (num41 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)21);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj42 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			nint num42 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rdx_v44+18]");
			if (num42 >= 0)
			{
				goto IL_0ce7;
			}
			_ = 21;
		}
		arcanas = list;
		((CharacterController)this)._002Ector();
		return;
		IL_0ce7:
		throw new IndexOutOfRangeException();
	}
}
