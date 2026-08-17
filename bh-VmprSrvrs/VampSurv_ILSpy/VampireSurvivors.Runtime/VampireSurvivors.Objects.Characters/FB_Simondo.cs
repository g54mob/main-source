using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters;

public class FB_Simondo : CharacterController_FirstBlood
{
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public float x;

		public float y;

		public ItemType itemType;

		public FB_Simondo _003C_003E4__this;

		public float delay;

		internal void _003CSpawnSingle_003Eb__0()
		{
			//IL_00cf: Expected O, but got I
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Expected O, but got Unknown
			//IL_0144: Expected O, but got I
			//IL_0189: Expected O, but got I4
			//IL_017b: Expected F4, but got I4
			//IL_012f: Expected O, but got I8
			Vector2 pos = default(Vector2);
			float num = default(float);
			ItemType itemType = default(ItemType);
			bool shouldCallValidatePickups = default(bool);
			bool isRemote = default(bool);
			Pickup pickup = GM.Core.MakePickup(pos, this.itemType, WeaponType.VOID, num, itemType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
			GameManager core = GM.Core;
			bool isOnlineMultiplayer = core._multiplayer.IsOnlineMultiplayer;
			FB_Simondo fB_Simondo = _003C_003E4__this;
			if (!isOnlineMultiplayer)
			{
				_003C_003E4__this.ShowHighlight(x, y, delay);
				return;
			}
			Action<float, float, float> action = null;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r10_v2 (Il2CppMethodInfo)+8]");
			_ = 0;
			_ = 0;
			_ = _003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r10_v2 (Il2CppMethodInfo)+4C]");
			object obj = (nint)0 >> 4;
			object obj2 = obj & 1;
			object obj3;
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r10_v2 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 3)
				{
					obj3 = 6447790672L;
					goto IL_0180;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v8 (System.Action`3<System.Single, System.Single, System.Single>)+10]");
			obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v8 (System.Action`3<System.Single, System.Single, System.Single>)+20]");
			_ = 0;
			goto IL_0180;
			IL_0180:
			object obj4 = 24;
			_ = 6447790528L;
			bool flag = fB_Simondo._coherenceSync.SendCommand(action, MessageTarget.All, x, num, (float)itemType);
		}
	}

	private float _spawnPickupsDelay;

	private float _spawnPickupsTime;

	private Timer _activationTimer;

	private List<ItemType> _pickupTypes;

	private PhaserSprite _highlight;

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		((CharacterController)this)._isCriticalHPEnabled = true;
		Action onCriticalHP = CriticalHP;
		((CharacterController)this)._onCriticalHP = onCriticalHP;
		float spawnPickupsTime = _spawnPickupsDelay * 0.75f;
		_spawnPickupsTime = spawnPickupsTime;
	}

	public float SpawnPickupsInterval()
	{
		float num = base.PCooldownFinal(0.3f);
		object obj = default(object);
		return (float)obj * _spawnPickupsDelay;
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		float num2 = (_spawnPickupsTime = num + _spawnPickupsTime);
		float num3 = base.PCooldownFinal(0.3f);
		float num4 = deltaTime * _spawnPickupsDelay;
		if (!(num2 < num4))
		{
			_spawnPickupsTime = 0f;
			if (_activationTimer != null)
			{
				_activationTimer.Cancel();
			}
			Action onComplete = delegate
			{
				SpawnPickups();
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer activationTimer = Timers.Register(0.15f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_activationTimer = activationTimer;
		}
	}

	private void CriticalHP()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 2 Invalid \"Jump target not found in method: 0x1875E0E30\"");
	}

	private void SpawnPickups(int extra = 0)
	{
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_02b8: Expected O, but got F4
		//IL_02dc: Invalid comparison between F4 and I4
		//IL_0121: Expected O, but got I4
		//IL_012a: Expected O, but got I4
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected O, but got Unknown
		//IL_018b: Invalid comparison between F4 and O
		GameManager core = GM.Core;
		if (!core._003CCanInterrupt_003Ek__BackingField || !core.IsStageHost)
		{
			return;
		}
		float num = base.PAmount();
		object obj = default(object);
		float num2 = (float)extra + (float)obj;
		if (!(1f > num2))
		{
			object obj2 = 1f & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				goto IL_01b6;
			}
		}
		num2 = 1f;
		goto IL_01b6;
		IL_01b6:
		GameManager core2 = GM.Core;
		ArcanaManager arcanaManager = core2._arcanaManager;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A968E0");
		object obj3 = default(object);
		if (obj3 != null)
		{
			num2 += 3f;
		}
		float num3 = (float)Math.PI * 2f / num2;
		object obj4 = UnityEngine.Random.value;
		float num4 = 1f * 360f;
		float2 float5 = base.position;
		if (!(num2 > 0f))
		{
			return;
		}
		object obj5 = 0;
		object obj6 = 0;
		object obj7 = default(object);
		float delay = default(float);
		bool flag2;
		do
		{
			ItemType itemType = Extensions.PickRnd(_pickupTypes);
			float num5;
			if (itemType == ItemType.FB_RAPIDFIRE)
			{
				num5 = 1.65f;
			}
			else
			{
				bool flag = itemType != ItemType.FB_GRENADE;
				num5 = 1.15f;
				if (!flag)
				{
					num5 = 2.15f;
				}
			}
			float num6 = (float)obj6 * num3;
			float num7 = num6 + num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			float num8 = (float)obj6 * num3;
			float num9 = num7 * num5;
			float num10 = num8 + num4;
			float y = num9 + (float)obj7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			float num11 = num10 * num5;
			float x = num11 + (float)float5;
			SpawnSingle(x, y, itemType, delay);
			obj5++;
			flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5);
			obj6 = obj5;
		}
		while (flag2);
	}

	private void SpawnSingle(float x, float y, ItemType itemType, float delay)
	{
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass10_0();
		CS_0024_003C_003E8__locals13.x = x;
		CS_0024_003C_003E8__locals13.y = y;
		CS_0024_003C_003E8__locals13.itemType = itemType;
		CS_0024_003C_003E8__locals13._003C_003E4__this = this;
		float num = default(float);
		CS_0024_003C_003E8__locals13.delay = num;
		Action onComplete = delegate
		{
			//IL_00cf: Expected O, but got I
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Expected O, but got Unknown
			//IL_0144: Expected O, but got I
			//IL_0189: Expected O, but got I4
			//IL_017b: Expected F4, but got I4
			//IL_012f: Expected O, but got I8
			Vector2 pos = default(Vector2);
			float num2 = default(float);
			ItemType itemType2 = default(ItemType);
			bool shouldCallValidatePickups = default(bool);
			bool isRemote = default(bool);
			Pickup pickup = GM.Core.MakePickup(pos, CS_0024_003C_003E8__locals13.itemType, WeaponType.VOID, num2, itemType2, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
			GameManager core = GM.Core;
			bool isOnlineMultiplayer = core._multiplayer.IsOnlineMultiplayer;
			FB_Simondo fB_Simondo = CS_0024_003C_003E8__locals13._003C_003E4__this;
			if (!isOnlineMultiplayer)
			{
				CS_0024_003C_003E8__locals13._003C_003E4__this.ShowHighlight(CS_0024_003C_003E8__locals13.x, CS_0024_003C_003E8__locals13.y, CS_0024_003C_003E8__locals13.delay);
				return;
			}
			Action<float, float, float> action = null;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r10_v2 (Il2CppMethodInfo)+8]");
			_ = 0;
			_ = 0;
			_ = CS_0024_003C_003E8__locals13._003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r10_v2 (Il2CppMethodInfo)+4C]");
			object obj = (nint)0 >> 4;
			object obj2 = obj & 1;
			object obj3;
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r10_v2 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 3)
				{
					obj3 = 6447790672L;
					goto IL_0180;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v8 (System.Action`3<System.Single, System.Single, System.Single>)+10]");
			obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v8 (System.Action`3<System.Single, System.Single, System.Single>)+20]");
			_ = 0;
			goto IL_0180;
			IL_0180:
			object obj4 = 24;
			_ = 6447790528L;
			bool flag = fB_Simondo._coherenceSync.SendCommand(action, MessageTarget.All, CS_0024_003C_003E8__locals13.x, num2, (float)itemType2);
		};
		float duration = num * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public void ShowHighlightOnline(float x, float y, float delay)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1 Invalid \"Jump target not found in method: 0x1875E1320\"");
	}

	private void ShowHighlight(float x, float y, float detune)
	{
		//IL_038f: Expected O, but got I4
		//IL_00a3: Expected I4, but got F4
		//IL_00ea: Expected O, but got I4
		//IL_018a: Expected I4, but got F4
		//IL_01f1: Expected O, but got I4
		//IL_0408->IL0356: Incompatible stack heights: 1 vs 0
		//IL_0268->IL0268: Incompatible stack heights: 1 vs 0
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Detune = detune;
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.DLC4_Explosion1, soundConfig, 400f, 4, num);
		PhaserSprite highlight = _highlight;
		if ((object)_highlight != null && ((UnityEngine.Object)highlight).m_CachedPtr != (IntPtr)0)
		{
			goto IL_0268;
		}
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Crush Bomb-Explosion-F", 1, 7, "firstBlood", (int)num);
		PhaserWorld instance = PhaserWorld.Instance;
		if ((object)instance != null)
		{
			PhaserSprite highlight2 = instance.AddPhaserSprite((Vector2)0, "firstBlood", "Crush Bomb-Explosion-F1");
			_highlight = highlight2;
			PhaserSprite highlight3 = _highlight;
			if ((object)_highlight != null)
			{
				Action action = delegate
				{
					PhaserSprite phaserSprite5 = _highlight.setVisible(visible: false);
				};
				if ((object)highlight3._spriteAnimation != null)
				{
					bool startRandomFrame = default(bool);
					Action onComplete = default(Action);
					bool autoSetAnimation = default(bool);
					highlight3._spriteAnimation.AddAnimation("bang", animationFrames, 16, (byte)(int)num != 0, startRandomFrame, onComplete, autoSetAnimation);
					if ((object)_highlight != null)
					{
						PhaserSprite phaserSprite = _highlight.setVisible(visible: false);
						if ((object)_highlight != null)
						{
							PhaserSprite phaserSprite2 = _highlight.setScale(2f, (float?)(object)0);
							if ((object)_highlight != null)
							{
								Transform transform = _highlight.transform;
								if ((object)transform != null)
								{
									bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
									Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
									if ((object)_highlight != null)
									{
										PhaserSprite phaserSprite3 = _highlight.setDepth(3000);
										goto IL_0268;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0356;
		IL_0356:
		throw new NullReferenceException();
		IL_0268:
		if ((object)_highlight != null)
		{
			_highlight.X = x;
			if ((object)_highlight != null)
			{
				_highlight.Y = y;
				if ((object)_highlight != null)
				{
					PhaserSprite phaserSprite4 = _highlight.setVisible(visible: true);
					PhaserSprite highlight4 = _highlight;
					if ((object)_highlight != null && (object)highlight4._spriteAnimation != null)
					{
						highlight4._spriteAnimation.SetAnimation("bang");
						return;
					}
				}
			}
		}
		goto IL_0356;
	}

	public FB_Simondo()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_01af: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_01d7: Expected O, but got I
		//IL_0156: Expected O, but got I
		_spawnPickupsDelay = 30000f;
		List<ItemType> list = new List<ItemType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)202);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 202;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)201);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 201;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)200);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 200;
		}
		_pickupTypes = list;
		base._002Ector();
	}

	private void _003COnUpdate_003Eb__7_0()
	{
		SpawnPickups();
	}

	private void _003CShowHighlight_003Eb__12_0()
	{
		PhaserSprite phaserSprite = _highlight.setVisible(visible: false);
	}
}
