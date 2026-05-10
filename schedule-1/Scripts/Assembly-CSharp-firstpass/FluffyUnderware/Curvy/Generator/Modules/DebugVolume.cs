using System;
using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[HelpURL("https://curvyeditor.com/doclink/cgdebugvolume")]
	[ModuleInfo("Debug/Volume", ModuleName = "Debug Volume")]
	public class DebugVolume : CGModule
	{
		[InputSlotInfo(new Type[] { typeof(CGVolume) }, Name = "Volume")]
		[HideInInspector]
		public CGModuleInputSlot InData;

		[Tab("General")]
		public bool ShowPathSamples;

		public bool ShowCrossSamples;

		[IntRegion(RegionIsOptional = true)]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		public IntRegion LimitCross;

		public bool ShowNormals;

		public bool ShowIndex;

		public bool ShowMap;

		public Color PathColor;

		public Color VolumeColor;

		public Color NormalColor;

		[Tab("Interpolate")]
		public bool Interpolate;

		[RangeEx(-1f, 1f, "Path", null)]
		public float InterpolatePathF;

		[RangeEx(-1f, 1f, "Cross", null)]
		public float InterpolateCrossF;

		public override void Reset()
		{
		}
	}
}
