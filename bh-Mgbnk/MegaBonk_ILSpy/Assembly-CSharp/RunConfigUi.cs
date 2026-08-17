using System.Collections.Generic;
using Assets.Scripts.Game.Other;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RunConfigUi : MonoBehaviour
{
	public TextMeshProUGUI t_mapName;

	public TextMeshProUGUI t_mapTier;

	public TextMeshProUGUI t_silverMultiplier;

	public TextMeshProUGUI t_challengeName;

	public TextMeshProUGUI t_challengeDescription;

	public Image mapOutline;

	public GameObject challenge;

	public GameObject challengeFailedOverlay;

	private void OnEnable()
	{
	}

	private unsafe void Start()
	{
		//IL_0051: Expected O, but got Ref
		//IL_0078: Expected O, but got Ref
		//IL_009e: Expected O, but got Ref
		//IL_012b: Expected I, but got O
		RunConfig runConfig = MapController.runConfig;
		Material material = mapOutline.material;
		Color tierColor = MyColorUtility.GetTierColor(runConfig.mapTierIndex);
		float num = default(float);
		material.SetColor("_Color", (Color)(&num));
		Color tierColor2 = MyColorUtility.GetTierColor(runConfig.mapTierIndex);
		t_mapName.color = (Color)(&num);
		Color tierColor3 = MyColorUtility.GetTierColor(runConfig.mapTierIndex);
		t_mapTier.color = (Color)(&num);
		string text = runConfig.mapData.GetName();
		t_mapName.text = text;
		TextMeshProUGUI textMeshProUGUI = t_mapTier;
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		int num2 = default(int);
		string value = num2.ToString();
		((Dictionary<object, object>)(object)dictionary).Add((object)"tier", (object)value);
		string localizedString = LocalizationUtility.GetLocalizedString("Other", "TIER_SMART", dictionary);
		nint num3 = (nint)textMeshProUGUI;
		textMeshProUGUI.text = localizedString;
		float silverMultiplier = runConfig.GetSilverMultiplier();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		string text2 = $"<sprite name=silver> <size=90%>{arg}x";
		t_silverMultiplier.text = text2;
		if (runConfig.challenge != null)
		{
			challenge.SetActive(value: true);
			string displayName = runConfig.challenge.GetDisplayName();
			bool flag = displayName == null;
			string text3 = "";
			if (!flag)
			{
				text3 = displayName;
			}
			t_challengeName.text = text3;
			string unlockDescription = runConfig.challenge.GetUnlockDescription();
			t_challengeDescription.text = unlockDescription;
		}
		Transform transform = base.transform;
		Transform parent = transform.parent;
		UiUtility.RebuildUi(parent);
	}

	private void Refresh()
	{
	}
}
