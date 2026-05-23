using System.Collections.Generic;
using UnityEngine;

namespace Data.Credits
{
	[CreateAssetMenu(fileName = "CreditsSO", menuName = "UI/Credits")]
	public class CreditsSO : ScriptableObject
	{
		[SerializeField]
		private List<CreditsSegmentData> _creditsElements = new List<CreditsSegmentData>();

		public List<CreditsSegmentData> CreditsElements => _creditsElements;
	}
}
