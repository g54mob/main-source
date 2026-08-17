using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class FourSeasons2Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public int copy;

		public FourSeasons2Weapon _003C_003E4__this;

		internal void _003CFire_003Eb__0()
		{
			FourSeasons2Weapon fourSeasons2Weapon = _003C_003E4__this;
			float2 pos = default(float2);
			Projectile projectile = fourSeasons2Weapon._projectilePool.SpawnAt(pos, _003C_003E4__this, copy);
		}
	}

	private PhaserSprite[] _orbs;

	private bool _canSpin;

	public float2[] _positions;

	private float _angleUnit = 0.00031415926f;

	private float[] _angles;

	public override float PPower()
	{
		//IL_013b: Expected F4, but got I4
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null || ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0)
		{
			return 0f;
		}
		WeaponData currentWeaponData = _currentWeaponData;
		bool flag = _currentWeaponData == null;
		float num2 = default(float);
		float num = num2;
		if (!flag)
		{
			float num3 = base.PDuration();
			float num4 = base.PAmount();
			bool flag2 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
			num = num2;
			if (!flag2)
			{
				num = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
					float num5 = num2 * 0.001f;
					float num6 = num5 + currentWeaponData._003Cpower_003Ek__BackingField;
					float num7 = num6 * num2;
					float num8 = num7 * num;
					return num + num8;
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void FakeConstruct()
	{
		//IL_0256: Expected I, but got O
		//IL_0026: Expected I, but got O
		//IL_005c: Expected I, but got O
		//IL_0092: Expected I, but got O
		//IL_00c8: Expected I, but got O
		base.FakeConstruct();
		float2[] positions = new float2[5];
		nint num = (nint)typeof(float2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rcx_v4 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
		nint num2 = 0;
		_ = float2.zero;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v3 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
		_ = 0;
		nint num3 = (nint)typeof(float2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rcx_v9 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
		nint num4 = 0;
		_ = float2.zero;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rax_v11 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
		_ = 0;
		nint num5 = (nint)typeof(float2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rax_v12 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
		nint num6 = 0;
		_ = float2.zero;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rcx_v10 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
		_ = 0;
		nint num7 = (nint)typeof(float2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rax_v13 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
		nint num8 = 0;
		_ = float2.zero;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rcx_v11 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
		_ = 0;
		nint num9 = (nint)typeof(float2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rax_v14 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
		nint num10 = 0;
		_ = float2.zero;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rcx_v12 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
		_ = 0;
		_positions = positions;
		PhaserSprite[] orbs = new PhaserSprite[24];
		_orbs = orbs;
		bool flag = false;
		Vector2 pos = default(Vector2);
		while (true)
		{
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserSprite phaserSprite = RenderingExtensions.sprite(s_scene.add, pos, "vfx", "bulletFourSeasons");
			PhaserSprite phaserSprite2 = RenderingExtensions.SetScrollFactor(phaserSprite, 0f);
			PhaserSprite[] orbs2 = _orbs;
			if ((object)phaserSprite != null)
			{
				PhaserSprite phaserSprite3 = RenderingExtensions.SetScrollFactor(phaserSprite, 0f);
				if ((object)phaserSprite3 == null)
				{
					break;
				}
			}
			orbs2[flag ? 1u : 0u] = phaserSprite;
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			if ((flag ? 1 : 0) >= 24)
			{
				_explodeOnExpire = false;
				_explosionType = WeaponType.RAYEXPLOSION;
				return;
			}
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private void Set5Positions()
	{
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num = renderer.width * 0.5f;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float2[] positions = _positions;
		float num2 = renderer2.height * -0.5f;
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float num3 = (float)position - num;
		float num4 = num3 + 0.64f;
		float2[] positions2 = _positions;
		float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		object obj = default(object);
		float num5 = (float)obj - num2;
		float num6 = num5 - 0.64f;
		float2[] positions3 = _positions;
		float2 position3 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float num7 = (float)position3 + num;
		float num8 = num7 - 0.64f;
		float2[] positions4 = _positions;
		float2 position4 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float num9 = (float)obj - num2;
		float num10 = num9 - 0.64f;
		float2[] positions5 = _positions;
		float2 position5 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float num11 = (float)position5 - num;
		float num12 = num11 + 0.64f;
		float2[] positions6 = _positions;
		float2 position6 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float num13 = (float)obj + num2;
		float num14 = num13 + 0.64f;
		float2[] positions7 = _positions;
		float2 position7 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float num15 = (float)position7 + num;
		float num16 = num15 - 0.64f;
		float2[] positions8 = _positions;
		float2 position8 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float num17 = (float)obj + num2;
		float num18 = num17 + 0.64f;
		float2[] positions9 = _positions;
		float2 position9 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float2[] positions10 = _positions;
		float2 position10 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
	}

	protected override void MakeLevelOne()
	{
		//IL_003b: Expected O, but got I4
		//IL_0044: Expected O, but got I4
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		base.MakeLevelOne();
		PhaserSprite[] orbs = _orbs;
		float[] angles = new float[orbs.Length];
		_angles = angles;
		PhaserSprite[] orbs2 = _orbs;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < orbs2.Length)
		{
			PhaserSprite[] orbs3 = _orbs;
			float[] angles2 = _angles;
			object obj3 = obj + 1;
			object obj4 = obj / orbs3.Length;
			float num = (float)obj4 * ((float)Math.PI * 2f);
			angles2[obj] = num;
			orbs2 = _orbs;
			obj = obj3;
			obj2 = obj3;
		}
	}

	public override void InternalUpdate()
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_00b3: Expected O, but got I4
		//IL_00bc: Expected O, but got I4
		//IL_0102: Expected O, but got I4
		//IL_010b: Expected O, but got I4
		//IL_022c: Expected O, but got F4
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		base.InternalUpdate();
		Set5Positions();
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		object obj = renderer2.height & -2147483649L;
		if ((nint)obj > 2139095040 || renderer2.height > renderer.width)
		{
		}
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float[] angles = _angles;
		object obj2 = 0;
		object obj3 = 0;
		float num2 = default(float);
		while ((nint)obj3 < angles.Length)
		{
			float[] angles2 = _angles;
			object obj4 = Time.deltaTime;
			float num = num2 * _angleUnit;
			object obj5 = obj2 + 1;
			float num3 = num * 1000f;
			num2 = (angles2[obj2] = num3 + angles2[obj2]);
			angles = _angles;
			obj2 = obj5;
			obj3 = obj5;
		}
		PhaserSprite[] orbs = _orbs;
		object obj6 = 0;
		object obj7 = 0;
		float2 position2 = default(float2);
		bool flag;
		do
		{
			if ((nint)obj7 < orbs.Length)
			{
				PhaserSprite[] orbs2 = _orbs;
				float[] angles3 = _angles;
				double num4 = Math.Cos(angles3[obj6]);
				float[] angles4 = _angles;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm6,xmm0\"");
				double num5 = Math.Sin(angles4[obj6]);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm0\"");
				PhaserSprite phaserSprite = orbs2[obj6].setPosition(position2);
				orbs = _orbs;
				obj6++;
				flag = _orbs != null;
				obj7 = obj6;
				continue;
			}
			return;
		}
		while (flag);
		throw new NullReferenceException();
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_01f4: Expected O, but got I4
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		//IL_0129: Expected I4, but got F4
		//IL_00ba: Expected F4, but got O
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Seasons1, soundConfig, 2000f, 1, num);
		int num2 = 0;
		float2 float5 = default(float2);
		float num3;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass10_0();
			CS_0024_003C_003E8__locals5._003C_003E4__this = this;
			CS_0024_003C_003E8__locals5.copy = num2;
			WeaponData currentWeaponData = _currentWeaponData;
			object obj = num2 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
			if ((nint)obj <= 0)
			{
				Projectile projectile = _projectilePool.SpawnAt(float5, this, num2);
				num3 = (float)float5;
			}
			else
			{
				Action onComplete = delegate
				{
					FourSeasons2Weapon fourSeasons2Weapon = CS_0024_003C_003E8__locals5._003C_003E4__this;
					float2 pos = default(float2);
					Projectile projectile2 = fourSeasons2Weapon._projectilePool.SpawnAt(pos, CS_0024_003C_003E8__locals5._003C_003E4__this, CS_0024_003C_003E8__locals5.copy);
				};
				float num4 = (float)num2 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
				num3 = num4 * 0.001f;
				Timer lastShotTimer = Timers.Register(num3, onComplete, null, isLooped: false, (byte)(int)num != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_lastShotTimer = lastShotTimer;
			}
			num2++;
		}
		while (num2 < 5);
		float num5 = base.PInterval();
		bool flag = _lastFiringInterval == num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018750C44Ch\"");
		if (!flag)
		{
			float num6 = base.PInterval();
			_lastFiringInterval = num3;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public override void SetVisible(bool visible)
	{
		//IL_001d: Expected O, but got I4
		//IL_0026: Expected O, but got I4
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		PhaserSprite[] orbs = _orbs;
		_isVisible = visible;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < orbs.Length)
		{
			PhaserSprite[] orbs2 = _orbs;
			PhaserSprite phaserSprite = orbs2[obj2];
			orbs2[obj2].EnsureSpriteRenderer();
			SpriteRenderer spriteRenderer = phaserSprite._spriteRenderer;
			if ((object)phaserSprite._spriteRenderer != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
			{
				phaserSprite._spriteRenderer.enabled = visible;
			}
			orbs = _orbs;
			obj2++;
			obj = obj2;
		}
	}
}
