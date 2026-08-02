using UnityEngine;
using UnityEngine.UI;

namespace JUTPS.Utilities
{
	[AddComponentMenu("JU TPS/Utilities/Trigger Menssage")]
	[RequireComponent(typeof(BoxCollider))]
	public class UIMenssengerTrigger : MonoBehaviour
	{
		private GameObject TextPanel;

		private Text TextTarget;

		[TextArea(0, 10)]
		public string TextToShow;

		[SerializeField]
		private string PlayerTag = "Player";

		[SerializeField]
		private string MessageFieldName = "MenssagesPanel";

		private BoxCollider boxcollider;

		public void Start()
		{
			TextPanel = GameObject.Find(MessageFieldName);
			TextTarget = TextPanel.GetComponentInChildren<Text>();
		}

		public void ShowMenssage()
		{
			TextPanel.SetActive(value: true);
			TextTarget.text = TextToShow;
		}

		public void HideMenssage()
		{
			TextPanel.SetActive(value: false);
			TextTarget.text = "";
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.tag == PlayerTag)
			{
				ShowMenssage();
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.gameObject.tag == PlayerTag)
			{
				HideMenssage();
			}
		}

		private void OnDrawGizmos()
		{
			if (boxcollider == null)
			{
				boxcollider = GetComponent<BoxCollider>();
			}
			Gizmos.matrix = Matrix4x4.TRS(base.transform.position, base.transform.rotation, base.transform.lossyScale);
			Gizmos.color = new Color(0f, 1f, 0f, 0.1f);
			Gizmos.DrawCube(boxcollider.center, boxcollider.size);
			Gizmos.color = new Color(1f, 1f, 1f, 0.2f);
			Gizmos.DrawWireCube(boxcollider.center, boxcollider.size);
		}
	}
}
