using System.Collections.Generic;
using DV.Logic.Job;
using DV.Utils;
using UnityEngine;

public class YardTracksOrganizer : SingletonBehaviour<YardTracksOrganizer>
{
	private const float END_OF_TRACK_OFFSET_RESERVATION = 40f;

	private const float FLOATING_POINT_IMPRECISION_THRESHOLD = 0.5f;

	public Dictionary<string, Track> yardTrackIdToTrack;

	private Dictionary<Track, float> trackToReservedLength;

	public new static string AllowAutoCreate()
	{
		return "[YardTracksOrganizer]";
	}

	protected override void Awake()
	{
		base.Awake();
		yardTrackIdToTrack = new Dictionary<string, Track>();
		trackToReservedLength = new Dictionary<Track, float>();
	}

	public void ReserveSpace(Track track, float length, bool ignoreOccupiedTrackLength)
	{
		if (!IsTrackManagedByOrganizer(track))
		{
			Debug.LogError("track is not part of trackToReservedLength! Can't release reserved space!");
			return;
		}
		if (ignoreOccupiedTrackLength)
		{
			if (GetUnreservedSpace(track) < (double)length)
			{
				Debug.LogError("Unexpected state: Not enough unreserved space for reservation! Something is not right.");
			}
		}
		else if (GetFreeSpaceOnTrack(track) < (double)length)
		{
			Debug.LogError("Unexpected state: Not enough free space for reservation! Something is not right.");
		}
		trackToReservedLength[track] += length;
	}

	public bool ReleaseReservedSpace(Track track, float lengthToRelease)
	{
		if (!IsTrackManagedByOrganizer(track))
		{
			Debug.LogError("track is not part of trackToReservedLength! Can't release reserved space!");
			return false;
		}
		float num = (float)GetReservedSpace(track) - 40f;
		if (lengthToRelease > num + 0.5f)
		{
			Debug.LogError(string.Format("Unexpected state: Trying to release more than it was reserved for all jobs ({0} out of {1}). Clamping reservation to {2}", lengthToRelease, num, "END_OF_TRACK_OFFSET_RESERVATION"));
			lengthToRelease = num;
		}
		trackToReservedLength[track] -= lengthToRelease;
		return true;
	}

	public double GetReservedSpace(Track track)
	{
		if (!IsTrackManagedByOrganizer(track))
		{
			Debug.LogError("track is not part of trackToReservedLength! Can't extract reserved space!");
			return 0.0;
		}
		return trackToReservedLength[track];
	}

	public double GetUnreservedSpace(Track track)
	{
		if (!IsTrackManagedByOrganizer(track))
		{
			Debug.LogError("track is not part of trackToReservedLength! Can't extract unreserved space!");
			return 0.0;
		}
		return track.length - (double)trackToReservedLength[track];
	}

	public double GetFreeSpaceOnTrack(Track track)
	{
		if (!IsTrackManagedByOrganizer(track))
		{
			Debug.LogError("track is not part of trackToReservedLength! Can't extract free space!");
			return 0.0;
		}
		double reservedSpace = GetReservedSpace(track);
		return track.length - (double)track.OccupiedLength - reservedSpace;
	}

	public List<Track> FilterOutTracksWithoutRequiredFreeSpace(List<Track> tracks, float requiredLength)
	{
		List<Track> list = new List<Track>();
		foreach (Track track in tracks)
		{
			if (GetFreeSpaceOnTrack(track) > (double)requiredLength)
			{
				list.Add(track);
			}
		}
		return list;
	}

	public List<Track> FilterOutReservedTracks(List<Track> tracks)
	{
		List<Track> list = new List<Track>();
		foreach (Track track in tracks)
		{
			if (GetReservedSpace(track) <= 40.5)
			{
				list.Add(track);
			}
		}
		return list;
	}

	public List<Track> FilterOutOccupiedTracks(List<Track> tracks)
	{
		List<Track> list = new List<Track>();
		foreach (Track track in tracks)
		{
			if (track.IsFree())
			{
				list.Add(track);
			}
		}
		return list;
	}

	public TrackState GetTrackState(Track track)
	{
		double reservedSpace = GetReservedSpace(track);
		float occupiedLength = track.OccupiedLength;
		double freeSpaceOnTrack = GetFreeSpaceOnTrack(track);
		return new TrackState(reservedSpace, occupiedLength, freeSpaceOnTrack);
	}

	public List<TrackState> GetTracksState(List<Track> tracks)
	{
		List<TrackState> list = new List<TrackState>();
		foreach (Track track in tracks)
		{
			list.Add(GetTrackState(track));
		}
		return list;
	}

	public void InitializeYardTrack(Track track)
	{
		if (IsTrackManagedByOrganizer(track))
		{
			Debug.LogError("Track is already initialized in YardTracksOrganizer");
		}
		else
		{
			trackToReservedLength.Add(track, 40f);
		}
	}

	public bool IsTrackManagedByOrganizer(Track track)
	{
		return trackToReservedLength.ContainsKey(track);
	}
}
