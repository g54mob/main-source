public interface IWorkPlace
{
	ITarget Target { get; }

	bool StartWorking(Agent agent);

	bool IsWorking(Agent agent);
}
