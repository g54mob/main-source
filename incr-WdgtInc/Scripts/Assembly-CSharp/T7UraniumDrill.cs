using Assets.Source.World;
using UnityEngine;

public class T7UraniumDrill : MonoBehaviour
{
	[SerializeField]
	private int _handCraftSlot;

	[SerializeField]
	private FrameHoldButton _button;

	[SerializeField]
	private float _yMin;

	[SerializeField]
	private float _yMax;

	[SerializeField]
	private Transform _drill;

	[SerializeField]
	private FrameGizmoShaker _shaker;

	private float _drillTime;

	private float _charge;

	private void Update()
	{
		Transform transform = _drill.transform;
		transform.localPosition = new Vector3(transform.localPosition.x, Mathf.SmoothStep(_yMax, _yMin, _charge), transform.localPosition.z);
		if (_button.IsDown)
		{
			_charge = Mathf.Clamp01(_charge + Time.deltaTime / 2f);
			if (_charge == 1f)
			{
				_drillTime = 3f;
				_shaker.ForceActive = true;
				_button.SetActive(active: false);
				UISounds.CraftStep();
				GetComponentInParent<ActiveWorldFrame>().ActiveFrame.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, _handCraftSlot));
			}
		}
		else if (_drillTime <= 0f)
		{
			_charge = Mathf.Clamp01(_charge - Time.deltaTime / 2f);
			if (_charge == 0f)
			{
				_button.SetActive(active: true);
			}
		}
		if (_drillTime > 0f)
		{
			_drillTime -= Time.deltaTime;
			if (_drillTime <= 0f)
			{
				_shaker.ForceActive = false;
			}
		}
	}
}
