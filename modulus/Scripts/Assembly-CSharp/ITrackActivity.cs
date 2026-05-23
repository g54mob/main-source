using Logic.Threading.Events;

public interface ITrackActivity
{
	MainThreadEvent OnActivityStart { get; }

	MainThreadEvent OnActivityEnd { get; }
}
