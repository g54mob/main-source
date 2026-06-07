using UnityEngine;

namespace Brewery.NPC.TradingSystem
{
	[ExecuteAlways]
	public class TradingNPCSpawnPoint : MonoBehaviour
	{
		[Header("Spawn Configuration")]
		[Tooltip("Must match homeLocationId in TradingProfile")]
		[SerializeField]
		private string homeLocationId;

		[Tooltip("Optional: Manually specify which NPC to spawn (leave null for auto-match)")]
		[SerializeField]
		private TradingProfile npcProfile;

		[Header("Spawn Transform")]
		[Tooltip("Optional: Specific transform for spawn position/rotation")]
		[SerializeField]
		private Transform spawnTransform;

		[Tooltip("Position offset from spawn transform (local space)")]
		[SerializeField]
		private Vector3 spawnPositionOffset;

		[Header("Spawn Rotation Override")]
		[Tooltip("Enable to use custom Y rotation instead of transform rotation (useful when you have nested children you don't want to rotate)")]
		[SerializeField]
		private bool useCustomRotation;

		[Tooltip("Custom Y rotation in degrees (0 = forward/+Z, 90 = right/+X, 180 = back/-Z, 270 = left/-X)")]
		[Range(0f, 360f)]
		[SerializeField]
		private float spawnYRotation;

		[Header("Debug")]
		[SerializeField]
		private Color gizmoColor;

		[SerializeField]
		private bool showLabel;

		public string HomeLocationId => null;

		public TradingProfile NPCProfile => null;

		public Vector3 SpawnPosition => default(Vector3);

		public Quaternion SpawnRotation => default(Quaternion);

		private void OnValidate()
		{
		}
	}
}
