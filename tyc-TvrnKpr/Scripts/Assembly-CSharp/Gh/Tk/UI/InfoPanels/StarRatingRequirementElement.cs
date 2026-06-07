using System;
using I18n;
using TMPro;
using UnityEngine;

namespace Gh.Tk.UI.InfoPanels
{
	public class StarRatingRequirementElement : MonoBehaviour
	{
		public TextMeshPro HighLevel;

		public TextMeshProI18n Detail;

		private StarRatingManager _starRatingManager;

		public StarRatingManager StarRatingManager
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void Refresh()
		{
		}

		private void Start()
		{
		}

		private void OnStarRatingChanged(object sender, EventArgs e)
		{
		}
	}
}
