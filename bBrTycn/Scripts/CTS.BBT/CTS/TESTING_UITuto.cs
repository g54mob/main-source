using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class TESTING_UITuto : MonoBehaviour
	{
		[SerializeField]
		private InterfaceElement[] toggleable;

		private LockToggle[] wrappers;

		private void Start()
		{
			wrappers = new LockToggle[toggleable.Length];
			for (int i = 0; i < toggleable.Length; i++)
			{
				wrappers[i] = new LockToggle(toggleable[i]);
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		private void TestToggleSwitch()
		{
			for (int i = 0; i < wrappers.Length; i++)
			{
				if (wrappers[i] != null)
				{
					if (wrappers[i].Locked)
					{
						wrappers[i].Unlock();
					}
					else
					{
						wrappers[i].Lock();
					}
				}
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		private void TestToggleOn()
		{
			for (int i = 0; i < wrappers.Length; i++)
			{
				if (wrappers[i] != null)
				{
					wrappers[i].Unlock();
				}
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		private void TestToggleOff()
		{
			for (int i = 0; i < wrappers.Length; i++)
			{
				if (wrappers[i] != null)
				{
					wrappers[i].Lock();
				}
			}
		}
	}
}
