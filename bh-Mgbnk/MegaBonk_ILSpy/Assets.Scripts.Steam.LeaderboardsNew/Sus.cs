using System;
using System.IO;
using System.Reflection;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Steam.LeaderboardsNew;

public static class Sus
{
	public static bool Check()
	{
		string reason;
		return CheckMods(out reason);
	}

	public unsafe static bool CheckMods(out string reason)
	{
		//IL_0560: Expected I4, but got O
		//IL_001b: Expected O, but got I4
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Expected O, but got Unknown
		//IL_04c9: Expected O, but got I4
		//IL_051b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0520: Expected O, but got Unknown
		ref string reference = ref *(string*)null;
		AppDomain curDomain = AppDomain.getCurDomain();
		if (curDomain != null)
		{
			Assembly[] assemblies = curDomain.GetAssemblies();
			object obj = 0;
			object obj3 = default(object);
			object obj4 = default(object);
			object obj5 = default(object);
			object obj6 = default(object);
			object obj7 = default(object);
			object obj8 = default(object);
			while (true)
			{
				if ((nint)obj >= assemblies.Length)
				{
					AppDomain curDomain2 = AppDomain.getCurDomain();
					string baseDirectory = curDomain2.BaseDirectory;
					bool flag = baseDirectory != null;
					string path = baseDirectory;
					if (!flag)
					{
						string dataPath = Application.dataPath;
						path = dataPath;
					}
					string[] array = new string[10];
					string text = Path.Combine(path, "MelonLoader");
					array[0] = text;
					string text2 = Path.Combine(path, "patchers");
					array[1] = text2;
					string text3 = Path.Combine(path, "BepInExPack");
					array[2] = text3;
					string text4 = Path.Combine(path, "BepInEx");
					array[3] = text4;
					string text5 = Path.Combine(path, "Mods");
					array[4] = text5;
					string text6 = Path.Combine(path, "Plugins");
					array[5] = text6;
					string text7 = Path.Combine(path, "mod");
					array[6] = text7;
					string text8 = Path.Combine(path, "BepInEx", "core");
					array[7] = text8;
					string text9 = Path.Combine(path, "BepInEx", "plugins");
					array[8] = text9;
					string text10 = Path.Combine(path, "BepInEx", "patchers");
					array[9] = text10;
					object obj2 = 0;
					while (true)
					{
						if ((nint)obj2 < array.Length)
						{
							string text11 = "Checking path: " + array[obj2];
							if (Directory.Exists(array[obj2]))
							{
								break;
							}
							obj2++;
							continue;
						}
						reference = ref *(string*)null;
						return false;
					}
					string text12 = "Suspicious folder found: " + array[obj2];
					reference = ref *(string*)text12;
					break;
				}
				string value = assemblies[obj].GetName()?.name;
				if (!string.IsNullOrEmpty(value))
				{
					Type type = assemblies[obj].GetType("BepInEx.Bootstrap.Chainloader", throwOnError: false);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805B5BF0");
					if (obj3 == null)
					{
						Type type2 = assemblies[obj].GetType("MelonLoader.MelonHandler", throwOnError: false);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805B5BF0");
						if (obj4 == null)
						{
							Type type3 = assemblies[obj].GetType("MelonLoader.MelonLogger", throwOnError: false);
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805B5BF0");
							if (obj5 == null)
							{
								Type type4 = assemblies[obj].GetType("UnityExplorer.Explorer", throwOnError: false);
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805B5BF0");
								if (obj6 == null)
								{
									Type type5 = assemblies[obj].GetType("HarmonyLib.Harmony", throwOnError: false);
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805B5BF0");
									if (obj7 == null)
									{
										Type type6 = assemblies[obj].GetType("0Harmony.Harmony", throwOnError: false);
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805B5BF0");
										if (obj8 == null)
										{
											goto IL_02a6;
										}
									}
									reference = ref *(string*)"Harmony (type)";
								}
								else
								{
									reference = ref *(string*)"UnityExplorer (type)";
								}
								break;
							}
						}
						reference = ref *(string*)"MelonLoader (type)";
					}
					else
					{
						reference = ref *(string*)"BepInEx (type)";
					}
					break;
				}
				goto IL_02a6;
				IL_02a6:
				obj++;
			}
			return true;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
