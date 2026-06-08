using DG.Tweening;
using Dorfromantik;
using Dorfromantik.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TileLimiter : MonoBehaviour
{
	[SerializeField]
	[FormerlySerializedAs("tileCapacity")]
	private int tileLimit = 75;

	[SerializeField]
	private TileStack tileStack;

	[SerializeField]
	private HideableUi progressBarObject;

	[SerializeField]
	private Image progressBarFill;

	[SerializeField]
	private TextMeshProUGUI progressBarLabel;

	[SerializeField]
	private RewardSystem rewardSystem;

	[SerializeField]
	private TilePlacementEventBroadcaster tilePlacementEventBroadcaster;

	[SerializeField]
	private LoadingProgressRouter loadingProgressRouter;

	[SerializeField]
	private Transform demoOverSign;

	[SerializeField]
	private float initialDemoOverDelay = 1f;

	[SerializeField]
	private float demoSignScaleDuration = 2f;

	[SerializeField]
	private AnimationCurve demoSignScaleCurve;

	private Vector3 initialSignScale;

	private void Awake()
	{
		initialSignScale = demoOverSign.localScale;
	}

	public void Setup(int tileLimit)
	{
		if (tileLimit <= 0)
		{
			tilePlacementEventBroadcaster.OnTilePlaced_Finalized -= OnTilePlaced;
			rewardSystem.OnReset -= OnResetRewardSystem;
			rewardSystem.OnUndoGameOver -= UndoGameOver;
			progressBarObject.Show(shouldShow: false, shouldAnimate: false);
			demoOverSign.gameObject.SetActive(value: false);
			progressBarObject.Lock(shouldLock: true);
		}
		else
		{
			this.tileLimit = tileLimit;
			progressBarObject.Show(shouldShow: true, shouldAnimate: false);
			demoOverSign.gameObject.SetActive(value: false);
			tilePlacementEventBroadcaster.OnTilePlaced_Finalized -= OnTilePlaced;
			rewardSystem.OnReset -= OnResetRewardSystem;
			rewardSystem.OnUndoGameOver -= UndoGameOver;
			tilePlacementEventBroadcaster.OnTilePlaced_Finalized += OnTilePlaced;
			rewardSystem.OnReset += OnResetRewardSystem;
			rewardSystem.OnUndoGameOver += UndoGameOver;
			OnTilePlaced(null, isPlacedByPlayer: true);
		}
	}

	private void OnResetRewardSystem()
	{
		OnTilePlaced(null, isPlacedByPlayer: true);
	}

	private void OnTilePlaced(Tile placedTile, bool isPlacedByPlayer)
	{
		if (isPlacedByPlayer)
		{
			DOTweenModuleUI.DOFillAmount(progressBarFill, (float)rewardSystem.PlacedTileCount / (float)tileLimit, 0.2f);
			progressBarLabel.text = $"{rewardSystem.PlacedTileCount} / {tileLimit}";
			if (rewardSystem.PlacedTileCount >= tileLimit)
			{
				FinishDemo();
			}
		}
	}

	private void FinishDemo()
	{
		tilePlacementEventBroadcaster.OnTilePlaced_Finalized -= OnTilePlaced;
		tileStack.TileLimitReached();
		rewardSystem.GameOver(animate: true, setHighscore: true);
		ShowLimitReachedSign();
	}

	private void ShowLimitReachedSign()
	{
	}

	private void AnimateSign()
	{
		Physics.Raycast(new Ray(tileStack.transform.position + Vector3.up * 3f, Vector3.down), out var hitInfo, 3f, 1 << LayerMask.NameToLayer("TileStack"));
		demoOverSign.gameObject.SetActive(value: true);
		if ((bool)hitInfo.collider)
		{
			demoOverSign.transform.position = hitInfo.point;
		}
		else
		{
			demoOverSign.transform.position = tileStack.transform.position;
		}
		TweenSettingsExtensions.SetEase(TweenSettingsExtensions.From(ShortcutExtensions.DOScale(demoOverSign, initialSignScale, demoSignScaleDuration), Vector3.zero), demoSignScaleCurve);
	}

	private void UndoGameOver()
	{
		tilePlacementEventBroadcaster.OnTilePlaced_Finalized -= OnTilePlaced;
		tilePlacementEventBroadcaster.OnTilePlaced_Finalized += OnTilePlaced;
		ShortcutExtensions.DOScale(demoOverSign, 0f, demoSignScaleDuration);
		tileStack.UndoTileLimitReached();
	}

	private void OnDestroy()
	{
		tilePlacementEventBroadcaster.OnTilePlaced_Finalized -= OnTilePlaced;
		rewardSystem.OnReset -= OnResetRewardSystem;
		rewardSystem.OnUndoGameOver -= UndoGameOver;
	}
}
