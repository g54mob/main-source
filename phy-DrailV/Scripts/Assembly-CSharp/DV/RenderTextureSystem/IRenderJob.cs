using UnityEngine;

namespace DV.RenderTextureSystem
{
	public interface IRenderJob
	{
		bool NeedsAlpha { get; }

		Vector2Int GetTargetTextureSize();

		float GetMipMapBias();

		float Prepare(Vector3 suggestedPosition, Quaternion suggestedRotation);

		void OnRenderCompleted(Texture render);
	}
}
