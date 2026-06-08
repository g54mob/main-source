using System.Collections;
using System.Collections.Generic;
using KitchenData;
using UnityEngine;

namespace Kitchen
{
	public class MenuBackgroundItemScroller : MonoBehaviour
	{
		public List<Item> Items = new List<Item>();

		public Vector3 StartLineA;

		public Vector3 StartLineB;

		public GameObject Backdrop;

		private bool IsCreated;

		private int Index;

		public List<Vector3> ItemLocations = new List<Vector3>();

		private void Start()
		{
			Camera main = Camera.main;
			if (!(main == null))
			{
				base.transform.parent = main.transform;
				base.transform.Reset();
				Vector3[] array = new Vector3[4];
				main.CalculateFrustumCorners(new Rect(0f, 0f, 1f, 1f), main.farClipPlane, Camera.MonoOrStereoscopicEye.Mono, array);
				StartLineA = array[0];
				StartLineB = array[2];
				Backdrop.transform.localPosition = new Vector3(0f, 0f, StartLineA.z * 0.999f);
				Items.ShuffleInPlace();
			}
		}

		private void Update()
		{
			if (GameData.Main != null && !IsCreated)
			{
				IsCreated = true;
				StartCoroutine(CreateRows());
			}
		}

		private IEnumerator CreateRows()
		{
			ItemLocations.Clear();
			float num = (StartLineA.x + StartLineB.x) / 2f;
			for (float num2 = Mathf.Floor(StartLineA.x); num2 < Mathf.Ceil(StartLineB.x) + 0.5f; num2 += 1f)
			{
				if (Mathf.Abs(num2 - (StartLineA.x + StartLineB.x) / 2f) < 4.5f)
				{
					continue;
				}
				for (float num3 = StartLineA.y; num3 < StartLineB.y; num3 += 1f)
				{
					float num4 = 2f * Mathf.Abs(num - num2) / Mathf.Abs(num - StartLineA.x);
					if (Random.value < num4)
					{
						ItemLocations.Add(new Vector3(num2, num3, StartLineA.z) * 0.99f);
					}
				}
			}
			ItemLocations.ShuffleInPlace();
			int i = 0;
			foreach (Vector3 itemLocation in ItemLocations)
			{
				CreateItem(itemLocation);
				if (i++ % 10 == 0)
				{
					yield return null;
				}
			}
		}

		private GameObject CreateItem(Vector3 pos, int index = -1)
		{
			Item item = Items[(index > -1) ? index : (Index++ % Items.Count)];
			GameObject obj = Object.Instantiate(item.Prefab, base.transform, worldPositionStays: true);
			obj.transform.localPosition = pos;
			obj.transform.localRotation = Quaternion.AngleAxis(Random.value * 360f, Vector3.back) * Quaternion.LookRotation(Vector3.up, Vector3.back);
			if (obj.TryGetComponent<ItemGroupView>(out var component))
			{
				ItemList randomConfiguration = GameData.Main.ItemSetView.GetRandomConfiguration(item.ID, null, allow_any: true);
				component.ForceNoColourblind = true;
				component.PerformUpdate(item.ID, randomConfiguration);
			}
			return obj;
		}
	}
}
