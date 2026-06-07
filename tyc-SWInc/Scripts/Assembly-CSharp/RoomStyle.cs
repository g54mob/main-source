using System;
using System.Collections.Generic;

[Serializable]
public class RoomStyle : IStyle
{
	public string StyleName;

	public string OutsideMat;

	public string InsideMat;

	public string FloorMat;

	public string FenceStyle;

	public SVector3 InsideColor;

	public SVector3 OutsideColor;

	public SVector3 FloorColor;

	public SVector3 FenceColor;

	public SVector3 InsideColor2 = new SVector3(1f, 1f, 1f, 1f);

	public SVector3 OutsideColor2 = new SVector3(1f, 1f, 1f, 1f);

	public SVector3 FloorColor2 = new SVector3(1f, 1f, 1f, 1f);

	public bool OutdoorStyle;

	public bool RoofStyle;

	public bool PathStyle;

	public bool Balcony;

	public string ActualFenceStyle
	{
		get
		{
			if (!string.IsNullOrEmpty(FenceStyle))
			{
				return FenceStyle;
			}
			return OutsideMat;
		}
	}

	public SVector3 ActualFenceColor
	{
		get
		{
			if (!string.IsNullOrEmpty(FenceStyle))
			{
				return FenceColor;
			}
			return OutsideColor;
		}
	}

	public string Name
	{
		get
		{
			return StyleName;
		}
	}

	public bool IsInterior()
	{
		if (!OutdoorStyle && !RoofStyle)
		{
			return !PathStyle;
		}
		return false;
	}

	public bool IsExterior()
	{
		if (OutdoorStyle && !RoofStyle)
		{
			return !PathStyle;
		}
		return false;
	}

	public bool IsRoof()
	{
		return RoofStyle;
	}

	public bool IsPath()
	{
		return PathStyle;
	}

	public RoomStyle()
	{
	}

	public RoomStyle(string name, string outsideMat, string insideMat, string floorMat, bool outdoor, SVector3 insideColor, SVector3 outsideColor, SVector3 floorColor)
	{
		StyleName = name;
		if (outdoor)
		{
			FenceStyle = outsideMat;
		}
		else
		{
			OutsideMat = outsideMat;
		}
		InsideMat = insideMat;
		FloorMat = floorMat;
		InsideColor = insideColor;
		if (outdoor)
		{
			FenceColor = outsideColor;
		}
		else
		{
			OutsideColor = outsideColor;
		}
		FloorColor = floorColor;
		OutdoorStyle = outdoor;
	}

	public RoomStyle(string name, string outsideMat, string insideMat, string floorMat, string fence, SVector3 insideColor, SVector3 outsideColor, SVector3 floorColor, SVector3 fenceColor)
	{
		StyleName = name;
		FenceStyle = fence;
		OutsideMat = outsideMat;
		InsideMat = insideMat;
		FloorMat = floorMat;
		InsideColor = insideColor;
		FenceColor = fenceColor;
		OutsideColor = outsideColor;
		FloorColor = floorColor;
		OutdoorStyle = false;
		Balcony = true;
	}

	public RoomStyle(string name, Room room)
	{
		StyleName = name;
		OutdoorStyle = room.Outdoors;
		Balcony = room.IsBalcony;
		FenceStyle = room.FenceStyle;
		OutsideMat = room.OutsideMat;
		InsideMat = room.InsideMat;
		FloorMat = room.FloorMat;
		InsideColor = room.InsideColor;
		OutsideColor = room.OutsideColor;
		FloorColor = room.FloorColor;
		InsideColor2 = room.InsideColor2;
		OutsideColor2 = room.OutsideColor2;
		FloorColor2 = room.FloorColor2;
		FenceColor = room.FenceColor;
	}

	public RoomStyle(string name, Roof roof)
	{
		StyleName = name;
		RoofStyle = true;
		OutsideMat = roof.GableMaterial;
		FloorMat = roof.RoofMaterial;
		OutsideColor = roof.GableColor;
		OutsideColor2 = roof.GableColor2;
		FloorColor = roof.RoofColor;
		FloorColor2 = roof.RoofColor2;
	}

	public RoomStyle(string name, PathObject path)
	{
		StyleName = name;
		PathStyle = true;
		OutsideMat = path.Material;
		OutsideColor = path.MatColor;
		OutsideColor2 = path.MatColor2;
	}

	public bool Match(Selectable s)
	{
		if (PathStyle)
		{
			PathObject pathObject = s as PathObject;
			if (pathObject != null)
			{
				if (pathObject.Material == OutsideMat && SVector3.MatchColor(OutsideColor, pathObject.MatColor))
				{
					return MatchColor(OutsideColor2, pathObject.MatColor2, OutsideMat);
				}
				return false;
			}
			return false;
		}
		if (RoofStyle)
		{
			Roof roof = s as Roof;
			if (roof != null)
			{
				if (roof.GableMaterial == OutsideMat && roof.RoofMaterial == FloorMat && SVector3.MatchColor(OutsideColor, roof.GableColor) && MatchColor(OutsideColor2, roof.GableColor2, OutsideMat) && SVector3.MatchColor(FloorColor, roof.RoofColor))
				{
					return MatchColor(FloorColor2, roof.RoofColor2, FloorMat);
				}
				return false;
			}
			return false;
		}
		Room room = s as Room;
		if (room != null && room.Outdoors == OutdoorStyle && room.IsBalcony == Balcony)
		{
			if (OutdoorStyle || Balcony)
			{
				if (room.FenceStyle == ActualFenceStyle && room.FloorMat == FloorMat && SVector3.MatchColor(ActualFenceColor, room.FenceColor) && SVector3.MatchColor(FloorColor, room.FloorColor))
				{
					return MatchColor(FloorColor2, room.FloorColor2, FloorMat);
				}
				return false;
			}
			if (room.OutsideMat == OutsideMat && room.InsideMat == InsideMat && room.FloorMat == FloorMat && SVector3.MatchColor(OutsideColor, room.OutsideColor) && SVector3.MatchColor(InsideColor, room.InsideColor) && SVector3.MatchColor(FloorColor, room.FloorColor) && MatchColor(OutsideColor2, room.OutsideColor2, OutsideMat) && MatchColor(InsideColor2, room.InsideColor2, InsideMat))
			{
				return MatchColor(FloorColor2, room.FloorColor2, FloorMat);
			}
			return false;
		}
		return false;
	}

	public bool Match(MaterialPreviewer.Mode m)
	{
		switch (m)
		{
		case MaterialPreviewer.Mode.Room:
			if (!PathStyle && !RoofStyle && !OutdoorStyle)
			{
				return !Balcony;
			}
			return false;
		case MaterialPreviewer.Mode.Fence:
			if (!PathStyle && !RoofStyle && OutdoorStyle)
			{
				return !Balcony;
			}
			return false;
		case MaterialPreviewer.Mode.Balcony:
			return Balcony;
		case MaterialPreviewer.Mode.Roof:
			return RoofStyle;
		case MaterialPreviewer.Mode.Path:
			return PathStyle;
		default:
			return false;
		}
	}

	public bool Match(IStyle ss)
	{
		RoomStyle roomStyle = ss as RoomStyle;
		if (roomStyle == null)
		{
			return false;
		}
		if (OutdoorStyle != roomStyle.OutdoorStyle || RoofStyle != roomStyle.RoofStyle || PathStyle != roomStyle.PathStyle)
		{
			return false;
		}
		if (PathStyle)
		{
			if (OutsideMat == roomStyle.OutsideMat && MatchVectors(OutsideColor, roomStyle.OutsideColor))
			{
				return MatchColor(OutsideColor2, roomStyle.OutsideColor2, OutsideMat);
			}
			return false;
		}
		if (RoofStyle)
		{
			if (OutsideMat == roomStyle.OutsideMat && FloorMat == roomStyle.FloorMat && SVector3.MatchColor(OutsideColor, roomStyle.OutsideColor) && SVector3.MatchColor(FloorColor, roomStyle.FloorColor) && MatchColor(OutsideColor2, roomStyle.OutsideColor2, OutsideMat))
			{
				return MatchColor(FloorColor2, roomStyle.FloorColor2, FloorMat);
			}
			return false;
		}
		if (OutdoorStyle || Balcony)
		{
			if (ActualFenceStyle == roomStyle.ActualFenceStyle && FloorMat == roomStyle.FloorMat && SVector3.MatchColor(ActualFenceColor, roomStyle.ActualFenceColor) && SVector3.MatchColor(FloorColor, roomStyle.FloorColor))
			{
				return MatchColor(FloorColor2, roomStyle.FloorColor2, FloorMat);
			}
			return false;
		}
		if (InsideMat == roomStyle.InsideMat && OutsideMat == roomStyle.OutsideMat && FloorMat == roomStyle.FloorMat && SVector3.MatchColor(InsideColor, roomStyle.InsideColor) && SVector3.MatchColor(OutsideColor, roomStyle.OutsideColor) && SVector3.MatchColor(FloorColor, roomStyle.FloorColor) && MatchColor(InsideColor2, roomStyle.InsideColor2, InsideMat) && MatchColor(OutsideColor2, roomStyle.OutsideColor2, OutsideMat))
		{
			return MatchColor(FloorColor2, roomStyle.FloorColor2, FloorMat);
		}
		return false;
	}

	public static bool MatchColor(SVector3 c1, SVector3 c2, string matDep)
	{
		if (RoomMaterialController.AllowSecondaryRecolor(matDep))
		{
			return SVector3.MatchColor(c1, c2);
		}
		return true;
	}

	private bool MatchVectors(SVector3 a, SVector3 b)
	{
		if (a == null)
		{
			if (b == null)
			{
				return true;
			}
			return false;
		}
		if (b == null)
		{
			return false;
		}
		return a.Equals(b);
	}

	public void Apply(Room r, bool exte, bool inte)
	{
		if (PathStyle || RoofStyle || OutdoorStyle || Balcony)
		{
			return;
		}
		if (exte)
		{
			r.OutsideMat = OutsideMat;
			r.OutsideColor = OutsideColor;
			if (RoomMaterialController.AllowSecondaryRecolor(OutsideMat))
			{
				r.OutsideColor2 = OutsideColor2;
			}
		}
		if (inte)
		{
			r.InsideMat = InsideMat;
			r.FloorMat = FloorMat;
			r.InsideColor = InsideColor;
			r.FloorColor = FloorColor;
			if (RoomMaterialController.AllowSecondaryRecolor(InsideMat))
			{
				r.InsideColor2 = InsideColor2;
			}
			if (RoomMaterialController.AllowSecondaryRecolor(FloorMat))
			{
				r.FloorColor2 = FloorColor2;
			}
		}
	}

	public void Apply(Selectable s, List<UndoObject.UndoAction> undos)
	{
		if (PathStyle)
		{
			PathObject pathObject = s as PathObject;
			if (pathObject != null)
			{
				pathObject.Material = OutsideMat;
				pathObject.MatColor = OutsideColor;
				if (RoomMaterialController.AllowSecondaryRecolor(OutsideMat))
				{
					pathObject.MatColor2 = OutsideColor2;
				}
			}
			return;
		}
		if (RoofStyle)
		{
			Roof roof = s as Roof;
			if (roof != null)
			{
				roof.GableMaterial = OutsideMat;
				roof.RoofMaterial = FloorMat;
				roof.GableColor = OutsideColor;
				roof.RoofColor = FloorColor;
				if (RoomMaterialController.AllowSecondaryRecolor(OutsideMat))
				{
					roof.GableColor2 = OutsideColor2;
				}
				if (RoomMaterialController.AllowSecondaryRecolor(FloorMat))
				{
					roof.RoofColor2 = FloorColor2;
				}
			}
			return;
		}
		Room room = s as Room;
		if (!(room != null) || room.Outdoors != OutdoorStyle)
		{
			return;
		}
		if (OutdoorStyle || Balcony)
		{
			room.SetFenceStyle(ActualFenceStyle, undos);
			room.FenceColor = ActualFenceColor;
		}
		else
		{
			room.OutsideMat = OutsideMat;
			room.InsideMat = InsideMat;
			room.OutsideColor = OutsideColor;
			room.InsideColor = InsideColor;
			if (RoomMaterialController.AllowSecondaryRecolor(OutsideMat))
			{
				room.OutsideColor2 = OutsideColor2;
			}
			if (RoomMaterialController.AllowSecondaryRecolor(InsideMat))
			{
				room.InsideColor2 = InsideColor2;
			}
		}
		room.FloorMat = FloorMat;
		room.FloorColor = FloorColor;
		if (RoomMaterialController.AllowSecondaryRecolor(FloorMat))
		{
			room.FloorColor2 = FloorColor2;
		}
	}
}
