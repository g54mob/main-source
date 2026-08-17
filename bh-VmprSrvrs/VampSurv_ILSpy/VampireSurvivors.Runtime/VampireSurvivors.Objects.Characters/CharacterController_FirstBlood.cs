using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters;

public class CharacterController_FirstBlood : CharacterController
{
	protected float _spawnPROPS_Delay = 30000f;

	protected float _spawnPROPS_Time;

	protected Timer _PROPSactivationTimer;

	protected List<PropType> _PROPSTypes;

	protected bool _spawnExtraProps;

	public override void AfterFullInitialization()
	{
		//IL_0045: Expected O, but got I
		//IL_00bf: Expected O, but got I
		//IL_02ce: Expected O, but got I
		//IL_0129: Expected O, but got I
		//IL_0316: Expected O, but got I
		//IL_0193: Expected O, but got I
		//IL_03b8->IL028f: Incompatible stack heights: 1 vs 0
		//IL_026d->IL028f: Incompatible stack heights: 1 vs 0
		//IL_040d->IL028f: Incompatible stack heights: 2 vs 0
		base.AfterFullInitialization();
		List<ItemType> list = new List<ItemType>();
		if (list != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v13+18]");
				if (num >= 0)
				{
					((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)201);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
					object obj2 = (nint)0 + (nint)1;
					_ = 201;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdx_v15+18]");
					if (num2 >= 0)
					{
						((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)202);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
						object obj4 = (nint)0 + (nint)1;
						_ = 202;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdx_v17+18]");
						if (num3 >= 0)
						{
							((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)200);
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
							object obj6 = (nint)0 + (nint)1;
							_ = 200;
						}
						GameManager core = GM.Core;
						if ((object)GM.Core != null && core._lootManager != null)
						{
							core._lootManager.AddToLootTable(list);
							SpriteAnimation spriteAnimation = _spriteAnimation;
							CheckRenderer();
							if ((object)((ArcadeSprite)this)._spriteRenderer != null)
							{
								Sprite sprite = ((ArcadeSprite)this)._spriteRenderer.sprite;
								if ((object)sprite != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v27 (UnityEngine.Sprite)+10]");
									bool flag = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v27 (UnityEngine.Sprite)+10]");
									Sprite.get_rect_Injected((IntPtr)0, out Rect _);
									CheckRenderer();
									if ((object)((ArcadeSprite)this)._spriteRenderer != null)
									{
										Sprite sprite2 = ((ArcadeSprite)this)._spriteRenderer.sprite;
										if ((object)sprite2 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rax_v33 (UnityEngine.Sprite)+10]");
											bool flag2 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rax_v33 (UnityEngine.Sprite)+10]");
											Sprite.get_rect_Injected((IntPtr)0, out Rect _);
											if ((object)_spriteAnimation != null)
											{
												float2 originalSpriteSize = default(float2);
												spriteAnimation._originalSpriteSize = originalSpriteSize;
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
		throw new NullReferenceException();
	}

	public override void OnDeath()
	{
		//IL_0015: Expected O, but got I
		//IL_01b1: Invalid comparison between I4 and F4
		//IL_007b: Expected O, but got I8
		//IL_0161: Expected F4, but got I4
		if (_characterType != CharacterType.FB_SIMONDO)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			bool flag = (nint)0 != 0;
			CharacterController_FirstBlood characterController_FirstBlood = this;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
				characterController_FirstBlood = (CharacterController_FirstBlood)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v136 @ rax_v5 (should have been resolved before IL gen)");
			bool flag2 = !(0f > 0.5f);
			SfxType sfxType = SfxType.DLC4_PlayerDeath;
			if (!flag2)
			{
				sfxType = SfxType.DLC4_PlayerDeath2;
			}
			if (_characterType == CharacterType.FB_STANLEY || _characterType == CharacterType.FB_BROWNY)
			{
				sfxType = SfxType.DLC4_Explosion1;
			}
			if (_characterType == CharacterType.FB_LUCIA || _characterType == CharacterType.FB_SHEENA || _characterType == CharacterType.FB_ARIANA)
			{
			}
			if (_characterType == CharacterType.FB_BRADFANG || _characterType == CharacterType.FB_NEWT)
			{
			}
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(sfxType, 500f, 10, 0f, volume, rate, detune, loop, 1f);
		}
		base.OnDeath();
	}

	private void PlayDeathSound()
	{
		//IL_0015: Expected O, but got I
		//IL_01b1: Invalid comparison between I4 and F4
		//IL_007b: Expected O, but got I8
		//IL_0161: Expected F4, but got I4
		if (_characterType == CharacterType.FB_SIMONDO)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		CharacterController_FirstBlood characterController_FirstBlood = this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			characterController_FirstBlood = (CharacterController_FirstBlood)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v137 @ rax_v4 (should have been resolved before IL gen)");
		bool flag2 = !(0f > 0.5f);
		SfxType sfxType = SfxType.DLC4_PlayerDeath;
		if (!flag2)
		{
			sfxType = SfxType.DLC4_PlayerDeath2;
		}
		if (_characterType == CharacterType.FB_STANLEY || _characterType == CharacterType.FB_BROWNY)
		{
			sfxType = SfxType.DLC4_Explosion1;
		}
		if (_characterType == CharacterType.FB_LUCIA || _characterType == CharacterType.FB_SHEENA || _characterType == CharacterType.FB_ARIANA)
		{
		}
		if (_characterType == CharacterType.FB_BRADFANG || _characterType == CharacterType.FB_NEWT)
		{
		}
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(sfxType, 500f, 10, 0f, volume, rate, detune, loop, 1f);
	}

	protected float PROPSSpawnInterval()
	{
		float num = base.PCooldownFinal(0.3f);
		object obj = default(object);
		return (float)obj * _spawnPROPS_Delay;
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		if (!_spawnExtraProps)
		{
			return;
		}
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		float num2 = (_spawnPROPS_Time = num + _spawnPROPS_Time);
		float num3 = base.PCooldownFinal(0.3f);
		float num4 = deltaTime * _spawnPROPS_Delay;
		if (!(num2 < num4))
		{
			_spawnPROPS_Time = 0f;
			if (_PROPSactivationTimer != null)
			{
				_PROPSactivationTimer.Cancel();
			}
			Action onComplete = delegate
			{
				SpawnProps();
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer pROPSactivationTimer = Timers.Register(0.15f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_PROPSactivationTimer = pROPSactivationTimer;
		}
	}

	protected void SpawnProps()
	{
		//IL_020f: Expected O, but got I
		//IL_0068: Expected O, but got I
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ stack_-38_v3+1C]");
				if (obj2 == null)
				{
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ stack_-38_v3+18]");
					if ((nint)obj3 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ stack_-38_v3+10]");
						object obj5 = 0;
						object obj6 = obj4 + 1;
						GameManager core = GM.Core;
						Stage stage = core._stage;
						TilingTileset tilingTileset = stage._tilingTileset;
						if ((object)stage._tilingTileset != null && ((UnityEngine.Object)tilingTileset).m_CachedPtr != (IntPtr)0)
						{
							GameManager core2 = GM.Core;
							Stage stage2 = core2._stage;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v409 @ rdx_v10+20+v212 @ stack_-30_v2*4]");
							stage2.SpawnChosenDestructibleWallsCheck(PropType.CANDLE);
							obj4 = obj6;
						}
						else
						{
							GameManager core3 = GM.Core;
							Stage stage3 = core3._stage;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v409 @ rdx_v10+20+v212 @ stack_-30_v2*4]");
							stage3.SpawnChocenDestructibleOutOfSight(PropType.CANDLE, force: true, 2f);
							obj4 = obj6;
						}
						continue;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag = obj == null;
		CharacterController_FirstBlood characterController_FirstBlood = (CharacterController_FirstBlood)0;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ stack_-38_v3+1C]");
			if (obj2 == null)
			{
				return;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			characterController_FirstBlood = null;
		}
		throw new NullReferenceException();
	}

	public CharacterController_FirstBlood()
	{
		List<PropType> pROPSTypes = new List<PropType>();
		_PROPSTypes = pROPSTypes;
		base._002Ector();
	}

	private void _003COnUpdate_003Eb__9_0()
	{
		SpawnProps();
	}
}
