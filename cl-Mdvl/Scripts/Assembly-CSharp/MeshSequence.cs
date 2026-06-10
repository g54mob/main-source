using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MeshSequence
{
	[SerializeField]
	private List<KeyValWarpper> sequence;

	public List<KeyValWarpper> Sequence => sequence;

	public void SetSequence(List<KeyValWarpper> seq)
	{
		sequence = seq;
	}
}
