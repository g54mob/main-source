using System;
using Rewired;
using TMPro;
using UnityEngine;

namespace Placemaker.Ui
{
	public class ControlBindingKey : MonoBehaviour
	{
		public string actionName;

		public InputAction inputAction;

		public AxisRange axisRange;

		public int actionElementMapId;

		public TextMeshProUGUI buttonText;

		[SerializeField]
		private BaseButton baseButton;

		private void Awake()
		{
		}

		public void SetOnClickListener(int actionElementMapId, Action<ControlBindingKey> onClickCall)
		{
		}
	}
}
