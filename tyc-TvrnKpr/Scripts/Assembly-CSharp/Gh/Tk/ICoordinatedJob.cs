using System;

namespace Gh.Tk
{
	public interface ICoordinatedJob<T> where T : Enum
	{
		T CurrentStage { get; }

		ICoordinatedJob<T> OtherJob { get; }

		void SetStage(T stage);
	}
}
