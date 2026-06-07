using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Localization;
using UnityEngine.UI;

public class TooltipVisualizer : MonoSingleton<TooltipVisualizer>
{
	[SerializeField]
	private Canvas canvas;

	[SerializeField]
	private CanvasGroup group;

	[SerializeField]
	private RectTransform tooltipRect;

	[SerializeField]
	private LayoutElement descriptionLayout;

	[SerializeField]
	private LocalizeStringHandler titleHandler;

	[SerializeField]
	private LocalizeStringHandler descriptionHandler;

	[SerializeField]
	private Vector2 defaultPivot;

	[SerializeField]
	private Vector2 offset;

	[SerializeField]
	private float padding = 4f;

	[SerializeField]
	private float maxTooltipWidth = 300f;

	[SerializeField]
	private float debounceTime = 0.2f;

	private RectTransform _canvasRect;

	private CancellationTokenSource _ctsShow;

	private CancellationTokenSource _ctsFollow;

	private bool _titleChanged;

	private bool _descriptionChanged;

	private void Awake()
	{
		Initializer.Context(canvas).GetComponent<RectTransform>(out _canvasRect).Context(tooltipRect.gameObject)
			.SetInactive();
		descriptionLayout.preferredWidth = maxTooltipWidth + padding * 2f;
		descriptionLayout.enabled = true;
		group.alpha = 0f;
		tooltipRect.gameObject.SetActive(value: true);
		tooltipRect.gameObject.SetActive(value: false);
		titleHandler.PropertyChanged += delegate
		{
			_titleChanged = true;
		};
		descriptionHandler.PropertyChanged += delegate
		{
			_descriptionChanged = true;
		};
	}

	public void Show(LocalizedString title, LocalizedString description)
	{
		tooltipRect.gameObject.SetActive(value: true);
		_titleChanged = false;
		titleHandler.SetLocalizedString(title);
		_descriptionChanged = false;
		descriptionHandler.SetLocalizedString(description);
		ShowTooltipAsync(this.GenerateToken(ref _ctsShow)).Forget();
		FollowCursorAsync(this.GenerateToken(ref _ctsFollow)).Forget();
	}

	public void Hide()
	{
		tooltipRect.gameObject.SetActive(value: false);
		group.alpha = 0f;
		this.CancelToken(ref _ctsShow);
		this.CancelToken(ref _ctsFollow);
	}

	private async UniTaskVoid ShowTooltipAsync(CancellationToken token)
	{
		await UniTask.WaitUntil(() => _titleChanged && _descriptionChanged, PlayerLoopTiming.Update, token, cancelImmediately: true);
		if (!token.IsCancellationRequested)
		{
			float x = titleHandler.Text.GetPreferredValues().x;
			float x2 = descriptionHandler.Text.GetPreferredValues().x;
			float num = Mathf.Max(x, x2);
			descriptionLayout.preferredWidth = ((num > maxTooltipWidth) ? maxTooltipWidth : num) + padding * 2f;
			LayoutRebuilder.ForceRebuildLayoutImmediate(tooltipRect);
			await UniTask.WaitForSeconds(debounceTime, ignoreTimeScale: false, PlayerLoopTiming.Update, token, cancelImmediately: true);
			if (!token.IsCancellationRequested)
			{
				group.alpha = 1f;
			}
		}
	}

	private async UniTaskVoid FollowCursorAsync(CancellationToken token)
	{
		while (!token.IsCancellationRequested)
		{
			UpdateTooltipLayout();
			await UniTask.Yield(token);
		}
	}

	private void UpdateTooltipLayout()
	{
		RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasRect, Mouse.current.position.ReadValue(), canvas.worldCamera, out var localPoint);
		Vector2 size = tooltipRect.rect.size;
		bool flag = localPoint.x + offset.x + size.x > _canvasRect.rect.xMax;
		bool flag2 = localPoint.y - offset.y - size.y < _canvasRect.rect.yMin;
		tooltipRect.pivot = new Vector2(flag ? 1f : 0f, flag2 ? 0f : 1f);
		float x = (flag ? (0f - offset.x) : offset.x);
		float y = (flag2 ? offset.y : (0f - offset.y));
		tooltipRect.anchoredPosition = localPoint + new Vector2(x, y);
	}
}
