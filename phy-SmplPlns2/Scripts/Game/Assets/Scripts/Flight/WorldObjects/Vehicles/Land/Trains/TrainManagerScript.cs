using System;
using System.Collections.Generic;
using Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Trains.Events;
using FishNet.Object;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Trains
{
	public class TrainManagerScript : NetworkBehaviour
	{
		private static List<Action<TrainManagerScript>> _onCreatedActions;

		private List<TrainTrackScript> _tracks;

		private List<TrainScript> _trains;

		private bool NetworkInitialize___EarlyAssets_002EScripts_002EFlight_002EWorldObjects_002EVehicles_002ELand_002ETrains_002ETrainManagerScriptGame_002Edll_Excuted;

		private bool NetworkInitialize___LateAssets_002EScripts_002EFlight_002EWorldObjects_002EVehicles_002ELand_002ETrains_002ETrainManagerScriptGame_002Edll_Excuted;

		public static TrainManagerScript Instance { get; private set; }

		public IReadOnlyList<TrainTrackScript> Tracks => _tracks;

		public IReadOnlyList<TrainScript> Trains => _trains;

		public event EventHandler<TrainTrackEventArgs> TrackLoaded;

		public event EventHandler<TrainTrackEventArgs> TrackUnloaded;

		public static void EnqueueAction(Action<TrainManagerScript> action)
		{
			if (Instance == null)
			{
				(_onCreatedActions ?? (_onCreatedActions = new List<Action<TrainManagerScript>>())).Add(action);
			}
			else
			{
				action(Instance);
			}
		}

		public TrainTrackScript FindTrack(string id)
		{
			for (int i = 0; i < _tracks.Count; i++)
			{
				if (_tracks[i].Id == id)
				{
					return _tracks[i];
				}
			}
			return null;
		}

		public void RegisterTrack(TrainTrackScript track)
		{
			_tracks.Add(track);
			this.TrackLoaded?.Invoke(this, new TrainTrackEventArgs(track.Id, track));
		}

		public void RegisterTrain(TrainScript train)
		{
			_trains.Add(train);
		}

		public void UnregisterTrack(TrainTrackScript track)
		{
			_tracks.Remove(track);
			this.TrackUnloaded?.Invoke(this, new TrainTrackEventArgs(track.Id, track));
		}

		public void UnregisterTrain(TrainScript train)
		{
			_trains.Remove(train);
		}

		public virtual void Awake()
		{
			NetworkInitialize___Early();
			Awake_UserLogic_Assets_002EScripts_002EFlight_002EWorldObjects_002EVehicles_002ELand_002ETrains_002ETrainManagerScript_Game_002Edll();
			NetworkInitialize___Late();
		}

		protected virtual void OnDestroy()
		{
			Instance = null;
		}

		protected virtual void Start()
		{
			if (FlightSceneScript.Instance != null)
			{
				base.transform.SetParent(FlightSceneScript.Instance.transform, worldPositionStays: false);
			}
		}

		public override void NetworkInitialize___Early()
		{
			if (!NetworkInitialize___EarlyAssets_002EScripts_002EFlight_002EWorldObjects_002EVehicles_002ELand_002ETrains_002ETrainManagerScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___EarlyAssets_002EScripts_002EFlight_002EWorldObjects_002EVehicles_002ELand_002ETrains_002ETrainManagerScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Early();
			}
		}

		public override void NetworkInitialize___Late()
		{
			if (!NetworkInitialize___LateAssets_002EScripts_002EFlight_002EWorldObjects_002EVehicles_002ELand_002ETrains_002ETrainManagerScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___LateAssets_002EScripts_002EFlight_002EWorldObjects_002EVehicles_002ELand_002ETrains_002ETrainManagerScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Late();
			}
		}

		public override void NetworkInitializeIfDisabled()
		{
			NetworkInitialize___Early();
			NetworkInitialize___Late();
		}

		protected virtual void Awake_UserLogic_Assets_002EScripts_002EFlight_002EWorldObjects_002EVehicles_002ELand_002ETrains_002ETrainManagerScript_Game_002Edll()
		{
			Instance = this;
			_tracks = new List<TrainTrackScript>();
			_trains = new List<TrainScript>();
			if (_onCreatedActions == null)
			{
				return;
			}
			foreach (Action<TrainManagerScript> onCreatedAction in _onCreatedActions)
			{
				try
				{
					onCreatedAction(this);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
			_onCreatedActions = null;
		}
	}
}
