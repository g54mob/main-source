using System;
using BestHTTP;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using mattmc3.dotmore.Collections.Generic;

public class ColonyMissionDetail : MonoBehaviour
{
	private class AcceptAllCertificates : CertificateHandler
	{
		protected override bool ValidateCertificate(byte[] certificateData)
		{
			return false;
		}
	}

	public GameObject colonialMissionTagPrefab;

	public ColonySector colonySector;

	public GameObject approvedControls;

	public GameObject approvedSubmitting;

	public GameObject forumButton;

	public GameObject discordButton;

	public Image approveImage;

	public TextMeshProUGUI approvedText;

	public Toggle favoriteToggle;

	public Toggle hiddenToggle;

	public TextMeshProUGUI forumsCountText;

	public TMP_InputField tagInputField;

	public GalaxyMissionPanel gmp;

	public Transform tagContainer;

	public GameObject notifyPane;

	public TextMeshProUGUI notifyPaneText;

	public GameObject notifyButton;

	private string map_guid;

	[NonSerialized]
	public ColonySector.MapEntry mapEntry;

	public ReportPane reportPane;

	public GameObject confirmAddTagPane;

	public TextMeshProUGUI confirmAddTagPaneText;

	private bool _approved;

	private int lastThumb;

	private bool approved
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public void OnEnable()
	{
	}

	public void Refresh(ColonySector.MapEntry me, string mapFile)
	{
	}

	private void RefreshMapDetail()
	{
	}

	private void RefreshTags(OrderedDictionary2<string, int> tags)
	{
	}

	public void OnTagClicked(string mytag)
	{
	}

	public void OnForumClicked()
	{
	}

	public void OnDiscordClicked()
	{
	}

	public void OnApprove()
	{
	}

	public void OnFavorite(bool val)
	{
	}

	public void OnHidden(bool val)
	{
	}

	private void QueryMapDetailBest(string guid, string key)
	{
	}

	private void QueryMapDetailBestCallback(HTTPRequest request, HTTPResponse response)
	{
	}

	private void UpdateMapEntryData(OrderedDictionary2<string, int> tagResults, int thumbChange)
	{
	}

	private void SubmitApprovalBest(string missionGUID, string key, string user, string grp, bool approve)
	{
	}

	private void SubmitApprovalBestCallback(HTTPRequest request, HTTPResponse response)
	{
	}

	public void OnAddTag()
	{
	}

	public void OnConfirmAddTag()
	{
	}

	public void OnVoteState(string tag, int state)
	{
	}

	private void SubmitTagBest(string missionGUID, string key, string user, string grp, string tag, int state)
	{
	}

	private void SubmitTagBestCallback(HTTPRequest request, HTTPResponse response)
	{
	}

	public static void DestroyChildren(Transform transform)
	{
	}
}
