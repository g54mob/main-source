using Assets.Scripts.Flight;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.GameLoop;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.LandingLeg
{
	public abstract class LandingLegCommon : ILandingLeg
	{
		private LoopingAudioScript _audio;

		private Transform _centerOfMass;

		private float _designerExtensionPercentage;

		private Transform _landingLeg;

		public LandingLegData Data { get; private set; }

		public IPartScript PartScript { get; private set; }

		protected GameObject GameObject { get; private set; }

		protected bool Moving { get; private set; }

		protected LandingLegSuspensionScript Suspension { get; private set; }

		protected Transform Transform { get; private set; }

		public LandingLegCommon(LandingLegScript landingLegScript)
		{
			Suspension = landingLegScript.PartScript.GetModifier<LandingLegSuspensionScript>();
			GameObject = landingLegScript.gameObject;
			Transform = GameObject.transform;
			Data = landingLegScript.Data;
			PartScript = landingLegScript.PartScript;
			_designerExtensionPercentage = Data.ExtensionPercentage;
			_centerOfMass = Utilities.FindFirstGameObjectMyselfOrChildren("CenterOfMass", GameObject).transform;
			_landingLeg = Utilities.FindFirstGameObjectMyselfOrChildren("LandingLeg", GameObject).transform;
		}

		public void DesignerUpdate(in DesignerFrameData frame)
		{
			bool flag = false;
			float num = UpdateExtensionPercentage(_designerExtensionPercentage, Data.PropertiesOpen || Data.StartDeployed);
			if (_designerExtensionPercentage != num)
			{
				flag = true;
				_designerExtensionPercentage = num;
			}
			SetDeploymentState(_designerExtensionPercentage, flight: false);
			if (Moving != flag)
			{
				Moving = flag;
				UpdateCenterOfMass(flight: false);
				PartScript.CraftScript.SetStructureChanged();
			}
		}

		public void FlightStart(in FlightFrameData frame)
		{
			if (Data.StartDeployed)
			{
				PartScript.Data.Activated = true;
				Data.StartDeployed = false;
			}
			if (Data.SoundVolume > 0f)
			{
				_audio = PartScript.Transform.GetComponentInChildren<LoopingAudioScript>(includeInactive: true);
			}
		}

		public void FlightUpdate(in FlightFrameData frame)
		{
			bool flag = false;
			float num = UpdateExtensionPercentage(Data.ExtensionPercentage, PartScript.Data.Activated);
			Suspension.ExtensionPercentage = num;
			if (Data.ExtensionPercentage != num)
			{
				flag = true;
				Data.ExtensionPercentage = num;
			}
			SetDeploymentState(Data.ExtensionPercentage, flight: true);
			if (Moving != flag)
			{
				Moving = flag;
				if (!Moving)
				{
					FlightSceneScript.Instance.DragCalculator.Queue.AddBody(PartScript.BodyScript);
				}
				UpdateCenterOfMass(flight: true);
			}
			if (_audio != null)
			{
				_audio.UpdateLoopAudio(flag ? (Data.SoundVolume * 0.25f) : 0f);
			}
		}

		public virtual void PrepareForPartIcon()
		{
		}

		public void SetStartDeployed(bool startDeployed)
		{
			Data.ExtensionPercentage = (startDeployed ? 1f : 0f);
		}

		public void UpdateScale()
		{
			foreach (AttachPointScript attachPointScript in PartScript.AttachPointScripts)
			{
				attachPointScript.AttachPoint.Scale = 2f * Data.Scale * Data.BaseScale;
			}
			_landingLeg.localScale = new Vector3(Data.Scale * Data.BaseScale, Data.Scale * Data.BaseScale, Data.Scale * Data.BaseScale);
		}

		protected abstract void SetDeploymentState(float extensionPercentage, bool flight);

		protected void UpdateCenterOfMass(bool flight)
		{
			PartScript.Data.Config.CenterOfMass = Transform.InverseTransformPoint(_centerOfMass.position);
			if (flight)
			{
				PartScript.BodyScript.OnPartMassChanged();
			}
		}

		private float UpdateExtensionPercentage(float percentage, bool extend)
		{
			float num = Data.DeploySpeed / 100f * Time.deltaTime;
			if (!extend)
			{
				num = 0f - num;
			}
			return Mathf.Clamp01(percentage + num);
		}

		void ILandingLeg.DesignerUpdate(in DesignerFrameData frame)
		{
			DesignerUpdate(in frame);
		}

		void ILandingLeg.FlightStart(in FlightFrameData frame)
		{
			FlightStart(in frame);
		}

		void ILandingLeg.FlightUpdate(in FlightFrameData frame)
		{
			FlightUpdate(in frame);
		}
	}
}
