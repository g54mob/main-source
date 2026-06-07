using System.Linq;
using Assets.Scripts.Design.Tools;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class EngineThrustPortScript : PartModifierScript
	{
		public bool EnableGroundEffect = true;

		private Transform _centerOfThrust;

		private EngineThrustPortData _engineThrustPort;

		private float _functionalHealth = 1f;

		private Transform _mesh;

		private PartScript _part;

		private ParticleSystem _particleSystem;

		private ParticleSystem.EmissionModule _particleSystemEmission;

		private ParticleSystem.MainModule _particleSystemMain;

		private float _particleSystemStartLifetime;

		private RotatorScript _rotatorScript;

		private VtolManagerScript _vtolManager;

		public void FixedUpdateWithEnforcedOrder(float forceMagnitude)
		{
			if (!((double)_functionalHealth < 0.001))
			{
				Vector3 position = _centerOfThrust.position;
				Rigidbody component = _part.Body.GetComponent<Rigidbody>();
				Vector3 force = _centerOfThrust.forward * (forceMagnitude * _functionalHealth);
				component.AddForceAtPosition(force, position);
			}
		}

		public void Initialize(EngineThrustPortData engineThrustPort)
		{
			_engineThrustPort = engineThrustPort;
		}

		public override void OnDamageLevelIncreased(PartDamageLevel level, float lastDamage, Vector3 lastDamagePosition, Vector3 lastDamageDirection)
		{
			if (level == PartDamageLevel.Moderate)
			{
				base.PartScript.Aircraft.DamageEffects.CreateFireSmall(base.PartScript, null);
			}
			if (level > PartDamageLevel.Light)
			{
				_functionalHealth = Mathf.Max(0f, _functionalHealth - Random.value * (float)level);
			}
		}

		public override void PreviewPartPlacement(AttachPointData myAttachPointBeingUsed, AttachPointData theirAttachPointToPreviewConnectionTo, PartSelection selection)
		{
			base.PreviewPartPlacement(myAttachPointBeingUsed, theirAttachPointToPreviewConnectionTo, selection);
			AdjustPortOrientationBasedOnAttachPointBeingUsed(myAttachPointBeingUsed);
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterStart(OnStart);
			registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.FlightDefault);
		}

		private void AdjustPortOrientationBasedOnAttachPointBeingUsed()
		{
			AdjustPortOrientationBasedOnAttachPointBeingUsed(GetAttachPointBeingUsed());
		}

		private void AdjustPortOrientationBasedOnAttachPointBeingUsed(AttachPointData attachPointBeingUsed)
		{
			if (attachPointBeingUsed == _part.Part.AttachPoints.First())
			{
				_mesh.transform.localEulerAngles = new Vector3(180f, 90f, 90f);
				_rotatorScript.Invert = true;
			}
			else
			{
				_mesh.transform.localEulerAngles = new Vector3(0f, 90f, 90f);
				_rotatorScript.Invert = false;
			}
			_rotatorScript.UpdateNeutralPosition();
		}

		private AttachPointData GetAttachPointBeingUsed()
		{
			foreach (AttachPointData attachPoint in _part.Part.AttachPoints)
			{
				if (!attachPoint.IsAvailable)
				{
					return attachPoint;
				}
			}
			return null;
		}

		private void OnStart(in CraftUpdateFrameData frame)
		{
			_part = base.transform.GetComponent<PartScript>();
			CraftLoadContext loadContext = base.LoadContext;
			bool flag = loadContext == CraftLoadContext.Designer;
			bool active = loadContext == CraftLoadContext.Flight;
			if (!flag)
			{
				Collider[] componentsInChildren = base.transform.GetComponentInParent<PartScript>().GetComponentsInChildren<Collider>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].enabled = false;
				}
			}
			_vtolManager = _part.Aircraft.VtolManagerScript;
			_rotatorScript = GetComponent<RotatorScript>();
			_mesh = Utilities.FindFirstGameObjectMyselfOrChildren("Mesh", _part.gameObject).transform;
			_particleSystem = Utilities.FindFirstGameObjectMyselfOrChildren("EngineSmokeSystem", _part.gameObject).GetComponent<ParticleSystem>();
			_particleSystemMain = _particleSystem.main;
			_particleSystemEmission = _particleSystem.emission;
			_particleSystemEmission.enabled = active;
			_particleSystem.gameObject.SetActive(active);
			_particleSystemStartLifetime = _particleSystemMain.startLifetime.constantMax;
			_particleSystemMain.startLifetime = 0f;
			_particleSystemMain.scalingMode = ParticleSystemScalingMode.Hierarchy;
			_particleSystem.transform.localScale = _engineThrustPort.ExhaustScale;
			if (_engineThrustPort.ExhaustStartColorOverridePrimary.HasValue)
			{
				_particleSystemMain.startColor = _engineThrustPort.ExhaustStartColorOverridePrimary.Value;
			}
			_engineThrustPort.ExhaustStartColorOverridePrimary = _particleSystemMain.startColor.color;
			_centerOfThrust = Utilities.FindFirstGameObjectMyselfOrChildren("CenterOfThrust", _part.gameObject).transform;
			AdjustPortOrientationBasedOnAttachPointBeingUsed();
		}

		private void OnUpdate(in CraftUpdateFrameData frame)
		{
			_particleSystemMain.startLifetime = _particleSystemStartLifetime * _vtolManager.CurrentMaxDuctedEngineThrottle * _functionalHealth;
		}
	}
}
