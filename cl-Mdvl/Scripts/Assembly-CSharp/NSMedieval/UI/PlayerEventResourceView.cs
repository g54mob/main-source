using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine.Events;

namespace NSMedieval.UI
{
	public class PlayerEventResourceView : LayoutGroupItemView
	{
		private readonly int editInputGroupIndex = 2;

		private readonly int nameIndex;

		private readonly int statValueIndex = 1;

		private UnityAction<Resource, int> addCallback;

		private UnityAction<Resource, int> getValueAction;

		private Resource resource;

		private UnityAction<Resource, int> setCallback;

		private EditableInputGroupLayoutItemView InputGroupLayoutItemView => base.GroupItems[editInputGroupIndex].GetComponent<EditableInputGroupLayoutItemView>();

		public void SetData(Resource resource, UnityAction<Resource, int> setCallback, UnityAction<Resource, int> addCallback)
		{
			this.resource = resource;
			this.setCallback = setCallback;
			this.addCallback = addCallback;
			base.GroupItems[nameIndex].GetComponent<TMP_Text>().SetText(ResourceUtils.GetLocalizedNameWithSprite(this.resource));
			InputGroupLayoutItemView.SetData(GetCurrentResourceCount().ToString(), SetCallback, AddCallback);
			UpdateCountText();
			HandleButtons();
			base.TooltipNew.SetLines(ResourceUtils.GetTooltipData(resource.GetID()));
		}

		private void UpdateCountText()
		{
			int num = MonoSingleton<ResourcePileTracker>.Instance.GetCount(resource).StockpileAllowedCount - GetCurrentResourceCount();
			base.GroupItems[statValueIndex].GetComponent<TMP_Text>().SetText($"{num}");
		}

		private int GetCurrentResourceCount()
		{
			return MonoSingleton<PlayerTriggeredEventManager>.Instance.EventToStart.GetEventResourceCount(resource);
		}

		private void AddCallback(int value)
		{
			addCallback?.Invoke(resource, value);
			InputGroupLayoutItemView.InputField.text = GetCurrentResourceCount().ToString();
			HandleButtons();
			UpdateCountText();
		}

		private void SetCallback(int value)
		{
			setCallback?.Invoke(resource, value);
			InputGroupLayoutItemView.InputField.text = GetCurrentResourceCount().ToString();
			HandleButtons();
			UpdateCountText();
		}

		private void HandleButtons()
		{
			InputGroupLayoutItemView.MinusButton.interactable = GetCurrentResourceCount() > 0;
			InputGroupLayoutItemView.PlusButton.interactable = GetCurrentResourceCount() < MonoSingleton<ResourcePileTracker>.Instance.GetCount(resource).StockpileAllowedCount;
		}
	}
}
