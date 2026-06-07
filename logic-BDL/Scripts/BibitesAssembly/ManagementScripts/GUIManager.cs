using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OneUseScripts;
using PropertiesScripts;
using SettingScripts;
using SimulationScripts;
using SimulationScripts.BibiteScripts;
using SimulationScripts.Rendering;
using SteamIntegrations;
using TMPro;
using UIScripts;
using UIScripts.UIPanels;
using UnityEngine;

namespace ManagementScripts
{
	public class GUIManager : MonoBehaviour
	{
		public static GUIManager Instance;

		[SerializeField]
		private TimeKeeper timeKeeper;

		[SerializeField]
		private UserControl userControl;

		public TextMeshProUGUI timeText;

		[Header("Top-Left Buttons")]
		public GameObject TopLeftButtonHolder;

		public GameObject OpenBiologyPanelButton;

		[Header("Bibite Panels")]
		public BibiteStatsPanel StatsPanel;

		public ExpandedBrainPanel ExpandedBrainPanel;

		public BiologyPanel BiologyPanel;

		public GenesPanel GenesPanel;

		public BrainPanel BrainPanel;

		[Header("Utility Panels")]
		public ColorKillerPanel colorKillerPanel;

		public EscapePanel escapePanel;

		public BibiteTemplateSelectorPanel selectorPanel;

		public SaveGamePanel savePanel;

		public LoadGamePanel loadPanel;

		public WorkshopItemsPanel workshopItemsPanel;

		[Header("RightmostPanels")]
		public RightmostPanelsManager rightmostPanelsManager;

		public DynamicSettingsPanel dynamicSettingsPanel;

		public ZonesEditorPanel zonesEditorPanel;

		[Header("UI Elements")]
		[SerializeField]
		private FieldOfViewDisplay fieldOfViewDisplay;

		[SerializeField]
		private StatusBarsReference barsController;

		private BibitePanels curMenu;

		private GameObject target;

		private BibiteBody body;

		private EggHatching hatching;

		private ColorKiller colorSelector;

		private List<BibitePanel> bibitePanels;

		private List<UIPanel> utilityPanels;

		private UITargetType targetType;

		public bool hasTarget => target != null;

		private bool targetIsBibiteOrEgg
		{
			get
			{
				if (targetType != UITargetType.Bibite)
				{
					return targetType == UITargetType.Egg;
				}
				return true;
			}
		}

		private void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
			}
			else
			{
				Object.Destroy(this);
			}
			bibitePanels = new List<BibitePanel> { StatsPanel, BiologyPanel, GenesPanel, BrainPanel, ExpandedBrainPanel };
			utilityPanels = new List<UIPanel> { colorKillerPanel, escapePanel, savePanel, loadPanel, selectorPanel };
			if (SteamManager.Initialized)
			{
				utilityPanels.Add(workshopItemsPanel);
			}
		}

		private void Start()
		{
			bibitePanels.ForEach(delegate(BibitePanel panel)
			{
				panel.OpenPanel();
			});
			bibitePanels.ForEach(delegate(BibitePanel panel)
			{
				panel.ClosePanel();
			});
			utilityPanels.ForEach(delegate(UIPanel panel)
			{
				panel.Initialize();
			});
			utilityPanels.ForEach(delegate(UIPanel panel)
			{
				panel.ClosePanel();
			});
			fieldOfViewDisplay.SetTarget();
			userControl.onTargetChange.AddListener(delegate(GameObject arg)
			{
				OnTargetChanged(arg);
			});
			OnTargetChanged(target, checkTargetChanged: false);
			UpdateTime();
		}

		private void Update()
		{
			UpdateTime();
			if (!UserControl.AllowControl || !UserControl.AllowKeyboardControl)
			{
				return;
			}
			if (Input.GetKeyDown(KeyCode.Escape) && UINavigationManager.emptyEscapeStack)
			{
				escapePanel.OpenPanel();
			}
			if (targetIsBibiteOrEgg)
			{
				if (Input.GetKey(KeyCode.LeftControl) || (Input.GetKey(KeyCode.LeftMeta) && Input.GetKeyDown(KeyCode.C)))
				{
					CopyTagOfTarget();
				}
				if (Input.GetKey(KeyCode.LeftControl) || (Input.GetKey(KeyCode.LeftMeta) && Input.GetKeyDown(KeyCode.V)))
				{
					TagTarget();
				}
				if (Input.GetKeyDown(KeyCode.Alpha1))
				{
					OpenBibitePanel(BibitePanels.StatsPanel);
				}
				if (Input.GetKeyDown(KeyCode.Alpha2))
				{
					OpenBibitePanel(BibitePanels.GenesPanel);
				}
				if (Input.GetKeyDown(KeyCode.Alpha3))
				{
					OpenBibitePanel((targetType == UITargetType.Bibite) ? BibitePanels.BiologyPanel : BibitePanels.BrainPanel);
				}
				if (Input.GetKeyDown(KeyCode.Alpha4) && targetType == UITargetType.Bibite)
				{
					OpenBibitePanel(BibitePanels.BrainPanel);
				}
			}
		}

		public void CopyTagOfTarget()
		{
			if (body != null)
			{
				GUIUtility.systemCopyBuffer = body.gene.speciesTag;
			}
			else if (hatching != null)
			{
				GUIUtility.systemCopyBuffer = hatching.eggGene.speciesTag;
			}
		}

		public void TagTarget()
		{
			string systemCopyBuffer = GUIUtility.systemCopyBuffer;
			if (systemCopyBuffer.Length > 100)
			{
				return;
			}
			if (body != null)
			{
				body.gene.speciesTag = systemCopyBuffer;
			}
			else
			{
				if (!(hatching != null))
				{
					return;
				}
				hatching.eggGene.speciesTag = systemCopyBuffer;
			}
			if (curMenu == BibitePanels.StatsPanel)
			{
				StatsPanel.SetTarget(target);
			}
		}

		public void LayEggIfBibite()
		{
			if (target != null && targetType == UITargetType.Bibite)
			{
				body.eggLayer.LayEgg();
			}
		}

		public void TryKillTarget()
		{
			if (!(target == null))
			{
				switch (targetType)
				{
				case UITargetType.Bibite:
					body.Die();
					break;
				case UITargetType.Egg:
					hatching.Abort();
					break;
				case UITargetType.ColorSelector:
					Object.Destroy(target);
					break;
				case UITargetType.Zone:
					break;
				}
			}
		}

		public void OnTargetChanged(GameObject newTarget, bool checkTargetChanged = true)
		{
			if (bibitePanels[0] == null || (newTarget == target && checkTargetChanged))
			{
				return;
			}
			if (newTarget == null || !newTarget.GetComponent<TargetableObject>())
			{
				ClearTarget();
				return;
			}
			target = newTarget;
			targetType = UITargetType.None;
			if (newTarget.CompareTag("bibite"))
			{
				OpenBiologyPanelButton.SetActive(value: true);
				targetType = UITargetType.Bibite;
			}
			else if (newTarget.CompareTag("egg"))
			{
				OpenBiologyPanelButton.SetActive(value: false);
				targetType = UITargetType.Egg;
			}
			if (targetIsBibiteOrEgg)
			{
				TopLeftButtonHolder.SetActive(value: true);
				bibitePanels.ForEach(delegate(BibitePanel panel)
				{
					panel.SetTarget(newTarget);
				});
				barsController.TargetThat(newTarget);
				body = target.GetComponent<BibiteBody>();
				fieldOfViewDisplay.SetTarget(body);
				hatching = target.GetComponent<EggHatching>();
				OpenBibitePanel(curMenu, toggle: false);
				StartCoroutine("UpdateRealTimeUI", 0.25f);
				return;
			}
			fieldOfViewDisplay.SetTarget();
			TopLeftButtonHolder.SetActive(value: false);
			barsController.TargetThat(null);
			if (newTarget.CompareTag("zone") && UserSettings.OpenZoneEditorOnSelect.val)
			{
				CloseAllPanels();
				if (zonesEditorPanel.SelectItemOfZone(newTarget.GetComponent<Zone>()))
				{
					rightmostPanelsManager.OpenPanel(RightmostPanels.DynamicSettingsPanel);
					dynamicSettingsPanel.OpenTab(DynamicSettingsTabs.ZonesTab);
					targetType = UITargetType.Zone;
				}
			}
			else if (newTarget.CompareTag("ColorKiller"))
			{
				CloseAllPanels();
				colorKillerPanel.colorKiller = newTarget.GetComponent<ColorKiller>();
				colorKillerPanel.OpenPanel();
				targetType = UITargetType.ColorSelector;
			}
		}

		public void ClearTarget()
		{
			CloseAllPanels();
			bibitePanels.ForEach(delegate(BibitePanel panel)
			{
				panel.ResetState();
			});
			TopLeftButtonHolder.SetActive(value: false);
			fieldOfViewDisplay.SetTarget();
			barsController.TargetThat(null);
			targetType = UITargetType.None;
			target = null;
			body = null;
			hatching = null;
		}

		public void OpenBibitePanel(BibitePanelChoice panel)
		{
			OpenBibitePanel(panel.panel);
		}

		public void OpenBibitePanel(BibitePanels panel, bool toggle = true)
		{
			CloseAllPanels(panel);
			BibitePanel bibitePanel = bibitePanels.FirstOrDefault((BibitePanel p) => p.PanelIndex == panel);
			if (!(bibitePanel == null))
			{
				if (!bibitePanel.isActiveAndEnabled)
				{
					bibitePanel.OpenPanel();
					curMenu = panel;
				}
				else if (toggle)
				{
					bibitePanel.ClosePanel();
					curMenu = BibitePanels.None;
				}
			}
		}

		public void ResetPanelToNone()
		{
			curMenu = BibitePanels.None;
		}

		public void CloseAllPanels(BibitePanels except = BibitePanels.None)
		{
			if (bibitePanels[0] == null)
			{
				return;
			}
			bibitePanels.ForEach(delegate(BibitePanel p)
			{
				if (p.PanelIndex != except && p.isActiveAndEnabled)
				{
					p.ClosePanel();
				}
			});
			utilityPanels.ForEach(delegate(UIPanel p)
			{
				p.ClosePanel();
			});
		}

		private IEnumerator UpdateRealTimeUI(float delay)
		{
			WaitForSecondsRealtime wait = new WaitForSecondsRealtime(delay);
			while (target != null)
			{
				if (body != null && target.CompareTag("bibite"))
				{
					barsController.UpdateHealth(body.Health.Amount, body.Health.MaxAmount);
					barsController.UpdateEnergy(body.Energy.Amount, body.Energy.MaxAmount);
				}
				else if (target.CompareTag("egg"))
				{
					barsController.UpdateHealth(hatching.HatchRatio() * hatching.totalRequiredEnergy, hatching.totalRequiredEnergy);
					barsController.UpdateEnergy(hatching.freeEnergy, hatching.energy);
				}
				yield return wait;
			}
			barsController.TargetThat(null);
		}

		private void UpdateTime()
		{
			timeKeeper.UpdateTimes();
			timeText.text = $"Time: {timeKeeper.hours:00}:{timeKeeper.minutes:00}:{timeKeeper.seconds:00}" + $"\n{$"{timeKeeper.renderFramesPerSecond:F0} fps",-6}  /  {timeKeeper.logicFramePerSeconds:F0} tps" + $"\nsim/real: x{timeKeeper.simSecondsPerSeconds:F2}";
		}
	}
}
