using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SFB;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.ExtContent
{
	public static class ExtContentUIUtils
	{
		public static string[] OpenFilePanel(string promptStr, string directory, ExtensionFilter[] extensionFilter, bool multiselect)
		{
			string[] array = null;
			bool flag = false;
			while (!flag)
			{
				flag = true;
				array = StandaloneFileBrowser.OpenFilePanel(promptStr, directory, extensionFilter, multiselect);
				if (array.Length > 0)
				{
					array = RemoveInvalidExtensionFileSpecs(array, extensionFilter);
					if (array.Length <= 0)
					{
						flag = false;
					}
				}
			}
			return array;
		}

		public static string[] RemoveInvalidExtensionFileSpecs(string[] fileSpecs, ExtensionFilter[] extensionFilters)
		{
			List<string> list = new List<string>();
			foreach (string text in fileSpecs)
			{
				string pathExtensionWithoutDot = ExtContentUtils.GetPathExtensionWithoutDot(text);
				bool flag = false;
				for (int j = 0; j < extensionFilters.Length; j++)
				{
					string[] extensions = extensionFilters[j].Extensions;
					foreach (string value in extensions)
					{
						if (pathExtensionWithoutDot.Equals(value, StringComparison.InvariantCultureIgnoreCase))
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						break;
					}
				}
				if (flag)
				{
					list.Add(text);
				}
			}
			return list.ToArray();
		}

		public static string PromptUserForImageFileSpec(string promptStr, string currentFileSpec, string[] supportedTextureFileExtensions)
		{
			string result = string.Empty;
			ExtensionFilter[] fileBrowserExtensionFilter = GetFileBrowserExtensionFilter(supportedTextureFileExtensions, EMessageType.FileBrowserImageFilesLabel);
			string directory = string.Empty;
			if (!currentFileSpec.IsNullOrEmpty())
			{
				directory = Path.GetDirectoryName(currentFileSpec);
			}
			string[] array = OpenFilePanel(promptStr, directory, fileBrowserExtensionFilter, multiselect: false);
			if (array != null && array.Length != 0)
			{
				result = array[0];
			}
			return result;
		}

		public static string[] PromptUserForMusicFileSpecs(string promptStr, string currentFileSpec)
		{
			ExtensionFilter[] fileBrowserExtensionFilter = GetFileBrowserExtensionFilter(new string[1] { "mp3" }, EMessageType.FileBrowserMusicFilesLabel);
			string directory = string.Empty;
			if (!currentFileSpec.IsNullOrEmpty())
			{
				directory = Path.GetDirectoryName(currentFileSpec);
			}
			return OpenFilePanel(promptStr, directory, fileBrowserExtensionFilter, multiselect: true);
		}

		public static ExtensionFilter[] GetFileBrowserExtensionFilter(string[] supportedFileExtensions, EMessageType fileTypeLabelMsgType)
		{
			return new ExtensionFilter[1]
			{
				new ExtensionFilter
				{
					Name = ExtContentMessages.GetMessageString(fileTypeLabelMsgType),
					Extensions = supportedFileExtensions
				}
			};
		}

		public static ExtensionFilter[] GetMusicFileBrowserExtensionFilter(string[] supportedMusicFileExtensions)
		{
			return new ExtensionFilter[1]
			{
				new ExtensionFilter
				{
					Name = ExtContentMessages.GetMessageString(EMessageType.FileBrowserMusicFilesLabel),
					Extensions = supportedMusicFileExtensions
				}
			};
		}

		public static void SetSelectableInteractable(Selectable selectable, bool bCanInteract)
		{
			if (!(selectable != null))
			{
				return;
			}
			selectable.interactable = bCanInteract;
			if (selectable.gameObject.GetComponent<DynamicButton>() != null)
			{
				ButtonAnimator component = selectable.gameObject.GetComponent<ButtonAnimator>();
				if (component != null)
				{
					component.CurrentState = ((!bCanInteract) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
				}
				TMP_Text componentInChildren = selectable.gameObject.GetComponentInChildren<TMP_Text>();
				if (componentInChildren != null)
				{
					componentInChildren.alpha = (bCanInteract ? 1f : 0.5f);
				}
			}
		}

		public static void SetSelectableSelectability(Selectable selectable, bool bCanInteract, bool bIsSelected)
		{
			selectable.interactable = bCanInteract;
			if (!(selectable.gameObject.GetComponent<DynamicButton>() != null))
			{
				return;
			}
			ButtonAnimator component = selectable.gameObject.GetComponent<ButtonAnimator>();
			if (component != null)
			{
				if (bCanInteract)
				{
					component.CurrentState = (bIsSelected ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
				}
				else
				{
					component.CurrentState = ButtonAnimator.State.Unselectable;
				}
			}
		}

		public static void CloseAllGameMenusOnGameItemsUpdate()
		{
			App app = ExtContentUtils.ExtContentManager.App;
			if (app.Level != null && app.Level.HospitalHUDManager != null)
			{
				app.Level.HospitalHUDManager.HideRibbonMenuBuildBar();
				app.Level.HospitalHUDManager.HideItemsList();
			}
		}

		public static bool IsTextureFileResetModifierActive()
		{
			bool result = false;
			if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
			{
				result = true;
			}
			return result;
		}

		public static bool IsGameItemUIScreenShown()
		{
			return ExtContentUtils.ExtContentManager.ExtContentUIManager.GameItemUIScreen.IsShown;
		}

		public static bool AreAnyugcUIScreensShown()
		{
			return ExtContentUtils.ExtContentManager.ExtContentUIManager.AreAnyUIScreensShown();
		}

		public static void OpenGameItemUIScreen(GameItemBase gameItem, Transform invokingSiblingUI = null, bool bHideInvokingSiblingUI = false)
		{
			if (gameItem != null && gameItem.ContentSource == EContentSourceType.LocalMods)
			{
				ExtContentGameItemUIScreen gameItemUIScreen = ExtContentUtils.ExtContentManager.ExtContentUIManager.GameItemUIScreen;
				_ = ExtContentUtils.ExtContentManager.ContentSourceLocalMods;
				gameItemUIScreen.Configure(bCreateNewItem: false, bAllowAmendContentType: false, gameItem.ContentType, null, gameItem);
				gameItemUIScreen.Show(invokingSiblingUI, bHideInvokingSiblingUI);
			}
		}

		public static void OpenGameItemWorkshopPage(GameItemBase gameItem)
		{
			string steamURL = string.Empty;
			string browserURL = string.Empty;
			if (gameItem != null)
			{
				ExtContentUtils.ExtContentManager.ContentSourceWorkshop.GetSteamOverlayWorkshopItemURLsForGameItem(gameItem, ref steamURL, ref browserURL);
			}
			else
			{
				ExtContentSourceWorkshop.GetSteamOverlayWorkshopURLs(ref steamURL, ref browserURL);
			}
			WorkshopUtils.OpenSteamOverlay(steamURL, browserURL);
		}

		public static void OpenGameItemUIOrWorkshopUIScreen(GameItemBase gameItem, Transform invokingSiblingUI = null, bool bHideInvokingSiblingUI = false)
		{
			if (gameItem != null)
			{
				switch (gameItem.ContentSource)
				{
				case EContentSourceType.LocalMods:
					OpenGameItemUIScreen(gameItem, invokingSiblingUI, bHideInvokingSiblingUI);
					break;
				case EContentSourceType.Workshop:
					OpenGameItemWorkshopPage(gameItem);
					break;
				}
			}
		}

		public static void CallOpenFileBrowserFunction(Action openFileBrowserProcessFn)
		{
			ExtContentUtils.ExtContentManager.App.StartCoroutine(CallOpenFileBrowserCoroutine(openFileBrowserProcessFn));
		}

		public static IEnumerator CallOpenFileBrowserCoroutine(Action openFileBrowserProcessFn)
		{
			if (openFileBrowserProcessFn != null)
			{
				bool previousFullscreenState = Screen.fullScreen;
				Screen.fullScreen = false;
				yield return null;
				yield return null;
				openFileBrowserProcessFn();
				Screen.fullScreen = previousFullscreenState;
			}
		}

		public static void ProcessBusyIndicatorAnimation(Image imageIndicator, float indicatorAngularVelocity = -360f)
		{
			if (imageIndicator != null)
			{
				Vector3 localEulerAngles = imageIndicator.gameObject.transform.localEulerAngles;
				localEulerAngles.z += indicatorAngularVelocity * Time.unscaledDeltaTime;
				if (localEulerAngles.z > 360f)
				{
					localEulerAngles.z -= 360f;
				}
				else if (localEulerAngles.z < 0f)
				{
					localEulerAngles.z += 360f;
				}
				imageIndicator.gameObject.transform.localEulerAngles = localEulerAngles;
			}
		}
	}
}
