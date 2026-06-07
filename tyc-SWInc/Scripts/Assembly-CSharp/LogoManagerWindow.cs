using System;
using System.Collections.Generic;
using SINetworking;
using UnityEngine;
using UnityEngine.UI;

public class LogoManagerWindow : MonoBehaviour
{
	public GUIWindow Window;

	public RawImage SelLogo;

	public Button[] PrevLogo;

	public Text[] PrevLogoText;

	public RawImage[] PrevLogoThumb;

	public Button Next;

	public Button Prev;

	public SimpleLogoEditorWindow LogoWindow;

	public SDFDownloader Downloader;

	[NonSerialized]
	private Company _selCompany;

	private int _logoOffset;

	private int _selLogo;

	public byte[] SelectedLogo
	{
		get
		{
			if (_selLogo != -1)
			{
				return _selCompany.PreviousLogos[_selLogo].Value;
			}
			return _selCompany.Logo;
		}
	}

	public void Show(Company c)
	{
		Init();
		_selCompany = c;
		_logoOffset = -1;
		_selLogo = -1;
		UpdateSubLogos();
		UpdateSelectedLogo();
		Window.OnClose = DeInit;
		Window.Show();
		Downloader.ShowDefault();
		Downloader.OnLogoDownload = delegate(string x)
		{
			OnSave(SDFCreator.GetTreeFromString(x));
		};
	}

	private void Init()
	{
		if (SelLogo.texture == null)
		{
			SelLogo.texture = new RenderTexture(256, 256, 0, RenderTextureFormat.ARGB32);
			for (int i = 0; i < PrevLogoThumb.Length; i++)
			{
				PrevLogoThumb[i].texture = new RenderTexture(64, 64, 0, RenderTextureFormat.ARGB32);
			}
		}
	}

	private void DeInit()
	{
		if (SelLogo.texture != null)
		{
			UnityEngine.Object.Destroy(SelLogo.texture);
			SelLogo.texture = null;
		}
		for (int i = 0; i < PrevLogoThumb.Length; i++)
		{
			if (PrevLogoThumb[i].texture != null)
			{
				UnityEngine.Object.Destroy(PrevLogoThumb[i].texture);
				PrevLogoThumb[i].texture = null;
			}
		}
	}

	public void ChangeOffset(int off)
	{
		_logoOffset += off;
		UpdateSubLogos();
	}

	public void UpdateSubLogos()
	{
		if (_selCompany.PreviousLogos == null)
		{
			for (int i = 0; i < PrevLogo.Length; i++)
			{
				PrevLogo[i].gameObject.SetActive(false);
			}
			Prev.interactable = false;
			Next.interactable = false;
			return;
		}
		for (int j = 0; j < PrevLogo.Length; j++)
		{
			int num = _logoOffset + j;
			if (num < _selCompany.PreviousLogos.Count)
			{
				PrevLogo[j].gameObject.SetActive(true);
				if (num == -1)
				{
					PrevLogoText[j].text = SDateTime.Now().RealYear.ToString();
					SDFCreator.LoadSDFTree(_selCompany.Logo).Execute(64, (RenderTexture)PrevLogoThumb[j].texture, Matrix4x4.identity);
				}
				else
				{
					KeyValuePair<int, byte[]> keyValuePair = _selCompany.PreviousLogos[num];
					PrevLogoText[j].text = keyValuePair.Key.ToString();
					SDFCreator.LoadSDFTree(keyValuePair.Value).Execute(64, (RenderTexture)PrevLogoThumb[j].texture, Matrix4x4.identity);
				}
			}
			else
			{
				PrevLogo[j].gameObject.SetActive(false);
			}
		}
		Next.interactable = _logoOffset + PrevLogo.Length < _selCompany.PreviousLogos.Count;
		Prev.interactable = _logoOffset > -1;
	}

	public void UpdateSelectedLogo()
	{
		if (_selLogo == -1)
		{
			SDFCreator.LoadSDFTree(_selCompany.Logo).Execute(256, (RenderTexture)SelLogo.texture, Matrix4x4.identity);
		}
		else
		{
			SDFCreator.LoadSDFTree(_selCompany.PreviousLogos[_selLogo].Value).Execute(256, (RenderTexture)SelLogo.texture, Matrix4x4.identity);
		}
	}

	private void OnDestroy()
	{
		DeInit();
	}

	public void SetLogo(int logo)
	{
		_selLogo = _logoOffset + logo;
		UpdateSelectedLogo();
	}

	public void EditLogo()
	{
		if (Input.GetKey(KeyCode.LeftShift))
		{
			LogoWindow.MainEditor.AdvancedEditor.Show(SelectedLogo, OnSave);
			LogoWindow.MainEditor.AdvancedEditor.Window.SetParentWindow(Window);
		}
		else
		{
			LogoWindow.Show(SelectedLogo, OnSave);
			LogoWindow.Window.SetParentWindow(Window);
		}
	}

	private void OnSave(byte[] x)
	{
		if (_selCompany.PreviousLogos == null)
		{
			_selCompany.PreviousLogos = new List<KeyValuePair<int, byte[]>>();
		}
		_selCompany.PreviousLogos.Insert(0, new KeyValuePair<int, byte[]>(SDateTime.Now().RealYear, _selCompany.Logo));
		_selCompany.Logo = x;
		LogoController.Instance.DirtyLogo(_selCompany);
		NetworkMessaging.SendUpdateCompanyLogo(_selCompany.ID, x, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		_logoOffset = -1;
		_selLogo = -1;
		UpdateSubLogos();
		UpdateSelectedLogo();
	}
}
