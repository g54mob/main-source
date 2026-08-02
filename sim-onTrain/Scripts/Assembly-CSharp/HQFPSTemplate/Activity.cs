using System;
using UnityEngine;

namespace HQFPSTemplate
{
	public class Activity
	{
		private bool m_Active;

		public bool Active => m_Active;

		public float LastStartTime { get; private set; }

		public float LastEndTime { get; private set; }

		private event TryerDelegate m_StartTryers;

		private event TryerDelegate m_StopTryers;

		private event Action m_StartCallbacks;

		private event Action m_StopCallbacks;

		public void AddStartListener(Action listener)
		{
			m_StartCallbacks += listener;
		}

		public void AddStopListener(Action listener)
		{
			m_StopCallbacks += listener;
		}

		public void SetStartTryer(TryerDelegate tryer)
		{
			this.m_StartTryers = tryer;
		}

		public void SetStopTryer(TryerDelegate tryer)
		{
			this.m_StopTryers = tryer;
		}

		public void ForceStart()
		{
			if (!m_Active)
			{
				m_Active = true;
				if (this.m_StartCallbacks != null)
				{
					this.m_StartCallbacks();
					LastStartTime = Time.time;
				}
			}
		}

		public bool TryStart(bool bypassState = false)
		{
			if (m_Active && !bypassState)
			{
				return false;
			}
			if (this.m_StartTryers != null)
			{
				bool num = CallStartApprovers();
				if (num)
				{
					m_Active = true;
				}
				if (num && this.m_StartCallbacks != null)
				{
					this.m_StartCallbacks();
					LastStartTime = Time.time;
				}
				return num;
			}
			Debug.LogWarning("[Activity] - You tried to start an activity which has no tryer (if no one checks if the activity can start, it won't start).");
			return false;
		}

		public bool TryStop()
		{
			if (!m_Active)
			{
				return false;
			}
			if (this.m_StopTryers != null && CallStopApprovers())
			{
				m_Active = false;
				if (this.m_StopCallbacks != null)
				{
					this.m_StopCallbacks();
					LastEndTime = Time.time;
				}
				return true;
			}
			return false;
		}

		public void ForceStop()
		{
			if (m_Active)
			{
				m_Active = false;
				if (this.m_StopCallbacks != null)
				{
					this.m_StopCallbacks();
					LastEndTime = Time.time;
				}
			}
		}

		public void RemoveStartListener(Action listener)
		{
			m_StartCallbacks -= listener;
		}

		public void RemoveStopListener(Action listener)
		{
			m_StopCallbacks -= listener;
		}

		private bool CallStartApprovers()
		{
			Delegate[] invocationList = this.m_StartTryers.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				if (!(bool)invocationList[i].DynamicInvoke())
				{
					return false;
				}
			}
			return true;
		}

		private bool CallStopApprovers()
		{
			Delegate[] invocationList = this.m_StopTryers.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				if (!(bool)invocationList[i].DynamicInvoke())
				{
					return false;
				}
			}
			return true;
		}
	}
	public class Activity<T>
	{
		public delegate bool ActivityTryerDelegate(T parameter);

		private T m_Parameter;

		private bool m_Active;

		public bool Active => m_Active;

		public T Parameter => m_Parameter;

		public float LastStartTime { get; private set; }

		public float LastEndTime { get; private set; }

		private event ActivityTryerDelegate m_StartTryers;

		private event ActivityTryerDelegate m_StopTryers;

		private event Action m_StartCallbacks;

		private event Action m_StopCallbacks;

		public void SetStartTryer(ActivityTryerDelegate tryer)
		{
			this.m_StartTryers = tryer;
		}

		public void SetStopTryer(ActivityTryerDelegate tryer)
		{
			this.m_StopTryers = tryer;
		}

		public void AddStartListener(Action listener)
		{
			m_StartCallbacks += listener;
		}

		public void AddStopListener(Action listener)
		{
			m_StopCallbacks += listener;
		}

		public void ForceStart(T parameter)
		{
			if (!m_Active)
			{
				m_Active = true;
				m_Parameter = parameter;
				if (this.m_StartCallbacks != null)
				{
					this.m_StartCallbacks();
					LastStartTime = Time.time;
				}
			}
		}

		public bool TryStart(T parameter)
		{
			if (m_Active)
			{
				return false;
			}
			if (this.m_StartTryers != null)
			{
				bool num = CallStartApprovers(parameter);
				if (num)
				{
					m_Active = true;
					m_Parameter = parameter;
				}
				if (num && this.m_StartCallbacks != null)
				{
					this.m_StartCallbacks();
					LastStartTime = Time.time;
				}
				return num;
			}
			Debug.LogWarning("[Activity] - You tried to start an activity which has no tryer (if no one checks if the activity can start, it won't start).");
			return false;
		}

		public bool TryStop()
		{
			if (!m_Active)
			{
				return false;
			}
			if (this.m_StopTryers != null && CallStopApprovers(m_Parameter))
			{
				m_Active = false;
				if (this.m_StopCallbacks != null)
				{
					this.m_StopCallbacks();
					LastEndTime = Time.time;
				}
				return true;
			}
			return false;
		}

		public void ForceStop()
		{
			if (m_Active)
			{
				m_Active = false;
				if (this.m_StopCallbacks != null)
				{
					this.m_StopCallbacks();
					LastEndTime = Time.time;
				}
			}
		}

		public void RemoveStartListener(Action listener)
		{
			m_StartCallbacks -= listener;
		}

		public void RemoveStopListener(Action listener)
		{
			m_StopCallbacks -= listener;
		}

		private bool CallStartApprovers(T parameter)
		{
			Delegate[] invocationList = this.m_StartTryers.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				if (!(bool)invocationList[i].DynamicInvoke(parameter))
				{
					return false;
				}
			}
			return true;
		}

		private bool CallStopApprovers(T parameter)
		{
			Delegate[] invocationList = this.m_StopTryers.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				if (!(bool)invocationList[i].DynamicInvoke(parameter))
				{
					return false;
				}
			}
			return true;
		}
	}
}
