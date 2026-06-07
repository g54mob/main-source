using DV.JObjectExtstensions;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetRoadrunner : ExternallySwitchableGadget
	{
		private const string KEY_COUNTUP = "countup";

		private const string KEY_TARGET = "target";

		public const float SPEED_THRESHOLD = 0.1f;

		[SerializeField]
		[Tooltip("Maximum selectable distance")]
		private int maxLength = 2000;

		[SerializeField]
		[Tooltip("Distance after countup completed after which the roadrunner will self ack")]
		private int resetDistance = 200;

		private int length;

		private double countup = -1.0;

		private bool? lastDirectionReversed;

		public int MaxLength => maxLength;

		public int ResetDistance => resetDistance;

		public int LengthMeters
		{
			get
			{
				return length;
			}
			set
			{
				length = value;
				if (length > maxLength)
				{
					length = maxLength;
				}
				if (length < 0)
				{
					length = 0;
				}
			}
		}

		public float Countup => (float)countup;

		public bool IsCounting
		{
			get
			{
				if (countup >= 0.0)
				{
					return countup < (double)length;
				}
				return false;
			}
		}

		public bool HasCompleted { get; private set; }

		public void StartMeasure()
		{
			countup = 0.0;
			HasCompleted = false;
			lastDirectionReversed = null;
		}

		public void Acknowledge()
		{
			HasCompleted = false;
			lastDirectionReversed = null;
			countup = -1.0;
		}

		private void Update()
		{
			if (!IsCounting && !HasCompleted)
			{
				return;
			}
			if (!base.PowerState)
			{
				Acknowledge();
				return;
			}
			float value;
			float num = (TryReadPort(STDSimPort.WheelSpeedKMH, out value) ? (value / 3.6f) : 0f);
			if (num > 0.1f || num < -0.1f)
			{
				bool flag = num < 0f;
				if (flag != lastDirectionReversed)
				{
					if (lastDirectionReversed.HasValue)
					{
						Acknowledge();
					}
					lastDirectionReversed = flag;
				}
			}
			countup += Mathf.Abs(num) * Time.deltaTime;
			HasCompleted = countup >= (double)length;
			if (countup > (double)(length + resetDistance))
			{
				Acknowledge();
			}
		}

		public override void SaveDataRequested(JObject dst)
		{
			dst.SetFloat("countup", (float)countup);
			dst.SetInt("target", LengthMeters);
			base.SaveDataRequested(dst);
		}

		public override void SaveDataLoaded(JObject src)
		{
			base.SaveDataLoaded(src);
			countup = src.GetFloat("countup") ?? 0f;
			LengthMeters = src.GetInt("target") ?? 0;
		}
	}
}
