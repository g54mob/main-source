using System;
using System.Collections.Generic;
using ManagementScripts;
using SettingScripts;
using UnityEngine;

namespace SimulationScripts.BibiteScripts
{
	public class BibiteProceduralSpriter : MonoBehaviour
	{
		[Header("Materials")]
		public Material BibiteMaterial;

		public Material EyeMaterial;

		[Header("Sprites")]
		public SpriteRenderer Body;

		public SpriteRenderer Mouth;

		public SpriteRenderer LeftArm;

		public SpriteRenderer RightArm;

		public SpriteRenderer Eyes;

		public SpriteRenderer Exoskeleton;

		private List<SpriteRenderer> Sprites;

		private BibiteGenes bibiteGenes;

		private BibiteGrowth growth;

		private float[] genes;

		private int previousInflateIndex;

		private int previousSizeIndex = -1;

		private static readonly int HueShift = Shader.PropertyToID("_hueShift");

		private static readonly int Color1 = Shader.PropertyToID("_Color");

		private UserSettings.ProceduralSizeChoice sizeChoice;

		[NonSerialized]
		public float ppu;

		private void Awake()
		{
			Sprites = new List<SpriteRenderer> { Body, Mouth, LeftArm, RightArm, Exoskeleton };
			bibiteGenes = GetComponent<BibiteGenes>();
			growth = GetComponent<BibiteGrowth>();
			BibiteMaterial = UnityEngine.Object.Instantiate(BibiteMaterial);
			EyeMaterial = UnityEngine.Object.Instantiate(EyeMaterial);
			Sprites.ForEach(delegate(SpriteRenderer s)
			{
				s.sharedMaterial = BibiteMaterial;
			});
			Eyes.material = EyeMaterial;
		}

		private void Start()
		{
			if (UserSettings.ProceduralSize.val != UserSettings.ProceduralSizeChoice.Genetic && growth != null)
			{
				growth.onGrowth.AddListener(SpriteChangeFromGrowth);
			}
		}

		public void InitSprites()
		{
			genes = bibiteGenes.genes;
			sizeChoice = UserSettings.ProceduralSize.val;
			UserSettings.ProceduralSize.Subscribe(UpdateSizeChoice);
			BibiteMaterial.SetColor(Color1, bibiteGenes.GetBodyColor(objective: true));
			EyeMaterial.SetColor(Color1, bibiteGenes.GetBodyColor(objective: true));
			EyeMaterial.SetFloat(HueShift, bibiteGenes.Gene(BibiteGenes.Genes.EyeOffset));
		}

		public void SpriteChangeFromGrowth(float growthFactor)
		{
			float size = sizeChoice switch
			{
				UserSettings.ProceduralSizeChoice.Genetic => genes[3], 
				UserSettings.ProceduralSizeChoice.Maturity => Mathf.Sqrt(growthFactor), 
				UserSettings.ProceduralSizeChoice.Both => genes[3] * Mathf.Sqrt(growthFactor), 
				_ => 0f, 
			};
			int num = ProceduralSpriteManager.Instance.ClosestSizeIndex(size);
			if (num != previousSizeIndex)
			{
				previousSizeIndex = num;
				RequestAndSetSprites(previousSizeIndex, previousInflateIndex);
			}
		}

		public void SpriteChangeFromInflate(float inflateFactor)
		{
			int num = ProceduralSpriteManager.Instance.ClosestInflateIndex(previousSizeIndex, inflateFactor);
			if (num != previousInflateIndex)
			{
				previousInflateIndex = num;
				RequestAndSetSprites(previousSizeIndex, previousInflateIndex);
			}
		}

		private void UpdateSizeChoice(UserSettings.ProceduralSizeChoice val)
		{
			if (sizeChoice == UserSettings.ProceduralSizeChoice.Genetic && growth != null)
			{
				growth.onGrowth.AddListener(SpriteChangeFromGrowth);
			}
			if (val == UserSettings.ProceduralSizeChoice.Genetic && growth != null)
			{
				growth.onGrowth.RemoveListener(SpriteChangeFromGrowth);
			}
			sizeChoice = val;
			SpriteChangeFromGrowth(growth.growth);
		}

		private void RequestAndSetSprites(int sizeIndex, int inflateIndex)
		{
			float num = BibiteGenes.TotalOrganWAG(genes);
			Body.sprite = ProceduralSpriteManager.Instance.RequestBodySprite(sizeIndex, inflateIndex);
			ppu = Body.sprite.pixelsPerUnit;
			Eyes.sprite = ProceduralSpriteManager.Instance.RequestEyeSprite(sizeIndex, genes[13], genes[12]);
			Mouth.sprite = ProceduralSpriteManager.Instance.RequestMouthSprite(sizeIndex, genes[16], Mathf.Sqrt(genes[31] / num));
			LeftArm.sprite = ProceduralSpriteManager.Instance.RequestArmSprite(sizeIndex, genes[4]);
			RightArm.sprite = LeftArm.sprite;
			BibiteMaterial.SetFloat("_BodyWidth", Body.sprite.rect.height + 2f * RightArm.sprite.rect.height);
			Exoskeleton.sprite = ProceduralSpriteManager.Instance.RequestExoskeletonSprite(sizeIndex, inflateIndex, genes[29] / num);
		}

		public Material RequestSkinMaterial()
		{
			return BibiteMaterial;
		}

		private void OnDestroy()
		{
			UserSettings.ProceduralSize.UnSubscribe(UpdateSizeChoice);
			UnityEngine.Object.DestroyImmediate(BibiteMaterial);
			UnityEngine.Object.DestroyImmediate(EyeMaterial);
		}
	}
}
