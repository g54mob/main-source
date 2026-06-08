using System.Collections.Generic;
using Kitchen.Components;
using Shapes;
using Sirenix.Utilities;
using TMPro;
using UnityEngine;

namespace Kitchen.Modules
{
	public class MoneyDisplayRow : LabelElement
	{
		[SerializeField]
		[Header("References")]
		private SoundSource Sound;

		[SerializeField]
		private Line Divider;

		[Header("Configuration")]
		[SerializeField]
		protected TextMeshPro Value;

		[Header("Configuration")]
		public bool Interpolate = true;

		public int CoinsPerSound = 1;

		public float PitchShiftPerSound = 0.001f;

		public AnimationCurve InterpolationCurve;

		[Header("State")]
		private int Target;

		public int Current;

		private int Start;

		private float InterpTime;

		private float TotalInterpTime;

		private bool HasFinished;

		private MoneyDisplayRow WaitingFor;

		private List<MoneyDisplayRow> SumUp;

		private int LastSoundPlayed;

		private List<SoundSource> Sources = new List<SoundSource>();

		public MoneyDisplayRow SetLine(bool active)
		{
			Divider.gameObject.SetActive(active);
			return this;
		}

		public MoneyDisplayRow QueueAfter(MoneyDisplayRow row)
		{
			WaitingFor = row;
			return this;
		}

		public MoneyDisplayRow AddToSum(MoneyDisplayRow row)
		{
			if (SumUp == null)
			{
				SumUp = new List<MoneyDisplayRow>();
			}
			SumUp.Add(row);
			return this;
		}

		public void StartLerp()
		{
			WaitingFor = null;
		}

		public MoneyDisplayRow SetValue(int value)
		{
			Target = value;
			TotalInterpTime = (Interpolate ? Mathf.Log10(value * 10) : 0f);
			InterpTime = TotalInterpTime;
			HasFinished = false;
			return this;
		}

		public void FinishNow()
		{
			if (!SumUp.IsNullOrEmpty())
			{
				foreach (MoneyDisplayRow item in SumUp)
				{
					item.FinishNow();
				}
				return;
			}
			InterpTime = 0f;
		}

		public bool IsFinished()
		{
			if (!SumUp.IsNullOrEmpty())
			{
				foreach (MoneyDisplayRow item in SumUp)
				{
					if (!item.HasFinished)
					{
						return false;
					}
				}
				return true;
			}
			return HasFinished;
		}

		private void Update()
		{
			if (!SumUp.IsNullOrEmpty())
			{
				int num = 0;
				foreach (MoneyDisplayRow item in SumUp)
				{
					num += item.Current;
				}
				Value.text = Mathf.RoundToInt(num).ToString();
			}
			else if (InterpTime > 0f)
			{
				if (!(WaitingFor != null) || WaitingFor.HasFinished)
				{
					InterpTime -= Time.unscaledDeltaTime;
					float num2 = Target - Start;
					if (InterpolationCurve != null)
					{
						float time = (TotalInterpTime - InterpTime) / TotalInterpTime;
						int num3 = Target - Start;
						num2 = InterpolationCurve.Evaluate(time) * (float)num3;
					}
					if (CoinsPerSound > 0 && Current > LastSoundPlayed + CoinsPerSound)
					{
						LastSoundPlayed = Current;
						PlaySound();
					}
					Current = Mathf.RoundToInt((float)Start + num2);
					Value.text = Current.ToString();
				}
			}
			else if (!HasFinished)
			{
				Current = Target;
				HasFinished = true;
				Value.text = Target.ToString();
			}
		}

		private void PlaySound()
		{
			if (Sources.Count == 0)
			{
				for (int i = 0; i < 5; i++)
				{
					GameObject obj = new GameObject();
					obj.transform.parent = base.transform;
					SoundSource soundSource = obj.AddComponent<SoundSource>();
					soundSource.Configure(SoundCategory.Effects, Sound.Clip);
					soundSource.TransitionTime = 0f;
					Sound.Pitch += PitchShiftPerSound;
					soundSource.Pitch = Sound.Pitch;
					soundSource.ShouldLoop = false;
					Sources.Add(soundSource);
				}
			}
			if (Sound == null)
			{
				return;
			}
			Sound.Pitch += PitchShiftPerSound;
			foreach (SoundSource source in Sources)
			{
				if (!source.IsPlaying)
				{
					source.Pitch = Sound.Pitch;
					source.Play();
					break;
				}
			}
		}
	}
}
