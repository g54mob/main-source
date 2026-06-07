using System;
using UnityEngine;
using UnityEngine.UI;

public class MaterialPreviewButton : MonoBehaviour
{
	public Image ToggleImg;

	public Image HelperColor;

	public Button ClickButton;

	public Button DeleteButton;

	public GameObject AdditionImg;

	public RawImage Thumbnail;

	public Text Caption;

	public bool NeedsRender;

	[NonSerialized]
	public string[] Mats = new string[3];

	[NonSerialized]
	public Color[] Colors = new Color[6];

	[NonSerialized]
	public int AtlasIndex;

	public void SetStyle(IStyle style, Selectable subject, int atlas)
	{
		RoomStyle roomStyle = style as RoomStyle;
		if (roomStyle != null)
		{
			if (roomStyle.PathStyle)
			{
				SetPathStyle(roomStyle);
			}
			else if (roomStyle.RoofStyle)
			{
				SetRoofStyle(roomStyle);
			}
			else if (roomStyle.OutdoorStyle || roomStyle.Balcony)
			{
				SetFenceStyle(roomStyle);
			}
			else
			{
				SetRoomStyle(roomStyle);
			}
		}
		else
		{
			FurnitureStyle furnitureStyle = style as FurnitureStyle;
			if (furnitureStyle != null)
			{
				SetFurniture(subject as WallSnap, furnitureStyle, atlas);
			}
		}
		Caption.text = style.Name;
	}

	public void SetRoomStyle(RoomStyle r)
	{
		Mats[0] = r.FloorMat;
		Mats[1] = r.InsideMat;
		Mats[2] = r.OutsideMat;
		Colors[0] = r.FloorColor;
		SVector3 c;
		Colors[1] = (RoomMaterialController.GetMaterialForcedSecondarySVec(r.FloorMat, out c) ? c : r.FloorColor2);
		Colors[2] = r.InsideColor;
		SVector3 c2;
		Colors[3] = (RoomMaterialController.GetMaterialForcedSecondarySVec(r.InsideMat, out c2) ? c2 : r.InsideColor2);
		Colors[4] = r.OutsideColor;
		SVector3 c3;
		Colors[5] = (RoomMaterialController.GetMaterialForcedSecondarySVec(r.OutsideMat, out c3) ? c3 : r.OutsideColor2);
		HelperColor.gameObject.SetActive(false);
	}

	public void SetFenceStyle(RoomStyle r)
	{
		Mats[0] = r.FloorMat;
		Mats[1] = r.ActualFenceStyle;
		Colors[0] = r.FloorColor;
		SVector3 c;
		Colors[1] = (RoomMaterialController.GetMaterialForcedSecondarySVec(r.FloorMat, out c) ? c : r.FloorColor2);
		Colors[2] = r.ActualFenceColor;
		Colors[3] = Color.clear;
		HelperColor.gameObject.SetActive(false);
	}

	public void SetRoofStyle(RoomStyle r)
	{
		Mats[0] = r.FloorMat;
		Mats[1] = r.OutsideMat;
		Colors[0] = r.FloorColor;
		SVector3 c;
		Colors[1] = (RoomMaterialController.GetMaterialForcedSecondarySVec(r.FloorMat, out c) ? c : r.FloorColor2);
		Colors[2] = r.OutsideColor;
		SVector3 c2;
		Colors[3] = (RoomMaterialController.GetMaterialForcedSecondarySVec(r.OutsideMat, out c2) ? c2 : r.OutsideColor2);
		HelperColor.gameObject.SetActive(false);
	}

	public void SetPathStyle(RoomStyle r)
	{
		Mats[0] = r.OutsideMat;
		Colors[0] = r.OutsideColor;
		SVector3 c;
		Colors[1] = (RoomMaterialController.GetMaterialForcedSecondarySVec(r.OutsideMat, out c) ? c : r.OutsideColor2);
		HelperColor.gameObject.SetActive(false);
	}

	public void SetFurniture(WallSnap furn, FurnitureStyle f, int atlas)
	{
		AtlasIndex = ((f.AtlasIndex > -1) ? f.AtlasIndex : atlas);
		Colors[0] = f.Color1 ?? ((SVector3)furn.ColorPrimaryDefault);
		Colors[1] = f.Color2 ?? ((SVector3)furn.ColorSecondaryDefault);
		Colors[2] = f.Color3 ?? ((SVector3)furn.ColorTertiaryDefault);
		Mats[0] = f.Replacement1 ?? furn.GetReplacement(0);
		Mats[1] = f.Replacement2 ?? furn.GetReplacement(1);
		UserImageFrame component;
		Mats[2] = f.Replacement2 ?? (furn.TryGetComponent<UserImageFrame>(out component) ? component.ImageName : null);
		if (furn.ColorableLights.Count > 0 && !furn.LightPrimary)
		{
			HelperColor.gameObject.SetActive(true);
			HelperColor.color = f.Color3 ?? ((SVector3)furn.ColorTertiaryDefault);
		}
		else
		{
			HelperColor.gameObject.SetActive(false);
		}
	}
}
