using System.Linq;
using UnityEngine;

public class LampComponent : MonoBehaviour
{
	[SerializeField]
	private Item paintBrush;

	[SerializeField]
	private Light light;

	[SerializeField]
	private MeshRenderer[] renderer;

	[SerializeField]
	private GameObject[] turnOnObjects;

	[SerializeField]
	private ParticleSystem psDust;

	[SerializeField]
	private Color[] colors;

	[SerializeField]
	private int index;

	[SerializeField]
	private bool startOff;

	[SerializeField]
	private bool decoAttachable;

	[SerializeField]
	private ItemSocket attachablePoint;

	[SerializeField]
	private string soundSwitchOn;

	[SerializeField]
	private string soundSwitchOff;

	[HideInInspector]
	public Color currentColor;

	private bool isOn;

	private bool loadColor;

	private void Start()
	{
		isOn = true;
		if (!loadColor)
		{
			SetColor();
			if (startOff)
			{
				SwitchLight(playSound: false);
			}
		}
	}

	public void OnInteraction(CharacterControllerComponent character)
	{
		if (decoAttachable && character.socket.IsHoldingItem() && (bool)character.socket.GetItemComponent().GetComponent<EntitySmoghComponent>())
		{
			character.socket.GetItemComponent().GetComponent<EntitySmoghComponent>().ActivateAttachment();
			attachablePoint.PushItem(character.socket.GetItemComponent(), default(Vector3), reactivateCollision: true);
		}
		else if (character.socket.IsHoldingItem() && character.socket.GetItemComponent().item.id == paintBrush.id)
		{
			if (!isOn)
			{
				SwitchLight();
			}
			SetColor();
			SoundManager.PlaySoundOnce(character.socket.GetItemComponent().soundOnInteract);
		}
		else
		{
			SwitchLight();
		}
	}

	public void LoadColor(Color color)
	{
		loadColor = true;
		currentColor = color;
		Color.RGBToHSV(currentColor, out var H, out var S, out var V);
		light.color = Color.HSVToRGB(H, S * 0.5f, V);
		renderer.ToList().ForEach(delegate(MeshRenderer r)
		{
			r.materials.ToList().ForEach(delegate(Material m)
			{
				m.SetColor("_EmissionColor", currentColor);
				m.SetFloat("_EmissionAlpha", 1f);
			});
		});
		if (psDust != null)
		{
			ParticleSystem.MainModule main = psDust.main;
			main.startColor = currentColor;
		}
	}

	private void SetColor()
	{
		index++;
		if (index >= colors.Length)
		{
			index = 0;
		}
		currentColor = colors[index];
		Color.RGBToHSV(colors[index], out var H, out var S, out var V);
		light.color = Color.HSVToRGB(H, S * 0.5f, V);
		renderer.ToList().ForEach(delegate(MeshRenderer r)
		{
			r.materials.ToList().ForEach(delegate(Material m)
			{
				m.SetColor("_EmissionColor", colors[index]);
				m.SetFloat("_EmissionAlpha", 1f);
			});
		});
		if (psDust != null)
		{
			ParticleSystem.MainModule main = psDust.main;
			main.startColor = currentColor;
		}
	}

	private void SwitchLight(bool playSound = true)
	{
		isOn = !isOn;
		light.enabled = isOn;
		if (playSound)
		{
			if (isOn)
			{
				SoundManager.PlaySoundOnce(soundSwitchOn);
			}
			else
			{
				SoundManager.PlaySoundOnce(soundSwitchOff);
			}
		}
		renderer.ToList().ForEach(delegate(MeshRenderer r)
		{
			r.sharedMaterials.ToList().ForEach(delegate(Material m)
			{
				m.SetFloat("_EmissionAlpha", isOn ? 1 : 0);
			});
		});
		turnOnObjects.ToList().ForEach(delegate(GameObject o)
		{
			o.SetActive(isOn);
		});
		if (psDust != null)
		{
			if (isOn)
			{
				psDust.Play();
			}
			else
			{
				psDust.Stop();
			}
		}
	}
}
