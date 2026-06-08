using System.Collections.Generic;
using UnityEngine;

namespace Dorfromantik
{
	public class LakeShore : TileGround
	{
		[SerializeField]
		private List<MeshRenderer> potentialShoreMeshes;

		[SerializeField]
		private int seedOffset;

		private bool isSetup;

		protected override void InitializeTileReferences()
		{
			if (!isSetup)
			{
				if ((bool)tileGroundRenderer)
				{
					Object.Destroy(tileGroundRenderer.gameObject);
				}
				Random.InitState(tile.Seed + seedOffset);
				tileGroundRenderer = Object.Instantiate(potentialShoreMeshes[Random.Range(0, potentialShoreMeshes.Count)], base.transform);
				Randomizer.RandomizeSeed();
				if (currentBiomeConfiguration != null)
				{
					ApplyBiomeConfiguration(currentBiomeConfiguration);
				}
				isSetup = true;
			}
		}
	}
}
