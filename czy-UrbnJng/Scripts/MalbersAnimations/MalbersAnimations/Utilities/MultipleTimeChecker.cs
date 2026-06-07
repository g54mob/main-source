using MalbersAnimations.Events;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations.Utilities
{
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/utilities/multiple-time-checker")]
	[AddComponentMenu("Malbers/Utilities/Multiple Time Checker")]
	public class MultipleTimeChecker : MonoBehaviour
	{
		[Tooltip("Amount of taps/click/checks you need to ")]
		[Min(1f)]
		public int MaxChecks = 2;

		[Min(0.1f)]
		public float interval = 0.3f;

		public IntEvent CheckStep = new IntEvent();

		public UnityEvent CheckSuccessful = new UnityEvent();

		public bool debug;

		public int CurrentCheck { get; private set; }

		public float CurrentTime { get; private set; }

		public void Check()
		{
			if (CurrentTime != 0f)
			{
				if (!MTools.ElapsedTime(CurrentTime, interval))
				{
					if (CurrentCheck == MaxChecks)
					{
						if (debug)
						{
							Debug.Log("Max Checks Successful!");
						}
						CheckSuccessful.Invoke();
						ResetCheck();
					}
					else
					{
						CheckAdd();
					}
				}
				else
				{
					ResetCheck();
					CheckAdd();
				}
			}
			else
			{
				CheckAdd();
			}
		}

		private void ResetCheck()
		{
			CurrentCheck = 1;
			CurrentTime = 0f;
		}

		private void CheckAdd()
		{
			CurrentCheck++;
			if (debug)
			{
				Debug.Log($"Check [{CurrentCheck}]");
			}
			CurrentTime = Time.time;
			CheckStep.Invoke(CurrentCheck);
		}
	}
}
