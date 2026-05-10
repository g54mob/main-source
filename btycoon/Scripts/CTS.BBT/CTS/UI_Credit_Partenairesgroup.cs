using TMPro;
using UnityEngine;

namespace CTS
{
	public class UI_Credit_Partenairesgroup : MonoBehaviour
	{
		[field: SerializeField]
		public GameObject ParentImage { get; private set; }

		[field: SerializeField]
		public TextMeshProUGUI PartenaireText { get; private set; }
	}
}
