using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Wallet))]
public class WalletAccelerationReaction : ItemAccelerationReaction
{
	public float coinSpawnCooldown = 0.3f;

	private Vector3 offset = new Vector3(-0.06f, 0f, 0f);

	private Coroutine spawnCoro;

	private IMoney wallet;

	private bool canSpawnCoin = true;

	protected override void Start()
	{
		base.Start();
		wallet = GetComponent<Wallet>();
	}

	protected override void TryReactToAcceleration()
	{
		Vector3 worldAccelerationEstimate = velocityEstimator.GetWorldAccelerationEstimate();
		if (wallet.Amount >= 1.0 && canSpawnCoin && canReactToAcceleration && CheckAccelerationAlignmentToWalletOpening(worldAccelerationEstimate))
		{
			DoReactToAcceleration();
		}
	}

	private bool CheckAccelerationAlignmentToWalletOpening(Vector3 acceleration)
	{
		return Vector3.Dot(acceleration, base.transform.right) > accelerationThreshold;
	}

	private void DoReactToAcceleration()
	{
		Coin coin = Coin.MakeCoin();
		offset.z = Random.Range(-0.05f, 0.05f);
		coin.transform.position = base.transform.TransformPoint(offset);
		coin.transform.rotation = base.transform.rotation;
		wallet.TrySpend(coin.Amount);
		if (spawnCoro != null)
		{
			StopCoroutine(spawnCoro);
		}
		spawnCoro = StartCoroutine(DelayNextCoinSpawn());
	}

	private IEnumerator DelayNextCoinSpawn()
	{
		canSpawnCoin = false;
		yield return WaitFor.Seconds(coinSpawnCooldown);
		canSpawnCoin = true;
		spawnCoro = null;
	}
}
