using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;

namespace VampireSurvivors.Tools;

public class OnlineCheats : GameMonoBehaviour
{
	private TextMeshProUGUI _authEnemiesCount;

	private TextMeshProUGUI _nonAuthEnemiesCount;

	private Slider _slider;

	private TextMeshProUGUI _sliderTitle;

	protected unsafe override void OnUpdate()
	{
		//IL_00e7: Expected O, but got I4
		//IL_01d6: Expected O, but got Ref
		//IL_0242: Expected O, but got Ref
		//IL_0285: Expected I, but got O
		//IL_0332: Expected F4, but got O
		//IL_0390: Expected O, but got Ref
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage == null || ((UnityEngine.Object)stage).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			GameManager core2 = GM.Core;
			if ((object)GM.Core != null)
			{
				Stage stage2 = core2._stage;
				if ((object)core2._stage != null && stage2._spawnedEnemies != null)
				{
					int value = 0;
					int value2 = 0;
					List<VampireSurvivors.Objects.Characters.EnemyController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.EnemyController>.Enumerator);
					if (enumerator.MoveNext())
					{
						object obj = 0;
						nint num = (nint)(&enumerator);
						throw new NullReferenceException();
					}
					System.ParamsArray paramsArray = default(System.ParamsArray);
					string text = System.Number.FormatInt32(value2, (ReadOnlySpan<char>)(&paramsArray), null);
					string text2 = "Auth: " + text;
					if ((object)_authEnemiesCount != null)
					{
						_authEnemiesCount.text = text2;
						TextMeshProUGUI nonAuthEnemiesCount = _nonAuthEnemiesCount;
						string text3 = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&paramsArray), null);
						string text4 = "Non-Auth: " + text3;
						if ((object)_nonAuthEnemiesCount != null)
						{
							nint num2 = (nint)nonAuthEnemiesCount;
							_nonAuthEnemiesCount.text = text4;
							GameManager core3 = GM.Core;
							if ((object)GM.Core != null)
							{
								Stage stage3 = core3._stage;
								if ((object)_slider != null)
								{
									GameManager core4 = GM.Core;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v955.<FreeRoamCameraTargetWhenDead>k__BackingField (System.Int32) (should have been resolved before IL gen)");
									if ((object)core3._stage != null)
									{
										stage3._onlineEnemyMultiplier = (float)stage2._spawnedEnemies;
										if ((object)_slider != null)
										{
											GameManager core5 = GM.Core;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v957.<FreeRoamCameraTargetWhenDead>k__BackingField (System.Int32) (should have been resolved before IL gen)");
											Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
											object arg = default(object);
											System.ParamsArray paramsArray2 = new System.ParamsArray(arg);
											string text5 = string.FormatHelper((IFormatProvider)null, "Enemy Multiplier: x{0:0.00} ", (System.ParamsArray)(&paramsArray));
											if ((object)_sliderTitle != null)
											{
												_sliderTitle.text = text5;
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
		throw new NullReferenceException();
	}

	public void ToggleNetStats()
	{
		NetStats instance = NetStats._instance;
		bool display = !instance.display;
		instance.display = display;
		if (~(instance.display ? 1u : 0u) == 0)
		{
			NetStats.RemoveGraphs();
		}
	}

	public void DebugEnemyRemotePosition()
	{
		bool flag = !EnemyOnlineDebugger._003CEnableDebugPosition_003Ek__BackingField;
		EnemyOnlineDebugger._003CEnableDebugPosition_003Ek__BackingField = flag;
	}

	public void DebugEnemyAuthority()
	{
		bool flag = !EnemyOnlineDebugger._003CEnableDebugAuthority_003Ek__BackingField;
		EnemyOnlineDebugger._003CEnableDebugAuthority_003Ek__BackingField = flag;
	}

	public OnlineCheats()
	{
		//IL_0020: Expected I, but got O
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
