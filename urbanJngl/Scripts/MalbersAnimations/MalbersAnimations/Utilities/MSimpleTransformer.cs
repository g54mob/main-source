using System.Collections;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations.Utilities
{
	public abstract class MSimpleTransformer : MonoBehaviour
	{
		public enum UpdateCycle
		{
			Update = 0,
			FixedUpdate = 1,
			LateUpdate = 2
		}

		[Tooltip("This is the object to move. Must be child of this gameobject")]
		[RequiredField]
		public Transform Object;

		public UpdateCycle update = UpdateCycle.FixedUpdate;

		[Tooltip("Once: The animation will be applied once and then the Component will be disabled\nPing Pong: The animation will be played on forward and backards forever\nRepeat: The animation will be played on repeat forever.")]
		public LoopType loopType;

		[Hide("loopType", new int[] { 0 })]
		[Tooltip("Once the Animation end you can: \nAdditive: Keep Pusing Forward.\nInvert: If it gets to the End it will go on the oppositive Direction")]
		public EndType endType;

		[Tooltip("The Laps to play the animation when the Loop is set to PingPong or Repeat. less than 0 means infinite")]
		[Hide("loopType", true, new int[] { 0 })]
		public IntReference Laps = new IntReference(0);

		public bool UnScaleTime;

		public bool CannotBeInterrupted = true;

		public FloatReference StartDelay = new FloatReference();

		public FloatReference EndDelay = new FloatReference();

		public FloatReference duration = new FloatReference(1f);

		public AnimationCurve m_Curve = new AnimationCurve(MTools.DefaultCurve);

		[Tooltip("Show/Hide the Events")]
		public bool events;

		[Hide("events")]
		public UnityEvent WaitStart = new UnityEvent();

		[Hide("events")]
		public UnityEvent OnStart = new UnityEvent();

		[Hide("events")]
		public UnityEvent OnEnd = new UnityEvent();

		[Hide("events")]
		public UnityEvent EndWait = new UnityEvent();

		[Range(0f, 1f)]
		public float preview;

		protected bool forward;

		protected WaitForSeconds StartWaitSeconds;

		protected WaitForSeconds EndWaitSeconds;

		public int currentLap { get; protected set; }

		public float time { get; protected set; }

		public float value { get; protected set; }

		public float lastValue { get; protected set; }

		public bool Waiting { get; set; }

		public bool Playing { get; set; }

		public bool Inverted { get; protected set; }

		protected virtual void OnEnable()
		{
			Restart();
			SetStartWait(StartDelay);
			SetEndWait(EndDelay);
			DoWaitStart();
		}

		public virtual void Play()
		{
			Activate();
		}

		public virtual void Stop()
		{
			Playing = false;
			Waiting = false;
			base.enabled = false;
		}

		protected virtual void OnDisable()
		{
			Stop();
		}

		private void SetStartWait(float delay)
		{
			StartWaitSeconds = new WaitForSeconds(delay);
		}

		private void SetEndWait(float delay)
		{
			EndWaitSeconds = new WaitForSeconds(delay);
		}

		protected virtual void Restart()
		{
			Waiting = false;
			lastValue = 0f;
			currentLap = 0;
			forward = true;
			Evaluate(value);
			StopAllCoroutines();
		}

		private void Logic(float deltaTime)
		{
			if (Playing)
			{
				time += deltaTime / (float)duration % 1f;
				switch (loopType)
				{
				case LoopType.Once:
					LoopOnce();
					break;
				case LoopType.PingPong:
					LoopPingPong();
					break;
				case LoopType.Repeat:
					LoopRepeat();
					break;
				}
				if (Playing)
				{
					Evaluate(value);
				}
			}
		}

		private IEnumerator C_WaitStart()
		{
			Pre_Start();
			WaitStart.Invoke();
			if ((float)StartDelay > 0f)
			{
				Waiting = true;
				Playing = false;
				yield return StartWaitSeconds;
			}
			Pos_Start();
			OnStart.Invoke();
			Waiting = false;
			Playing = true;
		}

		private IEnumerator C_WaitEnd()
		{
			Pre_End();
			Playing = false;
			OnEnd.Invoke();
			if ((float)EndDelay > 0f)
			{
				Waiting = true;
				yield return EndWaitSeconds;
			}
			Pos_End();
			EndWait.Invoke();
			if (loopType == LoopType.PingPong)
			{
				OnStart.Invoke();
				Playing = true;
			}
			else
			{
				time = 0f;
				if (loopType == LoopType.Once && endType != EndType.None)
				{
					value = 0f;
				}
			}
			Waiting = false;
			Evaluate(value);
			if (loopType == LoopType.Once)
			{
				base.enabled = false;
			}
		}

		private IEnumerator C_WaitRepeat()
		{
			Playing = false;
			Pre_End();
			OnEnd.Invoke();
			currentLap++;
			if ((float)EndDelay > 0f)
			{
				Waiting = true;
				yield return EndWaitSeconds;
			}
			Pos_End();
			if ((int)Laps > 0 && currentLap >= (int)Laps)
			{
				base.enabled = false;
				yield break;
			}
			value = 0f;
			Evaluate(value);
			Pre_Start();
			if ((float)StartDelay > 0f)
			{
				Waiting = true;
				Playing = false;
				yield return StartWaitSeconds;
			}
			OnStart.Invoke();
			Pos_Start();
			Waiting = false;
			Playing = true;
			yield return null;
		}

		public void Activate()
		{
			if (!Waiting && (!Playing || !CannotBeInterrupted))
			{
				Playing = true;
				base.enabled = true;
				OnEnable();
			}
		}

		public void ActivateToggle()
		{
			base.enabled = !base.enabled;
		}

		private void LateUpdate()
		{
			if (update == UpdateCycle.LateUpdate)
			{
				Logic(UnScaleTime ? Time.unscaledDeltaTime : Time.deltaTime);
			}
		}

		private void Update()
		{
			if (update == UpdateCycle.Update)
			{
				Logic(UnScaleTime ? Time.unscaledDeltaTime : Time.deltaTime);
			}
		}

		private void FixedUpdate()
		{
			if (update == UpdateCycle.FixedUpdate)
			{
				Logic(UnScaleTime ? Time.fixedUnscaledDeltaTime : Time.fixedDeltaTime);
			}
		}

		public abstract void Evaluate(float curveValue);

		protected virtual void Pre_Start()
		{
		}

		protected virtual void Pos_Start()
		{
		}

		protected virtual void Pre_End()
		{
		}

		protected virtual void Pos_End()
		{
		}

		private void LoopPingPong()
		{
			lastValue = value;
			value = Mathf.PingPong(time, 1f);
			if (forward && lastValue > value)
			{
				OnEnd.Invoke();
				forward = !forward;
				DoWaitEnd();
			}
			else if (!forward && lastValue < value)
			{
				OnEnd.Invoke();
				forward = !forward;
				DoWaitStart();
				currentLap++;
			}
			if ((int)Laps > 0 && currentLap >= (int)Laps)
			{
				base.enabled = false;
				value = 0f;
				time = 0f;
				Evaluate(value);
			}
		}

		private void LoopRepeat()
		{
			lastValue = value;
			value = Mathf.Repeat(time, 1f);
			if (lastValue > value)
			{
				value = 1f;
				WaitRepeat();
			}
		}

		private void DoWaitEnd()
		{
			StartCoroutine(C_WaitEnd());
		}

		private void DoWaitStart()
		{
			StartCoroutine(C_WaitStart());
		}

		private void WaitRepeat()
		{
			StartCoroutine(C_WaitRepeat());
		}

		private void LoopOnce()
		{
			value = Mathf.Clamp01(time);
			if (value >= 1f)
			{
				value = 1f;
				time = 1f;
				DoWaitEnd();
			}
		}

		protected virtual void Reset()
		{
			if (base.transform.childCount > 0)
			{
				Object = base.transform.GetChild(0);
			}
			else
			{
				Object = base.transform;
			}
		}
	}
}
