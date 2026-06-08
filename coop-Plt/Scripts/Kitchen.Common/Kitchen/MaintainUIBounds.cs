using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	[FilterModes(AllowedModes = GameSetupMode.All)]
	public class MaintainUIBounds : GenericSystemBase
	{
		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SAssetDirectory_14;

		protected override void Initialise()
		{
			base.Initialise();
			RequireSingletonForUpdate<SAssetDirectory>();
		}

		protected override void OnUpdate()
		{
			Entity singletonEntity = _SingletonEntityQuery_SAssetDirectory_14.GetSingletonEntity();
			CViewDirectory sharedComponentData = base.EntityManager.GetSharedComponentData<CViewDirectory>(singletonEntity);
			sharedComponentData.UIBounds = ViewHelpers.GetOrthoCameraBounds(sharedComponentData.UICamera);
			base.EntityManager.SetSharedComponentData(singletonEntity, sharedComponentData);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SAssetDirectory_14 = GetEntityQuery(ComponentType.ReadOnly<SAssetDirectory>());
		}
	}
}
