using System;

namespace Brewery.Face
{
	public interface IFaceMoodProducer
	{
		FaceMoodSet CurrentMoodSet { get; }

		event Action<FaceMoodSet> OnMoodSetChanged;
	}
}
