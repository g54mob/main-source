using System;
using UnityEngine;

[Serializable]
public class TowerBuffStatReplace
{
	[SerializeField]
	private eStatType originalStatType;

	[SerializeField]
	private eStatType newStatType;

	public eStatType OriginalStatType => default(eStatType);

	public eStatType NewStatType => default(eStatType);
}
