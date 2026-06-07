using System.Collections;
using System.Collections.Generic;
using Client;
using Factory;
using Factory.Pools;
using Motorways.Themes;
using UnityEngine;

namespace Motorways.UI
{
	public class ColourWidget : MonoBehaviour, IView, ICreatedInScopeHandler, IReusable
	{
		public Animator ColourButtonAnimator;

		public Animator RadialColourWidgetAnimator;

		public ColourWidgetSwatch SetColourButtonSwatch;

		public ColourWidgetSwatch[] ColourSwatches;

		public int InactiveTimerInSeconds = 5;

		public FloatingElement FloatingElement;

		public RectTransform RectTransform;

		public RectTransform HitboxRect;

		[Dependency]
		private IScope _scope;

		private const int ColourButtonIndex = 2;

		private int _colourMovementCounter;

		private int _colourGroupCount;

		private List<ColorGroup> _themeColors;

		private bool _clickedSinceLastWait;

		private Coroutine _waitForActivity;

		private int _currentColour;

		private bool _swatchEclipseActive
		{
			get
			{
				return ColourButtonAnimator.GetBool("SwatchEclipse_Active");
			}
			set
			{
				ColourButtonAnimator.SetBool("SwatchEclipse_Active", value);
			}
		}

		private bool _radialWidgetActive
		{
			get
			{
				return RadialColourWidgetAnimator.GetBool("SetActive");
			}
			set
			{
				RadialColourWidgetAnimator.SetBool("SetActive", value);
			}
		}

		public int CurrentColour => _colourMovementCounter % GetColourGroupCount();

		private void ChangeColour()
		{
			RadialColourWidgetAnimator.SetTrigger("ChangeColour");
		}

		public void AfterColourChanged()
		{
			_colourMovementCounter++;
			RefreshColours();
		}

		public void ColourButton()
		{
			Debug.Log("ColourButton pressed from ColourWidget.");
			if (_waitForActivity != null)
			{
				StopCoroutine(_waitForActivity);
			}
			_waitForActivity = StartCoroutine(WaitForInactivity());
			if (!_radialWidgetActive)
			{
				SetRadialColourWidgetVisible(visible: true);
			}
			else
			{
				ChangeColour();
			}
		}

		public void SetRadialColourWidgetVisible(bool visible)
		{
			_swatchEclipseActive = visible;
			_radialWidgetActive = visible;
		}

		private IEnumerator WaitForInactivity()
		{
			yield return new WaitForSeconds(InactiveTimerInSeconds);
			SetRadialColourWidgetVisible(visible: false);
		}

		private int GetColourGroupCount()
		{
			return _scope.Get<City>().Definition.schedulePlanner.demandOscillationData.Count;
		}

		public TickResult Tick(TimeInterval tickTime, float stepAlpha)
		{
			return TickResult.ContinueTicking;
		}

		public void SetGameobjectActive(bool active)
		{
			base.gameObject.SetActive(active);
		}

		public void OnCreatedInScope(IScope scope)
		{
			_scope = scope;
		}

		private Color GetColorForIndex(int index)
		{
			return _themeColors[(index + _colourMovementCounter) % _colourGroupCount].GetColor(ThemeComponentGroupTarget.BuildingBase);
		}

		public void RefreshColours(bool resetCounter = false)
		{
			if (resetCounter)
			{
				_colourMovementCounter = 0;
			}
			_colourGroupCount = GetColourGroupCount();
			Theme theme = _scope.Get<IThemeDatabase>().GetTheme() as Theme;
			if (theme != null && theme.buildingColorGroups != null)
			{
				_themeColors = theme.buildingColorGroups.GetRange(0, _colourGroupCount);
			}
			Diagnostics.Verify(ColourSwatches.Length == 6, "There must be 6 colour swatches in the ColourWidget!");
			for (int i = 0; i < ColourSwatches.Length; i++)
			{
				ColourWidgetSwatch colourWidgetSwatch = ColourSwatches[i];
				colourWidgetSwatch.SwatchColor = GetColorForIndex(_colourGroupCount - 2 + (colourWidgetSwatch.SwatchSlot - 1));
			}
			SetColourButtonSwatch.SwatchColor = ColourSwatches[2].SwatchColor;
		}

		public void Reset()
		{
			_colourMovementCounter = 0;
			_themeColors = null;
			_colourGroupCount = 0;
			_clickedSinceLastWait = false;
		}
	}
}
