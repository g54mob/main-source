using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using Zenject;

namespace VampireSurvivors.Graphics;

public class SpriteManager : IInitializable
{
	public class StringHashCaseIComparer : IEqualityComparer<StringHashCaseI>
	{
		public static readonly StringHashCaseIComparer Instance;

		public bool Equals(StringHashCaseI x, StringHashCaseI y)
		{
			object obj = (object)x - (object)y;
			return obj == null;
		}

		public int GetHashCode(StringHashCaseI obj)
		{
			//IL_0005: Expected I4, but got O
			return (int)obj;
		}

		static StringHashCaseIComparer()
		{
			StringHashCaseIComparer instance = new StringHashCaseIComparer();
			Instance = instance;
		}
	}

	public struct StringHashCaseI : IEquatable<StringHashCaseI>
	{
		public readonly int _Hash;

		public StringHashCaseI(string str)
		{
			//IL_0012: Expected I4, but got I8
			int strHashCode = GetStrHashCode(str, -1);
			_Hash = strHashCode;
		}

		public StringHashCaseI(string str, bool ignoreExtension)
		{
			//IL_0102: Expected I4, but got I8
			//IL_0074: Expected O, but got I4
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Expected O, but got Unknown
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Expected O, but got Unknown
			int num;
			if (ignoreExtension)
			{
				bool flag = (nint)str < 0;
				if (str != null)
				{
					num = str._stringLength - 1;
					if (!flag)
					{
						object obj = num + 10;
						object obj2 = obj * 2;
						object obj3 = str + obj2;
						while (true)
						{
							if (num < str._stringLength)
							{
								if ((nint)obj3 == 46)
								{
									break;
								}
								object obj4 = obj3 - 2;
								num--;
								bool flag2 = (nint)obj3 >= 46;
								obj3 = obj4;
								if (flag2)
								{
									continue;
								}
								goto IL_00f5;
							}
							System.ThrowHelper.ThrowIndexOutOfRangeException();
							return;
						}
						goto IL_010d;
					}
				}
			}
			goto IL_00f5;
			IL_00f5:
			num = -1;
			goto IL_010d;
			IL_010d:
			int strHashCode = GetStrHashCode(str, num);
			_Hash = strHashCode;
		}

		public static implicit operator StringHashCaseI(string str)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 2 Invalid \"Jump target not found in method: 0x1876000D0\"");
			StringHashCaseI result = default(StringHashCaseI);
			return result;
		}

		public static int GetStrHashCode(string str, int lenght = -1)
		{
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			//IL_012f: Expected O, but got I4
			//IL_017d: Expected O, but got I4
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_018a: Expected I4, but got Unknown
			//IL_0063: Expected I4, but got O
			//IL_0075: Expected O, but got I4
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Expected O, but got Unknown
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Expected I4, but got Unknown
			//IL_00c2: Expected I4, but got O
			//IL_00d4: Expected O, but got I4
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Expected O, but got Unknown
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Expected I4, but got Unknown
			int num2;
			int num3;
			if (str != null)
			{
				object obj = str + 20;
				int num = default(int);
				object obj3 = default(object);
				if (num > 0)
				{
					object obj2 = str._stringLength * 2;
					obj3 = obj + obj2;
					bool flag = obj == obj3;
					num2 = 5381;
					num3 = 5381;
					if (flag)
					{
						goto IL_016f;
					}
				}
				int num4 = 5381;
				num3 = 5381;
				bool flag3;
				do
				{
					char c = char.ToLowerInvariant((char)(int)obj);
					object obj4 = num3 * 33;
					object obj5 = obj + 2;
					num3 = obj4 ^ c;
					bool flag2 = obj5 == obj3;
					num2 = num4;
					if (flag2)
					{
						break;
					}
					char c2 = char.ToLowerInvariant((char)(int)obj5);
					object obj6 = num4 * 33;
					obj = obj5 + 2;
					num2 = obj6 ^ c2;
					flag3 = obj != obj3;
					num4 = num2;
				}
				while (flag3);
				goto IL_016f;
			}
			return 1;
			IL_016f:
			object obj7 = num2 * 1566083941;
			return obj7 + num3;
		}

		public override bool Equals(object obj)
		{
			//IL_0013: Expected I, but got O
			//IL_0057: Expected I, but got O
			//IL_00c5: Expected I4, but got O
			//IL_009d: Expected O, but got I
			if (obj != null)
			{
				nint num = (nint)typeof(StringHashCaseI);
				bool flag = (object)obj.GetType() != typeof(StringHashCaseI);
				object obj2 = null;
				if (!flag)
				{
					obj2 = obj;
				}
				if (obj2 != null)
				{
					nint num2 = (nint)obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rcx_v2 (Il2CppClass<System.Object>)+40]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rdx_v2 (Il2CppClass<VampireSurvivors.Graphics.SpriteManager+StringHashCaseI>)+40]");
					if (num3 == 0)
					{
						int hash = _Hash;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ rdx (System.Object)+10]");
						object obj3 = (nint)hash - (nint)0;
						return obj3 == null;
					}
					InvalidCastException ex = new InvalidCastException();
					return (byte)(int)ex != 0;
				}
			}
			return false;
		}

		public override int GetHashCode()
		{
			return _Hash;
		}

		public bool Equals(StringHashCaseI other)
		{
			//IL_000a: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Expected O, but got Unknown
			object obj = _Hash - other;
			return obj == null;
		}
	}

	public static bool HighlightMissingAssetErrors;

	private Sprite[] _rawSprites;

	private static readonly Dictionary<StringHashCaseI, Sprite> Sprites;

	private static readonly Dictionary<StringHashCaseI, string> AnimationsTextureReferences;

	private static readonly Dictionary<StringHashCaseI, List<Sprite>> Animations;

	private static readonly Dictionary<StringHashCaseI, Texture2D> SpritesAsTextures;

	private static readonly Dictionary<StringHashCaseI, Dictionary<StringHashCaseI, Sprite>> SpriteTextureReference;

	private static readonly Dictionary<int, string> FastAnimationsTextureReferences;

	private static readonly Dictionary<int, List<Sprite>> FastAnimations;

	private static readonly bool LogWarnings;

	private static readonly Dictionary<string, Dictionary<string, Sprite>> SpriteTextureCache;

	private static readonly ProfilerMarker MarkerGetSprite1;

	private static readonly ProfilerMarker MarkerGetSprite2;

	private static readonly ProfilerMarker _markerGetAnimationFrames;

	private static readonly ProfilerMarker MarkerGetAnimationFramesFast;

	public void Initialize()
	{
		//IL_00af: Expected O, but got I4
		//IL_00b8: Expected O, but got I4
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		Sprite[] rawSprites = Resources.LoadAll<Sprite>("SpriteSheets");
		_rawSprites = rawSprites;
		Sprite[] rawSprites2 = _rawSprites;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < rawSprites2.Length)
		{
			RegisterSprite(rawSprites2[obj]);
			obj++;
			obj2 = obj;
		}
		Sprite sprite = Resources.Load<Sprite>("SpriteSheets/Stars1");
		((UnityEngine.Object)sprite).SetName("hStars1");
		RegisterSprite(sprite);
		Sprite sprite2 = Resources.Load<Sprite>("SpriteSheets/Stars2");
		((UnityEngine.Object)sprite2).SetName("hStars2");
		RegisterSprite(sprite2);
	}

	[MethodImpl((MethodImplOptions)256)]
	public static Sprite GetSpriteFast(string spriteName, string textureName)
	{
		return GetSprite(spriteName, textureName, ignoreExtension: false);
	}

	public static Sprite GetSprite(string spriteName, bool ignoreExtension = true)
	{
		//IL_01ba: Expected I, but got O
		//IL_00ea: Expected I4, but got I8
		//IL_0105: Expected O, but got I4
		//IL_0062: Expected O, but got I4
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_017b->IL00f3: Incompatible stack heights: 1 vs 0
		//IL_00d3->IL01e7: Incompatible stack heights: 1 vs 0
		//IL_00d8->IL00d8: Incompatible stack heights: 1 vs 0
		if ((object)MarkerGetSprite1 != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)MarkerGetSprite1);
		}
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		if (spriteName == null || spriteName._stringLength <= 0)
		{
			autoScope.Dispose();
			return null;
		}
		bool flag = (ignoreExtension ? 1 : 0) < (false ? 1 : 0);
		int strHashCode;
		if (ignoreExtension)
		{
			int num = spriteName._stringLength - 1;
			if (!flag)
			{
				object obj = num + num;
				while (true)
				{
					bool flag2 = num >= spriteName._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rax_v30+14+spriteName @ rcx (System.String)]");
					if ((nint)0 == 46)
					{
						break;
					}
					object obj2 = obj - 2;
					num--;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rax_v30+14+spriteName @ rcx (System.String)]");
					bool flag3 = (nint)0 >= (nint)46;
					obj = obj2;
					if (flag3)
					{
						continue;
					}
					goto IL_00d8;
				}
				strHashCode = StringHashCaseI.GetStrHashCode(spriteName, num);
				goto IL_00f3;
			}
		}
		goto IL_00d8;
		IL_00d8:
		strHashCode = StringHashCaseI.GetStrHashCode(spriteName, -1);
		goto IL_00f3;
		IL_00f3:
		if (!((Dictionary<StringHashCaseI, object>)(object)Sprites).TryGetValue((StringHashCaseI)strHashCode, out object value))
		{
			string message = "Could not find sprite : " + spriteName;
			Debug.LogWarning(message);
			autoScope.Dispose();
			return null;
		}
		autoScope.Dispose();
		return (Sprite)value;
	}

	public static Sprite GetUnpackedSprite(string spriteName, bool ignoreExtension = true)
	{
		//IL_01ba: Expected I, but got O
		//IL_00ea: Expected I4, but got I8
		//IL_0105: Expected O, but got I4
		//IL_0062: Expected O, but got I4
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_017b->IL00f3: Incompatible stack heights: 1 vs 0
		//IL_00d3->IL01e7: Incompatible stack heights: 1 vs 0
		//IL_00d8->IL00d8: Incompatible stack heights: 1 vs 0
		if ((object)MarkerGetSprite1 != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)MarkerGetSprite1);
		}
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		if (spriteName == null || spriteName._stringLength <= 0)
		{
			autoScope.Dispose();
			return null;
		}
		bool flag = (ignoreExtension ? 1 : 0) < (false ? 1 : 0);
		int strHashCode;
		if (ignoreExtension)
		{
			int num = spriteName._stringLength - 1;
			if (!flag)
			{
				object obj = num + num;
				while (true)
				{
					bool flag2 = num >= spriteName._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rax_v30+14+spriteName @ rcx (System.String)]");
					if ((nint)0 == 46)
					{
						break;
					}
					object obj2 = obj - 2;
					num--;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rax_v30+14+spriteName @ rcx (System.String)]");
					bool flag3 = (nint)0 >= (nint)46;
					obj = obj2;
					if (flag3)
					{
						continue;
					}
					goto IL_00d8;
				}
				strHashCode = StringHashCaseI.GetStrHashCode(spriteName, num);
				goto IL_00f3;
			}
		}
		goto IL_00d8;
		IL_00d8:
		strHashCode = StringHashCaseI.GetStrHashCode(spriteName, -1);
		goto IL_00f3;
		IL_00f3:
		if (!((Dictionary<StringHashCaseI, object>)(object)Sprites).TryGetValue((StringHashCaseI)strHashCode, out object value))
		{
			string message = "Could not find sprite : " + spriteName;
			Debug.LogWarning(message);
			autoScope.Dispose();
			return null;
		}
		autoScope.Dispose();
		return (Sprite)value;
	}

	public static bool TextureExists(string textureName)
	{
		//IL_0082: Expected I4, but got O
		if (SpriteTextureCache != null)
		{
			bool flag = ((Dictionary<object, object>)(object)SpriteTextureCache).TryGetValue((object)textureName, out object value);
			if (!flag)
			{
				return flag;
			}
			bool flag2 = (nint)value < 0;
			bool flag3 = value == null;
			bool flag4 = !flag2;
			bool flag5 = !flag3;
			return flag5 & flag4;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public static Sprite GetSprite(SpriteTextureData sprite)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 41 Invalid \"Jump target not found in method: 0x1874BEF70\"");
		Sprite result = default(Sprite);
		return result;
	}

	public static Sprite GetSprite(string spriteName, string textureName, bool ignoreExtension = true)
	{
		//IL_04d4: Expected I, but got O
		//IL_018d: Expected I4, but got I8
		//IL_01c2: Expected O, but got I4
		//IL_0373: Expected I4, but got I8
		//IL_0105: Expected O, but got I4
		//IL_03a6: Expected O, but got I4
		//IL_02eb: Expected O, but got I4
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Expected O, but got Unknown
		//IL_006a->IL00a6: Incompatible stack heights: 1 vs 2
		//IL_0262->IL0521: Incompatible stack heights: 3 vs 2
		//IL_0278->IL0196: Incompatible stack heights: 3 vs 2
		//IL_04aa->IL0521: Incompatible stack heights: 5 vs 2
		//IL_0176->IL0501: Incompatible stack heights: 3 vs 2
		//IL_017b->IL017b: Incompatible stack heights: 3 vs 2
		//IL_0446->IL0521: Incompatible stack heights: 4 vs 2
		//IL_045c->IL037c: Incompatible stack heights: 4 vs 3
		//IL_035c->IL0526: Incompatible stack heights: 4 vs 3
		//IL_0433->IL0433: Incompatible stack heights: 5 vs 4
		//IL_0361->IL0361: Incompatible stack heights: 4 vs 3
		if ((object)MarkerGetSprite2 != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)MarkerGetSprite2);
		}
		bool flag = SpriteTextureCache == null;
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		Dictionary<string, Sprite> dictionary = default(Dictionary<string, Sprite>);
		if (((Dictionary<object, object>)(object)SpriteTextureCache).TryGetValue((object)textureName, out object value))
		{
			bool flag2 = value == null;
			if (((Dictionary<object, object>)value).TryGetValue((object)spriteName, out object value2))
			{
				autoScope.Dispose();
				return (Sprite)value2;
			}
		}
		else
		{
			Dictionary<string, Sprite> value3 = new Dictionary<string, Sprite>();
			bool flag3 = ((Dictionary<object, object>)(object)SpriteTextureCache).TryInsert((object)textureName, (object)value3, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			dictionary = SpriteTextureCache.get_Item(textureName);
		}
		int strHashCode;
		if (ignoreExtension)
		{
			bool flag4 = (nint)textureName < 0;
			if (textureName != null)
			{
				int num = textureName._stringLength - 1;
				if (!flag4)
				{
					object obj = num + num;
					while (true)
					{
						bool flag5 = num >= textureName._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [textureName @ rdx (System.String)+14+v591 @ rax_v66]");
						if ((nint)0 == 46)
						{
							break;
						}
						object obj2 = obj - 2;
						num--;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [textureName @ rdx (System.String)+14+v591 @ rax_v66]");
						bool flag6 = (nint)0 >= (nint)46;
						obj = obj2;
						if (flag6)
						{
							continue;
						}
						goto IL_017b;
					}
					strHashCode = StringHashCaseI.GetStrHashCode(textureName, num);
					goto IL_0196;
				}
			}
		}
		goto IL_017b;
		IL_0361:
		int strHashCode2 = StringHashCaseI.GetStrHashCode(spriteName, -1);
		goto IL_037c;
		IL_037c:
		object value4;
		bool flag7 = value4 == null;
		if (!((Dictionary<StringHashCaseI, object>)value4).TryGetValue((StringHashCaseI)strHashCode2, out object value5))
		{
			string message = "Sprite " + spriteName + " does not exist in " + textureName;
			Debug.LogWarning(message);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v546 @ rax_v82 (System.Collections.Generic.Dictionary`2<System.String, UnityEngine.Sprite>)+20]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v546 @ rax_v82 (System.Collections.Generic.Dictionary`2<System.String, UnityEngine.Sprite>)+28]");
			if (num2 == 0)
			{
				bool flag8 = SpriteTextureCache == null;
				bool flag9 = ((Dictionary<object, object>)(object)SpriteTextureCache).Remove((object)textureName);
			}
			autoScope.Dispose();
			return null;
		}
		bool flag10 = dictionary == null;
		bool flag11 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)spriteName, value5, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		autoScope.Dispose();
		return (Sprite)value5;
		IL_017b:
		strHashCode = StringHashCaseI.GetStrHashCode(textureName, -1);
		goto IL_0196;
		IL_0196:
		bool flag12 = SpriteTextureReference == null;
		if (!((Dictionary<StringHashCaseI, object>)(object)SpriteTextureReference).TryGetValue((StringHashCaseI)strHashCode, out value4))
		{
			string message2 = "Texture " + textureName + " does not exist in the Sprite/Texture dictionary.  spriteName = " + spriteName;
			Debug.LogWarning(message2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v546 @ rax_v82 (System.Collections.Generic.Dictionary`2<System.String, UnityEngine.Sprite>)+20]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v546 @ rax_v82 (System.Collections.Generic.Dictionary`2<System.String, UnityEngine.Sprite>)+28]");
			if (num3 == 0)
			{
				bool flag13 = ((Dictionary<object, object>)(object)SpriteTextureCache).Remove((object)textureName);
			}
			autoScope.Dispose();
			return null;
		}
		if (ignoreExtension)
		{
			bool flag14 = (nint)spriteName < 0;
			if (spriteName != null)
			{
				int num4 = spriteName._stringLength - 1;
				if (!flag14)
				{
					object obj3 = num4 + num4;
					while (true)
					{
						bool flag15 = num4 >= spriteName._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [spriteName @ rcx (System.String)+14+v885 @ rax_v46]");
						if ((nint)0 == 46)
						{
							break;
						}
						object obj4 = obj3 - 2;
						num4--;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [spriteName @ rcx (System.String)+14+v885 @ rax_v46]");
						bool flag16 = (nint)0 >= (nint)46;
						obj3 = obj4;
						if (flag16)
						{
							continue;
						}
						goto IL_0361;
					}
					strHashCode2 = StringHashCaseI.GetStrHashCode(spriteName, num4);
					goto IL_037c;
				}
			}
		}
		goto IL_0361;
	}

	public static bool DoesSpriteExistInTexture(string spriteName, string textureName, bool ignoreExtension = true)
	{
		//IL_012e: Expected I4, but got I8
		//IL_032f: Expected I4, but got O
		//IL_0145: Expected O, but got I4
		//IL_00a0: Expected O, but got I4
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_0241: Expected I4, but got I8
		//IL_0253: Expected O, but got I4
		//IL_01b3: Expected O, but got I4
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Expected O, but got Unknown
		if (spriteName == null || spriteName._stringLength <= 0 || textureName == null || textureName._stringLength <= 0)
		{
			return false;
		}
		bool flag = (ignoreExtension ? 1 : 0) < (false ? 1 : 0);
		int num;
		if (ignoreExtension)
		{
			num = textureName._stringLength - 1;
			if (!flag)
			{
				object obj = num + 10;
				object obj2 = obj * 2;
				object obj3 = textureName + obj2;
				while (num < textureName._stringLength)
				{
					if ((nint)obj3 != 46)
					{
						object obj4 = obj3 - 2;
						num--;
						bool flag2 = (nint)obj3 >= 46;
						obj3 = obj4;
						if (flag2)
						{
							continue;
						}
						goto IL_0121;
					}
					goto IL_02ce;
				}
				goto IL_027e;
			}
		}
		goto IL_0121;
		IL_0321:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_032f:
		int num2;
		int strHashCode = StringHashCaseI.GetStrHashCode(spriteName, num2);
		object value;
		bool flag3;
		if (value != null)
		{
			int num3 = ((Dictionary<StringHashCaseI, object>)value).FindEntry((StringHashCaseI)strHashCode);
			int num4 = num3 >> 31;
			flag3 = (byte)(num4 ^ 1) != 0;
			goto IL_0157;
		}
		goto IL_0321;
		IL_0121:
		num = -1;
		goto IL_02ce;
		IL_027e:
		System.ThrowHelper.ThrowIndexOutOfRangeException();
		goto IL_0321;
		IL_02ce:
		int strHashCode2 = StringHashCaseI.GetStrHashCode(textureName, num);
		if (SpriteTextureReference != null)
		{
			flag3 = ((Dictionary<StringHashCaseI, object>)(object)SpriteTextureReference).TryGetValue((StringHashCaseI)strHashCode2, out value);
			if (!flag3)
			{
				goto IL_0157;
			}
			bool flag4 = (ignoreExtension ? 1 : 0) < (false ? 1 : 0);
			if (ignoreExtension)
			{
				num2 = spriteName._stringLength - 1;
				if (!flag4)
				{
					object obj5 = num2 + 10;
					object obj6 = obj5 * 2;
					object obj7 = spriteName + obj6;
					while (num2 < spriteName._stringLength)
					{
						if ((nint)obj7 != 46)
						{
							object obj8 = obj7 - 2;
							num2--;
							bool flag5 = (nint)obj7 >= 46;
							obj7 = obj8;
							if (flag5)
							{
								continue;
							}
							goto IL_0234;
						}
						goto IL_032f;
					}
					goto IL_027e;
				}
			}
			goto IL_0234;
		}
		goto IL_0321;
		IL_0157:
		return flag3;
		IL_0234:
		num2 = -1;
		goto IL_032f;
	}

	public unsafe static Sprite GetUnpackedSprite(string spriteName, Vector2 newPivot)
	{
		//IL_00ed: Expected O, but got I4
		//IL_00ed: Expected O, but got Ref
		Sprite unpackedSprite = GetUnpackedSprite(spriteName);
		if ((object)unpackedSprite != null && ((UnityEngine.Object)unpackedSprite).m_CachedPtr != (IntPtr)0)
		{
			Texture2D texture = unpackedSprite.texture;
			bool flag = ((UnityEngine.Object)unpackedSprite).m_CachedPtr == (IntPtr)0;
			Sprite.get_rect_Injected(((UnityEngine.Object)unpackedSprite).m_CachedPtr, out Rect ret);
			uint extrude = default(uint);
			SpriteMeshType meshType = default(SpriteMeshType);
			Vector4 border = default(Vector4);
			bool generateFallbackPhysicsShape = default(bool);
			return Sprite.Create(texture, (Rect)(&ret), newPivot, 100f, extrude, meshType, border, generateFallbackPhysicsShape, (SecondarySpriteTexture[])1);
		}
		return null;
	}

	public unsafe static Sprite GetSprite(string spriteName, Vector2 newPivot, string textureName, bool respectOriginalXPivot = false)
	{
		//IL_00fe: Expected O, but got I4
		//IL_01f9: Expected O, but got I4
		//IL_01f9: Expected O, but got Ref
		//IL_016d->IL01c9: Incompatible stack heights: 1 vs 0
		//IL_0202->IL01c4: Incompatible stack heights: 1 vs 0
		Sprite sprite = GetSprite(spriteName, textureName);
		bool flag2;
		if ((object)sprite != null)
		{
			bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
			flag2 = !flag;
		}
		else
		{
			flag2 = false;
		}
		object obj = respectOriginalXPivot & flag2;
		bool flag3 = obj == null;
		Vector2 pivot = newPivot;
		Rect ret;
		if (!flag3)
		{
			Vector2 pivot2 = sprite.pivot;
			bool flag4 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
			Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out ret);
			object obj2 = default(object);
			Vector2 vector = (Vector2)((object)pivot2 / obj2);
			pivot = vector;
		}
		if ((object)sprite != null && ((UnityEngine.Object)sprite).m_CachedPtr != (IntPtr)0)
		{
			Texture2D texture = sprite.texture;
			bool flag5 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
			Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out ret);
			uint extrude = default(uint);
			SpriteMeshType meshType = default(SpriteMeshType);
			Vector4 border = default(Vector4);
			bool generateFallbackPhysicsShape = default(bool);
			return Sprite.Create(texture, (Rect)(&ret), pivot, 100f, extrude, meshType, border, generateFallbackPhysicsShape, (SecondarySpriteTexture[])1);
		}
		return null;
	}

	public static Sprite GetSprite(SpriteTextureData sprite, Vector2 newPivot, bool respectOriginalXPivot = false)
	{
		return GetSprite(sprite.Sprite, newPivot, sprite.Texture, respectOriginalXPivot);
	}

	public static Texture2D GetSpriteAsTexture(string spriteName, string textureName, bool generateMipMaps = false)
	{
		//IL_016e: Expected I4, but got I8
		//IL_00b3: Expected O, but got I4
		//IL_01a2: Expected I4, but got I8
		//IL_00f7: Expected O, but got I4
		Sprite sprite = ((textureName == null || textureName._stringLength <= 0) ? GetSprite(spriteName) : GetSprite(spriteName, textureName));
		if ((object)sprite == null || ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0)
		{
			return null;
		}
		int strHashCode = StringHashCaseI.GetStrHashCode(spriteName, -1);
		if (SpritesAsTextures != null)
		{
			Texture2D texture2D;
			if (!((Dictionary<StringHashCaseI, object>)(object)SpritesAsTextures).TryGetValue((StringHashCaseI)strHashCode, out object value))
			{
				texture2D = RenderingExtensions.ConvertToTexture(sprite, generateMipMaps);
				int strHashCode2 = StringHashCaseI.GetStrHashCode(spriteName, -1);
				if (SpritesAsTextures == null)
				{
					goto IL_010f;
				}
				bool flag = ((Dictionary<StringHashCaseI, object>)(object)SpritesAsTextures).TryInsert((StringHashCaseI)strHashCode2, (object)texture2D, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			}
			else
			{
				texture2D = (Texture2D)value;
			}
			return texture2D;
		}
		goto IL_010f;
		IL_010f:
		return (Texture2D)(object)new NullReferenceException();
	}

	public unsafe static List<Sprite> GetAnimation(string animName, int startValue, int frameCount, string textureName, bool addLeadingZeros = true)
	{
		//IL_00bc: Expected I4, but got I8
		//IL_00d7: Expected O, but got I4
		//IL_0104: Expected O, but got I4
		//IL_02d0: Expected O, but got I4
		//IL_0309: Expected O, but got I4
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Expected O, but got Unknown
		List<Sprite> list = new List<Sprite>();
		string[] array = new string[5];
		int strHashCode;
		if (array != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			int num = default(int);
			string text = num.ToString();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			int num2 = default(int);
			string text2 = num2.ToString();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998A2F7]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			object obj = default(object);
			bool flag = obj == null;
			object obj2 = "False";
			if (!flag)
			{
				obj2 = "True";
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			string str = string.Concat(array);
			strHashCode = StringHashCaseI.GetStrHashCode(str, -1);
			if (Animations != null)
			{
				if (((Dictionary<StringHashCaseI, object>)(object)Animations).TryGetValue((StringHashCaseI)strHashCode, out object value))
				{
					list = (List<Sprite>)value;
					goto IL_0434;
				}
				bool flag2 = frameCount <= 0;
				object obj3 = 0;
				object obj4 = obj;
				string text3 = animName;
				if (flag2)
				{
					goto IL_0272;
				}
				int num3 = default(int);
				while (true)
				{
					bool flag3 = obj4 == null;
					string text4 = "";
					if (!flag3)
					{
						text4 = "D2";
					}
					string text5 = num3.ToString(text4);
					string text6 = text3 + text5;
					Sprite sprite;
					bool flag4;
					if (textureName != null && textureName._stringLength > 0)
					{
						sprite = GetSprite(text6, textureName);
						flag4 = true;
					}
					else
					{
						sprite = GetSprite(text6);
						flag4 = false;
					}
					if ((object)sprite != null && ((UnityEngine.Object)sprite).m_CachedPtr != (IntPtr)0)
					{
						if (list == null)
						{
							break;
						}
						bool flag5 = ((Dictionary<StringHashCaseI, List<Sprite>>)(object)list).TryGetValue((StringHashCaseI)sprite, out *(flag4 ? ((List<Sprite>*)1) : ((List<Sprite>*)null)));
					}
					else
					{
						string message = "Missing frame " + text6;
						Debug.LogWarning(message);
					}
					obj3++;
					bool flag6 = (nint)obj3 < frameCount;
					obj4 = obj;
					text3 = animName;
					if (flag6)
					{
						continue;
					}
					goto IL_0272;
				}
			}
		}
		goto IL_031f;
		IL_0434:
		return list;
		IL_031f:
		return (List<Sprite>)(object)new NullReferenceException();
		IL_0272:
		if (list != null)
		{
			if (list._size <= 0)
			{
				goto IL_0434;
			}
			if (Animations != null)
			{
				bool flag7 = ((Dictionary<StringHashCaseI, object>)(object)Animations).TryInsert((StringHashCaseI)strHashCode, (object)list, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				if (AnimationsTextureReferences != null)
				{
					bool flag8 = ((Dictionary<StringHashCaseI, object>)(object)AnimationsTextureReferences).TryInsert((StringHashCaseI)strHashCode, (object)textureName, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
					goto IL_0434;
				}
			}
		}
		goto IL_031f;
	}

	public static List<Sprite> GetAnimationFrames(SpriteAnimationData spriteAnimation, int zeroPad = 0)
	{
		//IL_004f: Expected I4, but got O
		int end = spriteAnimation.StartFrame >> 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
		int zeroPad2 = default(int);
		return GetAnimationFrames(spriteAnimation.SpriteNameStart, (int)spriteAnimation.SpriteNameStart, end, spriteAnimation.Texture, zeroPad2);
	}

	public unsafe static List<Sprite> GetAnimationFrames(string animName, int start, int end, string textureName, int zeroPad = 0)
	{
		//IL_002a: Expected I, but got O
		//IL_008f: Expected I, but got O
		//IL_00f4: Expected I, but got O
		//IL_0159: Expected I, but got O
		//IL_0201: Expected O, but got Ref
		//IL_0217: Expected I4, but got I8
		//IL_01af: Expected I, but got O
		//IL_0237: Expected O, but got I4
		//IL_027f: Expected O, but got I4
		//IL_0288: Expected O, but got I4
		//IL_03e2: Expected O, but got I4
		//IL_0402: Expected O, but got I4
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Expected O, but got Unknown
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Expected O, but got Unknown
		object[] array = new object[5];
		if (animName != null)
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj2 = default(object);
		if (obj2 != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj4 = default(object);
		if (obj4 != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj6 = default(object);
		if (obj6 != null)
		{
			nint num4 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj7 = default(object);
			if (obj7 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if (textureName != null)
		{
			nint num5 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj8 = default(object);
			if (obj8 == null)
			{
				ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
				throw ex5;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		System.ParamsArray paramsArray = new System.ParamsArray(array);
		object obj9 = default(object);
		string str = string.FormatHelper((IFormatProvider)null, "{0}{1}{2}{3}{4}", (System.ParamsArray)(&obj9));
		int strHashCode = StringHashCaseI.GetStrHashCode(str, -1);
		List<Sprite> list2;
		if (!((Dictionary<StringHashCaseI, object>)(object)Animations).TryGetValue((StringHashCaseI)strHashCode, out object value))
		{
			int zeroPad2 = default(int);
			List<string> list = GenerateFrameNames(start, end, zeroPad2, animName);
			list2 = new List<Sprite>();
			object obj10 = 0;
			object obj11 = 0;
			List<Sprite> result = default(List<Sprite>);
			while ((nint)obj11 < list._size)
			{
				if ((nint)obj10 < list._size)
				{
					string[] items = list._items;
					Sprite sprite = GetSprite(items[obj10], textureName);
					if ((object)sprite != null && ((UnityEngine.Object)sprite).m_CachedPtr != (IntPtr)0)
					{
						((UnityEngine.Object)sprite).SetName(items[obj10]);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
						obj10++;
						obj11 = obj10;
					}
					else
					{
						string message = "Missing frame " + items[obj10];
						Debug.LogWarning(message);
						obj10++;
						obj11 = obj10;
					}
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result;
			}
			if (list2._size > 0)
			{
				bool flag = ((Dictionary<StringHashCaseI, object>)(object)Animations).TryInsert((StringHashCaseI)strHashCode, (object)list2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				bool flag2 = ((Dictionary<StringHashCaseI, object>)(object)AnimationsTextureReferences).TryInsert((StringHashCaseI)strHashCode, (object)textureName, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			}
		}
		else
		{
			list2 = (List<Sprite>)value;
		}
		return list2;
	}

	public static List<Sprite> GetAnimationFrames(SpriteAnimationData spriteAnimation, Vector2 pivot, int zeroPad = 0, bool respectOriginalXPivot = false)
	{
		//IL_0058: Expected I4, but got O
		int end = spriteAnimation.StartFrame >> 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
		string textureName = default(string);
		int zeroPad2 = default(int);
		bool respectOriginalXPivot2 = default(bool);
		return GetAnimationFrames(spriteAnimation.SpriteNameStart, (int)spriteAnimation.SpriteNameStart, end, pivot, textureName, zeroPad2, respectOriginalXPivot2);
	}

	public static List<Sprite> GetAnimationFrames(string animName, int start, int end, Vector2 pivot, string textureName, int zeroPad = 0, bool respectOriginalXPivot = false)
	{
		//IL_00ba: Expected O, but got I4
		//IL_0109: Expected I4, but got I8
		//IL_0124: Expected O, but got I4
		//IL_016c: Expected O, but got I4
		//IL_0175: Expected O, but got I4
		//IL_02f6: Expected O, but got I4
		//IL_0316: Expected O, but got I4
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		string[] array = new string[7];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int num = default(int);
		string text = num.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int num2 = default(int);
		string text2 = num2.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		bool flag = default(bool);
		object obj = default(object);
		if (flag)
		{
			obj = "o";
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		}
		if (obj != null)
		{
			object obj2 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v448 @ rdx_v37+168] (should have been resolved before IL gen)");
		}
		else
		{
			object obj3 = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		float num3 = default(float);
		string text3 = num3.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int zeroPad2 = default(int);
		string text4 = zeroPad2.ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		string str = string.Concat(array);
		int strHashCode = StringHashCaseI.GetStrHashCode(str, -1);
		List<Sprite> list2;
		if (!((Dictionary<StringHashCaseI, object>)(object)Animations).TryGetValue((StringHashCaseI)strHashCode, out object value))
		{
			List<string> list = GenerateFrameNames(start, end, zeroPad2, animName);
			list2 = new List<Sprite>();
			object obj4 = 0;
			object obj5 = 0;
			string text5 = default(string);
			List<Sprite> result = default(List<Sprite>);
			while ((nint)obj4 < list._size)
			{
				if ((nint)obj5 < list._size)
				{
					string[] items = list._items;
					Sprite sprite = GetSprite(items[obj5], pivot, text5, flag);
					if ((object)sprite != null && ((UnityEngine.Object)sprite).m_CachedPtr != (IntPtr)0)
					{
						((UnityEngine.Object)sprite).SetName(items[obj5]);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
						obj5++;
						obj4 = obj5;
					}
					else
					{
						string message = "Missing frame " + items[obj5];
						Debug.LogWarning(message);
						obj5++;
						obj4 = obj5;
					}
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result;
			}
			if (list2._size > 0)
			{
				bool flag2 = ((Dictionary<StringHashCaseI, object>)(object)Animations).TryInsert((StringHashCaseI)strHashCode, (object)list2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				bool flag3 = ((Dictionary<StringHashCaseI, object>)(object)AnimationsTextureReferences).TryInsert((StringHashCaseI)strHashCode, (object)text5, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			}
		}
		else
		{
			list2 = (List<Sprite>)value;
		}
		return list2;
	}

	public static List<Sprite> GetAnimationFrames(List<string> frameNames, string textureName)
	{
		List<Sprite> list = new List<Sprite>();
		List<string>.Enumerator enumerator = default(List<string>.Enumerator);
		while (enumerator.MoveNext())
		{
			Sprite sprite = GetSprite(null, textureName);
			bool flag = list == null;
			string text = null;
			if (!flag)
			{
				int version = list._version + 1;
				list._version = version;
				text = (string)(object)list._items;
				if (list._items != null)
				{
					int size = list._size;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rcx_v5 (System.String)+18]");
					if ((nint)size >= (nint)0)
					{
						((List<object>)(object)list).AddWithResize((object)sprite);
						continue;
					}
					int size2 = list._size + 1;
					list._size = size2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					continue;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		return list;
	}

	public static List<Sprite> GetAnimationFrames(List<string> frameNames, string textureName, Vector2 pivot)
	{
		List<Sprite> list = new List<Sprite>();
		List<string>.Enumerator enumerator = default(List<string>.Enumerator);
		while (enumerator.MoveNext())
		{
			Sprite sprite = GetSprite(null, pivot, textureName);
			bool flag = list == null;
			string text = null;
			if (!flag)
			{
				int version = list._version + 1;
				list._version = version;
				text = (string)(object)list._items;
				if (list._items != null)
				{
					int size = list._size;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rcx_v5 (System.String)+18]");
					if ((nint)size >= (nint)0)
					{
						((List<object>)(object)list).AddWithResize((object)sprite);
						continue;
					}
					int size2 = list._size + 1;
					list._size = size2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					continue;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		return list;
	}

	public static List<Sprite> GetAnimationFramesFast(List<string> frameNames, string textureName, bool skipCache = false)
	{
		//IL_008b: Expected O, but got I4
		//IL_026f: Expected I, but got O
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_006f->IL0274: Incompatible stack heights: 1 vs 2
		//IL_0231->IL0231: Incompatible stack heights: 4 vs 2
		//IL_0198->IL02a0: Incompatible stack heights: 2 vs 1
		//IL_015b->IL02a0: Incompatible stack heights: 2 vs 1
		if ((object)MarkerGetAnimationFramesFast != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)MarkerGetAnimationFramesFast);
		}
		bool flag = frameNames == null;
		int hashCode = frameNames.GetHashCode();
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		if (!skipCache && ((Dictionary<int, object>)(object)FastAnimations).TryGetValue(hashCode, out object value))
		{
			autoScope.Dispose();
			return (List<Sprite>)value;
		}
		List<Sprite> list = new List<Sprite>(frameNames._size);
		object obj = 0;
		while ((nint)obj < frameNames._size)
		{
			bool flag2 = (nint)obj >= frameNames._size;
			string[] items = frameNames._items;
			Sprite sprite = GetSprite(items[obj], textureName, ignoreExtension: false);
			if ((object)sprite != null && ((UnityEngine.Object)sprite).m_CachedPtr != (IntPtr)0)
			{
				((UnityEngine.Object)sprite).SetName(items[obj]);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
				obj++;
			}
			else
			{
				string message = "Missing frame " + items[obj];
				Debug.LogWarning(message);
				obj++;
			}
		}
		bool flag3 = list == null;
		if (list._size > 0)
		{
			bool flag4 = FastAnimationsTextureReferences == null;
			bool flag5 = ((Dictionary<int, object>)(object)FastAnimationsTextureReferences).TryInsert(hashCode, (object)textureName, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			bool flag6 = FastAnimations == null;
			bool flag7 = ((Dictionary<int, object>)(object)FastAnimations).TryInsert(hashCode, (object)list, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		}
		autoScope.Dispose();
		return list;
	}

	public static List<string> GenerateFrameNames(int start, int end, int zeroPad = 0, string prefix = null)
	{
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected O, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		List<string> list = FramesNumberArray(start, end);
		List<string> list2 = new List<string>();
		bool flag = prefix != null;
		string text = prefix;
		if (!flag)
		{
			text = "";
		}
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < list._size)
			{
				if ((nint)obj >= list._size)
				{
					break;
				}
				string[] items = list._items;
				string text2 = items[obj].PadLeft(zeroPad, '0');
				string item = text + text2;
				int version = list2._version + 1;
				list2._version = version;
				string[] items2 = list2._items;
				if (list2._size >= items2.Length)
				{
					((List<object>)(object)list2).AddWithResize((object)item);
					obj++;
					obj2 = obj;
				}
				else
				{
					int size = list2._size + 1;
					list2._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					obj++;
					obj2 = obj;
				}
				continue;
			}
			return list2;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		List<string> result = default(List<string>);
		return result;
	}

	private void LoadAllSpriteSheets()
	{
		//IL_0022: Expected O, but got I4
		//IL_002b: Expected O, but got I4
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		Sprite[] rawSprites = Resources.LoadAll<Sprite>("SpriteSheets");
		_rawSprites = rawSprites;
		Sprite[] rawSprites2 = _rawSprites;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < rawSprites2.Length)
		{
			RegisterSprite(rawSprites2[obj]);
			obj++;
			obj2 = obj;
		}
	}

	public static void RegisterSprites(Sprite[] rawSprites)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < rawSprites.Length)
		{
			RegisterSprite(rawSprites[obj]);
			obj++;
			obj2 = obj;
		}
	}

	public static void RegisterSprite(Sprite s)
	{
		//IL_020d: Expected I4, but got I8
		//IL_0037: Expected O, but got I4
		//IL_0246: Expected I4, but got I8
		//IL_00b0: Expected O, but got I4
		//IL_0261: Expected I4, but got I8
		//IL_00fd: Expected O, but got I4
		//IL_02ab: Expected I4, but got I8
		//IL_0159: Expected O, but got I4
		//IL_016f: Expected I4, but got I8
		//IL_027c: Expected I4, but got I8
		//IL_0185: Expected O, but got I4
		//IL_013d: Expected O, but got I4
		//IL_02c6: Expected I4, but got I8
		//IL_01bc: Expected O, but got I4
		//IL_01d2: Expected I4, but got I8
		//IL_01f1: Expected O, but got I4
		string name = ((UnityEngine.Object)s).GetName();
		string str = name.ToLowerInvariant();
		int strHashCode = StringHashCaseI.GetStrHashCode(str, -1);
		int num = ((Dictionary<StringHashCaseI, object>)(object)Sprites).FindEntry((StringHashCaseI)strHashCode);
		if (num >= 0)
		{
			if (LogWarnings)
			{
				string name2 = ((UnityEngine.Object)s).GetName();
				string message = "Already cached a sprite with the same key: " + name2;
				Debug.LogWarning(message);
			}
		}
		else
		{
			int strHashCode2 = StringHashCaseI.GetStrHashCode(str, -1);
			bool flag = ((Dictionary<StringHashCaseI, object>)(object)Sprites).TryInsert((StringHashCaseI)strHashCode2, (object)s, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		}
		Texture2D texture = s.texture;
		string name3 = ((UnityEngine.Object)texture).GetName();
		string str2 = name3.ToLowerInvariant();
		int strHashCode3 = StringHashCaseI.GetStrHashCode(str2, -1);
		int num2 = ((Dictionary<StringHashCaseI, object>)(object)SpriteTextureReference).FindEntry((StringHashCaseI)strHashCode3);
		if (num2 < 0)
		{
			int strHashCode4 = StringHashCaseI.GetStrHashCode(str2, -1);
			Dictionary<StringHashCaseI, Sprite> value = (Dictionary<StringHashCaseI, Sprite>)(object)new Dictionary<StringHashCaseI, object>(StringHashCaseIComparer.Instance);
			bool flag2 = ((Dictionary<StringHashCaseI, object>)(object)SpriteTextureReference).TryInsert((StringHashCaseI)strHashCode4, (object)value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		}
		int strHashCode5 = StringHashCaseI.GetStrHashCode(str2, -1);
		object obj = ((Dictionary<StringHashCaseI, object>)(object)SpriteTextureReference).get_Item((StringHashCaseI)strHashCode5);
		int strHashCode6 = StringHashCaseI.GetStrHashCode(str, -1);
		int num3 = ((Dictionary<StringHashCaseI, object>)obj).FindEntry((StringHashCaseI)strHashCode6);
		if (num3 < 0)
		{
			int strHashCode7 = StringHashCaseI.GetStrHashCode(str2, -1);
			object obj2 = ((Dictionary<StringHashCaseI, object>)(object)SpriteTextureReference).get_Item((StringHashCaseI)strHashCode7);
			int strHashCode8 = StringHashCaseI.GetStrHashCode(str, -1);
			bool flag3 = ((Dictionary<StringHashCaseI, object>)obj2).TryInsert((StringHashCaseI)strHashCode8, (object)s, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		}
	}

	public static Sprite UnregisterSprite(string spriteName)
	{
		//IL_0379: Expected I4, but got I8
		//IL_0013: Expected O, but got I4
		//IL_0260: Expected I4, but got I8
		//IL_0054: Expected O, but got I4
		//IL_0340: Expected I4, but got I8
		//IL_022a: Expected O, but got I4
		//IL_02d8: Expected I4, but got I8
		//IL_0148: Expected O, but got I4
		//IL_015e: Expected I4, but got I8
		//IL_0191: Expected O, but got I4
		//IL_030c: Expected I4, but got I8
		//IL_01c5: Expected O, but got I4
		//IL_01db: Expected I4, but got I8
		//IL_020e: Expected O, but got I4
		int strHashCode = StringHashCaseI.GetStrHashCode(spriteName, -1);
		object obj;
		if (Sprites != null)
		{
			int num = ((Dictionary<StringHashCaseI, object>)(object)Sprites).FindEntry((StringHashCaseI)strHashCode);
			if (num < 0)
			{
				return null;
			}
			int strHashCode2 = StringHashCaseI.GetStrHashCode(spriteName, -1);
			if (Sprites != null)
			{
				obj = ((Dictionary<StringHashCaseI, object>)(object)Sprites).get_Item((StringHashCaseI)strHashCode2);
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rax_v14 (System.Object)+10]");
					if ((nint)0 != 0)
					{
						Texture2D texture = ((Sprite)obj).texture;
						if ((object)texture != null && ((UnityEngine.Object)texture).m_CachedPtr != (IntPtr)0)
						{
							Texture2D texture2 = ((Sprite)obj).texture;
							if ((object)texture2 != null)
							{
								string name = ((UnityEngine.Object)texture2).GetName();
								if (name != null)
								{
									string str = name.ToLowerInvariant();
									int strHashCode3 = StringHashCaseI.GetStrHashCode(str, -1);
									if (SpriteTextureReference != null)
									{
										object obj2 = ((Dictionary<StringHashCaseI, object>)(object)SpriteTextureReference).get_Item((StringHashCaseI)strHashCode3);
										int strHashCode4 = StringHashCaseI.GetStrHashCode(spriteName, -1);
										if (obj2 != null)
										{
											int num2 = ((Dictionary<StringHashCaseI, object>)obj2).FindEntry((StringHashCaseI)strHashCode4);
											if (num2 < 0)
											{
												goto IL_032e;
											}
											int strHashCode5 = StringHashCaseI.GetStrHashCode(str, -1);
											if (SpriteTextureReference != null)
											{
												object obj3 = ((Dictionary<StringHashCaseI, object>)(object)SpriteTextureReference).get_Item((StringHashCaseI)strHashCode5);
												int strHashCode6 = StringHashCaseI.GetStrHashCode(spriteName, -1);
												if (obj3 != null)
												{
													bool flag = ((Dictionary<StringHashCaseI, object>)obj3).Remove((StringHashCaseI)strHashCode6);
													goto IL_032e;
												}
											}
										}
									}
								}
							}
							goto IL_023b;
						}
					}
				}
				goto IL_032e;
			}
		}
		goto IL_023b;
		IL_032e:
		int strHashCode7 = StringHashCaseI.GetStrHashCode(spriteName, -1);
		if (Sprites != null)
		{
			bool flag2 = ((Dictionary<StringHashCaseI, object>)(object)Sprites).Remove((StringHashCaseI)strHashCode7);
			return (Sprite)obj;
		}
		goto IL_023b;
		IL_023b:
		return (Sprite)(object)new NullReferenceException();
	}

	public unsafe static void UnregisterTexture(string textureName)
	{
		//IL_08f8: Expected I4, but got I8
		//IL_0013: Expected O, but got I4
		//IL_06f4: Expected I4, but got I8
		//IL_0038: Expected O, but got I4
		//IL_018a: Expected I, but got O
		//IL_01cc: Expected O, but got Ref
		//IL_077b: Expected I4, but got I8
		//IL_009e: Expected O, but got I
		//IL_0128: Expected O, but got I4
		//IL_00c5: Expected O, but got I
		//IL_00fd: Expected O, but got I
		//IL_005a: Expected O, but got I4
		//IL_02ec: Expected O, but got I4
		//IL_0080: Expected O, but got I4
		//IL_036a: Expected O, but got I
		//IL_0665: Expected I, but got O
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Expected O, but got Unknown
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Expected Ref, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected Ref, but got Unknown
		//IL_0281: Expected I8, but got I
		//IL_0398: Expected O, but got I
		//IL_0838: Expected I, but got O
		//IL_03b7: Expected O, but got I
		//IL_05b2: Expected O, but got I
		//IL_06b0: Expected I, but got O
		//IL_05c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c5: Expected O, but got Unknown
		//IL_0499: Unknown result type (might be due to invalid IL or missing references)
		//IL_049e: Expected Ref, but got Unknown
		//IL_04a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ac: Expected Ref, but got Unknown
		//IL_04c9: Expected I8, but got I
		int strHashCode = StringHashCaseI.GetStrHashCode(textureName, -1);
		bool flag = SpriteTextureReference == null;
		int num = ((Dictionary<StringHashCaseI, object>)(object)SpriteTextureReference).FindEntry((StringHashCaseI)strHashCode);
		if (!flag)
		{
			int strHashCode2 = StringHashCaseI.GetStrHashCode(textureName, -1);
			object obj = ((Dictionary<StringHashCaseI, object>)(object)SpriteTextureReference).get_Item((StringHashCaseI)strHashCode2);
			Dictionary<StringHashCaseI, Sprite>.Enumerator enumerator = default(Dictionary<StringHashCaseI, Sprite>.Enumerator);
			while (enumerator.MoveNext())
			{
				bool flag2 = Sprites == null;
				if (!flag2)
				{
					int num2 = ((Dictionary<StringHashCaseI, object>)(object)Sprites).FindEntry((StringHashCaseI)0);
					if (!flag2)
					{
						bool flag3 = ((Dictionary<StringHashCaseI, object>)(object)Sprites).Remove((StringHashCaseI)0);
					}
					continue;
				}
				throw new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v165 (System.Object)+20]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v165 (System.Object)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v165 (System.Object)+10]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ r8_v74+18]");
				Array.Clear((Array)num3, 0, 0);
				_ = 0;
				_ = 4294967295L;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v165 (System.Object)+18]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v165 (System.Object)+20]");
				Array.Clear((Array)num4, 0, 0);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v165 (System.Object)+2C]");
			_ = (nint)0 + (nint)1;
			int strHashCode3 = StringHashCaseI.GetStrHashCode(textureName, -1);
			bool flag4 = ((Dictionary<StringHashCaseI, object>)(object)SpriteTextureReference).Remove((StringHashCaseI)strHashCode3);
		}
		bool flag5 = SpriteTextureCache == null;
		int num5 = SpriteTextureCache.FindEntry(textureName);
		if (!flag5)
		{
			bool flag6 = ((Dictionary<object, object>)(object)SpriteTextureCache).Remove((object)textureName);
		}
		List<StringHashCaseI> list = new List<StringHashCaseI>();
		nint num6 = (nint)typeof(SpriteManager);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v773 @ rax_v33 (Il2CppClass<VampireSurvivors.Graphics.SpriteManager>)+E4]");
		bool flag7 = (nint)0 != 0;
		Dictionary<StringHashCaseI, string> dictionary = AnimationsTextureReferences;
		Dictionary<StringHashCaseI, string>.Enumerator enumerator2 = default(Dictionary<StringHashCaseI, string>.Enumerator);
		object obj3 = default(object);
		while (enumerator2.MoveNext())
		{
			bool flag8 = obj3 == textureName;
			Dictionary<StringHashCaseI, string> dictionary2 = dictionary;
			Dictionary<StringHashCaseI, object> dictionary3 = (Dictionary<StringHashCaseI, object>)(&enumerator2);
			bool flag9 = flag7;
			if (!flag8)
			{
				if (obj3 == null || textureName == null)
				{
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1122 @ stack_-B8+10]");
				flag7 = (nint)0 != textureName._stringLength;
				if (flag7)
				{
					continue;
				}
				ref byte first = ref *(byte*)(obj3 + 20);
				ref byte second = ref *(byte*)(textureName + 20);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1122 @ stack_-B8+10]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1122 @ stack_-B8+10]");
				ulong length = (ulong)(num7 + 0);
				bool flag10 = System.SpanHelpers.SequenceEqual(ref first, ref second, length);
				bool flag11 = !flag10;
				dictionary2 = null;
				flag9 = flag7;
				dictionary = null;
				if (flag11)
				{
					continue;
				}
			}
			if (list != null)
			{
				list.Add((StringHashCaseI)0);
				dictionary = dictionary2;
				flag7 = flag9;
				continue;
			}
			throw new NullReferenceException();
		}
		object obj4 = default(object);
		object obj5 = default(object);
		object obj7 = default(object);
		while (true)
		{
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ stack_-100_v7+1C]");
				if (obj5 == null)
				{
					object obj6 = obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ stack_-100_v7+18]");
					if ((nint)obj6 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ stack_-100_v7+10]");
						object obj8 = 0;
						obj7++;
						Dictionary<StringHashCaseI, List<Sprite>> animations = Animations;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1166 @ rbx_v14+20+v1768 @ rcx_v52*4]");
						bool flag12 = ((Dictionary<StringHashCaseI, object>)(object)animations).Remove((StringHashCaseI)0);
						Dictionary<StringHashCaseI, string> animationsTextureReferences = AnimationsTextureReferences;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1166 @ rbx_v14+20+v1768 @ rcx_v52*4]");
						bool flag13 = ((Dictionary<StringHashCaseI, object>)(object)animationsTextureReferences).Remove((StringHashCaseI)0);
						continue;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag14 = obj4 == null;
		nint num8 = 0;
		if (!flag14)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ stack_-100_v7+1C]");
			if (obj5 == null)
			{
				List<int> list2 = null;
				bool flag15 = ((List<StringHashCaseI>.Enumerator*)list2)->MoveNext();
				nint num9 = (nint)typeof(SpriteManager);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1996 @ rax_v53 (Il2CppClass<VampireSurvivors.Graphics.SpriteManager>)+E4]");
				bool flag16 = (nint)0 != 0;
				Dictionary<int, string> dictionary4 = FastAnimationsTextureReferences;
				Dictionary<int, string>.Enumerator enumerator3 = default(Dictionary<int, string>.Enumerator);
				object obj9 = default(object);
				while (enumerator3.MoveNext())
				{
					bool flag17 = obj9 == textureName;
					Dictionary<int, string> dictionary5 = dictionary4;
					num8 = (nint)(&enumerator3);
					bool flag18 = flag16;
					if (!flag17)
					{
						if (obj9 == null || textureName == null)
						{
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2363 @ stack_-90+10]");
						flag16 = (nint)0 != textureName._stringLength;
						if (flag16)
						{
							continue;
						}
						ref byte first2 = ref *(byte*)(obj9 + 20);
						ref byte second2 = ref *(byte*)(textureName + 20);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2363 @ stack_-90+10]");
						nint num10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2363 @ stack_-90+10]");
						ulong length2 = (ulong)(num10 + 0);
						bool flag19 = System.SpanHelpers.SequenceEqual(ref first2, ref second2, length2);
						bool flag20 = !flag19;
						dictionary5 = null;
						flag18 = flag16;
						dictionary4 = null;
						if (flag20)
						{
							continue;
						}
					}
					if (list2 != null)
					{
						list2.Add(0);
						dictionary4 = dictionary5;
						flag16 = flag18;
						continue;
					}
					throw new NullReferenceException();
				}
				object obj10 = default(object);
				object obj11 = default(object);
				object obj13 = default(object);
				while (true)
				{
					if (obj10 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ stack_-E8_v5+1C]");
						if (obj11 == null)
						{
							object obj12 = obj13;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ stack_-E8_v5+18]");
							if ((nint)obj12 < 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ stack_-E8_v5+10]");
								object obj14 = 0;
								obj13++;
								Dictionary<int, List<Sprite>> fastAnimations = FastAnimations;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1820 @ rdx_v30+20+v2540 @ rcx_v35*4]");
								bool flag21 = ((Dictionary<int, object>)(object)fastAnimations).Remove(0);
								Dictionary<int, string> fastAnimationsTextureReferences = FastAnimationsTextureReferences;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1820 @ rdx_v30+20+v2540 @ rcx_v35*4]");
								bool flag22 = ((Dictionary<int, object>)(object)fastAnimationsTextureReferences).Remove(0);
								continue;
							}
							break;
						}
						break;
					}
					throw new NullReferenceException();
				}
				bool flag23 = obj10 == null;
				nint num11 = 0;
				if (!flag23)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ stack_-E8_v5+1C]");
					if (obj11 == null)
					{
						return;
					}
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
					num11 = unchecked((nint)null);
				}
				throw new NullReferenceException();
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			num8 = unchecked((nint)null);
		}
		throw new NullReferenceException();
	}

	private static string RemoveExtension(string name)
	{
		//IL_0043: Expected O, but got I4
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		bool flag = (nint)name < 0;
		int num = name._stringLength - 1;
		if (!flag)
		{
			object obj = num + 10;
			object obj2 = obj * 2;
			object obj3 = name + obj2;
			bool flag2;
			string result = default(string);
			do
			{
				if (num < name._stringLength)
				{
					if ((nint)obj3 != 46)
					{
						object obj4 = obj3 - 2;
						num--;
						flag2 = (nint)obj3 >= 46;
						obj3 = obj4;
						continue;
					}
					return name.Substring(0, num);
				}
				System.ThrowHelper.ThrowIndexOutOfRangeException();
				return result;
			}
			while (flag2);
		}
		return name;
	}

	private static bool CheckIfAnimationExists(string name)
	{
		//IL_005d: Expected I4, but got I8
		//IL_0046: Expected I4, but got O
		//IL_0013: Expected O, but got I4
		int strHashCode = StringHashCaseI.GetStrHashCode(name, -1);
		if (Animations != null)
		{
			int num = ((Dictionary<StringHashCaseI, object>)(object)Animations).FindEntry((StringHashCaseI)strHashCode);
			int num2 = num >> 31;
			return (byte)(num2 ^ 1) != 0;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private static void AddCustomPhaserMappings()
	{
		Sprite sprite = Resources.Load<Sprite>("SpriteSheets/Stars1");
		((UnityEngine.Object)sprite).SetName("hStars1");
		RegisterSprite(sprite);
		Sprite sprite2 = Resources.Load<Sprite>("SpriteSheets/Stars2");
		((UnityEngine.Object)sprite2).SetName("hStars2");
		RegisterSprite(sprite2);
	}

	private unsafe static List<string> FramesNumberArray(int start, int end, string prefix = null, string suffix = null)
	{
		//IL_01c0: Expected O, but got Ref
		//IL_008d: Expected O, but got Ref
		List<string> list = new List<string>();
		string text;
		if (prefix != null)
		{
			bool flag = prefix._stringLength > 0;
			text = prefix;
			if (flag)
			{
				goto IL_0315;
			}
		}
		text = "";
		goto IL_0315;
		IL_0332:
		bool flag2 = end < start;
		int num = start;
		int num2 = start;
		object obj = default(object);
		string text3;
		if (!flag2)
		{
			while (true)
			{
				string text2 = System.Number.FormatInt32(num, (ReadOnlySpan<char>)(&obj), null);
				string item = text + text2 + text3;
				if (list == null)
				{
					break;
				}
				int version = list._version + 1;
				list._version = version;
				string[] items = list._items;
				if (list._items == null)
				{
					break;
				}
				if (list._size >= items.Length)
				{
					((List<object>)(object)list).AddWithResize((object)item);
				}
				else
				{
					int size = list._size + 1;
					list._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				num++;
				if (num <= end)
				{
					continue;
				}
				goto IL_02db;
			}
		}
		else
		{
			while (true)
			{
				string text4 = System.Number.FormatInt32(num2, (ReadOnlySpan<char>)(&obj), null);
				string item2 = text + text4 + text3;
				if (list == null)
				{
					break;
				}
				int version2 = list._version + 1;
				list._version = version2;
				string[] items2 = list._items;
				if (list._items == null)
				{
					break;
				}
				if (list._size >= items2.Length)
				{
					((List<object>)(object)list).AddWithResize((object)item2);
				}
				else
				{
					int size2 = list._size + 1;
					list._size = size2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				num2--;
				if (num2 >= end)
				{
					continue;
				}
				goto IL_02db;
			}
		}
		return (List<string>)(object)new NullReferenceException();
		IL_02db:
		return list;
		IL_0315:
		if (suffix != null)
		{
			bool flag3 = suffix._stringLength > 0;
			text3 = suffix;
			if (flag3)
			{
				goto IL_0332;
			}
		}
		text3 = "";
		goto IL_0332;
	}

	static SpriteManager()
	{
		//IL_0114: Expected O, but got I
		//IL_013f: Expected O, but got I
		//IL_0165: Expected O, but got I
		//IL_0190: Expected O, but got I
		HighlightMissingAssetErrors = false;
		Dictionary<StringHashCaseI, Sprite> sprites = (Dictionary<StringHashCaseI, Sprite>)(object)new Dictionary<StringHashCaseI, object>(StringHashCaseIComparer.Instance);
		Sprites = sprites;
		Dictionary<StringHashCaseI, string> animationsTextureReferences = (Dictionary<StringHashCaseI, string>)(object)new Dictionary<StringHashCaseI, object>(StringHashCaseIComparer.Instance);
		AnimationsTextureReferences = animationsTextureReferences;
		Dictionary<StringHashCaseI, List<Sprite>> animations = (Dictionary<StringHashCaseI, List<Sprite>>)(object)new Dictionary<StringHashCaseI, object>(StringHashCaseIComparer.Instance);
		Animations = animations;
		Dictionary<StringHashCaseI, Texture2D> spritesAsTextures = (Dictionary<StringHashCaseI, Texture2D>)(object)new Dictionary<StringHashCaseI, object>(StringHashCaseIComparer.Instance);
		SpritesAsTextures = spritesAsTextures;
		Dictionary<StringHashCaseI, Dictionary<StringHashCaseI, Sprite>> spriteTextureReference = (Dictionary<StringHashCaseI, Dictionary<StringHashCaseI, Sprite>>)(object)new Dictionary<StringHashCaseI, object>(StringHashCaseIComparer.Instance);
		SpriteTextureReference = spriteTextureReference;
		Dictionary<int, string> fastAnimationsTextureReferences = new Dictionary<int, string>();
		FastAnimationsTextureReferences = fastAnimationsTextureReferences;
		Dictionary<int, List<Sprite>> fastAnimations = new Dictionary<int, List<Sprite>>();
		FastAnimations = fastAnimations;
		LogWarnings = false;
		Dictionary<string, Dictionary<string, Sprite>> spriteTextureCache = new Dictionary<string, Dictionary<string, Sprite>>();
		SpriteTextureCache = spriteTextureCache;
		IntPtr intPtr = ProfilerUnsafeUtility.CreateMarker("SpriteManager.GetSprite1", 1, MarkerFlags.Default, 0);
		MarkerGetSprite1 = (ProfilerMarker)(nint)intPtr;
		IntPtr intPtr2 = ProfilerUnsafeUtility.CreateMarker("SpriteManager.GetSprite2", 1, MarkerFlags.Default, 0);
		MarkerGetSprite2 = (ProfilerMarker)(nint)intPtr2;
		IntPtr intPtr3 = ProfilerUnsafeUtility.CreateMarker("SpriteManager.GetAnimationFrames", 1, MarkerFlags.Default, 0);
		_markerGetAnimationFrames = (ProfilerMarker)(nint)intPtr3;
		IntPtr intPtr4 = ProfilerUnsafeUtility.CreateMarker("SpriteManager.GetAnimationFramesFast", 1, MarkerFlags.Default, 0);
		MarkerGetAnimationFramesFast = (ProfilerMarker)(nint)intPtr4;
	}
}
