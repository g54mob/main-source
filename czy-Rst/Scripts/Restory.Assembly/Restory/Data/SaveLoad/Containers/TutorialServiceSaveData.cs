using System;
using System.Collections.Generic;
using Restory.Data.Tutorials;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class TutorialServiceSaveData
	{
		public List<TutorialBase> NotCompletedTutorials { get; set; }
	}
}
