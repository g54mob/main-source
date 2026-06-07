using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace UMA
{
	public abstract class UMAGeneratorBuiltin : UMAGeneratorBase
	{
		[NonSerialized]
		protected UMAData umaData;

		[NonSerialized]
		protected List<UMAData> umaDirtyList;

		private LinkedList<UMAData> cleanUmas;

		private LinkedList<UMAData> dirtyUmas;

		public UMAMeshCombiner meshCombiner;

		private HashSet<string> raceNames;

		[Range(1f, 16f)]
		[Tooltip("Increase scale factor to decrease texture usage. A value of 1 means the textures will not be downsampled. Values greater than 1 will result in texture savings. The size of the texture is divided by this value.")]
		public int InitialScaleFactor;

		[Range(1f, 16f)]
		[Tooltip("Scale factor for edit-time builds. Increase scale factor to decrease texture usage. A value of 1 means the textures will not be downsampled. Values greater than 1 will result in texture savings. The size of the texture is divided by this value.")]
		public int editorInitialScaleFactor;

		[Tooltip("Number of iterations to process each frame")]
		public int IterationCount;

		[Tooltip("Enable Process All Pending to force the generate to process all pending UMA during the next frame")]
		public bool processAllPending;

		[Tooltip("When enable, the texture will be applied right away during the conversion process")]
		public bool applyInline;

		private int forceGarbageCollect;

		[Tooltip("Number of character updates before triggering garbage collection.")]
		[Range(0f, 128f)]
		public int garbageCollectionRate;

		public bool collectGarbage;

		private Stopwatch stopWatch;

		[Tooltip("Automatically set blendshapes based on race")]
		public bool autoSetRaceBlendshapes;

		[Tooltip("Allow read on generated mesh data. Will increase memory usage.")]
		public bool AllowReadFromMesh;

		[NonSerialized]
		public long ElapsedTicks;

		[NonSerialized]
		public long DnaChanged;

		[NonSerialized]
		public long TextureChanged;

		[NonSerialized]
		public long SlotsChanged;

		[NonSerialized]
		public long TexturesProcessed;

		public static uint WorkCount;

		public virtual void OnEnable()
		{
		}

		public virtual void Awake()
		{
		}

		public virtual void Update()
		{
		}

		private bool CheckRenderTextures()
		{
			return false;
		}

		private RenderTexture FindRenderTexture()
		{
			return null;
		}

		public override void Work()
		{
		}

		public void RebuildAllRenderTextures()
		{
		}

		private void RebuildRenderTexture(UMAData data)
		{
		}

		public void SaveMountedItems(UMAData umaData)
		{
		}

		public bool GenerateSingleUMA(UMAData data, bool fireEvents)
		{
			return false;
		}

		private int ToMS(long ticks)
		{
			return 0;
		}

		public void UpdateSlots(UMAData data)
		{
		}

		public virtual bool OldHandleDirtyUpdate(UMAData data)
		{
			return false;
		}

		public virtual void OnDirtyUpdate()
		{
		}

		private void UpdateUMAMesh(bool updatedAtlas)
		{
		}

		public override bool updatePending(UMAData umaToCheck)
		{
			return false;
		}

		public override bool updateProcessing(UMAData umaToCheck)
		{
			return false;
		}

		public override void removeUMA(UMAData umaToRemove)
		{
		}

		public override void addDirtyUMA(UMAData umaToAdd)
		{
		}

		public void Clear()
		{
		}

		public override bool IsIdle()
		{
			return false;
		}

		public bool hasPendingUMAS()
		{
			return false;
		}

		public override int QueueSize()
		{
			return 0;
		}

		public virtual void UMAReady(bool fireEvents = true)
		{
		}

		public virtual void PreApply(UMAData umaData)
		{
		}

		public virtual void UpdateUMABody(UMAData umaData)
		{
		}
	}
}
