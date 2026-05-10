using Animancer;
using CTS.BBT.AI;

namespace CTS
{
	public interface ICTSTransition
	{
		bool ApplyRootMotion { get; set; }

		ELayer Layer { get; set; }

		EEndEvent EndEvent { get; set; }

		ITransition GetTransition();
	}
}
