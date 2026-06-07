using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute;
using UnityEngine;

namespace Assets.Nimbatus.GUI.WeaponWorkshop.Scripts.Attributes
{
	public class FloatAttributeDisplay : MonoBehaviour
	{
		public UILabel AttributeNameLabel;

		public UITexture BaseValueTexture;

		public UITexture ValueTexture;

		public GameObject PositionMarker;

		public Color PositiveColor;

		public Color NegativeColor;

		private FloatWeaponAttribute _attribute;

		public void Init(FloatWeaponAttribute attribute)
		{
			AttributeNameLabel.text = attribute.AttributeName;
			_attribute = attribute;
			UpdatePosition();
		}

		public void Update()
		{
			if (_attribute != null)
			{
				UpdatePosition();
			}
		}

		public void UpdatePosition()
		{
			float num = 1f / (_attribute.Max - _attribute.Min) * (_attribute.BaseValue - _attribute.Min);
			float num2 = 1f / (_attribute.Max - _attribute.Min) * (_attribute.Value - _attribute.Min);
			if (num > num2)
			{
				float num3 = num;
				num = num2;
				num2 = num3;
				ValueTexture.color = NegativeColor;
				PositionMarker.transform.localPosition = BaseValueTexture.transform.localPosition + new Vector3(num * (float)BaseValueTexture.width, 0f, 0f);
			}
			else
			{
				ValueTexture.color = PositiveColor;
				PositionMarker.transform.localPosition = ValueTexture.transform.localPosition + new Vector3(num2 * (float)ValueTexture.width, 0f, 0f);
			}
			BaseValueTexture.fillAmount = num;
			ValueTexture.fillAmount = num2;
		}

		public void OnTooltip(bool show)
		{
			NimbatusToolTip.Show(_attribute.ToString());
			if (!show)
			{
				NimbatusToolTip.Show(null);
			}
		}
	}
}
