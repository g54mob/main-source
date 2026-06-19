using UnityEngine;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Configs/Retro Visual Manager", order = 1112)]
	public class RetroVisualManagerConfig : ScriptableObjectWithID
	{
		public Material RetroPlaneMaterial;

		public Vector3 MeshScale;

		public AnimationCurve MeshBias = AnimationCurve.Linear(0f, 0.5f, 0.5f, 0.16f);

		public Vector3 CameraLookAtOffset;

		public float CameraHeightOffset;

		public float CameraOffsetDistance = 12f;

		public float CameraFieldOfView;

		public int RetroTextureWidth = 32;

		public int RetroTextureHeight = 32;

		public int RetroFrameRate = 12;

		public AdvisorLighting Lighting;
	}
}
