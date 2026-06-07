using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PajamaLlama.UI
{
	public class ArrowToggle : ArrowList, ISubmitHandler, IEventSystemHandler, IPointerClickHandler
	{
		[Header("Arrow Toggle")]
		[SerializeField]
		private LocalizedString _offLabel;

		[SerializeField]
		private LocalizedString _onLabel;

		public bool IsOn => base.Index > 0;

		protected override void Awake()
		{
			base.Awake();
			base.AddOptions(_offLabel, _onLabel);
		}

		public void SetIsOnWithoutNotify(bool isOn)
		{
			if (isOn)
			{
				SetIndexWithoutNotify(1);
			}
			else
			{
				SetIndexWithoutNotify(0);
			}
		}

		public override void AddOptions(IEnumerable<object> options)
		{
			Debug.LogException(new NotSupportedException());
		}

		public override void AddOptions(params object[] options)
		{
			Debug.LogException(new NotSupportedException());
		}

		public void OnSubmit(BaseEventData eventData)
		{
			Toggle();
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			Toggle();
		}

		private void Toggle()
		{
			if (base.Index == 0)
			{
				Next();
			}
			else
			{
				Previous();
			}
		}
	}
}
