using Aggro.Core;
using Aggro.Core.Networking;
using FMODUnity;
using UnityEngine;
using UnityEngine.UI;

public class ShiftProceedArea : EntityBehaviourBase
{
	public Bounds areaBounds;

	public MeshRenderer zoneMesh;

	public Image[] playerImages;

	public Sprite playerMissing;

	public Sprite playerHere;

	private ObjectQuery<VehicleController> _vehicleQuery;

	private bool _requested;

	private MaterialPropertyBlock _zoneMpb;

	public StudioEventEmitter proceedSfxEmitter;

	private static readonly int UV1_WIPE = Shader.PropertyToID("_UV1Wipe");

	protected override void OnEntityCreated()
	{
		_zoneMpb = new MaterialPropertyBlock();
		_vehicleQuery = base.entityManager.CreateObjectQuery<VehicleController>();
	}

	protected override void OnUpdateSimulation()
	{
		if (GameUtil.isLobby || GameUtil.isTutorial || (GameUtil.isRun && NetworkAggroManagerBase<ShiftManager>.instance.GetShiftPhase() == ShiftPhase.BreakRoom))
		{
			if (GameUtil.TryGetLocalPlayer(out var player) && !NetworkAggroManagerBase<ShiftManager>.instance.isTransitioning)
			{
				PlayerStress playerStress = player.GetObject<PlayerStress>();
				Vector3 point = base.entity.transform.InverseTransformPoint(player.transform.position);
				bool flag = areaBounds.Contains(point);
				if (_requested)
				{
					if (!flag || playerStress.crashingOut)
					{
						_requested = false;
						NetworkAggroManagerBase<PlayersManager>.instance.RequestCancel();
					}
				}
				else if (flag && !playerStress.crashingOut)
				{
					_requested = true;
					NetworkAggroManagerBase<PlayersManager>.instance.RequestProceed();
				}
			}
			else
			{
				_requested = false;
			}
		}
		else
		{
			_requested = false;
		}
		_zoneMpb.SetFloat(UV1_WIPE, 1f - NetworkAggroManagerBase<PlayersManager>.instance.GetNormalizedProceedValue());
		zoneMesh.SetPropertyBlock(_zoneMpb);
	}

	protected override void OnUpdatePresentation()
	{
		Image[] array = playerImages;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].gameObject.SetActive(value: false);
		}
		_vehicleQuery.Run();
		for (int j = 0; j < _vehicleQuery.count; j++)
		{
			playerImages[j].gameObject.SetActive(value: true);
		}
		for (int k = 0; k < playerImages.Length; k++)
		{
			if (NetworkAggroManagerBase<PlayersManager>.instance.proceededLastTimer || k <= NetworkAggroManagerBase<PlayersManager>.instance.GetNumberPlayersProceeding() - 1)
			{
				playerImages[k].sprite = playerHere;
			}
			else
			{
				playerImages[k].sprite = playerMissing;
			}
		}
		proceedSfxEmitter.SetParameter("confirm-hold-BR", NetworkAggroManagerBase<PlayersManager>.instance.GetNormalizedProceedValue());
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.matrix = base.transform.localToWorldMatrix;
		Gizmos.DrawWireCube(areaBounds.center, areaBounds.size);
	}
}
