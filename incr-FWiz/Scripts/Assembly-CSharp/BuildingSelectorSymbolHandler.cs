using System.Collections.Generic;
using UnityEngine;

public class BuildingSelectorSymbolHandler : MonoBehaviour
{
	public BuildingSelectorSymbol SymbolPrefab;

	private Dictionary<Transform, BuildingSelectorSymbol> _symbols;

	public void Show(List<BuildingSelectorData> selectionData)
	{
	}

	public void Clear()
	{
	}

	public void Wipe()
	{
	}
}
