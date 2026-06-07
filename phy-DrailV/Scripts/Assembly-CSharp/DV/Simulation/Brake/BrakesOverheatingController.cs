using System.Collections;
using UnityEngine;

namespace DV.Simulation.Brake
{
	public class BrakesOverheatingController : MonoBehaviour
	{
		private const float GLOW_UPDATE_PERIOD = 0.16f;

		private static readonly int emissionColorHash = Shader.PropertyToID("_EmissionColor");

		public Renderer[] brakeRenderers;

		public BrakesOverheatingColorGradient overheatColor;

		private BrakeSystem bs;

		private MaterialPropertyBlock overheatColorPropertyBlock;

		private Coroutine overheatUpdateCoro;

		private void Awake()
		{
			if (brakeRenderers == null || brakeRenderers.Length == 0)
			{
				Debug.LogError("Unexpected state: brakeRenderers not set. Destroying self.", base.gameObject);
				Object.Destroy(this);
			}
			else if (overheatColor == null)
			{
				Debug.LogError("Unexpected state: overheatColor not set. Destroying self.", base.gameObject);
				Object.Destroy(this);
			}
			else
			{
				overheatColorPropertyBlock = new MaterialPropertyBlock();
			}
		}

		private void Start()
		{
			bs = TrainCar.Resolve(base.gameObject)?.brakeSystem;
			if (bs == null)
			{
				Debug.LogError("Unexpected state: Couldn't extract BrakeSystem. Destroying self", base.gameObject);
				Object.Destroy(this);
			}
			else
			{
				bs.heatController.OverheatingActiveStateChanged += OnOverheatingStateChanged;
			}
		}

		private void OnDestroy()
		{
			if (bs != null)
			{
				bs.heatController.OverheatingActiveStateChanged -= OnOverheatingStateChanged;
			}
			if (overheatUpdateCoro != null)
			{
				StopCoroutine(overheatUpdateCoro);
			}
		}

		private void OnOverheatingStateChanged(bool overheatActive)
		{
			if (overheatUpdateCoro != null && !overheatActive)
			{
				StopCoroutine(overheatUpdateCoro);
				overheatUpdateCoro = null;
				SetOverheatPropertyBlockToAllRenderers(null);
			}
			else if (overheatUpdateCoro == null && overheatActive)
			{
				overheatUpdateCoro = StartCoroutine(OverheatUpdate());
			}
		}

		private IEnumerator OverheatUpdate()
		{
			while (true)
			{
				overheatColorPropertyBlock.SetColor(emissionColorHash, overheatColor.colorGradient.Evaluate(bs.heatController.overheatPercentage));
				SetOverheatPropertyBlockToAllRenderers(overheatColorPropertyBlock);
				yield return WaitFor.Seconds(0.16f);
			}
		}

		private void SetOverheatPropertyBlockToAllRenderers(MaterialPropertyBlock mpb)
		{
			Renderer[] array = brakeRenderers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetPropertyBlock(mpb);
			}
		}
	}
}
