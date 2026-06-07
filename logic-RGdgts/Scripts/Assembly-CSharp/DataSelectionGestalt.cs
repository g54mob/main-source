using System;
using UnityEngine;

[CreateAssetMenu]
public class DataSelectionGestalt : ScriptableObject
{
	[Serializable]
	public class Value
	{
		public int id;

		public string name;
	}

	public bool dynamicValues;

	public bool exposeToLua;

	public Value[] values;

	public DataSelectionGestaltEnum id;

	private void OnValidate()
	{
	}

	private void SetAsInvalid()
	{
	}
}
