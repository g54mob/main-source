using System.Collections.Generic;
using Restory.Data.Base;
using UnityEngine;

namespace Restory.Data.Tutorials
{
	public abstract class TutorialBase : RestoryEntityInfoBase
	{
		[SerializeField]
		private List<TutorialBase> upcomingTutorials;

		public IReadOnlyList<TutorialBase> UpcomingTutorials => upcomingTutorials;
	}
}
