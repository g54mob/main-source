using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
	private RectTransform rt;

	[SerializeField]
	public SerializedDictionary<string, LocalizedString> DifficultyModifiersLocalization;

	[field: SerializeField]
	public TextMeshProUGUI DescriptionTxt { get; private set; }

	[field: SerializeField]
	public TextMeshProUGUI NegativeModifiersTxt { get; private set; }

	[field: SerializeField]
	public TextMeshProUGUI PositiveModifiersTxt { get; private set; }

	[field: SerializeField]
	public Image Separator1Img { get; private set; }

	[field: SerializeField]
	public Image Separator2Img { get; private set; }

	private void Awake()
	{
		rt = GetComponent<RectTransform>();
	}

	public void SetMapNode(MapNode node)
	{
		Level level = node.Level;
		string arg = ((level.LevelType != LevelType.Boss) ? DistanceHelper.UnitsToMetricString(level.LevelDistance) : "???");
		DescriptionTxt.text = $"{level.Name}\n{level.TooltipString}\n{arg}";
		bool active = false;
		if (level.DifficultyModifiers.Any((KeyValuePair<string, float> m) => m.Value != 0f))
		{
			active = true;
		}
		NegativeModifiersTxt.text = "";
		PositiveModifiersTxt.text = "";
		NegativeModifiersTxt.gameObject.SetActive(active);
		PositiveModifiersTxt.gameObject.SetActive(active);
		Separator1Img.gameObject.SetActive(active);
		Separator2Img.gameObject.SetActive(active);
		foreach (KeyValuePair<string, float> difficultyModifier in level.DifficultyModifiers)
		{
			if (difficultyModifier.Value == 0f)
			{
				continue;
			}
			if (difficultyModifier.Key == "Storm Spawn Time")
			{
				if (level.Difficulty.Name == "Medium")
				{
					TextMeshProUGUI negativeModifiersTxt = NegativeModifiersTxt;
					negativeModifiersTxt.text = negativeModifiersTxt.text + "<color=red>- </color>" + DifficultyModifiersLocalization["Storm Spawn Time Medium"].GetLocalizedString() + "\n";
				}
				else if (level.Difficulty.Name == "Hard")
				{
					TextMeshProUGUI negativeModifiersTxt2 = NegativeModifiersTxt;
					negativeModifiersTxt2.text = negativeModifiersTxt2.text + "<color=red>- </color>" + DifficultyModifiersLocalization["Storm Spawn Time Hard"].GetLocalizedString() + "\n";
				}
			}
			else if (difficultyModifier.Key == "Storm Damage")
			{
				TextMeshProUGUI negativeModifiersTxt3 = NegativeModifiersTxt;
				negativeModifiersTxt3.text = negativeModifiersTxt3.text ?? "";
			}
			else if (difficultyModifier.Key == "Scrap Gain")
			{
				LocalizedString localizedString = DifficultyModifiersLocalization[difficultyModifier.Key];
				localizedString.Arguments = new object[1] { difficultyModifier.Value * 100f };
				TextMeshProUGUI positiveModifiersTxt = PositiveModifiersTxt;
				positiveModifiersTxt.text = positiveModifiersTxt.text + "<color=green>+ </color>" + localizedString.GetLocalizedString() + "\n";
			}
			else if (difficultyModifier.Key == "Additional Enemies Count")
			{
				LocalizedString localizedString2 = DifficultyModifiersLocalization[difficultyModifier.Key];
				localizedString2.Arguments = new object[1] { difficultyModifier.Value };
				TextMeshProUGUI negativeModifiersTxt4 = NegativeModifiersTxt;
				negativeModifiersTxt4.text = negativeModifiersTxt4.text + "<color=red>- </color>" + localizedString2.GetLocalizedString() + "\n";
			}
			else
			{
				LocalizedString localizedString3 = DifficultyModifiersLocalization[difficultyModifier.Key];
				localizedString3.Arguments = new object[1] { difficultyModifier.Value * 100f };
				TextMeshProUGUI negativeModifiersTxt5 = NegativeModifiersTxt;
				negativeModifiersTxt5.text = negativeModifiersTxt5.text + "<color=red>- </color>" + localizedString3.GetLocalizedString() + "\n";
			}
		}
		if (level.LootType == LootType.Shop || level.LootType == LootType.MysteryLocation)
		{
			if (level.Difficulty.Name == "Medium")
			{
				TextMeshProUGUI positiveModifiersTxt2 = PositiveModifiersTxt;
				positiveModifiersTxt2.text = positiveModifiersTxt2.text + "<color=green>+ </color>" + DifficultyModifiersLocalization["Shop Rewards Medium"].GetLocalizedString() + "\n";
			}
			else if (level.Difficulty.Name == "Hard")
			{
				TextMeshProUGUI positiveModifiersTxt3 = PositiveModifiersTxt;
				positiveModifiersTxt3.text = positiveModifiersTxt3.text + "<color=green>+ </color>" + DifficultyModifiersLocalization["Shop Rewards Hard"].GetLocalizedString() + "\n";
			}
		}
		else if (level.LootType == LootType.Module)
		{
			if (level.Difficulty.Name == "Medium")
			{
				TextMeshProUGUI positiveModifiersTxt4 = PositiveModifiersTxt;
				positiveModifiersTxt4.text = positiveModifiersTxt4.text + "<color=green>+ </color>" + DifficultyModifiersLocalization["Module Rewards Medium"].GetLocalizedString() + "\n";
			}
			else if (level.Difficulty.Name == "Hard")
			{
				TextMeshProUGUI positiveModifiersTxt5 = PositiveModifiersTxt;
				positiveModifiersTxt5.text = positiveModifiersTxt5.text + "<color=green>+ </color>" + DifficultyModifiersLocalization["Module Rewards Hard"].GetLocalizedString() + "\n";
			}
		}
		else if (level.Difficulty.Name == "Medium")
		{
			TextMeshProUGUI positiveModifiersTxt6 = PositiveModifiersTxt;
			positiveModifiersTxt6.text = positiveModifiersTxt6.text + "<color=green>+ </color>" + DifficultyModifiersLocalization["Basic Rewards Medium"].GetLocalizedString() + "\n";
		}
		else if (level.Difficulty.Name == "Hard")
		{
			TextMeshProUGUI positiveModifiersTxt7 = PositiveModifiersTxt;
			positiveModifiersTxt7.text = positiveModifiersTxt7.text + "<color=green>+ </color>" + DifficultyModifiersLocalization["Basic Rewards Hard"].GetLocalizedString() + "\n";
		}
		LayoutRebuilder.ForceRebuildLayoutImmediate(rt);
		rt.position = node.GetComponent<RectTransform>().position;
		LayoutRebuilder.ForceRebuildLayoutImmediate(rt);
		Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, node.transform.position);
		Vector2 pivot = new Vector2((screenPoint.x > (float)Screen.width / 2f) ? 1f : 0f, (screenPoint.y > (float)Screen.height / 2f) ? 1f : 0f);
		rt.pivot = pivot;
		float num = rt.rect.width * pivot.x;
		float num2 = rt.rect.height * pivot.y;
		screenPoint.x = Mathf.Clamp(screenPoint.x, num, (float)Screen.width - (rt.rect.width - num));
		screenPoint.y = Mathf.Clamp(screenPoint.y, num2, (float)Screen.height - (rt.rect.height - num2));
		RectTransformUtility.ScreenPointToWorldPointInRectangle(rt.parent as RectTransform, screenPoint, Camera.main, out var worldPoint);
		rt.position = worldPoint;
	}
}
