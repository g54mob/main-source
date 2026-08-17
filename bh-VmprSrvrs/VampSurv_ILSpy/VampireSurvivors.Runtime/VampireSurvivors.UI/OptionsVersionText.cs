using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.DLC;
using Zenject;

namespace VampireSurvivors.UI;

public class OptionsVersionText : MonoBehaviour, IInitializable
{
	private TextMeshProUGUI _VersionText;

	private VersionData _VersionData;

	private DataManager _dataManager;

	public void Initialize()
	{
	}

	private void Start()
	{
		//IL_004d: Expected I, but got O
		//IL_005d: Expected O, but got I
		//IL_010b: Expected I, but got O
		//IL_0121: Expected I, but got O
		//IL_03a9: Expected I, but got O
		//IL_0431: Expected I, but got O
		//IL_025f: Expected O, but got I
		//IL_02f9: Expected O, but got I
		//IL_0313: Expected I, but got O
		//IL_0323: Expected O, but got I
		//IL_0333: Expected O, but got I
		TextMeshProUGUI versionText = _VersionText;
		string version = Application.version;
		string text = "Vampire Survivors - " + version;
		if ((object)_VersionText != null)
		{
			nint num = (nint)versionText;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r8_v16 (Il2CppClass<TMPro.TextMeshProUGUI>)+560]");
			object obj = 0;
			_VersionText.text = text;
			if (_dataManager == null)
			{
				return;
			}
			Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
			if (loadedDlc != null)
			{
				Dictionary<DlcType, BundleManifestData> dictionary = loadedDlc;
				OptionsVersionText optionsVersionText = this;
				Dictionary<DlcType, BundleManifestData>.Enumerator enumerator = default(Dictionary<DlcType, BundleManifestData>.Enumerator);
				object obj2 = default(object);
				object obj5 = default(object);
				while (enumerator.MoveNext())
				{
					string versionText2 = (string)(object)optionsVersionText._VersionText;
					string[] array = new string[6];
					bool flag = (object)optionsVersionText._VersionText == null;
					nint num2 = (nint)typeof(string[]);
					if (!flag)
					{
						nint num3 = (nint)versionText2;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1019 @ rdx_v34 (Il2CppClass<System.String>)+548] (should have been resolved before IL gen)");
						if (array != null)
						{
							if (array.Length > 0)
							{
								array[0] = (string)obj2;
								if (array.Length > 1)
								{
									array[1] = "\n";
									DlcCatalog dlcCatalog = DlcSystem._dlcCatalog;
									if ((object)DlcSystem._dlcCatalog == null)
									{
										throw new NullReferenceException();
									}
									bool flag2 = dlcCatalog._DlcData == null;
									if (!flag2)
									{
										int num4 = ((Dictionary<System.Int32Enum, object>)(object)dlcCatalog._DlcData).FindEntry((System.Int32Enum)0);
										object obj4;
										if (!flag2)
										{
											if (dlcCatalog._DlcData == null)
											{
												throw new NullReferenceException();
											}
											object obj3 = ((Dictionary<System.Int32Enum, object>)(object)dlcCatalog._DlcData).get_Item((System.Int32Enum)0);
											if (obj3 == null)
											{
												throw new NullReferenceException();
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v527 @ rax_v107 (System.Object)+18]");
											obj4 = 0;
										}
										else
										{
											obj4 = "UNKNOWN";
										}
										if (array.Length > 2)
										{
											array[2] = (string)obj4;
											if (array.Length > 3)
											{
												array[3] = "";
												if (array.Length > 4)
												{
													array[4] = " - ";
													if (obj5 != null)
													{
														if (array.Length > 5)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v896 @ stack_-40+18]");
															array[5] = (string)0;
															string text2 = string.Concat(array);
															nint num5 = (nint)versionText2;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1675 @ r8_v37 (Il2CppClass<System.String>)+558]");
															dictionary = (Dictionary<DlcType, BundleManifestData>)0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1675 @ r8_v37 (Il2CppClass<System.String>)+560]");
															obj = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1675 @ r8_v37 (Il2CppClass<System.String>)+558] (should have been resolved before IL gen)");
															optionsVersionText = this;
															continue;
														}
														throw new IndexOutOfRangeException();
													}
													throw new NullReferenceException();
												}
												throw new IndexOutOfRangeException();
											}
											throw new IndexOutOfRangeException();
										}
										throw new IndexOutOfRangeException();
									}
									throw new NullReferenceException();
								}
								throw new IndexOutOfRangeException();
							}
							throw new IndexOutOfRangeException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				VersionData versionData = optionsVersionText._VersionData;
				if ((object)optionsVersionText._VersionData != null)
				{
					string formattedBuildId = optionsVersionText._VersionData.GetFormattedBuildId();
					string versionText3 = (string)(object)optionsVersionText._VersionText;
					string[] array2 = new string[6];
					if ((object)optionsVersionText._VersionText != null)
					{
						nint num6 = (nint)versionText3;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1227 @ rdx_v23 (Il2CppClass<System.String>)+548] (should have been resolved before IL gen)");
						if (array2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							string text3 = string.Concat(array2);
							nint num7 = (nint)versionText3;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v269 @ r9_v20 (Il2CppClass<System.String>)+558] (should have been resolved before IL gen)");
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public OptionsVersionText()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
