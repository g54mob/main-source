using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "neonsign_data", menuName = "Database/Neon Sign Characters")]
public class NeonSignCharacters : SoCustomComparison
{
	[Serializable]
	public class NeonCharacter
	{
		public string character;

		public GameObject prefab;
	}

	public List<NeonCharacter> characterList;
}
