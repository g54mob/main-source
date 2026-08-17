using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsUI : MonoBehaviour
{
	public List<StatContainer> statContainers;

	public void SetCharacter(CharacterData data)
	{
	}

	private void OnValidate()
	{
		List<StatContainer> list = new List<StatContainer>();
		statContainers = list;
		StatContainer[] componentsInChildren = GetComponentsInChildren<StatContainer>();
		((List<object>)(object)statContainers).AddRange((IEnumerable<object>)componentsInChildren);
	}
}
