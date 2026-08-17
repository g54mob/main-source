using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Objects.VFX;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Weapons;

public class SantaJavelin2Weapon : SantaJavelinWeapon
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__43_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CScreenShake_003Eb__43_1()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = 0f;
			followOffset.y = 0f;
		}
	}

	private sealed class _003C_003Ec__DisplayClass35_0
	{
		public List<Transform> gemTS;

		public List<Pickup> gems;

		public float angle;

		public Vector3 offset;

		public Action<Pickup> _003C_003E9__8;

		public DOGetter<float> _003C_003E9__9;

		public DOSetter<float> _003C_003E9__10;

		public TweenCallback _003C_003E9__11;

		public TweenCallback _003C_003E9__12;

		internal void _003CWSPDamage_003Eb__8(Pickup gem)
		{
			if ((object)gem != null && ((UnityEngine.Object)gem).m_CachedPtr != (IntPtr)0)
			{
				Transform transform = gem.transform;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049F4B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA3FE0");
				gem._003CDisableGet_003Ek__BackingField = true;
			}
		}

		internal float _003CWSPDamage_003Eb__0()
		{
			return angle;
		}

		internal void _003CWSPDamage_003Eb__1(float x)
		{
			angle = x;
		}

		internal void _003CWSPDamage_003Eb__2()
		{
			//IL_0082->IL0082: Incompatible stack heights: 1 vs 0
			List<Transform>.Enumerator enumerator = default(List<Transform>.Enumerator);
			Vector3 euler = default(Vector3);
			Quaternion value = default(Quaternion);
			while (enumerator.MoveNext())
			{
				object obj = null;
				Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdi_v4 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdi_v4 (System.Object)+10]");
				Transform.set_localRotation_Injected((IntPtr)0, ref value);
			}
		}

		internal void _003CWSPDamage_003Eb__3()
		{
			//IL_006d->IL006d: Incompatible stack heights: 1 vs 0
			List<Transform>.Enumerator enumerator = default(List<Transform>.Enumerator);
			Vector3 euler = default(Vector3);
			Quaternion value = default(Quaternion);
			while (enumerator.MoveNext())
			{
				object obj = null;
				Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdi_v4 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdi_v4 (System.Object)+10]");
				Transform.set_localRotation_Injected((IntPtr)0, ref value);
			}
		}

		internal float _003CWSPDamage_003Eb__4()
		{
			//IL_000d: Expected F4, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.SantaJavelin2Weapon+<>c__DisplayClass35_0)+28]");
			return 0f;
		}

		internal void _003CWSPDamage_003Eb__5(float x)
		{
		}

		internal unsafe void _003CWSPDamage_003Eb__6()
		{
			//IL_0084->IL00a5: Incompatible stack heights: 2 vs 0
			List<Transform>.Enumerator enumerator = default(List<Transform>.Enumerator);
			List<Transform>.Enumerator value = default(List<Transform>.Enumerator);
			while (enumerator.MoveNext())
			{
				object obj = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rbx_v4 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rbx_v4 (System.Object)+10]");
				Transform.get_localPosition_Injected((IntPtr)0, out Vector3 _);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rbx_v4 (System.Object)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rbx_v4 (System.Object)+10]");
				Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)(&value));
			}
		}

		internal unsafe void _003CWSPDamage_003Eb__7()
		{
			//IL_0217: Expected O, but got I4
			offset = (Vector3)0;
			_ = 0;
			DOGetter<float> getter = _003C_003E9__9;
			if (_003C_003E9__9 == null)
			{
				DOGetter<float> dOGetter = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
				_003C_003E9__9 = dOGetter;
				getter = dOGetter;
			}
			DOSetter<float> setter = _003C_003E9__10;
			if (_003C_003E9__10 == null)
			{
				DOSetter<float> dOSetter = null;
				float x = default(float);
				((_003C_003Ec__DisplayClass35_0)(object)dOSetter)._003CWSPDamage_003Eb__10(x);
				_003C_003E9__10 = dOSetter;
				setter = dOSetter;
			}
			TweenerCore<float, float, FloatOptions> t = DOTween.To(getter, setter, -0.04f, 0.5f);
			TweenerCore<float, float, FloatOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, 0.5f);
			TweenCallback tweenCallback = _003C_003E9__11;
			if (_003C_003E9__11 == null)
			{
				tweenCallback = (_003C_003E9__11 = delegate
				{
					//IL_0084->IL00a5: Incompatible stack heights: 2 vs 0
					List<Transform>.Enumerator enumerator = default(List<Transform>.Enumerator);
					List<Transform>.Enumerator value = default(List<Transform>.Enumerator);
					while (enumerator.MoveNext())
					{
						object obj = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rbx_v4 (System.Object)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rbx_v4 (System.Object)+10]");
						Transform.get_localPosition_Injected((IntPtr)0, out Vector3 _);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rbx_v4 (System.Object)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rbx_v4 (System.Object)+10]");
						Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)(&value));
					}
				});
			}
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			TweenCallback tweenCallback2 = _003C_003E9__12;
			if (_003C_003E9__12 == null)
			{
				tweenCallback2 = (_003C_003E9__12 = delegate
				{
					//IL_0013: Expected O, but got I4
					List<Pickup>.Enumerator enumerator = default(List<Pickup>.Enumerator);
					if (!enumerator.MoveNext())
					{
						return;
					}
					object obj = 0;
					throw new NullReferenceException();
				});
			}
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
		}

		internal float _003CWSPDamage_003Eb__9()
		{
			//IL_000d: Expected F4, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.SantaJavelin2Weapon+<>c__DisplayClass35_0)+28]");
			return 0f;
		}

		internal void _003CWSPDamage_003Eb__10(float x)
		{
		}

		internal unsafe void _003CWSPDamage_003Eb__11()
		{
			//IL_0084->IL00a5: Incompatible stack heights: 2 vs 0
			List<Transform>.Enumerator enumerator = default(List<Transform>.Enumerator);
			List<Transform>.Enumerator value = default(List<Transform>.Enumerator);
			while (enumerator.MoveNext())
			{
				object obj = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rbx_v4 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rbx_v4 (System.Object)+10]");
				Transform.get_localPosition_Injected((IntPtr)0, out Vector3 _);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rbx_v4 (System.Object)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rbx_v4 (System.Object)+10]");
				Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)(&value));
			}
		}

		internal void _003CWSPDamage_003Eb__12()
		{
			//IL_0013: Expected O, but got I4
			List<Pickup>.Enumerator enumerator = default(List<Pickup>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj = 0;
				throw new NullReferenceException();
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass43_0
	{
		public float strength;

		internal void _003CScreenShake_003Eb__0()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			float x = strength * -3f;
			followOffset.x = x;
		}
	}

	private sealed class _003C_003Ec__DisplayClass46_0
	{
		public int localIndex;

		public SantaJavelin2Weapon _003C_003E4__this;

		internal void _003CFire_FireProjectiles_003Eb__0()
		{
			//IL_0106: Expected O, but got I4
			//IL_00b4: Expected O, but got I
			//IL_00c0: Expected I, but got O
			//IL_0079->IL00cf: Incompatible stack heights: 1 vs 0
			//IL_009e->IL00cf: Incompatible stack heights: 1 vs 0
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
					GameObject gameObject2 = (GameObject)(object)_003C_003E4__this;
					if ((object)_003C_003E4__this != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rdi_v7 (UnityEngine.GameObject)+58]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rdi_v7 (UnityEngine.GameObject)+58]");
							float2 position = ((ArcadeSprite)0).position;
							nint num = (nint)gameObject2;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v229 @ r10_v2 (Il2CppClass<UnityEngine.GameObject>)+4D8] (should have been resolved before IL gen)");
							return;
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private List<MeshRenderer> _3DMeshes;

	private Transform _RingTransform;

	private MeshRenderer _RingMesh;

	private Transform _Ring2Transform;

	private MeshRenderer _Ring2Mesh;

	private Transform _spearCTransform;

	private MeshRenderer _spearCMesh;

	private Transform _spearLTransform;

	private MeshRenderer _spearLMesh;

	private Transform _spearRTransform;

	private MeshRenderer _spearRMesh;

	private float _modelMaterialAlpha = 10f;

	private PhaserSprite _darkBackground;

	private PhaserSprite _lightBackground;

	private float _defaultSkyScale = 100f;

	private int _AccumulatedRosaries;

	private bool _isPlayingWSP;

	private float _delayBetweenWSP = 3000f;

	private float _WSPDelayTotalTime;

	private static readonly int _ScrollSpeedX;

	private static readonly int _ScrollSpeedY;

	private static readonly int _AlphaMul;

	private MultiTargetTween _tween1;

	private MultiTargetTween _tween2;

	private MultiTargetTween _tweenGems;

	private bool _generatedPools;

	private BulletPool _tvExplosionPool;

	public override bool SingleProjectile => true;

	public override float PPower()
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected F4, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
		{
			goto IL_0151;
		}
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
		float num3 = default(float);
		float num2 = num3 & -2147483649L;
		object obj = num2 & -2147483649L;
		float num4;
		if ((nint)obj <= 2139095040)
		{
			bool flag = !(num2 > 10f);
			num4 = num2;
			if (flag)
			{
				goto IL_015c;
			}
		}
		num4 = 10f;
		goto IL_015c;
		IL_015c:
		WeaponData currentWeaponData = _currentWeaponData;
		bool flag2 = _currentWeaponData == null;
		num3 = 10f;
		if (!flag2)
		{
			bool flag3 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
			num3 = 10f;
			if (!flag3)
			{
				num3 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
					float num5 = num4 + 1f;
					float num6 = num5 * currentWeaponData._003Cpower_003Ek__BackingField;
					float num7 = num6 * num3;
					return num3 + num7;
				}
			}
		}
		goto IL_0151;
		IL_0151:
		throw new NullReferenceException();
	}

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_027d: Expected O, but got I4
		//IL_02f8: Expected O, but got I4
		//IL_0399: Expected I4, but got I8
		//IL_0481: Expected O, but got I4
		//IL_054c: Expected O, but got I4
		//IL_05ed: Expected I4, but got I8
		//IL_06a2: Expected O, but got Ref
		//IL_080a: Expected O, but got Ref
		//IL_0a0a->IL0a0a: Incompatible stack heights: 32 vs 30
		//IL_0ac0->IL0ac0: Incompatible stack heights: 33 vs 31
		//IL_0b76->IL0b76: Incompatible stack heights: 34 vs 32
		//IL_0c2c->IL0c2c: Incompatible stack heights: 35 vs 33
		//IL_0ce2->IL0ce2: Incompatible stack heights: 36 vs 34
		//IL_104c->IL107e: Incompatible stack heights: 36 vs 35
		((Weapon)this)._003CCanCrit_003Ek__BackingField = true;
		_secondaryOvarlapDamageType = WeaponType.CURSE;
		((Weapon)this).InitWeapon(characterController, weaponType);
		((Weapon)this)._003CCanCrit_003Ek__BackingField = true;
		Transform transform = _RingTransform.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector2 value = default(Vector2);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
		Material material = ((Renderer)_RingMesh).GetMaterial();
		material.SetFloatImpl(_ScrollSpeedX, 0.5f);
		Material material2 = ((Renderer)_RingMesh).GetMaterial();
		material2.SetFloatImpl(_ScrollSpeedY, 0.5f);
		Material material3 = ((Renderer)_RingMesh).GetMaterial();
		material3.SetFloatImpl(_AlphaMul, 0f);
		Transform transform2 = _Ring2Transform.transform;
		bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Vector2 value2 = default(Vector2);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value2));
		Material material4 = ((Renderer)_Ring2Mesh).GetMaterial();
		material4.SetFloatImpl(_ScrollSpeedX, 0.5f);
		Material material5 = ((Renderer)_Ring2Mesh).GetMaterial();
		material5.SetFloatImpl(_ScrollSpeedY, 0.5f);
		Material material6 = ((Renderer)_Ring2Mesh).GetMaterial();
		material6.SetFloatImpl(_AlphaMul, 0f);
		Material material7 = ((Renderer)_spearCMesh).GetMaterial();
		material7.SetFloatImpl(_AlphaMul, 0f);
		Material material8 = ((Renderer)_spearLMesh).GetMaterial();
		material8.SetFloatImpl(_AlphaMul, 0f);
		Material material9 = ((Renderer)_spearRMesh).GetMaterial();
		material9.SetFloatImpl(_AlphaMul, 0f);
		Transform transform3 = _spearCTransform.transform;
		bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
		Vector2 value3 = default(Vector2);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)(&value3));
		Transform transform4 = _spearLTransform.transform;
		bool flag4 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
		Vector2 value4 = default(Vector2);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref *(Vector3*)(&value4));
		Transform transform5 = _spearRTransform.transform;
		bool flag5 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
		Vector2 value5 = default(Vector2);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref *(Vector3*)(&value5));
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "vfx", "blackDot");
		PhaserSprite phaserSprite2 = phaserSprite.setOrigin(0f, (float?)(object)0);
		bool flag6 = (object)GM.Core == null;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		bool flag7 = (object)GM.Core == null;
		float xScale = renderer.width * 100f;
		PhaserSprite phaserSprite3 = phaserSprite2.setScale(xScale, (float?)(object)1);
		bool flag8 = (object)phaserSprite3 == null;
		PhaserSprite phaserSprite4 = phaserSprite3.setBlendMode(BlendMode.Normal);
		bool flag9 = (object)phaserSprite4 == null;
		PhaserSprite component = phaserSprite4.setAlpha(0f);
		PhaserSprite phaserSprite5 = RenderingExtensions.SetScrollFactor(component, 0f);
		bool flag10 = (object)phaserSprite5 == null;
		PhaserSprite phaserSprite6 = phaserSprite5.setDepth(-1998);
		bool flag11 = (object)phaserSprite6 == null;
		GameObject gameObject2 = phaserSprite6.gameObject;
		bool flag12 = (object)gameObject2 == null;
		((UnityEngine.Object)gameObject2).SetName("darkBackground");
		_darkBackground = phaserSprite6;
		PhaserSprite darkBackground = _darkBackground;
		bool flag13 = (object)_darkBackground == null;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(darkBackground._spriteRenderer, 1f);
		GameObject gameObject3 = base.gameObject;
		PhaserSprite phaserSprite7 = RenderingExtensions.AddPhaserSprite(gameObject3, pos, "vfx", "WhiteDot");
		bool flag14 = (object)phaserSprite7 == null;
		PhaserSprite phaserSprite8 = phaserSprite7.setOrigin(0f, (float?)(object)0);
		bool flag15 = (object)GM.Core == null;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		bool flag16 = ArcadePhysics.s_scene == null;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		bool flag17 = s_scene2._renderer == null;
		bool flag18 = (object)GM.Core == null;
		PhaserScene s_scene3 = ArcadePhysics.s_scene;
		bool flag19 = ArcadePhysics.s_scene == null;
		bool flag20 = s_scene3._renderer == null;
		bool flag21 = (object)phaserSprite8 == null;
		float xScale2 = renderer2.width * 100f;
		PhaserSprite phaserSprite9 = phaserSprite8.setScale(xScale2, (float?)(object)1);
		bool flag22 = (object)phaserSprite9 == null;
		PhaserSprite phaserSprite10 = phaserSprite9.setBlendMode(BlendMode.Add);
		bool flag23 = (object)phaserSprite10 == null;
		PhaserSprite component2 = phaserSprite10.setAlpha(0f);
		PhaserSprite phaserSprite11 = RenderingExtensions.SetScrollFactor(component2, 0f);
		bool flag24 = (object)phaserSprite11 == null;
		PhaserSprite phaserSprite12 = phaserSprite11.setDepth(-1998);
		bool flag25 = (object)phaserSprite12 == null;
		GameObject gameObject4 = phaserSprite12.gameObject;
		bool flag26 = (object)gameObject4 == null;
		((UnityEngine.Object)gameObject4).SetName("darkBackground");
		_lightBackground = phaserSprite12;
		PhaserSprite darkBackground2 = _darkBackground;
		bool flag27 = (object)_darkBackground == null;
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(darkBackground2._spriteRenderer, 1f);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(_RingTransform, (Vector3)(&value5), 1.65f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2690 @ rax_v121 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2690 @ rax_v121 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 4294967295L;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2690 @ rax_v121 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
					if ((nint)0 == 0)
					{
						_ = 2139095040;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2690 @ rax_v121 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2690 @ rax_v121 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2690 @ rax_v121 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2690 @ rax_v121 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
						}
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag28 = tweenerCore == null;
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DOLocalRotate(_Ring2Transform, (Vector3)(&value5), 1.65f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2858 @ rax_v125 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2858 @ rax_v125 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 4294967295L;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2858 @ rax_v125 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
					if ((nint)0 == 0)
					{
						_ = 2139095040;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2858 @ rax_v125 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2858 @ rax_v125 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2858 @ rax_v125 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2858 @ rax_v125 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
						}
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag29 = tweenerCore2 == null;
		bool flag30 = (object)_RingTransform == null;
		GameObject gameObject5 = _RingTransform.gameObject;
		if ((object)gameObject5 != null && ((UnityEngine.Object)gameObject5).m_CachedPtr != (IntPtr)0)
		{
			bool flag31 = (object)_RingTransform == null;
			GameObject gameObject6 = _RingTransform.gameObject;
			bool flag32 = (object)gameObject6 == null;
			gameObject6.SetActive(value: true);
		}
		bool flag33 = (object)_Ring2Transform == null;
		GameObject gameObject7 = _Ring2Transform.gameObject;
		if ((object)gameObject7 != null && ((UnityEngine.Object)gameObject7).m_CachedPtr != (IntPtr)0)
		{
			bool flag34 = (object)_Ring2Transform == null;
			GameObject gameObject8 = _Ring2Transform.gameObject;
			bool flag35 = (object)gameObject8 == null;
			gameObject8.SetActive(value: true);
		}
		bool flag36 = (object)_spearCTransform == null;
		GameObject gameObject9 = _spearCTransform.gameObject;
		if ((object)gameObject9 != null && ((UnityEngine.Object)gameObject9).m_CachedPtr != (IntPtr)0)
		{
			bool flag37 = (object)_spearCTransform == null;
			GameObject gameObject10 = _spearCTransform.gameObject;
			bool flag38 = (object)gameObject10 == null;
			gameObject10.SetActive(value: true);
		}
		bool flag39 = (object)_spearLTransform == null;
		GameObject gameObject11 = _spearLTransform.gameObject;
		if ((object)gameObject11 != null && ((UnityEngine.Object)gameObject11).m_CachedPtr != (IntPtr)0)
		{
			bool flag40 = (object)_spearLTransform == null;
			GameObject gameObject12 = _spearLTransform.gameObject;
			bool flag41 = (object)gameObject12 == null;
			gameObject12.SetActive(value: true);
		}
		bool flag42 = (object)_spearRTransform == null;
		GameObject gameObject13 = _spearRTransform.gameObject;
		if ((object)gameObject13 != null && ((UnityEngine.Object)gameObject13).m_CachedPtr != (IntPtr)0)
		{
			bool flag43 = (object)_spearRTransform == null;
			GameObject gameObject14 = _spearRTransform.gameObject;
			bool flag44 = (object)gameObject14 == null;
			gameObject14.SetActive(value: true);
		}
		bool flag45 = _3DMeshes == null;
		List<MeshRenderer>.Enumerator enumerator = default(List<MeshRenderer>.Enumerator);
		while (enumerator.MoveNext())
		{
			Transform transform6 = null;
			((Renderer)null).sortingLayerName = "Default";
			bool flag46 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
			Renderer.set_sortingOrder_Injected(((UnityEngine.Object)transform6).m_CachedPtr, 3000);
		}
	}

	public void StartWeirdSoulsPurifier()
	{
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		int num = config._003CRunWeirdSoulsPurifier_003Ek__BackingField + 1;
		config._003CRunWeirdSoulsPurifier_003Ek__BackingField = num;
		if (!_isPlayingWSP)
		{
			_isPlayingWSP = true;
			PlayWSP();
		}
		else
		{
			int accumulatedRosaries = _AccumulatedRosaries + 1;
			_AccumulatedRosaries = accumulatedRosaries;
		}
	}

	public override void InternalUpdate()
	{
		((Weapon)this).InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		bool flag = !_cooldownAffectedByMovement;
		float num = deltaTime * 1000f;
		float num2 = (((Weapon)this)._003CTotalTime_003Ek__BackingField = num + ((Weapon)this)._003CTotalTime_003Ek__BackingField);
		if (!flag)
		{
			float frameWalk = ((Equipment)this)._003COwner_003Ek__BackingField.FrameWalk;
			float deltaTime2 = PauseSystem.DeltaTime;
			float num3 = deltaTime2 * 1000f;
			float num4 = frameWalk * 100f;
			float num5 = num3 / base._mul;
			float num6 = num5 * num4;
			num2 = (((Weapon)this)._003CTotalTime_003Ek__BackingField = num6 + ((Weapon)this)._003CTotalTime_003Ek__BackingField);
		}
		float num7 = base.PInterval();
		if (!(((Weapon)this)._003CTotalTime_003Ek__BackingField < num2))
		{
			float num8 = base.PInterval();
			float num9 = ((Weapon)this)._003CTotalTime_003Ek__BackingField - num2;
			((Weapon)this)._003CTotalTime_003Ek__BackingField = num9;
			base.Fire();
		}
		if (_AccumulatedRosaries > 0 && !_isPlayingWSP)
		{
			float deltaTime3 = PauseSystem.DeltaTime;
			float num10 = deltaTime3 * 1000f;
			if ((_WSPDelayTotalTime = num10 + _WSPDelayTotalTime) > _delayBetweenWSP)
			{
				int accumulatedRosaries = _AccumulatedRosaries - 1;
				_AccumulatedRosaries = accumulatedRosaries;
				_isPlayingWSP = true;
				PlayWSP();
			}
		}
	}

	private unsafe void PlayWSP()
	{
		exe_FadeInBG();
		exe_RigthSpear();
		Action action = exe_LeftSpear;
		action._002Ector(this, (nint)__ldftn(SantaJavelin2Weapon.exe_LeftSpear));
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(1f, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete = exe_CentralSpear;
		Timer timer2 = Timers.Register(2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete2 = exe_Explode;
		Timer timer3 = Timers.Register(4f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void AlternateBackgrounds()
	{
		//IL_00e3: Expected I, but got O
		//IL_0155: Expected O, but got I4
		//IL_01ee: Expected I, but got O
		//IL_0260: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (!config._003CFlashingVFXEnabled_003Ek__BackingField)
		{
			return;
		}
		PhaserSprite phaserSprite = _darkBackground.setAlpha(0.65f);
		PhaserSprite phaserSprite2 = _lightBackground.setAlpha(0f);
		if (_tween1 != null)
		{
			_tween1.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_darkBackground != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.yoyo = true;
		tweenConfig.duration = 200f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween1 = tween;
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_lightBackground != null)
		{
			nint num2 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.yoyo = true;
		tweenConfig2.duration = 200f;
		tweenConfig2.alpha = (float?)(object)1;
		MultiTargetTween tween2 = Tweens.Add(tweenConfig2);
		_tween2 = tween2;
	}

	private unsafe void WSPDamage()
	{
		//IL_0093: Expected O, but got I4
		//IL_0512: Expected O, but got I4
		//IL_0a5c: Expected I, but got O
		//IL_0a72: Expected O, but got I
		//IL_0a7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a80: Expected O, but got Unknown
		//IL_0677: Expected I, but got O
		//IL_0aa6: Expected O, but got I4
		//IL_0abd: Expected I, but got I8
		//IL_04de: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e3: Expected O, but got Unknown
		//IL_04ee: Expected O, but got I4
		//IL_0ae7: Expected I, but got O
		//IL_0afd: Expected O, but got I
		//IL_0b06: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b0b: Expected O, but got Unknown
		//IL_0660: Expected I, but got I8
		//IL_0745: Expected I, but got O
		//IL_0b3f: Expected I, but got I8
		//IL_0222: Expected F4, but got O
		//IL_0244: Invalid comparison between F4 and I4
		//IL_025c: Invalid comparison between F4 and O
		//IL_0285: Expected I, but got O
		//IL_072e: Expected I, but got I8
		//IL_02c5: Invalid comparison between F4 and I4
		//IL_02f7: Expected I, but got O
		//IL_01d1: Expected I, but got O
		//IL_01f0: Expected O, but got I4
		//IL_031e: Invalid comparison between F4 and I4
		//IL_034b: Expected I, but got O
		//IL_0b69: Expected I, but got O
		//IL_0b7f: Expected O, but got I
		//IL_0b88: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8d: Expected O, but got Unknown
		//IL_085e: Expected I, but got O
		//IL_038f: Invalid comparison between F4 and I4
		//IL_03b8: Expected O, but got I4
		//IL_03ef: Expected I, but got O
		//IL_0bb3: Expected O, but got I4
		//IL_0bca: Expected I, but got I8
		//IL_040e: Expected F4, but got I
		//IL_041f: Invalid comparison between F4 and I
		//IL_0bf4: Expected I, but got O
		//IL_0c0a: Expected O, but got I
		//IL_0c13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c18: Expected O, but got Unknown
		//IL_0847: Expected I, but got I8
		//IL_09be: Expected I, but got O
		//IL_0931: Expected I, but got O
		//IL_0c4c: Expected I, but got I8
		//IL_0904: Expected I, but got I8
		//IL_04a4: Expected O, but got F4
		//IL_04c8: Expected O, but got I4
		//IL_04d0: Expected I, but got F4
		_003C_003Ec__DisplayClass35_0 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass35_0();
		GameManager core = GM.Core;
		Stage stage = core._stage;
		List<Transform> gemTS = new List<Transform>();
		CS_0024_003C_003E8__locals11.gemTS = gemTS;
		List<Pickup> gems = new List<Pickup>();
		CS_0024_003C_003E8__locals11.gems = gems;
		nint num = 0;
		List<EnemyController> spawnedEnemies = stage._spawnedEnemies;
		bool flag = (nint)stage._spawnedEnemies < 0;
		object obj = spawnedEnemies._size - 1;
		float x = default(float);
		if (!flag)
		{
			Action<Pickup> action2 = default(Action<Pickup>);
			Action<Pickup> action = action2;
			float num3 = default(float);
			float num2 = num3;
			float num4 = default(float);
			x = num4;
			object obj3 = default(object);
			object obj2 = obj3;
			float num6 = default(float);
			float num5 = num6;
			object obj4 = default(object);
			float num8 = default(float);
			float num11 = default(float);
			object obj6;
			do
			{
				List<EnemyController> spawnedEnemies2 = stage._spawnedEnemies;
				bool flag2;
				if ((nint)obj < spawnedEnemies2._size)
				{
					EnemyController[] items = spawnedEnemies2._items;
					Component component = items[obj];
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rbx_v18 (UnityEngine.Component)+260]");
					flag2 = (nint)0 < (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rbx_v18 (UnityEngine.Component)+260]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rbx_v18 (UnityEngine.Component)+20C]");
						if ((nint)0 != 0)
						{
							flag2 = (nint)obj4 < 0;
							if ((nint)obj4 > 0)
							{
								num5 = (((Weapon)this)._003CStatsInflictedDamage_003Ek__BackingField = ((Weapon)this)._003CStatsInflictedDamage_003Ek__BackingField + 66f);
								num = (nint)component;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v637 @ rdx_v35 (Il2CppMethodInfo)+3E8] (should have been resolved before IL gen)");
								x = 66f;
								obj2 = 0;
								goto IL_04d5;
							}
						}
						Transform transform = component.transform;
						Vector3 position = transform.position;
						x = (float)stage._containmentScreenRect;
						float num7 = position.x - (float)stage._containmentScreenRect;
						flag2 = num7 < 0f;
						float x2 = position.x;
						Rect containmentScreenRect = stage._containmentScreenRect;
						bool flag3 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x2) < System.Runtime.CompilerServices.Unsafe.As<Rect, UIntPtr>(ref containmentScreenRect);
						num2 = position.x;
						num5 = position.x;
						num = (nint)transform;
						if (!flag3)
						{
							num5 = num8 + (float)stage._containmentScreenRect;
							float num9 = num5 - position.x;
							flag2 = num9 < 0f;
							bool flag4 = !(num5 > position.x);
							num2 = position.x;
							num = (nint)transform;
							if (!flag4)
							{
								float num10 = num11 - num8;
								flag2 = num10 < 0f;
								bool flag5 = num11 < num8;
								num2 = num11;
								num5 = num8;
								num = (nint)transform;
								if (!flag5)
								{
									num5 = num8 + num8;
									bool flag6 = num5 < num11;
									float num12 = num5 - num11;
									bool flag7 = num12 == 0f;
									bool flag8 = !flag6;
									bool flag9 = !flag7;
									object obj5 = flag9 & flag8;
									flag2 = (nint)obj5 < 0;
									bool flag10 = obj5 == null;
									num2 = num11;
									x = num8;
									num = (nint)transform;
									if (!flag10)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rbx_v18 (UnityEngine.Component)+1EC]");
										float num13 = 0f;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rbx_v18 (UnityEngine.Component)+1EC]");
										if (66f > 0f)
										{
											num13 = 66f;
										}
										num5 = (((Weapon)this)._003CStatsInflictedDamage_003Ek__BackingField = num13 + ((Weapon)this)._003CStatsInflictedDamage_003Ek__BackingField);
										nint num14 = (nint)component;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1298 @ rdx_v38 (Il2CppClass<UnityEngine.Component>)+3E8] (should have been resolved before IL gen)");
										Action<Pickup> action3 = CS_0024_003C_003E8__locals11._003C_003E9__8;
										if (CS_0024_003C_003E8__locals11._003C_003E9__8 == null)
										{
											action3 = (CS_0024_003C_003E8__locals11._003C_003E9__8 = delegate(Pickup gem)
											{
												if ((object)gem != null && ((UnityEngine.Object)gem).m_CachedPtr != (IntPtr)0)
												{
													Transform transform2 = gem.transform;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049F4B0");
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA3FE0");
													gem._003CDisableGet_003Ek__BackingField = true;
												}
											});
										}
										flag2 = (nint)GM.Core < 0;
										GM.Core.MakeGem((Vector2)num8, 1f, action3);
										action = action3;
										num2 = 1f;
										x = num8;
										obj2 = 0;
										num = (nint)num8;
									}
								}
							}
						}
					}
					goto IL_04d5;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				throw new NullReferenceException();
				IL_04d5:
				obj--;
				obj6 = !flag2;
				num6 = num5;
			}
			while (obj6 != null);
		}
		CS_0024_003C_003E8__locals11.offset = (Vector3)0;
		_ = 0;
		CS_0024_003C_003E8__locals11.angle = 0f;
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		((_003C_003Ec__DisplayClass35_0)(object)dOSetter)._003CWSPDamage_003Eb__1(x);
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 360f, 0.3f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v724 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v724 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v724 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v724 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+A0]");
						float num6 = 0f * 5f;
					}
				}
			}
		}
		TweenCallback tweenCallback = null;
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v923 @ r10_v1 (Il2CppMethodInfo)+8]");
		((Delegate)tweenCallback).method_ptr = (IntPtr)0;
		((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass35_0._003CWSPDamage_003Eb__2);
		((Delegate)tweenCallback).m_target = CS_0024_003C_003E8__locals11;
		((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v923 @ r10_v1 (Il2CppMethodInfo)+4C]");
		object obj7 = (nint)0 >> 4;
		object obj8 = obj7 & 1;
		nint num16;
		if (obj8 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v923 @ r10_v1 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num16 = unchecked((nint)6447293664L);
				goto IL_0a9d;
			}
		}
		((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
		num16 = ((Delegate)tweenCallback).method_ptr;
		goto IL_0a9d;
		IL_0a9d:
		object obj9 = 24;
		((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v724 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		TweenCallback tweenCallback2 = null;
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1139 @ r10_v2 (Il2CppMethodInfo)+8]");
		((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
		((Delegate)tweenCallback2).method = (nint)__ldftn(_003C_003Ec__DisplayClass35_0._003CWSPDamage_003Eb__3);
		((Delegate)tweenCallback2).m_target = CS_0024_003C_003E8__locals11;
		((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1139 @ r10_v2 (Il2CppMethodInfo)+4C]");
		object obj10 = (nint)0 >> 4;
		object obj11 = obj10 & 1;
		nint num18;
		if (obj11 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1139 @ r10_v2 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num18 = unchecked((nint)6447293664L);
				goto IL_0b28;
			}
		}
		((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
		num18 = ((Delegate)tweenCallback2).method_ptr;
		goto IL_0b28;
		IL_0b28:
		((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v724 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		DOGetter<float> getter2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter2 = null;
		((_003C_003Ec__DisplayClass35_0)(object)dOSetter2)._003CWSPDamage_003Eb__5(x);
		TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter2, dOSetter2, 0.04f, 0.5f);
		TweenCallback tweenCallback3 = null;
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1449 @ r10_v3 (Il2CppMethodInfo)+8]");
		((Delegate)tweenCallback3).method_ptr = (IntPtr)0;
		((Delegate)tweenCallback3).method = (nint)__ldftn(_003C_003Ec__DisplayClass35_0._003CWSPDamage_003Eb__6);
		((Delegate)tweenCallback3).m_target = CS_0024_003C_003E8__locals11;
		((Delegate)tweenCallback3).method_code = (IntPtr)tweenCallback3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1449 @ r10_v3 (Il2CppMethodInfo)+4C]");
		object obj12 = (nint)0 >> 4;
		object obj13 = obj12 & 1;
		nint num20;
		if (obj13 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1449 @ r10_v3 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num20 = unchecked((nint)6447293664L);
				goto IL_0baa;
			}
		}
		((Delegate)tweenCallback3).method_code = (IntPtr)((Delegate)tweenCallback3).m_target;
		num20 = ((Delegate)tweenCallback3).method_ptr;
		goto IL_0baa;
		IL_0c35:
		TweenCallback tweenCallback4;
		((Delegate)tweenCallback4).extra_arg = unchecked((nint)6447293568L);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1445 @ rax_v38 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		return;
		IL_0baa:
		object obj14 = 24;
		((Delegate)tweenCallback3).extra_arg = unchecked((nint)6447293568L);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1445 @ rax_v38 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		tweenCallback4 = null;
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v417 @ r10_v4 (Il2CppMethodInfo)+8]");
		((Delegate)tweenCallback4).method_ptr = (IntPtr)0;
		((Delegate)tweenCallback4).method = (nint)__ldftn(_003C_003Ec__DisplayClass35_0._003CWSPDamage_003Eb__7);
		((Delegate)tweenCallback4).m_target = CS_0024_003C_003E8__locals11;
		((Delegate)tweenCallback4).method_code = (IntPtr)tweenCallback4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v417 @ r10_v4 (Il2CppMethodInfo)+4C]");
		object obj15 = (nint)0 >> 4;
		object obj16 = obj15 & 1;
		nint num22;
		if (obj16 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v417 @ r10_v4 (Il2CppMethodInfo)+52]");
			bool flag11 = (nint)0 == 0;
			num22 = unchecked((nint)6447293664L);
			if (flag11)
			{
				goto IL_0c35;
			}
		}
		num22 = ((Delegate)tweenCallback4).method_ptr;
		((Delegate)tweenCallback4).method_code = (IntPtr)((Delegate)tweenCallback4).m_target;
		goto IL_0c35;
	}

	private void PlaySFX(float vol1 = 1.8f, float vol2 = 0.5f)
	{
		//IL_00a3: Expected O, but got I4
		//IL_0041: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Rosary, soundConfig, 500f, 4, time);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 1f;
		soundConfig2.Detune = -1000f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.sfx_javelin, soundConfig2, 200f, 12, time);
	}

	private unsafe void exe_FadeInBG()
	{
		//IL_0261: Expected O, but got Ref
		//IL_02bc: Expected O, but got Ref
		//IL_0448: Expected I, but got O
		//IL_03c0->IL047b: Incompatible stack heights: 19 vs 0
		//IL_0436->IL047b: Incompatible stack heights: 19 vs 0
		//IL_0414->IL0414: Incompatible stack heights: 20 vs 19
		if ((object)_RingTransform != null)
		{
			Transform transform = _RingTransform.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			Transform transform2 = _Ring2Transform.transform;
			bool flag2 = (object)transform2 == null;
			bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			Vector3 value2 = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
			bool flag4 = (object)_RingMesh == null;
			Material material = ((Renderer)_RingMesh).GetMaterial();
			TweenerCore<float, float, FloatOptions> tweenerCore = ShortcutExtensions.DOFloat(material, _modelMaterialAlpha, _AlphaMul, 0.05f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			bool flag5 = tweenerCore == null;
			bool flag6 = (object)_RingMesh == null;
			Material material2 = ((Renderer)_RingMesh).GetMaterial();
			bool flag7 = (object)material2 == null;
			material2.SetFloatImpl(_ScrollSpeedX, 0.5f);
			bool flag8 = (object)_RingMesh == null;
			Material material3 = ((Renderer)_RingMesh).GetMaterial();
			bool flag9 = (object)material3 == null;
			material3.SetFloatImpl(_ScrollSpeedY, 0.5f);
			bool flag10 = (object)_Ring2Mesh == null;
			Material material4 = ((Renderer)_Ring2Mesh).GetMaterial();
			TweenerCore<float, float, FloatOptions> tweenerCore2 = ShortcutExtensions.DOFloat(material4, _modelMaterialAlpha, _AlphaMul, 0.05f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			bool flag11 = tweenerCore2 == null;
			bool flag12 = (object)_Ring2Mesh == null;
			Material material5 = ((Renderer)_Ring2Mesh).GetMaterial();
			bool flag13 = (object)material5 == null;
			material5.SetFloatImpl(_ScrollSpeedX, 0.5f);
			bool flag14 = (object)_Ring2Mesh == null;
			Material material6 = ((Renderer)_Ring2Mesh).GetMaterial();
			bool flag15 = (object)material6 == null;
			material6.SetFloatImpl(_ScrollSpeedY, 0.5f);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOScale(_RingTransform, (Vector3)(&value), 0.5f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			bool flag16 = tweenerCore3 == null;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore4 = ShortcutExtensions.DOScale(_Ring2Transform, (Vector3)(&value), 0.5f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			bool flag17 = tweenerCore4 == null;
			bool flag18 = (object)_darkBackground == null;
			PhaserSprite phaserSprite = _darkBackground.setAlpha(0f);
			bool flag19 = (object)_lightBackground == null;
			PhaserSprite phaserSprite2 = _lightBackground.setAlpha(0f);
			if (_tween1 != null)
			{
				_tween1.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if (array != null)
			{
				if ((object)_darkBackground != null)
				{
					void* value3 = ((IntPtr*)(&array))->m_value;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj = default(object);
					bool flag20 = obj == null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig != null)
				{
					((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
					_ = 1132068864;
					_ = 1;
					MultiTargetTween tween = Tweens.Add(tweenConfig);
					_tween1 = tween;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void exe_RigthSpear()
	{
		//IL_02c7: Expected O, but got Ref
		//IL_00d1: Expected O, but got Ref
		//IL_038c: Expected O, but got Ref
		object obj = default(object);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_RingTransform, (Vector3)(&obj), 0.2f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 1;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
						_ = 0;
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(_Ring2Transform, (Vector3)(&obj), 0.2f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 1;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
						_ = 0;
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Transform transform = _spearRTransform.transform;
		if (((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0)
		{
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOLocalMove(_spearRTransform, (Vector3)(&obj), 0.2f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore4 = ShortcutExtensions.DOScaleZ(_spearRTransform, 8f, 0.2f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Material material = ((Renderer)_spearRMesh).GetMaterial();
			TweenerCore<float, float, FloatOptions> tweenerCore5 = ShortcutExtensions.DOFloat(material, _modelMaterialAlpha, _AlphaMul, 0.2f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			AlternateBackgrounds();
			Action onComplete = delegate
			{
				PlaySFX(1.5f, 1f);
				WSPDamage();
				ScreenShake();
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			return;
		}
		UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
		throw new NullReferenceException();
	}

	private unsafe void exe_LeftSpear()
	{
		//IL_02c7: Expected O, but got Ref
		//IL_00d1: Expected O, but got Ref
		//IL_038c: Expected O, but got Ref
		object obj = default(object);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_RingTransform, (Vector3)(&obj), 0.2f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 1;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
						_ = 0;
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(_Ring2Transform, (Vector3)(&obj), 0.2f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 1;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
						_ = 0;
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Transform transform = _spearLTransform.transform;
		if (((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0)
		{
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOLocalMove(_spearLTransform, (Vector3)(&obj), 0.2f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore4 = ShortcutExtensions.DOScaleZ(_spearLTransform, 8f, 0.2f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Material material = ((Renderer)_spearLMesh).GetMaterial();
			TweenerCore<float, float, FloatOptions> tweenerCore5 = ShortcutExtensions.DOFloat(material, _modelMaterialAlpha, _AlphaMul, 0.2f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			AlternateBackgrounds();
			Action onComplete = delegate
			{
				PlaySFX(1.5f, 1f);
				WSPDamage();
				ScreenShake();
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			return;
		}
		UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
		throw new NullReferenceException();
	}

	private unsafe void exe_CentralSpear()
	{
		//IL_02c7: Expected O, but got Ref
		//IL_00d1: Expected O, but got Ref
		//IL_038c: Expected O, but got Ref
		object obj = default(object);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_RingTransform, (Vector3)(&obj), 0.2f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 1;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
						_ = 0;
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(_Ring2Transform, (Vector3)(&obj), 0.2f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 1;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
						_ = 0;
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Transform transform = _spearCTransform.transform;
		if (((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0)
		{
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOLocalMove(_spearCTransform, (Vector3)(&obj), 0.2f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore4 = ShortcutExtensions.DOScaleZ(_spearCTransform, 10f, 0.2f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Material material = ((Renderer)_spearCMesh).GetMaterial();
			TweenerCore<float, float, FloatOptions> tweenerCore5 = ShortcutExtensions.DOFloat(material, _modelMaterialAlpha, _AlphaMul, 0.2f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			AlternateBackgrounds();
			Action onComplete = delegate
			{
				PlaySFX(1.5f, 1f);
				WSPDamage();
				ScreenShake(48f);
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			return;
		}
		UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
		throw new NullReferenceException();
	}

	private unsafe void exe_Explode()
	{
		//IL_0008: Expected O, but got Ref
		//IL_015b: Expected O, but got Ref
		//IL_01db: Expected O, but got Ref
		//IL_09f9: Expected O, but got Ref
		//IL_00e2: Expected O, but got Ref
		//IL_031f: Expected O, but got Ref
		//IL_0420: Expected O, but got Ref
		//IL_0521: Expected O, but got Ref
		//IL_06ec: Expected I, but got O
		//IL_077d: Expected O, but got I
		//IL_087e: Expected I, but got O
		//IL_091d: Expected O, but got I
		//IL_0a3e->IL098f: Incompatible stack heights: 1 vs 0
		//IL_0123->IL098f: Incompatible stack heights: 1 vs 0
		//IL_014d->IL014d: Incompatible stack heights: 1 vs 0
		//IL_070f->IL070f: Incompatible stack heights: 1 vs 0
		//IL_08a1->IL08a1: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		PlaySFX(1.8f, 0.35f);
		WSPDamage();
		ScreenShake(48f, 2f);
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null)
			{
				if (!config._003CFlashingVFXEnabled_003Ek__BackingField)
				{
					goto IL_014d;
				}
				Camera main = Camera.main;
				if ((object)main != null)
				{
					Transform transform = main.transform;
					if ((object)transform != null)
					{
						_ = 0;
						_ = 0;
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-11]");
						_ = 0;
						ObjectPool pool = HeroVfxManager.GetPool(HeroVfxType.RosaryVfx);
						if ((object)pool != null)
						{
							Vector3 position = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
							_ = 0;
							RosaryVfx objectComponent = pool.GetObjectComponent<RosaryVfx>(position);
							if ((object)objectComponent != null)
							{
								objectComponent.SetParent(transform);
								objectComponent.Play(0f);
								goto IL_014d;
							}
						}
					}
				}
			}
		}
		goto IL_098f;
		IL_098f:
		throw new NullReferenceException();
		IL_014d:
		Vector3 endValue = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		float num = _defaultSkyScale * 4f;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_RingTransform, endValue, 0.25f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (tweenerCore != null)
		{
			Vector3 endValue2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(_Ring2Transform, endValue2, 0.25f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (tweenerCore2 != null && (object)_RingMesh != null)
			{
				Material material = ((Renderer)_RingMesh).GetMaterial();
				TweenerCore<float, float, FloatOptions> tweenerCore3 = ShortcutExtensions.DOFloat(material, 0f, _AlphaMul, 0.5f);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				if (tweenerCore3 != null && (object)_Ring2Mesh != null)
				{
					Material material2 = ((Renderer)_Ring2Mesh).GetMaterial();
					TweenerCore<float, float, FloatOptions> tweenerCore4 = ShortcutExtensions.DOFloat(material2, 0f, _AlphaMul, 0.5f);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					if (tweenerCore4 != null)
					{
						Vector3 endValue3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
						_ = 0;
						TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore5 = ShortcutExtensions.DOLocalMove(_spearRTransform, endValue3, 0.2f);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						if (tweenerCore5 != null && (object)_spearRMesh != null)
						{
							Material material3 = ((Renderer)_spearRMesh).GetMaterial();
							TweenerCore<float, float, FloatOptions> tweenerCore6 = ShortcutExtensions.DOFloat(material3, 0f, _AlphaMul, 0.2f);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							if (tweenerCore6 != null)
							{
								Vector3 endValue4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
								_ = 0;
								TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore7 = ShortcutExtensions.DOLocalMove(_spearLTransform, endValue4, 0.2f);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
								if ((nint)0 == 0)
								{
									_ = 1;
								}
								if (tweenerCore7 != null && (object)_spearLMesh != null)
								{
									Material material4 = ((Renderer)_spearLMesh).GetMaterial();
									TweenerCore<float, float, FloatOptions> tweenerCore8 = ShortcutExtensions.DOFloat(material4, 0f, _AlphaMul, 0.2f);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
									if ((nint)0 == 0)
									{
										_ = 1;
									}
									if (tweenerCore8 != null)
									{
										Vector3 endValue5 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
										_ = 0;
										TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore9 = ShortcutExtensions.DOLocalMove(_spearCTransform, endValue5, 0.2f);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
										if ((nint)0 == 0)
										{
											_ = 1;
										}
										if (tweenerCore9 != null && (object)_spearCMesh != null)
										{
											Material material5 = ((Renderer)_spearCMesh).GetMaterial();
											TweenerCore<float, float, FloatOptions> tweenerCore10 = ShortcutExtensions.DOFloat(material5, 0f, _AlphaMul, 0.2f);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
											if ((nint)0 == 0)
											{
												_ = 1;
											}
											if (tweenerCore10 != null)
											{
												Action onComplete = delegate
												{
													_WSPDelayTotalTime = 0f;
													_isPlayingWSP = false;
												};
												bool useRealTime = default(bool);
												MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
												int repeat = default(int);
												TimerType type = default(TimerType);
												Timer timer = Timers.Register(0.2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
												if (_tween1 != null)
												{
													_tween1.Kill();
												}
												TweenConfig tweenConfig = new TweenConfig();
												object[] array = new object[1];
												if (array != null)
												{
													if ((object)_darkBackground != null)
													{
														nint num2 = (nint)array;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														object obj4 = default(object);
														bool flag2 = obj4 == null;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													if (tweenConfig != null)
													{
														tweenConfig.targets = array;
														_ = 0;
														tweenConfig.duration = 200f;
														_ = 0;
														_ = 1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
														tweenConfig.alpha = (float?)(object)0;
														TweenCallback onStop = delegate
														{
															PhaserSprite phaserSprite = _darkBackground.setAlpha(0f);
														};
														tweenConfig.onStop = onStop;
														TweenCallback onComplete2 = delegate
														{
															PhaserSprite phaserSprite = _darkBackground.setAlpha(0f);
														};
														tweenConfig.onComplete = onComplete2;
														MultiTargetTween tween = Tweens.Add(tweenConfig);
														_tween1 = tween;
														if (_tween2 != null)
														{
															_tween2.Kill();
														}
														TweenConfig tweenConfig2 = new TweenConfig();
														object[] array2 = new object[1];
														if (array2 != null)
														{
															if ((object)_lightBackground != null)
															{
																nint num3 = (nint)array2;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj5 = default(object);
																bool flag3 = obj5 == null;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if (tweenConfig2 != null)
															{
																tweenConfig2.targets = array2;
																_ = 0;
																tweenConfig2.duration = 200f;
																tweenConfig2.yoyo = true;
																_ = 1059481190;
																_ = 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
																tweenConfig2.alpha = (float?)(object)0;
																TweenCallback onStop2 = delegate
																{
																	PhaserSprite phaserSprite = _lightBackground.setAlpha(0f);
																};
																tweenConfig2.onStop = onStop2;
																TweenCallback onComplete3 = delegate
																{
																	PhaserSprite phaserSprite = _lightBackground.setAlpha(0f);
																};
																tweenConfig2.onComplete = onComplete3;
																MultiTargetTween tween2 = Tweens.Add(tweenConfig2);
																_tween2 = tween2;
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
		goto IL_098f;
	}

	private void OnWSPComplete()
	{
		_WSPDelayTotalTime = 0f;
		_isPlayingWSP = false;
	}

	protected void ScreenShake(float duration = 24f, float strength = 1f)
	{
		//IL_00ce: Expected I, but got O
		//IL_014d: Expected O, but got I4
		_003C_003Ec__DisplayClass43_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass43_0();
		CS_0024_003C_003E8__locals2.strength = strength;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (!config._003CScreenShakeEnabled_003Ek__BackingField)
		{
			return;
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.CameraSet cameras = s_scene.cameras;
		PhaserCamera main = cameras.main;
		if (main.followOffset != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = duration;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = 12;
		tweenConfig.x = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras2 = s_scene2.cameras;
			PhaserCamera main2 = cameras2.main;
			PhaserScene.BoxedVector2 followOffset = main2.followOffset;
			float x = CS_0024_003C_003E8__locals2.strength * -3f;
			followOffset.x = x;
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = _003C_003Ec._003C_003E9__43_1;
		if (_003C_003Ec._003C_003E9__43_1 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__43_1 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.x = 0f;
				followOffset.y = 0f;
			});
		}
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	public override void Cleanup()
	{
		base.Cleanup();
		PhaserSprite darkBackground = _darkBackground;
		if ((object)_darkBackground != null && ((UnityEngine.Object)darkBackground).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite = _darkBackground.setVisible(visible: false);
		}
		PhaserSprite lightBackground = _lightBackground;
		if ((object)_lightBackground != null && ((UnityEngine.Object)lightBackground).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite2 = _lightBackground.setVisible(visible: false);
		}
		GameObject gameObject = _RingTransform.gameObject;
		if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject2 = _RingTransform.gameObject;
			gameObject2.SetActive(value: false);
		}
		GameObject gameObject3 = _Ring2Transform.gameObject;
		if ((object)gameObject3 != null && ((UnityEngine.Object)gameObject3).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject4 = _Ring2Transform.gameObject;
			gameObject4.SetActive(value: false);
		}
		GameObject gameObject5 = _spearCTransform.gameObject;
		if ((object)gameObject5 != null && ((UnityEngine.Object)gameObject5).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject6 = _spearCTransform.gameObject;
			gameObject6.SetActive(value: false);
		}
		GameObject gameObject7 = _spearLTransform.gameObject;
		if ((object)gameObject7 != null && ((UnityEngine.Object)gameObject7).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject8 = _spearLTransform.gameObject;
			gameObject8.SetActive(value: false);
		}
		GameObject gameObject9 = _spearRTransform.gameObject;
		if ((object)gameObject9 != null && ((UnityEngine.Object)gameObject9).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject10 = _spearRTransform.gameObject;
			gameObject10.SetActive(value: false);
		}
	}

	public unsafe override void ForcedFire(bool hasTarget, Vector3 position, bool skipTriggers = false)
	{
		//IL_02de: Expected O, but got Ref
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Expected Ref, but got Unknown
		//IL_0352: Expected O, but got Ref
		Vector3 ret = default(Vector3);
		Vector3 vector = Fire_FireProjectiles(hasTarget, (Vector3)(&ret));
		Camera main = Camera.main;
		Bounds bounds = CameraExtensions.OrthographicBounds(main);
		object obj = default(object);
		float num = (float)obj * 2f;
		float num2 = num * 0.75f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v8 (UnityEngine.Bounds)+10]");
		float num3 = 0f * 2f;
		float num4 = num3 * 0.85f;
		float num5 = (float)obj * 2f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v8 (UnityEngine.Bounds)+10]");
		float num6 = 0f * 2f;
		object obj2 = (object)bounds.m_Center - obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v8 (UnityEngine.Bounds)+10]");
		object obj3 = obj - 0;
		Rectangle rectangle = new Rectangle();
		float num7 = num5 - num2;
		float num8 = num6 - num4;
		rectangle._width = num2;
		rectangle._height = num4;
		float num9 = num7 * 0.5f;
		float num10 = num8 * 0.5f;
		float x = num9 + (float)obj2;
		float y = num10 + (float)obj3;
		rectangle._x = x;
		rectangle._y = y;
		GameManager core = GM.Core;
		if ((object)GM.Core != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null && (object)core._stage != null)
		{
			ref Unity.Mathematics.Random rng = ref *(Unity.Mathematics.Random*)(((Equipment)this)._003COwner_003Ek__BackingField + 176);
			Transform targetTransform = core._stage.PickRandomEnemyInRectBounds(rectangle, ref rng);
			_targetTransform = targetTransform;
			Camera targetTransform2 = (Camera)(object)_targetTransform;
			if ((object)_targetTransform == null || ((UnityEngine.Object)targetTransform2).m_CachedPtr == (IntPtr)0)
			{
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
				{
					goto IL_02c8;
				}
				Transform targetTransform3 = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
				_targetTransform = targetTransform3;
			}
			Camera targetTransform4 = (Camera)(object)_targetTransform;
			if ((object)_targetTransform != null)
			{
				bool flag = ((UnityEngine.Object)targetTransform4).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)targetTransform4).m_CachedPtr, out ret);
				object obj4 = default(object);
				Fire_FireCounter((Vector3)(&obj4), skipTriggers);
				return;
			}
		}
		goto IL_02c8;
		IL_02c8:
		throw new NullReferenceException();
	}

	protected unsafe override Vector3 Fire_FireProjectiles(bool hasTarget, Vector3 position, bool skipTriggers = false)
	{
		//IL_028d: Expected native int or pointer, but got O
		//IL_029b: Expected native int or pointer, but got O
		//IL_003d: Invalid comparison between O and F4
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Expected O, but got Unknown
		//IL_0210: Invalid comparison between O and F4
		//IL_0065: Expected O, but got I4
		//IL_023b: Expected F4, but got O
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		//IL_00b4: Expected I4, but got O
		//IL_00fa: Expected I4, but got O
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Expected O, but got Unknown
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = 0f;
		((Vector3*)(nint)vector)->z = 0f;
		Vector2 vector3;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Vector2 vector2 = default(Vector2);
			Projectile projectile = base.FireOneProjectile(vector2, 0);
			float num = PAmount();
			bool flag = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
			vector3 = vector2;
			if (flag)
			{
				goto IL_01d7;
			}
			Action<float> action = (Action<float>)1;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			while (true)
			{
				WeaponData currentWeaponData = _currentWeaponData;
				if (_currentWeaponData == null)
				{
					break;
				}
				object obj = action * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
				if ((nint)obj <= 0)
				{
					Vector2 playerPos = base.PlayerPos;
					Projectile projectile2 = base.FireOneProjectile(playerPos, (int)action);
				}
				else
				{
					_003C_003Ec__DisplayClass46_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass46_0();
					if (CS_0024_003C_003E8__locals7 == null)
					{
						break;
					}
					CS_0024_003C_003E8__locals7._003C_003E4__this = this;
					CS_0024_003C_003E8__locals7.localIndex = (int)action;
					WeaponData currentWeaponData2 = _currentWeaponData;
					if (_currentWeaponData == null)
					{
						break;
					}
					Action onComplete = delegate
					{
						//IL_0106: Expected O, but got I4
						//IL_00b4: Expected O, but got I
						//IL_00c0: Expected I, but got O
						//IL_0079->IL00cf: Incompatible stack heights: 1 vs 0
						//IL_009e->IL00cf: Incompatible stack heights: 1 vs 0
						if ((object)CS_0024_003C_003E8__locals7._003C_003E4__this != null)
						{
							GameObject gameObject = CS_0024_003C_003E8__locals7._003C_003E4__this.gameObject;
							if ((object)gameObject != null)
							{
								bool flag3 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
								object obj4 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
								if (obj4 == null)
								{
									return;
								}
								GameObject gameObject2 = (GameObject)(object)CS_0024_003C_003E8__locals7._003C_003E4__this;
								if ((object)CS_0024_003C_003E8__locals7._003C_003E4__this != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rdi_v7 (UnityEngine.GameObject)+58]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rdi_v7 (UnityEngine.GameObject)+58]");
										float2 position3 = ((ArcadeSprite)0).position;
										nint num6 = (nint)gameObject2;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v229 @ r10_v2 (Il2CppClass<UnityEngine.GameObject>)+4D8] (should have been resolved before IL gen)");
										return;
									}
								}
							}
						}
						throw new NullReferenceException();
					};
					float num2 = (float)action * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
					float duration = num2 * 0.001f;
					Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_lastShotTimer = lastShotTimer;
				}
				action = (Action<float>)(action + 1);
				bool flag2 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector2) > System.Runtime.CompilerServices.Unsafe.As<Action<float>, UIntPtr>(ref action);
				vector3 = (Vector2)action;
				if (flag2)
				{
					continue;
				}
				goto IL_01d7;
			}
		}
		goto IL_0276;
		IL_0276:
		return (Vector3)new NullReferenceException();
		IL_01d7:
		float num3 = base.PInterval();
		float num4 = _lastFiringInterval - (float)vector3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj2 = num4 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num5 = base.PInterval();
			_lastFiringInterval = (float)vector3;
			ResetFiringTimer();
		}
		object obj3 = default(object);
		if (obj3 == null)
		{
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
			{
				goto IL_0276;
			}
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
		return vector;
	}

	protected override void OnStart()
	{
		base.OnStart();
		if (!_generatedPools)
		{
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.SANTAJAVELIN2EXPLO);
			BulletPool tvExplosionPool = new BulletPool(projectilePrefab);
			_tvExplosionPool = tvExplosionPool;
			_generatedPools = true;
		}
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		ArcadePhysicsCallback collideCallback = OnMinorBulletOverlapsEnemy;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_tvExplosionPool, core.Enemies, collideCallback, processCallback, callbackContext);
	}

	protected override void OnPause()
	{
		//IL_0045->IL00a7: Incompatible stack heights: 2 vs 0
		List<MeshRenderer>.Enumerator enumerator = default(List<MeshRenderer>.Enumerator);
		while (enumerator.MoveNext())
		{
			Material material = null;
			bool flag = ((UnityEngine.Object)material).m_CachedPtr == (IntPtr)0;
			IntPtr material_Injected = Renderer.GetMaterial_Injected(((UnityEngine.Object)material).m_CachedPtr);
			Material material2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Material>(material_Injected);
			bool flag2 = (object)material2 == null;
			int num = Shader.PropertyToID("_IsPaused");
			material2.SetFloatImpl(num, 1f);
		}
	}

	protected override void OnResume()
	{
		//IL_0045->IL00a7: Incompatible stack heights: 2 vs 0
		List<MeshRenderer>.Enumerator enumerator = default(List<MeshRenderer>.Enumerator);
		while (enumerator.MoveNext())
		{
			Material material = null;
			bool flag = ((UnityEngine.Object)material).m_CachedPtr == (IntPtr)0;
			IntPtr material_Injected = Renderer.GetMaterial_Injected(((UnityEngine.Object)material).m_CachedPtr);
			Material material2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Material>(material_Injected);
			bool flag2 = (object)material2 == null;
			int num = Shader.PropertyToID("_IsPaused");
			material2.SetFloatImpl(num, 0f);
		}
	}

	public void SecondaryFireAt(Vector2 targetPos)
	{
		//IL_0023: Invalid comparison between F4 and I4
		//IL_0076: Invalid comparison between F4 and I4
		float num = PAmount();
		object obj = default(object);
		float num2 = (float)obj * 0.5f;
		if (num2 > 0f)
		{
			int num3 = 0;
			float2 pos = default(float2);
			do
			{
				Projectile projectile = _tvExplosionPool.SpawnAt(pos, this, num3);
				num3++;
			}
			while (num2 > (float)num3);
		}
	}

	protected bool OnMinorBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_015c: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_0179;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									float num = PAmount();
									float num2 = PPower();
									object obj = default(object);
									float num3 = (float)obj * 0.5f;
									float damage = (float)obj / num3;
									base.DealDamage(component, damage);
								}
								goto IL_0179;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0179:
		return false;
	}

	static SantaJavelin2Weapon()
	{
		int scrollSpeedX = Shader.PropertyToID("_ScrollSpeedX");
		_ScrollSpeedX = scrollSpeedX;
		int scrollSpeedY = Shader.PropertyToID("_ScrollSpeedY");
		_ScrollSpeedY = scrollSpeedY;
		int alphaMul = Shader.PropertyToID("_AlphaMul");
		_AlphaMul = alphaMul;
	}

	private void _003Cexe_RigthSpear_003Eb__38_0()
	{
		PlaySFX(1.5f, 1f);
		WSPDamage();
		ScreenShake();
	}

	private void _003Cexe_LeftSpear_003Eb__39_0()
	{
		PlaySFX(1.5f, 1f);
		WSPDamage();
		ScreenShake();
	}

	private void _003Cexe_CentralSpear_003Eb__40_0()
	{
		PlaySFX(1.5f, 1f);
		WSPDamage();
		ScreenShake(48f);
	}

	private void _003Cexe_Explode_003Eb__41_0()
	{
		_WSPDelayTotalTime = 0f;
		_isPlayingWSP = false;
	}

	private void _003Cexe_Explode_003Eb__41_1()
	{
		PhaserSprite phaserSprite = _darkBackground.setAlpha(0f);
	}

	private void _003Cexe_Explode_003Eb__41_2()
	{
		PhaserSprite phaserSprite = _darkBackground.setAlpha(0f);
	}

	private void _003Cexe_Explode_003Eb__41_3()
	{
		PhaserSprite phaserSprite = _lightBackground.setAlpha(0f);
	}

	private void _003Cexe_Explode_003Eb__41_4()
	{
		PhaserSprite phaserSprite = _lightBackground.setAlpha(0f);
	}
}
