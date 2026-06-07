using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Part Targeting")]
	public class PartTargetingData : PartModifierData, IPartIDChangedListener
	{
		[DesignerPropertyCustomWidget(WidgetTemplate = "property-part-list", Order = 501, Label = "Targeted Parts")]
		private List<int> _customPartIds;

		private List<int> _partIds;

		private bool _refreshProperties;

		private PartTargetingScript _script;

		[DesignerPropertyToggleButton(new string[] { }, Label = "Target", Order = 500, Tooltip = "Determines which parts are affected.")]
		private PartTargetingMode _targetMode = PartTargetingMode.MultipleParts;

		public List<int> PartIDs
		{
			get
			{
				return _partIds;
			}
			set
			{
				_partIds = value;
			}
		}

		public PartTargetingMode TargetMode
		{
			get
			{
				return _targetMode;
			}
			set
			{
				_targetMode = value;
			}
		}

		public PartData TargetPart { get; set; }

		public PartTargetingData(XElement element)
			: base(element)
		{
		}

		public void FindConnectedTargetPart()
		{
			PartData targetPart = ((base.Part.PartConnections.Count <= 0) ? base.Part : base.Part.PartConnections[0].GetOtherPart(base.Part));
			TargetPart = targetPart;
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.SetAttributeValue("targetMode", _targetMode);
			if (_targetMode == PartTargetingMode.Custom)
			{
				xElement.SetAttributeValue("customPartIds", string.Join(',', _customPartIds));
			}
			else
			{
				_partIds = _script.Handler.GetPartIDs();
				xElement.SetAttributeValue("partIds", string.Join(',', _partIds));
			}
			return xElement;
		}

		public override Func<bool> GetGenericDesignerPropertyVisibilityCallback(IConfigurableProperty property)
		{
			if (property.Member.Name == "_customPartIds")
			{
				return () => _targetMode == PartTargetingMode.Custom;
			}
			return base.GetGenericDesignerPropertyVisibilityCallback(property);
		}

		public override object GetSymmetricValue(string propertyName, int symmetricPartCount, PartModifierData sourceModifier, object sourceValue)
		{
			if (symmetricPartCount == 2 && propertyName == "_customPartIds" && sourceValue is List<int> sourcePartIds)
			{
				return CloneCustomPartIDs(sourcePartIds);
			}
			return base.GetSymmetricValue(propertyName, symmetricPartCount, sourceModifier, sourceValue);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			if (base.Part.LoadContext == CraftLoadContext.Designer)
			{
				_script = parentGameObject.AddComponent<PartTargetingScript>();
				_script.Initialize(this);
				return _script;
			}
			return null;
		}

		public override void OnGenericDesignerPropertiesUpdate(IGenericPartProperties genericPartProperties)
		{
			base.OnGenericDesignerPropertiesUpdate(genericPartProperties);
			if (_refreshProperties)
			{
				_refreshProperties = false;
				RefreshCustomPartList(genericPartProperties);
				genericPartProperties.RefreshUI();
			}
		}

		public override void OnGenericDesignerPropertiesVisible(IGenericPartProperties genericPartPropertiesScript)
		{
			base.OnGenericDesignerPropertiesVisible(genericPartPropertiesScript);
			_refreshProperties = true;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			if (propertyName == "_customPartIds" || propertyName == "_targetMode")
			{
				OnTargetingChanged();
				if (propertyName == "_targetMode")
				{
					_refreshProperties = true;
				}
			}
		}

		public void OnMirrored(PartTargetingData source)
		{
			if (source != null)
			{
				_customPartIds = CloneCustomPartIDs(source._customPartIds);
			}
		}

		void IPartIDChangedListener.OnPartIDsRemapped(Dictionary<int, int> idMap)
		{
			if (_customPartIds == null)
			{
				return;
			}
			bool flag = false;
			for (int i = 0; i < _customPartIds.Count; i++)
			{
				if (idMap.TryGetValue(_customPartIds[i], out var value))
				{
					_customPartIds[i] = value;
					flag = true;
				}
			}
			if (flag)
			{
				OnTargetingChanged();
			}
		}

		void IPartIDChangedListener.OnPartRemoved(PartData part)
		{
			if (_customPartIds != null && _customPartIds.Remove(part.Id))
			{
				OnTargetingChanged();
				_refreshProperties = true;
			}
		}

		public void OnTargetingChanged()
		{
			if (TargetMode == PartTargetingMode.SinglePart)
			{
				FindConnectedTargetPart();
			}
			else if (TargetMode == PartTargetingMode.MultipleParts)
			{
				TargetPart = null;
			}
			else if (TargetMode == PartTargetingMode.Custom)
			{
				TargetPart = null;
				_script.Handler.SetPartIDs(_customPartIds);
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_targetMode = stateElement.GetEnumAttribute("targetMode", _targetMode);
			_customPartIds = stateElement.GetIntListAttribute("customPartIds");
			if (TargetMode == PartTargetingMode.Custom)
			{
				_partIds = _customPartIds.ToList();
			}
			else
			{
				_partIds = stateElement.GetIntListAttribute("partIds");
			}
		}

		public void SetHandler(IPartTargetingHandler handler)
		{
			if (_customPartIds == null)
			{
				_customPartIds = new List<int>();
			}
			if (_script != null)
			{
				_script.Handler = handler;
			}
		}

		private List<int> CloneCustomPartIDs(List<int> sourcePartIds)
		{
			List<int> list = new List<int>(sourcePartIds.Count);
			if (sourcePartIds == null)
			{
				return list;
			}
			Assembly assembly = base.Part.PartScript.Aircraft.Aircraft.Assembly;
			foreach (int sourcePartId in sourcePartIds)
			{
				PartData partById = assembly.GetPartById(sourcePartId);
				if (partById != null && partById.SymmetryId != 0)
				{
					List<PartData> symmetricParts;
					using (assembly.GetOtherSymmetricParts(partById, out symmetricParts))
					{
						if (symmetricParts.Count == 1)
						{
							list.Add(symmetricParts[0].Id);
							continue;
						}
					}
				}
				list.Add(sourcePartId);
			}
			return list;
		}

		private void RefreshCustomPartList(IGenericPartProperties partProperties)
		{
			partProperties.GetProperty<CustomWidgetProperty>("_customPartIds").Widget.GetComponent<PartListWidget>().SetPartList(_customPartIds, base.Part.PartScript.Aircraft.Aircraft.Assembly);
		}
	}
}
