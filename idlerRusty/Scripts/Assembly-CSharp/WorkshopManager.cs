using System.IO;
using Steamworks;
using TMPro;
using UnityEngine;

public class WorkshopManager : MonoBehaviour
{
	protected AppId_t appId = new AppId_t(2666510u);

	public TMP_InputField title;

	public TMP_InputField description;

	private SteamAPICall_t createItemCall;

	private CallResult<CreateItemResult_t> createCallRes;

	private UGCUpdateHandle_t updateHandle;

	private string path;

	private bool klikd;

	private bool properImageSelected;

	protected string m_textPath;

	[SerializeField]
	protected Texture2D m_directoryImage;

	[SerializeField]
	protected Texture2D m_fileImage;

	private void Start()
	{
		klikd = false;
		properImageSelected = true;
	}

	public void TaskOnClick()
	{
		klikd = true;
		SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
	}

	protected void FileSelectedCallback(string path)
	{
		m_textPath = path;
		if (new FileInfo(path).Length > 1000000)
		{
			properImageSelected = false;
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
		}
		else
		{
			properImageSelected = true;
		}
	}

	public void SubmitToWorkshop()
	{
		path = Application.persistentDataPath + "/" + title.text;
		if (File.Exists(path) && properImageSelected)
		{
			if (SteamManager.Initialized)
			{
				SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
				createCallRes = CallResult<CreateItemResult_t>.Create(OnCreateItem);
				SteamAPICall_t hAPICall = SteamUGC.CreateItem(appId, EWorkshopFileType.k_EWorkshopFileTypeFirst);
				createCallRes.Set(hAPICall);
			}
		}
		else
		{
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
		}
	}

	private void OnCreateItem(CreateItemResult_t pCallback, bool bIOFailure)
	{
		if (!pCallback.m_bUserNeedsToAcceptWorkshopLegalAgreement)
		{
			updateHandle = SteamUGC.StartItemUpdate(appId, pCallback.m_nPublishedFileId);
			SteamUGC.SetItemTitle(updateHandle, title.text);
			SteamUGC.SetItemDescription(updateHandle, description.text);
			SteamUGC.SetItemContent(updateHandle, path);
			string pszPreviewFile = "";
			if (m_textPath != null)
			{
				pszPreviewFile = m_textPath.Replace("\\", "/");
			}
			if (File.Exists(pszPreviewFile))
			{
				SteamUGC.SetItemPreview(updateHandle, pszPreviewFile);
			}
			SteamUGC.SetItemVisibility(updateHandle, ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityPublic);
			SteamUGC.SubmitItemUpdate(updateHandle, "New workshop item");
			PublishedFileId_t nPublishedFileId = pCallback.m_nPublishedFileId;
			SteamFriends.ActivateGameOverlayToWebPage("steam://url/CommunityFilePage/" + nPublishedFileId.ToString());
		}
		else
		{
			redirectToLegal();
		}
	}

	public void redirectToLegal()
	{
		SteamFriends.ActivateGameOverlayToWebPage("https://steamcommunity.com/sharedfiles/workshoplegalagreement");
	}
}
