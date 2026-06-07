using System.Collections.Generic;
using Gh.Tk.UI;
using UnityEngine;

namespace Gh.Tk
{
	public class PatronCheckListItem3DUIView : BaseInteractable3DUIView
	{
		public GameObject[] pawnPrefabs;

		[SerializeField]
		private Transform _pawnSocket;

		private PatronAttractionChartItemView _pawnInstance;

		[SerializeField]
		private List<GameObject> _groupIconPrefabs;

		private GameObject _groupIconInstance;

		[SerializeField]
		private GameObject _checkObj;

		[SerializeField]
		private GameObject _crossObj;

		[SerializeField]
		private ObjectProgressBar3DUIView _progressBar;

		public UINotificationData.PatronCheckListItem Data { get; private set; }

		public void SetData(UINotificationData.PatronCheckListItem data, bool isGrouped = false)
		{
		}

		private void UpdateGroupIcon()
		{
		}

		public void UpdatePawn()
		{
		}

		public void UpdateState()
		{
		}

		public void UpdateProgress()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected override void OnClickedInternal()
		{
		}
	}
}
