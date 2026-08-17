using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using Unity.Mathematics;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters;

public class CharacterSkillCardsManager
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<WeightedEdition, float> _003C_003E9__12_0;

		public static Predicate<CharacterSkillCard_Base> _003C_003E9__13_0;

		public static Predicate<CharacterSkillCard_Base> _003C_003E9__13_1;

		public static Predicate<CharacterSkillCard_Base> _003C_003E9__14_0;

		public static Predicate<CharacterSkillCard_Base> _003C_003E9__14_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal float _003CGetWeightedEdition_003Eb__12_0(WeightedEdition x)
		{
			return x.Weight;
		}

		internal bool _003CGetSurvarotDifficultyMultiplier_003Eb__13_0(CharacterSkillCard_Base x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if (x != null)
			{
				object obj = x.Edition - 4;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CGetSurvarotDifficultyMultiplier_003Eb__13_1(CharacterSkillCard_Base x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if (x != null)
			{
				object obj = x.Edition - 4;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CAdjustAdditionalEnemiesHPMultiplierWithINVE_003Eb__14_0(CharacterSkillCard_Base x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if (x != null)
			{
				object obj = x.Edition - 4;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CAdjustAdditionalEnemiesHPMultiplierWithINVE_003Eb__14_1(CharacterSkillCard_Base x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if (x != null)
			{
				object obj = x.Edition - 4;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private List<CharacterSkillCard_Base> _characterCards;

	public List<CharacterSkillCard_Base> ActiveCards => _characterCards;

	public void AddCharacterCard(CharacterSkillCard_Base card)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1A80");
		card.InitialActivate();
	}

	public void OnOwnerRevived(float percentage = 1f, bool instantRevival = false)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		List<CharacterSkillCard_Base> characterCards = _characterCards;
		object obj = 0;
		object obj2 = 0;
		List<CharacterSkillCard_Base> characterCards2 = _characterCards;
		while (true)
		{
			if ((nint)obj < characterCards._size)
			{
				if ((nint)obj2 >= characterCards2._size)
				{
					break;
				}
				CharacterSkillCard_Base[] items = characterCards2._items;
				items[obj2].OnOwnerRevived(percentage, instantRevival);
				characterCards2 = _characterCards;
				obj2++;
				obj = obj2;
				characterCards = _characterCards;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void OnOwnerLevelUpSkipped()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		List<CharacterSkillCard_Base> characterCards = _characterCards;
		object obj = 0;
		object obj2 = 0;
		List<CharacterSkillCard_Base> characterCards2 = _characterCards;
		while (true)
		{
			if ((nint)obj2 < characterCards._size)
			{
				if ((nint)obj >= characterCards2._size)
				{
					break;
				}
				CharacterSkillCard_Base[] items = characterCards2._items;
				items[obj].OnOwnerLevelUpSkipped();
				characterCards2 = _characterCards;
				obj++;
				obj2 = obj;
				characterCards = _characterCards;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void OnOwnerGetDamaged(float damageAmount)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		List<CharacterSkillCard_Base> characterCards = _characterCards;
		object obj = 0;
		object obj2 = 0;
		List<CharacterSkillCard_Base> characterCards2 = _characterCards;
		while (true)
		{
			if ((nint)obj < characterCards._size)
			{
				if ((nint)obj2 >= characterCards2._size)
				{
					break;
				}
				CharacterSkillCard_Base[] items = characterCards2._items;
				items[obj2].OnOwnerGetDamaged(damageAmount);
				characterCards2 = _characterCards;
				obj2++;
				obj = obj2;
				characterCards = _characterCards;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void OnOwnerCriticalHPTreshold(float rawValue)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		List<CharacterSkillCard_Base> characterCards = _characterCards;
		object obj = 0;
		object obj2 = 0;
		List<CharacterSkillCard_Base> characterCards2 = _characterCards;
		while (true)
		{
			if ((nint)obj < characterCards._size)
			{
				if ((nint)obj2 >= characterCards2._size)
				{
					break;
				}
				CharacterSkillCard_Base[] items = characterCards2._items;
				items[obj2].OnOwnerCriticalHPTreshold(rawValue);
				characterCards2 = _characterCards;
				obj2++;
				obj = obj2;
				characterCards = _characterCards;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void OnOwnerLevelUp()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		List<CharacterSkillCard_Base> characterCards = _characterCards;
		object obj = 0;
		object obj2 = 0;
		List<CharacterSkillCard_Base> characterCards2 = _characterCards;
		while (true)
		{
			if ((nint)obj2 < characterCards._size)
			{
				if ((nint)obj >= characterCards2._size)
				{
					break;
				}
				CharacterSkillCard_Base[] items = characterCards2._items;
				items[obj].OnOwnerLevelUp();
				characterCards2 = _characterCards;
				obj++;
				obj2 = obj;
				characterCards = _characterCards;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void UpdateCards()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		List<CharacterSkillCard_Base> characterCards = _characterCards;
		object obj = 0;
		object obj2 = 0;
		List<CharacterSkillCard_Base> characterCards2 = _characterCards;
		while (true)
		{
			if ((nint)obj2 < characterCards._size)
			{
				if ((nint)obj >= characterCards2._size)
				{
					break;
				}
				CharacterSkillCard_Base[] items = characterCards2._items;
				items[obj].Update();
				characterCards2 = _characterCards;
				obj++;
				obj2 = obj;
				characterCards = _characterCards;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public static List<SkillCardEdition> GetSpecialEditions(int cardCount, ref Unity.Mathematics.Random random)
	{
		//IL_0015: Expected O, but got I
		//IL_0153: Expected O, but got I
		//IL_0091: Expected O, but got I
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		List<SkillCardEdition> list = new List<SkillCardEdition>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.SkillCardEdition>)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.SkillCardEdition>)+18]");
		if ((nint)0 < (nint)cardCount)
		{
			float wHolo = default(float);
			float wPoly = default(float);
			float wInve = default(float);
			do
			{
				SkillCardEdition weightedEdition = GetWeightedEdition(ref random, 0f, 4f, 4f, wHolo, wPoly, wInve);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.SkillCardEdition>)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.SkillCardEdition>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.SkillCardEdition>)+18]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rdx_v6+18]");
				if (num >= 0)
				{
					((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)weightedEdition);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.SkillCardEdition>)+18]");
					object obj3 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.SkillCardEdition>)+18]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rdx_v6+18]");
					if (num2 >= 0)
					{
						return (List<SkillCardEdition>)(object)new IndexOutOfRangeException();
					}
				}
				obj++;
			}
			while ((nint)obj < cardCount);
		}
		return list;
	}

	public static List<SkillCardEdition> GetRandomEditions(int totalCardsInDraft, ref Unity.Mathematics.Random random)
	{
		//IL_00aa: Expected O, but got I
		//IL_0205: Expected O, but got I
		//IL_012b: Expected O, but got I
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		List<SkillCardEdition> list = new List<SkillCardEdition>();
		float wHolo = default(float);
		float wPoly = default(float);
		float wInve = default(float);
		if (totalCardsInDraft >= 6)
		{
			SkillCardEdition weightedEdition = GetWeightedEdition(ref random, 0f, 50f, 50f, wHolo, wPoly, wInve);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB17A0");
		}
		else if (totalCardsInDraft < 5)
		{
			goto IL_009a;
		}
		SkillCardEdition weightedEdition2 = GetWeightedEdition(ref random, 0f, 4f, 4f, wHolo, wPoly, wInve);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB17A0");
		goto IL_009a;
		IL_009a:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.SkillCardEdition>)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.SkillCardEdition>)+18]");
		if ((nint)0 < (nint)totalCardsInDraft)
		{
			do
			{
				SkillCardEdition weightedEdition3 = GetWeightedEdition(ref random, 75f, 4f, 4f, wHolo, wPoly, wInve);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.SkillCardEdition>)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.SkillCardEdition>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.SkillCardEdition>)+18]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rdx_v7+18]");
				if (num >= 0)
				{
					((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)weightedEdition3);
					nint num2 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.SkillCardEdition>)+18]");
					object obj3 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.SkillCardEdition>)+18]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rdx_v7+18]");
					if (num3 >= 0)
					{
						return (List<SkillCardEdition>)(object)new IndexOutOfRangeException();
					}
				}
				obj++;
			}
			while ((nint)obj < totalCardsInDraft);
		}
		return list;
	}

	public unsafe static SkillCardEdition GetWeightedEdition(ref Unity.Mathematics.Random random, float wBase = 75f, float wFoil = 4f, float wGala = 4f, float wHolo = 7f, float wPoly = 7f, float wInve = 3f)
	{
		//IL_044c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0451: Expected O, but got Unknown
		//IL_0570: Expected I, but got O
		//IL_0586: Expected O, but got I
		//IL_047e: Expected O, but got I4
		//IL_0360: Unknown result type (might be due to invalid IL or missing references)
		//IL_0365: Expected O, but got Unknown
		//IL_0380: Expected O, but got I8
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_038e: Expected O, but got Unknown
		//IL_0630: Expected O, but got I4
		//IL_0640: Unknown result type (might be due to invalid IL or missing references)
		//IL_0645: Expected O, but got Unknown
		//IL_048c: Expected O, but got I4
		//IL_0494: Expected O, but got Ref
		List<WeightedEdition> list = new List<WeightedEdition>();
		WeightedEdition weightedEdition = new WeightedEdition();
		if (weightedEdition != null)
		{
			weightedEdition.Edition = SkillCardEdition.Base;
			float num = SvMult_Base();
			float weight = num * wBase;
			weightedEdition.Weight = weight;
			if (list != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1800");
				WeightedEdition weightedEdition2 = new WeightedEdition();
				if (weightedEdition2 != null)
				{
					weightedEdition2.Edition = SkillCardEdition.Foil;
					float num2 = SvMult_Foil();
					float num3 = SvMult_AnyRare();
					float num4 = num2 * wFoil;
					float weight2 = num4 * num3;
					weightedEdition2.Weight = weight2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1800");
					WeightedEdition weightedEdition3 = new WeightedEdition();
					if (weightedEdition3 != null)
					{
						weightedEdition3.Edition = SkillCardEdition.Gala;
						float num5 = SvMult_Gala();
						float num6 = SvMult_AnyRare();
						float num7 = num5 * wGala;
						float weight3 = num7 * num6;
						weightedEdition3.Weight = weight3;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1800");
						WeightedEdition weightedEdition4 = new WeightedEdition();
						if (weightedEdition4 != null)
						{
							weightedEdition4.Edition = SkillCardEdition.Holo;
							float num8 = SvMult_Holo();
							float num9 = SvMult_AnyRare();
							object obj = default(object);
							float num10 = num8 * (float)obj;
							float weight4 = num10 * num9;
							weightedEdition4.Weight = weight4;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1800");
							WeightedEdition weightedEdition5 = new WeightedEdition();
							if (weightedEdition5 != null)
							{
								weightedEdition5.Edition = SkillCardEdition.Poly;
								float num11 = SvMult_Poly();
								float num12 = SvMult_AnyRare();
								object obj2 = default(object);
								float num13 = num11 * (float)obj2;
								float weight5 = num13 * num12;
								weightedEdition5.Weight = weight5;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1800");
								WeightedEdition weightedEdition6 = new WeightedEdition();
								if (weightedEdition6 != null)
								{
									weightedEdition6.Edition = SkillCardEdition.Inve;
									float num14 = SvMult_Inve();
									float num15 = SvMult_AnyRare();
									object obj3 = default(object);
									float num16 = num14 * (float)obj3;
									float weight6 = num16 * num15;
									weightedEdition6.Weight = weight6;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1800");
									Func<WeightedEdition, float> selector = _003C_003Ec._003C_003E9__12_0;
									if (_003C_003Ec._003C_003E9__12_0 == null)
									{
										Func<WeightedEdition, float> func = (_003C_003Ec._003C_003E9__12_0 = (Func<object, float>)((WeightedEdition x) => x.Weight));
										nint num17 = (nint)typeof(_003C_003Ec);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rax_v55 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterSkillCardsManager+<>c>)+B8]");
										object obj4 = (nint)0 + (nint)8;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
										bool flag = (nint)0 == 0;
										selector = func;
										if (!flag)
										{
											object obj5 = obj4 >> 12;
											object obj6 = obj5 & 0x1FFFFF;
											object obj7 = obj6 >> 6;
											object obj8 = 6603577472L;
											object obj9 = obj6 & 0x3F;
											nint num19;
											do
											{
												object obj10 = 1 << (int)obj9;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ rbx_v14+462E0+v461 @ rdx_v24 (System.Object)*8]");
												object obj11 = 0 | obj10;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ rbx_v14+462E0+v461 @ rdx_v24 (System.Object)*8]");
												nint num18 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ rbx_v14+462E0+v461 @ rdx_v24 (System.Object)*8]");
												if (num18 == 0)
												{
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ rbx_v14+462E0+v461 @ rdx_v24 (System.Object)*8]");
												num19 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ rbx_v14+462E0+v461 @ rdx_v24 (System.Object)*8]");
											}
											while (num19 != 0);
											selector = func;
										}
									}
									IEnumerable<float> source = Enumerable.Select(list, selector);
									float num20 = Enumerable.Sum(source);
									object obj12 = (object)random << 13;
									object obj13 = obj12 ^ (object)random;
									object obj14 = obj13 >> 17;
									object obj15 = obj14 ^ obj13;
									object obj16 = obj15 << 5;
									object obj17 = obj16 ^ obj15;
									ref Unity.Mathematics.Random reference = ref *(Unity.Mathematics.Random*)obj17;
									object obj18 = (object)random >> 9;
									object obj19 = obj18 | 0x3F800000;
									float num21 = (float)obj19 - 1f;
									float num22 = num21 * num20;
									object obj20 = 0;
									List<WeightedEdition>.Enumerator enumerator = default(List<WeightedEdition>.Enumerator);
									if (enumerator.MoveNext())
									{
										object obj21 = 0;
										List<WeightedEdition>.Enumerator enumerator2 = (List<WeightedEdition>.Enumerator)(&enumerator);
										throw new NullReferenceException();
									}
									return SkillCardEdition.Base;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe static float GetSurvarotDifficultyMultiplier()
	{
		//IL_0205: Expected O, but got I
		//IL_023a: Expected O, but got I
		//IL_005a: Expected O, but got I
		//IL_026f: Expected O, but got I
		//IL_008f: Expected F4, but got I
		//IL_02a4: Expected O, but got I
		//IL_02d9: Expected O, but got I
		//IL_031e: Expected O, but got I
		//IL_0336: Expected O, but got I
		//IL_0346: Expected O, but got I
		//IL_0356: Expected O, but got I
		//IL_01e8: Expected O, but got I8
		//IL_05ec: Expected O, but got I4
		//IL_0607: Expected F4, but got I4
		//IL_00d9: Expected O, but got I4
		//IL_00e9: Expected O, but got Ref
		//IL_0408: Expected O, but got I8
		//IL_049d: Expected O, but got I4
		//IL_06d7: Expected O, but got I
		//IL_0437: Expected F4, but got I4
		//IL_0685: Expected F4, but got I4
		//IL_036e: Expected I, but got O
		//IL_0384: Expected O, but got I
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a0: Expected O, but got Unknown
		//IL_03bb: Expected O, but got I8
		//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c9: Expected O, but got Unknown
		//IL_044c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0451: Expected O, but got Unknown
		//IL_0738: Expected O, but got I4
		//IL_0748: Unknown result type (might be due to invalid IL or missing references)
		//IL_074d: Expected O, but got Unknown
		//IL_03ed: Expected O, but got I8
		//IL_03f6: Expected F4, but got I4
		GameManager core = GM.Core;
		bool flag = (object)GM.Core == null;
		List<object> typeFromHandle = (List<object>)(object)typeof(GM);
		int num2;
		int num3;
		object obj4;
		Predicate<CharacterSkillCard_Base> match;
		if (!flag)
		{
			typeFromHandle = (List<object>)(object)typeof(GM);
			if (core._mainCharacters != null)
			{
				List<CharacterController> mainCharacters = core._mainCharacters;
				if (mainCharacters._size > 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ rcx_v5 (System.Collections.Generic.List`1<System.Object>)+B8]");
					object obj = 0;
					object obj2 = obj;
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ r9_v10+2A0]");
						float num = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ r9_v10+2A0]");
						if ((nint)0 != 0)
						{
							num2 = 0;
							num3 = 0;
							List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
							float num4;
							if (enumerator.MoveNext())
							{
								object obj3 = 0;
								num4 = num;
								typeFromHandle = (List<object>)(&enumerator);
								throw new NullReferenceException();
							}
							obj4 = 6442450944L;
							num4 = num;
							goto IL_05de;
						}
					}
					goto IL_04c1;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ rcx_v5 (System.Collections.Generic.List`1<System.Object>)+B8]");
			object obj5 = 0;
			object obj6 = obj5;
			if (obj5 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v8+E0]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v8+E0]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v20+10]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v20+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rdx_v9+388]");
						object obj9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rdx_v9+388]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v21+10]");
							object obj10 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v21+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r15_v9+18]");
								num3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ rcx_v5 (System.Collections.Generic.List`1<System.Object>)+B8]");
								object obj11 = 0;
								object obj12 = obj11;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v569 @ rcx_v12+E0]");
								object obj13 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ rax_v23+10]");
								object obj14 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v571 @ rcx_v13+388]");
								object obj15 = 0;
								match = _003C_003Ec._003C_003E9__13_0;
								if (_003C_003Ec._003C_003E9__13_0 == null)
								{
									Predicate<CharacterSkillCard_Base> predicate = (_003C_003Ec._003C_003E9__13_0 = delegate(CharacterSkillCard_Base x)
									{
										//IL_0052: Expected I4, but got O
										//IL_0030: Expected O, but got I4
										if (x == null)
										{
											NullReferenceException ex = new NullReferenceException();
											return (byte)(int)ex != 0;
										}
										object obj27 = x.Edition - 4;
										return obj27 == null;
									});
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
									bool flag2 = (nint)0 == 0;
									match = predicate;
									float num = 0f;
									if (!flag2)
									{
										nint num5 = (nint)typeof(_003C_003Ec);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v901 @ rax_v35 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterSkillCardsManager+<>c>)+B8]");
										object obj16 = (nint)0 + (nint)16;
										object obj17 = obj16 >> 12;
										object obj18 = obj17 & 0x1FFFFF;
										object obj19 = obj18 >> 6;
										object obj20 = 6442450944L;
										object obj21 = obj18 & 0x3F;
										nint num7;
										do
										{
											object obj22 = 1 << (int)obj21;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v808 @ rdi_v10+99EFB60+v805 @ rdx_v15*8]");
											object obj23 = 0 | obj22;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v808 @ rdi_v10+99EFB60+v805 @ rdx_v15*8]");
											nint num6 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v808 @ rdi_v10+99EFB60+v805 @ rdx_v15*8]");
											if (num6 == 0)
											{
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v808 @ rdi_v10+99EFB60+v805 @ rdx_v15*8]");
											num7 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v808 @ rdi_v10+99EFB60+v805 @ rdx_v15*8]");
										}
										while (num7 != 0);
										match = predicate;
										obj4 = 6442450944L;
										num = 0f;
										goto IL_06c2;
									}
								}
								obj4 = 6442450944L;
								goto IL_06c2;
							}
						}
					}
				}
			}
		}
		goto IL_04c1;
		IL_05de:
		object obj24 = num3 + 1;
		bool flag3 = (nint)obj24 <= 0;
		float num8 = 0f;
		if (!flag3)
		{
			int num9 = 0;
			float num10 = 0f;
			bool flag4;
			do
			{
				if (num9 <= 5)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v637 @ rdi_v6+7566BA0+v586 @ rsi_v4 (System.Int32)*4]");
					object obj25 = 0 + obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v653 @ rcx_v11 (should have been resolved before IL gen)");
				}
				float num11 = (float)num3 * 0.01f;
				float num4 = num11 + 0.05f;
				num8 = num10 + num4;
				num9++;
				flag4 = num9 < (nint)obj24;
				num10 = num8;
			}
			while (flag4);
		}
		object obj26 = num2 + 1;
		float num12 = num8 / (float)obj26;
		return num12 + 1f;
		IL_04c1:
		throw new NullReferenceException();
		IL_06c2:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ rax_v24+10]");
		List<object> list = ((List<object>)0).FindAll((Predicate<object>)match);
		if (list == null)
		{
			goto IL_04c1;
		}
		num2 = list._size;
		nint num13 = 0;
		goto IL_05de;
	}

	public unsafe static float AdjustAdditionalEnemiesHPMultiplierWithINVE(float currentMul)
	{
		//IL_01da: Expected O, but got I
		//IL_020f: Expected O, but got I
		//IL_005a: Expected O, but got I
		//IL_0244: Expected O, but got I
		//IL_0279: Expected O, but got I
		//IL_0472: Expected O, but got I4
		//IL_00c0: Expected O, but got I4
		//IL_00d0: Expected F4, but got I
		//IL_00d8: Expected O, but got Ref
		//IL_02e3: Expected O, but got I
		GameManager core = GM.Core;
		bool flag = (object)GM.Core == null;
		List<object> typeFromHandle = (List<object>)(object)typeof(GM);
		int num;
		float num2;
		if (!flag)
		{
			typeFromHandle = (List<object>)(object)typeof(GM);
			if (core._mainCharacters != null)
			{
				List<CharacterController> mainCharacters = core._mainCharacters;
				if (mainCharacters._size > 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rcx_v5 (System.Collections.Generic.List`1<System.Object>)+B8]");
					object obj = 0;
					object obj2 = obj;
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r10_v7+2A0]");
						if ((nint)0 != 0)
						{
							num = 0;
							List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
							if (enumerator.MoveNext())
							{
								object obj3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r10_v7+2A0]");
								num2 = 0f;
								typeFromHandle = (List<object>)(&enumerator);
								throw new NullReferenceException();
							}
							goto IL_0464;
						}
					}
					goto IL_0316;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rcx_v5 (System.Collections.Generic.List`1<System.Object>)+B8]");
			object obj4 = 0;
			object obj5 = obj4;
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v19+E0]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v19+E0]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v20+10]");
					typeFromHandle = (List<object>)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v20+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rcx_v5 (System.Collections.Generic.List`1<System.Object>)+388]");
						object obj7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rcx_v5 (System.Collections.Generic.List`1<System.Object>)+388]");
						if ((nint)0 != 0)
						{
							Predicate<object> match = (Predicate<object>)_003C_003Ec._003C_003E9__14_0;
							if (_003C_003Ec._003C_003E9__14_0 == null)
							{
								match = (Predicate<object>)(_003C_003Ec._003C_003E9__14_0 = delegate(CharacterSkillCard_Base x)
								{
									//IL_0052: Expected I4, but got O
									//IL_0030: Expected O, but got I4
									if (x == null)
									{
										NullReferenceException ex = new NullReferenceException();
										return (byte)(int)ex != 0;
									}
									object obj9 = x.Edition - 4;
									return obj9 == null;
								});
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rax_v21+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rax_v21+10]");
								List<object> list = ((List<object>)0).FindAll(match);
								if (list != null)
								{
									num = list._size;
									goto IL_0464;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0316;
		IL_0464:
		object obj8 = num + 1;
		return currentMul / (float)obj8;
		IL_0316:
		num2 = currentMul;
		throw new NullReferenceException();
	}

	public static CharacterSkillCard_Base GetCardForArcanaType(ArcanaType arcanaType)
	{
		//IL_072a: Expected O, but got I4
		//IL_0737: Expected O, but got I8
		//IL_0786: Expected O, but got I4
		//IL_04e7: Expected O, but got I4
		//IL_0230: Expected O, but got I4
		//IL_0890: Expected I, but got O
		//IL_076e: Expected O, but got I8
		//IL_0033: Expected O, but got I4
		//IL_07ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b1: Expected O, but got Unknown
		//IL_050d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0512: Expected O, but got Unknown
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected O, but got Unknown
		//IL_087d: Expected I, but got O
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_07c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07cd: Expected O, but got Unknown
		//IL_0529: Unknown result type (might be due to invalid IL or missing references)
		//IL_052e: Expected O, but got Unknown
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Expected O, but got Unknown
		//IL_01e1: Expected I, but got O
		//IL_086a: Expected I, but got O
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Expected O, but got Unknown
		//IL_01ce: Expected I, but got O
		//IL_0857: Expected I, but got O
		//IL_0806: Expected O, but got I4
		//IL_0567: Expected O, but got I4
		//IL_01bb: Expected I, but got O
		//IL_05c3: Expected O, but got I4
		//IL_00b3: Expected O, but got I4
		//IL_083d: Expected O, but got I8
		//IL_0591: Expected O, but got I8
		//IL_05ab: Expected O, but got I8
		//IL_02cc: Expected O, but got I4
		//IL_05e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ee: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Expected O, but got Unknown
		//IL_0605: Unknown result type (might be due to invalid IL or missing references)
		//IL_060a: Expected O, but got Unknown
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Expected O, but got Unknown
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Expected O, but got Unknown
		//IL_0368: Expected O, but got I4
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0393: Expected O, but got Unknown
		SubSkillCard_GoldCount_AddPassiveSlots subSkillCard_GoldCount_AddPassiveSlots;
		ArcanaType type = default(ArcanaType);
		if (arcanaType > ArcanaType.SUB_ONDAMAGED_GROUNDHIT)
		{
			if (arcanaType > ArcanaType.SUB_HPCRITICAL_MAXARMOR)
			{
				object obj = arcanaType - 7000;
				bool flag = arcanaType == ArcanaType.SUB_OVERHEAL_ICEBREATH;
				if (!flag)
				{
					object obj2 = obj - 1;
					if (!flag)
					{
						object obj3 = obj2 - 1;
						if (!flag)
						{
							if ((nint)obj3 != 1)
							{
								object obj4 = arcanaType - 8000;
								bool flag2 = arcanaType == ArcanaType.SUB_GOLDCOUNT_LIGHTSOURCES;
								if (!flag2)
								{
									object obj5 = obj4 - 1;
									if (!flag2)
									{
										object obj6 = obj5 - 1;
										if (!flag2)
										{
											if ((nint)obj6 != 1)
											{
												if (arcanaType != ArcanaType.SUB_FAMILIAR_BROWNIE)
												{
													goto IL_0847;
												}
												SubSkillCard_Familiar_Brownie subSkillCard_Familiar_Brownie = null;
												subSkillCard_Familiar_Brownie.followerType = CharacterType.FS_FOLLOWER_BROWNIE;
												type = arcanaType;
												subSkillCard_GoldCount_AddPassiveSlots = (SubSkillCard_GoldCount_AddPassiveSlots)(object)subSkillCard_Familiar_Brownie;
												goto IL_08b5;
											}
											subSkillCard_GoldCount_AddPassiveSlots = null;
										}
										else
										{
											SubSkillCard_GoldCount_AddRevives subSkillCard_GoldCount_AddRevives = null;
											subSkillCard_GoldCount_AddPassiveSlots = (SubSkillCard_GoldCount_AddPassiveSlots)(object)subSkillCard_GoldCount_AddRevives;
										}
									}
									else
									{
										SubSkillCard_GoldCount_Thorns subSkillCard_GoldCount_Thorns = null;
										subSkillCard_GoldCount_AddPassiveSlots = (SubSkillCard_GoldCount_AddPassiveSlots)(object)subSkillCard_GoldCount_Thorns;
									}
								}
								else
								{
									SubSkillCard_GoldCount_LightSources subSkillCard_GoldCount_LightSources = null;
									subSkillCard_GoldCount_AddPassiveSlots = (SubSkillCard_GoldCount_AddPassiveSlots)(object)subSkillCard_GoldCount_LightSources;
								}
								goto IL_08c7;
							}
							nint num = (nint)typeof(SubSkillCard_Overheal_RerollUp);
						}
						else
						{
							nint num = (nint)typeof(SubSkillCard_Overheal_FeverUp);
						}
					}
					else
					{
						nint num = (nint)typeof(SubSkillCard_Overheal_MightUp);
					}
					subSkillCard_GoldCount_AddPassiveSlots = (SubSkillCard_GoldCount_AddPassiveSlots)new CharacterSkillCard_Base(type);
					_ = 1098907648;
					_ = 1;
					_ = 1120403456;
				}
				else
				{
					SubSkillCard_Overheal_IceBreath subSkillCard_Overheal_IceBreath = null;
					subSkillCard_Overheal_IceBreath.overhealTriggerValue = 16f;
					subSkillCard_Overheal_IceBreath.canOverheal = true;
					subSkillCard_Overheal_IceBreath.overhealDelay = 1000f;
					subSkillCard_GoldCount_AddPassiveSlots = (SubSkillCard_GoldCount_AddPassiveSlots)(object)subSkillCard_Overheal_IceBreath;
				}
			}
			else
			{
				object obj7 = arcanaType - 4000;
				bool flag3 = arcanaType == ArcanaType.SUB_PASSIVE_CRITICALUP;
				if (!flag3)
				{
					object obj8 = obj7 - 1;
					if (!flag3)
					{
						object obj9 = obj8 - 1;
						if (!flag3)
						{
							object obj10 = obj9 - 1;
							if (!flag3)
							{
								if ((nint)obj10 != 1)
								{
									object obj11 = arcanaType - 5000;
									bool flag4 = arcanaType == ArcanaType.SUB_ENEMIESCOUNT_ADDREVIVES;
									if (!flag4)
									{
										object obj12 = obj11 - 1;
										if (!flag4)
										{
											object obj13 = obj12 - 1;
											if (!flag4)
											{
												object obj14 = obj13 - 1;
												if (!flag4)
												{
													if ((nint)obj14 != 1)
													{
														object obj15 = arcanaType - 6000;
														bool flag5 = arcanaType == ArcanaType.SUB_HPCRITICAL_RECOVERHP;
														if (!flag5)
														{
															object obj16 = obj15 - 1;
															if (!flag5)
															{
																if ((nint)obj16 != 1)
																{
																	goto IL_0847;
																}
																SubSkillCard_HPCritical_MaxArmor subSkillCard_HPCritical_MaxArmor = null;
																subSkillCard_GoldCount_AddPassiveSlots = (SubSkillCard_GoldCount_AddPassiveSlots)(object)subSkillCard_HPCritical_MaxArmor;
															}
															else
															{
																SubSkillCard_HPCritical_FireBreath subSkillCard_HPCritical_FireBreath = null;
																subSkillCard_GoldCount_AddPassiveSlots = (SubSkillCard_GoldCount_AddPassiveSlots)(object)subSkillCard_HPCritical_FireBreath;
															}
														}
														else
														{
															SubSkillCard_HPCritical_RecoverHP subSkillCard_HPCritical_RecoverHP = null;
															subSkillCard_GoldCount_AddPassiveSlots = (SubSkillCard_GoldCount_AddPassiveSlots)(object)subSkillCard_HPCritical_RecoverHP;
														}
													}
													else
													{
														SubSkillCard_EnemiesCount_GoldFever subSkillCard_EnemiesCount_GoldFever = null;
														subSkillCard_GoldCount_AddPassiveSlots = (SubSkillCard_GoldCount_AddPassiveSlots)(object)subSkillCard_EnemiesCount_GoldFever;
													}
												}
												else
												{
													SubSkillCard_EnemiesCount_AddCoins subSkillCard_EnemiesCount_AddCoins = null;
													subSkillCard_GoldCount_AddPassiveSlots = (SubSkillCard_GoldCount_AddPassiveSlots)(object)subSkillCard_EnemiesCount_AddCoins;
												}
											}
											else
											{
												SubSkillCard_EnemiesCount_AddArmor subSkillCard_EnemiesCount_AddArmor = null;
												subSkillCard_GoldCount_AddPassiveSlots = (SubSkillCard_GoldCount_AddPassiveSlots)(object)subSkillCard_EnemiesCount_AddArmor;
											}
										}
										else
										{
											SubSkillCard_EnemiesCount_AddAmount subSkillCard_EnemiesCount_AddAmount = null;
											subSkillCard_GoldCount_AddPassiveSlots = (SubSkillCard_GoldCount_AddPassiveSlots)(object)subSkillCard_EnemiesCount_AddAmount;
										}
									}
									else
									{
										SubSkillCard_EnemiesCount_AddRevives subSkillCard_EnemiesCount_AddRevives = null;
										subSkillCard_GoldCount_AddPassiveSlots = (SubSkillCard_GoldCount_AddPassiveSlots)(object)subSkillCard_EnemiesCount_AddRevives;
									}
								}
								else
								{
									SubSkillCard_Passive_Disable subSkillCard_Passive_Disable = null;
									subSkillCard_Passive_Disable.triggerChance = 0.5f;
									subSkillCard_GoldCount_AddPassiveSlots = (SubSkillCard_GoldCount_AddPassiveSlots)(object)subSkillCard_Passive_Disable;
								}
							}
							else
							{
								SubSkillCard_Passive_CharmUp subSkillCard_Passive_CharmUp = null;
								subSkillCard_GoldCount_AddPassiveSlots = (SubSkillCard_GoldCount_AddPassiveSlots)(object)subSkillCard_Passive_CharmUp;
							}
						}
						else
						{
							SubSkillCard_Passive_DefangUp subSkillCard_Passive_DefangUp = null;
							subSkillCard_GoldCount_AddPassiveSlots = (SubSkillCard_GoldCount_AddPassiveSlots)(object)subSkillCard_Passive_DefangUp;
						}
					}
					else
					{
						SubSkillCard_Passive_GuardianAura subSkillCard_Passive_GuardianAura = null;
						subSkillCard_GoldCount_AddPassiveSlots = (SubSkillCard_GoldCount_AddPassiveSlots)(object)subSkillCard_Passive_GuardianAura;
					}
				}
				else
				{
					SubSkillCard_Passive_CriticalUp subSkillCard_Passive_CriticalUp = null;
					subSkillCard_GoldCount_AddPassiveSlots = (SubSkillCard_GoldCount_AddPassiveSlots)(object)subSkillCard_Passive_CriticalUp;
				}
			}
		}
		else if (arcanaType > ArcanaType.SUB_XLEVEL_BANISH1)
		{
			object obj17 = arcanaType - 1200;
			bool flag6 = arcanaType == ArcanaType.SUB_SKIP_COOLDOWNDOWN;
			if (!flag6)
			{
				object obj18 = obj17 - 1;
				if (!flag6)
				{
					object obj19 = obj18 - 1;
					if (!flag6)
					{
						if ((nint)obj19 != 1)
						{
							object obj20 = arcanaType - 2000;
							if ((nint)obj20 <= 5)
							{
								object obj21 = 6442450944L;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rbx_v8+7568A28+v481 @ rax_v17*4]");
								object obj22 = 0 + 6442450944L;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v178 @ rax_v24 (should have been resolved before IL gen)");
							}
							object obj23 = arcanaType - 3000;
							bool flag7 = arcanaType == ArcanaType.SUB_ONDAMAGED_ARMORUP;
							if (!flag7)
							{
								object obj24 = obj23 - 1;
								if (!flag7)
								{
									object obj25 = obj24 - 1;
									if (!flag7)
									{
										if ((nint)obj25 != 1)
										{
											goto IL_0847;
										}
										SubSkillCard_OnDamaged_GroundHit subSkillCard_OnDamaged_GroundHit = null;
										subSkillCard_OnDamaged_GroundHit._canRetaliate = true;
										subSkillCard_OnDamaged_GroundHit.retaliationDelay = 1000f;
										subSkillCard_GoldCount_AddPassiveSlots = (SubSkillCard_GoldCount_AddPassiveSlots)(object)subSkillCard_OnDamaged_GroundHit;
									}
									else
									{
										SubSkillCard_OnDamaged_AddCoin subSkillCard_OnDamaged_AddCoin = null;
										subSkillCard_OnDamaged_AddCoin._canRetaliate = true;
										subSkillCard_OnDamaged_AddCoin.retaliationDelay = 50f;
										subSkillCard_GoldCount_AddPassiveSlots = (SubSkillCard_GoldCount_AddPassiveSlots)(object)subSkillCard_OnDamaged_AddCoin;
									}
								}
								else
								{
									SubSkillCard_OnDamaged_RecoveryUp subSkillCard_OnDamaged_RecoveryUp = null;
									subSkillCard_OnDamaged_RecoveryUp.bonusDelay = 10000f;
									subSkillCard_GoldCount_AddPassiveSlots = (SubSkillCard_GoldCount_AddPassiveSlots)(object)subSkillCard_OnDamaged_RecoveryUp;
								}
							}
							else
							{
								SubSkillCard_OnDamaged_ArmorUp subSkillCard_OnDamaged_ArmorUp = null;
								subSkillCard_OnDamaged_ArmorUp.armorDelay = 10000f;
								subSkillCard_GoldCount_AddPassiveSlots = (SubSkillCard_GoldCount_AddPassiveSlots)(object)subSkillCard_OnDamaged_ArmorUp;
							}
						}
						else
						{
							SubSkillCard_OnSkip_TimeFreeze subSkillCard_OnSkip_TimeFreeze = null;
							subSkillCard_GoldCount_AddPassiveSlots = (SubSkillCard_GoldCount_AddPassiveSlots)(object)subSkillCard_OnSkip_TimeFreeze;
						}
					}
					else
					{
						SubSkillCard_OnSkip_Rosary subSkillCard_OnSkip_Rosary = null;
						subSkillCard_GoldCount_AddPassiveSlots = (SubSkillCard_GoldCount_AddPassiveSlots)(object)subSkillCard_OnSkip_Rosary;
					}
				}
				else
				{
					SubSkillCard_OnSkip_FullRecoverHP subSkillCard_OnSkip_FullRecoverHP = null;
					subSkillCard_GoldCount_AddPassiveSlots = (SubSkillCard_GoldCount_AddPassiveSlots)(object)subSkillCard_OnSkip_FullRecoverHP;
				}
			}
			else
			{
				SubSkillCard_OnSkip_CooldownDown subSkillCard_OnSkip_CooldownDown = null;
				subSkillCard_GoldCount_AddPassiveSlots = (SubSkillCard_GoldCount_AddPassiveSlots)(object)subSkillCard_OnSkip_CooldownDown;
			}
		}
		else
		{
			object obj26 = arcanaType - 101;
			object obj27 = 6442450944L;
			if ((nint)obj26 <= 23)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rbx_v7+7568A40+v114 @ rax_v8*4]");
				object obj28 = 0 + 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v143 @ rcx_v17 (should have been resolved before IL gen)");
			}
			object obj29 = arcanaType - 1000;
			bool flag8 = arcanaType == ArcanaType.SUB_ADDWEAPON_BONE2;
			if (!flag8)
			{
				object obj30 = obj29 - 1;
				if (!flag8)
				{
					object obj31 = obj30 - 1;
					if (!flag8)
					{
						if ((nint)obj31 != 1)
						{
							object obj32 = arcanaType - 1100;
							if ((nint)obj32 <= 8)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rbx_v7+7568AA0+v492 @ rax_v10*4]");
								object obj33 = 0 + 6442450944L;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v183 @ rcx_v15 (should have been resolved before IL gen)");
							}
							goto IL_0847;
						}
						nint num2 = (nint)typeof(SubSkillCard_AddWeapon_Flower2);
					}
					else
					{
						nint num2 = (nint)typeof(SubSkillCard_AddWeapon_Cherry2);
					}
				}
				else
				{
					nint num2 = (nint)typeof(SubSkillCard_AddWeapon_Cart2Evo);
				}
			}
			else
			{
				nint num2 = (nint)typeof(SubSkillCard_AddWeapon_Bone2);
			}
			subSkillCard_GoldCount_AddPassiveSlots = null;
			_ = 80;
		}
		goto IL_08c7;
		IL_08c7:
		type = arcanaType;
		goto IL_08b5;
		IL_0847:
		return null;
		IL_08b5:
		((CharacterSkillCard_Base)subSkillCard_GoldCount_AddPassiveSlots)._002Ector(type);
		return subSkillCard_GoldCount_AddPassiveSlots;
	}

	public unsafe static float SvMult_AnyRare()
	{
		//IL_0045: Expected I, but got O
		//IL_0073: Expected O, but got I
		//IL_00af: Expected O, but got I4
		//IL_00bd: Expected O, but got I4
		//IL_00c5: Expected O, but got Ref
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			if (core._mainCharacters != null)
			{
				List<CharacterController> mainCharacters = core._mainCharacters;
				if (mainCharacters._size > 1)
				{
					nint num = (nint)GM.Core;
					if ((object)GM.Core != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v4 (Il2CppMethodInfo)+2A0]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v4 (Il2CppMethodInfo)+2A0]");
						if ((nint)0 != 0)
						{
							GameManager core2 = GM.Core;
							object obj2 = 0;
							List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
							if (enumerator.MoveNext())
							{
								object obj3 = 0;
								List<CharacterController>.Enumerator enumerator2 = (List<CharacterController>.Enumerator)(&enumerator);
								throw new NullReferenceException();
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v16+18]");
							float num2 = 0f - 1f;
							return (float)obj2 - num2;
						}
					}
					goto IL_0178;
				}
			}
			GameManager core3 = GM.Core;
			if ((object)GM.Core != null)
			{
				GameSessionData gameSessionData = core3._gameSessionData;
				if (core3._gameSessionData != null)
				{
					CharacterController activeCharacter = gameSessionData._activeCharacter;
					if ((object)gameSessionData._activeCharacter != null)
					{
						return activeCharacter.SvMult_AnyRare;
					}
				}
			}
		}
		goto IL_0178;
		IL_0178:
		throw new NullReferenceException();
	}

	public unsafe static float SvMult_Foil()
	{
		//IL_0045: Expected I, but got O
		//IL_0073: Expected O, but got I
		//IL_00af: Expected O, but got I4
		//IL_00bd: Expected O, but got I4
		//IL_00c5: Expected O, but got Ref
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			if (core._mainCharacters != null)
			{
				List<CharacterController> mainCharacters = core._mainCharacters;
				if (mainCharacters._size > 1)
				{
					nint num = (nint)GM.Core;
					if ((object)GM.Core != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v4 (Il2CppMethodInfo)+2A0]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v4 (Il2CppMethodInfo)+2A0]");
						if ((nint)0 != 0)
						{
							GameManager core2 = GM.Core;
							object obj2 = 0;
							List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
							if (enumerator.MoveNext())
							{
								object obj3 = 0;
								List<CharacterController>.Enumerator enumerator2 = (List<CharacterController>.Enumerator)(&enumerator);
								throw new NullReferenceException();
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v16+18]");
							float num2 = 0f - 1f;
							return (float)obj2 - num2;
						}
					}
					goto IL_0178;
				}
			}
			GameManager core3 = GM.Core;
			if ((object)GM.Core != null)
			{
				GameSessionData gameSessionData = core3._gameSessionData;
				if (core3._gameSessionData != null)
				{
					CharacterController activeCharacter = gameSessionData._activeCharacter;
					if ((object)gameSessionData._activeCharacter != null)
					{
						return activeCharacter.SvMult_Foil;
					}
				}
			}
		}
		goto IL_0178;
		IL_0178:
		throw new NullReferenceException();
	}

	public unsafe static float SvMult_Gala()
	{
		//IL_0045: Expected I, but got O
		//IL_0073: Expected O, but got I
		//IL_00af: Expected O, but got I4
		//IL_00bd: Expected O, but got I4
		//IL_00c5: Expected O, but got Ref
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			if (core._mainCharacters != null)
			{
				List<CharacterController> mainCharacters = core._mainCharacters;
				if (mainCharacters._size > 1)
				{
					nint num = (nint)GM.Core;
					if ((object)GM.Core != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v4 (Il2CppMethodInfo)+2A0]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v4 (Il2CppMethodInfo)+2A0]");
						if ((nint)0 != 0)
						{
							GameManager core2 = GM.Core;
							object obj2 = 0;
							List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
							if (enumerator.MoveNext())
							{
								object obj3 = 0;
								List<CharacterController>.Enumerator enumerator2 = (List<CharacterController>.Enumerator)(&enumerator);
								throw new NullReferenceException();
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v16+18]");
							float num2 = 0f - 1f;
							return (float)obj2 - num2;
						}
					}
					goto IL_0178;
				}
			}
			GameManager core3 = GM.Core;
			if ((object)GM.Core != null)
			{
				GameSessionData gameSessionData = core3._gameSessionData;
				if (core3._gameSessionData != null)
				{
					CharacterController activeCharacter = gameSessionData._activeCharacter;
					if ((object)gameSessionData._activeCharacter != null)
					{
						return activeCharacter.SvMult_Gala;
					}
				}
			}
		}
		goto IL_0178;
		IL_0178:
		throw new NullReferenceException();
	}

	public unsafe static float SvMult_Poly()
	{
		//IL_0045: Expected I, but got O
		//IL_0073: Expected O, but got I
		//IL_00af: Expected O, but got I4
		//IL_00bd: Expected O, but got I4
		//IL_00c5: Expected O, but got Ref
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			if (core._mainCharacters != null)
			{
				List<CharacterController> mainCharacters = core._mainCharacters;
				if (mainCharacters._size > 1)
				{
					nint num = (nint)GM.Core;
					if ((object)GM.Core != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v4 (Il2CppMethodInfo)+2A0]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v4 (Il2CppMethodInfo)+2A0]");
						if ((nint)0 != 0)
						{
							GameManager core2 = GM.Core;
							object obj2 = 0;
							List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
							if (enumerator.MoveNext())
							{
								object obj3 = 0;
								List<CharacterController>.Enumerator enumerator2 = (List<CharacterController>.Enumerator)(&enumerator);
								throw new NullReferenceException();
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v16+18]");
							float num2 = 0f - 1f;
							return (float)obj2 - num2;
						}
					}
					goto IL_0178;
				}
			}
			GameManager core3 = GM.Core;
			if ((object)GM.Core != null)
			{
				GameSessionData gameSessionData = core3._gameSessionData;
				if (core3._gameSessionData != null)
				{
					CharacterController activeCharacter = gameSessionData._activeCharacter;
					if ((object)gameSessionData._activeCharacter != null)
					{
						return activeCharacter.SvMult_Poly;
					}
				}
			}
		}
		goto IL_0178;
		IL_0178:
		throw new NullReferenceException();
	}

	public unsafe static float SvMult_Holo()
	{
		//IL_0045: Expected I, but got O
		//IL_0073: Expected O, but got I
		//IL_00af: Expected O, but got I4
		//IL_00bd: Expected O, but got I4
		//IL_00c5: Expected O, but got Ref
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			if (core._mainCharacters != null)
			{
				List<CharacterController> mainCharacters = core._mainCharacters;
				if (mainCharacters._size > 1)
				{
					nint num = (nint)GM.Core;
					if ((object)GM.Core != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v4 (Il2CppMethodInfo)+2A0]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v4 (Il2CppMethodInfo)+2A0]");
						if ((nint)0 != 0)
						{
							GameManager core2 = GM.Core;
							object obj2 = 0;
							List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
							if (enumerator.MoveNext())
							{
								object obj3 = 0;
								List<CharacterController>.Enumerator enumerator2 = (List<CharacterController>.Enumerator)(&enumerator);
								throw new NullReferenceException();
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v16+18]");
							float num2 = 0f - 1f;
							return (float)obj2 - num2;
						}
					}
					goto IL_0178;
				}
			}
			GameManager core3 = GM.Core;
			if ((object)GM.Core != null)
			{
				GameSessionData gameSessionData = core3._gameSessionData;
				if (core3._gameSessionData != null)
				{
					CharacterController activeCharacter = gameSessionData._activeCharacter;
					if ((object)gameSessionData._activeCharacter != null)
					{
						return activeCharacter.SvMult_Holo;
					}
				}
			}
		}
		goto IL_0178;
		IL_0178:
		throw new NullReferenceException();
	}

	public unsafe static float SvMult_Inve()
	{
		//IL_0045: Expected I, but got O
		//IL_0073: Expected O, but got I
		//IL_00af: Expected O, but got I4
		//IL_00bd: Expected O, but got I4
		//IL_00c5: Expected O, but got Ref
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			if (core._mainCharacters != null)
			{
				List<CharacterController> mainCharacters = core._mainCharacters;
				if (mainCharacters._size > 1)
				{
					nint num = (nint)GM.Core;
					if ((object)GM.Core != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v4 (Il2CppMethodInfo)+2A0]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v4 (Il2CppMethodInfo)+2A0]");
						if ((nint)0 != 0)
						{
							GameManager core2 = GM.Core;
							object obj2 = 0;
							List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
							if (enumerator.MoveNext())
							{
								object obj3 = 0;
								List<CharacterController>.Enumerator enumerator2 = (List<CharacterController>.Enumerator)(&enumerator);
								throw new NullReferenceException();
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v16+18]");
							float num2 = 0f - 1f;
							return (float)obj2 - num2;
						}
					}
					goto IL_0178;
				}
			}
			GameManager core3 = GM.Core;
			if ((object)GM.Core != null)
			{
				GameSessionData gameSessionData = core3._gameSessionData;
				if (core3._gameSessionData != null)
				{
					CharacterController activeCharacter = gameSessionData._activeCharacter;
					if ((object)gameSessionData._activeCharacter != null)
					{
						return activeCharacter.SvMult_Inve;
					}
				}
			}
		}
		goto IL_0178;
		IL_0178:
		throw new NullReferenceException();
	}

	public unsafe static float SvMult_Base()
	{
		//IL_0045: Expected I, but got O
		//IL_0073: Expected O, but got I
		//IL_00af: Expected O, but got I4
		//IL_00bd: Expected O, but got I4
		//IL_00c5: Expected O, but got Ref
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			if (core._mainCharacters != null)
			{
				List<CharacterController> mainCharacters = core._mainCharacters;
				if (mainCharacters._size > 1)
				{
					nint num = (nint)GM.Core;
					if ((object)GM.Core != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v4 (Il2CppMethodInfo)+2A0]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v4 (Il2CppMethodInfo)+2A0]");
						if ((nint)0 != 0)
						{
							GameManager core2 = GM.Core;
							object obj2 = 0;
							List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
							if (enumerator.MoveNext())
							{
								object obj3 = 0;
								List<CharacterController>.Enumerator enumerator2 = (List<CharacterController>.Enumerator)(&enumerator);
								throw new NullReferenceException();
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v16+18]");
							float num2 = 0f - 1f;
							return (float)obj2 - num2;
						}
					}
					goto IL_0178;
				}
			}
			GameManager core3 = GM.Core;
			if ((object)GM.Core != null)
			{
				GameSessionData gameSessionData = core3._gameSessionData;
				if (core3._gameSessionData != null)
				{
					CharacterController activeCharacter = gameSessionData._activeCharacter;
					if ((object)gameSessionData._activeCharacter != null)
					{
						return activeCharacter.SvMult_Base;
					}
				}
			}
		}
		goto IL_0178;
		IL_0178:
		throw new NullReferenceException();
	}

	public CharacterSkillCardsManager()
	{
		List<CharacterSkillCard_Base> characterCards = new List<CharacterSkillCard_Base>();
		_characterCards = characterCards;
	}
}
