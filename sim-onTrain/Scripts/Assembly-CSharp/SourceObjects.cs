using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SourceObjects
{
	public string ID;

	public GameObject SourcePrefab;

	public int MinNumberOfObject;

	public bool AllowGrow = true;

	public bool AutoDestroy = true;

	public List<GameObject> clones;
}
