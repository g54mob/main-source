using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts._Data.Hats;
using Cpp2ILInjected;

namespace Assets.Scripts.Saves___Serialization.SaveFiles.Configs;

public class Preferences
{
	public Dictionary<ECharacter, int> characterSkins;

	public Dictionary<ECharacter, EHat> characterHats;

	public ECharacter selectedCharacter;

	public bool hasShownUnlocks;

	public bool hasShownQuests;

	public bool hasShownShop;

	public bool hasShownLeaderboards;

	public bool hasShownQuickQuests;

	public bool hasShownWarningForChestSkip;

	public unsafe void Init()
	{
		//IL_0044: Expected O, but got Ref
		//IL_004c: Expected O, but got Ref
		//IL_0693: Expected I, but got O
		//IL_0069: Expected I4, but got O
		//IL_029d: Expected I4, but got O
		//IL_02a9: Expected O, but got I4
		//IL_009d: Expected I, but got O
		//IL_00b8: Expected I, but got O
		//IL_0143: Expected I4, but got O
		//IL_0315: Expected O, but got Ref
		//IL_031d: Expected O, but got Ref
		//IL_00f9: Expected O, but got I4
		//IL_0195: Expected I, but got O
		//IL_019d: Expected I, but got O
		//IL_01cc: Expected I, but got O
		//IL_0332: Expected I, but got O
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_03bd: Expected O, but got I4
		//IL_020b: Expected I, but got O
		//IL_036a: Expected O, but got I
		//IL_0373: Expected O, but got I4
		//IL_0232: Expected I4, but got O
		//IL_0244: Expected I, but got O
		//IL_0381: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Expected O, but got Unknown
		//IL_0270: Expected I4, but got O
		//IL_0452: Expected I, but got O
		//IL_045a: Expected I, but got O
		//IL_0489: Expected I, but got O
		//IL_04c8: Expected I, but got O
		//IL_04ef: Expected I4, but got O
		//IL_054e: Expected I4, but got O
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(ECharacter));
		Array values = Enum.GetValues(typeFromHandle);
		IEnumerator enumerator = values.GetEnumerator();
		IEnumerator enumerator2 = default(IEnumerator);
		object obj = (object)(&enumerator2);
		object obj3 = default(object);
		object obj2 = (object)(&obj3);
		Array array = values;
		object obj9 = default(object);
		while (true)
		{
			bool flag = enumerator2 == null;
			nint num = (nint)enumerator2;
			if (!flag)
			{
				if (((Dictionary<ECharacter, EHat>)null).ContainsKey((ECharacter)typeof(IEnumerator)))
				{
					bool flag2 = enumerator2 == null;
					num = (nint)enumerator2;
					array = null;
					if (!flag2)
					{
						nint num2 = (nint)enumerator2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ r10_v14 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
						if ((nint)0 >= (nint)0)
						{
							goto IL_0130;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ r10_v14 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
						num = 0;
						object obj4 = 0;
						while (true)
						{
							object obj5 = obj4 + obj4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ r8_v8 (Il2CppMethodInfo)+v486 @ rax_v86*8]");
							if (0 != (nint)typeof(IEnumerator))
							{
								obj4++;
								object obj6 = obj4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ r10_v14 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
								if ((nint)obj6 < 0)
								{
									continue;
								}
								goto IL_0130;
							}
							break;
						}
						goto IL_0155;
					}
					throw new NullReferenceException();
				}
				bool flag3 = ((Dictionary<ECharacter, EHat>)obj).ContainsKey((ECharacter)typeof(IDisposable));
				obj2 = flag3;
				if (flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
				}
				Type typeFromHandle2 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(ECharacter));
				Array values2 = Enum.GetValues(typeFromHandle2);
				IEnumerator enumerator3 = values2.GetEnumerator();
				object obj7 = (object)(&enumerator2);
				object obj8 = (object)(&obj3);
				Dictionary<System.Int32Enum, System.Int32Enum> dictionary = (Dictionary<System.Int32Enum, System.Int32Enum>)(object)values2;
				break;
			}
			throw new NullReferenceException();
			IL_0155:
			object current = enumerator2.Current;
			bool flag4 = current == null;
			array = (Array)enumerator2;
			if (!flag4)
			{
				nint num3 = (nint)typeof(ECharacter);
				nint num4 = (nint)current;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v674 @ rdx_v41 (Il2CppClass<System.Object>)+40]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v673 @ r8_v30 (Il2CppClass<ECharacter>)+40]");
				bool flag5 = num5 != 0;
				nint num6 = (nint)typeof(ECharacter);
				array = (Array)current;
				if (!flag5)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
					bool flag6 = characterSkins == null;
					num6 = (nint)typeof(ECharacter);
					array = (Array)(object)characterSkins;
					if (!flag6)
					{
						bool flag7 = characterSkins.ContainsKey((ECharacter)obj9);
						nint num7 = (nint)typeof(IEnumerator);
						array = (Array)(object)characterSkins;
						if (!flag7)
						{
							((Dictionary<System.Int32Enum, int>)(object)characterSkins).Add((System.Int32Enum)obj9, 0);
							num7 = 0;
							array = (Array)(object)characterSkins;
						}
						continue;
					}
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = num6;
			}
			throw new NullReferenceException();
			IL_0130:
			bool flag8 = ((Dictionary<ECharacter, EHat>)enumerator2).ContainsKey((ECharacter)typeof(IEnumerator));
			num = 1;
			goto IL_0155;
		}
		object obj14 = default(object);
		object obj15 = default(object);
		while (true)
		{
			object obj10;
			if (enumerator2 != null)
			{
				nint num8 = (nint)enumerator2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ r10_v11 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
				if ((nint)0 >= (nint)0)
				{
					goto IL_03aa;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ r10_v11 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
				obj10 = 0;
				object obj11 = 0;
				while (true)
				{
					object obj12 = obj11 + obj11;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v711 @ r8_v13+v858 @ rax_v60*8]");
					if (0 != (nint)typeof(IEnumerator))
					{
						obj11++;
						object obj13 = obj11;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ r10_v11 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
						if ((nint)obj13 < 0)
						{
							continue;
						}
						goto IL_03aa;
					}
					break;
				}
				goto IL_03c2;
			}
			throw new NullReferenceException();
			IL_03aa:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18026F510");
			obj10 = 0;
			goto IL_03c2;
			IL_03c2:
			if (enumerator2.MoveNext())
			{
				bool flag9 = enumerator2 == null;
				Dictionary<System.Int32Enum, System.Int32Enum> dictionary = (Dictionary<System.Int32Enum, System.Int32Enum>)enumerator2;
				if (!flag9)
				{
					object current2 = enumerator2.Current;
					bool flag10 = current2 == null;
					dictionary = (Dictionary<System.Int32Enum, System.Int32Enum>)enumerator2;
					if (!flag10)
					{
						nint num9 = (nint)typeof(ECharacter);
						nint num10 = (nint)current2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ rdx_v30 (Il2CppClass<System.Object>)+40]");
						nint num11 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ r8_v17 (Il2CppClass<ECharacter>)+40]");
						bool flag11 = num11 != 0;
						nint num = (nint)typeof(ECharacter);
						dictionary = (Dictionary<System.Int32Enum, System.Int32Enum>)current2;
						if (!flag11)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
							bool flag12 = characterHats == null;
							num = (nint)typeof(ECharacter);
							dictionary = (Dictionary<System.Int32Enum, System.Int32Enum>)(object)characterHats;
							if (!flag12)
							{
								bool flag13 = characterHats.ContainsKey((ECharacter)obj14);
								dictionary = (Dictionary<System.Int32Enum, System.Int32Enum>)(object)characterHats;
								if (!flag13)
								{
									dictionary = (Dictionary<System.Int32Enum, System.Int32Enum>)(object)characterHats;
									bool flag14 = characterHats == null;
									num = 0;
									if (flag14)
									{
										break;
									}
									((Dictionary<System.Int32Enum, System.Int32Enum>)(object)characterHats).Add((System.Int32Enum)obj14, (System.Int32Enum)0);
								}
								continue;
							}
							throw new NullReferenceException();
						}
						bool flag15 = ((Dictionary<ECharacter, EHat>)(object)dictionary).ContainsKey((ECharacter)num);
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj8 = obj15;
			if (obj15 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
			}
			return;
		}
		throw new NullReferenceException();
	}

	public void SetCharacterHat(ECharacter character, EHat hat)
	{
		if (characterHats.ContainsKey(character))
		{
			((Dictionary<System.Int32Enum, System.Int32Enum>)(object)characterHats).set_Item((System.Int32Enum)character, (System.Int32Enum)hat);
		}
		else
		{
			((Dictionary<System.Int32Enum, System.Int32Enum>)(object)characterHats).Add((System.Int32Enum)character, (System.Int32Enum)hat);
		}
	}

	public EHat GetCharacterHat(ECharacter character)
	{
		//IL_00a3: Expected I4, but got O
		if (characterHats != null)
		{
			if (!characterHats.ContainsKey(character))
			{
				if (characterHats == null)
				{
					goto IL_0095;
				}
				((Dictionary<System.Int32Enum, System.Int32Enum>)(object)characterHats).Add((System.Int32Enum)character, (System.Int32Enum)0);
			}
			if (characterHats != null)
			{
				return characterHats.get_Item(character);
			}
		}
		goto IL_0095;
		IL_0095:
		NullReferenceException ex = new NullReferenceException();
		return (EHat)ex;
	}

	public Preferences()
	{
		Dictionary<ECharacter, int> dictionary = new Dictionary<ECharacter, int>();
		characterSkins = dictionary;
		Dictionary<ECharacter, EHat> dictionary2 = new Dictionary<ECharacter, EHat>();
		characterHats = dictionary2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
	}
}
