using System;
using System.Collections.Generic;
using System.Linq;
using ManagementScripts;
using OneUseScripts;
using ScriptHelpers;
using SettingScripts;
using SimulationScripts;
using SimulationScripts.BibiteScripts;
using UIScripts.InfoHandles;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utility;

namespace UIScripts.UIPanels
{
	public class BiologyPanel : BibitePanel, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerMoveHandler
	{
		public static BiologyPanel instance;

		public Image interns;

		private Material interns_mat;

		public Material sections_mat;

		public Material internsMat_fallback;

		private Texture2D tex;

		private int[] internsMap;

		private int interns_width;

		private int interns_height;

		[Header("Health Info References")]
		public ValueSliderHandle healthSlider;

		public FloatValueTextHandle maxHealthText;

		public GameObject healthDetailsPanel;

		public FloatValueTextHandle baseEnergyDensity;

		public FloatValueTextHandle bloodEnergyDensity;

		public FloatValueTextHandle healthMovementPenalty;

		public FloatValueTextHandle healRateText;

		public FloatValueTextHandle healRateHPText;

		[Header("Energy Info References")]
		public GameObject energyInfoPanel;

		public FloatValueTextHandle eggCostText;

		public FloatValueTextHandle efficiencyText;

		public ValueSliderHandle energySlider;

		public FloatValueTextHandle maxEnergyText;

		public RateSliderHandle energyRateSlider;

		public GameObject energyDetailsPanel;

		public Toggle sortEnergyDetailsToggle;

		public RateSliderHandle digestRateSlider;

		public RateSliderHandle moveRateSlider;

		public RateSliderHandle growthRateSlider;

		public RateSliderHandle metaRateSlider;

		public RateSliderHandle pheroRateSlider;

		public RateSliderHandle healRateSlider;

		public RateSliderHandle fatRateSlider;

		public RateSliderHandle fatSustainRateSlider;

		public RateSliderHandle brainRateSlider;

		public RateSliderHandle eggProductionRateSlider;

		[Header("Growth Info References")]
		public ProgressSliderHandle growthSlider;

		public GameObject growthDetailsPanel;

		public FloatValueTextHandle sizeFactor;

		public FloatValueTextHandle sizeGene;

		public FloatValueTextHandle growthFactor;

		public FloatValueTextHandle maturityFactor;

		public FloatValueTextHandle lengthIndicator;

		public FloatValueTextHandle areaIndicator;

		public BoolValueTextHandle isMature;

		public BoolValueTextHandle canLayEggs2;

		[Header("Age Info References")]
		public ProgressSliderHandle ageSlider;

		public GameObject ageDetailsPanel;

		public FloatValueTextHandle ageingThreshold;

		public FloatValueTextHandle ageingFactor;

		public FloatValueTextHandle strengthPenalty;

		public FloatValueTextHandle metabolismPenalty;

		[Header("Body Info References")]
		public GameObject bodyDetailsPanel;

		public FloatValueTextHandle bodySizeText;

		public FloatValueTextHandle armorArea;

		public FloatValueTextHandle armorThickness;

		public FloatValueTextHandle armorStrength;

		public FloatValueTextHandle armorPortion;

		public FloatValueTextHandle moveMusclesArea;

		public FloatValueTextHandle moveMusclesPortion;

		public FloatValueTextHandle moveMusclesStrength;

		public FloatValueTextHandle moveMusclesTurnStrength;

		public FloatValueTextHandle baseBodySizeText;

		public FloatValueTextHandle fatInflationText;

		public FloatValueTextHandle bodyEnergyText;

		public FloatValueTextHandle bodyEnergyDensityText;

		public FloatValueTextHandle meatEquivalencyText;

		public FloatValueTextHandle bibiteMassText;

		public FloatValueTextHandle baseMassText;

		public FloatValueTextHandle armorMassText;

		public FloatValueTextHandle stomachMassText;

		public FloatValueTextHandle eggsMassText2;

		public FloatValueTextHandle fatMassText2;

		[Header("Stomach Info References")]
		public RectTransform stomachContainer;

		public Image acidImage;

		public Image throat;

		public Image womb;

		private Color wombColor;

		public GameObject stomachDetailsPanel;

		public ValueSliderHandle fullnessSlider;

		public FloatValueTextHandle capacityText;

		public FloatValueTextHandle capacity2Text;

		public FloatValueTextHandle stomachPortionText;

		public FloatValueTextHandle fullnessPercentageText;

		public ValueSliderHandle acidLevelSlider;

		public FloatValueTextHandle digestionBonusText;

		public FloatValueTextHandle efficiencyMalusText;

		public ValueSliderHandle digestionPotentialSlider;

		public Transform stomachContentList;

		public GameObject stomachContentPrefab;

		public GameObject stomachEmptyText;

		public EdgeCollider2D stomachCollider;

		[Header("Womb Info References")]
		public GameObject wombDetailsPanel;

		public BoolValueTextHandle isWombActiveText;

		public FloatValueTextHandle wombCapacityText;

		public FloatValueTextHandle wombAreaPortion;

		public FloatValueTextHandle eggSizeText;

		public FloatValueTextHandle eggFloatCapacityText;

		public FloatValueTextHandle eggCapacityText;

		public GameObject onceMatureWombSection;

		public ProgressSliderHandle eggProductionSlider;

		public RateSliderHandle eggProductionEnergySlider;

		public FloatValueTextHandle eggProgressRateText;

		public ValueSliderHandle eggProgressSlider;

		public FloatValueTextHandle eggsStoredText;

		public FloatValueTextHandle eggCapacity2Text;

		public FloatValueTextHandle energyPerEggText;

		public FloatValueTextHandle eggsMassText;

		public ProgressSliderHandle eggLayingSlider;

		public EdgeCollider2D wombCollider;

		[Header("Mouth Info References")]
		public GameObject mouthDetailsPanel;

		public FloatValueTextHandle bitePeriodText;

		public ValueSliderHandle biteProgressSlider;

		public FloatValueTextHandle swallowText;

		public BoolValueTextHandle canSwallowText;

		public FloatValueTextHandle throatArea;

		public FloatValueTextHandle mouthOpeningText;

		public FloatValueTextHandle throatPortionText;

		public FloatValueTextHandle biteAmountText;

		public FloatValueTextHandle noBiteAmountText;

		public FloatValueTextHandle attackText;

		public BoolValueTextHandle canAttackText;

		public FloatValueTextHandle jawMusclesArea;

		public FloatValueTextHandle jawMusclesPortion;

		public FloatValueTextHandle mouthStrengthText;

		public FloatValueTextHandle attackStrengthText;

		[Header("Fat Info References")]
		public Image fatImage;

		public GameObject fatDetailsPanel;

		public DeadbandSliderHandle energyRatioSlider;

		public RateSliderHandle fatActivationSlider;

		public RateSliderHandle fatProductionSlider;

		public ValueSliderHandle fatEfficiencySlider;

		public RateSliderHandle fatEnergyConsumptionSlider;

		public ValueSliderHandle fatReserveSlider;

		public ProgressSliderHandle fatInflateSlider;

		public FloatValueTextHandle fatArea;

		public FloatValueTextHandle fatPortion;

		public FloatValueTextHandle fatInflateText;

		public FloatValueTextHandle fatEnergyText;

		public RateSliderHandle fatSustainSlider;

		public FloatValueTextHandle fatMassText;

		private BibiteStomach stomach;

		private BibiteMouth mouth;

		private BibiteBody body;

		private BibiteGenes genes;

		private BibiteGrowth growth;

		private BibitePheromoneOrgan pheromoneOrgan;

		private NEATBrain brain;

		private BibiteEggLayingOrgan eggLayer;

		private BibiteFatOrgan fat;

		private List<GameObject> onHoverPanels;

		private List<RateSliderHandle> energyRateSliders;

		private float previousTimeScale = 1f;

		private float maxEnergyDetailScale = 1f;

		private float metabolicCostEfficiency;

		private Vector2 pointerPos;

		private int fatStart = -1;

		private int fatEnd = -1;

		private Vector2 stomach_offset;

		private float stomach_r;

		private float stomach_h;

		private float stomach_w;

		private float stomach_d;

		private Vector2 womb_offset;

		private float womb_r;

		private float womb_R;

		private float womb_theta;

		[Header("References")]
		[SerializeField]
		private GameObject eggPrefab;

		[SerializeField]
		private Transform eggContainer;

		[SerializeField]
		private GameObject stomachPelletPrefab;

		private Camera cam;

		private ItemPool<UIEgg> eggPool;

		private UIEgg activeEgg;

		private ItemPool<StomachContentPellet> pelletPool;

		private readonly List<StomachContentUIHandle> stomachContentHandles = new List<StomachContentUIHandle>();

		private const float DefaultPelletRadius = 10f;

		private const float DefaultEggRadius = 5f;

		private const float GravityForce = 400f;

		private const float InternsWidthPixel = 195f;

		private const float WombEggBaseFactor = 25f;

		private bool sortEnergyDetails;

		private bool stomachContentFilled;

		private float eggProgress;

		private int nEggsDisplayed;

		private float acidLevel;

		private bool generateInternalsMap;

		private static readonly FloatSetting AgingThreshold = ScenarioSettings.Instance.ageingThreshold;

		private static float agingThreshold = AgingThreshold.SubscribeTo<FloatSetting, float>(UpdateAgingThreshold);

		private static readonly int WombPortion = Shader.PropertyToID("_WombPortion");

		private static readonly int ThroatPortion = Shader.PropertyToID("_ThroatPortion");

		private static readonly int StomachPortion = Shader.PropertyToID("_StomachPortion");

		private static readonly int MusclesPortion = Shader.PropertyToID("_MusclesPortion");

		private static readonly int JawPortion = Shader.PropertyToID("_JawPortion");

		private static readonly int ArmorPortion = Shader.PropertyToID("_ArmorPortion");

		private static readonly int Color1 = Shader.PropertyToID("_Color");

		private static readonly int FatStart = Shader.PropertyToID("_FatStart");

		private static readonly int FatEnd = Shader.PropertyToID("_FatEnd");

		private static readonly int FatFullness = Shader.PropertyToID("_FatFullness");

		private static readonly int InflateFactor = Shader.PropertyToID("_InflateFactor");

		private static readonly int StomachOffset = Shader.PropertyToID("_StomachOffset");

		private static readonly int StomachDim = Shader.PropertyToID("_StomachDim");

		private static readonly int AcidLevel = Shader.PropertyToID("_Fullness");

		public override BibitePanels PanelIndex => BibitePanels.BiologyPanel;

		private List<StomachContentPellet> stomachPellets => pelletPool.activeItems;

		private static void UpdateAgingThreshold(float val)
		{
			agingThreshold = val;
		}

		public override void InitPanel()
		{
			instance = this;
			cam = GameObject.Find("UICamera").GetComponent<Camera>();
			eggPool = new ItemPool<UIEgg>(eggPrefab, eggContainer, 10);
			pelletPool = new ItemPool<StomachContentPellet>(stomachPelletPrefab, stomachContainer, 40);
			onHoverPanels = new List<GameObject> { healthDetailsPanel, energyInfoPanel, energyDetailsPanel, growthDetailsPanel, ageDetailsPanel, bodyDetailsPanel, stomachDetailsPanel, mouthDetailsPanel, wombDetailsPanel, fatDetailsPanel };
			energyRateSliders = new List<RateSliderHandle> { digestRateSlider, moveRateSlider, growthRateSlider, metaRateSlider, pheroRateSlider, healRateSlider, brainRateSlider, fatRateSlider, fatSustainRateSlider, eggProductionRateSlider };
			interns_mat = interns.material;
			interns_width = interns_mat.GetInteger("_Width");
			interns_height = interns_mat.GetInteger("_Height");
			sections_mat.SetInteger("_Width", interns_width);
			sections_mat.SetInteger("_Height", interns_height);
			tex = new Texture2D(interns_width, interns_height);
			healthSlider.InitSliderHandle(100f, updatableScale: false);
			healthMovementPenalty.InitHandle();
			energySlider.InitSliderHandle(100f, updatableScale: false);
			energyRateSlider.InitSliderHandle(1f);
			energyRateSliders.ForEach(delegate(RateSliderHandle e)
			{
				e.InitSliderHandle(1f);
			});
			energyRateSliders.ForEach(delegate(RateSliderHandle e)
			{
				e.OnScaleRaised.AddListener(UpdateEnergyDetailsScale);
			});
			sortEnergyDetails = UserSettings.SortBiologyPanelEnergyDetails.val;
			sortEnergyDetailsToggle.isOn = sortEnergyDetails;
			sortEnergyDetailsToggle.onValueChanged.AddListener(ToggleSortEnergyDetails);
			growthSlider.InitProgressHandle(2f, 1f);
			growthSlider.OnTargetReachedChange.AddListener(UpdateIsMature);
			ageSlider.InitProgressHandle(1.25f * agingThreshold, agingThreshold);
			acidLevelSlider.InitSliderHandle(1f, updatableScale: false);
			digestionPotentialSlider.InitSliderHandle(1f);
			biteProgressSlider.InitSliderHandle(1f, updatableScale: false);
			wombColor = womb.color;
			eggProductionSlider.InitProgressHandle(1f, 0.15f, updatableScale: false);
			eggProductionEnergySlider.InitSliderHandle(1f);
			eggProgressSlider.InitSliderHandle(1f, updatableScale: false);
			eggLayingSlider.InitProgressHandle(1f, 0.25f, updatableScale: false);
			energyRatioSlider.InitSliderHandle(1f, updatableScale: false);
			fatActivationSlider.InitSliderHandle(1f, updatableScale: false);
		}

		public override void ResetState()
		{
			eggPool?.RetireAll();
			nEggsDisplayed = 0;
			ClearStomachContentUI();
			interns_mat.SetFloat(FatStart, 1f);
			interns_mat.SetFloat(FatEnd, 0f);
			stomach = null;
			mouth = null;
			body = null;
			genes = null;
			growth = null;
			pheromoneOrgan = null;
			brain = null;
			fat = null;
		}

		public override void FillPanel()
		{
			if (bibite.CompareTag("egg"))
			{
				if (base.isActiveAndEnabled)
				{
					GUIManager.Instance.OpenBibitePanel(BibitePanels.StatsPanel);
				}
				return;
			}
			body = bibite.GetComponent<BibiteBody>();
			stomach = body.stomach;
			mouth = body.mouth;
			eggLayer = body.eggLayer;
			growth = body.growth;
			pheromoneOrgan = bibite.GetComponent<BibitePheromoneOrgan>();
			brain = body.brain;
			genes = body.gene;
			fat = body.fat;
			if (stomach == null)
			{
				ClosePanel();
				return;
			}
			InternalsCalculator.FromGenes(genes.genes);
			stomach_offset = InternalsCalculator.stomachOffset;
			acidImage.material.SetVector(StomachOffset, stomach_offset);
			stomach_offset.y = 0f;
			stomach_r = InternalsCalculator.stomach_r;
			stomach_w = InternalsCalculator.stomach_w;
			stomach_d = stomach_w - 2f * stomach_r;
			List<Vector2> list = new List<Vector2>();
			int num = 10;
			float num2 = 0.5f;
			for (int i = 0; i < num; i++)
			{
				list.Add(5f * new Vector2(stomach_offset.x + stomach_d / 2f + (stomach_r - num2) * Mathf.Sin(MathF.PI * (float)i / (float)(num - 1)), (stomach_r - num2) * Mathf.Cos(MathF.PI * (float)i / (float)(num - 1))));
			}
			for (int j = 0; j < num; j++)
			{
				list.Add(5f * new Vector2(stomach_offset.x - stomach_d / 2f - (stomach_r - num2) * Mathf.Sin(MathF.PI * (float)j / (float)(num - 1)), (0f - (stomach_r - num2)) * Mathf.Cos(MathF.PI * (float)j / (float)(num - 1))));
			}
			list.Add(5f * new Vector2(stomach_offset.x + stomach_d / 2f, stomach_r - num2));
			acidImage.material.SetVector(StomachDim, new Vector2(stomach_w, 2f * stomach_r));
			acidImage.material.SetFloat(AcidLevel, stomach.digestOutput);
			stomach_offset *= 5f;
			stomach_r = 5f * (stomach_r - num2);
			stomach_h = 2f * stomach_r;
			stomach_d *= 5f;
			stomach_w *= 5f;
			stomachCollider.points = list.ToArray();
			womb_offset = InternalsCalculator.wombOffset;
			womb_offset.y = 0f;
			womb_r = InternalsCalculator.womb_r;
			womb_R = InternalsCalculator.womb_R;
			womb_theta = InternalsCalculator.womb_theta;
			list.Clear();
			for (int k = 0; k < num; k++)
			{
				list.Add(5f * new Vector2(womb_offset.x + (womb_r - num2) * Mathf.Sin(MathF.PI * (float)k / (float)(num - 1)), (womb_r - num2) * Mathf.Cos(MathF.PI * (float)k / (float)(num - 1))));
			}
			for (int l = 0; l < num - 1; l++)
			{
				list.Add(5f * new Vector2(womb_offset.x - (womb_R - num2) * Mathf.Sin(womb_theta * (float)l / (float)(num - 1)), womb_R - womb_r - (womb_R - num2) * Mathf.Cos(womb_theta * (float)l / (float)(num - 1))));
			}
			list.Add(5f * new Vector2(womb_offset.x - InternalsCalculator.womb_h + num2, 0f));
			for (int num3 = num - 2; num3 > 0; num3--)
			{
				list.Add(5f * new Vector2(womb_offset.x - (womb_R - num2) * Mathf.Sin(womb_theta * (float)num3 / (float)(num - 1)), womb_r - womb_R + (womb_R - num2) * Mathf.Cos(womb_theta * (float)num3 / (float)(num - 1))));
			}
			list.Add(5f * new Vector2(womb_offset.x, womb_r - num2));
			wombCollider.points = list.ToArray();
			womb_offset = (womb_offset - Vector2.right * InternalsCalculator.womb_h / 3f) * 5f;
			womb_r = 5f * (womb_r - num2);
			onHoverPanels.ForEach(delegate(GameObject p)
			{
				p.SetActive(value: false);
			});
			baseEnergyDensity.UpdateValue(body.baseEnergyDensity);
			bloodEnergyDensity.UpdateValue(body.baseEnergyDensity * ScenarioSettings.Instance.healthEnergyFactor.val / ScenarioSettings.Instance.healthPerArea.val);
			healRateText.UpdateValue(body.healMaxRate);
			UpdateIsMature(growth.maturity > 1f);
			armorPortion.UpdateValue(genes.armorAreaPortion);
			stomachPortionText.UpdateValue(genes.stomachAreaPortion);
			jawMusclesPortion.UpdateValue(genes.jawAreaPortion);
			wombAreaPortion.UpdateValue(genes.wombAreaPortion);
			throatPortionText.UpdateValue(genes.throatAreaPortion);
			fatPortion.UpdateValue(genes.fatAreaPortion);
			moveMusclesPortion.UpdateValue(genes.moveMusclesAreaPortion);
			interns_mat.SetFloat(WombPortion, genes.wombAreaPortion);
			interns_mat.SetFloat(ThroatPortion, genes.throatAreaPortion);
			interns_mat.SetFloat(StomachPortion, genes.stomachAreaPortion);
			interns_mat.SetFloat(MusclesPortion, genes.moveMusclesAreaPortion);
			interns_mat.SetFloat(JawPortion, genes.jawAreaPortion);
			interns_mat.SetFloat(ArmorPortion, genes.armorAreaPortion);
			interns_mat.SetFloat(FatFullness, 0f);
			interns_mat.SetColor(Color1, genes.GetBodyColor());
			interns_mat.SetFloat(InflateFactor, fat.inflateFactor);
			sections_mat.SetFloat(WombPortion, genes.wombAreaPortion);
			sections_mat.SetFloat(ThroatPortion, genes.throatAreaPortion);
			sections_mat.SetFloat(StomachPortion, genes.stomachAreaPortion);
			sections_mat.SetFloat(MusclesPortion, genes.moveMusclesAreaPortion);
			sections_mat.SetFloat(JawPortion, genes.jawAreaPortion);
			sections_mat.SetFloat(ArmorPortion, genes.armorAreaPortion);
			sections_mat.SetFloat(InflateFactor, fat.inflateFactor);
			generateInternalsMap = true;
			GenerateInternalsMap();
			eggCostText.UpdateValue(eggLayer.eggEnergy);
			efficiencyText.UpdateValue(genes.MetabolicEfficiency);
			maxEnergyDetailScale = 0.25f;
			energyRateSliders.ForEach(delegate(RateSliderHandle e)
			{
				e.InitSliderHandle(maxEnergyDetailScale);
			});
			metabolicCostEfficiency = genes.MetabolicEfficiency;
			growthSlider.InitProgressHandle(1.25f, 1f);
			sizeGene.UpdateValue(genes.Gene(BibiteGenes.Genes.SizeRatio));
			ageSlider.InitProgressHandle(1.25f * body.agingThreshold, body.agingThreshold);
			ageingThreshold.UpdateValue(body.agingThreshold);
			digestionPotentialSlider.InitSliderHandle(1f);
			if (base.isActiveAndEnabled)
			{
				FillStomachContentUI();
			}
			eggProductionEnergySlider.InitSliderHandle(1f);
			eggSizeText.UpdateValue(eggLayer.eggSize);
			energyPerEggText.UpdateValue(eggLayer.eggEnergy);
			energyRatioSlider.SetDeadband(fat.threshold - fat.deadband, Mathf.Min(0.99f, fat.threshold + fat.deadband));
			fatProductionSlider.InitSliderHandle(0.05f);
			fatSustainSlider.InitSliderHandle(0.05f);
			fatEfficiencySlider.InitSliderHandle(1f);
			fatEnergyConsumptionSlider.InitSliderHandle(1f);
			fatReserveSlider.InitSliderHandle(fat.area);
			fatArea.UpdateValue(fat.area);
			fatInflateSlider.InitProgressHandle(1f, 1f, updatableScale: false);
			fatImage.fillAmount = fat.fullness;
		}

		public override void ClosePanel()
		{
			onHoverPanels.ForEach(delegate(GameObject p)
			{
				p.SetActive(value: false);
			});
			Graphics.ClearRandomWriteTargets();
			ClearStomachContentUI();
			base.ClosePanel();
		}

		public override void OpenPanel()
		{
			base.OpenPanel();
			if (stomach == null)
			{
				ClosePanel();
				return;
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(base.gameObject.GetComponent<RectTransform>());
			FillStomachContentUI();
			UpdatePanel();
		}

		protected override void UpdatePanel()
		{
			if (!(stomach == null))
			{
				UpdateBodySection();
				UpdateBodyDetailsSection();
				UpdateStomachSection();
				UpdateWombSection();
				UpdateMouthSection();
				UpdateFatSection();
			}
		}

		private void FixedUpdate()
		{
			if (!base.isActiveAndEnabled || stomach == null || Time.deltaTime <= 0f || Time.timeScale <= 0f)
			{
				return;
			}
			_ = stomachContainer.rect;
			bool updateTimeScale = !Mathf.Approximately(previousTimeScale, Time.timeScale);
			stomachPellets.ForEach(delegate(StomachContentPellet c)
			{
				if (updateTimeScale)
				{
					c.ScaleSpeed(previousTimeScale / Time.timeScale);
				}
				Vector2 vector = (Vector2)c.transform.localPosition - stomach_offset;
				if (Mathf.Abs(vector.x) < stomach_d / 2f)
				{
					if (Mathf.Abs(vector.y) > stomach_r - c.radius)
					{
						vector = new Vector3(vector.x, Mathf.Sign(vector.y) * (stomach_r - c.radius));
					}
				}
				else
				{
					Vector2 vector2 = vector - Vector2.right * (Mathf.Sign(vector.x) * stomach_d) / 2f;
					if (vector2.magnitude > stomach_r - c.radius)
					{
						vector2 = vector2.normalized * (stomach_r - c.radius);
						vector = vector2 + Vector2.right * (Mathf.Sign(vector.x) * stomach_d) / 2f;
					}
				}
				c.Move(vector + stomach_offset - (Vector2)c.transform.localPosition);
				if (Mathf.InverseLerp(0f - stomach_r, stomach_r, vector.y) <= acidLevel)
				{
					c.ApplyForce(400f * (c.material.MassDensity / 0.02f - 1f) * Vector2.down);
				}
				else
				{
					c.ApplyForce(400f * Vector2.down);
				}
			});
		}

		public void GenerateInternalsMap()
		{
			if (!generateInternalsMap)
			{
				return;
			}
			generateInternalsMap = false;
			RenderTexture temporary = RenderTexture.GetTemporary(interns_width, interns_height);
			Graphics.Blit(null, temporary, sections_mat);
			RenderTexture.active = temporary;
			tex.ReadPixels(new Rect(0f, 0f, interns_width, interns_height), 0, 0);
			tex.Apply();
			Color[] pixels = tex.GetPixels();
			internsMap = new int[interns_width * interns_height];
			for (int i = 0; i < pixels.Length; i++)
			{
				internsMap[i] = Mathf.RoundToInt(pixels[i].r * 7f);
			}
			fatStart = -1;
			fatEnd = -1;
			int num = 7;
			for (int j = 2; j < interns_width; j++)
			{
				if (fatEnd >= 0)
				{
					break;
				}
				for (int k = 2 + (interns_height - 1) / 2; k < interns_height; k++)
				{
					if (internsMap[j + k * interns_width] == num)
					{
						fatEnd = j;
						break;
					}
				}
			}
			int num2 = interns_width - 1;
			while (num2 > fatEnd && fatStart < 0)
			{
				for (int l = 2 + (interns_height - 1) / 2; l < interns_height; l++)
				{
					if (internsMap[num2 + l * interns_width] == num)
					{
						fatStart = num2;
						break;
					}
				}
				num2--;
			}
			if (fatEnd > 0)
			{
				interns_mat.SetFloat(FatStart, (float)fatStart / (float)interns_width);
				interns_mat.SetFloat(FatEnd, (float)fatEnd / (float)interns_width);
			}
		}

		public void OnInternalsHover(bool hovering, Vector2 uv)
		{
		}

		private void UpdateBodySection()
		{
			healthSlider.scale = body.maxHealth;
			healthSlider.UpdateValue(body.health);
			maxHealthText.UpdateValue(body.maxHealth);
			if (healthDetailsPanel.activeSelf)
			{
				float num = ((body.ageStrengthPenaltyFactor > 0f) ? (body.move.movementPenalty / body.ageStrengthPenaltyFactor) : body.move.movementPenalty);
				healthMovementPenalty.UpdateValue(Mathf.Abs(1f - num));
				healRateHPText.UpdateValue(body.healMaxRate * body.maxHealth);
			}
			efficiencyText.UpdateValue(genes.MetabolicEfficiency);
			energySlider.scale = body.Energy.MaxAmount;
			energySlider.UpdateValue(body.Energy.Amount);
			maxEnergyText.UpdateValue(body.Energy.MaxAmount);
			energyRateSlider.UpdateValue(body.EnergyFlowRate);
			if (energyDetailsPanel.activeSelf)
			{
				digestRateSlider.UpdateValue(stomach.EnergyGainRate);
				moveRateSlider.UpdateValue((0f - body.move.movementCost) / metabolicCostEfficiency);
				growthRateSlider.UpdateValue((0f - growth.growthCostRate) / metabolicCostEfficiency);
				metaRateSlider.UpdateValue((0f - body.metabolism) / metabolicCostEfficiency);
				pheroRateSlider.UpdateValue((0f - pheromoneOrgan.pheromoneCost) / metabolicCostEfficiency);
				fatRateSlider.UpdateValue(fat.lastEnergyGainRate);
				fatSustainRateSlider.UpdateValue((0f - fat.lastEnergySustainRate) / metabolicCostEfficiency);
				healRateSlider.UpdateValue((0f - body.healingRateEnergyCost) / metabolicCostEfficiency);
				brainRateSlider.UpdateValue((0f - brain.brainUpkeepCost) / metabolicCostEfficiency);
				eggProductionRateSlider.UpdateValue((0f - eggLayer.energyConsumption) / metabolicCostEfficiency);
				if (!sortEnergyDetails)
				{
					return;
				}
				foreach (RateSliderHandle item in energyRateSliders.OrderByDescending((RateSliderHandle e) => e.value))
				{
					item.transform.parent.SetAsLastSibling();
				}
			}
			growthSlider.UpdateValue(growth.maturity);
			if (growthDetailsPanel.activeSelf)
			{
				sizeFactor.UpdateValue(body.d1Size);
				growthFactor.UpdateValue(growth.growth);
				maturityFactor.UpdateValue(growth.maturity);
				lengthIndicator.UpdateValue(body.bodyLength);
				areaIndicator.UpdateValue(body.baseBodyArea);
			}
			ageSlider.UpdateValue(body.age);
			if (ageDetailsPanel.activeSelf)
			{
				ageingFactor.UpdateValue(body.ageingFactor);
				strengthPenalty.UpdateValue(body.ageStrengthPenaltyFactor - 1f);
				metabolismPenalty.UpdateValue(body.ageMetabolismPenaltyFactor);
			}
		}

		private void UpdateStomachSection()
		{
			if (stomachDetailsPanel.activeSelf)
			{
				fullnessSlider.UpdateValue(stomach.totalAmount);
				fullnessSlider.scale = stomach.area;
				capacityText.UpdateValue(stomach.area);
				capacity2Text.UpdateValue(stomach.area);
				fullnessPercentageText.UpdateValue(stomach.fullness);
				acidLevelSlider.UpdateValue(stomach.digestOutput);
				digestionBonusText.UpdateValue(stomach.digestionPotentialBonus);
				efficiencyMalusText.UpdateValue(stomach.efficiencyMalus);
				digestionPotentialSlider.UpdateValue(stomach.digestionEffectiveness);
			}
			StomachContent[] stomachContents = stomach.stomachContents;
			for (int i = 0; i < stomachContents.Length; i++)
			{
				StomachContent content = stomachContents[i];
				StomachContentUIHandle stomachContentUIHandle = stomachContentHandles.FirstOrDefault((StomachContentUIHandle h) => h.Material == content.material);
				if (!(stomachContentUIHandle == null))
				{
					stomachContentUIHandle.UpdateContent(content, stomach.totalContent);
				}
			}
			AnimateStomach();
		}

		private void UpdateWombSection()
		{
			float maturity = growth.maturity;
			if (maturity < 1f)
			{
				wombColor.a = maturity * maturity;
				womb.color = wombColor;
			}
			UpdateWombAnimation();
			if (wombDetailsPanel.activeSelf)
			{
				wombCapacityText.UpdateValue(eggLayer.area);
				eggFloatCapacityText.UpdateValue(eggLayer.area / eggLayer.eggSize);
				eggCapacityText.UpdateValue(eggLayer.eggCapacity);
				eggCapacity2Text.UpdateValue(eggLayer.eggCapacity);
				if (onceMatureWombSection.activeSelf)
				{
					eggProductionSlider.UpdateValue(eggLayer.eggProduction);
					eggProductionEnergySlider.UpdateValue(0f - eggLayer.energyConsumption);
					eggProgressRateText.UpdateValue(eggLayer.eggProgressRate);
					eggProgressSlider.UpdateValue(eggLayer.currentEggProgress);
					eggsStoredText.UpdateValue(eggLayer.nEgg);
					eggsMassText.UpdateValue(eggLayer.mass);
					eggLayingSlider.UpdateValue(eggLayer.want2Lay);
				}
			}
		}

		private void UpdateMouthSection()
		{
			if (mouthDetailsPanel.activeSelf)
			{
				bitePeriodText.UpdateValue(mouth.bitePeriod);
				biteProgressSlider.UpdateValue(mouth.biteProgress / mouth.bitePeriod);
				swallowText.UpdateValue(mouth.swallowOutput);
				canSwallowText.UpdateValue(mouth.ableToSwallow);
				throatArea.UpdateValue(mouth.area);
				mouthOpeningText.UpdateValue(mouth.swallowWidth);
				biteAmountText.UpdateValue(mouth.swallowAmount);
				noBiteAmountText.UpdateValue(mouth.maxAmountNoBiteNeeded);
				attackText.UpdateValue(mouth.attackOutput);
				canAttackText.UpdateValue(mouth.readyToAttack);
				jawMusclesArea.UpdateValue(mouth.jawArea);
				mouthStrengthText.UpdateValue(mouth.jawStrength);
				attackStrengthText.UpdateValue(mouth.biteForce);
			}
		}

		private void UpdateFatSection()
		{
			fatImage.fillAmount = fat.fullness;
			interns_mat.SetFloat(FatFullness, Mathf.Min(1f, fat.fatReserves.Amount / fat.baseCapacity));
			if (fatDetailsPanel.activeSelf)
			{
				energyRatioSlider.UpdateValue(body.energyRatio);
				fatActivationSlider.UpdateValue(fat.lastActivation);
				fatProductionSlider.UpdateValue(fat.lastAmountRate);
				fatEfficiencySlider.UpdateValue(fat.lastEfficiency);
				fatEnergyConsumptionSlider.UpdateValue(fat.lastEnergyGainRate);
				fatReserveSlider.value = fat.fatReserves.Amount;
				fatReserveSlider.UpdateScale(fat.area);
				fatArea.UpdateValue(fat.area);
				fatInflateSlider.value = fat.fatReserves.Amount;
				fatInflateSlider.targetValue = fat.baseCapacity;
				fatInflateSlider.UpdateScale(fat.area);
				interns_mat.SetFloat(InflateFactor, fat.inflateFactor);
				fatInflateText.UpdateValue(fat.inflateFactor * 0.35f);
				fatEnergyText.UpdateValue(fat.fatReserves.energy);
				fatSustainSlider.UpdateValue(0f - fat.lastEnergySustainRate);
				fatMassText.UpdateValue(fat.mass);
			}
		}

		private void OnPostRender()
		{
			Graphics.ClearRandomWriteTargets();
		}

		private void UpdateBodyDetailsSection()
		{
			if (bodyDetailsPanel.activeSelf)
			{
				bodySizeText.UpdateValue(body.realBodyArea);
				armorArea.UpdateValue(body.armor.area);
				armorStrength.UpdateValue(body.armor.armorStrength);
				armorThickness.UpdateValue(body.armor.armorThickness);
				baseBodySizeText.UpdateValue(body.baseBodyArea);
				fatInflationText.UpdateValue(1f + fat.inflateFactor * 0.35f);
				float totalEnergy = body.totalEnergy;
				bodyEnergyText.UpdateValue(totalEnergy);
				bodyEnergyDensityText.UpdateValue(body.energyDensity);
				meatEquivalencyText.UpdateValue(MatterMaterialManager.Meat.AmountOfEnergy(totalEnergy));
				bibiteMassText.UpdateValue(body.mass);
				baseMassText.UpdateValue(body.baseMass);
				armorMassText.UpdateValue(body.armor.mass);
				stomachMassText.UpdateValue(stomach.mass);
				eggsMassText2.UpdateValue(eggLayer.mass);
				fatMassText2.UpdateValue(fat.mass);
				moveMusclesArea.UpdateValue(body.move.area);
				moveMusclesStrength.UpdateValue(body.move.muscleMoveStrength);
				moveMusclesTurnStrength.UpdateValue(body.move.muscleTurnStrength);
			}
		}

		private void AnimateStomach()
		{
			acidLevel = stomach.acidLevel;
			acidImage.material.SetFloat(AcidLevel, stomach.digestOutput);
			if (stomachPellets.Count < 1)
			{
				return;
			}
			for (int i = 0; i < stomach.nContent; i++)
			{
				StomachContent content = stomach.stomachContents[i];
				int n = stomachPellets.Count((StomachContentPellet c) => c.material == content.material);
				float digestedAmount = Time.deltaTime * content.digestionRate;
				stomachPellets.ForEach(delegate(StomachContentPellet c)
				{
					if (!(c.material != content.material))
					{
						digestedAmount += c.ChangeAmount((0f - digestedAmount) / (float)n);
						n--;
					}
				});
			}
			pelletPool.ReturnDelayedItems();
			previousTimeScale = Time.timeScale;
		}

		private void UpdateWombAnimation()
		{
			int num = Mathf.CeilToInt(eggLayer.eggProgress);
			if (num < 1)
			{
				if (nEggsDisplayed > 0)
				{
					eggPool.RetireAll();
				}
				nEggsDisplayed = 0;
				return;
			}
			float num2 = Mathf.Sqrt(eggLayer.eggSize / eggLayer.area) * womb_r / 5f;
			if (num > nEggsDisplayed)
			{
				int n = num - nEggsDisplayed;
				eggPool.WakeUpItems(n);
				for (int i = Mathf.Max(nEggsDisplayed - 1, 0); i < num; i++)
				{
					activeEgg = eggPool.activeItems[i];
					if (i >= nEggsDisplayed)
					{
						activeEgg.SetColor(genes.GetBodyColor());
						activeEgg.pos = womb_offset + Mathf.Max(0f, womb_r - 5f * num2) * UnityEngine.Random.insideUnitCircle;
						activeEgg.rotation = UnityEngine.Random.value * 360f;
					}
					if (i == num - 1)
					{
						break;
					}
					activeEgg.SetGrowing(0f);
					activeEgg.SetSize(num2, eggLayer.eggSize);
				}
			}
			else if (num < nEggsDisplayed)
			{
				for (int num3 = nEggsDisplayed - 1; num3 >= num; num3--)
				{
					eggPool.activeItems[num3].ReturnToPoolDelayed();
				}
				eggPool.ReturnDelayedItems();
				activeEgg = eggPool.activeItems[num - 1];
			}
			for (int j = 0; j < num - 1; j++)
			{
				eggPool.activeItems[j].SetSize(num2, eggLayer.eggSize);
			}
			nEggsDisplayed = num;
			eggProgress = eggLayer.currentEggProgress;
			activeEgg.SetGrowing(eggLayer.eggProduction);
			activeEgg.SetSize(num2 * Mathf.Sqrt(eggProgress), eggLayer.eggSize * eggProgress);
		}

		private void UpdateIsMature(bool mature)
		{
			isMature.UpdateValue(mature, check: false);
			isWombActiveText.UpdateValue(mature, check: false);
			onceMatureWombSection.SetActive(mature);
			wombColor.a = 1f;
			womb.color = wombColor;
			canLayEggs2.UpdateValue(mature, check: false);
		}

		private void AddMatterPellet(MatterMaterial mat, float amount, bool enter = false)
		{
			if (!(amount < 0f))
			{
				Rect rect = stomachContainer.rect;
				Vector2 vector = stomach_offset;
				float num = Mathf.Sqrt(amount / MathF.PI);
				float a = Mathf.Sqrt(amount / stomach.area) * stomach_r / 10f;
				a = 0.8f * Mathf.Max(a, stomach_r / 100f);
				vector += (enter ? new Vector2(stomach_d / 2f + stomach_r / 1.1f, 0f) : RandomExtension.RandomPointInside2DCapsule(new Vector2(stomach_w - num, stomach_h - num)));
				StomachContentPellet itemFromPool = pelletPool.GetItemFromPool();
				itemFromPool.InitPellet(vector, amount, a, mat);
				if (enter)
				{
					itemFromPool.GetComponent<Rigidbody2D>().linearVelocity = (Vector2.left + UnityEngine.Random.Range(-0.1f, 0.1f) * Vector2.up) * rect.width / 10f;
				}
			}
		}

		private void ClearStomachContentUI()
		{
			if (!stomachContentFilled)
			{
				return;
			}
			if (stomach != null)
			{
				stomach.onMatterEnter.RemoveListener(OnMatterSwallow);
				stomach.onMatterLeft.RemoveListener(OnMatterVomit);
				stomach.onNewMaterialEntered.RemoveListener(OnNewStomachMaterialEntered);
				stomach.onMaterialFinished.RemoveListener(OnStomachMaterialFinished);
			}
			pelletPool.RetireAll();
			foreach (StomachContentUIHandle stomachContentHandle in stomachContentHandles)
			{
				stomachContentHandle.gameObject.SetActive(value: false);
			}
			stomachContentFilled = false;
		}

		private void FillStomachContentUI()
		{
			if (stomachContentFilled)
			{
				return;
			}
			stomach.onMatterEnter.AddListener(OnMatterSwallow);
			stomach.onMatterLeft.AddListener(OnMatterVomit);
			stomach.onNewMaterialEntered.AddListener(OnNewStomachMaterialEntered);
			stomach.onMaterialFinished.AddListener(OnStomachMaterialFinished);
			for (int i = 0; i < stomach.nContent; i++)
			{
				StomachContent matter = stomach.stomachContents[i];
				CreateHandleOfMaterialContent(matter);
				float num = matter.amount;
				float num2 = Mathf.Min(Mathf.Max(matter.averageChunkAmount, stomach.area / 30f, 0.2f), stomach.area / 2f);
				while (num > 0f)
				{
					float num3 = num2 * UnityEngine.Random.Range(0.5f, 1.5f);
					if (num3 > num)
					{
						AddMatterPellet(matter.material, num);
						num = -0.01f;
					}
					else
					{
						AddMatterPellet(matter.material, num3);
						num -= num3;
					}
				}
			}
			stomachEmptyText.SetActive(stomach.isEmpty);
			stomachContentFilled = true;
		}

		private void CreateHandleOfMaterialContent(StomachContent matter)
		{
			StomachContentUIHandle stomachContentUIHandle = stomachContentHandles.FirstOrDefault((StomachContentUIHandle c) => c.Material == matter.material);
			if (stomachContentUIHandle != null)
			{
				stomachContentUIHandle.gameObject.SetActive(value: true);
				return;
			}
			stomachContentUIHandle = UnityEngine.Object.Instantiate(stomachContentPrefab, stomachContentList).GetComponent<StomachContentUIHandle>();
			stomachContentUIHandle.InitContentHandle(matter);
			stomachContentUIHandle.OnDigestionScaleUpdate.AddListener(OnStomachContentDigestionScaleUpdated);
			stomachContentUIHandle.OnEnergyGainScaleUpdate.AddListener(OnStomachContentEnergyScaleUpdated);
			stomachContentHandles.Add(stomachContentUIHandle);
		}

		private void UpdateEnergyDetailsScale(float raisedScale)
		{
			if (!(raisedScale < maxEnergyDetailScale))
			{
				maxEnergyDetailScale = raisedScale;
				energyRateSliders.ForEach(delegate(RateSliderHandle e)
				{
					e.UpdateScale(maxEnergyDetailScale);
				});
			}
		}

		private void ToggleSortEnergyDetails(bool sort)
		{
			sortEnergyDetails = sort;
			UserSettings.SortBiologyPanelEnergyDetails.SetValue(sort);
			if (!sort)
			{
				energyRateSliders.ForEach(delegate(RateSliderHandle e)
				{
					e.transform.parent.SetAsLastSibling();
				});
			}
		}

		private void OnMatterSwallow(MatterMaterial mat, float amount)
		{
			float num = stomach.area / 20f;
			if (amount > num)
			{
				AddMatterPellet(mat, amount, enter: true);
				return;
			}
			float num2 = stomachPellets.Where((StomachContentPellet c) => c.material == mat).Sum((StomachContentPellet c) => c.amount);
			if (num2 <= 0f)
			{
				AddMatterPellet(mat, amount, enter: true);
				return;
			}
			StomachContent stomachContent = stomach.stomachContents.FirstOrDefault((StomachContent c) => c.material == mat);
			if (stomachContent.amount - num2 > num)
			{
				AddMatterPellet(mat, stomachContent.amount - num2, enter: true);
			}
		}

		private void OnMatterVomit(MatterMaterial mat, float amount)
		{
			stomachPellets.ForEach(delegate(StomachContentPellet c)
			{
				if (!(c.material != mat) && amount != 0f)
				{
					amount -= c.ChangeAmount(0f - amount);
				}
			});
			pelletPool.ReturnDelayedItems();
		}

		private void OnNewStomachMaterialEntered(StomachContent content)
		{
			CreateHandleOfMaterialContent(content);
			stomachEmptyText.SetActive(value: false);
		}

		private void OnStomachMaterialFinished(MatterMaterial mat)
		{
			stomachPellets.Where((StomachContentPellet c) => c.material == mat).ToList().ForEach(delegate(StomachContentPellet p)
			{
				p.ReturnToPool();
			});
			StomachContentUIHandle stomachContentUIHandle = stomachContentHandles.FirstOrDefault((StomachContentUIHandle c) => c.Material == mat);
			if (!(stomachContentUIHandle == null))
			{
				stomachContentUIHandle.gameObject.SetActive(value: false);
				if (!stomachContentHandles.Any((StomachContentUIHandle h) => h.gameObject.activeSelf))
				{
					stomachEmptyText.SetActive(value: true);
				}
			}
		}

		private void OnStomachContentDigestionScaleUpdated(float scale)
		{
			stomachContentHandles.ForEach(delegate(StomachContentUIHandle c)
			{
				c.UpdateDigestionScale(scale);
			});
		}

		private void OnStomachContentEnergyScaleUpdated(float scale)
		{
			stomachContentHandles.ForEach(delegate(StomachContentUIHandle c)
			{
				c.UpdateEnergyScale(scale);
			});
		}

		private void OnDestroy()
		{
			sortEnergyDetailsToggle.onValueChanged.RemoveListener(ToggleSortEnergyDetails);
			energyRateSliders.ForEach(delegate(RateSliderHandle e)
			{
				e.OnScaleRaised.RemoveListener(UpdateEnergyDetailsScale);
			});
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			pointerPos = eventData.position;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			pointerPos = eventData.position;
			onHoverPanels.ForEach(delegate(GameObject p)
			{
				p.SetActive(value: false);
			});
		}

		public void OnPointerMove(PointerEventData eventData)
		{
			pointerPos = eventData.position;
			RectTransform rectTransform = interns.rectTransform;
			Vector2 localPoint = Vector2.zero;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(interns.rectTransform, pointerPos, UICamera.cam, out localPoint);
			Rect rect = rectTransform.rect;
			if (rectTransform.rect.Contains(localPoint))
			{
				Vector2 vector = (localPoint - rect.min) / rect.size;
				int num = Mathf.Clamp(Mathf.FloorToInt(vector.x * (float)interns_width), 0, interns_width - 1);
				int num2 = Mathf.Clamp(Mathf.FloorToInt(vector.y * (float)interns_height), 0, interns_height - 1);
				onHoverPanels.ForEach(delegate(GameObject p)
				{
					p.SetActive(value: false);
				});
				switch (internsMap[num + num2 * interns_width])
				{
				case 1:
					bodyDetailsPanel.SetActive(value: true);
					break;
				case 2:
					stomachDetailsPanel.SetActive(value: true);
					break;
				case 3:
					wombDetailsPanel.SetActive(value: true);
					break;
				case 4:
					mouthDetailsPanel.SetActive(value: true);
					break;
				case 5:
					bodyDetailsPanel.SetActive(value: true);
					break;
				case 6:
					mouthDetailsPanel.SetActive(value: true);
					break;
				case 7:
					fatDetailsPanel.SetActive(value: true);
					break;
				}
			}
		}
	}
}
