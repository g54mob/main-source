using System;
using R3;

public class DatacenterDetails : IDisposable
{
	public readonly ReactiveProperty<DatacenterState> State = new ReactiveProperty<DatacenterState>(DatacenterState.Unprovisioned);

	public readonly ReactiveProperty<int> Engineers = new ReactiveProperty<int>(0);

	public readonly ReactiveProperty<float> ReprovisionProgress = new ReactiveProperty<float>(0f);

	public DatacenterDetails(DatacenterState state, int engineers = 0, float reprovisionProgress = 0f)
	{
		State.Value = state;
		Engineers.Value = engineers;
		ReprovisionProgress.Value = reprovisionProgress;
	}

	public void Dispose()
	{
		State.Dispose();
		Engineers.Dispose();
		ReprovisionProgress.Dispose();
	}
}
