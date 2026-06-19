using System;
using FullInspector;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[DontSaveAssetReference]
	public class WallsDefinition
	{
		[InspectorMargin(8)]
		[InspectorHeader("Back")]
		public GameObject WallBack;

		public GameObject WindowBack;

		[InspectorMargin(8)]
		[InspectorHeader("Wall")]
		public GameObject Wall;

		public GameObject WallCornerLeft;

		public GameObject WallCornerRight;

		public GameObject WallCornerBoth;

		[InspectorMargin(8)]
		[InspectorHeader("Corner")]
		public GameObject CornerInner;

		public GameObject CornerOuter;

		[InspectorMargin(8)]
		[InspectorHeader("Door")]
		public GameObject Door;

		public GameObject DoorCornerLeft;

		public GameObject DoorCornerRight;

		public GameObject DoorCornerBoth;

		[InspectorMargin(8)]
		[InspectorHeader("Window")]
		public GameObject Window;

		public GameObject WindowCornerLeft;

		public GameObject WindowCornerRight;

		public GameObject WindowCornerBoth;

		[InspectorMargin(8)]
		[InspectorHeader("Pillar")]
		public GameObject Pillar;

		public GameObject PillarCornerLeft;

		public GameObject PillarCornerRight;

		public GameObject PillarCornerBoth;

		[InspectorMargin(8)]
		[InspectorHeader("Filler")]
		public GameObject FillerLeft;

		public GameObject FillerRight;
	}
}
