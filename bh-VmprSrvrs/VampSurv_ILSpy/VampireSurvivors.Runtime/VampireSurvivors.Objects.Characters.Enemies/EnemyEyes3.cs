using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyEyes3 : EnemyController
{
	private bool _hasGeneratedSprites;

	private PhaserSprite _eyes;

	private MultiTargetTween _onEnterTween;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		GenerateSprites();
		base.InitEnemy(enemyType, asRemote);
	}

	private void LateUpdate()
	{
		UpdateEyes();
	}

	private unsafe void UpdateEyes()
	{
		//IL_008e: Expected O, but got I4
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		SpriteAnimation spriteAnimation = _SpriteAnimation;
		if ((object)_SpriteAnimation != null)
		{
			FrameAnimationData currentAnimation = ((BaseSpriteAnimation)spriteAnimation)._currentAnimation;
			if (((BaseSpriteAnimation)spriteAnimation)._currentAnimation != null)
			{
				bool flag = currentAnimation._frameIndex == 0;
				if (!flag)
				{
					object obj = currentAnimation._frameIndex - 1;
					if (!flag)
					{
						object obj2 = obj - 1;
						if (!flag && (nint)obj2 != 1)
						{
						}
					}
				}
			}
			if (base.flipX)
			{
			}
			if ((object)_eyes != null)
			{
				Transform transform = _eyes.transform;
				CheckRenderer();
				if ((object)((ArcadeSprite)this)._spriteRenderer != null)
				{
					Transform transform2 = ((ArcadeSprite)this)._spriteRenderer.transform;
					if ((object)transform2 != null)
					{
						bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret);
						bool flag3 = (object)transform == null;
						bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Vector3 value = default(Vector3);
						Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
						bool flag5 = (object)_eyes == null;
						Transform transform3 = _eyes.transform;
						CheckRenderer();
						bool flag6 = (object)((ArcadeSprite)this)._spriteRenderer == null;
						Transform transform4 = ((ArcadeSprite)this)._spriteRenderer.transform;
						bool flag7 = (object)transform4 == null;
						bool flag8 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
						Transform.get_rotation_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out *(Quaternion*)(&ret));
						bool flag9 = (object)transform3 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v905 @ rax_v40 (UnityEngine.Transform)+10]");
						bool flag10 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v905 @ rax_v40 (UnityEngine.Transform)+10]");
						Quaternion value2 = default(Quaternion);
						Transform.set_rotation_Injected((IntPtr)0, ref value2);
						bool flag11 = base.flipX;
						bool flag12 = (object)_eyes == null;
						PhaserSprite phaserSprite = _eyes.setFlipX(flag11);
						int num = base.depth;
						bool flag13 = (object)_eyes == null;
						int num2 = num + 1;
						PhaserSprite phaserSprite2 = _eyes.setDepth(num2);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void Die()
	{
		base.Die();
		PhaserSprite phaserSprite = _eyes.setVisible(visible: false);
	}

	public override void Disappear()
	{
		base.Disappear();
		PhaserSprite phaserSprite = _eyes.setVisible(visible: false);
	}

	public override void Despawn()
	{
		base.Despawn();
		PhaserSprite phaserSprite = _eyes.setVisible(visible: false);
	}

	protected override void OnRecycleEnemy()
	{
		//IL_0030: Expected O, but got I4
		//IL_0030: Expected F4, but got O
		//IL_0057: Expected O, but got I4
		//IL_00b1: Expected O, but got I
		//IL_010b: Expected O, but got I
		//IL_0237: Expected O, but got I
		//IL_0175: Expected O, but got I
		//IL_01e9: Expected O, but got I
		base.OnRecycleEnemy();
		BaseBody baseBody = body;
		ArcadeTransform arcadeTransform = baseBody._transform;
		PhaserSprite phaserSprite = _eyes.setOrigin((float)arcadeTransform._origin, (float?)(object)1);
		float xScale = base.scale;
		PhaserSprite phaserSprite2 = _eyes.setScale(xScale, (float?)(object)0);
		PhaserSprite phaserSprite3 = _eyes.setVisible(visible: true);
		UpdateEyes();
		List<uint> list = new List<uint>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v13 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v13 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v13 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdx_v8+18]");
		if (num >= 0)
		{
			list.AddWithResize(8947814u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v13 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 8947814;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v13 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v13 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v13 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v10+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(8939110u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v13 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 8939110;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v13 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v13 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		uint item = 0u;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v13 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ rdx_v13 (System.UInt32)+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(8947780u);
			item = 8947780u;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v13 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj5 = (nint)0 + (nint)1;
			_ = 8947780;
		}
		list.Add(item);
		uint num4 = default(uint);
		_saveTint = num4;
		ArcadeSprite arcadeSprite = setTint(num4);
	}

	private void GenerateSprites()
	{
		if (!_hasGeneratedSprites)
		{
			_hasGeneratedSprites = true;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			PhaserSprite phaserSprite = RenderingExtensions.sprite(s_scene.add, pos, "enemiesM", "Mud_eyes");
			PhaserSprite phaserSprite2 = phaserSprite.setDepth(3200);
			GameObject gameObject = phaserSprite2.gameObject;
			((UnityEngine.Object)gameObject).SetName("EnemyEyes3 - Eyes");
			PhaserSprite eyes = phaserSprite2.setVisible(visible: false);
			_eyes = eyes;
		}
	}
}
