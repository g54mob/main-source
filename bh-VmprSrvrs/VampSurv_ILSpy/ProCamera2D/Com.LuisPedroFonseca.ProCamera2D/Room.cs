using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D;

[Serializable]
public class Room
{
	public string ID;

	public Rect Dimensions;

	public float TransitionDuration;

	public EaseType TransitionEaseType;

	public bool ScaleCameraToFit;

	public bool Zoom;

	public float ZoomScale;

	public int InternalID;

	public Room(Room otherRoom)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998C30C]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		ID = "";
		Dimensions = otherRoom.Dimensions;
		TransitionDuration = otherRoom.TransitionDuration;
		TransitionEaseType = otherRoom.TransitionEaseType;
		ScaleCameraToFit = otherRoom.ScaleCameraToFit;
		Zoom = otherRoom.Zoom;
		ZoomScale = otherRoom.ZoomScale;
	}

	public Room()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998C30D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		ID = "";
	}
}
