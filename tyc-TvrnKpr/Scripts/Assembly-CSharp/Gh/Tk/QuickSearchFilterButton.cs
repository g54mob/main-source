using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class QuickSearchFilterButton : Button3DUIView
	{
		[SerializeField]
		private List<GameObject> _filterIcons;

		protected override void Start()
		{
		}

		protected override void OnClickedInternal()
		{
		}

		public void ClearSearchFilter()
		{
		}

		private void OnFilterChanged(object sender, EventArgs eventArgs)
		{
		}

		public override void CheckState()
		{
		}
	}
}
