using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MapNode : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	private Image image;

	private Material material;

	public Level Level { get; private set; }

	public void Initialize(Level level)
	{
		Level = level;
		GetComponent<RectTransform>().anchoredPosition = level.MapPosition;
		image = GetComponent<Image>();
		image.material = Object.Instantiate(image.material);
		material = image.material;
	}

	public void SetSprite(Sprite sprite)
	{
		image.sprite = sprite;
		image.SetNativeSize();
	}

	public void Highlight(bool isActive)
	{
		material.SetFloat("_OutlineThickness", isActive ? 1f : 0f);
		material.SetColor("_OutlineColor", Color.white);
	}

	public void ChangeColor(Color color)
	{
		material.SetColor("_Color", color);
	}

	public void AlphaFade(float a)
	{
		LeanTween.cancel(image.gameObject);
		float num = material.GetFloat("_Alpha");
		LeanTween.value(image.gameObject, SetAlpha, num, a, 0.25f).setIgnoreTimeScale(useUnScaledTime: true).setEase(LeanTweenType.linear)
			.setEaseLinear();
	}

	public void SetAlpha(float a)
	{
		material.SetFloat("_Alpha", a);
	}

	public void OnLevelDiscovered()
	{
		Color color = Level.Difficulty.Color;
		color.a = 1f;
		ChangeColor(color);
		AlphaFade(1f);
		if (Level.LevelType == LevelType.Waves)
		{
			SetSprite(Level.Loot.MapNodeIcon);
		}
		else if (Level.LevelType == LevelType.Hub)
		{
			SetSprite(LevelManager.Instance.Config.HubIcon);
		}
		else if (Level.LevelType == LevelType.Boss)
		{
			SetSprite(LevelManager.Instance.Config.BossIcon);
		}
	}

	public void OnLevelUndiscovered()
	{
		AlphaFade(0.1f);
		SetSprite(LevelManager.Instance.Config.NodeDot);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			LevelManager.Instance.OnNodeClick(this);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		LevelManager.Instance.Map.OnPointerEnterNode(this);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		LevelManager.Instance.Map.OnPointerExitLevel();
	}

	public void DestroySelf()
	{
		Object.Destroy(base.gameObject);
	}
}
