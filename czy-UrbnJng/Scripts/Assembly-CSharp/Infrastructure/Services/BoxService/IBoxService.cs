using System.Collections.Generic;

namespace Infrastructure.Services.BoxService
{
	public interface IBoxService : IService
	{
		void SetCurrentBoxes(BoxOnLevel box);

		List<BoxOnLevel> GetCurrentBoxes();

		void ClearCurrenBoxes();
	}
}
