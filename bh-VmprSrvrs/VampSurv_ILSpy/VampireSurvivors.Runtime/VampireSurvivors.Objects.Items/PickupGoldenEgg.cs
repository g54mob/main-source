using System;
using System.Collections.Generic;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Cursors;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Items;

public class PickupGoldenEgg : NetworkPickup
{
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public PhaserSprite s;

		internal void _003CGetTaken_003Eb__0()
		{
			s.destroy();
			UnityEngine.Object.Destroy(s, 0f);
		}
	}

	private EggManager _eggManager;

	private uint _003CSeed_003Ek__BackingField;

	public uint Seed
	{
		get
		{
			return _003CSeed_003Ek__BackingField;
		}
		set
		{
			_003CSeed_003Ek__BackingField = value;
		}
	}

	private void Construct(EggManager eggManager)
	{
		_eggManager = eggManager;
	}

	protected override void Awake()
	{
		//IL_0016: Expected O, but got I4
		base.Awake();
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
	}

	public override void SetData(ItemType itemType)
	{
		//IL_00b1: Expected O, but got I
		//IL_01a6: Invalid comparison between I4 and F4
		//IL_0085: Expected O, but got I
		//IL_0112: Expected O, but got I8
		base.SetData(itemType);
		SpawnCursor();
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		bool flag = coherenceSync._003CEntityState_003Ek__BackingField == null;
		PickupGoldenEgg pickupGoldenEgg = this;
		if (!flag)
		{
			pickupGoldenEgg = (PickupGoldenEgg)(object)networkEntityState._003CAuthorityType_003Ek__BackingField;
			bool flag2 = (byte)(nint)((UnityEngine.Object)pickupGoldenEgg).m_CachedPtr != 0;
			if (((UnityEngine.Object)pickupGoldenEgg).m_CachedPtr != (IntPtr)1)
			{
				object obj = (nint)((UnityEngine.Object)pickupGoldenEgg).m_CachedPtr - 3;
				bool flag3 = obj == null;
				flag2 = flag3;
			}
			if (!flag2)
			{
				return;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj2 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			pickupGoldenEgg = (PickupGoldenEgg)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v170 @ rax_v13 (should have been resolved before IL gen)");
		uint num = default(uint);
		if (0f > 1f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
			_003CSeed_003Ek__BackingField = num;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rax,xmm0\"");
			_003CSeed_003Ek__BackingField = num;
		}
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float2 float5 = SafeXY();
		base.position = float5;
	}

	public override void Despawn()
	{
		base.Despawn();
		GameObject gameObject = base.gameObject;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4A10");
		GameManager core = GM.Core;
		bool flag = ((List<object>)(object)core._stagePickups).Remove((object)this);
	}

	public unsafe override void GetTaken()
	{
		//IL_0091: Expected O, but got I4
		//IL_0091: Expected I4, but got O
		//IL_0091: Expected O, but got Ref
		//IL_0106: Expected O, but got Ref
		//IL_058b: Expected O, but got I4
		//IL_0186: Expected O, but got I4
		//IL_01de: Expected O, but got I4
		//IL_03b6: Expected I, but got O
		//IL_042e: Expected O, but got I4
		//IL_043c: Expected O, but got I4
		//IL_044a: Expected O, but got I4
		//IL_0458: Expected O, but got I4
		//IL_05fd->IL04fc: Incompatible stack heights: 1 vs 0
		//IL_030c->IL04fc: Incompatible stack heights: 1 vs 0
		//IL_056f->IL04fc: Incompatible stack heights: 1 vs 0
		//IL_033b->IL04fc: Incompatible stack heights: 1 vs 0
		//IL_0387->IL04fc: Incompatible stack heights: 1 vs 0
		//IL_023c->IL04fc: Incompatible stack heights: 1 vs 0
		//IL_03fb->IL04fc: Incompatible stack heights: 1 vs 0
		//IL_025e->IL04fc: Incompatible stack heights: 1 vs 0
		//IL_03d9->IL03d9: Incompatible stack heights: 2 vs 1
		//IL_027b->IL0602: Incompatible stack heights: 1 vs 0
		//IL_04b7->IL04fc: Incompatible stack heights: 1 vs 0
		//IL_04d9->IL04fc: Incompatible stack heights: 1 vs 0
		//IL_04fc->IL0602: Incompatible stack heights: 1 vs 0
		if (((Pickup)this)._003CDisableGet_003Ek__BackingField)
		{
			return;
		}
		VampireSurvivors.Objects.Characters.CharacterController targetPlayer = _targetPlayer;
		if ((object)_targetPlayer != null)
		{
			Vector3 ret;
			Vector2 vector = default(Vector2);
			if (targetPlayer._characterType != CharacterType.SIGMA)
			{
				VampireSurvivors.Objects.Characters.CharacterController targetPlayer2 = _targetPlayer;
				if (_eggManager != null)
				{
					object obj = default(object);
					KeyValuePair<string, float> keyValuePair = ((EggManager)(&obj)).AddGoldenEgg((CharacterType)_eggManager, (Unity.Mathematics.Random?)(object)targetPlayer2._characterType);
					if ((object)_targetPlayer != null)
					{
						Transform transform = _targetPlayer.transform;
						if ((object)transform != null)
						{
							bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
							if (_eggManager != null)
							{
								float num = default(float);
								_eggManager.ShowResultAt(vector, (KeyValuePair<string, float>)(&obj), -16f, num);
								base.AddToRunPickups();
								base.SetHasSeenItem();
								if (!_taken)
								{
									((Pickup)this).GetTaken();
									_taken = true;
								}
								PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Roast, new SoundManager.SoundConfig
								{
									Volume = (float?)(object)1,
									Rate = 1f,
									Detune = 200f
								}, 0f, 10, num);
								PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Roast, new SoundManager.SoundConfig
								{
									Volume = (float?)(object)1,
									Rate = 1f,
									Detune = 400f
								}, 0f, 10, num);
								PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.Roast, new SoundManager.SoundConfig
								{
									Volume = (float?)(object)1,
									Rate = 1f,
									Detune = 600f
								}, 0f, 10, num);
								GameManager core = GM.Core;
								if ((object)GM.Core != null && core._stagePickups != null)
								{
									bool flag2 = ((List<object>)(object)core._stagePickups).Remove((object)this);
									return;
								}
							}
						}
					}
				}
			}
			else
			{
				_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass10_0();
				if ((object)_targetPlayer != null)
				{
					Transform transform2 = _targetPlayer.transform;
					if ((object)transform2 != null)
					{
						bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
						PhaserWorld instance = PhaserWorld.Instance;
						if ((object)instance != null)
						{
							PhaserSprite phaserSprite = instance.AddPhaserSprite(vector, "items", "goldenegg");
							if ((object)phaserSprite != null)
							{
								PhaserSprite s = phaserSprite.setDepth(1);
								if (CS_0024_003C_003E8__locals5 != null)
								{
									CS_0024_003C_003E8__locals5.s = s;
									TweenConfig tweenConfig = new TweenConfig();
									object[] array = new object[1];
									if (array != null)
									{
										if ((object)CS_0024_003C_003E8__locals5.s != null)
										{
											nint num2 = (nint)array;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj2 = default(object);
											bool flag4 = obj2 == null;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										if (tweenConfig != null)
										{
											tweenConfig.targets = array;
											tweenConfig.duration = 500f;
											tweenConfig.x = (float?)(object)1;
											tweenConfig.y = (float?)(object)1;
											tweenConfig.scale = (float?)(object)1;
											tweenConfig.angle = (float?)(object)1;
											TweenCallback onComplete = delegate
											{
												CS_0024_003C_003E8__locals5.s.destroy();
												UnityEngine.Object.Destroy(CS_0024_003C_003E8__locals5.s, 0f);
											};
											tweenConfig.onComplete = onComplete;
											MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
											GameManager core2 = GM.Core;
											if ((object)GM.Core != null && core2._stagePickups != null)
											{
												bool flag5 = ((List<object>)(object)core2._stagePickups).Remove((object)this);
												Despawn();
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

	private void SpawnCursor()
	{
		//IL_01b7: Expected O, but got I4
		//IL_0029->IL0159: Incompatible stack heights: 1 vs 0
		//IL_0055->IL0159: Incompatible stack heights: 1 vs 0
		//IL_0144->IL0159: Incompatible stack heights: 1 vs 0
		GameObject gameObject = base.gameObject;
		if ((object)gameObject != null)
		{
			bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
			object obj = GameObject.get_activeInHierarchy_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
			if (obj == null)
			{
				return;
			}
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null)
				{
					if (!config._003CShowPickups_003Ek__BackingField)
					{
						return;
					}
					CursorData cursorData = new CursorData
					{
						IconAlpha = 1f,
						_cursorProportionOfScreenFromCenter = 0.45f,
						AnimationName = "arrow_0"
					};
					_ = 1;
					_ = 8;
					_ = 16;
					Sprite sprite = SpriteManager.GetSprite("arrow_01", "UI");
					_ = 1065353216;
					_ = 1065353216;
					Sprite sprite2 = SpriteManager.GetSprite("goldenegg", "items");
					GameObject gameObject2 = base.gameObject;
					if (_signalBus != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4920");
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void RemoveCursor()
	{
		Transform transform = base.transform;
		GameObject gameObject = transform.gameObject;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4A10");
	}

	protected override void ToggleCursors(UISignals.ToggleGuidesSignal sig)
	{
		if ((object)sig == null)
		{
			Transform transform = base.transform;
			GameObject gameObject = transform.gameObject;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4A10");
		}
		else
		{
			SpawnCursor();
		}
	}
}
