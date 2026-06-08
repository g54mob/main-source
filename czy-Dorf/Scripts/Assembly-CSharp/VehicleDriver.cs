using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Dorfromantik;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class VehicleDriver : Vehicle, IPointerClickHandler, IEventSystemHandler
{
	private sealed class _003CMoving_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public VehicleDriver _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CMoving_003Ed__20(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			VehicleDriver vehicleDriver = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				AudioManager.Instance.PlaySoundAtTransform(vehicleDriver.engineLoop, vehicleDriver.transform);
				vehicleDriver.State = VehicleState.moving;
				vehicleDriver.onStartMoving?.Invoke();
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (vehicleDriver.State == VehicleState.moving)
			{
				vehicleDriver.Speed = vehicleDriver.targetSpeed;
				Vector3 pathPointPosition = vehicleDriver.currentPath.GetPathPointPosition(vehicleDriver.nextPathPointIndex, Space.World);
				vehicleDriver.MoveAndRotateTowards(pathPointPosition);
				if (Vector3.Distance(vehicleDriver.transform.position, pathPointPosition) < 0.01f)
				{
					vehicleDriver.StoreLastPathPosition(pathPointPosition);
					if (vehicleDriver.nextPathPointIndex == vehicleDriver.currentPath.LastPathPointIndex)
					{
						if (vehicleDriver.nextSegment == null)
						{
							vehicleDriver.nextSegment = vehicleDriver.currentVehicleSegment;
							vehicleDriver.currentPath = vehicleDriver.currentVehicleSegment.GetPathAtEntrance(vehicleDriver.currentPath.ExitWorldEdge, Space.World);
						}
						else
						{
							vehicleDriver.currentVehicleSegment = vehicleDriver.nextSegment;
							vehicleDriver.currentPath = vehicleDriver.currentVehicleSegment.GetPathAtEntrance((vehicleDriver.currentPath.ExitWorldEdge + 3) % 6, Space.World);
							if ((bool)vehicleDriver.currentVehicleSegment)
							{
								vehicleDriver.UpdateCurrentTile(vehicleDriver.currentVehicleSegment.Tile);
							}
						}
						vehicleDriver.nextPathPointIndex = 1;
						bool traversable;
						VehicleSegment nextSegment = vehicleDriver.currentVehicleSegment.GetNextSegment(vehicleDriver.currentPath.ExitWorldEdge, out traversable);
						vehicleDriver.nextSegment = (traversable ? nextSegment : null);
					}
					else
					{
						vehicleDriver.nextPathPointIndex++;
					}
				}
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			vehicleDriver.State = VehicleState.waitingToMove;
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[SerializeField]
	[FormerlySerializedAs("currentVehicleSegment")]
	private VehicleSegment initialVehicleSegment;

	[SerializeField]
	private int initialExitEdge;

	[SerializeField]
	private bool startDrivingImmediately;

	[SerializeField]
	private int initialPathPointIndex = -1;

	private VehiclePathData currentPath;

	private VehicleSegment currentVehicleSegment;

	private int nextPathPointIndex = 1;

	private VehicleSegment nextSegment;

	private int leavingEdge = -1;

	[SerializeField]
	private PointerEventData.InputButton debug_SpawnWagonButton;

	[SerializeField]
	private KeyCode debug_HoldWagonButton;

	[SerializeField]
	private UnityEvent onStartMoving;

	[SerializeField]
	private AudioClipOptions engineLoop;

	private Coroutine movingCoroutine;

	private bool initialized;

	public void StartMoving()
	{
		currentVehicleSegment = initialVehicleSegment;
		currentPath = currentVehicleSegment.GetPathTowardsExit(initialExitEdge, Space.Self);
		nextPathPointIndex = ((initialPathPointIndex == -1) ? currentPath.LastPathPointIndex : initialPathPointIndex);
		bool traversable;
		VehicleSegment vehicleSegment = currentVehicleSegment.GetNextSegment(currentPath.ExitWorldEdge, out traversable);
		nextSegment = (traversable ? vehicleSegment : null);
		if (!initialized)
		{
			initialized = true;
			initialTile.OnDestroyed += Destroy;
			initialTile.OnNeighborTilePlaced += CheckIfMovementIsPossible;
		}
		if (base.State != VehicleState.moving)
		{
			if (startDrivingImmediately || (bool)nextSegment)
			{
				StartCoroutine(Moving());
			}
			else
			{
				base.State = VehicleState.waitingToMove;
			}
		}
	}

	private void Destroy()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}

	protected override void ResetToInitialTile()
	{
		base.ResetToInitialTile();
		UpdateCurrentTile(initialTile);
		base.transform.localPosition = Vector3.zero;
		StartMoving();
	}

	private void CheckIfMovementIsPossible(int direction, Tile neighbor)
	{
		if (base.State == VehicleState.waitingToMove)
		{
			bool traversable;
			VehicleSegment vehicleSegment = currentVehicleSegment.GetNextSegment(currentPath.ExitWorldEdge, out traversable);
			if ((bool)vehicleSegment)
			{
				nextSegment = (traversable ? vehicleSegment : null);
				StartCoroutine(Moving());
			}
		}
	}

	public void StartParticleSystem()
	{
		GetComponentInChildren<ParticleSystem>().Play();
	}

	private IEnumerator Moving()
	{
		return new _003CMoving_003Ed__20(0)
		{
			_003C_003E4__this = this
		};
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}

	public void StartParticleSystemIfMoving()
	{
		if (base.State == VehicleState.moving)
		{
			StartParticleSystem();
		}
	}
}
