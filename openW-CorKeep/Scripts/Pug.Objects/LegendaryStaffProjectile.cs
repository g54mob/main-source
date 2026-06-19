using System;
using System.Collections.Generic;
using SiphonMana.Components;
using UnityEngine;

public class LegendaryStaffProjectile : Projectile, ISiphonManaPresenter
{
	[Serializable]
	public struct BeamInfo
	{
		public ParticleSystem particleSystem;

		public ParticlesMoveToTarget particlesMoveToTarget;
	}

	public BeamInfo toOwnerBeam;

	public List<BeamInfo> targetBeams;

	public Transform beamStartPosition;

	public GameObject trail;

	public override void OnOccupied()
	{
		base.OnOccupied();
		Manager.effects.PlayPuff(PuffID.SmallEnergyExplosion, base.transform.position, 1);
	}

	protected override void OnShow()
	{
		base.OnShow();
		trail.SetActive(value: false);
		spriteObjects[0].PlayAnimation(-1878077465);
		HideSiphonToOwnerBeam();
		for (int i = 0; i < targetBeams.Count; i++)
		{
			HideSiphonTargetBeam(i);
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		trail.SetActive(value: false);
		HideSiphonToOwnerBeam();
		for (int i = 0; i < targetBeams.Count; i++)
		{
			HideSiphonTargetBeam(i);
		}
	}

	public void ShowSiphonToOwnerBeam(Vector3 ownerPositionWorld)
	{
		if (!toOwnerBeam.particleSystem.isPlaying)
		{
			toOwnerBeam.particleSystem.Play();
		}
		toOwnerBeam.particleSystem.transform.position = beamStartPosition.position;
		toOwnerBeam.particlesMoveToTarget.targetWorldPosition = ownerPositionWorld;
	}

	public void HideSiphonToOwnerBeam()
	{
		HideBeam(toOwnerBeam);
	}

	public void ShowSiphonTargetBeam(int index, Vector3 targetPositionWorld)
	{
		if (!targetBeams[index].particleSystem.isPlaying)
		{
			targetBeams[index].particleSystem.Play();
		}
		targetBeams[index].particleSystem.transform.position = EntityMonoBehaviour.ToRenderFromWorld(targetPositionWorld);
		targetBeams[index].particlesMoveToTarget.targetWorldPosition = EntityMonoBehaviour.ToWorldFromRender(beamStartPosition.position);
	}

	public void HideSiphonTargetBeam(int index)
	{
		HideBeam(targetBeams[index]);
	}

	private static void HideBeam(BeamInfo beamInfo)
	{
		beamInfo.particleSystem.Stop();
	}
}
