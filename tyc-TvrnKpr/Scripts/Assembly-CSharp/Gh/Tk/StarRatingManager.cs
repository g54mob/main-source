using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class StarRatingManager : IUpdateable
	{
		private float _starRating;

		protected readonly Dictionary<float, RequirementGroup> _requirements;

		public readonly string TitleKey;

		public readonly string StarType;

		private bool _isUpdating;

		public float StarRating
		{
			get
			{
				return 0f;
			}
			private set
			{
			}
		}

		public Func<string> GetDescriptionAction { get; set; }

		public bool IsDirty { get; set; }

		public float MaxStarsOverride { get; set; }

		public static event EventHandler<EventArgs> StarRatingChanged
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

		public static event EventHandler<EventArgs> InfoChanged
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

		protected StarRatingManager()
		{
		}

		public StarRatingManager(string starType, string titleKey)
		{
		}

		~StarRatingManager()
		{
		}

		public void AddToRequirement(float star, Requirement requirement)
		{
		}

		public void SetRequirement(float star, RequirementGroup requirement)
		{
		}

		public void Init()
		{
		}

		protected void UpdateStarRating()
		{
		}

		protected virtual float ModifyNewStarRating(float starRating)
		{
			return 0f;
		}

		private void AttachListeners()
		{
		}

		private void OnStatusChanged(object sender, EventArgs e)
		{
		}

		private void DetachListeners()
		{
		}

		public string GetSubRequirementInfo()
		{
			return null;
		}

		public string GetInfo(bool withDescription = true)
		{
			return null;
		}

		protected (float, RequirementGroup) GetNextRequirement()
		{
			return default((float, RequirementGroup));
		}

		public void MarkDirty()
		{
		}

		public void UpdateObject()
		{
		}

		private void UpdateStarRatings()
		{
		}

		protected float GetMaxStars()
		{
			return 0f;
		}
	}
}
