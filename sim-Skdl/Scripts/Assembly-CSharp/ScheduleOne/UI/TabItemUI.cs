using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI
{
	public class TabItemUI : MonoBehaviour
	{
		[SerializeField]
		[Header("Components")]
		private ButtonUI _button;

		[SerializeField]
		private Text _label;

		[SerializeField]
		private GameObject _content;

		[Header("Additionals")]
		[SerializeField]
		private GameObject _indicator;

		[SerializeField]
		private Text _indicatorLabel;

		public ButtonUI Button => null;

		public Text Label => null;

		public GameObject Content => null;

		public void SetIndicator(string text)
		{
		}

		public void HideIndicator()
		{
		}
	}
}
