using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathObject : Selectable
{
	public MeshRenderer MeshRend;

	public MeshFilter MeshComp;

	[NonSerialized]
	public HashSet<PathController.PathPoint> Path = new HashSet<PathController.PathPoint>();

	[SerializeField]
	public string _material = "BrickPath";

	[NonSerialized]
	private int _colorID = -1;

	[SerializeField]
	private Color _matColor = Color.grey;

	[SerializeField]
	private Color _matColor2 = Color.grey;

	public bool Dirty;

	public static string[] Actions = new string[3] { "Path Color", "Destroy Path", "Path material" };

	public Color MatColor
	{
		get
		{
			return _matColor;
		}
		set
		{
			_matColor = value;
			foreach (PathController.PathPoint item in Path)
			{
				item.Color = value;
			}
			if (_colorID >= 0)
			{
				RoomMaterialController.WriteColor(_colorID, _matColor);
			}
		}
	}

	public Color MatColor2
	{
		get
		{
			return _matColor2;
		}
		set
		{
			_matColor2 = value;
			foreach (PathController.PathPoint item in Path)
			{
				item.Color = value;
			}
			if (_colorID >= 0)
			{
				RoomMaterialController.WriteColor(_colorID + 1, _matColor2);
			}
		}
	}

	public int ColorID
	{
		get
		{
			if (_colorID == -1)
			{
				_colorID = RoomMaterialController.Take2Colors();
			}
			return _colorID;
		}
	}

	public string Material
	{
		get
		{
			return _material;
		}
		set
		{
			foreach (PathController.PathPoint item in Path)
			{
				item.Material = value;
			}
			if (value.Equals(_material))
			{
				return;
			}
			_material = value;
			Color? materialForcedSecondaryColor = RoomMaterialController.GetMaterialForcedSecondaryColor(value);
			if (materialForcedSecondaryColor.HasValue)
			{
				MatColor2 = materialForcedSecondaryColor.Value;
			}
			if (MeshComp.sharedMesh != null)
			{
				Vector2[] uv = MeshComp.sharedMesh.uv2;
				MeshComp.sharedMesh.uv2 = uv.SelectInPlace((Vector2 x) => new Vector2(x.x, RoomMaterialController.GetMaterialID(_material)));
			}
		}
	}

	public override int GetFloor()
	{
		return 0;
	}

	public void SetMesh(Mesh mesh)
	{
		if (MeshComp.sharedMesh != null)
		{
			UnityEngine.Object.Destroy(MeshComp.sharedMesh);
		}
		MeshComp.sharedMesh = mesh;
	}

	private void Start()
	{
		RoomMaterialController.WriteColor(ColorID, MatColor);
		RoomMaterialController.WriteColor(ColorID + 1, MatColor2);
		MeshRend.sharedMaterial = RoomMaterialController.Instance.MainMat;
	}

	private void OnDestroy()
	{
		if (MeshComp.sharedMesh != null)
		{
			UnityEngine.Object.Destroy(MeshComp.sharedMesh);
		}
		if (!GameSettings.Instance.IsReferenceNull())
		{
			GameSettings.Instance.sRoomManager.PathController.AllPathObjects.Remove(this);
			if (RoomMaterialController.Instance != null)
			{
				RoomMaterialController.Free2Colors(ColorID);
			}
		}
	}

	public override Vector2 GetFlatPos()
	{
		return Path.Select((PathController.PathPoint x) => x.Point).GetBounds().center;
	}

	public override string[] GetActions()
	{
		return Actions;
	}

	public override string Description()
	{
		return "Path";
	}

	public override string GetInfo()
	{
		return "";
	}

	public override bool IsSelectionRestricted()
	{
		if (GameSettings.Instance.RentMode)
		{
			return !GameSettings.Instance.EditMode;
		}
		return false;
	}

	public override bool IsSelectableInView()
	{
		return GameSettings.Instance.ActiveFloor >= 0;
	}

	public override IEnumerable<Selectable> GetRelated()
	{
		foreach (PathController.PathPoint item in Path)
		{
			foreach (RoomSegment connectedSegment in item.GetConnectedSegments())
			{
				yield return connectedSegment;
			}
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.cyan;
		foreach (PathController.PathPoint item in Path)
		{
			foreach (KeyValuePair<PathController.PathPoint, float> connection in item.Connections)
			{
				Gizmos.DrawLine(item.Point.ToVector3(0f), connection.Key.Point.ToVector3(0f));
			}
		}
		Gizmos.color = Color.white;
	}

	public override IStyle GetStyle()
	{
		return new RoomStyle("", this);
	}
}
