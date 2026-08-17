using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamageSourceEntry : MonoBehaviour
{
	public RawImage icon;

	public TextMeshProUGUI t_sourceName;

	public TextMeshProUGUI t_lvl;

	public TextMeshProUGUI t_dmg;

	public TextMeshProUGUI t_dps;

	public void Set(DamageSource dmgSource)
	{
		//IL_0168: Invalid comparison between I4 and F4
		//IL_017a: Expected F4, but got I4
		Texture texture = dmgSource.GetIcon();
		icon.texture = texture;
		string localizedDamageSource = LocalizationUtility.GetLocalizedDamageSource(dmgSource.damageSource);
		t_sourceName.text = localizedDamageSource;
		TextMeshProUGUI textMeshProUGUI = t_dmg;
		string text = DamageNumbers.FormatDamageNumber(dmgSource.damage);
		t_dmg.text = text;
		if (t_lvl != null)
		{
			int level = dmgSource.GetLevel();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string text2 = $"{arg}";
			t_lvl.text = text2;
		}
		float num = MyTime.time - dmgSource.addedAtTime;
		bool flag = !(0f < num);
		float number = 0f;
		if (!flag)
		{
			number = dmgSource.damage / num;
		}
		string text3 = DamageNumbers.FormatDamageNumber(number);
		t_dps.text = text3;
	}

	private string FormatNumberWithSpaces(float num)
	{
		return DamageNumbers.FormatDamageNumber(num);
	}
}
