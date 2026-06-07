using System;
using Dhs5.Utility.Updates;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class FurnitureMover : MonoBehaviour, IActivable
	{
		[SerializeField]
		private InputHint m_inputHint;

		public Furniture MovingFurniture { get; private set; }

		public bool IsActive { get; private set; }

		private bool MoveIsCancellable { get; set; }

		public event Action OnMoved;

		private void OnDisable()
		{
			SetActive(active: false);
		}

		public void SetActive(bool active)
		{
			if (IsActive != active)
			{
				IsActive = active;
				if (m_inputHint != null)
				{
					m_inputHint.enabled = active;
				}
				Updater.RegisterChannelCallback(active, EUpdateChannel.GAME_PLAYING, OnUpdate);
			}
		}

		protected virtual void OnUpdate(float deltaTime)
		{
			UpdatePhantomMovePosition();
		}

		public bool CanMove(Furniture furniture)
		{
			if (MovingFurniture == null)
			{
				return furniture.CanBeMoved();
			}
			return false;
		}

		public void StartMoving(Furniture furniture, bool cancellable)
		{
			MoveIsCancellable = cancellable;
			MovingFurniture = furniture;
			OnStartMoving();
		}

		public bool Put()
		{
			if (MovingFurniture != null)
			{
				return MovingFurniture.Put();
			}
			return false;
		}

		public bool LetGo()
		{
			if (MovingFurniture != null && MoveIsCancellable)
			{
				MovingFurniture.OnCancelMove();
				OnStopMoving();
				return true;
			}
			return false;
		}

		public void ForceLetGo()
		{
			if (MovingFurniture != null)
			{
				MovingFurniture.OnCancelMove();
			}
			OnStopMoving();
		}

		public virtual void ModifyPhantomOrientation(float rotateInput)
		{
			MovingFurniture.RotatePhantom((int)rotateInput);
			UpdatePhantomMovePosition();
		}

		protected virtual void UpdatePhantomMovePosition()
		{
			MovingFurniture.MovePhantom(World.PlayerController.Sensor.PhysicTargetHit.point);
		}

		protected virtual void OnStartMoving()
		{
			MovingFurniture.OnStartMoveBy(this);
			MovingFurniture.Moved += OnFurnitureMoved;
			switch (MovingFurniture.Type)
			{
			case EFurnitureType.GROUND:
				World.PlayerController.Sensor.PhysicMode = PlayerSensor.EPhysicMode.GROUND;
				break;
			case EFurnitureType.WALLS:
				World.PlayerController.Sensor.PhysicMode = PlayerSensor.EPhysicMode.WALLS;
				break;
			case EFurnitureType.CEILING:
				World.PlayerController.Sensor.PhysicMode = PlayerSensor.EPhysicMode.CEILING;
				break;
			}
			SetActive(active: true);
		}

		protected virtual void OnStopMoving()
		{
			MovingFurniture = null;
			World.PlayerController.Sensor.PhysicMode = PlayerSensor.EPhysicMode.NONE;
			SetActive(active: false);
		}

		protected virtual void OnFurnitureMoved(Furniture furniture, Vector3 formerPos)
		{
			OnStopMoving();
			this.OnMoved?.Invoke();
		}
	}
}
