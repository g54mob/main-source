using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class SummonNightWeapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass0_0
	{
		public SummonNightWeapon _003C_003E4__this;

		public float x;

		public float incrementUnit;

		public float y;

		public int index;

		public Action _003C_003E9__0;

		internal void _003CFire_003Eb__0()
		{
			SummonNightWeapon summonNightWeapon = _003C_003E4__this;
			Vector2 pos = default(Vector2);
			Projectile projectile = _003C_003E4__this.FireOneProjectile(pos, index, summonNightWeapon._targetTransform);
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0039: Expected O, but got I4
		//IL_0369: Invalid comparison between F4 and I4
		//IL_03a0: Expected F4, but got I4
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Expected O, but got Unknown
		//IL_0318: Expected I4, but got F4
		_003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals21 = new _003C_003Ec__DisplayClass0_0();
		CS_0024_003C_003E8__locals21._003C_003E4__this = this;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ExploNight, soundConfig, 100f, 8, num);
		float num2 = base.PAmount();
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			object obj = default(object);
			float num3 = (float)obj + 1f;
			float incrementUnit = renderer.width / num3;
			CS_0024_003C_003E8__locals21.incrementUnit = incrementUnit;
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer2 = s_scene2._renderer;
				float num4 = renderer2.width * 0.5f;
				float x = (float)position - num4;
				CS_0024_003C_003E8__locals21.x = x;
				float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene3 = ArcadePhysics.s_scene;
					PhaserScene.Renderer renderer3 = s_scene3._renderer;
					float num5 = renderer3.height * 0.5f;
					CS_0024_003C_003E8__locals21.index = 0;
					float y = num5 + 1.0636755E+09f;
					CS_0024_003C_003E8__locals21.y = y;
					Vector2 pos = default(Vector2);
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					while ((nint)obj > CS_0024_003C_003E8__locals21.index)
					{
						WeaponData currentWeaponData = _currentWeaponData;
						object obj2 = CS_0024_003C_003E8__locals21.index * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
						if ((nint)obj2 <= 0)
						{
							Projectile projectile = base.FireOneProjectile(pos, CS_0024_003C_003E8__locals21.index, _targetTransform);
							int index = CS_0024_003C_003E8__locals21.index + 1;
							CS_0024_003C_003E8__locals21.index = index;
							continue;
						}
						Action onComplete = CS_0024_003C_003E8__locals21._003C_003E9__0;
						if (CS_0024_003C_003E8__locals21._003C_003E9__0 == null)
						{
							onComplete = (CS_0024_003C_003E8__locals21._003C_003E9__0 = delegate
							{
								SummonNightWeapon summonNightWeapon = CS_0024_003C_003E8__locals21._003C_003E4__this;
								Vector2 pos2 = default(Vector2);
								Projectile projectile2 = CS_0024_003C_003E8__locals21._003C_003E4__this.FireOneProjectile(pos2, CS_0024_003C_003E8__locals21.index, summonNightWeapon._targetTransform);
							});
						}
						float num6 = (float)CS_0024_003C_003E8__locals21.index * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
						float duration = num6 * 0.001f;
						Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, (byte)(int)num != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						_lastShotTimer = lastShotTimer;
						int index2 = CS_0024_003C_003E8__locals21.index + 1;
						CS_0024_003C_003E8__locals21.index = index2;
					}
					float num7 = base.PInterval();
					bool flag = _lastFiringInterval == (float)CS_0024_003C_003E8__locals21.index;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018755635Eh\"");
					if (!flag)
					{
						float num8 = base.PInterval();
						_lastFiringInterval = CS_0024_003C_003E8__locals21.index;
						base.ResetFiringTimer();
					}
					if (!skipTriggers)
					{
						((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
					}
					return;
				}
			}
		}
		throw new NullReferenceException();
	}
}
