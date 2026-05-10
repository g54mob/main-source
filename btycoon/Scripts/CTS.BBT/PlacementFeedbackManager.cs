using System.Collections.Generic;
using CTS;
using CTS.Core;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class PlacementFeedbackManager : MonoSingleton<PlacementFeedbackManager>
{
	private List<PlacementFeedback> _invalidPlacements = new List<PlacementFeedback>();

	[SerializeField]
	private Color _validColor;

	[SerializeField]
	private Color _invalidColor;

	private static readonly int _shaderBaseColor = Shader.PropertyToID("_BaseColor");

	protected override void OnSingletonDestroy()
	{
	}

	protected override void SingletonAwake()
	{
	}

	private void Update()
	{
		ClearList();
	}

	public void ClearList()
	{
		foreach (PlacementFeedback invalidPlacement in _invalidPlacements)
		{
			if (!(invalidPlacement.Renderer == null) && !(invalidPlacement.Renderer.gameObject == null))
			{
				invalidPlacement.Show(show: false);
				invalidPlacement.SetColor(_validColor);
				invalidPlacement.SetRenderersColor(null);
			}
		}
		_invalidPlacements.Clear();
	}

	public void AddToList(PlacementFeedback placement)
	{
		if (placement.Renderer == null || placement.Renderer.gameObject == null)
		{
			return;
		}
		placement.Show(show: true);
		placement.SetColor(_invalidColor);
		placement.SetRenderersColor(_invalidColor);
		_invalidPlacements.Add(placement);
		foreach (PlacementFeedback child in placement.Children)
		{
			_invalidPlacements.Add(child);
		}
	}
}
