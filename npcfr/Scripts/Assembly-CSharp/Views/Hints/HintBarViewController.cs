using System.Collections.Generic;
using Player.GameplayInput.ButtonsActions;
using UnityEngine;
using Zenject;

namespace Views.Hints
{
	public class HintBarViewController : MonoBehaviour
	{
		private lb ptw;

		private bgk ptx;

		private bhp pty;

		private mm ptz;

		private bfc pua;

		[SerializeField]
		private RectTransform m_slots;

		[SerializeField]
		private MKHintBarViewController m_mkHintBarViewController;

		private Dictionary<ButtonActionData, HintSlot> pub;

		[Inject]
		private void dui(lb a, bhp b, bgk c, mm d, bfc e)
		{
		}

		private void Awake()
		{
		}

		private void duj()
		{
		}

		private void duk(IEnumerable<ButtonActionData> a)
		{
		}

		public void dul(ButtonActionData a)
		{
		}

		public void dum(ButtonActionData a)
		{
		}

		private void dun(ButtonActionData a)
		{
		}

		private void duo(ButtonActionData a)
		{
		}

		private HintSlot dup()
		{
			return null;
		}

		private void duq()
		{
		}
	}
}
