using SINetworking;
using UnityEngine;

public abstract class Landmark : Writeable
{
	public uint LocalID;

	public BillboardAd Billboard;

	public virtual void CreateBillboard()
	{
	}

	protected virtual void Start()
	{
		InitWritable();
		if (LocalID == 0 && !RoadManager.Instance.IsReferenceNull())
		{
			LocalID = RoadManager.Instance.GetLandmarkID();
		}
	}

	protected virtual void OnDestroy()
	{
		if (RoadManager.Instance != null)
		{
			RoadManager.Instance.Landmarks.Remove(this);
		}
		if (GrassSystem.Instance != null)
		{
			GrassSystem.Instance.InvalidateArea();
		}
		if (TimeOfDay.Instance != null && MakeHole())
		{
			TimeOfDay.Instance.GroundTopDirty = true;
		}
	}

	public void DestroyLandmark()
	{
		DestroyGO();
		if (LocalID != 0)
		{
			NetworkMessaging.SendDestroyLandmark(LocalID, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
	}

	public abstract Rect GetArea();

	public abstract Vector2[] GetNavMesh();

	public abstract Vector2 Center();

	public abstract MeshFilter GetGrassMesh();

	public abstract float GetHeight();

	public virtual bool MakeHole()
	{
		return false;
	}

	public virtual bool AreaIsNavMesh()
	{
		return false;
	}

	public virtual bool RemoveOnBuy()
	{
		return true;
	}

	protected override void SerializeMe(WriteDictionary dictionary, GameReader.NewLoadMode mode, LoadType networkMode, bool checkDIDs)
	{
		dictionary["LocalID"] = LocalID;
		if (Billboard != null && Billboard.ID != 0)
		{
			Billboard.Serialize(dictionary);
		}
	}

	protected override object DeserializeMe(WriteDictionary dictionary, bool loading, LoadType networkMode)
	{
		LocalID = dictionary.Get("LocalID", RoadManager.Instance.GetLandmarkID());
		if (dictionary.Contains("BillboardID"))
		{
			CreateBillboard();
			Billboard.Deserialize(dictionary);
		}
		return this;
	}
}
