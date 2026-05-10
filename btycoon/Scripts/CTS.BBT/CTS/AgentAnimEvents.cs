using System;
using UnityEngine;

namespace CTS
{
	public class AgentAnimEvents : MonoBehaviour
	{
		public event Action OnBitten;

		public event Action<int> OnUseTool;

		public event Action OnGrab;

		public event Action SpawnedVomit;

		public event Action<string> OnPlayVFX;

		public event Action<string> OnStopVFX;

		public event Action OnThrowMoney;

		public event Action OnAskAnswer;

		public void TriggerOnBitten()
		{
			this.OnBitten?.Invoke();
		}

		public void TriggerOnUseTool(int toolIndex)
		{
			this.OnUseTool?.Invoke(toolIndex);
		}

		public void TriggerGrab()
		{
			this.OnGrab?.Invoke();
		}

		public void SpawnVomit()
		{
			this.SpawnedVomit?.Invoke();
		}

		public void TriggerVFX(string vfxIndex)
		{
			this.OnPlayVFX?.Invoke(vfxIndex);
		}

		public void TriggerStopVFX(string vfxIndex)
		{
			this.OnStopVFX?.Invoke(vfxIndex);
		}

		public void ThrowMoney()
		{
			this.OnThrowMoney?.Invoke();
		}

		public void TriggerAskAnswer()
		{
			this.OnAskAnswer?.Invoke();
		}
	}
}
