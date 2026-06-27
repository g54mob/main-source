using System;
using System.Collections.Generic;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class TutorialRegistrySaveData
	{
		public List<string> CompletedTutorials { get; set; }
	}
}
