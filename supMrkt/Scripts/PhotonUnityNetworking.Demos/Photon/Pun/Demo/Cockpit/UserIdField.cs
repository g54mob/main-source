using UnityEngine;
using UnityEngine.UI;

namespace Photon.Pun.Demo.Cockpit
{
	public class UserIdField : MonoBehaviour
	{
		public PunCockpit Manager;

		public InputField PropertyValueInput;

		private string _cache;

		private bool registered;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Update()
		{
		}

		public void OnEndEdit(string value)
		{
		}

		public void SubmitForm(string value)
		{
		}
	}
}
