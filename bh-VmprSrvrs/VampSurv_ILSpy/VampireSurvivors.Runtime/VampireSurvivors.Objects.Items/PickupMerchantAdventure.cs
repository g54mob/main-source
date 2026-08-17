using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.App.Data;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Items;

public class PickupMerchantAdventure : PickupCustomMerchant
{
	protected override MerchantInventoryType GetInventoryType()
	{
		return MerchantInventoryType.ADVENTURES;
	}

	public override bool IsMerchantSoldOut()
	{
		//IL_00e3: Expected I4, but got O
		//IL_0060: Expected O, but got I
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		CustomMerchantData customMerchantData = _customMerchantData;
		if (_customMerchantData != null)
		{
			List<WeaponType> validAdventureWeaponsForMerchant = ShopFactory.GetValidAdventureWeaponsForMerchant(customMerchantData._003CMerchantInventory_003Ek__BackingField, _playerOptions);
			if (validAdventureWeaponsForMerchant == null)
			{
				return true;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj = num ^ 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj2 = 0 & obj;
			bool flag = (nint)obj2 < 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			bool flag2 = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			bool flag3 = (nint)0 == 0;
			bool flag4 = flag2 != flag;
			return flag4 | flag3;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public PickupMerchantAdventure()
	{
		base._facePlayer = true;
		base._shopCooldown = 3000f;
		List<CustomActionInventoryItem> customActionInventoryItems = new List<CustomActionInventoryItem>();
		CustomActionInventoryItems = customActionInventoryItems;
		((NetworkPickup)this)._002Ector();
	}
}
