using System.Collections.Generic;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "GifsOrderSO", menuName = "BBT/UIGifsSO/GifsOrderSO")]
	public class HelpGifsOdrerSO : ScriptableObject
	{
		[field: SerializeField]
		public List<UIGifsListSO> HelpGifsList { get; private set; }
	}
}
