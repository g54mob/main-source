using Assets.Source.World;
using Assets.Source.World.Frames;
using TMPro;
using UnityEngine;

public class T3CapacitorWidgetPanel : MonoBehaviour
{
	[SerializeField]
	private FrameButton[] _onButtons;

	[SerializeField]
	private FrameButton[] _offButtons;

	[SerializeField]
	private SpriteRenderer _fillInput;

	[SerializeField]
	private SpriteRenderer _fillOutput;

	[SerializeField]
	private TMP_Text _targetText;

	private ActiveWorldFrame _parentFrame;

	private float _smoothInputVoltage;

	private float _smoothOutputVoltage;

	private void Start()
	{
		_parentFrame = GetComponentInParent<ActiveWorldFrame>();
	}

	private void Update()
	{
		if (!_parentFrame || _parentFrame.ActiveFrame == null)
		{
			return;
		}
		T3CapacitorWidget t3CapacitorWidget = _parentFrame.ActiveFrame as T3CapacitorWidget;
		_targetText.text = t3CapacitorWidget.InputVoltage + "V";
		float num = (float)t3CapacitorWidget.InputVoltage - _smoothInputVoltage;
		float num2 = (float)t3CapacitorWidget.OutputVoltage - _smoothOutputVoltage;
		if (Mathf.Abs(num) < 0.005f && Mathf.Abs(num2) < 0.005f)
		{
			if (t3CapacitorWidget.InputVoltage > 0 && t3CapacitorWidget.InputVoltage == t3CapacitorWidget.OutputVoltage)
			{
				UISounds.Button();
				t3CapacitorWidget.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
			}
		}
		else
		{
			float num3 = Time.deltaTime * 16f;
			if (t3CapacitorWidget.InputVoltage == 0 && t3CapacitorWidget.OutputVoltage == 0)
			{
				num3 /= 3f;
			}
			float num4 = ((!(Mathf.Abs(num) < num3)) ? (num3 * (float)((!(num < 0f)) ? 1 : (-1))) : num);
			float num5 = ((!(Mathf.Abs(num2) < num3)) ? (num3 * (float)((!(num2 < 0f)) ? 1 : (-1))) : num2);
			_smoothInputVoltage += num4;
			_smoothOutputVoltage += num5;
			_fillInput.size = new Vector2(1f, _smoothInputVoltage / 15f * 5.5f);
			_fillOutput.size = new Vector3(1f, _smoothOutputVoltage / 15f * 5.5f);
		}
		for (int i = 0; i < _onButtons.Length; i++)
		{
			bool flag = (t3CapacitorWidget.OutputVoltage & (1 << i)) > 0;
			_onButtons[i].gameObject.SetActive(flag);
			_offButtons[i].gameObject.SetActive(!flag);
		}
	}
}
