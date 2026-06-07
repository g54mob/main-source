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
	public class BibiteGenePreviewer : MonoBehaviour
	{
		[Header("Parameters")]
		public bool rotateModelWithDiet = true;

		public bool sqrtSizing = true;

		public bool adjustOffset = true;

		private float baseOffset = 15f;

		private float baseAngle;

		[FormerlySerializedAs("scale")]
		public float baseScale = 6f;

		public float maxScale = 12f;

		[Header("Reference")]
		public Transform Bibite;

		public GameObject FoodPreviewHolder;

		public Image MouthImage;

		public Image BodyImage;

		public Image Arm1Image;

		public Image Arm2Image;

		public Image EyesImage;

		public Image ExoskeletonImage;

		public Material BibiteMaterial;

		public Material EyeMaterial;

		public TextMeshProUGUI nameText;

		public TextMeshProUGUI descText;

		public LayoutElement layoutElement;

		public FloatValueTextHandle nodeNumber;

		public FloatValueTextHandle synapseNumber;

		public Image PlantImage;

		public Image MeatImage;

		private Vector2 baseLayoutDim;

		private List<Image> bodyImages;

		private float r;

		private float g;

		private float b;

		private RectTransform mouthRT;

		private RectTransform bodyRT;

		private RectTransform arm1RT;

		private RectTransform arm2RT;

		private RectTransform eyesRT;

		private RectTransform exoskeletonRT;

		private float size;

		private int sizeIndex;

		private float carn;

		private BibiteTemplate template;

		private static readonly int SaturationOverride = Shader.PropertyToID("_saturationOverride");

		private static readonly int HueShift = Shader.PropertyToID("_hueShift");

		private static readonly int Color1 = Shader.PropertyToID("_Color");

		private bool hasInit;

		public void InitializePreview(bool thenUpdate = true)
		{
			if (!hasInit)
			{
				bodyImages = new List<Image> { MouthImage, BodyImage, Arm1Image, Arm2Image, ExoskeletonImage };
				mouthRT = MouthImage.GetComponent<RectTransform>();
				bodyRT = BodyImage.GetComponent<RectTransform>();
				arm1RT = Arm1Image.GetComponent<RectTransform>();
				arm2RT = Arm2Image.GetComponent<RectTransform>();
				eyesRT = EyesImage.GetComponent<RectTransform>();
				exoskeletonRT = ExoskeletonImage.GetComponent<RectTransform>();
				BibiteMaterial = Object.Instantiate(BibiteMaterial);
				EyeMaterial = Object.Instantiate(EyeMaterial);
				bodyImages.ForEach(delegate(Image m)
				{
					m.material = BibiteMaterial;
				});
				EyesImage.material = EyeMaterial;
				EyeMaterial.SetFloat(SaturationOverride, 1f);
				baseOffset = Bibite.localPosition.x;
				baseAngle = Bibite.rotation.eulerAngles.z;
				if (layoutElement != null)
				{
					baseLayoutDim = new Vector2(layoutElement.preferredWidth, layoutElement.preferredHeight);
				}
				hasInit = true;
				if (thenUpdate)
				{
					UpdateTemplate(template);
				}
			}
		}

		public void UpdateTemplate(BibiteTemplate bibiteTemplate)
		{
			if (!hasInit)
			{
				InitializePreview(thenUpdate: false);
			}
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
			float num = ProceduralSpriteManager.Instance.SizeRatioFromSizeIndex(sizeIndex);
			float num2 = (sqrtSizing ? Mathf.Sqrt(size) : size);
			float num3 = Mathf.Clamp(baseScale * num2, 0.05f, maxScale) / num;
			Bibite.localScale = Vector3.one * num3;
			if (layoutElement != null)
			{
				Vector2 vector = baseLayoutDim * num3;
				layoutElement.preferredWidth = vector.x;
				layoutElement.minWidth = vector.x;
				layoutElement.preferredHeight = vector.y;
				layoutElement.minHeight = vector.y;
			}
			if (adjustOffset)
			{
				Bibite.localPosition = new Vector3(baseOffset * num * num3 / baseScale, Bibite.localPosition.y, 0f);
			}
			if (FoodPreviewHolder != null)
			{
				FoodPreviewHolder.transform.localScale = Vector3.one / (sqrtSizing ? Mathf.Sqrt(size) : 1f);
			}
			r = ((template != null) ? template.genes[5] : 0f);
			g = ((template != null) ? template.genes[6] : 0f);
			b = ((template != null) ? template.genes[7] : 0f);
			Color value = BibiteGenes.GenesToColor(r, g, b);
			BibiteMaterial.SetColor(Color1, value);
			EyeMaterial.SetColor(Color1, value);
			Material eyeMaterial = EyeMaterial;
			int hueShift = HueShift;
			BibiteTemplate bibiteTemplate2 = template;
			eyeMaterial.SetFloat(hueShift, (bibiteTemplate2 != null) ? bibiteTemplate2.genes[25] : 0.5f);
			float num4 = ((template != null) ? BibiteGenes.TotalOrganWAG(template.genes) : 1f);
			BodyImage.sprite = ProceduralSpriteManager.Instance.RequestBodySprite(sizeIndex, 0);
			bodyRT.sizeDelta = BodyImage.sprite.rect.size;
			carn = ((template != null) ? template.genes[16] : 0.5f);
			float f = ((template != null) ? (template.genes[31] / num4) : 0f);
			MouthImage.sprite = ProceduralSpriteManager.Instance.RequestMouthSprite(sizeIndex, carn, Mathf.Sqrt(f));
			mouthRT.sizeDelta = MouthImage.sprite.rect.size;
			float defenceProportion = ((template != null) ? (template.genes[29] / num4) : 0f);
			ExoskeletonImage.sprite = ProceduralSpriteManager.Instance.RequestExoskeletonSprite(sizeIndex, 0, defenceProportion);
			exoskeletonRT.sizeDelta = ExoskeletonImage.sprite.rect.size;
			exoskeletonRT.pivot = ExoskeletonImage.sprite.pivot / exoskeletonRT.sizeDelta;
			exoskeletonRT.anchoredPosition = Vector2.zero;
			float radiusGene = ((template != null) ? template.genes[13] : 80f);
			float angleGene = ((template != null) ? template.genes[12] : 120f);
			EyesImage.sprite = ProceduralSpriteManager.Instance.RequestEyeSprite(sizeIndex, radiusGene, angleGene);
			eyesRT.sizeDelta = EyesImage.sprite.rect.size;
			eyesRT.pivot = EyesImage.sprite.pivot / eyesRT.sizeDelta;
			eyesRT.anchoredPosition = Vector2.zero;
			float speedGene = ((template != null) ? template.genes[4] : 80f);
			Arm1Image.sprite = ProceduralSpriteManager.Instance.RequestArmSprite(sizeIndex, speedGene);
			Arm2Image.sprite = Arm1Image.sprite;
			arm1RT.sizeDelta = Arm1Image.sprite.rect.size;
			arm2RT.sizeDelta = arm1RT.sizeDelta;
			arm1RT.anchoredPosition = bodyRT.sizeDelta.y / 2f * Vector2.up;
			arm2RT.anchoredPosition = -arm1RT.anchoredPosition;
			if (PlantImage != null && MeatImage != null)
			{
				float num5 = 1f - carn;
				PlantImage.color = new Color(1f, 1f, 1f, 4f * num5 * num5);
				PlantImage.rectTransform.localScale = Mathf.Sqrt(num5 + 0.5f) * Vector3.one;
				MeatImage.color = new Color(1f, 1f, 1f, 4f * carn * carn);
				MeatImage.rectTransform.localScale = Mathf.Sqrt(carn + 0.5f) * Vector3.one;
				if (rotateModelWithDiet)
				{
					Bibite.transform.rotation = Quaternion.Euler(0f, 0f, baseAngle - 2f * (carn - 0.5f) * 57.29578f * Mathf.Atan(40f / (112f * Mathf.Sqrt(size))));
				}
			}
		}

		private void OnDestroy()
		{
			if (hasInit)
			{
				Object.Destroy(BibiteMaterial);
				Object.Destroy(EyeMaterial);
			}
		}
	}
}
