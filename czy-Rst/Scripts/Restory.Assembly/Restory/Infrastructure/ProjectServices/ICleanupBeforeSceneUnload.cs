using RSG;

namespace Restory.Infrastructure.ProjectServices
{
	public interface ICleanupBeforeSceneUnload
	{
		IPromise CleanupPromise();
	}
}
