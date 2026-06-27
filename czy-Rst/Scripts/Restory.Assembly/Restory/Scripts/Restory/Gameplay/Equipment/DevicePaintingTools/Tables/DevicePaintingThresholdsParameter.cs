using System;
using Restory.Data.Tables.Parameters;
using UnityEngine;

namespace Restory.Scripts.Restory.Gameplay.Equipment.DevicePaintingTools.Tables
{
	[Serializable]
	public class DevicePaintingThresholdsParameter : GameEntityParameters
	{
		public Vector2 ThresholdRange = new Vector2(0f, 1f);
	}
}
