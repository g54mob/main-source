using System.Collections.Generic;

public interface IAppCommandSource
{
	void Start();

	IEnumerable<IAppCommand> GetFrameCommands();

	void SetRewiredMode(int mode);
}
