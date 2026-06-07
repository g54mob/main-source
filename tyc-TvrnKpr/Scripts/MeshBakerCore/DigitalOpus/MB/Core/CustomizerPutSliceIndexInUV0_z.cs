using UnityEngine;

namespace DigitalOpus.MB.Core
{
	[CreateAssetMenu(fileName = "MeshAssignCustomizerSimpleAPIPutSliceIdxInUV0_z", menuName = "Mesh Baker/Assign To Mesh Customizer/Simple API Put Slice Index In UV0.z", order = 1)]
	public class CustomizerPutSliceIndexInUV0_z : MB_DefaultMeshAssignCustomizer
	{
		public override void meshAssign_UV0(int channel, MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, Mesh mesh, Vector2[] uvs, float[] sliceIndexes)
		{
		}
	}
}
