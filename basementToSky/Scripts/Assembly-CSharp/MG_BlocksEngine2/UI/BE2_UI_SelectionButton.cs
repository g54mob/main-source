using MG_BlocksEngine2.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.UI
{
	[ExecuteInEditMode]
	public class BE2_UI_SelectionButton : MonoBehaviour
	{
		private Button _button;

		private BE2_UI_BlocksSelectionViewer _blocksSelectionViewer;

		public BE2_UI_SelectionPanel selectionPanel;

		private void OnValidate()
		{
			foreach (Transform item in base.transform)
			{
				if ((bool)item.GetComponent<Image>())
				{
					item.GetComponent<Image>().raycastTarget = false;
				}
			}
			base.transform.GetComponent<Image>().raycastTarget = true;
			BE2_Text[] bE2TextsInChildren = BE2_Text.GetBE2TextsInChildren(base.transform);
			for (int i = 0; i < bE2TextsInChildren.Length; i++)
			{
				bE2TextsInChildren[i].raycastTarget = false;
			}
		}

		private void Awake()
		{
			_button = GetComponent<Button>();
		}

		private void Start()
		{
			_blocksSelectionViewer = BE2_UI_BlocksSelectionViewer.Instance;
			_button.onClick.AddListener(ToggleSection);
		}

		public void ToggleSection()
		{
			foreach (BE2_UI_SelectionPanel selectionPanels in _blocksSelectionViewer.selectionPanelsList)
			{
				if ((bool)selectionPanel)
				{
					if (selectionPanels == selectionPanel)
					{
						selectionPanels.gameObject.SetActive(value: true);
					}
					else
					{
						selectionPanels.gameObject.SetActive(value: false);
					}
				}
				else
				{
					selectionPanels.gameObject.SetActive(value: true);
				}
			}
		}
	}
}
