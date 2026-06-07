using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using Assets.Scripts.Craft.Parts.Modifiers.Variables;
using Assets.Scripts.Design.PartProperties;
using Assets.Scripts.Design.Symmetry;
using Assets.Scripts.Design.UI.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Obfuscation(Exclude = true)]
	public abstract class PartModifierData
	{
		private float _massCached;

		private bool _recalculateMass;

		private List<VariableOutputDefinition> _variableOutputDefinitions;

		public virtual bool AllowDisableSymmetry => true;

		public virtual bool AllowTransformation => true;

		public virtual Vector3 CoM => Vector3.zero;

		public virtual bool EnabledForRemoteAircraft => true;

		public virtual string Id { get; protected set; }

		public virtual bool IsGenericDesignerPropertiesVisible => true;

		public virtual float Mass
		{
			get
			{
				if (_recalculateMass)
				{
					_recalculateMass = false;
					_massCached = CalculateMass();
				}
				return _massCached;
			}
		}

		public PartData Part { get; set; }

		public virtual float PerformanceCost => 0f;

		public virtual string StateElementName => Id + ".State";

		public bool SymmetryDisabled { get; set; }

		public virtual bool UsedInPropMode => false;

		public List<VariableOutputDefinition> VariableOutputDefinitions
		{
			get
			{
				if (_variableOutputDefinitions != null)
				{
					return _variableOutputDefinitions;
				}
				if (this is IModifierWithOutputs modifierWithOutputs)
				{
					_variableOutputDefinitions = VariableOutputDefinition.GetDefinitionsForType(modifierWithOutputs.ModifierScriptType);
				}
				return _variableOutputDefinitions;
			}
		}

		public List<VariableOutput> VariableOutputs { get; set; } = new List<VariableOutput>();

		public PartModifierData(XElement element)
		{
			Id = element?.Name.LocalName;
			_recalculateMass = true;
		}

		public virtual XElement GenerateStateXml()
		{
			XElement xElement = new XElement(StateElementName);
			xElement.Add(GenerateVariableState());
			if (AllowDisableSymmetry && SymmetryDisabled)
			{
				xElement.SetAttributeValue("symmetryDisabled", SymmetryDisabled);
			}
			return xElement;
		}

		public virtual string GetGenericDesignerPropertyNameLabel(IConfigurableProperty property)
		{
			return property.GetDefaultLabel();
		}

		public virtual string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			return sliderValue.ToString();
		}

		public virtual string GetGenericDesignerPropertySpinnerValueLabel(string propertyName, float spinnerValue)
		{
			return spinnerValue.ToString();
		}

		public virtual string GetGenericDesignerPropertyTextSpinnerValueLabel(string propertyName, string spinnerValue)
		{
			return spinnerValue;
		}

		public virtual void GetGenericDesignerPropertyTextSpinnerValues(ITextSpinnerProperty textSpinnerProperty, List<string> values)
		{
		}

		public virtual string GetGenericDesignerPropertyToggleButtonValueLabel(string propertyName, string value)
		{
			return null;
		}

		public virtual PartPropertyValueConverter GetGenericDesignerPropertyValueConverter(IConfigurableProperty property)
		{
			return null;
		}

		public virtual string GetGenericDesignerPropertyVectorValueLabel(string propertyName, object vectorValue)
		{
			return vectorValue.ToString();
		}

		public virtual Func<bool> GetGenericDesignerPropertyVisibilityCallback(IConfigurableProperty property)
		{
			return null;
		}

		public virtual object GetSymmetricValue(string propertyName, int symmetricPartCount, PartModifierData sourceModifier, object sourceValue)
		{
			return sourceValue;
		}

		public abstract PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript);

		public void InitVariables(PartModifierScript script)
		{
			if (!(this is IModifierWithOutputs) || Part.PartScript.LoadContext != CraftLoadContext.Flight)
			{
				return;
			}
			foreach (VariableOutput variableOutput in VariableOutputs)
			{
				variableOutput.InitScript(script);
			}
		}

		public virtual bool IsSymmetricMatch(PartModifierData otherModifier, SymmetryConfig symmetry)
		{
			return otherModifier != null;
		}

		public virtual void OnAssemblyLoaded(Assembly assembly, CraftLoadContext loadContext)
		{
		}

		public virtual void OnGenericDesignerPropertiesClosed()
		{
		}

		public virtual void OnGenericDesignerPropertiesPartDeselected()
		{
		}

		public virtual void OnGenericDesignerPropertiesUpdate(IGenericPartProperties genericPartProperties)
		{
		}

		public virtual void OnGenericDesignerPropertiesVisible(IGenericPartProperties genericPartPropertiesScript)
		{
		}

		public virtual void OnGenericDesignerPropertyButtonClicked(IConfigurableProperty property)
		{
		}

		public virtual void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
		}

		public virtual void OnGenericDesignerPropertyChanging(string propertyName, string newValue)
		{
		}

		public virtual void OnModifiersCreated()
		{
		}

		public virtual void OnPartCloned(PartData sourcePart)
		{
		}

		public virtual void OnPartNameChanged(string name)
		{
		}

		public void RecalculateMass(bool recalculatePartMass)
		{
			_recalculateMass = true;
			if (recalculatePartMass)
			{
				Part?.RecalculateLoadedMass(recalculateModifierMass: false);
			}
		}

		public virtual void RestoreFromState(XElement stateElement)
		{
			RestoreVariables(stateElement);
			SymmetryDisabled = AllowDisableSymmetry && stateElement.GetBoolAttribute("symmetryDisabled");
		}

		protected virtual float CalculateMass()
		{
			return 0f;
		}

		protected XElement GenerateVariableState()
		{
			if (VariableOutputDefinitions != null)
			{
				XElement xElement = new XElement("Variables");
				{
					foreach (VariableOutput variableOutput in VariableOutputs)
					{
						xElement.Add(variableOutput.SaveToXML());
					}
					return xElement;
				}
			}
			return null;
		}

		protected void RestoreVariables(XElement stateElement)
		{
			if (VariableOutputDefinitions == null)
			{
				return;
			}
			VariableOutputs.Clear();
			XElement xElement = stateElement.Element("Variables");
			if (xElement != null)
			{
				foreach (XElement item in xElement.Elements("VariableOutput"))
				{
					string text = (string)item.Attribute("id");
					foreach (VariableOutputDefinition variableOutputDefinition in VariableOutputDefinitions)
					{
						if (variableOutputDefinition.Id == text)
						{
							VariableOutputs.Add(new VariableOutput(variableOutputDefinition, item));
							break;
						}
					}
				}
				return;
			}
			foreach (VariableOutputDefinition variableOutputDefinition2 in VariableOutputDefinitions)
			{
				if (!string.IsNullOrWhiteSpace(variableOutputDefinition2.DefaultOutputVariable))
				{
					VariableOutputs.Add(new VariableOutput(variableOutputDefinition2));
				}
			}
		}
	}
}
