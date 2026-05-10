using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;

public class IceCreamCone : MonoBehaviour, IPoolable
{
	[SerializeField]
	private int m_ConeIndex;

	[SerializeField]
	private IceCreamFlavourInstance m_FlavourBallPrefab;

	[SerializeField]
	private float m_ToppingOffset;

	[SerializeField]
	private Vector3 m_FlavourLocalOffset;

	private List<IceCreamFlavourInstance> m_Flavours;

	private IceCreamTopping m_Topping;

	private GameObject m_ToppingInstance;

	public IReadOnlyList<IceCreamFlavourInstance> Flavours => null;

	public int FlavourCount => 0;

	public bool HasTopping => false;

	public IceCreamTopping Topping => null;

	public void AddFlavour(IceCreamFlavour flavour)
	{
	}

	public void AddFlavourAndAnimate(IceCreamFlavour flavour, Vector3 animateFrom, Quaternion animateFromRot)
	{
	}

	private Vector3 GetFlavourLocalPosition(int index)
	{
		return default(Vector3);
	}

	public void OnSpawn()
	{
	}

	public void OnDespawn()
	{
	}

	public void AddTopping(IceCreamTopping topping)
	{
	}

	public int GetFlavourCount(IceCreamFlavour ofFlavour)
	{
		return 0;
	}

	public IceCreamStatus CreateStatus()
	{
		return default(IceCreamStatus);
	}
}
