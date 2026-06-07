using UnityEngine;

namespace JBooth.MicroVerseCore
{
	public interface ISpawner : IModifier
	{
		bool UsesOtherTreeSDF();

		bool UsesOtherObjectSDF();

		bool NeedParentSDF();

		bool NeedToGenerateSDFForChilden();

		void SetSDF(Terrain t, RenderTexture rt);

		RenderTexture GetSDF(Terrain t);
	}
}
