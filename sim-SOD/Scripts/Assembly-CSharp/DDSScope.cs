using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "scope_data", menuName = "Database/DDS Scope")]
public class DDSScope : SoCustomComparison
{
	public enum SpecialCase
	{
		none = 0
	}

	[Serializable]
	public class ContainedScope
	{
		public string name;

		public DDSScope type;
	}

	[Header("Setup")]
	public Color colour;

	[Tooltip("This can be accessed from any scope")]
	public bool isGlobal;

	public SpecialCase specialCase;

	[Header("Content")]
	public List<ContainedScope> containedScopes;

	public List<string> containedValues;
}
