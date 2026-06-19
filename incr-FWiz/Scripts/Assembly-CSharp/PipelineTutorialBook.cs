using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;

public class PipelineTutorialBook : TutorialBoxItem
{
	public PipelineTutorialBookOption BookOptionPrefab;

	public Transform BookOptionsParent;

	private List<PipelineTutorialBookOption> _bookOptions;

	private PipelineTutorialBookOption _selectedBook;

	public LocalizeStringEvent TitleText;

	public LocalizeStringEvent TutorialText;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void SetSelected(PipelineTutorialBookOption bookOption)
	{
	}
}
