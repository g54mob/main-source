using System;
using System.Collections.Generic;
using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using ToolBuddy.Pooling.Collections;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[ModuleInfo("Modifier/Deform Mesh", ModuleName = "Deform Mesh", Description = "Deform a mesh following a path")]
	[HelpURL("https://curvyeditor.com/doclink/cgdeformmesh")]
	public class DeformMesh : ScalingModule
	{
		[InputSlotInfo(new Type[] { typeof(CGVMesh) }, Array = true, Name = "VMesh")]
		[HideInInspector]
		public CGModuleInputSlot InVMeshes;

		[HideInInspector]
		[InputSlotInfo(new Type[] { typeof(CGPath) }, Name = "Path", DisplayName = "Volume/Rasterized Path")]
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

		[Tab("General")]
		[SerializeField]
		[Tooltip("Stretch the meshes to make them fit the end of the path")]
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
