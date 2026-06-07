using LitMotion;
using LitMotion.Extensions;
using R3;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UpgradeNodeConnection : MonoBehaviour
{
	[SerializeField]
	private float lockedAlpha = 0.3f;

	[SerializeField]
	private float drawDuration = 0.35f;

	[SerializeField]
	private Ease drawEase = Ease.OutCubic;

	private Image _image;

	private Color _unlockedColor;

	private Color _lockedColor;

	private UpgradeNode _prerequisiteUpgrade;

	private ResearchNode _prerequisiteResearch;

	private MotionHandle _drawMotion;

	private bool _hasAppeared;

	public void Setup(UpgradeNodeData prerequisiteUpgrade, ResearchNode prerequisiteResearch)
	{
		_prerequisiteUpgrade = prerequisiteUpgrade;
		_prerequisiteResearch = prerequisiteResearch;
		_image = GetComponent<Image>();
		_unlockedColor = _image.color;
		Color unlockedColor = _unlockedColor;
		float? a = lockedAlpha;
		_lockedColor = unlockedColor.With(null, null, null, a);
		Database.State.Upgrades.ObserveUnlockedOrVisited(prerequisiteUpgrade).Prepend(Unit.Default).Subscribe(delegate
		{
			HandleState();
		})
			.AddTo(this);
		Database.State.Research.Unlocked.ObserveContains(prerequisiteResearch).Subscribe(delegate
		{
			HandleState();
		}).AddTo(this);
	}

	private void OnDestroy()
	{
		if (_drawMotion.IsActive())
		{
			_drawMotion.Cancel();
		}
	}

	private void HandleState()
	{
		bool flag = Database.State.Upgrades.IsVisited(_prerequisiteUpgrade) && Database.State.Research.IsUnlocked(_prerequisiteResearch);
		bool flag2 = !base.gameObject.activeSelf;
		base.gameObject.SetActive(flag);
		_image.color = (Database.State.Upgrades.IsUnlocked(_prerequisiteUpgrade) ? _unlockedColor : _lockedColor);
		if (flag && flag2 && !_hasAppeared)
		{
			_hasAppeared = true;
			PlayDrawAnimation();
		}
	}

	private void PlayDrawAnimation()
	{
		if (_drawMotion.IsActive())
		{
			_drawMotion.Cancel();
		}
		_image.fillAmount = 0f;
		_drawMotion = LMotion.Create(0f, 1f, drawDuration).WithEase(drawEase).WithOnComplete(delegate
		{
			_image.fillAmount = 1f;
		})
			.BindToFillAmount(_image);
	}
}
