using UnityEngine;

namespace UMA.CharacterSystem.Examples
{
	public class DNAHandler : MonoBehaviour
	{
		public GameObject SelectionPanel;

		public GameObject DnaPrefab;

		public GameObject LabelPrefab;

		private DnaSetter DNA;

		private DynamicCharacterAvatar Avatar;

		public void Setup(DynamicCharacterAvatar avatar, DnaSetter dna, GameObject panel)
		{
		}

		private void Cleanup()
		{
		}

		public void OnClick()
		{
		}

		private void AddLabel(string theText)
		{
		}
	}
}
