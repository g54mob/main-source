using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility
{
	[Serializable]
	[CustomObfuscation(rename = false)]
	internal class Timer
	{
		public bool running;

		[SerializeField]
		private double timer;

		public double length;

		public Timer()
		{
		}

		public Timer(double P_0)
		{
			length = P_0;
		}

		public void ukLAEwNjdVoyhqVMvBmXIQyctvAs()
		{
			running = true;
			timer = length;
		}

		public void WhfEedCNyEQKEnjXVbrrauhqhvFL(double P_0)
		{
			running = true;
			length = P_0;
			timer = length;
		}

		public void RyGFHlLhMaABOWkBeUNCQtiCLUGi()
		{
			uyipcdimxBXwnQAhOaMGrGyiLyFB();
			ukLAEwNjdVoyhqVMvBmXIQyctvAs();
		}

		public bool ACwOeKZazhSpCkhCJpeHEwhiXcBC(double P_0)
		{
			if (!running)
			{
				return false;
			}
			timer -= P_0;
			if (timer <= 0.0)
			{
				running = false;
				return true;
			}
			return false;
		}

		public void uyipcdimxBXwnQAhOaMGrGyiLyFB()
		{
			running = false;
			timer = 0.0;
		}

		public void ZsThHzoKCNiWYAKjgOTzarnKFYgUB(double P_0)
		{
			length = P_0;
		}

		public Timer KJvtHlosUOPmUhYOGDXlVUwwmInc()
		{
			return (Timer)MemberwiseClone();
		}
	}
}
