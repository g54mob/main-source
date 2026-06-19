using System.Collections.Generic;
using Aggro.Core;
using Aggro.Core.Networking;
using UnityEngine;

public class StackTape : EntityBehaviourBase
{
	public Transform aZPos;

	public Transform aZNeg;

	public Transform aXPos;

	public Transform aXNeg;

	public Transform bZPos;

	public Transform bZNeg;

	public Transform bXPos;

	public Transform bXNeg;

	public Renderer[] tapeRenderers;

	public GameObject poofPrefab;

	private bool _active;

	private static List<Grabbable> _grabbables = new List<Grabbable>();

	protected override void OnEntityCreated()
	{
		base.entity.AddEventListener<Grabbable.EvBrokeEntireStack>(OnBrokeEntireStack);
	}

	protected override void OnEntityDestroyed()
	{
		base.entity.RemoveEventListener<Grabbable.EvBrokeEntireStack>(OnBrokeEntireStack);
	}

	private void OnBrokeEntireStack(Entity e, Grabbable.EvBrokeEntireStack ev)
	{
		Renderer[] array = tapeRenderers;
		foreach (Renderer renderer in array)
		{
			NetworkAggroManagerBase<VFXManager>.instance.Play(poofPrefab, renderer.transform.position);
		}
	}

	[UpdateInGroup((UpdatePriority)10001)]
	protected override void OnUpdatePresentationLate()
	{
		Grabbable grabbable = base.entity.GetObject<Grabbable>();
		bool flag = grabbable.isInStack && grabbable.syncStackIndex < grabbable.GetStackCount() - 1;
		if (_active != flag)
		{
			_active = flag;
			for (int i = 0; i < tapeRenderers.Length; i++)
			{
				tapeRenderers[i].gameObject.SetActive(_active);
			}
		}
		if (_active)
		{
			_grabbables.Clear();
			grabbable.GetStack(_grabbables);
			StackTape stackTape = _grabbables[grabbable.syncStackIndex + 1].entity.GetObject<StackTape>();
			SetTransform(aZPos, stackTape.bZPos);
			SetTransform(aZNeg, stackTape.bZNeg);
			SetTransform(aXPos, stackTape.bXPos);
			SetTransform(aXNeg, stackTape.bXNeg);
		}
	}

	private void SetTransform(Transform a, Transform b)
	{
		b.GetPositionAndRotation(out var position, out var rotation);
		a.SetPositionAndRotation(position, rotation);
		a.localScale = b.localScale;
	}
}
