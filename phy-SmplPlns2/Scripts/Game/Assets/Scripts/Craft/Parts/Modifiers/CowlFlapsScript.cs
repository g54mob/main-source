using System.Collections.Generic;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class CowlFlapsScript : PartModifierScript
	{
		private List<Transform> _cowlFlaps;

		private CowlFlapsData _partData;

		public void Initialize(CowlFlapsData cowlFlaps)
		{
			_partData = cowlFlaps;
			Transform transform = Utilities.FindFirstGameObjectMyselfOrChildren("CowlFlaps", base.gameObject).transform;
			if (cowlFlaps.HideCowl)
			{
				transform.gameObject.SetActive(value: false);
				Utilities.FindFirstGameObjectMyselfOrChildren("Large_Engine", base.gameObject).SetActive(value: false);
				return;
			}
			_cowlFlaps = new List<Transform>();
			MeshRenderer[] componentsInChildren = transform.GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer meshRenderer in componentsInChildren)
			{
				GameObject gameObject = new GameObject("CowlFlap");
				gameObject.transform.parent = transform;
				gameObject.transform.localPosition = meshRenderer.transform.localPosition;
				gameObject.transform.localEulerAngles = meshRenderer.transform.localEulerAngles;
				gameObject.transform.localScale = meshRenderer.transform.localScale;
				meshRenderer.transform.parent = gameObject.transform;
				meshRenderer.transform.localPosition = Vector3.zero;
				meshRenderer.transform.localEulerAngles = Vector3.zero;
				meshRenderer.transform.localScale = Vector3.one;
				_cowlFlaps.Add(meshRenderer.transform);
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.FlightUnpaused);
		}

		private void OnUpdate(in CraftUpdateFrameData frame)
		{
			if (_partData.HideCowl || _cowlFlaps.Count == 0)
			{
				return;
			}
			float y = _cowlFlaps[0].localEulerAngles.y;
			float num = 0f;
			float throttle = frame.Craft.Controls.Throttle;
			if (throttle > 0f)
			{
				num = throttle * Mathf.Clamp(1f - frame.Craft.AirSpeed / 90f, 0f, 1f) * 35f;
			}
			if (Utilities.CompareFloats(y, num, 0.0001f))
			{
				return;
			}
			Quaternion localRotation = Quaternion.Euler(new Vector3(0f, Mathf.Lerp(y, num, frame.DeltaTime), 0f));
			foreach (Transform cowlFlap in _cowlFlaps)
			{
				cowlFlap.localRotation = localRotation;
			}
		}
	}
}
