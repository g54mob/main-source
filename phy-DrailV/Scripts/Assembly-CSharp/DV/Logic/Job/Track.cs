using System;
using System.Collections.Generic;
using DV.Utils;

namespace DV.Logic.Job
{
	public class Track
	{
		public readonly double length;

		private List<Car> currentCarsFullyOnTrack;

		private List<Car> currentCarsPartiallyOnTrack;

		private bool idOverridden;

		public TrackID ID { get; private set; }

		public float OccupiedLength
		{
			get
			{
				float num = 0f;
				foreach (Car item in currentCarsFullyOnTrack)
				{
					num += item.length;
				}
				return num;
			}
		}

		public Track InTrack { get; private set; }

		public HashSet<Track> PossibleInTracks { get; private set; }

		public Track OutTrack { get; private set; }

		public HashSet<Track> PossibleOutTracks { get; private set; }

		public Track(double length, TrackID ID = null)
		{
			this.length = length;
			currentCarsFullyOnTrack = new List<Car>();
			currentCarsPartiallyOnTrack = new List<Car>();
			this.ID = ID ?? SingletonBehaviour<IdGenerator>.Instance.GenerateGenericTrackID();
		}

		public void OverrideTrackID(TrackID ID)
		{
			if (!idOverridden)
			{
				this.ID = ID;
				idOverridden = true;
				return;
			}
			throw new Exception("Trying to override track ID multiple times");
		}

		public void InitializePossibleOutTracks(HashSet<Track> possibleOutTracks)
		{
			PossibleOutTracks = possibleOutTracks;
		}

		public void ConnectOutTrack(Track outTrack)
		{
			OutTrack = outTrack;
		}

		public void InitializePossibleInTracks(HashSet<Track> possibleInTracks)
		{
			PossibleInTracks = possibleInTracks;
		}

		public void ConnectInTrack(Track inTrack)
		{
			InTrack = inTrack;
		}

		public bool IsFree()
		{
			return currentCarsFullyOnTrack.Count == 0;
		}

		public List<Car> GetCarsFullyOnTrack()
		{
			return currentCarsFullyOnTrack;
		}

		public void RemoveFullyOnTrackCar(Car car)
		{
			currentCarsFullyOnTrack.Remove(car);
		}

		public void AddFullyOnTrackCar(Car car)
		{
			currentCarsFullyOnTrack.Add(car);
		}

		public List<Car> GetCarsPartiallyOnTrack()
		{
			return currentCarsPartiallyOnTrack;
		}

		public void RemovePartiallyOnTrackCar(Car car)
		{
			currentCarsPartiallyOnTrack.Remove(car);
		}

		public void AddPartiallyOnTrackCar(Car car)
		{
			currentCarsPartiallyOnTrack.Add(car);
		}
	}
}
