using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Parts.Modifiers.XR;
using Assets.Scripts.Tutorials.Requirements.Attributes;
using Assets.Scripts.XR.UI;
using UnityEngine;

namespace Assets.Scripts.Tutorials.Requirements
{
	[Serializable]
	public abstract class TutorialRequirement
	{
		[Serializable]
		public class HighlightedPart
		{
			public const float DefaultPulseRate = 1f;

			public static readonly Vector3 DefaultPulseScale = new Vector3(1.1f, 1.1f, 1.1f);

			[field: SerializeField]
			public bool Enabled { get; set; }

			[field: SerializeField]
			public PartMaterialScript.PartHighlightSettings Highlight { get; }

			[field: SerializeField]
			public PartMaterialScript.PartHighlightSettings HighlightOriginal { get; }

			[field: SerializeField]
			public PartMaterialScript.PartHighlightSettings HighlightPulse { get; }

			[field: SerializeField]
			public PartScript Part { get; }

			[field: SerializeField]
			public float PulseRate { get; set; }

			public HighlightedPart(PartScript part, PartMaterialScript.PartHighlightSettings highlight, Vector3? pulseScale, float? pulseRate)
			{
				Part = part;
				Highlight = highlight;
				HighlightOriginal = highlight.Clone();
				HighlightPulse = highlight.Clone();
				HighlightPulse.Scale = Vector3.Scale(HighlightPulse.Scale, pulseScale ?? DefaultPulseScale);
				PulseRate = pulseRate ?? 1f;
				Enabled = true;
			}

			public void Pulse(float time)
			{
				float num = PulseRate * 0.5f;
				float num2 = time % PulseRate / num;
				if (num2 > 1f)
				{
					num2 = 2f - num2;
				}
				Highlight.Scale = Vector3.Lerp(HighlightOriginal.Scale, HighlightPulse.Scale, num2);
			}
		}

		[Serializable]
		public class HighlightedUIElement
		{
			public RadialMenuButtonScript RadialMenuButton { get; }

			public HighlightedUIElement(RadialMenuButtonScript button)
			{
				RadialMenuButton = button;
			}
		}

		[Serializable]
		public class PartHighlightRequirement
		{
			public GaugeData.GaugeFaceTypes? GaugeFaceType { get; private set; }

			public string InputId { get; private set; }

			public Type ModifierType { get; private set; }

			public int? PartId { get; private set; }

			public PartHighlightRequirement()
			{
				PartId = null;
				GaugeFaceType = null;
				InputId = null;
				ModifierType = null;
			}

			public PartHighlightRequirement(XElement xml)
				: this()
			{
				RestoreFromXml(xml);
			}

			public PartHighlightRequirement(int partId)
			{
				PartId = partId;
			}

			public PartHighlightRequirement(GaugeData.GaugeFaceTypes gaugeFaceType)
			{
				GaugeFaceType = gaugeFaceType;
			}

			public PartHighlightRequirement(string inputId)
			{
				InputId = inputId;
			}

			public PartHighlightRequirement(Type modifierType)
			{
				ModifierType = modifierType;
			}

			public XElement GenerateXml()
			{
				return new XElement("PartHighlight", PartId.HasValue ? new XAttribute("partId", PartId.Value) : null, (InputId != null) ? new XAttribute("inputId", InputId) : null, (ModifierType != null) ? new XAttribute("modifierType", ModifierType.Name) : null, GaugeFaceType.HasValue ? new XAttribute("gaugeFace", GaugeFaceType.Value) : null);
			}

			public void RestoreFromXml(XElement xml)
			{
				PartId = (int?)xml.Attribute("partId");
				InputId = (string)xml.Attribute("inputId");
				GaugeFaceType = (Enum.TryParse<GaugeData.GaugeFaceTypes>((string)xml.Attribute("gaugeFace"), out var result) ? new GaugeData.GaugeFaceTypes?(result) : ((GaugeData.GaugeFaceTypes?)null));
				string text = (string)xml.Attribute("modifierType");
				if (text != null)
				{
					Type type = typeof(CockpitData).Assembly.GetType(text, throwOnError: false, ignoreCase: true);
					if (type != null)
					{
						ModifierType = type;
					}
				}
			}
		}

		public class TutorialRequirementBuilder<T> where T : TutorialRequirement
		{
			public T Requirement { get; }

			public TutorialStep.TutorialStepBuilder Step { get; }

			public TutorialRequirementBuilder(TutorialStep.TutorialStepBuilder stepBuilder, T requirement)
			{
				Step = stepBuilder;
				Requirement = requirement;
			}

			public TutorialRequirementBuilder<T> AddHighlightRequirement(int partId)
			{
				Requirement.AddPartHighlightRequirement(new PartHighlightRequirement(partId));
				return this;
			}

			public TutorialRequirementBuilder<T> AddHighlightRequirement(GaugeData.GaugeFaceTypes gaugeFaceType)
			{
				Requirement.AddPartHighlightRequirement(new PartHighlightRequirement(gaugeFaceType));
				return this;
			}

			public TutorialRequirementBuilder<T> AddHighlightRequirement(string inputId)
			{
				Requirement.AddPartHighlightRequirement(new PartHighlightRequirement(inputId));
				return this;
			}

			public TutorialRequirementBuilder<T> AddHighlightRequirement<TModifierType>() where TModifierType : PartModifierData
			{
				Requirement.AddPartHighlightRequirement(new PartHighlightRequirement(typeof(TModifierType)));
				return this;
			}

			public TutorialRequirementBuilder<T> AddUIHighlightRequirement(string id)
			{
				Requirement.AddUIHighlightRequirement(new UIHighlightRequirement(id));
				return this;
			}

			public TutorialRequirementBuilder<T> Config(Action<T> action)
			{
				action(Requirement);
				return this;
			}

			public TutorialRequirementBuilder<T> HighlightDefaultParts(bool enabled)
			{
				Requirement.HighlightDefaultParts = enabled;
				return this;
			}

			public TutorialRequirementBuilder<T> HoldDuration(float seconds)
			{
				Requirement.RequiredMetDuration = seconds;
				return this;
			}

			public TutorialRequirementBuilder<T> Inherited(bool inherited)
			{
				Requirement.Inherited = inherited;
				return this;
			}

			public TutorialRequirementBuilder<T> Message(string message)
			{
				Requirement.RequirementNotMetMessage = message;
				return this;
			}

			public TutorialRequirementBuilder<T> Message(string message, string messageVR)
			{
				Requirement.RequirementNotMetMessage = message;
				Requirement.RequirementNotMetMessageVR = messageVR;
				return this;
			}

			public TutorialRequirementBuilder<T> MessageVR(string messageVR)
			{
				Requirement.RequirementNotMetMessageVR = messageVR;
				return this;
			}

			public TutorialRequirementBuilder<T> PartHighlightColor(Color color)
			{
				Requirement.PartHighlightColor = color;
				return this;
			}
		}

		[Serializable]
		public class UIHighlightRequirement
		{
			public string Id { get; private set; }

			public UIHighlightRequirement()
			{
				Id = null;
			}

			public UIHighlightRequirement(XElement xml)
				: this()
			{
				RestoreFromXml(xml);
			}

			public UIHighlightRequirement(string id)
			{
				Id = id;
			}

			public XElement GenerateXml()
			{
				return new XElement("UIHighlight", (Id != null) ? new XAttribute("id", Id) : null);
			}

			public void RestoreFromXml(XElement xml)
			{
				Id = (string)xml.Attribute("id");
			}
		}

		private static Dictionary<string, Type> _tutorialRequirementTypeLookup;

		private float _currentMetDuration;

		[SerializeField]
		private List<HighlightedPart> _highlightedParts;

		[SerializeField]
		private List<HighlightedUIElement> _highlightedUIElements;

		[SerializeField]
		private List<PartHighlightRequirement> _partHighlightRequirements;

		[SerializeField]
		private List<UIHighlightRequirement> _uiHighlightRequirements;

		[field: SerializeField]
		public string CurrentMessage { get; set; }

		[field: SerializeField]
		public bool HighlightDefaultParts { get; set; }

		public IReadOnlyList<HighlightedPart> HighlightedParts => _highlightedParts;

		public IReadOnlyList<HighlightedUIElement> HighlightedUIElements => _highlightedUIElements;

		[field: SerializeField]
		public bool HighlightPartsEnabled { get; set; }

		[field: SerializeField]
		public bool Inherited { get; set; }

		[field: SerializeField]
		[field: HideInInspector]
		public Color? PartHighlightColor { get; set; }

		public AircraftScript PlayerAircraft => Step.Tutorial.PlayerAircraft;

		[field: SerializeField]
		public float RequiredMetDuration { get; set; }

		[field: SerializeField]
		public string RequirementNotMetMessage { get; set; }

		[field: SerializeField]
		public string RequirementNotMetMessageVR { get; set; }

		public virtual bool ShowContinueButton => false;

		[field: SerializeField]
		public TutorialRequirementState State { get; private set; }

		public TutorialStep Step { get; private set; }

		protected virtual float DefaultRequiredMetDuration => 0.25f;

		protected string DefaultRequirementNotMetMessage { get; private set; }

		protected string DefaultRequirementNotMetMessageVR { get; private set; }

		public TutorialRequirement()
		{
			_highlightedParts = new List<HighlightedPart>();
			_partHighlightRequirements = new List<PartHighlightRequirement>();
			_highlightedUIElements = new List<HighlightedUIElement>();
			_uiHighlightRequirements = new List<UIHighlightRequirement>();
			HighlightPartsEnabled = true;
			HighlightDefaultParts = true;
			RequiredMetDuration = DefaultRequiredMetDuration;
		}

		public static TutorialRequirementBuilder<T> Create<T>(TutorialStep.TutorialStepBuilder stepBuilder) where T : TutorialRequirement
		{
			T requirement = (T)Activator.CreateInstance(typeof(T));
			return new TutorialRequirementBuilder<T>(stepBuilder, requirement);
		}

		public static Type GetTutorialRequirementType(string id)
		{
			if (_tutorialRequirementTypeLookup == null)
			{
				_tutorialRequirementTypeLookup = new Dictionary<string, Type>();
				Type[] types = typeof(TutorialRequirement).Assembly.GetTypes();
				foreach (Type type in types)
				{
					TutorialRequirementAttribute customAttribute = type.GetCustomAttribute<TutorialRequirementAttribute>();
					if (customAttribute != null)
					{
						_tutorialRequirementTypeLookup[customAttribute.Id] = type;
					}
				}
			}
			_tutorialRequirementTypeLookup.TryGetValue(id, out var value);
			return value;
		}

		public static TutorialRequirement LoadFromXml(XElement xml)
		{
			string localName = xml.Name.LocalName;
			TutorialRequirement obj = (TutorialRequirement)Activator.CreateInstance(GetTutorialRequirementType(localName) ?? throw new Exception($"Unable to find tutorial requirement type with id '{localName}'.{System.Environment.NewLine}{xml}"));
			obj.RestoreFromXml(xml);
			return obj;
		}

		public void AddPartHighlightRequirement(PartHighlightRequirement requirement)
		{
			_partHighlightRequirements.Add(requirement);
		}

		public void AddUIHighlightRequirement(UIHighlightRequirement requirement)
		{
			_uiHighlightRequirements.Add(requirement);
		}

		public XElement GenerateXml()
		{
			XElement xElement = new XElement(GetType().GetCustomAttribute<TutorialRequirementAttribute>().Id);
			GenerateXml(xElement);
			return xElement;
		}

		public void Initialize(TutorialStep step)
		{
			Step = step;
			State = TutorialRequirementState.RequirementNotMet;
			OnInitialized();
			if (RequirementNotMetMessage == null)
			{
				DefaultRequirementNotMetMessage = GetDefaultRequirementNotMetMessage(vr: false);
			}
			if (RequirementNotMetMessageVR == null)
			{
				DefaultRequirementNotMetMessageVR = GetDefaultRequirementNotMetMessage(vr: true);
			}
		}

		public virtual void OnContinueButtonClicked()
		{
		}

		public virtual void OnRadialMenuButtonClicked(RadialMenuButtonScript button)
		{
		}

		public virtual void OnStepCompleted(TutorialStepState state)
		{
		}

		public virtual void OnStepFailed()
		{
		}

		public virtual void OnStepPassed()
		{
		}

		public virtual void OnStepStarted()
		{
			if (HighlightDefaultParts)
			{
				OnHighlightDefaultParts();
			}
			foreach (PartHighlightRequirement partHighlightRequirement in _partHighlightRequirements)
			{
				if (partHighlightRequirement.PartId.HasValue)
				{
					HighlightPartById(partHighlightRequirement.PartId.Value);
					continue;
				}
				if (partHighlightRequirement.GaugeFaceType.HasValue)
				{
					HighlightGaugeByFaceType(partHighlightRequirement.GaugeFaceType.Value);
					continue;
				}
				if (partHighlightRequirement.InputId != null)
				{
					HighlightInteractablePartsByInput(partHighlightRequirement.InputId);
					continue;
				}
				if (partHighlightRequirement.ModifierType != null)
				{
					HighlightPartsWithModifier(partHighlightRequirement.ModifierType);
					continue;
				}
				throw new NotSupportedException();
			}
			foreach (UIHighlightRequirement uiHighlightRequirement in _uiHighlightRequirements)
			{
				if (uiHighlightRequirement.Id != null)
				{
					HighlightUIElements(uiHighlightRequirement.Id);
				}
			}
		}

		public virtual void Update()
		{
			TutorialRequirementState tutorialRequirementState = OnRequirementUpdate();
			if (tutorialRequirementState == TutorialRequirementState.RequirementMet)
			{
				if (_currentMetDuration < RequiredMetDuration)
				{
					tutorialRequirementState = TutorialRequirementState.RequirementNotMet;
					_currentMetDuration += Time.unscaledDeltaTime;
				}
			}
			else
			{
				_currentMetDuration = 0f;
			}
			State = tutorialRequirementState;
			if (State == TutorialRequirementState.RequirementNotMet)
			{
				CurrentMessage = (Game.Instance.XRDeviceManager.HmdActive ? FormatMessage(RequirementNotMetMessageVR ?? RequirementNotMetMessage ?? DefaultRequirementNotMetMessageVR) : FormatMessage(RequirementNotMetMessage ?? RequirementNotMetMessageVR ?? DefaultRequirementNotMetMessage));
			}
		}

		protected virtual string FormatMessage(string message)
		{
			return message;
		}

		protected virtual void GenerateXml(XElement xml)
		{
			xml.SetAttributeValue("message", RequirementNotMetMessage);
			xml.SetAttributeValue("messageVR", RequirementNotMetMessageVR);
			xml.SetAttributeValue("inherited", Inherited ? new bool?(Inherited) : ((bool?)null));
			xml.SetAttributeValue("holdDuration", (RequiredMetDuration != DefaultRequiredMetDuration) ? new float?(RequiredMetDuration) : ((float?)null));
			xml.SetAttributeValue("highlightDefaultParts", (!HighlightDefaultParts) ? new bool?(HighlightDefaultParts) : ((bool?)null));
			xml.SetAttributeValue("partHighlightColor", PartHighlightColor.HasValue ? ColorUtility.ToHtmlStringRGBA(PartHighlightColor.Value) : null);
			foreach (PartHighlightRequirement partHighlightRequirement in _partHighlightRequirements)
			{
				xml.Add(partHighlightRequirement.GenerateXml());
			}
			foreach (UIHighlightRequirement uiHighlightRequirement in _uiHighlightRequirements)
			{
				xml.Add(uiHighlightRequirement.GenerateXml());
			}
		}

		protected ComparisonOperatorType GetComparisonOperator(XElement xml, string attributeName = "op")
		{
			string text = (string)xml.Attribute(attributeName);
			if (!Enum.TryParse<ComparisonOperatorType>(text, out var result))
			{
				switch (text)
				{
				case "=":
				case "==":
					return ComparisonOperatorType.Equal;
				case "!=":
					return ComparisonOperatorType.NotEqual;
				case "<":
					return ComparisonOperatorType.LessThan;
				case "<=":
					return ComparisonOperatorType.LessThanOrEqual;
				case ">":
					return ComparisonOperatorType.GreaterThan;
				case ">=":
					return ComparisonOperatorType.GreaterThanOrEqual;
				default:
					throw new NotSupportedException("Comparison operator '" + text + "' not supported by '" + GetType().Name + "'.");
				}
			}
			return result;
		}

		protected virtual string GetDefaultRequirementNotMetMessage(bool vr)
		{
			return null;
		}

		protected List<HighlightedPart> HighlightGaugeByFaceType(GaugeData.GaugeFaceTypes gaugeFaceType)
		{
			List<HighlightedPart> list = new List<HighlightedPart>();
			GaugeData[] array = (from x in PlayerAircraft?.Parts
				select x.GetModifier<GaugeData>() into x
				where x != null
				select x).ToArray();
			foreach (GaugeData gaugeData in array)
			{
				if (gaugeData.FaceType == gaugeFaceType)
				{
					list.Add(HighlightPart(gaugeData.Part.PartScript));
				}
			}
			return list;
		}

		protected List<HighlightedPart> HighlightInteractablePartsByInput(string inputId, Vector3? pulseScale = null, float? pulseRate = null)
		{
			List<HighlightedPart> list = new List<HighlightedPart>();
			foreach (PartScript item in FindInteractablePartsByInput(inputId))
			{
				list.Add(HighlightPart(item, pulseScale, pulseRate));
			}
			return list;
		}

		protected HighlightedPart HighlightPart(PartScript part, Vector3? pulseScale = null, float? pulseRate = null)
		{
			if (part != null)
			{
				Vector3 scale = new Vector3(1.1f, 1.1f, 1.1f);
				PosedGripScript modifier = part.GetModifier<PosedGripScript>();
				if (modifier != null)
				{
					scale = modifier.Modifier.OutlineScale;
				}
				PartMaterialScript.PartHighlightSettings highlight = new PartMaterialScript.PartHighlightSettings(PartHighlightColor, scale, useZTest: true);
				HighlightedPart highlightedPart = new HighlightedPart(part, highlight, pulseScale, pulseRate);
				_highlightedParts.Add(highlightedPart);
				return highlightedPart;
			}
			return null;
		}

		protected HighlightedPart HighlightPartById(int partId, Vector3? pulseScale = null, float? pulseRate = null)
		{
			PartScript part = Step.Tutorial.PlayerAircraft?.GetPartById(partId)?.PartScript;
			return HighlightPart(part, pulseScale, pulseRate);
		}

		protected List<HighlightedPart> HighlightPartsWithModifier<TModifier>(Vector3? pulseScale = null, float? pulseRate = null) where TModifier : PartModifierData
		{
			List<HighlightedPart> list = new List<HighlightedPart>();
			foreach (PartData part in PlayerAircraft.Parts)
			{
				if (part.GetModifier<TModifier>() != null)
				{
					list.Add(HighlightPart(part.PartScript, pulseScale, pulseRate));
				}
			}
			return list;
		}

		protected List<HighlightedPart> HighlightPartsWithModifier(Type modifierType, Vector3? pulseScale = null, float? pulseRate = null)
		{
			List<HighlightedPart> list = new List<HighlightedPart>();
			foreach (PartData part in PlayerAircraft.Parts)
			{
				foreach (PartModifierData modifier in part.Modifiers)
				{
					if (modifierType.IsAssignableFrom(modifier.GetType()))
					{
						list.Add(HighlightPart(part.PartScript, pulseScale, pulseRate));
						break;
					}
				}
			}
			return list;
		}

		protected List<HighlightedUIElement> HighlightUIElements(string id)
		{
			List<HighlightedUIElement> list = new List<HighlightedUIElement>();
			foreach (FlightMenuScript instance in FlightMenuScript.Instances)
			{
				RadialMenuButtonScript button = instance.GetButton(id);
				list.Add(new HighlightedUIElement(button));
			}
			_highlightedUIElements.AddRange(list);
			return list;
		}

		protected virtual void OnHighlightDefaultParts()
		{
		}

		protected virtual void OnInitialized()
		{
		}

		protected abstract TutorialRequirementState OnRequirementUpdate();

		protected virtual void RestoreFromXml(XElement xml)
		{
			RequirementNotMetMessage = (string)xml.Attribute("message");
			RequirementNotMetMessageVR = (string)xml.Attribute("messageVR");
			Inherited = (bool?)xml.Attribute("inherited") == true;
			RequiredMetDuration = ((float?)xml.Attribute("holdDuration")) ?? DefaultRequiredMetDuration;
			HighlightDefaultParts = ((bool?)xml.Attribute("highlightDefaultParts")) ?? true;
			PartHighlightColor = xml.GetHtmlColorAttributeOrNull("partHighlightColor");
			foreach (XElement item in xml.Elements("PartHighlight"))
			{
				_partHighlightRequirements.Add(new PartHighlightRequirement(item));
			}
			foreach (XElement item2 in xml.Elements("UIHighlight"))
			{
				_uiHighlightRequirements.Add(new UIHighlightRequirement(item2));
			}
		}

		private List<PartScript> FindInteractablePartsByInput(string inputId)
		{
			List<PartScript> list = new List<PartScript>();
			foreach (PartData part in PlayerAircraft.Parts)
			{
				IInteractablePartModifier modifierWithInterface = part.PartScript.GetModifierWithInterface<IInteractablePartModifier>();
				if (modifierWithInterface is PosedGripScript)
				{
					ControlBaseScript controlBase = ((PosedGripScript)modifierWithInterface).GetControlBase();
					bool flag = false;
					ControlBaseScript.ControlAxis[] movementAxes = controlBase.ControlBase.MovementAxes;
					foreach (ControlBaseScript.ControlAxis controlAxis in movementAxes)
					{
						flag |= controlAxis.InputName == inputId;
					}
					movementAxes = controlBase.ControlBase.RotationAxes;
					foreach (ControlBaseScript.ControlAxis controlAxis2 in movementAxes)
					{
						flag |= controlAxis2.InputName == inputId;
					}
					if (flag)
					{
						list.Add(part.PartScript);
					}
				}
				else if (modifierWithInterface is CockpitButtonScript)
				{
					if (((CockpitButtonScript)modifierWithInterface).Modifier.Input?.InputId == inputId)
					{
						list.Add(part.PartScript);
					}
				}
				else if (modifierWithInterface is CockpitSwitchScript && ((CockpitSwitchScript)modifierWithInterface).Modifier.Input?.InputId == inputId)
				{
					list.Add(part.PartScript);
				}
			}
			return list;
		}
	}
}
