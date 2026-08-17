using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Rendering;
using VampireSurvivors.Data;
using VampireSurvivors.Graphics.Blitters;
using Zenject;

namespace VampireSurvivors.Graphics;

public class PentagramManager : IInitializable, IDisposable
{
	private static readonly Dictionary<PentagramType, Texture2D> PentagramTextures;

	private static readonly Dictionary<PentagramType, Sprite> PentagramSprites;

	private const int RTDepth = 0;

	private const int RTWidth = 256;

	private const int RTHeight = 256;

	private Texture2D _circle;

	private Color _goodTint;

	private Color _badTint;

	private Color _sireTint;

	private Color[] _tints;

	private bool _hasBeenGenerated;

	private SignalBus _signalBus;

	private Material _pentagramMaterial;

	private CommandBuffer _commandBuffer;

	private void Construct(SignalBus signalBus)
	{
		_signalBus = signalBus;
	}

	public void Initialize()
	{
		GenerateTextures();
	}

	public void Dispose()
	{
		PentagramTextures.Clear();
		PentagramSprites.Clear();
		if (_commandBuffer != null)
		{
			_commandBuffer.Dispose();
		}
	}

	public static Texture2D GetTexture(PentagramType pentagram)
	{
		if (PentagramTextures != null)
		{
			int num = ((Dictionary<System.Int32Enum, object>)(object)PentagramTextures).FindEntry((System.Int32Enum)pentagram);
			if (num < 0)
			{
				return null;
			}
			if (PentagramTextures != null)
			{
				return (Texture2D)((Dictionary<System.Int32Enum, object>)(object)PentagramTextures).get_Item((System.Int32Enum)pentagram);
			}
		}
		return (Texture2D)(object)new NullReferenceException();
	}

	public static Sprite GetSprite(PentagramType pentagram)
	{
		if (PentagramSprites != null)
		{
			int num = ((Dictionary<System.Int32Enum, object>)(object)PentagramSprites).FindEntry((System.Int32Enum)pentagram);
			if (num < 0)
			{
				return null;
			}
			if (PentagramSprites != null)
			{
				return (Sprite)((Dictionary<System.Int32Enum, object>)(object)PentagramSprites).get_Item((System.Int32Enum)pentagram);
			}
		}
		return (Sprite)(object)new NullReferenceException();
	}

	private void GenerateTextures()
	{
		//IL_0569: Expected O, but got I4
		//IL_0572: Expected O, but got I4
		//IL_0613: Unknown result type (might be due to invalid IL or missing references)
		//IL_0618: Expected O, but got Unknown
		if (!_hasBeenGenerated)
		{
			_hasBeenGenerated = true;
			Material material = MaterialManager.GetMaterial(MaterialType.Pentagram);
			Material pentagramMaterial = UnityEngine.Object.Instantiate(material);
			_pentagramMaterial = pentagramMaterial;
			Texture2D circle = Resources.Load<Texture2D>("Circle");
			_circle = circle;
			Sprite sprite = SpriteManager.GetSprite("outer0", "vfx");
			Sprite sprite2 = SpriteManager.GetSprite("center", "vfx");
			Sprite sprite3 = SpriteManager.GetSprite("inner1", "vfx");
			Sprite sprite4 = SpriteManager.GetSprite("inner2", "vfx");
			Sprite sprite5 = SpriteManager.GetSprite("inner3", "vfx");
			Sprite sprite6 = SpriteManager.GetSprite("outer1", "vfx");
			Sprite sprite7 = SpriteManager.GetSprite("outer2", "vfx");
			Sprite sprite8 = SpriteManager.GetSprite("outer3", "vfx");
			Sprite[][] array = new Sprite[8][];
			Sprite[] array2 = new Sprite[4];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Sprite[] array3 = new Sprite[4];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Sprite[] array4 = new Sprite[4];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Sprite[] array5 = new Sprite[4];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Sprite[] array6 = new Sprite[4];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Sprite[] array7 = new Sprite[4];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Sprite[] array8 = new Sprite[4];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Sprite[] array9 = new Sprite[4];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			PentagramType[][] array10 = new PentagramType[8][];
			PentagramType[] array11 = new PentagramType[2];
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			PentagramType[] array12 = new PentagramType[2];
			_ = 3;
			_ = 2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			PentagramType[] array13 = new PentagramType[2];
			_ = 5;
			_ = 4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			PentagramType[] array14 = new PentagramType[2];
			_ = 7;
			_ = 6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			PentagramType[] array15 = new PentagramType[2];
			_ = 9;
			_ = 8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			PentagramType[] array16 = new PentagramType[2];
			_ = 11;
			_ = 10;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			PentagramType[] array17 = new PentagramType[2];
			_ = 13;
			_ = 12;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			PentagramType[] array18 = new PentagramType[2];
			_ = 15;
			_ = 14;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			CommandBuffer commandBuffer = new CommandBuffer();
			IntPtr ptr = CommandBuffer.InitBuffer();
			commandBuffer.m_Ptr = ptr;
			_commandBuffer = commandBuffer;
			_commandBuffer.name = "PentagramManagerBaker";
			object obj = 0;
			object obj2 = 0;
			float circleScale = default(float);
			Color circleTint = default(Color);
			MaterialType matType = default(MaterialType);
			while ((nint)obj2 < array.Length)
			{
				object obj3 = array10[obj];
				Sprite[] sprites = array[obj];
				Color[] tints = _tints;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v569 @ r9_v18+20]");
				MergeAndSaveTexture(sprites, tints, PentagramType.Lvl1Good, circleScale, circleTint, matType);
				object obj4 = array10[obj];
				Sprite[] sprites2 = array[obj];
				Color[] tints2 = _tints;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ r9_v20+24]");
				MergeAndSaveTexture(sprites2, tints2, PentagramType.Lvl1Good, circleScale, circleTint, matType);
				obj++;
				obj2 = obj;
			}
			Sprite sprite9 = SpriteManager.GetSprite("moon", "vfx");
			Sprite sprite10 = SpriteManager.GetSprite("moon2", "vfx");
			Sprite[] sprites3 = new Sprite[2];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			MergeAndSaveTexture(sprites3, _tints, PentagramType.Sire, circleScale, circleTint, matType);
		}
	}

	private unsafe Texture2D DoBlitter(Sprite[] sprites, Color[] tints, PentagramType type)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0b6c: Expected I, but got O
		//IL_0b8c: Expected O, but got I
		//IL_0bd1: Expected O, but got Ref
		//IL_0c17: Expected I, but got O
		//IL_0c37: Expected O, but got I
		//IL_10fb: Expected O, but got I4
		//IL_0289: Expected O, but got I4
		//IL_0249: Invalid comparison between I and F4
		//IL_02cd: Expected F4, but got I4
		//IL_027b: Expected O, but got F4
		//IL_0297: Invalid comparison between O and F4
		//IL_02a8: Expected F4, but got O
		//IL_026d: Expected O, but got I
		//IL_0311: Expected F4, but got I4
		//IL_14e0: Expected O, but got I4
		//IL_02db: Invalid comparison between O and F4
		//IL_02ec: Expected F4, but got O
		//IL_1189: Expected O, but got I4
		//IL_0355: Expected F4, but got I4
		//IL_11b4: Expected O, but got Ref
		//IL_11d7: Expected F4, but got I4
		//IL_11d7: Expected F4, but got I4
		//IL_11d7: Expected F4, but got I4
		//IL_11d7: Expected F4, but got O
		//IL_11e7: Expected O, but got I
		//IL_11f7: Expected O, but got I
		//IL_031f: Invalid comparison between O and F4
		//IL_0330: Expected F4, but got O
		//IL_03d0: Expected O, but got I4
		//IL_0390: Invalid comparison between I and F4
		//IL_1236: Expected native int or pointer, but got O
		//IL_1244: Expected native int or pointer, but got O
		//IL_1252: Expected native int or pointer, but got O
		//IL_0414: Expected F4, but got I4
		//IL_03c2: Expected O, but got F4
		//IL_03de: Invalid comparison between O and F4
		//IL_03ef: Expected F4, but got O
		//IL_03b4: Expected O, but got I
		//IL_085b: Expected O, but got Ref
		//IL_088e: Expected O, but got I
		//IL_089e: Expected O, but got I
		//IL_0458: Expected F4, but got I4
		//IL_0422: Invalid comparison between O and F4
		//IL_0433: Expected F4, but got O
		//IL_049c: Expected F4, but got I4
		//IL_12a5: Expected O, but got I4
		//IL_0466: Invalid comparison between O and F4
		//IL_0477: Expected F4, but got O
		//IL_12e4: Expected F4, but got I4
		//IL_12f4: Expected O, but got I
		//IL_1304: Expected O, but got I
		//IL_0517: Expected O, but got I4
		//IL_04d7: Invalid comparison between I and F4
		//IL_055b: Expected F4, but got I4
		//IL_0509: Expected O, but got F4
		//IL_1333: Expected O, but got Ref
		//IL_0525: Invalid comparison between O and F4
		//IL_0536: Expected F4, but got O
		//IL_04fb: Expected O, but got I
		//IL_059f: Expected F4, but got I4
		//IL_135b: Expected O, but got Ref
		//IL_1369: Expected O, but got Ref
		//IL_1377: Expected O, but got Ref
		//IL_0569: Invalid comparison between O and F4
		//IL_057a: Expected F4, but got O
		//IL_05e3: Expected F4, but got I4
		//IL_05ad: Invalid comparison between O and F4
		//IL_05be: Expected F4, but got O
		//IL_0988: Expected native int or pointer, but got O
		//IL_099d: Expected native int or pointer, but got O
		//IL_09b2: Expected native int or pointer, but got O
		//IL_09f2: Expected O, but got I
		//IL_09f2: Expected O, but got Ref
		//IL_09f2: Expected O, but got I
		//IL_0a02: Expected O, but got I
		//IL_0a12: Expected O, but got I
		//IL_065e: Expected O, but got I4
		//IL_061e: Invalid comparison between I and F4
		//IL_06a2: Expected F4, but got I4
		//IL_0650: Expected O, but got F4
		//IL_066c: Invalid comparison between O and F4
		//IL_067d: Expected F4, but got O
		//IL_0642: Expected O, but got I
		//IL_06e6: Expected F4, but got I4
		//IL_06b0: Invalid comparison between O and F4
		//IL_06c1: Expected F4, but got O
		//IL_072a: Expected F4, but got I4
		//IL_06f4: Invalid comparison between O and F4
		//IL_0705: Expected F4, but got O
		//IL_0a5f: Expected O, but got Ref
		//IL_073f: Expected O, but got I
		//IL_0754: Expected O, but got I
		//IL_0769: Expected O, but got I
		//IL_077e: Expected O, but got I
		//IL_10b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_10bd: Expected O, but got Unknown
		//IL_0afd: Expected O, but got I
		//IL_07ff->IL0b3f: Incompatible stack heights: 8 vs 0
		//IL_0c6d->IL0b3f: Incompatible stack heights: 9 vs 0
		//IL_1217->IL0b3f: Incompatible stack heights: 9 vs 0
		//IL_1284->IL0b3f: Incompatible stack heights: 10 vs 0
		//IL_13a9->IL0b3f: Incompatible stack heights: 15 vs 0
		//IL_0973->IL0b3f: Incompatible stack heights: 15 vs 0
		//IL_13f5->IL0b3f: Incompatible stack heights: 17 vs 0
		//IL_10aa->IL0b3f: Incompatible stack heights: 13 vs 0
		//IL_10cb->IL1479: Incompatible stack heights: 13 vs 8
		//IL_0b1d->IL0b3f: Incompatible stack heights: 17 vs 0
		RenderTargetIdentifier renderTargetIdentifier2 = default(RenderTargetIdentifier);
		RenderTargetIdentifier renderTargetIdentifier = (RenderTargetIdentifier)(&renderTargetIdentifier2);
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, "Pentagram Blitters");
		if ((object)gameObject != null)
		{
			Transform transform = gameObject.transform;
			GameObject gameObject2 = new GameObject();
			GameObject.Internal_CreateGameObject(gameObject2, "Pentagram Blitter");
			if ((object)gameObject2 != null)
			{
				Transform transform2 = gameObject2.transform;
				nint num = (nint)typeof(Vector2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v922 @ rcx_v76 (Il2CppClass<UnityEngine.Vector2>)+B8]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ rdx_v56 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
				object obj = 0;
				bool flag = (object)transform2 == null;
				_ = 0;
				bool flag2 = ((string)(object)transform2)._stringLength == 0;
				object obj2 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref renderTargetIdentifier2, 48));
				Transform.set_position_Injected((IntPtr)((string)(object)transform2)._stringLength, ref *(Vector3*)obj2);
				Transform transform3 = gameObject2.transform;
				bool flag3 = (object)transform3 == null;
				transform3.SetParent(transform, worldPositionStays: false);
				VampireSurvivors.Graphics.Blitters.Blitter blitter = gameObject2.AddComponent<VampireSurvivors.Graphics.Blitters.Blitter>();
				bool flag4 = (object)blitter == null;
				Renderer component = blitter.GetComponent<Renderer>();
				Material material = MaterialManager.GetMaterial(MaterialType.BlitterAdditive);
				bool flag5 = (object)component == null;
				component.SetMaterial(material);
				bool flag6 = sprites == null;
				bool flag7 = sprites.Length <= 0;
				bool flag8 = (object)sprites[0] == null;
				Texture2D texture = sprites[0].texture;
				blitter.SetAtlasTexture(texture);
				blitter._renderMode = BlitterRenderMode.ONCE;
				string text = null;
				string text2 = null;
				Vector2 vector = default(Vector2);
				object obj4 = default(object);
				object obj6 = default(object);
				object obj8 = default(object);
				RenderTextureFormat renderTextureFormat = default(RenderTextureFormat);
				Vector2 backgroundColor = default(Vector2);
				bool flag27 = default(bool);
				IntPtr intPtr = default(IntPtr);
				bool createUninitialized = default(bool);
				while (true)
				{
					if ((nint)text2 < sprites.Length)
					{
						bool flag9 = (nint)text >= sprites.Length;
						nint num3 = (nint)typeof(Vector2);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2140 @ rax_v207 (Il2CppClass<UnityEngine.Vector2>)+B8]");
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2141 @ rcx_v176 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
						obj = 0;
						Bob bob = blitter.CreateBob(vector, sprites[(object)text]);
						if (tints == null)
						{
							break;
						}
						bool flag10 = tints.Length <= 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [tints @ r8 (UnityEngine.Color[])+20]");
						Color color;
						if ((nint)0 <= (nint)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [tints @ r8 (UnityEngine.Color[])+20]");
							if (!(0f > 1f))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [tints @ r8 (UnityEngine.Color[])+20]");
								color = (Color)0;
							}
							else
							{
								color = (Color)1f;
							}
						}
						else
						{
							color = (Color)0;
						}
						float num5 = (float)color * 255f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
						float num6;
						if (0 <= (nint)vector)
						{
							bool flag11 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
							num6 = (float)vector;
							if (!flag11)
							{
								num6 = 1f;
							}
						}
						else
						{
							num6 = 0f;
						}
						float num7 = num6 * 255f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
						float num8;
						if (0 <= (nint)vector)
						{
							bool flag12 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
							num8 = (float)vector;
							if (!flag12)
							{
								num8 = 1f;
							}
						}
						else
						{
							num8 = 0f;
						}
						float num9 = num8 * 255f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
						float num10;
						if (0 <= (nint)vector)
						{
							bool flag13 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
							num10 = (float)vector;
							if (!flag13)
							{
								num10 = 1f;
							}
						}
						else
						{
							num10 = 0f;
						}
						float num11 = num10 * 255f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm0\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm9\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm10\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm11\"");
						object obj3 = obj4 >> 16;
						bool flag14 = tints.Length <= 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [tints @ r8 (UnityEngine.Color[])+30]");
						Color color2;
						if ((nint)0 <= (nint)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [tints @ r8 (UnityEngine.Color[])+30]");
							if (!(0f > 1f))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [tints @ r8 (UnityEngine.Color[])+30]");
								color2 = (Color)0;
							}
							else
							{
								color2 = (Color)1f;
							}
						}
						else
						{
							color2 = (Color)0;
						}
						float num12 = (float)color2 * 255f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
						float num13;
						if (0 <= (nint)vector)
						{
							bool flag15 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
							num13 = (float)vector;
							if (!flag15)
							{
								num13 = 1f;
							}
						}
						else
						{
							num13 = 0f;
						}
						float num14 = num13 * 255f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
						float num15;
						if (0 <= (nint)vector)
						{
							bool flag16 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
							num15 = (float)vector;
							if (!flag16)
							{
								num15 = 1f;
							}
						}
						else
						{
							num15 = 0f;
						}
						float num16 = num15 * 255f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
						float num17;
						if (0 <= (nint)vector)
						{
							bool flag17 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
							num17 = (float)vector;
							if (!flag17)
							{
								num17 = 1f;
							}
						}
						else
						{
							num17 = 0f;
						}
						float num18 = num17 * 255f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm0\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm9\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm10\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm11\"");
						object obj5 = obj6 >> 16;
						bool flag18 = tints.Length <= 2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [tints @ r8 (UnityEngine.Color[])+40]");
						Color color3;
						if ((nint)0 <= (nint)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [tints @ r8 (UnityEngine.Color[])+40]");
							if (!(0f > 1f))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [tints @ r8 (UnityEngine.Color[])+40]");
								color3 = (Color)0;
							}
							else
							{
								color3 = (Color)1f;
							}
						}
						else
						{
							color3 = (Color)0;
						}
						float num19 = (float)color3 * 255f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
						float num20;
						if (0 <= (nint)vector)
						{
							bool flag19 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
							num20 = (float)vector;
							if (!flag19)
							{
								num20 = 1f;
							}
						}
						else
						{
							num20 = 0f;
						}
						float num21 = num20 * 255f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
						float num22;
						if (0 <= (nint)vector)
						{
							bool flag20 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
							num22 = (float)vector;
							if (!flag20)
							{
								num22 = 1f;
							}
						}
						else
						{
							num22 = 0f;
						}
						float num23 = num22 * 255f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
						float num24;
						if (0 <= (nint)vector)
						{
							bool flag21 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
							num24 = (float)vector;
							if (!flag21)
							{
								num24 = 1f;
							}
						}
						else
						{
							num24 = 0f;
						}
						float num25 = num24 * 255f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm0\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm9\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm10\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm11\"");
						object obj7 = obj8 >> 16;
						bool flag22 = tints.Length <= 3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [tints @ r8 (UnityEngine.Color[])+50]");
						Color color4;
						if ((nint)0 <= (nint)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [tints @ r8 (UnityEngine.Color[])+50]");
							if (!(0f > 1f))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [tints @ r8 (UnityEngine.Color[])+50]");
								color4 = (Color)0;
							}
							else
							{
								color4 = (Color)1f;
							}
						}
						else
						{
							color4 = (Color)0;
						}
						float num26 = (float)color4 * 255f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
						float num27;
						if (0 <= (nint)vector)
						{
							bool flag23 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
							num27 = (float)vector;
							if (!flag23)
							{
								num27 = 1f;
							}
						}
						else
						{
							num27 = 0f;
						}
						float num28 = num27 * 255f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
						float num29;
						if (0 <= (nint)vector)
						{
							bool flag24 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
							num29 = (float)vector;
							if (!flag24)
							{
								num29 = 1f;
							}
						}
						else
						{
							num29 = 0f;
						}
						float num30 = num29 * 255f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
						float num31;
						if (0 <= (nint)vector)
						{
							bool flag25 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
							num31 = (float)vector;
							if (!flag25)
							{
								num31 = 1f;
							}
						}
						else
						{
							num31 = 0f;
						}
						float num32 = num31 * 255f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm0\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm9\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm10\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm11\"");
						if (bob == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ rax_v208 (VampireSurvivors.Graphics.Blitters.Bob)+28]");
						object obj9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ rax_v208 (VampireSurvivors.Graphics.Blitters.Bob)+28]");
						object obj10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ rax_v208 (VampireSurvivors.Graphics.Blitters.Bob)+28]");
						object obj11 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ rax_v208 (VampireSurvivors.Graphics.Blitters.Bob)+28]");
						object obj12 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1 (UnityEngine.Rendering.RenderTargetIdentifier)+148]");
						if ((nint)0 == 16)
						{
							_ = 1056964608;
							_ = 1056964608;
						}
						text++;
						text2 = text;
						continue;
					}
					blitter.UpdateBobs();
					RenderTexture renderTexture = new RenderTexture(256, 256, 0, renderTextureFormat);
					if ((object)renderTexture == null)
					{
						break;
					}
					bool flag26 = ((UnityEngine.Object)renderTexture).m_CachedPtr == (IntPtr)0;
					object obj13 = RenderTexture.Create_Injected(((UnityEngine.Object)renderTexture).m_CachedPtr);
					IntPtr active_Injected = RenderTexture.GetActive_Injected();
					RenderTexture renderTexture2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<RenderTexture>(active_Injected);
					nint num33 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2700 @ rcx_v100 (Il2CppMethodInfo)+38]");
					if ((nint)0 == 0)
					{
						RenderTexture renderTexture3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<RenderTexture>((nint)(delegate*<RenderTexture, IntPtr>)(&UnityEngine.Object.MarshalledUnityObject.Marshal));
					}
					RenderTexture.SetActive_Injected(((UnityEngine.Object)renderTexture).m_CachedPtr);
					GL.GLClear_Injected(true, true, ref *(Color*)(&backgroundColor), 0f);
					Texture2D texture2D = new Texture2D(256, 256, TextureFormat.ARGB32, (int)renderTextureFormat, flag27, intPtr, createUninitialized, (MipmapLimitDescriptor)1);
					texture2D._002Ector(256, 256, TextureFormat.ARGB32, (int)renderTextureFormat, flag27, intPtr, createUninitialized, (MipmapLimitDescriptor)1);
					_ = 0;
					_ = 0;
					_ = 0;
					_ = 0;
					object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref renderTargetIdentifier2, 128));
					Matrix4x4.Ortho_Injected((float)obj14, 256f, 256f, 5f, 0f, 1f, out *(Matrix4x4*)null);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1 (UnityEngine.Rendering.RenderTargetIdentifier)+130]");
					string text3 = (string)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rdi_v34 (System.String)+68]");
					object obj15 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rdi_v34 (System.String)+68]");
					if ((nint)0 == 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ rcx_v110 (System.Object)+10]");
					bool flag28 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ rcx_v110 (System.Object)+10]");
					CommandBuffer.Clear_Injected((IntPtr)0);
					((RenderTargetIdentifier*)(nint)renderTargetIdentifier)->m_DepthSlice = 0;
					((RenderTargetIdentifier*)(nint)renderTargetIdentifier)->m_Type = BuiltinRenderTextureType.None;
					((RenderTargetIdentifier*)(nint)renderTargetIdentifier)->m_BufferPointer = (IntPtr)0;
					renderTargetIdentifier2 = new RenderTargetIdentifier(renderTexture);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rdi_v34 (System.String)+68]");
					if ((nint)0 == 0)
					{
						break;
					}
					RenderTargetIdentifier renderTarget = (RenderTargetIdentifier)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref renderTargetIdentifier2, 64));
					_ = renderTargetIdentifier.m_Type;
					_ = renderTargetIdentifier.m_DepthSlice;
					_ = renderTargetIdentifier.m_BufferPointer;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rdi_v34 (System.String)+68]");
					((CommandBuffer)0).SetRenderTarget(renderTarget);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rdi_v34 (System.String)+68]");
					GameObject gameObject3 = (GameObject)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rdi_v34 (System.String)+68]");
					bool flag29 = (nint)0 == 0;
					bool flag30 = ((UnityEngine.Object)gameObject3).m_CachedPtr == (IntPtr)0;
					object obj16 = CommandBuffer.ValidateAgainstExecutionFlags_Injected(((UnityEngine.Object)gameObject3).m_CachedPtr, CommandBufferExecutionFlags.None, CommandBufferExecutionFlags.AsyncCompute);
					bool flag31 = ((UnityEngine.Object)gameObject3).m_CachedPtr == (IntPtr)0;
					CommandBuffer.ClearRenderTargetSingle_Internal_Injected(((UnityEngine.Object)gameObject3).m_CachedPtr, RTClearFlags.All, ref *(Color*)(&backgroundColor), 5f, 0u);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1 (UnityEngine.Rendering.RenderTargetIdentifier)+130]");
					string text4 = (string)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2214 @ rdi_v37 (System.String)+68]");
					object obj17 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2214 @ rdi_v37 (System.String)+68]");
					bool flag32 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1 (UnityEngine.Rendering.RenderTargetIdentifier)-80]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1 (UnityEngine.Rendering.RenderTargetIdentifier)-70]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1 (UnityEngine.Rendering.RenderTargetIdentifier)-60]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1 (UnityEngine.Rendering.RenderTargetIdentifier)-50]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3627 @ rcx_v119 (System.Object)+10]");
					bool flag33 = (nint)0 == 0;
					object obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref renderTargetIdentifier2, 64));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3627 @ rcx_v119 (System.Object)+10]");
					CommandBuffer.SetProjectionMatrix_Injected((IntPtr)0, ref *(Matrix4x4*)obj18);
					_ = 0.75f;
					_ = Quaternion.identityQuaternion;
					_ = 0;
					_ = 0;
					_ = 0;
					_ = 0;
					object obj19 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref renderTargetIdentifier2, 128));
					object obj20 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref renderTargetIdentifier2, 32));
					object obj21 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref renderTargetIdentifier2, 16));
					Matrix4x4.TRS_Injected(ref *(Vector3*)(&backgroundColor), ref *(Quaternion*)obj21, ref *(Vector3*)obj20, out *(Matrix4x4*)obj19);
					if ((object)blitter._meshRenderer == null)
					{
						break;
					}
					Material material2 = ((Renderer)blitter._meshRenderer).GetMaterial();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2214 @ rdi_v37 (System.String)+68]");
					if ((nint)0 == 0)
					{
						break;
					}
					RenderTargetIdentifier renderTargetIdentifier3 = renderTargetIdentifier;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1 (UnityEngine.Rendering.RenderTargetIdentifier)-80]");
					((RenderTargetIdentifier*)(nint)renderTargetIdentifier3)->m_Type = BuiltinRenderTextureType.None;
					RenderTargetIdentifier renderTargetIdentifier4 = renderTargetIdentifier;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1 (UnityEngine.Rendering.RenderTargetIdentifier)-70]");
					((RenderTargetIdentifier*)(nint)renderTargetIdentifier4)->m_BufferPointer = (IntPtr)0;
					RenderTargetIdentifier renderTargetIdentifier5 = renderTargetIdentifier;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1 (UnityEngine.Rendering.RenderTargetIdentifier)-60]");
					((RenderTargetIdentifier*)(nint)renderTargetIdentifier5)->m_DepthSlice = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1 (UnityEngine.Rendering.RenderTargetIdentifier)-50]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2214 @ rdi_v37 (System.String)+68]");
					((CommandBuffer)0).DrawMesh(blitter._mesh, (Matrix4x4)(&renderTargetIdentifier2), material2, (int)renderTextureFormat, flag27 ? 1 : 0, (MaterialPropertyBlock)(nint)intPtr);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1 (UnityEngine.Rendering.RenderTargetIdentifier)+130]");
					object obj22 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4135 @ rbx_v40+68]");
					GameObject gameObject4 = (GameObject)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4135 @ rbx_v40+68]");
					bool flag34 = (nint)0 == 0;
					bool flag35 = ((UnityEngine.Object)gameObject4).m_CachedPtr == (IntPtr)0;
					UnityEngine.Graphics.ExecuteCommandBuffer_Injected(((UnityEngine.Object)gameObject4).m_CachedPtr);
					if ((object)texture2D == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A127E0]");
					_ = 0;
					Rect source = (Rect)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref renderTargetIdentifier2, 16));
					texture2D.ReadPixels(source, 0, 0);
					texture2D.Apply(updateMipmaps: true, makeNoLongerReadable: false);
					nint num34 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4366 @ rcx_v136 (Il2CppMethodInfo)+38]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
					}
					bool flag36 = (object)renderTexture2 == null;
					nint active_Injected2 = 0;
					if (!flag36)
					{
						active_Injected2 = ((UnityEngine.Object)renderTexture2).m_CachedPtr;
					}
					RenderTexture.SetActive_Injected((IntPtr)active_Injected2);
					UnityEngine.Object.Destroy(renderTexture, 0f);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1 (UnityEngine.Rendering.RenderTargetIdentifier)-40]");
					string text5 = (string)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1 (UnityEngine.Rendering.RenderTargetIdentifier)-40]");
					if ((nint)0 == 0)
					{
						break;
					}
					bool flag37 = text5._stringLength == 0;
					IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)text5._stringLength);
					GameObject obj23 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
					UnityEngine.Object.Destroy(obj23, 0f);
					return texture2D;
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe Texture2D PadTexture(Texture2D texture, int width, int height)
	{
		//IL_0153: Expected O, but got I4
		//IL_01f8: Expected O, but got I4
		//IL_0217: Expected I, but got O
		//IL_0231: Expected O, but got I4
		//IL_0271: Expected O, but got I4
		//IL_006b: Expected I4, but got O
		//IL_006b: Expected O, but got I4
		//IL_0087: Expected O, but got Ref
		RenderTextureFormat renderTextureFormat = default(RenderTextureFormat);
		RenderTexture renderTexture = new RenderTexture(width, height, 0, renderTextureFormat);
		bool flag = ((UnityEngine.Object)renderTexture).m_CachedPtr == (IntPtr)0;
		object obj = RenderTexture.Create_Injected(((UnityEngine.Object)renderTexture).m_CachedPtr);
		RenderTexture active = RenderTexture.GetActive();
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v487 @ rcx_v29 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		RenderTexture.SetActive_Injected(((UnityEngine.Object)renderTexture).m_CachedPtr);
		int backgroundColor = default(int);
		GL.GLClear_Injected(true, true, ref *(Color*)(&backgroundColor), 0f);
		bool flag2 = ((UnityEngine.Object)texture).m_CachedPtr == (IntPtr)0;
		TextureFormat textureFormat = Texture2D.get_format_Injected(((UnityEngine.Object)texture).m_CachedPtr);
		bool flag3 = default(bool);
		IntPtr intPtr = default(IntPtr);
		bool flag4 = default(bool);
		Texture2D texture2D = new Texture2D(width, height, textureFormat, (int)renderTextureFormat, flag3, intPtr, flag4, (MipmapLimitDescriptor)1);
		int width2 = texture.width;
		nint num2 = (nint)texture;
		int height2 = texture.height;
		object obj2 = width - width2;
		object obj3 = obj2 >> 31;
		object obj4 = obj2 - obj3;
		object obj5 = obj4 >> 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		object obj6 = height - height2;
		object obj7 = obj6 >> 31;
		object obj8 = obj6 - obj7;
		object obj9 = obj8 >> 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		UnityEngine.Graphics.CopyTexture(texture, 0, 0, 0, (int)renderTextureFormat, flag3 ? 1 : 0, (int)(nint)intPtr, (Texture)flag4, 0, width2, height2, (int)renderTexture);
		texture2D.ReadPixels((Rect)(&backgroundColor), 0, 0);
		texture2D.Apply(updateMipmaps: true, makeNoLongerReadable: false);
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v942 @ rcx_v47 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		bool flag5 = (object)active == null;
		int num4 = 0;
		if (!flag5)
		{
			num4 = (int)(nint)((UnityEngine.Object)active).m_CachedPtr;
		}
		RenderTexture.SetActive_Injected((IntPtr)num4);
		UnityEngine.Object.Destroy(renderTexture, 0f);
		return texture2D;
	}

	private unsafe void CopyToRT(Texture2D texture, RenderTexture renderTexture, MaterialType matType = MaterialType.Vfx)
	{
		//IL_0029: Expected O, but got Ref
		Material material = MaterialManager.GetMaterial(matType);
		object obj = default(object);
		material.SetColor("_Color", (Color)(&obj));
		UnityEngine.Graphics.Blit(texture, renderTexture, material);
	}

	private unsafe void RenderCircle(Texture2D texture, RenderTexture renderTexture, int width, int height, float circleScale, Color circleTint)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected I4, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected I4, but got Unknown
		//IL_00a7: Expected O, but got I4
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected I4, but got Unknown
		//IL_00e5: Expected O, but got Ref
		int width2 = _circle.width;
		int width3 = _circle.width;
		int num = width3 / width;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm1\"");
		object obj = num * _circle;
		int height2 = _circle.height;
		int height3 = _circle.height;
		int width4 = obj + width2;
		object obj2 = default(object);
		int num2 = height3 / obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r9d,xmm6\"");
		object obj3 = width * num2;
		int height4 = obj3 + height2;
		Texture2D source = PadTexture(_circle, width4, height4);
		object obj4 = default(object);
		_pentagramMaterial.SetColor("_Color", (Color)(&obj4));
		UnityEngine.Graphics.Blit(source, renderTexture, _pentagramMaterial);
	}

	private unsafe void MergeAndSaveTexture(Sprite[] sprites, Color[] tints, PentagramType key, float circleScale, Color circleTint, MaterialType matType)
	{
		//IL_0240: Expected O, but got I4
		//IL_0416: Expected O, but got I4
		//IL_0285: Expected O, but got I4
		//IL_02a4: Expected O, but got I
		//IL_02a4: Expected F4, but got I4
		//IL_0064: Expected O, but got Ref
		//IL_00ae: Expected O, but got Ref
		//IL_037b: Expected O, but got I4
		//IL_037b: Expected O, but got I
		//IL_037b: Expected O, but got Ref
		//IL_017b: Expected O, but got Ref
		//IL_004d->IL01cf: Incompatible stack heights: 1 vs 0
		//IL_0092->IL01cf: Incompatible stack heights: 1 vs 0
		//IL_032d->IL01cf: Incompatible stack heights: 2 vs 0
		//IL_034b->IL01cf: Incompatible stack heights: 2 vs 0
		//IL_045b->IL01cf: Incompatible stack heights: 2 vs 0
		//IL_0197->IL01cf: Incompatible stack heights: 2 vs 0
		//IL_03a2->IL01cf: Incompatible stack heights: 2 vs 0
		RenderTextureFormat renderTextureFormat = default(RenderTextureFormat);
		RenderTexture renderTexture = new RenderTexture(256, 256, 0, renderTextureFormat);
		if ((object)renderTexture != null)
		{
			bool flag = ((UnityEngine.Object)renderTexture).m_CachedPtr == (IntPtr)0;
			object obj = RenderTexture.Create_Injected(((UnityEngine.Object)renderTexture).m_CachedPtr);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ rcx_v26 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
			RenderTexture.SetActive_Injected(((UnityEngine.Object)renderTexture).m_CachedPtr);
			Color backgroundColor = default(Color);
			GL.GLClear_Injected(true, true, ref backgroundColor, 0f);
			bool flag2 = default(bool);
			IntPtr intPtr = default(IntPtr);
			bool flag3 = default(bool);
			Texture2D texture2D = new Texture2D(256, 256, TextureFormat.ARGB32, (int)renderTextureFormat, flag2, intPtr, flag3, (MipmapLimitDescriptor)1);
			texture2D._002Ector(256, 256, TextureFormat.ARGB32, (int)renderTextureFormat, flag2, intPtr, flag3, (MipmapLimitDescriptor)1);
			RenderCircle(texture2D, renderTexture, 256, (int)renderTextureFormat, flag2 ? 1 : 0, (Color)(nint)intPtr);
			Texture2D source = DoBlitter(sprites, tints, key);
			MaterialType type = default(MaterialType);
			Material material = MaterialManager.GetMaterial(type);
			if ((object)material != null)
			{
				material.SetColor("_Color", (Color)(&backgroundColor));
				UnityEngine.Graphics.Blit(source, renderTexture, material);
				if ((object)texture2D != null)
				{
					texture2D.ReadPixels((Rect)(&backgroundColor), 0, 0);
					texture2D.Apply(updateMipmaps: true, makeNoLongerReadable: false);
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v971 @ rcx_v45 (Il2CppMethodInfo)+38]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
					}
					RenderTexture.SetActive_Injected((IntPtr)0);
					bool flag4 = ((UnityEngine.Object)renderTexture).m_CachedPtr == (IntPtr)0;
					RenderTexture.Release_Injected(((UnityEngine.Object)renderTexture).m_CachedPtr);
					if (PentagramTextures != null)
					{
						int num3 = ((Dictionary<System.Int32Enum, object>)(object)PentagramTextures).FindEntry((System.Int32Enum)key);
						if (num3 < 0)
						{
							if (PentagramTextures == null)
							{
								goto IL_01cf;
							}
							bool flag5 = ((Dictionary<System.Int32Enum, object>)(object)PentagramTextures).TryInsert((System.Int32Enum)key, (object)texture2D, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
						}
						object obj2 = default(object);
						Vector2 pivot = default(Vector2);
						Sprite sprite = Sprite.Create(texture2D, (Rect)(&obj2), pivot, 100f, (uint)renderTextureFormat, flag2 ? SpriteMeshType.Tight : SpriteMeshType.FullRect, (Vector4)(nint)intPtr, flag3, (SecondarySpriteTexture[])1);
						if (PentagramSprites != null)
						{
							int num4 = ((Dictionary<System.Int32Enum, object>)(object)PentagramSprites).FindEntry((System.Int32Enum)key);
							if (num4 >= 0)
							{
								return;
							}
							string name = ((Enum)(&obj2)).ToString();
							if ((object)sprite != null)
							{
								((UnityEngine.Object)sprite).SetName(name);
								if (PentagramSprites != null)
								{
									bool flag6 = ((Dictionary<System.Int32Enum, object>)(object)PentagramSprites).TryInsert((System.Int32Enum)key, (object)sprite, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_01cf;
		IL_01cf:
		throw new NullReferenceException();
	}

	private void SaveMergedTexture(Texture2D texture, PentagramType key)
	{
		int num = ((Dictionary<System.Int32Enum, object>)(object)PentagramTextures).FindEntry((System.Int32Enum)key);
		if (num < 0)
		{
			bool flag = ((Dictionary<System.Int32Enum, object>)(object)PentagramTextures).TryInsert((System.Int32Enum)key, (object)texture, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		}
	}

	private unsafe void SaveMergedSprite(Sprite sprite, PentagramType key)
	{
		//IL_0040: Expected O, but got Ref
		int num = ((Dictionary<System.Int32Enum, object>)(object)PentagramSprites).FindEntry((System.Int32Enum)key);
		if (num < 0)
		{
			object obj = default(object);
			string name = ((Enum)(&obj)).ToString();
			((UnityEngine.Object)sprite).SetName(name);
			bool flag = ((Dictionary<System.Int32Enum, object>)(object)PentagramSprites).TryInsert((System.Int32Enum)key, (object)sprite, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		}
	}

	public PentagramManager()
	{
		//IL_006a: Expected O, but got I
		//IL_007c: Expected O, but got I
		//IL_008e: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11E00]");
		_goodTint = (Color)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11E80]");
		_sireTint = (Color)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11DF0]");
		_badTint = (Color)0;
		Color[] tints = new Color[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12030]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12030]");
		_ = 0;
		_tints = tints;
	}

	static PentagramManager()
	{
		Dictionary<PentagramType, Texture2D> pentagramTextures = new Dictionary<PentagramType, Texture2D>();
		PentagramTextures = pentagramTextures;
		Dictionary<PentagramType, Sprite> pentagramSprites = new Dictionary<PentagramType, Sprite>();
		PentagramSprites = pentagramSprites;
	}
}
