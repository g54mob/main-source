using System;
using Assets.Scripts.Flight.Sim;
using ModApi;
using ModApi.Common.Events;
using ModApi.Craft;
using ModApi.Craft.Parts;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Flight.UI
{
	public class EvaPanelController : FlightPanelController
	{
		public delegate void PanelItemsVisibleChangedHandler();

		private delegate void EvaScriptChangedHandler();

		private const string TetherSeatedClass = "seated";

		private IEvaScript _evaScript;

		private FlightControls _flightControls;

		private int _fuelPercentage = -1;

		private TextMeshProUGUI _fuelText;

		private Transform _jumpAndFuelTextParent;

		private XmlElement _jumpButton;

		private XmlElement _panel;

		private XmlElement _tetherPanel;

		private InputSlider _tetherSlider;

		public CraftControls Controls { get; private set; }

		public EvaControlSchemeType EvaControlScheme
		{
			get
			{
				if (EvaScript == null)
				{
					return EvaControlSchemeType.FlightNormal;
				}
				return EvaScript.EvaControlScheme;
			}
		}

		public bool EvaGrounded => base.CraftNode.InContactWithPlanet;

		public IEvaScript EvaScript
		{
			get
			{
				return _evaScript;
			}
			set
			{
				bool num = value != _evaScript;
				_evaScript = value;
				if (num)
				{
					this.EvaScriptChanged?.Invoke();
				}
			}
		}

		private bool TetherPanelVisible
		{
			get
			{
				return _tetherPanel.gameObject.activeSelf;
			}
			set
			{
				_tetherPanel.SetActive(value);
			}
		}

		private bool TetherSliderVisible
		{
			get
			{
				return _tetherSlider.Element.gameObject.activeSelf;
			}
			set
			{
				_tetherSlider.Element.SetActive(value);
			}
		}

		public event PanelItemsVisibleChangedHandler PanelItemsVisibleChanged;

		private event EvaScriptChangedHandler EvaScriptChanged;

		public override void CraftNodeChanged(CraftNode craftNode)
		{
			Controls = craftNode?.Controls;
		}

		public override void Initialize(FlightSceneUiController flightSceneUiController)
		{
			base.Initialize(flightSceneUiController);
			Game.Instance.FlightScene.ActiveCommandPodChanged += OnActiveCommandPodChanged;
			Game.Instance.FlightScene.FlightEnded += OnFlightEnded;
			_flightControls = FlightSceneScript.Instance.FlightControls;
			Game.Instance.FlightScene.Initialized += delegate
			{
				OnActiveCommandPodChanged(Game.Instance.FlightScene.CraftNode);
				UpdatePanelVisibility();
			};
			new EventMigrator<IEvaScript>(() => EvaScript, delegate(IEvaScript evaScript)
			{
				evaScript.ActiveWhileInCrewCompartmentChanged += OnEvaInChairStateChanged;
			}, delegate(IEvaScript evaScript)
			{
				evaScript.ActiveWhileInCrewCompartmentChanged -= OnEvaInChairStateChanged;
			}).AddMigrationTrigger(() => this, delegate(EventMigrator<IEvaScript> migrator, EvaPanelController evaPanel)
			{
				evaPanel.EvaScriptChanged += migrator.MigrateEvent;
			}, delegate(EventMigrator<IEvaScript> migrator, EvaPanelController evaPanel)
			{
				evaPanel.EvaScriptChanged -= migrator.MigrateEvent;
			});
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			if (!Application.isPlaying)
			{
				return;
			}
			_fuelText = base.xmlLayout.GetElementById<TextMeshProUGUI>("fuel-percentage");
			_tetherPanel = base.xmlLayout.GetElementById("tether-panel");
			_jumpButton = base.xmlLayout.GetElementById("jump-button");
			if (_jumpButton != null)
			{
				_jumpAndFuelTextParent = _fuelText.rectTransform.parent;
				_jumpButton.AddOnMouseDownEvent(delegate
				{
					OnJumpButtonDown();
				});
				_jumpButton.AddOnMouseUpEvent(delegate
				{
					OnJumpButtonUp();
				});
			}
			XmlElement elementById = base.xmlLayout.GetElementById("tether-button");
			elementById.AddOnMouseDownEvent(delegate
			{
				OnTetherButtonDown();
			});
			elementById.AddOnMouseUpEvent(delegate
			{
				OnTetherButtonUp();
			});
			_tetherSlider = new InputSlider(() => (!EvaScript.TetherAdjustLengthEnabled) ? 0f : Controls.EvaTetherLength, delegate(float x)
			{
				Controls.EvaTetherLengthOffset = x;
			});
			_tetherSlider.CreateUi(base.xmlLayout.GetElementById("tether-slider"));
		}

		public override void UpdatePanel(CraftNode craftNode)
		{
			if (EvaScript == null)
			{
				return;
			}
			if (_fuelText != null)
			{
				int num = Utilities.RoundPercentage(craftNode.CraftScript.FlightData.RemainingFuelInStage);
				if (num != _fuelPercentage)
				{
					_fuelPercentage = num;
					_fuelText.text = $"{num}%";
				}
			}
			TetherPanelVisible = EvaScript.GrapplingHookEnabled;
			TetherSliderVisible = EvaScript.TetherAdjustLengthEnabled;
		}

		private void OnActiveCommandPodChanged(ICraftNode craftNode)
		{
			ICommandPod activeCommandPod = Game.Instance.FlightScene.CraftNode.CraftScript.ActiveCommandPod;
			EvaScript = activeCommandPod.EvaScript;
			UpdatePanelVisibility();
		}

		private void OnEvaInChairStateChanged()
		{
			UpdatePanelVisibility();
		}

		private void OnFlightEnded(object sender, EventArgs e)
		{
			Game.Instance.FlightScene.ActiveCommandPodChanged -= OnActiveCommandPodChanged;
			Game.Instance.FlightScene.FlightEnded -= OnFlightEnded;
		}

		private void OnJumpButtonDown()
		{
			_flightControls.EvaJumpUI = 1f;
		}

		private void OnJumpButtonUp()
		{
			_flightControls.EvaJumpUI = 0f;
		}

		private void OnTetherButtonDown()
		{
			_flightControls.EvaShootTetherUI = true;
		}

		private void OnTetherButtonUp()
		{
			_flightControls.EvaShootTetherUI = false;
		}

		private void UpdatePanelVisibility()
		{
			bool active;
			if (EvaScript != null)
			{
				switch (EvaScript.EvaControlScheme)
				{
				case EvaControlSchemeType.Eva:
					_jumpAndFuelTextParent?.gameObject.SetActive(value: true);
					_tetherPanel.gameObject.SetActive(value: true);
					_tetherPanel.RemoveClass("seated");
					active = true;
					break;
				case EvaControlSchemeType.EvaInChair:
					_jumpAndFuelTextParent?.gameObject.SetActive(value: false);
					_tetherPanel.gameObject.SetActive(value: true);
					_tetherPanel.AddClass("seated");
					active = true;
					break;
				case EvaControlSchemeType.FlightNormal:
					_jumpAndFuelTextParent?.gameObject.SetActive(value: false);
					_tetherPanel.gameObject.SetActive(value: false);
					_tetherPanel.RemoveClass("seated");
					active = false;
					break;
				default:
					Debug.LogWarning($"Unknown EvaControlSchemeType: {EvaScript.EvaControlScheme}");
					active = false;
					break;
				}
			}
			else
			{
				active = false;
			}
			Active = active;
			this.PanelItemsVisibleChanged?.Invoke();
		}
	}
}
