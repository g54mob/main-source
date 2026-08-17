using System;
using System.Collections.Generic;
using System.Globalization;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_DraculaHand_Projectile : Projectile
{
	[NonSerialized]
	public bool _isMoving;

	private PhaserSprite _arm;

	private int _armFrameCount;

	private float _armProgress;

	private int _armFrame;

	private bool animsSetup;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("TP_MDR_Hand_i01", "character_tp_dracula");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		base.InitProjectile(pool, weapon, index);
		_isMoving = false;
		_isCullable = false;
		if (!animsSetup)
		{
			CheckRenderer();
			SpriteAnimation component = ((ArcadeSprite)this)._spriteRenderer.GetComponent<SpriteAnimation>();
			int num = default(int);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_MDR_Hand_i", 1, 2, "character_tp_dracula", num);
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			component.AddAnimation("idle", animationFrames, 2, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
			List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("TP_MDR_Hand_i", 3, 4, "character_tp_dracula", num);
			component.AddAnimation("swipe", animationFrames2, 2, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
			component.SetAnimation("idle");
			animsSetup = true;
		}
		PhaserSprite arm = _arm;
		if ((object)_arm == null || ((UnityEngine.Object)arm).m_CachedPtr == (IntPtr)0)
		{
			PhaserWorld instance = PhaserWorld.Instance;
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "character_tp_dracula", "TP_MDR_Arm_i01");
			GameObject gameObject = phaserSprite.gameObject;
			((UnityEngine.Object)gameObject).SetName("DraculaArm");
			_arm = phaserSprite;
		}
		_armFrameCount = 6;
		_armFrame = 1;
	}

	private void InitAnims()
	{
		CheckRenderer();
		SpriteAnimation component = ((ArcadeSprite)this)._spriteRenderer.GetComponent<SpriteAnimation>();
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_MDR_Hand_i", 1, 2, "character_tp_dracula", num);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		component.AddAnimation("idle", animationFrames, 2, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("TP_MDR_Hand_i", 3, 4, "character_tp_dracula", num);
		component.AddAnimation("swipe", animationFrames2, 2, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		component.SetAnimation("idle");
	}

	private unsafe void SetArmFrame(int frame)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected I4, but got Unknown
		_armFrame = frame;
		int num = this + 232;
		string text = ((int*)num)->ToString(CultureInfo.invariant_culture_info);
		string text2 = "TP_MDR_Arm_i0" + text;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		Sprite sprite = default(Sprite);
		PhaserSprite phaserSprite = _arm.setFrame(sprite);
	}

	public void Swipe()
	{
		BaseBody baseBody = body;
		baseBody._enable = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		_isMoving = true;
		_armProgress = 0f;
		SetArmFrame(1);
		CheckRenderer();
		SpriteAnimation component = ((ArcadeSprite)this)._spriteRenderer.GetComponent<SpriteAnimation>();
		component.Play("swipe", 0);
	}

	public override void InternalUpdate()
	{
	}

	private unsafe void LateUpdate()
	{
		//IL_01ac: Expected O, but got I4
		//IL_043f: Expected O, but got I4
		//IL_0456: Unknown result type (might be due to invalid IL or missing references)
		//IL_045b: Expected O, but got Unknown
		//IL_02e4: Invalid comparison between F4 and I4
		//IL_0472: Unknown result type (might be due to invalid IL or missing references)
		//IL_0477: Expected O, but got Unknown
		//IL_034d: Expected O, but got I4
		//IL_048e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0493: Expected O, but got Unknown
		Transform transform = base.transform;
		Weapon weapon = _weapon;
		bool flag;
		bool flag2;
		if ((object)_weapon != null)
		{
			ArcadeSprite arcadeSprite = ((Equipment)weapon)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
			{
				((ArcadeSprite)((Equipment)weapon)._003COwner_003Ek__BackingField).CheckRenderer();
				if ((object)arcadeSprite._spriteRenderer != null)
				{
					Transform parent = arcadeSprite._spriteRenderer.transform;
					if ((object)transform != null)
					{
						transform.SetParent(parent, worldPositionStays: true);
						if ((object)_arm != null)
						{
							Transform transform2 = _arm.transform;
							Weapon weapon2 = _weapon;
							if ((object)_weapon != null)
							{
								ArcadeSprite arcadeSprite2 = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
								if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
								{
									((ArcadeSprite)((Equipment)weapon2)._003COwner_003Ek__BackingField).CheckRenderer();
									if ((object)arcadeSprite2._spriteRenderer != null)
									{
										Transform parent2 = arcadeSprite2._spriteRenderer.transform;
										if ((object)transform2 != null)
										{
											transform2.SetParent(parent2, worldPositionStays: true);
											object obj = _indexInWeapon - 1;
											flag = obj == null;
											if (_indexInWeapon == 1)
											{
											}
											Weapon weapon3 = _weapon;
											if ((object)_weapon != null && (object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
											{
												int num = ((Equipment)weapon3)._003COwner_003Ek__BackingField.depth;
												int num2 = num + 15;
												ArcadeSprite arcadeSprite3 = setDepth(num2);
												ArcadeSprite arcadeSprite4 = setFlipX(flag);
												flag2 = !_isMoving;
												if (!flag2)
												{
													float deltaTime = PauseSystem.DeltaTime;
													if ((object)_weapon == null)
													{
														goto IL_058d;
													}
													float num3 = _weapon.PSpeed();
													float num4 = deltaTime * 4f;
													float num5 = deltaTime * num4;
													float num6 = num5 + _armProgress;
													float num7 = num6 - 1f;
													flag2 = num7 == 0f;
													_armProgress = num6;
													if (num6 > 1f)
													{
														float armProgress = num6 - 1f;
														int num8 = _armFrame + 1;
														_armProgress = armProgress;
														object obj2 = num8 - _armFrameCount;
														flag2 = obj2 == null;
														if (num8 >= _armFrameCount)
														{
															_isMoving = false;
															CheckRenderer();
															if ((object)((ArcadeSprite)this)._spriteRenderer != null)
															{
																SpriteAnimation component = ((ArcadeSprite)this)._spriteRenderer.GetComponent<SpriteAnimation>();
																if ((object)component != null)
																{
																	component.SetAnimation("idle");
																	BaseBody baseBody = body;
																	flag2 = body == null;
																	if (!flag2)
																	{
																		baseBody._enable = false;
																		goto IL_042f;
																	}
																}
															}
															goto IL_058d;
														}
														SetArmFrame(num8);
													}
												}
												goto IL_042f;
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
		goto IL_058d;
		IL_061c:
		Transform transform3 = default(Transform);
		bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
		float2 value = default(float2);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)(&value));
		return;
		IL_060d:
		transform3 = base.transform;
		goto IL_061c;
		IL_058d:
		throw new NullReferenceException();
		IL_042f:
		object obj3 = _armFrame - 1;
		if (!flag2)
		{
			object obj4 = obj3 - 1;
			if (!flag2)
			{
				object obj5 = obj4 - 1;
				if (!flag2)
				{
					object obj6 = obj5 - 1;
					if (!flag2 && (nint)obj6 != 1)
					{
					}
				}
			}
		}
		if (_indexInWeapon != 1)
		{
			if ((object)_arm != null)
			{
				float2 localPosition = default(float2);
				PhaserSprite phaserSprite = _arm.setLocalPosition(localPosition);
				int num9 = base.depth;
				if ((object)_arm != null)
				{
					int num10 = num9 - 1;
					PhaserSprite phaserSprite2 = _arm.setDepth(num10);
					if ((object)_arm != null)
					{
						PhaserSprite phaserSprite3 = _arm.setFlipX(flag);
						if (_indexInWeapon == 1)
						{
							goto IL_060d;
						}
						goto IL_061c;
					}
				}
			}
			goto IL_058d;
		}
		goto IL_060d;
	}
}
