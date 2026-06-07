using System;
using UnityEngine;

[Serializable]
public struct TestItemEntry
{
	[Tooltip("Test item")]
	public T_ItemSO item;

	[Tooltip("Bu itemden kaç adet ekleneceği (Y tuşu için)")]
	public int count;
}
