using System;
using System.Text;
using Kitchen.Modules;
using KitchenData;
using TMPro;
using UnityEngine;

namespace Kitchen
{
	public class UnlockCardElement : Element
	{
		public TextMeshPro Title;

		public TextMeshPro Description;

		public TextMeshPro Icon;

		public Renderer Card;

		public TextMeshPro Reward;

		public GameObject RewardContainer;

		public TextMeshPro CustomerChange;

		public GameObject CustomerChangeContainer;

		private static readonly int TitleParameter = Shader.PropertyToID("_Title");

		public override Bounds BoundingBox
		{
			get
			{
				Vector3 size = Card.bounds.size.XZY();
				return new Bounds(base.transform.localPosition + new Vector3(0f, size.y / 2f, 0f), size);
			}
		}

		public void SetUIMode(bool is_ui_mode)
		{
			base.gameObject.SetLayer(LayerMask.NameToLayer(is_ui_mode ? "UI" : "Default"));
		}

		public void SetUnlock(int unlock)
		{
			if (GameData.Main.TryGet<Unlock>(unlock, out var output))
			{
				ICard card = output;
				if (card != null)
				{
					SetUnlock(card);
				}
				else
				{
					Debug.LogError($"Tried to draw a card for {output.name} ({output.ID})");
				}
			}
			else
			{
				Debug.LogError($"Tried to draw a card for {unlock}");
			}
		}

		public void SetUnlock(ICard unlock)
		{
			if (unlock == null)
			{
				Title.text = "";
				Description.text = "";
				Reward.text = "";
				return;
			}
			Title.text = unlock.Name;
			if (unlock is Contract contract && Math.Abs(contract.ExperienceMultiplier - 1f) > 0.01f)
			{
				Reward.text = $"x{Mathf.Round(contract.ExperienceMultiplier * 10f) / 10f} XP";
				RewardContainer.gameObject.SetActive(value: true);
			}
			else if (unlock.ExpReward != Unlock.RewardLevel.None)
			{
				Reward.text = $"+{(int)unlock.ExpReward} XP";
				RewardContainer.gameObject.SetActive(value: true);
			}
			else
			{
				RewardContainer.gameObject.SetActive(value: false);
			}
			if (unlock is Unlock unlock2 && unlock2.CustomerMultiplier != DishCustomerChange.None)
			{
				int num = -unlock2.CustomerMultiplier.Value();
				bool flag = num > 0;
				int num2 = Mathf.FloorToInt((float)num * DifficultyHelpers.CustomerChangePerPoint);
				CustomerChange.text = (flag ? "+" : "") + num2 + "% <size=130><sprite name=\"queue\" color=#D13E0F></size>";
				CustomerChangeContainer.SetActive(value: true);
			}
			else
			{
				CustomerChangeContainer.SetActive(value: false);
			}
			Icon.text = unlock.Icon;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(unlock.Description);
			if (unlock.FlavourText != "")
			{
				stringBuilder.Append("\n\n<style=desc>" + unlock.FlavourText + "</style>");
			}
			string infoString = GetInfoString(unlock);
			if (infoString != "")
			{
				stringBuilder.Append("\n" + infoString);
			}
			Description.text = stringBuilder.ToString();
			base.MemoryManagerHandle.Register(Card.material).SetColor(TitleParameter, unlock.Colour);
		}

		public void SetText(string icon, string title, string main_text, string sub_text, Color colour)
		{
			Title.text = title;
			Icon.text = icon;
			RewardContainer.gameObject.SetActive(value: false);
			CustomerChangeContainer.SetActive(value: false);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(main_text);
			if (sub_text != "")
			{
				stringBuilder.Append("\n\n<style=desc>" + sub_text + "</style>");
			}
			Description.text = stringBuilder.ToString();
			base.MemoryManagerHandle.Register(Card.material).SetColor(TitleParameter, colour);
		}

		public string GetInfoString(ICard card)
		{
			if (!(card is Dish { HideInfoPanel: false } dish))
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("<line-height=110%><size=130><align=\"center\">");
			stringBuilder.AppendLine(GetInfoIconString("INFO_RECIPE_DIFFICULTY", "star", dish.RecipeDifficulty()));
			if (dish.HasExtendedInfoPanel)
			{
				stringBuilder.AppendLine(GetInfoIconString("INFO_EATING_TIME", "clock", dish.EatingTime()));
				stringBuilder.AppendLine(GetInfoIconString("INFO_DISH_VALUE", "coin", dish.DishValue()));
			}
			return stringBuilder.ToString();
		}

		private string GetInfoIconString(string type, string icon, int count)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(GameData.Main.GlobalLocalisation[type]);
			stringBuilder.Append("<pos=40%><cspace=0.2em>");
			for (int i = 0; i < 5; i++)
			{
				stringBuilder.Append("<sprite name=\"" + icon + "\" " + ((count <= i) ? "color=#000000" : "") + ">");
			}
			stringBuilder.Append("</cspace>");
			return stringBuilder.ToString();
		}
	}
}
