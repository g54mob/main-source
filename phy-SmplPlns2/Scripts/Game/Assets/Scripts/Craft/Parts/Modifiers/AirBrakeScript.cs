using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class AirBrakeScript : PartModifierScript
	{
		private float _angle;

		private AudioSource _audio;

		private Transform _brakeRoot;

		private InputControllerScript _controller;

		private float _drag;

		private float _functionalHealth = 1f;

		private float _targetAngle;

		public AirBrakeData AirBrake { get; set; }

		public bool IsDamaged { get; protected set; }

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart);
		}

		public override void OnDamageLevelIncreased(PartDamageLevel level, float lastDamage, Vector3 lastDamagePosition, Vector3 lastDamageDirection)
		{
			if (level > PartDamageLevel.Light)
			{
				float value = Random.value;
				if (value < 0.3f)
				{
					IsDamaged = true;
				}
				else if (value < 0.6f)
				{
					_functionalHealth = Mathf.Max(0f, _functionalHealth - Random.value);
				}
				else
				{
					_functionalHealth = Mathf.Max(0f, _functionalHealth - Random.value / 2f);
				}
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightLocalUnpaused);
			registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.FlightUnpaused);
		}

		private void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			if (!(base.PartScript.Body != null))
			{
				return;
			}
			if (base.PartScript.Body.DragPhysics is BodyDragPhysicsLegacy bodyDragPhysicsLegacy)
			{
				bodyDragPhysicsLegacy.AddFrameDrag(PartDrag.DragDirection.Forward, _drag * Mathf.Clamp01(1f - base.PartScript.EstimateOfUnderwaterPercent), base.transform.position);
				if (base.PartScript.EstimateOfUnderwaterPercent > 0f)
				{
					float underwaterDragScalar = base.PartScript.Part.PartType.UnderwaterDragScalar;
					bodyDragPhysicsLegacy.AddWaterFrameDrag(PartDrag.DragDirection.Forward, _drag * base.PartScript.EstimateOfUnderwaterPercent * underwaterDragScalar, base.transform.position);
				}
			}
			else
			{
				base.PartScript.Body.DragPhysics.AddFrameDrag(PartDrag.DragDirection.Forward, _drag, base.transform.position);
			}
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			_controller = base.PartScript.GetModifier<InputControllerScript>();
			_brakeRoot = base.PartScript.transform.Find("BrakeRoot");
			_audio = base.PartScript.transform.GetComponent<AudioSource>();
			return UniTask.CompletedTask;
		}

		private void OnUpdate(in CraftUpdateFrameData frame)
		{
			if (IsDamaged)
			{
				return;
			}
			float num = _controller.Value * _functionalHealth;
			_drag = num * AirBrake.Drag;
			_targetAngle = num * -65f;
			float num2 = _targetAngle - _angle;
			float num3 = num2 * frame.DeltaTime * 100f;
			if (Mathf.Abs(num3) > Mathf.Abs(num2))
			{
				num3 = num2;
			}
			if (Mathf.Abs(num3) > 0f || _audio.isPlaying)
			{
				_audio.volume = Mathf.Lerp(_audio.volume, Mathf.Min(0.5f, Mathf.Abs(num3)), frame.DeltaTime);
				_audio.pitch = 0.75f + 0.5f * _audio.volume;
				if (!_audio.isPlaying)
				{
					_audio.Play();
				}
				else if (_audio.volume < 0.001f)
				{
					_audio.Stop();
				}
			}
			_angle += num3;
			Vector3 eulerAngles = _brakeRoot.localRotation.eulerAngles;
			eulerAngles.x = _angle;
			_brakeRoot.localRotation = Quaternion.Euler(eulerAngles);
		}
	}
}
