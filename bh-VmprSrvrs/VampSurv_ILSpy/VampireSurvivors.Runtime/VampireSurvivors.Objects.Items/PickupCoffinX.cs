using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Newtonsoft.Json.Linq;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Items;

public class PickupCoffinX : PickupGuarded
{
	private SpriteRenderer _charSprite;

	private SpriteRenderer _lid;

	private bool _isOpened;

	private Tween _charScaleTween;

	private Tween _charMoveTween;

	private Sequence _lidTween;

	private CharacterType _003CCharCff_003Ek__BackingField;

	public int SyncedCharCff
	{
		get
		{
			return (int)_003CCharCff_003Ek__BackingField;
		}
		set
		{
			_003CCharCff_003Ek__BackingField = (CharacterType)value;
		}
	}

	private CharacterType CharCff
	{
		get
		{
			return _003CCharCff_003Ek__BackingField;
		}
		set
		{
			_003CCharCff_003Ek__BackingField = value;
		}
	}

	protected override bool UsesOrderedCommand => true;

	protected unsafe override void Awake()
	{
		//IL_011c: Expected O, but got I4
		//IL_00fa: Expected O, but got Ref
		//IL_0058->IL00ff: Incompatible stack heights: 1 vs 0
		//IL_00ae->IL00ff: Incompatible stack heights: 1 vs 0
		base.Awake();
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		Transform cachedTransform = _cachedTransform;
		((Pickup)this)._003CIsStationary_003Ek__BackingField = true;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret);
			GameObject gameObject = base.gameObject;
			Vector2 pos = default(Vector2);
			SpriteRenderer lid = RenderingExtensions.AddSprite(gameObject, pos, "items", "CoffinLid");
			_lid = lid;
			if ((object)_lid != null)
			{
				_lid.enabled = false;
				GameObject gameObject2 = base.gameObject;
				SpriteRenderer charSprite = RenderingExtensions.AddSprite(gameObject2, pos, null, null);
				_charSprite = charSprite;
				if ((object)_charSprite != null)
				{
					_charSprite.enabled = false;
					SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_charSprite, 0f);
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
					SpriteRenderer spriteRenderer2 = RenderingExtensions.SetTintFill(_charSprite, isEnabled: true, (Color?)(object)(&ret));
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void SetData(ItemType itemType)
	{
		//IL_009d: Expected O, but got I4
		//IL_009d: Expected O, but got I4
		((Pickup)this).SetData(ItemType.COFFIN);
		((Pickup)this)._003CResRosary_003Ek__BackingField = 1f;
		OnRecycle();
		if (_charScaleTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_charScaleTween);
		}
		if (_charMoveTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_charMoveTween);
		}
		if (_lidTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_lidTween);
		}
		BaseBody baseBody = body.setCircle(16f, (float?)(object)1, (float?)(object)1);
		SetFrame("Coffin");
		_lid.enabled = true;
		_charSprite.enabled = true;
		((Pickup)this)._003CResRosary_003Ek__BackingField = 1f;
	}

	public override void InternalUpdate()
	{
		((Pickup)this).InternalUpdate();
		if (!_hasSpawned && IsAnyPlayerInGuardSpawnRange())
		{
			base.TriggerSpawn();
		}
		if (!AnyGuardsAlive())
		{
			CheckSpawnParticles();
		}
	}

	public void SetChar(CharacterType characterType)
	{
		//IL_002a: Expected I, but got O
		//IL_00ca: Expected O, but got I
		//IL_019f->IL011a: Incompatible stack heights: 1 vs 0
		_003CCharCff_003Ek__BackingField = characterType;
		DataManager dataManager = _dataManager;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)_003CCharCff_003Ek__BackingField);
		nint num = (nint)obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v269 @ r8_v5 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
		JToken jToken = default(JToken);
		object obj2 = jToken.ToObject<object>();
		if (obj2 != null)
		{
			List<string> texturesForCharacterType = CharacterLoader.GetTexturesForCharacterType(characterType, _playerOptions, _dataManager);
			List<string>.Enumerator enumerator = default(List<string>.Enumerator);
			while (enumerator.MoveNext())
			{
				CharacterLoader.LoadCharacterTexture(null, characterType, _dataManager, "Gameplay");
			}
			object charSprite = _charSprite;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v15 (System.Object)+40]");
			Sprite sprite = SpriteManager.GetSprite("random_00", (string)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rbx_v9 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			bool flag2 = (object)sprite == null;
			nint value = 0;
			if (!flag2)
			{
				value = ((UnityEngine.Object)sprite).m_CachedPtr;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rbx_v9 (System.Object)+10]");
			SpriteRenderer.set_sprite_Injected((IntPtr)0, (IntPtr)value);
		}
	}

	public override void UpdateDepth()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num = default(int);
		if (_ShowAboveAll)
		{
			num = 1990;
		}
		ArcadeSprite arcadeSprite = setDepth(num);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int sortingOrder = default(int);
		_lid.sortingOrder = sortingOrder;
	}

	protected override void OnRecycle()
	{
		base.OnRecycle();
		SetFrame("Coffin");
		_itemRenderer.enabled = true;
		Sprite sprite = SpriteManager.GetSprite("CoffinLid", _textureName);
		_lid.sprite = sprite;
		_lid.enabled = true;
		Transform transform = _charSprite.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	public override void GetOnlineTaken()
	{
		if (!AnyGuardsAlive())
		{
			base.GetOnlineTaken();
		}
	}

	public override void GetTaken()
	{
		//IL_0103: Expected O, but got I4
		//IL_022f: Expected I, but got O
		//IL_0294: Expected O, but got I4
		//IL_02b0: Expected O, but got I4
		//IL_0354: Expected I, but got O
		//IL_0651: Expected O, but got I4
		//IL_047f: Expected I, but got O
		//IL_04e4: Expected O, but got I4
		//IL_0500: Expected O, but got I4
		//IL_050e: Expected O, but got I4
		//IL_051c: Expected O, but got I4
		//IL_01d9->IL0556: Incompatible stack heights: 1 vs 0
		//IL_0205->IL0556: Incompatible stack heights: 1 vs 0
		//IL_0274->IL0556: Incompatible stack heights: 1 vs 0
		//IL_0252->IL0252: Incompatible stack heights: 2 vs 1
		//IL_02fe->IL0556: Incompatible stack heights: 1 vs 0
		//IL_032a->IL0556: Incompatible stack heights: 1 vs 0
		//IL_0399->IL0556: Incompatible stack heights: 1 vs 0
		//IL_0377->IL0377: Incompatible stack heights: 2 vs 1
		//IL_03d1->IL0556: Incompatible stack heights: 1 vs 0
		//IL_0429->IL0556: Incompatible stack heights: 2 vs 0
		//IL_0455->IL0556: Incompatible stack heights: 2 vs 0
		//IL_04c4->IL0556: Incompatible stack heights: 2 vs 0
		//IL_04a2->IL04a2: Incompatible stack heights: 3 vs 2
		//IL_0556->IL057f: Incompatible stack heights: 2 vs 0
		if (((Pickup)this)._003CDisableGet_003Ek__BackingField || _isOpened || AnyGuardsAlive())
		{
			return;
		}
		_isOpened = true;
		GameObject gameObject = base.gameObject;
		if (_signalBus != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4A10");
			GameManager core = GM.Core;
			if ((object)GM.Core != null && core._playerOptions != null)
			{
				PlayerOptionsData config = core._playerOptions.Config;
				bool flag = core._playerOptions.UnlockSecret(SecretType.UnderTheCoffin, config);
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Rate = 1f;
				soundConfig.Volume = (float?)(object)1;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Lid, soundConfig, 150f, 2, time);
				Bounds bounds = CameraExtensions.OrthographicBounds(_camera);
				if ((object)_charSprite != null)
				{
					Transform transform = _charSprite.transform;
					if ((object)_lid != null)
					{
						Transform transform2 = _lid.transform;
						if ((object)transform2 != null)
						{
							bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
							TweenConfig tweenConfig = new TweenConfig();
							object[] array = new object[1];
							if ((object)_charSprite != null)
							{
								Transform transform3 = _charSprite.transform;
								if (array != null)
								{
									if ((object)transform3 != null)
									{
										nint num = (nint)array;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										object obj = default(object);
										bool flag3 = obj == null;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									if (tweenConfig != null)
									{
										tweenConfig.targets = array;
										tweenConfig.scaleX = (float?)(object)1;
										tweenConfig.duration = 100f;
										tweenConfig.scaleY = (float?)(object)1;
										MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
										TweenConfig tweenConfig2 = new TweenConfig();
										object[] array2 = new object[1];
										if ((object)_charSprite != null)
										{
											Transform transform4 = _charSprite.transform;
											if (array2 != null)
											{
												if ((object)transform4 != null)
												{
													nint num2 = (nint)array2;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
													object obj2 = default(object);
													bool flag4 = obj2 == null;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												if (tweenConfig2 != null)
												{
													tweenConfig2.targets = array2;
													tweenConfig2.duration = 400f;
													if ((object)transform != null)
													{
														bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
														Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v455 @ rax_v35 (UnityEngine.Bounds)+10]");
														float num3 = 0f * 2f;
														object obj3 = default(object);
														float num4 = (float)obj3 + num3;
														tweenConfig2.y = (float?)(object)1;
														TweenCallback onComplete = delegate
														{
															_charSprite.enabled = false;
														};
														tweenConfig2.onComplete = onComplete;
														MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
														TweenConfig tweenConfig3 = new TweenConfig();
														object[] array3 = new object[1];
														if ((object)_lid != null)
														{
															Transform transform5 = _lid.transform;
															if (array3 != null)
															{
																if ((object)transform5 != null)
																{
																	nint num5 = (nint)array3;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																	object obj4 = default(object);
																	bool flag6 = obj4 == null;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																if (tweenConfig3 != null)
																{
																	tweenConfig3.targets = array3;
																	tweenConfig3.x = (float?)(object)1;
																	tweenConfig3.duration = 500f;
																	tweenConfig3.y = (float?)(object)1;
																	tweenConfig3.angle = (float?)(object)1;
																	tweenConfig3.scaleX = (float?)(object)1;
																	TweenCallback onComplete2 = delegate
																	{
																		//IL_00d7: Expected O, but got I4
																		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
																		soundConfig2.Volume = (float?)(object)1;
																		soundConfig2.Detune = -1000f;
																		soundConfig2.Rate = 0.5f;
																		float time2 = default(float);
																		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.ThingFound, soundConfig2, 0f, 10, time2);
																		_lid.enabled = false;
																		GameManager core2 = GM.Core;
																		core2._playerOptions.UnlockCharacter(_003CCharCff_003Ek__BackingField);
																		GameManager core3 = GM.Core;
																		core3._playerOptions.Save();
																		base.SetHasSeenItem();
																		if (!_taken)
																		{
																			((Pickup)this).GetTaken();
																			_taken = true;
																		}
																	};
																	tweenConfig3.onComplete = onComplete2;
																	MultiTargetTween multiTargetTween3 = Tweens.Add(tweenConfig3);
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
		throw new NullReferenceException();
	}

	protected void OnCharacterSetRemotely(int old, int newChar)
	{
		SetChar((CharacterType)newChar);
	}

	private void _003CGetTaken_003Eb__22_0()
	{
		_charSprite.enabled = false;
	}

	private void _003CGetTaken_003Eb__22_1()
	{
		//IL_00d7: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = -1000f;
		soundConfig.Rate = 0.5f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ThingFound, soundConfig, 0f, 10, time);
		_lid.enabled = false;
		GameManager core = GM.Core;
		core._playerOptions.UnlockCharacter(_003CCharCff_003Ek__BackingField);
		GameManager core2 = GM.Core;
		core2._playerOptions.Save();
		base.SetHasSeenItem();
		if (!_taken)
		{
			((Pickup)this).GetTaken();
			_taken = true;
		}
	}
}
