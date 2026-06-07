using DV.JObjectExtstensions;
using DV.UI;
using DV.UIFramework;
using DV.Utils;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class TextGadget : GadgetComponent
	{
		public delegate void PopupResultHandler(bool ok, string text);

		private const string KEY_TEXT = "text";

		private const string DIALOG_LABEL_LOC_KEY = "item/custom_text_prompt";

		[SerializeField]
		private TextMeshPro textMesh;

		[SerializeField]
		private bool autoInputPrompt = true;

		private Popup currentPopup;

		private PopupResultHandler currentResultHandler;

		private Transform soundSourceOverride;

		private TextMeshPro textMeshItem;

		protected override void Awake()
		{
			base.Awake();
			base.ThisGadget.AfterLinked += Linked;
			base.ThisGadget.BeforeUnlinked += Unlinked;
			base.ThisGadget.ItemAssigned += ItemAssigned;
			if (base.ThisGadget.GadgetItem != null)
			{
				ItemAssigned();
			}
		}

		private void Linked(object _, object __)
		{
			if (autoInputPrompt && base.ThisGadget.GadgetItem.Item.IsGrabbed())
			{
				ShowPopup(useExistingText: false, removeButton: false);
			}
		}

		private void Unlinked(object _, object __)
		{
			ClosePopup();
			UpdateItemText();
		}

		private void ItemAssigned(object _ = null)
		{
			textMeshItem = (base.ThisGadget.GadgetItem.TryGetComponent<GadgetItemTextMesh>(out var component) ? component.itemTextMesh : null);
			UpdateItemText();
		}

		protected internal override void SaveDataRequested(JObject dst)
		{
			base.SaveDataRequested(dst);
			dst.SetString("text", textMesh.text);
		}

		protected internal override void AfterSaveDataLoaded(JObject src)
		{
			base.AfterSaveDataLoaded(src);
			string text = src.GetString("text");
			if (text != null)
			{
				textMesh.text = text;
			}
			UpdateItemText();
		}

		private void UpdateItemText()
		{
			if (textMeshItem != null)
			{
				textMeshItem.text = textMesh.text;
			}
		}

		public void ShowPopup(bool useExistingText, bool removeButton, Transform soundSourceOverride = null, PopupResultHandler resultHandler = null)
		{
			if (currentPopup != null)
			{
				return;
			}
			if (removeButton)
			{
				currentPopup = SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.PopupManager.ShowPopup(SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.uiReferences.pupupTextInputWithDelete, new PopupLocalizationKeys
				{
					labelKey = "item/custom_text_prompt",
					positiveKey = "ok",
					abortionKey = "cancel"
				});
			}
			else
			{
				currentPopup = SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.PopupManager.ShowPopup(SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.uiReferences.popupTextInput, new PopupLocalizationKeys
				{
					labelKey = "item/custom_text_prompt",
					positiveKey = "ok",
					abortionKey = "cancel"
				});
			}
			if (currentPopup == null)
			{
				return;
			}
			if (useExistingText)
			{
				PopupTextInputFieldController component = currentPopup.GetComponent<PopupTextInputFieldController>();
				if ((bool)component)
				{
					component.field.text = textMesh.text;
				}
			}
			currentResultHandler = resultHandler;
			this.soundSourceOverride = soundSourceOverride;
			currentPopup.Closed += PopupClosed;
		}

		private void ClosePopup()
		{
			if (!(currentPopup == null))
			{
				currentPopup.RequestClose(PopupClosedByAction.Abortion, string.Empty);
			}
		}

		private void PopupClosed(PopupResult result)
		{
			if (result.closedBy == PopupClosedByAction.Positive)
			{
				textMesh.text = result.data;
				base.ThisGadget.PlayPlaceSound(soundSourceOverride);
			}
			currentPopup.Closed -= PopupClosed;
			currentPopup = null;
			if (currentResultHandler != null)
			{
				currentResultHandler(result.closedBy == PopupClosedByAction.Positive, result.data);
				currentResultHandler = null;
			}
			if (result.closedBy == PopupClosedByAction.Negative)
			{
				base.ThisGadget.ForceRemove();
				base.ThisGadget.PlayRemoveSound(soundSourceOverride);
			}
		}
	}
}
