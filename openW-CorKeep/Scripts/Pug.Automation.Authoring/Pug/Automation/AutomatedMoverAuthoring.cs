using System;
using System.Collections.Generic;
using NaughtyAttributes;
using Unity.Mathematics;
using UnityEngine;

namespace Pug.Automation
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(AutomatedMoverSharedAuthoring))]
	public class AutomatedMoverAuthoring : MonoBehaviour
	{
		[Serializable]
		public struct AffectedArea
		{
			public int2 bottomLeft;

			public int2 size;

			public int2 moveTo;
		}

		[Serializable]
		public struct AffectedPositions
		{
			public int2 position;

			public int2 moveVector;
		}

		[InfoBox("Should be added in respect to default rotation forward", EInfoBoxType.Normal)]
		public List<AffectedArea> affectedAreas;

		public List<AffectedPositions> affectedPositions;
	}
}
