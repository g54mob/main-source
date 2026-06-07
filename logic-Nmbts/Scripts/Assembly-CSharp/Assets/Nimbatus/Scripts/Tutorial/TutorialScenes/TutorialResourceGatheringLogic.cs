using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.ResourceCollection;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Tutorial.TutorialScenes
{
	public class TutorialResourceGatheringLogic : GenericTutorialLogic
	{
		private enum EResourceGathering
		{
			Gathering = 0,
			Deploying = 1
		}

		public TutorialResourceJunk ResourceJunk;

		public Transform TargetResource;

		public Transform TargetContainer;

		private float _fakeResourceAmount;

		private float _resourceAmountToFinish;

		private EResourceGathering _resourceState;

		private void Awake()
		{
			_resourceAmountToFinish = 150f;
			_resourceState = EResourceGathering.Gathering;
		}

		public override void OnUpdate()
		{
			bool flag = RuntimeGlobals.NimbatusPlayer.Drone.RootDronePart.ResourceHub.HasCapacity(EResourceType.CommonOre, 10f);
			bool flag2 = RuntimeGlobals.NimbatusPlayer.Drone.RootDronePart.ResourceHub.HasResource(EResourceType.CommonOre, 10f);
			if (_resourceState == EResourceGathering.Gathering)
			{
				if (!flag || ResourceJunk.IsEverythingCollected())
				{
					_resourceState = EResourceGathering.Deploying;
				}
			}
			else if (_resourceState == EResourceGathering.Deploying && !flag2)
			{
				_resourceState = EResourceGathering.Gathering;
			}
			if (!flag && !flag2)
			{
				_resourceState = EResourceGathering.Gathering;
			}
		}

		public override bool IsCompleted()
		{
			return GetResourceFakeAmount() >= _resourceAmountToFinish;
		}

		public override string TutorialLabel()
		{
			string translation = LocalizationManager.GetTermTranslation("Tutorial/ResourceGatheringStatus");
			LocalizationManager.ApplyLocalizationParams(ref translation, "Amount", Mathf.CeilToInt(_resourceAmountToFinish).ToString());
			LocalizationManager.ApplyLocalizationParams(ref translation, "Current", Mathf.CeilToInt(GetResourceFakeAmount()).ToString());
			LocalizationManager.ApplyLocalizationParams(ref translation, "Goal", Mathf.CeilToInt(_resourceAmountToFinish).ToString());
			return translation;
		}

		public override Vector3 CursorPosition()
		{
			if (TargetContainer != null && TargetResource != null)
			{
				if (_resourceState == EResourceGathering.Gathering)
				{
					return TargetResource.position;
				}
				return TargetContainer.position;
			}
			return Vector3.zero;
		}

		public override bool IsCursorVisible()
		{
			if (ResourceJunk.IsEverythingCollected())
			{
				return false;
			}
			if (TargetContainer != null && TargetResource != null)
			{
				return !IsCompleted();
			}
			return false;
		}

		public float GetResourceFakeAmount()
		{
			return _fakeResourceAmount;
		}

		public void AddResourceFakeAmount(float amount)
		{
			_fakeResourceAmount += amount;
		}
	}
}
