using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts
{
	public abstract class BindableDronePart : DronePart
	{
		internal List<KeyBinding> KeyBindings;

		protected override void Awake()
		{
			base.Awake();
			KeyBindings = GetKeyBindings();
		}

		public abstract List<KeyBinding> GetKeyBindings();

		public override NimbatusItemData CreateData()
		{
			return new BindableDronePartData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			BindableDronePartData bindableDronePartData = data as BindableDronePartData;
			if (bindableDronePartData == null || KeyBindings == null)
			{
				return;
			}
			bindableDronePartData.KeyBindings = new List<KeyBindingData>();
			foreach (KeyBinding keyBinding in KeyBindings)
			{
				bindableDronePartData.KeyBindings.Add(keyBinding.GetSaveData());
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			BindableDronePartData bindableDronePartData = data as BindableDronePartData;
			if (bindableDronePartData == null)
			{
				return;
			}
			KeyBindings = GetKeyBindings();
			if (bindableDronePartData.KeyBindings == null)
			{
				return;
			}
			foreach (KeyBindingData kb in bindableDronePartData.KeyBindings)
			{
				KeyBinding keyBinding = KeyBindings.FirstOrDefault((KeyBinding k) => k.Name == kb.Name);
				if (keyBinding != null)
				{
					keyBinding.Load(kb);
				}
			}
		}
	}
}
