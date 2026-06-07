namespace DigitalOpus.MB.Core
{
	public static class MeshBakerSettingsUtility
	{
		public static MB_MeshVertexChannelFlags GetMeshChannelsAsFlags(MB_IMeshBakerSettings settings, bool doVerts, bool uvsSliceIdx_w)
		{
			return default(MB_MeshVertexChannelFlags);
		}

		public static bool DoUV2getDataFromSourceMeshes(ref MB_IMeshBakerSettings settings)
		{
			return false;
		}
	}
}
