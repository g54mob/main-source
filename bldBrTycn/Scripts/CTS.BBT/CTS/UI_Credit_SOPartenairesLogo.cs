using System.Collections.Generic;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "CreditPartenaire", menuName = "Sheet/PartenaireData")]
	public class UI_Credit_SOPartenairesLogo : ScriptableObject
	{
		[field: SerializeField]
		public List<CreditDataPartenaineStruct> DataPartenaires { get; private set; }
	}
}
