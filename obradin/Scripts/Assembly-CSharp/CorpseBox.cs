using System;
using System.Collections.Generic;
using UnityEngine;

public class CorpseBox : MonoBehaviour
{
	[MomentId]
	public string visitMomentId;

	public Bounds localBounds;

	public bool inceptive;

	private Bounds worldBounds_;

	private bool worldBoundsSet;

	public GameObject focusGo;

	public Vector3 focusBurstPos;

	public VaporMesh vaporMesh;

	public List<GameObject> corpseGos = new List<GameObject>();

	public List<Material> corpseMaterials = new List<Material>();

	private bool alreadyUnlocked_;

	private bool alreadyVisited_;

	[NonSerialized]
	public Color debugColor;

	public Bounds worldBounds
	{
		get
		{
			if (!worldBoundsSet)
			{
				worldBounds_ = Util.ToWorldBounds(localBounds, base.transform.localToWorldMatrix);
				worldBoundsSet = true;
			}
			return worldBounds_;
		}
	}

	public bool alreadyUnlocked
	{
		get
		{
			return alreadyUnlocked_;
		}
	}

	public bool alreadyVisited
	{
		get
		{
			return alreadyVisited_;
		}
	}

	public bool canVisit
	{
		get
		{
			return (alreadyVisited_ || inceptive) && alreadyUnlocked_;
		}
	}

	private void Awake()
	{
		SaveData.MomentDataRo momentDataRo = SaveData.it.momentRo[visitMomentId];
		alreadyUnlocked_ = momentDataRo.unlocked;
		alreadyVisited_ = momentDataRo.visited;
		if (focusGo != null)
		{
			SetCorpseMaterialFocus(false);
			focusGo.SetActive(canVisit);
		}
	}

	public void SetCorpseMaterialFocus(bool on)
	{
		foreach (Material corpseMaterial in corpseMaterials)
		{
			corpseMaterial.SetFloat("_HumanCorpseWatchHand", on ? 1 : 0);
		}
	}
}
