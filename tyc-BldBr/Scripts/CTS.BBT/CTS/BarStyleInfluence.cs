using System;
using System.Collections.Generic;
using System.Linq;
using CTS.BBT;
using UnityEngine;

namespace CTS
{
	public class BarStyleInfluence : StyleInfluence<EBarStyle, BarStyleInfluence>
	{
		[SerializeField]
		private bool _debug;

		public List<BarStyleValues> MainBarStyles { get; private set; } = new List<BarStyleValues>();

		public float HighestInfluence
		{
			get
			{
				if (base.StyleInfluences.Count == 0)
				{
					return 0f;
				}
				return base.StyleInfluences.OrderBy((KeyValuePair<EBarStyle, float> x) => x.Value).ToList()[0].Value;
			}
		}

		public float TotalInfluence
		{
			get
			{
				float num = 0f;
				foreach (KeyValuePair<EBarStyle, float> styleInfluence in base.StyleInfluences)
				{
					num += styleInfluence.Value;
				}
				return num;
			}
		}

		public static event Action<BarStyleInfluence> StylesInfluenceChanged;

		public static event Action<List<BarStyleValues>> OnMainStylesInfluenceChanged;

		protected override void OnDisabled()
		{
			Furniture.FurnitureAdded -= OnFurnitureAdded;
			Furniture.FurnitureRemoved -= OnFurnitureRemoved;
			BuildablePlacementSystem.OnBuildablePlaced -= OnBuildableAdded;
			BuildableElement.Destroyed -= OnBuildableRemoved;
			StylesInfluenceChanged -= UpdateMainsInfluences;
			base.StyleInfluences.Clear();
		}

		protected override void OnEnabled()
		{
			foreach (Furniture item in StaticObjectSet<Furniture>.List)
			{
				OnFurnitureAdded(item);
			}
			Furniture.FurnitureAdded += OnFurnitureAdded;
			Furniture.FurnitureRemoved += OnFurnitureRemoved;
			BuildablePlacementSystem.OnBuildablePlaced += OnBuildableAdded;
			BuildableElement.Destroyed += OnBuildableRemoved;
			StylesInfluenceChanged += UpdateMainsInfluences;
			UpdateMainsInfluences(this);
		}

		public void ReLoad()
		{
			foreach (BuildableElement item in StaticObjectSet<BuildableElement>.List)
			{
				OnBuildableAdded(item);
			}
			foreach (Furniture item2 in StaticObjectSet<Furniture>.List)
			{
				OnFurnitureAdded(item2);
			}
		}

		private void OnFurnitureRemoved(Furniture furniture)
		{
			EBarStyle style = furniture.Parameters.Style;
			if (style != EBarStyle.None && furniture.Parameters.Influence != 0f)
			{
				RemoveInfluence(style, furniture.Parameters.Influence);
				BarStyleInfluence.StylesInfluenceChanged?.Invoke(this);
			}
		}

		private void OnFurnitureAdded(Furniture furniture)
		{
			EBarStyle style = furniture.Parameters.Style;
			if (style != EBarStyle.None && furniture.Parameters.Influence != 0f)
			{
				AddInfluence(style, furniture.Parameters.Influence);
				BarStyleInfluence.StylesInfluenceChanged?.Invoke(this);
			}
		}

		private void OnBuildableRemoved(BuildableElement buildable)
		{
			EBarStyle style = buildable.BuildableElementSO.Style;
			if (style != EBarStyle.None && buildable.BuildableElementSO.Influence != 0f)
			{
				RemoveInfluence(style, buildable.BuildableElementSO.Influence);
				BarStyleInfluence.StylesInfluenceChanged?.Invoke(this);
			}
		}

		private void OnBuildableAdded(BuildableElement buildable)
		{
			EBarStyle style = buildable.BuildableElementSO.Style;
			if (style != EBarStyle.None && buildable.BuildableElementSO.Influence != 0f)
			{
				AddInfluence(style, buildable.BuildableElementSO.Influence);
				BarStyleInfluence.StylesInfluenceChanged?.Invoke(this);
			}
		}

		private void OnPaintingChanged(SurfaceData oldSurface, SurfaceData newSurface)
		{
			UpdatePaint(oldSurface, toAdd: false);
			UpdatePaint(newSurface, toAdd: true);
			BarStyleInfluence.StylesInfluenceChanged?.Invoke(this);
		}

		private void UpdatePaint(SurfaceData paint, bool toAdd)
		{
			if (paint.Style != EBarStyle.None && paint.Influence != 0f)
			{
				if (toAdd)
				{
					AddInfluence(paint.Style, paint.Influence);
				}
				else
				{
					RemoveInfluence(paint.Style, paint.Influence);
				}
			}
		}

		public float GetStyleInfluence(params EBarStyle[] barStyle)
		{
			float num = 0f;
			foreach (EBarStyle key in barStyle)
			{
				if (base.StyleInfluences.ContainsKey(key))
				{
					num += base.StyleInfluences[key];
				}
			}
			return num;
		}

		private void UpdateMainsInfluences(BarStyleInfluence obj)
		{
			List<KeyValuePair<EBarStyle, float>> list = obj.StyleInfluences.OrderBy((KeyValuePair<EBarStyle, float> x) => x.Value).ToList();
			MainBarStyles.Clear();
			int num = list.Count - 1;
			int num2 = 0;
			while (num >= 0 && num2 < 5)
			{
				MainBarStyles.Add(new BarStyleValues
				{
					_style = list[num].Key,
					_value = list[num].Value
				});
				num--;
				num2++;
			}
			foreach (BarStyleValues mainBarStyle in MainBarStyles)
			{
				_ = mainBarStyle;
			}
			BarStyleInfluence.OnMainStylesInfluenceChanged?.Invoke(MainBarStyles);
		}

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}
	}
}
