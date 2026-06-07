using System;
using Presentation.FactoryFloor.Culling;

public interface ICullable
{
	CullableObjectState CurrentState { get; }

	bool IsCulledOrShadowsOnly { get; }

	Action<CullableObjectState, CullableObjectState> OnNewCullState { get; set; }

	CullableSettings GetSettings();

	CullablePositionInfo GetPosition();

	void UpdateCullState(CullableObjectState cull);
}
