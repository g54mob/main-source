using System;
using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Common.Cursor;
using Assets.Nimbatus.Scripts.Controls.Keybinds;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Dragging;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items
{
	public abstract class NimbatusItem : NimbatusObject
	{
		[HideInInspector]
		public NimbatusItemData Data;

		public Texture2D Icon;

		public bool DoNotImport;

		public bool AlwaysUnlocked;

		[NonSerialized]
		internal bool IsStackable;

		[NonSerialized]
		internal int CurrentStackSize;

		[NonSerialized]
		internal int TemporaryUsageCount;

		public TranslationTerm CustomToolTip;

		[NonSerialized]
		internal bool Unlocked;

		[NonSerialized]
		internal bool UnlimitedStackSize;

		internal bool IsDraggable;

		[NonSerialized]
		internal bool WasGenerated;

		private tk2dSprite _sprite;

		internal Dictionary<tk2dSprite, Color> Sprites;

		internal tk2dSprite Sprite
		{
			get
			{
				return _sprite ?? (_sprite = GetComponent<tk2dSprite>());
			}
			set
			{
				_sprite = value;
			}
		}

		public virtual Texture2D GetIcon()
		{
			return Icon;
		}

		protected override void Awake()
		{
			base.Awake();
			Sprites = new Dictionary<tk2dSprite, Color>();
			tk2dSprite[] componentsInChildren = GetComponentsInChildren<tk2dSprite>();
			foreach (tk2dSprite tk2dSprite2 in componentsInChildren)
			{
				Sprites.Add(tk2dSprite2, tk2dSprite2.color);
			}
		}

		public abstract void InitStackSettings();

		public virtual void InitDronePerkSettings(List<DroneEffect> effects)
		{
		}

		public virtual void OnTooltip(bool show)
		{
			if (DragAndDropHelper.DraggedItem == null)
			{
				NimbatusToolTip.Show(GetTooltip());
				if (!show)
				{
					NimbatusToolTip.Show(null);
				}
			}
			else
			{
				NimbatusToolTip.Show(null);
			}
		}

		public virtual string GetTooltip()
		{
			string text = string.Concat(LabelHelper.Blue, Name, LabelHelper.White);
			Weapon weapon;
			TranslationTerm translationTerm = (((object)(weapon = this as Weapon) != null) ? weapon.Emitter.CustomToolTip : CustomToolTip);
			if (!string.IsNullOrEmpty(CustomToolTip.GetTranslation()))
			{
				text = text + LabelHelper.NewLine + LabelHelper.LightGrey + translationTerm;
			}
			string detailedTooltip = GetDetailedTooltip();
			if (!string.IsNullOrEmpty(detailedTooltip))
			{
				text = text + LabelHelper.NewLine + detailedTooltip;
			}
			return text;
		}

		public virtual string GetDetailedTooltip()
		{
			return "";
		}

		public virtual void OnDrag(Vector2 delta)
		{
			if (Input.GetMouseButton(0) && !Input.GetMouseButton(1) && IsDraggable && DragAndDropHelper.DraggedItem == null)
			{
				UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;
				DragAndDropHelper.DraggedItem = this;
			}
		}

		public void OnDoubleClick()
		{
			if (!BaseSingleton<KeybindManager>.Instance.GetKey(EKeybinding.MultiSelect) && IsDraggable && DragAndDropHelper.DraggedItem == null)
			{
				DragAndDropHelper.DraggedItem = this;
				IsDragged(true);
			}
		}

		public virtual void OnClick()
		{
		}

		public virtual void IsDragged(bool isDragged)
		{
			if (isDragged)
			{
				NimbatusCursor.Set(base.gameObject);
				EnableColliders(false);
			}
			else
			{
				EnableColliders(true);
			}
		}

		public void ChangeStackSize(int amount)
		{
			SetStackSize(CurrentStackSize + amount);
		}

		public void SetStackSize(int size)
		{
			CurrentStackSize = Mathf.Max(0, size);
		}

		public virtual bool ShouldBePlaced()
		{
			return true;
		}

		public virtual void Load(NimbatusItemData data)
		{
			Data = data;
			UniqueId = data.PrefabId;
		}

		public NimbatusItemData GenerateData()
		{
			NimbatusItemData data = CreateData();
			data.PrefabId = UniqueId;
			FillUpData(ref data);
			return data;
		}

		public abstract void FillUpData(ref NimbatusItemData data);

		public abstract NimbatusItemData CreateData();

		public virtual NimbatusItem Clone()
		{
			return SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.InstantiateItemFromData(GenerateData());
		}

		public virtual void PreLoad()
		{
		}

		public virtual void PostLoad()
		{
		}
	}
}
