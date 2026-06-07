using System.Collections;
using DV.CabControls;
using DV.HUD;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public class WhistleRopeController : MonoBehaviour
	{
		private const float MUTE_DURATION = 1.5f;

		private const float SMOOTHDAMP_TIME = 0.1f;

		public GameObject dummyLeverGO;

		private ObiRopeTension ropeTension;

		private float smoothedValue;

		private float smoothedValueVelocity;

		private ControlImplBase whistleDummyLever;

		private InteriorControlsManager icm;

		private bool initialized;

		private bool isVR;

		private IEnumerator Start()
		{
			isVR = VRManager.IsVREnabled();
			whistleDummyLever = dummyLeverGO?.GetComponent<ControlImplBase>();
			if (whistleDummyLever == null)
			{
				Debug.LogError("Can't extract whistleDummyLever. Destroying self");
				Object.Destroy(this);
				yield break;
			}
			whistleDummyLever.InteractionAllowed = false;
			Collider[] componentsInChildren = whistleDummyLever.GetComponentsInChildren<Collider>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].GetComponent<Collider>().enabled = false;
			}
			icm = GetComponentInParent<InteriorControlsManager>();
			if (!icm)
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: couldn't find icm, WhistleRopeController UI input won't work!");
			}
			base.transform.Find(isVR ? "[vr]" : "[nonvr]").gameObject.SetActive(value: true);
			ropeTension = GetComponentInChildren<ObiRopeTension>();
			yield return null;
			yield return null;
			yield return WaitFor.Seconds(1.5f);
			initialized = true;
		}

		private void OnDisable()
		{
			whistleDummyLever.SetValue(0f);
			smoothedValueVelocity = (smoothedValue = 0f);
		}

		private void Update()
		{
			if (!initialized || !TimeUtil.IsFlowing)
			{
				return;
			}
			if (!isVR && icm != null && icm.IsControlScrolledRecently(InteriorControlsManager.ControlType.Horn))
			{
				smoothedValue = 1f;
				smoothedValueVelocity = 0f;
				return;
			}
			float value = ropeTension.value;
			smoothedValue = Mathf.SmoothDamp(smoothedValue, ropeTension.value, ref smoothedValueVelocity, 0.1f);
			if (value > 0f)
			{
				whistleDummyLever.SetValue(smoothedValue);
			}
			else if (whistleDummyLever.Value > 0f)
			{
				if (smoothedValue < 0.01f)
				{
					smoothedValue = (smoothedValueVelocity = 0f);
				}
				whistleDummyLever.SetValue(smoothedValue);
			}
		}
	}
}
