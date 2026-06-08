using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	[ExecuteInEditMode]
	public class UIManagerAnimatedIcon : MonoBehaviour
	{
		public UIManager UIManagerAsset;

		public List<GameObject> images = new List<GameObject>();

		public List<GameObject> imagesWithAlpha = new List<GameObject>();

		private bool dynamicUpdateEnabled;

		private void OnEnable()
		{
			if (UIManagerAsset == null)
			{
				try
				{
					UIManagerAsset = Resources.Load<UIManager>("MUIP Manager");
				}
				catch
				{
					Debug.Log("No UI Manager found. Assign it manually, otherwise you'll get errors about it.", this);
				}
			}
		}

		private void Awake()
		{
			if (!dynamicUpdateEnabled)
			{
				base.enabled = true;
				UpdateAnimatedIcon();
			}
		}

		private void LateUpdate()
		{
			if (Application.isEditor && UIManagerAsset != null)
			{
				if (UIManagerAsset.enableDynamicUpdate)
				{
					dynamicUpdateEnabled = true;
					UpdateAnimatedIcon();
				}
				else
				{
					dynamicUpdateEnabled = false;
				}
			}
		}

		private void UpdateAnimatedIcon()
		{
			for (int i = 0; i < images.Count; i++)
			{
				images[i].GetComponent<Image>().color = UIManagerAsset.animatedIconColor;
			}
			for (int j = 0; j < imagesWithAlpha.Count; j++)
			{
				Image component = imagesWithAlpha[j].GetComponent<Image>();
				component.color = new Color(UIManagerAsset.animatedIconColor.r, UIManagerAsset.animatedIconColor.g, UIManagerAsset.animatedIconColor.b, component.color.a);
			}
		}
	}
}
