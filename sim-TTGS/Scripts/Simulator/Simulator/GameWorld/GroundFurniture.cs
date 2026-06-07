using System;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class GroundFurniture : Furniture, IMainInteractable
	{
		[Header("Associated Workshop")]
		[SerializeField]
		private EnabledValue<Workshop> m_associatedWorkshop;

		public override EFurnitureType Type => EFurnitureType.GROUND;

		protected override void InitPosition(Vector3 position)
		{
			base.transform.position = new Vector3(position.x, FurnitureSettings.FloorY, position.z);
		}

		protected override Vector3 ComputePhantomPosition(Vector3 worldPosition)
		{
			return new Vector3(Mathf.Round(worldPosition.x * (1f / FurnitureSettings.Step)) * FurnitureSettings.Step, FurnitureSettings.FloorY, Mathf.Round(worldPosition.z * (1f / FurnitureSettings.Step)) * FurnitureSettings.Step);
		}

		public override void RotatePhantom(int input)
		{
			int phantomOrientation = Utilities.Mod((int)(m_phantomOrientation + input), Enum.GetValues(typeof(EFurnitureOrientation)).Length);
			m_phantomOrientation = (EFurnitureOrientation)phantomOrientation;
			m_phantom.transform.eulerAngles = GetRotationFromOrientation(m_phantomOrientation);
		}

		public virtual bool CanMainInteract(Character character)
		{
			if (HasAssociatedWorkshop())
			{
				if (character.IsPlayer)
				{
					return World.PlayerCharacter.CharacterContext == EPlayerCharacterContext.NONE;
				}
				return false;
			}
			return false;
		}

		void IMainInteractable.OnMainInteractedBy(Character character)
		{
			if (TryGetAssociatedWorkshop(out var workshop))
			{
				character.Controller.TakeControl(workshop);
			}
		}

		protected virtual bool HasAssociatedWorkshop()
		{
			Workshop value;
			return m_associatedWorkshop.IsEnabled(out value);
		}

		protected virtual bool TryGetAssociatedWorkshop(out Workshop workshop)
		{
			return m_associatedWorkshop.IsEnabled(out workshop);
		}
	}
}
