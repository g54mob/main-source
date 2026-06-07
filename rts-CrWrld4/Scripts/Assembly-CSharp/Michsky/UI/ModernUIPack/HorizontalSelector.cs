using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Michsky.UI.ModernUIPack
{
	public class HorizontalSelector : MonoBehaviour
	{
		private TextMeshProUGUI label;

		private TextMeshProUGUI labeHelper;

		private Animator selectorAnimator;

		private int index;

		public int defaultIndex;

		public List<string> elements;

		public UnityEvent onValueChanged;

		private void Start()
		{
		}

		public void PreviousClick()
		{
		}

		public void ForwardClick()
		{
		}
	}
}
