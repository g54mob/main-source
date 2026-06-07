using System.Collections.Generic;

namespace VoxelBusters.EssentialKit
{
	public class MediaServicesSelectMediaContentResult
	{
		public IMediaContent[] Contents { get; private set; }

		internal MediaServicesSelectMediaContentResult(List<IMediaContent> contents)
		{
		}
	}
}
