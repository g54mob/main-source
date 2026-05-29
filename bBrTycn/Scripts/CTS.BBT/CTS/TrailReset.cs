using System;

namespace CTS
{
	[Serializable]
	public class TrailReset : TrailUpdater
	{
		public override void Execute()
		{
			TrailRenderer.Clear();
		}
	}
}
