using Assets.Scripts.Actors.Player;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class DesertStorm : MonoBehaviour
{
	public MeshRenderer fogOfWarRenderer;

	private Material fogOfWarMaterial;

	public ParticleSystem[] stormParticles;

	public AudioSource audio;

	private float fadeOverTime = 3f;

	private float fadeTime;

	private bool isStorm;

	private float audioVolume;

	private float oldFogValue;

	private Color oldFogColor;

	private Color stormColor;

	private float stormFogIntensity = 0.03f;

	private void TryInit()
	{
		if (fogOfWarMaterial == null)
		{
			Material material = ((Renderer)fogOfWarRenderer).GetMaterial();
			fogOfWarMaterial = material;
			float volume = audio.volume;
			audioVolume = volume;
		}
	}

	public void FadeIn()
	{
		//IL_00bd: Expected O, but got F4
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected O, but got Unknown
		//IL_0119: Expected O, but got F4
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected O, but got Unknown
		//IL_01e0: Expected O, but got I4
		//IL_01e9: Expected O, but got I4
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Expected O, but got Unknown
		if (fogOfWarMaterial == null)
		{
			Material material = ((Renderer)fogOfWarRenderer).GetMaterial();
			fogOfWarMaterial = material;
			float volume = audio.volume;
			audioVolume = volume;
		}
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		isStorm = true;
		fogOfWarRenderer.enabled = true;
		float fogDensity = RenderSettings.fogDensity;
		oldFogValue = fogDensity;
		Color fogColor = RenderSettings.fogColor;
		oldFogColor = (Color)fogColor.r;
		float num = 0f - fogColor.r;
		fadeTime = 0f;
		float num2 = num * 0.65f;
		float num3 = num2 + fogColor.r;
		object obj2 = default(object);
		object obj = 0 - obj2;
		stormColor = (Color)num3;
		float num4 = (float)obj * 0.65f;
		object obj3 = 0 - obj2;
		float num5 = num4 + (float)obj2;
		float num6 = (float)obj3 * 0.65f;
		float num7 = num6 + (float)obj2;
		float num8 = 1f - (float)obj2;
		float num9 = num8 * 0.65f;
		float num10 = num9 + (float)obj2;
		audio.volume = 0f;
		audio.Play();
		ParticleSystem[] array = stormParticles;
		object obj4 = 0;
		object obj5 = 0;
		ParticleSystem.EmissionModule emissionModule = default(ParticleSystem.EmissionModule);
		while ((nint)obj5 < array.Length)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181565C70");
			emissionModule.enabled = true;
			obj4++;
			obj5 = obj4;
		}
	}

	public void FadeOut()
	{
		//IL_002e: Expected F4, but got I4
		//IL_0037: Expected F4, but got I4
		//IL_0081: Invalid comparison between F4 and I4
		ParticleSystem[] array = stormParticles;
		fadeTime = 0f;
		isStorm = false;
		float num = 0f;
		ParticleSystem.EmissionModule emissionModule = default(ParticleSystem.EmissionModule);
		for (float num2 = 0f; num2 < (float)array.Length; num2 = num)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181565C70");
			emissionModule.enabled = false;
			num++;
		}
	}

	private unsafe void Update()
	{
		//IL_0037: Expected O, but got Ref
		//IL_028e: Invalid comparison between I4 and F4
		//IL_0098: Expected F4, but got I4
		//IL_00b6: Expected O, but got Ref
		//IL_0190: Invalid comparison between I4 and F4
		//IL_01e5: Expected F4, but got I4
		//IL_0108: Invalid comparison between I4 and F4
		//IL_03c4: Invalid comparison between I4 and F4
		//IL_015d: Expected F4, but got I4
		//IL_03e1: Expected O, but got Ref
		//IL_0366: Invalid comparison between I4 and F4
		Transform transform = base.transform;
		Transform transform2 = MyPlayer.Instance.transform;
		Vector3 position = transform2.position;
		object obj = default(object);
		transform.position = (Vector3)(&obj);
		if (!(fadeOverTime > fadeTime))
		{
			return;
		}
		float num = fadeTime + MyTime.deltaTime;
		if (!(0f > num))
		{
			if (num > fadeOverTime)
			{
				num = fadeOverTime;
			}
		}
		else
		{
			num = 0f;
		}
		fadeTime = num;
		float num2 = num / fadeOverTime;
		if (!isStorm)
		{
		}
		object obj2 = default(object);
		fogOfWarMaterial.SetColor("_Color", (Color)(&obj2));
		float num3 = (isStorm ? num2 : (1f - num2));
		float volume = num3 * audioVolume;
		audio.volume = volume;
		if (!isStorm)
		{
			float num4 = ((0f > num2) ? 0f : ((num2 > 1f) ? 1f : num2));
			float num5 = oldFogValue - stormFogIntensity;
			float num6 = num5 * num4;
			float fogDensity = num6 + stormFogIntensity;
			RenderSettings.fogDensity = fogDensity;
			if (!(0f > num2) && !(num2 > 1f))
			{
			}
		}
		else
		{
			float num7 = ((0f > num2) ? 0f : ((num2 > 1f) ? 1f : num2));
			float num8 = stormFogIntensity - oldFogValue;
			float num9 = num8 * num7;
			float fogDensity2 = num9 + oldFogValue;
			RenderSettings.fogDensity = fogDensity2;
			if (!(0f > num2) && !(num2 > 1f))
			{
			}
		}
		RenderSettings.fogColor = (Color)(&obj2);
		if (!(fadeTime < fadeOverTime) && !isStorm)
		{
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: false);
			audio.Stop();
		}
	}
}
