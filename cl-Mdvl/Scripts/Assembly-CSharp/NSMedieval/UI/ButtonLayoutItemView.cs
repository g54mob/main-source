using System.Collections.Generic;
using NSEipix.View.UI;
using TMPro;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class ButtonLayoutItemView : LayoutGroupItemView
	{
		private int iconIndex;

		private int textIndex = 1;

		private int buttonIndex = 2;

		private int shortcutKeyIndex = 3;

		private int selectImageIndex = 4;

		private SoundButton button;

		private TMP_Text textObject;

		private Image imageObject;

		private Image buttonIcon;

		private string id;

		public SoundButton Button => button = ((button == null) ? base.GroupItems[buttonIndex].GetComponent<SoundButton>() : button);

		public TMP_Text TextObject => textObject = ((textObject == null) ? base.GroupItems[textIndex].GetComponent<TMP_Text>() : textObject);

		public Image ImageObject => imageObject = ((imageObject == null) ? base.GroupItems[iconIndex].GetComponent<Image>() : imageObject);

		public Image ButtonIcon => buttonIcon = ((buttonIcon == null) ? Button.GetComponent<Image>() : buttonIcon);

		public int IconIndex => iconIndex;

		public int TextIndex => textIndex;

		public string GetId => id;

		public void Select(bool select)
		{
			if (base.GroupItems[selectImageIndex] != null)
			{
				base.GroupItems[selectImageIndex].gameObject.SetActive(select);
			}
		}

		public void SetButtonData(string name)
		{
			SetText(textIndex, name);
		}

		public void SetButtonData(string id, string name)
		{
			this.id = id;
			SetText(textIndex, name, id);
		}

		public void SetButtonData(string id, string name, bool selected)
		{
			if (base.GroupItems[selectImageIndex] != null)
			{
				Select(selected);
			}
			this.id = id;
			SetText(textIndex, name, id);
		}

		public void SetButtonData(string id, string iconPath, string name, bool selected)
		{
			if (base.GroupItems[selectImageIndex] != null)
			{
				Select(selected);
			}
			SetButtonData(id, iconPath, name);
		}

		public void SetButtonData(string id, string iconPath, string name)
		{
			this.id = id;
			SetImage(iconIndex, iconPath);
			SetText(textIndex, name, id);
		}

		public void SetButtonData(string id, string iconPath, string name, string key)
		{
			this.id = id;
			SetImage(iconIndex, iconPath);
			SetText(textIndex, name, id);
			SetText(shortcutKeyIndex, key, id);
		}

		public void SetImageData(string id, string iconPath, string iconColor = "")
		{
			this.id = id;
			SetImage(iconIndex, iconPath, iconColor);
		}

		public void SetTextData(string id, string text)
		{
			this.id = id;
			SetText(textIndex, text, id);
		}

		public void SetTextData(string text)
		{
			SetText(textIndex, text, id);
		}

		public void SetTextData(string text, List<string> tooltipLines, string id = "")
		{
			this.id = id;
			SetText(textIndex, text, string.Empty);
			if (base.TooltipNew != null)
			{
				base.TooltipNew.SetLines(tooltipLines);
			}
		}
	}
}
