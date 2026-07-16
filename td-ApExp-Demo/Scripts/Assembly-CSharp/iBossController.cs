using System.Collections.Generic;

public interface iBossController
{
	float GetCurrentTotalHealth();

	float GetTotalMaxHealth();

	List<iBossController> GetAllControllers()
	{
		return null;
	}
}
