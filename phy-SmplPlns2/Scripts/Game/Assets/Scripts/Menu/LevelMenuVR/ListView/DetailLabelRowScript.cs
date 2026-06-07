using TMPro;
using UnityEngine;

namespace Assets.Scripts.Menu.LevelMenuVR.ListView
{
	public class DetailLabelRowScript : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _label;

		public TextMeshProUGUI Label => _label;
	}
}
