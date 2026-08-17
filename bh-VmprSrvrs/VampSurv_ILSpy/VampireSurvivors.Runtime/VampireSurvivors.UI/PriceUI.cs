using System;
using System.Globalization;
using Cpp2ILInjected;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.Tools;

namespace VampireSurvivors.UI;

public class PriceUI : MonoBehaviour
{
	private Image Icon;

	private TextMeshProUGUI Text;

	private bool _shouldUpdateFormatting;

	public void SetPrice(float price)
	{
		NumberFormatInfo instance = NumberFormatInfo.GetInstance(LocalizationManager.mCurrentCulture);
		string text = System.Number.FormatSingle(price, "N0", instance);
		Text.text = text;
		_shouldUpdateFormatting = true;
	}

	private void LateUpdate()
	{
		if (_shouldUpdateFormatting)
		{
			_shouldUpdateFormatting = false;
			RectTransform component = GetComponent<RectTransform>();
			Extensions.RefreshLayoutGroupsImmediateAndRecursive(component);
			Canvas.ForceUpdateCanvases();
		}
	}

	public PriceUI()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
