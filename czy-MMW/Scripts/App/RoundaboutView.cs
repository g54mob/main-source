using Client;
using Factory;
using Factory.Pools;
using Motorways;
using Motorways.Views;
using UnityEngine;

public class RoundaboutView : MonoBehaviour, IView, IThemeComponent, IReusable
{
	[Dependency]
	private City _city;

	[Dependency]
	private VisualConstantsData _visualConstants;

	private TileView _tileView;

	[SerializeField]
	private InteractionCircleView _interactionCircleView;

	public TickResult Tick(TimeInterval tickTime, float stepAlpha)
	{
		if (_city.Rules.RoadsBecomePermanentOverTime)
		{
			_interactionCircleView.SetPermanenceProgress(_visualConstants.DryingInteractionCircleFalloff.Evaluate((float)_tileView.Tile.RoundaboutPermanenceProgress));
			if (_tileView.Tile.HasRoundabout(RoadState.Active) && _tileView.Tile.IsRoundaboutPermanent)
			{
				return TickResult.StopTicking;
			}
			return TickResult.ContinueTicking;
		}
		return TickResult.StopTicking;
	}

	public void SetGameobjectActive(bool isActive)
	{
		base.gameObject.SetActive(isActive);
	}

	public void Initialize(TileView tileView)
	{
		_tileView = tileView;
	}

	public void InitializeTheme(IThemeDatabase themeDatabase)
	{
		_interactionCircleView.InitializeTheme(themeDatabase);
	}

	public void ApplyTheme(ITheme theme)
	{
		_interactionCircleView.ApplyTheme(theme);
	}

	public ThemeBlendingResult ApplyBlendedTheme(ITheme oldTheme, ITheme newTheme, float progress)
	{
		return _interactionCircleView.ApplyBlendedTheme(oldTheme, newTheme, progress);
	}

	public void ReleaseTheme(IThemeDatabase themeDatabase)
	{
		_interactionCircleView.ReleaseTheme(themeDatabase);
	}

	public void Reset()
	{
		_tileView = null;
		base.transform.localPosition = Vector3.zero;
		ReconfigurePermanenceVisibility();
	}

	public void ReconfigurePermanenceVisibility()
	{
		_interactionCircleView.SetPermanenceProgress(0f);
	}
}
