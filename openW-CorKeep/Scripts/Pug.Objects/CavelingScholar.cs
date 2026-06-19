using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class CavelingScholar : EntityMonoBehaviour
{
	private static int _emissiveTexStrength = Shader.PropertyToID("_emissiveTexStrength");

	public List<LineRenderer> beams;

	public Transform beamStartPositionDown;

	public Transform beamStartPositionSide;

	public Transform beamStartPositionUp;

	private Vector3 beamStartPosition;

	protected override bool updateAnimOrientation => true;

	protected override bool updateAnimMovement => true;

	protected override bool updateAnimMovementSpeed => true;

	protected override float GetAnimSpeed()
	{
		return 1f;
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		Entity targetEntity = EntityUtility.GetComponentData<HealOtherEntityStateCD>(base.entity, base.world).targetEntity;
		if (targetEntity != Entity.Null && XScaler.gameObject.activeSelf)
		{
			switch (spriteObjects[0].currentVariantHash)
			{
			default:
				beamStartPosition = beamStartPositionDown.position;
				break;
			case 595663797:
				beamStartPosition = beamStartPositionSide.position;
				break;
			case 1133833840:
				beamStartPosition = beamStartPositionUp.position;
				break;
			}
			EntityMonoBehaviour entityMono = Manager.memory.GetEntityMono(targetEntity);
			if (!(entityMono != null))
			{
				return;
			}
			{
				foreach (LineRenderer beam in beams)
				{
					beam.gameObject.SetActive(value: true);
					beam.SetPosition(0, beamStartPosition);
					beam.SetPosition(1, entityMono.center);
				}
				return;
			}
		}
		foreach (LineRenderer beam2 in beams)
		{
			beam2.gameObject.SetActive(value: false);
		}
	}
}
