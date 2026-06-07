using System;
using UnityEngine;

namespace CTS.Core
{
	public abstract class CTSBehaviour : MonoBehaviour
	{
		private const string ProfilerAwake = "Awake";

		internal bool Constructed { get; set; }

		internal bool IsAwake { get; set; }

		internal void Awake()
		{
			if (Constructed)
			{
				if (!IsAwake)
				{
					IsAwake = true;
					try
					{
						OnAwake();
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}
			else
			{
				CTSFactory.Construct(this);
			}
		}

		protected virtual void OnAwake()
		{
		}

		protected virtual void OnEnabled()
		{
		}

		protected virtual void OnDisabled()
		{
		}

		private void OnEnable()
		{
			if (base.enabled)
			{
				if (Constructed)
				{
					OnEnabled();
				}
				else
				{
					CTSFactory.CurrentConstructionFinished += OnEnable;
				}
			}
		}

		private void OnDisable()
		{
			if (Constructed)
			{
				OnDisabled();
			}
		}
	}
}
