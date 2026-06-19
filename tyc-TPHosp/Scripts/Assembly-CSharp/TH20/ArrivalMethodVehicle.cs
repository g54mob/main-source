using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class ArrivalMethodVehicle : ArrivalMethod, IAnimationEndEvent
	{
		private readonly ArrivalMethodVehicleDefinition _definition;

		private Character _characterWaitAnimEnd;

		private int _vehicleAnimationState;

		private float _vehicleAnimationTime;

		private readonly int _spawnID;

		private int _reservedID;

		private bool _arrived;

		private readonly List<IArrivedCallback> _passengers = new List<IArrivedCallback>();

		[DontSave]
		private GameObject _vehicleInstance;

		[DontSave]
		private Animator _vehicleAnimator;

		[DontSave]
		private VehicleAnimationEventListener _animationEventListener;

		public ArrivalMethodDefinition Definition => _definition;

		public List<IArrivedCallback> Passengers => _passengers;

		public ArrivalMethodVehicle(ArrivalMethodVehicleDefinition definition, int spawnID, Level level, IArrivedCallback arrivedCallback)
			: base(level, arrivedCallback)
		{
			_definition = definition;
			_spawnID = spawnID;
			_reservedID = spawnID;
			AddPassenger(arrivedCallback);
			SpawnVehicle();
		}

		public override void Destroy()
		{
			if (_animationEventListener != null)
			{
				UnityEngine.Object.DestroyImmediate(_animationEventListener);
			}
			base.Destroy();
		}

		public void AddPassenger(IArrivedCallback arrivedCallback)
		{
			_passengers.Add(arrivedCallback);
		}

		private void SpawnVehicle()
		{
			ArrivalBaseComponent arrivalComponent = _definition.GetArrivalComponent(_spawnID);
			_vehicleInstance = _definition.SetupVehicle(arrivalComponent);
			_vehicleAnimator = _vehicleInstance.GetComponentInChildren<Animator>();
			_vehicleAnimator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
			_vehicleAnimator.runtimeAnimatorController = _definition.VehicleAnimGraph;
			_animationEventListener = _vehicleAnimator.gameObject.AddComponent<VehicleAnimationEventListener>();
			_animationEventListener.Method = this;
		}

		public override bool Update()
		{
			if (_vehicleInstance != null)
			{
				AnimatorStateInfo currentAnimatorStateInfo = _vehicleAnimator.GetCurrentAnimatorStateInfo(0);
				_vehicleAnimationTime = currentAnimatorStateInfo.normalizedTime;
				_vehicleAnimationState = currentAnimatorStateInfo.shortNameHash;
			}
			if (_vehicleInstance == null)
			{
				return _characterWaitAnimEnd == null;
			}
			return false;
		}

		public void TriggerArrival(Vector3 position, Quaternion rotation)
		{
			_arrived = true;
			if (_passengers.Count == 0)
			{
				return;
			}
			Character character = _passengers.Pop().OnArrived(position);
			if (character != null && character.GameObject != null)
			{
				character.Position = position;
				character.Rotation = rotation;
				character.NavPath.PutBackInNavWorld();
				character.NavPath.Warp(position);
				RuntimeAnimatorController runtimeAnimatorController = character.FindAnimationGraph(ref _definition.CharacterAnimGraph);
				if (runtimeAnimatorController != null)
				{
					if (_characterWaitAnimEnd != null)
					{
						OnAnimationEndEvent();
					}
					_characterWaitAnimEnd = character;
					_characterWaitAnimEnd.NavPath.RemoveFromNavWorld();
					_characterWaitAnimEnd.Interrupt();
					_characterWaitAnimEnd.PushAnimationGraph(runtimeAnimatorController, 0f, this);
				}
			}
			if (_passengers.Count == 0)
			{
				ReadyToDepart();
			}
		}

		private void ReadyToDepart()
		{
			if (_reservedID != -1)
			{
				_definition.Free(_reservedID);
				_reservedID = -1;
			}
			if (_vehicleAnimator.HasParameter("ReadyToDepart"))
			{
				_vehicleAnimator.SetBool("ReadyToDepart", value: true);
			}
		}

		public void TriggerDestroy()
		{
			if (_animationEventListener != null)
			{
				UnityEngine.Object.Destroy(_animationEventListener);
			}
			_definition.DestroyVehicle(ref _vehicleInstance);
		}

		public void OnAnimationEndEvent()
		{
			if (!_characterWaitAnimEnd.HasBeenDestroyed())
			{
				RuntimeAnimatorController animationGraph = _characterWaitAnimEnd.FindAnimationGraph(ref _definition.CharacterAnimGraph);
				_characterWaitAnimEnd.PopAnimationGraph(animationGraph, 0.25f);
				_characterWaitAnimEnd.NavPath.PutBackInNavWorld();
				_characterWaitAnimEnd.Resume();
			}
			_characterWaitAnimEnd = null;
		}

		public override bool IsValid()
		{
			return _definition.ValidArrivalComponent(_spawnID);
		}

		public override void RestoreFromSave()
		{
			if (_reservedID != -1)
			{
				_definition.RestoreFromSave(_reservedID);
			}
			SpawnVehicle();
			_vehicleAnimator.Play(_vehicleAnimationState, 0, _vehicleAnimationTime);
			if (_passengers.Count == 0)
			{
				ReadyToDepart();
			}
			if (_characterWaitAnimEnd != null)
			{
				RuntimeAnimatorController animgraph = _characterWaitAnimEnd.FindAnimationGraph(ref _definition.CharacterAnimGraph);
				Character characterWaitAnimEnd = _characterWaitAnimEnd;
				characterWaitAnimEnd.PostRestoreFromSaveCallback = (Action)Delegate.Combine(characterWaitAnimEnd.PostRestoreFromSaveCallback, (Action)delegate
				{
					_characterWaitAnimEnd.FixupAnimationEndEvent(this, animgraph);
				});
			}
			Level level = _level;
			level.PostConstruct = (Action)Delegate.Combine(level.PostConstruct, (Action)delegate
			{
				IArrivedCallback[] array = _passengers.ToArray();
				foreach (IArrivedCallback arrivedCallback in array)
				{
					if (!arrivedCallback.IsValid())
					{
						arrivedCallback.OnFailed();
						_passengers.Remove(arrivedCallback);
					}
				}
			});
		}

		public bool IsAtMaxCapacity()
		{
			if (!_arrived)
			{
				return _passengers.Count >= _definition.MaxCapacity;
			}
			return true;
		}

		public override bool IsArriving(Character character)
		{
			return _characterWaitAnimEnd == character;
		}
	}
}
