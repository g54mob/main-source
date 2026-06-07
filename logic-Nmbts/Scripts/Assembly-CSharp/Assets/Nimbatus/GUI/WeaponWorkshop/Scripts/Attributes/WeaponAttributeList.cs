using System.Linq;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Emitters;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.GUI.WeaponWorkshop.Scripts.Attributes
{
	public class WeaponAttributeList : SerializedMonoBehaviour
	{
		public FloatAttributeDisplay FloatAttributePrefab;

		public UIGrid AttributeContainer;

		public void Fill(Emitter emitter)
		{
			(from Transform child in AttributeContainer.transform
				select child.gameObject).ToList().ForEach(Object.DestroyImmediate);
			if (emitter == null)
			{
				return;
			}
			foreach (WeaponAttribute item in emitter.Attributes.Where((WeaponAttribute i) => !i.Hidden).ToList())
			{
				FloatWeaponAttribute floatWeaponAttribute = item as FloatWeaponAttribute;
				if (floatWeaponAttribute != null)
				{
					FloatAttributeDisplay floatAttributeDisplay = Object.Instantiate(FloatAttributePrefab);
					floatAttributeDisplay.Init(floatWeaponAttribute);
					floatAttributeDisplay.transform.position = AttributeContainer.transform.position;
					floatAttributeDisplay.transform.parent = AttributeContainer.transform;
					floatAttributeDisplay.transform.localScale = FloatAttributePrefab.transform.localScale;
				}
			}
			AttributeContainer.Reposition();
			AttributeContainer.enabled = false;
		}
	}
}
