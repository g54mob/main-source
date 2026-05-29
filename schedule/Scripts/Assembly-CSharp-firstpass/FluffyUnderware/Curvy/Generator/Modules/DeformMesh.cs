using System;
using System.Collections.Generic;
using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using ToolBuddy.Pooling.Collections;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[HelpURL("https://curvyeditor.com/doclink/cgdeformmesh")]
	[ModuleInfo("Modifier/Deform Mesh", ModuleName = "Deform Mesh", Description = "Deform a mesh following a path")]
	public class DeformMesh : ScalingModule
	{
		[HideInInspector]
		[InputSlotInfo(new Type[] { typeof(CGVMesh) }, Array = true, Name = "VMesh")]
		public CGModuleInputSlot InVMeshes;

		[InputSlotInfo(new Type[] { typeof(CGPath) }, Name = "Path", DisplayName = "Volume/Rasterized Path")]
		[HideInInspector]
		public CGModuleInputSlot InPath;

		[InputSlotInfo(new Type[] { typeof(CGSpots) }, Array = true, Name = "Spots", Optional = true)]
		[HideInInspector]
		public CGModuleInputSlot InSpots;

		[HideInInspector]
		[OutputSlotInfo(typeof(CGVMesh), Name = "VMesh", Array = true)]
		public CGModuleOutputSlot OutVMeshes;

		[OutputSlotInfo(typeof(CGSpots), Array = true, Name = "Spots")]
		[HideInInspector]
		public CGModuleOutputSlot OutSpots;

		[Tooltip("Stretch the meshes to make them fit the end of the path")]
		[SerializeField]
		[Tab("General")]
		private bool stretchToEnd;

		private readonly ThreadPoolWorker<CGSpot> threadWorker;

		public bool StretchToEnd
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public override void Reset()
		{
		}

		protected override void OnDestroy()
		{
		}

		public override void Refresh()
		{
		}

		public static void DeformMeshes([NotNull] List<CGVMesh> inputMeshes, SubArray<CGSpot> inputSpots, SubArray<CGSpot> outputSpots, [NotNull] CGVMesh[] outputMeshes, [NotNull] CGPath path, bool stretchToEnd, ThreadPoolWorker<CGSpot> threadPoolWorker)
		{
		}

		public static void DeformMeshes([NotNull] List<CGVMesh> inputMeshes, SubArray<CGSpot> inputSpots, SubArray<CGSpot> outputSpots, [NotNull] CGVMesh[] outputMeshes, [NotNull] CGPath path, bool stretchToEnd, ThreadPoolWorker<CGSpot> threadPoolWorker, ScaleParameters scaleParameters)
		{
		}

		private static bool IsCurveEvaluationNeeded(ScaleParameters scaleParameters)
		{
			return false;
		}

		private static float GetSpotDistance(CGPath path, Vector3 spotPosition, Vector3[] pathPoints, int maxIndex, float[] pathRelativeDistances, float pathLength)
		{
			return 0f;
		}

		private static SubArray<CGSpot>? ToOneDimensionalArray(List<CGSpots> spotsList, out bool arrayIsCopy)
		{
			arrayIsCopy = default(bool);
			return null;
		}
	}
}
