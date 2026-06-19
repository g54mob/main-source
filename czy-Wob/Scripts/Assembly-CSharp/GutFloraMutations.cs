using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

public class GutFloraMutations
{
	private static float maxPropertyChangePerGeneration = 0.33f;

	private static Color colorWhite = Color.white;

	private static Color colorHam = new Color(1f, 0.71f, 0.91f);

	private static Color colorBrown = new Color(0.8f, 0.5f, 0.22f);

	private static Color colorOrange = new Color(1f, 0.5f, 0f);

	private static Color colorPink = new Color(1f, 0.55f, 1f);

	private static Color colorYellow = new Color(1f, 1f, 0f);

	private static Color colorBlue = new Color(0f, 0f, 1f);

	private static Color colorGreen = new Color(0f, 1f, 0f);

	private static Color colorLightGreen = new Color(0.4f, 1f, 0.4f);

	private static Color colorDarkGreen = new Color(0f, 0.6f, 0f);

	private static Color colorBlack = new Color(0f, 0f, 0f);

	private static Color colorPurple = new Color(0.6f, 0f, 0.6f);

	private static Color colorRed = new Color(1f, 0f, 0f);

	public static string GetReadableNameForMutationEffect(GutFloraMutationEffect effect)
	{
		switch (effect)
		{
		case GutFloraMutationEffect.LONG_LEGS:
			return ScriptLocalization.Flora.EFFECT_LONGLEGS;
		case GutFloraMutationEffect.SHORT_LEGS:
			return ScriptLocalization.Flora.EFFECT_SHORTLEGS;
		case GutFloraMutationEffect.THICK_BODY:
			return ScriptLocalization.Flora.EFFECT_THICKBODY;
		case GutFloraMutationEffect.THIN_BODY:
			return ScriptLocalization.Flora.EFFECT_THINBODY;
		case GutFloraMutationEffect.LONG_BODY:
			return ScriptLocalization.Flora.EFFECT_LONGBODY;
		case GutFloraMutationEffect.SHORT_BODY:
			return ScriptLocalization.Flora.EFFECT_SHORTBODY;
		case GutFloraMutationEffect.BIG:
			return ScriptLocalization.Flora.EFFECT_BIG;
		case GutFloraMutationEffect.SMALL:
			return ScriptLocalization.Flora.EFFECT_SMALL;
		case GutFloraMutationEffect.DROOPY_FACE:
			return ScriptLocalization.Flora.EFFECT_DROOPYFACE;
		case GutFloraMutationEffect.DEFAULT_COLORS:
			return ScriptLocalization.Flora.EFFECT_DEFAULTCOL;
		case GutFloraMutationEffect.ORANGE_SKIN:
			return ScriptLocalization.Flora.EFFECT_ORANGECOL;
		case GutFloraMutationEffect.YELLOW_SKIN:
			return ScriptLocalization.Flora.EFFECT_YELLOWCOL;
		case GutFloraMutationEffect.BROWN_EVERYTHING:
			return ScriptLocalization.Flora.EFFECT_BROWNCOL;
		case GutFloraMutationEffect.GREEN_SKIN:
			return ScriptLocalization.Flora.EFFECT_GREENCOL;
		case GutFloraMutationEffect.WHITE_EVERYTHING:
			return ScriptLocalization.Flora.EFFECT_WHITECOL;
		case GutFloraMutationEffect.DESATURATED_COLORS:
			return ScriptLocalization.Flora.EFFECT_DESATURATEDCOL;
		case GutFloraMutationEffect.BROWN_BODY:
			return ScriptLocalization.Flora.EFFECT_BROWNBODY;
		case GutFloraMutationEffect.HAM_COLORED_BODY:
			return ScriptLocalization.Flora.EFFECT_HAMBODY;
		case GutFloraMutationEffect.YELLOW_BODY:
			return ScriptLocalization.Flora.EFFECT_YELLOWBODY;
		case GutFloraMutationEffect.PURPLE_BODY:
			return ScriptLocalization.Flora.EFFECT_PURPLEBODY;
		case GutFloraMutationEffect.WHITE_BODY:
			return ScriptLocalization.Flora.EFFECT_WHITEBODY;
		case GutFloraMutationEffect.BLACK_BODY:
			return ScriptLocalization.Flora.EFFECT_BLACKBODY;
		case GutFloraMutationEffect.GREEN_BODY:
			return ScriptLocalization.Flora.EFFECT_GREENBODY;
		case GutFloraMutationEffect.YELLOW_PATTERN:
			return ScriptLocalization.Flora.EFFECT_YELLOWPATT;
		case GutFloraMutationEffect.BLACK_PATTERN:
			return ScriptLocalization.Flora.EFFECT_BLACKPATT;
		case GutFloraMutationEffect.WHITE_PATTERN:
			return ScriptLocalization.Flora.EFFECT_WHITEPATTERN;
		case GutFloraMutationEffect.DARK_GREEN_PATTERN:
			return ScriptLocalization.Flora.EFFECT_DARKGREENPATTERN;
		case GutFloraMutationEffect.RED_PATTERN:
			return ScriptLocalization.Flora.EFFECT_REDPATT;
		case GutFloraMutationEffect.ORANGE_NOSE_EARS:
			return ScriptLocalization.Flora.EFFECT_ORANGENOSEEAR;
		case GutFloraMutationEffect.BLUE_NOSE_EARS:
			return ScriptLocalization.Flora.EFFECT_BLUENOSEEARS;
		case GutFloraMutationEffect.RED_NOSE_EARS:
			return ScriptLocalization.Flora.EFFECT_REDNOSEEAR;
		case GutFloraMutationEffect.RANDOM_MUTATIONS:
			return ScriptLocalization.Flora.EFFECT_RANDOMMUTATIONS;
		case GutFloraMutationEffect.WHITE_LEGS:
			return ScriptLocalization.Flora.EFFECT_WHITELEGS;
		case GutFloraMutationEffect.PINK_LEGS:
			return ScriptLocalization.Flora.EFFECT_PINKLEGS;
		case GutFloraMutationEffect.BLUE_LEGS:
			return ScriptLocalization.Flora.EFFECT_BLUELEGS;
		case GutFloraMutationEffect.LIGHT_GREEN_LEGS:
			return ScriptLocalization.Flora.EFFECT_LIGHTGREENLEGS;
		case GutFloraMutationEffect.LEG_COUNT:
			return ScriptLocalization.Flora.EFFECT_LEGNUMBER;
		case GutFloraMutationEffect.LONG_SNOUT:
			return ScriptLocalization.Flora.EFFECT_LONGSNOUT;
		case GutFloraMutationEffect.SHORT_SNOUT:
			return ScriptLocalization.Flora.EFFECT_SHORTSNOUT;
		case GutFloraMutationEffect.LONG_EARS:
			return ScriptLocalization.Flora.EFFECT_LONGEARS;
		case GutFloraMutationEffect.SHORT_EARS:
			return ScriptLocalization.Flora.EFFECT_SHORTEARS;
		case GutFloraMutationEffect.BIG_NOSE:
			return ScriptLocalization.Flora.EFFECT_BIGNOSE;
		case GutFloraMutationEffect.TINY_NOSE:
			return ScriptLocalization.Flora.EFFECT_TINYNOSE;
		case GutFloraMutationEffect.INVERTED_SNOUT:
			return ScriptLocalization.Flora.EFFECT_INVERTEDSNOUT;
		case GutFloraMutationEffect.WIDE_STANCE:
			return ScriptLocalization.Flora.EFFECT_WIDESTANCE;
		case GutFloraMutationEffect.NARROW_STANCE:
			return ScriptLocalization.Flora.EFFECT_NARROWSTANCE;
		case GutFloraMutationEffect.THICK_LEGS:
			return ScriptLocalization.Flora.EFFECT_THICKLEGS;
		case GutFloraMutationEffect.SKINNY_LEGS:
			return ScriptLocalization.Flora.EFFECT_SKINNYLEGS;
		case GutFloraMutationEffect.GLOSSY_SHEEN:
			return ScriptLocalization.Flora.EFFECT_GLOSSYSHEEN;
		case GutFloraMutationEffect.METALLIC_SHEEN:
			return ScriptLocalization.Flora.EFFECT_METALSHEEN;
		case GutFloraMutationEffect.MATTE_FINISH:
			return ScriptLocalization.Flora.EFFECT_MATTEFINISH;
		case GutFloraMutationEffect.INTENSE_PATTERN:
			return ScriptLocalization.Flora.EFFECT_INTENSEPATT;
		case GutFloraMutationEffect.FLAT_BODY:
			return ScriptLocalization.Flora.EFFECT_FLATBODY;
		case GutFloraMutationEffect.TALL_BODY:
			return ScriptLocalization.Flora.EFFECT_TALLBODY;
		case GutFloraMutationEffect.BIG_TAIL:
			return ScriptLocalization.Flora.EFFECT_BIGTAIL;
		case GutFloraMutationEffect.TINY_TAIL:
			return ScriptLocalization.Flora.EFFECT_TINYTAIL;
		case GutFloraMutationEffect.BIG_WINGS:
			return ScriptLocalization.Flora.EFFECT_BIGWINGS;
		case GutFloraMutationEffect.TINY_WINGS:
			return ScriptLocalization.Flora.EFFECT_TINYWINGS;
		case GutFloraMutationEffect.BIG_HEAD:
			return ScriptLocalization.Flora.EFFECT_BIGHEAD;
		case GutFloraMutationEffect.TINY_HEAD:
			return ScriptLocalization.Flora.EFFECT_TINYHEAD;
		case GutFloraMutationEffect.WIDE_BODY:
			return ScriptLocalization.Flora.EFFECT_WIDEBODY;
		case GutFloraMutationEffect.NARROW_BODY:
			return ScriptLocalization.Flora.EFFECT_NARROWBODY;
		case GutFloraMutationEffect.BIG_HORNS:
			return ScriptLocalization.Flora.EFFECT_BIGHORNS;
		case GutFloraMutationEffect.TINY_HORNS:
			return ScriptLocalization.Flora.EFFECT_TINYHORNS;
		case GutFloraMutationEffect.ORANGE_BODY:
			return ScriptLocalization.Flora.EFFECT_ORANGEBODY;
		case GutFloraMutationEffect.WHITE_NOSE_EARS:
			return ScriptLocalization.Flora.EFFECT_WHITENOSEEAR;
		case GutFloraMutationEffect.YELLOW_NOSE_EARS:
			return ScriptLocalization.Flora.EFFECT_YELLOWNOSEEAR;
		case GutFloraMutationEffect.YELLOW_LEGS:
			return ScriptLocalization.Flora.EFFECT_YELLOWLEGS;
		case GutFloraMutationEffect.PURPLE_COLORS:
			return ScriptLocalization.Flora.EFFECT_PURPLECOL;
		case GutFloraMutationEffect.PINK_COLORS:
			return ScriptLocalization.Flora.EFFECT_PINKCOL;
		default:
			Debug.LogError("No readable name exists for effect: " + effect);
			return "Unknown Mutation";
		}
	}

	public static void MutateGeneFromEffect(MasterDogGene geneRef, GutFloraMutationEffect effect, DogAge newAge, float mutationRate, FloraMutationInfo infoRef)
	{
		float num = (float)EnumUtils.GetNumValues<DogAge>() - 2f;
		float ageProgress = ((float)newAge - 1f) / num;
		float previousAgeProgress = ((float)newAge - 2f) / num;
		switch (effect)
		{
		case GutFloraMutationEffect.LONG_LEGS:
			LegLengthMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 1f);
			break;
		case GutFloraMutationEffect.SHORT_LEGS:
			LegLengthMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 1f, 0f);
			break;
		case GutFloraMutationEffect.THICK_BODY:
			BodyThicknessMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 1f);
			break;
		case GutFloraMutationEffect.THIN_BODY:
			BodyThicknessMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 1f, 0f);
			break;
		case GutFloraMutationEffect.LONG_BODY:
			BodyLengthMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 1f);
			break;
		case GutFloraMutationEffect.SHORT_BODY:
			BodyLengthMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 1f, 0f);
			break;
		case GutFloraMutationEffect.BIG:
			BodyScaleMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 1f);
			break;
		case GutFloraMutationEffect.SMALL:
			BodyScaleMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 1f, 0f);
			break;
		case GutFloraMutationEffect.DROOPY_FACE:
			SnoutRotationMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 1f, 0f);
			break;
		case GutFloraMutationEffect.INVERTED_SNOUT:
			SnoutRotationMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 1f);
			break;
		case GutFloraMutationEffect.BROWN_BODY:
			BodyColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, colorBrown);
			break;
		case GutFloraMutationEffect.YELLOW_BODY:
			BodyColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, colorYellow);
			break;
		case GutFloraMutationEffect.PURPLE_BODY:
			BodyColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, colorPurple);
			break;
		case GutFloraMutationEffect.HAM_COLORED_BODY:
			BodyColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, colorHam);
			break;
		case GutFloraMutationEffect.WHITE_BODY:
			BodyColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, colorWhite);
			break;
		case GutFloraMutationEffect.BLACK_BODY:
			BodyColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, colorBlack);
			break;
		case GutFloraMutationEffect.GREEN_BODY:
			BodyColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, colorGreen);
			break;
		case GutFloraMutationEffect.ORANGE_BODY:
			BodyColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, colorOrange);
			break;
		case GutFloraMutationEffect.DESATURATED_COLORS:
			DesaturatedColorsMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef);
			break;
		case GutFloraMutationEffect.BROWN_EVERYTHING:
			FullColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, colorBrown);
			break;
		case GutFloraMutationEffect.PURPLE_COLORS:
			FullColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, colorPurple);
			break;
		case GutFloraMutationEffect.PINK_COLORS:
			FullColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, colorPink);
			break;
		case GutFloraMutationEffect.ORANGE_SKIN:
			FullColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, colorOrange);
			break;
		case GutFloraMutationEffect.YELLOW_SKIN:
			FullColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, colorYellow);
			break;
		case GutFloraMutationEffect.GREEN_SKIN:
			FullColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, colorGreen);
			break;
		case GutFloraMutationEffect.WHITE_EVERYTHING:
			FullColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, colorWhite);
			break;
		case GutFloraMutationEffect.ORANGE_NOSE_EARS:
			NoseEarsColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, colorOrange);
			break;
		case GutFloraMutationEffect.RED_NOSE_EARS:
			NoseEarsColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, colorRed);
			break;
		case GutFloraMutationEffect.BLUE_NOSE_EARS:
			NoseEarsColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, colorBlue);
			break;
		case GutFloraMutationEffect.WHITE_NOSE_EARS:
			NoseEarsColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, colorWhite);
			break;
		case GutFloraMutationEffect.YELLOW_NOSE_EARS:
			NoseEarsColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, colorYellow);
			break;
		case GutFloraMutationEffect.WHITE_LEGS:
			LegsColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, colorWhite);
			break;
		case GutFloraMutationEffect.PINK_LEGS:
			LegsColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, colorPink);
			break;
		case GutFloraMutationEffect.BLUE_LEGS:
			LegsColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, colorBlue);
			break;
		case GutFloraMutationEffect.LIGHT_GREEN_LEGS:
			LegsColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, colorLightGreen);
			break;
		case GutFloraMutationEffect.YELLOW_LEGS:
			LegsColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, colorYellow);
			break;
		case GutFloraMutationEffect.YELLOW_PATTERN:
			PatternColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, colorYellow);
			break;
		case GutFloraMutationEffect.BLACK_PATTERN:
			PatternColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, colorBlack);
			break;
		case GutFloraMutationEffect.WHITE_PATTERN:
			PatternColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, colorWhite);
			break;
		case GutFloraMutationEffect.DARK_GREEN_PATTERN:
			PatternColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, colorDarkGreen);
			break;
		case GutFloraMutationEffect.RED_PATTERN:
			PatternColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, colorRed);
			break;
		case GutFloraMutationEffect.DEFAULT_COLORS:
			DefaultColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef);
			break;
		case GutFloraMutationEffect.RANDOM_MUTATIONS:
			RandomMutations(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef);
			break;
		case GutFloraMutationEffect.LEG_COUNT:
			LegNumberMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef);
			break;
		case GutFloraMutationEffect.LONG_SNOUT:
			SnoutLengthMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 1f);
			break;
		case GutFloraMutationEffect.SHORT_SNOUT:
			SnoutLengthMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 1f, 0f);
			break;
		case GutFloraMutationEffect.LONG_EARS:
			EarLengthMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 1f);
			break;
		case GutFloraMutationEffect.SHORT_EARS:
			EarLengthMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 1f, 0f);
			break;
		case GutFloraMutationEffect.BIG_NOSE:
			NoseSizeMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 1f);
			break;
		case GutFloraMutationEffect.TINY_NOSE:
			NoseSizeMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 1f, 0f);
			break;
		case GutFloraMutationEffect.WIDE_STANCE:
			StanceWidthMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 1f);
			break;
		case GutFloraMutationEffect.NARROW_STANCE:
			StanceWidthMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 1f, 0f);
			break;
		case GutFloraMutationEffect.THICK_LEGS:
			LegThicknessMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 1f);
			break;
		case GutFloraMutationEffect.SKINNY_LEGS:
			LegThicknessMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 1f, 0f);
			break;
		case GutFloraMutationEffect.GLOSSY_SHEEN:
			FullGlossMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 1f);
			break;
		case GutFloraMutationEffect.METALLIC_SHEEN:
			FullMetalMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 1f);
			break;
		case GutFloraMutationEffect.MATTE_FINISH:
			FullGlossMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 1f, 0f);
			FullMetalMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 1f, 0f);
			break;
		case GutFloraMutationEffect.INTENSE_PATTERN:
			PatternIntensityMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 1f);
			break;
		case GutFloraMutationEffect.BIG_TAIL:
			TailSizeMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 1f);
			break;
		case GutFloraMutationEffect.TINY_TAIL:
			TailSizeMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 1f, 0f);
			break;
		case GutFloraMutationEffect.FLAT_BODY:
			BodyHeightMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 1f, 0f);
			break;
		case GutFloraMutationEffect.TALL_BODY:
			BodyHeightMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 1f);
			break;
		case GutFloraMutationEffect.BIG_WINGS:
			WingSizeMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 1f);
			break;
		case GutFloraMutationEffect.TINY_WINGS:
			WingSizeMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 1f, 0f);
			break;
		case GutFloraMutationEffect.BIG_HEAD:
			HeadSizeMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 1f);
			break;
		case GutFloraMutationEffect.TINY_HEAD:
			HeadSizeMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 1f, 0f);
			break;
		case GutFloraMutationEffect.WIDE_BODY:
			BodyWidthMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 1f);
			break;
		case GutFloraMutationEffect.NARROW_BODY:
			BodyWidthMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 1f, 0f);
			break;
		case GutFloraMutationEffect.BIG_HORNS:
			HornSizeMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 1f);
			break;
		case GutFloraMutationEffect.TINY_HORNS:
			HornSizeMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, 1f, 0f);
			break;
		default:
			Debug.LogError("No implementation for effect: " + effect);
			break;
		}
	}

	public static void DefaultColorMutation(MasterDogGene geneRef, DogAge newAge, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef)
	{
		ModifyPlusMinusProperty(geneRef, GeneticProperty.BodyColorRPlus, GeneticProperty.BodyColorRMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 0f);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.BodyColorGPlus, GeneticProperty.BodyColorGMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 0f);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.BodyColorBPlus, GeneticProperty.BodyColorBMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 0f);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.BodyEmissionColorRPlus, GeneticProperty.BodyEmissionColorRMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 0f);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.BodyEmissionColorGPlus, GeneticProperty.BodyEmissionColorGMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 0f);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.BodyEmissionColorBPlus, GeneticProperty.BodyEmissionColorBMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 0f);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.LegColorRPlus, GeneticProperty.LegColorRMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 0f);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.LegColorGPlus, GeneticProperty.LegColorGMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 0f);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.LegColorBPlus, GeneticProperty.LegColorBMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 0f);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.LegEmissionColorRPlus, GeneticProperty.LegEmissionColorRMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 0f);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.LegEmissionColorGPlus, GeneticProperty.LegEmissionColorGMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 0f);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.LegEmissionColorBPlus, GeneticProperty.LegEmissionColorBMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 0f);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.PatternColorRPlus, GeneticProperty.PatternColorRMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 0f);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.PatternColorGPlus, GeneticProperty.PatternColorGMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 0f);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.PatternColorBPlus, GeneticProperty.PatternColorBMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 0f);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.PatternEmissionColorRPlus, GeneticProperty.PatternEmissionColorRMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 0f);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.PatternEmissionColorGPlus, GeneticProperty.PatternEmissionColorGMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 0f);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.PatternEmissionColorBPlus, GeneticProperty.PatternEmissionColorBMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 0f);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.NoseEarColorRPlus, GeneticProperty.NoseEarColorRMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 0f);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.NoseEarColorGPlus, GeneticProperty.NoseEarColorGMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 0f);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.NoseEarColorBPlus, GeneticProperty.NoseEarColorBMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 0f);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.NoseEarEmissionColorRPlus, GeneticProperty.NoseEarEmissionColorRMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 0f);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.NoseEarEmissionColorGPlus, GeneticProperty.NoseEarEmissionColorGMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 0f);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.NoseEarEmissionColorBPlus, GeneticProperty.NoseEarEmissionColorBMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, 0f, 0f);
	}

	public static void DesaturatedColorsMutation(MasterDogGene geneRef, DogAge newAge, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef)
	{
		float p = 0.75f;
		float minSaturation = 0.25f;
		DogLooks component = geneRef.GetComponent<DogLooks>();
		Color newColor = MathUtil.DesaturateColorByPercentage(component.bodyRenderer.material.color, p, minSaturation);
		Color newColor2 = MathUtil.DesaturateColorByPercentage(component.GetBodyPatternColor(), p, minSaturation);
		Color newColor3 = MathUtil.DesaturateColorByPercentage(component.GetNoseEarsColor(), p, minSaturation);
		Color newColor4 = ((!component.useOldHead) ? MathUtil.DesaturateColorByPercentage(component.face.GetComponent<Renderer>().material.color, p, minSaturation) : MathUtil.DesaturateColorByPercentage(component.oldFace.GetComponent<Renderer>().material.color, p, minSaturation));
		BodyColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, newColor);
		LegsColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, newColor4);
		PatternColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, newColor2);
		NoseEarsColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, newColor3);
	}

	public static void FullColorMutation(MasterDogGene geneRef, DogAge newAge, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef, Color newColor)
	{
		BodyColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, newColor);
		LegsColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, newColor);
		PatternColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, newColor);
		NoseEarsColorMutation(geneRef, newAge, mutationRate, ageProgress, previousAgeProgress, infoRef, newColor);
	}

	public static void BodyColorMutation(MasterDogGene geneRef, DogAge newAge, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef, Color newColor)
	{
		float rPlus;
		float gMinus;
		float gPlus;
		float bMinus;
		float bPlus;
		float rMinus = (rPlus = (gMinus = (gPlus = (bMinus = (bPlus = 0f)))));
		DogLooks component = geneRef.GetComponent<DogLooks>();
		Material defaultBodyMaterial = component.GetDefaultBodyMaterial();
		Color color = defaultBodyMaterial.color;
		Color color2 = defaultBodyMaterial.GetColor("_EmissionColor");
		GetColorTargets(ref rMinus, ref rPlus, ref gMinus, ref gPlus, ref bMinus, ref bPlus, color, newColor);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.BodyColorRPlus, GeneticProperty.BodyColorRMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, rMinus, rPlus, 0f, component.BodyMatColorRMax, 0f, component.BodyMatColorRMin);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.BodyColorGPlus, GeneticProperty.BodyColorGMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, gMinus, gPlus, 0f, component.BodyMatColorGMax, 0f, component.BodyMatColorGMin);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.BodyColorBPlus, GeneticProperty.BodyColorBMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, bMinus, bPlus, 0f, component.BodyMatColorBMax, 0f, component.BodyMatColorBMin);
		GetColorTargets(ref rMinus, ref rPlus, ref gMinus, ref gPlus, ref bMinus, ref bPlus, color2, Color.black);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.BodyEmissionColorRPlus, GeneticProperty.BodyEmissionColorRMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, rMinus, rPlus, 0f, component.BodyMatEmissionColorRMax, 0f, component.BodyMatEmissionColorRMin);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.BodyEmissionColorGPlus, GeneticProperty.BodyEmissionColorGMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, gMinus, gPlus, 0f, component.BodyMatEmissionColorGMax, 0f, component.BodyMatEmissionColorGMin);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.BodyEmissionColorBPlus, GeneticProperty.BodyEmissionColorBMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, bMinus, bPlus, 0f, component.BodyMatEmissionColorBMax, 0f, component.BodyMatEmissionColorBMin);
	}

	public static void LegsColorMutation(MasterDogGene geneRef, DogAge newAge, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef, Color newColor)
	{
		float rPlus;
		float gMinus;
		float gPlus;
		float bMinus;
		float bPlus;
		float rMinus = (rPlus = (gMinus = (gPlus = (bMinus = (bPlus = 0f)))));
		DogLooks component = geneRef.GetComponent<DogLooks>();
		Material defaultLegMaterial = component.GetDefaultLegMaterial();
		Color color = defaultLegMaterial.color;
		Color color2 = defaultLegMaterial.GetColor("_EmissionColor");
		GetColorTargets(ref rMinus, ref rPlus, ref gMinus, ref gPlus, ref bMinus, ref bPlus, color, newColor);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.LegColorRPlus, GeneticProperty.LegColorRMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, rMinus, rPlus, 0f, component.LegMatColorRMax, 0f, component.LegMatColorRMin);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.LegColorGPlus, GeneticProperty.LegColorGMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, gMinus, gPlus, 0f, component.LegMatColorGMax, 0f, component.LegMatColorGMin);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.LegColorBPlus, GeneticProperty.LegColorBMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, bMinus, bPlus, 0f, component.LegMatColorBMax, 0f, component.LegMatColorBMin);
		GetColorTargets(ref rMinus, ref rPlus, ref gMinus, ref gPlus, ref bMinus, ref bPlus, color2, Color.black);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.LegEmissionColorRPlus, GeneticProperty.LegEmissionColorRMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, rMinus, rPlus, 0f, component.LegMatEmissionColorRMax, 0f, component.LegMatEmissionColorRMin);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.LegEmissionColorGPlus, GeneticProperty.LegEmissionColorGMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, gMinus, gPlus, 0f, component.LegMatEmissionColorGMax, 0f, component.LegMatEmissionColorGMin);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.LegEmissionColorBPlus, GeneticProperty.LegEmissionColorBMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, bMinus, bPlus, 0f, component.LegMatEmissionColorBMax, 0f, component.LegMatEmissionColorBMin);
	}

	public static void NoseEarsColorMutation(MasterDogGene geneRef, DogAge newAge, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef, Color newColor)
	{
		float rPlus;
		float gMinus;
		float gPlus;
		float bMinus;
		float bPlus;
		float rMinus = (rPlus = (gMinus = (gPlus = (bMinus = (bPlus = 0f)))));
		DogLooks component = geneRef.GetComponent<DogLooks>();
		Material defaultNoseEarMaterial = component.GetDefaultNoseEarMaterial();
		Color color = defaultNoseEarMaterial.color;
		Color color2 = defaultNoseEarMaterial.GetColor("_EmissionColor");
		GetColorTargets(ref rMinus, ref rPlus, ref gMinus, ref gPlus, ref bMinus, ref bPlus, color, newColor);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.NoseEarColorRPlus, GeneticProperty.NoseEarColorRMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, rMinus, rPlus, 0f, component.NoseEarMatColorRMax, 0f, component.NoseEarMatColorRMin);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.NoseEarColorGPlus, GeneticProperty.NoseEarColorGMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, gMinus, gPlus, 0f, component.NoseEarMatColorGMax, 0f, component.NoseEarMatColorGMin);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.NoseEarColorBPlus, GeneticProperty.NoseEarColorBMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, bMinus, bPlus, 0f, component.NoseEarMatColorBMax, 0f, component.NoseEarMatColorBMin);
		GetColorTargets(ref rMinus, ref rPlus, ref gMinus, ref gPlus, ref bMinus, ref bPlus, color2, Color.black);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.NoseEarEmissionColorRPlus, GeneticProperty.NoseEarEmissionColorRMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, rMinus, rPlus, 0f, component.NoseEarMatEmissionColorRMax, 0f, component.NoseEarMatEmissionColorRMin);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.NoseEarEmissionColorGPlus, GeneticProperty.NoseEarEmissionColorGMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, gMinus, gPlus, 0f, component.NoseEarMatEmissionColorGMax, 0f, component.NoseEarMatEmissionColorGMin);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.NoseEarEmissionColorBPlus, GeneticProperty.NoseEarEmissionColorBMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, bMinus, bPlus, 0f, component.NoseEarMatEmissionColorBMax, 0f, component.NoseEarMatEmissionColorBMin);
	}

	public static void PatternColorMutation(MasterDogGene geneRef, DogAge newAge, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef, Color newColor)
	{
		float rPlus;
		float gMinus;
		float gPlus;
		float bMinus;
		float bPlus;
		float rMinus = (rPlus = (gMinus = (gPlus = (bMinus = (bPlus = 0f)))));
		DogLooks component = geneRef.GetComponent<DogLooks>();
		Material defaultBodyPatternMaterial = component.GetDefaultBodyPatternMaterial();
		Color color = defaultBodyPatternMaterial.color;
		Color color2 = defaultBodyPatternMaterial.GetColor("_EmissionColor");
		GetColorTargets(ref rMinus, ref rPlus, ref gMinus, ref gPlus, ref bMinus, ref bPlus, color, newColor);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.PatternColorRPlus, GeneticProperty.PatternColorRMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, rMinus, rPlus, 0f, component.BodyPatternMatColorRMax, 0f, component.BodyPatternMatColorRMin);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.PatternColorGPlus, GeneticProperty.PatternColorGMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, gMinus, gPlus, 0f, component.BodyPatternMatColorGMax, 0f, component.BodyPatternMatColorGMin);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.PatternColorBPlus, GeneticProperty.PatternColorBMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, bMinus, bPlus, 0f, component.BodyPatternMatColorBMax, 0f, component.BodyPatternMatColorBMin);
		GetColorTargets(ref rMinus, ref rPlus, ref gMinus, ref gPlus, ref bMinus, ref bPlus, color2, Color.black);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.PatternEmissionColorRPlus, GeneticProperty.PatternEmissionColorRMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, rMinus, rPlus, 0f, component.BodyPatternMatEmissionColorRMax, 0f, component.BodyPatternMatEmissionColorRMin);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.PatternEmissionColorGPlus, GeneticProperty.PatternEmissionColorGMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, gMinus, gPlus, 0f, component.BodyPatternMatEmissionColorGMax, 0f, component.BodyPatternMatEmissionColorGMin);
		ModifyPlusMinusProperty(geneRef, GeneticProperty.PatternEmissionColorBPlus, GeneticProperty.PatternEmissionColorBMinus, mutationRate, ageProgress, previousAgeProgress, infoRef, bMinus, bPlus, 0f, component.BodyPatternMatEmissionColorBMax, 0f, component.BodyPatternMatEmissionColorBMin);
	}

	public static void PatternIntensityMutation(MasterDogGene geneRef, DogAge newAge, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef, float targetValue)
	{
		ModifyStandardProperty(geneRef, GeneticProperty.PatternAlpha, mutationRate, ageProgress, previousAgeProgress, infoRef, targetValue);
	}

	public static void RandomMutations(MasterDogGene geneRef, DogAge newAge, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef)
	{
		foreach (GeneticProperty value in EnumUtils.GetValues<GeneticProperty>())
		{
			string geneString = geneRef.GetGeneString(value, raw: true);
			string text = MasterDogGene.MutateGenome(geneString, allowSuperMutations: false, forceMutation: false);
			if (geneString != text)
			{
				infoRef.changedProperties.Add(value);
				geneRef.UpdateGeneString(value, text, updateActualGene: false);
			}
		}
		geneRef.UpdateActualGene();
	}

	public static void SnoutRotationMutation(MasterDogGene geneRef, DogAge newAge, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef, float negativeTarget, float positiveTarget)
	{
		List<GeneticProperty> list = new List<GeneticProperty> { GeneticProperty.SnoutModAPlus };
		List<GeneticProperty> list2 = new List<GeneticProperty> { GeneticProperty.SnoutModAMinus };
		for (int i = 0; i < list.Count; i++)
		{
			ModifyPlusMinusProperty(geneRef, list[i], list2[i], mutationRate, ageProgress, previousAgeProgress, infoRef, negativeTarget, positiveTarget);
		}
	}

	public static void SnoutLengthMutation(MasterDogGene geneRef, DogAge newAge, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef, float negativeTarget, float positiveTarget)
	{
		List<GeneticProperty> list = new List<GeneticProperty> { GeneticProperty.SnoutModBPlus };
		List<GeneticProperty> list2 = new List<GeneticProperty> { GeneticProperty.SnoutModBMinus };
		for (int i = 0; i < list.Count; i++)
		{
			ModifyPlusMinusProperty(geneRef, list[i], list2[i], mutationRate, ageProgress, previousAgeProgress, infoRef, negativeTarget, positiveTarget);
		}
	}

	public static void EarLengthMutation(MasterDogGene geneRef, DogAge newAge, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef, float negativeTarget, float positiveTarget)
	{
		List<GeneticProperty> list = new List<GeneticProperty> { GeneticProperty.EarModAPlus };
		List<GeneticProperty> list2 = new List<GeneticProperty> { GeneticProperty.EarModAMinus };
		for (int i = 0; i < list.Count; i++)
		{
			ModifyPlusMinusProperty(geneRef, list[i], list2[i], mutationRate, ageProgress, previousAgeProgress, infoRef, negativeTarget, positiveTarget);
		}
	}

	public static void NoseSizeMutation(MasterDogGene geneRef, DogAge newAge, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef, float negativeTarget, float positiveTarget)
	{
		List<GeneticProperty> list = new List<GeneticProperty> { GeneticProperty.NoseModAPlus };
		List<GeneticProperty> list2 = new List<GeneticProperty> { GeneticProperty.NoseModAMinus };
		for (int i = 0; i < list.Count; i++)
		{
			ModifyPlusMinusProperty(geneRef, list[i], list2[i], mutationRate, ageProgress, previousAgeProgress, infoRef, negativeTarget, positiveTarget);
		}
	}

	public static void StanceWidthMutation(MasterDogGene geneRef, DogAge newAge, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef, float negativeTarget, float positiveTarget)
	{
		List<GeneticProperty> list = new List<GeneticProperty>
		{
			GeneticProperty.StanceWidthBackPlus,
			GeneticProperty.StanceWidthFrontPlus
		};
		List<GeneticProperty> list2 = new List<GeneticProperty>
		{
			GeneticProperty.StanceWidthBackMinus,
			GeneticProperty.StanceWidthFrontMinus
		};
		for (int i = 0; i < list.Count; i++)
		{
			ModifyPlusMinusProperty(geneRef, list[i], list2[i], mutationRate, ageProgress, previousAgeProgress, infoRef, negativeTarget, positiveTarget);
		}
	}

	public static void LegThicknessMutation(MasterDogGene geneRef, DogAge newAge, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef, float negativeTarget, float positiveTarget)
	{
		List<GeneticProperty> list = new List<GeneticProperty>
		{
			GeneticProperty.LegScaleXZFrontPlus,
			GeneticProperty.LegScaleXZBackPlus
		};
		List<GeneticProperty> list2 = new List<GeneticProperty>
		{
			GeneticProperty.LegScaleXZFrontMinus,
			GeneticProperty.LegScaleXZBackMinus
		};
		for (int i = 0; i < list.Count; i++)
		{
			ModifyPlusMinusProperty(geneRef, list[i], list2[i], mutationRate, ageProgress, previousAgeProgress, infoRef, negativeTarget, positiveTarget);
		}
	}

	public static void TailSizeMutation(MasterDogGene geneRef, DogAge newAge, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef, float negativeTarget, float positiveTarget)
	{
		List<GeneticProperty> list = new List<GeneticProperty> { GeneticProperty.TailScalePlus };
		List<GeneticProperty> list2 = new List<GeneticProperty> { GeneticProperty.TailScaleMinus };
		for (int i = 0; i < list.Count; i++)
		{
			ModifyPlusMinusProperty(geneRef, list[i], list2[i], mutationRate, ageProgress, previousAgeProgress, infoRef, negativeTarget, positiveTarget);
		}
	}

	public static void HornSizeMutation(MasterDogGene geneRef, DogAge newAge, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef, float negativeTarget, float positiveTarget)
	{
		List<GeneticProperty> list = new List<GeneticProperty> { GeneticProperty.HornSizePlus };
		List<GeneticProperty> list2 = new List<GeneticProperty> { GeneticProperty.HornSizeMinus };
		for (int i = 0; i < list.Count; i++)
		{
			ModifyPlusMinusProperty(geneRef, list[i], list2[i], mutationRate, ageProgress, previousAgeProgress, infoRef, negativeTarget, positiveTarget);
		}
	}

	public static void WingSizeMutation(MasterDogGene geneRef, DogAge newAge, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef, float negativeTarget, float positiveTarget)
	{
		List<GeneticProperty> list = new List<GeneticProperty> { GeneticProperty.WingSizePlus };
		List<GeneticProperty> list2 = new List<GeneticProperty> { GeneticProperty.WingSizeMinus };
		for (int i = 0; i < list.Count; i++)
		{
			ModifyPlusMinusProperty(geneRef, list[i], list2[i], mutationRate, ageProgress, previousAgeProgress, infoRef, negativeTarget, positiveTarget);
		}
	}

	public static void HeadSizeMutation(MasterDogGene geneRef, DogAge newAge, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef, float negativeTarget, float positiveTarget)
	{
		List<GeneticProperty> list = new List<GeneticProperty> { GeneticProperty.HeadSizePlus };
		List<GeneticProperty> list2 = new List<GeneticProperty> { GeneticProperty.HeadSizeMinus };
		for (int i = 0; i < list.Count; i++)
		{
			ModifyPlusMinusProperty(geneRef, list[i], list2[i], mutationRate, ageProgress, previousAgeProgress, infoRef, negativeTarget, positiveTarget);
		}
	}

	public static void FullGlossMutation(MasterDogGene geneRef, DogAge newAge, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef, float negativeTarget, float positiveTarget)
	{
		List<GeneticProperty> list = new List<GeneticProperty>
		{
			GeneticProperty.BodyGlossPlus,
			GeneticProperty.LegGlossPlus,
			GeneticProperty.NoseEarGlossPlus
		};
		List<GeneticProperty> list2 = new List<GeneticProperty>
		{
			GeneticProperty.BodyGlossMinus,
			GeneticProperty.LegGlossMinus,
			GeneticProperty.NoseEarGlossMinus
		};
		for (int i = 0; i < list.Count; i++)
		{
			ModifyPlusMinusProperty(geneRef, list[i], list2[i], mutationRate, ageProgress, previousAgeProgress, infoRef, negativeTarget, positiveTarget);
		}
	}

	public static void FullMetalMutation(MasterDogGene geneRef, DogAge newAge, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef, float negativeTarget, float positiveTarget)
	{
		List<GeneticProperty> list = new List<GeneticProperty>
		{
			GeneticProperty.BodyMetallicPlus,
			GeneticProperty.LegMetallicPlus,
			GeneticProperty.NoseEarMetallicPlus
		};
		List<GeneticProperty> list2 = new List<GeneticProperty>
		{
			GeneticProperty.BodyMetallicMinus,
			GeneticProperty.LegMetallicMinus,
			GeneticProperty.NoseEarMetallicMinus
		};
		for (int i = 0; i < list.Count; i++)
		{
			ModifyPlusMinusProperty(geneRef, list[i], list2[i], mutationRate, ageProgress, previousAgeProgress, infoRef, negativeTarget, positiveTarget);
		}
	}

	public static void LegLengthMutation(MasterDogGene geneRef, DogAge newAge, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef, float negativeTarget, float positiveTarget)
	{
		List<GeneticProperty> list = new List<GeneticProperty>
		{
			GeneticProperty.LegScaleYBackBotPlus,
			GeneticProperty.LegScaleYBackTopPlus,
			GeneticProperty.LegScaleYFrontBotPlus,
			GeneticProperty.LegScaleYFrontTopPlus
		};
		List<GeneticProperty> list2 = new List<GeneticProperty>
		{
			GeneticProperty.LegScaleYBackBotMinus,
			GeneticProperty.LegScaleYBackTopMinus,
			GeneticProperty.LegScaleYFrontBotMinus,
			GeneticProperty.LegScaleYFrontTopMinus
		};
		for (int i = 0; i < list.Count; i++)
		{
			ModifyPlusMinusProperty(geneRef, list[i], list2[i], mutationRate, ageProgress, previousAgeProgress, infoRef, negativeTarget, positiveTarget);
		}
	}

	public static void BodyThicknessMutation(MasterDogGene geneRef, DogAge newAge, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef, float negativeTarget, float positiveTarget)
	{
		List<GeneticProperty> list = new List<GeneticProperty> { GeneticProperty.BodyScaleYZPlus };
		List<GeneticProperty> list2 = new List<GeneticProperty> { GeneticProperty.BodyScaleYZMinus };
		for (int i = 0; i < list.Count; i++)
		{
			ModifyPlusMinusProperty(geneRef, list[i], list2[i], mutationRate, ageProgress, previousAgeProgress, infoRef, negativeTarget, positiveTarget);
		}
	}

	public static void BodyLengthMutation(MasterDogGene geneRef, DogAge newAge, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef, float negativeTarget, float positiveTarget)
	{
		List<GeneticProperty> list = new List<GeneticProperty> { GeneticProperty.BodyScaleXPlus };
		List<GeneticProperty> list2 = new List<GeneticProperty> { GeneticProperty.BodyScaleXMinus };
		for (int i = 0; i < list.Count; i++)
		{
			ModifyPlusMinusProperty(geneRef, list[i], list2[i], mutationRate, ageProgress, previousAgeProgress, infoRef, negativeTarget, positiveTarget);
		}
	}

	public static void BodyHeightMutation(MasterDogGene geneRef, DogAge newAge, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef, float negativeTarget, float positiveTarget)
	{
		List<GeneticProperty> list = new List<GeneticProperty> { GeneticProperty.BodyScaleZPlus };
		List<GeneticProperty> list2 = new List<GeneticProperty> { GeneticProperty.BodyScaleZMinus };
		for (int i = 0; i < list.Count; i++)
		{
			ModifyPlusMinusProperty(geneRef, list[i], list2[i], mutationRate, ageProgress, previousAgeProgress, infoRef, negativeTarget, positiveTarget);
		}
	}

	public static void BodyWidthMutation(MasterDogGene geneRef, DogAge newAge, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef, float negativeTarget, float positiveTarget)
	{
		List<GeneticProperty> list = new List<GeneticProperty> { GeneticProperty.BodyScaleYPlus };
		List<GeneticProperty> list2 = new List<GeneticProperty> { GeneticProperty.BodyScaleYMinus };
		for (int i = 0; i < list.Count; i++)
		{
			ModifyPlusMinusProperty(geneRef, list[i], list2[i], mutationRate, ageProgress, previousAgeProgress, infoRef, negativeTarget, positiveTarget);
		}
	}

	public static void BodyScaleMutation(MasterDogGene geneRef, DogAge newAge, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef, float negativeTarget, float positiveTarget)
	{
		List<GeneticProperty> list = new List<GeneticProperty> { GeneticProperty.BodyScaleGlobalPlus };
		List<GeneticProperty> list2 = new List<GeneticProperty> { GeneticProperty.BodyScaleGlobalMinus };
		for (int i = 0; i < list.Count; i++)
		{
			ModifyPlusMinusProperty(geneRef, list[i], list2[i], mutationRate, ageProgress, previousAgeProgress, infoRef, negativeTarget, positiveTarget);
		}
	}

	public static void LegNumberMutation(MasterDogGene geneRef, DogAge newAge, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef)
	{
		List<GeneticProperty> list = new List<GeneticProperty>
		{
			GeneticProperty.LegPairsBack,
			GeneticProperty.LegPairsFront
		};
		for (int i = 0; i < list.Count; i++)
		{
			MutateSuperProperty(geneRef, list[i], mutationRate, ageProgress, previousAgeProgress, infoRef);
		}
	}

	private static void GetColorTargets(ref float rMinus, ref float rPlus, ref float gMinus, ref float gPlus, ref float bMinus, ref float bPlus, Color defaultColor, Color newColor)
	{
		rMinus = 0f;
		rPlus = 0f;
		gMinus = 0f;
		gPlus = 0f;
		bMinus = 0f;
		bPlus = 0f;
		if (newColor.r > defaultColor.r)
		{
			rPlus = newColor.r - defaultColor.r;
		}
		else if (newColor.r < defaultColor.r)
		{
			rMinus = defaultColor.r - newColor.r;
		}
		if (newColor.g > defaultColor.g)
		{
			gPlus = newColor.g - defaultColor.g;
		}
		else
		{
			gMinus = defaultColor.g - newColor.g;
		}
		if (newColor.b > defaultColor.b)
		{
			bPlus = newColor.b - defaultColor.b;
		}
		else
		{
			bMinus = defaultColor.b - newColor.b;
		}
	}

	private static void MutateSuperProperty(MasterDogGene geneRef, GeneticProperty property, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef)
	{
		string geneString = geneRef.GetGeneString(property, raw: true);
		string text = MasterDogGene.MutateGenome(geneString, allowSuperMutations: false);
		if (Random.value <= MasterDogGene.superMutationRate)
		{
			text += "1";
		}
		if (geneString != text)
		{
			infoRef.changedProperties.Add(property);
			geneRef.UpdateGeneString(property, text, updateActualGene: false);
		}
	}

	private static void ModifyStandardProperty(MasterDogGene geneRef, GeneticProperty property, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef, float targetValue)
	{
		string geneString = geneRef.GetGeneString(property);
		float num = MathUtil.GetFloatFromGeneSequence(geneString, 0f, 1f);
		Gene geneForProperty = GetGeneForProperty(geneRef, property, plusMinus: false);
		if (geneForProperty == null)
		{
			Debug.LogError("No specific gene found for: " + geneRef);
			return;
		}
		AnimationCurve customCurve = geneForProperty.customCurve;
		float num2 = customCurve.Evaluate(ageProgress);
		float num3 = customCurve.Evaluate(previousAgeProgress);
		float num4 = num2 - num3;
		float num5 = Random.Range(0.5f, 1.5f);
		float num6 = num4 * 2f * mutationRate * maxPropertyChangePerGeneration * num5;
		if (num6 != 0f)
		{
			infoRef.changedProperties.Add(property);
			if (num < targetValue)
			{
				num = Mathf.Min(num + num6, targetValue);
			}
			else if (num > targetValue)
			{
				num = Mathf.Max(num - num6, targetValue);
			}
			string geneSequenceFromValues = MathUtil.GetGeneSequenceFromValues(num, 0f, 1f, geneString.Length);
			geneRef.UpdateGeneString(property, geneSequenceFromValues, updateActualGene: false);
		}
	}

	private static void ModifyPlusMinusProperty(MasterDogGene geneRef, GeneticProperty positiveProperty, GeneticProperty negativeProperty, float mutationRate, float ageProgress, float previousAgeProgress, FloraMutationInfo infoRef, float negativeTarget, float positiveTarget, float posMin = 0f, float posMax = 1f, float negMin = 0f, float negMax = 1f)
	{
		string geneString = geneRef.GetGeneString(positiveProperty);
		string geneString2 = geneRef.GetGeneString(negativeProperty);
		float num = MathUtil.GetFloatFromGeneSequence(geneString, posMin, posMax);
		float num2 = MathUtil.GetFloatFromGeneSequence(geneString2, negMin, negMax);
		if (num == positiveTarget && num2 == negativeTarget)
		{
			return;
		}
		AnimationCurve customCurve = GetGeneForProperty(geneRef, positiveProperty, plusMinus: true).customCurve;
		float num3 = customCurve.Evaluate(ageProgress);
		float num4 = customCurve.Evaluate(previousAgeProgress);
		float num5 = num3 - num4;
		float num6 = Random.Range(0.5f, 1.5f);
		float num7 = num5 * 2f * mutationRate * maxPropertyChangePerGeneration * num6;
		if (num7 == 0f)
		{
			return;
		}
		infoRef.changedProperties.Add(positiveProperty);
		infoRef.changedProperties.Add(negativeProperty);
		if (num2 > negativeTarget)
		{
			float num8 = num2 - negativeTarget;
			if (num7 > num8)
			{
				num7 -= num8;
				num2 = negativeTarget;
			}
			else
			{
				num2 -= num7;
				num7 = 0f;
			}
		}
		else if (num2 < negativeTarget)
		{
			float num9 = negativeTarget - num2;
			if (num7 > num9)
			{
				num7 -= num9;
				num2 = negativeTarget;
			}
			else
			{
				num2 += num7;
				num7 = 0f;
			}
		}
		if (num7 > 0f)
		{
			if (num < positiveTarget)
			{
				num = Mathf.Min(num + num7, positiveTarget);
			}
			else if (num > positiveTarget)
			{
				num = Mathf.Max(num - num7, positiveTarget);
			}
		}
		string geneSequenceFromValues = MathUtil.GetGeneSequenceFromValues(num, posMin, posMax, geneString.Length);
		string geneSequenceFromValues2 = MathUtil.GetGeneSequenceFromValues(num2, negMin, negMax, geneString2.Length);
		geneRef.UpdateGeneString(positiveProperty, geneSequenceFromValues, updateActualGene: false);
		geneRef.UpdateGeneString(negativeProperty, geneSequenceFromValues2, updateActualGene: false);
	}

	private static Gene GetGeneForProperty(MasterDogGene geneRef, GeneticProperty propertyRef, bool plusMinus)
	{
		for (int i = 0; i < geneRef.dogGenes.Count; i++)
		{
			if (geneRef.dogGenes[i].plusMinus == plusMinus)
			{
				GeneticProperty geneticProperty = (geneRef.dogGenes[i].plusMinus ? geneRef.GetGeneticPropertyPlusFromKeyString(geneRef.dogGenes[i].key) : geneRef.GetGeneticPropertyFromKeyString(geneRef.dogGenes[i].key));
				if (propertyRef == geneticProperty)
				{
					return geneRef.dogGenes[i];
				}
			}
		}
		Debug.LogError("No gene found for property: " + propertyRef);
		return null;
	}
}
