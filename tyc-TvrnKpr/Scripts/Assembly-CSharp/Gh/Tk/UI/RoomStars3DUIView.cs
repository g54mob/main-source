using System;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class RoomStars3DUIView : Button3DUIView
	{
		[SerializeField]
		private Stars3DUIView _stars;

		private StarRatingManager _starRatingManager;

		protected override void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void StarRatingChanged(object sender, EventArgs e)
		{
		}

		public void SetData(Room room)
		{
		}

		private void RefreshFromStarRatingManager()
		{
		}

		private void SetStars(float stars, Func<TooltipData> tooltipProvider)
		{
		}
	}
}
