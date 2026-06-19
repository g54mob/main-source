using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class MapBarrierController : MonoBehaviour
{
	public List<CostStack> OpenBoundryCosts;

	[SerializeField]
	private PaymentGroup _payment;

	[SerializeField]
	private PaymentCollector _paymentCollector;

	[SerializeField]
	private MapBarrierTerminalUI _terminalUI;

	public bool Completed;

	public MapBarrierWall MapBarrierWall;

	public MapBarrierBrazier Brazier;

	public EventReference CompleteSound;

	public Checkpoint Checkpoint;

	public PaymentGroup Payment => null;

	private void Start()
	{
	}

	public void Initiate()
	{
	}

	public void Complete()
	{
	}
}
