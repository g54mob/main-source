using System.Collections.Generic;

namespace Gh.Tk.Story.Requirements
{
	public interface IRequirementProvider
	{
		IEnumerable<RequirementNode> GetRequirements();
	}
}
