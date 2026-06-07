using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ModDetailPanel : MonoBehaviour
{
	public InputField Name;

	public InputField Author;

	public InputField Description;

	public Text ExtraInfo;

	public Text SteamButtonText;

	public RawImage Thumbnail;

	public GameObject SteamSticker;

	public GameObject SteamButton;

	public GameObject SaveButton;

	public bool AllowUpload;

	private Texture2D _mainTexture;

	[NonSerialized]
	private IWorkshopItem Mod;

	private bool _isAsking;

	private void Awake()
	{
		if (Thumbnail != null)
		{
			_mainTexture = new Texture2D(256, 256, TextureFormat.ARGB32, false);
			Thumbnail.texture = _mainTexture;
		}
	}

	private void OnDestroy()
	{
		if (_mainTexture != null)
		{
			UnityEngine.Object.Destroy(_mainTexture);
		}
	}

	private void ActuallySetMod(IWorkshopItem mod)
	{
		_isAsking = false;
		Mod = mod;
		if (mod == null)
		{
			Name.text = "";
			Author.text = "";
			Description.text = "";
			ExtraInfo.text = "";
			Thumbnail.gameObject.SetActive(false);
			SteamButton.SetActive(false);
			SteamSticker.SetActive(false);
			SaveButton.SetActive(false);
			SetEditMode(false);
			return;
		}
		Name.text = (mod.CanUpload ? mod.MetaData.Name : mod.ItemTitle);
		Author.text = mod.MetaData.Author;
		Description.text = mod.MetaData.Description;
		ExtraInfo.text = mod.GetExtraInfo();
		SteamButton.SetActive(false);
		SteamSticker.SetActive(false);
		SaveButton.SetActive(mod.CanUpload);
		string path = Path.Combine(mod.Root, "Thumbnail.png");
		if (File.Exists(path))
		{
			_mainTexture.LoadImage(File.ReadAllBytes(path));
			_mainTexture.Apply();
			Thumbnail.gameObject.SetActive(true);
		}
		else
		{
			Thumbnail.gameObject.SetActive(false);
		}
		SetEditMode(mod.CanUpload);
	}

	public void SetMod(IWorkshopItem mod)
	{
		if (_isAsking || (mod != null && mod == Mod))
		{
			return;
		}
		if (Mod != null && Mod.CanUpload && (!Mod.MetaData.Name.Equals(Name.text) || !Mod.MetaData.Name.Equals(Name.text) || !Mod.MetaData.Name.Equals(Name.text)))
		{
			_isAsking = true;
			WindowManager.Instance.ShowMessageBox("SaveChangesPrompt".Loc(), true, DialogWindow.DialogType.Question, delegate
			{
				SaveChanges();
				ActuallySetMod(mod);
			}, null, delegate
			{
				ActuallySetMod(mod);
			});
		}
		else
		{
			ActuallySetMod(mod);
		}
	}

	private void Update()
	{
		if (CanUpload())
		{
			SteamButton.SetActive(true);
			SteamButtonText.text = (Mod.MetaData.SteamID.HasValue ? "UpdateAction".Loc() : "Upload".Loc());
		}
		else
		{
			SteamButton.SetActive(false);
		}
		SteamSticker.SetActive(Mod != null && Mod.MetaData.SteamID.HasValue);
	}

	private bool CanUpload()
	{
		if (Mod != null && AllowUpload && Mod.CanUpload)
		{
			return SteamManager.Initialized;
		}
		return false;
	}

	private void SetEditMode(bool canEdit)
	{
		Name.interactable = canEdit;
		Author.interactable = canEdit;
		Description.interactable = canEdit;
	}

	public void SaveChanges()
	{
		if (Mod != null && Mod.CanUpload)
		{
			Mod.MetaData.Name = Name.text;
			Mod.MetaData.Author = Author.text;
			Mod.MetaData.Description = Description.text;
			Mod.MetaData.SaveChanges();
		}
	}

	public void UploadClick()
	{
		if (CanUpload())
		{
			SaveChanges();
			bool hasShownError;
			if (Mod.PrepareForUpload(out hasShownError))
			{
				string text = SteamWorkshop.CheckValid(Mod.GetValidExts(), Mod.FolderPath());
				if (text == null)
				{
					SteamWorkshop.Instance.UploadMod(Mod);
				}
				else
				{
					WindowManager.SpawnDialog(text, true, DialogWindow.DialogType.Error);
				}
			}
			else if (!hasShownError)
			{
				WindowManager.SpawnDialog("SteamUploadPrepareError".Loc(), true, DialogWindow.DialogType.Error);
			}
		}
		else
		{
			WindowManager.SpawnDialog("SteamUploadDenied".Loc(), true, DialogWindow.DialogType.Error);
		}
	}
}
