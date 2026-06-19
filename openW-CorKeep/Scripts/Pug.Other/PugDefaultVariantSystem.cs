using System.Collections.Generic;
using Unity.Entities;
using Unity.NetCode;
using Unity.Physics.GraphicsIntegration;
using Unity.Transforms;
using UnityEngine.Scripting;

public class PugDefaultVariantSystem : DefaultVariantSystemBase
{
	protected override void RegisterDefaultVariants(Dictionary<ComponentType, Rule> defaultVariants)
	{
		if (defaultVariants.ContainsKey(typeof(LocalTransform)))
		{
			defaultVariants.Remove(typeof(LocalTransform));
		}
		if (defaultVariants.ContainsKey(typeof(PredictedLocalTransformSmoothingCD)))
		{
			defaultVariants.Remove(typeof(PredictedLocalTransformSmoothingCD));
		}
		defaultVariants.Add(typeof(LocalTransform), Rule.ForAll(typeof(PugLocalTransformDefaultVariant)));
		defaultVariants.Add(typeof(PredictedLocalTransformSmoothingCD), Rule.ForAll(typeof(PugPredictedLocalTransformSmoothingCDVariant)));
	}

	[Preserve]
	public PugDefaultVariantSystem()
	{
	}
}
