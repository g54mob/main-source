using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemList
{
	public List<bool> itemDropped = new List<bool>();

	public List<bool> itemMaxxed = new List<bool>();

	public List<bool> itemFiltered = new List<bool>();

	public int totalDiscovered;

	public int totalMaxxed;

	public bool trainingComplete;

	public bool sewersComplete;

	public bool forestComplete;

	public bool caveComplete;

	public bool skyComplete;

	public bool HSBComplete;

	public bool GRBComplete;

	public bool clockComplete;

	public bool twoDComplete;

	public bool ghostComplete;

	public bool jakeComplete;

	public bool gaudyComplete;

	public bool megaComplete;

	public bool beardverseComplete;

	public bool waldoComplete;

	public bool antiWaldoComplete;

	public bool badlyDrawnComplete;

	public bool stealthComplete;

	public bool beast1complete;

	public bool chocoComplete;

	public bool edgyComplete;

	public bool edgyBootsComplete;

	public bool prettyComplete;

	public bool nerdComplete;

	public bool metaComplete;

	public bool partyComplete;

	public bool godmotherComplete;

	public bool typoComplete;

	public bool fadComplete;

	public bool jrpgComplete;

	public bool exileComplete;

	public bool radComplete;

	public bool schoolComplete;

	public bool westernComplete;

	public bool spaceComplete;

	public bool breadverseComplete;

	public bool that70sComplete;

	public bool halloweeniesComplete;

	public bool rockLobsterComplete;

	public bool constructionComplete;

	public bool duckComplete;

	public bool netherComplete;

	public bool amalgamateComplete;

	public bool pirateComplete;

	public bool wandoosComplete;

	public bool tutorialCubeComplete;

	public bool numberComplete;

	public bool flubberComplete;

	public bool seedComplete;

	public bool uugComplete;

	public bool uugRingComplete;

	public bool redLiquidComplete;

	public bool brownHeartComplete;

	public bool xlComplete;

	public bool greenHeartComplete;

	public bool itopodKeyComplete;

	public bool purpleLiquidComplete;

	public bool blueHeartComplete;

	public bool jakeNoteComplete;

	public bool purpleHeartComplete;

	public bool orangeHeartComplete;

	public bool greyHeartComplete;

	public bool sigilComplete;

	public bool evidenceComplete;

	public bool pinkHeartComplete;

	public bool severedHeadComplete;

	public bool rainbowHeartComplete;

	public bool beatingHeartComplete;

	public bool normalBonusAccComplete;

	public bool evilBonusAccComplete;

	public ItemList()
	{
		for (int i = 0; i < 600; i++)
		{
			itemDropped.Add(item: false);
			itemMaxxed.Add(item: false);
			itemFiltered.Add(item: false);
		}
		totalDiscovered = 0;
		totalMaxxed = 0;
		trainingComplete = false;
		sewersComplete = false;
		forestComplete = false;
		caveComplete = false;
		skyComplete = false;
		HSBComplete = false;
		GRBComplete = false;
		clockComplete = false;
		twoDComplete = false;
		ghostComplete = false;
		jakeComplete = false;
		gaudyComplete = false;
		megaComplete = false;
		beardverseComplete = false;
		waldoComplete = false;
		antiWaldoComplete = false;
		badlyDrawnComplete = false;
		stealthComplete = false;
		beast1complete = false;
		chocoComplete = false;
		edgyComplete = false;
		edgyBootsComplete = false;
		prettyComplete = false;
		nerdComplete = false;
		metaComplete = false;
		partyComplete = false;
		godmotherComplete = false;
		typoComplete = false;
		fadComplete = false;
		jrpgComplete = false;
		exileComplete = false;
		radComplete = false;
		schoolComplete = false;
		westernComplete = false;
		spaceComplete = false;
		breadverseComplete = false;
		that70sComplete = false;
		halloweeniesComplete = false;
		rockLobsterComplete = false;
		constructionComplete = false;
		duckComplete = false;
		netherComplete = false;
		amalgamateComplete = false;
		pirateComplete = false;
		wandoosComplete = false;
		tutorialCubeComplete = false;
		numberComplete = false;
		flubberComplete = false;
		seedComplete = false;
		uugComplete = false;
		uugRingComplete = false;
		redLiquidComplete = false;
		brownHeartComplete = false;
		xlComplete = false;
		greenHeartComplete = false;
		itopodKeyComplete = false;
		purpleLiquidComplete = false;
		blueHeartComplete = false;
		jakeNoteComplete = false;
		purpleHeartComplete = false;
		orangeHeartComplete = false;
		greyHeartComplete = false;
		sigilComplete = false;
		evidenceComplete = false;
		greyHeartComplete = false;
		pinkHeartComplete = false;
		severedHeadComplete = false;
		rainbowHeartComplete = false;
		normalBonusAccComplete = false;
		evilBonusAccComplete = false;
	}

	public void checkItemList()
	{
		if (itemDropped == null)
		{
			itemDropped = new List<bool>();
		}
		if (itemMaxxed == null)
		{
			itemDropped = new List<bool>();
		}
		if (itemFiltered == null)
		{
			itemFiltered = new List<bool>();
		}
		while (itemDropped.Count < 600)
		{
			itemDropped.Add(item: false);
		}
		while (itemMaxxed.Count < 600)
		{
			itemMaxxed.Add(item: false);
		}
		while (itemFiltered.Count < 600)
		{
			itemFiltered.Add(item: false);
		}
		if (itemDropped.Count >= 289 && itemDropped[288] && !itemMaxxed[288])
		{
			itemMaxxed[288] = true;
		}
	}

	public void debugList()
	{
		for (int i = 0; i < 500; i++)
		{
			Debug.Log(i + " id dropped is " + itemDropped[i].ToString());
			Debug.Log(i + " id maxxxed is " + itemMaxxed[i].ToString());
			Debug.Log(i + " id filtered is " + itemMaxxed[i].ToString());
		}
	}

	public void debugList(int i)
	{
		Debug.Log(i + " id dropped is " + itemDropped[i].ToString());
		Debug.Log(i + " id maxxxed is " + itemMaxxed[i].ToString());
		Debug.Log(i + " id filtered is " + itemMaxxed[i].ToString());
	}

	public float totalBonus()
	{
		return (1f + (float)totalDiscovered * 0.005f) * (1f + (float)totalMaxxed * 0.01f);
	}

	public bool maxxedTraining()
	{
		if (itemMaxxed[62] && itemMaxxed[63] && itemMaxxed[64] && itemMaxxed[65])
		{
			return itemMaxxed[75];
		}
		return false;
	}

	public bool maxxedSewers()
	{
		if (itemMaxxed[40] && itemMaxxed[41] && itemMaxxed[42] && itemMaxxed[43] && itemMaxxed[44] && itemMaxxed[45])
		{
			return itemMaxxed[46];
		}
		return false;
	}

	public bool maxxedForest()
	{
		if (itemMaxxed[47] && itemMaxxed[48] && itemMaxxed[49] && itemMaxxed[50] && itemMaxxed[51] && itemMaxxed[52])
		{
			return itemMaxxed[53];
		}
		return false;
	}

	public bool maxxedCave()
	{
		if (itemMaxxed[54] && itemMaxxed[55] && itemMaxxed[56] && itemMaxxed[57] && itemMaxxed[58] && itemMaxxed[59] && itemMaxxed[60])
		{
			return itemMaxxed[61];
		}
		return false;
	}

	public bool maxxedHSB()
	{
		if (itemMaxxed[68] && itemMaxxed[69] && itemMaxxed[70] && itemMaxxed[71] && itemMaxxed[72] && itemMaxxed[73])
		{
			return itemMaxxed[74];
		}
		return false;
	}

	public bool maxxedGRB()
	{
		if (itemMaxxed[78] && itemMaxxed[79] && itemMaxxed[80] && itemMaxxed[81] && itemMaxxed[82] && itemMaxxed[83])
		{
			return itemMaxxed[84];
		}
		return false;
	}

	public bool maxxedClock()
	{
		if (itemMaxxed[85] && itemMaxxed[86] && itemMaxxed[87] && itemMaxxed[88] && itemMaxxed[89] && itemMaxxed[90])
		{
			return itemMaxxed[91];
		}
		return false;
	}

	public bool maxxed2D()
	{
		if (itemMaxxed[95] && itemMaxxed[96] && itemMaxxed[97] && itemMaxxed[98] && itemMaxxed[99] && itemMaxxed[100])
		{
			return itemMaxxed[101];
		}
		return false;
	}

	public bool maxxedGhost()
	{
		if (itemMaxxed[103] && itemMaxxed[104] && itemMaxxed[105] && itemMaxxed[106] && itemMaxxed[107] && itemMaxxed[108])
		{
			return itemMaxxed[109];
		}
		return false;
	}

	public bool maxxedJake()
	{
		if (itemMaxxed[111] && itemMaxxed[112] && itemMaxxed[113] && itemMaxxed[114] && itemMaxxed[115] && itemMaxxed[116])
		{
			return itemMaxxed[117];
		}
		return false;
	}

	public bool maxxedGaudy()
	{
		if (itemMaxxed[122] && itemMaxxed[123] && itemMaxxed[124] && itemMaxxed[125])
		{
			return itemMaxxed[126];
		}
		return false;
	}

	public bool maxxedMega()
	{
		if (itemMaxxed[130] && itemMaxxed[131] && itemMaxxed[132] && itemMaxxed[133])
		{
			return itemMaxxed[134];
		}
		return false;
	}

	public bool maxxedWandoos()
	{
		return itemMaxxed[66];
	}

	public bool maxxedNumber()
	{
		return itemMaxxed[102];
	}

	public bool maxxedTutorialCube()
	{
		return itemMaxxed[77];
	}

	public bool receivedGRBSet()
	{
		if (itemDropped[78] && itemDropped[79] && itemDropped[80] && itemDropped[81] && itemDropped[82] && itemDropped[83])
		{
			return itemDropped[84];
		}
		return false;
	}

	public bool maxxedFlubber()
	{
		return itemMaxxed[121];
	}

	public bool maxxedSeed()
	{
		return itemMaxxed[92];
	}

	public bool maxxedUUG()
	{
		return itemMaxxed[141];
	}

	public bool maxxedRingUUG()
	{
		if (itemMaxxed[136] && itemMaxxed[137] && itemMaxxed[138] && itemMaxxed[139])
		{
			return itemMaxxed[140];
		}
		return false;
	}

	public bool maxxedBeardverse()
	{
		if (itemMaxxed[143] && itemMaxxed[144] && itemMaxxed[145] && itemMaxxed[146])
		{
			return itemMaxxed[147];
		}
		return false;
	}

	public bool maxxedRedLiquid()
	{
		return itemMaxxed[93];
	}

	public bool maxxedWaldo()
	{
		if (itemMaxxed[150] && itemMaxxed[151] && itemMaxxed[152])
		{
			return itemMaxxed[153];
		}
		return false;
	}

	public bool maxxedAntiWaldo()
	{
		if (itemMaxxed[155] && itemMaxxed[156] && itemMaxxed[157])
		{
			return itemMaxxed[158];
		}
		return false;
	}

	public bool maxxedBadlyDrawn()
	{
		if (itemMaxxed[164] && itemMaxxed[165] && itemMaxxed[166] && itemMaxxed[167])
		{
			return itemMaxxed[168];
		}
		return false;
	}

	public bool maxxedStealth()
	{
		if (itemMaxxed[173] && itemMaxxed[174] && itemMaxxed[175] && itemMaxxed[176])
		{
			return itemMaxxed[177];
		}
		return false;
	}

	public bool maxxedBeast1()
	{
		if (itemMaxxed[184] && itemMaxxed[185] && itemMaxxed[186] && itemMaxxed[187])
		{
			return itemMaxxed[188];
		}
		return false;
	}

	public bool maxxedEdgy()
	{
		if (itemMaxxed[213] && itemMaxxed[214] && itemMaxxed[215] && itemMaxxed[217])
		{
			return itemMaxxed[218];
		}
		return false;
	}

	public bool maxxedEdgyBoots()
	{
		if (itemMaxxed[216])
		{
			return itemMaxxed[219];
		}
		return false;
	}

	public bool maxxedBrownHeart()
	{
		return itemMaxxed[162];
	}

	public bool maxxedXL()
	{
		return itemMaxxed[163];
	}

	public bool maxxedGreenHeart()
	{
		return itemMaxxed[171];
	}

	public bool maxxedItopodKey()
	{
		return itemMaxxed[172];
	}

	public bool maxxedPurpleLiquid()
	{
		return itemMaxxed[191];
	}

	public bool maxxedBlueHeart()
	{
		return itemMaxxed[196];
	}

	public bool maxxedJakeNote()
	{
		return itemMaxxed[197];
	}

	public bool maxxedPurpleHeart()
	{
		return itemMaxxed[212];
	}

	public bool maxxedGreyHeart()
	{
		return itemMaxxed[297];
	}

	public bool maxxedPinkHeart()
	{
		return itemMaxxed[344];
	}

	public bool maxxedChoco()
	{
		if (itemMaxxed[221] && itemMaxxed[222] && itemMaxxed[223] && itemMaxxed[224])
		{
			return itemMaxxed[225];
		}
		return false;
	}

	public bool maxxedPretty()
	{
		if (itemMaxxed[231] && itemMaxxed[232] && itemMaxxed[233] && itemMaxxed[234] && itemMaxxed[235])
		{
			return itemMaxxed[236];
		}
		return false;
	}

	public bool maxxedNerd()
	{
		if (itemMaxxed[237] && itemMaxxed[238] && itemMaxxed[239] && itemMaxxed[240])
		{
			return itemMaxxed[241];
		}
		return false;
	}

	public bool maxxedMeta()
	{
		if (itemMaxxed[251] && itemMaxxed[252] && itemMaxxed[253] && itemMaxxed[254] && itemMaxxed[255] && itemMaxxed[256])
		{
			return itemMaxxed[257];
		}
		return false;
	}

	public bool maxxedParty()
	{
		if (itemMaxxed[258] && itemMaxxed[259] && itemMaxxed[260] && itemMaxxed[261] && itemMaxxed[262] && itemMaxxed[263])
		{
			return itemMaxxed[264];
		}
		return false;
	}

	public bool maxxedGodmother()
	{
		if (itemMaxxed[265] && itemMaxxed[266] && itemMaxxed[267] && itemMaxxed[268] && itemMaxxed[269] && itemMaxxed[270])
		{
			return itemMaxxed[271];
		}
		return false;
	}

	public bool maxxedOrangeHeart()
	{
		return itemMaxxed[293];
	}

	public bool maxxedHeroicSigil()
	{
		return itemMaxxed[292];
	}

	public bool maxxedEvidence()
	{
		return itemMaxxed[294];
	}

	public bool maxxedSeveredHead()
	{
		return itemMaxxed[343];
	}

	public bool maxxedTypo()
	{
		if (itemMaxxed[301] && itemMaxxed[302] && itemMaxxed[303] && itemMaxxed[304] && itemMaxxed[305] && itemMaxxed[306])
		{
			return itemMaxxed[307];
		}
		return false;
	}

	public bool maxxedFad()
	{
		if (itemMaxxed[308] && itemMaxxed[309] && itemMaxxed[310] && itemMaxxed[311] && itemMaxxed[312] && itemMaxxed[313])
		{
			return itemMaxxed[314];
		}
		return false;
	}

	public bool maxxedJRPG()
	{
		if (itemMaxxed[315] && itemMaxxed[316] && itemMaxxed[317] && itemMaxxed[318] && itemMaxxed[319] && itemMaxxed[320])
		{
			return itemMaxxed[321];
		}
		return false;
	}

	public bool maxxedExile()
	{
		if (itemMaxxed[322] && itemMaxxed[323] && itemMaxxed[324] && itemMaxxed[325])
		{
			return itemMaxxed[326];
		}
		return false;
	}

	public bool droppedAllSewers()
	{
		if (itemDropped[40] && itemDropped[41] && itemDropped[42] && itemDropped[43] && itemDropped[44] && itemDropped[45])
		{
			return itemDropped[46];
		}
		return false;
	}

	public bool maxxedRad()
	{
		if (itemMaxxed[345] && itemMaxxed[346] && itemMaxxed[347] && itemMaxxed[348] && itemMaxxed[349] && itemMaxxed[350])
		{
			return itemMaxxed[351];
		}
		return false;
	}

	public bool maxxedSchool()
	{
		if (itemMaxxed[352] && itemMaxxed[353] && itemMaxxed[354] && itemMaxxed[355] && itemMaxxed[356] && itemMaxxed[357])
		{
			return itemMaxxed[358];
		}
		return false;
	}

	public bool maxxedWestern()
	{
		if (itemMaxxed[359] && itemMaxxed[360] && itemMaxxed[361] && itemMaxxed[362] && itemMaxxed[363] && itemMaxxed[364])
		{
			return itemMaxxed[365];
		}
		return false;
	}

	public bool maxxedSpace()
	{
		if (itemMaxxed[373] && itemMaxxed[374] && itemMaxxed[375] && itemMaxxed[376] && itemMaxxed[377] && itemMaxxed[378])
		{
			return itemMaxxed[379];
		}
		return false;
	}

	public bool maxxedRainbowHeart()
	{
		return itemMaxxed[390];
	}

	public bool maxxedBeatingHeart()
	{
		return itemMaxxed[391];
	}

	public bool maxxedBread()
	{
		if (itemMaxxed[392] && itemMaxxed[393] && itemMaxxed[394] && itemMaxxed[395] && itemMaxxed[396] && itemMaxxed[397] && itemMaxxed[398])
		{
			return itemMaxxed[399];
		}
		return false;
	}

	public bool maxxed70sZone()
	{
		if (itemMaxxed[400] && itemMaxxed[401] && itemMaxxed[402] && itemMaxxed[403] && itemMaxxed[404] && itemMaxxed[405] && itemMaxxed[406])
		{
			return itemMaxxed[407];
		}
		return false;
	}

	public bool maxxedHalloweenies()
	{
		if (itemMaxxed[408] && itemMaxxed[409] && itemMaxxed[410] && itemMaxxed[411] && itemMaxxed[412] && itemMaxxed[413] && itemMaxxed[414])
		{
			return itemMaxxed[415];
		}
		return false;
	}

	public bool maxxedRockLobster()
	{
		if (itemMaxxed[416] && itemMaxxed[417] && itemMaxxed[418] && itemMaxxed[419] && itemMaxxed[420] && itemMaxxed[421] && itemMaxxed[422])
		{
			return itemMaxxed[423];
		}
		return false;
	}

	public bool maxxedConstruction()
	{
		if (itemMaxxed[453] && itemMaxxed[454] && itemMaxxed[455] && itemMaxxed[456] && itemMaxxed[457] && itemMaxxed[458] && itemMaxxed[459])
		{
			return itemMaxxed[460];
		}
		return false;
	}

	public bool maxxedDuck()
	{
		if (itemMaxxed[496] && itemMaxxed[497] && itemMaxxed[498] && itemMaxxed[499] && itemMaxxed[500] && itemMaxxed[501] && itemMaxxed[502])
		{
			return itemMaxxed[503];
		}
		return false;
	}

	public bool maxxedNether()
	{
		if (itemMaxxed[461] && itemMaxxed[462] && itemMaxxed[463] && itemMaxxed[464] && itemMaxxed[465] && itemMaxxed[466] && itemMaxxed[467])
		{
			return itemMaxxed[468];
		}
		return false;
	}

	public bool maxxedAmalgamate()
	{
		if (itemMaxxed[469] && itemMaxxed[470] && itemMaxxed[471] && itemMaxxed[472] && itemMaxxed[473] && itemMaxxed[474] && itemMaxxed[475])
		{
			return itemMaxxed[476];
		}
		return false;
	}

	public bool maxxedPirate()
	{
		if (itemMaxxed[507] && itemMaxxed[508] && itemMaxxed[509] && itemMaxxed[510] && itemMaxxed[511] && itemMaxxed[512] && itemMaxxed[513])
		{
			return itemMaxxed[514];
		}
		return false;
	}

	public bool maxxedNormalBonusAcc()
	{
		if (itemMaxxed[432] && itemMaxxed[433] && itemMaxxed[434] && itemMaxxed[435] && itemMaxxed[436] && itemMaxxed[437] && itemMaxxed[438] && itemMaxxed[439] && itemMaxxed[440] && itemMaxxed[441] && itemMaxxed[442] && itemMaxxed[443])
		{
			return itemMaxxed[444];
		}
		return false;
	}

	public bool maxxedEvilBonusAcc()
	{
		if (itemMaxxed[445] && itemMaxxed[446] && itemMaxxed[447] && itemMaxxed[448] && itemMaxxed[449] && itemMaxxed[450] && itemMaxxed[451])
		{
			return itemMaxxed[452];
		}
		return false;
	}
}
