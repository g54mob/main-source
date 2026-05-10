using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_Credit_WriteTeamGroup : MonoBehaviour
	{
		[field: SerializeField]
		public TextMeshProUGUI TeamText { get; private set; }

		[field: SerializeField]
		public GameObject PrefabNewWorker { get; private set; }

		[field: SerializeField]
		public GameObject ParentJobAndWorker { get; private set; }

		[field: SerializeField]
		public Image ImageJob { get; private set; }
	}
}
