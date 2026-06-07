using System;
using DV.Utils;
using Unity.Entities;
using UnityEngine;

public sealed class DistanceLod : MonoBehaviour
{
	public Func<ushort[]> GetLodThresholds;

	public byte CurrentLod { get; private set; }

	public DVConvertToEntity ConvertToEntity { get; private set; }

	public event Action<byte> OnLodChanged;

	private void Awake()
	{
		if (!base.gameObject.TryGetComponent<DVConvertToEntity>(out var component))
		{
			component = base.gameObject.AddComponent<DVConvertToEntity>();
		}
		component.OnConverted += delegate(EntityManager entityManager, Entity entity)
		{
			entityManager.AddComponentObject(entity, this);
		};
		ConvertToEntity = component;
	}

	public void SetLod(byte lod)
	{
		CurrentLod = lod;
		this.OnLodChanged?.Invoke(CurrentLod);
	}
}
