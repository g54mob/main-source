using System;
using UnityEngine;
using UnityEngine.UI;

public class ViewControlTutorial : MonoBehaviour
{
	public Image[] CompletionImages;

	public GUIProgressBar[] CompletionProg;

	public float[] CompletionNeeded = new float[4] { 2f, 20f, 0.05f, 2f };

	public Sprite CompletSprite;

	public Color CompletionColor;

	private bool[] _completion = new bool[4];

	private bool _active;

	private Vector2 _camPos;

	private Quaternion _camRot;

	private float _camZoom;

	private int _floor;

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		if (_active)
		{
			CheckCompletion(ref _camPos, CameraScript.Instance.transform.position.FlattenVector3(), (Vector2 x, Vector2 y) => (x - y).magnitude, 0);
			CheckCompletion(ref _camRot, CameraScript.Instance.transform.rotation, Quaternion.Angle, 1);
			CheckCompletion(ref _camZoom, CameraScript.Instance.GetZoomLevel(), (float x, float y) => Mathf.Abs(x - y), 2);
			CheckCompletion(ref _floor, GameSettings.Instance.ActiveFloor, (int x, int y) => Mathf.Abs(x - y), 3);
			if (_completion[0] && _completion[1] && _completion[2] && _completion[3])
			{
				base.gameObject.SetActive(false);
			}
		}
		else if (SelectorController.Instance != null && SelectorController.Instance.DoneLoading)
		{
			_active = true;
			_camPos = CameraScript.Instance.transform.position.FlattenVector3();
			_camRot = CameraScript.Instance.transform.rotation;
			_camZoom = CameraScript.Instance.GetZoomLevel();
			_floor = GameSettings.Instance.ActiveFloor;
		}
	}

	public void CheckCompletion<T>(ref T oldValue, T newValue, Func<T, T, float> getValue, int id)
	{
		if (!_completion[id])
		{
			CompletionProg[id].Value = Mathf.Min(1f, CompletionProg[id].Value + getValue(oldValue, newValue) / CompletionNeeded[id]);
			oldValue = newValue;
			if (CompletionProg[id].Value >= 1f)
			{
				CompletionImages[id].sprite = CompletSprite;
				_completion[id] = true;
			}
		}
	}
}
