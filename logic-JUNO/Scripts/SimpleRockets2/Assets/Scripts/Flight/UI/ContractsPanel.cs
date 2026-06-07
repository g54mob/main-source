using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Career.Contracts;
using Assets.Scripts.Career.Contracts.Requirements;
using Assets.Scripts.Input;
using Assets.Scripts.State;
using Assets.Scripts.Ui;
using ModApi.Audio;
using ModApi.Craft;
using ModApi.Flight;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Flight.UI
{
	public class ContractsPanel
	{
		public class ContractElement
		{
			private bool _isExpenaded;

			private ContractsPanel _panel;

			private ContractStatus _status;

			public Contract Contract { get; }

			public XmlElement Element { get; }

			public ContractFeedback FeedbackPanel { get; internal set; }

			public XmlElement Icon { get; }

			public bool IsExpanded
			{
				get
				{
					return _isExpenaded;
				}
				set
				{
					if (_isExpenaded != value)
					{
						_isExpenaded = value;
						if (_isExpenaded)
						{
							RefreshRequirements(clear: false);
						}
						else
						{
							ClearRequirements();
						}
					}
				}
			}

			public List<RequirementElement> Requirements { get; private set; } = new List<RequirementElement>();

			public ContractElement(XmlElement element, Contract contract, ContractsPanel panel)
			{
				Element = element;
				Contract = contract;
				_panel = panel;
				element.GetElementByInternalId<TextMeshProUGUI>("description").text = "<color=#fff>" + contract.Name + "</color>" + contract.GetContractNumberText() + " - " + contract.DescriptionShort;
				Icon = element.GetElementByInternalId("icon");
			}

			public void RefreshRequirements(bool clear)
			{
				if (clear)
				{
					ClearRequirements();
				}
				int num = Element.transform.GetSiblingIndex() + 1;
				foreach (ContractRequirement requirement in Contract.Requirements)
				{
					if (requirement.VisibilityType != RequirementVisibilityType.Hidden)
					{
						RequirementElement requirementElement = new RequirementElement(UiUtilities.CloneTemplate(_panel.RequirementTemplate, _panel.PanelElement), requirement);
						requirementElement.Element.transform.SetSiblingIndex(num++);
						Requirements.Add(requirementElement);
					}
				}
				if (Contract.DeadlineLength > 0)
				{
					DeadlineRequirementElement deadlineRequirementElement = new DeadlineRequirementElement(UiUtilities.CloneTemplate(_panel.RequirementTemplate, _panel.PanelElement), Contract);
					deadlineRequirementElement.Element.transform.SetSiblingIndex(num++);
					Requirements.Add(deadlineRequirementElement);
				}
			}

			public void Update()
			{
				foreach (RequirementElement requirement in Requirements)
				{
					requirement.Update();
				}
				if (_status != Contract.Status)
				{
					_status = Contract.Status;
					Icon.RemoveClass("failed");
					Icon.RemoveClass("passed");
					Icon.RemoveClass("incomplete");
					if (_status == ContractStatus.Complete)
					{
						Icon.AddClass("passed");
						ClearRequirements();
						Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Career.ContractComplete);
					}
					else if (_status == ContractStatus.Failed || _status == ContractStatus.Terminated)
					{
						Icon.AddClass("failed");
						IsExpanded = true;
						Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Career.ContractFail);
					}
					else
					{
						Icon.AddClass("incomplete");
					}
				}
			}

			private void ClearRequirements()
			{
				foreach (RequirementElement requirement in Requirements)
				{
					UnityEngine.Object.Destroy(requirement.Element.gameObject);
				}
				Requirements.Clear();
			}
		}

		public class DeadlineRequirementElement : RequirementElement
		{
			private double _daysUntilDeadline = -1.0;

			private bool _overdue;

			private ContractStatus _status;

			public Contract Contract { get; }

			public DeadlineRequirementElement(XmlElement element, Contract contract)
				: base(element, null)
			{
				Contract = contract;
				base.DescriptionText.text = "Deadline";
				base.Icon.RemoveClass("failed");
				base.Icon.RemoveClass("passed");
				base.Icon.RemoveClass("incomplete");
				base.Icon.AddClass("passed");
				_status = ContractStatus.Active;
			}

			public override void Update()
			{
				if (_status == ContractStatus.Complete)
				{
					return;
				}
				bool num = Contract.Status != _status;
				if (num)
				{
					_status = Contract.Status;
				}
				double daysUntilDeadline = _daysUntilDeadline;
				double daysUntilDeadline2 = Contract.GetDaysUntilDeadline(Game.Instance.FlightScene.FlightState.Time);
				if (!num && !(Math.Abs(daysUntilDeadline - daysUntilDeadline2) > 0.1))
				{
					return;
				}
				_daysUntilDeadline = daysUntilDeadline2;
				if (daysUntilDeadline2 <= 0.0)
				{
					if (!_overdue)
					{
						_overdue = true;
						base.Icon.RemoveClass("passed");
						base.Icon.AddClass("failed");
					}
					base.ValueText.text = $"{Math.Abs(daysUntilDeadline2):n1} days overdue";
				}
				else
				{
					base.ValueText.text = $"{daysUntilDeadline2:n1} days";
				}
			}
		}

		public class RequirementElement
		{
			public XmlElement Button { get; }

			public XmlElement Element { get; }

			public XmlElement Icon { get; }

			public bool IsSelected { get; set; }

			public ContractRequirement Requirement { get; }

			protected ContractRequirement.ButtonInformation ButtonInfo { get; set; }

			protected TextMeshProUGUI DescriptionText { get; }

			protected RequirementStatus? Status { get; set; }

			protected TextMeshProUGUI ValueText { get; }

			public RequirementElement(XmlElement element, ContractRequirement requirement)
			{
				Element = element;
				Requirement = requirement;
				DescriptionText = element.GetElementByInternalId<TextMeshProUGUI>("description");
				DescriptionText.text = requirement?.FlightDescription;
				ValueText = element.GetElementByInternalId<TextMeshProUGUI>("value");
				Icon = element.GetElementByInternalId("icon");
				Button = element.GetElementByInternalId("button");
			}

			public virtual void Update()
			{
				if (Status != Requirement.Status)
				{
					Status = Requirement.Status;
					bool isVisible = Requirement.IsVisible;
					if (isVisible)
					{
						Icon.RemoveClass("failed");
						Icon.RemoveClass("passed");
						Icon.RemoveClass("incomplete");
						if (Status == RequirementStatus.Active)
						{
							if (Requirement.OnFail == RequirementFailureType.Warn)
							{
								Icon.AddClass("failed");
							}
							else
							{
								Icon.AddClass("incomplete");
							}
						}
						else if (Status == RequirementStatus.Fail)
						{
							Icon.AddClass("failed");
						}
						else if (Status == RequirementStatus.Pass)
						{
							if (Requirement.ShowCheckmarkWhenPassed)
							{
								Icon.AddClass("passed");
							}
						}
						else if (Status == RequirementStatus.Complete)
						{
							Icon.AddClass("passed");
						}
						ContractRequirement.ButtonInformation buttonInfo = Requirement.ButtonInfo;
						if (ButtonInfo?.Sprite != buttonInfo?.Sprite)
						{
							ButtonInfo = buttonInfo;
							Button.SetActive(ButtonInfo != null);
							if (ButtonInfo != null)
							{
								Button.GetElementByInternalId("button-icon").SetAndApplyAttribute("sprite", ButtonInfo.Sprite);
								Button.SetAndApplyAttribute("tooltip", ButtonInfo.Tooltip);
							}
						}
					}
					if (isVisible != Element.gameObject.activeSelf)
					{
						Element.SetActive(isVisible);
					}
				}
				if (Element.gameObject.activeSelf)
				{
					ValueText.text = (Requirement.ShowDisplayValue ? Requirement.DisplayValue : string.Empty);
					string flightDescription = Requirement.FlightDescription;
					if (flightDescription != DescriptionText.text)
					{
						DescriptionText.text = flightDescription;
					}
					if (DescriptionText.isTextOverflowing)
					{
						Element.AddClass("requirement-tall");
					}
				}
			}
		}

		private bool _contractListDirty = true;

		private List<ContractElement> _contracts = new List<ContractElement>();

		private XmlElement _contractTemplate;

		private XmlElement _endFlightButton;

		private Dictionary<string, bool> _feedbacksClosed = new Dictionary<string, bool>();

		private XmlElement _finishPanel;

		private IFlightScene _flightScene;

		private XmlElement _noContracts;

		private int _numFramesDestroyed;

		private XmlElement _retryButton;

		private bool _showRetry = true;

		public XmlElement PanelElement { get; private set; }

		public XmlElement RequirementTemplate { get; private set; }

		public bool Visible
		{
			get
			{
				return PanelElement.gameObject.activeSelf;
			}
			set
			{
				PanelElement.SetActive(value);
				if (value)
				{
					RefreshContractsList();
				}
			}
		}

		public ContractsPanel(XmlElement panel)
		{
			_flightScene = Game.Instance.FlightScene;
			PanelElement = panel;
			XmlLayout xmlLayoutInstance = PanelElement.xmlLayoutInstance;
			_contractTemplate = xmlLayoutInstance.GetElementById("contract-template");
			_noContracts = xmlLayoutInstance.GetElementById("no-contracts");
			RequirementTemplate = xmlLayoutInstance.GetElementById("requirement-template");
			_finishPanel = xmlLayoutInstance.GetElementById("finish-contracts");
			_retryButton = xmlLayoutInstance.GetElementById("retry-button");
			_endFlightButton = xmlLayoutInstance.GetElementById("end-flight-button");
			_showRetry = Game.Instance.GameState.Validator.IsItemAvailable("Cheats.UndoRetry");
		}

		public void HideCompleteContracts()
		{
			Game.Instance.GameState.Career?.Contracts.RefreshActiveContracts();
			_contractListDirty = true;
			RefreshContractsList();
		}

		public void OnContractClicked(XmlElement element)
		{
			ContractElement contractElement = _contracts.Where((ContractElement x) => x.Element == element).FirstOrDefault();
			if (DebugInput.GetKey(KeyCode.LeftControl))
			{
				Debug.Log(contractElement.Contract.GenerateXml());
			}
			else if (CareerState.IsDebugMode)
			{
				Debug.Log("Marking contract complete");
				contractElement.Contract.Status = ContractStatus.Complete;
			}
			else
			{
				contractElement.IsExpanded = !contractElement.IsExpanded;
			}
		}

		public void OnRequirementClicked(XmlElement element)
		{
			element = element.GetParentElementWithClass("requirement");
			foreach (ContractElement contract in _contracts)
			{
				RequirementElement requirementElement = contract.Requirements.Where((RequirementElement x) => x.Element == element).FirstOrDefault();
				if (requirementElement != null)
				{
					requirementElement.Requirement?.OnClick(delegate
					{
						contract.RefreshRequirements(clear: true);
					});
					break;
				}
			}
		}

		public void RefreshContractsList()
		{
			if (!_contractListDirty)
			{
				return;
			}
			_contractListDirty = false;
			foreach (ContractElement contract in _contracts)
			{
				foreach (RequirementElement requirement in contract.Requirements)
				{
					UnityEngine.Object.Destroy(requirement.Element.gameObject);
				}
				if (contract.FeedbackPanel != null)
				{
					UnityEngine.Object.Destroy(contract.FeedbackPanel.Element.gameObject);
				}
				UnityEngine.Object.Destroy(contract.Element.gameObject);
			}
			_contracts.Clear();
			IReadOnlyList<Contract> active = (Game.Instance.GameState.Career?.Contracts).Active;
			if (active.Count > 0)
			{
				_noContracts.SetActive(active: false);
				{
					foreach (Contract item2 in active)
					{
						ContractElement item = new ContractElement(UiUtilities.CloneTemplate(_contractTemplate, PanelElement), item2, this);
						_contracts.Add(item);
					}
					return;
				}
			}
			_noContracts.SetActive(active: true);
		}

		public void ShowFirstContract()
		{
			RefreshContractsList();
			ContractElement contractElement = _contracts.FirstOrDefault();
			if (contractElement != null)
			{
				Visible = true;
				contractElement.IsExpanded = true;
			}
		}

		public void Update()
		{
			bool flag = false;
			bool flag2 = false;
			foreach (ContractElement contract in _contracts)
			{
				contract.Update();
				flag = flag || contract.Contract.IsComplete;
				flag2 = flag2 || contract.Contract.Status == ContractStatus.Failed || contract.Contract.Status == ContractStatus.Terminated;
			}
			ICraftNode craftNode = _flightScene.CraftNode;
			if (craftNode != null && craftNode.IsDestroyed)
			{
				_numFramesDestroyed++;
			}
			else
			{
				_numFramesDestroyed = 0;
			}
			flag2 = flag2 || (_numFramesDestroyed > 10 && !flag);
			if (flag || flag2)
			{
				if (!_finishPanel.Visible)
				{
					_finishPanel.transform.SetAsLastSibling();
					_finishPanel.Show();
					_retryButton.SetActive(flag2 && _showRetry);
					_endFlightButton.SetActive(!flag2);
				}
			}
			else if (_finishPanel.Visible)
			{
				_finishPanel.Hide();
			}
			if (!Game.Instance.Analytics.Enabled)
			{
				return;
			}
			foreach (ContractElement contract2 in _contracts)
			{
				if (contract2.Contract.IsComplete)
				{
					CreateFeedbackPanel(contract2);
				}
			}
		}

		private void CreateFeedbackPanel(ContractElement contractElement)
		{
			Contract contract = contractElement.Contract;
			if (contractElement.FeedbackPanel == null && !_feedbacksClosed.ContainsKey(contract.Id))
			{
				contractElement.FeedbackPanel = new ContractFeedback(PanelElement.GetElementByInternalId("contract-feedback"), contract);
				contractElement.FeedbackPanel.Element.transform.SetSiblingIndex(contractElement.Element.transform.GetSiblingIndex() + 1);
				contractElement.FeedbackPanel.Closed = delegate
				{
					contractElement.FeedbackPanel = null;
					_feedbacksClosed[contract.Id] = true;
				};
			}
		}
	}
}
