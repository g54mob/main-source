using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class AdaptiveBlockData : PartModifierData
	{
		public class MeshState
		{
			public int AttachPointIndex { get; set; }

			public bool Default { get; set; }

			public int HardEdgeMask { get; set; }

			public int Index { get; set; }

			public string MeshName { get; set; }

			public Vector3 Scale { get; set; }
		}

		public bool Auto { get; private set; }

		public MeshState DefaultMeshState { get; private set; }

		public List<MeshState> MeshStates { get; private set; }

		public string MeshType { get; set; }

		public int State { get; set; }

		public AdaptiveBlockData(XElement element)
			: base(element)
		{
			Auto = element.GetBoolAttribute("auto", defaultValue: true);
			MeshType = element.GetStringAttribute("type", "Block");
			MeshStates = new List<MeshState>();
			if (Auto)
			{
				return;
			}
			IEnumerable<XElement> enumerable = element.Elements("State");
			int num = 0;
			foreach (XElement item in enumerable)
			{
				MeshState meshState = new MeshState
				{
					Index = num++,
					MeshName = item.Attribute("mesh").Value,
					AttachPointIndex = item.GetIntAttribute("attachPoint"),
					HardEdgeMask = item.GetIntAttribute("hardEdgeMask"),
					Scale = item.GetVector3Attribute("scale", Vector3.one),
					Default = item.GetBoolAttribute("default")
				};
				if (meshState.Default)
				{
					Debug.Log("Found Default: " + meshState.Index);
					DefaultMeshState = meshState;
				}
				MeshStates.Add(meshState);
			}
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("state", State));
			return xElement;
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			AdaptiveBlockScript adaptiveBlockScript = parentGameObject.transform.Find("Mesh").gameObject.AddComponent<AdaptiveBlockScript>();
			adaptiveBlockScript.AdaptiveBlock = this;
			return adaptiveBlockScript;
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			State = stateElement.GetIntAttribute("state");
		}
	}
}
