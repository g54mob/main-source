using Assets.Scripts.Flight;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.GameLoop;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.LandingLeg
{
	public class LandingLegOriginal : ILandingLeg
	{
		private Vector3 _closedExtensionPosition;

		private Quaternion _closedRotation;

		private Vector3 _deployedExtensionPosition;

		private Quaternion _deployedRotation;

		private Transform _extension;

		private GameObject _gameObject;

		private Transform _landingLeg;

		private bool _moving;

		private Transform _pivot;

		private Vector3 _pivotRelativeCoM = Vector3.zero;

		private Transform _transform;

		public LandingLegData Data { get; private set; }

		public IPartScript PartScript { get; private set; }

		public LandingLegOriginal(LandingLegScript landingLegScript)
		{
			_gameObject = landingLegScript.gameObject;
			Data = landingLegScript.Data;
			PartScript = landingLegScript.PartScript;
			_transform = landingLegScript.transform;
			_landingLeg = Utilities.FindFirstGameObjectMyselfOrChildren("LandingLeg", _gameObject).transform;
			_pivot = Utilities.FindFirstGameObjectMyselfOrChildren("Pivot", _gameObject).transform;
			_extension = Utilities.FindFirstGameObjectMyselfOrChildren("Extension", _gameObject).transform;
			_closedRotation = _pivot.localRotation;
			_deployedRotation = Quaternion.Euler(_closedRotation.eulerAngles.x, _closedRotation.eulerAngles.y, 180f - Data.DeployedAngle);
			_closedExtensionPosition = _extension.localPosition;
			_deployedExtensionPosition = _closedExtensionPosition;
			_deployedExtensionPosition.y = Data.DeployedExtensionY;
			_pivot.localRotation = Quaternion.Euler(Data.CurrentRotation);
			_extension.localPosition = Data.CurrentExtensionPosition;
			UpdateScale();
			Data.Part.Config.CenterOfMass = _transform.InverseTransformPoint(_extension.position) / 3f;
		}

		public void DesignerUpdate(in DesignerFrameData frame)
		{
			if (Data.PropertiesOpen || Data.StartDeployed)
			{
				_deployedRotation = Quaternion.Euler(_closedRotation.eulerAngles.x, _closedRotation.eulerAngles.y, 180f - Data.DeployedAngle);
				_pivot.localRotation = Quaternion.RotateTowards(_pivot.localRotation, _deployedRotation, frame.DeltaTime * 100f);
				_extension.localPosition = Vector3.MoveTowards(_extension.localPosition, _deployedExtensionPosition, frame.DeltaTime * 2f);
			}
			else
			{
				_pivot.localRotation = Quaternion.RotateTowards(_pivot.localRotation, _closedRotation, frame.DeltaTime * 100f);
				_extension.localPosition = Vector3.MoveTowards(_extension.localPosition, _closedExtensionPosition, frame.DeltaTime * 2f);
			}
		}

		public void FlightStart(in FlightFrameData frame)
		{
			if (PartScript.Data.AttachPoints.Count > 0 && PartScript.BodyScript.Joints.Count > 0 && PartScript.BodyScript.Joints[0].Joints.Count > 0)
			{
				ConfigurableJoint configurableJoint = PartScript.BodyScript.Joints[0].Joints[0].Joint as ConfigurableJoint;
				if (configurableJoint != null)
				{
					configurableJoint.angularXMotion = ConfigurableJointMotion.Locked;
					configurableJoint.angularYMotion = ConfigurableJointMotion.Locked;
					configurableJoint.angularZMotion = ConfigurableJointMotion.Locked;
				}
			}
			_pivotRelativeCoM = _pivot.InverseTransformPoint(PartScript.BodyScript.RigidBody.transform.TransformPoint(PartScript.BodyScript.RigidBody.centerOfMass));
			if (Data.StartDeployed)
			{
				PartScript.Data.Activated = true;
				Data.StartDeployed = false;
			}
		}

		public void FlightUpdate(in FlightFrameData frame)
		{
			Quaternion quaternion = (PartScript.Data.Activated ? _deployedRotation : _closedRotation);
			bool flag = false;
			if (!Utilities.CompareQuaternions(_pivot.localRotation, quaternion))
			{
				_pivot.localRotation = Quaternion.RotateTowards(_pivot.localRotation, quaternion, frame.DeltaTime * Data.DeploySpeed);
				Data.CurrentRotation = _pivot.localEulerAngles;
				flag = true;
			}
			Vector3 vector = (PartScript.Data.Activated ? _deployedExtensionPosition : _closedExtensionPosition);
			if (!Utilities.CompareVector3s(_extension.localPosition, vector))
			{
				Data.CurrentExtensionPosition = Vector3.MoveTowards(_extension.localPosition, vector, frame.DeltaTime * Data.DeploySpeed / 50f);
				_extension.localPosition = Data.CurrentExtensionPosition;
				flag = true;
			}
			if (flag)
			{
				UpdateCenterOfMass();
			}
			if (_moving != flag)
			{
				_moving = flag;
				if (!_moving)
				{
					FlightSceneScript.Instance.DragCalculator.Queue.AddBody(PartScript.BodyScript);
				}
			}
		}

		public void PrepareForPartIcon()
		{
		}

		public void SetStartDeployed(bool startDeployed)
		{
			Data.CurrentRotation = (startDeployed ? _deployedRotation : _closedRotation).eulerAngles;
			Data.CurrentExtensionPosition = (startDeployed ? _deployedExtensionPosition : _closedExtensionPosition);
		}

		public void UpdateScale()
		{
			foreach (AttachPointScript attachPointScript in PartScript.AttachPointScripts)
			{
				attachPointScript.AttachPoint.Scale = 1f * Data.Scale;
			}
			_landingLeg.localScale = new Vector3(Data.Scale * 0.75f, Data.Scale * 0.75f, Data.Scale * 0.75f);
		}

		private void UpdateCenterOfMass()
		{
			if (PartScript.BodyScript != null && PartScript.BodyScript.RigidBody != null)
			{
				PartScript.BodyScript.CenterOfMass = PartScript.BodyScript.Transform.InverseTransformPoint(_pivot.TransformPoint(_pivotRelativeCoM));
				PartScript.CraftScript.SetMassChanged();
			}
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
