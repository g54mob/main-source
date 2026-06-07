using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View : ActiveComponent
{
	[SceneBind("Marker")]
	private Image _marker;

	[SceneBind("MailboxCP")]
	private RectTransform _mailboxCP;

	[SceneBind("RecordingCP")]
	private RectTransform _recordingCP;

	[SceneBind("HistoryCP")]
	private RectTransform _historyCP;

	[SceneBind("ResultsCP")]
	private RectTransform _resultsCP;

	[SceneBind("DaysCP")]
	private RectTransform _daysCP;

	[SceneBind("MoneyCP")]
	private RectTransform _moneyCP;

	private const float MOVE_TIME = 0.5f;

	private float _speed;

	private RectTransform _from;

	private RectTransform _to;

	private Dictionary<ControlPoint, RectTransform> _cps = new Dictionary<ControlPoint, RectTransform>();

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this);
		_cps.Add(ControlPoint.DaysCP, _daysCP);
		_cps.Add(ControlPoint.HistoryCP, _historyCP);
		_cps.Add(ControlPoint.MailboxCP, _mailboxCP);
		_cps.Add(ControlPoint.RecordingCP, _recordingCP);
		_cps.Add(ControlPoint.ResultsCP, _resultsCP);
		_cps.Add(ControlPoint.MoneyCP, _moneyCP);
		StopMarker();
	}

	public void DrawMarker(ControlPoint start, ControlPoint end)
	{
		_from = _cps[start];
		_to = _cps[end];
		_marker.rectTransform.position = _from.position;
		_speed = Vector3.Distance(_from.position, _to.position) / 0.5f;
		_marker.enabled = true;
		_marker.gameObject.SetActive(value: true);
	}

	public void StopMarker()
	{
		_from = null;
		_to = null;
	}

	private void Update()
	{
		if (base.IsEnabled && _from != null && _to != null)
		{
			_marker.rectTransform.position = Vector3.MoveTowards(_marker.rectTransform.position, _to.position, _speed * Time.deltaTime);
			if (Vector3.Distance(_marker.rectTransform.position, _to.position) < 0.1f)
			{
				StopMarker();
			}
		}
	}
}
