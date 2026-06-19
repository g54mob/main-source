using Aggro.Core;
using FMODUnity;
using UnityEngine;

public class FMODEntityEventListener : EntityEventListenerBase
{
	[Space]
	public EventReference eventReference;

	public bool isPositional = true;

	protected override void OnEvent()
	{
		if (isPositional)
		{
			AudioManager.PlaySfx(eventReference, base.entity);
		}
		else
		{
			AudioManager.PlaySfx(eventReference);
		}
	}
}
