using System;
using UnityEngine;

public class ForcedPrefabElement : MonoBehaviour
{
	[NonSerialized]
	public bool Room;

	[NonSerialized]
	public bool Fence;

	[NonSerialized]
	public string Furniture;

	[NonSerialized]
	public string Segment;

	[NonSerialized]
	private MeshRenderer[] _rends;

	private void Start()
	{
		_rends = GetComponentsInChildren<MeshRenderer>();
	}

	public void Highlight(bool enable)
	{
		_rends.ForEachEnum(delegate(MeshRenderer x)
		{
			x.sharedMaterial = (enable ? BuildController.Instance.ForcedPrefabMaterialHighlight : BuildController.Instance.ForcedPrefabMaterial);
		});
	}

	public void Click()
	{
		if (Room)
		{
			HUD.Instance.BuildMode = true;
			if (HUD.Instance.BuildMode)
			{
				BuildController.Instance.ActivateBuildMode(Fence);
			}
		}
		else if (Furniture != null)
		{
			HUD.Instance.BuildMode = true;
			if (HUD.Instance.BuildMode)
			{
				HUD.Instance.SearchBar.text = Furniture;
			}
		}
		else if (Segment != null)
		{
			HUD.Instance.BuildMode = true;
			if (HUD.Instance.BuildMode)
			{
				HUD.Instance.SearchBar.text = Segment;
			}
		}
	}
}
