using DG.Tweening;
using Mirror;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreenUI : UIPanelBase
{
	public Button respawnButton;

	public float reveivingTime;

	public Slider respawnSlider;

	public CanvasGroup sliderCanvasGroup;

	private bool isDeath;

	private TSPlayerController player;

	private void Start()
	{
		respawnButton.onClick.AddListener(Spawn);
	}

	public new void ShowPanel()
	{
		respawnButton.gameObject.SetActive(value: false);
		base.gameObject.SetActive(value: true);
		base.ShowPanel();
		respawnButton.interactable = false;
		respawnSlider.gameObject.SetActive(value: true);
		respawnSlider.value = 1f;
		sliderCanvasGroup.alpha = 1f;
		float duration = reveivingTime;
		if (NetworkServer.connections.Count <= 1)
		{
			duration = reveivingTime / 5f;
		}
		respawnSlider.DOValue(0f, duration).OnComplete(delegate
		{
			sliderCanvasGroup.DOFade(0f, 0.5f).OnComplete(delegate
			{
				respawnSlider.gameObject.SetActive(value: false);
			});
			respawnButton.gameObject.SetActive(value: true);
			respawnButton.interactable = true;
			player = TrainGameManager.instance.mainPlayer.GetComponent<TSPlayerController>();
			EnableRespawn();
			player.Death();
		});
	}

	private void Update()
	{
		if (isDeath)
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.Confined;
		}
	}

	public void EnableRespawn()
	{
		isDeath = true;
	}

	public new void HidePanel()
	{
		isDeath = false;
		respawnSlider.DOKill();
		sliderCanvasGroup.DOKill();
		base.HidePanel();
		respawnButton.interactable = false;
		respawnSlider.value = 0f;
		respawnSlider.gameObject.SetActive(value: false);
		sliderCanvasGroup.alpha = 0f;
		base.gameObject.SetActive(value: false);
	}

	public void Spawn()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		player.Spawn();
		HidePanel();
	}
}
