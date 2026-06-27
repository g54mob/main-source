using System;
using Restory.Data.Equipment;
using UnityEngine;

namespace Restory.Data.Devices.DeviceWorkTypes
{
	[Serializable]
	public class DeviceWorkTypePaintConcretePalette : DeviceWorkTypePaintBase
	{
		[SerializeField]
		[HideInInspector]
		private PaintingPaletteInfo concretePalette;

		public PaintingPaletteInfo ConcretePalette
		{
			get
			{
				return concretePalette;
			}
			set
			{
				concretePalette = value;
			}
		}
	}
}
