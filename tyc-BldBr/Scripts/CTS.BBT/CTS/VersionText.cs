using TMPro;
using UnityEngine;

namespace CTS
{
	public class VersionText : MonoBehaviour
	{
		[SerializeField]
		private string _buildText = "Build ";

		private void Awake()
		{
			GetComponent<TextMeshProUGUI>().SetText(_buildText + Application.version);
		}
	}
}
