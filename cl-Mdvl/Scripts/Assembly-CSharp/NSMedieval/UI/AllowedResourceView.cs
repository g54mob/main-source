using System;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class AllowedResourceView : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI resourceName;

		[SerializeField]
		private Toggle toggle;

		[NonSerialized]
		private Resource resource;

		[NonSerialized]
		private ProductionInstance productionInstance;

		[NonSerialized]
		private ResourceCategoryView parent;

		public bool IsOn => toggle.isOn;

		public Resource Resource => resource;

		public void Setup(Resource resource)
		{
			this.resource = resource;
			string text = ResourceUtils.GetTextIcon(resource) + " " + ResourceUtils.GetLocalizedResourceName(resource, showQuality: false);
			resourceName.text = text;
		}

		public void SetToggle(bool value)
		{
			toggle.isOn = value;
		}

		public void AddCallback(Action<bool, Resource> cb)
		{
			toggle.onValueChanged.AddListener(delegate(bool value)
			{
				cb(value, resource);
			});
		}
	}
}
