using UnityEngine;

namespace Restory.Data.SaveLoad
{
	[CreateAssetMenu(fileName = "SaveIssuesMessages", menuName = "Restory/Data/SaveSystem/Create SaveIssuesMessages")]
	public class SaveIssuesMessages : ScriptableObject
	{
		[SerializeField]
		private FallbackText notEnoughDiskSpace;

		public FallbackText NotEnoughDiskSpace => notEnoughDiskSpace;
	}
}
