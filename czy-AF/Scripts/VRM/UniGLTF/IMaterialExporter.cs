using UnityEngine;

namespace UniGLTF
{
	public interface IMaterialExporter
	{
		glTFMaterial ExportMaterial(Material m, TextureExportManager textureManager);
	}
}
