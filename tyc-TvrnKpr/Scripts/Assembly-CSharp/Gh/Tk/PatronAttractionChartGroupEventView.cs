using System;
using Gh.Tk.UI.Dialogs;
using UnityEngine;

namespace Gh.Tk
{
	public class PatronAttractionChartGroupEventView : MonoBehaviour
	{
		public static EventHandler<EventArgs<PatronAttractionChart.AttractionChartItem[]>> GroupConfirmed;

		[SerializeField]
		private GroupRequestButton3DUIView _headerButton;

		[SerializeField]
		private Transform _headerSocket;

		[SerializeField]
		private BoxCollider _headerCollider;

		[SerializeField]
		private Transform _fillObject;

		[SerializeField]
		private Transform _highlightObject;

		[SerializeField]
		private float _highlightHeaderPadding;

		[SerializeField]
		private float _headerConfirmedPadding;

		[SerializeField]
		private float _headerUnconfirmedPadding;

		public PatronAttractionChart.AttractionChartItem[] GroupMembers { get; private set; }

		public void SetSize(int pawns, float height)
		{
		}

		public void SetData(PatronAttractionChart chart, PatronAttractionChart.AttractionChartItem[] groupMembers, float stackedHeight)
		{
		}

		public void ConfirmGroup()
		{
		}
	}
}
