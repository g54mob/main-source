using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Bindings;
using UnityEngine.Rendering.Universal;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Actions;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundBoneZone : BackgroundManager
{
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public BackgroundBoneZone _003C_003E4__this;

		public Action onComplete;

		internal void _003CCustomPreload_003Eb__0(Texture asset)
		{
			BackgroundBoneZone backgroundBoneZone = _003C_003E4__this;
			backgroundBoneZone._normalMap = asset;
			Action action = onComplete;
			if (onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v68.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public BackgroundBoneZone _003C_003E4__this;

		public float x;

		public float y;

		internal void _003CAddFlowers_003Eb__0()
		{
			BackgroundBoneZone backgroundBoneZone = _003C_003E4__this;
			Vector2 point = default(Vector2);
			Actions.RotateAroundDistance(backgroundBoneZone._group, point, 0.02f, backgroundBoneZone._TweenTarget);
		}

		internal void _003CAddFlowers_003Eb__1()
		{
			BackgroundBoneZone backgroundBoneZone = _003C_003E4__this;
			Vector2 point = default(Vector2);
			Actions.RotateAroundDistance(backgroundBoneZone._group2, point, 0.02f, backgroundBoneZone._Tween2Target);
		}
	}

	private float _elapsedTime;

	private float _elapsedTime2;

	private Circle _fixedCircle;

	private SpriteRenderer _groundFx;

	private List<Transform> _group;

	private List<Transform> _group2;

	private Transform _group1Parent;

	private Transform _group2Parent;

	public float _TweenTarget;

	public float _Tween2Target;

	private MultiTargetTween _tween;

	private MultiTargetTween _tween2;

	private MultiTargetTween _tween3;

	private Texture _normalMap;

	private VampireSurvivors.Objects.Characters.CharacterController Player
	{
		get
		{
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				GameSessionData gameSessionData = core._gameSessionData;
				if (core._gameSessionData != null)
				{
					return gameSessionData._activeCharacter;
				}
			}
			return (VampireSurvivors.Objects.Characters.CharacterController)(object)new NullReferenceException();
		}
	}

	protected override void OnUpdate()
	{
		//IL_03c0: Expected O, but got I4
		//IL_008f->IL05a5: Incompatible stack heights: 1 vs 0
		//IL_0611->IL05a5: Incompatible stack heights: 1 vs 0
		//IL_012c->IL0579: Incompatible stack heights: 1 vs 0
		//IL_018d->IL0579: Incompatible stack heights: 1 vs 0
		//IL_01af->IL0579: Incompatible stack heights: 1 vs 0
		//IL_01de->IL0579: Incompatible stack heights: 1 vs 0
		//IL_0200->IL0579: Incompatible stack heights: 1 vs 0
		//IL_022a->IL05a5: Incompatible stack heights: 1 vs 0
		//IL_0251->IL0579: Incompatible stack heights: 1 vs 0
		//IL_0273->IL0579: Incompatible stack heights: 1 vs 0
		//IL_02ad->IL0579: Incompatible stack heights: 1 vs 0
		//IL_02cf->IL0579: Incompatible stack heights: 1 vs 0
		//IL_0309->IL0579: Incompatible stack heights: 1 vs 0
		//IL_032b->IL0579: Incompatible stack heights: 1 vs 0
		//IL_0365->IL0579: Incompatible stack heights: 1 vs 0
		//IL_0387->IL0579: Incompatible stack heights: 1 vs 0
		//IL_04a8->IL0579: Incompatible stack heights: 1 vs 0
		//IL_04f0->IL0579: Incompatible stack heights: 1 vs 0
		//IL_053f->IL0579: Incompatible stack heights: 1 vs 0
		//IL_0579->IL05a5: Incompatible stack heights: 1 vs 0
		base.OnUpdate();
		if (_group == null || _fixedCircle == null)
		{
			return;
		}
		VampireSurvivors.Objects.Characters.CharacterController player = Player;
		if ((object)player != null)
		{
			Transform transform = player.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				Vector2 point = default(Vector2);
				if (!_fixedCircle.Contains(point))
				{
					_elapsedTime = 0f;
					return;
				}
				float deltaTime = PauseSystem.DeltaTime;
				float elapsedTime = deltaTime + _elapsedTime;
				_elapsedTime = elapsedTime;
				float deltaTime2 = PauseSystem.DeltaTime;
				bool flag2 = (_elapsedTime2 = deltaTime2 + _elapsedTime2) < 0.5f;
				bool flag3 = false;
				float num2 = default(float);
				float num = num2;
				if (!flag2)
				{
					VampireSurvivors.Objects.Characters.CharacterController player2 = Player;
					if ((object)player2 == null)
					{
						goto IL_0579;
					}
					player2.RecoverHp(8f, showRecovery: true);
					_elapsedTime2 = 0f;
					flag3 = true;
					num = 8f;
				}
				if (_elapsedTime < 10f)
				{
					return;
				}
				GameManager core = GM.Core;
				if ((object)GM.Core != null && core._playerOptions != null)
				{
					PlayerOptionsData config = core._playerOptions.Config;
					if (config != null && config._003CUnlockedCharacters_003Ek__BackingField != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
						object obj = default(object);
						if (obj != null)
						{
							return;
						}
						GameManager core2 = GM.Core;
						if ((object)GM.Core != null && core2._playerOptions != null)
						{
							core2._playerOptions.UnlockCharacter(CharacterType.BOROS);
							GameManager core3 = GM.Core;
							if ((object)GM.Core != null && core3._playerOptions != null)
							{
								core3._playerOptions.BuyCharacter(CharacterType.BOROS);
								GameManager core4 = GM.Core;
								if ((object)GM.Core != null && core4._playerOptions != null)
								{
									core4._playerOptions.RevealCharacter(CharacterType.BOROS);
									GameManager core5 = GM.Core;
									if ((object)GM.Core != null && core5._playerOptions != null)
									{
										core5._playerOptions.Save();
										float time = default(float);
										PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ThingFound, new SoundManager.SoundConfig
										{
											Volume = (float?)(object)1,
											Detune = -1000f,
											Rate = 0.5f
										}, 0f, 10, time);
										if (_tween != null)
										{
											_tween.Kill();
										}
										if (_tween2 != null)
										{
											_tween2.Kill();
										}
										if (_tween3 != null)
										{
											_tween3.Kill();
										}
										if ((object)_groundFx != null)
										{
											GameObject obj2 = _groundFx.gameObject;
											UnityEngine.Object.Destroy(obj2);
											_groundFx = null;
											if ((object)_group1Parent != null)
											{
												GameObject obj3 = _group1Parent.gameObject;
												UnityEngine.Object.Destroy(obj3);
												_group1Parent = null;
												_group = null;
												if ((object)_group2Parent != null)
												{
													GameObject obj4 = _group2Parent.gameObject;
													UnityEngine.Object.Destroy(obj4);
													_group2Parent = null;
													_group2 = null;
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
		goto IL_0579;
		IL_0579:
		throw new NullReferenceException();
	}

	public override void CustomPreload(Action onComplete)
	{
		_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass17_0();
		CS_0024_003C_003E8__locals7._003C_003E4__this = this;
		CS_0024_003C_003E8__locals7.onComplete = onComplete;
		GameManager core = GM.Core;
		AssetReference assetReference = core._assetReferenceLibrary.GetAssetReference("bg_boneN");
		if (assetReference != null)
		{
			Action<Texture> action = delegate(Texture asset)
			{
				BackgroundBoneZone backgroundBoneZone = CS_0024_003C_003E8__locals7._003C_003E4__this;
				backgroundBoneZone._normalMap = asset;
				Action onComplete3 = CS_0024_003C_003E8__locals7.onComplete;
				if (CS_0024_003C_003E8__locals7.onComplete != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v68.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F95F40");
		}
		else
		{
			Action onComplete2 = CS_0024_003C_003E8__locals7.onComplete;
			if (CS_0024_003C_003E8__locals7.onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v333.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	public override void Create()
	{
		base.Create();
		Texture normalMap = _normalMap;
		if ((object)_normalMap != null && ((UnityEngine.Object)normalMap).m_CachedPtr != (IntPtr)0)
		{
			GameManager core = GM.Core;
			Stage stage = core._stage;
			TilingBackground tilingBackground = stage._tilingBackground;
			TileSprite bgtile = tilingBackground._bgtile;
			Material material = ((Renderer)bgtile._spriteRenderer).GetMaterial();
			int num = Shader.PropertyToID("_NormalMap");
			material.SetTextureImpl(num, _normalMap);
		}
		GameManager core2 = GM.Core;
		PlayerOptionsData config = core2._playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rcx_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				GameManager core3 = GM.Core;
				Vector2 spawnPos = default(Vector2);
				bool forceSpawn = default(bool);
				GameObject gameObject = core3._stage.SpawnEnemy(EnemyType.SKETAMARI, spawnPos, asRemote: false, forceSpawn);
			}
		}
		GameManager core4 = GM.Core;
		PlayerOptionsData config2 = core4._playerOptions.Config;
		List<CharacterType> list2 = config2._003CUnlockedCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rcx_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				return;
			}
		}
		_elapsedTime = 0f;
		Circle circle = new Circle();
		circle._x = 0f;
		circle._y = 204.79999f;
		circle._radius = 2f;
		_fixedCircle = circle;
		AddGroundFx(0f, 204.79999f);
		AddFlowers(0f, 204.79999f);
	}

	public override void OnInitCompleted()
	{
		//IL_007e: Expected O, but got F4
		base.OnInitCompleted();
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._003CSelectedInverse_003Ek__BackingField)
		{
			GameManager core2 = GM.Core;
			Light2D spotlight2D = core2._Spotlight2D;
			spotlight2D.m_Color = (Color)ColourHelper.HexToColor("0xff2200").r;
		}
	}

	private void AddGroundFx(float x, float y)
	{
		//IL_0111: Expected I, but got O
		//IL_0179: Expected I4, but got I8
		//IL_0195: Expected O, but got I4
		GameObject gameObject = base.gameObject;
		string spriteName = default(string);
		SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(gameObject, x, y, null, spriteName);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetTint(spriteRenderer, 65280u);
		SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(spriteRenderer2, 0.1f);
		spriteRenderer3.enabled = true;
		Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
		((Renderer)spriteRenderer3).SetMaterial(material);
		SpriteRenderer spriteRenderer4 = RenderingExtensions.SetScale(spriteRenderer3, 400f);
		((UnityEngine.Object)spriteRenderer4).SetName("GroundFx");
		_groundFx = spriteRenderer4;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_groundFx != null)
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
		tweenConfig.yoyo = true;
		tweenConfig.repeat = -1;
		tweenConfig.ease = Ease.InOutSine;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween3 = tween;
	}

	private unsafe void AddFlowers(float x, float y)
	{
		//IL_00cb: Expected O, but got Ref
		//IL_00ff: Expected O, but got I4
		//IL_0208: Expected O, but got I4
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		//IL_0b00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b05: Expected O, but got Unknown
		//IL_0b12: Expected I, but got O
		//IL_0b1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b20: Expected I, but got Unknown
		//IL_0b2d: Expected O, but got I
		//IL_01f2: Expected O, but got I4
		//IL_0194: Expected O, but got I
		//IL_01d2: Expected O, but got I4
		//IL_03be: Expected O, but got I4
		//IL_0443: Expected O, but got I
		//IL_04c1: Expected O, but got I
		//IL_04df: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e4: Expected O, but got Unknown
		//IL_050c: Expected O, but got I4
		//IL_062e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0633: Expected O, but got Unknown
		//IL_066b: Expected O, but got I4
		//IL_066b: Expected O, but got I4
		//IL_06bd: Expected I, but got O
		//IL_07b8: Expected I4, but got I8
		//IL_0ea8: Expected I, but got O
		//IL_0ebe: Expected O, but got I
		//IL_0ec7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ecc: Expected O, but got Unknown
		//IL_0853: Expected I, but got O
		//IL_0ef2: Expected O, but got I4
		//IL_0f09: Expected I, but got I8
		//IL_083c: Expected I, but got I8
		//IL_089f: Expected O, but got I4
		//IL_089f: Expected O, but got I4
		//IL_08f1: Expected I, but got O
		//IL_09ec: Expected I4, but got I8
		//IL_0f28: Expected I, but got O
		//IL_0f3e: Expected O, but got I
		//IL_0f47: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f4c: Expected O, but got Unknown
		//IL_0a8c: Expected I, but got O
		//IL_0f80: Expected I, but got I8
		//IL_0a5f: Expected I, but got I8
		//IL_0c25->IL0aae: Incompatible stack heights: 2 vs 0
		//IL_0388->IL0aae: Incompatible stack heights: 2 vs 0
		//IL_0cd2->IL0aae: Incompatible stack heights: 4 vs 0
		//IL_0db7->IL0aae: Incompatible stack heights: 4 vs 0
		//IL_0411->IL0aae: Incompatible stack heights: 5 vs 0
		//IL_0d8e->IL0aae: Incompatible stack heights: 6 vs 0
		//IL_0463->IL0aae: Incompatible stack heights: 6 vs 0
		//IL_04fd->IL0d93: Incompatible stack heights: 6 vs 4
		//IL_0e96->IL0aae: Incompatible stack heights: 6 vs 0
		//IL_055d->IL0aae: Incompatible stack heights: 7 vs 0
		//IL_0e6d->IL0aae: Incompatible stack heights: 8 vs 0
		//IL_05b6->IL0aae: Incompatible stack heights: 8 vs 0
		//IL_064d->IL0e72: Incompatible stack heights: 8 vs 6
		//IL_06b0->IL0aae: Incompatible stack heights: 8 vs 0
		//IL_0702->IL0aae: Incompatible stack heights: 9 vs 0
		//IL_074a->IL0aae: Incompatible stack heights: 9 vs 0
		//IL_08e4->IL0aae: Incompatible stack heights: 9 vs 0
		//IL_0936->IL0aae: Incompatible stack heights: 10 vs 0
		//IL_097e->IL0aae: Incompatible stack heights: 10 vs 0
		_003C_003Ec__DisplayClass21_0 obj = new _003C_003Ec__DisplayClass21_0();
		if (obj != null)
		{
			obj._003C_003E4__this = this;
			obj.x = x;
			obj.y = y;
			Circle circle = new Circle();
			circle._x = x;
			circle._y = y;
			circle._radius = 2f;
			List<Transform> list = new List<Transform>();
			_group = list;
			List<Transform> group = new List<Transform>();
			_group2 = group;
			List<string> list2 = new List<string>();
			int num = 0;
			object obj2 = default(object);
			Vector2 pos = default(Vector2);
			object obj12 = default(object);
			object value = default(object);
			object obj15 = default(object);
			object value2 = default(object);
			while (true)
			{
				string text = System.Number.FormatInt32(num, (ReadOnlySpan<char>)(&obj2), null);
				if (text == null)
				{
					break;
				}
				object obj3 = 2 - text._stringLength;
				string text3;
				if ((nint)obj3 > 0)
				{
					string text2 = string.FastAllocateString(2);
					if (text2 == null)
					{
						break;
					}
					object obj4 = text2 + 20;
					if ((nint)obj3 > 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"rep stosw\"");
					}
					int num2 = text._stringLength + text._stringLength;
					object obj5 = obj3 * 2;
					byte* ptr = (byte*)(nint)(obj4 + obj5);
					byte* ptr2 = (byte*)(nint)(text + 20);
					object obj6 = (object)(ptr - (nuint)ptr2);
					object obj8;
					if ((nint)obj6 >= num2)
					{
						object obj7 = (object)(ptr2 - (nuint)ptr);
						if ((nint)obj7 >= num2)
						{
							Buffer.Memcpy(ptr, ptr2, num2);
							text3 = text2;
							obj8 = 0;
							goto IL_0b49;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
					text3 = text2;
					obj8 = 0;
				}
				else
				{
					text3 = text;
					object obj8 = 0;
				}
				goto IL_0b49;
				IL_0b49:
				string item = "fl" + text3;
				if (list2 == null)
				{
					break;
				}
				int version = list2._version + 1;
				list2._version = version;
				string[] items = list2._items;
				if (list2._items == null)
				{
					break;
				}
				if (list2._size >= items.Length)
				{
					((List<object>)(object)list2).AddWithResize((object)item);
				}
				else
				{
					int size = list2._size + 1;
					list2._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				num++;
				if (num <= 88)
				{
					continue;
				}
				GameObject gameObject = new GameObject();
				GameObject.Internal_CreateGameObject(gameObject, "Group1Parent");
				if ((object)gameObject == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1464 @ rax_v69 (UnityEngine.GameObject)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1464 @ rax_v69 (UnityEngine.GameObject)+10]");
				IntPtr gcHandlePtr = GameObject.get_transform_Injected((IntPtr)0);
				Transform group1Parent = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
				_group1Parent = group1Parent;
				bool flag2 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
				Transform parent = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
				if ((object)_group1Parent == null)
				{
					break;
				}
				_group1Parent.SetParent(parent, worldPositionStays: true);
				GameObject gameObject2 = new GameObject();
				GameObject.Internal_CreateGameObject(gameObject2, "Group2Parent");
				if ((object)gameObject2 == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2178 @ rax_v85 (UnityEngine.GameObject)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2178 @ rax_v85 (UnityEngine.GameObject)+10]");
				IntPtr gcHandlePtr3 = GameObject.get_transform_Injected((IntPtr)0);
				Transform group2Parent = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
				_group2Parent = group2Parent;
				bool flag4 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr4 = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
				Transform parent2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr4);
				if ((object)_group2Parent == null)
				{
					break;
				}
				_group2Parent.SetParent(parent2, worldPositionStays: true);
				float? num3 = (float?)(object)0;
				while (true)
				{
					object group1Parent2 = _group1Parent;
					if ((object)_group1Parent == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rdi_v36 (System.Object)+10]");
					bool flag5 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rdi_v36 (System.Object)+10]");
					IntPtr gcHandlePtr5 = Component.get_gameObject_Injected((IntPtr)0);
					GameObject gameObject3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr5);
					string spriteName = Extensions.PickRnd(list2);
					SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(gameObject3, pos, "vfx", spriteName);
					object obj9 = _group;
					if ((object)spriteRenderer == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rax_v111 (UnityEngine.SpriteRenderer)+10]");
					bool flag6 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rax_v111 (UnityEngine.SpriteRenderer)+10]");
					IntPtr gcHandlePtr6 = Component.get_transform_Injected((IntPtr)0);
					Transform item2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr6);
					if (_group == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdi_v38 (System.Object)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdi_v38 (System.Object)+10]");
					object obj10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdi_v38 (System.Object)+10]");
					if ((nint)0 == 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdi_v38 (System.Object)+18]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ rcx_v107+18]");
					if (num4 >= 0)
					{
						((List<object>)(object)_group).AddWithResize((object)item2);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdi_v38 (System.Object)+18]");
						object obj11 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					num3 = (float?)(object)((_003F?)num3 + 1);
					if ((nint)num3 < 24)
					{
						continue;
					}
					float? num5 = (float?)(object)0;
					while (true)
					{
						string group2Parent2 = (string)(object)_group2Parent;
						if ((object)_group2Parent == null)
						{
							break;
						}
						bool flag7 = group2Parent2._stringLength == 0;
						IntPtr gcHandlePtr7 = Component.get_gameObject_Injected((IntPtr)group2Parent2._stringLength);
						GameObject gameObject4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr7);
						string spriteName2 = Extensions.PickRnd(list2);
						SpriteRenderer spriteRenderer2 = RenderingExtensions.AddSprite(gameObject4, pos, "vfx", spriteName2);
						List<object> group2 = (List<object>)(object)_group2;
						if ((object)spriteRenderer2 == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v129 (UnityEngine.SpriteRenderer)+10]");
						bool flag8 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v129 (UnityEngine.SpriteRenderer)+10]");
						IntPtr gcHandlePtr8 = Component.get_transform_Injected((IntPtr)0);
						Transform item3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr8);
						if (_group2 == null)
						{
							break;
						}
						int version2 = group2._version + 1;
						group2._version = version2;
						object[] items2 = group2._items;
						if (group2._items == null)
						{
							break;
						}
						if (group2._size >= items2.Length)
						{
							((List<object>)(object)_group2).AddWithResize((object)item3);
						}
						else
						{
							int size2 = group2._size + 1;
							group2._size = size2;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						num5 = (float?)(object)((_003F?)num5 + 1);
						if ((nint)num5 < 24)
						{
							continue;
						}
						Actions.PlaceOnCircle(_group, circle, (float?)(object)0, (float?)(object)0);
						_TweenTarget = 2f;
						TweenConfig tweenConfig = new TweenConfig();
						object[] array = new object[1];
						if (array == null)
						{
							break;
						}
						nint num6 = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						bool flag9 = obj12 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (tweenConfig == null)
						{
							break;
						}
						tweenConfig.targets = array;
						Dictionary<string, object> dictionary = new Dictionary<string, object>();
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
						if (dictionary == null)
						{
							break;
						}
						bool flag10 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_TweenTarget", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
						tweenConfig.custom = dictionary;
						tweenConfig.duration = 3000f;
						tweenConfig.delay = 2000f;
						tweenConfig.ease = Ease.InOutSine;
						tweenConfig.repeat = -1;
						tweenConfig.yoyo = true;
						TweenCallback tweenCallback = null;
						nint num7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2900 @ r9_v32 (Il2CppMethodInfo)+8]");
						((Delegate)tweenCallback).method_ptr = (IntPtr)0;
						((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass21_0._003CAddFlowers_003Eb__0);
						((Delegate)tweenCallback).m_target = obj;
						((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2900 @ r9_v32 (Il2CppMethodInfo)+4C]");
						object obj13 = (nint)0 >> 4;
						object obj14 = obj13 & 1;
						nint num8;
						if (obj14 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2900 @ r9_v32 (Il2CppMethodInfo)+52]");
							if ((nint)0 == 0)
							{
								num8 = unchecked((nint)6447293664L);
								goto IL_0ee9;
							}
						}
						((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
						num8 = ((Delegate)tweenCallback).method_ptr;
						goto IL_0ee9;
						IL_0ee9:
						string text4 = (string)24;
						((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
						tweenConfig.onUpdate = tweenCallback;
						MultiTargetTween tween = Tweens.Add(tweenConfig);
						_tween = tween;
						Actions.PlaceOnCircle(_group2, circle, (float?)(object)0, (float?)(object)0);
						_Tween2Target = 1.5f;
						TweenConfig tweenConfig2 = new TweenConfig();
						object[] array2 = new object[1];
						if (array2 == null)
						{
							break;
						}
						nint num9 = (nint)array2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						bool flag11 = obj15 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (tweenConfig2 == null)
						{
							break;
						}
						tweenConfig2.targets = array2;
						Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
						if (dictionary2 == null)
						{
							break;
						}
						bool flag12 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"_Tween2Target", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
						tweenConfig2.custom = dictionary2;
						tweenConfig2.duration = 3000f;
						tweenConfig2.delay = 2000f;
						tweenConfig2.ease = Ease.InOutSine;
						tweenConfig2.repeat = -1;
						tweenConfig2.yoyo = true;
						TweenCallback tweenCallback2 = null;
						nint num10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1810 @ r9_v35 (Il2CppMethodInfo)+8]");
						((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
						((Delegate)tweenCallback2).method = (nint)__ldftn(_003C_003Ec__DisplayClass21_0._003CAddFlowers_003Eb__1);
						((Delegate)tweenCallback2).m_target = obj;
						((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1810 @ r9_v35 (Il2CppMethodInfo)+4C]");
						object obj16 = (nint)0 >> 4;
						object obj17 = obj16 & 1;
						nint num11;
						if (obj17 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1810 @ r9_v35 (Il2CppMethodInfo)+52]");
							bool flag13 = (nint)0 == 0;
							num11 = unchecked((nint)6447293664L);
							if (flag13)
							{
								goto IL_0f69;
							}
						}
						num11 = ((Delegate)tweenCallback2).method_ptr;
						((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
						goto IL_0f69;
						IL_0f69:
						((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
						tweenConfig2.onUpdate = tweenCallback2;
						MultiTargetTween tween2 = Tweens.Add(tweenConfig2);
						_tween2 = tween2;
						return;
					}
					break;
				}
				break;
			}
		}
		throw new NullReferenceException();
	}
}
