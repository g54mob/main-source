using UnityEngine;
using UnityEngine.Rendering;

namespace Placemaker.TownRenderPipeline
{
	[CreateAssetMenu]
	public class TRPAsset : RenderPipelineAsset
	{
		public Mesh skyboxMesh;

		public Material skyboxMaterial;

		public float skyboxFOV;

		protected override RenderPipeline CreatePipeline()
		{
			return null;
		}
	}
}
