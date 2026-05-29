using System;
using UnityEngine;

public class KongregateAPIBehaviour : MonoBehaviour
{
	public struct SafeID
	{
		private int offset;

		private int value;

		public SafeID(int value = 0)
		{
			offset = UnityEngine.Random.Range(-1000, 1000);
			this.value = value + offset;
		}

		public int GetValue()
		{
			return value - offset;
		}

		public void Dispose()
		{
			offset = 0;
			value = 0;
		}

		public override string ToString()
		{
			return GetValue().ToString();
		}
	}

	public Character character;

	public HoverTooltip tooltip;

	private SafeID kongID;

	private string _kongName = "hi";

	private string authToken = "";

	public string kongName
	{
		get
		{
			return _kongName;
		}
		set
		{
			_kongName = value;
		}
	}

	public string getToken()
	{
		return authToken;
	}

	public int retrieveKongID()
	{
		return kongID.GetValue();
	}

	public void Start()
	{
		if (character.platform == platform.Kong)
		{
			Application.ExternalEval("if(typeof(kongregateUnitySupport) != 'undefined'){\r\n        kongregateUnitySupport.initAPI('KongregateAPI', 'OnKongregateAPILoaded');\r\n      };");
			InvokeRepeating("submitBadgeProgress", 10f, 5f);
		}
	}

	public void OnKongregateAPILoaded(string userInfoString)
	{
		if (character.platform == platform.Kong)
		{
			OnKongregateUserInfo(userInfoString);
			Application.ExternalEval("\r\n      kongregate.services.addEventListener('login', function(){\r\n        var unityObject = kongregateUnitySupport.getUnityObject();\r\n        var services = kongregate.services;\r\n        var params=[services.getUserId(), services.getUsername(), \r\n                    services.getGameAuthToken()].join('|');\r\n \r\n        unityObject.SendMessage('KongregateAPI', 'OnKongregateUserInfo', params);\r\n    });");
		}
	}

	public void OnKongregateUserInfo(string userInfoString)
	{
		if (character.platform == platform.Kong)
		{
			string[] array = userInfoString.Split('|');
			int num = Convert.ToInt32(array[0]);
			string playerName = array[1];
			string text = array[2];
			kongID = new SafeID(num);
			kongName = playerName;
			authToken = text;
			character.playerName = playerName;
			character.playerID = num;
			if (!character.mainMenu.doneInitialLoad && Application.platform != RuntimePlatform.WindowsEditor)
			{
				character.saveLoad.setCloudSave();
			}
		}
	}

	public void submitScores()
	{
		if (character.platform != platform.Kong || character.platform != platform.Kong || !character.settings.submitHighscores)
		{
			return;
		}
		if (character.challenges.basicChallenge.bestTime < 1000000)
		{
			Application.ExternalCall("kongregate.stats.submit", "Fastest Basic Challenge", character.challenges.basicChallenge.bestTime);
		}
		if (character.challenges.hour24Challenge.highScore > 57)
		{
			Application.ExternalCall("kongregate.stats.submit", "Highest Boss Defeated in 24 Hour Challenge", character.challenges.hour24Challenge.highScore);
		}
		if (character.challenges.noAugsChallenge.bestTime < 1000000)
		{
			Application.ExternalCall("kongregate.stats.submit", "Fastest No Augments Challenge", character.challenges.noAugsChallenge.bestTime);
		}
		if (character.highestBoss > 20)
		{
			Application.ExternalCall("kongregate.stats.submit", "Highest Boss Defeated", character.highestBoss);
		}
		if (character.stats.bossesDefeated > 100)
		{
			Application.ExternalCall("kongregate.stats.submit", "Bosses Defeated", (int)character.stats.bossesDefeated);
		}
		if (character.stats.advBossesKilled > 100)
		{
			Application.ExternalCall("kongregate.stats.submit", "Adventure Bosses Defeated", character.stats.advBossesKilled);
		}
		if (character.stats.totalExp > 100)
		{
			if (character.stats.totalExp >= int.MaxValue)
			{
				Application.ExternalCall("kongregate.stats.submit", "Total EXP Earned", int.MaxValue);
			}
			else
			{
				Application.ExternalCall("kongregate.stats.submit", "Total EXP Earned", character.stats.totalExp);
			}
		}
		if (character.inventory.itemList.totalDiscovered > 1)
		{
			Application.ExternalCall("kongregate.stats.submit", "Items Discovered", character.inventory.itemList.totalDiscovered);
		}
		if (character.inventory.itemList.totalMaxxed > 1)
		{
			Application.ExternalCall("kongregate.stats.submit", "Items Maxxed", character.inventory.itemList.totalMaxxed);
		}
		if (character.adventure.highestItopodLevel > 50)
		{
			Application.ExternalCall("kongregate.stats.submit", "Highest ITOPOD Floor Reached", character.adventure.highestItopodLevel);
		}
	}

	public void submitBadgeProgress()
	{
		if (character.platform == platform.Kong && Application.platform != RuntimePlatform.WindowsEditor)
		{
			if (character.settings.badge2Part1Complete)
			{
				Application.ExternalCall("kongregate.stats.submit", "Badge2Part1Complete", 1);
			}
			else
			{
				Application.ExternalCall("kongregate.stats.submit", "Badge2Part1Complete", 0);
			}
			if (character.settings.badge2Part2Complete)
			{
				Application.ExternalCall("kongregate.stats.submit", "Badge2Part2Complete", 1);
			}
			else
			{
				Application.ExternalCall("kongregate.stats.submit", "Badge2Part2Complete", 0);
			}
			if (character.settings.badge2Part3Complete)
			{
				Application.ExternalCall("kongregate.stats.submit", "Badge2Part3Complete", 1);
			}
			else
			{
				Application.ExternalCall("kongregate.stats.submit", "Badge2Part3Complete", 0);
			}
			if (character.settings.badge2Part4Complete)
			{
				Application.ExternalCall("kongregate.stats.submit", "Badge2Part4Complete", 1);
			}
			else
			{
				Application.ExternalCall("kongregate.stats.submit", "Badge2Part4Complete", 0);
			}
			if (character.settings.badge2Part1Complete && character.settings.badge2Part2Complete && character.settings.badge2Part3Complete && character.settings.badge2Part4Complete)
			{
				Application.ExternalCall("kongregate.stats.submit", "Badge2Complete", 1);
			}
			else
			{
				Application.ExternalCall("kongregate.stats.submit", "Badge2Complete", 0);
			}
			if (character.highestBoss >= 7)
			{
				Application.ExternalCall("kongregate.stats.submit", "Badge1Complete", 1);
			}
			else
			{
				Application.ExternalCall("kongregate.stats.submit", "Badge1Complete", 0);
			}
		}
	}

	public void startbuyBudget()
	{
		if (character.platform == platform.Kong)
		{
			startBuy20KAP();
		}
		else if (character.platform == platform.AG)
		{
			character.AGAPI.startBuy20KAP();
		}
		else if (character.platform == platform.Kartridge)
		{
			character.KartridgeAPI.startBuy20KAP();
		}
		else if (character.platform == platform.Steam)
		{
			character.steamAPI.startBuy20KAP();
		}
	}

	public void startbuyTiny()
	{
		if (character.platform == platform.Kong)
		{
			startBuy100KAP();
		}
		else if (character.platform == platform.AG)
		{
			character.AGAPI.startBuy100KAP();
		}
		else if (character.platform == platform.Kartridge)
		{
			character.KartridgeAPI.startBuy100KAP();
		}
		else if (character.platform == platform.Steam)
		{
			character.steamAPI.startBuy100KAP();
		}
	}

	public void startbuySmall()
	{
		if (character.platform == platform.Kong)
		{
			startBuy200KAP();
		}
		else if (character.platform == platform.AG)
		{
			character.AGAPI.startBuy200KAP();
		}
		else if (character.platform == platform.Kartridge)
		{
			character.KartridgeAPI.startBuy200KAP();
		}
		else if (character.platform == platform.Steam)
		{
			character.steamAPI.startBuy200KAP();
		}
	}

	public void startbuyMedium()
	{
		if (character.platform == platform.Kong)
		{
			startBuy400KAP();
		}
		else if (character.platform == platform.AG)
		{
			character.AGAPI.startBuy400KAP();
		}
		else if (character.platform == platform.Kartridge)
		{
			character.KartridgeAPI.startBuy400KAP();
		}
		else if (character.platform == platform.Steam)
		{
			character.steamAPI.startBuy400KAP();
		}
	}

	public void startbuyLarge()
	{
		if (character.platform == platform.Kong)
		{
			startBuy1MAP();
		}
		else if (character.platform == platform.AG)
		{
			character.AGAPI.startBuy1MAP();
		}
		else if (character.platform == platform.Kartridge)
		{
			character.KartridgeAPI.startBuy1MAP();
		}
		else if (character.platform == platform.Steam)
		{
			character.steamAPI.startBuy1MAP();
		}
	}

	public void startbuyHuge()
	{
		if (character.platform == platform.Kong)
		{
			startBuy2MAP();
		}
		else if (character.platform == platform.AG)
		{
			character.AGAPI.startBuy2MAP();
		}
		else if (character.platform == platform.Kartridge)
		{
			character.KartridgeAPI.startBuy2MAP();
		}
		else if (character.platform == platform.Steam)
		{
			character.steamAPI.startBuy2MAP();
		}
	}

	public void startbuyStupidNewbie()
	{
		if (character.platform == platform.Kong)
		{
			if (!character.arbitrary.boughtNewbiePack)
			{
				startNewPlayerAP();
			}
			else if (!character.arbitrary.boughtAscendedNewbiePack)
			{
				startAscendedNewbieAP();
			}
			else if (!character.arbitrary.boughtAscendedNewbiePack2)
			{
				startAscendedNewbie2AP();
			}
			else if (!character.arbitrary.boughtAscendedNewbiePack3)
			{
				startAscendedNewbie3AP();
			}
			else if (!character.arbitrary.boughtAscendedNewbiePack4)
			{
				startAscendedNewbie4AP();
			}
		}
		else if (character.platform == platform.AG)
		{
			if (!character.arbitrary.boughtNewbiePack)
			{
				character.AGAPI.startNewPlayerAP();
			}
			else if (!character.arbitrary.boughtAscendedNewbiePack)
			{
				character.AGAPI.startAscendedAP();
			}
		}
		else if (character.platform == platform.Kartridge)
		{
			if (!character.arbitrary.boughtNewbiePack)
			{
				character.KartridgeAPI.startNewPlayerAP();
			}
			else if (!character.arbitrary.boughtAscendedNewbiePack)
			{
				character.KartridgeAPI.startAscendedNewbieAP();
			}
			else if (!character.arbitrary.boughtAscendedNewbiePack2)
			{
				character.KartridgeAPI.startAscendedNewbie2AP();
			}
			else if (!character.arbitrary.boughtAscendedNewbiePack3)
			{
				character.KartridgeAPI.startAscendedNewbie3AP();
			}
			else if (!character.arbitrary.boughtAscendedNewbiePack4)
			{
				character.KartridgeAPI.startAscendedNewbie4AP();
			}
		}
		else if (character.platform == platform.Steam)
		{
			if (!character.arbitrary.boughtNewbiePack)
			{
				character.steamAPI.startNewPlayerAP();
			}
			else if (!character.arbitrary.boughtAscendedNewbiePack)
			{
				character.steamAPI.startAscendedNewbieAP();
			}
			else if (!character.arbitrary.boughtAscendedNewbiePack2)
			{
				character.steamAPI.startAscendedNewbie2AP();
			}
			else if (!character.arbitrary.boughtAscendedNewbiePack3)
			{
				character.steamAPI.startAscendedNewbie3AP();
			}
			else if (!character.arbitrary.boughtAscendedNewbiePack4)
			{
				character.steamAPI.startAscendedNewbie4AP();
			}
		}
	}

	public void startbuyAscendedNewbie()
	{
		if (character.platform == platform.Kong)
		{
			startAscendedNewbieAP();
		}
		else if (character.platform == platform.AG)
		{
			tooltip.showOverrideTooltip("This isn't available to buy yet on Armor :c. Sorry friend.");
		}
	}

	public void startBuyItopodNamePack()
	{
		if (character.platform == platform.Kong)
		{
			startItopodAP();
		}
		else if (character.platform == platform.AG)
		{
			tooltip.showOverrideTooltip("This isn't available to buy yet on Armor :c. Sorry friend.");
		}
		else if (character.platform == platform.Steam)
		{
			character.steamAPI.startITOPODNameAP();
		}
	}

	public void startBuyRes3Pack()
	{
		if (character.platform == platform.Kong)
		{
			startRes3AP();
		}
		else if (character.platform == platform.AG)
		{
			tooltip.showOverrideTooltip("This isn't available to buy yet on Armor :c. Sorry friend.", 3f);
		}
		else if (character.platform == platform.Kartridge)
		{
			character.KartridgeAPI.startRes3AP();
		}
		else if (character.platform == platform.Steam)
		{
			character.steamAPI.startRes3AP();
		}
	}

	public void startBuyFashionPack1()
	{
		if (character.platform == platform.Kong)
		{
			startFashionPack1AP();
		}
		else if (character.platform == platform.AG)
		{
			tooltip.showOverrideTooltip("This isn't available to buy yet on Armor :c. Sorry friend.");
		}
		else if (character.platform == platform.Kartridge)
		{
			character.KartridgeAPI.startFashionPack1AP();
		}
		else if (character.platform == platform.Steam)
		{
			character.steamAPI.startFashionPack1AP();
		}
	}

	public void startBuy20KAP()
	{
		Application.ExternalEval("\r\n        kongregate.mtx.purchaseItems(['ap20k'], function(result) {\r\n        var unityObject = kongregateUnitySupport.getUnityObject();\r\n        if (result.success) {\r\n            unityObject.SendMessage('KongregateAPI', 'OnPurchaseSuccess', '');\r\n        } else {\r\n            unityObject.SendMessage('KongregateAPI', 'OnPurchaseFailure', '');\r\n        }\r\n    });\r\n    ");
	}

	public void startBuy100KAP()
	{
		Application.ExternalEval("\r\n        kongregate.mtx.purchaseItems(['ap100k'], function(result) {\r\n        var unityObject = kongregateUnitySupport.getUnityObject();\r\n        if (result.success) {\r\n            unityObject.SendMessage('KongregateAPI', 'OnPurchaseSuccess', '');\r\n        } else {\r\n            unityObject.SendMessage('KongregateAPI', 'OnPurchaseFailure', '');\r\n        }\r\n    });\r\n    ");
	}

	public void startBuy200KAP()
	{
		Application.ExternalEval("\r\n        kongregate.mtx.purchaseItems(['ap200k'], function(result) {\r\n        var unityObject = kongregateUnitySupport.getUnityObject();\r\n        if (result.success) {\r\n            unityObject.SendMessage('KongregateAPI', 'OnPurchaseSuccess', '');\r\n        } else {\r\n            unityObject.SendMessage('KongregateAPI', 'OnPurchaseFailure', '');\r\n        }\r\n    });\r\n    ");
	}

	public void startBuy400KAP()
	{
		Application.ExternalEval("\r\n        kongregate.mtx.purchaseItems(['ap400k'], function(result) {\r\n        var unityObject = kongregateUnitySupport.getUnityObject();\r\n        if (result.success) {\r\n            unityObject.SendMessage('KongregateAPI', 'OnPurchaseSuccess', '');\r\n        } else {\r\n            unityObject.SendMessage('KongregateAPI', 'OnPurchaseFailure', '');\r\n        }\r\n    });\r\n    ");
	}

	public void startBuy1MAP()
	{
		Application.ExternalEval("\r\n        kongregate.mtx.purchaseItems(['ap1m'], function(result) {\r\n        var unityObject = kongregateUnitySupport.getUnityObject();\r\n        if (result.success) {\r\n            unityObject.SendMessage('KongregateAPI', 'OnPurchaseSuccess', '');\r\n        } else {\r\n            unityObject.SendMessage('KongregateAPI', 'OnPurchaseFailure', '');\r\n        }\r\n    });\r\n    ");
	}

	public void startBuy2MAP()
	{
		Application.ExternalEval("\r\n        kongregate.mtx.purchaseItems(['ap2m'], function(result) {\r\n        var unityObject = kongregateUnitySupport.getUnityObject();\r\n        if (result.success) {\r\n            unityObject.SendMessage('KongregateAPI', 'OnPurchaseSuccess', '');\r\n        } else {\r\n            unityObject.SendMessage('KongregateAPI', 'OnPurchaseFailure', '');\r\n        }\r\n    });\r\n    ");
	}

	public void startNewPlayerAP()
	{
		Application.ExternalEval("\r\n        kongregate.mtx.purchaseItems(['npp'], function(result) {\r\n        var unityObject = kongregateUnitySupport.getUnityObject();\r\n        if (result.success) {\r\n            unityObject.SendMessage('KongregateAPI', 'OnPurchaseSuccess', '');\r\n        } else {\r\n            unityObject.SendMessage('KongregateAPI', 'OnPurchaseFailure', '');\r\n        }\r\n    });\r\n    ");
	}

	public void startAscendedNewbieAP()
	{
		Application.ExternalEval("\r\n        kongregate.mtx.purchaseItems(['anp'], function(result) {\r\n        var unityObject = kongregateUnitySupport.getUnityObject();\r\n        if (result.success) {\r\n            unityObject.SendMessage('KongregateAPI', 'OnPurchaseSuccess', '');\r\n        } else {\r\n            unityObject.SendMessage('KongregateAPI', 'OnPurchaseFailure', '');\r\n        }\r\n    });\r\n    ");
	}

	public void startAscendedNewbie2AP()
	{
		Application.ExternalEval("\r\n        kongregate.mtx.purchaseItems(['anp2'], function(result) {\r\n        var unityObject = kongregateUnitySupport.getUnityObject();\r\n        if (result.success) {\r\n            unityObject.SendMessage('KongregateAPI', 'OnPurchaseSuccess', '');\r\n        } else {\r\n            unityObject.SendMessage('KongregateAPI', 'OnPurchaseFailure', '');\r\n        }\r\n    });\r\n    ");
	}

	public void startAscendedNewbie3AP()
	{
		Application.ExternalEval("\r\n        kongregate.mtx.purchaseItems(['anp3'], function(result) {\r\n        var unityObject = kongregateUnitySupport.getUnityObject();\r\n        if (result.success) {\r\n            unityObject.SendMessage('KongregateAPI', 'OnPurchaseSuccess', '');\r\n        } else {\r\n            unityObject.SendMessage('KongregateAPI', 'OnPurchaseFailure', '');\r\n        }\r\n    });\r\n    ");
	}

	public void startAscendedNewbie4AP()
	{
		Application.ExternalEval("\r\n        kongregate.mtx.purchaseItems(['anp4'], function(result) {\r\n        var unityObject = kongregateUnitySupport.getUnityObject();\r\n        if (result.success) {\r\n            unityObject.SendMessage('KongregateAPI', 'OnPurchaseSuccess', '');\r\n        } else {\r\n            unityObject.SendMessage('KongregateAPI', 'OnPurchaseFailure', '');\r\n        }\r\n    });\r\n    ");
	}

	public void startItopodAP()
	{
		Application.ExternalEval("\r\n        kongregate.mtx.purchaseItems(['itopodname'], function(result) {\r\n        var unityObject = kongregateUnitySupport.getUnityObject();\r\n        if (result.success) {\r\n            unityObject.SendMessage('KongregateAPI', 'OnPurchaseSuccess', '');\r\n        } else {\r\n            unityObject.SendMessage('KongregateAPI', 'OnPurchaseFailure', '');\r\n        }\r\n    });\r\n    ");
	}

	public void startRes3AP()
	{
		Application.ExternalEval("\r\n        kongregate.mtx.purchaseItems(['res3ap'], function(result) {\r\n        var unityObject = kongregateUnitySupport.getUnityObject();\r\n        if (result.success) {\r\n            unityObject.SendMessage('KongregateAPI', 'OnPurchaseSuccess', '');\r\n        } else {\r\n            unityObject.SendMessage('KongregateAPI', 'OnPurchaseFailure', '');\r\n        }\r\n    });\r\n    ");
	}

	public void startFashionPack1AP()
	{
		Application.ExternalEval("\r\n        kongregate.mtx.purchaseItems(['pic1'], function(result) {\r\n        var unityObject = kongregateUnitySupport.getUnityObject();\r\n        if (result.success) {\r\n            unityObject.SendMessage('KongregateAPI', 'OnPurchaseSuccess', '');\r\n        } else {\r\n            unityObject.SendMessage('KongregateAPI', 'OnPurchaseFailure', '');\r\n        }\r\n    });\r\n    ");
	}

	public void OnPurchaseSuccess()
	{
		tooltip.showOverrideTooltip("Looks like you bought something!", 2f);
		consumeAnyOustandingItems();
	}

	public void OnPurchaseFailure()
	{
		tooltip.showOverrideTooltip("Hm, that purchase didn't seem to go through. Try again?", 2f);
	}

	public void startConsumeAll()
	{
		if (character.platform == platform.Kong)
		{
			consumeAnyOustandingItems();
		}
		else if (character.platform == platform.AG)
		{
			character.AGAPI.consumeAnyOutstandingItems();
		}
	}

	public void consumeAnyOustandingItems()
	{
		if (character.platform == platform.Kong)
		{
			Application.ExternalEval("\r\n           kongregate.mtx.requestUserItemList('', function(result) { \r\n            var unityObject = kongregateUnitySupport.getUnityObject();\r\n            console.log('User item list received, success: ' + result.success);\r\n            if (result.success)\r\n            {\r\n                for (var i = 0; i < result.data.length; i++) \r\n                {\r\n                    var item = result.data[i];\r\n                    console.log((i+1) + '. ' + item.identifier + ', ' + item.id + ',' + item.data);\r\n                    if (item.identifier == 'ap20k') \r\n                    { \r\n                           kongregate.mtx.useItemInstance(item.id, function(result) {\r\n                               if (result.success) {\r\n                                   unityObject.SendMessage('KongregateAPI', 'consume20KPurchase', '');\r\n                               }\r\n                           });\r\n                    } else if (item.identifier == 'ap100k') \r\n                    { \r\n                           kongregate.mtx.useItemInstance(item.id, function(result) {\r\n                               if (result.success) {\r\n                                   unityObject.SendMessage('KongregateAPI', 'consume100KPurchase', '');\r\n                               }\r\n                           });\r\n                    } else if (item.identifier == 'ap200k') \r\n                    { \r\n                           kongregate.mtx.useItemInstance(item.id, function(result) {\r\n                               if (result.success) {\r\n                                   unityObject.SendMessage('KongregateAPI', 'consume200KPurchase', '');\r\n                               }\r\n                           });\r\n                    } else if (item.identifier == 'ap400k') \r\n                    { \r\n                           kongregate.mtx.useItemInstance(item.id, function(result) {\r\n                               if (result.success) {\r\n                                   unityObject.SendMessage('KongregateAPI', 'consume400KPurchase', '');\r\n                               }\r\n                           });\r\n                    } else if (item.identifier == 'ap1m') \r\n                    { \r\n                           kongregate.mtx.useItemInstance(item.id, function(result) {\r\n                               if (result.success) {\r\n                                   unityObject.SendMessage('KongregateAPI', 'consume1MPurchase', '');\r\n                               }\r\n                           });\r\n                    } else if (item.identifier == 'ap2m') \r\n                    { \r\n                           kongregate.mtx.useItemInstance(item.id, function(result) {\r\n                               if (result.success) {\r\n                                   unityObject.SendMessage('KongregateAPI', 'consume2MPurchase', '');\r\n                               }\r\n                           });\r\n                    } else if (item.identifier == 'npp') \r\n                    { \r\n                           kongregate.mtx.useItemInstance(item.id, function(result) {\r\n                               if (result.success) {\r\n                                   unityObject.SendMessage('KongregateAPI', 'consumeNewPlayerPurchase', '');\r\n                               }\r\n                           });\r\n                    } else if (item.identifier == 'anp') \r\n                    { \r\n                           kongregate.mtx.useItemInstance(item.id, function(result) {\r\n                               if (result.success) {\r\n                                   unityObject.SendMessage('KongregateAPI', 'consumeAscendedNewbiePurchase', '');\r\n                               }\r\n                           });\r\n                    } else if (item.identifier == 'itopodname') \r\n                    { \r\n                           kongregate.mtx.useItemInstance(item.id, function(result) {\r\n                               if (result.success) {\r\n                                   unityObject.SendMessage('KongregateAPI', 'consumeITOPODNamePack', '');\r\n                               }\r\n                           });\r\n                    } else if (item.identifier == 'anp2') \r\n                    { \r\n                           kongregate.mtx.useItemInstance(item.id, function(result) {\r\n                               if (result.success) {\r\n                                   unityObject.SendMessage('KongregateAPI', 'consumeAscendedNewbiePurchase2', '');\r\n                               }\r\n                           });\r\n                    } else if (item.identifier == 'res3ap') \r\n                    { \r\n                           kongregate.mtx.useItemInstance(item.id, function(result) {\r\n                               if (result.success) {\r\n                                   unityObject.SendMessage('KongregateAPI', 'consumeRes3Purchase', '');\r\n                               }\r\n                           });\r\n                    } else if (item.identifier == 'anp3') \r\n                    { \r\n                           kongregate.mtx.useItemInstance(item.id, function(result) {\r\n                               if (result.success) {\r\n                                   unityObject.SendMessage('KongregateAPI', 'consumeAscendedNewbiePurchase3', '');\r\n                               }\r\n                           });\r\n                    }else if (item.identifier == 'pic1') \r\n                    { \r\n                           kongregate.mtx.useItemInstance(item.id, function(result) {\r\n                               if (result.success) {\r\n                                   unityObject.SendMessage('KongregateAPI', 'consumeFashionPack1', '');\r\n                               }\r\n                           });\r\n                    }else if (item.identifier == 'anp4') \r\n                    { \r\n                           kongregate.mtx.useItemInstance(item.id, function(result) {\r\n                               if (result.success) {\r\n                                   unityObject.SendMessage('KongregateAPI', 'consumeAscendedNewbiePurchase4', '');\r\n                               }\r\n                           });\r\n                    }\r\n                }\r\n            }\r\n        });\r\n");
		}
	}

	public void consume20KPurchase()
	{
		character.addAP(20000);
		tooltip.showOverrideTooltip("Thank you so much! " + character.checkAPAdded(20000L).ToString("###,##0") + " AP has been added!", 5f);
		StartCoroutine(character.saveLoad.uploadSave(forced: false));
		character.allArbitrary.updateMenu();
	}

	public void consume100KPurchase()
	{
		character.addAP(110000);
		tooltip.showOverrideTooltip("Thank you so much! " + character.checkAPAdded(100000L).ToString("###,##0") + " AP has been added, plus a bonus of " + character.checkAPAdded(10000L).ToString("###,##0") + " AP! I'm going to save your game online, but PLEASE make a file save as well to ensure you don't lose what you bought!", 10f);
		StartCoroutine(character.saveLoad.uploadSave(forced: false));
		character.allArbitrary.updateMenu();
	}

	public void consume200KPurchase()
	{
		character.addAP(225000);
		tooltip.showOverrideTooltip("Thank you so much! " + character.checkAPAdded(200000L).ToString("###,##0") + " AP has been added, plus a bonus of " + character.checkAPAdded(25000L).ToString("###,##0") + " AP! I'm going to save your game online, but PLEASE make a file save as well to ensure you don't lose what you bought!", 10f);
		StartCoroutine(character.saveLoad.uploadSave(forced: false));
		character.allArbitrary.updateMenu();
	}

	public void consume400KPurchase()
	{
		character.addAP(460000);
		tooltip.showOverrideTooltip("Thank you so much! " + character.checkAPAdded(400000L).ToString("###,##0") + " AP has been added, plus a bonus of " + character.checkAPAdded(60000L).ToString("###,##0") + " AP! I'm going to save your game online, but PLEASE make a file save as well to ensure you don't lose what you bought!", 10f);
		StartCoroutine(character.saveLoad.uploadSave(forced: false));
		character.allArbitrary.updateMenu();
	}

	public void consume1MPurchase()
	{
		character.addAP(1200000);
		tooltip.showOverrideTooltip("Thank you so much! " + character.checkAPAdded(1000000L).ToString("###,##0") + " AP has been added, plus a bonus of " + character.checkAPAdded(200000L).ToString("###,##0") + " AP! I'm going to save your game online, but PLEASE make a file save as well to ensure you don't lose what you bought!", 10f);
		StartCoroutine(character.saveLoad.uploadSave(forced: false));
		character.allArbitrary.updateMenu();
	}

	public void consume2MPurchase()
	{
		character.addAP(3200000);
		tooltip.showOverrideTooltip("Thank you so much! " + character.checkAPAdded(2500000L).ToString("###,##0") + " AP has been added, plus a bonus of " + character.checkAPAdded(700000L).ToString("###,##0") + " AP! I'm going to save your game online, but PLEASE make a file save as well to ensure you don't lose what you bought!", 10f);
		StartCoroutine(character.saveLoad.uploadSave(forced: false));
		character.allArbitrary.updateMenu();
	}

	public void consumeNewPlayerPurchase()
	{
		string text = "Thank you so much for buying the Stupid Newbie Pack! You've received:\n\n<b>" + character.checkAPAdded(225000L).ToString("###,##0") + "AP!</b>\n<b>2 of every consumable boost!</b>\n<b>25 Poop!</b>";
		character.addAP(225000);
		character.arbitrary.energyPotion1Count += 2;
		character.arbitrary.energyPotion2Count += 2;
		character.arbitrary.energyPotion3Count += 2;
		character.arbitrary.magicPotion1Count += 2;
		character.arbitrary.magicPotion2Count += 2;
		character.arbitrary.magicPotion3Count += 2;
		character.arbitrary.lootCharm1Count += 2;
		character.arbitrary.energyBarBar1Count += 2;
		character.arbitrary.magicBarBar1Count += 2;
		character.arbitrary.poop1Count += 25;
		character.arbitrary.lootCharm2Count += 2;
		if (character.arbitrary.lootFilter)
		{
			character.arbitrary.curArbitraryPoints += 100000L;
			text += "\n<b>An extra 100000 AP Since you already have the Improved Loot Filter!</b>";
		}
		else
		{
			character.arbitrary.lootFilter = true;
			text += "\n<b>The Improved Loot Filter!</b>";
		}
		long num = 0L;
		long num2 = character.arbitrary.inventorySpaces + 12 - character.allArbitrary.randomArbitraryController.maxSpaces();
		if (num2 < 0)
		{
			num2 = 0L;
		}
		if (num2 > 12)
		{
			num2 = 12L;
		}
		if (num2 > 0)
		{
			num = num2 * 10000;
		}
		if (num > 0)
		{
			character.arbitrary.curArbitraryPoints += num;
			character.arbitrary.curLifetimePoints += num;
			text = text + "\n<b>An extra " + num.ToString("###,##0") + " AP since you reached the max inventory spaces available!</b>";
		}
		else
		{
			text += "\n<b>12 inventory spaces!</b>";
		}
		character.arbitrary.inventorySpaces += 12;
		if (character.arbitrary.inventorySpaces > character.allArbitrary.randomArbitraryController.maxSpaces())
		{
			character.arbitrary.inventorySpaces = (int)character.allArbitrary.randomArbitraryController.maxSpaces();
		}
		character.arbitrary.boughtNewbiePack = true;
		character.inventoryController.updateInvCount();
		text += "\n<b>Plus, you can PM me for a personalized insult!</b>\n\nI'm going to save your game online, but PLEASE make a file save as well to ensure you don't lose what you bought!";
		tooltip.showOverrideTooltip(text, 11f);
		character.APPackDisplay.refreshMenu();
		character.allArbitrary.updateMenu();
		StartCoroutine(character.saveLoad.uploadSave(forced: false));
	}

	public void consumeAscendedNewbiePurchase()
	{
		string text = "Thank you so much for buying the Ascended Newbie Pack! You've received:\n\n<b>" + character.checkAPAdded(600000L).ToString("###,##0") + "AP!</b>\n<b>4 of every consumable boost!</b>\n<b>25 Poop!</b>";
		character.addAP(600000);
		character.arbitrary.energyPotion1Count += 4;
		character.arbitrary.energyPotion2Count += 4;
		character.arbitrary.energyPotion3Count += 4;
		character.arbitrary.magicPotion1Count += 4;
		character.arbitrary.magicPotion2Count += 4;
		character.arbitrary.magicPotion3Count += 4;
		character.arbitrary.lootCharm1Count += 4;
		character.arbitrary.energyBarBar1Count += 4;
		character.arbitrary.magicBarBar1Count += 4;
		character.arbitrary.poop1Count += 50;
		character.arbitrary.lootCharm2Count += 4;
		character.arbitrary.macGuffinBooster1Count += 4;
		character.arbitrary.beastButterCount += 4;
		if (!character.inventoryController.freeSpace())
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you had no space for the Red Heart!</b>";
		}
		else if ((character.arbitrary.lootFilter && character.inventory.itemList.itemFiltered[119]) || (character.settings.filterOn && character.settings.filterAccessory))
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you had the Red Heart filtered!</b>";
		}
		else if (character.inventory.itemList.itemMaxxed[119])
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you already had a maxxed out Red Heart!</b>";
		}
		else
		{
			character.itemInfo.makeLevelledLoot(119, 10);
			text += "\n<b>A Red Heart!</b>";
		}
		if (character.arbitrary.boughtLazyITOPOD)
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you already bought the Lazy ITOPOD Shifter!</b>";
		}
		else
		{
			character.arbitrary.boughtLazyITOPOD = true;
			text += "\n<b>The Lazy ITOPOD Shifter!</b>";
		}
		character.arbitrary.boughtAscendedNewbiePack = true;
		text += "\n<b>Plus, you can PM me for a personalized compliment!</b>\n\nI'm going to save your game online, but PLEASE make a file save as well to ensure you don't lose what you bought!";
		tooltip.showOverrideTooltip(text, 11f);
		character.allArbitrary.updateMenu();
		character.APPackDisplay.refreshMenu();
		StartCoroutine(character.saveLoad.uploadSave(forced: false));
	}

	public void consumeRes3Purchase()
	{
		string text = "Thank you so much for buying the Resource 3 Pack! You've received:\n\n<b>" + character.checkAPAdded(600000L).ToString("###,##0") + "AP!</b>\n<b>4 of each Resource 3 Potion!</b>";
		character.addAP(600000);
		character.arbitrary.res3Potion1Count += 4;
		character.arbitrary.res3Potion2Count += 4;
		character.arbitrary.res3Potion3Count += 4;
		if (!character.inventoryController.freeSpace())
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you had no space for the Grey Heart!</b>";
		}
		else if ((character.arbitrary.lootFilter && character.inventory.itemList.itemFiltered[297]) || (character.settings.filterOn && character.settings.filterAccessory))
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you had the Grey Heart filtered!</b>";
		}
		else if (character.inventory.itemList.itemMaxxed[297])
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you already had a maxxed out Grey Heart!</b>";
		}
		else
		{
			character.itemInfo.makeLevelledLoot(297, 10);
			text += "\n<b>A Grey Heart!</b>";
		}
		text += "\n<b>You can now fully customize Resource 3's Colour! Check Page 2 of the Settings Menu.</b>";
		character.arbitrary.boughtRes3Pack = true;
		text += "\n<b>Plus, you can PM me for a personalized NUMBER! No one else can have the number I give you, it's yours and yours alone.</b>\n\nI'm going to save your game online, but PLEASE make a file save as well to ensure you don't lose what you bought!";
		tooltip.showOverrideTooltip(text, 11f);
		character.allArbitrary.updateMenu();
		character.APPackDisplay.refreshMenu();
		StartCoroutine(character.saveLoad.uploadSave(forced: false));
	}

	public void onPurchaseFailure()
	{
		tooltip.showOverrideTooltip("You didn't buy anything, but it's the thought that counts <3.", 3f);
	}

	public void consumeITOPODNamePack()
	{
		character.arbitrary.nameSlotsBought++;
		if (character.arbitrary.nameSlotsBought == 1)
		{
			character.addAP(1200000);
			tooltip.showOverrideTooltip("Thank you so much for purchasing the ITOPOD Name Pack! Since this is your first purchase, you've received a bonus of <b>" + character.checkAPAdded(1200000L).ToString("###,##0") + "</b> AP! I have to add names manually on my server, so it may take a day or two for your name to appear on the list! If you want the name to be something other than your username, you can contact me on Discord or Kongregate!", 12f);
		}
		else
		{
			tooltip.showOverrideTooltip("Thank you so much for purchasing the ITOPOD Name Pack! I have to add names manually on my server, so it may take a day or two for your name to appear on the list! If you want the name to be something other than your username, you can contact me on Discord or Kongregate!", 12f);
		}
		character.allArbitrary.updateMenu();
		character.APPackDisplay.refreshMenu();
		StartCoroutine(character.saveLoad.uploadSave(forced: false));
	}

	public void consumeAscendedNewbiePurchase2()
	{
		string text = "Thank you so much for buying the Ascended Ascended Pack! You've received:\n\n<b>" + character.checkAPAdded(700000L).ToString("###,##0") + "AP!</b>\n<b>4 of every consumable boost!</b>\n<b>50 Poop!</b>";
		character.addAP(700000);
		character.arbitrary.energyPotion1Count += 4;
		character.arbitrary.energyPotion2Count += 4;
		character.arbitrary.energyPotion3Count += 4;
		character.arbitrary.magicPotion1Count += 4;
		character.arbitrary.magicPotion2Count += 4;
		character.arbitrary.magicPotion3Count += 4;
		character.arbitrary.lootCharm1Count += 4;
		character.arbitrary.energyBarBar1Count += 4;
		character.arbitrary.magicBarBar1Count += 4;
		character.arbitrary.poop1Count += 50;
		character.arbitrary.lootCharm2Count += 4;
		character.arbitrary.macGuffinBooster1Count += 4;
		character.arbitrary.beastButterCount += 4;
		if (!character.inventoryController.freeSpace())
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you had no space for the Orange Heart!</b>";
		}
		else if ((character.arbitrary.lootFilter && character.inventory.itemList.itemFiltered[293]) || (character.settings.filterOn && character.settings.filterAccessory))
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you had the Orange Heart filtered!</b>";
		}
		else if (character.inventory.itemList.itemMaxxed[293])
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you already had a maxxed out Orange Heart!</b>";
		}
		else
		{
			character.itemInfo.makeLevelledLoot(293, 10);
			text += "\n<b>An Orange Heart!</b>";
		}
		if (character.arbitrary.hasFasterQuests)
		{
			character.arbitrary.curArbitraryPoints += 250000L;
			text += "\n<b>An additional 250,000 AP because you already bought Faster Questing!</b>";
		}
		else
		{
			character.arbitrary.hasFasterQuests = true;
			text += "\n<b>Faster Questing!</b>";
		}
		character.inventory.unlockedKittyArt[3] = true;
		text += "\n<b>THE GOLDEN KITTY</b>";
		character.arbitrary.boughtAscendedNewbiePack2 = true;
		text += "\n<b>Plus, you can PM me for a personalized pun!</b>\n\nI'm going to save your game online, but PLEASE make a file save as well to ensure you don't lose what you bought!";
		tooltip.showOverrideTooltip(text, 11f);
		character.allArbitrary.updateMenu();
		character.APPackDisplay.refreshMenu();
		StartCoroutine(character.saveLoad.uploadSave(forced: false));
	}

	public void consumeAscendedNewbiePurchase3()
	{
		string text = "Thank you so much for buying the Ascended ^ 3 Pack! You've received:\n\n<b>" + character.checkAPAdded(500000L).ToString("###,##0") + "AP!</b>\n<b>A huge dump of consumable boosts!</b>\n<b>50 Poop!</b>";
		character.addAP(500000);
		character.arbitrary.energyPotion1Count += 4;
		character.arbitrary.energyPotion2Count += 4;
		character.arbitrary.energyPotion3Count += 4;
		character.arbitrary.magicPotion1Count += 4;
		character.arbitrary.magicPotion2Count += 4;
		character.arbitrary.magicPotion3Count += 4;
		character.arbitrary.res3Potion1Count += 4;
		character.arbitrary.res3Potion2Count += 4;
		character.arbitrary.res3Potion3Count += 4;
		character.arbitrary.lootCharm1Count += 4;
		character.arbitrary.energyBarBar1Count += 4;
		character.arbitrary.magicBarBar1Count += 4;
		character.arbitrary.poop1Count += 50;
		character.adventure.itopod.buffedKills += 4000L;
		character.arbitrary.lootCharm2Count += 4;
		character.arbitrary.macGuffinBooster1Count += 4;
		character.arbitrary.beastButterCount += 4;
		if (!character.inventoryController.freeSpace())
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you had no space for the Blue Heart!</b>";
		}
		else if ((character.arbitrary.lootFilter && character.inventory.itemList.itemFiltered[196]) || (character.settings.filterOn && character.settings.filterAccessory))
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you had the Blue Heart filtered!</b>";
		}
		else if (character.inventory.itemList.itemMaxxed[196])
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you already had a maxxed out Blue Heart!</b>";
		}
		else
		{
			character.itemInfo.makeLevelledLoot(196, 10);
			text += "\n<b>A Blue Heart!</b>";
		}
		if (character.arbitrary.wishSpeedBoster)
		{
			character.arbitrary.curArbitraryPoints += 250000L;
			text += "\n<b>An additional 150,000 AP because you already bought Faster Wishes!</b>";
		}
		else
		{
			character.arbitrary.wishSpeedBoster = true;
			text += "\n<b>Faster Wishes!</b>";
		}
		character.arbitrary.boughtAscendedNewbiePack3 = true;
		text += "\n<b>Plus, you can PM me, and i'll send back a kitten pic or video!</b>\n\nI'm going to save your game online, but PLEASE make a file save as well to ensure you don't lose what you bought!";
		tooltip.showOverrideTooltip(text, 11f);
		character.allArbitrary.updateMenu();
		character.APPackDisplay.refreshMenu();
		StartCoroutine(character.saveLoad.uploadSave(forced: false));
	}

	public void consumeFashionPack1()
	{
		character.arbitrary.boughtFashionPack1 = true;
		character.portraits.portraitUnlocked[1] = true;
		character.portraits.portraitUnlocked[2] = true;
		character.portraits.portraitUnlocked[3] = true;
		character.portraits.portraitUnlocked[4] = true;
		character.portraits.portraitUnlocked[5] = true;
		character.portraits.portraitUnlocked[6] = true;
		character.portraits.portraitUnlocked[7] = true;
		character.portraits.portraitUnlocked[8] = true;
		character.portraits.portraitUnlocked[9] = true;
		character.portraits.portraitUnlocked[10] = true;
		character.addAP(200000);
		string message = "Thank you so much for buying the Sexy Player Fashion Pack! You've unlocked 10 sexy new pics for your player in the Fight Boss Menu, PLUS a bonus " + character.checkAPAdded(200000L).ToString("###,##0") + "AP! I'm going to save your game online, but PLEASE make a file save as well to ensure you don't lose what you bought!";
		tooltip.showOverrideTooltip(message, 11f);
		character.allArbitrary.updateMenu();
		character.APPackDisplay.refreshMenu();
		StartCoroutine(character.saveLoad.uploadSave(forced: false));
	}

	public void consumeAscendedNewbiePurchase4()
	{
		string text = "Thank you so much for buying the Ascended ^ 4 Pack! You've received:\n\n<b>" + character.checkAPAdded(300000L).ToString("###,##0") + "AP!</b>\n<b>A huge dump of consumable boosts!</b>\n<b>50 Poop!</b>";
		character.addAP(300000);
		character.arbitrary.energyPotion1Count += 4;
		character.arbitrary.energyPotion2Count += 4;
		character.arbitrary.energyPotion3Count += 4;
		character.arbitrary.magicPotion1Count += 4;
		character.arbitrary.magicPotion2Count += 4;
		character.arbitrary.magicPotion3Count += 4;
		character.arbitrary.res3Potion1Count += 4;
		character.arbitrary.res3Potion2Count += 4;
		character.arbitrary.res3Potion3Count += 4;
		character.arbitrary.lootCharm1Count += 4;
		character.arbitrary.energyBarBar1Count += 4;
		character.arbitrary.magicBarBar1Count += 4;
		character.arbitrary.poop1Count += 50;
		character.adventure.itopod.buffedKills += 4000L;
		character.arbitrary.lootCharm2Count += 4;
		character.arbitrary.macGuffinBooster1Count += 4;
		character.arbitrary.beastButterCount += 4;
		character.arbitrary.mayoSpeedPotCount += 4;
		character.arbitrary.cardTierUpperCount += 100;
		if (!character.inventoryController.freeSpace())
		{
			character.arbitrary.curArbitraryPoints += 500000L;
			text += "\n<b>An additional 500,000 AP because you had no space for the Rainbow Heart!</b>";
		}
		else if ((character.arbitrary.lootFilter && character.inventory.itemList.itemFiltered[390]) || (character.settings.filterOn && character.settings.filterAccessory))
		{
			character.arbitrary.curArbitraryPoints += 500000L;
			text += "\n<b>An additional 500,000 AP because you had the Rainbow Heart filtered!</b>";
		}
		else if (character.inventory.itemList.itemMaxxed[390])
		{
			character.arbitrary.curArbitraryPoints += 500000L;
			text += "\n<b>An additional 500,000 AP because you already had a maxxed out Rainbow Heart!</b>";
		}
		else
		{
			character.itemInfo.makeLevelledLoot(390, 10);
			text += "\n<b>A Rainbow Heart!</b>";
		}
		if (!character.arbitrary.boughtFoils)
		{
			character.arbitrary.boughtFoils = true;
			text += "\n<b>Perma Foils!</b>";
		}
		else
		{
			character.arbitrary.curArbitraryPoints += 250000L;
			text += "\n<b>An additional 250,000 AP because you already have Perma Foils!</b>";
		}
		character.arbitrary.boughtAscendedNewbiePack4 = true;
		text += "\n<b>Plus, you can PM me, and I'll do something... weird.</b>\n\nI'm going to save your game online, but PLEASE make a file save as well to ensure you don't lose what you bought!";
		tooltip.showOverrideTooltip(text, 11f);
		character.allArbitrary.updateMenu();
		character.APPackDisplay.refreshMenu();
		StartCoroutine(character.saveLoad.uploadSave(forced: false));
	}
}
