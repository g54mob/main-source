using UnityEngine;

namespace Mirror.Examples.CharacterSelection
{
	public class CharacterData : MonoBehaviour
	{
		public GameObject[] characterPrefabs;

		public GameObject[] previewPrefabs;

		public string[] characterTitles;

		public static CharacterData characterDataSingleton { get; private set; }

		public void Awake()
		{
			characterDataSingleton = this;
		}
	}
}
