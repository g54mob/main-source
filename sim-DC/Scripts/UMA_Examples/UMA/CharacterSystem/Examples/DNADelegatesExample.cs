using UnityEngine;

namespace UMA.CharacterSystem.Examples
{
	public class DNADelegatesExample : MonoBehaviour
	{
		public DynamicCharacterAvatar targetAvatar;

		public DNAPanel delegateDNAEditor;

		private RaceData lastRace;

		private Color startingSkinColor;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public void CheckRaceChange(UMAData umaData)
		{
		}

		public void SetUpDNADelegates(UMAData umaData)
		{
		}

		public void ChangeCharacterRedness(string affectedDNA, float currentDNAVal)
		{
		}

		public void ChangeCharacterGreenness(string affectedDNA, float currentDNAVal)
		{
		}

		public void ChangeCharacterBlueness(string affectedDNA, float currentDNAVal)
		{
		}
	}
}
