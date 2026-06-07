using System;
using System.Collections.Generic;

namespace Motorways.UI.NewContentIndicators
{
	[Serializable]
	public class NewContentDataEntry
	{
		public string newContentId;

		public List<Feature> requiredFeatures;
	}
}
