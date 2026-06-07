using UnityEngine;

public class Clock
{
	private interface ICore
	{
		float time { get; }

		float deltaTime { get; }

		int frameCount { get; }

		bool running { get; set; }

		void Update();
	}

	public sealed class WaitForSecondsInstruction : CustomYieldInstruction
	{
		private readonly Clock clock;

		private readonly float endTime;

		public override bool keepWaiting
		{
			get
			{
				return clock.time < endTime;
			}
		}

		public WaitForSecondsInstruction(Clock clock_, float seconds)
		{
			clock = clock_;
			endTime = clock.time + seconds;
		}
	}

	private class SystemCore : ICore
	{
		public float time
		{
			get
			{
				return Time.time;
			}
		}

		public float deltaTime
		{
			get
			{
				return Time.deltaTime;
			}
		}

		public int frameCount
		{
			get
			{
				return Time.frameCount;
			}
		}

		public bool running
		{
			get
			{
				return Time.timeScale != 0f;
			}
			set
			{
				Time.timeScale = ((!value) ? 0f : globalTimeScale);
				Time.fixedDeltaTime = ((!value) ? 0f : (1f / 60f));
			}
		}

		public void Update()
		{
		}
	}

	private class CustomCore : ICore
	{
		private float sysPreTime;

		private float sysCurTime;

		private float sysStartTime;

		private float sysMinCompensation;

		public static float maxDeltaTime = 100f;

		public float time
		{
			get
			{
				return sysCurTime - sysStartTime;
			}
		}

		public float deltaTime
		{
			get
			{
				return sysCurTime - sysPreTime;
			}
		}

		public bool running { get; set; }

		public int frameCount { get; private set; }

		private float prevTime
		{
			get
			{
				return sysPreTime - sysStartTime;
			}
		}

		public CustomCore()
		{
			Start();
		}

		public void Start()
		{
			SetTime(0f);
			frameCount = 0;
		}

		public void Update()
		{
			sysPreTime = sysCurTime;
			sysCurTime = globalTimeScale * (Time.realtimeSinceStartup - sysMinCompensation);
			if (running)
			{
				if (Time.captureFramerate != 0)
				{
					sysCurTime = sysPreTime + 1f / (float)Time.captureFramerate;
				}
				else if (sysCurTime - sysPreTime > maxDeltaTime)
				{
					sysMinCompensation += sysCurTime - sysPreTime - maxDeltaTime;
					sysCurTime = sysPreTime + maxDeltaTime;
				}
				frameCount++;
			}
			else
			{
				sysStartTime += sysCurTime - sysPreTime;
			}
		}

		public void SetTime(float time_)
		{
			sysCurTime = globalTimeScale * Time.realtimeSinceStartup;
			sysPreTime = sysCurTime;
			sysStartTime = sysCurTime - globalTimeScale * time_;
			sysMinCompensation = 0f;
		}
	}

	private ICore core;

	private static Clock play_;

	private static Clock menu_;

	public static float globalTimeScale = 1f;

	private const float kFixedTimeStep = 1f / 60f;

	public float time
	{
		get
		{
			return core.time;
		}
	}

	public float deltaTime
	{
		get
		{
			return core.deltaTime;
		}
	}

	public int frameCount
	{
		get
		{
			return core.frameCount;
		}
	}

	public bool running
	{
		get
		{
			return core.running;
		}
		set
		{
			core.running = value;
		}
	}

	public static Clock play
	{
		get
		{
			if (play_ == null)
			{
				play_ = new Clock(new SystemCore());
			}
			return play_;
		}
	}

	public static Clock menu
	{
		get
		{
			if (menu_ == null)
			{
				menu_ = new Clock(new CustomCore());
				PreUpdater.Add(menu_.Update);
			}
			return menu_;
		}
	}

	public static Clock active
	{
		get
		{
			return (!play.running) ? menu : play;
		}
		set
		{
			if (value == play || value == menu)
			{
				play.running = value == play;
				menu.running = value == menu;
			}
		}
	}

	private Clock(ICore core_)
	{
		core = core_;
	}

	public void Update()
	{
		core.Update();
	}

	public WaitForSecondsInstruction WaitForSeconds(float seconds)
	{
		return new WaitForSecondsInstruction(this, seconds);
	}
}
