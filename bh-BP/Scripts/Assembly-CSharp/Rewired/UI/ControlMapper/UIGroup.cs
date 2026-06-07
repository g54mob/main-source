using UnityEngine;
using UnityEngine.UI;

namespace Rewired.UI.ControlMapper
{
	[AddComponentMenu(null)]
	public class UIGroup : MonoBehaviour
	{
		[SerializeField]
		private Text _label;

		[SerializeField]
		private Transform _content;

		public string labelText
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Transform content => null;

		public void SetLabelActive(bool state)
		{
		}
	}
}
