using System;
using System.Collections.Generic;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.UI.Debug;

public class CommandImplementation
{
	private static int helpAttempts;

	public unsafe static void GetSeed()
	{
		//IL_0066: Expected I, but got O
		//IL_0021: Expected I, but got O
		nint num = (nint)typeof(RsgController);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rcx_v4 (Il2CppClass<RsgController>)+B8]");
		int num2 = (int)((nint)0 + (nint)8);
		string text = ((int*)num2)->ToString();
		string msg = text + " (Copied to clipboard)";
		DebugConsole.Instance.AppendMessage(msg);
		nint num3 = (nint)typeof(RsgController);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rax_v8 (Il2CppClass<RsgController>)+B8]");
		int num4 = (int)((nint)0 + (nint)8);
		string systemCopyBuffer = ((int*)num4)->ToString();
		GUIUtility.systemCopyBuffer = systemCopyBuffer;
	}

	public static void SetSeedCrypt(int seed)
	{
		RsgController.customSeed = seed;
		int num = default(int);
		string text = num.ToString();
		string msg = "Set crypt seed to: " + text;
		DebugConsole.Instance.AppendMessage(msg);
		if (num != 0)
		{
			DebugConsole.Instance.AppendMessage("NOTE: CANNOT unlock ghost skins, crypt challenges, Pot Item or Snek Item if using this. To return to random seeds, use 'set_seed_crypt 0'");
		}
	}

	public static void SetResetTime(float time)
	{
		bool flag = 0.2f > time;
		float quick_reset_time = 0.2f;
		if (!flag)
		{
			bool flag2 = time > 1f;
			quick_reset_time = 1f;
			if (!flag2)
			{
				quick_reset_time = time;
			}
		}
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		CFGameSettings cfGameSettings = config.cfGameSettings;
		cfGameSettings.quick_reset_time = quick_reset_time;
	}

	public static void Help()
	{
		//IL_0091: Expected I, but got O
		//IL_009f: Expected I, but got O
		//IL_00af: Expected O, but got I
		//IL_00eb: Expected O, but got I
		//IL_0143: Expected I, but got O
		//IL_0173: Expected I, but got O
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected I, but got Unknown
		//IL_01dd: Expected O, but got I
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected I, but got Unknown
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Expected I, but got Unknown
		//IL_026a: Expected O, but got I
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Expected I, but got Unknown
		if (helpAttempts > 0)
		{
			DebugConsole instance = DebugConsole.Instance;
			if ((object)DebugConsole.Instance != null && instance.commandList != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
				nint num = 0;
				string text = "\n";
				List<object>.Enumerator enumerator = default(List<object>.Enumerator);
				object obj = default(object);
				while (enumerator.MoveNext())
				{
					if (obj == null)
					{
						continue;
					}
					num = (nint)obj;
					nint num2 = (nint)typeof(DebugCommandBase);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rdx_v15 (Il2CppClass<DebugCommandBase>)+130]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ r8_v10 (Il2CppMethodInfo)+130]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rdx_v15 (Il2CppClass<DebugCommandBase>)+130]");
					if (num3 < 0)
					{
						continue;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ r8_v10 (Il2CppMethodInfo)+C8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rax_v29+FFFFFFF8+v321 @ rax_v28*8]");
					if (0 == (nint)typeof(DebugCommandBase))
					{
						string[] array = new string[5];
						bool flag = array == null;
						nint num4 = (nint)typeof(string[]);
						if (flag)
						{
							throw new NullReferenceException();
						}
						bool flag2 = array.Length <= 0;
						num4 = (nint)typeof(string[]);
						if (flag2)
						{
							throw new IndexOutOfRangeException();
						}
						array[0] = text;
						num4 = (nint)(array + 32);
						if (array.Length <= 1)
						{
							throw new IndexOutOfRangeException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ stack_-50+10]");
						array[1] = (string)0;
						num4 = (nint)(array + 40);
						if (array.Length <= 2)
						{
							throw new IndexOutOfRangeException();
						}
						array[2] = " - ";
						num4 = (nint)(array + 48);
						if (array.Length <= 3)
						{
							throw new IndexOutOfRangeException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ stack_-50+18]");
						array[3] = (string)0;
						num4 = (nint)(array + 56);
						if (array.Length <= 4)
						{
							throw new IndexOutOfRangeException();
						}
						array[4] = "\n";
						string text2 = string.Concat(array);
						text = text2;
					}
				}
				enumerator.Dispose();
				if ((object)DebugConsole.Instance != null)
				{
					DebugConsole.Instance.AppendMessage(text);
					return;
				}
			}
		}
		else if ((object)DebugConsole.Instance != null)
		{
			DebugConsole.Instance.AppendMessage("no");
			int num5 = helpAttempts + 1;
			helpAttempts = num5;
			return;
		}
		throw new NullReferenceException();
	}
}
