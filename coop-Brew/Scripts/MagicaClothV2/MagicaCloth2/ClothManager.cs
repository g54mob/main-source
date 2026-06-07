using System;
using System.Collections.Generic;
using System.Text;
using Unity.Jobs;
using Unity.Profiling;
using UnityEngine;

namespace MagicaCloth2
{
	public class ClothManager : IManager, IDisposable, IValid
	{
		internal HashSet<ClothProcess> clothSet;

		internal HashSet<ClothProcess> boneClothSet;

		internal HashSet<ClothProcess> meshClothSet;

		private Dictionary<MagicaObjectId, bool> animatorVisibleDict;

		private Dictionary<MagicaObjectId, bool> rendererVisibleDict;

		private JobHandle masterJob;

		private bool isValid;

		private static readonly ProfilerMarker startClothUpdateTimeProfiler;

		private static readonly ProfilerMarker startClothUpdateTeamProfiler;

		private static readonly ProfilerMarker startClothUpdatePrePareProfiler;

		private static readonly ProfilerMarker startClothUpdateScheduleProfiler;

		public void Dispose()
		{
		}

		public void EnterdEditMode()
		{
		}

		public void Initialize()
		{
		}

		public bool IsValid()
		{
			return false;
		}

		private void ClearMasterJob()
		{
		}

		private void CompleteMasterJob()
		{
		}

		internal int AddCloth(ClothProcess cprocess, in ClothParameters clothParams)
		{
			return 0;
		}

		internal void RemoveCloth(ClothProcess cprocess)
		{
		}

		private void OnEarlyClothUpdate()
		{
		}

		private void OnFirstPreUpdate()
		{
		}

		private void OnBeforeLateUpdate()
		{
		}

		private void OnAfterLateUpdate()
		{
		}

		private void ClothUpdate()
		{
		}

		internal void ClearVisibleDict()
		{
		}

		internal bool CheckVisible(Animator ani, List<Renderer> renderers)
		{
			return false;
		}

		private bool CheckRendererVisible(List<Renderer> renderers)
		{
			return false;
		}

		public void InformationLog(StringBuilder allsb)
		{
		}
	}
}
