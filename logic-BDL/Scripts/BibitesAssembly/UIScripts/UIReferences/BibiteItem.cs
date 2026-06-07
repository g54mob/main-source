using SteamIntegrations;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using Utility;

namespace UIScripts.UIReferences
{
	public class BibiteItem : PoolableDictItem<string, BibiteItem>, IPointerClickHandler, IEventSystemHandler
	{
		[SerializeField]
		private TextMeshProUGUI nameText;

		[SerializeField]
		private TextMeshProUGUI version;

		[SerializeField]
		private GameObject officialIcon;

		[SerializeField]
		private GameObject nonOfficialIcon;

		[SerializeField]
		private GameObject externalIcon;

		[SerializeField]
		private TooltipTrigger externalTooltip;

		public bool isShared;

		public BibiteTemplate template;

		private UnityAction<BibiteItem> click;

		private WorkshopItem item;

		public bool isExternal => template.isExternal;

		public bool isOfficial => template.isOfficial;

		public string templateName => template.name;

		public WorkshopItem workshopItem => item;

		public void InitializeItem(BibiteTemplate bibiteTemplate, UnityAction<BibiteItem> onClicked, WorkshopItem external = null)
		{
			template = bibiteTemplate;
			item = external;
			nameText.text = template.name;
			version.text = Version.Parse(template.version).ToString();
			officialIcon.SetActive(!isExternal && template.isOfficial);
			nonOfficialIcon.SetActive(!isExternal && !template.isOfficial);
			externalIcon.SetActive(isExternal);
			if (isExternal)
			{
				externalTooltip.UpdateText(null, "This bibite comes from one of the workshop items you subscribe to:\n" + item.title + " by " + item.creatorName);
			}
			else
			{
				item = ((SteamWorkshopManager.instance != null) ? SteamWorkshopManager.instance.GetSharedItem(template.filePath) : null);
				if (item != null)
				{
					isShared = true;
				}
			}
			click = onClicked;
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			click(this);
		}
	}
}
