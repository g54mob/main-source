using System.Collections.Generic;

namespace TH20
{
	[DontSave]
	public class MetagameCutsceneManager : MustCallDestroy
	{
		private readonly Dictionary<string, MetagameCutsceneLocation> _cutsceneLocations = new Dictionary<string, MetagameCutsceneLocation>();

		private readonly Dictionary<string, MetagameHospitalVisual> _cutsceneAnimatables = new Dictionary<string, MetagameHospitalVisual>();

		private readonly Dictionary<string, MetagameCutscenePlayableDirector> _cutscenePlayableDirectors = new Dictionary<string, MetagameCutscenePlayableDirector>();

		public void RegisterCutsceneLocation(MetagameCutsceneLocation location)
		{
			_cutsceneLocations[location.LocationId] = location;
		}

		public MetagameCutsceneLocation GetCutsceneLocation(string id)
		{
			_cutsceneLocations.TryGetValue(id, out var value);
			return value;
		}

		public void RegisterCutsceneAnimatable(MetagameHospitalVisual animatable)
		{
			_cutsceneAnimatables[animatable.AnimatableId] = animatable;
		}

		public MetagameHospitalVisual GetCutsceneAnimatable(string id)
		{
			_cutsceneAnimatables.TryGetValue(id, out var value);
			return value;
		}

		public void RegisterCutscenePlayableDirector(MetagameCutscenePlayableDirector playableDirector)
		{
			_cutscenePlayableDirectors[playableDirector.DirectorId] = playableDirector;
		}

		public MetagameCutscenePlayableDirector GetCutscenePlayableDirector(string id)
		{
			_cutscenePlayableDirectors.TryGetValue(id, out var value);
			return value;
		}
	}
}
