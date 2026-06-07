using System.Collections.Generic;
using ManagementScripts;
using SettingScripts;
using SimulationScripts.BibiteScripts;
using TMPro;
using UIScripts.InfoHandles;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Utility;

namespace UIScripts.UIReferences
{
	public class BibiteTemplateGenePreviewer : MonoBehaviour
	{
		[Header("Parameters")]
		public bool rotateModelWithDiet = true;

		public bool sqrtSizing = true;

		[FormerlySerializedAs("scale")]
		public float baseScale = 6f;

		public float maxScale = 12f;

		[Header("Reference")]
		public GameObject FoodPreviewHolder;

		public GameObject Bibite;

		public SpriteRenderer MouthImage;

		public SpriteRenderer BodyImage;

		public SpriteRenderer Arm1Image;

		public SpriteRenderer Arm2Image;

		public SpriteRenderer EyesImage;

		public SpriteRenderer ExoskeletonImage;

		private Material bibiteMat;

		private Material eyeMat;

		public Material BibiteMaterial;

		public Material EyeMaterial;

		public TextMeshProUGUI nameText;

		public TextMeshProUGUI descText;

		public FloatValueTextHandle nodeNumber;

		public FloatValueTextHandle synapseNumber;

		private List<SpriteRenderer> BodyImages;

		public Image PlantImage;

		public Image MeatImage;

		private float r;

		private float g;

		private float b;

		private float size;

		private int sizeIndex;

		private float herb;

		private float carn;

		private BibiteTemplate template;

		private static readonly int HueShift = Shader.PropertyToID("_hueShift");

		private static readonly int Color1 = Shader.PropertyToID("_Color");

		public void InitializePreview()
		{
			BodyImages = new List<SpriteRenderer> { MouthImage, BodyImage, Arm1Image, Arm2Image, ExoskeletonImage };
			bibiteMat = Object.Instantiate(BibiteMaterial);
			eyeMat = Object.Instantiate(EyeMaterial);
			BodyImages.ForEach(delegate(SpriteRenderer m)
			{
				m.sharedMaterial = bibiteMat;
			});
			EyesImage.material = eyeMat;
			if (PlantImage != null && MeatImage != null)
			{
				int num = ProceduralSpriteManager.Instance.ClosestSizeIndex(1f, ProceduralSpriteManager.SizeTypes.PelletSizes);
				PlantImage.sprite = ProceduralSpriteManager.Instance.RequestPlantSprite(num);
				MeatImage.sprite = ProceduralSpriteManager.Instance.RequestMeatSprite(num);
			}
			UpdateTemplate(template);
		}

		public void UpdateTemplate(BibiteTemplate bibiteTemplate)
		{
			template = bibiteTemplate;
			if (nameText != null)
			{
				nameText.text = ((template != null) ? template.name : "No bibites selected");
			}
			if (descText != null)
			{
				descText.text = ((template != null) ? template.description : "Select a bibite");
			}
			if (nodeNumber != null)
			{
				nodeNumber.SetValue((template != null) ? (template.nodes.Length - NEATBrain.NInputs - NEATBrain.NOutputs) : 0);
			}
			if (synapseNumber != null)
			{
				synapseNumber.SetValue((template != null) ? template.synapses.Length : 0);
			}
			size = ((template != null) ? (template.genes[3] * Mathf.Sqrt(BibiteGenes.GrowthAtMature(template.genes))) : 1f);
			sizeIndex = UserSettings.ProceduralSize.val switch
			{
				UserSettings.ProceduralSizeChoice.Genetic => ProceduralSpriteManager.Instance.ClosestSizeIndex(size), 
				UserSettings.ProceduralSizeChoice.Maturity => ProceduralSpriteManager.Instance.ClosestSizeIndex(1f), 
				UserSettings.ProceduralSizeChoice.Both => ProceduralSpriteManager.Instance.ClosestSizeIndex(size), 
				_ => ProceduralSpriteManager.Instance.ClosestSizeIndex(1f), 
			};
			BodyImage.sprite = ProceduralSpriteManager.Instance.RequestBodySprite(sizeIndex, 0);
			float value = baseScale * (sqrtSizing ? Mathf.Sqrt(size) : size);
			value = Mathf.Clamp(value, 0.05f, maxScale);
			Bibite.transform.localScale = Vector3.one * value;
			if (FoodPreviewHolder != null)
			{
				FoodPreviewHolder.transform.localScale = Vector3.one / (sqrtSizing ? Mathf.Sqrt(size) : 1f);
			}
			r = ((template != null) ? template.genes[5] : 0f);
			g = ((template != null) ? template.genes[6] : 0f);
			b = ((template != null) ? template.genes[7] : 0f);
			Color value2 = BibiteGenes.GenesToColor(r, g, b);
			bibiteMat.SetColor(Color1, value2);
			eyeMat.SetColor(Color1, value2);
			Material material = eyeMat;
			int hueShift = HueShift;
			BibiteTemplate bibiteTemplate2 = template;
			material.SetFloat(hueShift, (bibiteTemplate2 != null) ? bibiteTemplate2.genes[25] : 0.5f);
			float num = ((template != null) ? BibiteGenes.TotalOrganWAG(template.genes) : 1f);
			carn = ((template != null) ? template.genes[16] : 0.5f);
			herb = 1f - carn;
			float f = ((template != null) ? (template.genes[31] / num) : 0f);
			MouthImage.sprite = ProceduralSpriteManager.Instance.RequestMouthSprite(sizeIndex, carn, Mathf.Sqrt(f));
			if (rotateModelWithDiet)
			{
				Bibite.transform.rotation = Quaternion.Euler(0f, 0f, -90f - 2f * (carn - 0.5f) * 57.29578f * Mathf.Atan(40f / (112f * Mathf.Sqrt(size))));
			}
			if (PlantImage != null && MeatImage != null)
			{
				PlantImage.color = new Color(1f, 1f, 1f, 4f * herb * herb);
				PlantImage.rectTransform.localScale = Mathf.Sqrt(herb + 0.5f) * Vector3.one;
				MeatImage.color = new Color(1f, 1f, 1f, 4f * carn * carn);
				MeatImage.rectTransform.localScale = Mathf.Sqrt(carn + 0.5f) * Vector3.one;
			}
			float defenceProportion = ((template != null) ? (template.genes[29] / num) : 0f);
			ExoskeletonImage.sprite = ProceduralSpriteManager.Instance.RequestExoskeletonSprite(sizeIndex, 0, defenceProportion);
			float radiusGene = ((template != null) ? template.genes[13] : 80f);
			float angleGene = ((template != null) ? template.genes[12] : 120f);
			EyesImage.sprite = ProceduralSpriteManager.Instance.RequestEyeSprite(sizeIndex, radiusGene, angleGene);
			float speedGene = ((template != null) ? template.genes[4] : 1f);
			Arm1Image.sprite = ProceduralSpriteManager.Instance.RequestArmSprite(sizeIndex, speedGene);
			Arm2Image.sprite = Arm1Image.sprite;
		}

		private void OnDestroy()
		{
			if (bibiteMat != null)
			{
				Object.Destroy(bibiteMat);
			}
			if (eyeMat != null)
			{
				Object.Destroy(eyeMat);
			}
		}
	}
}
