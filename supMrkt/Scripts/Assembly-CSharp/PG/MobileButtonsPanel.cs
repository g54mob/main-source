using UnityEngine;
using UnityEngine.UI;

namespace PG
{
	public class MobileButtonsPanel : MonoBehaviour
	{
		[SerializeField]
		private float CloseY;

		[SerializeField]
		private float OpenY;

		[SerializeField]
		private float OpenCloseSpeed;

		[SerializeField]
		private Button OpenButton;

		[SerializeField]
		private Button CloseButton;

		private RectTransform RectTR;

		private float TargetY;

		private bool ButtonsPanelIsOpen
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
