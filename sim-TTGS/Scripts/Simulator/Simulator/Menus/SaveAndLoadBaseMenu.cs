using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator.Menus
{
	public abstract class SaveAndLoadBaseMenu : Menu
	{
		[Header("Base components")]
		[SerializeField]
		private ScrollRect m_scrollRect;

		[SerializeField]
		private RectTransform m_saveContainer;

		[Header("Prefabs")]
		[SerializeField]
		private UI_SaveAndLoadBaseFile m_saveAndLoadBaseFilePrefab;

		[Header("Confirmation Popup")]
		[SerializeField]
		private MenuConfirmationPopup.Terms m_confirmationPopupTerms;

		private NavBox m_saveContainerNavBox;

		private ScrollRectAutoScroll m_autoScroll;

		private void Start()
		{
			m_saveContainerNavBox = m_saveContainer.GetComponent<NavBox>();
			m_autoScroll = m_scrollRect.GetComponent<ScrollRectAutoScroll>();
		}

		protected override void OnSetActive()
		{
			base.OnSetActive();
			m_scrollRect.verticalNormalizedPosition = 0f;
			CreateLoadFiles();
		}

		protected override void OnSetInactive()
		{
			base.OnSetInactive();
			ClearLoadFiles();
		}

		private void CreateLoadFiles()
		{
			m_saveContainerNavBox.ClearAllElements();
			SaveFileInfo[] array = SaveManager.GetSaveFilesInfos().ToArray();
			if (array.Length == 0)
			{
				return;
			}
			if (array.Length == 1)
			{
				InstantiateSaveFile(array[0], MenuSettings.SaveFileFullRoundedVariation1);
			}
			else
			{
				InstantiateSaveFile(array[0], MenuSettings.SaveFileTopRoundedVariation1);
				Sprite buttonSprite;
				for (int i = 1; i < array.Length - 1; i++)
				{
					buttonSprite = ((i % 2 == 0) ? MenuSettings.SaveFileNotRoundedVariation1 : MenuSettings.SaveFileNotRoundedVariation2);
					InstantiateSaveFile(array[i], buttonSprite);
				}
				int num = array.Length - 1;
				buttonSprite = ((num % 2 == 0) ? MenuSettings.SaveFileBotRoundedVariation1 : MenuSettings.SaveFileBotRoundedVariation2);
				InstantiateSaveFile(array[num], buttonSprite);
			}
			RefreshLayout();
			SetSaveButtonNavigationNeighbours();
			if (TransientManager<InputManager>.Instance.CurrentDevice == EInputDeviceType.GAMEPAD)
			{
				base.NavBox.SelectFirstChild();
			}
			m_autoScroll.RefreshScrollView();
		}

		private void ClearLoadFiles()
		{
			for (int num = m_saveContainer.childCount - 1; num >= 0; num--)
			{
				Object.Destroy(m_saveContainer.GetChild(num).gameObject);
			}
		}

		protected void Refresh()
		{
			ClearLoadFiles();
			CreateLoadFiles();
		}

		private void ShowConfirmationPopup(FileInfo fileInfo)
		{
			Menus.ConfirmationPopup.Show(m_confirmationPopupTerms, delegate
			{
				OnConfirmationPopupValidate(fileInfo);
			}, OnConfirmationPopupCancel);
		}

		private void OnConfirmationPopupCancel()
		{
			if (TransientManager<InputManager>.Instance.CurrentDevice == EInputDeviceType.GAMEPAD)
			{
				base.NavBox.SelectFirstChild();
			}
		}

		protected abstract void OnConfirmationPopupValidate(FileInfo fileInfo);

		private void InstantiateSaveFile(SaveFileInfo saveFileInfo, Sprite buttonSprite)
		{
			UI_SaveAndLoadBaseFile uI_SaveAndLoadBaseFile = Object.Instantiate(m_saveAndLoadBaseFilePrefab, m_saveContainer);
			uI_SaveAndLoadBaseFile.Image.sprite = buttonSprite;
			uI_SaveAndLoadBaseFile.SetInfo(saveFileInfo);
			m_saveContainerNavBox.AddChild(uI_SaveAndLoadBaseFile.GetComponent<UINavElement>());
			m_autoScroll.AddElement(uI_SaveAndLoadBaseFile);
			OnInstantiateSaveFile(uI_SaveAndLoadBaseFile);
		}

		private void SetSaveButtonNavigationNeighbours()
		{
			List<UINavElement> list = new List<UINavElement>();
			Transform transform = m_saveContainer.transform;
			for (int i = 0; i < transform.childCount; i++)
			{
				if (transform.GetChild(i).TryGetComponent<UINavElement>(out var component))
				{
					list.Add(component);
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				int index = j - 1;
				int index2 = j + 1;
				UINavElement upNeighbour = null;
				if (list.IsIndexValid(index))
				{
					upNeighbour = list[index];
				}
				UINavElement downNeighbour = null;
				if (list.IsIndexValid(index2))
				{
					downNeighbour = list[index2];
				}
				list[j].SetNeighbours(new SimpleNavElementNeighbours
				{
					DownNeighbour = downNeighbour,
					UpNeighbour = upNeighbour
				});
			}
		}

		protected virtual void OnInstantiateSaveFile(UI_SaveAndLoadBaseFile saveFile)
		{
			saveFile.OnClick += delegate(FileInfo fileInfo)
			{
				if (OnSaveFileClick_CanShowConfirmationPopup(fileInfo))
				{
					ShowConfirmationPopup(fileInfo);
				}
				else
				{
					OnSaveFileClick_DoWithoutConfirmationPopup(fileInfo);
				}
			};
		}

		private void RefreshLayout()
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(m_saveContainer);
		}

		protected abstract bool OnSaveFileClick_CanShowConfirmationPopup(FileInfo fileInfo);

		protected abstract void OnSaveFileClick_DoWithoutConfirmationPopup(FileInfo fileInfo);
	}
}
