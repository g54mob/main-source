using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class InfoMotifSource : MonoBehaviour
	{
		[SerializeField]
		private Image _motifSourceImage;

		[SerializeField]
		private RectTransform _motifSourceParent;

		private Dictionary<eLuggage, eSecondaryMachineCategory> motifSourceDic;

		public void DisplayMotifSource(eLuggage luggage)
		{
		}

		private void CreateMotifSourceIcon(eLuggage luggage)
		{
		}
	}
}
