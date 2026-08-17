using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Stages;

public class Background_TP_ADV_001_Stage_DEATHFIGHT : BackgroundManager
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<VampireSurvivors.Objects.Characters.CharacterController, CharacterLightManager> _003C_003E9__13_0;

		public static Func<CharacterLightManager, bool> _003C_003E9__13_1;

		public static Func<SuperMap, Tilemap[]> _003C_003E9__23_0;

		public static Func<Tilemap[], IEnumerable<Tilemap>> _003C_003E9__23_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal CharacterLightManager _003COnInitCompleted_003Eb__13_0(VampireSurvivors.Objects.Characters.CharacterController player)
		{
			if ((object)player != null)
			{
				return player.GetComponentInChildren<CharacterLightManager>();
			}
			return (CharacterLightManager)(object)new NullReferenceException();
		}

		internal bool _003COnInitCompleted_003Eb__13_1(CharacterLightManager pLight)
		{
			if ((object)pLight != null)
			{
				bool flag = ((UnityEngine.Object)pLight).m_CachedPtr == (IntPtr)0;
				return !flag;
			}
			return false;
		}

		internal Tilemap[] _003CTestSpawnDeathFightBackground_003Eb__23_0(SuperMap tile)
		{
			if ((object)tile != null)
			{
				return tile.GetComponentsInChildren<Tilemap>();
			}
			return (Tilemap[])(object)new NullReferenceException();
		}

		internal IEnumerable<Tilemap> _003CTestSpawnDeathFightBackground_003Eb__23_1(Tilemap[] tilemaps)
		{
			return tilemaps;
		}
	}

	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public Rectangle rect;

		internal bool _003CIsAnyPlayerInAPlatformingZone_003Eb__0(VampireSurvivors.Objects.Characters.CharacterController player)
		{
			//IL_0115: Expected I4, but got O
			//IL_0060: Invalid comparison between O and F4
			//IL_0095: Invalid comparison between F4 and O
			//IL_00b6: Invalid comparison between O and F4
			//IL_00eb: Invalid comparison between F4 and O
			Rectangle rectangle = rect;
			if ((object)player != null)
			{
				float2 position = player.position;
				if (rect != null)
				{
					if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)rectangle._x))
					{
						float num = rectangle._width + rectangle._x;
						object obj = default(object);
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) >= System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)rectangle._y))
						{
							float num2 = rectangle._height + rectangle._y;
							bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
							return !flag;
						}
					}
					return false;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public Rect groupBounds;

		internal bool _003CUpdateCurrentPlatformingArea_003Eb__0(VampireSurvivors.Objects.Characters.CharacterController player)
		{
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Expected O, but got Unknown
			//IL_00f8: Expected O, but got I
			bool flag2;
			if ((object)player != null)
			{
				GameObject gameObject = player.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					flag2 = GameObject.get_activeInHierarchy_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (flag2)
					{
						float2 position = player.position;
						Rect rect = groupBounds;
						if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position) >= System.Runtime.CompilerServices.Unsafe.As<Rect, UIntPtr>(ref rect))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background_TP_ADV_001_Stage_DEATHFIGHT+<>c__DisplayClass17_0)+18]");
							object obj = 0 + groupBounds;
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background_TP_ADV_001_Stage_DEATHFIGHT+<>c__DisplayClass17_0)+14]");
								object obj2 = default(object);
								if ((nint)obj2 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background_TP_ADV_001_Stage_DEATHFIGHT+<>c__DisplayClass17_0)+1C]");
									nint num = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background_TP_ADV_001_Stage_DEATHFIGHT+<>c__DisplayClass17_0)+14]");
									object obj3 = num + 0;
									bool flag3 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
									object obj4 = obj3 - obj2;
									bool flag4 = obj4 == null;
									bool flag5 = !flag3;
									bool flag6 = !flag4;
									flag2 = flag6 & flag5;
									goto IL_0051;
								}
							}
						}
						flag2 = false;
					}
					goto IL_0051;
				}
			}
			throw new NullReferenceException();
			IL_0051:
			return flag2;
		}
	}

	private TilingTileset _tilingTileset;

	private PlatformZoneMovement _platformMovement;

	private PolygonGroupComponent[] _polygonGroups;

	private PolygonGroupComponent _currentPlatformingArea;

	private List<Rectangle> _platformingZones;

	private bool _created;

	private TileSprite _deathFightBG;

	private TileSprite _deathFightTile;

	private PhaserSprite _deathFightTileTop;

	private float2? _deathFightStartCameraPos;

	private Camera _camera;

	public override void Awake()
	{
		base.Awake();
		Camera main = Camera.main;
		_camera = main;
	}

	public override void Create()
	{
		base.Create();
		GameManager core = GM.Core;
		Stage stage = core._stage;
		_tilingTileset = stage._tilingTileset;
		GameManager core2 = GM.Core;
		Stage stage2 = core2._stage;
		List<Rectangle> scriptRectangularLocations = stage2._tilingTileset.GetScriptRectangularLocations("PlatformingZone", autoScaleAndOffset: true);
		_platformingZones = scriptRectangularLocations;
		GameManager core3 = GM.Core;
		Stage stage3 = core3._stage;
		List<Rectangle> scriptRectangularLocations2 = stage3._tilingTileset.GetScriptRectangularLocations("CutscenePlatformingZone", autoScaleAndOffset: true);
		if (scriptRectangularLocations2 != null && scriptRectangularLocations2._size > 0)
		{
			if (scriptRectangularLocations2._size <= 0)
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			Rectangle[] items = scriptRectangularLocations2._items;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4C30");
		}
		GameManager core4 = GM.Core;
		Stage stage4 = core4._stage;
		PolygonGroupComponent[] polygonGroups;
		bool flag;
		if ((object)stage4._tilingTileset != null)
		{
			GameObject defaultSupportMap = stage4._tilingTileset.DefaultSupportMap;
			if ((object)defaultSupportMap != null)
			{
				polygonGroups = defaultSupportMap.GetComponentsInChildren<PolygonGroupComponent>(includeInactive: false);
				flag = false;
				goto IL_0265;
			}
		}
		flag = true;
		polygonGroups = null;
		goto IL_0265;
		IL_0265:
		_polygonGroups = polygonGroups;
		PolygonGroupComponent[] polygonGroups2 = _polygonGroups;
		if (_polygonGroups != null && polygonGroups2.Length > 0)
		{
			_platformMovement = PlatformZoneMovement._003CInstance_003Ek__BackingField;
		}
		_created = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA61F0");
	}

	public unsafe override void OnInitCompleted()
	{
		//IL_03e2: Expected I, but got O
		//IL_03f8: Expected O, but got I
		//IL_0414: Expected I, but got O
		//IL_00ba: Expected O, but got Ref
		//IL_00c3: Expected O, but got I4
		//IL_04ca: Expected I, but got O
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_0046: Expected O, but got I8
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_058f: Expected O, but got I4
		//IL_059f: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a4: Expected O, but got Unknown
		//IL_0068: Expected I, but got O
		//IL_011e: Expected I, but got O
		//IL_01b1: Expected O, but got I4
		//IL_0156: Expected O, but got I
		//IL_015f: Expected O, but got I4
		//IL_027e: Expected O, but got I
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Expected O, but got Unknown
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		//IL_02e4: Expected I, but got O
		//IL_020e: Expected O, but got I
		//IL_024d: Expected I, but got O
		//IL_0256: Expected O, but got I4
		base.OnInitCompleted();
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Func<VampireSurvivors.Objects.Characters.CharacterController, CharacterLightManager> selector = _003C_003Ec._003C_003E9__13_0;
			if (_003C_003Ec._003C_003E9__13_0 == null)
			{
				Func<VampireSurvivors.Objects.Characters.CharacterController, CharacterLightManager> func = (_003C_003Ec._003C_003E9__13_0 = (VampireSurvivors.Objects.Characters.CharacterController player) => (CharacterLightManager)(((object)player != null) ? ((object)player.GetComponentInChildren<CharacterLightManager>()) : ((object)new NullReferenceException())));
				nint num = (nint)typeof(_003C_003Ec);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rax_v68 (Il2CppClass<VampireSurvivors.Objects.Stages.Background_TP_ADV_001_Stage_DEATHFIGHT+<>c>)+B8]");
				object obj = (nint)0 + (nint)8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag = (nint)0 == 0;
				nint num2 = unchecked((nint)null);
				selector = func;
				if (!flag)
				{
					object obj2 = obj >> 12;
					object obj3 = obj2 & 0x1FFFFF;
					object obj4 = obj3 >> 6;
					object obj5 = 6603577472L;
					object obj6 = obj3 & 0x3F;
					nint num4;
					do
					{
						object obj7 = 1 << (int)obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ rdi_v15+462E0+v291 @ rdx_v34*8]");
						object obj8 = 0 | obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ rdi_v15+462E0+v291 @ rdx_v34*8]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ rdi_v15+462E0+v291 @ rdx_v34*8]");
						if (num3 == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ rdi_v15+462E0+v291 @ rdx_v34*8]");
						num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ rdi_v15+462E0+v291 @ rdx_v34*8]");
					}
					while (num4 != 0);
					num2 = unchecked((nint)null);
					selector = func;
				}
			}
			IEnumerable<CharacterLightManager> source = Enumerable.Select(core._characters, selector);
			Func<CharacterLightManager, bool> predicate = _003C_003Ec._003C_003E9__13_1;
			if (_003C_003Ec._003C_003E9__13_1 == null)
			{
				Func<CharacterLightManager, bool> func2 = (_003C_003Ec._003C_003E9__13_1 = delegate(CharacterLightManager pLight)
				{
					if ((object)pLight != null)
					{
						bool flag3 = ((UnityEngine.Object)pLight).m_CachedPtr == (IntPtr)0;
						return !flag3;
					}
					return false;
				});
				nint num5 = (nint)typeof(_003C_003Ec);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v510 @ rax_v53 (Il2CppClass<VampireSurvivors.Objects.Stages.Background_TP_ADV_001_Stage_DEATHFIGHT+<>c>)+B8]");
				nint num2 = (nint)0 + (nint)16;
				predicate = func2;
			}
			IEnumerable<CharacterLightManager> enumerable = Enumerable.Where(source, predicate);
			if (enumerable != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				Light2D light2D = default(Light2D);
				object obj9 = (object)(&light2D);
				object obj10 = 0;
				Light2D light2D2 = null;
				object obj11 = default(object);
				object obj20 = default(object);
				Component component = default(Component);
				while (true)
				{
					object obj19;
					object obj12;
					if ((object)light2D != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						if (obj11 != null)
						{
							bool flag2 = (object)light2D == null;
							light2D2 = null;
							if (!flag2)
							{
								nint num6 = (nint)light2D;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ r10_v8 (Il2CppClass<UnityEngine.Rendering.Universal.Light2D>)+12E]");
								if ((nint)0 >= (nint)0)
								{
									goto IL_0196;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ r10_v8 (Il2CppClass<UnityEngine.Rendering.Universal.Light2D>)+B0]");
								obj12 = 0;
								object obj13 = 0;
								while (true)
								{
									object obj14 = obj13 + obj13;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ r8_v17+v759 @ rax_v47*8]");
									if (0 == (nint)typeof(IEnumerator<CharacterLightManager>))
									{
										break;
									}
									obj13++;
									object obj15 = obj13;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ r10_v8 (Il2CppClass<UnityEngine.Rendering.Universal.Light2D>)+12E]");
									if ((nint)obj15 < 0)
									{
										continue;
									}
									goto IL_0196;
								}
								object obj16 = obj13 + obj13;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ r8_v17+8+v815 @ rcx_v36*8]");
								object obj17 = (nint)0 << 4;
								object obj18 = obj17 + 312;
								obj19 = obj18 + num6;
								goto IL_0557;
							}
							throw new NullReferenceException();
						}
						if (obj9 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
						}
						TP_Character.AddTPItemsToLootTable();
						return;
					}
					throw new NullReferenceException();
					IL_0196:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
					obj19 = obj20;
					obj12 = 0;
					goto IL_0557;
					IL_0557:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v820 @ rdx_v19] (should have been resolved before IL gen)");
					if (obj10 == null)
					{
						if ((object)component == null)
						{
							throw new NullReferenceException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rax_v36 (UnityEngine.Component)+20]");
						if ((nint)0 == 0)
						{
							throw new NullReferenceException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rax_v36 (UnityEngine.Component)+20]");
						((Light2D)0).lightType = Light2D.LightType.Global;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rax_v36 (UnityEngine.Component)+20]");
						if ((nint)0 == 0)
						{
							break;
						}
						_ = 1065353216;
						_ = 1;
						nint num2 = (nint)typeof(IEnumerator<CharacterLightManager>);
						obj10 = 1;
					}
					else
					{
						if ((object)component == null)
						{
							throw new NullReferenceException();
						}
						GameObject obj21 = component.gameObject;
						UnityEngine.Object.Destroy(obj21);
						nint num2 = (nint)typeof(IEnumerator<CharacterLightManager>);
					}
				}
				throw new NullReferenceException();
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnUpdate()
	{
		UpdateCurrentPlatformingArea();
	}

	private bool IsAnyPlayerInAPlatformingZone()
	{
		//IL_0053: Expected I, but got O
		//IL_0079: Expected I, but got O
		List<Rectangle>.Enumerator enumerator = default(List<Rectangle>.Enumerator);
		Color colour = default(Color);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass15_0();
				bool flag = CS_0024_003C_003E8__locals6 == null;
				nint num = (nint)typeof(_003C_003Ec__DisplayClass15_0);
				if (!flag)
				{
					CS_0024_003C_003E8__locals6.rect = null;
					num = (nint)typeof(_003C_003Ec__DisplayClass15_0);
					Rectangle rect = CS_0024_003C_003E8__locals6.rect;
					if (CS_0024_003C_003E8__locals6.rect != null)
					{
						VSDebug.DrawDebugRect(rect._x, rect._y, rect._width, rect._height, colour);
						GameManager core = GM.Core;
						if ((object)GM.Core == null)
						{
							break;
						}
						Func<VampireSurvivors.Objects.Characters.CharacterController, bool> predicate = delegate(VampireSurvivors.Objects.Characters.CharacterController player)
						{
							//IL_0115: Expected I4, but got O
							//IL_0060: Invalid comparison between O and F4
							//IL_0095: Invalid comparison between F4 and O
							//IL_00b6: Invalid comparison between O and F4
							//IL_00eb: Invalid comparison between F4 and O
							Rectangle rect2 = CS_0024_003C_003E8__locals6.rect;
							if ((object)player != null)
							{
								float2 position = player.position;
								if (CS_0024_003C_003E8__locals6.rect != null)
								{
									if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)rect2._x))
									{
										float num2 = rect2._width + rect2._x;
										object obj = default(object);
										if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) >= System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)rect2._y))
										{
											float num3 = rect2._height + rect2._y;
											bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
											return !flag2;
										}
									}
									return false;
								}
							}
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						};
						if (Enumerable.Any(core._mainCharacters, predicate))
						{
							return true;
						}
						continue;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			return false;
		}
		throw new NullReferenceException();
	}

	private void ExitPlatformingZone()
	{
		//IL_0050: Expected I, but got O
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._characters != null)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
			if (enumerator.MoveNext())
			{
				ArcadeSprite arcadeSprite = null;
				nint num = (nint)typeof(float2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v410 @ rax_v25 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
				nint num2 = 0;
				throw new NullReferenceException();
			}
			_currentPlatformingArea = null;
			if ((object)_platformMovement != null)
			{
				_platformMovement.LoadStageEdges(null);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void UpdateCurrentPlatformingArea()
	{
		//IL_00b3: Expected O, but got I4
		//IL_00ee: Expected O, but got F4
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected O, but got Unknown
		if (_polygonGroups == null)
		{
			return;
		}
		PolygonGroupComponent currentPlatformingArea = _currentPlatformingArea;
		if ((object)_currentPlatformingArea != null && ((UnityEngine.Object)currentPlatformingArea).m_CachedPtr != (IntPtr)0)
		{
			if (!IsAnyPlayerInAPlatformingZone())
			{
				ExitPlatformingZone();
			}
		}
		else
		{
			if (!IsAnyPlayerInAPlatformingZone())
			{
				return;
			}
			PolygonGroupComponent[] polygonGroups = _polygonGroups;
			bool flag = polygonGroups.Length <= 0;
			object obj = 0;
			if (flag)
			{
				return;
			}
			PolygonGroupComponent[] polygonGroups2;
			while (true)
			{
				_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass17_0();
				polygonGroups2 = _polygonGroups;
				CS_0024_003C_003E8__locals3.groupBounds = (Rect)polygonGroups2[obj].Bounds.m_XMin;
				GameManager core = GM.Core;
				Func<VampireSurvivors.Objects.Characters.CharacterController, bool> predicate = delegate(VampireSurvivors.Objects.Characters.CharacterController player)
				{
					//IL_0093: Unknown result type (might be due to invalid IL or missing references)
					//IL_0098: Expected O, but got Unknown
					//IL_00f8: Expected O, but got I
					bool flag3;
					if ((object)player != null)
					{
						GameObject gameObject = player.gameObject;
						if ((object)gameObject != null)
						{
							bool flag2 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
							flag3 = GameObject.get_activeInHierarchy_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
							if (flag3)
							{
								float2 position = player.position;
								Rect groupBounds = CS_0024_003C_003E8__locals3.groupBounds;
								if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position) >= System.Runtime.CompilerServices.Unsafe.As<Rect, UIntPtr>(ref groupBounds))
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background_TP_ADV_001_Stage_DEATHFIGHT+<>c__DisplayClass17_0)+18]");
									object obj2 = 0 + CS_0024_003C_003E8__locals3.groupBounds;
									if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position))
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background_TP_ADV_001_Stage_DEATHFIGHT+<>c__DisplayClass17_0)+14]");
										object obj3 = default(object);
										if ((nint)obj3 >= 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background_TP_ADV_001_Stage_DEATHFIGHT+<>c__DisplayClass17_0)+1C]");
											nint num = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background_TP_ADV_001_Stage_DEATHFIGHT+<>c__DisplayClass17_0)+14]");
											object obj4 = num + 0;
											bool flag4 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3);
											object obj5 = obj4 - obj3;
											bool flag5 = obj5 == null;
											bool flag6 = !flag4;
											bool flag7 = !flag5;
											flag3 = flag7 & flag6;
											goto IL_0051;
										}
									}
								}
								flag3 = false;
							}
							goto IL_0051;
						}
					}
					throw new NullReferenceException();
					IL_0051:
					return flag3;
				};
				if (Enumerable.Any(core._mainCharacters, predicate))
				{
					break;
				}
				obj++;
				if ((nint)obj >= polygonGroups.Length)
				{
					return;
				}
			}
			_currentPlatformingArea = polygonGroups2[obj];
			_platformMovement.LoadStageEdges(_currentPlatformingArea);
		}
	}

	public void DeactivatePlatformingAltogether()
	{
		ExitPlatformingZone();
		_polygonGroups = null;
	}

	private void LateUpdate()
	{
		if (_created)
		{
			UpdateBackground();
		}
	}

	public override void Cleanup()
	{
		//IL_0013: Expected O, but got I4
		base._003CIsBackgroundActive_003Ek__BackingField = false;
		GameManager core = GM.Core;
		core._003CHardBounds_003Ek__BackingField = (Rect?)(object)0;
		_ = 0;
		RemoveDeathFightBackground();
	}

	public override bool HasExtraSafeXYLogic()
	{
		return true;
	}

	public override float2 ExtraSafeXY(float2 position, float2 playerPosition)
	{
		//IL_00da: Expected O, but got I4
		//IL_00e2: Invalid comparison between F4 and O
		//IL_0100: Invalid comparison between F4 and I4
		//IL_0129: Expected O, but got I4
		//IL_02a4: Invalid comparison between O and F4
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Expected O, but got Unknown
		//IL_015e: Expected O, but got I4
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Expected O, but got Unknown
		//IL_0214: Invalid comparison between O and F4
		PolygonGroupComponent currentPlatformingArea = _currentPlatformingArea;
		bool flag = (object)_currentPlatformingArea == null;
		float2 result = position;
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)currentPlatformingArea).m_CachedPtr == (IntPtr)0;
			result = position;
			if (!flag2)
			{
				if ((object)_currentPlatformingArea == null)
				{
					goto IL_0249;
				}
				Rect bounds = _currentPlatformingArea.Bounds;
				float2 float5 = default(float2);
				object obj = float5 + float5;
				float num = (float)float5 + bounds.m_XMin;
				object obj2 = default(object);
				bool flag3 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
				object obj3 = obj - obj2;
				bool flag4 = obj3 == null;
				bool flag5 = !flag3;
				bool flag6 = !flag4;
				object obj4 = flag6 & flag5;
				bool flag7 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) < System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position);
				float num2 = num - (float)position;
				bool flag8 = num2 == 0f;
				bool flag9 = !flag7;
				bool flag10 = !flag8;
				object obj5 = flag10 & flag9;
				object obj6 = obj4 & obj5;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5))
				{
					obj6 = 0;
				}
				bool flag11 = System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)bounds.m_XMin);
				bool flag12 = !flag11;
				object obj7 = flag12 & obj6;
				bool flag13 = obj7 == null;
				result = position;
				if (!flag13)
				{
					float num3 = (float)obj2 + 5f;
					if ((object)_platformMovement == null)
					{
						goto IL_0249;
					}
					bool flag14 = _platformMovement.FindClosestWalkableEdgeBelow(float5)._edge == null;
					result = position;
					if (!flag14)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rax_v16 (VampireSurvivors.Objects.Stages.PlatformZoneMovement+ClosestEdge)+C]");
						float num4 = 0f - num3;
						float num5 = num4 + 5f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
						object obj8 = num5 & 0;
						bool flag15 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.05f);
						result = position;
						if (!flag15)
						{
							float deltaTime = PauseSystem.DeltaTime;
							result = float5;
						}
					}
				}
			}
		}
		return result;
		IL_0249:
		return (float2)new NullReferenceException();
	}

	public unsafe void TestSpawnDeathFightBackground()
	{
		//IL_0324: Expected I, but got O
		//IL_033a: Expected O, but got I
		//IL_0356: Expected I, but got O
		//IL_0118: Expected O, but got Ref
		//IL_040c: Expected I, but got O
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		//IL_00a4: Expected O, but got I8
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_04e5: Expected O, but got I4
		//IL_04f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fa: Expected O, but got Unknown
		//IL_00c6: Expected I, but got O
		//IL_0165: Expected I, but got O
		//IL_01f8: Expected O, but got I4
		//IL_019d: Expected O, but got I
		//IL_01a6: Expected O, but got I4
		//IL_022a: Expected O, but got I
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_04aa: Expected I, but got O
		//IL_055c->IL02a1: Incompatible stack heights: 1 vs 0
		//IL_04af->IL0529: Incompatible stack heights: 4 vs 0
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null)
			{
				TilingTileset tilingTileset = stage._tilingTileset;
				if ((object)stage._tilingTileset != null)
				{
					Func<SuperMap, Tilemap[]> selector = _003C_003Ec._003C_003E9__23_0;
					if (_003C_003Ec._003C_003E9__23_0 == null)
					{
						Func<SuperMap, Tilemap[]> func = (_003C_003Ec._003C_003E9__23_0 = (SuperMap tile) => (Tilemap[])(((object)tile != null) ? ((object)tile.GetComponentsInChildren<Tilemap>()) : ((object)new NullReferenceException())));
						nint num = (nint)typeof(_003C_003Ec);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rax_v70 (Il2CppClass<VampireSurvivors.Objects.Stages.Background_TP_ADV_001_Stage_DEATHFIGHT+<>c>)+B8]");
						object obj = (nint)0 + (nint)24;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
						bool flag = (nint)0 == 0;
						nint num2 = unchecked((nint)null);
						selector = func;
						if (!flag)
						{
							object obj2 = obj >> 12;
							object obj3 = obj2 & 0x1FFFFF;
							object obj4 = obj3 >> 6;
							object obj5 = 6603577472L;
							object obj6 = obj3 & 0x3F;
							nint num4;
							do
							{
								object obj7 = 1 << (int)obj6;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rdi_v13 (System.Object)+462E0+v400 @ rdx_v34*8]");
								object obj8 = 0 | obj7;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rdi_v13 (System.Object)+462E0+v400 @ rdx_v34*8]");
								nint num3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rdi_v13 (System.Object)+462E0+v400 @ rdx_v34*8]");
								if (num3 == 0)
								{
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rdi_v13 (System.Object)+462E0+v400 @ rdx_v34*8]");
								num4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rdi_v13 (System.Object)+462E0+v400 @ rdx_v34*8]");
							}
							while (num4 != 0);
							num2 = unchecked((nint)null);
							selector = func;
						}
					}
					IEnumerable<Tilemap[]> source = Enumerable.Select(tilingTileset._maps, selector);
					Func<Tilemap[], IEnumerable<Tilemap>> selector2 = _003C_003Ec._003C_003E9__23_1;
					if (_003C_003Ec._003C_003E9__23_1 == null)
					{
						Func<Tilemap[], IEnumerable<Tilemap>> func2 = (_003C_003Ec._003C_003E9__23_1 = (Tilemap[] tilemaps) => tilemaps);
						nint num5 = (nint)typeof(_003C_003Ec);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v588 @ rax_v55 (Il2CppClass<VampireSurvivors.Objects.Stages.Background_TP_ADV_001_Stage_DEATHFIGHT+<>c>)+B8]");
						nint num2 = (nint)0 + (nint)32;
						selector2 = func2;
					}
					IEnumerable<Tilemap> enumerable = Enumerable.SelectMany(source, selector2);
					if (enumerable != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						object obj10 = default(object);
						object obj9 = (object)(&obj10);
						object obj11 = default(object);
						object obj20 = default(object);
						object obj21 = default(object);
						Color value = default(Color);
						while (true)
						{
							bool flag2 = obj10 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
							if (obj11 == null)
							{
								break;
							}
							bool flag3 = obj10 == null;
							nint num6 = (nint)obj10;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ r10_v8 (Il2CppClass<System.Object>)+12E]");
							object obj19;
							object obj12;
							if ((nint)0 < (nint)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ r10_v8 (Il2CppClass<System.Object>)+B0]");
								obj12 = 0;
								object obj13 = 0;
								while (true)
								{
									object obj14 = obj13 + obj13;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ r8_v16+v788 @ rax_v49*8]");
									if (0 == (nint)typeof(IEnumerator<Tilemap>))
									{
										break;
									}
									obj13++;
									object obj15 = obj13;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ r10_v8 (Il2CppClass<System.Object>)+12E]");
									if ((nint)obj15 < 0)
									{
										continue;
									}
									goto IL_01dd;
								}
								object obj16 = obj13 + obj13;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ r8_v16+8+v858 @ rcx_v42*8]");
								object obj17 = (nint)0 << 4;
								object obj18 = obj17 + 312;
								obj19 = obj18 + num6;
								goto IL_04af;
							}
							goto IL_01dd;
							IL_01dd:
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
							obj19 = obj20;
							obj12 = 0;
							goto IL_04af;
							IL_04af:
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v863 @ rdx_v21] (should have been resolved before IL gen)");
							bool flag4 = obj21 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ rax_v38 (System.Object)+10]");
							bool flag5 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ rax_v38 (System.Object)+10]");
							Tilemap.set_color_Injected((IntPtr)0, ref value);
							nint num2 = (nint)typeof(IEnumerator<Tilemap>);
						}
						bool flag6 = obj9 == null;
						object obj22 = obj10;
						if (!flag6)
						{
							obj22 = obj9;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
						}
						if (_signalBus != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA61F0");
							SpawnDeathFightTile();
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void TestRemoveDeathFightBackground()
	{
		RemoveDeathFightBackground();
	}

	private void SpawnDeathFightBackground()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA61F0");
	}

	public unsafe void SpawnDeathFightTile()
	{
		//IL_0076: Expected O, but got F4
		//IL_00a9: Expected I4, but got I8
		//IL_0395: Expected I4, but got I8
		//IL_03b9: Expected O, but got I
		//IL_040f: Expected O, but got I
		//IL_022c: Expected I, but got O
		//IL_048f: Expected F4, but got I4
		//IL_0580: Expected I4, but got O
		//IL_05ae: Expected I, but got O
		//IL_0713: Expected O, but got F4
		//IL_0720: Expected F4, but got O
		//IL_0092->IL05d2: Incompatible stack heights: 1 vs 0
		//IL_00c5->IL05d2: Incompatible stack heights: 1 vs 0
		//IL_00f4->IL05d2: Incompatible stack heights: 1 vs 0
		//IL_0123->IL05d2: Incompatible stack heights: 1 vs 0
		//IL_014d->IL05d2: Incompatible stack heights: 1 vs 0
		//IL_01a4->IL05d2: Incompatible stack heights: 1 vs 0
		//IL_021a->IL05d2: Incompatible stack heights: 1 vs 0
		//IL_01f8->IL01f8: Incompatible stack heights: 2 vs 1
		//IL_0254->IL0254: Incompatible stack heights: 1 vs 0
		//IL_056d->IL056d: Incompatible stack heights: 1 vs 0
		//IL_0725->IL06b4: Incompatible stack heights: 1 vs 0
		if (_deathFightStartCameraPos != null)
		{
			goto IL_0254;
		}
		Vector3 ret;
		float num = default(float);
		if ((object)_camera != null)
		{
			Transform transform = _camera.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
				GameObject gameObject = base.gameObject;
				PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, (Vector2)num, "DeathFightTop", "DeathFightTop");
				if ((object)phaserSprite != null)
				{
					PhaserSprite phaserSprite2 = phaserSprite.setDepth(-8001);
					if ((object)phaserSprite2 != null)
					{
						PhaserSprite phaserSprite3 = phaserSprite2.setAlpha(0f);
						if ((object)phaserSprite3 != null)
						{
							PhaserSprite phaserSprite4 = phaserSprite3.setBlendMode(BlendMode.Normal);
							if ((object)phaserSprite4 != null)
							{
								GameObject gameObject2 = phaserSprite4.gameObject;
								if ((object)gameObject2 != null)
								{
									((UnityEngine.Object)gameObject2).SetName("DeathFightTop");
									_deathFightTileTop = phaserSprite4;
									TweenConfig tweenConfig = new TweenConfig();
									object[] array = new object[1];
									if (array != null)
									{
										if ((object)_deathFightTileTop != null)
										{
											void* value = ((IntPtr*)(&array))->m_value;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj = default(object);
											bool flag2 = obj == null;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										if (tweenConfig != null)
										{
											((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
											_ = 1148846080;
											_ = 1;
											MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
											goto IL_0254;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_05d2;
		IL_05d2:
		throw new NullReferenceException();
		IL_0254:
		float scrollFactor;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null && (object)GM.Core != null)
				{
					PhaserScene s_scene2 = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null)
					{
						PhaserScene.Renderer renderer2 = s_scene2._renderer;
						if (s_scene2._renderer != null)
						{
							float y = renderer2.height * 0.5f;
							float x = renderer.width * 0.5f;
							float height = default(float);
							string textureName = default(string);
							string spriteName = default(string);
							TileSprite component = RenderingExtensions.AddTileSprite(this, x, y, 6.72f, height, textureName, spriteName);
							TileSprite tileSprite = RenderingExtensions.SetScrollFactor(component, 0f);
							if ((object)tileSprite != null)
							{
								TileSprite tileSprite2 = tileSprite.SetDepth(-8000);
								if ((object)tileSprite2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1120 @ rax_v34 (VampireSurvivors.Graphics.TileSprite)+28]");
									SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha((SpriteRenderer)0, 0f);
									Material material = MaterialManager.GetMaterial(MaterialType.DefaultSprite);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1120 @ rax_v34 (VampireSurvivors.Graphics.TileSprite)+28]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1120 @ rax_v34 (VampireSurvivors.Graphics.TileSprite)+28]");
										((Renderer)0).SetMaterial(material);
										GameObject gameObject3 = tileSprite2.gameObject;
										if ((object)gameObject3 != null)
										{
											((UnityEngine.Object)gameObject3).SetName("DeathFightTile");
											TileSprite deathFightTile = tileSprite2.SetMaterial(MaterialType.ScrollableSprite);
											_deathFightTile = deathFightTile;
											bool flag3 = _deathFightStartCameraPos != null;
											scrollFactor = 0f;
											if (flag3)
											{
												goto IL_06b4;
											}
											if ((object)_camera != null)
											{
												Transform transform2 = _camera.transform;
												if ((object)transform2 != null)
												{
													bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
													Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
													object obj2 = default(object);
													float num2 = (float)obj2 - 0.98f;
													_deathFightStartCameraPos = (float2?)(object)num;
													scrollFactor = (float)ret;
													goto IL_06b4;
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
		goto IL_05d2;
		IL_06b4:
		UpdateBackground();
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if (array2 != null)
		{
			if ((object)_deathFightTile != null)
			{
				TileSprite tileSprite3 = RenderingExtensions.SetScrollFactor(_deathFightTile, scrollFactor);
				bool flag5 = (object)tileSprite3 == null;
			}
			TileSprite tileSprite4 = RenderingExtensions.SetScrollFactor((TileSprite)(object)array2, scrollFactor, (byte)(int)_deathFightTile != 0);
			if (tweenConfig2 != null)
			{
				((UnityEngine.Object)(object)tweenConfig2).m_CachedPtr = (IntPtr)array2;
				_ = 1148846080;
				_ = 1;
				MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
				return;
			}
		}
		goto IL_05d2;
	}

	private void RemoveDeathFightBackground()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA61F0");
		TileSprite deathFightBG = _deathFightBG;
		if ((object)_deathFightBG != null && ((UnityEngine.Object)deathFightBG).m_CachedPtr != (IntPtr)0)
		{
			_deathFightBG.destroy();
			_deathFightBG = null;
		}
		PhaserSprite deathFightTileTop = _deathFightTileTop;
		if ((object)_deathFightTileTop != null && ((UnityEngine.Object)deathFightTileTop).m_CachedPtr != (IntPtr)0)
		{
			_deathFightTileTop.destroy();
			_deathFightTileTop = null;
		}
		TileSprite deathFightTile = _deathFightTile;
		if ((object)_deathFightTile != null && ((UnityEngine.Object)deathFightTile).m_CachedPtr != (IntPtr)0)
		{
			_deathFightTile.destroy();
			_deathFightTile = null;
		}
	}

	private unsafe void UpdateBackground()
	{
		//IL_0340: Invalid comparison between F4 and I4
		//IL_00d9: Expected F4, but got I4
		//IL_017a: Expected O, but got I
		//IL_049d: Invalid comparison between F4 and O
		//IL_01f9: Expected O, but got I
		//IL_04c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c7: Expected O, but got Unknown
		//IL_04cf: Invalid comparison between F4 and O
		//IL_026e: Invalid comparison between O and F4
		//IL_02ac->IL02ac: Incompatible stack heights: 8 vs 0
		//IL_0239->IL047d: Incompatible stack heights: 11 vs 10
		//IL_051c->IL04e6: Incompatible stack heights: 10 vs 8
		TileSprite deathFightTile = _deathFightTile;
		if ((object)_deathFightTile == null || ((UnityEngine.Object)deathFightTile).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		bool flag = _deathFightStartCameraPos == null;
		TileSprite deathFightTile2 = _deathFightTile;
		deathFightTile2._xScrollOffset = 0f;
		deathFightTile2._spriteScroller.SetScrollOffsetX(deathFightTile2._xScrollOffset);
		Transform transform = _camera.transform;
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background_TP_ADV_001_Stage_DEATHFIGHT)+D0]");
		float num2 = default(float);
		float num = 0f - num2;
		float num3 = num - 10.725f;
		if (num3 > 0f)
		{
			num3 = 0f;
		}
		Transform transform2 = _deathFightTile.transform;
		Transform transform3 = _camera.transform;
		bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out ret);
		bool flag4 = (object)transform2 == null;
		bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		float2 value = default(float2);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value));
		Transform deathFightTile3 = (Transform)(object)_deathFightTile;
		bool flag6 = (object)_camera == null;
		Transform transform4 = _camera.transform;
		bool flag7 = (object)transform4 == null;
		bool flag8 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out ret);
		float scrollOffsetY = num2 + num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rdi_v18 (UnityEngine.Transform)+30]");
		((SpriteScroller)0).SetScrollOffsetY(scrollOffsetY);
		GameManager core = GM.Core;
		float num4 = 10f;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator characters = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)core._characters;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		float2 position = default(float2);
		while (enumerator.MoveNext())
		{
			Background_TP_ADV_001_Stage_DEATHFIGHT background_TP_ADV_001_Stage_DEATHFIGHT = null;
			Transform cachedTrans = ((ArcadeSprite)null).CachedTrans;
			bool flag9 = (object)cachedTrans == null;
			bool flag10 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out ret);
			object obj2;
			if ((object)background_TP_ADV_001_Stage_DEATHFIGHT._mainCamera != null)
			{
				Camera mainCamera = background_TP_ADV_001_Stage_DEATHFIGHT._mainCamera;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1251 @ rax_v76 (UnityEngine.Camera)+28]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1251 @ rax_v76 (UnityEngine.Camera)+28]");
				bool flag11 = (nint)0 == 0;
				num4 = num2;
				obj2 = ret;
			}
			else
			{
				num4 = num2;
				obj2 = ret;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background_TP_ADV_001_Stage_DEATHFIGHT)+CC]");
			float num5 = 0f - 2.56f;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num5) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background_TP_ADV_001_Stage_DEATHFIGHT)+CC]");
				float num6 = 0f + 2.56f;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6))
				{
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background_TP_ADV_001_Stage_DEATHFIGHT)+D0]");
			characters = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(0 + 0.16f);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4) > System.Runtime.CompilerServices.Unsafe.As<List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator, UIntPtr>(ref characters))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background_TP_ADV_001_Stage_DEATHFIGHT)+D0]");
				num4 = 0f + 0.16f;
			}
			((ArcadeSprite)null).position = position;
		}
	}
}
