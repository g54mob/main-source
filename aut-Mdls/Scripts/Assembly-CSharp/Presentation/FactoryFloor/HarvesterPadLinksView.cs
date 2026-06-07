using Data.Buildings;
using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using Shapes;
using UnityEngine;

namespace Presentation.FactoryFloor
{
	public class HarvesterPadLinksView : ReferenceBehaviourLinksView
	{
		[SerializeField]
		private HarvesterPadBehaviour _harvesterPadBehaviour;

		protected override void ShowPreviewLine(Vector3 position, FactoryObject linkObject)
		{
			if (!_factoryObjectsLines.Contains(linkObject) && _harvesterPadBehaviour.IsPointInsideLinkingDistance(position, linkObject.Position))
			{
				BuildingBehaviour factoryObjectBehaviour = linkObject.GetFactoryObjectBehaviour<BuildingBehaviour>();
				Vector3 vector = factoryObjectBehaviour.BuildingLandingPad.GetLandingPadPosition(position);
				factoryObjectBehaviour.BuildingLandingPad.ShowLandingPadPreview(position);
				CreateSoftLinkLine(position + new Vector3(0.5f, 0f, 0.5f), vector + new Vector3(0.5f, 0f, 0.5f));
				_factoryObjectsLines.Add(linkObject);
			}
		}

		protected override Polyline CreateSoftLinkLine(FactoryObject linkObject)
		{
			if (_factoryObjectsLines.Contains(linkObject))
			{
				return null;
			}
			if (!_harvesterPadBehaviour.IsPointInsideLinkingDistance(base.transform.position, linkObject.Position))
			{
				return null;
			}
			Vector3 vector = linkObject.GetFactoryObjectBehaviour<BuildingBehaviour>().BuildingLandingPad.GetLandingPadPosition(_factoryObject.Position);
			Polyline result = CreateSoftLinkLine(_factoryObject.Position + new Vector3(0.5f, 0f, 0.5f), vector + new Vector3(0.5f, 0f, 0.5f));
			_factoryObjectsLines.Add(linkObject);
			return result;
		}

		public override void HideLinks()
		{
			foreach (FactoryObject factoryObjectsLine in _factoryObjectsLines)
			{
				if (factoryObjectsLine.HasFactoryObjectBehaviour(out BuildingBehaviour behaviour))
				{
					behaviour.BuildingLandingPad.HideLandingPadPreview();
				}
			}
			base.HideLinks();
		}
	}
}
