using System.Collections.Generic;
using KitchenData;
using UnityEngine;

namespace Kitchen.Modules
{
	public class DecorationBonusSetElement : Element
	{
		public Vector3 StartOffset;

		public DecorationLocalisation Localisation;

		public DecorationBonusElement Template;

		[HideInInspector]
		public List<DecorationBonusElement> Modules = new List<DecorationBonusElement>();

		public override Bounds BoundingBox => default(Bounds);

		public void Set(DecorationType type)
		{
			int index = 0;
			for (int i = 1; i <= 3; i++)
			{
				SetModule(index++, type, i, 0);
			}
			ClearAfterIndex(index);
		}

		public void Set(DecorationValues values)
		{
			int index = 0;
			DecorationType[] types = DecorationValues.Types;
			foreach (DecorationType decorationType in types)
			{
				if (values[decorationType] > 0)
				{
					int num = Mathf.Clamp(values.GetBonusLevel(decorationType) + 1, 1, 3);
					for (int j = 1; j <= num; j++)
					{
						SetModule(index++, decorationType, j, values[decorationType]);
					}
				}
			}
			ClearAfterIndex(index);
		}

		private void SetModule(int index, DecorationType type, int level, int progress)
		{
			DecorationBonusElement decorationBonusElement = ModuleAtIndex(index);
			DecorationBonus b = DecorationValues.Bonus(type, level);
			decorationBonusElement.Set(Localisation[b], type, progress, level * 3);
		}

		private void ClearAfterIndex(int index)
		{
			for (int i = index; i < Modules.Count; i++)
			{
				Modules[i].Destroy();
			}
			Modules.RemoveRange(index, Modules.Count - index);
		}

		private DecorationBonusElement ModuleAtIndex(int index)
		{
			if (index < Modules.Count)
			{
				return Modules[index];
			}
			DecorationBonusElement decorationBonusElement = Object.Instantiate(Template);
			Transform obj = decorationBonusElement.transform;
			obj.parent = base.transform;
			obj.localScale = Vector3.one;
			obj.localRotation = Quaternion.identity;
			Bounds bounds = ((index > 0) ? Modules[index - 1].BoundingBox : new Bounds(StartOffset, Vector3.zero));
			obj.localPosition = bounds.center - new Vector3(0f, bounds.size.y + 0.2f, 0f);
			Modules.Add(decorationBonusElement);
			return decorationBonusElement;
		}
	}
}
