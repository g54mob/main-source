using System;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class CeilingFurniture : Furniture
	{
		public override EFurnitureType Type => EFurnitureType.CEILING;

		protected override void InitPosition(Vector3 position)
		{
			base.transform.position = new Vector3(position.x, FurnitureSettings.CeilingY, position.z);
		}

		protected override Vector3 ComputePhantomPosition(Vector3 worldPosition)
		{
			return new Vector3(Mathf.Round(worldPosition.x * (1f / FurnitureSettings.Step)) * FurnitureSettings.Step, FurnitureSettings.CeilingY, Mathf.Round(worldPosition.z * (1f / FurnitureSettings.Step)) * FurnitureSettings.Step);
		}

		public override void RotatePhantom(int input)
		{
			int phantomOrientation = Utilities.Mod((int)(m_phantomOrientation + input), Enum.GetValues(typeof(EFurnitureOrientation)).Length);
			m_phantomOrientation = (EFurnitureOrientation)phantomOrientation;
			m_phantom.transform.eulerAngles = GetRotationFromOrientation(m_phantomOrientation);
		}
	}
}
