using Pug.Conversion;
using UnityEngine;

public class VelocityAffectorConverter : SingleAuthoringComponentConverter<VelocityAffectorAuthoring>
{
	protected override void Convert(VelocityAffectorAuthoring authoring)
	{
		if (authoring.moveForceOptions.Count == 0)
		{
			Debug.LogError("VelocityAffector " + authoring.name + " has no move force options set.", authoring);
		}
		AddComponentData(new VelocityAffectorCD
		{
			priority = authoring.priority,
			requiresElectricity = authoring.requiresElectricity,
			lastIndex = -1,
			moveOptions = CreateAndAddSimpleBlobArrayAsset(authoring.moveForceOptions, (VelocityAffectorAuthoring.MoveForceOption x) => new VelocityAffectorMoveOptionElementData
			{
				moveForce = x.moveForce
			})
		});
	}
}
