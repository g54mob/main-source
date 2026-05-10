using System;
using UnityEngine;

[Serializable]
public struct CellGroup
{
	[SerializeField]
	private ConstructionCell[] _group;

	public ConstructionCell[] Group => _group;
}
