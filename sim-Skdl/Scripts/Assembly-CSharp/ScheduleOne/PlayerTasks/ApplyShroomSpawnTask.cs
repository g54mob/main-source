using System.Collections.Generic;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace ScheduleOne.PlayerTasks
{
	public class ApplyShroomSpawnTask : Task
	{
		private enum EStage
		{
			BreakUpChunks = 0,
			MixIntoSoil = 1
		}

		private const float DistanceBetweenMixes = 0.08f;

		private const float MixRadius = 0.1f;

		private const int MaskTextureSize = 128;

		private const int SmallChunkCount = 16;

		private ShroomSpawnDefinition _spawnDefinition;

		private MushroomBed _mushroomBed;

		private SpawnChunk _baseSpawnChunk;

		private EStage _currentStage;

		private DecalProjector _mixProjector;

		private Vector3 _lastMixPosition;

		private Texture2D _maskingTexture;

		private List<SpawnChunk> _mixedChunks;

		private bool _mixMouseUp;

		public ApplyShroomSpawnTask(MushroomBed mushroomBed, ShroomSpawnDefinition spawnDefinition)
		{
		}

		public override void StopTask()
		{
		}

		public override void Success()
		{
		}

		public override void Update()
		{
		}

		public override void LateUpdate()
		{
		}

		private void UpdateInstructionText()
		{
		}

		private void UpdateProgression()
		{
		}

		private bool GetCursorHoverOnSoil(out Vector3 hitPoint)
		{
			hitPoint = default(Vector3);
			return false;
		}

		private void TriggerMix(Vector3 mixPoint)
		{
		}

		private void PaintMask(int x, int y)
		{
		}

		private Texture2D CreateMaskTexture()
		{
			return null;
		}
	}
}
