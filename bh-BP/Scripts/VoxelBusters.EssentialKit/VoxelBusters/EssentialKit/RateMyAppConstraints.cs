using System;
using UnityEngine;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	public class RateMyAppConstraints
	{
		[Serializable]
		public class PromptConstraints
		{
			[SerializeField]
			[Tooltip("Minimum hours elapsed.")]
			private int m_minHours;

			[SerializeField]
			[Tooltip("Minimum app launches count.")]
			private int m_minLaunches;

			public int MinHours => 0;

			public int MinLaunches => 0;

			public PromptConstraints(int minHours, int minLaunches)
			{
			}
		}

		[SerializeField]
		[Tooltip("The number of hours elapsed since first launch,  to show ratings window for the first time.")]
		private PromptConstraints m_initialPromptConstraints;

		[SerializeField]
		[Tooltip("The number of times the user must launch the app to show ratings window for the first time.")]
		private PromptConstraints m_repeatPromptConstraints;

		public PromptConstraints InitialPromptConstraints => null;

		public PromptConstraints RepeatPromptConstraints => null;

		public RateMyAppConstraints()
		{
		}

		public RateMyAppConstraints(PromptConstraints initialPromptConstraints, PromptConstraints repeatPromptConstraints)
		{
		}
	}
}
