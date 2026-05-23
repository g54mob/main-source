using System.Collections.Generic;
using UnityEngine.UI;

public class FaceChooser
{
	public class Choice
	{
		public string nameId;

		public string faceId;

		public Choice(string nameId_, string faceId_)
		{
			nameId = nameId_;
			faceId = faceId_;
		}
	}

	public delegate void OnFaceChosen(Choice choice);

	private FaceLib faceLib;

	private Book book;

	private BookContent bookContent;

	private string nameId;

	private OnFaceChosen onFaceChosen;

	public FaceChooser(FaceLib faceLib_, Book book_, BookContent bookContent_)
	{
		faceLib = faceLib_;
		book = book_;
		bookContent = bookContent_;
	}

	public void Prep(string nameId_, OnFaceChosen onFaceChosen_)
	{
		nameId = nameId_;
		onFaceChosen = onFaceChosen_;
	}

	public void Refresh(Dictionary<string, PageItem> items, bool forSelectionChanged)
	{
		items["folio-chooseface"].visible = true;
		items["title"].visible = true;
		if (forSelectionChanged)
		{
			BookContent.Selection selection = bookContent.GetSelection();
			if (selection.pageId != null)
			{
				items["info"].visible = true;
				items["face"].sprite = faceLib.Find(selection.itemId).spriteHi;
				items["face"].material = BookContent.GetClueFaceMaterial(book.assets, selection.itemId, Graphic.defaultGraphicMaterial);
			}
			return;
		}
		items["title"].text = Manifest.ApplyGender(Lang.Get("chooseface_title", "$subject", Manifest.it.GetEntName(nameId, nameId, false)), Manifest.it.GetCrewGender(nameId));
		SaveData.FaceData faceData = SaveData.it.FindFaceDataForNameId(nameId);
		Folio folio = items["folio-chooseface"].folio;
		folio.BeginRefresh();
		folio.ShowPin("back");
		for (int i = 0; i < Manifest.it.crewCount; i++)
		{
			string crewId = Manifest.it.GetCrewId(i);
			if ((faceData != null && crewId == faceData.id) || !SaveData.it.faceRo[crewId].markedCorrect)
			{
				folio.ShowPin(crewId);
			}
		}
		if (faceData != null)
		{
			folio.SetFocusPin(faceData.id);
		}
		folio.EndRefresh();
	}

	public void OnPageButtonClick(string actionId)
	{
	}

	public void OnFolioPinClicked(FolioSpec.PinSpec folioPinSpec)
	{
		if (onFaceChosen != null)
		{
			onFaceChosen(new Choice(nameId, folioPinSpec.id));
		}
		else
		{
			book.GoBack(0f);
		}
	}
}
