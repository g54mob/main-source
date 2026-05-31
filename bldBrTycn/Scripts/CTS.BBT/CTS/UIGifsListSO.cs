using System.Collections.Generic;
using CTS.Core;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	[CreateAssetMenu(fileName = "UIGifsListSO", menuName = "BBT/UIGifsSO/UIGifsListSO")]
	public class UIGifsListSO : ScriptableObject
	{
		[field: SerializeField]
		public LocalizedString HelpName { get; private set; }

		[field: SerializeField]
		public List<UIGifsSO> ListOfHelp { get; private set; }

		public void Show()
		{
			CTSSingleton<UIHelpingGifs>.Instance.ChooseHelpList(this);
		}
	}
}
