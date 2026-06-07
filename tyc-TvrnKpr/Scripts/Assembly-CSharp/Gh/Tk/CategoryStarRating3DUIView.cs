using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class CategoryStarRating3DUIView : MonoBehaviour, ITooltipProvider
	{
		private string _currentFlagName;

		private float _starRating;

		[SerializeField]
		private Transform[] _starVisuals;

		[SerializeField]
		public BoxCollider _shortBannerCollider;

		[SerializeField]
		public BoxCollider _longBannerCollider;

		public string ratingCategory;

		public string zoneNeeded;

		public event EventHandler TooltipChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void OnInfoChanged(object sender, EventArgs e)
		{
		}

		private void OnStateChanged(object sender, EventArgs e)
		{
		}

		private void OnStarRatingChanged(object sender, EventArgs e)
		{
		}

		private void InvalidateFlag()
		{
		}

		private bool IsUnlocked()
		{
			return false;
		}

		private StarRatingManager GetStarRatingInfo()
		{
			return null;
		}

		public TooltipData GetTooltipData()
		{
			return null;
		}

		public Vector3 GetTooltipPosition()
		{
			return default(Vector3);
		}

		private void UpdateFlagState()
		{
		}

		private void ShowVisual()
		{
		}

		private void HideVisual()
		{
		}
	}
}
