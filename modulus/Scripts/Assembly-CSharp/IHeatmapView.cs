using System;

public interface IHeatmapView
{
	event Action OnInit;

	ITrackActivity GetTrackActivity();
}
