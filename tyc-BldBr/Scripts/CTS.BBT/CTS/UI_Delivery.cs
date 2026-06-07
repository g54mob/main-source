using CTS.Core;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class UI_Delivery : CTSBehaviour
	{
		[InjectScope(EGetScope.Children)]
		[SerializeField]
		[Inject(false)]
		private TMP_Text _text;

		private Delivery _delivery;

		public void SetDelivery(Delivery delivery)
		{
			_delivery = delivery;
		}

		private void Update()
		{
			if (_delivery.ArrivalTime < 0f)
			{
				_text.text = "Waiting...";
				return;
			}
			float arrivalTime = _delivery.ArrivalTime;
			_text.text = Mathf.CeilToInt(arrivalTime).ToString();
		}
	}
}
