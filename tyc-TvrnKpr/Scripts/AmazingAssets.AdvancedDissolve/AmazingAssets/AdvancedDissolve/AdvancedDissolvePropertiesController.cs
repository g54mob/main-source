using UnityEngine;

namespace AmazingAssets.AdvancedDissolve
{
	[ExecuteAlways]
	public class AdvancedDissolvePropertiesController : AdvancedDissolveController
	{
		public enum UpdateMode
		{
			OnAwake = 0,
			OnFixedUpdate = 1,
			EveryFrame = 2,
			Manual = 3
		}

		public UpdateMode updateMode;

		public AdvancedDissolveProperties.Cutout.Standard cutoutStandard;

		public AdvancedDissolveProperties.Cutout.Geometric cutoutGeometric;

		public AdvancedDissolveProperties.Edge.Base edgeBase;

		public AdvancedDissolveProperties.Edge.AdditionalColor edgeAdditionalColor;

		public AdvancedDissolveProperties.Edge.UVDistortion edgeUVDistortion;

		public AdvancedDissolveProperties.Edge.GlobalIllumination edgeGlobalIllumination;

		protected override void Awake()
		{
		}

		protected override void Update()
		{
		}

		private void FixedUpdate()
		{
		}

		[ContextMenu("Force Update Properties Controller")]
		public override void ForceUpdateShaderData()
		{
		}

		private void UpdateShaderData()
		{
		}

		[ContextMenu("Reset Properties Controller")]
		public override void ResetShaderData()
		{
		}
	}
}
