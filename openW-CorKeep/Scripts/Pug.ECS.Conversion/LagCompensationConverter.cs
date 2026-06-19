using Pug.Conversion;
using Unity.NetCode;
using UnityEngine;

public class LagCompensationConverter : Converter
{
	public override void Convert(GameObject authoring)
	{
		if (!(authoring.GetComponent<GhostAuthoringComponent>() == null) && ShouldUseLagCompensation(authoring))
		{
			EnsureHasComponent<UseLagCompensationCD>();
			if (!base.IsServer)
			{
				AddComponentData(default(InterpolatedDestroyPositionCD), componentIsEnabled: false);
			}
		}
	}

	private bool ShouldUseLagCompensation(GameObject authoring)
	{
		ObjectType objectType = ((!(authoring.GetComponent(typeof(IEntityMonoBehaviourData)) is IEntityMonoBehaviourData entityMonoBehaviourData)) ? ObjectType.NonObtainable : entityMonoBehaviourData.ObjectInfo.objectType);
		if (objectType != ObjectType.PlaceablePrefab && objectType != ObjectType.NonObtainable)
		{
			return objectType != ObjectType.PlayerType;
		}
		return false;
	}
}
