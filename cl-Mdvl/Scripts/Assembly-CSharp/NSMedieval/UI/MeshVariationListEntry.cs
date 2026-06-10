using System;
using NSMedieval.Construction;
using NSMedieval.UI.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class MeshVariationListEntry : MonoBehaviour
	{
		[SerializeField]
		private Image image;

		[SerializeField]
		private Image backgroundImage;

		[SerializeField]
		private Button toggleButton;

		[SerializeField]
		private Graphic toggleGraphicCheckmark;

		[SerializeField]
		private Graphic toggleGraphicPartial;

		[NonSerialized]
		private MeshVariation variation;

		[NonSerialized]
		private MeshVariationList meshVariationList;

		public Button Toggle => toggleButton;

		public MeshVariation Variation => variation;

		public MeshVariationList MeshVariationList => meshVariationList;

		public void Init(MeshVariation variation, Color backgroundColor, MeshVariationList meshVariationList)
		{
			if (this.variation != variation)
			{
				this.variation = variation;
				this.meshVariationList = meshVariationList;
				backgroundImage.color = backgroundColor;
				if (!string.IsNullOrEmpty(variation.Icon))
				{
					image.gameObject.SetActive(value: true);
					image.sprite = AssetUtils.GetSprite(variation.Icon);
				}
				else
				{
					image.gameObject.SetActive(value: false);
				}
			}
		}

		public void SetCheckboxGraphic(bool enabled, bool partial)
		{
			toggleGraphicPartial.gameObject.SetActive(enabled && partial);
			toggleGraphicCheckmark.gameObject.SetActive(enabled && !partial);
		}
	}
}
