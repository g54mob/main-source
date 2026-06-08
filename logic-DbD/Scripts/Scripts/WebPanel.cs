using System.Collections;
using UnityEngine;

public class WebPanel : PanelScroll
{
	protected override IEnumerator OnPanelClose(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		if (!isOpen)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
