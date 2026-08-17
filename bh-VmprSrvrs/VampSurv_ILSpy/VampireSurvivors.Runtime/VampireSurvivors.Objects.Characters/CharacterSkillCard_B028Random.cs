using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;

namespace VampireSurvivors.Objects.Characters;

public class CharacterSkillCard_B028Random : CharacterSkillCard_Base
{
	public CharacterSkillCard_B028Random(ArcanaType type)
		: base(type)
	{
	}

	public override void InitialActivate()
	{
		//IL_16b1: Expected O, but got I4
		//IL_16be: Expected O, but got I8
		//IL_16f3: Expected O, but got I4
		//IL_177f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1784: Expected O, but got Unknown
		//IL_001f: Expected O, but got I8
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Expected O, but got Unknown
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Expected O, but got Unknown
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_0378: Expected O, but got Unknown
		//IL_041b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Expected O, but got Unknown
		//IL_04c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ca: Expected O, but got Unknown
		//IL_057f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0584: Expected O, but got Unknown
		//IL_06ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b1: Expected O, but got Unknown
		//IL_06e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ea: Expected O, but got Unknown
		//IL_078f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0794: Expected O, but got Unknown
		//IL_0849: Unknown result type (might be due to invalid IL or missing references)
		//IL_084e: Expected O, but got Unknown
		//IL_0903: Unknown result type (might be due to invalid IL or missing references)
		//IL_0908: Expected O, but got Unknown
		//IL_09ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ef: Expected O, but got Unknown
		//IL_0a5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5f: Expected O, but got Unknown
		//IL_0b82: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b87: Expected O, but got Unknown
		//IL_0be4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be9: Expected O, but got Unknown
		//IL_0cc8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ccd: Expected O, but got Unknown
		//IL_0dcd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd2: Expected O, but got Unknown
		//IL_0e4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e51: Expected O, but got Unknown
		//IL_0f20: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f25: Expected O, but got Unknown
		//IL_1025: Unknown result type (might be due to invalid IL or missing references)
		//IL_102a: Expected O, but got Unknown
		//IL_10a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a9: Expected O, but got Unknown
		//IL_1178: Unknown result type (might be due to invalid IL or missing references)
		//IL_117d: Expected O, but got Unknown
		//IL_127d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1282: Expected O, but got Unknown
		//IL_12fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1301: Expected O, but got Unknown
		//IL_13d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_13d5: Expected O, but got Unknown
		//IL_14d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_14da: Expected O, but got Unknown
		//IL_1554: Unknown result type (might be due to invalid IL or missing references)
		//IL_1559: Expected O, but got Unknown
		//IL_160d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1612: Expected O, but got Unknown
		base.InitialActivate();
		object obj = Random.RandomRangeInt(0, 7);
		object obj2 = 6442450944L;
		ModifierStats modifierStats = default(ModifierStats);
		object obj14 = default(object);
		object obj18 = default(object);
		if ((nint)obj <= 7)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rbp_v3+7570EC0+v99 @ rax_v11*4]");
			object obj3 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v116 @ rcx_v154 (should have been resolved before IL gen)");
		}
		else
		{
			object obj4 = Random.RandomRangeInt(1, 2147483647);
			object obj5 = obj4 << 13;
			object obj6 = obj4 ^ obj5;
			object obj7 = obj6 >> 17;
			object obj8 = obj6 ^ obj7;
			object obj9 = obj8 << 5;
			object obj10 = obj8 ^ obj9;
			modifierStats = new ModifierStats();
			object obj11 = obj10 << 13;
			object obj12 = obj10 ^ obj11;
			object obj13 = obj10 >> 9;
			obj14 = obj13 | 0x3F800000;
			object obj15 = obj12 >> 17;
			object obj16 = obj12 ^ obj15;
			object obj17 = obj16 << 5;
			obj18 = obj16 ^ obj17;
		}
		object obj19 = obj18 >> 9;
		object obj20 = obj19 | 0x3F800000;
		float num = (float)obj14 - 1f;
		float num2 = num - 0.025f;
		float num3 = num2 * 1f;
		modifierStats._003CMaxHp_003Ek__BackingField = num3;
		object obj21 = obj18 << 13;
		object obj22 = obj18 ^ obj21;
		float num4 = (float)obj20 - 1f;
		object obj23 = obj22 >> 17;
		object obj24 = obj22 ^ obj23;
		object obj25 = obj24 << 5;
		object obj26 = obj24 ^ obj25;
		float num5 = num4 - 0.1f;
		object obj27 = obj26 << 13;
		object obj28 = obj26 ^ obj27;
		object obj29 = obj26 >> 9;
		object obj30 = obj29 | 0x3F800000;
		float num6 = num5 * 0.01f;
		object obj31 = obj28 >> 17;
		object obj32 = obj28 ^ obj31;
		float num7 = num6 * 1f;
		object obj33 = obj32 << 5;
		object obj34 = obj32 ^ obj33;
		modifierStats._003CRegen_003Ek__BackingField = num7;
		object obj35 = obj34 << 13;
		object obj36 = obj34 ^ obj35;
		object obj37 = obj34 >> 9;
		float num8 = (float)obj30 - 1f;
		object obj38 = obj36 >> 17;
		object obj39 = obj37 | 0x3F800000;
		object obj40 = obj36 ^ obj38;
		object obj41 = obj40 << 5;
		float num9 = num8 - 0.1f;
		object obj42 = obj40 ^ obj41;
		object obj43 = obj42 << 13;
		float num10 = num9 * 0.01f;
		float num11 = num10 * 1f;
		modifierStats._003CArmor_003Ek__BackingField = num11;
		float num12 = (float)obj39 - 1f;
		object obj44 = obj42 >> 9;
		object obj45 = obj42 ^ obj43;
		object obj46 = obj45 >> 17;
		object obj47 = obj45 ^ obj46;
		float num13 = num12 - 0.1f;
		object obj48 = obj47 << 5;
		object obj49 = obj47 ^ obj48;
		object obj50 = obj44 | 0x3F800000;
		float num14 = num13 * 0.01f;
		float num15 = num14 * 1f;
		modifierStats._003CAmount_003Ek__BackingField = num15;
		float num16 = (float)obj50 - 1f;
		float num17 = num16 - 0.1f;
		float num18 = num17 * 0.01f;
		float num19 = num18 * 1f;
		modifierStats._003CRevivals_003Ek__BackingField = num19;
		object obj51 = obj49 >> 9;
		object obj52 = obj49 << 13;
		object obj53 = obj51 | 0x3F800000;
		object obj54 = obj49 ^ obj52;
		object obj55 = obj54 >> 17;
		object obj56 = obj54 ^ obj55;
		float num20 = (float)obj53 - 1f;
		object obj57 = obj56 << 5;
		object obj58 = obj56 ^ obj57;
		object obj59 = obj58 << 13;
		object obj60 = obj58 ^ obj59;
		object obj61 = obj58 >> 9;
		float num21 = num20 - 0.1f;
		object obj62 = obj60 >> 17;
		object obj63 = obj61 | 0x3F800000;
		object obj64 = obj60 ^ obj62;
		object obj65 = obj64 << 5;
		float num22 = num21 * 0.003f;
		object obj66 = obj64 ^ obj65;
		object obj67 = obj66 << 13;
		float num23 = num22 * 1f;
		modifierStats._003CMagnet_003Ek__BackingField = num23;
		object obj68 = obj66 ^ obj67;
		object obj69 = obj66 >> 9;
		float num24 = (float)obj63 - 1f;
		object obj70 = obj68 >> 17;
		object obj71 = obj69 | 0x3F800000;
		object obj72 = obj68 ^ obj70;
		object obj73 = obj72 << 5;
		object obj74 = obj72 ^ obj73;
		float num25 = num24 - 0.1f;
		object obj75 = obj74 << 13;
		float num26 = num25 * 0.01f;
		float num27 = num26 * 1f;
		modifierStats._003CSpeed_003Ek__BackingField = num27;
		object obj76 = obj74 ^ obj75;
		object obj77 = obj74 >> 9;
		float num28 = (float)obj71 - 1f;
		object obj78 = obj76 >> 17;
		object obj79 = obj77 | 0x3F800000;
		object obj80 = obj76 ^ obj78;
		object obj81 = obj80 << 5;
		float num29 = num28 - 0.2f;
		object obj82 = obj80 ^ obj81;
		object obj83 = obj82 << 13;
		float num30 = num29 * 0.01f;
		float num31 = num30 * 1f;
		modifierStats._003CMoveSpeed_003Ek__BackingField = num31;
		object obj84 = obj82 ^ obj83;
		float num32 = (float)obj79 - 1f;
		object obj85 = obj84 >> 17;
		object obj86 = obj84 ^ obj85;
		float num33 = num32 - 0.1f;
		object obj87 = obj86 << 5;
		object obj88 = obj86 ^ obj87;
		float num34 = num33 * 0.01f;
		float num35 = num34 * 1f;
		modifierStats._003CPower_003Ek__BackingField = num35;
		object obj89 = obj82 >> 9;
		object obj90 = obj88 << 13;
		object obj91 = obj89 | 0x3F800000;
		object obj92 = obj88 ^ obj90;
		object obj93 = obj88 >> 9;
		float num36 = (float)obj91 - 1f;
		object obj94 = obj93 | 0x3F800000;
		object obj95 = obj92 >> 17;
		object obj96 = obj92 ^ obj95;
		float num37 = num36 - 0.05f;
		object obj97 = obj96 << 5;
		object obj98 = obj96 ^ obj97;
		object obj99 = obj98 << 13;
		float num38 = num37 * -0.005f;
		modifierStats._003CCooldown_003Ek__BackingField = num38;
		object obj100 = obj98 ^ obj99;
		object obj101 = obj98 >> 9;
		float num39 = (float)obj94 - 1f;
		object obj102 = obj101 | 0x3F800000;
		object obj103 = obj100 >> 17;
		object obj104 = obj100 ^ obj103;
		float num40 = num39 - 0.1f;
		object obj105 = obj104 << 5;
		object obj106 = obj104 ^ obj105;
		object obj107 = obj106 << 13;
		float num41 = num40 * 0.01f;
		float num42 = num41 * 1f;
		modifierStats._003CArea_003Ek__BackingField = num42;
		object obj108 = obj106 ^ obj107;
		object obj109 = obj106 >> 9;
		float num43 = (float)obj102 - 1f;
		object obj110 = obj109 | 0x3F800000;
		object obj111 = obj108 >> 17;
		object obj112 = obj108 ^ obj111;
		float num44 = num43 - 0.1f;
		object obj113 = obj112 << 5;
		object obj114 = obj112 ^ obj113;
		object obj115 = obj114 << 13;
		float num45 = num44 * 0.01f;
		float num46 = num45 * 1f;
		modifierStats._003CDuration_003Ek__BackingField = num46;
		object obj116 = obj114 ^ obj115;
		object obj117 = obj114 >> 9;
		float num47 = (float)obj110 - 1f;
		object obj118 = obj117 | 0x3F800000;
		object obj119 = obj116 >> 17;
		object obj120 = obj116 ^ obj119;
		float num48 = num47 - 0.1f;
		object obj121 = obj120 << 5;
		object obj122 = obj120 ^ obj121;
		object obj123 = obj122 << 13;
		float num49 = num48 * 0.01f;
		float num50 = num49 * 1f;
		modifierStats._003CLuck_003Ek__BackingField = num50;
		float num51 = (float)obj118 - 1f;
		float num52 = num51 - 0.1f;
		float num53 = num52 * 0.01f;
		modifierStats._003CGrowth_003Ek__BackingField = num53;
		object obj124 = obj122 ^ obj123;
		object obj125 = obj122 >> 9;
		object obj126 = obj125 | 0x3F800000;
		object obj127 = obj124 >> 17;
		object obj128 = obj124 ^ obj127;
		object obj129 = obj128 << 5;
		object obj130 = obj128 ^ obj129;
		float num54 = (float)obj126 - 1f;
		object obj131 = obj130 >> 9;
		object obj132 = obj130 << 13;
		object obj133 = obj131 | 0x3F800000;
		object obj134 = obj130 ^ obj132;
		float num55 = num54 - 0.1f;
		object obj135 = obj134 >> 17;
		object obj136 = obj134 ^ obj135;
		object obj137 = obj136 << 5;
		object obj138 = obj136 ^ obj137;
		float num56 = num55 * 0.01f;
		modifierStats._003CGreed_003Ek__BackingField = num56;
		float num57 = (float)obj133 - 1f;
		float num58 = num57 - 0.025f;
		float num59 = num58 * 0.01f;
		float num60 = num59 * 1f;
		modifierStats._003CCurse_003Ek__BackingField = num60;
		OnEveryLevelUp = modifierStats;
		CharacterController linkedCharacter = LinkedCharacter;
		CharacterData currentCharacterData = linkedCharacter._currentCharacterData;
		SineBonusData sineBonusData = new SineBonusData();
		object obj139 = obj138 << 13;
		object obj140 = obj138 ^ obj139;
		object obj141 = obj138 >> 9;
		object obj142 = obj141 | 0x3F800000;
		object obj143 = obj140 >> 17;
		object obj144 = obj140 ^ obj143;
		object obj145 = obj144 << 5;
		object obj146 = obj144 ^ obj145;
		float num61 = (float)obj142 - 1f;
		object obj147 = obj146 >> 9;
		object obj148 = obj147 | 0x3F800000;
		float num62 = num61 + 0.1f;
		float num63 = num62 + num62;
		float num64 = num63 * 1f;
		sineBonusData._003Cmin_003Ek__BackingField = num64;
		object obj149 = obj146 << 13;
		object obj150 = obj146 ^ obj149;
		float num65 = (float)obj148 - 1f;
		object obj151 = obj150 >> 17;
		object obj152 = obj150 ^ obj151;
		object obj153 = obj152 << 5;
		object obj154 = obj152 ^ obj153;
		float num66 = num65 + 0.1f;
		object obj155 = obj154 << 13;
		object obj156 = obj154 ^ obj155;
		object obj157 = obj154 >> 9;
		object obj158 = obj157 | 0x3F800000;
		float num67 = num66 + num66;
		object obj159 = obj156 >> 17;
		object obj160 = obj156 ^ obj159;
		object obj161 = obj160 << 5;
		object obj162 = obj160 ^ obj161;
		float num68 = num67 * 1f;
		sineBonusData._003Cmax_003Ek__BackingField = num68;
		float num69 = (float)obj158 - 1f;
		float num70 = num69 + 0.1f;
		float num71 = num70 * 60000f;
		sineBonusData._003Cduration_003Ek__BackingField = num71;
		currentCharacterData._003CsineMight_003Ek__BackingField = sineBonusData;
		CharacterController linkedCharacter2 = LinkedCharacter;
		CharacterData currentCharacterData2 = linkedCharacter2._currentCharacterData;
		SineBonusData sineBonusData2 = new SineBonusData();
		object obj163 = obj162 >> 9;
		object obj164 = obj162 << 13;
		object obj165 = obj163 | 0x3F800000;
		object obj166 = obj162 ^ obj164;
		object obj167 = obj166 >> 17;
		object obj168 = obj166 ^ obj167;
		float num72 = (float)obj165 - 1f;
		object obj169 = obj168 << 5;
		object obj170 = obj168 ^ obj169;
		object obj171 = obj170 >> 9;
		float num73 = num72 + 0.1f;
		object obj172 = obj171 | 0x3F800000;
		float num74 = num73 + num73;
		float num75 = num74 * 1f;
		sineBonusData2._003Cmin_003Ek__BackingField = num75;
		object obj173 = obj170 << 13;
		object obj174 = obj170 ^ obj173;
		float num76 = (float)obj172 - 1f;
		object obj175 = obj174 >> 17;
		object obj176 = obj174 ^ obj175;
		object obj177 = obj176 << 5;
		object obj178 = obj176 ^ obj177;
		float num77 = num76 + 0.1f;
		object obj179 = obj178 << 13;
		object obj180 = obj178 ^ obj179;
		object obj181 = obj178 >> 9;
		object obj182 = obj181 | 0x3F800000;
		float num78 = num77 + num77;
		object obj183 = obj180 >> 17;
		object obj184 = obj180 ^ obj183;
		object obj185 = obj184 << 5;
		object obj186 = obj184 ^ obj185;
		float num79 = num78 * 1f;
		sineBonusData2._003Cmax_003Ek__BackingField = num79;
		float num80 = (float)obj182 - 1f;
		float num81 = num80 + 0.1f;
		float num82 = num81 * 60000f;
		sineBonusData2._003Cduration_003Ek__BackingField = num82;
		currentCharacterData2._003CsineSpeed_003Ek__BackingField = sineBonusData2;
		CharacterController linkedCharacter3 = LinkedCharacter;
		CharacterData currentCharacterData3 = linkedCharacter3._currentCharacterData;
		SineBonusData sineBonusData3 = new SineBonusData();
		object obj187 = obj186 >> 9;
		object obj188 = obj186 << 13;
		object obj189 = obj187 | 0x3F800000;
		object obj190 = obj186 ^ obj188;
		object obj191 = obj190 >> 17;
		object obj192 = obj190 ^ obj191;
		float num83 = (float)obj189 - 1f;
		object obj193 = obj192 << 5;
		object obj194 = obj192 ^ obj193;
		object obj195 = obj194 >> 9;
		float num84 = num83 + 0.1f;
		object obj196 = obj195 | 0x3F800000;
		float num85 = num84 + num84;
		float num86 = num85 * 1f;
		sineBonusData3._003Cmin_003Ek__BackingField = num86;
		object obj197 = obj194 << 13;
		object obj198 = obj194 ^ obj197;
		float num87 = (float)obj196 - 1f;
		object obj199 = obj198 >> 17;
		object obj200 = obj198 ^ obj199;
		object obj201 = obj200 << 5;
		object obj202 = obj200 ^ obj201;
		float num88 = num87 + 0.1f;
		object obj203 = obj202 << 13;
		object obj204 = obj202 ^ obj203;
		object obj205 = obj202 >> 9;
		object obj206 = obj205 | 0x3F800000;
		float num89 = num88 + num88;
		object obj207 = obj204 >> 17;
		object obj208 = obj204 ^ obj207;
		object obj209 = obj208 << 5;
		object obj210 = obj208 ^ obj209;
		float num90 = num89 * 1f;
		sineBonusData3._003Cmax_003Ek__BackingField = num90;
		float num91 = (float)obj206 - 1f;
		float num92 = num91 + 0.1f;
		float num93 = num92 * 60000f;
		sineBonusData3._003Cduration_003Ek__BackingField = num93;
		currentCharacterData3._003CsineDuration_003Ek__BackingField = sineBonusData3;
		CharacterController linkedCharacter4 = LinkedCharacter;
		CharacterData currentCharacterData4 = linkedCharacter4._currentCharacterData;
		SineBonusData sineBonusData4 = new SineBonusData();
		object obj211 = obj210 >> 9;
		object obj212 = obj210 << 13;
		object obj213 = obj211 | 0x3F800000;
		object obj214 = obj210 ^ obj212;
		object obj215 = obj214 >> 17;
		object obj216 = obj214 ^ obj215;
		float num94 = (float)obj213 - 1f;
		object obj217 = obj216 << 5;
		object obj218 = obj216 ^ obj217;
		object obj219 = obj218 >> 9;
		float num95 = num94 + 0.1f;
		object obj220 = obj219 | 0x3F800000;
		float num96 = num95 + num95;
		float num97 = num96 * 1f;
		sineBonusData4._003Cmin_003Ek__BackingField = num97;
		object obj221 = obj218 << 13;
		object obj222 = obj218 ^ obj221;
		float num98 = (float)obj220 - 1f;
		object obj223 = obj222 >> 17;
		object obj224 = obj222 ^ obj223;
		object obj225 = obj224 << 5;
		object obj226 = obj224 ^ obj225;
		float num99 = num98 + 0.1f;
		object obj227 = obj226 << 13;
		object obj228 = obj226 ^ obj227;
		object obj229 = obj226 >> 9;
		object obj230 = obj229 | 0x3F800000;
		float num100 = num99 + num99;
		object obj231 = obj228 >> 17;
		object obj232 = obj228 ^ obj231;
		object obj233 = obj232 << 5;
		object obj234 = obj232 ^ obj233;
		float num101 = num100 * 1f;
		sineBonusData4._003Cmax_003Ek__BackingField = num101;
		float num102 = (float)obj230 - 1f;
		float num103 = num102 + 0.1f;
		float num104 = num103 * 60000f;
		sineBonusData4._003Cduration_003Ek__BackingField = num104;
		currentCharacterData4._003CsineArea_003Ek__BackingField = sineBonusData4;
		CharacterController linkedCharacter5 = LinkedCharacter;
		CharacterData currentCharacterData5 = linkedCharacter5._currentCharacterData;
		SineBonusData sineBonusData5 = new SineBonusData();
		object obj235 = obj234 >> 9;
		object obj236 = obj234 << 13;
		object obj237 = obj235 | 0x3F800000;
		object obj238 = obj234 ^ obj236;
		object obj239 = obj238 >> 17;
		object obj240 = obj238 ^ obj239;
		float num105 = (float)obj237 - 1f;
		object obj241 = obj240 << 5;
		object obj242 = obj240 ^ obj241;
		object obj243 = obj242 >> 9;
		float num106 = num105 + 0.1f;
		object obj244 = obj243 | 0x3F800000;
		float num107 = num106 + num106;
		float num108 = num107 * 1f;
		sineBonusData5._003Cmin_003Ek__BackingField = num108;
		object obj245 = obj242 << 13;
		object obj246 = obj242 ^ obj245;
		float num109 = (float)obj244 - 1f;
		object obj247 = obj246 >> 17;
		object obj248 = obj246 ^ obj247;
		object obj249 = obj248 << 5;
		float num110 = num109 + 0.1f;
		object obj250 = obj249 ^ obj248;
		object obj251 = obj250 >> 9;
		object obj252 = obj251 | 0x3F800000;
		float num111 = num110 + num110;
		float num112 = num111 * 1f;
		sineBonusData5._003Cmax_003Ek__BackingField = num112;
		float num113 = (float)obj252 - 1f;
		float num114 = num113 + 0.1f;
		float num115 = num114 * 60000f;
		sineBonusData5._003Cduration_003Ek__BackingField = num115;
		currentCharacterData5._003CsineCooldown_003Ek__BackingField = sineBonusData5;
	}
}
