using UnityEngine;

namespace MG_BlocksEngine2.Environment
{
	public interface I_BE2_TargetObject
	{
		Transform Transform { get; }

		I_BE2_ProgrammingEnv ProgrammingEnv { get; set; }
	}
}
