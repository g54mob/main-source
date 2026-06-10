using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Map;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(BaseBuildingViewComponent))]
	public class BeamComponent : BaseComponent
	{
		[SerializeField]
		private BeamComponentInstance componentInstance;

		[NonSerialized]
		private bool markedForRemoval;

		public BaseBuildingInstance BaseBuildingInstance => base.BaseBuildingViewComponent.BaseBuildingInstance;

		public BeamComponentInstance ComponentInstance => componentInstance;

		public event Action<bool> EnableCollidersEvent;

		public void CacheInstance(BeamComponentInstance beamComponentInstance)
		{
			componentInstance = beamComponentInstance;
			base.BaseComponentInstance = componentInstance;
		}

		public void EnableColliders(bool value)
		{
			this.EnableCollidersEvent?.Invoke(value);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoadedDestroyBeam;
			}
			this.EnableCollidersEvent = null;
			componentInstance = null;
		}

		protected override void OnEnterPoolOnMainSceneLeaving()
		{
			base.OnEnterPoolOnMainSceneLeaving();
			componentInstance = null;
		}

		protected override void OnReturnToPoolDuringGameplay()
		{
			base.OnReturnToPoolDuringGameplay();
			componentInstance = null;
		}

		protected override void OnAfterBaseBuildingPlaced(bool afterLoading = false)
		{
			if (afterLoading)
			{
				VillageInstance activeVillage = VillageManager.ActiveVillage;
				componentInstance = activeVillage.WorldObjectStorage.GetBaseComponentInstanceByUniqueId(base.OwnerBuilding.UniqueId) as BeamComponentInstance;
				base.BaseComponentInstance = componentInstance;
				if (componentInstance == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(62, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Beams\\BeamComponent.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Couldn't find BeamComponentInstance in component storage! ID: ");
						messageBuilder.AppendFormatted(base.OwnerBuilding.UniqueId);
					}
					Log.Error(messageBuilder);
					markedForRemoval = true;
					MonoSingleton<World>.Instance.MapLoadedEvent += OnMapLoadedDestroyBeam;
					return;
				}
				componentInstance.SetupAfterLoading(base.OwnerBuilding);
				componentInstance.Map.BeamComponentManager.AddToCache(this, componentInstance);
			}
			base.OnAfterBaseBuildingPlaced(afterLoading);
		}

		protected override void OnInfoPanelDataRequested()
		{
		}

		private void OnMapLoadedDestroyBeam(bool fromSave)
		{
			MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoadedDestroyBeam;
			if (fromSave && markedForRemoval)
			{
				base.OwnerBuilding.Map.BuildingsManagerMain.DestroyBuilding(base.OwnerBuilding);
			}
		}
	}
}
