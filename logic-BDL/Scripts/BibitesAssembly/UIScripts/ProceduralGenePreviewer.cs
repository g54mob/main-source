using System.Collections.Generic;
using ManagementScripts;
using SettingScripts;
using SimulationScripts.BibiteScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts
{
	public class ProceduralGenePreviewer : SettingPreviewer
	{
		[Header("Parameters")]
		public bool rotateModelWithDiet = true;

		public bool sqrtSizing = true;

		public float scale = 6f;

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

		private List<SpriteRenderer> BodyImages;

		public Image PlantImage;

		public Image MeatImage;

		public TextMeshProUGUI HealthText;

		public TextMeshProUGUI EnergyText;

		private float r;

		private float g;

		private float b;

		private float size;

		private int sizeIndex;

		private int inflateIndex;

		private float herb;

		private float carn;

		private float[] genes;

		private float WAGsum;

		public float maxScale = 10f;

		private float energyRatio;

		private static readonly int Color1 = Shader.PropertyToID("_Color");

		private static readonly int HueShift = Shader.PropertyToID("_hueShift");

		public override void InitializePreview()
		{
			settings = new List<ChangingSetting>
			{
				SpriteGeneratorSettings.inflateRatio,
				BibiteEditorSettings.colorR,
				BibiteEditorSettings.colorG,
				BibiteEditorSettings.colorB,
				BibiteEditorSettings.eyeOffset,
				BibiteEditorSettings.diet,
				BibiteEditorSettings.armorWAG,
				BibiteEditorSettings.stomachWAG,
				BibiteEditorSettings.wombWAG,
				BibiteEditorSettings.fatDeadband,
				BibiteEditorSettings.jawWAG,
				BibiteEditorSettings.throatWAG,
				BibiteEditorSettings.moveWAG,
				BibiteEditorSettings.sizeRatio,
				UserSettings.ProceduralSize,
				BibiteEditorSettings.speedRatio,
				BibiteEditorSettings.viewRadius,
				BibiteEditorSettings.viewAngle,
				BibiteEditorSettings.hatchTime,
				BibiteEditorSettings.broodTime
			};
			BodyImages = new List<SpriteRenderer> { MouthImage, BodyImage, Arm1Image, Arm2Image, ExoskeletonImage };
			bibiteMat = Object.Instantiate(BibiteMaterial);
			eyeMat = Object.Instantiate(EyeMaterial);
			BodyImages.ForEach(delegate(SpriteRenderer m)
			{
				m.sharedMaterial = bibiteMat;
			});
			EyesImage.sharedMaterial = eyeMat;
			if (PlantImage != null && MeatImage != null)
			{
				int num = ProceduralSpriteManager.Instance.ClosestSizeIndex(1f, ProceduralSpriteManager.SizeTypes.PelletSizes);
				PlantImage.sprite = ProceduralSpriteManager.Instance.RequestPlantSprite(num);
				MeatImage.sprite = ProceduralSpriteManager.Instance.RequestMeatSprite(num);
			}
			genes = new float[BibiteGenes.NGene];
			base.InitializePreview();
		}

		protected override void UpdatePreview()
		{
			foreach (GeneSetting geneSetting in BibiteEditorSettings.geneSettings)
			{
				genes[(int)geneSetting.gene] = geneSetting.val;
			}
			size = UserSettings.ProceduralSize.val switch
			{
				UserSettings.ProceduralSizeChoice.Genetic => BibiteEditorSettings.sizeRatio.val, 
				UserSettings.ProceduralSizeChoice.Maturity => BibiteGenes.GrowthAtMature(genes), 
				UserSettings.ProceduralSizeChoice.Both => BibiteEditorSettings.sizeRatio.val * BibiteGenes.GrowthAtMature(genes), 
				_ => 1f, 
			};
			sizeIndex = ProceduralSpriteManager.Instance.ClosestSizeIndex(size);
			inflateIndex = ProceduralSpriteManager.Instance.ClosestInflateIndex(sizeIndex, SpriteGeneratorSettings.inflateRatio.val);
			BodyImage.sprite = ProceduralSpriteManager.Instance.RequestBodySprite(sizeIndex, inflateIndex);
			Bibite.transform.localScale = Vector3.one * Mathf.Min(maxScale, scale * (sqrtSizing ? Mathf.Sqrt(size) : size));
			if (FoodPreviewHolder != null)
			{
				FoodPreviewHolder.transform.localScale = Vector3.one / (sqrtSizing ? Mathf.Sqrt(size) : 1f);
			}
			UpdateBibiteColor();
			UpdateBibiteDiet();
			UpdateBibiteExoskeleton();
			UpdateBibiteVision();
			UpdateBibiteSpeed();
			UpdateStatusBars();
		}

		private void UpdateBibiteColor()
		{
			r = BibiteEditorSettings.colorR.val;
			g = BibiteEditorSettings.colorG.val;
			b = BibiteEditorSettings.colorB.val;
			Color value = BibiteGenes.GenesToColor(r, g, b);
			bibiteMat.SetColor(Color1, value);
			eyeMat.SetColor(Color1, value);
		}

		private void UpdateBibiteDiet()
		{
			carn = BibiteEditorSettings.diet.val;
			herb = 1f - carn;
			float strengthGene = Mathf.Sqrt(BibiteGenes.JawAreaPortion(genes));
			MouthImage.sprite = ProceduralSpriteManager.Instance.RequestMouthSprite(sizeIndex, carn, strengthGene);
			if (rotateModelWithDiet)
			{
				Bibite.transform.rotation = Quaternion.Euler(0f, 0f, -90f - 2f * (carn - 0.5f) * 57.29578f * Mathf.Atan(40f / (112f * Mathf.Sqrt(size))));
			}
			if (!(PlantImage == null) && !(MeatImage == null))
			{
				PlantImage.color = new Color(1f, 1f, 1f, 4f * herb * herb);
				PlantImage.rectTransform.localScale = Mathf.Sqrt(herb + 0.5f) * Vector3.one;
				MeatImage.color = new Color(1f, 1f, 1f, 4f * carn * carn);
				MeatImage.rectTransform.localScale = Mathf.Sqrt(carn + 0.5f) * Vector3.one;
			}
		}

		private void UpdateBibiteExoskeleton(float arg1 = 0f, float arg2 = 0f)
		{
			float defenceProportion = BibiteGenes.ArmorOrganAreaPortion(genes);
			ExoskeletonImage.sprite = ProceduralSpriteManager.Instance.RequestExoskeletonSprite(sizeIndex, inflateIndex, defenceProportion);
		}

		private void UpdateBibiteVision(float arg1 = 0f, float arg2 = 0f)
		{
			float val = BibiteEditorSettings.viewRadius.val;
			float val2 = BibiteEditorSettings.viewAngle.val;
			float val3 = BibiteEditorSettings.eyeOffset.val;
			EyesImage.sprite = ProceduralSpriteManager.Instance.RequestEyeSprite(sizeIndex, val, val2);
			eyeMat.SetFloat(HueShift, val3);
		}

		private void UpdateBibiteSpeed(float arg1 = 0f, float arg2 = 0f)
		{
			float val = BibiteEditorSettings.speedRatio.val;
			Arm1Image.sprite = ProceduralSpriteManager.Instance.RequestArmSprite(sizeIndex, val);
			Arm2Image.sprite = Arm1Image.sprite;
		}

		private void UpdateStatusBars(float arg1 = 0f, float arg2 = 0f)
		{
			if (!(HealthText == null) && !(EnergyText == null))
			{
				energyRatio = ScenarioSettings.Instance.storableEnergyPerArea.val;
				float num = 100f * size * size;
				float f = num * energyRatio;
				HealthText.text = $"{Mathf.Round(num)} / {Mathf.Round(num)}";
				EnergyText.text = $"{Mathf.Round(f)} / {Mathf.Round(f)}";
			}
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
