using System.ComponentModel;
using DV.Common;
using DV.UIFramework;
using TMPro;
using UnityEngine;

namespace DV.UI
{
	public class UserProfileViewElement : AViewElement<IUserProfile>
	{
		[SerializeField]
		private TextMeshProUGUI row1;

		private IUserProfile data;

		public override void SetData(IUserProfile data, AGridView<IUserProfile> _)
		{
			if (this.data != null)
			{
				this.data = null;
			}
			if (data != null)
			{
				this.data = data;
			}
			UpdateView();
		}

		private void UpdateView(object sender = null, PropertyChangedEventArgs e = null)
		{
			row1.text = data?.Name ?? "";
		}
	}
}
