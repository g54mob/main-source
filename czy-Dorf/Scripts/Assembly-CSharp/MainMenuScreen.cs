using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DG.Tweening;
using Dorfromantik;
using Dorfromantik.UI;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScreen : MonoBehaviour
{
	private sealed class _003CShowScreenInNextFrame_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MainMenuScreen _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CShowScreenInNextFrame_003Ed__29(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			MainMenuScreen mainMenuScreen = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				mainMenuScreen.Show(mainMenuScreen.shown, shouldAnimate: false);
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	public MainMenuScreenType screenType;

	public int layer;

	[SerializeField]
	public GameObject defaultSelectableParent;

	[SerializeField]
	public Selectable defaultSelectable;

	[SerializeField]
	private bool shouldAnimatePosition = true;

	[SerializeField]
	private Vector2 hiddenAnchoredPos;

	[SerializeField]
	private bool useWidthAsHiddenPosition;

	[SerializeField]
	private SettingsRouter settingsRouter;

	[SerializeField]
	private float animationDuration = 0.3f;

	private bool _003CVisible_003Ek__BackingField;

	private Vector2 visibleAnchorPos = Vector2.negativeInfinity;

	private RectTransform rectTransform;

	private Dictionary<int, List<MainMenuScreen>> childScreensByLayer;

	private Sequence showSequence;

	private bool shown;

	private bool isVisibleAnchorPosSet;

	private List<Selectable> allChildSelectables;

	private Selectable lastSelectedSelectable;

	public bool Visible
	{
		get
		{
			return _003CVisible_003Ek__BackingField;
		}
		private set
		{
			_003CVisible_003Ek__BackingField = value;
		}
	}

	public event Action<bool> OnShow;

	public void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		if (!isVisibleAnchorPosSet)
		{
			visibleAnchorPos = rectTransform.anchoredPosition;
			isVisibleAnchorPosSet = true;
		}
		childScreensByLayer = new Dictionary<int, List<MainMenuScreen>>();
		MainMenuScreen[] componentsInChildren = GetComponentsInChildren<MainMenuScreen>();
		foreach (MainMenuScreen mainMenuScreen in componentsInChildren)
		{
			if (!childScreensByLayer.ContainsKey(mainMenuScreen.layer))
			{
				childScreensByLayer.Add(mainMenuScreen.layer, new List<MainMenuScreen>());
			}
			childScreensByLayer[mainMenuScreen.layer].Add(mainMenuScreen);
		}
		if (useWidthAsHiddenPosition)
		{
			settingsRouter.OnResolutionChanged += UpdatePositionFromResolution;
		}
		allChildSelectables = Enumerable.ToList(GetComponentsInChildren<Selectable>(includeInactive: true));
	}

	private void Start()
	{
		Singleton<UiSelectionManager>.Instance.OnSelect += ChangeLastSelected;
	}

	public void ChangeLastSelected(Selectable currentSelectable)
	{
		if (currentSelectable == null)
		{
			lastSelectedSelectable = null;
		}
		else if (allChildSelectables.Contains(currentSelectable))
		{
			lastSelectedSelectable = currentSelectable;
		}
	}

	public void SetVisibleAnchorPos(Vector2 value)
	{
		visibleAnchorPos = value;
		isVisibleAnchorPosSet = true;
	}

	private void UpdatePositionFromResolution(Resolution obj)
	{
		StartCoroutine(ShowScreenInNextFrame());
	}

	private IEnumerator ShowScreenInNextFrame()
	{
		return new _003CShowScreenInNextFrame_003Ed__29(0)
		{
			_003C_003E4__this = this
		};
	}

	public void Show(bool shouldShow, bool shouldAnimate = true)
	{
		Sequence sequence = showSequence;
		if (sequence != null)
		{
			TweenExtensions.Pause(sequence);
		}
		showSequence = DOTween.Sequence();
		Vector2 vector = (shouldShow ? visibleAnchorPos : (useWidthAsHiddenPosition ? new Vector2(rectTransform.rect.width, hiddenAnchoredPos.y) : hiddenAnchoredPos));
		if (shouldShow)
		{
			base.gameObject.SetActive(value: true);
			if ((bool)defaultSelectableParent)
			{
				defaultSelectable = defaultSelectableParent.GetComponentInChildren<Selectable>();
			}
			Selectable selectable = (lastSelectedSelectable ? lastSelectedSelectable : defaultSelectable);
			if ((bool)selectable)
			{
				selectable.Select();
				if (selectable is UiSelectable uiSelectable && !selectable.isActiveAndEnabled)
				{
					uiSelectable.OnSelect(null);
				}
			}
		}
		if (!rectTransform)
		{
			rectTransform = GetComponent<RectTransform>();
		}
		if (shouldAnimate && shouldAnimatePosition)
		{
			TweenSettingsExtensions.Append(showSequence, DOTweenModuleUI.DOAnchorPos(rectTransform, vector, animationDuration));
			if (!shouldShow)
			{
				TweenSettingsExtensions.OnComplete(showSequence, delegate
				{
					base.gameObject.SetActive(value: false);
				});
			}
		}
		else
		{
			if (shouldAnimatePosition)
			{
				rectTransform.anchoredPosition = vector;
			}
			base.gameObject.SetActive(shouldShow);
		}
		shown = shouldShow;
		this.OnShow?.Invoke(shown);
	}

	private void OnDisable()
	{
		lastSelectedSelectable = null;
	}

	private void OnDestroy()
	{
		if (useWidthAsHiddenPosition)
		{
			settingsRouter.OnResolutionChanged -= UpdatePositionFromResolution;
		}
		if ((bool)Singleton<UiSelectionManager>.Instance)
		{
			Singleton<UiSelectionManager>.Instance.OnSelect -= ChangeLastSelected;
		}
	}

	public void SelectLastOrDefaultSelectable()
	{
		if ((bool)lastSelectedSelectable)
		{
			lastSelectedSelectable.Select();
		}
		else if ((bool)defaultSelectable)
		{
			defaultSelectable.Select();
		}
	}

	public void UpdateAndSelectDefaultSelectable()
	{
		lastSelectedSelectable = null;
		if ((bool)defaultSelectableParent)
		{
			defaultSelectable = defaultSelectableParent.GetComponentInChildren<Selectable>();
		}
		defaultSelectable.Select();
		if (defaultSelectable is UiSelectable uiSelectable && !defaultSelectable.isActiveAndEnabled)
		{
			uiSelectable.OnSelect(null);
		}
	}

	private void _003CShow_003Eb__30_0()
	{
		base.gameObject.SetActive(value: false);
	}
}
