using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
	private bool on;

	private float flickerTimeOffset;

	private LightDimmerKnob lightDimmerKnob;

	private float illumAppliedToRendererMaterials;

	private List<Material> localMaterials = new List<Material>();

	private void Start()
	{
		lightDimmerKnob = LightDimmer.AttachKnob(base.gameObject);
		Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>(true);
		foreach (Renderer renderer in componentsInChildren)
		{
			localMaterials.AddRange(renderer.materials);
		}
		flickerTimeOffset = Random.value * 10f;
		illumAppliedToRendererMaterials = -1f;
		if (Game.isExploring)
		{
			LanternPhantom componentInParent = GetComponentInParent<LanternPhantom>();
			if (componentInParent == null)
			{
				Debug.LogError("Lantern has no LanternPhantom parent: " + Util.GetObjectPath(base.gameObject));
			}
			if (componentInParent != null && componentInParent.wantOn)
			{
				on = true;
			}
			else
			{
				on = false;
			}
		}
	}

	private void Update()
	{
		float num = ((!on) ? 0f : GetFlicker(1f));
		lightDimmerKnob.illum = num;
		if (!(Mathf.Abs(num - illumAppliedToRendererMaterials) > 0.01f))
		{
			return;
		}
		illumAppliedToRendererMaterials = num;
		foreach (Material localMaterial in localMaterials)
		{
			localMaterial.color = num * Color.white;
		}
	}

	private float GetFlicker(float steadyT)
	{
		float a = Mathf.Lerp(0f, 0.8f, steadyT);
		float b = Mathf.Lerp(0.5f, 1f, steadyT);
		float num = Clock.play.time + flickerTimeOffset;
		float t = Mathf.Lerp((Mathf.Cos(30f * num) > 0f) ? 1 : 0, Mathf.PerlinNoise(5f * num, 0f), steadyT);
		return Mathf.Lerp(a, b, t);
	}

	public void DebugForceOn()
	{
		on = true;
	}
}
