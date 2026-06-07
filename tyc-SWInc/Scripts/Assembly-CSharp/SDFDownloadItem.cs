using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SDFDownloadItem : MonoBehaviour
{
	[NonSerialized]
	public int ID;

	[NonSerialized]
	public string Logo;

	[NonSerialized]
	public string Reports;

	public Image[] ButtonImages;

	public RawImage Thumbnail;

	public Text Name;

	public Text Downloaded;

	public Text Date;

	public Button DownloadButton;

	public Button ApproveButton;

	public Button UnapproveButton;

	public Button DeleteButton;

	public Button ReportButton;

	public GUIToolTipper AmountTip;

	[NonSerialized]
	private Action<string> _onDownload;

	private RenderTexture _texture;

	[NonSerialized]
	private string _authCode;

	[NonSerialized]
	private bool _local;

	public void Init(int id, string name, string logo, string reports, int downloaded, DateTime date, Action<string> onDownload, string authCode, bool local)
	{
		base.gameObject.SetActive(true);
		DownloadButton.interactable = true;
		ID = id;
		Name.text = name;
		Logo = logo;
		Reports = reports;
		_local = local;
		if (local)
		{
			Downloaded.transform.parent.gameObject.SetActive(false);
			Date.gameObject.SetActive(false);
		}
		else
		{
			Downloaded.transform.parent.gameObject.SetActive(true);
			Date.gameObject.SetActive(true);
			if (downloaded >= 1000000)
			{
				Downloaded.text = ((double)downloaded / 1000000.0).ToString("0.#") + "m";
				AmountTip.ToolTipValue = downloaded.ToString();
			}
			else if (downloaded >= 100000)
			{
				Downloaded.text = downloaded / 1000 + "k";
				AmountTip.ToolTipValue = downloaded.ToString();
			}
			else if (downloaded >= 1000)
			{
				Downloaded.text = ((double)downloaded / 1000.0).ToString("0.#") + "k";
				AmountTip.ToolTipValue = downloaded.ToString();
			}
			else
			{
				Downloaded.text = downloaded.ToString();
				AmountTip.ToolTipValue = "";
			}
			Date.text = (DateTime.Now - date).GetString();
		}
		if (_texture == null)
		{
			_texture = new RenderTexture(256, 256, 0, RenderTextureFormat.ARGB32);
			Thumbnail.texture = _texture;
		}
		try
		{
			SDFCreator.ISDFNode iSDFNode = SDFCreator.LoadSDFTree(SDFCreator.GetTreeFromString(Logo));
			GetComponentInChildren<Image>().color = (OnlyWhite(iSDFNode) ? Color.gray : Color.white);
			iSDFNode.Execute(256, _texture, Matrix4x4.identity);
			_onDownload = onDownload;
		}
		catch (Exception)
		{
			base.gameObject.SetActive(false);
		}
		if (local)
		{
			DeleteButton.gameObject.SetActive(true);
		}
		DownloadButton.gameObject.SetActive(authCode == null);
		ApproveButton.gameObject.SetActive(authCode != null);
		UnapproveButton.gameObject.SetActive(authCode != null);
		DeleteButton.gameObject.SetActive(local);
		ReportButton.gameObject.SetActive(authCode == null || reports != null);
		_authCode = authCode;
		FixButtons();
	}

	private void FixButtons()
	{
		Image image = null;
		Image image2 = null;
		for (int i = 0; i < ButtonImages.Length; i++)
		{
			Image image3 = ButtonImages[i];
			if (image3.gameObject.activeSelf)
			{
				if (image2 == null)
				{
					image2 = image3;
					image3.sprite = ObjectDatabase.Instance.GetSprite(false, false, true, false);
				}
				else
				{
					image3.sprite = null;
				}
				image = image3;
			}
		}
		if (image != null)
		{
			if (image == image2)
			{
				image.sprite = ObjectDatabase.Instance.GetSprite(false, true, true, false);
			}
			else
			{
				image.sprite = ObjectDatabase.Instance.GetSprite(false, true, false, false);
			}
		}
	}

	public void Delete()
	{
		GameData.DeleteLogo(Logo);
		base.gameObject.SetActive(false);
	}

	private static bool IsWhite(Color c)
	{
		if (c.r > 0.9f && c.g > 0.9f)
		{
			return c.b > 0.9f;
		}
		return false;
	}

	private static bool OnlyWhite(SDFCreator.ISDFNode node)
	{
		if (node == null)
		{
			return false;
		}
		if (node != null)
		{
			SDFCreator.SDFExport sDFExport;
			if ((sDFExport = node as SDFCreator.SDFExport) != null)
			{
				SDFCreator.SDFExport sDFExport2 = sDFExport;
				if (sDFExport2.Outline > 0f && !IsWhite(sDFExport2.OutlineColor))
				{
					return false;
				}
				if (sDFExport2.Input != sDFExport2.ColorSDF && !IsWhite(sDFExport2.GradientColor))
				{
					return false;
				}
				return IsWhite(sDFExport2.MainColor);
			}
			SDFCreator.SDFMix sDFMix;
			if ((sDFMix = node as SDFCreator.SDFMix) != null)
			{
				SDFCreator.SDFMix sDFMix2 = sDFMix;
				if (!OnlyWhite(sDFMix2.Input1))
				{
					return OnlyWhite(sDFMix2.Input2);
				}
				return true;
			}
		}
		return false;
	}

	public void Approve(bool approve)
	{
		if (!approve || Reports != null)
		{
			StartCoroutine(Approval(approve ? 1 : 2, Name.text));
			base.gameObject.SetActive(false);
			return;
		}
		WindowManager.SpawnInputDialog("New name", "Logo", Name.text, delegate(string x)
		{
			StartCoroutine(Approval(approve ? 1 : 2, x));
			base.gameObject.SetActive(false);
		}, null, 64);
	}

	public void Download()
	{
		DownloadButton.interactable = false;
		_onDownload(Logo);
		if (!_local)
		{
			GameData.SaveLogo(Logo);
			StartCoroutine(MakeHit());
		}
	}

	public void Report()
	{
		if (_authCode != null)
		{
			if (Reports != null)
			{
				WindowManager.Instance.ShowMessageBox(Reports, true, DialogWindow.DialogType.Information);
			}
			return;
		}
		WindowManager.SpawnInputDialog("LogoReportPrompt".Loc(), "LogoReport".Loc(), "", delegate(string x)
		{
			if (!string.IsNullOrWhiteSpace(x))
			{
				ReportButton.gameObject.SetActive(false);
				FixButtons();
				StartCoroutine(Report(x));
			}
		}, null, 128);
	}

	private IEnumerator Report(string report)
	{
		UnityWebRequest unityWebRequest = UnityWebRequest.Post("https://SoftwareInc.Coredumping.com/logo/load.php", new Dictionary<string, string>
		{
			{
				"report",
				report.Replace("\n", ">>").Replace("|", "")
			},
			{
				"id",
				ID.ToString()
			}
		});
		unityWebRequest.SetRequestHeader("User-Agent", "Swinc User Agent");
		yield return unityWebRequest.SendWebRequest();
	}

	private IEnumerator Approval(int status, string name)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>
		{
			{ "auth", _authCode },
			{ "name", name },
			{
				"id",
				ID.ToString()
			}
		};
		if (Reports != null)
		{
			dictionary["HandleReport"] = ((status == 1) ? "1" : "0");
		}
		else
		{
			dictionary["Approve"] = status.ToString();
		}
		UnityWebRequest unityWebRequest = UnityWebRequest.Post("https://SoftwareInc.Coredumping.com/logo/load.php", dictionary);
		unityWebRequest.SetRequestHeader("User-Agent", "Swinc User Agent");
		yield return unityWebRequest.SendWebRequest();
	}

	private IEnumerator MakeHit()
	{
		UnityWebRequest unityWebRequest = UnityWebRequest.Get(string.Format("https://SoftwareInc.Coredumping.com/logo/load.php?hit={0}", ID));
		unityWebRequest.SetRequestHeader("User-Agent", "Swinc User Agent");
		yield return unityWebRequest.SendWebRequest();
	}

	private void OnDestroy()
	{
		if (_texture != null)
		{
			UnityEngine.Object.Destroy(_texture);
		}
	}
}
