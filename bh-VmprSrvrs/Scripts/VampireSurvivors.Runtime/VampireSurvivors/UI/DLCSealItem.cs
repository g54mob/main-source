using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;

namespace VampireSurvivors.UI
{
	public class DLCSealItem : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _Name;

		[SerializeField]
		private Image _ToggleIcon;

		private bool _isBanished;

		private MegaSealPanel _megaSealPanel;

		private ContentGroupType _type;

		public void SetDLCData(MegaSealPanel seal, ContentGroupType t, bool isBanished)
		{
		}

		public void RefreshText()
		{
		}

		private void Toggle()
		{
		}

		private void ApplySetting()
		{
		}

		public void SetUnBanished()
		{
		}
	}
}
