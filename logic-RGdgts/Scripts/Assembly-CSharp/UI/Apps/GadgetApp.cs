using System;
using System.Collections;
using System.Collections.Generic;
using UI.Common;
using UI.Elements;
using UI.Modal;
using UI.SmallCanvas;
using UI.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Apps
{
	public class GadgetApp : MultiToolApp, ArchiveDrawerBehaviour.IListener
	{
		public WaitingAnimation waitingAnimation;

		private Dictionary<GadgetWorkshopStates, ButtonGameobjectsAndState[]> browserButtonDict;

		private Dictionary<GadgetShareStatus, GameObject[]> shareObjectsDict;

		private Dictionary<GadgetTags, UIButton> tagButtonDict;

		private SerializedGadgetMetaData currentGadgetMetadata;

		private GadgetSmallCanvas gadgetDataSmallCanvas;

		private GadgetLauncherSmallCanvas launcherSmallCanvas;

		public GadgetSmallCanvas smallCanvasPrefab;

		public GadgetLauncherSmallCanvas launcherSmallCanvasPrefab;

		public UIText gadgetName;

		public UIText descriptionText;

		public UIText descriptionPlaceholderText;

		public Image gadgetPreview;

		public Image statusIcon;

		public UIButton fileNameButton;

		public GameObject tags;

		public Sprite minusTagIcon;

		public Sprite plusTagIcon;

		public UIButton expandTagsButton;

		private bool tagsExpanded;

		public UIButton codeTagButton;

		public UIButton artTagButton;

		public UIButton audioTagButton;

		public UIButton gameTagButton;

		public UIButton toolTagButton;

		public UIButton gamepadTagButton;

		public UIButton keyboardTagButton;

		public UIButton assetsTagButton;

		public UIButton templateTagButton;

		public UIToggle showcase;

		public UIButton likeButton;

		public UIButton editButton;

		public UIButton openButton;

		public UIButton renameButton;

		public UIButton duplicateButton;

		public UIButton jailBreakButton;

		public UIButton deleteButton;

		public UIButton addDescriptionButton;

		public GameObject protectedLabel;

		public GameObject openLabel;

		public GameObject questionMarkLabel;

		private List<UIButton> editButtons;

		public UIButton publishButton;

		public UIButton uploadLocalChangesButton;

		public UIButton subscribeButton;

		public UIButton downloadButton;

		public UIButton printButton;

		public UIButton unpubblishButton;

		public UIButton unsubscribeButton;

		public UIButton securityButton;

		private List<UIButton> workshopButtons;

		private bool changingWorkshopState;

		private GadgetWorkshopStates desiredStatus;

		private Coroutine waitForStatusToChangeCo;

		private UIModal currentOpenModal;

		private void AddDevTag()
		{
		}

		public override void Init()
		{
		}

		private void InitLikeButtons()
		{
		}

		private void InitEditGadgetButtons()
		{
		}

		private void InitBrowserButtons()
		{
		}

		private void InitTags()
		{
		}

		private void ExpandTags()
		{
		}

		public override void AppStart()
		{
		}

		public override void AppStop()
		{
		}

		public void OnArchiveDrawerShowGadget(SerializedGadgetMetaData metadata)
		{
		}

		public void OpenGadget(SerializedGadgetMetaData metadata = null)
		{
		}

		private void OpenGadgetAssets()
		{
		}

		private void GadgetFromOpenDrawerToDesk(Action onComplete, UIButton button)
		{
		}

		private void OpenSecurityApp()
		{
		}

		private void RefreshGadget(bool buttons = true)
		{
		}

		private void RefreshDescriptionText()
		{
		}

		private void RefreshPreview()
		{
		}

		private void RefreshLikes(SerializedGadgetMetaData metadata)
		{
		}

		private void RefreshGadgetVisualization()
		{
		}

		private GadgetWorkshopStates GetGadgetWorkshopState()
		{
			return default(GadgetWorkshopStates);
		}

		private void RefreshButtonsGadgetState(bool refreshLikes = true, GadgetWorkshopStates gadgetState = GadgetWorkshopStates.None)
		{
		}

		private void RefreshShareStateNonLocalGadgetButtons()
		{
		}

		private GadgetShareStatus GetNonLocalShareState()
		{
			return default(GadgetShareStatus);
		}

		private void ChangeButtonToDesiredStatus(GadgetWorkshopStates state, bool coroutine = true)
		{
		}

		private IEnumerator WaitForSteamStatusChangeCO()
		{
			return null;
		}

		private void StopCoroutines()
		{
		}

		private void DisableAllElementsDuringWorkshopActions()
		{
		}

		private void DisableWorkshopButtons()
		{
		}

		private void DisableGadgetButtons()
		{
		}

		private void DeactivateGadgetStateButtons()
		{
		}

		private void DisableEditGameObjects()
		{
		}

		public void OnDeleteGadget()
		{
		}

		private void OnConfirmDeleteGadget(bool confirm)
		{
		}

		private void Destroy()
		{
		}

		private void ResetEmptyDeskStatus()
		{
		}

		public void OpenRenameDialog()
		{
		}

		public void RenameLocal(string newName)
		{
		}

		private void OnMetadataChange(SerializedGadgetMetaData metadata)
		{
		}

		public void OpenDuplicateDialog()
		{
		}

		public void OnDuplicate(string name)
		{
		}

		private void OnRemoteBecomeLocal(ulong publishedFileId, SerializedGadgetMetaData metadata)
		{
		}

		public void OpenJailbreakDialog()
		{
		}

		public void OnJailbreak(string name)
		{
		}

		private void OpenWriteDescriptionDialog()
		{
		}

		public void OnDescriptionWritten(string newDescription)
		{
		}

		private void OnPublish()
		{
		}

		private void CheckPublishing(List<UIToggle> toggles = null)
		{
		}

		private void OnPublishError()
		{
		}

		private bool CheckPublishToggle()
		{
			return false;
		}

		private void WrongToggles()
		{
		}

		private void OnPublishConfirm()
		{
		}

		private void OnUploadChanges()
		{
		}

		private void OnUnpublish()
		{
		}

		private void OnUnpublishConfirm(bool confirm)
		{
		}

		private void CheckProtectionTag()
		{
		}

		private void OnSubscribe()
		{
		}

		private void OnDownload()
		{
		}

		private void OnDownloadComplete(ulong publishedFildId, bool success, WorkshopController.WorkshopItemDownloadedResult result)
		{
		}

		private void OnUnsubscribe()
		{
		}

		private void OnUnsubscribeConfirm(bool confirm)
		{
		}

		private void DestroyAndUnsubscribe()
		{
		}

		private void OnDestroyed()
		{
		}

		private void Print()
		{
		}

		private void OnGadgetPrinted(float positiveRatio)
		{
		}

		public override void OnSetGadget(Gadget gadget)
		{
		}

		private void CloseAppNoGadget()
		{
		}

		public override void OnMultitoolOpen()
		{
		}

		public override void OnMultitoolClose()
		{
		}

		public override bool NeedGadget()
		{
			return false;
		}

		private void OpenLauncherSettings()
		{
		}

		private void OpenFileFolder()
		{
		}

		private void OpenFileFolder(bool confirm)
		{
		}

		private void ResetCurrentOpenModal()
		{
		}

		private void VoteGadget(bool success, bool like)
		{
		}

		private void OnVoteGadget()
		{
		}

		private void ResetLikeButtons()
		{
		}

		private void ActivateAndColorVotesButtons(bool success, bool? voteStatus)
		{
		}

		private void ManageTags()
		{
		}

		private void ManageTagButtons()
		{
		}

		private void AddShowcaseTag(bool onEdit = true)
		{
		}

		private void AddTag(UIButton tagButton, GadgetTags tag)
		{
		}
	}
}
