using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KitchenData;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Kitchen
{
	public class ItemGroupView : SerializedMonoBehaviour, IItemSpecificView
	{
		[Serializable]
		public struct ComponentGroup
		{
			public Item Item;

			public GameObject GameObject;

			public List<GameObject> Objects;

			public bool DrawAll;

			[HideInInspector]
			public bool IsDrawing;

			[HideInInspector]
			public bool ShouldDraw;
		}

		[Serializable]
		public struct ColourBlindLabel
		{
			public Item Item;

			public string Text;
		}

		public Dictionary<int, ComponentGroup> DrawComponents;

		[SerializeField]
		private TextMeshPro ColourblindLabel;

		[SerializeField]
		private GameObject SubviewPrefab;

		[SerializeField]
		private GameObject SubviewContainer;

		[SerializeField]
		public List<ComponentGroup> ComponentGroups;

		[SerializeField]
		protected List<ColourBlindLabel> ComponentLabels = new List<ColourBlindLabel>();

		public bool ForceNoColourblind;

		public ItemGroupView Subview;

		private void FillColourblindLabels()
		{
			if (ComponentLabels == null)
			{
				ComponentLabels = new List<ColourBlindLabel>();
			}
			foreach (ComponentGroup componentGroup in ComponentGroups)
			{
				ComponentLabels.Add(new ColourBlindLabel
				{
					Item = componentGroup.Item,
					Text = componentGroup.Item.name.Substring(0, 1)
				});
			}
		}

		private void Start()
		{
			Setup();
		}

		private void Setup()
		{
			DrawComponents = ComponentGroups.ToDictionary((ComponentGroup e) => e.Item.ID, (ComponentGroup e) => e);
		}

		public virtual void PerformUpdate(int item_id, ItemList components, bool is_order = false)
		{
			if (SubviewPrefab != null)
			{
				if (Subview == null)
				{
					Subview = UnityEngine.Object.Instantiate(SubviewPrefab).GetComponent<ItemGroupView>();
					Transform obj = Subview.transform;
					obj.parent = SubviewContainer.transform;
					obj.localScale = Vector3.one;
					obj.localPosition = Vector3.zero;
				}
				Subview.PerformUpdate(item_id, components);
			}
			if (DrawComponents == null)
			{
				Setup();
			}
			foreach (KeyValuePair<int, ComponentGroup> drawComponent in DrawComponents)
			{
				if (drawComponent.Value.Objects != null && drawComponent.Value.Objects.Count > 0)
				{
					foreach (GameObject @object in drawComponent.Value.Objects)
					{
						@object.SetActive(value: false);
					}
				}
				else if (drawComponent.Value.GameObject != null)
				{
					drawComponent.Value.GameObject.SetActive(value: false);
				}
			}
			AddComponent(item_id);
			foreach (int item in components)
			{
				AddComponent(item);
			}
			if (ColourblindLabel != null && ComponentLabels != null)
			{
				if (!ForceNoColourblind)
				{
					StringBuilder stringBuilder = new StringBuilder();
					foreach (ColourBlindLabel componentLabel in ComponentLabels)
					{
						foreach (int item2 in components)
						{
							if (componentLabel.Item.ID == item2)
							{
								stringBuilder.Append(componentLabel.Text);
							}
						}
					}
					ColourblindLabel.text = stringBuilder.ToString();
				}
				else
				{
					ColourblindLabel.text = "";
				}
			}
			if (ForceNoColourblind)
			{
				ColourBlindMode[] componentsInChildren = GetComponentsInChildren<ColourBlindMode>();
				foreach (ColourBlindMode obj2 in componentsInChildren)
				{
					obj2.ShowInColourblindMode = false;
					obj2.ShowInNonColourblindMode = false;
				}
			}
		}

		private void AddComponent(int id)
		{
			if (!DrawComponents.TryGetValue(id, out var value))
			{
				return;
			}
			if (value.Objects != null && value.Objects.Count > 0)
			{
				foreach (GameObject @object in value.Objects)
				{
					if (!@object.activeSelf)
					{
						@object.SetActive(value: true);
						if (!value.DrawAll)
						{
							break;
						}
					}
				}
				return;
			}
			value.GameObject.SetActive(value: true);
		}
	}
}
