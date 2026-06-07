using System.Diagnostics;
using UnityEngine;

public class DisableTracer : MonoBehaviour
{
	[Tooltip("Drag the component that keeps getting disabled.")]
	public Behaviour target;

	private bool lastEnabled;

	private void Awake()
	{
		if (target == null)
		{
			target = GetComponent<Behaviour>();
		}
		lastEnabled = target != null && target.enabled;
	}

	private void LateUpdate()
	{
		if (!(target == null))
		{
			bool flag = target.enabled;
			if (lastEnabled && !flag)
			{
				UnityEngine.Debug.Log("[DisableTracer] " + target.GetType().Name + " was DISABLED on '" + target.gameObject.name + "'\n" + new StackTrace(fNeedFileInfo: true).ToString(), target);
			}
			lastEnabled = flag;
		}
	}
}
