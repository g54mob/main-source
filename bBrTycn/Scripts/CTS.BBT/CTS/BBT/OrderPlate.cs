using System;
using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Pooling;
using CTS.Utilities;
using DG.Tweening;
using UnityEngine;

namespace CTS.BBT
{
	[Constructor("Construct")]
	public class OrderPlate : Item
	{
		[SerializeField]
		private float _fadeDuration = 0.75f;

		[SerializeField]
		private AnimationCurve _fadeCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[SerializeField]
		public PlateSlot[] DrinkSlots;

		[InjectScope(EGetScope.Children)]
		[Inject(false)]
		private Renderer _renderer;

		public static readonly Func<OrderPlate, bool> HasNoCleanDrinks = delegate(OrderPlate plate)
		{
			foreach (Drink drink in plate.Drinks)
			{
				if (!drink.IsEmpty)
				{
					return false;
				}
			}
			return true;
		};

		private Material _originalMat;

		private static StringKey _invisibilityMatKey = "Invisibility";

		public GroupOrder Order { get; set; }

		public List<Drink> Drinks { get; } = new List<Drink>();

		private void Construct([InjectScope(EGetScope.Children)] Renderer meshRenderer)
		{
			_originalMat = meshRenderer.material;
			meshRenderer.material = _originalMat;
		}

		protected override void OnAwake()
		{
			PlateSlot[] drinkSlots = DrinkSlots;
			for (int i = 0; i < drinkSlots.Length; i++)
			{
				drinkSlots[i].SetPlate(this);
			}
		}

		public bool Contains(Drink drink)
		{
			return Drinks.Contains(drink);
		}

		public void AddDrink(Drink drink)
		{
			if (!Drinks.Contains(drink))
			{
				Drinks.Add(drink);
				drink.RoomObject.SetParent(base.RoomObject);
				drink.Place(DrinkSlots[Drinks.Count - 1]);
				if (!base.IsVisible)
				{
					drink.SetVisible(isVisible: false);
				}
			}
		}

		public void RemoveDrink(Drink drink)
		{
			if (Drinks.Remove(drink))
			{
				drink.transform.SetParent(null);
				drink.RoomObject.SetParent(null);
				drink.InSlot.SetUnused();
			}
			Drinks.Remove(drink);
			if (!base.IsVisible)
			{
				drink.SetVisible(isVisible: true);
			}
		}

		public void DoFade()
		{
			base.transform.DOScaleX(0f, _fadeDuration).SetEase(_fadeCurve);
			base.transform.DOScaleZ(0f, _fadeDuration).SetEase(_fadeCurve);
			base.transform.DOScaleY(2f, _fadeDuration).SetEase(_fadeCurve);
		}

		public void ClearAll()
		{
			while (Drinks.Count > 0)
			{
				Drink drink = Drinks[0];
				if (!base.IsVisible)
				{
					drink.SetVisible(isVisible: true);
				}
				drink.Clear();
				Drinks.Remove(drink);
			}
			Pooler.Push(this);
		}

		protected override void OnVisible()
		{
			base.OnVisible();
			_renderer.material = _originalMat;
			foreach (Drink drink in Drinks)
			{
				drink.SetVisible(isVisible: true);
			}
		}

		protected override void OnInvisible()
		{
			base.OnInvisible();
			foreach (Drink drink in Drinks)
			{
				drink.SetVisible(isVisible: false);
			}
			Material sharedMaterial = CTSSingleton<Materials>.Instance.GetSharedMaterial(_invisibilityMatKey);
			_renderer.material = sharedMaterial;
		}

		protected override void OnPulledFromPool()
		{
			base.OnPulledFromPool();
			StaticObjectSet<OrderPlate>.Add(this);
		}

		protected override void OnPushedToPool()
		{
			base.OnPushedToPool();
			base.transform.localScale = Vector3.one;
			StaticObjectSet<OrderPlate>.Remove(this);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			StaticObjectSet<OrderPlate>.Remove(this);
		}
	}
}
