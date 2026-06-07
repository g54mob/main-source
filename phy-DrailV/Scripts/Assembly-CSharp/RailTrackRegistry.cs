using System.Collections.Generic;
using System.Text.RegularExpressions;
using DV.Logic.Job;
using DV.Utils;
using UnityEngine;

public class RailTrackRegistry : RailTrackRegistryBase
{
	private Dictionary<Track, RailTrack> _logicToRailTrack;

	private Dictionary<RailTrack, Track> _railTrackToLogicTrack;

	public static Dictionary<Track, RailTrack> LogicToRailTrack
	{
		get
		{
			RailTrackRegistry railTrackRegistry = (RailTrackRegistry)SingletonBehaviour<RailTrackRegistryBase>.Instance;
			if (railTrackRegistry._logicToRailTrack == null)
			{
				_ = railTrackRegistry.AllTracks;
			}
			return railTrackRegistry._logicToRailTrack;
		}
	}

	public static Dictionary<RailTrack, Track> RailTrackToLogicTrack
	{
		get
		{
			RailTrackRegistry railTrackRegistry = (RailTrackRegistry)SingletonBehaviour<RailTrackRegistryBase>.Instance;
			if (railTrackRegistry._railTrackToLogicTrack == null)
			{
				_ = railTrackRegistry.AllTracks;
			}
			return railTrackRegistry._railTrackToLogicTrack;
		}
	}

	protected override void CreateLogicTracks()
	{
		_logicToRailTrack = new Dictionary<Track, RailTrack>();
		_railTrackToLogicTrack = new Dictionary<RailTrack, Track>();
		RailTrack[] allTracks = _allTracks;
		foreach (RailTrack railTrack in allTracks)
		{
			railTrack.Init();
			double span = railTrack.GetKinkedPointSet().span;
			TrackID iD = TryGenerateTrackIdFromName(railTrack.gameObject);
			Track track = new Track(span, iD);
			_logicToRailTrack.Add(track, railTrack);
			_railTrackToLogicTrack.Add(railTrack, track);
		}
		allTracks = _allTracks;
		for (int i = 0; i < allTracks.Length; i++)
		{
			allTracks[i].gameObject.AddComponent<RailTrackLogicTrackSwitching>().Init();
		}
	}

	private static TrackID TryGenerateTrackIdFromName(GameObject trackObject)
	{
		Match match = new Regex("\\[Y\\]_\\[([a-z0-9]*)\\]_\\[([a-z0-9]+)-(\\d+)-([a-z0-9]+)\\]", RegexOptions.IgnoreCase).Match(trackObject.name);
		if (!match.Success)
		{
			return SingletonBehaviour<IdGenerator>.Instance.GenerateGenericTrackID();
		}
		string value = match.Groups[1].Value;
		string value2 = match.Groups[2].Value;
		string value3 = match.Groups[3].Value;
		string value4 = match.Groups[4].Value;
		return new TrackID(value, value2, value3, value4);
	}
}
