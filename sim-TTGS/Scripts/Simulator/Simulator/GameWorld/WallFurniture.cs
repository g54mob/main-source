using Dhs5.Utility.Updates;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class WallFurniture : Furniture
	{
		protected Wall m_wall;

		private Wall m_phantomWall;

		private bool m_destroyed;

		public override EFurnitureType Type => EFurnitureType.WALLS;

		public override void InitPostLoad(SaveClass_Furnitures.FurnitureState state)
		{
			base.InitPostLoad(state);
			if (CheckForWall(out m_wall))
			{
				m_wall.Destroyed += OnWallDestroyed;
			}
			else
			{
				Updater.CallInXFrames(0, OnWallDestroyed, out var _, EUpdatePass.AFTER_LATE_UPDATE);
			}
		}

		protected override void InitPosition(Vector3 position)
		{
			base.transform.position = position;
		}

		protected override Vector3 ComputePhantomPosition(Vector3 worldPosition)
		{
			RaycastHit physicTargetHit = World.PlayerController.Sensor.PhysicTargetHit;
			if (physicTargetHit.collider != null && physicTargetHit.collider.TryGetComponent<Wall>(out m_phantomWall))
			{
				m_phantomOrientation = GetOrientationFromNormal(physicTargetHit.normal);
				m_phantom.transform.eulerAngles = GetRotationFromOrientation(m_phantomOrientation);
				return new Vector3(worldPosition.x, Mathf.Round(worldPosition.y * (1f / FurnitureSettings.Step)) * FurnitureSettings.Step, worldPosition.z) + physicTargetHit.normal * 0.01f;
			}
			return m_phantomPosition;
		}

		public override void RotatePhantom(int input)
		{
		}

		protected override bool IsInsideLimits()
		{
			Bounds bounds = m_phantom.GetBounds();
			if ((m_zone & EFurnitureZone.SHOP) == 0 && bounds.max.z <= FurnitureSettings.MaxZ)
			{
				return false;
			}
			if ((m_zone & EFurnitureZone.RESERVE) == 0 && bounds.min.z > FurnitureSettings.MaxZ)
			{
				return false;
			}
			if (bounds.min.y > FurnitureSettings.FloorY)
			{
				return bounds.max.y < FurnitureSettings.CeilingY;
			}
			return false;
		}

		public override void OnCompleteMove()
		{
			base.OnCompleteMove();
			if (m_wall != null)
			{
				m_wall.Destroyed -= OnWallDestroyed;
			}
			m_wall = m_phantomWall;
			if (m_wall != null)
			{
				m_wall.Destroyed += OnWallDestroyed;
			}
		}

		protected virtual void OnWallDestroyed()
		{
			if (!m_destroyed)
			{
				if ((bool)m_wall)
				{
					m_wall.Destroyed -= OnWallDestroyed;
				}
				World.DeliverySystem.DeliverBoxOfFurniture(this, 1);
				World.ShopBuilding.DestroyFurniture(base.GameID);
				m_destroyed = true;
			}
		}

		private bool CheckForWall(out Wall wall)
		{
			Collider[] array = Physics.OverlapSphere(base.transform.position, 0.05f, PlayerSensorSettings.WallsMask, QueryTriggerInteraction.Ignore);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != null && array[i].TryGetComponent<Wall>(out wall))
				{
					return true;
				}
			}
			wall = null;
			return false;
		}
	}
}
