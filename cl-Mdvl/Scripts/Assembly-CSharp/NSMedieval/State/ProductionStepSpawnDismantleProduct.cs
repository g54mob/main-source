using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Models.Production;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.Views.Resources;

namespace NSMedieval.State
{
	[Serializable]
	[FVSerializableKey("ProductionStepSpawnDismantleProduct", "")]
	public class ProductionStepSpawnDismantleProduct : ProductionStepInstance
	{
		public ProductionStepSpawnDismantleProduct()
			: base(ProductionStepType.SpawnDismantleProduct)
		{
		}

		internal override void OnBecomeActive()
		{
			base.OnBecomeActive();
			Resource resource = base.OwnerProductionInstance.Storage.GetSingleResource()?.Blueprint;
			bool isEnabled;
			if (resource == null)
			{
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(49, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Production\\Steps\\ProductionStepSpawnDismantleProduct.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Dismantle tried to spawn but no blueprint found. ");
					messageBuilder.AppendFormatted(base.OwnerProductionInstance.BlueprintId);
				}
				Log.Warning(messageBuilder);
				Complete();
				return;
			}
			if (resource.DismantledProduct == null)
			{
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(37, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Production\\Steps\\ProductionStepSpawnDismantleProduct.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("No dismantle products specified for. ");
					messageBuilder.AppendFormatted(resource.GetID());
				}
				Log.Warning(messageBuilder);
				Complete();
				return;
			}
			base.OwnerProductionInstance.Storage.ClearAll(isSilent: true);
			foreach (KeyIntPair item in resource.DismantledProduct)
			{
				Resource byID = Repository<ResourceRepository, Resource>.Instance.GetByID(item.GetID());
				ResourcePileView resourcePileView = MonoSingleton<ResourcePileManager>.Instance.SpawnPile(new ResourceInstance(byID, item.Value), base.OwnerProductionInstance.OwnerProductionComponentInstance.GetPosition());
				if (resourcePileView != null)
				{
					MonoSingleton<ResourcePileHaulingManager>.Instance.ForceProcessPileState(resourcePileView.ResourcePileInstance);
				}
			}
			Complete();
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public ProductionStepSpawnDismantleProduct(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
