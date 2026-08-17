using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class AstroidClearWeapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public int asteroidID;

		public AstroidClearWeapon _003C_003E4__this;

		internal void _003CInitWeapon_003Eb__0()
		{
			//IL_0057: Expected O, but got I
			//IL_00c0: Expected O, but got I
			AstroidClearWeapon astroidClearWeapon = _003C_003E4__this;
			int num = asteroidID;
			List<bool> asteroidActive = astroidClearWeapon._asteroidActive;
			int num2 = asteroidID;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rcx_v6 (System.Collections.Generic.List`1<System.Boolean>)+18]");
			if ((nint)num2 < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rcx_v6 (System.Collections.Generic.List`1<System.Boolean>)+10]");
				object obj = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rcx_v6 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
				_ = (nint)0 + (nint)1;
				List<bool> asteroidShootable = astroidClearWeapon._asteroidShootable;
				int num3 = asteroidID;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rcx_v7 (System.Collections.Generic.List`1<System.Boolean>)+18]");
				if ((nint)num3 < (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rcx_v7 (System.Collections.Generic.List`1<System.Boolean>)+10]");
					object obj2 = 0;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rcx_v7 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
					_ = (nint)0 + (nint)1;
					List<PhaserSprite> asteroidSprites = astroidClearWeapon._asteroidSprites;
					if (asteroidID < asteroidSprites._size)
					{
						PhaserSprite[] items = asteroidSprites._items;
						PhaserSprite phaserSprite = items[num].setVisible(visible: false);
						return;
					}
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass18_0
	{
		public int localIndex;

		public AstroidClearWeapon _003C_003E4__this;

		internal void _003CFire_003Eb__0()
		{
			//IL_0152: Expected O, but got I4
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Expected O, but got Unknown
			//IL_006f->IL011b: Incompatible stack heights: 1 vs 0
			//IL_009d->IL011b: Incompatible stack heights: 1 vs 0
			if ((object)_003C_003E4__this != null)
			{
				GameObject gameObject = _003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj == null)
					{
						return;
					}
					if ((object)_003C_003E4__this != null)
					{
						int nextAvailableAsteroid = _003C_003E4__this.getNextAvailableAsteroid();
						if ((object)_003C_003E4__this != null)
						{
							float num = _003C_003E4__this.PAmount();
							object obj2 = default(object);
							bool flag2 = (nint)obj2 < localIndex;
							object obj3 = obj2 - localIndex;
							bool flag3 = obj3 == null;
							bool flag4 = !flag2;
							bool flag5 = !flag3;
							bool shootable = flag5 & flag4;
							_003C_003E4__this.fireAsteroid(nextAvailableAsteroid, shootable);
							return;
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public AstroidClearWeapon _003C_003E4__this;

		public float2 explosionLocation;

		public PhaserSprite asteroidSprite;
	}

	private sealed class _003C_003Ec__DisplayClass26_1
	{
		public int num;

		public _003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals1;

		internal void _003CAsteroidExplode_003Eb__0()
		{
			_003C_003Ec__DisplayClass26_0 obj = CS_0024_003C_003E8__locals1;
			Transform transform = obj.asteroidSprite.transform;
			Vector2 pos = default(Vector2);
			Projectile projectile = obj._003C_003E4__this.FireOneProjectile(pos, num, transform);
		}
	}

	[NonSerialized]
	public PhaserSprite _crosshairSprite;

	private PhaserSprite _bulletSprite1;

	private PhaserSprite _bulletSprite2;

	private List<PhaserSprite> _asteroidSprites;

	private List<bool> _asteroidActive;

	private List<bool> _asteroidShootable;

	private List<Vector2> _asteroidVelocity;

	private List<float> _asteroidRotation;

	private MultiTargetTween _moveTween;

	private int _asteroidHitNum;

	[NonSerialized]
	public float CrosshairOffsetX;

	[NonSerialized]
	public float CrosshairOffsetY;

	private int _maxAsteroids;

	private MultiTargetTween explodeScaleTween;

	private float sureFire;

	private bool justFired;

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0036: Expected I4, but got O
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_0163: Expected O, but got F4
		//IL_0280: Expected O, but got F4
		//IL_0430: Expected I4, but got O
		//IL_0430: Expected O, but got I4
		//IL_0430: Expected O, but got F4
		//IL_0458: Expected I4, but got O
		//IL_0458: Expected O, but got I4
		//IL_0458: Expected O, but got F4
		//IL_0322: Expected O, but got F4
		//IL_04b2: Expected O, but got I4
		//IL_0520: Expected O, but got F4
		//IL_0614: Expected I, but got O
		//IL_062a: Expected O, but got I
		//IL_0633: Unknown result type (might be due to invalid IL or missing references)
		//IL_0638: Expected O, but got Unknown
		//IL_06a1: Expected I, but got O
		//IL_0acd: Expected O, but got I4
		//IL_0ae4: Expected I, but got I8
		//IL_068a: Expected I, but got I8
		//IL_073b: Expected O, but got I4
		//IL_0776: Expected O, but got I
		//IL_07d0: Expected O, but got I
		//IL_0808: Expected O, but got I
		//IL_0862: Expected O, but got I
		//IL_093f: Expected F4, but got I
		//IL_09af: Expected O, but got I
		//IL_098d: Expected O, but got F4
		//IL_0b64: Expected I4, but got I8
		//IL_0b68: Expected F4, but got I4
		//IL_09e8: Expected O, but got I
		//IL_0a41: Expected O, but got I
		//IL_0b35: Expected O, but got I4
		base.InitWeapon(characterController, weaponType);
		WeaponData currentWeaponData = _currentWeaponData;
		bool flag = (object)currentWeaponData._003CpoolLimit_003Ek__BackingField == null;
		int maxAsteroids = (object?)currentWeaponData._003CpoolLimit_003Ek__BackingField >> 32;
		_maxAsteroids = maxAsteroids;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float height = renderer.height;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj = height ^ 0;
		PhaserSprite crosshairSprite = _crosshairSprite;
		float crosshairOffsetY = (float)obj * 0.75f;
		CrosshairOffsetY = crosshairOffsetY;
		int num;
		int num2 = default(int);
		float num3 = default(float);
		bool flag2 = default(bool);
		Action action = default(Action);
		bool autoSetAnimation = default(bool);
		if ((object)_crosshairSprite != null && ((UnityEngine.Object)crosshairSprite).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite = _crosshairSprite.setVisible(visible: true);
			num = 0;
		}
		else
		{
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("C1_Crosshair", 0, 0, "vfx", num2);
			List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("C1_Crosshair", 0, 7, "vfx", num2);
			PhaserWorld instance = PhaserWorld.Instance;
			PhaserSprite component = instance.AddPhaserSprite((Vector2)num3, "vfx", "C1_Crosshair");
			PhaserSprite phaserSprite2 = RenderingExtensions.SetScrollFactor(component, 0f);
			PhaserSprite phaserSprite3 = phaserSprite2.setDepth(31757);
			PhaserSprite phaserSprite4 = phaserSprite3.setAlpha(0.75f);
			GameObject gameObject = phaserSprite4.gameObject;
			((UnityEngine.Object)gameObject).SetName("_crosshairSprite");
			_crosshairSprite = phaserSprite4;
			PhaserSprite crosshairSprite2 = _crosshairSprite;
			crosshairSprite2._spriteAnimation.AddAnimation("idle", animationFrames, 0, (byte)num2 != 0, flag2, action, autoSetAnimation);
			PhaserSprite crosshairSprite3 = _crosshairSprite;
			crosshairSprite3._spriteAnimation.AddAnimation("shot", animationFrames2, 22, (byte)num2 != 0, flag2, action, autoSetAnimation);
			PhaserWorld instance2 = PhaserWorld.Instance;
			PhaserSprite component2 = instance2.AddPhaserSprite((Vector2)num3, "vfx", "C1_Laser");
			PhaserSprite phaserSprite5 = RenderingExtensions.SetScrollFactor(component2, 0f);
			PhaserSprite phaserSprite6 = phaserSprite5.setDepth(31758);
			PhaserSprite phaserSprite7 = phaserSprite6.setAlpha(0f);
			GameObject gameObject2 = phaserSprite7.gameObject;
			((UnityEngine.Object)gameObject2).SetName("_bulletSprite1");
			_bulletSprite1 = phaserSprite7;
			PhaserWorld instance3 = PhaserWorld.Instance;
			PhaserSprite component3 = instance3.AddPhaserSprite((Vector2)num3, "vfx", "C1_Laser");
			PhaserSprite phaserSprite8 = RenderingExtensions.SetScrollFactor(component3, 0f);
			PhaserSprite phaserSprite9 = phaserSprite8.setDepth(31758);
			PhaserSprite phaserSprite10 = phaserSprite9.setAlpha(0f);
			GameObject gameObject3 = phaserSprite10.gameObject;
			((UnityEngine.Object)gameObject3).SetName("_bulletSprite2");
			_bulletSprite2 = phaserSprite10;
			num = 0;
		}
		List<bool> asteroidActive = new List<bool>();
		_asteroidActive = asteroidActive;
		List<bool> asteroidShootable = new List<bool>();
		_asteroidShootable = asteroidShootable;
		List<Vector2> asteroidVelocity = new List<Vector2>();
		_asteroidVelocity = asteroidVelocity;
		List<float> asteroidRotation = new List<float>();
		_asteroidRotation = asteroidRotation;
		List<Sprite> animationFrames3 = SpriteManager.GetAnimationFrames("rockBreak_", 0, 22, (Vector2)num3, (string)num2, flag2 ? 1 : 0, (byte)(int)action != 0);
		List<Sprite> animationFrames4 = SpriteManager.GetAnimationFrames("rock", 0, 47, (Vector2)num3, (string)num2, flag2 ? 1 : 0, (byte)(int)action != 0);
		if (_asteroidSprites == null)
		{
			List<PhaserSprite> asteroidSprites = new List<PhaserSprite>();
			_asteroidSprites = asteroidSprites;
			object obj2 = _maxAsteroids + _maxAsteroids;
			if ((nint)obj2 > 0)
			{
				int num4 = num;
				object obj13;
				do
				{
					_003C_003Ec__DisplayClass16_0 target = new _003C_003Ec__DisplayClass16_0
					{
						_003C_003E4__this = this,
						asteroidID = num4
					};
					PhaserWorld instance4 = PhaserWorld.Instance;
					PhaserSprite component4 = instance4.AddPhaserSprite((Vector2)num3, "vfx", "rock0000");
					PhaserSprite phaserSprite11 = RenderingExtensions.SetScrollFactor(component4, 0f);
					PhaserSprite phaserSprite12 = phaserSprite11.setDepth(31756);
					PhaserSprite phaserSprite13 = phaserSprite12.setTint(5592405u);
					PhaserSprite phaserSprite14 = phaserSprite13.setVisible(visible: false);
					PhaserSprite phaserSprite15 = phaserSprite14.setAlpha(0.65f);
					GameObject gameObject4 = phaserSprite15.gameObject;
					((UnityEngine.Object)gameObject4).SetName("_asteroidSprite");
					Action action2 = null;
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ r10_v7 (Il2CppMethodInfo)+8]");
					((Delegate)action2).method_ptr = (IntPtr)0;
					((Delegate)action2).method = (nint)__ldftn(_003C_003Ec__DisplayClass16_0._003CInitWeapon_003Eb__0);
					((Delegate)action2).m_target = target;
					((Delegate)action2).method_code = (IntPtr)action2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ r10_v7 (Il2CppMethodInfo)+4C]");
					object obj3 = (nint)0 >> 4;
					object obj4 = obj3 & 1;
					nint num6;
					if (obj4 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ r10_v7 (Il2CppMethodInfo)+52]");
						if ((nint)0 == 0)
						{
							num6 = unchecked((nint)6447293664L);
							goto IL_0ac4;
						}
					}
					((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
					num6 = ((Delegate)action2).method_ptr;
					goto IL_0ac4;
					IL_0ac4:
					object obj5 = 24;
					((Delegate)action2).extra_arg = unchecked((nint)6447293568L);
					phaserSprite15._spriteAnimation.AddAnimation("explode", animationFrames3, 30, (byte)num2 != 0, flag2, action, autoSetAnimation);
					phaserSprite15._spriteAnimation.AddAnimation("idle", animationFrames4, 30, (byte)num2 != 0, flag2, action, autoSetAnimation);
					phaserSprite15._spriteAnimation.SetAnimation("idle");
					PhaserSprite phaserSprite16 = phaserSprite15.setOrigin(0.5f, (float?)(object)1);
					List<bool> asteroidActive2 = _asteroidActive;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rcx_v62 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rcx_v62 (System.Collections.Generic.List`1<System.Boolean>)+10]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rcx_v62 (System.Collections.Generic.List`1<System.Boolean>)+18]");
					nint num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ r8_v30+18]");
					if (num7 >= 0)
					{
						asteroidActive2.AddWithResize(false);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rcx_v62 (System.Collections.Generic.List`1<System.Boolean>)+18]");
						object obj7 = (nint)0 + (nint)1;
						_ = 0;
					}
					List<bool> asteroidShootable2 = _asteroidShootable;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rcx_v63 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rcx_v63 (System.Collections.Generic.List`1<System.Boolean>)+10]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rcx_v63 (System.Collections.Generic.List`1<System.Boolean>)+18]");
					nint num8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ r8_v32+18]");
					if (num8 >= 0)
					{
						asteroidShootable2.AddWithResize(false);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rcx_v63 (System.Collections.Generic.List`1<System.Boolean>)+18]");
						object obj9 = (nint)0 + (nint)1;
						_ = 0;
					}
					List<object> asteroidSprites2 = (List<object>)(object)_asteroidSprites;
					int version = asteroidSprites2._version + 1;
					asteroidSprites2._version = version;
					object[] items = asteroidSprites2._items;
					if (asteroidSprites2._size >= items.Length)
					{
						asteroidSprites2.AddWithResize((object)phaserSprite15);
					}
					else
					{
						int size = asteroidSprites2._size + 1;
						asteroidSprites2._size = size;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					List<Vector2> asteroidVelocity2 = _asteroidVelocity;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rcx_v66 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rcx_v66 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
					float num9 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rcx_v66 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					nint num10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rcx_v66 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					nint num11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rdx_v40 (System.Single)+18]");
					if (num11 >= 0)
					{
						asteroidVelocity2.AddWithResize((Vector2)num3);
						num10 = 0;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rcx_v66 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
						object obj10 = (nint)0 + (nint)1;
						_ = 0;
					}
					List<float> asteroidRotation2 = _asteroidRotation;
					float item = UnityEngine.Random.RandomRangeInt(-100, 100);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rbx_v17 (System.Collections.Generic.List`1<System.Single>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rbx_v17 (System.Collections.Generic.List`1<System.Single>)+10]");
					object obj11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rbx_v17 (System.Collections.Generic.List`1<System.Single>)+18]");
					nint num12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rdx_v43+18]");
					if (num12 >= 0)
					{
						asteroidRotation2.AddWithResize(item);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rbx_v17 (System.Collections.Generic.List`1<System.Single>)+18]");
						object obj12 = (nint)0 + (nint)1;
					}
					num4++;
					obj13 = _maxAsteroids + _maxAsteroids;
				}
				while (num4 < (nint)obj13);
			}
		}
		moveTarget();
	}

	public override void Cleanup()
	{
		base.Cleanup();
		if (_moveTween != null)
		{
			_moveTween.Kill();
		}
		PhaserSprite crosshairSprite = _crosshairSprite;
		if ((object)_crosshairSprite != null && ((UnityEngine.Object)crosshairSprite).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite = _crosshairSprite.setVisible(visible: false);
		}
		List<PhaserSprite>.Enumerator enumerator = default(List<PhaserSprite>.Enumerator);
		if (!enumerator.MoveNext())
		{
			return;
		}
		throw new NullReferenceException();
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		//IL_01d6: Invalid comparison between O and F4
		//IL_0201: Expected F4, but got I4
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		//IL_0189: Invalid comparison between F4 and I4
		float num = base.PAmount();
		float num2 = default(float);
		sureFire = num2;
		justFired = true;
		int nextAvailableAsteroid = getNextAvailableAsteroid();
		fireAsteroid(nextAvailableAsteroid, shootable: true);
		float num3 = base.PAmount();
		float num4 = num2 + num2;
		int num5 = default(int);
		if (num4 > 1f)
		{
			num5 = 1;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			do
			{
				WeaponData currentWeaponData = _currentWeaponData;
				object obj = num5 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
				if ((nint)obj <= 0)
				{
					int nextAvailableAsteroid2 = getNextAvailableAsteroid();
					float num6 = base.PAmount();
					bool flag = (nint)obj < num5;
					object obj2 = obj - num5;
					bool flag2 = obj2 == null;
					bool flag3 = !flag;
					bool flag4 = !flag2;
					bool shootable = flag4 & flag3;
					fireAsteroid(nextAvailableAsteroid2, shootable);
				}
				else
				{
					_003C_003Ec__DisplayClass18_0 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass18_0();
					CS_0024_003C_003E8__locals11._003C_003E4__this = this;
					CS_0024_003C_003E8__locals11.localIndex = num5;
					WeaponData currentWeaponData2 = _currentWeaponData;
					Action onComplete = delegate
					{
						//IL_0152: Expected O, but got I4
						//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
						//IL_00d0: Expected O, but got Unknown
						//IL_006f->IL011b: Incompatible stack heights: 1 vs 0
						//IL_009d->IL011b: Incompatible stack heights: 1 vs 0
						if ((object)CS_0024_003C_003E8__locals11._003C_003E4__this != null)
						{
							GameObject gameObject = CS_0024_003C_003E8__locals11._003C_003E4__this.gameObject;
							if ((object)gameObject != null)
							{
								bool flag5 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
								object obj4 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
								if (obj4 == null)
								{
									return;
								}
								if ((object)CS_0024_003C_003E8__locals11._003C_003E4__this != null)
								{
									int nextAvailableAsteroid3 = CS_0024_003C_003E8__locals11._003C_003E4__this.getNextAvailableAsteroid();
									if ((object)CS_0024_003C_003E8__locals11._003C_003E4__this != null)
									{
										float num11 = CS_0024_003C_003E8__locals11._003C_003E4__this.PAmount();
										object obj5 = default(object);
										bool flag6 = (nint)obj5 < CS_0024_003C_003E8__locals11.localIndex;
										object obj6 = obj5 - CS_0024_003C_003E8__locals11.localIndex;
										bool flag7 = obj6 == null;
										bool flag8 = !flag6;
										bool flag9 = !flag7;
										bool shootable2 = flag9 & flag8;
										CS_0024_003C_003E8__locals11._003C_003E4__this.fireAsteroid(nextAvailableAsteroid3, shootable2);
										return;
									}
								}
							}
						}
						throw new NullReferenceException();
					};
					float num7 = (float)num5 * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
					float duration = num7 * 0.001f;
					Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_lastShotTimer = lastShotTimer;
				}
				num5++;
			}
			while (num4 > (float)num5);
		}
		float num8 = base.PInterval();
		float num9 = _lastFiringInterval - (float)num5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj3 = num9 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num10 = base.PInterval();
			_lastFiringInterval = num5;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	private void fireAsteroid(int asteroidInt, bool shootable)
	{
		//IL_007b: Expected O, but got I
		//IL_013f: Expected O, but got I4
		//IL_018e: Expected O, but got I
		//IL_01f2: Expected O, but got I
		if (asteroidInt == -1)
		{
			return;
		}
		Vector2 borderPosition = getBorderPosition();
		Vector2 randomCentralPoint = getRandomCentralPoint();
		object obj2 = default(object);
		object obj3 = default(object);
		object obj = obj2 - obj3;
		List<Vector2> asteroidVelocity = _asteroidVelocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rdi_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		if ((nint)asteroidInt < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rdi_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rdi_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
			_ = (nint)0 + (nint)1;
			List<PhaserSprite> asteroidSprites = _asteroidSprites;
			if (asteroidInt < asteroidSprites._size)
			{
				PhaserSprite[] items = asteroidSprites._items;
				PhaserSprite phaserSprite = items[asteroidInt];
				phaserSprite._spriteAnimation.SetAnimation("idle");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
				PhaserSprite phaserSprite2 = phaserSprite.setVisible(visible: true);
				PhaserSprite phaserSprite3 = phaserSprite.setScale(1f, (float?)(object)0);
				List<bool> asteroidActive = _asteroidActive;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rcx_v17 (System.Collections.Generic.List`1<System.Boolean>)+18]");
				if ((nint)asteroidInt < (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rcx_v17 (System.Collections.Generic.List`1<System.Boolean>)+10]");
					object obj5 = 0;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rcx_v17 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
					_ = (nint)0 + (nint)1;
					List<bool> asteroidShootable = _asteroidShootable;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rcx_v18 (System.Collections.Generic.List`1<System.Boolean>)+18]");
					if ((nint)asteroidInt < (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rcx_v18 (System.Collections.Generic.List`1<System.Boolean>)+10]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rcx_v18 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
						_ = (nint)0 + (nint)1;
						return;
					}
				}
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private Vector2 getBorderPosition()
	{
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null && s_scene._renderer != null && (object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null)
				{
					PhaserScene.Renderer renderer = s_scene2._renderer;
					if (s_scene2._renderer != null)
					{
						float num = renderer.height * 0.6f;
						Camera main = Camera.main;
						if ((object)main != null)
						{
							Transform transform = main.transform;
							if ((object)transform != null)
							{
								bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
								object obj = default(object);
								float maxInclusive = (float)obj + num;
								float minInclusive = (float)obj - num;
								float num2 = UnityEngine.Random.Range(minInclusive, maxInclusive);
								Vector2 result = default(Vector2);
								return result;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private Vector2 getRandomCentralPoint()
	{
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null)
				{
					float num = renderer.width * 0.3f;
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene2 = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null)
						{
							PhaserScene.Renderer renderer2 = s_scene2._renderer;
							if (s_scene2._renderer != null)
							{
								float num2 = renderer2.height * 0.3f;
								Camera main = Camera.main;
								if ((object)main != null)
								{
									Transform transform = main.transform;
									if ((object)transform != null)
									{
										bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
										Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
										float minInclusive = (float)ret - num;
										float maxInclusive = (float)ret + num;
										float num3 = UnityEngine.Random.Range(minInclusive, maxInclusive);
										object obj = default(object);
										float minInclusive2 = (float)obj - num2;
										float maxInclusive2 = (float)obj + num2;
										float num4 = UnityEngine.Random.Range(minInclusive2, maxInclusive2);
										Vector2 result = default(Vector2);
										return result;
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

	private int getNextAvailableAsteroid()
	{
		//IL_00b6: Expected I4, but got I8
		//IL_0062: Expected O, but got I
		List<PhaserSprite> asteroidSprites = _asteroidSprites;
		int num = 0;
		int num2 = 0;
		while (true)
		{
			if (num2 < asteroidSprites._size)
			{
				List<bool> asteroidActive = _asteroidActive;
				int num3 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v11 (System.Collections.Generic.List`1<System.Boolean>)+18]");
				if ((nint)num3 >= (nint)0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v11 (System.Collections.Generic.List`1<System.Boolean>)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rdx_v5 (System.Int32)+20+v54 @ rcx_v7]");
				if ((nint)0 != 0)
				{
					num++;
					num2 = num;
					continue;
				}
				return num;
			}
			return -1;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		int result = default(int);
		return result;
	}

	private int findClosestCentralAsteroid()
	{
		//IL_0124: Expected I4, but got I8
		//IL_05de: Expected I4, but got I8
		//IL_019e: Expected O, but got I
		//IL_06eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f0: Expected O, but got Unknown
		//IL_024c: Invalid comparison between F4 and I4
		//IL_02d5: Invalid comparison between O and F4
		//IL_02e6: Expected F4, but got O
		//IL_0366: Invalid comparison between F4 and O
		//IL_0576: Expected I4, but got O
		//IL_070a->IL0633: Incompatible stack heights: 1 vs 0
		//IL_0225->IL0633: Incompatible stack heights: 1 vs 0
		//IL_05b0->IL070f: Incompatible stack heights: 1 vs 0
		//IL_0285->IL0633: Incompatible stack heights: 1 vs 0
		//IL_02ac->IL0633: Incompatible stack heights: 1 vs 0
		//IL_0316->IL0633: Incompatible stack heights: 1 vs 0
		//IL_033d->IL0633: Incompatible stack heights: 1 vs 0
		//IL_039f->IL0633: Incompatible stack heights: 1 vs 0
		//IL_03c6->IL0633: Incompatible stack heights: 1 vs 0
		//IL_0430->IL0633: Incompatible stack heights: 1 vs 0
		//IL_0457->IL0633: Incompatible stack heights: 1 vs 0
		//IL_04b9->IL0633: Incompatible stack heights: 1 vs 0
		//IL_04e7->IL0633: Incompatible stack heights: 1 vs 0
		//IL_050e->IL0633: Incompatible stack heights: 1 vs 0
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null)
				{
					float num = renderer.width * 0.4f;
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene2 = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null)
						{
							PhaserScene.Renderer renderer2 = s_scene2._renderer;
							if (s_scene2._renderer != null)
							{
								float num2 = renderer2.height * 0.4f;
								Camera main = Camera.main;
								if ((object)main != null)
								{
									Transform transform = main.transform;
									bool flag = (object)transform == null;
									Transform transform2 = transform;
									if (!flag)
									{
										bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
										object obj = transform;
										if (flag2)
										{
											UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(obj);
											Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 328 ConditionalJump @-1, v226 @ TEMP_v15 (System.Boolean) --- -1 Nop");
											/*Error: End of method reached without returning.*/;
										}
										Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
										List<PhaserSprite> asteroidSprites = _asteroidSprites;
										bool flag3 = _asteroidSprites == null;
										transform2 = null;
										if (!flag3)
										{
											int num3 = -1;
											float num4 = 3.4028235E+38f;
											transform2 = null;
											Transform transform3 = null;
											float num5 = default(float);
											float2 float6 = default(float2);
											PhaserSprite phaserSprite = default(PhaserSprite);
											PhaserSprite phaserSprite2 = default(PhaserSprite);
											PhaserSprite phaserSprite3 = default(PhaserSprite);
											object obj5 = default(object);
											float num7 = default(float);
											PhaserSprite phaserSprite4 = default(PhaserSprite);
											PhaserSprite phaserSprite5 = default(PhaserSprite);
											float num9 = default(float);
											while (true)
											{
												if ((nint)transform3 < asteroidSprites._size)
												{
													List<bool> asteroidShootable = _asteroidShootable;
													if (_asteroidShootable == null)
													{
														break;
													}
													Transform obj2 = transform2;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rax_v29 (System.Collections.Generic.List`1<System.Boolean>)+18]");
													if ((nint)obj2 < 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rax_v29 (System.Collections.Generic.List`1<System.Boolean>)+10]");
														object obj3 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rax_v29 (System.Collections.Generic.List`1<System.Boolean>)+10]");
														if ((nint)0 == 0)
														{
															break;
														}
														Transform obj4 = transform2;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rcx_v21+18]");
														bool flag4 = (nint)obj4 >= 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rbx_v4 (UnityEngine.Transform)+20+v212 @ rcx_v21]");
														if ((nint)0 != 0)
														{
															if (_asteroidVelocity == null)
															{
																break;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
															bool flag5 = !(num5 > 0f);
															float2 float5 = float6;
															if (!flag5)
															{
																if (_asteroidSprites == null)
																{
																	break;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
																if ((object)phaserSprite == null)
																{
																	break;
																}
																float2 position = phaserSprite.position;
																float num6 = (float)ret - num;
																bool flag6 = System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6);
																num5 = (float)position;
																float5 = position;
																if (!flag6)
																{
																	if (_asteroidSprites == null)
																	{
																		break;
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
																	if ((object)phaserSprite2 == null)
																	{
																		break;
																	}
																	float2 position2 = phaserSprite2.position;
																	num5 = (float)ret + num;
																	bool flag7 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num5) <= System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position2);
																	float5 = position2;
																	if (!flag7)
																	{
																		if (_asteroidSprites == null)
																		{
																			break;
																		}
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
																		if ((object)phaserSprite3 == null)
																		{
																			break;
																		}
																		float2 position3 = phaserSprite3.position;
																		num6 = (float)obj5 - num2;
																		bool flag8 = !(num7 > num6);
																		num5 = num7;
																		float5 = position3;
																		if (!flag8)
																		{
																			if (_asteroidSprites == null)
																			{
																				break;
																			}
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
																			if ((object)phaserSprite4 == null)
																			{
																				break;
																			}
																			float2 position4 = phaserSprite4.position;
																			num5 = (float)obj5 + num2;
																			bool flag9 = !(num5 > num7);
																			float5 = position4;
																			if (!flag9)
																			{
																				if ((object)_crosshairSprite == null)
																				{
																					break;
																				}
																				float2 position5 = _crosshairSprite.position;
																				if (_asteroidSprites == null)
																				{
																					break;
																				}
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
																				if ((object)phaserSprite5 == null)
																				{
																					break;
																				}
																				float2 position6 = phaserSprite5.position;
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
																				bool flag10 = !(num4 > num7);
																				float num8 = num9;
																				num5 = num7;
																				num6 = num9;
																				float5 = position6;
																				if (!flag10)
																				{
																					num3 = (int)transform2;
																					num4 = num7;
																					num8 = num9;
																					num5 = num7;
																					num6 = num9;
																					float5 = position6;
																				}
																			}
																		}
																	}
																}
															}
														}
														asteroidSprites = _asteroidSprites;
														transform2 = (Transform)(transform2 + 1);
														if (_asteroidSprites == null)
														{
															break;
														}
														transform3 = transform2;
														continue;
													}
													System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
													break;
												}
												if (num3 <= 4294967295L)
												{
													num3 = -1;
												}
												return num3;
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

	private unsafe void moveTarget()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0779: Expected O, but got Ref
		//IL_07e9: Expected O, but got Ref
		//IL_081a: Invalid comparison between I4 and F4
		//IL_0875: Expected O, but got F4
		//IL_087f: Invalid comparison between I4 and F4
		//IL_008b: Expected I4, but got I8
		//IL_03fe: Expected O, but got I
		//IL_0147: Expected O, but got F4
		//IL_0abf: Expected O, but got Ref
		//IL_0b2f: Expected O, but got Ref
		//IL_0b5e: Expected O, but got I
		//IL_0b7b: Expected O, but got I
		//IL_0234: Expected O, but got F4
		//IL_0591: Expected O, but got Ref
		//IL_05e6: Expected O, but got Ref
		//IL_096a: Expected O, but got Ref
		//IL_0684: Expected I, but got O
		//IL_09da: Expected O, but got Ref
		//IL_0a09: Expected O, but got I
		//IL_07ac->IL071b: Incompatible stack heights: 1 vs 0
		//IL_0068->IL071b: Incompatible stack heights: 1 vs 0
		//IL_0321->IL071b: Incompatible stack heights: 2 vs 0
		//IL_00a9->IL071b: Incompatible stack heights: 2 vs 0
		//IL_0372->IL071b: Incompatible stack heights: 3 vs 0
		//IL_08b8->IL071b: Incompatible stack heights: 2 vs 0
		//IL_03c4->IL071b: Incompatible stack heights: 4 vs 0
		//IL_00dd->IL071b: Incompatible stack heights: 2 vs 0
		//IL_00fb->IL071b: Incompatible stack heights: 2 vs 0
		//IL_041e->IL071b: Incompatible stack heights: 5 vs 0
		//IL_08df->IL071b: Incompatible stack heights: 2 vs 0
		//IL_0469->IL071b: Incompatible stack heights: 6 vs 0
		//IL_012f->IL071b: Incompatible stack heights: 2 vs 0
		//IL_049c->IL071b: Incompatible stack heights: 6 vs 0
		//IL_0196->IL071b: Incompatible stack heights: 2 vs 0
		//IL_0906->IL071b: Incompatible stack heights: 2 vs 0
		//IL_0af2->IL071b: Incompatible stack heights: 7 vs 0
		//IL_01ca->IL071b: Incompatible stack heights: 2 vs 0
		//IL_04d0->IL071b: Incompatible stack heights: 7 vs 0
		//IL_01e8->IL071b: Incompatible stack heights: 2 vs 0
		//IL_092d->IL071b: Incompatible stack heights: 2 vs 0
		//IL_021c->IL071b: Incompatible stack heights: 2 vs 0
		//IL_0284->IL071b: Incompatible stack heights: 2 vs 0
		//IL_02b0->IL071b: Incompatible stack heights: 2 vs 0
		//IL_05b8->IL071b: Incompatible stack heights: 8 vs 0
		//IL_062d->IL071b: Incompatible stack heights: 8 vs 0
		//IL_099d->IL071b: Incompatible stack heights: 3 vs 0
		//IL_02e4->IL071b: Incompatible stack heights: 3 vs 0
		//IL_0677->IL071b: Incompatible stack heights: 8 vs 0
		//IL_0a68->IL0a68: Incompatible stack heights: 4 vs 8
		object obj2 = default(object);
		object obj = (object)(&obj2);
		float duration;
		if ((object)_crosshairSprite != null)
		{
			Transform transform = _crosshairSprite.transform;
			if ((object)transform != null)
			{
				_ = 0;
				_ = 0;
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj3);
				Camera main = Camera.main;
				if ((object)main != null)
				{
					Transform transform2 = main.transform;
					if ((object)transform2 != null)
					{
						_ = 0;
						_ = 0;
						bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
						Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)obj4);
						int asteroidHitNum = findClosestCentralAsteroid();
						_asteroidHitNum = asteroidHitNum;
						if (!(0f < sureFire))
						{
							object obj5 = UnityEngine.Random.value;
							if (0f > 0.5f)
							{
								_asteroidHitNum = -1;
							}
						}
						float num = sureFire - 1f;
						sureFire = num;
						float num6 = default(float);
						if (_asteroidHitNum == -1)
						{
							if ((object)GM.Core != null)
							{
								PhaserScene s_scene = ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene != null)
								{
									PhaserScene.Renderer renderer = s_scene._renderer;
									if (s_scene._renderer != null && (object)GM.Core != null)
									{
										PhaserScene s_scene2 = ArcadePhysics.s_scene;
										if (ArcadePhysics.s_scene != null)
										{
											PhaserScene.Renderer renderer2 = s_scene2._renderer;
											if (s_scene2._renderer != null)
											{
												object obj6 = renderer.width ^ -0f;
												float minInclusive = (float)obj6 * 0.4f;
												float maxInclusive = renderer2.width * 0.4f;
												float num2 = UnityEngine.Random.Range(minInclusive, maxInclusive);
												if ((object)GM.Core != null)
												{
													PhaserScene s_scene3 = ArcadePhysics.s_scene;
													if (ArcadePhysics.s_scene != null)
													{
														PhaserScene.Renderer renderer3 = s_scene3._renderer;
														if (s_scene3._renderer != null && (object)GM.Core != null)
														{
															PhaserScene s_scene4 = ArcadePhysics.s_scene;
															if (ArcadePhysics.s_scene != null)
															{
																PhaserScene.Renderer renderer4 = s_scene4._renderer;
																if (s_scene4._renderer != null)
																{
																	object obj7 = renderer3.height ^ -0f;
																	float minInclusive2 = (float)obj7 * 0.4f;
																	float maxInclusive2 = renderer4.height * 0.4f;
																	float num3 = UnityEngine.Random.Range(minInclusive2, maxInclusive2);
																	if ((object)_crosshairSprite != null)
																	{
																		Transform transform3 = _crosshairSprite.transform;
																		if ((object)transform3 != null)
																		{
																			_ = 0;
																			_ = 0;
																			bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
																			object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
																			Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out *(Vector3*)obj8);
																			Camera main2 = Camera.main;
																			if ((object)main2 != null)
																			{
																				Transform transform4 = main2.transform;
																				if ((object)transform4 != null)
																				{
																					_ = 0;
																					_ = 0;
																					bool flag4 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
																					object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
																					Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out *(Vector3*)obj9);
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-25]");
																					nint num4 = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-35]");
																					object obj10 = num4 - 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
																					float num5 = num6 / 0.01f;
																					float num7 = base.PSpeed();
																					float num8 = num5 / num6;
																					duration = num8 + num8;
																					float num9 = num2;
																					float num10 = num3;
																					float num11 = num6;
																					goto IL_0a68;
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
						else
						{
							List<PhaserSprite> asteroidSprites = _asteroidSprites;
							int asteroidHitNum2 = _asteroidHitNum;
							if (_asteroidSprites != null)
							{
								bool flag5 = _asteroidHitNum >= asteroidSprites._size;
								PhaserSprite[] items = asteroidSprites._items;
								if (asteroidSprites._items != null)
								{
									bool flag6 = _asteroidHitNum >= items.Length;
									List<Vector2> asteroidVelocity = _asteroidVelocity;
									int asteroidHitNum3 = _asteroidHitNum;
									if (_asteroidVelocity != null)
									{
										int asteroidHitNum4 = _asteroidHitNum;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rdx_v68 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
										bool flag7 = (nint)asteroidHitNum4 >= (nint)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rdx_v68 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
										object obj11 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rdx_v68 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
										if ((nint)0 != 0)
										{
											int asteroidHitNum5 = _asteroidHitNum;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdx_v69+18]");
											bool flag8 = (nint)asteroidHitNum5 >= (nint)0;
											if ((object)items[asteroidHitNum2] != null)
											{
												Transform transform5 = items[asteroidHitNum2].transform;
												if ((object)transform5 != null)
												{
													_ = 0;
													_ = 0;
													bool flag9 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
													object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
													Transform.get_position_Injected(((UnityEngine.Object)transform5).m_CachedPtr, out *(Vector3*)obj12);
													Camera main3 = Camera.main;
													if ((object)main3 != null)
													{
														Transform transform6 = main3.transform;
														if ((object)transform6 != null)
														{
															_ = 0;
															_ = 0;
															bool flag10 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
															object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
															Transform.get_position_Injected(((UnityEngine.Object)transform6).m_CachedPtr, out *(Vector3*)obj13);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
															nint num12 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
															object obj14 = num12 - 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-25]");
															nint num13 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-35]");
															object obj15 = num13 - 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
															float deltaTime = PauseSystem.DeltaTime;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdx_v69+20+v196 @ rax_v99 (System.Int32)*8]");
															float num14 = 0f * deltaTime;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdx_v69+24+v196 @ rax_v99 (System.Int32)*8]");
															float num15 = 0f * deltaTime;
															float num16 = num6 * 10f;
															float num17 = num16 * num15;
															float num18 = num16 * num14;
															float num9 = (float)obj14 + num18;
															float num10 = (float)obj15 + num17;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
															if (!justFired)
															{
																duration = 16f;
																float num11 = num6;
															}
															else
															{
																float num19 = num6 / 0.01f;
																float num20 = base.PSpeed();
																float num11 = num6 * 0.5f;
																duration = num19 / num11;
															}
															justFired = false;
															goto IL_0a68;
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
		goto IL_071b;
		IL_071b:
		throw new NullReferenceException();
		IL_0a68:
		if (_moveTween != null)
		{
			_moveTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		if (dictionary != null)
		{
			object value = default(object);
			bool flag11 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"CrosshairOffsetX", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value2 = default(object);
			bool flag12 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"CrosshairOffsetY", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			if (tweenConfig != null)
			{
				tweenConfig.custom = dictionary;
				tweenConfig.duration = duration;
				object[] array = new object[1];
				if (array != null)
				{
					nint num21 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj18 = default(object);
					bool flag13 = obj18 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					tweenConfig.targets = array;
					tweenConfig.ease = Ease.Linear;
					TweenCallback onComplete = delegate
					{
						checkAsteroidCollision();
					};
					tweenConfig.onComplete = onComplete;
					MultiTargetTween moveTween = Tweens.Add(tweenConfig);
					_moveTween = moveTween;
					return;
				}
			}
		}
		goto IL_071b;
	}

	private unsafe void checkAsteroidCollision()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00be: Expected F4, but got I
		//IL_099b: Expected O, but got Ref
		//IL_0a11: Expected O, but got Ref
		//IL_0a80: Expected O, but got Ref
		//IL_0af3: Expected O, but got Ref
		//IL_04eb: Expected O, but got I
		//IL_050d: Expected O, but got I
		//IL_0539: Expected O, but got I
		//IL_0556: Expected O, but got I
		//IL_05a3: Expected O, but got F4
		//IL_0601: Expected O, but got Ref
		//IL_0631: Expected O, but got F4
		//IL_068f: Expected O, but got Ref
		//IL_0707: Expected I, but got O
		//IL_075b: Expected I, but got O
		//IL_0818: Expected O, but got I
		//IL_087f: Expected O, but got I
		//IL_08ae: Expected O, but got I
		//IL_09d1->IL08e9: Incompatible stack heights: 1 vs 0
		//IL_020f->IL08e9: Incompatible stack heights: 1 vs 0
		//IL_0a40->IL08e9: Incompatible stack heights: 2 vs 0
		//IL_0289->IL08e9: Incompatible stack heights: 2 vs 0
		//IL_02b3->IL08e9: Incompatible stack heights: 2 vs 0
		//IL_0ab6->IL08e9: Incompatible stack heights: 3 vs 0
		//IL_02e7->IL08e9: Incompatible stack heights: 3 vs 0
		//IL_0b1f->IL08e9: Incompatible stack heights: 4 vs 0
		//IL_0355->IL08e9: Incompatible stack heights: 4 vs 0
		//IL_0388->IL08e9: Incompatible stack heights: 4 vs 0
		//IL_03bb->IL08e9: Incompatible stack heights: 4 vs 0
		//IL_03ee->IL08e9: Incompatible stack heights: 4 vs 0
		//IL_0421->IL08e9: Incompatible stack heights: 4 vs 0
		//IL_0454->IL08e9: Incompatible stack heights: 4 vs 0
		//IL_0487->IL08e9: Incompatible stack heights: 4 vs 0
		//IL_04ba->IL08e9: Incompatible stack heights: 4 vs 0
		//IL_05bd->IL08e9: Incompatible stack heights: 4 vs 0
		//IL_05e9->IL08e9: Incompatible stack heights: 4 vs 0
		//IL_064b->IL08e9: Incompatible stack heights: 4 vs 0
		//IL_0677->IL08e9: Incompatible stack heights: 4 vs 0
		//IL_06db->IL08e9: Incompatible stack heights: 4 vs 0
		//IL_07a0->IL08e9: Incompatible stack heights: 4 vs 0
		//IL_072a->IL072a: Incompatible stack heights: 5 vs 4
		//IL_077e->IL077e: Incompatible stack heights: 5 vs 4
		//IL_07d1->IL08e9: Incompatible stack heights: 4 vs 0
		//IL_0832->IL08e9: Incompatible stack heights: 4 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (_asteroidHitNum == -1)
		{
			moveTarget();
			return;
		}
		PhaserSprite crosshairSprite = _crosshairSprite;
		if ((object)_crosshairSprite != null && (object)crosshairSprite._spriteAnimation != null)
		{
			crosshairSprite._spriteAnimation.SetAnimation("shot");
			_ = 0;
			_ = 1065353216;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_PanelWeaponFire, 100f, 10, 0f, volume, rate, detune, loop);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null)
				{
					PhaserScene.Renderer renderer = s_scene._renderer;
					if (s_scene._renderer != null)
					{
						float num = renderer.width * 0.5f;
						if ((object)GM.Core != null)
						{
							PhaserScene s_scene2 = ArcadePhysics.s_scene;
							if (ArcadePhysics.s_scene != null)
							{
								PhaserScene.Renderer renderer2 = s_scene2._renderer;
								if (s_scene2._renderer != null)
								{
									float num2 = renderer2.height * 0.5f;
									Camera main = Camera.main;
									if ((object)main != null)
									{
										Transform transform = main.transform;
										if ((object)transform != null)
										{
											_ = 0;
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rax_v44 (UnityEngine.Transform)+10]");
											bool flag = (nint)0 == 0;
											object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rax_v44 (UnityEngine.Transform)+10]");
											Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj3);
											Camera main2 = Camera.main;
											if ((object)main2 != null)
											{
												Transform transform2 = main2.transform;
												if ((object)transform2 != null)
												{
													_ = 0;
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rax_v51 (UnityEngine.Transform)+10]");
													bool flag2 = (nint)0 == 0;
													object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rax_v51 (UnityEngine.Transform)+10]");
													Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj4);
													if ((object)_bulletSprite1 != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-25]");
														float y = 0f - num2;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-41]");
														float x = 0f - num;
														PhaserSprite phaserSprite = _bulletSprite1.setPosition(x, y);
														Camera main3 = Camera.main;
														if ((object)main3 != null)
														{
															Transform transform3 = main3.transform;
															if ((object)transform3 != null)
															{
																_ = 0;
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rax_v59 (UnityEngine.Transform)+10]");
																bool flag3 = (nint)0 == 0;
																object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rax_v59 (UnityEngine.Transform)+10]");
																Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj5);
																Camera main4 = Camera.main;
																if ((object)main4 != null)
																{
																	Transform transform4 = main4.transform;
																	if ((object)transform4 != null)
																	{
																		_ = 0;
																		_ = 0;
																		bool flag4 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
																		object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
																		Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out *(Vector3*)obj6);
																		if ((object)_bulletSprite2 != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-25]");
																			float y2 = 0f - num2;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-41]");
																			float x2 = 0f + num;
																			PhaserSprite phaserSprite2 = _bulletSprite2.setPosition(x2, y2);
																			if ((object)_bulletSprite1 != null)
																			{
																				float2 position = _bulletSprite1.position;
																				if ((object)_crosshairSprite != null)
																				{
																					float2 position2 = _crosshairSprite.position;
																					if ((object)_crosshairSprite != null)
																					{
																						float2 position3 = _crosshairSprite.position;
																						if ((object)_bulletSprite1 != null)
																						{
																							float2 position4 = _bulletSprite1.position;
																							if ((object)_bulletSprite2 != null)
																							{
																								float2 position5 = _bulletSprite2.position;
																								if ((object)_crosshairSprite != null)
																								{
																									float2 position6 = _crosshairSprite.position;
																									if ((object)_crosshairSprite != null)
																									{
																										float2 position7 = _crosshairSprite.position;
																										if ((object)_bulletSprite2 != null)
																										{
																											float2 position8 = _bulletSprite2.position;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+6B]");
																											nint num3 = 0;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7B]");
																											object obj7 = num3 - 0;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7F]");
																											nint num4 = 0;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-59]");
																											object obj8 = num4 - 0;
																											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-4D]");
																											nint num5 = 0;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-45]");
																											object obj9 = num5 - 0;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-41]");
																											nint num6 = 0;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
																											object obj10 = num6 - 0;
																											float num7 = (float)obj7 * 57.29578f;
																											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
																											float num8 = (float)obj9 * 57.29578f;
																											float num9 = num8 + 90f;
																											object obj11 = num9 ^ -0f;
																											if ((object)_bulletSprite1 != null)
																											{
																												Transform transform5 = _bulletSprite1.transform;
																												if ((object)transform5 != null)
																												{
																													Vector3 localEulerAngles = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
																													transform5.localEulerAngles = localEulerAngles;
																													float num10 = num7 + 90f;
																													object obj12 = num10 ^ -0f;
																													if ((object)_bulletSprite2 != null)
																													{
																														Transform transform6 = _bulletSprite2.transform;
																														if ((object)transform6 != null)
																														{
																															Vector3 localEulerAngles2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
																															transform6.localEulerAngles = localEulerAngles2;
																															TweenConfig tweenConfig = new TweenConfig();
																															object[] array = new object[2];
																															if (array != null)
																															{
																																if ((object)_bulletSprite1 != null)
																																{
																																	nint num11 = (nint)array;
																																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																	object obj13 = default(object);
																																	bool flag5 = obj13 == null;
																																}
																																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																if ((object)_bulletSprite2 != null)
																																{
																																	nint num12 = (nint)array;
																																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																	object obj14 = default(object);
																																	bool flag6 = obj14 == null;
																																}
																																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																if (tweenConfig != null)
																																{
																																	tweenConfig.targets = array;
																																	if ((object)_crosshairSprite != null)
																																	{
																																		float2 position9 = _crosshairSprite.position;
																																		_ = 0;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
																																		_ = 0;
																																		_ = 1;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
																																		tweenConfig.x = (float?)(object)0;
																																		if ((object)_crosshairSprite != null)
																																		{
																																			float2 position10 = _crosshairSprite.position;
																																			_ = 0;
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7B]");
																																			_ = 0;
																																			_ = 1;
																																			_ = 0;
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
																																			tweenConfig.y = (float?)(object)0;
																																			tweenConfig.duration = 100f;
																																			_ = 1065353216;
																																			_ = 1;
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
																																			tweenConfig.alpha = (float?)(object)0;
																																			TweenCallback onComplete = delegate
																																			{
																																				AsteroidExplode();
																																			};
																																			tweenConfig.onComplete = onComplete;
																																			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
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
		throw new NullReferenceException();
	}

	private void AsteroidExplode()
	{
		//IL_010f: Expected O, but got I
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_06da: Expected O, but got F4
		//IL_0707: Expected O, but got I4
		//IL_070f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0714: Expected O, but got Unknown
		//IL_0175: Expected O, but got I4
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected O, but got Unknown
		//IL_074f: Expected F4, but got I4
		//IL_02be: Expected O, but got F4
		//IL_0309: Expected O, but got I4
		//IL_032d: Expected I4, but got O
		//IL_0363: Unknown result type (might be due to invalid IL or missing references)
		//IL_0368: Expected O, but got Unknown
		//IL_0496: Expected I4, but got F4
		//IL_0496: Expected O, but got F4
		//IL_0496: Expected I4, but got O
		//IL_04b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b7: Expected O, but got Unknown
		//IL_04c9: Invalid comparison between F4 and O
		//IL_05eb: Expected I, but got O
		//IL_066d: Expected O, but got I4
		//IL_069d: Expected I4, but got I8
		//IL_0082->IL06a4: Incompatible stack heights: 1 vs 0
		//IL_00ba->IL06a4: Incompatible stack heights: 1 vs 0
		//IL_00ed->IL06a4: Incompatible stack heights: 1 vs 0
		//IL_0781->IL06a4: Incompatible stack heights: 1 vs 0
		//IL_0215->IL06a4: Incompatible stack heights: 2 vs 0
		//IL_024f->IL06a4: Incompatible stack heights: 2 vs 0
		//IL_0293->IL06a4: Incompatible stack heights: 2 vs 0
		//IL_0507->IL06a4: Incompatible stack heights: 2 vs 0
		//IL_0529->IL06a4: Incompatible stack heights: 2 vs 0
		//IL_07a7->IL06a4: Incompatible stack heights: 2 vs 0
		//IL_0351->IL06a4: Incompatible stack heights: 2 vs 0
		//IL_05b7->IL06a4: Incompatible stack heights: 2 vs 0
		//IL_0427->IL06a4: Incompatible stack heights: 2 vs 0
		//IL_03af->IL06a4: Incompatible stack heights: 2 vs 0
		//IL_0801->IL06a4: Incompatible stack heights: 3 vs 0
		//IL_03d2->IL06a4: Incompatible stack heights: 2 vs 0
		//IL_0630->IL06a4: Incompatible stack heights: 3 vs 0
		//IL_060e->IL060e: Incompatible stack heights: 4 vs 3
		_003C_003Ec__DisplayClass26_0 obj = new _003C_003Ec__DisplayClass26_0();
		if (obj != null)
		{
			obj._003C_003E4__this = this;
			List<Vector2> asteroidVelocity = _asteroidVelocity;
			if (_asteroidVelocity != null)
			{
				int asteroidHitNum = _asteroidHitNum;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rcx_v18 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				bool flag = (nint)asteroidHitNum >= (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rcx_v18 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
				if ((nint)0 != 0)
				{
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rcx_v18 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
					_ = (nint)0 + (nint)1;
					if ((object)_bulletSprite1 != null)
					{
						PhaserSprite phaserSprite = _bulletSprite1.setAlpha(0f);
						if ((object)_bulletSprite2 != null)
						{
							PhaserSprite phaserSprite2 = _bulletSprite2.setAlpha(0f);
							object obj2 = (nint)0 ^ (nint)0;
							object obj3 = 0 & obj2;
							bool flag2 = (nint)obj3 < 0;
							bool flag3 = (nint)0 < (nint)0;
							bool flag4 = (nint)0 == 0;
							object obj4 = UnityEngine.Random.value;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm2,xmm1\"");
							bool flag5 = flag3 == flag2;
							object obj5 = !flag4;
							object obj6 = flag5 & obj5;
							SfxType sfxType;
							if (obj6 == null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm0\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm2,xmm0\"");
								bool flag6 = flag3 == flag2;
								object obj7 = !flag4;
								object obj8 = flag6 & obj7;
								sfxType = ((obj8 != null) ? SfxType.DLC3_PanelWeaponHit2 : SfxType.DLC3_PanelWeaponHit3);
							}
							else
							{
								sfxType = SfxType.DLC3_PanelWeaponHit1;
							}
							float? num = default(float?);
							float num2 = default(float);
							float num3 = default(float);
							bool flag7 = default(bool);
							PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(sfxType, 100f, 10, 0f, num, num2, num3, flag7, 1f);
							List<PhaserSprite> asteroidSprites = _asteroidSprites;
							int asteroidHitNum2 = _asteroidHitNum;
							if (_asteroidSprites != null)
							{
								bool flag8 = _asteroidHitNum >= asteroidSprites._size;
								PhaserSprite[] items = asteroidSprites._items;
								if (asteroidSprites._items != null)
								{
									obj.asteroidSprite = items[asteroidHitNum2];
									if ((object)_crosshairSprite != null)
									{
										float2 position = _crosshairSprite.position;
										obj.explosionLocation = position;
										_ = 1065353216;
										if ((object)obj.asteroidSprite != null)
										{
											Transform transform = obj.asteroidSprite.transform;
											float num4 = default(float);
											Projectile projectile = base.FireOneProjectile((Vector2)num4, 0, transform);
											float num5 = base.PAmount();
											bool flag9 = !(num4 > 1f);
											Transform transform2 = transform;
											float num6 = num4;
											if (flag9)
											{
												goto IL_04dd;
											}
											Transform transform3 = (Transform)1;
											while (true)
											{
												_003C_003Ec__DisplayClass26_1 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass26_1();
												if (CS_0024_003C_003E8__locals7 == null)
												{
													break;
												}
												CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1 = obj;
												CS_0024_003C_003E8__locals7.num = (int)transform3;
												WeaponData currentWeaponData = _currentWeaponData;
												if (_currentWeaponData == null)
												{
													break;
												}
												object obj9 = transform3 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
												if ((nint)obj9 <= 0)
												{
													_003C_003Ec__DisplayClass26_0 obj10 = CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1;
													if (CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1 == null || (object)obj10.asteroidSprite == null)
													{
														break;
													}
													Transform transform4 = obj10.asteroidSprite.transform;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
													transform2 = transform3;
													num6 = num4;
												}
												else
												{
													if (_currentWeaponData == null)
													{
														break;
													}
													Action onComplete = delegate
													{
														_003C_003Ec__DisplayClass26_0 obj12 = CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1;
														Transform target = obj12.asteroidSprite.transform;
														Vector2 pos = default(Vector2);
														Projectile projectile2 = obj12._003C_003E4__this.FireOneProjectile(pos, CS_0024_003C_003E8__locals7.num, target);
													};
													float num7 = (float)transform3 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
													num6 = num7 * 0.001f;
													Timer timer = Timers.Register(num6, onComplete, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)num2, (int)num3, flag7 ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
													transform2 = null;
												}
												transform3 = (Transform)(transform3 + 1);
												float num8 = base.PAmount();
												if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6) > System.Runtime.CompilerServices.Unsafe.As<Transform, UIntPtr>(ref transform3))
												{
													continue;
												}
												goto IL_04dd;
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
		goto IL_06a4;
		IL_04dd:
		PhaserSprite asteroidSprite = obj.asteroidSprite;
		if ((object)obj.asteroidSprite != null && (object)asteroidSprite._spriteAnimation != null)
		{
			asteroidSprite._spriteAnimation.SetAnimation("explode");
			if (explodeScaleTween != null)
			{
				explodeScaleTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			Transform asteroidSprite2 = (Transform)(object)obj.asteroidSprite;
			if ((object)obj.asteroidSprite != null)
			{
				bool flag10 = ((UnityEngine.Object)asteroidSprite2).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)asteroidSprite2).m_CachedPtr);
				Transform transform5 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
				if (array != null)
				{
					if ((object)transform5 != null)
					{
						nint num9 = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj11 = default(object);
						bool flag11 = obj11 == null;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					if (tweenConfig != null)
					{
						tweenConfig.targets = array;
						float num10 = base.PArea();
						tweenConfig.duration = 100f;
						tweenConfig.scale = (float?)(object)1;
						MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
						explodeScaleTween = multiTargetTween;
						_asteroidHitNum = -1;
						moveTarget();
						return;
					}
				}
			}
		}
		goto IL_06a4;
		IL_06a4:
		throw new NullReferenceException();
	}

	private void OnExplodeComplete(int asteroidNum)
	{
		//IL_003c: Expected O, but got I
		//IL_00a0: Expected O, but got I
		List<bool> asteroidActive = _asteroidActive;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdx_v1 (System.Collections.Generic.List`1<System.Boolean>)+18]");
		if ((nint)asteroidNum < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdx_v1 (System.Collections.Generic.List`1<System.Boolean>)+10]");
			object obj = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdx_v1 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
			_ = (nint)0 + (nint)1;
			List<bool> asteroidShootable = _asteroidShootable;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v7 (System.Collections.Generic.List`1<System.Boolean>)+18]");
			if ((nint)asteroidNum < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v7 (System.Collections.Generic.List`1<System.Boolean>)+10]");
				object obj2 = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v7 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
				_ = (nint)0 + (nint)1;
				List<PhaserSprite> asteroidSprites = _asteroidSprites;
				if (asteroidNum < asteroidSprites._size)
				{
					PhaserSprite[] items = asteroidSprites._items;
					PhaserSprite phaserSprite = items[asteroidNum].setVisible(visible: false);
					return;
				}
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private unsafe void LateUpdate()
	{
		//IL_0aa0: Expected I, but got O
		//IL_0aaa: Expected O, but got I4
		//IL_0143: Expected O, but got I
		//IL_01cb: Expected O, but got I4
		//IL_0252: Expected O, but got Ref
		//IL_056e: Expected O, but got I
		//IL_05c3: Expected O, but got I4
		//IL_0612: Expected F4, but got I4
		//IL_0680: Unknown result type (might be due to invalid IL or missing references)
		//IL_0685: Expected O, but got Unknown
		//IL_068e: Invalid comparison between F4 and O
		//IL_06ff: Expected O, but got I4
		//IL_076b: Expected O, but got I
		//IL_077b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0780: Expected O, but got Unknown
		//IL_07dd: Expected O, but got I
		//IL_0818: Expected O, but got I4
		//IL_0820: Unknown result type (might be due to invalid IL or missing references)
		//IL_0825: Expected O, but got Unknown
		//IL_09ae: Expected F4, but got I4
		//IL_09bf: Expected O, but got I4
		//IL_09d3: Expected F4, but got I4
		//IL_09f6: Expected O, but got F4
		//IL_0860: Expected O, but got I4
		//IL_0868: Unknown result type (might be due to invalid IL or missing references)
		//IL_086d: Expected O, but got Unknown
		//IL_092e: Expected F4, but got I4
		//IL_093f: Expected O, but got I4
		//IL_0953: Expected F4, but got I4
		//IL_0976: Expected O, but got F4
		//IL_08ae: Expected F4, but got I4
		//IL_08bf: Expected O, but got I4
		//IL_08d3: Expected F4, but got I4
		//IL_08f6: Expected O, but got F4
		//IL_0acc->IL0af2: Incompatible stack heights: 6 vs 2
		//IL_0a16->IL0ab9: Incompatible stack heights: 8 vs 6
		//IL_0527->IL05e8: Incompatible stack heights: 6 vs 8
		//IL_09fb->IL0acc: Incompatible stack heights: 12 vs 8
		//IL_097b->IL0acc: Incompatible stack heights: 12 vs 8
		//IL_08fb->IL0acc: Incompatible stack heights: 12 vs 8
		Camera main = Camera.main;
		Transform transform = main.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator ret;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
		float num2 = default(float);
		float num = num2 + CrosshairOffsetY;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		Camera main2 = Camera.main;
		Transform transform2 = main2.transform;
		bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)(&ret));
		nint num3 = unchecked((nint)null);
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)0;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = ret;
		Vector2 vector = default(Vector2);
		object obj2 = default(object);
		Vector2 vector2 = default(Vector2);
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		while (true)
		{
			List<PhaserSprite> asteroidSprites = _asteroidSprites;
			if (num3 >= asteroidSprites._size)
			{
				break;
			}
			bool flag3 = num3 >= asteroidSprites._size;
			PhaserSprite[] items = asteroidSprites._items;
			bool flag4 = num3 >= items.Length;
			List<bool> asteroidActive = _asteroidActive;
			nint intPtr = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v760 @ rax_v39 (System.Collections.Generic.List`1<System.Boolean>)+18]");
			bool flag5 = intPtr >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v760 @ rax_v39 (System.Collections.Generic.List`1<System.Boolean>)+10]");
			object obj = 0;
			nint intPtr2 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v761 @ rax_v40+18]");
			bool flag6 = intPtr2 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ r14_v9 (Il2CppMethodInfo)+20+v761 @ rax_v40]");
			if ((nint)0 == 0)
			{
				goto IL_0ab9;
			}
			bool flag7 = ((List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator*)_asteroidVelocity)->MoveNext();
			bool flag8 = ret.MoveNext();
			bool flag9 = (nint)enumerator2 <= 0;
			ret = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)flag7;
			if (flag9)
			{
				goto IL_0ab9;
			}
			Transform transform3 = items[num3].transform;
			Vector3 localEulerAngles = transform3.localEulerAngles;
			bool flag10 = ((List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator*)_asteroidRotation)->MoveNext();
			float deltaTime = PauseSystem.DeltaTime;
			Transform transform4 = items[num3].transform;
			transform4.localEulerAngles = (Vector3)(&vector);
			float2 position = items[num3].position;
			bool flag11 = ((List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator*)_asteroidVelocity)->MoveNext();
			float deltaTime2 = PauseSystem.DeltaTime;
			float num4 = (float)obj2 * deltaTime2;
			float num5 = (float)(flag11 ? 1 : 0) * deltaTime2;
			float num6 = num2 + num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
			Transform transform5 = items[num3].transform;
			Vector3 position2 = transform5.position;
			PhaserScene scene = GM.Core.scene;
			PhaserScene.Renderer renderer = scene._renderer;
			float num7 = renderer.width * 0.6f;
			float num8 = (float)(flag7 ? 1 : 0) - num7;
			int num15;
			if (!(num8 > position2.x))
			{
				Transform transform6 = items[num3].transform;
				Vector3 position3 = transform6.position;
				PhaserScene scene2 = GM.Core.scene;
				PhaserScene.Renderer renderer2 = scene2._renderer;
				float num9 = renderer2.width * 0.6f;
				float num10 = num9 + (float)(flag7 ? 1 : 0);
				if (!(position3.x > num10))
				{
					Transform transform7 = items[num3].transform;
					Vector3 position4 = transform7.position;
					PhaserScene scene3 = GM.Core.scene;
					PhaserScene.Renderer renderer3 = scene3._renderer;
					float num11 = renderer3.height * 0.6f;
					float num12 = (float)vector2 - num11;
					if (!(num12 > position4.y))
					{
						Transform transform8 = items[num3].transform;
						Vector3 position5 = transform8.position;
						PhaserScene scene4 = GM.Core.scene;
						PhaserScene.Renderer renderer4 = scene4._renderer;
						float num13 = renderer4.height * 0.6f;
						float num14 = (float)vector2 - num13;
						bool flag12 = !(num14 > position5.y);
						num15 = 0;
						if (flag12)
						{
							goto IL_05e8;
						}
					}
				}
			}
			List<bool> asteroidActive2 = _asteroidActive;
			nint intPtr3 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rcx_v68 (System.Collections.Generic.List`1<System.Boolean>)+18]");
			bool flag13 = intPtr3 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rcx_v68 (System.Collections.Generic.List`1<System.Boolean>)+10]");
			object obj3 = 0;
			nint intPtr4 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v784 @ rax_v87+18]");
			bool flag14 = intPtr4 >= 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rcx_v68 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
			_ = (nint)0 + (nint)1;
			PhaserSprite phaserSprite = (PhaserSprite)((List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator*)_asteroidSprites)->MoveNext();
			PhaserSprite phaserSprite2 = phaserSprite.setVisible(visible: false);
			num15 = 0;
			goto IL_05e8;
			IL_05e8:
			GameManager core = GM.Core;
			Transform characters = (Transform)(object)core._characters;
			num = 0f;
			enumerator2 = ret;
			while (enumerator.MoveNext())
			{
				float2 position6 = items[num3].position;
				float2 position7 = ((ArcadeSprite)null).position;
				float num16 = num2 - (float)obj2;
				object obj4 = position7 - position6;
				num = num16 * num16;
				object obj5 = obj4 * obj4;
				enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(obj5 + num);
				bool flag15 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.0576f) < System.Runtime.CompilerServices.Unsafe.As<List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator, UIntPtr>(ref enumerator2);
				ret = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)position7;
				if (flag15)
				{
					continue;
				}
				bool flag16 = _asteroidVelocity == null;
				bool flag17 = ((List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator*)_asteroidVelocity)->MoveNext();
				bool flag18 = _asteroidSprites == null;
				Transform transform9 = (Transform)((List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator*)_asteroidSprites)->MoveNext();
				float2 position8 = ((ArcadeSprite)null).position;
				bool flag19 = (object)transform9 == null;
				Transform transform10 = transform9.transform;
				Projectile projectile = base.FireOneProjectile(vector2, 0, transform10);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2143 @ rax_v69 (UnityEngine.Transform)+30]");
				nint num17 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2143 @ rax_v69 (UnityEngine.Transform)+30]");
				object obj6 = num17 ^ 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2143 @ rax_v69 (UnityEngine.Transform)+30]");
				object obj7 = 0 & obj6;
				bool flag20 = (nint)obj7 < 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2143 @ rax_v69 (UnityEngine.Transform)+30]");
				bool flag21 = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2143 @ rax_v69 (UnityEngine.Transform)+30]");
				bool flag22 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2143 @ rax_v69 (UnityEngine.Transform)+30]");
				((BaseSpriteAnimation)0).SetAnimation("explode");
				float value = UnityEngine.Random.value;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm12,xmm1\"");
				bool flag23 = flag21 == flag20;
				object obj8 = !flag22;
				object obj9 = flag23 & obj8;
				if (obj9 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm0\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm12,xmm0\"");
					bool flag24 = flag21 == flag20;
					object obj10 = !flag22;
					object obj11 = flag24 & obj10;
					if (obj11 == null)
					{
						PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_PanelWeaponHit3, 100f, 10, 0f, volume, rate, detune, loop, 1f);
						obj2 = 1065353216;
						characters = transform10;
						num6 = 0f;
						num = 100f;
						num15 = 10;
						ret = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)position8;
						enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)value;
					}
					else
					{
						PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_PanelWeaponHit2, 100f, 10, 0f, volume, rate, detune, loop, 1f);
						obj2 = 1065353216;
						characters = transform10;
						num6 = 0f;
						num = 100f;
						num15 = 10;
						ret = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)position8;
						enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)value;
					}
				}
				else
				{
					PlaySoundResult playSoundResult3 = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_PanelWeaponHit1, 100f, 10, 0f, volume, rate, detune, loop, 1f);
					obj2 = 1065353216;
					characters = transform10;
					num6 = 0f;
					num = 100f;
					num15 = 10;
					ret = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)position8;
					enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)value;
				}
			}
			enumerator = ret;
			vector = vector2;
			goto IL_0ab9;
			IL_0ab9:
			num3++;
		}
	}

	public override void SetVisible(bool visible)
	{
		//IL_0039: Expected O, but got I4
		//IL_0042: Expected O, but got I4
		//IL_00b1: Expected O, but got I
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected O, but got Unknown
		_isVisible = visible;
		PhaserSprite phaserSprite = _crosshairSprite.setVisible(visible);
		if (visible)
		{
			return;
		}
		List<PhaserSprite> asteroidSprites = _asteroidSprites;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj < asteroidSprites._size)
			{
				List<bool> asteroidActive = _asteroidActive;
				object obj3 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rcx_v10 (System.Collections.Generic.List`1<System.Boolean>)+18]");
				if ((nint)obj3 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rcx_v10 (System.Collections.Generic.List`1<System.Boolean>)+10]");
				object obj4 = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rcx_v10 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
				_ = (nint)0 + (nint)1;
				List<PhaserSprite> asteroidSprites2 = _asteroidSprites;
				if ((nint)obj2 >= asteroidSprites2._size)
				{
					break;
				}
				PhaserSprite[] items = asteroidSprites2._items;
				PhaserSprite phaserSprite2 = items[obj2].setVisible(visible: false);
				asteroidSprites = _asteroidSprites;
				obj2++;
				obj = obj2;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public AstroidClearWeapon()
	{
		//IL_001b: Expected I4, but got I8
		_asteroidHitNum = -1;
		_maxAsteroids = 50;
		sureFire = 1f;
		base._002Ector();
	}

	private void _003CmoveTarget_003Eb__24_0()
	{
		checkAsteroidCollision();
	}

	private void _003CcheckAsteroidCollision_003Eb__25_0()
	{
		AsteroidExplode();
	}
}
