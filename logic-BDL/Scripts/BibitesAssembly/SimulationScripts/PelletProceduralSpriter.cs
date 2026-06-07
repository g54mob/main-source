using ManagementScripts;
using UnityEngine;

namespace SimulationScripts
{
	public class PelletProceduralSpriter : MonoBehaviour
	{
		public MatterPellet pellet;

		public SpriteRenderer sr;

		private int sizeIndex = -1;

		private void Awake()
		{
			if (!(pellet == null))
			{
				sr = GetComponent<SpriteRenderer>();
				pellet.AfterAmountChange.AddListener(UpdatePelletSprite);
				if (pellet.amount > 0f)
				{
					UpdatePelletSprite();
				}
			}
		}

		private void UpdatePelletSprite(MatterPellet pelletSrc = null, float amount = 0f)
		{
			int num = ProceduralSpriteManager.Instance.ClosestSizeIndex(Mathf.Sqrt(pellet.sizeFactor), ProceduralSpriteManager.SizeTypes.PelletSizes);
			if (num != sizeIndex)
			{
				sizeIndex = num;
				sr.sprite = ProceduralSpriteManager.Instance.RequestPelletSpriteOfMaterial(pellet.material, sizeIndex);
			}
		}

		private void OnDestroy()
		{
			if (!(pellet == null))
			{
				pellet.AfterAmountChange.RemoveListener(UpdatePelletSprite);
			}
		}
	}
}
