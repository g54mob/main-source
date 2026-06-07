using System;
using UnityEngine;
using UnityEngine.UI;

public class SpeedLayerControl : ActiveComponent
{
	[SceneBind("MinusTime")]
	public Button minusTimeButton;

	[SceneBind("PlusTime")]
	public Button plusTimeButton;

	public Text speedText;

	private Image minusTimeImage;

	private Image plusTimeImage;

	private float minValue;

	private float maxValue;

	private float step;

	private bool freezed;

	private float prevSpeed;

	private static readonly Color activeColor = new Color(0.3254902f, 69f / 85f, 0.40392157f);

	private static readonly Color inActiveColor = new Color(0.5882353f, 0.5882353f, 0.5882353f);

	private float savedMinValue;

	private float savedMaxValue;

	private float savedStep;

	private float savedSpeed;

	private bool savedFreezed;

	private float savedPrevSpeed;

	private bool somethingSaved;

	private float speed = 1f;

	public float MinValue
	{
		get
		{
			return minValue;
		}
		set
		{
			if (value < 0f || value > 1f)
			{
				throw new ArgumentOutOfRangeException("MinValue must be from 0 to 1");
			}
			minValue = value;
		}
	}

	public float MaxValue
	{
		get
		{
			return maxValue;
		}
		set
		{
			if (value < 1f)
			{
				throw new ArgumentOutOfRangeException("MaxValue must be greater than 1");
			}
			maxValue = value;
		}
	}

	public float Step
	{
		get
		{
			return step;
		}
		set
		{
			if (value <= 0f)
			{
				throw new ArgumentOutOfRangeException("Step must be positive");
			}
			step = value;
		}
	}

	public float Speed
	{
		get
		{
			return speed;
		}
		set
		{
			speed = Math.Max(MinValue, value);
			speed = Math.Min(MaxValue, speed);
			minusTimeButton.interactable = !(speed <= MinValue);
			minusTimeImage.color = ((speed <= MinValue) ? inActiveColor : activeColor);
			plusTimeButton.interactable = !(speed >= MaxValue);
			plusTimeImage.color = ((speed >= MaxValue) ? inActiveColor : activeColor);
			speedText.text = "x" + Math.Round(speed, 1);
			if (!somethingSaved && !freezed && ActiveComponent.Model.P != null)
			{
				ActiveComponent.Model.P.rememberedSpeed = speed;
			}
		}
	}

	public bool Freezed
	{
		get
		{
			return freezed;
		}
		set
		{
			if (freezed ^ value)
			{
				if (value)
				{
					Freeze();
				}
				else
				{
					Unfreeze();
				}
			}
		}
	}

	public void SaveState()
	{
		somethingSaved = true;
		savedMinValue = minValue;
		savedMaxValue = maxValue;
		savedStep = step;
		savedSpeed = Speed;
		savedFreezed = freezed;
		savedPrevSpeed = prevSpeed;
	}

	public void LoadState()
	{
		somethingSaved = false;
		minValue = savedMinValue;
		maxValue = savedMaxValue;
		step = savedStep;
		Speed = savedSpeed;
		freezed = savedFreezed;
		prevSpeed = savedPrevSpeed;
		if (freezed)
		{
			Speed = 0f;
			speed = 0f;
			speedText.text = "x0";
		}
	}

	public void Init(float minValue, float maxValue, float step)
	{
		MinValue = minValue;
		MaxValue = maxValue;
		Step = step;
		base.Init();
		freezed = false;
		somethingSaved = false;
		if (ActiveComponent.Model.P != null)
		{
			Speed = ActiveComponent.Model.P.rememberedSpeed;
		}
		else
		{
			Speed = 1f;
		}
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		base.gameObject.GetComponentsInChildren<Button>();
		speedText = base.gameObject.GetComponentInChildren<Text>();
		if (speedText.gameObject.GetComponent<Button>() != null)
		{
			speedText.gameObject.GetComponent<Button>().onClick.AddListener(Pause);
		}
		minusTimeButton.onClick.AddListener(delegate
		{
			DecreaseSpeed();
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Slower_Button");
		});
		plusTimeButton.onClick.AddListener(delegate
		{
			IncreaseSpeed();
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Faster_Button");
		});
		minusTimeImage = minusTimeButton.GetComponent<Image>();
		plusTimeImage = plusTimeButton.GetComponent<Image>();
	}

	private void Pause()
	{
		if (freezed)
		{
			Unfreeze();
		}
		else
		{
			Freeze();
		}
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Pause");
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Slower_Button");
			DecreaseSpeed();
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Faster_Button");
			IncreaseSpeed();
		}
		else if (Input.GetKeyDown(KeyCode.Space))
		{
			Pause();
		}
	}

	protected virtual void DecreaseSpeed()
	{
		Speed -= Step;
	}

	protected virtual void IncreaseSpeed()
	{
		freezed = false;
		Speed += Step;
	}

	private void Freeze()
	{
		freezed = true;
		prevSpeed = Speed;
		Speed = 0f;
		speed = 0f;
		speedText.text = "x0";
	}

	protected void Unfreeze()
	{
		freezed = false;
		Speed = prevSpeed;
	}
}
