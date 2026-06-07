using DV.Customization.Gadgets;
using DV.JObjectExtstensions;
using DV.UI;
using DV.UIFramework;
using DV.Utils;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine;

namespace DV
{
	public class LabelableItem : MonoBehaviour
	{
		private const string KEY = "label_text";

		[SerializeField]
		[Header("Working mode")]
		private bool manuallyControlled;

		[SerializeField]
		[Header("Component")]
		private GameObject labelRoot;

		[SerializeField]
		private GadgetBase referenceGadget;

		[SerializeField]
		private GameObject brokenLabel;

		[SerializeField]
		private TextMeshPro textMesh;

		[SerializeField]
		[Header("Localization")]
		private string dialogLocKey = "item/custom_text_prompt";

		private InventoryItemSpec itemSpec;

		private ItemSaveData itemSaveData;

		private Popup currentPopup;

		public bool ValidTarget => !manuallyControlled;

		public GameObject LabelRoot => labelRoot;

		public GadgetBase ReferenceGadget => referenceGadget;

		public bool HasText => !string.IsNullOrEmpty(textMesh.text);

		public string Text => textMesh.text;

		private void Start()
		{
			if (!manuallyControlled)
			{
				itemSaveData = GetComponent<ItemSaveData>();
				if (!itemSaveData)
				{
					Debug.LogError("[LabelableItem] ItemSaveData component not found on " + base.gameObject.name + ". This component is required for saving/loading label text.");
					Object.Destroy(this);
				}
				else
				{
					itemSaveData.AfterItemSaveDataLoaded += OnSaveDataLoaded;
					itemSaveData.ItemSaveDataRequested += OnSaveDataRequested;
					itemSpec = GetComponent<InventoryItemSpec>();
				}
			}
		}

		private JObject OnSaveDataRequested(JObject data)
		{
			if (HasText)
			{
				data.SetString("label_text", textMesh.text);
			}
			else
			{
				data.Remove("label_text");
			}
			return data;
		}

		private void OnSaveDataLoaded(JObject data)
		{
			if (data.ContainsKey("label_text"))
			{
				UpdateText(data.GetString("label_text"));
			}
			else
			{
				UpdateText(null);
			}
		}

		public void UpdateText(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				textMesh.text = string.Empty;
				if ((bool)itemSpec)
				{
					itemSpec.NameOverride = null;
				}
				labelRoot.SetActive(value: false);
			}
			else
			{
				textMesh.text = text;
				if ((bool)itemSpec)
				{
					itemSpec.NameOverride = text;
				}
				labelRoot.SetActive(value: true);
			}
		}

		public void ShowPopup(PopupClosedDelegate resultHandler = null)
		{
			if (currentPopup != null)
			{
				return;
			}
			if (labelRoot.gameObject.activeInHierarchy)
			{
				currentPopup = SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.PopupManager.ShowPopup(SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.uiReferences.pupupTextInputWithDelete, new PopupLocalizationKeys
				{
					labelKey = dialogLocKey,
					positiveKey = "ok",
					abortionKey = "cancel"
				});
			}
			else
			{
				currentPopup = SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.PopupManager.ShowPopup(SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.uiReferences.popupTextInput, new PopupLocalizationKeys
				{
					labelKey = dialogLocKey,
					positiveKey = "ok",
					abortionKey = "cancel"
				});
			}
			if (!(currentPopup == null))
			{
				PopupTextInputFieldController component = currentPopup.GetComponent<PopupTextInputFieldController>();
				if ((bool)component)
				{
					component.field.text = textMesh.text;
				}
				currentPopup.Closed += PopupClosed;
				if (resultHandler != null)
				{
					currentPopup.Closed += resultHandler;
				}
			}
		}

		private void PopupClosed(PopupResult result)
		{
			if (result.closedBy == PopupClosedByAction.Positive)
			{
				textMesh.text = result.data;
				if ((bool)itemSpec)
				{
					itemSpec.NameOverride = result.data;
				}
				labelRoot.SetActive(value: true);
				if ((bool)referenceGadget)
				{
					referenceGadget.PlayPlaceSound(labelRoot.transform);
				}
			}
			currentPopup.Closed -= PopupClosed;
			currentPopup = null;
			if (result.closedBy == PopupClosedByAction.Negative && labelRoot.gameObject.activeInHierarchy)
			{
				textMesh.text = string.Empty;
				if ((bool)itemSpec)
				{
					itemSpec.NameOverride = null;
				}
				labelRoot.SetActive(value: false);
				if ((bool)referenceGadget)
				{
					referenceGadget.PlayRemoveSound(labelRoot.transform);
				}
				if ((bool)brokenLabel)
				{
					Object.Instantiate(brokenLabel, labelRoot.transform.position, labelRoot.transform.rotation);
				}
			}
		}
	}
}
