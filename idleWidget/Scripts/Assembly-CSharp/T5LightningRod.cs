using Assets.Source.World;
using UnityEngine;

public class T5LightningRod : MonoBehaviour
{
	public const float LineYOffset = 8f;

	[SerializeField]
	private LineRenderer _line;

	[SerializeField]
	private FrameHoldButton _button;

	[SerializeField]
	private float _yMin;

	[SerializeField]
	private float _yMax;

	private float _lightningUpdateTimer;

	private float _lightningTime;

	private float _charge;

	private void Update()
	{
		base.transform.position = new Vector3(base.transform.position.x, Mathf.SmoothStep(_yMin, _yMax, _charge), base.transform.position.z);
		if (_button.IsDown)
		{
			_charge = Mathf.Clamp01(_charge + Time.deltaTime / 2f);
			if (_charge == 1f)
			{
				_lightningTime = 3f;
				_line.gameObject.SetActive(value: true);
				_button.SetActive(active: false);
				UISounds.CraftStep();
				GetComponentInParent<ActiveWorldFrame>().ActiveFrame.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
			}
		}
		else if (_lightningTime <= 0f)
		{
			_charge = Mathf.Clamp01(_charge - Time.deltaTime / 2f);
			if (_charge == 0f)
			{
				_button.SetActive(active: true);
			}
		}
		if (!(_lightningTime > 0f))
		{
			return;
		}
		_lightningTime -= Time.deltaTime;
		if (_lightningTime <= 0f)
		{
			_line.gameObject.SetActive(value: false);
			return;
		}
		_lightningUpdateTimer -= Time.deltaTime;
		if (_lightningUpdateTimer <= 0f)
		{
			_line.SetPosition(1, new Vector3(SeededRandom.Global.RandomRange(-2f, 2f), SeededRandom.Global.RandomRange(0.5f, 2.5f), 0f));
			_line.SetPosition(2, new Vector3(SeededRandom.Global.RandomRange(-4f, 4f), SeededRandom.Global.RandomRange(1.5f, 4.5f), 0f));
			_lightningUpdateTimer = 0.05f;
		}
	}
}
