using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class InlineIcon3DUIView : NestedTooltipInteractable3DUIView
	{
		public Transform socket;

		public float monospacing;

		public GameObject progressBarPrefab;

		public Transform progressBarSocket;

		private string _buttonId;

		public void ApplyAttributes(Dictionary<string, string> attributes)
		{
		}

		private void AppendProgressBar(Dictionary<string, string> attributes)
		{
		}

		protected override void OnClickedInternal()
		{
		}
	}
}
