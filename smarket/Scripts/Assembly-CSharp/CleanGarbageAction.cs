using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using __Project__.Scripts.Janitor;

public class CleanGarbageAction : ActionTask
{
	public BBParameter<Janitor> janitorParam;

	[RequiredField]
	public BBParameter<GameObject> target;

	protected override void OnExecute()
	{
	}
}
