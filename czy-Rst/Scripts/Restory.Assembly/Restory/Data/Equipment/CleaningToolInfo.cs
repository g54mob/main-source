using FMODUnity;
using UnityEngine;

namespace Restory.Data.Equipment
{
	[CreateAssetMenu(fileName = "Cleaning Tool - Name", menuName = "Restory/Equipment/CleaningTool")]
	public class CleaningToolInfo : ElementCleanerToolInfoBase
	{
		private static class Style
		{
			public const string CleaningPowerGroup = "Cleaning Power";

			public const string BrushApplicationGroup = "Brush Usage";

			public const string VfxGroup = "VFX";

			public const string CleaningCollisionVfxGroup = "VFX/Cleaning Collision Vfx";
		}

		[SerializeField]
		private Texture2D brushTextureSource;

		[SerializeField]
		private Vector2Int brushSize = new Vector2Int(128, 128);

		[SerializeField]
		[Min(0.1f)]
		private float brushRaycastRingsSpacing = 10f;

		[SerializeField]
		[Min(0f)]
		private float brushRaycastRayMaxRandomDeviation = 1f;

		[SerializeField]
		private bool areBrushRaysCastParallelInWorldSpace;

		[SerializeField]
		[Range(0f, 1f)]
		private float redCleanPower = 1f;

		[SerializeField]
		[Range(0f, 1f)]
		private float greenCleanPower = 1f;

		[SerializeField]
		[Range(0f, 1f)]
		private float blueCleanPower = 1f;

		[SerializeField]
		[Range(0f, 1f)]
		private float alphaCleanPower = 1f;

		[SerializeField]
		private Vector2 cleaningCursorSize = new Vector2Int(128, 128);

		[SerializeField]
		private int maxCleaningResidueVfxInstances = 1;

		[SerializeField]
		private ParticleSystem cleaningCollisionVFX;

		[SerializeField]
		[Range(1f, 10f)]
		private int maxCleaningCollisionVfxInstancesActive = 1;

		[SerializeField]
		[Range(0.1f, 1f)]
		private float cleaningCollisionVfxEmissionMinTime = 0.2f;

		[SerializeField]
		private EventReference toolWorkProcessSoundLoop;

		[SerializeField]
		private EventReference toolWorkProcessEmptySoundLoop;

		public Texture2D BrushTexture => brushTextureSource;

		public Vector2Int BrushSize => brushSize;

		public float RedCleanPower => redCleanPower;

		public float GreenCleanPower => greenCleanPower;

		public float BlueCleanPower => blueCleanPower;

		public float AlphaCleanPower => alphaCleanPower;

		public float BrushRaycastRingsSpacing => brushRaycastRingsSpacing;

		public float BrushRaycastRayMaxRandomDeviation => brushRaycastRayMaxRandomDeviation;

		public bool AreBrushRaysCastParallelInWorldSpace => areBrushRaysCastParallelInWorldSpace;

		public override Vector2 CursorSize => cleaningCursorSize;

		public ParticleSystem CleaningCollisionVFX => cleaningCollisionVFX;

		public int MaxCleaningCollisionVfxInstancesActive => maxCleaningCollisionVfxInstancesActive;

		public float CleaningCollisionVfxEmissionMinTime => cleaningCollisionVfxEmissionMinTime;

		public int MaxCleaningResidueVfxInstances => maxCleaningResidueVfxInstances;

		public EventReference ToolWorkProcessSoundLoop => toolWorkProcessSoundLoop;

		public EventReference ToolWorkProcessEmptySoundLoop => toolWorkProcessEmptySoundLoop;
	}
}
