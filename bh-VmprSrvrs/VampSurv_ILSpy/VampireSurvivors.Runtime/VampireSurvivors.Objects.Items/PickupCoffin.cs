using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Newtonsoft.Json.Linq;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Cursors;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Signals;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Items;

public class PickupCoffin : PickupGuarded
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<VampireSurvivors.Objects.Characters.CharacterController, bool> _003C_003E9__30_2;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CGetTaken_003Eb__30_2(VampireSurvivors.Objects.Characters.CharacterController player)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)player != null)
			{
				object obj = player._characterType - 229;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass30_0
	{
		public PickupCoffin _003C_003E4__this;

		public VampireSurvivors.Objects.Characters.CharacterController targetPlayer;

		internal void _003CGetTaken_003Eb__0()
		{
			PickupCoffin pickupCoffin = _003C_003E4__this;
			pickupCoffin._charSprite.enabled = false;
		}

		internal unsafe void _003CGetTaken_003Eb__1()
		{
			//IL_0057: Expected I4, but got O
			//IL_007c: Expected O, but got Ref
			//IL_014c: Expected O, but got Ref
			PickupCoffin pickupCoffin = _003C_003E4__this;
			pickupCoffin._lid.enabled = false;
			PickupCoffin pickupCoffin2 = _003C_003E4__this;
			System.ParamsArray paramsArray = default(System.ParamsArray);
			if (pickupCoffin2._003CCharCff_003Ek__BackingField != CharacterType.TP_DRACULA)
			{
				object obj = default(object);
				object arg = (CharacterType)obj;
				paramsArray = new System.ParamsArray(arg);
				object obj2 = default(object);
				string message = string.FormatHelper((IFormatProvider)null, "Opened coffin by {0}", (System.ParamsArray)(&obj2));
				Debug.Log(message);
				GameManager gameManager = pickupCoffin2._gameManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rax_v6 (VampireSurvivors.Objects.Items.PickupCoffin)+220]");
				gameManager.AddCharacterTypeToQueue(CharacterType.VOID, targetPlayer);
				pickupCoffin2.SetHasSeenItem();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rax_v6 (VampireSurvivors.Objects.Items.PickupCoffin)+160]");
				if ((nint)0 == 0)
				{
					((Pickup)pickupCoffin2).GetTaken();
					_ = 1;
				}
				return;
			}
			GameManager core = GM.Core;
			Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__30_2;
			if (_003C_003Ec._003C_003E9__30_2 == null)
			{
				predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__30_2 = delegate(VampireSurvivors.Objects.Characters.CharacterController player)
				{
					//IL_0052: Expected I4, but got O
					//IL_0030: Expected O, but got I4
					if ((object)player == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
					object obj4 = player._characterType - 229;
					return obj4 == null;
				});
			}
			object obj3 = Enumerable.FirstOrDefault(core._characters, predicate);
			PickupCoffin pickupCoffin3 = _003C_003E4__this;
			VampireSurvivors.Objects.Characters.CharacterController characterController = Enumerable.FirstOrDefault((IEnumerable<VampireSurvivors.Objects.Characters.CharacterController>)pickupCoffin3._signalBus, (Func<VampireSurvivors.Objects.Characters.CharacterController, bool>)(&paramsArray));
		}
	}

	private SpriteRenderer _charSprite;

	private SpriteRenderer _lid;

	private bool _isOpened;

	private Tween _charScaleTween;

	private Tween _charMoveTween;

	private Sequence _lidTween;

	private Vector2 _lidStartPosition;

	private string _003CLidSpriteName_003Ek__BackingField;

	private CharacterType _003CCharCff_003Ek__BackingField;

	public Action OnGotTaken;

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

	public string LidSpriteName
	{
		get
		{
			return _003CLidSpriteName_003Ek__BackingField;
		}
		set
		{
			_003CLidSpriteName_003Ek__BackingField = value;
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
		//IL_016c: Expected O, but got I4
		//IL_014a: Expected O, but got Ref
		//IL_0058->IL014f: Incompatible stack heights: 1 vs 0
		//IL_0087->IL014f: Incompatible stack heights: 1 vs 0
		//IL_00b3->IL014f: Incompatible stack heights: 1 vs 0
		//IL_00fe->IL014f: Incompatible stack heights: 2 vs 0
		base.Awake();
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		Transform cachedTransform = _cachedTransform;
		((Pickup)this)._003CIsStationary_003Ek__BackingField = true;
		_canPauseSyncTimer = false;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			GameObject gameObject = base.gameObject;
			Vector2 pos = default(Vector2);
			SpriteRenderer lid = RenderingExtensions.AddSprite(gameObject, pos, "items", "CoffinLid");
			_lid = lid;
			if ((object)_lid != null)
			{
				_lid.enabled = false;
				if ((object)_lid != null)
				{
					Transform transform = _lid.transform;
					if ((object)transform != null)
					{
						bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Vector2 ret2;
						Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret2));
						_lidStartPosition = ret2;
						GameObject gameObject2 = base.gameObject;
						SpriteRenderer charSprite = RenderingExtensions.AddSprite(gameObject2, pos, null, null);
						_charSprite = charSprite;
						if ((object)_charSprite != null)
						{
							_charSprite.enabled = false;
							SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_charSprite, 0f);
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
							SpriteRenderer spriteRenderer2 = RenderingExtensions.SetTintFill(_charSprite, isEnabled: true, (Color?)(object)(&ret2));
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void SetData(ItemType itemType)
	{
		//IL_00a8: Expected O, but got I4
		//IL_00a8: Expected O, but got I4
		((Pickup)this).SetData(itemType);
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
		SpawnCursor();
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
		bool flag = AnyGuardsAlive();
		if (!flag && _isOpened == flag)
		{
			CheckSpawnParticles();
		}
	}

	public unsafe void SetChar(CharacterType characterType)
	{
		//IL_0172: Expected O, but got Ref
		//IL_0051: Expected I, but got O
		//IL_00f8: Expected O, but got I
		//IL_00f8: Expected O, but got I
		//IL_01e6->IL0148: Incompatible stack heights: 1 vs 0
		CharacterType characterType2 = default(CharacterType);
		object arg = characterType2;
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		System.ParamsArray paramsArray2 = default(System.ParamsArray);
		string message = string.FormatHelper((IFormatProvider)null, "Setting Coffin Character: {0}", (System.ParamsArray)(&paramsArray2));
		Debug.Log(message);
		_003CCharCff_003Ek__BackingField = characterType;
		DataManager dataManager = _dataManager;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)_003CCharCff_003Ek__BackingField);
		nint num = (nint)obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v326 @ r8_v7 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ rax_v20 (System.Object)+48]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ rax_v20 (System.Object)+40]");
			Sprite sprite = SpriteManager.GetSprite((string)num2, (string)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rbx_v10 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			bool flag2 = (object)sprite == null;
			nint value = 0;
			if (!flag2)
			{
				value = ((UnityEngine.Object)sprite).m_CachedPtr;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rbx_v10 (System.Object)+10]");
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
		bool flag = !_ShowAboveAll;
		int num2 = default(int);
		int sortingOrder = num2;
		if (!flag)
		{
			sortingOrder = 1991;
		}
		_lid.sortingOrder = sortingOrder;
	}

	public void SetWhiteCoffinSprites()
	{
		SetFrame("CoffinW");
		_003CLidSpriteName_003Ek__BackingField = "CoffinLidW";
		Sprite sprite = SpriteManager.GetSprite(_003CLidSpriteName_003Ek__BackingField, _textureName);
		_lid.sprite = sprite;
	}

	public override void GetOnlineTaken()
	{
		if (!AnyGuardsAlive())
		{
			base.GetOnlineTaken();
		}
	}

	private void OnLidSpriteChanged(string old, string newSprite)
	{
		if (newSprite != null && newSprite._stringLength > 0)
		{
			Sprite sprite = SpriteManager.GetSprite(newSprite, _textureName);
			_lid.sprite = sprite;
		}
	}

	protected override void OnRecycle()
	{
		base.OnRecycle();
		SetFrame("Coffin");
		if ((object)_itemRenderer != null)
		{
			_itemRenderer.enabled = true;
			Sprite sprite = SpriteManager.GetSprite("CoffinLid", _textureName);
			if ((object)_lid != null)
			{
				_lid.sprite = sprite;
				if ((object)_lid != null)
				{
					_lid.enabled = true;
					_isOpened = false;
					if ((object)_lid != null)
					{
						Transform transform = _lid.transform;
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Vector3 value = default(Vector3);
						Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
						Transform transform2 = _charSprite.transform;
						bool flag2 = (object)transform2 == null;
						bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Vector3 value2 = default(Vector3);
						Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe override void GetTaken()
	{
		//IL_00ce: Expected O, but got I4
		//IL_0150: Expected O, but got Ref
		//IL_03cd: Expected O, but got Ref
		//IL_052a: Expected F4, but got I4
		//IL_0221->IL05fe: Incompatible stack heights: 1 vs 0
		//IL_024d->IL05fe: Incompatible stack heights: 1 vs 0
		//IL_05ea->IL062b: Incompatible stack heights: 2 vs 0
		//IL_05fe->IL062b: Incompatible stack heights: 2 vs 0
		_003C_003Ec__DisplayClass30_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass30_0();
		if (CS_0024_003C_003E8__locals8 != null)
		{
			CS_0024_003C_003E8__locals8._003C_003E4__this = this;
			if (((Pickup)this)._003CDisableGet_003Ek__BackingField || _isOpened || AnyGuardsAlive())
			{
				return;
			}
			_isOpened = true;
			GameObject gameObject = base.gameObject;
			if (_signalBus != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4A10");
				SoundManager.FadeMusic(SoundManager._003CCurrentBgm_003Ek__BackingField, 0.1f, 100f);
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Volume = (float?)(object)1;
				soundConfig.Rate = 1f;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Lid, soundConfig, 150f, 2, time);
				Bounds bounds = CameraExtensions.OrthographicBounds(_camera);
				if ((object)_charSprite != null)
				{
					Transform transform = _charSprite.transform;
					Vector3 ret = default(Vector3);
					TweenerCore<Vector3, Vector3, VectorOptions> gameId = ShortcutExtensions.DOScale(transform, (Vector3)(&ret), 0.1f);
					Tween charScaleTween = VampireSurvivors.Tools.TweenExtensions.SetGameId(gameId);
					_charScaleTween = charScaleTween;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v30 (UnityEngine.Bounds)+10]");
						float num = 0f * 2f;
						object obj = default(object);
						float endValue = (float)obj + num;
						TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOMoveY(transform, endValue, 0.4f);
						TweenCallback tweenCallback = delegate
						{
							PickupCoffin pickupCoffin = CS_0024_003C_003E8__locals8._003C_003E4__this;
							pickupCoffin._charSprite.enabled = false;
						};
						if (tweenerCore != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v950 @ rax_v40 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
							if ((nint)0 == 0)
							{
							}
						}
						Tween charMoveTween = VampireSurvivors.Tools.TweenExtensions.SetGameId(tweenerCore);
						_charMoveTween = charMoveTween;
						if ((object)_lid != null)
						{
							Transform transform2 = _lid.transform;
							if ((object)transform2 != null)
							{
								bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
								CS_0024_003C_003E8__locals8.targetPlayer = _targetPlayer;
								Sequence lidTween = DOTween.Sequence();
								_lidTween = lidTween;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v30 (UnityEngine.Bounds)+10]");
								float num2 = 0f * 2f;
								float num3 = num2 * 0.75f;
								float endValue2 = num3 + (float)obj;
								TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOMoveY(transform2, endValue2, 0.5f);
								if (TweenSettingsExtensions.ValidateAddToSequence(_lidTween, (Tween)t, false))
								{
									Sequence sequence = Sequence.DoInsert(_lidTween, (Tween)t, 0f);
								}
								object obj2 = default(object);
								float num4 = (float)obj2 * 2f;
								float num5 = num4 * 0.75f;
								float endValue3 = (float)ret - num5;
								TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOMoveX(transform2, endValue3, 0.5f);
								if (TweenSettingsExtensions.ValidateAddToSequence(_lidTween, (Tween)t2, false))
								{
									Sequence sequence2 = Sequence.DoInsert(_lidTween, (Tween)t2, 0f);
								}
								TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DOLocalRotate(transform2, (Vector3)(&ret), 0.5f, RotateMode.FastBeyond360);
								if (tweenerCore2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1189 @ rax_v63 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1189 @ rax_v63 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
										if ((nint)0 == 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1189 @ rax_v63 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
											if ((nint)0 == 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1189 @ rax_v63 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
												if ((nint)0 == 0)
												{
													_ = 1;
												}
											}
										}
									}
								}
								if (TweenSettingsExtensions.ValidateAddToSequence(_lidTween, (Tween)tweenerCore2, false))
								{
									Sequence sequence3 = Sequence.DoInsert(_lidTween, (Tween)tweenerCore2, 0f);
								}
								TweenerCore<Vector3, Vector3, VectorOptions> t3 = ShortcutExtensions.DOScaleX(transform2, -1f, 0.5f);
								bool flag3 = TweenSettingsExtensions.ValidateAddToSequence(_lidTween, (Tween)t3, false);
								bool flag4 = !flag3;
								float num6 = 0.5f;
								if (!flag4)
								{
									Sequence sequence4 = Sequence.DoInsert(_lidTween, (Tween)t3, 0f);
									num6 = 0f;
								}
								Sequence sequence5 = VampireSurvivors.Tools.TweenExtensions.SetGameId(_lidTween);
								Sequence lidTween2 = _lidTween;
								TweenCallback onComplete = delegate
								{
									//IL_0057: Expected I4, but got O
									//IL_007c: Expected O, but got Ref
									//IL_014c: Expected O, but got Ref
									PickupCoffin pickupCoffin = CS_0024_003C_003E8__locals8._003C_003E4__this;
									pickupCoffin._lid.enabled = false;
									PickupCoffin pickupCoffin2 = CS_0024_003C_003E8__locals8._003C_003E4__this;
									System.ParamsArray paramsArray = default(System.ParamsArray);
									if (pickupCoffin2._003CCharCff_003Ek__BackingField != CharacterType.TP_DRACULA)
									{
										object obj3 = default(object);
										object arg = (CharacterType)obj3;
										paramsArray = new System.ParamsArray(arg);
										object obj4 = default(object);
										string message = string.FormatHelper((IFormatProvider)null, "Opened coffin by {0}", (System.ParamsArray)(&obj4));
										Debug.Log(message);
										GameManager gameManager = pickupCoffin2._gameManager;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rax_v6 (VampireSurvivors.Objects.Items.PickupCoffin)+220]");
										gameManager.AddCharacterTypeToQueue(CharacterType.VOID, CS_0024_003C_003E8__locals8.targetPlayer);
										pickupCoffin2.SetHasSeenItem();
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rax_v6 (VampireSurvivors.Objects.Items.PickupCoffin)+160]");
										if ((nint)0 == 0)
										{
											((Pickup)pickupCoffin2).GetTaken();
											_ = 1;
										}
									}
									else
									{
										GameManager core = GM.Core;
										Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__30_2;
										if (_003C_003Ec._003C_003E9__30_2 == null)
										{
											predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__30_2 = delegate(VampireSurvivors.Objects.Characters.CharacterController player)
											{
												//IL_0052: Expected I4, but got O
												//IL_0030: Expected O, but got I4
												if ((object)player == null)
												{
													NullReferenceException ex = new NullReferenceException();
													return (byte)(int)ex != 0;
												}
												object obj6 = player._characterType - 229;
												return obj6 == null;
											});
										}
										object obj5 = Enumerable.FirstOrDefault(core._characters, predicate);
										PickupCoffin pickupCoffin3 = CS_0024_003C_003E8__locals8._003C_003E4__this;
										VampireSurvivors.Objects.Characters.CharacterController characterController = Enumerable.FirstOrDefault((IEnumerable<VampireSurvivors.Objects.Characters.CharacterController>)pickupCoffin3._signalBus, (Func<VampireSurvivors.Objects.Characters.CharacterController, bool>)(&paramsArray));
									}
								};
								bool flag5 = _lidTween == null;
								nint num7 = 0;
								if (!flag5)
								{
									bool flag6 = !((Tween)lidTween2)._003Cactive_003Ek__BackingField;
									num7 = 0;
									if (!flag6)
									{
										lidTween2.onComplete = onComplete;
										num7 = 0;
									}
								}
								Action onGotTaken = OnGotTaken;
								if (OnGotTaken != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v386.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
								}
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void PlaySfx()
	{
		//IL_003a: Expected O, but got I4
		SoundManager.FadeMusic(SoundManager._003CCurrentBgm_003Ek__BackingField, 0.1f, 100f);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Lid, soundConfig, 150f, 2, time);
	}

	private unsafe void TriggerCharacterPanel(VampireSurvivors.Objects.Characters.CharacterController targetPlayer)
	{
		//IL_000e: Expected I4, but got O
		//IL_0033: Expected O, but got Ref
		object obj = default(object);
		object arg = (CharacterType)obj;
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj2 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "Opened coffin by {0}", (System.ParamsArray)(&obj2));
		Debug.Log(message);
		_gameManager.AddCharacterTypeToQueue(_003CCharCff_003Ek__BackingField, targetPlayer);
		base.SetHasSeenItem();
		if (!_taken)
		{
			((Pickup)this).GetTaken();
			_taken = true;
		}
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
					_ = 1073741824;
					_ = 1065353216;
					Sprite sprite2 = SpriteManager.GetSprite("Coff", "UI");
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

	protected void OnCharacterSetRemotely(int old, int newChar)
	{
		SetChar((CharacterType)newChar);
	}
}
