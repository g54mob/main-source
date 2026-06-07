using System.Text;
using TMPro;
using UnityEngine;

public class ScreenSpeedometer : BaseComponentView
{
	private class ScreenSpeedometerDebug : MonoBehaviour
	{
		private float timeCounter;

		private float maxVelocity;

		private bool isTimeOver;

		private StringBuilder stringBuilder;

		private Rigidbody rb;

		private void Awake()
		{
			rb = GetComponent<Rigidbody>();
			stringBuilder = new StringBuilder();
			timeCounter = 0f;
			maxVelocity = 0f;
			isTimeOver = false;
		}

		private void Update()
		{
			float magnitude = rb.velocity.magnitude;
			if (magnitude >= 0.01f && !isTimeOver)
			{
				timeCounter += Time.deltaTime;
				if (magnitude > maxVelocity)
				{
					maxVelocity = magnitude;
					stringBuilder.AppendLine($"{timeCounter}\t{magnitude}");
				}
				if (timeCounter >= 12f)
				{
					isTimeOver = true;
				}
			}
			else if (isTimeOver)
			{
				if (stringBuilder.Length > 0)
				{
					Debug.Log(stringBuilder);
					stringBuilder.Clear();
				}
			}
			else
			{
				timeCounter = 0f;
				maxVelocity = 0f;
				isTimeOver = false;
			}
		}
	}

	private TextMeshProUGUI speedText;

	private float timeCounter;

	public float CurrentVelocity { get; private set; }

	protected void Update()
	{
		timeCounter += Time.deltaTime;
		if (timeCounter >= 0.1f)
		{
			CurrentVelocity = base.BlockBodyView.BlockRigidbody.velocity.magnitude;
			SetScreenVelocityText(CurrentVelocity);
			timeCounter = 0f;
		}
	}

	public override void SetUpToAction()
	{
		base.SetUpToAction();
		timeCounter = 0f;
	}

	public override void SetBlockDestroyed()
	{
		base.SetBlockDestroyed();
		speedText.SetText("---");
	}

	public void SetScreenVelocityText(float velocity)
	{
		string sourceText = ((velocity < 1000f) ? $"{velocity:0.0}" : "err");
		speedText.SetText(sourceText);
	}

	protected override void InternalInitialize(Properties properties)
	{
		base.InternalInitialize(properties);
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("ScreenSpeedometerCanvas"));
		gameObject.transform.SetParent(base.transform, worldPositionStays: false);
		gameObject.name = "ScreenSpeedometerCanvas";
		speedText = gameObject.transform.FindComponent<TextMeshProUGUI>("SpeedText", isRecursively: true);
		speedText.SetText("0.0");
		base.gameObject.AddComponent<ScreenSpeedometerReplay>();
	}

	protected override void InternalResetComponent()
	{
		base.InternalResetComponent();
		speedText.SetText("0.0");
	}

	public override string GetComponentName()
	{
		return typeof(ScreenSpeedometer).Name;
	}
}
