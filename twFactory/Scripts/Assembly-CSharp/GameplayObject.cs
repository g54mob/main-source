using System.Collections.Generic;
using UnityEngine;

public class GameplayObject : MonoBehaviour, ISavable
{
	[SerializeField]
	private GameObject model;

	[SerializeField]
	[Savable("objectData", true, false)]
	protected GameplayObjectData objectData;

	public GameplayObjectData ObjectData => objectData;

	public GameObject Model => model;

	public virtual void OnSave()
	{
	}

	public virtual void OnPreLoad()
	{
	}

	public virtual void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
	}
}
