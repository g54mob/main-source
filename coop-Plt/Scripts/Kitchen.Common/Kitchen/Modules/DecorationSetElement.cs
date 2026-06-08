using System;
using KitchenData;
using TMPro;
using UnityEngine;

namespace Kitchen.Modules
{
	public class DecorationSetElement : Element
	{
		public enum DrawMode
		{
			Normal = 0,
			Info = 1,
			Number = 2
		}

		public DecorationValueElement Prefab;

		public DecorationValueElement PrefabWithInfo;

		public DecorationValueElement PrefabNumbered;

		public Vector3 Base;

		public Vector3 Padding;

		public bool Centre;

		public bool DrawHorizontal;

		public bool DrawSigns;

		public TextMeshPro Range;

		private GameObject Container;

		public DrawMode PrefabDrawMode;

		private Bounds Bounds;

		public override Bounds BoundingBox => Bounds;

		public void SetRange(string text)
		{
			if (!(Range == null))
			{
				Range.text = text;
			}
		}

		public void SetValues(DecorationValues values)
		{
			if (Container != null)
			{
				UnityEngine.Object.Destroy(Container);
			}
			Bounds = default(Bounds);
			Container = new GameObject();
			Container.transform.parent = base.transform;
			Container.transform.localPosition = Vector3.zero;
			Container.transform.localRotation = Quaternion.identity;
			Container.transform.localScale = Vector3.one;
			Vector3 position = Base;
			foreach (DecorationType value in Enum.GetValues(typeof(DecorationType)))
			{
				if (PrefabDrawMode != DrawMode.Number)
				{
					int bonusLevel = values.GetBonusLevel(value);
					for (int i = 0; i <= bonusLevel; i++)
					{
						if ((i > 0 && PrefabDrawMode == DrawMode.Info) || (i == bonusLevel && PrefabDrawMode != DrawMode.Info))
						{
							int num = ((i == bonusLevel) ? values.GetPartialLevel(value) : 0);
							if (num > 0 || i > 0)
							{
								Element element = CreateModule(value, i, (PrefabDrawMode != DrawMode.Info) ? num : 0, position);
								Vector3 vector = (DrawHorizontal ? (Vector3.right * element.BoundingBox.size.x) : (Vector3.back * element.BoundingBox.size.y));
								position += vector + Padding;
								Bounds.Encapsulate(element.BoundingBox);
							}
						}
					}
				}
				else
				{
					int num2 = values[value];
					if (num2 != 0)
					{
						Element element2 = CreateModule(value, 0, num2, position);
						Vector3 vector2 = (DrawHorizontal ? (Vector3.right * element2.BoundingBox.size.x) : (Vector3.back * element2.BoundingBox.size.y));
						position += vector2 + Padding;
						Bounds.Encapsulate(element2.BoundingBox);
					}
				}
			}
			if (Centre)
			{
				Container.transform.localPosition = -Bounds.center;
			}
		}

		private Element CreateModule(DecorationType type, int count, int partial, Vector3 position)
		{
			DecorationValueElement decorationValueElement = UnityEngine.Object.Instantiate(PrefabDrawMode switch
			{
				DrawMode.Normal => Prefab, 
				DrawMode.Info => PrefabWithInfo, 
				DrawMode.Number => PrefabNumbered, 
				_ => Prefab, 
			}, Container.transform, worldPositionStays: true);
			decorationValueElement.Set(type, count, partial, DrawSigns);
			Transform obj = decorationValueElement.transform;
			obj.localScale = Vector3.one;
			obj.localPosition = position + Vector3.back * decorationValueElement.BoundingBox.extents.y;
			return decorationValueElement;
		}
	}
}
