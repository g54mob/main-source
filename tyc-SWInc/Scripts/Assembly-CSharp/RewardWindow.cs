using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RewardWindow : MonoBehaviour
{
	public GUIWindow Window;

	public Image ContentPanel;

	public Color EndColor;

	public RectTransform FurnPrefab;

	public Transform GiftTransform;

	public Image Gift;

	public Image Star;

	public Image Prog;

	public Image GiftLid;

	public Sprite GiftClosed;

	public Sprite GiftOpen;

	public ParticleSystem Particle;

	public Gradient StarColor;

	public AudioSource SFXPlayer;

	public AudioClip Roll;

	public AudioClip Pop;

	public float StarRotSpeed;

	public float StarColorSpeed;

	public float ProgIncSpeed;

	public float ProgDecSpeed;

	public float ShakeAmount;

	private float rot;

	private float col;

	private bool _isPressed;

	private bool _claimed;

	private string _reward;

	private Color _windowStartColor;

	private List<GameObject> _furns = new List<GameObject>();

	private void Awake()
	{
		_windowStartColor = ContentPanel.color;
	}

	public void Show(string reward)
	{
		Reset();
		Window.Show();
		SFXPlayer.Play();
		_reward = reward;
		GameSettings.ForcePause = true;
	}

	private void Update()
	{
		rot += Time.deltaTime * StarRotSpeed;
		col = (col + Time.deltaTime * StarColorSpeed) % 1f;
		Star.rectTransform.rotation = Quaternion.Euler(0f, 0f, rot);
		Star.color = StarColor.Evaluate(col);
		if (_claimed)
		{
			ContentPanel.color = _windowStartColor;
		}
		else
		{
			ContentPanel.color = Color.Lerp(_windowStartColor, EndColor, Prog.fillAmount);
		}
		if (Prog.fillAmount < 1f)
		{
			SFXPlayer.volume = Prog.fillAmount;
			Gift.rectTransform.anchoredPosition = new Vector2(UnityEngine.Random.value - 0.5f, UnityEngine.Random.value - 0.5f) * Prog.fillAmount * ShakeAmount;
			Gift.rectTransform.sizeDelta = Vector2.one * Prog.fillAmount.MapRange(0f, 1f, 100f, 128f);
		}
		else
		{
			Gift.rectTransform.anchoredPosition = Vector2.zero;
			if (!_claimed)
			{
				SFXPlayer.volume = Mathf.Lerp(SFXPlayer.volume, 0f, Time.deltaTime * 10f);
			}
		}
		if (_isPressed)
		{
			Prog.fillAmount = Mathf.Min(1f, Prog.fillAmount + Time.deltaTime * ProgIncSpeed);
			if (Input.GetMouseButtonUp(0))
			{
				GiftRelease();
			}
		}
		else if (Prog.fillAmount < 1f)
		{
			Prog.fillAmount = Mathf.Max(0f, Prog.fillAmount - Time.deltaTime * ProgDecSpeed);
		}
		else if (_claimed && Input.GetMouseButton(0))
		{
			GameSettings.ForcePause = false;
			Window.Close();
		}
	}

	public void GiftPress(BaseEventData ev)
	{
		PointerEventData pointerEventData = ev as PointerEventData;
		if (pointerEventData != null && pointerEventData.button == PointerEventData.InputButton.Left)
		{
			if (Prog.fillAmount == 1f)
			{
				GameSettings.ForcePause = false;
				Window.Close();
			}
			else
			{
				_isPressed = true;
			}
		}
	}

	public void Reset()
	{
		foreach (GameObject furn in _furns)
		{
			UnityEngine.Object.Destroy(furn);
		}
		_furns.Clear();
		ContentPanel.color = _windowStartColor;
		GiftLid.color = new Color(1f, 1f, 1f, 0f);
		GiftLid.rectTransform.anchoredPosition = Vector2.zero;
		Gift.rectTransform.anchoredPosition = Vector2.zero;
		Gift.rectTransform.sizeDelta = new Vector2(100f, 100f);
		Gift.sprite = GiftClosed;
		Star.rectTransform.sizeDelta = Vector2.zero;
		Prog.fillAmount = 0f;
		Prog.gameObject.SetActive(true);
		_isPressed = false;
		SFXPlayer.Stop();
		SFXPlayer.volume = 0f;
		SFXPlayer.clip = Roll;
		SFXPlayer.loop = true;
		_claimed = false;
	}

	private void ReleaseGifts()
	{
		List<Furniture> list = (from x in ObjectDatabase.Instance.GetAllFurniture()
			select x.GetComponent<Furniture>() into x
			where _reward.Equals(x.Unlockable)
			select x).ToList();
		float num = 180f;
		float num2 = 180f;
		if (list.Count == 1)
		{
			num = 90f;
		}
		else if (list.Count == 2)
		{
			num = 135f;
			num2 = 90f;
		}
		for (int num3 = 0; num3 < list.Count; num3++)
		{
			Furniture furniture = list[num3];
			RectTransform rectTransform = UnityEngine.Object.Instantiate(FurnPrefab);
			rectTransform.transform.SetParent(GiftTransform, false);
			rectTransform.anchoredPosition = new Vector2(0f, 0f);
			rectTransform.GetComponentsInChildren<Image>()[1].sprite = furniture.Thumbnail;
			string[] furniture2 = Localization.GetFurniture(furniture.GetLocalizationName(), furniture.GetDefaultName(), furniture.ButtonDescription);
			rectTransform.GetComponentInChildren<Text>().text = furniture2[0];
			float num4 = num - (float)num3 * num2 / (float)Mathf.Max(1, list.Count - 1);
			num4 *= (float)Math.PI / 180f;
			rectTransform.DOAnchorPos(new Vector2(Mathf.Cos(num4), Mathf.Sin(num4)) * 128f, 1f).SetEase(Ease.OutElastic);
			_furns.Add(rectTransform.gameObject);
			HUD.Instance.SetFurnitureNew(furniture, true);
		}
	}

	private void GiftRelease()
	{
		_isPressed = false;
		if (Prog.fillAmount == 1f)
		{
			GameSettings.Instance.ClaimedRewards.Add(_reward);
			Options.UnlockReward(_reward);
			HUD.Instance.RefreshBuildButtons();
			HUD.Instance.UpdateFurnitureButtons();
			ReleaseGifts();
			_claimed = true;
			Particle.Play();
			SFXPlayer.Stop();
			SFXPlayer.loop = false;
			SFXPlayer.clip = Pop;
			SFXPlayer.volume = 1f;
			SFXPlayer.Play();
			Star.rectTransform.DOSizeDelta(new Vector2(256f, 256f), 1f).SetEase(Ease.OutElastic);
			Gift.sprite = GiftOpen;
			GiftLid.color = Color.white;
			GiftLid.DOColor(new Color(1f, 1f, 1f, 0f), 1f);
			GiftLid.rectTransform.DOAnchorPos(new Vector2(0f, 128f), 1f).SetEase(Ease.OutCubic);
			DOTween.Sequence().Append(Gift.rectTransform.DOSizeDelta(new Vector2(256f, 256f), 0.1f)).Append(Gift.rectTransform.DOSizeDelta(new Vector2(100f, 100f), 0.5f))
				.Play();
			Prog.gameObject.SetActive(false);
		}
	}
}
