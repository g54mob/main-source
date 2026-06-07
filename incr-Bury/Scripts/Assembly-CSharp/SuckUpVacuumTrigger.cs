using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Events;

public class SuckUpVacuumTrigger : MonoBehaviour
{
	[SerializeField]
	private List<Rigidbody> suckUpsToSuck = new List<Rigidbody>();

	[SerializeField]
	private float suckStrength;

	[SerializeField]
	private float depositDist_Threshold;

	[Header("Feedbacks")]
	[SerializeField]
	private MMF_Player feedback_OnDeposit;

	[Header("Deposited Function")]
	public UnityEvent onSuckUp_Deposit;

	private SuckUppables suckuppableCurrent;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
		if (suckUpsToSuck.Count <= 0)
		{
			return;
		}
		Vector3 zero = Vector3.zero;
		for (int num = suckUpsToSuck.Count - 1; num >= 0; num--)
		{
			if ((bool)suckUpsToSuck[num])
			{
				if (Vector3.Distance(base.transform.position, suckUpsToSuck[num].transform.position) <= depositDist_Threshold)
				{
					try
					{
						suckuppableCurrent = suckUpsToSuck[num].GetComponent<SuckUppables>();
					}
					catch
					{
					}
					onSuckUp_Deposit?.Invoke();
					feedback_OnDeposit?.PlayFeedbacks();
				}
				else
				{
					zero = (base.transform.position - suckUpsToSuck[num].transform.position).normalized;
					suckUpsToSuck[num].AddForce(zero * suckStrength, ForceMode.Force);
				}
			}
			else
			{
				suckUpsToSuck.RemoveAt(num);
			}
		}
	}

	public void DepositSuckUpIntoPiggyBank()
	{
		if ((bool)suckuppableCurrent)
		{
			if (suckuppableCurrent.identity == ItemIdentity.Coin)
			{
				Coin component = suckuppableCurrent.GetComponent<Coin>();
				component.CalculateCoinValue();
				PlayerStats.Singleton.AddMoneyToPiggyBank(component.GetCoinValue());
			}
			else if (suckuppableCurrent.identity == ItemIdentity.Seed)
			{
				PlayerStats.Singleton.IncreaseSeeds(1);
			}
			Object.Destroy(suckuppableCurrent.gameObject);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.transform.root.CompareTag("SuckUppable") && other.gameObject.transform.root.GetComponent<SuckUppables>().CanBeSuckedUp)
		{
			suckUpsToSuck.Add(other.GetComponentInParent<Rigidbody>());
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.transform.root.CompareTag("SuckUppable"))
		{
			suckUpsToSuck.Remove(other.GetComponentInParent<Rigidbody>());
		}
	}
}
