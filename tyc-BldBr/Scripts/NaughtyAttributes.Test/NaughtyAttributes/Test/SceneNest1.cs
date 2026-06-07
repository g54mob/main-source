using System;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class SceneNest1
	{
		[Scene]
		public string scene1;

		public SceneNest2 nest2;
	}
}
