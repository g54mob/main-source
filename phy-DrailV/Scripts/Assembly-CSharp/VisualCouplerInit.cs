using DV.Items;
using UnityEngine;

public class VisualCouplerInit : MonoBehaviour
{
	public Transform chain;

	public Transform hoses;

	public ChainCouplerCouplerAdapter chainAdapter;

	public CouplingHoseCouplerAdapter hoseAdapter;

	public ItemSnapPointCoupler couplerSnapPoint;

	public void Init(Coupler coupler)
	{
		chainAdapter.coupler = coupler;
		hoseAdapter.Init(coupler);
		chain.SetParent(coupler.train.interior);
		hoses.SetParent(coupler.train.interior);
		if (couplerSnapPoint != null)
		{
			couplerSnapPoint.Initialize();
		}
	}
}
