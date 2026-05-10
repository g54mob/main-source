using System;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Pooling;
using CTS.Utilities;
using NaughtyAttributes;
using UnityEngine;

namespace CTS.BBT
{
	public sealed class Drink : Item
	{
		public static readonly Func<Drink, bool> IsNotEmptyFilter = (Drink p_drink) => !p_drink.IsEmpty;

		public static readonly Func<Drink, bool> IsEmptyFilter = (Drink p_drink) => p_drink.IsEmpty;

		[SerializeField]
		private Transform _visual;

		[SerializeField]
		[MinMaxSlider(1f, 10f)]
		private Vector2Int _drinkAnimationCount = Vector2Int.one;

		[SerializeField]
		[MinMaxSlider(0f, 10f)]
		private Vector2 _cooldown = Vector2.zero;

		private static readonly Resource<Drink> DrinkPrefab = new Resource<Drink>("Pfb_DrinkTemplate");

		private DrinkMesh _fullMesh;

		private DrinkMesh _emptyMesh;

		private int _maxFill = 4;

		private int _fillAmount = 4;

		private float _cooldownNextTime;

		private static StringKey _invisibilityMatKey = "Invisibility";

		public DrinkSO DrinkData { get; private set; }

		public CustomerOrder Order { get; private set; }

		public WorkerChoreClearDrink ClearChore { get; private set; }

		public bool IsEmpty => _fillAmount <= 0;

		public bool IsFull => _fillAmount >= _maxFill;

		public int Quality { get; set; }

		public bool OnCooldown => Time.time < _cooldownNextTime;

		public static Drink Create(DrinkSO p_data, CustomerOrder p_customerOrder)
		{
			Drink drink = Pooler.Pull(DrinkPrefab.Value);
			drink.name = p_data.Name;
			drink.Order = p_customerOrder;
			drink.Quality = 5;
			drink._fillAmount = 0;
			drink.UpdateMeshes(p_data);
			return drink;
		}

		public void UpdateMeshes(DrinkSO newData)
		{
			if (!(DrinkData == newData))
			{
				DrinkData = newData;
				UpdateMeshes();
			}
		}

		public void UpdateMeshes()
		{
			if (!(DrinkData == null))
			{
				if ((bool)_fullMesh)
				{
					Pooler.Push(_fullMesh);
				}
				if ((bool)_emptyMesh)
				{
					Pooler.Push(_emptyMesh);
				}
				_fullMesh = Pooler.Pull(DrinkData.FullMeshPrefab, _visual, !IsEmpty);
				_fullMesh.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
				_fullMesh.transform.localScale = Vector3.one;
				_emptyMesh = Pooler.Pull(DrinkData.EmptyMeshPrefab, _visual, IsEmpty);
				_emptyMesh.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
				_emptyMesh.transform.localScale = Vector3.one;
				GetComponent<OutlineRendererCollection>().SetRenderer(_emptyMesh.Renderer);
				GetComponent<BarVisualObject>().RefreshComponents();
			}
		}

		public void SetFull()
		{
			_maxFill = UnityEngine.Random.Range(_drinkAnimationCount.x, _drinkAnimationCount.y);
			_fillAmount = _maxFill;
			_fullMesh.gameObject.SetActive(value: true);
			_emptyMesh.gameObject.SetActive(value: false);
			GetComponent<OutlineRendererCollection>().SetRenderer(_fullMesh.Renderer);
			StaticObjectSet<Drink>.Add(this);
		}

		public float DecrementQuantity()
		{
			_cooldownNextTime = Time.time + UnityEngine.Random.Range(_cooldown.x, _cooldown.y);
			_fillAmount = Math.Max(0, _fillAmount - 1);
			if (_fillAmount == 0)
			{
				SetEmpty();
			}
			return 1f / (float)_maxFill * DrinkData.ThirstPercent;
		}

		public void SetEmpty()
		{
			_fillAmount = 0;
			_fullMesh.gameObject.SetActive(value: false);
			_emptyMesh.gameObject.SetActive(value: true);
			GetComponent<OutlineRendererCollection>().SetRenderer(_emptyMesh.Renderer);
		}

		public void CreateClearingChore()
		{
			ClearChore?.DestroyChore();
			ClearChore = new WorkerChoreClearDrink(ChoreCategory.Cleaning, this);
			ClearChore.AddContext(this);
			if (MonoSingleton<ChoreList>.TryGetInstance(out var outInstance))
			{
				outInstance.AddToList(ClearChore);
			}
			base.gameObject.layer = LayerMask.NameToLayer("Furniture");
		}

		protected override void OnVisible()
		{
			base.OnVisible();
			_emptyMesh.SetOverrideMaterial(null);
			_fullMesh.SetOverrideMaterial(null);
		}

		protected override void OnInvisible()
		{
			base.OnInvisible();
			Material sharedMaterial = CTSSingleton<Materials>.Instance.GetSharedMaterial(_invisibilityMatKey);
			_emptyMesh.SetOverrideMaterial(sharedMaterial);
			_fullMesh.SetOverrideMaterial(sharedMaterial);
		}

		public override void Clear()
		{
			base.Clear();
			if (Order != null && (bool)Order.CustomerRef)
			{
				Order.CustomerRef.ClearOrder();
			}
			if (base.IsHeld)
			{
				base.CurrentHolder.ObjectHolding.DropObject();
			}
			ClearChore?.DestroyChore();
			Pooler.Push(this);
		}

		protected override void OnPushedToPool()
		{
			base.OnPushedToPool();
			ClearChore?.DestroyChore();
			base.gameObject.layer = LayerMask.NameToLayer("Item");
			StaticObjectSet<Drink>.Remove(this);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			StaticObjectSet<Drink>.Remove(this);
		}
	}
}
