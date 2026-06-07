using System.Xml.Linq;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class DesignerSelectionPreviewData : PartModifierData
	{
		private Vector3 _offset = Vector3.zero;

		private string _parentPath;

		private string _prefabPath = "Text";

		private Vector3 _rotation = Vector3.zero;

		private DesignerSelectionPreviewScript _script;

		public Vector3 Offset => _offset;

		public string PrefabPath => _prefabPath;

		public Vector3 Rotation => _rotation;

		public DesignerSelectionPreviewData(XElement element)
			: base(element)
		{
			_prefabPath = element.GetStringAttribute("prefabPath", string.Empty);
			_parentPath = element.GetStringAttribute("parentPath", string.Empty);
			_offset = element.GetVector3Attribute("offset", Vector3.zero);
			_rotation = element.GetVector3Attribute("rotation", Vector3.zero);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			Transform transform = parentGameObject.transform;
			if (!string.IsNullOrEmpty(_parentPath))
			{
				transform = transform.Find(_parentPath);
				if (transform == null)
				{
					transform = parentGameObject.transform;
					Debug.LogError($"SelectionPreview on Part-{base.Part.Id} specifies invalid parent path.");
				}
			}
			_script = transform.gameObject.AddComponent<DesignerSelectionPreviewScript>();
			_script.Initialize(this);
			return _script;
		}
	}
}
