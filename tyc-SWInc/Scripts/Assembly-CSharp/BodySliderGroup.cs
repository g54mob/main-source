using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BodySliderGroup : MonoBehaviour
{
	public Text Label;

	public RectTransform ArrowToggle;

	public RectTransform SliderPanel;

	public Dictionary<string, KeyValuePair<Image, Slider>> Sliders = new Dictionary<string, KeyValuePair<Image, Slider>>();

	public bool AnyActive()
	{
		return Sliders.Any((KeyValuePair<string, KeyValuePair<Image, Slider>> x) => x.Value.Value.gameObject.activeSelf);
	}

	public void Randomize()
	{
		ActorBodyItem actorBodyItem = ActorCustomization.Instance.BodyItems.FirstOrDefault((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head);
		if (!(actorBodyItem != null))
		{
			return;
		}
		foreach (KeyValuePair<string, KeyValuePair<Image, Slider>> slider in Sliders)
		{
			Slider value = slider.Value.Value;
			if (value.gameObject.activeSelf)
			{
				ActorBodyItem.BlendKeys blendKey = actorBodyItem.GetBlendKey(slider.Key);
				if (blendKey != null)
				{
					float randomValue = blendKey.GetRandomValue();
					value.value = randomValue.MapRange(0f, 1f, value.minValue, value.maxValue);
				}
			}
		}
	}

	public void ResetSliders()
	{
		ActorBodyItem actorBodyItem = ActorCustomization.Instance.BodyItems.FirstOrDefault((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head);
		if (!(actorBodyItem != null))
		{
			return;
		}
		foreach (KeyValuePair<string, KeyValuePair<Image, Slider>> slider in Sliders)
		{
			Slider value = slider.Value.Value;
			if (!value.gameObject.activeSelf)
			{
				continue;
			}
			ActorBodyItem.BlendKeys blendKey = actorBodyItem.GetBlendKey(slider.Key);
			if (blendKey != null)
			{
				if (blendKey.Reverse && !blendKey.doubleKey)
				{
					value.value = 100f;
				}
				else
				{
					value.value = 0f;
				}
			}
		}
	}

	public void Activate(string slider)
	{
		KeyValuePair<Image, Slider> keyValuePair = Sliders[slider];
		keyValuePair.Key.gameObject.SetActive(true);
		keyValuePair.Value.gameObject.SetActive(true);
	}

	public void DeactivateAll()
	{
		foreach (KeyValuePair<string, KeyValuePair<Image, Slider>> slider in Sliders)
		{
			slider.Value.Key.gameObject.SetActive(false);
			slider.Value.Value.gameObject.SetActive(false);
		}
	}

	public Slider AddSlider(string name, Sprite icon)
	{
		Image component = SliderPanel.GetChild(0).GetComponent<Image>();
		Slider component2 = SliderPanel.GetChild(1).GetComponent<Slider>();
		component = Object.Instantiate(component);
		component.transform.SetParent(SliderPanel, false);
		component2 = Object.Instantiate(component2);
		component2.transform.SetParent(SliderPanel, false);
		component.sprite = ((icon != null) ? icon : ActorGenerator.Instance.DefaultBlendSprite);
		SliderWithExtra obj = component2 as SliderWithExtra;
		obj.OnEnter.AddListener(delegate
		{
			ActorCustomization.Instance.SliderHover = true;
			ActorBodyItem actorBodyItem = ActorCustomization.Instance.BodyItems.First((ActorBodyItem z) => z.Type == ActorBodyItem.BodyType.Head);
			actorBodyItem.rend.materials[1].SetInt("_TriangleHighlight0", actorBodyItem.Blends.FindIndex((ActorBodyItem.BlendKeys z) => z.BlendName.Equals(name)));
			actorBodyItem.rend.materials[1].SetVector("_EnableIndex", new Vector4(1f, 0f, 0f, 0f));
		});
		obj.OnExit.AddListener(delegate
		{
			ActorCustomization.Instance.SliderHover = false;
			ActorCustomization.Instance.BodyItems.First((ActorBodyItem z) => z.Type == ActorBodyItem.BodyType.Head).rend.materials[1].SetVector("_EnableIndex", new Vector4(0f, 0f, 0f, 0f));
		});
		Sliders[name] = new KeyValuePair<Image, Slider>(component, component2);
		return component2;
	}

	public void Toggle()
	{
		GameObject gameObject = SliderPanel.gameObject;
		gameObject.SetActive(!gameObject.activeSelf);
		ArrowToggle.rotation = Quaternion.Euler(0f, 0f, gameObject.activeSelf ? 90 : 180);
	}
}
