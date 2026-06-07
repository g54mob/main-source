using System.Collections.Generic;
using DV.Logic.Job;
using DV.Utils;
using UnityEngine;

namespace DV.Optimizers
{
	public class TrainsOptimizer : MonoBehaviour
	{
		private Vector3 CLOSE_CAR_OVERLAP_BOX_SIZE = new Vector3(1.25f, 1.75f, 0.5f);

		public bool logChanges;

		private HashSet<Track> nonStationaryTracks = new HashSet<Track>();

		private HashSet<Track> potentialStationaryTracks = new HashSet<Track>();

		private HashSet<Car> carsToAwake = new HashSet<Car>();

		private HashSet<Car> carsToSleep = new HashSet<Car>();

		private HashSet<Car> processedCars = new HashSet<Car>();

		private Collider[] overlapResults = new Collider[6];

		private LayerMask trainLayerMask;

		private void Start()
		{
			trainLayerMask = LayerMask.GetMask("Train_Big_Collider");
		}

		private void Update()
		{
			if (SingletonBehaviour<PausePhysicsHandler>.Instance.PhysicsHandlingInProcess)
			{
				return;
			}
			nonStationaryTracks.Clear();
			potentialStationaryTracks.Clear();
			carsToAwake.Clear();
			carsToSleep.Clear();
			processedCars.Clear();
			List<TrainCar> allCars = SingletonBehaviour<CarSpawner>.Instance.AllCars;
			for (int num = allCars.Count - 1; num >= 0; num--)
			{
				TrainCar trainCar = allCars[num];
				if (trainCar == null || trainCar.logicCar == null)
				{
					Debug.LogError("Unexpected car state: " + ((trainCar == null) ? "null" : "logicCar is null"), this);
				}
				else if (trainCar.derailed)
				{
					if (!trainCar.isStationary)
					{
						carsToAwake.Add(trainCar.logicCar);
					}
				}
				else if (trainCar.logicCar.BogiesOnSameTrack)
				{
					ProcessTrack(trainCar.logicCar.CurrentTrack);
				}
				else
				{
					ProcessTrack(trainCar.logicCar.RearBogieTrack);
					ProcessTrack(trainCar.logicCar.FrontBogieTrack);
				}
			}
			foreach (Track nonStationaryTrack in nonStationaryTracks)
			{
				foreach (Car item in nonStationaryTrack.GetCarsFullyOnTrack())
				{
					carsToAwake.Add(item);
				}
				foreach (Car item2 in nonStationaryTrack.GetCarsPartiallyOnTrack())
				{
					carsToAwake.Add(item2);
				}
				potentialStationaryTracks.Remove(nonStationaryTrack);
			}
			ForceOptimizationStateOnCars(carsToAwake, forceSleep: false, forceStateOnCloseStationaryCars: true);
			foreach (Track potentialStationaryTrack in potentialStationaryTracks)
			{
				foreach (Car item3 in potentialStationaryTrack.GetCarsFullyOnTrack())
				{
					carsToSleep.Add(item3);
				}
				foreach (Car item4 in potentialStationaryTrack.GetCarsPartiallyOnTrack())
				{
					carsToSleep.Add(item4);
				}
			}
			ForceOptimizationStateOnCars(carsToSleep, forceSleep: true, forceStateOnCloseStationaryCars: false);
		}

		private void ProcessTrack(Track trackToProcess)
		{
			if (trackToProcess != null && !nonStationaryTracks.Contains(trackToProcess) && !potentialStationaryTracks.Contains(trackToProcess))
			{
				if (TrackHasNonStationaryCars(trackToProcess))
				{
					UpdateProcessedTracksWithConnectedNonEmptyTracks(trackToProcess, nonStationaryTracks);
				}
				else
				{
					potentialStationaryTracks.Add(trackToProcess);
				}
			}
		}

		private void ForceOptimizationStateOnCars(HashSet<Car> carsToProcess, bool forceSleep, bool forceStateOnCloseStationaryCars)
		{
			Dictionary<Car, TrainCar> logicCarToTrainCar = SingletonBehaviour<TrainCarRegistry>.Instance.logicCarToTrainCar;
			foreach (Car item in carsToProcess)
			{
				if (processedCars.Contains(item))
				{
					continue;
				}
				TrainCar trainCar = logicCarToTrainCar[item];
				trainCar.ForceOptimizationState(forceSleep, logChanges);
				processedCars.Add(item);
				Trainset trainset = trainCar.trainset;
				foreach (TrainCar car in trainset.cars)
				{
					if (!processedCars.Contains(car.logicCar) && (!forceSleep || !car.derailed))
					{
						car.ForceOptimizationState(forceSleep, logChanges);
						processedCars.Add(car.logicCar);
					}
				}
				if (!forceStateOnCloseStationaryCars)
				{
					continue;
				}
				TrainCar firstCar = trainset.firstCar;
				if (!firstCar.frontCoupler.IsCoupled())
				{
					Transform couplerTransform = firstCar.frontCoupler.transform;
					FindCloseStationaryCarAndForceStateViaCoupler(couplerTransform, firstCar.rb, forceSleep);
				}
				if (!firstCar.rearCoupler.IsCoupled())
				{
					Transform couplerTransform2 = firstCar.rearCoupler.transform;
					FindCloseStationaryCarAndForceStateViaCoupler(couplerTransform2, firstCar.rb, forceSleep);
				}
				TrainCar lastCar = trainset.lastCar;
				if (!(firstCar == lastCar))
				{
					if (!lastCar.frontCoupler.IsCoupled())
					{
						Transform couplerTransform3 = lastCar.frontCoupler.transform;
						FindCloseStationaryCarAndForceStateViaCoupler(couplerTransform3, lastCar.rb, forceSleep);
					}
					if (!lastCar.rearCoupler.IsCoupled())
					{
						Transform couplerTransform4 = lastCar.rearCoupler.transform;
						FindCloseStationaryCarAndForceStateViaCoupler(couplerTransform4, lastCar.rb, forceSleep);
					}
				}
			}
		}

		private void FindCloseStationaryCarAndForceStateViaCoupler(Transform couplerTransform, Rigidbody trainRB, bool forceSleep)
		{
			int num = Physics.OverlapBoxNonAlloc(couplerTransform.position + couplerTransform.up, CLOSE_CAR_OVERLAP_BOX_SIZE, overlapResults, couplerTransform.rotation, trainLayerMask, QueryTriggerInteraction.Ignore);
			for (int i = 0; i < num; i++)
			{
				Rigidbody attachedRigidbody = overlapResults[i].attachedRigidbody;
				if (!(attachedRigidbody == trainRB))
				{
					TrainCar trainCar = attachedRigidbody?.GetComponent<TrainCar>();
					if (!(trainCar == null) && !processedCars.Contains(trainCar.logicCar) && (trainCar.derailed || (trainCar.logicCar.BogiesOnSameTrack && !nonStationaryTracks.Contains(trainCar.logicCar.CurrentTrack)) || (!trainCar.logicCar.BogiesOnSameTrack && (!nonStationaryTracks.Contains(trainCar.logicCar.FrontBogieTrack) || !nonStationaryTracks.Contains(trainCar.logicCar.RearBogieTrack)))))
					{
						trainCar.ForceOptimizationState(forceSleep, logChanges);
						processedCars.Add(trainCar.logicCar);
					}
				}
			}
		}

		private bool TrackHasNonStationaryCars(Track track)
		{
			Dictionary<Car, TrainCar> logicCarToTrainCar = SingletonBehaviour<TrainCarRegistry>.Instance.logicCarToTrainCar;
			foreach (Car item in track.GetCarsFullyOnTrack())
			{
				if (!logicCarToTrainCar[item].isEligibleForSleep)
				{
					return true;
				}
			}
			foreach (Car item2 in track.GetCarsPartiallyOnTrack())
			{
				if (!logicCarToTrainCar[item2].isEligibleForSleep)
				{
					return true;
				}
			}
			return false;
		}

		public void UpdateProcessedTracksWithConnectedNonEmptyTracks(Track startingTrack, HashSet<Track> alreadyProcessedTracks)
		{
			alreadyProcessedTracks.Add(startingTrack);
			UpdateProcessedTracksWithConnectedNonEmptyTracksInDirection(startingTrack, inDirection: true, alreadyProcessedTracks);
			UpdateProcessedTracksWithConnectedNonEmptyTracksInDirection(startingTrack, inDirection: false, alreadyProcessedTracks);
		}

		private void UpdateProcessedTracksWithConnectedNonEmptyTracksInDirection(Track startingTrack, bool inDirection, HashSet<Track> alreadyProcessedTracks)
		{
			Track track = (inDirection ? startingTrack.InTrack : startingTrack.OutTrack);
			Track track2 = startingTrack;
			while (track != null && !alreadyProcessedTracks.Contains(track) && (track.GetCarsFullyOnTrack().Count > 0 || track.GetCarsPartiallyOnTrack().Count > 0))
			{
				alreadyProcessedTracks.Add(track);
				if (track.PossibleInTracks.Contains(track2))
				{
					track2 = track;
					track = track.OutTrack;
					continue;
				}
				if (track.PossibleOutTracks.Contains(track2))
				{
					track2 = track;
					track = track.InTrack;
					continue;
				}
				Debug.LogError(string.Format("Error: Can't detect connection from {0}[{1}] to {2}[{3}] track!", "currentTrackToCheck", track, "prevCheckedTrack", track2.ID));
				track2 = track;
				track = null;
			}
		}
	}
}
