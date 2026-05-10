using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CTS
{
	[Obsolete]
	public class Tooltips : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[Space(20f)]
		[InfoBox("  Text Settings", EInfoBoxType.Normal)]
		[SerializeField]
		[Space(10f)]
		[Label("Title")]
		private string _toolTipTitle;

		[SerializeField]
		[Label("Text")]
		private string _toolTipText;

		[Space(30f)]
		[InfoBox("  Type Settings", EInfoBoxType.Normal)]
		[SerializeField]
		[Space(10f)]
		[Label("Padding")]
		private Vector3 _toolTipPadding;

		[Dropdown("ToolTipAnchorPosValue")]
		[Label("Anchor Position")]
		[SerializeField]
		[Space(10f)]
		private int _toolTipAnchorPos;

		[ShowIf("DisplayTopBottomValue")]
		[Dropdown("ToolTipAnchorPosTopBottomValue")]
		[Label("Anchor Align")]
		[SerializeField]
		private int _toolTipAnchorPosTopBottom;

		[ShowIf("DisplayLeftRightValue")]
		[Dropdown("ToolTipAnchorPosLeftRightValue")]
		[Label("Anchor Align")]
		[SerializeField]
		private int _toolTipAnchorPosLeftRight;

		private DropdownList<int> ToolTipAnchorPosValue()
		{
			return new DropdownList<int>
			{
				{ "Top", 0 },
				{ "Bottom", 1 },
				{ "Left", 2 },
				{ "Right", 3 }
			};
		}

		private DropdownList<int> ToolTipAnchorPosTopBottomValue()
		{
			return new DropdownList<int>
			{
				{ "Left", 0 },
				{ "Center", 1 },
				{ "Right", 2 }
			};
		}

		private DropdownList<int> ToolTipAnchorPosLeftRightValue()
		{
			return new DropdownList<int>
			{
				{ "Top", 0 },
				{ "Center", 1 },
				{ "Bottom", 2 }
			};
		}

		private bool DisplayTopBottomValue()
		{
			if (_toolTipAnchorPos != 0 && _toolTipAnchorPos != 1)
			{
				return false;
			}
			return true;
		}

		private bool DisplayLeftRightValue()
		{
			if (_toolTipAnchorPos != 2 && _toolTipAnchorPos != 3)
			{
				return false;
			}
			return true;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			SendRequest();
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			SendRequest();
		}

		private void SendRequest()
		{
		}
	}
}
