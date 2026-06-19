using System;
using System.Collections.Generic;
using Pug.UnityExtensions;

namespace PugWorldGen
{
	[Serializable]
	public class AffectedWorldParameter
	{
		public string affectedParameter;

		[ArrayElementTitle("level")]
		public List<ParameterChangeForLevel> levels;
	}
}
