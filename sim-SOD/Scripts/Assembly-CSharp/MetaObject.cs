using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MetaObject
{
	public int id;

	public string preset;

	public int owner;

	public int writer;

	public int reciever;

	public string dds;

	public List<Interactable.Passed> passed;

	public Vector3Int n;

	public bool cd;

	public MetaObject(InteractablePreset newPreset, Human newOwner, Human newWriter, Human newReciever, List<Interactable.Passed> newPassed)
	{
	}

	public void Remove()
	{
	}

	public Evidence GetEvidence(bool setPosition = false, Vector3Int nodeCoord = default(Vector3Int))
	{
		return null;
	}

	public InteractablePreset GetPreset()
	{
		return null;
	}
}
