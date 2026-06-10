using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class LayoutGroupItemView : UIView
	{
		[FormerlySerializedAs("groupeItems")]
		[SerializeField]
		private List<GameObject> groupItems;

		[SerializeField]
		private TooltipViewNew tooltipNew;

		public List<GameObject> GroupItems => groupItems;

		public TooltipViewNew TooltipNew
		{
			get
			{
				if (tooltipNew != null)
				{
					return tooltipNew;
				}
				if (tooltipNew == null)
				{
					tooltipNew = base.gameObject.GetComponent<TooltipViewNew>();
				}
				if (tooltipNew == null)
				{
					tooltipNew = base.gameObject.GetComponentInChildren<TooltipViewNew>();
				}
				return tooltipNew;
			}
		}

		public void SetText(string text, string textKey = "")
		{
			SetText(0, text, textKey);
		}

		public void SetText(int index, string text, string textKey = "")
		{
			if (groupItems.Count <= index || groupItems[index] == null)
			{
				return;
			}
			TMP_Text component = groupItems[index].GetComponent<TMP_Text>();
			if (!(component == null))
			{
				component.SetText(text);
				if (textKey == string.Empty)
				{
					SetTooltipLines(null);
				}
				else
				{
					SetTooltipLine(base.Localize.GetText(textKey));
				}
			}
		}

		public virtual void SetTextColor(string colorStyle)
		{
			SetTextColor(0, colorStyle);
		}

		protected void SetText(int index, string text, string textKey, HumanoidInstance humanoid)
		{
			if (!(groupItems[index] == null))
			{
				TMP_Text component = groupItems[index].GetComponent<TMP_Text>();
				if (!(component == null))
				{
					component.SetText(text);
					SetWorkerTooltip(textKey, humanoid);
				}
			}
		}

		protected void SetTextColor(int index, string colorStyle)
		{
			TMP_Text component = groupItems[index].GetComponent<TMP_Text>();
			if (!(component == null))
			{
				string sourceText = "<style=" + colorStyle + ">" + component.text + "</style>";
				component.SetText(sourceText);
			}
		}

		public void SetImage(string path)
		{
			SetImage(0, path);
		}

		public void SetImage(int index, string path)
		{
			Image component = groupItems[index].GetComponent<Image>();
			if (!(component == null))
			{
				component.sprite = AssetUtils.GetSprite(path);
			}
		}

		public void SetImage(int index, string path, string tint)
		{
			Image component = groupItems[index].GetComponent<Image>();
			if (component == null)
			{
				return;
			}
			component.sprite = AssetUtils.GetSprite(path);
			Material materialInstance = MonoSingleton<MaterialManager>.Instance.GetMaterialInstance(component);
			materialInstance.SetColor("_color_tint", new Color(0.76f, 0.76f, 0.76f, 1f));
			if (string.IsNullOrEmpty(tint))
			{
				return;
			}
			if (!ColorUtility.TryParseHtmlString(tint, out var color))
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(27, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Base\\LayoutGroupItemView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Color ");
					messageBuilder.AppendFormatted(tint);
					messageBuilder.AppendLiteral(" is not a valid color");
				}
				Log.Warning(messageBuilder);
			}
			else
			{
				materialInstance.SetColor("_color_tint", color);
			}
		}

		public void SetImageHumanoid(string path, string imageKey, HumanoidInstance humanoid)
		{
			SetImageHumanoid(0, path, imageKey, humanoid);
		}

		public void SetImageHumanoid(int index, string path, string imageKey, HumanoidInstance humanoid)
		{
			SetImage(index, path);
			SetWorkerTooltip(imageKey, humanoid);
		}

		protected void SetBackground(int index, Image image = null)
		{
			if (image == null)
			{
				image = base.gameObject.GetComponent<Image>();
			}
			image.color = ColorUtils.GetAlternatingColor(image.color, index);
		}

		public void SetTooltipLines(List<string> lines)
		{
			TooltipViewNew tooltipViewNew = TooltipNew;
			if (!(tooltipViewNew == null))
			{
				tooltipViewNew.SetLines(lines);
			}
		}

		public void SetTooltipLine(string line)
		{
			TooltipViewNew tooltipViewNew = TooltipNew;
			if (!(tooltipViewNew == null))
			{
				tooltipViewNew.SetSingleLineTooltip(line);
			}
		}

		public void SetWorkerTooltip(string imageKey, HumanoidInstance humanoid)
		{
			CreatureBaseTooltipView creatureBaseTooltipView = TooltipNew as CreatureBaseTooltipView;
			if (!(creatureBaseTooltipView == null) && !(imageKey == string.Empty))
			{
				creatureBaseTooltipView.SetTooltipData(imageKey, humanoid);
			}
		}
	}
}
