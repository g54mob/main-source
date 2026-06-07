using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using DV.Utils;
using UnityEngine;

public abstract class RailTrackRegistryBase : SingletonBehaviour<RailTrackRegistryBase>
{
	protected RailTrack[] _allTracks;

	private string _junctionsHash;

	private Junction[] _orderedJunctions;

	private const string RAILWAY_ROOT = "[railway]";

	private Transform _trackRootParent;

	private string _tracksHash;

	private RailTrack[] _orderedRailtracks;

	public RailTrack[] AllTracks
	{
		get
		{
			if (_allTracks == null)
			{
				_allTracks = UnityEngine.Object.FindObjectsOfType<RailTrack>();
				if (_allTracks.Length == 0)
				{
					Debug.LogError(GetType().Name + ".AllTracks was accessed but it found 0 tracks, you need to debug this");
				}
				else
				{
					Debug.Log($"{GetType().Name} found {_allTracks.Length} tracks using FindObjectsOfType");
					CreateLogicTracks();
				}
			}
			return _allTracks;
		}
	}

	public string JunctionsHash
	{
		get
		{
			if (string.IsNullOrEmpty(_junctionsHash))
			{
				_junctionsHash = GetJunctionsHash(OrderedJunctions);
			}
			return _junctionsHash;
		}
	}

	public Junction[] OrderedJunctions
	{
		get
		{
			if (_orderedJunctions == null)
			{
				_orderedJunctions = TrackRootParent.GetComponentsInChildren<Junction>();
			}
			return _orderedJunctions;
		}
	}

	public static Junction[] Junctions => SingletonBehaviour<RailTrackRegistryBase>.Instance.OrderedJunctions;

	public Transform TrackRootParent
	{
		get
		{
			if (_trackRootParent == null)
			{
				_trackRootParent = GameObject.Find("[railway]").transform;
			}
			return _trackRootParent;
		}
	}

	public string TracksHash
	{
		get
		{
			if (string.IsNullOrEmpty(_tracksHash))
			{
				_tracksHash = GetTracksHash(OrderedRailtracks);
			}
			return _tracksHash;
		}
	}

	public RailTrack[] OrderedRailtracks
	{
		get
		{
			if (_orderedRailtracks == null)
			{
				_orderedRailtracks = TrackRootParent.GetComponentsInChildren<RailTrack>();
			}
			return _orderedRailtracks;
		}
	}

	public static RailTrack[] RailTracks => SingletonBehaviour<RailTrackRegistryBase>.Instance.OrderedRailtracks;

	public new static string AllowAutoCreate()
	{
		return null;
	}

	protected abstract void CreateLogicTracks();

	public List<RailTrack> GetRailTracksWithNames(List<string> railtracksNames)
	{
		List<RailTrack> list = new List<RailTrack>();
		if (railtracksNames.Count == 0)
		{
			return list;
		}
		List<string> list2 = new List<string>();
		RailTrack[] allTracks = AllTracks;
		foreach (RailTrack railTrack in allTracks)
		{
			if (railtracksNames.Contains(railTrack.name))
			{
				if (list2.Contains(railTrack.name))
				{
					Debug.LogError("Track with name " + railTrack.name + " was already found! Bad track setup, some station tracks have the same name!");
					return null;
				}
				list.Add(railTrack);
				list2.Add(railTrack.name);
			}
		}
		if (list.Count != railtracksNames.Count)
		{
			Debug.LogError($"Couldn't find all required tracks (railtracks.Count: {list.Count}, railtracksNames.Count: {railtracksNames.Count})");
			return null;
		}
		return list;
	}

	public RailTrack GetTrackWithName(string trackName)
	{
		return AllTracks.FirstOrDefault((RailTrack track) => track.name == trackName);
	}

	private static string GetJunctionsHash(Junction[] junctions)
	{
		if (junctions == null || junctions.Length == 0)
		{
			return null;
		}
		return MD5(string.Join("|", junctions.Select((Junction j) => MD5(j.gameObject.GetPath())))).Replace("-", "");
	}

	private static string GetTracksHash(RailTrack[] tracks)
	{
		if (tracks == null || tracks.Length == 0)
		{
			return null;
		}
		return MD5(string.Join("|", tracks.Select((RailTrack rt) => MD5(rt.gameObject.GetPath())))).Replace("-", "");
	}

	private static string MD5(string str)
	{
		byte[] bytes = new ASCIIEncoding().GetBytes(str);
		return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(bytes));
	}
}
