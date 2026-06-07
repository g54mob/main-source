using UnityEngine;
using UnityEngine.UI;

public class LandmarkActionInvestigateUI : MonoBehaviour
{
	[SerializeField]
	private Text _title;

	[SerializeField]
	private Text _progress;

	[SerializeField]
	private Button _button;

	private LandmarkActionInvestigate _action;

	public void Initialize(LandmarkActionInvestigate action)
	{
		_button.onClick.RemoveAllListeners();
		_action = action;
		_title.text = action.Title;
		if (action.Project == null)
		{
			_progress.text = "0 %";
			_button.onClick.AddListener(OnActivateAction);
		}
	}

	public void Update()
	{
		_progress.text = _action.Progress + " %";
	}

	private void OnActivateAction()
	{
		_action.Activate();
	}
}
