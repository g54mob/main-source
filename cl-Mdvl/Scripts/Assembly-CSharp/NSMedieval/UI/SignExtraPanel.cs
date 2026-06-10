using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Manager;
using UnityEngine;

namespace NSMedieval.UI
{
	[Serializable]
	public class SignExtraPanel : SelectionExtraWindowView
	{
		[SerializeField]
		private SafeTMP_InputField messageInput;

		public void UpdatePanel(InfoPanelSign infoPanelSign)
		{
			Show();
			if (!messageInput.isFocused)
			{
				messageInput.transform.parent.gameObject.SetActive(value: true);
				messageInput.onEndEdit.RemoveAllListeners();
				messageInput.onEndEdit.AddListener(delegate(string message)
				{
					infoPanelSign.TooltipCallback(message);
				});
				messageInput.SetTextWithoutNotify(string.Empty);
				BaseBuildingInstance baseBuildingInstance = null;
				List<BaseBuildingInstance> selection = infoPanelSign.Selection;
				if (selection != null && selection.Count > 0)
				{
					baseBuildingInstance = selection[0];
				}
				SignComponentInstance signComponentInstance = baseBuildingInstance?.Map.SignComponentManager.GetComponentInstance(baseBuildingInstance);
				if (signComponentInstance != null && !string.IsNullOrEmpty(signComponentInstance.Message))
				{
					messageInput.SetTextWithoutNotify(signComponentInstance.Message);
					infoPanelSign.TooltipCallback(signComponentInstance.Message);
				}
			}
		}

		private void Start()
		{
			messageInput.onSelect.AddListener(delegate
			{
				MonoSingleton<InputManager>.Instance.SetInputEnabled(value: false);
			});
			messageInput.onDeselect.AddListener(delegate
			{
				MonoSingleton<InputManager>.Instance.SetInputEnabled(value: true);
			});
		}
	}
}
