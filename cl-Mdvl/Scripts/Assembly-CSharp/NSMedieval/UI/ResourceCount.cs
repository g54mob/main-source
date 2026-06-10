using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class ResourceCount : LayoutGroupItemView
	{
		[SerializeField]
		private TextMeshProUGUI resourceID;

		[SerializeField]
		private TextMeshProUGUI resourceCount;

		[SerializeField]
		private Image backgroundImage;

		private ResourceGroup groupParent;

		public int Count { get; private set; }

		public void SetupResource(string resourceID, ResourceGroup parent = null)
		{
			this.resourceID.text = ResourceUtils.GetTextIcon(resourceID) ?? "";
			resourceCount.text = "0";
			base.TooltipNew.SetLines(ResourceUtils.GetTooltipData(resourceID));
			backgroundImage.enabled = false;
			groupParent = parent;
		}

		public void SetActive(bool active)
		{
			if (active && Count > 0)
			{
				base.gameObject.SetActive(value: true);
			}
			else
			{
				base.gameObject.SetActive(value: false);
			}
		}

		public void UpdateValue(int count, bool backgroundEnabled)
		{
			Count = count;
			backgroundImage.enabled = backgroundEnabled;
			resourceCount.text = Count.ToString();
			if (groupParent != null)
			{
				groupParent.UpdateGroup();
			}
		}
	}
}
