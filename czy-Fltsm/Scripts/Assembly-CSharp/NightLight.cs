using System.Collections.Generic;
using UnityEngine;

public class NightLight : SceneBehaviour
{
	internal interface Switch
	{
		void Tween(float progress);

		void SetColor(Color color);
	}

	internal struct LightSwitch : Switch
	{
		private Light _light;

		private float _range;

		private float _intensity;

		public LightSwitch(Light light)
		{
			_light = light;
			_range = light.range;
			_intensity = light.intensity;
		}

		public void Tween(float progress)
		{
			if (progress == 0f)
			{
				_light.enabled = false;
				return;
			}
			_light.enabled = true;
			_light.intensity = Mathf.Lerp(0f, _intensity, progress);
			_light.range = Mathf.Lerp(0f, _range, progress);
		}

		public void SetColor(Color color)
		{
			_light.color = color;
		}
	}

	internal struct FoggyLightSwitch : Switch
	{
		private FoggyLight _foggyLight;

		private float _pointLightIntensity;

		private float _foggyLightIntensity;

		public FoggyLightSwitch(FoggyLight foggyLight)
		{
			_foggyLight = foggyLight;
			_pointLightIntensity = foggyLight.PointLightIntensity;
			_foggyLightIntensity = foggyLight.FoggyLightIntensity;
		}

		public void Tween(float progress)
		{
			if (progress == 0f)
			{
				_foggyLight.enabled = false;
				return;
			}
			_foggyLight.enabled = true;
			_foggyLight.PointLightIntensity = Mathf.Lerp(0f, _pointLightIntensity, progress);
			_foggyLight.FoggyLightIntensity = Mathf.Lerp(0f, _foggyLightIntensity, progress);
		}

		public void SetColor(Color color)
		{
			_foggyLight.PointLightColor = color;
		}
	}

	internal struct BillboardSwitch : Switch
	{
		private LightBillboard _billboard;

		public BillboardSwitch(LightBillboard billboard)
		{
			_billboard = billboard;
		}

		public void Tween(float progress)
		{
			if (progress == 0f)
			{
				_billboard.Renderer.enabled = false;
			}
			else
			{
				_billboard.Renderer.enabled = true;
			}
		}

		public void SetColor(Color color)
		{
			float num = Mathf.Pow(2f, _billboard.Intensity);
			Color value = new Color(color.r * num, color.g * num, color.b * num);
			_billboard.Renderer.material.SetColor("_BaseColor", value);
		}
	}

	private List<Switch> _switches;

	private bool _enabled;

	private float _tweenProgress;

	private float _tweenTimestamp;

	private float _tweenDuration;

	private float _tweenTime;

	protected override void Awake()
	{
		base.Awake();
		ListPool<FoggyLight>.List list = ListPool<FoggyLight>.Get(10);
		ListPool<Light>.List list2 = ListPool<Light>.Get(10);
		ListPool<LightBillboard>.List list3 = ListPool<LightBillboard>.Get(10);
		GetComponentsInChildren(list);
		GetComponentsInChildren(list2);
		GetComponentsInChildren(list3);
		int num = list2.Count;
		while (0 <= --num)
		{
			if (ReturnIsLightAttachedToFoggyLight(list, list2[num]))
			{
				list2.RemoveAt(num);
			}
		}
		_switches = new List<Switch>(list.Count + list2.Count + list3.Count);
		foreach (FoggyLight item in list)
		{
			_switches.Add(new FoggyLightSwitch(item));
		}
		foreach (Light item2 in list2)
		{
			_switches.Add(new LightSwitch(item2));
		}
		foreach (LightBillboard item3 in list3)
		{
			_switches.Add(new BillboardSwitch(item3));
		}
		list.Dispose();
		list2.Dispose();
		list3.Dispose();
	}

	private void Start()
	{
		GameManager.TimeManager.RegisterNightLight(this);
	}

	private void Update()
	{
		if (!(_tweenTime < _tweenDuration))
		{
			return;
		}
		float time = Time.time;
		_tweenTime += time - _tweenTimestamp;
		_tweenTimestamp = time;
		if (_enabled)
		{
			_tweenProgress = Mathf.Min(1f, _tweenTime / _tweenDuration);
		}
		else
		{
			_tweenProgress = Mathf.Max(0f, 1f - _tweenTime / _tweenDuration);
		}
		foreach (Switch @switch in _switches)
		{
			@switch.Tween(_tweenProgress);
		}
	}

	private void OnDestroy()
	{
		GameManager.TimeManager.UnregiserNightLight(this);
	}

	public void SetColor(Color color)
	{
		foreach (Switch @switch in _switches)
		{
			@switch.SetColor(color);
		}
	}

	public void SetEnabled(bool enabled, float duration = 0f)
	{
		_enabled = enabled;
		_tweenTimestamp = Time.time;
		_tweenDuration = duration;
		if (duration <= 0f)
		{
			_tweenProgress = (_enabled ? 1 : 0);
			_tweenTime = _tweenDuration;
			{
				foreach (Switch @switch in _switches)
				{
					@switch.Tween(_tweenProgress);
				}
				return;
			}
		}
		_tweenTime = (_enabled ? (_tweenProgress * duration) : ((1f - _tweenProgress) * duration));
	}

	public bool ReturnIsLightAttachedToFoggyLight(IEnumerable<FoggyLight> foggyLights, Light light)
	{
		foreach (FoggyLight foggyLight in foggyLights)
		{
			if (foggyLight.ReturnIsLightAttached(light))
			{
				return true;
			}
		}
		return false;
	}
}
