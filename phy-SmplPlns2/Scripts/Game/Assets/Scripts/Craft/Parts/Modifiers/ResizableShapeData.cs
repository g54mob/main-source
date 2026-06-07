using System.Xml.Linq;
using Assets.Scripts.Design;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Resizable Shape")]
	public class ResizableShapeData : PartModifierData
	{
		private Vector3 _attachPointPosition = Vector3.zero;

		[DesignerPropertySlider(0f, 1f, 101, Label = "Bounciness", Order = 1)]
		private float _bounciness = 0.1f;

		[DesignerPropertySlider(0f, 2f, 41, Label = "Friction", Order = 2)]
		private float _friction = 0.8f;

		private PartLodDataScript _partLod;

		private ResizableShapeScript _resizableSphereScript;

		[DesignerPropertySlider(0.25f, 5f, 96, Label = "Size", Order = 0)]
		private float _size = 1f;

		public float Bounciness => _bounciness;

		public float Friction => _friction;

		public override float Mass => base.Mass;

		public float Size => _size / 4f;

		public ResizableShapeData(XElement partType)
			: base(partType)
		{
		}

		public void ApplySize(bool reposition = true)
		{
			if (!(_resizableSphereScript != null))
			{
				return;
			}
			bool flag = base.Part.PartScript.LoadContext == CraftLoadContext.Designer;
			Vector3 localScale = new Vector3(Size, Size, Size);
			Vector3 vector = new Vector3(_size, _size, _size);
			if (base.Part.PartScale.HasValue)
			{
				vector.Scale(base.Part.PartScale.Value);
			}
			_partLod.UpdateLod(Mathf.Max(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z)));
			Vector3 vector2 = Vector3.zero;
			if (flag)
			{
				base.Part.AttachPoints[0].Position = _attachPointPosition;
			}
			if (reposition && flag)
			{
				vector2 = base.Part.AttachPoints[0].AttachPointScript.transform.position;
			}
			_resizableSphereScript.transform.Find("Mesh").localScale = localScale;
			_resizableSphereScript.transform.Find("Collider").localScale = localScale;
			if (flag)
			{
				for (int i = 0; i < base.Part.AttachPoints.Count; i++)
				{
					base.Part.AttachPoints[i].AttachPointScript.transform.localPosition = base.Part.AttachPoints[i].Position * (Size * 2f);
				}
			}
			if (reposition)
			{
				_resizableSphereScript.transform.position += vector2 - base.Part.AttachPoints[0].AttachPointScript.transform.position;
			}
			if (flag && Designer.Instance != null && Designer.Instance.Aircraft != null)
			{
				Designer.Instance.SetAircraftStructureChanged();
			}
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("size", _size.ToString()));
			xElement.Add(new XAttribute("bounciness", _bounciness.ToString()));
			xElement.Add(new XAttribute("friction", _friction.ToString()));
			xElement.Add(new XAttribute("attachPointPosition", _attachPointPosition.ToXAttributeValue()));
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			switch (propertyName)
			{
			case "_size":
				return sliderValue.ToString("0.00");
			case "_bounciness":
			case "_friction":
				return Utilities.FormatPercentage(sliderValue);
			default:
				return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
			}
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			_resizableSphereScript = parentGameObject.AddComponent<ResizableShapeScript>();
			_partLod = parentGameObject.GetComponent<PartLodDataScript>();
			_resizableSphereScript.Initialize(this);
			return _resizableSphereScript;
		}

		public override void OnGenericDesignerPropertiesUpdate(IGenericPartProperties genericPartProperties)
		{
			base.OnGenericDesignerPropertiesUpdate(genericPartProperties);
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			if (_resizableSphereScript != null)
			{
				_resizableSphereScript.CheckScale();
			}
			ApplySize();
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			if (stateElement.Attribute("size") != null && !float.TryParse(stateElement.Attribute("size").Value, out _size))
			{
				_size = 1f;
			}
			if (stateElement.Attribute("bounciness") != null)
			{
				if (!float.TryParse(stateElement.Attribute("bounciness").Value, out _bounciness))
				{
					_bounciness = 0.1f;
				}
				else
				{
					_bounciness = Mathf.Clamp(_bounciness, 0f, 1f);
				}
			}
			if (stateElement.Attribute("friction") != null && !float.TryParse(stateElement.Attribute("friction").Value, out _friction))
			{
				_friction = 0.8f;
			}
			if (stateElement.Attribute("attachPointPosition") != null)
			{
				_attachPointPosition = stateElement.GetVector3Attribute("attachPointPosition");
			}
		}

		protected override float CalculateMass()
		{
			float size = _size;
			float size2 = _size;
			float num = 0.25f * Size * 2f;
			float num2 = Size - num;
			float num3 = size2 - num2;
			return Mathf.Abs(size * 0.01f * num3 * 10f) * base.Part.MassScale;
		}
	}
}
