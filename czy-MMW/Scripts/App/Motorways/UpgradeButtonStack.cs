using System;
using System.Collections.Generic;
using Client;
using Easing;
using Motorways.Themes;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways
{
	public class UpgradeButtonStack : MonoBehaviour, IThemeComponent
	{
		protected int desiredStackCount;

		protected int hiddenUpgradeCount;

		private List<UpgradeIcon> _stackedIcons = new List<UpgradeIcon>();

		public UpgradeIcon stackPrefab;

		private float _animationTime;

		private const float AnimationDuration = 0.4f;

		private bool _animating;

		private bool _animatingIconAddition;

		private UpgradeIcon _baseStackIcon;

		public float offset = -10f;

		[Tooltip("The image that we will copy to put on the stack.")]
		public Image referenceImage;

		public static int MaxVisibleIcons = 5;

		public bool IsCircle;

		public bool ShowNumberCounter = true;

		protected bool _isUnlimited;

		protected Theme _currentTheme;

		private ButtonAnimationState internalSelectionState;

		[SerializeField]
		private PassiveUpgradeStackIcon _passiveUpgradeStack;

		public int AccountedIconNumber => desiredStackCount + hiddenUpgradeCount + PendingAdditionCount;

		public int PendingAdditionCount { get; set; }

		public virtual bool IsUnlimited
		{
			get
			{
				return _isUnlimited;
			}
			set
			{
				if (_isUnlimited != value)
				{
					_isUnlimited = value;
					SetCount(desiredStackCount);
				}
			}
		}

		private int VisibleStackCount => _stackedIcons.Count;

		public virtual UpgradeIcon GetTopIcon()
		{
			if (_stackedIcons.Count > 0)
			{
				return _stackedIcons[_stackedIcons.Count - 1];
			}
			return _baseStackIcon;
		}

		public virtual void SetCount(int count)
		{
			PendingAdditionCount = 0;
			if (desiredStackCount < count)
			{
				int num = Math.Min(MaxVisibleIcons, count);
				hiddenUpgradeCount = Math.Max(count - MaxVisibleIcons, 0);
				for (int i = 0; i < num - desiredStackCount; i++)
				{
					AddNewIcon().Rect.localScale = Vector3.one;
				}
				desiredStackCount = num;
			}
			else if (desiredStackCount > count)
			{
				int num2 = desiredStackCount - count;
				for (int j = 0; j < num2; j++)
				{
					if (_stackedIcons.Count > 0)
					{
						RemoveIcon();
					}
				}
				desiredStackCount = Math.Min(MaxVisibleIcons, count);
				hiddenUpgradeCount = Math.Max(count - MaxVisibleIcons, 0);
			}
			_animatingIconAddition = true;
			SetStackPositions(1f);
		}

		public virtual void AddToStack(int count = 1, bool fromAnimation = false)
		{
			if (IsUnlimited && AccountedIconNumber >= 1)
			{
				return;
			}
			if (fromAnimation)
			{
				if (PendingAdditionCount >= count)
				{
					PendingAdditionCount -= count;
				}
				else
				{
					PendingAdditionCount = 0;
				}
			}
			if (desiredStackCount >= MaxVisibleIcons)
			{
				hiddenUpgradeCount += count;
			}
			else if (count + desiredStackCount >= MaxVisibleIcons)
			{
				count -= MaxVisibleIcons - desiredStackCount;
				desiredStackCount = MaxVisibleIcons;
				hiddenUpgradeCount = count;
			}
			else
			{
				desiredStackCount += count;
			}
			_baseStackIcon.SetVisible(desiredStackCount <= 1);
		}

		public virtual void RemoveFromStack(int count = 1, bool fromAnimation = false)
		{
			if (IsUnlimited && AccountedIconNumber >= 1)
			{
				return;
			}
			if (hiddenUpgradeCount > 0)
			{
				if (hiddenUpgradeCount <= count)
				{
					count -= hiddenUpgradeCount;
					hiddenUpgradeCount = 0;
				}
				else
				{
					hiddenUpgradeCount -= count;
					count = 0;
				}
			}
			if (count > 0 && Diagnostics.Verify(desiredStackCount - count >= 0, "We tried to remove more icons from a stack than we have! Trying to remove {0} from {1} on {2}", count, desiredStackCount, base.name))
			{
				if (fromAnimation)
				{
					PendingAdditionCount += count;
				}
				desiredStackCount -= count;
			}
		}

		public virtual void DoStateTransition(ButtonAnimationState state, bool instant)
		{
			internalSelectionState = state;
			for (int i = 0; i < _stackedIcons.Count; i++)
			{
				_stackedIcons[i].IsHighlighted = state == ButtonAnimationState.Hover;
			}
		}

		private void Awake()
		{
			desiredStackCount = 0;
			_baseStackIcon = GetComponent<UpgradeIcon>();
		}

		private void Update()
		{
			if (_animating)
			{
				SetStackPositions(Easings.ElasticEaseOut(Mathf.Clamp01(_animationTime)));
				if (_animationTime > 0.5f)
				{
					if (!_animatingIconAddition)
					{
						RemoveIcon();
					}
					_animating = false;
					_animationTime = 0f;
				}
				_animationTime += 2.5f * Time.deltaTime;
			}
			if (desiredStackCount != VisibleStackCount && !_animating)
			{
				if (VisibleStackCount < desiredStackCount)
				{
					AddNewIcon().transform.localScale = Vector3.zero;
					_animating = true;
					_animatingIconAddition = true;
				}
				else
				{
					_animating = true;
					_animatingIconAddition = false;
				}
				_baseStackIcon.SetVisible(desiredStackCount <= 0);
			}
		}

		private void RemoveIcon()
		{
			UpgradeIcon upgradeIcon = _stackedIcons[_stackedIcons.Count - 1];
			_stackedIcons.RemoveAt(_stackedIcons.Count - 1);
			if (_passiveUpgradeStack != null)
			{
				_passiveUpgradeStack.RemoveIcon(upgradeIcon);
			}
			UnityEngine.Object.Destroy(upgradeIcon.gameObject);
		}

		private UpgradeIcon AddNewIcon()
		{
			UpgradeIcon upgradeIcon = UnityEngine.Object.Instantiate(stackPrefab, base.transform);
			upgradeIcon.transform.SetSiblingIndex(1);
			upgradeIcon.iconRenderer.sprite = referenceImage.sprite;
			upgradeIcon.name = "Icon " + _stackedIcons.Count;
			if (IsCircle)
			{
				upgradeIcon.SetToCircle();
			}
			else
			{
				upgradeIcon.SetToDiamond();
			}
			_stackedIcons.Add(upgradeIcon);
			upgradeIcon.Rect.anchoredPosition = Vector3.right * _stackedIcons.Count * offset;
			upgradeIcon.Rect.sizeDelta = GetComponent<RectTransform>().sizeDelta;
			upgradeIcon.ApplyTheme(_currentTheme);
			upgradeIcon.SetOutlineIndex(_stackedIcons.Count - 1);
			if (_passiveUpgradeStack != null)
			{
				_passiveUpgradeStack.AddIcon(upgradeIcon);
			}
			return upgradeIcon;
		}

		private void SetStackPositions(float lerpTime)
		{
			if (_stackedIcons.Count != 0)
			{
				for (int i = 0; i < _stackedIcons.Count - 1; i++)
				{
					int num = (_animatingIconAddition ? (_stackedIcons.Count - 2 - i) : (_stackedIcons.Count - 1 - i));
					int num2 = (_animatingIconAddition ? (_stackedIcons.Count - 1 - i) : (_stackedIcons.Count - 2 - i));
					float a = (float)num * offset;
					float b = (float)num2 * offset;
					Vector3 zero = Vector3.zero;
					zero.x = Mathf.Lerp(a, b, lerpTime);
					_stackedIcons[i].Rect.anchoredPosition = zero;
					_stackedIcons[i].SetOutlineIndex(i);
				}
				Vector3 a2 = (_animatingIconAddition ? Vector3.zero : Vector3.one);
				Vector3 b2 = (_animatingIconAddition ? Vector3.one : Vector3.zero);
				_stackedIcons[_stackedIcons.Count - 1].Rect.localScale = Vector3.Lerp(a2, b2, lerpTime);
				_stackedIcons[_stackedIcons.Count - 1].Rect.anchoredPosition = Vector3.zero;
			}
		}

		public void InitializeTheme(IThemeDatabase themeDatabase)
		{
		}

		public void ApplyTheme(ITheme theme)
		{
			_currentTheme = theme as Theme;
			for (int i = 0; i < _stackedIcons.Count; i++)
			{
				_stackedIcons[i].ApplyTheme(theme);
				_stackedIcons[i].SetOutlineIndex(i);
			}
		}

		public ThemeBlendingResult ApplyBlendedTheme(ITheme oldTheme, ITheme newTheme, float progress)
		{
			ThemeBlendingResult result = ThemeBlendingResult.StopBlending;
			_currentTheme = newTheme as Theme;
			for (int i = 0; i < _stackedIcons.Count; i++)
			{
				if (_stackedIcons[i].ApplyBlendedTheme(oldTheme, newTheme, progress) == ThemeBlendingResult.ContinueBlending)
				{
					result = ThemeBlendingResult.ContinueBlending;
				}
				_stackedIcons[i].SetOutlineIndex(i);
			}
			return result;
		}

		public void ReleaseTheme(IThemeDatabase themeDatabase)
		{
		}
	}
}
