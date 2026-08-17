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
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_DeathHand_Projectile : Projectile
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__20_0;

		public static TweenCallback _003C_003E9__20_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CScreenShake_003Eb__20_0()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = -2f;
		}

		internal void _003CScreenShake_003Eb__20_1()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = 0f;
			followOffset.y = 0f;
		}
	}

	private bool _isLeftHand;

	private List<PhaserSprite> _armSprites;

	private PhaserSprite _crack;

	private ParticleSystem _rockParticles;

	[NonSerialized]
	public bool _isMoving;

	private float2 _startPosition;

	private float2 _targetPosition;

	private float _moveTween;

	private MultiTargetTween _screenShakeTween;

	private MultiTargetTween _crackTween;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("TP_Death_ClawOpen", "TP_Death");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0008: Expected O, but got Ref
		//IL_08be: Expected O, but got I
		//IL_08f1: Expected O, but got I4
		//IL_0092: Expected O, but got I4
		//IL_019c: Expected O, but got I4
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Expected O, but got Unknown
		//IL_0379: Expected O, but got I4
		//IL_0b72: Expected O, but got I4
		//IL_0a45: Expected O, but got I4
		//IL_0769: Expected O, but got Ref
		//IL_077e: Expected native int or pointer, but got O
		//IL_07b0: Expected O, but got Ref
		//IL_07e4: Expected native int or pointer, but got O
		//IL_0aea->IL0838: Incompatible stack heights: 1 vs 0
		//IL_00d7->IL0838: Incompatible stack heights: 1 vs 0
		//IL_0126->IL0838: Incompatible stack heights: 1 vs 0
		//IL_0155->IL0838: Incompatible stack heights: 1 vs 0
		//IL_0184->IL0838: Incompatible stack heights: 1 vs 0
		//IL_01ba->IL0838: Incompatible stack heights: 1 vs 0
		//IL_020a->IL0838: Incompatible stack heights: 1 vs 0
		//IL_02a1->IL094f: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitProjectile(pool, weapon, index);
		bool isLeftHand = index == 0;
		_isCullable = false;
		_isLeftHand = isLeftHand;
		if ((object)weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
			if (_isLeftHand)
			{
			}
			float2 pos = default(float2);
			base.position = pos;
			float2 float6 = base.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+D0]");
			_targetPosition = (float2)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+D4]");
			_ = 0;
			_isMoving = false;
			_moveTween = 0f;
			ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
			List<PhaserSprite> armSprites = new List<PhaserSprite>();
			_armSprites = armSprites;
			float? num = (float?)(object)0;
			while (true)
			{
				List<object> armSprites2 = (List<object>)(object)_armSprites;
				PhaserWorld instance = PhaserWorld.Instance;
				Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
				if ((object)cachedTrans == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rax_v22 (UnityEngine.Transform)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rax_v22 (UnityEngine.Transform)+10]");
				float2 ret;
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
				if (body != null)
				{
					BaseBody baseBody = body;
					ArcadeTransform arcadeTransform = baseBody._transform;
					if (baseBody._transform == null)
					{
						break;
					}
					arcadeTransform.position = ret;
				}
				if ((object)instance == null)
				{
					break;
				}
				PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "TP_Death", "TP_Death_Joint2");
				if ((object)phaserSprite == null)
				{
					break;
				}
				PhaserSprite phaserSprite2 = phaserSprite.setTint(0u);
				if ((object)phaserSprite2 == null)
				{
					break;
				}
				PhaserSprite phaserSprite3 = phaserSprite2.setAlpha(0f);
				if ((object)phaserSprite3 == null)
				{
					break;
				}
				PhaserSprite item = phaserSprite3.setScale(0.5f, (float?)(object)0);
				if (_armSprites == null)
				{
					break;
				}
				int version = armSprites2._version + 1;
				armSprites2._version = version;
				object[] items = armSprites2._items;
				if (armSprites2._items == null)
				{
					break;
				}
				if (armSprites2._size >= items.Length)
				{
					((List<object>)(object)_armSprites).AddWithResize((object)item);
				}
				else
				{
					int num2 = armSprites2._size + 1;
					armSprites2._size = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				num = (float?)(object)((_003F?)num + 1);
				if ((nint)num >= 20)
				{
					PhaserWorld instance2 = PhaserWorld.Instance;
					float2 float7 = base.position;
					bool flag2 = (object)instance2 == null;
					PhaserSprite phaserSprite4 = instance2.AddPhaserSprite(pos, "vfx", "ground");
					bool flag3 = (object)phaserSprite4 == null;
					PhaserSprite phaserSprite5 = phaserSprite4.setTint(0u);
					bool flag4 = (object)phaserSprite5 == null;
					PhaserSprite phaserSprite6 = phaserSprite5.setAlpha(0f);
					bool flag5 = (object)phaserSprite6 == null;
					PhaserSprite crack = phaserSprite6.setScale(0.5f, (float?)(object)0);
					_crack = crack;
					ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
					List<string> list = new List<string>();
					bool flag6 = list == null;
					int version2 = list._version + 1;
					list._version = version2;
					string[] items2 = list._items;
					bool flag7 = list._items == null;
					if (list._size >= items2.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"rock0000");
					}
					else
					{
						int num3 = list._size + 1;
						list._size = num3;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					int version3 = list._version + 1;
					list._version = version3;
					string[] items3 = list._items;
					bool flag8 = list._items == null;
					if (list._size >= items3.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"rock0010");
					}
					else
					{
						int num4 = list._size + 1;
						list._size = num4;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					int version4 = list._version + 1;
					list._version = version4;
					string[] items4 = list._items;
					bool flag9 = list._items == null;
					if (list._size >= items4.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"rock0020");
					}
					else
					{
						int num5 = list._size + 1;
						list._size = num5;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					int version5 = list._version + 1;
					list._version = version5;
					string[] items5 = list._items;
					bool flag10 = list._items == null;
					if (list._size >= items5.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"rock0030");
					}
					else
					{
						int num6 = list._size + 1;
						list._size = num6;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					int version6 = list._version + 1;
					list._version = version6;
					string[] items6 = list._items;
					bool flag11 = list._items == null;
					if (list._size >= items6.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"rock0040");
					}
					else
					{
						int num7 = list._size + 1;
						list._size = num7;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					bool flag12 = particleSystemConfig == null;
					_ = 0;
					_ = 5;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+D0]");
					_ = 0;
					_ = 3;
					_ = 0;
					_ = 0;
					_ = 0;
					_ = 1142292480;
					_ = 1149861888;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-80]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-70]");
					_ = 0;
					_ = 3;
					_ = 0;
					_ = 0;
					_ = 0;
					_ = 0;
					_ = 1135869952;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-60]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-50]");
					_ = 0;
					_ = 3;
					_ = 0;
					_ = 0;
					_ = 0;
					_ = 1130430464;
					_ = 1134395392;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-40]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-30]");
					_ = 0;
					_ = 3;
					_ = 0;
					_ = 50f;
					_ = 400f;
					obj = 0;
					_ = 0;
					obj = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+10]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+20]");
					_ = 0;
					_ = 3;
					_ = 0;
					_ = 0.5f;
					_ = 0;
					_ = 0;
					_ = 0;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+28]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+38]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+48]");
					_ = 0;
					ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 32));
					_ = 0;
					_ = 0;
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(400f));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-20]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-10]");
					_ = 0;
					ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 32));
					_ = 0;
					_ = 2891542;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+D0]");
					_ = 0;
					_ = 0;
					_ = 0;
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0.1f));
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-20]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-10]");
					_ = 0;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+50]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+60]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+70]");
					_ = 0;
					_ = 0;
					ParticleSystem rockParticles = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig);
					_rockParticles = rockParticles;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public void DoStep(float2 targetPos)
	{
		//IL_0019: Expected I4, but got I8
		//IL_0095: Expected I, but got O
		//IL_00f9: Expected O, but got I4
		_targetPosition = targetPos;
		_isMoving = true;
		_moveTween = 0f;
		float2 startPosition = base.position;
		_startPosition = startPosition;
		PhaserSprite phaserSprite = _crack.setDepth(-1999);
		if (_crackTween != null)
		{
			_crackTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_crack != null)
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
		tweenConfig.duration = 500f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween crackTween = Tweens.Add(tweenConfig);
		_crackTween = crackTween;
	}

	private void EndStep()
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0076: Expected F4, but got I4
		//IL_00a8: Expected F4, but got I4
		//IL_00ee: Expected O, but got I4
		//IL_0163: Expected I, but got O
		//IL_01d5: Expected O, but got I4
		BaseBody baseBody = body;
		_isMoving = false;
		BaseBody baseBody2 = body.setCircle(64f, (float?)(object)1, (float?)(object)1);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		ScreenShake(8);
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.FireExplosion, 100f, 1, 0f, volume, rate, detune, loop, 1f);
		PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.ExploSoft, 100f, 1, 0f, volume, rate, detune, loop, 1f);
		float2 float5 = base.position;
		Vector2 pos = default(Vector2);
		RenderingExtensions.EmitParticleAt(_rockParticles, pos, 50);
		PhaserSprite phaserSprite = _crack.setScale(1f, (float?)(object)0);
		PhaserSprite phaserSprite2 = _crack.setAlpha(1f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_crack != null)
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
		tweenConfig.duration = 16000f;
		tweenConfig.ease = Ease.InCubic;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween crackTween = Tweens.Add(tweenConfig);
		if (_crackTween != null)
		{
			_crackTween.Kill();
		}
		_crackTween = crackTween;
	}

	protected unsafe override void OnUpdate()
	{
		//IL_0356: Invalid comparison between F4 and I4
		//IL_0051: Expected O, but got I4
		//IL_0051: Expected O, but got I4
		//IL_0119: Expected I, but got O
		//IL_0180: Expected O, but got I4
		//IL_03c7: Expected O, but got I4
		//IL_01cd: Expected O, but got I
		//IL_01fd: Expected O, but got I
		//IL_01a2: Expected O, but got I4
		//IL_04c5->IL0334: Incompatible stack heights: 1 vs 0
		//IL_027b->IL0334: Incompatible stack heights: 1 vs 0
		//IL_0457->IL02f9: Incompatible stack heights: 3 vs 0
		//IL_02f9->IL02f9: Incompatible stack heights: 3 vs 0
		CheckIfVisibleOnScreen();
		float pauseWallChecksTimer = base._pauseWallChecksTimer;
		if (base._pauseWallChecksTimer > 0f)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float pauseWallChecksTimer2 = base._pauseWallChecksTimer - deltaTime;
			base._pauseWallChecksTimer = pauseWallChecksTimer2;
			pauseWallChecksTimer = deltaTime;
		}
		if (body != null)
		{
			BaseBody baseBody = body.setCircle(28f, (float?)(object)1, (float?)(object)1);
			bool flag = !_isLeftHand;
			ArcadeSprite arcadeSprite = setFlipX(flag);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
			int num = default(int);
			ArcadeSprite arcadeSprite2 = setDepth(num);
			if (!_isMoving)
			{
				goto IL_02f9;
			}
			float deltaTime2 = PauseSystem.DeltaTime;
			Weapon weapon = _weapon;
			if ((object)_weapon != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
				{
					nint num2 = (nint)characterController;
					float num3 = ((Equipment)weapon)._003COwner_003Ek__BackingField.PMoveSpeed();
					float num4 = deltaTime2 + 1f;
					float num5 = num4 * deltaTime2;
					bool flag2 = !((_moveTween = num5 + _moveTween) > 1f);
					object obj = 0;
					if (!flag2)
					{
						_moveTween = 1f;
						obj = 1;
					}
					float num6 = _moveTween * (float)Math.PI;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					float xScale = num6 + 1f;
					ArcadeSprite arcadeSprite3 = setScale(xScale, (float?)(object)0);
					float2 float5 = (_targetPosition = CalculateTargetPos());
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_DeathHand_Projectile)+F8]");
					object obj2 = -0;
					object obj3 = float5 - _startPosition;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_DeathHand_Projectile)+F8]");
					object obj4 = -0;
					float num7 = _moveTween * (float)obj4;
					float2 float6 = default(float2);
					base.position = float6;
					Transform transform = base.transform;
					Transform transform2 = base.transform;
					if ((object)transform2 != null)
					{
						bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.get_rotation_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Quaternion ret);
						float2 euler = default(float2);
						Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)(&euler), out Quaternion _);
						float deltaTime3 = PauseSystem.DeltaTime;
						Weapon weapon2 = _weapon;
						if ((object)_weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
						{
							float num8 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.PMoveSpeed();
							float num9 = (float)ret * 0.5f;
							float num10 = deltaTime3 * 180f;
							float num11 = num9 * num10;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1870D8E20");
							bool flag4 = (object)transform == null;
							bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref ret);
							if (obj != null)
							{
								EndStep();
							}
							goto IL_02f9;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_02f9:
		float xOffset = ((!_isLeftHand) ? 1f : (-1f));
		float num12 = base.scale;
		float extraScale = num12 - 1f;
		UpdateJoints(xOffset, _armSprites, extraScale);
	}

	public float2 CalculateTargetPos()
	{
		Weapon weapon = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
			if (_isLeftHand)
			{
			}
			Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
			if ((object)cachedTrans != null)
			{
				float2 float7 = default(float2);
				float2 float6 = MathUtils.RotateFloat2(float7, cachedTrans.localEulerAngles.z);
				return float7;
			}
		}
		return (float2)new NullReferenceException();
	}

	private unsafe void UpdateJoints(float xOffset, List<PhaserSprite> armSprites, float extraScale)
	{
		//IL_002f: Invalid comparison between F4 and I4
		//IL_04f2: Invalid comparison between I4 and F4
		//IL_0072: Invalid comparison between F4 and I4
		//IL_0081: Invalid comparison between F4 and I4
		//IL_009a: Expected O, but got I4
		//IL_0180: Expected F8, but got I4
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_026f: Invalid comparison between I4 and F4
		//IL_06ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ef: Expected O, but got Unknown
		//IL_0614: Expected O, but got I4
		//IL_0361: Expected O, but got I4
		//IL_037c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0381: Expected O, but got Unknown
		//IL_0394: Expected O, but got I4
		//IL_03a1: Expected I4, but got O
		//IL_0409: Expected I, but got O
		//IL_043b: Expected F8, but got O
		//IL_06f8->IL04d9: Incompatible stack heights: 3 vs 1
		//IL_04d9->IL06fd: Incompatible stack heights: 3 vs 1
		//IL_0476->IL06e1: Incompatible stack heights: 5 vs 3
		Weapon weapon = _weapon;
		float2 start = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		Transform transform = base.transform;
		if (xOffset > 0f)
		{
		}
		if (0f > xOffset)
		{
		}
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 vector = default(Vector3);
		float2 ret;
		Transform.TransformPoint_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref vector, out *(Vector3*)(&ret));
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		bool flag2 = xOffset < 0f;
		bool flag3 = xOffset == 0f;
		object obj = armSprites._size - 1;
		bool flag4 = !flag2;
		bool flag5 = !flag3;
		bool flag6 = flag5 & flag4;
		if ((nint)obj < 0)
		{
			return;
		}
		double num2 = default(double);
		double num = num2;
		double num3 = num2;
		float2 float5 = ret;
		float num4 = 1f;
		float num5 = 1f;
		float2 float6 = ret;
		float num6 = extraScale;
		double num14 = default(double);
		float value = default(float);
		Sprite sprite = default(Sprite);
		double num19 = default(double);
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm14\"");
			double num7 = Math.Pow(0.0, 8.0);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm13,xmm0\"");
			float num8 = 0f * num6;
			float num9 = num8 + num5;
			float num10 = num9 * 0.15f;
			double num11 = 0.0;
			Transform transform2 = null;
			float2 float7 = float5;
			float num12 = num4;
			bool flag7;
			do
			{
				num12 += -0.001f;
				float2 float8 = ArmSample(start, ret, num12);
				object obj2 = float8 - float7;
				double num13 = num14 - num3;
				object obj3 = obj2 * obj2;
				double num15 = num13 * num13;
				double num16 = (double)obj3 + num15;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
				num11 += num16;
				if (num11 > (double)num10)
				{
					break;
				}
				transform2 = (Transform)(transform2 + 1);
				flag7 = (nint)transform2 < 100;
				num3 = num14;
				float7 = float8;
			}
			while (flag7);
			float2 float9 = ArmSample(start, ret, num12);
			float2 float10 = ArmSample(start, ret, num4);
			bool flag8 = (nint)obj >= armSprites._size;
			PhaserSprite[] items = armSprites._items;
			bool flag9 = (nint)obj >= items.Length;
			PhaserSprite phaserSprite = items[obj];
			bool flag12;
			if (!(0f > num12) && !(num12 > 1f))
			{
				PhaserSprite phaserSprite2 = items[obj].setVisible(visible: true);
				PhaserSprite phaserSprite3 = items[obj].setFlipX(flag6);
				float num17 = ((!flag6) ? (-0.08f) : 0.08f);
				float originX = 0.5f - num17;
				PhaserSprite phaserSprite4 = items[obj].setOrigin(originX, (float?)(object)1);
				object spriteRenderer = phaserSprite._spriteRenderer;
				CheckRenderer();
				Color color = ((ArcadeSprite)this)._spriteRenderer.color;
				bool flag10 = (object)phaserSprite._spriteRenderer == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v743 @ rbp_v11 (System.Object)+10]");
				bool flag11 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v743 @ rbp_v11 (System.Object)+10]");
				SpriteRenderer.set_color_Injected((IntPtr)0, ref *(Color*)(&value));
				PhaserSprite phaserSprite5 = items[obj].setFrame(sprite);
				object obj4 = float10 - float9;
				double num18 = num14 - num19;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003DD0");
				float num20 = (float)num18 * 57.29578f;
				float num21 = num20 + 90f;
				items[obj].angle = num21;
				PhaserSprite phaserSprite6 = items[obj].setScale(num9, (float?)(object)0);
				int num22 = base.depth;
				object obj5 = num22 - obj;
				object obj6 = armSprites._size + 50;
				int num23 = (int)(obj6 + obj5);
				PhaserSprite phaserSprite7 = items[obj].setDepth(num23);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
				float2 float11 = items[obj].position;
				float2 float12 = items[obj].position;
				nint num24 = (nint)typeof(VSDebug);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1329 @ rcx_v47 (Il2CppClass<VSDebug>)+E4]");
				flag12 = (nint)0 < (nint)0;
				VSDebug.DrawDebugCircle((double)float11, num19, 0.02);
				num = num19;
				value = color.r;
				num3 = num19;
				float5 = float9;
				num4 = num12;
				float6 = float9;
			}
			else
			{
				flag12 = (nint)items[obj] < 0;
				PhaserSprite phaserSprite8 = items[obj].setVisible(visible: false);
				num3 = num;
				float5 = float6;
			}
			obj--;
			if (!flag12)
			{
				num5 = 1f;
				num6 = extraScale;
				continue;
			}
			break;
		}
	}

	private float FindNextJointT(float2 start, float2 end, float2 lastJointPos, float lastJointT, float desiredDistance, float iterationStep = -0.01f)
	{
		//IL_0046: Expected O, but got I4
		//IL_004f: Expected O, but got I4
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		float2 float5 = lastJointPos;
		object obj2 = default(object);
		object obj = obj2;
		object obj3 = 0;
		object obj4 = 0;
		float num2 = default(float);
		float num = num2;
		object obj5 = default(object);
		object obj11 = default(object);
		bool flag;
		do
		{
			num += (float)obj5;
			float2 float6 = ArmSample(start, end, num);
			object obj6 = float6 - float5;
			object obj7 = obj2 - obj;
			object obj8 = obj6 * obj6;
			object obj9 = obj7 * obj7;
			object obj10 = obj8 + obj9;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
			obj3 += obj10;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj11))
			{
				break;
			}
			obj4++;
			flag = (nint)obj4 < 100;
			float5 = float6;
			obj = obj2;
		}
		while (flag);
		return num;
	}

	private float2 ArmSample(float2 start, float2 end, float t)
	{
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			Vector3 up = transform.up;
			float2 result = default(float2);
			return result;
		}
		return (float2)new NullReferenceException();
	}

	public override void Despawn()
	{
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected O, but got Unknown
		//IL_00c8->IL027c: Incompatible stack heights: 1 vs 0
		//IL_011c->IL027c: Incompatible stack heights: 2 vs 0
		//IL_0170->IL027c: Incompatible stack heights: 3 vs 0
		//IL_0183->IL02ca: Incompatible stack heights: 3 vs 0
		if (_crackTween != null)
		{
			_crackTween.Kill();
		}
		_crackTween = null;
		List<PhaserSprite> armSprites = _armSprites;
		bool flag = _armSprites == null;
		object obj = null;
		MultiTargetTween multiTargetTween = null;
		if (!flag)
		{
			while (true)
			{
				if ((nint)multiTargetTween < armSprites._size)
				{
					List<PhaserSprite> armSprites2 = _armSprites;
					if (_armSprites == null)
					{
						break;
					}
					bool flag2 = (nint)obj >= armSprites2._size;
					PhaserSprite[] items = armSprites2._items;
					if (armSprites2._items == null)
					{
						break;
					}
					bool flag3 = (nint)obj >= items.Length;
					GameObject gameObject = (GameObject)(object)items[obj];
					if ((object)items[obj] == null)
					{
						break;
					}
					bool flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					GameObject obj2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
					UnityEngine.Object.Destroy(obj2, 0f);
					armSprites = _armSprites;
					obj++;
					if (_armSprites == null)
					{
						break;
					}
					multiTargetTween = (MultiTargetTween)obj;
					continue;
				}
				object crack = _crack;
				if ((object)_crack == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rdi_v7 (System.Object)+10]");
				if ((nint)0 == 0)
				{
					UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_crack);
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rdi_v7 (System.Object)+10]");
				IntPtr gcHandlePtr2 = Component.get_gameObject_Injected((IntPtr)0);
				GameObject obj3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
				UnityEngine.Object.Destroy(obj3, 0f);
				object rockParticles = _rockParticles;
				if ((object)_rockParticles == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rdi_v9 (System.Object)+10]");
				bool flag5 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rdi_v9 (System.Object)+10]");
				IntPtr gcHandlePtr3 = Component.get_gameObject_Injected((IntPtr)0);
				GameObject obj4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr3);
				UnityEngine.Object.Destroy(obj4, 0f);
				if (_screenShakeTween != null)
				{
					_screenShakeTween.Kill();
				}
				_screenShakeTween = null;
				_armSprites = null;
				_crack = null;
				_rockParticles = null;
				base.Despawn();
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void ScreenShake(int repeats = 6)
	{
		//IL_00b3: Expected I, but got O
		//IL_0132: Expected O, but got I4
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
		tweenConfig.duration = 32f;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = repeats;
		tweenConfig.x = (float?)(object)1;
		TweenCallback onStart = _003C_003Ec._003C_003E9__20_0;
		if (_003C_003Ec._003C_003E9__20_0 == null)
		{
			onStart = (_003C_003Ec._003C_003E9__20_0 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.x = -2f;
			});
		}
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = _003C_003Ec._003C_003E9__20_1;
		if (_003C_003Ec._003C_003E9__20_1 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__20_1 = delegate
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
		MultiTargetTween screenShakeTween = Tweens.Add(tweenConfig);
		_screenShakeTween = screenShakeTween;
	}
}
