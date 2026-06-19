using System.Collections;
using Aggro.Core;
using UnityEngine;
using UnityEngine.Serialization;

public class TutorialGate : EntityBehaviourBase, IFloaterPopulator
{
	private static readonly int Open1 = Animator.StringToHash("open");

	[FormerlySerializedAs("collider")]
	public GameObject gateCollider;

	public Animator animator;

	public bool _opened;

	private FloaterUI _floaterUI;

	public void Open(bool cameraPan = false)
	{
		StartCoroutine(OpenCo(cameraPan));
	}

	public void Close()
	{
		StartCoroutine(CloseCo());
	}

	protected override void OnUpdatePresentationEarly()
	{
		if (_opened && _floaterUI != null)
		{
			_floaterUI.SetVisibleThisFrame();
		}
	}

	public IEnumerator OpenCo(bool cameraPan = false)
	{
		if (cameraPan)
		{
			yield return AggroManagerBase<CameraController>.instance.SetFocusPositionCo(base.transform.position, 2f);
		}
		_opened = true;
		gateCollider.SetActive(value: false);
		animator.SetBool(Open1, value: true);
		if (cameraPan)
		{
			yield return new WaitForSeconds(1f);
			yield return AggroManagerBase<CameraController>.instance.SetFocusPositionCo(GameUtil.GetLocalPlayer().transform.position, 2f);
			AggroManagerBase<CameraController>.instance.FollowPlayer();
		}
	}

	public IEnumerator CloseCo()
	{
		yield return null;
		gateCollider.SetActive(value: true);
		animator.SetBool(Open1, value: false);
		_opened = false;
	}

	public void AddedFloater(FloaterUI floaterAdded)
	{
		_floaterUI = floaterAdded;
	}

	public void RemovedFloater()
	{
	}
}
