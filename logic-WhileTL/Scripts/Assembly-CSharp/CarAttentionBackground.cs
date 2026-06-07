using System;
using App.Data;

public class CarAttentionBackground : BaseKeyData, ICloneable
{
	public bool TeachBeforeTrain;

	public bool TrainBeforeRelease;

	public CarAttentionBackground()
	{
	}

	public CarAttentionBackground(bool teachBeforeTrain, bool trainBeforeRelease)
	{
		TeachBeforeTrain = teachBeforeTrain;
		TrainBeforeRelease = trainBeforeRelease;
	}

	public object Clone()
	{
		return new CarAttentionBackground(TeachBeforeTrain, TrainBeforeRelease)
		{
			KeyName = KeyName
		};
	}
}
