using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class Enemy_FB_DieWithExplosions : EnemyController
{
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public int localIndex;

		public float2 bodyPos;

		public float expAngle;

		public float radius;

		public float rnd;

		public Enemy_FB_DieWithExplosions _003C_003E4__this;

		internal void _003CPlayExplosions_003Eb__0()
		{
			//IL_015c: Expected F4, but got I4
			Enemy_FB_DieWithExplosions enemy_FB_DieWithExplosions = _003C_003E4__this;
			List<PhaserSprite> explosionSprites = enemy_FB_DieWithExplosions.explosionSprites;
			if (explosionSprites._size >= localIndex)
			{
				Enemy_FB_DieWithExplosions enemy_FB_DieWithExplosions2 = _003C_003E4__this;
				List<PhaserSprite> explosionSprites2 = enemy_FB_DieWithExplosions2.explosionSprites;
				int num = localIndex;
				if (localIndex < explosionSprites2._size)
				{
					PhaserSprite[] items = explosionSprites2._items;
					PhaserSprite phaserSprite = items[num];
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					float num2 = expAngle * radius;
					float num3 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.Enemy_FB_DieWithExplosions+<>c__DisplayClass11_0)+18]");
					float num4 = num3 + 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
					PhaserSprite phaserSprite2 = items[num].setVisible(visible: true);
					phaserSprite._spriteAnimation.SetAnimation("bang");
					float? volume = default(float?);
					float rate = default(float);
					float detune = default(float);
					bool loop = default(bool);
					PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_Explosion1, 500f, 10, 0f, volume, rate, detune, loop, 1f);
				}
				else
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				}
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public PhaserSprite exp;

		internal void _003CInitEnemy_003Eb__0()
		{
			PhaserSprite phaserSprite = exp.setVisible(visible: false);
		}
	}

	private float OnDeathScaleMultiplier = 2f;

	private bool hasExplosions;

	private float _defaultScale;

	private List<PhaserSprite> explosionSprites;

	private float offsetRadius;

	private List<Timer> explosionTimers;

	private int ExplosionsNumber;

	private Vector2 _SpriteOffset;

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_05a0: Expected O, but got I4
		//IL_04fb: Expected I4, but got O
		//IL_0506: Expected I4, but got O
		//IL_0112: Expected O, but got I4
		//IL_070d: Expected I4, but got O
		//IL_0718: Expected I4, but got O
		//IL_01c2: Expected I, but got O
		//IL_01d8: Expected O, but got I
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Expected O, but got Unknown
		//IL_024f: Expected I, but got O
		//IL_05d0: Expected O, but got I4
		//IL_05e7: Expected I, but got I8
		//IL_0238: Expected I, but got I8
		//IL_06c2->IL0549: Incompatible stack heights: 1 vs 0
		//IL_0721->IL0549: Incompatible stack heights: 2 vs 0
		//IL_0781->IL0549: Incompatible stack heights: 3 vs 0
		//IL_07ff->IL05c6: Incompatible stack heights: 4 vs 0
		//IL_0662->IL0549: Incompatible stack heights: 1 vs 0
		//IL_0392->IL0549: Incompatible stack heights: 1 vs 0
		//IL_03c1->IL0549: Incompatible stack heights: 1 vs 0
		//IL_03f8->IL0549: Incompatible stack heights: 1 vs 0
		//IL_0447->IL0549: Incompatible stack heights: 1 vs 0
		//IL_04e6->IL00c6: Incompatible stack heights: 1 vs 0
		//IL_04eb->IL04eb: Incompatible stack heights: 1 vs 0
		base.InitEnemy(enemyType, asRemote);
		EnemyData currentEnemyData = _currentEnemyData;
		if (_currentEnemyData != null)
		{
			float num = default(float);
			ArcadeSprite arcadeSprite = setScale(_defaultScale = (((object)currentEnemyData._003Cscale_003Ek__BackingField == null) ? 1f : num), (float?)(object)0);
			if (hasExplosions)
			{
				return;
			}
			int num2 = default(int);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("fbDeathExplo_", 1, 6, "firstBloodEnemies", num2);
			hasExplosions = true;
			List<PhaserSprite> list = new List<PhaserSprite>();
			explosionSprites = list;
			bool flag = ExplosionsNumber <= 0;
			bool flag2 = false;
			string text = "firstBloodEnemies";
			if (flag)
			{
				goto IL_04eb;
			}
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			while (true)
			{
				_003C_003Ec__DisplayClass8_0 obj = new _003C_003Ec__DisplayClass8_0();
				PhaserWorld instance = PhaserWorld.Instance;
				if ((object)instance == null)
				{
					break;
				}
				PhaserSprite exp = instance.AddPhaserSprite((Vector2)0, "firstBlood", "Crush Bomb-Explosion-F1");
				if (obj == null)
				{
					break;
				}
				obj.exp = exp;
				PhaserSprite exp2 = obj.exp;
				if ((object)obj.exp == null)
				{
					break;
				}
				Action action = null;
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ r10_v15 (Il2CppMethodInfo)+8]");
				((Delegate)action).method_ptr = (IntPtr)0;
				((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass8_0._003CInitEnemy_003Eb__0);
				((Delegate)action).m_target = obj;
				((Delegate)action).method_code = (IntPtr)action;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ r10_v15 (Il2CppMethodInfo)+4C]");
				object obj2 = (nint)0 >> 4;
				object obj3 = obj2 & 1;
				nint num4;
				if (obj3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ r10_v15 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num4 = unchecked((nint)6447293664L);
						goto IL_05c7;
					}
				}
				((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
				num4 = ((Delegate)action).method_ptr;
				goto IL_05c7;
				IL_05c7:
				object obj4 = 24;
				((Delegate)action).extra_arg = unchecked((nint)6447293568L);
				if ((object)exp2._spriteAnimation == null)
				{
					break;
				}
				exp2._spriteAnimation.AddAnimation("bang", animationFrames, 16, (byte)num2 != 0, startRandomFrame, onComplete, autoSetAnimation);
				if ((object)obj.exp == null)
				{
					break;
				}
				PhaserSprite phaserSprite = obj.exp.setVisible(visible: false);
				if ((object)obj.exp == null)
				{
					break;
				}
				Transform transform = obj.exp.transform;
				if ((object)transform == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rax_v83 (UnityEngine.Transform)+10]");
				bool flag3 = (nint)0 == 0;
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1557 @ rcx_v78 (Il2CppMethodInfo)+38]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rax_v83 (UnityEngine.Transform)+10]");
				Transform.SetParent_Injected((IntPtr)0, (IntPtr)0, true);
				if ((object)obj.exp == null)
				{
					break;
				}
				PhaserSprite phaserSprite2 = obj.exp.setDepth(3000);
				if ((object)obj.exp == null)
				{
					break;
				}
				GameObject gameObject = obj.exp.gameObject;
				if ((object)gameObject == null)
				{
					break;
				}
				((UnityEngine.Object)gameObject).SetName("FB_Death_Bang");
				List<object> list2 = (List<object>)(object)explosionSprites;
				if (explosionSprites == null)
				{
					break;
				}
				int version = list2._version + 1;
				list2._version = version;
				text = (string)(object)list2._items;
				if (list2._items == null)
				{
					break;
				}
				int num6 = list2._size;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ r9_v16 (System.String)+18]");
				if ((nint)num6 >= (nint)0)
				{
					((List<object>)(object)explosionSprites).AddWithResize((object)obj.exp);
				}
				else
				{
					int num7 = list2._size + 1;
					list2._size = num7;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
				if ((flag2 ? 1 : 0) < ExplosionsNumber)
				{
					continue;
				}
				goto IL_04eb;
			}
		}
		goto IL_0549;
		IL_0549:
		throw new NullReferenceException();
		IL_04eb:
		CheckRenderer();
		bool flag4 = (byte)(int)((ArcadeSprite)this)._spriteRenderer != 0;
		if ((int)(~((ArcadeSprite)this)._spriteRenderer) == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rbx_v16 (System.Boolean)+10]");
			bool flag5 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rbx_v16 (System.Boolean)+10]");
			IntPtr gcHandlePtr = SpriteRenderer.get_sprite_Injected((IntPtr)0);
			Sprite sprite = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Sprite>(gcHandlePtr);
			if ((object)sprite != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rax_v45 (UnityEngine.Sprite)+10]");
				bool flag6 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rax_v45 (UnityEngine.Sprite)+10]");
				Sprite.get_rect_Injected((IntPtr)0, out Rect _);
				CheckRenderer();
				bool flag7 = (byte)(int)((ArcadeSprite)this)._spriteRenderer != 0;
				if ((int)(~((ArcadeSprite)this)._spriteRenderer) == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rbx_v18 (System.Boolean)+10]");
					bool flag8 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rbx_v18 (System.Boolean)+10]");
					IntPtr gcHandlePtr2 = SpriteRenderer.get_sprite_Injected((IntPtr)0);
					Sprite sprite2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Sprite>(gcHandlePtr2);
					if ((object)sprite2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rax_v55 (UnityEngine.Sprite)+10]");
						bool flag9 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rax_v55 (UnityEngine.Sprite)+10]");
						Sprite.get_rect_Injected((IntPtr)0, out Rect _);
						object obj5 = default(object);
						object obj6 = default(object);
						bool flag10 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6);
						object obj7 = obj5;
						if (!flag10)
						{
							obj7 = obj6;
						}
						float num8 = (float)obj7 * 0.25f;
						offsetRadius = num8;
						return;
					}
				}
			}
		}
		goto IL_0549;
	}

	public override void Despawn()
	{
		List<Timer> list = explosionTimers;
		if (explosionTimers != null)
		{
			int version = list._version + 1;
			list._version = version;
			list._size = 0;
			if (list._size > 0)
			{
				Array.Clear(list._items, 0, list._size);
			}
		}
		base.Despawn();
	}

	protected override void Die()
	{
		//IL_0028: Expected O, but got I4
		PlayExplosions();
		float xScale = _defaultScale * OnDeathScaleMultiplier;
		ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)0);
		base.Die();
	}

	private unsafe void PlayExplosions()
	{
		//IL_02f5: Expected O, but got F4
		//IL_03c1: Expected O, but got F4
		//IL_0155: Expected I, but got O
		//IL_016b: Expected O, but got I
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Expected O, but got Unknown
		//IL_01e2: Expected I, but got O
		//IL_032d: Expected O, but got I4
		//IL_0344: Expected I, but got I8
		//IL_01cb: Expected I, but got I8
		List<Timer> list = explosionTimers;
		if (explosionTimers != null)
		{
			int version = list._version + 1;
			list._version = version;
			list._size = 0;
			if (list._size > 0)
			{
				Array.Clear(list._items, 0, list._size);
			}
		}
		List<Timer> list2 = new List<Timer>();
		explosionTimers = list2;
		List<PhaserSprite> list3 = explosionSprites;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		float num = default(float);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		while ((flag3 ? 1 : 0) < list3._size)
		{
			_003C_003Ec__DisplayClass11_0 obj = new _003C_003Ec__DisplayClass11_0();
			obj._003C_003E4__this = this;
			object obj2 = UnityEngine.Random.value;
			obj.rnd = num;
			float num2 = (obj.expAngle = num * 360f);
			object obj3 = UnityEngine.Random.value;
			float num3 = num2 * offsetRadius;
			obj.localIndex = (flag2 ? 1 : 0);
			float num4 = num3 + offsetRadius;
			float radius = num4 * 0.01f;
			obj.radius = radius;
			BaseBody baseBody = body;
			obj.bodyPos = baseBody._position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rax_v24 (BaseBody)+54]");
			_ = 0;
			Action action = null;
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ r10_v5 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass11_0._003CPlayExplosions_003Eb__0);
			((Delegate)action).m_target = obj;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ r10_v5 (Il2CppMethodInfo)+4C]");
			object obj4 = (nint)0 >> 4;
			object obj5 = obj4 & 1;
			nint num6;
			if (obj5 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ r10_v5 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num6 = unchecked((nint)6447293664L);
					goto IL_0324;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num6 = ((Delegate)action).method_ptr;
			goto IL_0324;
			IL_0324:
			object obj6 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			num = (float)(flag ? 1 : 0) * 0.001f;
			Timer item = Timers.Register(num, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			List<object> list4 = (List<object>)(object)explosionTimers;
			int version2 = list4._version + 1;
			list4._version = version2;
			object[] items = list4._items;
			if (list4._size >= items.Length)
			{
				list4.AddWithResize((object)item);
			}
			else
			{
				int num7 = list4._size + 1;
				list4._size = num7;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			list3 = explosionSprites;
			flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
			flag = (byte)((flag ? 1u : 0u) + 30u) != 0;
			flag3 = flag2;
		}
	}

	public Enemy_FB_DieWithExplosions()
	{
		List<PhaserSprite> list = new List<PhaserSprite>();
		explosionSprites = list;
		ExplosionsNumber = 12;
		base._002Ector();
	}
}
