using UnityEngine;

public class T_DartboardInteractable : InteractableBase
{
	[SerializeField]
	private int dartsPerRound = 5;

	public T_Dartboard dartboard;

	public override bool CanInteractPrimary()
	{
		Debug.Log($"[DartboardInteractable] CanInteractPrimary çağrıldı - dartboard: {dartboard != null}");
		if (dartboard == null)
		{
			return false;
		}
		T_DartManager localDartManager = GetLocalDartManager();
		Debug.Log($"[DartboardInteractable] dartManager: {localDartManager != null}, IsInDartGame: {localDartManager != null && localDartManager.IsInDartGame}");
		if (localDartManager != null && localDartManager.IsInDartGame)
		{
			return false;
		}
		bool flag = GameManager.Instance != null && GameManager.Instance.localEquipments != null && GameManager.Instance.localEquipments.pickupItem != null;
		Debug.Log($"[DartboardInteractable] hasPickup: {flag}");
		if (flag)
		{
			return false;
		}
		Debug.Log("[DartboardInteractable] CanInteractPrimary -> true");
		return true;
	}

	public override void OnPrimaryInteracted()
	{
		Debug.Log("[DartboardInteractable] OnPrimaryInteracted çağrıldı!");
		T_DartManager localDartManager = GetLocalDartManager();
		Debug.Log($"[DartboardInteractable] dartManager: {localDartManager != null}, dartboard: {dartboard != null}");
		if (localDartManager == null)
		{
			Debug.LogWarning("[DartboardInteractable] dartManager NULL! localEquipments.dartManager atanmamış olabilir.");
			return;
		}
		localDartManager.GiveDarts(dartboard, dartsPerRound);
		Debug.Log($"[DartboardInteractable] GiveDarts çağrıldı - dartsPerRound: {dartsPerRound}");
	}

	public override bool CanInteractSecondary()
	{
		return dartboard != null;
	}

	public override void OnSecondaryInteracted()
	{
		if (!(dartboard == null))
		{
			dartboard.CmdResetScore();
		}
	}

	private T_DartManager GetLocalDartManager()
	{
		if (GameManager.Instance == null)
		{
			return null;
		}
		if (GameManager.Instance.localEquipments == null)
		{
			return null;
		}
		return GameManager.Instance.localEquipments.dartManager;
	}
}
