using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.Themes;

public class ThemeManager : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<ThemeData, bool> _003C_003E9__28_0;

		public static Func<ThemeVariantData, bool> _003C_003E9__28_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CActivateVariant_003Eb__28_0(ThemeData theme)
		{
			if ((object)theme != null)
			{
				return ((UnityEngine.Object)theme).m_CachedPtr == (IntPtr)0;
			}
			return true;
		}

		internal bool _003CActivateVariant_003Eb__28_1(ThemeVariantData variant)
		{
			return variant == null;
		}
	}

	private static ThemeManager s_instance;

	private static bool _003CApplicationIsQuitting_003Ek__BackingField;

	private static bool s_initialized;

	public static readonly Dictionary<Guid, List<ThemeTarget>> ThemeTargets;

	public static ThemeManager Instance
	{
		get
		{
			ThemeManager themeManager = s_instance;
			if ((object)s_instance == null || ((UnityEngine.Object)themeManager).m_CachedPtr == (IntPtr)0)
			{
				if (_003CApplicationIsQuitting_003Ek__BackingField)
				{
					return null;
				}
				ThemeManager themeManager2 = UnityEngine.Object.FindObjectOfType<ThemeManager>();
				s_instance = themeManager2;
				ThemeManager themeManager3 = s_instance;
				if ((object)s_instance == null || ((UnityEngine.Object)themeManager3).m_CachedPtr == (IntPtr)0)
				{
					ThemeManager themeManager4 = DoozyUtils.AddToScene<ThemeManager>("Theme Manager", isSingleton: true);
					if ((object)themeManager4 == null)
					{
						return (ThemeManager)(object)new NullReferenceException();
					}
					GameObject target = themeManager4.gameObject;
					UnityEngine.Object.DontDestroyOnLoad(target);
				}
			}
			return s_instance;
		}
	}

	public static bool ApplicationIsQuitting
	{
		get
		{
			return _003CApplicationIsQuitting_003Ek__BackingField;
		}
		private set
		{
			_003CApplicationIsQuitting_003Ek__BackingField = value;
		}
	}

	public static bool AutoSave
	{
		get
		{
			//IL_003e: Expected I4, but got O
			ThemesSettings instance = ThemesSettings.Instance;
			if ((object)instance != null)
			{
				return instance.AutoSave;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public static ThemesDatabase Database => ThemesSettings.Database;

	protected ThemeManager()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private static void RunOnStart()
	{
		_003CApplicationIsQuitting_003Ek__BackingField = false;
		s_initialized = false;
		ThemeTargets.Clear();
	}

	private void Awake()
	{
		//IL_0214: Expected O, but got I4
		//IL_022e: Expected O, but got I4
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		ThemeManager themeManager = s_instance;
		if ((object)s_instance != null && ((UnityEngine.Object)themeManager).m_CachedPtr != (IntPtr)0)
		{
			ThemeManager themeManager2 = s_instance;
			bool flag = (object)s_instance == null;
			bool flag2 = (object)this == null;
			object obj = flag2 & flag;
			bool flag3 = obj == null;
			object obj2 = !flag3;
			if (obj2 == null)
			{
				bool flag4;
				if ((object)this != null)
				{
					if ((object)s_instance != null)
					{
						object obj3 = (object)s_instance - (object)this;
						flag4 = obj3 == null;
					}
					else
					{
						flag4 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
					}
				}
				else
				{
					flag4 = ((UnityEngine.Object)themeManager2).m_CachedPtr == (IntPtr)0;
				}
				if (!flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
					object obj5 = default(object);
					object obj4 = obj5 + 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
					object obj6 = default(object);
					string text;
					string text2 = default(string);
					if (obj6 != null)
					{
						object obj7 = obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v643 @ rdx_v12+168] (should have been resolved before IL gen)");
						text = "There cannot be two ";
					}
					else
					{
						text = "There cannot be two ";
						text2 = null;
					}
					string message = text + text2 + "' active at the same time. Destroying this one!";
					DDebug.Log(message);
					GameObject obj8 = base.gameObject;
					UnityEngine.Object.Destroy(obj8, 0f);
					return;
				}
			}
		}
		s_instance = this;
		GameObject target = base.gameObject;
		UnityEngine.Object.DontDestroyOnLoad(target);
		s_initialized = true;
	}

	private void OnApplicationQuit()
	{
		_003CApplicationIsQuitting_003Ek__BackingField = true;
	}

	public unsafe ThemeData GetTheme(Guid themeId)
	{
		//IL_00fa: Expected O, but got Ref
		if (themeId._a == (nint)Guid.Empty)
		{
			object obj = (object)Guid.Empty >> 32;
			int num = themeId._a >> 32;
			if (num == (nint)obj)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if (themeId._a == (nint)Guid.Empty)
				{
					object obj2 = (object)Guid.Empty >> 32;
					int num2 = themeId._a >> 32;
					if (num2 == (nint)obj2)
					{
						return null;
					}
				}
			}
		}
		ThemesDatabase database = ThemesSettings.Database;
		object obj3 = default(object);
		if ((object)database != null)
		{
			return database.GetThemeData((Guid)(&obj3));
		}
		return (ThemeData)(object)new NullReferenceException();
	}

	public ThemeData GetTheme(string themeName)
	{
		if (themeName != null && themeName._stringLength > 0)
		{
			ThemesDatabase database = ThemesSettings.Database;
			if ((object)database != null)
			{
				return database.GetThemeData(themeName);
			}
			return (ThemeData)(object)new NullReferenceException();
		}
		return null;
	}

	public unsafe ThemeVariantData GetVariant(Guid variantId)
	{
		//IL_00fa: Expected O, but got Ref
		if (variantId._a == (nint)Guid.Empty)
		{
			object obj = (object)Guid.Empty >> 32;
			int num = variantId._a >> 32;
			if (num == (nint)obj)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if (variantId._a == (nint)Guid.Empty)
				{
					object obj2 = (object)Guid.Empty >> 32;
					int num2 = variantId._a >> 32;
					if (num2 == (nint)obj2)
					{
						return null;
					}
				}
			}
		}
		ThemesDatabase database = ThemesSettings.Database;
		object obj3 = default(object);
		if ((object)database != null)
		{
			return database.GetVariant((Guid)(&obj3));
		}
		return (ThemeVariantData)(object)new NullReferenceException();
	}

	public unsafe ThemeVariantData GetVariant(Guid themeId, Guid variantId)
	{
		//IL_01d3: Expected O, but got Ref
		//IL_021a: Expected O, but got Ref
		if (themeId._a == (nint)Guid.Empty)
		{
			object obj = (object)Guid.Empty >> 32;
			int num = themeId._a >> 32;
			if (num == (nint)obj)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if (themeId._a == (nint)Guid.Empty)
				{
					object obj2 = (object)Guid.Empty >> 32;
					int num2 = themeId._a >> 32;
					if (num2 == (nint)obj2)
					{
						goto IL_0223;
					}
				}
			}
		}
		if (variantId._a == (nint)Guid.Empty)
		{
			object obj3 = (object)Guid.Empty >> 32;
			int num3 = variantId._a >> 32;
			if (num3 == (nint)obj3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if (variantId._a == (nint)Guid.Empty)
				{
					object obj4 = (object)Guid.Empty >> 32;
					int num4 = variantId._a >> 32;
					if (num4 == (nint)obj4)
					{
						goto IL_0223;
					}
				}
			}
		}
		ThemesDatabase database = ThemesSettings.Database;
		if ((object)database != null)
		{
			int num5 = default(int);
			ThemeData themeData = database.GetThemeData((Guid)(&num5));
			if ((object)themeData != null && ((UnityEngine.Object)themeData).m_CachedPtr != (IntPtr)0)
			{
				return themeData.GetVariant((Guid)(&num5));
			}
			goto IL_0223;
		}
		return (ThemeVariantData)(object)new NullReferenceException();
		IL_0223:
		return null;
	}

	public unsafe ThemeVariantData GetVariant(Guid themeId, string variantName)
	{
		//IL_0137: Expected O, but got Ref
		if (themeId._a == (nint)Guid.Empty)
		{
			object obj = (object)Guid.Empty >> 32;
			int num = themeId._a >> 32;
			if (num == (nint)obj)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if (themeId._a == (nint)Guid.Empty)
				{
					object obj2 = (object)Guid.Empty >> 32;
					int num2 = themeId._a >> 32;
					if (num2 == (nint)obj2)
					{
						goto IL_0187;
					}
				}
			}
		}
		if (variantName != null && variantName._stringLength > 0)
		{
			ThemesDatabase database = ThemesSettings.Database;
			if ((object)database == null)
			{
				return (ThemeVariantData)(object)new NullReferenceException();
			}
			object obj3 = default(object);
			ThemeData themeData = database.GetThemeData((Guid)(&obj3));
			if ((object)themeData != null && ((UnityEngine.Object)themeData).m_CachedPtr != (IntPtr)0)
			{
				return themeData.GetVariant(variantName);
			}
		}
		goto IL_0187;
		IL_0187:
		return null;
	}

	public unsafe ThemeVariantData GetVariant(string themeName, Guid variantId)
	{
		//IL_0186: Expected O, but got Ref
		if (themeName != null && themeName._stringLength > 0)
		{
			if (variantId._a == (nint)Guid.Empty)
			{
				object obj = (object)Guid.Empty >> 32;
				int num = variantId._a >> 32;
				if (num == (nint)obj)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
					if (variantId._a == (nint)Guid.Empty)
					{
						object obj2 = (object)Guid.Empty >> 32;
						int num2 = variantId._a >> 32;
						if (num2 == (nint)obj2)
						{
							goto IL_018f;
						}
					}
				}
			}
			ThemesDatabase database = ThemesSettings.Database;
			if ((object)database == null)
			{
				return (ThemeVariantData)(object)new NullReferenceException();
			}
			ThemeData themeData = database.GetThemeData(themeName);
			object obj3 = default(object);
			if ((object)themeData != null && ((UnityEngine.Object)themeData).m_CachedPtr != (IntPtr)0)
			{
				return themeData.GetVariant((Guid)(&obj3));
			}
		}
		goto IL_018f;
		IL_018f:
		return null;
	}

	public ThemeVariantData GetVariant(string themeName, string variantName)
	{
		if (themeName != null && themeName._stringLength > 0 && variantName != null && variantName._stringLength > 0)
		{
			ThemesDatabase database = ThemesSettings.Database;
			if ((object)database == null)
			{
				return (ThemeVariantData)(object)new NullReferenceException();
			}
			ThemeData themeData = database.GetThemeData(themeName);
			if ((object)themeData != null && ((UnityEngine.Object)themeData).m_CachedPtr != (IntPtr)0)
			{
				return themeData.GetVariant(variantName);
			}
		}
		return null;
	}

	public unsafe static void ActivateVariant(Guid themeId, Guid variantId)
	{
		//IL_002f: Expected O, but got Ref
		//IL_0076: Expected O, but got Ref
		if (!s_initialized)
		{
			Init();
		}
		ThemeManager instance = Instance;
		int num = default(int);
		ThemeData theme = instance.GetTheme((Guid)(&num));
		if ((object)theme != null && ((UnityEngine.Object)theme).m_CachedPtr != (IntPtr)0)
		{
			theme.ActivateVariant((Guid)(&num));
			UpdateTargets(theme);
			ThemesSettings instance2 = ThemesSettings.Instance;
			if (instance2.AutoSave)
			{
				SaveActiveVariant(theme);
				PlayerPrefs.Save();
			}
		}
	}

	public unsafe static void ActivateVariant(Guid themeId, string variantName)
	{
		//IL_002f: Expected O, but got Ref
		if (!s_initialized)
		{
			Init();
		}
		ThemeManager instance = Instance;
		object obj = default(object);
		ThemeData theme = instance.GetTheme((Guid)(&obj));
		if ((object)theme != null && ((UnityEngine.Object)theme).m_CachedPtr != (IntPtr)0)
		{
			theme.ActivateVariant(variantName);
			UpdateTargets(theme);
			ThemesSettings instance2 = ThemesSettings.Instance;
			if (instance2.AutoSave)
			{
				SaveActiveVariant(theme);
				PlayerPrefs.Save();
			}
		}
	}

	public unsafe static void ActivateVariant(string themeName, Guid variantId)
	{
		//IL_00c5: Expected O, but got Ref
		if (!s_initialized)
		{
			Init();
		}
		ThemeManager instance = Instance;
		ThemeData themeData2;
		if (themeName != null && themeName._stringLength > 0)
		{
			ThemesDatabase database = ThemesSettings.Database;
			ThemeData themeData = database.GetThemeData(themeName);
			themeData2 = themeData;
		}
		else
		{
			themeData2 = null;
		}
		if ((object)themeData2 != null && ((UnityEngine.Object)themeData2).m_CachedPtr != (IntPtr)0)
		{
			object obj = default(object);
			themeData2.ActivateVariant((Guid)(&obj));
			UpdateTargets(themeData2);
			ThemesSettings instance2 = ThemesSettings.Instance;
			if (instance2.AutoSave)
			{
				SaveActiveVariant(themeData2);
				PlayerPrefs.Save();
			}
		}
	}

	public static void ActivateVariant(string themeName, string variantName)
	{
		if (!s_initialized)
		{
			Init();
		}
		ThemeManager instance = Instance;
		ThemeData themeData2;
		if (themeName != null && themeName._stringLength > 0)
		{
			ThemesDatabase database = ThemesSettings.Database;
			ThemeData themeData = database.GetThemeData(themeName);
			themeData2 = themeData;
		}
		else
		{
			themeData2 = null;
		}
		if ((object)themeData2 != null && ((UnityEngine.Object)themeData2).m_CachedPtr != (IntPtr)0)
		{
			themeData2.ActivateVariant(variantName);
			UpdateTargets(themeData2);
			ThemesSettings instance2 = ThemesSettings.Instance;
			if (instance2.AutoSave)
			{
				SaveActiveVariant(themeData2);
				PlayerPrefs.Save();
			}
		}
	}

	public unsafe static void ActivateVariant(Guid variantId)
	{
		//IL_009b: Expected O, but got Ref
		//IL_05e1: Expected I, but got O
		//IL_00f6: Expected I, but got O
		//IL_0189: Expected O, but got I4
		//IL_012e: Expected O, but got I
		//IL_0137: Expected O, but got I4
		//IL_044f: Expected O, but got I
		//IL_0458: Unknown result type (might be due to invalid IL or missing references)
		//IL_045d: Expected O, but got Unknown
		//IL_0465: Unknown result type (might be due to invalid IL or missing references)
		//IL_046a: Expected O, but got Unknown
		//IL_064f: Expected I, but got O
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected O, but got Unknown
		//IL_01ea: Expected O, but got Ref
		//IL_0688: Expected I, but got O
		if (!s_initialized)
		{
			Init();
		}
		ThemesDatabase database = ThemesSettings.Database;
		bool flag = (object)database == null;
		IEnumerable<ThemeData> enumerable = null;
		if (!flag)
		{
			Func<ThemeData, bool> predicate = _003C_003Ec._003C_003E9__28_0;
			if (_003C_003Ec._003C_003E9__28_0 == null)
			{
				Func<ThemeData, bool> func = (_003C_003Ec._003C_003E9__28_0 = (ThemeData theme) => (object)theme == null || ((UnityEngine.Object)theme).m_CachedPtr == (IntPtr)0);
				nint num = unchecked((nint)null);
				predicate = func;
			}
			IEnumerable<ThemeData> enumerable2 = Enumerable.Where(database.Themes, predicate);
			bool flag2 = enumerable2 == null;
			enumerable = database.Themes;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				IEnumerable<ThemeData> enumerable3 = default(IEnumerable<ThemeData>);
				object obj = (object)(&enumerable3);
				ThemeData themeData = null;
				object obj2 = default(object);
				object obj11 = default(object);
				ThemeData themeData2 = default(ThemeData);
				object obj13 = default(object);
				object obj14 = default(object);
				ThemeVariantData themeVariantData = default(ThemeVariantData);
				while (true)
				{
					bool flag3 = enumerable3 == null;
					enumerable = (IEnumerable<ThemeData>)themeData;
					object obj10;
					object obj3;
					if (!flag3)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						if (obj2 == null)
						{
							break;
						}
						bool flag4 = enumerable3 == null;
						enumerable = null;
						if (!flag4)
						{
							nint num2 = (nint)enumerable3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ r10_v13 (Il2CppClass<System.Collections.Generic.IEnumerable`1<Doozy.Engine.Themes.ThemeData>>)+12E]");
							if ((nint)0 >= (nint)0)
							{
								goto IL_016e;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ r10_v13 (Il2CppClass<System.Collections.Generic.IEnumerable`1<Doozy.Engine.Themes.ThemeData>>)+B0]");
							obj3 = 0;
							object obj4 = 0;
							while (true)
							{
								object obj5 = obj4 + obj4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v742 @ r8_v18+v875 @ rax_v89*8]");
								if (0 == (nint)typeof(IEnumerator<ThemeData>))
								{
									break;
								}
								obj4++;
								object obj6 = obj4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ r10_v13 (Il2CppClass<System.Collections.Generic.IEnumerable`1<Doozy.Engine.Themes.ThemeData>>)+12E]");
								if ((nint)obj6 < 0)
								{
									continue;
								}
								goto IL_016e;
							}
							object obj7 = obj4 + obj4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v742 @ r8_v18+8+v947 @ rcx_v68*8]");
							object obj8 = (nint)0 << 4;
							object obj9 = obj8 + 312;
							obj10 = obj9 + num2;
							goto IL_06c0;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
					IL_016e:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
					obj10 = obj11;
					obj3 = 0;
					goto IL_06c0;
					IL_06c0:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v952 @ rdx_v20] (should have been resolved before IL gen)");
					bool flag5 = (object)themeData2 == null;
					enumerable = enumerable3;
					if (flag5)
					{
						throw new NullReferenceException();
					}
					Func<ThemeVariantData, bool> predicate2 = _003C_003Ec._003C_003E9__28_1;
					bool flag6 = _003C_003Ec._003C_003E9__28_1 != null;
					nint num = (nint)typeof(IEnumerator<ThemeData>);
					if (!flag6)
					{
						predicate2 = (_003C_003Ec._003C_003E9__28_1 = (ThemeVariantData variant) => variant == null);
						num = unchecked((nint)null);
					}
					IEnumerable<ThemeVariantData> enumerable4 = Enumerable.Where(themeData2.Variants, predicate2);
					bool flag7 = enumerable4 == null;
					enumerable = (IEnumerable<ThemeData>)themeData2.Variants;
					if (!flag7)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						object obj12 = (object)(&obj13);
						enumerable = null;
						while (true)
						{
							if (obj13 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
								if (obj14 != null)
								{
									bool flag8 = obj13 == null;
									enumerable = null;
									if (!flag8)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D3B0");
										bool flag9 = themeVariantData == null;
										enumerable = null;
										if (!flag9)
										{
											bool flag10 = variantId._a != (nint)themeVariantData.m_id;
											enumerable = (IEnumerable<ThemeData>)themeVariantData.m_id;
											if (flag10)
											{
												continue;
											}
											int num3 = variantId._a >> 32;
											enumerable = (IEnumerable<ThemeData>)((object)themeVariantData.m_id >> 32);
											if (num3 != (nint)enumerable)
											{
												continue;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
											Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
											bool flag11 = variantId._a != (nint)themeVariantData.m_id;
											enumerable = (IEnumerable<ThemeData>)themeVariantData.m_id;
											if (flag11)
											{
												continue;
											}
											enumerable = (IEnumerable<ThemeData>)((object)themeVariantData.m_id >> 32);
											int num4 = variantId._a >> 32;
											if (num4 != (nint)enumerable)
											{
												continue;
											}
											themeData2.ActivateVariant(themeVariantData);
											ThemesSettings instance = ThemesSettings.Instance;
											bool flag12 = (object)instance == null;
											enumerable = null;
											if (!flag12)
											{
												if (instance.AutoSave)
												{
													SaveActiveVariant(themeData2);
												}
												UpdateTargets(themeData2);
												bool flag13 = obj12 == null;
												themeData = themeData2;
												if (!flag13)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
													themeData = null;
												}
												break;
											}
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								bool flag14 = obj12 == null;
								themeData = null;
								if (!flag14)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
									themeData = null;
								}
								break;
							}
							throw new NullReferenceException();
						}
						continue;
					}
					throw new NullReferenceException();
				}
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				ThemesSettings instance2 = ThemesSettings.Instance;
				bool flag15 = (object)instance2 == null;
				enumerable = null;
				if (!flag15)
				{
					if (instance2.AutoSave)
					{
						PlayerPrefs.Save();
					}
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public static void Init()
	{
		//IL_00aa: Expected O, but got I4
		//IL_0100: Expected O, but got I4
		//IL_012b: Expected O, but got I4
		if (s_initialized)
		{
			return;
		}
		ThemeManager themeManager = s_instance;
		if ((object)s_instance != null && ((UnityEngine.Object)themeManager).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		ThemeManager instance = Instance;
		s_instance = instance;
		ThemesSettings instance2 = ThemesSettings.Instance;
		bool flag = (object)instance2 == null;
		object obj = 0;
		if (!flag)
		{
			if (!instance2.AutoSave)
			{
				goto IL_01b9;
			}
			ThemesDatabase database = ThemesSettings.Database;
			bool flag2 = (object)database == null;
			obj = 0;
			if (!flag2)
			{
				bool flag3 = database.Themes == null;
				obj = 0;
				if (!flag3)
				{
					List<ThemeData>.Enumerator enumerator = default(List<ThemeData>.Enumerator);
					while (enumerator.MoveNext())
					{
						LoadActiveVariant(null);
					}
					goto IL_01b9;
				}
			}
		}
		throw new NullReferenceException();
		IL_01b9:
		s_initialized = true;
	}

	public unsafe static void LoadActiveVariant(ThemeData theme)
	{
		//IL_0175: Expected O, but got Ref
		if ((object)theme == null || ((UnityEngine.Object)theme).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998A4E4]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Guid guid = default(Guid);
		string key = guid.ToString("D", null);
		if (!PlayerPrefs.HasKey(key))
		{
			SaveActiveVariant(theme);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998A4E4]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string key2 = guid.ToString("D", null);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999017]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string g = PlayerPrefs.GetString(key2, "");
		Guid guid2 = new Guid(g);
		theme.ActivateVariant((Guid)(&guid2));
	}

	public unsafe static void RegisterTarget(ThemeTarget target)
	{
		//IL_0168: Expected O, but got Ref
		//IL_0198: Expected O, but got Ref
		//IL_01c1: Expected O, but got I
		//IL_01eb: Expected O, but got Ref
		//IL_030c: Expected O, but got Ref
		if (!s_initialized)
		{
			Init();
		}
		if ((object)target == null || ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		if ((object)target.ThemeId == (object)Guid.Empty)
		{
			object obj = (object)Guid.Empty >> 32;
			object obj2 = (object)target.ThemeId >> 32;
			if (obj2 == obj)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)target.ThemeId == (object)Guid.Empty)
				{
					object obj3 = (object)Guid.Empty >> 32;
					object obj4 = (object)target.ThemeId >> 32;
					if (obj4 == obj3)
					{
						return;
					}
				}
			}
		}
		ThemesDatabase database = ThemesSettings.Database;
		Guid themeId = default(Guid);
		if (!database.Contains((Guid)(&themeId)))
		{
			return;
		}
		int num = ((Dictionary<Guid, object>)(object)ThemeTargets).FindEntry((Guid)(&themeId));
		bool flag = num >= 0;
		themeId = target.ThemeId;
		object obj5 = 0;
		if (!flag)
		{
			List<ThemeTarget> list = new List<ThemeTarget>();
			bool flag2 = ((Dictionary<Guid, object>)(object)ThemeTargets).TryInsert((Guid)(&themeId), (object)list, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			themeId = target.ThemeId;
			obj5 = list;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049C0B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049C160");
		object obj6 = default(object);
		if (obj6 == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049C0B0");
			List<object> list2 = default(List<object>);
			int version = list2._version + 1;
			list2._version = version;
			object[] items = list2._items;
			if (list2._size >= items.Length)
			{
				list2.AddWithResize((object)target);
			}
			else
			{
				int size = list2._size + 1;
				list2._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			ThemesDatabase database2 = ThemesSettings.Database;
			ThemeData themeData = database2.GetThemeData((Guid)(&themeId));
			target.UpdateTarget(themeData);
		}
	}

	public static void SaveActiveVariant(ThemeData theme)
	{
		if ((object)theme == null || ((UnityEngine.Object)theme).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		ThemeVariantData activeVariant = theme.ActiveVariant;
		if (activeVariant != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998A4E4]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Guid guid = default(Guid);
			string key = guid.ToString("D", null);
			ThemeVariantData activeVariant2 = theme.ActiveVariant;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998A4E4]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			string value = guid.ToString("D", null);
			PlayerPrefs.SetString(key, value);
		}
	}

	public unsafe static void UnregisterTarget(ThemeTarget target)
	{
		//IL_0168: Expected O, but got Ref
		//IL_0199: Expected O, but got Ref
		//IL_01ce: Expected O, but got Ref
		//IL_01e4: Expected O, but got I4
		//IL_0218: Expected O, but got Ref
		//IL_021c: Expected O, but got I4
		if (!s_initialized)
		{
			Init();
		}
		if ((object)target == null || ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		if ((object)target.ThemeId == (object)Guid.Empty)
		{
			object obj = (object)Guid.Empty >> 32;
			object obj2 = (object)target.ThemeId >> 32;
			if (obj2 == obj)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)target.ThemeId == (object)Guid.Empty)
				{
					object obj3 = (object)Guid.Empty >> 32;
					object obj4 = (object)target.ThemeId >> 32;
					if (obj4 == obj3)
					{
						return;
					}
				}
			}
		}
		ThemesDatabase database = ThemesSettings.Database;
		Guid guid = default(Guid);
		if (!database.Contains((Guid)(&guid)))
		{
			return;
		}
		int num = ((Dictionary<Guid, object>)(object)ThemeTargets).FindEntry((Guid)(&guid));
		if (num >= 0)
		{
			int num2 = ThemeTargets.FindEntry((Guid)(&guid));
			if (((Dictionary<Guid, List<ThemeTarget>>)num2).FindEntry((Guid)target) != 0)
			{
				List<object> list = (List<object>)ThemeTargets.FindEntry((Guid)(&guid));
				bool flag = list.Remove(target);
			}
		}
	}

	public unsafe static void UpdateTargets()
	{
		//IL_0035: Expected O, but got I4
		//IL_01fe: Expected O, but got I4
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_0119: Expected O, but got Ref
		//IL_01ae: Expected O, but got I4
		//IL_0178: Expected O, but got I4
		//IL_0181: Expected O, but got I4
		if (!s_initialized)
		{
			Init();
		}
		Dictionary<Guid, List<ThemeTarget>>.KeyCollection keys = ThemeTargets.Keys;
		object obj = 0;
		object obj2 = default(object);
		object obj3 = default(object);
		object obj5 = default(object);
		List<ThemeTarget>.Enumerator enumerator = default(List<ThemeTarget>.Enumerator);
		List<ThemeTarget>.Enumerator enumerator2 = default(List<ThemeTarget>.Enumerator);
		while (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ stack_-88_v4+2C]");
			if (obj3 == null)
			{
				object obj4 = obj5;
				object obj7;
				bool flag;
				do
				{
					object obj6 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ stack_-88_v4+20]");
					if ((nint)obj6 < 0)
					{
						obj7 = obj4 + 1;
						object obj8 = obj4 << 5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ stack_-88_v4+18]");
						object obj9 = obj8 + 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v620 @ r8_v15+20]");
						flag = (nint)0 < (nint)0;
						obj4 = obj7;
						continue;
					}
					return;
				}
				while (flag);
				ThemesDatabase database = ThemesSettings.Database;
				ThemeData themeData = database.GetThemeData((Guid)(&enumerator));
				bool flag2 = (object)themeData == null;
				obj5 = obj7;
				if (flag2)
				{
					continue;
				}
				bool flag3 = ((UnityEngine.Object)themeData).m_CachedPtr == (IntPtr)0;
				obj5 = obj7;
				if (!flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049C0B0");
					if (enumerator2.MoveNext())
					{
						object obj10 = 0;
						object obj11 = 0;
						throw new NullReferenceException();
					}
					obj5 = obj7;
					obj = 0;
				}
				continue;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			object obj12 = 0;
			break;
		}
		throw new NullReferenceException();
	}

	public static void UpdateTargets(ThemeData themeData)
	{
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_0157: Expected O, but got I
		//IL_01a1: Expected O, but got I
		//IL_0259: Expected O, but got I
		//IL_029d: Expected O, but got I4
		//IL_02a6: Expected O, but got I4
		if (!s_initialized)
		{
			Init();
		}
		if ((object)themeData == null || ((UnityEngine.Object)themeData).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Dictionary<Guid, List<ThemeTarget>> themeTargets = ThemeTargets;
		Dictionary<Guid, List<ThemeTarget>>.KeyCollection keys = ThemeTargets.Keys;
		object obj2 = default(object);
		object obj = obj2;
		object obj3 = default(object);
		object obj4 = default(object);
		List<ThemeTarget>.Enumerator enumerator = default(List<ThemeTarget>.Enumerator);
		while (obj3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ stack_-88_v5+2C]");
			if (obj4 == null)
			{
				object obj6;
				bool flag;
				do
				{
					object obj5 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ stack_-88_v5+20]");
					if ((nint)obj5 < 0)
					{
						obj6 = obj + 1;
						object obj7 = obj << 5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ stack_-88_v5+18]");
						object obj8 = obj7 + 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v608 @ r9_v14+20]");
						flag = (nint)0 < (nint)0;
						obj = obj6;
						continue;
					}
					return;
				}
				while (flag);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v608 @ r9_v14+28]");
				themeTargets = (Dictionary<Guid, List<ThemeTarget>>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v608 @ r9_v14+28]");
				bool flag2 = 0 != (nint)themeData.m_id;
				obj = obj6;
				if (flag2)
				{
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v608 @ r9_v14+28]");
				themeTargets = (Dictionary<Guid, List<ThemeTarget>>)((nint)0 >> 32);
				object obj9 = (object)themeData.m_id >> 32;
				bool flag3 = themeTargets != obj9;
				obj = obj6;
				if (flag3)
				{
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v608 @ r9_v14+28]");
				bool flag4 = 0 != (nint)themeData.m_id;
				obj = obj6;
				themeTargets = (Dictionary<Guid, List<ThemeTarget>>)themeData.m_id;
				if (flag4)
				{
					continue;
				}
				themeTargets = (Dictionary<Guid, List<ThemeTarget>>)((object)themeData.m_id >> 32);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v608 @ r9_v14+28]");
				object obj10 = (nint)0 >> 32;
				bool flag5 = obj10 != themeTargets;
				obj = obj6;
				if (!flag5)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049C0B0");
					if (enumerator.MoveNext())
					{
						object obj11 = 0;
						object obj12 = 0;
						throw new NullReferenceException();
					}
					return;
				}
				continue;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			themeTargets = null;
			break;
		}
		throw new NullReferenceException();
	}

	public unsafe static void UpdateTargets(Guid themeId)
	{
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected O, but got Unknown
		//IL_01aa: Expected O, but got I
		//IL_01f4: Expected O, but got I
		//IL_0207: Expected O, but got I4
		//IL_0275: Expected O, but got I4
		//IL_0296: Expected O, but got I4
		//IL_02ac: Expected O, but got I
		//IL_02f4: Expected O, but got Ref
		//IL_034b: Expected O, but got I4
		//IL_0354: Expected O, but got I4
		if (!s_initialized)
		{
			Init();
		}
		if (themeId._a == (nint)Guid.Empty)
		{
			int num = themeId._a >> 32;
			object obj = (object)Guid.Empty >> 32;
			if (num == (nint)obj)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if (themeId._a == (nint)Guid.Empty)
				{
					object obj2 = (object)Guid.Empty >> 32;
					int num2 = themeId._a >> 32;
					if (num2 == (nint)obj2)
					{
						return;
					}
				}
			}
		}
		Dictionary<Guid, List<ThemeTarget>> themeTargets = ThemeTargets;
		Dictionary<Guid, List<ThemeTarget>>.KeyCollection keys = ThemeTargets.Keys;
		object obj4 = default(object);
		object obj3 = obj4;
		object obj5 = default(object);
		object obj6 = default(object);
		int num3 = default(int);
		List<ThemeTarget>.Enumerator enumerator = default(List<ThemeTarget>.Enumerator);
		while (obj5 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ stack_-78_v5+2C]");
			if (obj6 == null)
			{
				object obj8;
				bool flag;
				do
				{
					object obj7 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ stack_-78_v5+20]");
					if ((nint)obj7 < 0)
					{
						obj8 = obj3 + 1;
						object obj9 = obj3 << 5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ stack_-78_v5+18]");
						object obj10 = obj9 + 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ r9_v16+20]");
						flag = (nint)0 < (nint)0;
						obj3 = obj8;
						continue;
					}
					return;
				}
				while (flag);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ r9_v16+28]");
				themeTargets = (Dictionary<Guid, List<ThemeTarget>>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ r9_v16+28]");
				bool flag2 = (nint)0 != themeId._a;
				obj3 = obj8;
				if (flag2)
				{
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ r9_v16+28]");
				themeTargets = (Dictionary<Guid, List<ThemeTarget>>)((nint)0 >> 32);
				object obj11 = themeId._a >> 32;
				bool flag3 = themeTargets != obj11;
				obj3 = obj8;
				if (flag3)
				{
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ r9_v16+28]");
				bool flag4 = (nint)0 != themeId._a;
				obj3 = obj8;
				themeTargets = (Dictionary<Guid, List<ThemeTarget>>)themeId._a;
				if (flag4)
				{
					continue;
				}
				themeTargets = (Dictionary<Guid, List<ThemeTarget>>)(themeId._a >> 32);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ r9_v16+28]");
				object obj12 = (nint)0 >> 32;
				bool flag5 = obj12 != themeTargets;
				obj3 = obj8;
				if (flag5)
				{
					continue;
				}
				ThemesDatabase database = ThemesSettings.Database;
				ThemeData themeData = database.GetThemeData((Guid)(&num3));
				if ((object)themeData != null && ((UnityEngine.Object)themeData).m_CachedPtr != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049C0B0");
					if (enumerator.MoveNext())
					{
						object obj13 = 0;
						object obj14 = 0;
						throw new NullReferenceException();
					}
				}
				return;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			themeTargets = null;
			break;
		}
		throw new NullReferenceException();
	}

	private static ThemeManager AddToScene(bool selectGameObjectAfterCreation = false)
	{
		return DoozyUtils.AddToScene<ThemeManager>("Theme Manager", isSingleton: true, selectGameObjectAfterCreation);
	}

	static ThemeManager()
	{
		Dictionary<Guid, List<ThemeTarget>> themeTargets = (Dictionary<Guid, List<ThemeTarget>>)(object)new Dictionary<Guid, object>();
		ThemeTargets = themeTargets;
	}
}
