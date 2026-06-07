using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveFileItem : MonoBehaviour, IComparable<SaveFileItem>
{
	public Texture SaveError;

	public RawImage Thumbnail;

	public RawImage CLogo;

	public Text MainLabel;

	public Text SubLabel1;

	public Text SubLabel2;

	[NonSerialized]
	public SaveGame Save;

	public Toggle Toggle;

	public RectTransform rect;

	public GameObject SteamIcon;

	public GameObject DeleteIcon;

	public GameObject HighlightObject;

	public const int LogoSize = 32;

	public void Highlight(bool highlight)
	{
		HighlightObject.SetActive(highlight);
	}

	public static void GetRentMeta(float[] meta, out float rentArea, out float rentPrice, out float rentableArea)
	{
		int num = 0;
		int num2 = -1;
		rentArea = 0f;
		rentPrice = 0f;
		rentableArea = 0f;
		for (int i = 2; i < meta.Length; i++)
		{
			if (meta[i] == -1f)
			{
				num++;
				num2 = -1;
				continue;
			}
			if (num == 2)
			{
				rentableArea = meta[i];
				break;
			}
			rentArea += meta[i];
			rentPrice += BuildController.GetRoomCost(0f, meta[i], num == 1, false, num2, false, true, false);
			num2++;
		}
	}

	public void RefreshRentCost()
	{
		if (Save != null && Save.BuildingOnly)
		{
			float[] buildMeta = Save.GetBuildMeta();
			if (buildMeta == null || buildMeta.Length < 4)
			{
				SubLabel1.text = "Error".Loc();
			}
			else if (buildMeta[0] == 0f)
			{
				SubLabel1.text = string.Format("{0}\n{4}: {1}\n{5}: {3}\n{6}: {2}", "Forrent".Loc(), buildMeta[1].ToString("N0") + " m2", BuildController.GetRoomCost(0f, buildMeta[1], false, false, 0, false, true, false).Currency(), buildMeta[3].ToString("N0") + " m2", "Leasedarea".Loc(), "Buildingarea".Loc(), "Cost".Loc());
			}
			else if (buildMeta[0] == 2f)
			{
				float rentArea;
				float rentPrice;
				float rentableArea;
				GetRentMeta(buildMeta, out rentArea, out rentPrice, out rentableArea);
				SubLabel1.text = string.Format("{0}\n{4}: {1}\n{5}: {3}\n{6}: {2}", "Forrent".Loc(), rentArea.ToString("N0") + " m2", rentPrice.Currency(), rentableArea.ToString("N0") + " m2", "Leasedarea".Loc(), "Buildingarea".Loc(), "Cost".Loc());
			}
		}
	}

	public void Init(SaveGame save, Texture2D thumbnail, List<Texture2D> logoList)
	{
		Save = save;
		MainLabel.text = Save.ActualName;
		SteamIcon.SetActive(Save.GetSteamID().HasValue);
		DeleteIcon.SetActive(!Save.Readonly);
		if (Save.BuildingOnly)
		{
			float[] buildMeta = Save.GetBuildMeta();
			if (buildMeta == null || buildMeta.Length < 4)
			{
				SubLabel1.text = "Error".Loc();
			}
			else if (buildMeta[0] == 0f)
			{
				SubLabel1.text = string.Format("{0}\n{4}: {1}\n{5}: {3}\n{6}: {2}", "Forrent".Loc(), buildMeta[1].ToString("N0") + " m2", BuildController.GetRoomCost(0f, buildMeta[1], false, false, 0, false, true, false).Currency(), buildMeta[3].ToString("N0") + " m2", "Leasedarea".Loc(), "Buildingarea".Loc(), "Cost".Loc());
			}
			else if (buildMeta[0] == 2f)
			{
				float rentArea;
				float rentPrice;
				float rentableArea;
				GetRentMeta(buildMeta, out rentArea, out rentPrice, out rentableArea);
				SubLabel1.text = string.Format("{0}\n{4}: {1}\n{5}: {3}\n{6}: {2}", "Forrent".Loc(), rentArea.ToString("N0") + " m2", rentPrice.Currency(), rentableArea.ToString("N0") + " m2", "Leasedarea".Loc(), "Buildingarea".Loc(), "Cost".Loc());
			}
			else
			{
				SubLabel1.text = string.Format("{0}\n{4}: {1}\n{5}: {3}\n{6}: {2}", "Forsale".Loc(), buildMeta[1].ToString("N0") + " m2", buildMeta[2].Currency(), buildMeta[3].ToString("N0") + " m2", "Buildingarea".Loc(), "Plotarea".Loc(), "Cost".Loc());
			}
			SubLabel2.text = (Save.Readonly ? "" : Save.FileSize.ByteSize());
		}
		else
		{
			SubLabel1.text = string.Format("{0}\n{4}: {1}\n{5}: {2}\n{6}: {3}", Save.RealTime.ToString(Options.AMPM ? "dd MMM yyyy hh:mm tt" : "dd MMM yyyy HH:mm"), Save.CompanyName, Save.Money.Currency(), Save.Products, "Company".Loc(), "Money".Loc(), "Products".Loc());
			SubLabel2.text = string.Format("{0}\n{4}: {1}\n{5}: {2}\n{6}: {3}", Save.FileSize.ByteSize(), Save.InGameTime.ToCompactString(), Save.Employees, Save.DaysPerMonth, "Date".Loc(), "Employees".Loc(), "DaysPerMonth".Loc());
		}
		if (thumbnail != null)
		{
			Thumbnail.texture = thumbnail;
		}
		Texture2D texture2D = DeInitLogo();
		if (texture2D != null)
		{
			logoList.Add(texture2D);
		}
		InitLogo(logoList);
	}

	public void Delete()
	{
		DialogWindow diag = WindowManager.SpawnDialog();
		diag.Show("DeleteSaveConf".Loc(), false, DialogWindow.DialogType.Warning, new KeyValuePair<string, Action>("Yes", delegate
		{
			SaveGameManager.Instance.DeleteSave(Save, true);
			diag.Window.Close();
		}), new KeyValuePair<string, Action>("No", delegate
		{
			diag.Window.Close();
		}));
	}

	public bool InitTexture(Texture2D tex)
	{
		Thumbnail.texture = SaveError;
		if (Save.Broken)
		{
			return false;
		}
		if (!Save.BuildingOnly && Versioning.DisectVersionString(Save.GameVersion) < SaveGameManager.MinimumSupportedSaveAlpha)
		{
			return false;
		}
		Thumbnail.texture = tex;
		MainLabel.text = Save.ActualName;
		GameObject gameObject = MinimapThumbnailMaker.Instance.MinimapMaker.CreateMap(Save.Map, false);
		MinimapThumbnailMaker.Instance.RenderObject(gameObject, MinimapThumbnailMaker.ThumbSize.Small, tex);
		MeshFilter[] componentsInChildren = gameObject.GetComponentsInChildren<MeshFilter>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			UnityEngine.Object.Destroy(componentsInChildren[i].sharedMesh);
		}
		UnityEngine.Object.Destroy(gameObject);
		return true;
	}

	public void InitLogo(List<Texture2D> t)
	{
		if (Save.Logo != null)
		{
			Texture2D texture2D;
			if (t.Count == 0)
			{
				texture2D = new Texture2D(32, 32, TextureFormat.ARGB32, false);
			}
			else
			{
				texture2D = t.Last();
				t.RemoveAt(t.Count - 1);
			}
			CLogo.texture = texture2D;
			CLogo.gameObject.SetActive(true);
			RenderTexture temporary = RenderTexture.GetTemporary(32, 32, 0, RenderTextureFormat.ARGB32);
			SDFCreator.LoadSDFTree(Save.Logo).Execute(32, temporary, Matrix4x4.identity);
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = temporary;
			texture2D.ReadPixels(new Rect(0f, 0f, 32f, 32f), 0, 0, false);
			texture2D.Apply(false);
			RenderTexture.active = active;
			RenderTexture.ReleaseTemporary(temporary);
		}
		else
		{
			CLogo.texture = null;
			CLogo.gameObject.SetActive(false);
		}
	}

	public Texture2D DeInitLogo()
	{
		Texture2D result = CLogo.texture as Texture2D;
		CLogo.texture = null;
		CLogo.gameObject.SetActive(false);
		return result;
	}

	public Texture2D DeInitTex()
	{
		Texture2D texture2D = Thumbnail.texture as Texture2D;
		Thumbnail.texture = SaveError;
		if (!(texture2D != null) || !texture2D.name.Equals("SaveGameThumb"))
		{
			return null;
		}
		return texture2D;
	}

	public int CompareTo(SaveFileItem other)
	{
		if (other == null)
		{
			return -1;
		}
		if (Save == null)
		{
			if (other.Save != null)
			{
				return 1;
			}
			return 0;
		}
		return Save.CompareTo(other.Save);
	}
}
