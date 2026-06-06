using TMPro;
using UnityEngine;

public class TextPopup : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _text;

	[SerializeField]
	private float _disappearTime = 1f;

	[SerializeField]
	private float _moveSpeed = 10f;

	[SerializeField]
	private Vector3 _moveDirection = new Vector3(0f, 1f, 0f);

	private Vector3 _normalizedDirection;

	private float _timer;

	private void Update()
	{
		float pausableUnscaledDeltaTime = GameSpeedManager.PausableUnscaledDeltaTime;
		base.transform.position += _normalizedDirection * _moveSpeed * pausableUnscaledDeltaTime;
		_timer -= pausableUnscaledDeltaTime;
		if (_timer <= 0f)
		{
			TextPopupPool.Instance.Add(this);
		}
	}

	public static TextPopup Spawn(Vector3 position, string text)
	{
		TextPopup textPopup = TextPopupPool.Instance.Get();
		textPopup.Initialize(position, text);
		return textPopup;
	}

	private void Initialize(Vector3 position, string text)
	{
		base.transform.position = position;
		_text.text = text;
		_timer = _disappearTime;
		_normalizedDirection = _moveDirection.normalized;
	}
}
