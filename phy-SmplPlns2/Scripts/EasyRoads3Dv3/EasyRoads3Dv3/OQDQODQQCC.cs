using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	public class OQDQODQQCC : MonoBehaviour
	{
		public static void OODDQOQCCD(int el, ref List<int> OQCODQQCOO, ref List<Vector3> OOOQOOOODO, ref List<Vector3> OCCDOQDDOD, List<Vector2> OODQOODCOQ, List<Vector2> OCOCQQCDOQ, int[] OCQDQOCDCQ, int[] OCDCODCDQC, int[] ODCQQOQCCC, int[] ODCOCDCQDO, ref Vector3[] OODOOCCDQO, ref Vector2[] OQQOCCDCQO, ref int[] OOOOQOODCD, ref Vector3[] OQCDOCDOQQ, ref Vector3[] OOCOOQQDCO, ref Vector3[] OCCQCDCOCD, ref Vector3[] OCQCCCOOCO, int ODQCCQDCDC, bool OQQOOQCCDD, Vector3 OQCCCODDCD)
		{
			List<Vector2> list = new List<Vector2>();
			List<Vector2> list2 = new List<Vector2>();
			List<Vector2> list3 = new List<Vector2>();
			List<Vector2> list4 = new List<Vector2>();
			List<Vector3> list5 = new List<Vector3>();
			List<Vector3> list6 = new List<Vector3>();
			List<Vector3> list7 = new List<Vector3>();
			List<Vector3> list8 = new List<Vector3>();
			Vector3[] collection = OODOOCCDQO;
			List<Vector3> list9 = new List<Vector3>(collection);
			Vector2[] collection2 = OQQOCCDCQO;
			List<Vector2> list10 = new List<Vector2>(collection2);
			if (ODQCCQDCDC == 0)
			{
				OQCODQQCOO.Add(1);
				OQCODQQCOO.Add(0);
				OQCODQQCOO.Add(3);
				OQCODQQCOO.Add(3);
				OQCODQQCOO.Add(0);
				OQCODQQCOO.Add(4);
				OQCODQQCOO.Add(6);
				OQCODQQCOO.Add(7);
				OQCODQQCOO.Add(8);
				OQCODQQCOO.Add(6);
				OQCODQQCOO.Add(4);
				OQCODQQCOO.Add(7);
				int num = ODCQQOQCCC[el] - OCQDQOCDCQ[el];
				if (num > 1)
				{
					int count = list9.Count;
					list9.Add(OOOQOOOODO[OCQDQOCDCQ[el] + 1]);
					list10.Add(OODQOODCOQ[OCQDQOCDCQ[el] + 1]);
					OQCODQQCOO.Add(0);
					OQCODQQCOO.Add(count);
					OQCODQQCOO.Add(4);
					for (int i = 1; i < num - 1; i++)
					{
						list9.Add(OOOQOOOODO[OCQDQOCDCQ[el] + i + 1]);
						list10.Add(OCOCQQCDOQ[OCQDQOCDCQ[el] + i + 1]);
						OQCODQQCOO.Add(count + i - 1);
						OQCODQQCOO.Add(count + i);
						OQCODQQCOO.Add(4);
					}
					OQCODQQCOO.Add(count + num - 2);
					OQCODQQCOO.Add(7);
					OQCODQQCOO.Add(4);
				}
				else
				{
					OQCODQQCOO.Add(0);
					OQCODQQCOO.Add(7);
					OQCODQQCOO.Add(4);
				}
			}
			else
			{
				OQCODQQCOO.Add(2);
				OQCODQQCOO.Add(1);
				OQCODQQCOO.Add(0);
				OQCODQQCOO.Add(2);
				OQCODQQCOO.Add(4);
				OQCODQQCOO.Add(1);
				OQCODQQCOO.Add(5);
				OQCODQQCOO.Add(7);
				OQCODQQCOO.Add(8);
				OQCODQQCOO.Add(5);
				OQCODQQCOO.Add(8);
				OQCODQQCOO.Add(4);
				int num2 = ODCOCDCQDO[el] - OCDCODCDQC[el];
				if (num2 > 1)
				{
					int count2 = list9.Count;
					list9.Add(OCCDOQDDOD[OCDCODCDQC[el] + 1]);
					list10.Add(OCOCQQCDOQ[OCDCODCDQC[el] + 1]);
					OQCODQQCOO.Add(1);
					OQCODQQCOO.Add(4);
					OQCODQQCOO.Add(count2);
					for (int j = 1; j < num2 - 1; j++)
					{
						list9.Add(OCCDOQDDOD[OCDCODCDQC[el] + j + 1]);
						list10.Add(OCOCQQCDOQ[OCDCODCDQC[el] + j + 1]);
						OQCODQQCOO.Add(count2 + j - 1);
						OQCODQQCOO.Add(4);
						OQCODQQCOO.Add(count2 + j);
					}
					OQCODQQCOO.Add(count2 + num2 - 2);
					OQCODQQCOO.Add(4);
					OQCODQQCOO.Add(8);
				}
				else
				{
					OQCODQQCOO.Add(1);
					OQCODQQCOO.Add(4);
					OQCODQQCOO.Add(8);
				}
			}
			OODOOCCDQO = list9.ToArray();
			OQQOCCDCQO = list10.ToArray();
		}

		public static void OCOOQCQOQO(ref List<Vector3> OOQCOODQDO, ref List<Vector3> OQQQCQQCOC, ref List<Vector3> OCQQOCQQQD, ref List<Vector3> OOOQDCCCQD, List<Vector3> vecs, List<Vector3> OCDQDQQCCC, int start, int end, Vector3 OQCCCODDCD, string OQDQOQDOCO, bool OQQOOQCCDD, Vector3 OCQQCCCQOQ, Vector3 OCDOOQOOCO, ref List<Vector2> ODQOOOCDQO, ref List<Vector2> OCOQQDODOO, List<Vector2> UVs)
		{
		}

		public static void OQCQCDCOQQ(List<Vector2> OCOCQQCDOQ, Vector3 OQCCCODDCD, List<Vector3> OOCCDCODCC, List<Vector3> OQDQQDCOQO, List<Vector2> OCDOCDODOD, List<Vector2> OCODQCCQOD, int el, Vector3[] OQODCDCQDD, Vector3[] OQQOCQOQQO, Vector2[] OCDOQODDCC, Vector2[] OOOQOCCOQO, Vector3 OCCCOQCCQO, Vector3 OOCCOQDQOD, Vector2 OCCOCQCDCQ, Vector2 OOCQDQCQDO)
		{
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			List<int> list3 = new List<int>();
		}

		public static void OCDCOOOCCC(List<Vector2> OODQOODCOQ, Vector3 OQCCCODDCD, List<Vector3> OQODCDCQDD, List<Vector3> OQQOCQOQQO, List<Vector2> OCDOCDODOD, List<Vector2> OCODQCCQOD, int el, Vector3[] OOCCDCODCC, Vector3[] OQDQQDCOQO, Vector2[] ODQDDQDCCD, Vector2[] ODQQOQQODQ, Vector3 OQOQQDODOO, Vector3 OQOCDOQQOD, Vector2 OQOQQDODOOUV, Vector2 OQOCDOQQODUV)
		{
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			List<int> list3 = new List<int>();
		}

		public static void ODDDCOCCQO(int el, Vector3[] OQDOQQCOCQ, Vector2[] ODQOOOCDQO, Vector3[] OQODCDCQDD, Vector3[] OOCCDCODCC, Vector2[] OCDOQODDCC, Vector2[] ODQDDQDCCD, Vector3 OQCCCODDCD)
		{
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			List<int> list3 = new List<int>();
		}

		public static void OQQDCQOCQC(int el, Vector3[] OOQCQCOODD, Vector2[] OCOQQDODOO, Vector3[] OQQOCQOQQO, Vector3[] OQDQQDCOQO, Vector2[] OOOQOCCOQO, Vector2[] ODQQOQQODQ, Vector3 OQCCCODDCD)
		{
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			List<int> list3 = new List<int>();
		}
	}
}
