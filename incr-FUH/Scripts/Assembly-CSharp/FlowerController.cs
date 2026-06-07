using System;
using System.Collections.Generic;
using UnityEngine;

public class FlowerController : MonoBehaviour
{
	public Flower FirstFlower;

	public List<Flower> OtherFlowers = new List<Flower>();

	private int _cachedTotal;

	private void Start()
	{
		for (int i = 0; i < 20; i++)
		{
			Flower flower = UnityEngine.Object.Instantiate(FirstFlower, base.transform.position, Quaternion.identity, base.transform);
			flower.transform.position = new Vector3(FirstFlower.transform.position.x - (float)(i + 1) * 7f, FirstFlower.transform.position.y, FirstFlower.transform.position.z);
			OtherFlowers.Add(flower);
		}
	}

	private void Update()
	{
		if (_cachedTotal == House.GlobalInfo.CanHappyLongerAttribute.Level + House.GlobalInfo.CanNormalLongerAttribute.Level)
		{
			return;
		}
		_cachedTotal = House.GlobalInfo.CanHappyLongerAttribute.Level + House.GlobalInfo.CanNormalLongerAttribute.Level;
		int level = (int)MathF.Ceiling((float)_cachedTotal / 20f * 5f);
		FirstFlower.SetLevel(level);
		foreach (Flower otherFlower in OtherFlowers)
		{
			otherFlower.SetLevel(level);
		}
	}
}
