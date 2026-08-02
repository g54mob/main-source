using System.Collections.Generic;
using FIMSpace.FGenerating;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class RAF_Optimize : RagdollAnimatorFeatureBase
	{
		protected List<Renderer> visibilityMeshes;

		protected FUniversalVariable distanceV;

		protected FUniversalVariable enterThresholdV;

		protected FUniversalVariable fadeSpeedV;

		protected FUniversalVariable storeCalibrateV;

		private RagdollHandler.OptimizationHandler lodHandler;

		protected bool closeEnough = true;

		public override bool OnInit()
		{
			base.ParentRagdollHandler.AddToAlwaysUpdateLoop(Update);
			distanceV = base.InitializedWith.RequestVariable("Max Distance:", 0f);
			enterThresholdV = base.InitializedWith.RequestVariable("Enter Threshold:", 2f);
			fadeSpeedV = base.InitializedWith.RequestVariable("Fade Speed", 1f);
			storeCalibrateV = base.InitializedWith.RequestVariable("Store Pose", false);
			lodHandler = new RagdollHandler.OptimizationHandler(base.ParentRagdollHandler);
			visibilityMeshes = new List<Renderer>();
			foreach (Object customObject in base.InitializedWith.customObjectList)
			{
				Renderer renderer = customObject as Renderer;
				if ((bool)renderer)
				{
					visibilityMeshes.Add(renderer);
				}
			}
			return base.OnInit();
		}

		public override void OnDestroyFeature()
		{
			base.ParentRagdollHandler.RemoveFromAlwaysUpdateLoop(Update);
		}

		public virtual void Update()
		{
			if (CalculateShouldBeTurnedOn())
			{
				if (storeCalibrateV.GetBool())
				{
					base.ParentRagdollHandler.StoreCalibrationPose();
				}
				lodHandler.TurnOnTick(Time.unscaledDeltaTime * fadeSpeedV.GetFloat());
			}
			else
			{
				lodHandler.TurnOffTick(Time.unscaledDeltaTime * fadeSpeedV.GetFloat());
			}
		}

		protected bool CalculateShouldBeTurnedOn()
		{
			if (!CalculateMeshVisibilityRequirement())
			{
				return false;
			}
			if (!CalculateCameraDistanceRequirement())
			{
				return false;
			}
			return true;
		}

		protected virtual bool CalculateMeshVisibilityRequirement()
		{
			bool result = false;
			if (visibilityMeshes.Count == 0)
			{
				result = true;
			}
			else
			{
				foreach (Renderer visibilityMesh in visibilityMeshes)
				{
					if (visibilityMesh.isVisible)
					{
						result = true;
						break;
					}
				}
			}
			return result;
		}

		protected virtual bool CalculateCameraDistanceRequirement()
		{
			Camera main = Camera.main;
			if (main == null)
			{
				return true;
			}
			if (distanceV.GetFloat() <= 0f)
			{
				return true;
			}
			float num = Vector3.Distance(base.ParentRagdollHandler.GetAnchorSourceBone().position, main.transform.position);
			if (num < distanceV.GetFloat())
			{
				closeEnough = true;
				return true;
			}
			if (num > distanceV.GetFloat() + enterThresholdV.GetFloat())
			{
				closeEnough = false;
				return false;
			}
			return closeEnough;
		}
	}
}
