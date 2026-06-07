public interface IGraphicStatesProvider
{
	string[] States { get; }

	void PreviewState(string state);
}
