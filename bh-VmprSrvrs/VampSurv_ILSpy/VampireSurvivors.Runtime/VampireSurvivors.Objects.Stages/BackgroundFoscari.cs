using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Props;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundFoscari : BackgroundManager
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<SuperObject, bool> _003C_003E9__8_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal unsafe bool _003CCreate_003Eb__8_0(SuperObject o)
		{
			//IL_0144: Expected I4, but got O
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected Ref, but got Unknown
			//IL_00fd: Expected I8, but got I4
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Expected Ref, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3D30]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if ((object)o != null)
			{
				string tiledName = o.m_TiledName;
				if (o.m_TiledName != null)
				{
					object obj = "FS_SEAL1";
					if ((object)o.m_TiledName != "FS_SEAL1")
					{
						if ("FS_SEAL1" != null)
						{
							int stringLength = tiledName._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v1+10]");
							if ((nint)stringLength == 0)
							{
								ref byte second = ref *(byte*)("FS_SEAL1" + 20);
								ulong length = (ulong)(tiledName._stringLength + tiledName._stringLength);
								return System.SpanHelpers.SequenceEqual(ref *(byte*)(o.m_TiledName + 20), ref second, length);
							}
						}
						return false;
					}
					return true;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private MeshRenderer _magicWaterImage;

	private TileSprite _water;

	private bool _hasMagicWater = true;

	private PhaserSprite _waterAnim;

	private float _fsSealX = 8800f;

	private float _fsSealY = 1664f;

	protected override void OnDestroy()
	{
		base.OnDestroy();
		Action<Destructible> value = OnRemoteDestructibleSpawned;
		Delegate obj = Delegate.Remove(DestructibleInstantiator.OnRemoteDestructibleSpawned, value);
		if ((object)obj == null)
		{
			DestructibleInstantiator.OnRemoteDestructibleSpawned = (Action<Destructible>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		Action<Destructible> action = default(Action<Destructible>);
		if (action != null)
		{
			DestructibleInstantiator.OnRemoteDestructibleSpawned = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 != null)
			{
				return;
			}
			throw new InvalidCastException();
		}
		throw new InvalidCastException();
	}

	protected void InitMagicWater()
	{
		//IL_0214: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<AchievementType> list = config._003CAchievements_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rcx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				_hasMagicWater = false;
			}
		}
		if (!_hasMagicWater)
		{
			PhaserWorld instance = PhaserWorld.Instance;
			Vector2 pos = default(Vector2);
			PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "background_Foscari", "waterF1");
			PhaserSprite waterAnim = phaserSprite.setVisible(visible: false);
			_waterAnim = waterAnim;
			int num = default(int);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("waterF", 1, 8, "background_Foscari", num);
			PhaserSprite waterAnim2 = _waterAnim;
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			waterAnim2._spriteAnimation.AddAnimation("loop", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
			PhaserSprite waterAnim3 = _waterAnim;
			waterAnim3._spriteAnimation.SetAnimation("loop");
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer = s_scene._renderer;
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene2 = ArcadePhysics.s_scene;
					PhaserScene.Renderer renderer2 = s_scene2._renderer;
					float y = renderer2.height * 0.5f;
					float x = renderer.width * 0.5f;
					GameObject go = base.gameObject;
					TileSpriteBuilder tileSpriteBuilder = RenderingExtensions.AddTileSprite(go, x, y, "background_Foscari", (string)num);
					tileSpriteBuilder._depth = -10001f;
					tileSpriteBuilder._depthMul = 1f;
					Transform parent = base.transform;
					tileSpriteBuilder._parent = parent;
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene3 = ArcadePhysics.s_scene;
						PhaserScene.Renderer renderer3 = s_scene3._renderer;
						if ((object)GM.Core != null)
						{
							PhaserScene s_scene4 = ArcadePhysics.s_scene;
							PhaserScene.Renderer renderer4 = s_scene4._renderer;
							tileSpriteBuilder._tileHeight = renderer4.height;
							tileSpriteBuilder._tileWidth = renderer3.width;
							tileSpriteBuilder._name = "Water";
							TileSprite water = tileSpriteBuilder.Build();
							_water = water;
							TileSprite tileSprite = RenderingExtensions.SetScrollFactor(_water, 0f);
							return;
						}
					}
				}
			}
			throw new NullReferenceException();
		}
		InitVFX();
	}

	public unsafe override void Create()
	{
		//IL_0077->IL00c6: Incompatible stack heights: 0 vs 2
		//IL_00cc->IL00cc: Incompatible stack heights: 2 vs 0
		//IL_03b3->IL0289: Incompatible stack heights: 1 vs 0
		//IL_03f7->IL0326: Incompatible stack heights: 2 vs 0
		if ((object)GM.Core != null)
		{
			if (!GM.Core.IsStageHost)
			{
				Action<Destructible> b = OnRemoteDestructibleSpawned;
				Delegate obj = Delegate.Combine(DestructibleInstantiator.OnRemoteDestructibleSpawned, b);
				if ((object)obj == null)
				{
					DestructibleInstantiator.OnRemoteDestructibleSpawned = (Action<Destructible>)obj;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					Action<Destructible> action = default(Action<Destructible>);
					bool flag = action == null;
					DestructibleInstantiator.OnRemoteDestructibleSpawned = action;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj2 = default(object);
					bool flag2 = obj2 == null;
				}
			}
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				Stage stage = core._stage;
				if ((object)core._stage != null)
				{
					TilingTileset tilingTileset = stage._tilingTileset;
					if ((object)stage._tilingTileset != null)
					{
						Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__8_0;
						if (_003C_003Ec._003C_003E9__8_0 == null)
						{
							predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__8_0 = delegate(SuperObject o)
							{
								//IL_0144: Expected I4, but got O
								//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
								//IL_00e6: Expected Ref, but got Unknown
								//IL_00fd: Expected I8, but got I4
								//IL_010b: Unknown result type (might be due to invalid IL or missing references)
								//IL_0110: Expected Ref, but got Unknown
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3D30]");
								if ((nint)0 == 0)
								{
									_ = 1;
								}
								if ((object)o != null)
								{
									string tiledName = o.m_TiledName;
									if (o.m_TiledName != null)
									{
										object obj4 = "FS_SEAL1";
										if ((object)o.m_TiledName != "FS_SEAL1")
										{
											if ("FS_SEAL1" != null)
											{
												int stringLength = tiledName._stringLength;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v1+10]");
												if ((nint)stringLength == 0)
												{
													ref byte second = ref *(byte*)("FS_SEAL1" + 20);
													ulong length = (ulong)(tiledName._stringLength + tiledName._stringLength);
													return System.SpanHelpers.SequenceEqual(ref *(byte*)(o.m_TiledName + 20), ref second, length);
												}
											}
											return false;
										}
										return true;
									}
								}
								NullReferenceException ex = new NullReferenceException();
								return (byte)(int)ex != 0;
							});
						}
						object obj3 = Enumerable.FirstOrDefault(tilingTileset.SavedScripts, predicate);
						if (obj3 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rax_v27 (System.Object)+10]");
							if ((nint)0 != 0)
							{
								Transform transform = ((Component)obj3).transform;
								if ((object)transform != null)
								{
									bool flag3 = ((Delegate)(object)transform).method_ptr == (IntPtr)0;
									float ret;
									Transform.get_position_Injected(((Delegate)(object)transform).method_ptr, out *(Vector3*)(&ret));
									_fsSealX = ret;
									Transform transform2 = ((Component)obj3).transform;
									if ((object)transform2 != null)
									{
										bool flag4 = ((Delegate)(object)transform2).method_ptr == (IntPtr)0;
										Transform.get_position_Injected(((Delegate)(object)transform2).method_ptr, out *(Vector3*)(&ret));
										float fsSealY = default(float);
										_fsSealY = fsSealY;
										goto IL_0326;
									}
								}
								goto IL_0289;
							}
						}
						goto IL_0326;
					}
				}
			}
		}
		goto IL_0289;
		IL_0289:
		throw new NullReferenceException();
		IL_0326:
		base.Create();
		InitMagicWater();
		if (_hasMagicWater)
		{
			CreateSeal1();
			return;
		}
		GameManager core2 = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage2 = core2._stage;
			if ((object)core2._stage != null && (object)stage2._tilingTileset != null)
			{
				Vector2 defaultMapPosition = stage2._tilingTileset.DefaultMapPosition;
				Vector2 pos = default(Vector2);
				float value = default(float);
				ItemType relicType = default(ItemType);
				bool validatePickups = default(bool);
				Pickup pickup = GM.Core.MakeStagePickup(pos, ItemType.WEAPON, WeaponType.ACADEMYBADGE, value, relicType, validatePickups);
				return;
			}
		}
		goto IL_0289;
	}

	private void OnRemoteDestructibleSpawned(Destructible destructible)
	{
		//IL_0038: Expected I, but got O
		//IL_0040: Expected I, but got O
		//IL_0050: Expected O, but got I
		//IL_008c: Expected O, but got I
		//IL_00c9: Expected O, but got I
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_0182: Expected I, but got O
		//IL_018a: Expected I, but got O
		//IL_019a: Expected O, but got I
		//IL_011c: Expected O, but got I
		//IL_0160: Expected O, but got I4
		//IL_0152: Expected O, but got I4
		if (destructible._destructibleType != PropType.FOSCARI_SEAL_1)
		{
			return;
		}
		nint num = (nint)typeof(PropFoscariSeal1);
		nint num2 = (nint)destructible;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Props.PropFoscariSeal1>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Destructible>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Props.PropFoscariSeal1>)+130]");
		object obj7;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Destructible>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v6+FFFFFFF8+v61 @ rax_v5*8]");
			if (0 == (nint)typeof(PropFoscariSeal1))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Props.PropFoscariSeal1>)+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v6+FFFFFFF8+v167 @ rcx_v5*8]");
				object obj4 = 0 - typeof(PropFoscariSeal1);
				bool flag = obj4 == null;
				bool flag2 = !flag;
				Destructible destructible2 = null;
				if (flag2)
				{
					_ = _magicWaterImage;
					nint num4 = (nint)typeof(PropFoscariSeal1);
					nint num5 = (nint)destructible;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Props.PropFoscariSeal1>)+130]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Destructible>)+130]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Props.PropFoscariSeal1>)+130]");
					if (num6 < 0)
					{
						goto IL_0157;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Destructible>)+C8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rax_v18+FFFFFFF8+v193 @ rax_v8*8]");
				if (0 != (nint)typeof(PropFoscariSeal1))
				{
					goto IL_0157;
				}
				obj7 = 1;
				goto IL_01c6;
			}
		}
		throw new NullReferenceException();
		IL_0157:
		obj7 = 0;
		goto IL_01c6;
		IL_01c6:
		if (obj7 == null)
		{
		}
	}

	public override void OnInitCompleted()
	{
		float yMax = default(float);
		bool skipInverseCalculation = default(bool);
		GM.Core.SetHardBoundsMinMax(256f, 256f, 9984f, yMax, skipInverseCalculation);
	}

	protected override void OnUpdate()
	{
		//IL_0089: Expected F4, but got O
		//IL_00a5: Expected F4, but got O
		//IL_00e0: Expected F4, but got I
		//IL_00ff: Expected F4, but got I
		if (!_hasMagicWater)
		{
			PhaserSprite waterAnim = _waterAnim;
			Sprite sprite = waterAnim._spriteRenderer.sprite;
			string frameName = ((UnityEngine.Object)sprite).GetName();
			_water.SetFrame(frameName, "background_Foscari");
			TileSprite water = _water;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			water._xScrollOffset = (float)renderer.screenCenter;
			water._spriteScroller.SetScrollOffsetX((float)renderer.screenCenter);
			TileSprite water2 = _water;
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer2 = s_scene2._renderer;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rax_v19 (PhaserScene+Renderer)+38]");
			water2._yScrollOffset = 0f;
			SpriteScroller spriteScroller = water2._spriteScroller;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rax_v19 (PhaserScene+Renderer)+38]");
			spriteScroller.SetScrollOffsetY(0f);
		}
	}

	public override void Cleanup()
	{
		//IL_0013: Expected O, but got I4
		base._003CIsBackgroundActive_003Ek__BackingField = false;
		GameManager core = GM.Core;
		core._003CHardBounds_003Ek__BackingField = (Rect?)(object)0;
		_ = 0;
	}

	private void InitVFX()
	{
		//IL_0231: Expected I4, but got I8
		GameObject original = Resources.Load<GameObject>("MagicWater");
		Camera main = Camera.main;
		Transform parent = main.transform;
		GameObject gameObject = UnityEngine.Object.Instantiate(original, parent, worldPositionStays: false);
		int2 renderTextureSize = CameraExtensions.GetRenderTextureSize(_mainCamera);
		Transform transform = gameObject.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		Transform transform2 = gameObject.transform;
		Transform child = transform2.GetChild(0);
		GameObject gameObject2 = child.gameObject;
		int layer = (gameObject2.layer = LayerMask.NameToLayer("Default"));
		gameObject.layer = layer;
		Transform transform3 = gameObject.transform;
		Transform child2 = transform3.GetChild(0);
		bool flag2 = ((UnityEngine.Object)child2).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)child2).m_CachedPtr, ref value2);
		Transform transform4 = gameObject.transform;
		Transform child3 = transform4.GetChild(0);
		MeshRenderer component = child3.GetComponent<MeshRenderer>();
		bool flag3 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
		Renderer.set_sortingOrder_Injected(((UnityEngine.Object)component).m_CachedPtr, -9000);
		Transform transform5 = gameObject.transform;
		Transform child4 = transform5.GetChild(0);
		MeshRenderer component2 = child4.GetComponent<MeshRenderer>();
		_magicWaterImage = component2;
	}

	private void CreateSeal1()
	{
		//IL_0084: Expected I, but got O
		//IL_0092: Expected I, but got O
		//IL_00a2: Expected O, but got I
		//IL_0122: Expected O, but got I4
		//IL_00de: Expected O, but got I
		//IL_0114: Expected O, but got I4
		GameManager core = GM.Core;
		Stage stage = core._stage;
		Vector2 defaultMapPosition = stage._tilingTileset.DefaultMapPosition;
		GameManager core2 = GM.Core;
		Vector2 pos = default(Vector2);
		Destructible destructible = core2._stage.MakeDestructible(PropType.FOSCARI_SEAL_1, pos);
		Destructible destructible2;
		if ((object)destructible == null)
		{
			destructible2 = null;
			goto IL_01ac;
		}
		nint num = (nint)destructible;
		nint num2 = (nint)typeof(PropFoscariSeal1);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Props.PropFoscariSeal1>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Destructible>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Props.PropFoscariSeal1>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Destructible>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rax_v31+FFFFFFF8+v213 @ rax_v27*8]");
			if (0 == (nint)typeof(PropFoscariSeal1))
			{
				obj3 = 1;
				goto IL_0185;
			}
		}
		obj3 = 0;
		goto IL_0185;
		IL_0185:
		bool flag = obj3 == null;
		destructible2 = null;
		if (!flag)
		{
			destructible2 = destructible;
		}
		goto IL_01ac;
		IL_01ac:
		if ((object)destructible2 != null && ((UnityEngine.Object)destructible2).m_CachedPtr != (IntPtr)0)
		{
			_ = _magicWaterImage;
		}
	}

	private void CreateBadge()
	{
		GameManager core = GM.Core;
		Stage stage = core._stage;
		Vector2 defaultMapPosition = stage._tilingTileset.DefaultMapPosition;
		Vector2 pos = default(Vector2);
		float value = default(float);
		ItemType relicType = default(ItemType);
		bool validatePickups = default(bool);
		Pickup pickup = core.MakeStagePickup(pos, ItemType.WEAPON, WeaponType.ACADEMYBADGE, value, relicType, validatePickups);
	}
}
