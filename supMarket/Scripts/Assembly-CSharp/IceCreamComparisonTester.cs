using System;
using UnityEngine;

public class IceCreamComparisonTester : MonoBehaviour
{
	[Serializable]
	public class FlavourCountPair
	{
		public IceCreamFlavour Flavour;

		public int Count;
	}

	[Header("A")]
	public FlavourCountPair[] APairs;

	public IceCreamTopping ATopping;

	public int AConeIndex;

	[Header("B")]
	public FlavourCountPair[] BPairs;

	public IceCreamTopping BTopping;

	public int BConeIndex;

	private void Test()
	{
	}
}
