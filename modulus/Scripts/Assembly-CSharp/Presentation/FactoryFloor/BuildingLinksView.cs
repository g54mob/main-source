using Data.Buildings;
using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using Shapes;
using UnityEngine;

namespace Presentation.FactoryFloor
{
	public class BuildingLinksView : ReferenceBehaviourLinksView
	{
		[SerializeField]
		private HarvesterPadBehaviour _harvesterPadBehaviour;

		private BuildingBehaviour _buildingBehaviour;

		public override void SetFactoryObject(FactoryObject factoryObject, bool isGameLoading = false)
		{
			base.SetFactoryObject(factoryObject, isGameLoading);
			_buildingBehaviour = factoryObject.GetFactoryObjectBehaviour<BuildingBehaviour>();
		}

		protected override void ShowPreviewLine(Vector3 position, FactoryObject linkObject)
		{
			if (_harvesterPadBehaviour.IsPointInsideLinkingDistance(position, linkObject.Position))
			{
				base.ShowPreviewLine(position, linkObject);
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
			Vector3 vector = _buildingBehaviour.BuildingLandingPad.GetLandingPadPosition(linkObject.Position);
			Polyline result = CreateSoftLinkLine(vector + new Vector3(0.5f, 0f, 0.5f), linkObject.Position + new Vector3(0.5f, 0f, 0.5f));
			_factoryObjectsLines.Add(linkObject);
			return result;
		}
	}
}
