using System;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace DV.RailDriver
{
	public class RailDriverTextDebug : MonoBehaviour
	{
		[Serializable]
		public class FuckUnityEvent : UnityEvent<string>
		{
		}

		public FuckUnityEvent OnText;

		private RailDriver.Wrapper wrapper;

		private StringBuilder sb = new StringBuilder();

		private int counter;

		private void Awake()
		{
			GetComponent<RailDriver>().WrapperCreated += OnWrapperCreated;
		}

		private void Update()
		{
			if (wrapper == null)
			{
				return;
			}
			sb.Clear();
			sb.AppendLine($"Reverser: {wrapper.Reverser}");
			sb.AppendLine($"Throttle: {wrapper.Throttle}");
			sb.AppendLine($"AutoBrake: {wrapper.AutoBrake}");
			sb.AppendLine($"IndBrake: {wrapper.IndBrake}");
			sb.AppendLine($"BailOff: {wrapper.BailOff}");
			sb.AppendLine($"Wiper: {wrapper.Wiper}");
			sb.AppendLine($"Lights: {wrapper.Lights}");
			for (int i = 0; i < wrapper.ButtonsCurrentState.Length; i++)
			{
				sb.Append(string.Format("Button {0}: {1}", i, wrapper.ButtonsCurrentState[i] ? "Pressed" : "None"));
				if (i % 8 == 7)
				{
					sb.AppendLine();
				}
			}
			OnText.Invoke(sb.ToString());
			counter++;
			if (counter == 1000)
			{
				counter = 0;
			}
			wrapper.WriteDisplay(new RailDriver.DisplayBuffer(counter));
		}

		private void OnWrapperCreated(RailDriver.Wrapper wrapper)
		{
			this.wrapper = wrapper;
		}
	}
}
