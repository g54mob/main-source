using Aggro.Core;
using UnityEngine;
using UnityEngine.Video;

public class Tutorial : EntityBehaviourBase
{
	public BoxCollider activationBoxCollider;

	public LayerMask playerCollisionMask;

	public string description;

	public VideoClip videoClip;

	private bool _playerInBoundsLastFrame;

	private bool GetPlayerInBounds()
	{
		if (!GameUtil.TryGetLocalPlayer(out var player))
		{
			return false;
		}
		Vector3 center = activationBoxCollider.transform.TransformPoint(activationBoxCollider.center);
		Vector3 halfExtents = activationBoxCollider.size / 2f;
		Collider[] array = Physics.OverlapBox(center, halfExtents, activationBoxCollider.transform.rotation, playerCollisionMask);
		for (int i = 0; i < array.Length; i++)
		{
			Entity entity = array[i].GetComponent<EntityCollider>().entity;
			if (entity == player)
			{
				return true;
			}
		}
		return false;
	}

	protected override void OnUpdatePresentation()
	{
		bool playerInBounds = GetPlayerInBounds();
		TutorialWindowUI instance = AggroManagerBase<TutorialWindowUI>.instance;
		if (playerInBounds && !_playerInBoundsLastFrame)
		{
			instance.videoPlayer.clip = videoClip;
			instance.textHandler.text = description;
			instance.videoPlayer.Prepare();
			instance.videoPlayer.Play();
		}
		if (playerInBounds)
		{
			instance.SetVisibleThisFrame();
		}
		_playerInBoundsLastFrame = playerInBounds;
	}
}
