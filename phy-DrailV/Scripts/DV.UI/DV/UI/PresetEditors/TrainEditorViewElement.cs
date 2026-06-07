using System.ComponentModel;
using DV.Scenarios.Common;
using DV.ThingTypes;
using DV.UIFramework;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UI.PresetEditors
{
	public class TrainEditorViewElement : AViewElement<ICar>
	{
		[SerializeField]
		private Image image;

		[SerializeField]
		private Image cargoImage;

		[SerializeField]
		private Image resourceImage;

		[SerializeField]
		private GameObject lockedIcon;

		[SerializeField]
		private GameObject resourceBg;

		[SerializeField]
		private Sprite placeholderSprite;

		[SerializeField]
		private Sprite cargoPlaceholderSprite;

		private ICar data;

		private TrainEditorGridView parentView;

		public override void SetData(ICar newData, AGridView<ICar> parentView)
		{
			if (data != null)
			{
				data.PropertyChanged -= UpdateView;
				data = null;
			}
			if (newData != null)
			{
				data = newData;
				data.PropertyChanged += UpdateView;
			}
			this.parentView = parentView as TrainEditorGridView;
			UpdateView();
		}

		private void OnDestroy()
		{
			if (data != null)
			{
				data.PropertyChanged -= UpdateView;
			}
		}

		private void UpdateView(object sender = null, PropertyChangedEventArgs e = null)
		{
			TrainCarLivery trainCarLivery = data?.GetLivery();
			Sprite sprite = ((trainCarLivery != null && trainCarLivery.icon != null) ? trainCarLivery.icon : placeholderSprite);
			image.sprite = sprite;
			Vector3 localScale = image.transform.localScale;
			localScale.x = Mathf.Abs(localScale.x) * (float)((data == null || !data.Reversed) ? 1 : (-1));
			image.transform.localScale = localScale;
			CargoType_v2 cargoType_v = data?.GetCargo();
			if (cargoType_v == null)
			{
				cargoImage.enabled = false;
				resourceImage.enabled = false;
				resourceBg.SetActive(value: false);
			}
			else if (cargoType_v.icon != null && trainCarLivery != null && cargoType_v.HasVisibleModelForCarType(trainCarLivery.parentType))
			{
				cargoImage.enabled = true;
				resourceImage.enabled = false;
				resourceBg.SetActive(value: false);
				cargoImage.sprite = cargoType_v.icon;
			}
			else if (cargoType_v.resourceIcon != null)
			{
				cargoImage.enabled = false;
				resourceImage.enabled = true;
				resourceBg.SetActive(value: true);
				resourceImage.sprite = cargoType_v.resourceIcon;
			}
			else
			{
				cargoImage.enabled = false;
				resourceImage.enabled = true;
				resourceBg.SetActive(value: true);
				resourceImage.sprite = cargoPlaceholderSprite;
			}
			if (parentView != null)
			{
				lockedIcon.SetActive(!parentView.IsLiveryUnlocked(trainCarLivery));
			}
		}
	}
}
