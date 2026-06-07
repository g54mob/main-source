using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TetrisStarterSet
{
	[SerializeField]
	private string note;

	[SerializeField]
	private bool canShowBeforeTutorial;

	public int weight;

	public List<eItemType> list_TetrisTypes;

	public bool CanShowBeforeTutorial => false;
}
