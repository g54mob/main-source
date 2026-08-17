using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Characters;

public class FB_Lance : CharacterController_FirstBlood
{
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public WeaponType weaponType;

		public float value;

		public FB_Lance _003C_003E4__this;

		internal unsafe void _003CHandleEquipment_003Eb__0()
		{
			//IL_00a0: Expected O, but got I4
			//IL_0049: Expected Ref, but got F4
			//IL_007a: Expected O, but got F4
			//IL_007a: Expected O, but got Ref
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			float num = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Groove, soundConfig, 150f, 3, num);
			GameManager core = GM.Core;
			float num2 = (float)this + 20f;
			string text = ((float*)num2)->ToString();
			object obj = default(object);
			float displayTimeMultiplier = default(float);
			Vector2 vOffset = default(Vector2);
			core._gizmoManager.DisplayWeaponIconOverhead(weaponType, text, (Color?)(object)(&obj), (CharacterController)num, displayTimeMultiplier, vOffset);
		}
	}

	private int enemyKilledCounter;

	private float cooldownCounter = 100f;

	private float speedCounter = 100f;

	private float cooldownAdded;

	private float speedAdded;

	private float maxCooldown = 0.25f;

	private float maxSpeed = 0.5f;

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		base.MakeLevelOne();
		Action action = OnEnemyKilled;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1E60");
	}

	public override void OnQuit()
	{
		base.OnQuit();
		if (_signalBus != null)
		{
			Action action = OnEnemyKilled;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1FE0");
		}
	}

	public void OnEnemyKilled()
	{
		//IL_0024: Invalid comparison between I4 and F4
		//IL_00da: Invalid comparison between I4 and F4
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Expected F4, but got Unknown
		if ((float)(++enemyKilledCounter) > cooldownCounter && maxCooldown > cooldownAdded)
		{
			float num = cooldownCounter * 1.3f;
			cooldownCounter = num;
			float num2 = cooldownAdded + 0.01f;
			bool flag = !(num2 > maxCooldown);
			float num3 = 0.01f;
			if (!flag)
			{
				num3 = maxCooldown - cooldownAdded;
			}
			float num4 = num3 + cooldownAdded;
			float num5 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			float value = num5 ^ 0;
			cooldownAdded = num4;
			HandleEquipment(WeaponType.COOLDOWN, value);
		}
		if ((float)enemyKilledCounter > speedCounter && maxSpeed > speedAdded)
		{
			float num6 = speedCounter * 1.3f;
			speedCounter = num6;
			float num7 = speedAdded + 0.025f;
			bool flag2 = !(num7 > maxSpeed);
			float num8 = 0.025f;
			if (!flag2)
			{
				num8 = maxSpeed - speedAdded;
			}
			float num9 = num8 + speedAdded;
			speedAdded = num9;
			HandleEquipment(WeaponType.SPEED, num8, 400f);
		}
	}

	private unsafe void HandleEquipment(WeaponType weaponType, float value, float delay = 0f)
	{
		//IL_0064: Invalid comparison between I4 and F4
		//IL_00e2: Expected O, but got I4
		//IL_0103: Expected F4, but got I4
		//IL_012e: Expected Ref, but got F4
		//IL_0162: Expected O, but got I4
		//IL_0162: Expected F4, but got O
		//IL_0162: Expected O, but got I4
		//IL_0162: Expected O, but got Ref
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass10_0();
		CS_0024_003C_003E8__locals9.value = value;
		CS_0024_003C_003E8__locals9.weaponType = weaponType;
		CS_0024_003C_003E8__locals9._003C_003E4__this = this;
		AddValueToAttribute(this, CS_0024_003C_003E8__locals9.weaponType, CS_0024_003C_003E8__locals9.value);
		bool flag = default(bool);
		MonoBehaviour monoBehaviour = default(MonoBehaviour);
		int num = default(int);
		if (0f < delay)
		{
			Action onComplete = delegate
			{
				//IL_00a0: Expected O, but got I4
				//IL_0049: Expected Ref, but got F4
				//IL_007a: Expected O, but got F4
				//IL_007a: Expected O, but got Ref
				SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
				soundConfig2.Rate = 1f;
				soundConfig2.Volume = (float?)(object)1;
				float num3 = default(float);
				PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Groove, soundConfig2, 150f, 3, num3);
				GameManager core2 = GM.Core;
				float num4 = (float)CS_0024_003C_003E8__locals9 + 20f;
				string value3 = ((float*)num4)->ToString();
				object obj2 = default(object);
				float displayTimeMultiplier = default(float);
				Vector2 vOffset = default(Vector2);
				core2._gizmoManager.DisplayWeaponIconOverhead(CS_0024_003C_003E8__locals9.weaponType, value3, (Color?)(object)(&obj2), (CharacterController)num3, displayTimeMultiplier, vOffset);
			};
			Timer timer = TimerHelper.RegisterMillisUI(delay, onComplete, null, isLooped: false, flag, monoBehaviour, num);
		}
		else
		{
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Groove, soundConfig, 150f, 3, flag ? 1 : 0);
			GameManager core = GM.Core;
			float num2 = (float)CS_0024_003C_003E8__locals9 + 20f;
			string value2 = ((float*)num2)->ToString();
			object obj = default(object);
			core._gizmoManager.DisplayWeaponIconOverhead(CS_0024_003C_003E8__locals9.weaponType, value2, (Color?)(object)(&obj), (CharacterController)flag, (float)monoBehaviour, (Vector2)num);
		}
	}
}
