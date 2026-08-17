using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_AlucardSword1_Projectile : Projectile
{
	private SpriteAnimation _anim;

	private bool _cachedFlipX;

	private const int AnimFPS = 50;

	private const float XOffset = 0.14f;

	private const float XRepeatOffset = 0.16f;

	private const float YOffset = 0.26f;

	protected override void Awake()
	{
		//IL_00ac: Expected I, but got O
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("TP_VFX_AlucardSwordReal01", "ThosePeople");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		CheckRenderer();
		GameObject gameObject = ((ArcadeSprite)this)._spriteRenderer.gameObject;
		SpriteAnimation anim = gameObject.AddComponent<SpriteAnimation>();
		_anim = anim;
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_AlucardSwordReal", 1, 8, "ThosePeople", num);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_AlucardSword1_Projectile>)+440]");
		Action action = new Action(this, (IntPtr)0);
		nint num2 = (nint)this;
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_anim.AddAnimation("attack", animationFrames, 50, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_00fb: Expected O, but got I4
		//IL_0134: Expected O, but got I4
		//IL_0134: Expected O, but got I4
		//IL_016e: Expected F4, but got I4
		//IL_0187: Expected O, but got I4
		//IL_02a0: Expected O, but got I4
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Expected O, but got Unknown
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Expected I4, but got Unknown
		//IL_0306: Expected O, but got I4
		//IL_047b->IL034b: Incompatible stack heights: 5 vs 0
		//IL_01a5->IL034b: Incompatible stack heights: 5 vs 0
		//IL_01de->IL034b: Incompatible stack heights: 5 vs 0
		//IL_0200->IL034b: Incompatible stack heights: 5 vs 0
		//IL_0230->IL034b: Incompatible stack heights: 5 vs 0
		//IL_04a2->IL034b: Incompatible stack heights: 5 vs 0
		//IL_0264->IL034b: Incompatible stack heights: 5 vs 0
		//IL_0288->IL034b: Incompatible stack heights: 5 vs 0
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		if ((object)_weapon != null)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
			{
				_cachedFlipX = characterController._isFlipped;
				if ((object)_weapon != null)
				{
					float num = _weapon.PArea();
					if (!characterController._isFlipped)
					{
					}
					Transform transform = base.transform;
					if ((object)_weapon != null)
					{
						Transform transform2 = _weapon.transform;
						if ((object)transform2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v24 (UnityEngine.Transform)+10]");
							bool flag = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v24 (UnityEngine.Transform)+10]");
							Transform.get_position_Injected((IntPtr)0, out Vector3 _);
							bool flag2 = (object)transform == null;
							bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Vector3 value = default(Vector3);
							Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
							ArcadeSprite arcadeSprite = setFlipX(_cachedFlipX);
							bool flag4 = (object)_weapon == null;
							float num2 = _weapon.PArea();
							float xScale = default(float);
							ArcadeSprite arcadeSprite2 = setScale(xScale, (float?)(object)0);
							bool flag5 = body == null;
							BaseBody baseBody = body.setSize((float?)(object)1, (float?)(object)1);
							float x = ((!_cachedFlipX) ? 0f : (-16f));
							if (body != null)
							{
								BaseBody baseBody2 = body.setOffset(x, (float?)(object)1);
								if ((object)_anim != null)
								{
									_anim.SetAnimation("attack");
									Weapon weapon3 = _weapon;
									if ((object)_weapon != null && (object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
									{
										int num3 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.Depth;
										if ((object)GM.Core != null)
										{
											PhaserScene s_scene = ArcadePhysics.s_scene;
											if (ArcadePhysics.s_scene != null)
											{
												PhaserScene.Renderer renderer = s_scene._renderer;
												if (s_scene._renderer != null && (object)_renderer != null)
												{
													object obj = renderer.pixelHeight >> 31;
													object obj2 = renderer.pixelHeight - obj;
													object obj3 = obj2 >> 1;
													int sortingOrder = num3 + obj3;
													_renderer.sortingOrder = sortingOrder;
													SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
													{
														Rate = 1f,
														Volume = (float?)(object)1
													};
													float detune = (float)_indexInWeapon * -100f;
													soundConfig.Detune = detune;
													float time = default(float);
													PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_SwordSimple, soundConfig, 200f, 10, time);
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
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
	}

	public override void Despawn()
	{
		base.Despawn();
	}

	protected virtual void OnAnimAttackComplete()
	{
		Despawn();
	}
}
