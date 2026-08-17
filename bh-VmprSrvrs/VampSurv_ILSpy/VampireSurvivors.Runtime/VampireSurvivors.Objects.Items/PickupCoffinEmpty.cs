using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Cursors;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Signals;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Items;

public class PickupCoffinEmpty : PickupGuarded
{
	private sealed class _003C_003Ec__DisplayClass24_0
	{
		public Transform textObjectTrans;

		public TextMeshPro textValue;

		public GameObject textObject;

		public TweenCallback _003C_003E9__3;

		public TweenCallback _003C_003E9__2;

		internal void _003CGetTaken_003Eb__1()
		{
			//IL_0049: Expected I, but got O
			//IL_01b2: Expected O, but got I4
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if (array != null)
			{
				if ((object)textObjectTrans != null)
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
				if (tweenConfig != null)
				{
					tweenConfig.targets = array;
					Transform transform = textObjectTrans;
					if ((object)textObjectTrans != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						tweenConfig.duration = 2000f;
						tweenConfig.y = (float?)(object)1;
						TweenCallback onComplete = _003C_003E9__2;
						if (_003C_003E9__2 == null)
						{
							onComplete = (_003C_003E9__2 = delegate
							{
								//IL_002c: Expected I, but got O
								//IL_0082: Expected O, but got I4
								TweenConfig tweenConfig2 = new TweenConfig();
								object[] array2 = new object[1];
								if ((object)textValue != null)
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
								tweenConfig2.alpha = (float?)(object)1;
								tweenConfig2.duration = 1000f;
								TweenCallback onComplete2 = _003C_003E9__3;
								if (_003C_003E9__3 == null)
								{
									onComplete2 = (_003C_003E9__3 = delegate
									{
										UnityEngine.Object.Destroy(textObject, 0f);
									});
								}
								tweenConfig2.onComplete = onComplete2;
								MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
							});
						}
						tweenConfig.onComplete = onComplete;
						MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
						return;
					}
				}
			}
			throw new NullReferenceException();
		}

		internal void _003CGetTaken_003Eb__2()
		{
			//IL_002c: Expected I, but got O
			//IL_0082: Expected O, but got I4
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if ((object)textValue != null)
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
			tweenConfig.alpha = (float?)(object)1;
			tweenConfig.duration = 1000f;
			TweenCallback onComplete = _003C_003E9__3;
			if (_003C_003E9__3 == null)
			{
				onComplete = (_003C_003E9__3 = delegate
				{
					UnityEngine.Object.Destroy(textObject, 0f);
				});
			}
			tweenConfig.onComplete = onComplete;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		}

		internal void _003CGetTaken_003Eb__3()
		{
			UnityEngine.Object.Destroy(textObject, 0f);
		}
	}

	private SpriteRenderer _charSprite;

	private SpriteRenderer _lid;

	private bool _isOpened;

	private Tween _charScaleTween;

	private Tween _charMoveTween;

	private Sequence _lidTween;

	private CharacterType _003CCharCff_003Ek__BackingField;

	private Action _003COnOpen_003Ek__BackingField;

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

	public Action OnOpen
	{
		get
		{
			return _003COnOpen_003Ek__BackingField;
		}
		set
		{
			_003COnOpen_003Ek__BackingField = value;
		}
	}

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
		if (!AnyGuardsAlive())
		{
			CheckSpawnParticles();
		}
	}

	public void SetChar(CharacterType characterType)
	{
		//IL_0039: Expected I, but got O
		//IL_00e0: Expected O, but got I
		//IL_00e0: Expected O, but got I
		//IL_01c3->IL0130: Incompatible stack heights: 1 vs 0
		_003CCharCff_003Ek__BackingField = characterType;
		if (characterType == CharacterType.VOID)
		{
			return;
		}
		DataManager dataManager = _dataManager;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)_003CCharCff_003Ek__BackingField);
		nint num = (nint)obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v334 @ r8_v6 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v16 (System.Object)+48]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v16 (System.Object)+40]");
			Sprite sprite = SpriteManager.GetSprite((string)num2, (string)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rbx_v9 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			bool flag2 = (object)sprite == null;
			nint value = 0;
			if (!flag2)
			{
				value = ((UnityEngine.Object)sprite).m_CachedPtr;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rbx_v9 (System.Object)+10]");
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

	protected void OnCharTypeUpdated(int oldChar, int newChar)
	{
		SetChar((CharacterType)newChar);
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

	public unsafe override void GetTaken()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00b1: Expected O, but got Ref
		//IL_0a6b: Expected O, but got Ref
		//IL_0197: Expected O, but got I4
		//IL_01a0: Expected O, but got I4
		//IL_0b15: Expected O, but got Ref
		//IL_0b71: Expected O, but got Ref
		//IL_0d0f: Expected I, but got O
		//IL_061a: Expected O, but got I
		//IL_0bc1: Expected O, but got Ref
		//IL_0cb9: Expected O, but got Ref
		//IL_0ccb: Expected I, but got O
		//IL_052c: Expected O, but got I
		//IL_04a4: Expected I, but got O
		//IL_0815: Expected O, but got Ref
		//IL_0572: Expected O, but got I4
		//IL_057b: Expected O, but got I4
		//IL_0c72->IL0a09: Incompatible stack heights: 1 vs 0
		//IL_0662->IL0a09: Incompatible stack heights: 1 vs 0
		//IL_068e->IL0a09: Incompatible stack heights: 1 vs 0
		//IL_04c7->IL04c7: Incompatible stack heights: 12 vs 11
		//IL_0586->IL0586: Incompatible stack heights: 12 vs 1
		//IL_09d0->IL0a32: Incompatible stack heights: 2 vs 0
		//IL_09f2->IL0a32: Incompatible stack heights: 2 vs 0
		//IL_0a09->IL0a32: Incompatible stack heights: 2 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (((Pickup)this)._003CDisableGet_003Ek__BackingField || _isOpened)
		{
			return;
		}
		Bounds bounds = CameraExtensions.OrthographicBounds(_camera);
		bool flag = _003CCharCff_003Ek__BackingField == CharacterType.VOID;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ rax_v4 (UnityEngine.Bounds)+10]");
		_ = 0;
		Vector3 vector2 = default(Vector3);
		if (!flag)
		{
			if ((object)_charSprite != null)
			{
				Transform transform = _charSprite.transform;
				_ = 0;
				Vector3 endValue = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
				TweenerCore<Vector3, Vector3, VectorOptions> gameId = ShortcutExtensions.DOScale(transform, endValue, 0.1f);
				Tween charScaleTween = VampireSurvivors.Tools.TweenExtensions.SetGameId(gameId);
				_charScaleTween = charScaleTween;
				if ((object)transform != null)
				{
					_ = 0;
					_ = 0;
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ rax_v4 (UnityEngine.Bounds)+10]");
					float num = 0f * 2f;
					float num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-45]");
					float endValue2 = num2 + 0f;
					TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOMoveY(transform, endValue2, 0.4f);
					TweenCallback tweenCallback = delegate
					{
						_charSprite.enabled = false;
					};
					bool flag3 = tweenerCore == null;
					nint num3 = 0;
					if (!flag3)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v738 @ rax_v174 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
						bool flag4 = (nint)0 == 0;
						num3 = 0;
						if (!flag4)
						{
							num3 = 0;
						}
					}
					Tween charMoveTween = VampireSurvivors.Tools.TweenExtensions.SetGameId(tweenerCore);
					_charMoveTween = charMoveTween;
					object obj4 = 0;
					object obj5 = 0;
					Vector3 vector = vector2;
					nint num4 = num3;
					goto IL_0586;
				}
			}
		}
		else
		{
			_003C_003Ec__DisplayClass24_0 CS_0024_003C_003E8__locals35 = new _003C_003Ec__DisplayClass24_0();
			GameObject original = Resources.Load<GameObject>("GenericText");
			GameObject textObject = UnityEngine.Object.Instantiate(original);
			if (CS_0024_003C_003E8__locals35 != null)
			{
				CS_0024_003C_003E8__locals35.textObject = textObject;
				if ((object)CS_0024_003C_003E8__locals35.textObject != null)
				{
					GameObject textValue = UnityEngine.Object.Instantiate(CS_0024_003C_003E8__locals35.textObject);
					CS_0024_003C_003E8__locals35.textValue = (TextMeshPro)(object)textValue;
					if ((object)CS_0024_003C_003E8__locals35.textObject != null)
					{
						Transform textObjectTrans = CS_0024_003C_003E8__locals35.textObject.transform;
						CS_0024_003C_003E8__locals35.textObjectTrans = textObjectTrans;
						Camera cachedTransform = (Camera)(object)_cachedTransform;
						Transform textObjectTrans2 = CS_0024_003C_003E8__locals35.textObjectTrans;
						if ((object)_cachedTransform != null)
						{
							_ = 0;
							_ = 0;
							bool flag5 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
							object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
							Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)obj6);
							bool flag6 = (object)CS_0024_003C_003E8__locals35.textObjectTrans == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-41]");
							_ = 0;
							bool flag7 = ((UnityEngine.Object)textObjectTrans2).m_CachedPtr == (IntPtr)0;
							object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
							Transform.set_position_Injected(((UnityEngine.Object)textObjectTrans2).m_CachedPtr, ref *(Vector3*)obj7);
							Camera textObjectTrans3 = (Camera)(object)CS_0024_003C_003E8__locals35.textObjectTrans;
							nint num5 = (nint)typeof(Vector3);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1422 @ rax_v125 (Il2CppClass<UnityEngine.Vector3>)+B8]");
							nint num6 = 0;
							bool flag8 = (object)CS_0024_003C_003E8__locals35.textObjectTrans == null;
							Vector3 vector = Vector3.zeroVector;
							_ = Vector3.zeroVector;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1423 @ rax_v126 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
							_ = 0;
							bool flag9 = ((UnityEngine.Object)textObjectTrans3).m_CachedPtr == (IntPtr)0;
							object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
							Transform.set_localScale_Injected(((UnityEngine.Object)textObjectTrans3).m_CachedPtr, ref *(Vector3*)obj8);
							bool flag10 = (object)CS_0024_003C_003E8__locals35.textObject == null;
							CS_0024_003C_003E8__locals35.textObject.SetActive(value: true);
							bool flag11 = (object)CS_0024_003C_003E8__locals35.textValue == null;
							CS_0024_003C_003E8__locals35.textValue.sortingOrder = 3002;
							bool flag12 = (object)CS_0024_003C_003E8__locals35.textValue == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
							TextMeshPro textValue2 = CS_0024_003C_003E8__locals35.textValue;
							bool flag13 = (object)CS_0024_003C_003E8__locals35.textValue == null;
							if (((TMP_Text)textValue2).m_HorizontalAlignment != HorizontalAlignmentOptions.Center)
							{
								((TMP_Text)textValue2).m_HorizontalAlignment = HorizontalAlignmentOptions.Center;
								((TMP_Text)textValue2).m_havePropertiesChanged = true;
								CS_0024_003C_003E8__locals35.textValue.SetVerticesDirty();
							}
							TextMeshPro textValue3 = CS_0024_003C_003E8__locals35.textValue;
							bool flag14 = (object)CS_0024_003C_003E8__locals35.textValue == null;
							if (((TMP_Text)textValue3).m_VerticalAlignment != VerticalAlignmentOptions.Middle)
							{
								((TMP_Text)textValue3).m_VerticalAlignment = VerticalAlignmentOptions.Middle;
								((TMP_Text)textValue3).m_havePropertiesChanged = true;
								CS_0024_003C_003E8__locals35.textValue.SetVerticesDirty();
							}
							TweenConfig tweenConfig = new TweenConfig();
							object[] array = new object[1];
							bool flag15 = array == null;
							if ((object)CS_0024_003C_003E8__locals35.textObjectTrans != null)
							{
								nint num7 = (nint)array;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj9 = default(object);
								bool flag16 = obj9 == null;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							bool flag17 = tweenConfig == null;
							tweenConfig.targets = array;
							tweenConfig.duration = 200f;
							_ = 0;
							_ = 1065353216;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
							tweenConfig.scale = (float?)(object)0;
							TweenCallback onComplete = delegate
							{
								//IL_0049: Expected I, but got O
								//IL_01b2: Expected O, but got I4
								TweenConfig tweenConfig2 = new TweenConfig();
								object[] array2 = new object[1];
								if (array2 != null)
								{
									if ((object)CS_0024_003C_003E8__locals35.textObjectTrans != null)
									{
										nint num13 = (nint)array2;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										object obj11 = default(object);
										if (obj11 == null)
										{
											ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
											throw ex;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									if (tweenConfig2 != null)
									{
										tweenConfig2.targets = array2;
										Transform textObjectTrans4 = CS_0024_003C_003E8__locals35.textObjectTrans;
										if ((object)CS_0024_003C_003E8__locals35.textObjectTrans != null)
										{
											bool flag19 = ((UnityEngine.Object)textObjectTrans4).m_CachedPtr == (IntPtr)0;
											Transform.get_position_Injected(((UnityEngine.Object)textObjectTrans4).m_CachedPtr, out Vector3 _);
											tweenConfig2.duration = 2000f;
											tweenConfig2.y = (float?)(object)1;
											TweenCallback onComplete3 = CS_0024_003C_003E8__locals35._003C_003E9__2;
											if (CS_0024_003C_003E8__locals35._003C_003E9__2 == null)
											{
												onComplete3 = (CS_0024_003C_003E8__locals35._003C_003E9__2 = delegate
												{
													//IL_002c: Expected I, but got O
													//IL_0082: Expected O, but got I4
													TweenConfig tweenConfig3 = new TweenConfig();
													object[] array3 = new object[1];
													if ((object)CS_0024_003C_003E8__locals35.textValue != null)
													{
														nint num14 = (nint)array3;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														object obj12 = default(object);
														if (obj12 == null)
														{
															ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
															throw ex2;
														}
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													tweenConfig3.targets = array3;
													tweenConfig3.alpha = (float?)(object)1;
													tweenConfig3.duration = 1000f;
													TweenCallback onComplete4 = CS_0024_003C_003E8__locals35._003C_003E9__3;
													if (CS_0024_003C_003E8__locals35._003C_003E9__3 == null)
													{
														onComplete4 = (CS_0024_003C_003E8__locals35._003C_003E9__3 = delegate
														{
															UnityEngine.Object.Destroy(CS_0024_003C_003E8__locals35.textObject, 0f);
														});
													}
													tweenConfig3.onComplete = onComplete4;
													MultiTargetTween multiTargetTween3 = Tweens.Add(tweenConfig3);
												});
											}
											tweenConfig2.onComplete = onComplete3;
											MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
											return;
										}
									}
								}
								throw new NullReferenceException();
							};
							tweenConfig.onComplete = onComplete;
							MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
							object obj4 = 0;
							object obj5 = 0;
							nint num4 = 0;
							goto IL_0586;
						}
					}
				}
			}
		}
		goto IL_0a09;
		IL_0586:
		Action action = _003COnOpen_003Ek__BackingField;
		if (_003COnOpen_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1071.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		_isOpened = true;
		GameObject gameObject = base.gameObject;
		if (_signalBus != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4A10");
			SoundManager.FadeMusic(SoundManager._003CCurrentBgm_003Ek__BackingField, 0.1f, 100f);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			_ = 1073741824;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
			soundConfig.Volume = (float?)(object)0;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Lid, soundConfig, 150f, 2, time);
			if ((object)_lid != null)
			{
				Transform transform2 = _lid.transform;
				if ((object)transform2 != null)
				{
					_ = 0;
					_ = 0;
					bool flag18 = (object)((_003C_003Ec__DisplayClass24_0)(object)transform2).textObjectTrans == null;
					object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
					Transform.get_position_Injected((IntPtr)((_003C_003Ec__DisplayClass24_0)(object)transform2).textObjectTrans, out *(Vector3*)obj10);
					Sequence lidTween = DOTween.Sequence();
					_lidTween = lidTween;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ rax_v4 (UnityEngine.Bounds)+10]");
					float num8 = 0f * 2f;
					float num9 = num8 * 0.75f;
					float num10 = num9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-45]");
					float endValue3 = num10 + 0f;
					TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOMoveY(transform2, endValue3, 0.5f);
					if (TweenSettingsExtensions.ValidateAddToSequence(_lidTween, (Tween)t, false))
					{
						Sequence sequence = Sequence.DoInsert(_lidTween, (Tween)t, 0f);
					}
					float num11 = (float)vector2 * 2f;
					float num12 = num11 * 0.75f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
					float endValue4 = 0f - num12;
					TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOMoveX(transform2, endValue4, 0.5f);
					if (TweenSettingsExtensions.ValidateAddToSequence(_lidTween, (Tween)t2, false))
					{
						Sequence sequence2 = Sequence.DoInsert(_lidTween, (Tween)t2, 0f);
					}
					Vector3 endValue5 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
					_ = -360f;
					TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DOLocalRotate(transform2, endValue5, 0.5f, RotateMode.FastBeyond360);
					if (tweenerCore2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2002 @ rax_v68 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2002 @ rax_v68 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2002 @ rax_v68 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2002 @ rax_v68 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
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
					if (TweenSettingsExtensions.ValidateAddToSequence(_lidTween, (Tween)t3, false))
					{
						Sequence sequence4 = Sequence.DoInsert(_lidTween, (Tween)t3, 0f);
					}
					Sequence sequence5 = VampireSurvivors.Tools.TweenExtensions.SetGameId(_lidTween);
					Sequence lidTween2 = _lidTween;
					TweenCallback onComplete2 = delegate
					{
						if ((object)_lid != null)
						{
							_lid.enabled = false;
							if (!_taken)
							{
								((Pickup)this).GetTaken();
								_taken = true;
							}
							return;
						}
						throw new NullReferenceException();
					};
					if (_lidTween != null && ((Tween)lidTween2)._003Cactive_003Ek__BackingField)
					{
						lidTween2.onComplete = onComplete2;
					}
					return;
				}
			}
		}
		goto IL_0a09;
		IL_0a09:
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

	private void TriggerCharacterPanel()
	{
		_gameManager.AddCharacterTypeToQueue(_003CCharCff_003Ek__BackingField, _targetPlayer);
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

	private void _003CGetTaken_003Eb__24_4()
	{
		_charSprite.enabled = false;
	}

	private void _003CGetTaken_003Eb__24_0()
	{
		if ((object)_lid != null)
		{
			_lid.enabled = false;
			if (!_taken)
			{
				((Pickup)this).GetTaken();
				_taken = true;
			}
			return;
		}
		throw new NullReferenceException();
	}
}
