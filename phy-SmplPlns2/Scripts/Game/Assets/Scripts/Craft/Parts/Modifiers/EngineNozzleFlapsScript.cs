using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class EngineNozzleFlapsScript : PartModifierScript
	{
		private const int OpenFlapDeg = 15;

		private List<Transform> _engineNozzleFlaps;

		private InputControllerScript _throttleInput;

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart);
		}

		public void Initialize(EngineNozzleFlapsData engineNozzleFlaps)
		{
			Transform transform = base.transform.Find("Mesh/EngineNozzleFlaps");
			_engineNozzleFlaps = new List<Transform>();
			MeshRenderer[] componentsInChildren = transform.GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer meshRenderer in componentsInChildren)
			{
				GameObject gameObject = new GameObject("EngineNozzleFlap");
				gameObject.transform.parent = transform;
				gameObject.transform.localPosition = meshRenderer.transform.localPosition;
				gameObject.transform.localEulerAngles = meshRenderer.transform.localEulerAngles;
				gameObject.transform.localScale = meshRenderer.transform.localScale;
				meshRenderer.transform.parent = gameObject.transform;
				meshRenderer.transform.localPosition = Vector3.zero;
				meshRenderer.transform.localEulerAngles = Vector3.zero;
				meshRenderer.transform.localScale = Vector3.one;
				_engineNozzleFlaps.Add(meshRenderer.transform);
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.FlightUnpaused);
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			_throttleInput = base.PartScript.GetModifier<InputControllerScript>();
			return UniTask.CompletedTask;
		}

		private void OnUpdate(in CraftUpdateFrameData frame)
		{
			if (_engineNozzleFlaps.Count == 0)
			{
				return;
			}
			float num = 1f - Mathf.Clamp01(_throttleInput.Value);
			float num2 = 15f * num;
			float x = _engineNozzleFlaps[0].localEulerAngles.x;
			if (Utilities.CompareFloats(x, num2, 0.0001f))
			{
				return;
			}
			Quaternion localRotation = Quaternion.Euler(new Vector3(Mathf.Lerp(x, num2, frame.DeltaTime), 0f, 0f));
			foreach (Transform engineNozzleFlap in _engineNozzleFlaps)
			{
				engineNozzleFlap.localRotation = localRotation;
			}
		}
	}
}
