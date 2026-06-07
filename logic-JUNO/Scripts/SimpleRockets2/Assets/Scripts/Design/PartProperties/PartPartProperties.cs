using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Ui;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Design.PartProperties;
using ModApi.Math;
using TMPro;
using UI.Xml;

namespace Assets.Scripts.Design.PartProperties
{
	public class PartPartProperties : PartPropertiesScript
	{
		private XmlElement _activationGroup;

		private SpinnerScript _activationGroupSpinner;

		private BodyData _currentPartBodyData;

		private TextMeshProUGUI _partInfoMass;

		private TextMeshProUGUI _partInfoPrice;

		private TMP_InputField _partNameInput;

		private TextMeshProUGUI _partNamePlaceholder;

		public override bool HandlesMultipleModifiers => true;

		protected PartScript CurrentPart { get; private set; }

		public override void OnPartDeselected(IPartScript part)
		{
			CurrentPart = null;
		}

		public void OnPartNameInputChanged(string text)
		{
			if (CurrentPart != null)
			{
				if (!string.IsNullOrEmpty(text))
				{
					CurrentPart.Data.Name = text;
				}
				else
				{
					CurrentPart.Data.Name = CurrentPart.Data.PartType.Name;
				}
				PartPropertiesFlyoutScript.ChangesSinceLastUndoStep = true;
			}
		}

		public override bool OnPartSelected(IPartScript part)
		{
			CurrentPart = part as PartScript;
			if (CurrentPart != null)
			{
				_activationGroupSpinner.Value = ((CurrentPart.Data.ActivationGroup == 0) ? "None" : CurrentPart.Data.ActivationGroup.ToString());
				_activationGroup.gameObject.SetActive(CurrentPart.Data.Config.SupportsActivation);
				_partNamePlaceholder.text = part.Data.PartType.Name;
				if (part.Data.PartType.Name != part.Data.Name)
				{
					_partNameInput.text = part.Data.Name;
				}
				else
				{
					_partNameInput.text = string.Empty;
				}
				UpdatePartInfo();
				UpdateActivationGroupName();
			}
			return true;
		}

		public override void OnPropertiesClosed()
		{
			base.OnPropertiesClosed();
			base.Designer.CraftStructureChanged -= OnCraftStructureChanged;
		}

		public override void OnPropertiesOpened()
		{
			base.OnPropertiesOpened();
			base.Designer.CraftStructureChanged += OnCraftStructureChanged;
		}

		public override void SetVisible(bool visible)
		{
			base.SetVisible(visible);
		}

		protected override void OnInitialized()
		{
			PartPropertiesFlyoutScript partPropertiesFlyoutScript = base.Flyout as PartPropertiesFlyoutScript;
			_partNameInput = partPropertiesFlyoutScript.xmlLayout.GetElementById<TMP_InputField>("part-name-input");
			_partNameInput.onValueChanged.AddListener(OnPartNameInputChanged);
			_partNamePlaceholder = partPropertiesFlyoutScript.xmlLayout.GetElementById<TextMeshProUGUI>("part-name-input-placeholder");
			_activationGroup = partPropertiesFlyoutScript.xmlLayout.GetElementById("activation-group");
			_activationGroupSpinner = _activationGroup.GetElementByInternalId<SpinnerScript>("spinner");
			_activationGroupSpinner.NextButton.onClick.AddListener(delegate
			{
				OnAdvanceActivationGroup(1);
			});
			_activationGroupSpinner.PrevButton.onClick.AddListener(delegate
			{
				OnAdvanceActivationGroup(-1);
			});
			_partInfoMass = partPropertiesFlyoutScript.xmlLayout.GetElementById<TextMeshProUGUI>("part-info-mass");
			_partInfoPrice = partPropertiesFlyoutScript.xmlLayout.GetElementById<TextMeshProUGUI>("part-info-price");
		}

		private void OnAdvanceActivationGroup(int increment)
		{
			ICommandPod commandPod = CurrentPart.CommandPod;
			int num = CurrentPart.Data.ActivationGroup + increment;
			if (num < 0)
			{
				num = commandPod.ActivationGroupNames.Count;
			}
			else if (num > commandPod.ActivationGroupNames.Count)
			{
				num = 0;
			}
			CurrentPart.Data.ActivationGroup = num;
			UpdateActivationGroupName();
			PartPropertiesFlyoutScript.ChangesSinceLastUndoStep = true;
		}

		private void OnCraftStructureChanged()
		{
			UpdatePartInfo();
		}

		private void UpdateActivationGroupName()
		{
			ICommandPod commandPod = CurrentPart.CommandPod;
			int activationGroup = CurrentPart.Data.ActivationGroup;
			if (activationGroup == 0)
			{
				_activationGroupSpinner.Value = "None";
				return;
			}
			string text = commandPod.ActivationGroupNames[activationGroup - 1];
			text = ((!string.IsNullOrEmpty(text)) ? $"{activationGroup}. {text}" : activationGroup.ToString());
			_activationGroupSpinner.Value = text;
		}

		private void UpdatePartInfo()
		{
			if (CurrentPart != null)
			{
				_partInfoMass.text = Units.GetMassString(CurrentPart.Data.Mass);
				_partInfoPrice.text = Units.GetPriceString(CurrentPart.Data.Price);
				_partNameInput.text = CurrentPart.Data.Name;
			}
		}
	}
}
