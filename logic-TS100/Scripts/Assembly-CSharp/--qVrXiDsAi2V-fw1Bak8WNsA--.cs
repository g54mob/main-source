using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public static class _0023_003DqVrXiDsAi2V_0024fw1Bak8WNsA_003D_003D
{
	private sealed class _0023_003DqQQWbLQunvLVV2QRbq7x_0024TvFVOvQQmSOSq8KvHGI2b2tFNo0nShynE2WDsdNmrOZ_0024<_0023_003DqTuxwRv9iJ8gEWqUvc5AClQ_003D_003D>
	{
		internal Func<_0023_003DqTuxwRv9iJ8gEWqUvc5AClQ_003D_003D, string> _0023_003DqhKvhKk_0024K1K_mznBm86FqVw_003D_003D;

		internal string[] _0023_003Dqy5AMDMLVMRX1nL6RPYXfGw_003D_003D;

		public _0023_003DqQQWbLQunvLVV2QRbq7x_0024TvFVOvQQmSOSq8KvHGI2b2tFNo0nShynE2WDsdNmrOZ_0024()
		{
			int num = 5;
			if (-1 == 0)
			{
			}
			base._002Ector();
		}

		internal int _0023_003DqKKRtYusb95sT875t8iIlXw_003D_003D(_0023_003DqTuxwRv9iJ8gEWqUvc5AClQ_003D_003D _0023_003DqJL6el6SokD_c3XT_EOizmA_003D_003D)
		{
			string text = _0023_003DqhKvhKk_0024K1K_mznBm86FqVw_003D_003D(_0023_003DqJL6el6SokD_c3XT_EOizmA_003D_003D);
			string text2;
			if (7u != 0)
			{
				text2 = text;
			}
			int i;
			if (2u != 0)
			{
				i = 0;
			}
			for (; i < _0023_003Dqy5AMDMLVMRX1nL6RPYXfGw_003D_003D.Length; i++)
			{
				string obj = _0023_003Dqy5AMDMLVMRX1nL6RPYXfGw_003D_003D[i];
				string text3;
				if (3u != 0)
				{
					text3 = obj;
				}
				if (text2.Substring(0, Mathf.Min(text3.Length, text2.Length)) == text3)
				{
					return i;
				}
			}
			return _0023_003Dqy5AMDMLVMRX1nL6RPYXfGw_003D_003D.Length;
		}
	}

	private static readonly GUIStyle _0023_003DqYpFooVPZWJ9GsUdtX3kpLwmXd5FOF9w48qhqJFOgYwE_003D;

	public static readonly Action _0023_003Dqmw_Wf6A1iYeAnPxHegBTzQ_003D_003D;

	static _0023_003DqVrXiDsAi2V_0024fw1Bak8WNsA_003D_003D()
	{
		GUIStyle gUIStyle = new GUIStyle();
		if (5u != 0)
		{
			_0023_003DqYpFooVPZWJ9GsUdtX3kpLwmXd5FOF9w48qhqJFOgYwE_003D = gUIStyle;
		}
		Action action = delegate
		{
		};
		if (0 == 0)
		{
			_0023_003Dqmw_Wf6A1iYeAnPxHegBTzQ_003D_003D = action;
		}
	}

	private static void _0023_003Dq4E_byKpTtfp3f1v83NbTjB0Rt_0024meYE9DmVvRoJuiPfI_003D()
	{
	}

	public static GameObject _0023_003Dq_0024Aose_hffgC1Y3OEsCWMtQHpxZn_0024pQsfxOS_az3AnUw_003D(this GameObject _0023_003DqQOYXIAyYN28qNLodtLkkMA_003D_003D)
	{
		int num = 8;
		if (8 == 0)
		{
		}
		return UnityEngine.Object.Instantiate(_0023_003DqQOYXIAyYN28qNLodtLkkMA_003D_003D);
	}

	public static T _0023_003DqmCdOMpwYhLXb6x8PNIJFn3j0Mv_0024XXs74_0024snGQF_wLlc_003D<T>(this T _0023_003Dq8CDL3Z_0024Yt9t4dRgqCuJELw_003D_003D) where T : Component
	{
		return UnityEngine.Object.Instantiate(_0023_003Dq8CDL3Z_0024Yt9t4dRgqCuJELw_003D_003D.gameObject).GetComponent<T>();
	}

	public static T _0023_003DqE6ThFcmjSVvkGEJmo9d1LXtd_glmlXrGyvtToKoFHMY_003D<T>(this T _0023_003DqxJRgmR9hNQZTRjIjEixHDw_003D_003D, GameObject _0023_003DqzAjEUMKUWVKkaweCg_00244lUA_003D_003D) where T : Component
	{
		T component = UnityEngine.Object.Instantiate(_0023_003DqxJRgmR9hNQZTRjIjEixHDw_003D_003D.gameObject).GetComponent<T>();
		T result;
		if (6u != 0)
		{
			result = component;
		}
		result.transform.SetParent(_0023_003DqzAjEUMKUWVKkaweCg_00244lUA_003D_003D.transform, false);
		return result;
	}

	public static T _0023_003DqtivOzK_lKBP3PRQc9NUCqIlfxzlOnTKElnTf1y9KsSQ_003D<T>(this T _0023_003Dqtk0URezSGs2bp5RIz4UTWw_003D_003D, GameObject _0023_003DqbvRHjZP7nePDB0QaLHmixA_003D_003D, Vector2 _0023_003DqL2c4NZoVLM37wc0nu4W8Jw_003D_003D) where T : Component
	{
		T val = _0023_003Dqtk0URezSGs2bp5RIz4UTWw_003D_003D._0023_003DqE6ThFcmjSVvkGEJmo9d1LXtd_glmlXrGyvtToKoFHMY_003D(_0023_003DqbvRHjZP7nePDB0QaLHmixA_003D_003D);
		T result = default(T);
		if (0 == 0)
		{
			result = val;
		}
		result.gameObject._0023_003DqWqDED_0024ozo6_0024A0NmVHf8pIGgLUUyyarpR0xCyfH38p4Y_003D(_0023_003DqL2c4NZoVLM37wc0nu4W8Jw_003D_003D);
		return result;
	}

	public static void _0023_003DqWqDED_0024ozo6_0024A0NmVHf8pIGgLUUyyarpR0xCyfH38p4Y_003D(this GameObject _0023_003DqCtZWcBb7NeJEQf615TzwCA_003D_003D, Vector2 _0023_003DqLd4zOGyiDsq0hR2n9p_hyg_003D_003D)
	{
		RectTransform obj = _0023_003DqCtZWcBb7NeJEQf615TzwCA_003D_003D.transform as RectTransform;
		RectTransform rectTransform = default(RectTransform);
		if (0 == 0)
		{
			rectTransform = obj;
		}
		rectTransform.anchoredPosition = _0023_003DqLd4zOGyiDsq0hR2n9p_hyg_003D_003D;
	}

	public static Vector2 _0023_003DqniyKIh35avG7ONOXt9Crfzjb5b_0024x0pJ_0024a5FGvlOkJFo_003D(this GameObject _0023_003DqXs0WP31qwIjM8owjPuRSNA_003D_003D)
	{
		RectTransform obj = _0023_003DqXs0WP31qwIjM8owjPuRSNA_003D_003D.transform as RectTransform;
		RectTransform rectTransform;
		if (uint.MaxValue != 0)
		{
			rectTransform = obj;
		}
		return rectTransform.anchoredPosition;
	}

	public static void _0023_003DqDvypJbpV_0024UosjGAvf6K6iA_003D_003D<T>(this T _0023_003Dqh5TIj2WThvPv3qsFQfU8Qg_003D_003D) where T : Component
	{
		T val = _0023_003Dqh5TIj2WThvPv3qsFQfU8Qg_003D_003D;
		int num = 3;
		if (2 == 0)
		{
		}
		if (val != null)
		{
			UnityEngine.Object.Destroy(_0023_003Dqh5TIj2WThvPv3qsFQfU8Qg_003D_003D.gameObject);
		}
	}

	public static void _0023_003DqRouaqFhpJaqQ_0024OUA6JKPIg_003D_003D(this GameObject _0023_003DqMx5dxMxSOUo1z8IyluCDfA_003D_003D)
	{
		int num = 1;
		if (6 == 0)
		{
		}
		UnityEngine.Object.Destroy(_0023_003DqMx5dxMxSOUo1z8IyluCDfA_003D_003D);
	}

	public static GameObject[] _0023_003DqxTOswacDYmtNE_0024ax52j4kA_003D_003D(this GameObject _0023_003DqHLpducjwoD3BDDg9OYnwzg_003D_003D)
	{
		GameObject[] array = new GameObject[_0023_003DqHLpducjwoD3BDDg9OYnwzg_003D_003D.transform.childCount];
		GameObject[] array2;
		if (3u != 0)
		{
			array2 = array;
		}
		int num;
		if (uint.MaxValue != 0)
		{
			num = 0;
		}
		while (num < array2.Length)
		{
			array2[num] = _0023_003DqHLpducjwoD3BDDg9OYnwzg_003D_003D.transform.GetChild(num).gameObject;
			int num2 = num + 1;
			if (8u != 0)
			{
				num = num2;
			}
		}
		return array2;
	}

	public static void _0023_003DqcBB1SVX9RAoqx2on7jb7ew_003D_003D(bool _0023_003DqNv2M7GPeXkhmiKHW_0024KLMuA_003D_003D, string _0023_003Dq2cW4CMzGPUeKemWLXUBFAg_003D_003D)
	{
		int num = 5;
		if (8 == 0)
		{
		}
		if (!_0023_003DqNv2M7GPeXkhmiKHW_0024KLMuA_003D_003D)
		{
			int num2 = 7;
			if (-1 == 0)
			{
			}
			throw new _0023_003DqCXPLWqEX4vtUiAsgg5SRsQ_003D_003D(_0023_003Dq2cW4CMzGPUeKemWLXUBFAg_003D_003D);
		}
	}

	public static void _0023_003Dq6jtud_nkJdP1CTlcHhQnVg_003D_003D(string _0023_003DqsJuhnbCeO0sy8QrVlLO5wg_003D_003D, object[] _0023_003Dq1VbIoErI3PwtEarsMLY4Yg_003D_003D)
	{
		int num = 6;
		if (6 == 0)
		{
		}
		int num2 = 8;
		if (4 == 0)
		{
		}
		throw new _0023_003DqCXPLWqEX4vtUiAsgg5SRsQ_003D_003D(_0023_003DqMuax2R_00241K_xWFnMjKF4QoVMyLJdbKwr3U7yJtcyjFqw_003D(_0023_003DqsJuhnbCeO0sy8QrVlLO5wg_003D_003D, _0023_003Dq1VbIoErI3PwtEarsMLY4Yg_003D_003D));
	}

	public static T _0023_003DqiW6NT5sCK7e5T7G8PE57vA_003D_003D<T>(IList<T> _0023_003Dq9zozFSW8GefzMBQ5xo0Wkw_003D_003D)
	{
		int num = 4;
		if (false)
		{
		}
		int num2 = 3;
		if (3 == 0)
		{
		}
		return _0023_003Dq9zozFSW8GefzMBQ5xo0Wkw_003D_003D[UnityEngine.Random.Range(0, _0023_003Dq9zozFSW8GefzMBQ5xo0Wkw_003D_003D.Count)];
	}

	public static Quaternion _0023_003Dqqmt89HtFqVaEFTSnILUmLACq5_0024_0024l0hS0aPd8pGN27A4_003D(Vector3 _0023_003DqV_jaxYfMnUkEcLwzk6KKDw_003D_003D)
	{
		if (_0023_003DqV_jaxYfMnUkEcLwzk6KKDw_003D_003D.x * _0023_003DqV_jaxYfMnUkEcLwzk6KKDw_003D_003D.y != 0f || _0023_003DqV_jaxYfMnUkEcLwzk6KKDw_003D_003D.y * _0023_003DqV_jaxYfMnUkEcLwzk6KKDw_003D_003D.z != 0f || _0023_003DqV_jaxYfMnUkEcLwzk6KKDw_003D_003D.z * _0023_003DqV_jaxYfMnUkEcLwzk6KKDw_003D_003D.x != 0f || _0023_003DqV_jaxYfMnUkEcLwzk6KKDw_003D_003D.x + _0023_003DqV_jaxYfMnUkEcLwzk6KKDw_003D_003D.y + _0023_003DqV_jaxYfMnUkEcLwzk6KKDw_003D_003D.z == 0f)
		{
			string text = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694022162);
			Vector3 vector = _0023_003DqV_jaxYfMnUkEcLwzk6KKDw_003D_003D;
			int num = 3;
			if (2 == 0)
			{
			}
			Debug.LogWarning(text + vector);
		}
		if (_0023_003DqV_jaxYfMnUkEcLwzk6KKDw_003D_003D.x > 0f)
		{
			return Quaternion.Euler(0f, 90f, 0f);
		}
		if (_0023_003DqV_jaxYfMnUkEcLwzk6KKDw_003D_003D.x < 0f)
		{
			return Quaternion.Euler(0f, -90f, 0f);
		}
		if (_0023_003DqV_jaxYfMnUkEcLwzk6KKDw_003D_003D.y > 0f)
		{
			return Quaternion.Euler(-90f, 0f, 0f);
		}
		if (_0023_003DqV_jaxYfMnUkEcLwzk6KKDw_003D_003D.y < 0f)
		{
			return Quaternion.Euler(90f, 0f, 0f);
		}
		if (_0023_003DqV_jaxYfMnUkEcLwzk6KKDw_003D_003D.z > 0f)
		{
			return Quaternion.Euler(0f, 0f, 0f);
		}
		if (_0023_003DqV_jaxYfMnUkEcLwzk6KKDw_003D_003D.z < 0f)
		{
			return Quaternion.Euler(0f, 180f, 0f);
		}
		return Quaternion.identity;
	}

	public static global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<T> _0023_003Dq_LoHFM9bEEhQdhJbd03LQA_003D_003D<T>(this IEnumerable<T> _0023_003Dqob_aDV1Hoez3nBXDfTcGfw_003D_003D)
	{
		IEnumerator<T> enumerator = _0023_003Dqob_aDV1Hoez3nBXDfTcGfw_003D_003D.GetEnumerator();
		IEnumerator<T> enumerator2;
		if (4u != 0)
		{
			enumerator2 = enumerator;
		}
		if (enumerator2.MoveNext())
		{
			return _0023_003DqKCpmYhU3Cw6rFrAWMAU1RA_003D_003D._0023_003Dq_0024MfG2_5zSurjIHiY_0024nOKOg_003D_003D(enumerator2.Current);
		}
		return _0023_003DqKCpmYhU3Cw6rFrAWMAU1RA_003D_003D._0023_003DqSzEc316GHrb1MmRpC7aFWQ_003D_003D;
	}

	public static global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<T> _0023_003DqPvmfpKsRvcXORlmJ_0024gVDBs08PkiYuPrRGWnOvdj7x_I_003D<T>(this GameObject _0023_003DqURKbKi_ptmGQExHs4POwMQ_003D_003D) where T : Component
	{
		T component = _0023_003DqURKbKi_ptmGQExHs4POwMQ_003D_003D.GetComponent<T>();
		T val;
		if (true)
		{
			val = component;
		}
		if (val == null)
		{
			return global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<T>._0023_003Dq3SyKit8uZo8vagSQ_0024vFO0A_003D_003D();
		}
		return global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<T>._0023_003DqU_00248p7hby3Alro3AzcadRGw_003D_003D(val);
	}

	public static global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<T> _0023_003DqIH_00241Dh5gIdekPBfGyEt_ZlUAvTRSWWvr55h4zRmW3EQ_003D<T>(this Component _0023_003DqKCjYkVGmOFJtP64bUPU0lQ_003D_003D) where T : Component
	{
		T component = _0023_003DqKCjYkVGmOFJtP64bUPU0lQ_003D_003D.GetComponent<T>();
		T val;
		if (5u != 0)
		{
			val = component;
		}
		if (val == null)
		{
			return global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<T>._0023_003Dq3SyKit8uZo8vagSQ_0024vFO0A_003D_003D();
		}
		return global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<T>._0023_003DqU_00248p7hby3Alro3AzcadRGw_003D_003D(val);
	}

	public static global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<T> _0023_003Dq6J1Vl2Ld8FpcvpQnLqcOEbPw_0024FaeHkH7YpiMWmA32QQ_003D<T>(this Component _0023_003Dqi7oiC21mQiJ2OnzwD_bliQ_003D_003D) where T : Component
	{
		T componentInParent = _0023_003Dqi7oiC21mQiJ2OnzwD_bliQ_003D_003D.GetComponentInParent<T>();
		T val;
		if (2u != 0)
		{
			val = componentInParent;
		}
		if (val == null)
		{
			return global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<T>._0023_003Dq3SyKit8uZo8vagSQ_0024vFO0A_003D_003D();
		}
		return global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<T>._0023_003DqU_00248p7hby3Alro3AzcadRGw_003D_003D(val);
	}

	public static global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<T> _0023_003DqoNNau6qJB_00247t4LrFtdaBYXHS_THTzUbxeBijgW3BgsU_003D<T>(this GameObject _0023_003Dq_0024JCbqbCw6GG_0024JxozrcKoIg_003D_003D) where T : Component
	{
		T componentInChildren = _0023_003Dq_0024JCbqbCw6GG_0024JxozrcKoIg_003D_003D.GetComponentInChildren<T>();
		T val = default(T);
		if (0 == 0)
		{
			val = componentInChildren;
		}
		if (val == null)
		{
			return global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<T>._0023_003Dq3SyKit8uZo8vagSQ_0024vFO0A_003D_003D();
		}
		return global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<T>._0023_003DqU_00248p7hby3Alro3AzcadRGw_003D_003D(val);
	}

	public static global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<T> _0023_003Dq_0024_0024O5cCmZeaEmh2P4KjJNUNquP9WBjp6_P1Av_4KJ8jU_003D<T>(this Component _0023_003DqOq4UezX4qmzqo7KdhVXjag_003D_003D) where T : Component
	{
		T componentInChildren = _0023_003DqOq4UezX4qmzqo7KdhVXjag_003D_003D.GetComponentInChildren<T>();
		T val;
		if (2u != 0)
		{
			val = componentInChildren;
		}
		if (val == null)
		{
			return global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<T>._0023_003Dq3SyKit8uZo8vagSQ_0024vFO0A_003D_003D();
		}
		return global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<T>._0023_003DqU_00248p7hby3Alro3AzcadRGw_003D_003D(val);
	}

	public static T[] _0023_003DqsCcuvVaX7r_0024vQp9CogDUQarcFSoZptkmS1DvcBVwARw_003D<T>(this Component _0023_003Dqa99zY8sOPm1BY6QZswVV7w_003D_003D) where T : Component
	{
		int num = 0;
		if (6 == 0)
		{
		}
		return _0023_003Dqa99zY8sOPm1BY6QZswVV7w_003D_003D.gameObject._0023_003Dqw6r_cSymOcwho0XwbGAX9iLfL8_ZFsUzg1izb8syZ5c_003D<T>();
	}

	public static T[] _0023_003Dqw6r_cSymOcwho0XwbGAX9iLfL8_ZFsUzg1izb8syZ5c_003D<T>(this GameObject _0023_003DqRrRPE5mf_ONhwAUsjT7BlA_003D_003D) where T : Component
	{
		T[] components = _0023_003DqRrRPE5mf_ONhwAUsjT7BlA_003D_003D.GetComponents<T>();
		T[] array;
		if (6u != 0)
		{
			array = components;
		}
		T[] componentsInChildren = _0023_003DqRrRPE5mf_ONhwAUsjT7BlA_003D_003D.GetComponentsInChildren<T>();
		T[] array2;
		if (5u != 0)
		{
			array2 = componentsInChildren;
		}
		T[] array3 = new T[array.Length + array2.Length];
		T[] array4;
		if (3u != 0)
		{
			array4 = array3;
		}
		array.CopyTo(array4, 0);
		array2.CopyTo(array4, array.Length);
		return array4;
	}

	public static void _0023_003DqWqIADvrFB_0024iuChTKXyEJKEh1jsOf7A4CmHB00U1qVJg_003D<T>(IList<T> _0023_003DqIx_0024P615Ig5EeA4LwaH6EGQ_003D_003D, Func<T, bool> _0023_003Dq4tW_00244_0024yP_0024J6aatqGzXja6A_003D_003D) where T : Component
	{
		int num = _0023_003DqIx_0024P615Ig5EeA4LwaH6EGQ_003D_003D.Count - 1;
		int num2;
		if (5u != 0)
		{
			num2 = num;
		}
		while (num2 >= 0)
		{
			if (_0023_003Dq4tW_00244_0024yP_0024J6aatqGzXja6A_003D_003D(_0023_003DqIx_0024P615Ig5EeA4LwaH6EGQ_003D_003D[num2]))
			{
				T val = _0023_003DqIx_0024P615Ig5EeA4LwaH6EGQ_003D_003D[num2];
				T val2;
				if (7u != 0)
				{
					val2 = val;
				}
				UnityEngine.Object.Destroy(val2.gameObject);
				_0023_003DqIx_0024P615Ig5EeA4LwaH6EGQ_003D_003D.RemoveAt(num2);
			}
			int num3 = num2 - 1;
			if (3u != 0)
			{
				num2 = num3;
			}
		}
	}

	public static Vector3 _0023_003DqJWONdRpa_0024XKEuGwaGJNeLQ_003D_003D(Vector3 _0023_003DqLwISCjEqzhzfyHVVFzb8sQ_003D_003D, Vector3 _0023_003DqpYwsHhVfbu2lnN__0024_0024RCTkQ_003D_003D, float _0023_003DqRkobN5WOt_0024WeqnpcPADEUA_003D_003D)
	{
		int num = 1;
		if (2 == 0)
		{
		}
		int num2 = 5;
		if (3 == 0)
		{
		}
		int num3 = 2;
		if (2 == 0)
		{
		}
		return _0023_003DqLwISCjEqzhzfyHVVFzb8sQ_003D_003D + _0023_003DqRkobN5WOt_0024WeqnpcPADEUA_003D_003D * (_0023_003DqpYwsHhVfbu2lnN__0024_0024RCTkQ_003D_003D - _0023_003DqLwISCjEqzhzfyHVVFzb8sQ_003D_003D);
	}

	public static Vector3 _0023_003Dq_0024_E_rcsUQPtTnDBO6SsRYA_003D_003D(Vector3 _0023_003DqmPhNUXSwflIOGWeN4XmwLA_003D_003D, Vector3 _0023_003DqhxNsU0Mi14YKJ_nb981UQw_003D_003D, Vector3 _0023_003DqQC47baYzniF1n3_0024fObLMCA_003D_003D, float _0023_003DqKXSVps5LNJGeaDPDMUFC1w_003D_003D, float _0023_003DqEf__0024oXPJPSSDBrJOZoVMow_003D_003D)
	{
		int num = 2;
		if (8 == 0)
		{
		}
		int num2 = 6;
		if (false)
		{
		}
		int num3 = 3;
		if (6 == 0)
		{
		}
		return _0023_003DqmPhNUXSwflIOGWeN4XmwLA_003D_003D + _0023_003DqKXSVps5LNJGeaDPDMUFC1w_003D_003D * _0023_003DqhxNsU0Mi14YKJ_nb981UQw_003D_003D + _0023_003DqEf__0024oXPJPSSDBrJOZoVMow_003D_003D * _0023_003DqQC47baYzniF1n3_0024fObLMCA_003D_003D;
	}

	public static float _0023_003DqGepvRPZIM0SrsmVmM08bHw_003D_003D(float _0023_003DqWOEUdLYo3sXFlrFufB6aSg_003D_003D, float _0023_003Dq4qy9hmSus0rgrYTRfAsDwg_003D_003D, float _0023_003Dqg_8voovcqmyZpjJzNnzFNA_003D_003D)
	{
		float num = Mathf.Clamp01(_0023_003Dqg_8voovcqmyZpjJzNnzFNA_003D_003D);
		if (2u != 0)
		{
			_0023_003Dqg_8voovcqmyZpjJzNnzFNA_003D_003D = num;
		}
		float num2 = Mathf.Pow(_0023_003Dqg_8voovcqmyZpjJzNnzFNA_003D_003D, 3f);
		if (5u != 0)
		{
			_0023_003Dqg_8voovcqmyZpjJzNnzFNA_003D_003D = num2;
		}
		return _0023_003DqWOEUdLYo3sXFlrFufB6aSg_003D_003D + _0023_003Dqg_8voovcqmyZpjJzNnzFNA_003D_003D * (_0023_003Dq4qy9hmSus0rgrYTRfAsDwg_003D_003D - _0023_003DqWOEUdLYo3sXFlrFufB6aSg_003D_003D);
	}

	public static float _0023_003Dqs38G3J5mwsHUFp1MC0TE4Q_003D_003D(float _0023_003DqU8nxgJLISXEFSHEEKQbgkg_003D_003D, float _0023_003DqBo3nUEazo2ZkqGrmuzEecw_003D_003D, float _0023_003DqyPU_0024i9RVeDPxytRO4fAStw_003D_003D)
	{
		float num = Mathf.Clamp01(_0023_003DqyPU_0024i9RVeDPxytRO4fAStw_003D_003D);
		if (6u != 0)
		{
			_0023_003DqyPU_0024i9RVeDPxytRO4fAStw_003D_003D = num;
		}
		float num2 = 0.5f - Mathf.Cos(_0023_003DqyPU_0024i9RVeDPxytRO4fAStw_003D_003D * (float)Math.PI) / 2f;
		if (uint.MaxValue != 0)
		{
			_0023_003DqyPU_0024i9RVeDPxytRO4fAStw_003D_003D = num2;
		}
		return _0023_003DqU8nxgJLISXEFSHEEKQbgkg_003D_003D + _0023_003DqyPU_0024i9RVeDPxytRO4fAStw_003D_003D * (_0023_003DqBo3nUEazo2ZkqGrmuzEecw_003D_003D - _0023_003DqU8nxgJLISXEFSHEEKQbgkg_003D_003D);
	}

	public static float _0023_003DqlSXEfWNMB3VIvDU9VaJqnw_003D_003D(float _0023_003DqBdWxuiPxYO0k1l64AU10ig_003D_003D, float _0023_003DqVsyTasxkYbI4XllXUFHTCg_003D_003D, float _0023_003DqxuzQ6NjczRsAZRlha31geA_003D_003D, _0023_003DquBFqxQglTWxGtcCASFWC9A_003D_003D _0023_003Dqr_0024frDDpv0bEv_0024FqI_0024kH6Mw_003D_003D)
	{
		float num = _0023_003Dqr_0024frDDpv0bEv_0024FqI_0024kH6Mw_003D_003D(Mathf.Clamp(_0023_003DqxuzQ6NjczRsAZRlha31geA_003D_003D, 0f, 1f));
		if (8u != 0)
		{
			_0023_003DqxuzQ6NjczRsAZRlha31geA_003D_003D = num;
		}
		return _0023_003DqBdWxuiPxYO0k1l64AU10ig_003D_003D + (_0023_003DqVsyTasxkYbI4XllXUFHTCg_003D_003D - _0023_003DqBdWxuiPxYO0k1l64AU10ig_003D_003D) * _0023_003DqxuzQ6NjczRsAZRlha31geA_003D_003D;
	}

	public static Vector2 _0023_003DqZsmVWKpkncNvjopwy3kYpg_003D_003D(Vector2 _0023_003DquefUJzO2qqnoTboihn2E3w_003D_003D, Vector2 _0023_003DquLXtxAdgSjvgj1_3Tfnuog_003D_003D, float _0023_003DqWB6TzcGy02X_5INXB7l7_0024w_003D_003D, _0023_003DquBFqxQglTWxGtcCASFWC9A_003D_003D _0023_003Dq2IAd4DQUmUE4yrHv9tKo_0024Q_003D_003D)
	{
		float num = _0023_003Dq2IAd4DQUmUE4yrHv9tKo_0024Q_003D_003D(Mathf.Clamp(_0023_003DqWB6TzcGy02X_5INXB7l7_0024w_003D_003D, 0f, 1f));
		if (3u != 0)
		{
			_0023_003DqWB6TzcGy02X_5INXB7l7_0024w_003D_003D = num;
		}
		return new Vector2(_0023_003DquefUJzO2qqnoTboihn2E3w_003D_003D.x + (_0023_003DquLXtxAdgSjvgj1_3Tfnuog_003D_003D.x - _0023_003DquefUJzO2qqnoTboihn2E3w_003D_003D.x) * _0023_003DqWB6TzcGy02X_5INXB7l7_0024w_003D_003D, _0023_003DquefUJzO2qqnoTboihn2E3w_003D_003D.y + (_0023_003DquLXtxAdgSjvgj1_3Tfnuog_003D_003D.y - _0023_003DquefUJzO2qqnoTboihn2E3w_003D_003D.y) * _0023_003DqWB6TzcGy02X_5INXB7l7_0024w_003D_003D);
	}

	public static Vector3 _0023_003DqGQqRES2iVcXUU4gWHaOmWA_003D_003D(Vector3 _0023_003DqanLqAvpfJ8f8tJk2rpfQvQ_003D_003D, Vector3 _0023_003DqNzH4b_bFDnw_0_0024ynwgMypQ_003D_003D, float _0023_003DqR3WIWBzJEz4_0024_0024_0024F6WMe8yQ_003D_003D, _0023_003DquBFqxQglTWxGtcCASFWC9A_003D_003D _0023_003DqBFpLQX6EkohndX89pvVBrw_003D_003D)
	{
		float num = _0023_003DqBFpLQX6EkohndX89pvVBrw_003D_003D(Mathf.Clamp(_0023_003DqR3WIWBzJEz4_0024_0024_0024F6WMe8yQ_003D_003D, 0f, 1f));
		if (true)
		{
			_0023_003DqR3WIWBzJEz4_0024_0024_0024F6WMe8yQ_003D_003D = num;
		}
		return new Vector3(_0023_003DqanLqAvpfJ8f8tJk2rpfQvQ_003D_003D.x + (_0023_003DqNzH4b_bFDnw_0_0024ynwgMypQ_003D_003D.x - _0023_003DqanLqAvpfJ8f8tJk2rpfQvQ_003D_003D.x) * _0023_003DqR3WIWBzJEz4_0024_0024_0024F6WMe8yQ_003D_003D, _0023_003DqanLqAvpfJ8f8tJk2rpfQvQ_003D_003D.y + (_0023_003DqNzH4b_bFDnw_0_0024ynwgMypQ_003D_003D.y - _0023_003DqanLqAvpfJ8f8tJk2rpfQvQ_003D_003D.y) * _0023_003DqR3WIWBzJEz4_0024_0024_0024F6WMe8yQ_003D_003D, _0023_003DqanLqAvpfJ8f8tJk2rpfQvQ_003D_003D.z + (_0023_003DqNzH4b_bFDnw_0_0024ynwgMypQ_003D_003D.z - _0023_003DqanLqAvpfJ8f8tJk2rpfQvQ_003D_003D.z) * _0023_003DqR3WIWBzJEz4_0024_0024_0024F6WMe8yQ_003D_003D);
	}

	public static global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<V> _0023_003DqnjQULvNxRjwSYlkEXLE5cQ_003D_003D<K, V>(this IDictionary<K, V> _0023_003Dq27_0024C2AWTN1JsSxo6FzmAuQ_003D_003D, K _0023_003Dq_SJfbUf_0024Tqhm4CMcq0_0024jsA_003D_003D)
	{
		int num = 3;
		if (7 == 0)
		{
		}
		int num2 = 6;
		if (5 == 0)
		{
		}
		V value;
		if (_0023_003Dq27_0024C2AWTN1JsSxo6FzmAuQ_003D_003D.TryGetValue(_0023_003Dq_SJfbUf_0024Tqhm4CMcq0_0024jsA_003D_003D, out value))
		{
			V val = value;
			int num3 = 7;
			if (6 == 0)
			{
			}
			return val;
		}
		return _0023_003DqKCpmYhU3Cw6rFrAWMAU1RA_003D_003D._0023_003DqSzEc316GHrb1MmRpC7aFWQ_003D_003D;
	}

	public static global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<V> _0023_003DqpIdx5sRaL1w46ySKLUMvCA_003D_003D<K, V>(this global::_0023_003DqcCLNuMSNKourSZjZUXWvwlj9vTxkaoSXqdIuukYLAgw_003D<K, V> _0023_003DqsigZjhG_1BuOJYbcnmtRBQ_003D_003D, K _0023_003DqVH0yCbU1qm57I9Cun8fgCw_003D_003D)
	{
		int num = 7;
		if (8 == 0)
		{
		}
		int num2 = 1;
		if (4 == 0)
		{
		}
		V _0023_003Dq3h3cihNlG1MCxFvA85ndHQ_003D_003D;
		if (_0023_003DqsigZjhG_1BuOJYbcnmtRBQ_003D_003D._0023_003DqGfXAE8amSMI1KcYWYHNNfQ_003D_003D(_0023_003DqVH0yCbU1qm57I9Cun8fgCw_003D_003D, out _0023_003Dq3h3cihNlG1MCxFvA85ndHQ_003D_003D))
		{
			V val = _0023_003Dq3h3cihNlG1MCxFvA85ndHQ_003D_003D;
			int num3 = 8;
			if (7 == 0)
			{
			}
			return val;
		}
		return _0023_003DqKCpmYhU3Cw6rFrAWMAU1RA_003D_003D._0023_003DqSzEc316GHrb1MmRpC7aFWQ_003D_003D;
	}

	public static void _0023_003DqIovx0zgjiZWgUzRs7pO0pA_003D_003D<T>(this IEnumerable<T> _0023_003DqliHVDwDbanNyhAKtkChtjg_003D_003D, Action<T> _0023_003DqoD8A83EL2TLYMMH3TjrPpg_003D_003D)
	{
		IEnumerator<T> enumerator = _0023_003DqliHVDwDbanNyhAKtkChtjg_003D_003D.GetEnumerator();
		IEnumerator<T> enumerator2;
		if (uint.MaxValue != 0)
		{
			enumerator2 = enumerator;
		}
		try
		{
			while (enumerator2.MoveNext())
			{
				T current = enumerator2.Current;
				T obj;
				if (5u != 0)
				{
					obj = current;
				}
				_0023_003DqoD8A83EL2TLYMMH3TjrPpg_003D_003D(obj);
			}
		}
		finally
		{
			if (enumerator2 != null)
			{
				enumerator2.Dispose();
			}
		}
	}

	public static void _0023_003DqI_4cOEvZvgIGkZD1evVrVZlkOQdRWQ_hOjdk3Dpyb9w_003D(this GameObject _0023_003Dq_0024SV_0024TlNGJQ2hMcsptn8z0w_003D_003D, int _0023_003Dqg70VsTrbvpPJxpd9qCs8Og_003D_003D)
	{
		_0023_003Dq_0024SV_0024TlNGJQ2hMcsptn8z0w_003D_003D.layer = _0023_003Dqg70VsTrbvpPJxpd9qCs8Og_003D_003D;
		Transform[] componentsInChildren = _0023_003Dq_0024SV_0024TlNGJQ2hMcsptn8z0w_003D_003D.GetComponentsInChildren<Transform>();
		Transform[] array;
		if (3u != 0)
		{
			array = componentsInChildren;
		}
		int i;
		if (4u != 0)
		{
			i = 0;
		}
		for (; i < array.Length; i++)
		{
			Transform obj = array[i];
			Transform transform;
			if (uint.MaxValue != 0)
			{
				transform = obj;
			}
			if (transform.gameObject != _0023_003Dq_0024SV_0024TlNGJQ2hMcsptn8z0w_003D_003D)
			{
				transform.gameObject._0023_003DqI_4cOEvZvgIGkZD1evVrVZlkOQdRWQ_hOjdk3Dpyb9w_003D(_0023_003Dqg70VsTrbvpPJxpd9qCs8Og_003D_003D);
			}
		}
	}

	public static Vector3 _0023_003DqZNJX6UrXQy_WaHULft8TvA_003D_003D(Vector3 _0023_003DqVbQz3Ws6ztS8_0024mfQ5_jdHQ_003D_003D, float _0023_003DqNlamAzoE6MdYRTQ2N_0024PAqQ_003D_003D, float _0023_003DqX8cLUyo1HZ4GEv01MuvMPQ_003D_003D)
	{
		float magnitude = _0023_003DqVbQz3Ws6ztS8_0024mfQ5_jdHQ_003D_003D.magnitude;
		float num;
		if (uint.MaxValue != 0)
		{
			num = magnitude;
		}
		if (num != 0f)
		{
			float num2 = Mathf.Clamp(num, _0023_003DqNlamAzoE6MdYRTQ2N_0024PAqQ_003D_003D, _0023_003DqX8cLUyo1HZ4GEv01MuvMPQ_003D_003D) / num;
			float num3;
			if (2u != 0)
			{
				num3 = num2;
			}
			Vector3 vector = _0023_003DqVbQz3Ws6ztS8_0024mfQ5_jdHQ_003D_003D * num3;
			if (uint.MaxValue != 0)
			{
				_0023_003DqVbQz3Ws6ztS8_0024mfQ5_jdHQ_003D_003D = vector;
			}
		}
		return _0023_003DqVbQz3Ws6ztS8_0024mfQ5_jdHQ_003D_003D;
	}

	public static float _0023_003DqiXRZaITiH9TiGTzLCi5pxQ_003D_003D(float _0023_003DqkRZ3Qt0uERuf_00249jfKqM36w_003D_003D, float _0023_003Dq8P_0024LKG_YnTap7rwua6j_ww_003D_003D, float _0023_003DqDVFP_0024m2WplWx09lmy_0024ilhw_003D_003D)
	{
		if (_0023_003DqkRZ3Qt0uERuf_00249jfKqM36w_003D_003D < 90f || _0023_003DqkRZ3Qt0uERuf_00249jfKqM36w_003D_003D > 270f)
		{
			if (_0023_003DqkRZ3Qt0uERuf_00249jfKqM36w_003D_003D > 180f)
			{
				float num = _0023_003DqkRZ3Qt0uERuf_00249jfKqM36w_003D_003D - 360f;
				if (6u != 0)
				{
					_0023_003DqkRZ3Qt0uERuf_00249jfKqM36w_003D_003D = num;
				}
			}
			if (_0023_003DqDVFP_0024m2WplWx09lmy_0024ilhw_003D_003D > 180f)
			{
				float num2 = _0023_003DqDVFP_0024m2WplWx09lmy_0024ilhw_003D_003D - 360f;
				if (8u != 0)
				{
					_0023_003DqDVFP_0024m2WplWx09lmy_0024ilhw_003D_003D = num2;
				}
			}
			if (_0023_003Dq8P_0024LKG_YnTap7rwua6j_ww_003D_003D > 180f)
			{
				float num3 = _0023_003Dq8P_0024LKG_YnTap7rwua6j_ww_003D_003D - 360f;
				if (4u != 0)
				{
					_0023_003Dq8P_0024LKG_YnTap7rwua6j_ww_003D_003D = num3;
				}
			}
		}
		_0023_003DqkRZ3Qt0uERuf_00249jfKqM36w_003D_003D = Mathf.Clamp(_0023_003DqkRZ3Qt0uERuf_00249jfKqM36w_003D_003D, _0023_003Dq8P_0024LKG_YnTap7rwua6j_ww_003D_003D, _0023_003DqDVFP_0024m2WplWx09lmy_0024ilhw_003D_003D);
		if (_0023_003DqkRZ3Qt0uERuf_00249jfKqM36w_003D_003D < 0f)
		{
			_0023_003DqkRZ3Qt0uERuf_00249jfKqM36w_003D_003D += 360f;
		}
		return _0023_003DqkRZ3Qt0uERuf_00249jfKqM36w_003D_003D;
	}

	public static Bounds _0023_003Dq3abCHJTbFgKhU2vMXVUZod9pMNljcMNp195bX98ZvQ0_003D(GameObject _0023_003DqXxw3txurAO6hOc2yI_ygWA_003D_003D)
	{
		Renderer[] componentsInChildren = _0023_003DqXxw3txurAO6hOc2yI_ygWA_003D_003D.GetComponentsInChildren<Renderer>();
		Renderer[] array;
		if (6u != 0)
		{
			array = componentsInChildren;
		}
		if (array.Length == 0)
		{
			return new Bounds(Vector3.zero, Vector3.zero);
		}
		Bounds bounds = array[0].bounds;
		Bounds result;
		if (true)
		{
			result = bounds;
		}
		Renderer[] array2 = default(Renderer[]);
		if (0 == 0)
		{
			array2 = array;
		}
		foreach (Renderer renderer in array2)
		{
			result.Encapsulate(renderer.bounds);
		}
		return result;
	}

	public static Vector3[] _0023_003DqJnZgHr_BX2DDck1hpGB74Q_003D_003D(this Bounds _0023_003DqkIuTsFT9Fkq4Gbl4fT_HcQ_003D_003D)
	{
		Vector3[] array = new Vector3[8];
		Vector3[] array2;
		if (true)
		{
			array2 = array;
		}
		array2[0] = _0023_003DqkIuTsFT9Fkq4Gbl4fT_HcQ_003D_003D.min;
		array2[1] = _0023_003DqkIuTsFT9Fkq4Gbl4fT_HcQ_003D_003D.max;
		array2[2] = new Vector3(array2[0].x, array2[0].y, array2[1].z);
		array2[3] = new Vector3(array2[0].x, array2[1].y, array2[1].z);
		array2[4] = new Vector3(array2[0].x, array2[1].y, array2[0].z);
		array2[5] = new Vector3(array2[1].x, array2[1].y, array2[0].z);
		array2[6] = new Vector3(array2[1].x, array2[0].y, array2[0].z);
		array2[7] = new Vector3(array2[1].x, array2[0].y, array2[1].z);
		return array2;
	}

	public static IEnumerable<T> _0023_003Dq9Uar6elSWPYFvSAquc8_wu6S_xV1w_2EDGy5GRWX7Ug_003D<T>(this IEnumerable<T> _0023_003DqYXFB9XAYMiiscnCl_0024B41tg_003D_003D, Func<T, string> _0023_003Dq5iHKYmng76xd6rFq_00245xPNw_003D_003D, string[] _0023_003DqnrAPyGRPNK1oaY_0024lpyhX6A_003D_003D)
	{
		_0023_003DqQQWbLQunvLVV2QRbq7x_0024TvFVOvQQmSOSq8KvHGI2b2tFNo0nShynE2WDsdNmrOZ_0024<T> obj = new _0023_003DqQQWbLQunvLVV2QRbq7x_0024TvFVOvQQmSOSq8KvHGI2b2tFNo0nShynE2WDsdNmrOZ_0024<T>();
		_0023_003DqQQWbLQunvLVV2QRbq7x_0024TvFVOvQQmSOSq8KvHGI2b2tFNo0nShynE2WDsdNmrOZ_0024<T> _0023_003DqQQWbLQunvLVV2QRbq7x_0024TvFVOvQQmSOSq8KvHGI2b2tFNo0nShynE2WDsdNmrOZ_00242;
		if (2u != 0)
		{
			_0023_003DqQQWbLQunvLVV2QRbq7x_0024TvFVOvQQmSOSq8KvHGI2b2tFNo0nShynE2WDsdNmrOZ_00242 = obj;
		}
		if (2u != 0)
		{
			_0023_003DqQQWbLQunvLVV2QRbq7x_0024TvFVOvQQmSOSq8KvHGI2b2tFNo0nShynE2WDsdNmrOZ_00242._0023_003DqhKvhKk_0024K1K_mznBm86FqVw_003D_003D = _0023_003Dq5iHKYmng76xd6rFq_00245xPNw_003D_003D;
		}
		if (7u != 0)
		{
			_0023_003DqQQWbLQunvLVV2QRbq7x_0024TvFVOvQQmSOSq8KvHGI2b2tFNo0nShynE2WDsdNmrOZ_00242._0023_003Dqy5AMDMLVMRX1nL6RPYXfGw_003D_003D = _0023_003DqnrAPyGRPNK1oaY_0024lpyhX6A_003D_003D;
		}
		return _0023_003DqYXFB9XAYMiiscnCl_0024B41tg_003D_003D.OrderBy(_0023_003DqQQWbLQunvLVV2QRbq7x_0024TvFVOvQQmSOSq8KvHGI2b2tFNo0nShynE2WDsdNmrOZ_00242._0023_003DqhKvhKk_0024K1K_mznBm86FqVw_003D_003D).OrderBy(_0023_003DqQQWbLQunvLVV2QRbq7x_0024TvFVOvQQmSOSq8KvHGI2b2tFNo0nShynE2WDsdNmrOZ_00242._0023_003DqKKRtYusb95sT875t8iIlXw_003D_003D);
	}

	public static global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<T> _0023_003Dqh_0024_00244k5zZwMr_1o6CqM2aBA_003D_003D<T>(global::_0023_003DqRuhczpedQZk6qxNWujLeLicleqw16RrSmn3zLz1a7W0_003D<T> _0023_003DqDxf0iM_UcbuvXJf8zonpbw_003D_003D, string _0023_003Dq0kQo3fVfrxzMpQNKw3KKrg_003D_003D)
	{
		int num = 0;
		if (7 == 0)
		{
		}
		int num2 = 0;
		if (6 == 0)
		{
		}
		T _0023_003DqA7kqkDplM7t8GGp8R9_0024vVQ_003D_003D;
		if (_0023_003DqDxf0iM_UcbuvXJf8zonpbw_003D_003D(_0023_003Dq0kQo3fVfrxzMpQNKw3KKrg_003D_003D, out _0023_003DqA7kqkDplM7t8GGp8R9_0024vVQ_003D_003D))
		{
			T val = _0023_003DqA7kqkDplM7t8GGp8R9_0024vVQ_003D_003D;
			int num3 = 4;
			if (2 == 0)
			{
			}
			return val;
		}
		return _0023_003DqKCpmYhU3Cw6rFrAWMAU1RA_003D_003D._0023_003DqSzEc316GHrb1MmRpC7aFWQ_003D_003D;
	}

	public static int _0023_003Dq6eG8KshuUZsuS6XlfTmCvw_003D_003D(int _0023_003DqwtSI9ztEwbo4QZ2ApboQPg_003D_003D, int _0023_003Dq58VMtYJLqgteGOaYyGUqxg_003D_003D)
	{
		int num2 = 7;
		if (7 == 0)
		{
		}
		int num3 = 7;
		if (5 == 0)
		{
		}
		int num = _0023_003DqwtSI9ztEwbo4QZ2ApboQPg_003D_003D % _0023_003Dq58VMtYJLqgteGOaYyGUqxg_003D_003D;
		int num4 = -1;
		if (false)
		{
		}
		return (num + _0023_003Dq58VMtYJLqgteGOaYyGUqxg_003D_003D) % _0023_003Dq58VMtYJLqgteGOaYyGUqxg_003D_003D;
	}

	public static int _0023_003Dq98RC6cYx8uVkXlm9XRgrmA_003D_003D(int _0023_003DqhPl35ya_00246Gkhccb2brN8gA_003D_003D, int _0023_003Dq8OMOdkserpu_Vm8zoAFyMg_003D_003D)
	{
		int num = -1;
		if (8 == 0)
		{
		}
		int num2 = 6;
		if (5 == 0)
		{
		}
		int num3 = 0;
		if (5 == 0)
		{
		}
		return _0023_003DqhPl35ya_00246Gkhccb2brN8gA_003D_003D - _0023_003Dq6eG8KshuUZsuS6XlfTmCvw_003D_003D(_0023_003DqhPl35ya_00246Gkhccb2brN8gA_003D_003D, _0023_003Dq8OMOdkserpu_Vm8zoAFyMg_003D_003D);
	}

	public static Vector3 _0023_003DqGQxi7VbrJaJvtQEexthkvw_003D_003D(Vector3 _0023_003DqqP1dr24O0jALMx9TKY9XNA_003D_003D)
	{
		return new Vector3(Mathf.Sign(_0023_003DqqP1dr24O0jALMx9TKY9XNA_003D_003D.x), Mathf.Sign(_0023_003DqqP1dr24O0jALMx9TKY9XNA_003D_003D.y), Mathf.Sign(_0023_003DqqP1dr24O0jALMx9TKY9XNA_003D_003D.z));
	}

	public static float _0023_003Dqt7_0024HtlW_0024qp4JCQnhRLAd4fuyhPWufqAhlB52xfmMaKc_003D(float _0023_003DqBjusK3_80dlSFdROA_0024qoWA_003D_003D, float _0023_003DqKNZgBu9LGdmbG_0024vIhkpEhg_003D_003D)
	{
		if (_0023_003DqKNZgBu9LGdmbG_0024vIhkpEhg_003D_003D < 0f)
		{
			float num = _0023_003DqBjusK3_80dlSFdROA_0024qoWA_003D_003D * -1f;
			if (5u != 0)
			{
				_0023_003DqBjusK3_80dlSFdROA_0024qoWA_003D_003D = num;
			}
			float num2 = _0023_003DqKNZgBu9LGdmbG_0024vIhkpEhg_003D_003D * -1f;
			if (0 == 0)
			{
				_0023_003DqKNZgBu9LGdmbG_0024vIhkpEhg_003D_003D = num2;
			}
		}
		float num3 = _0023_003DqBjusK3_80dlSFdROA_0024qoWA_003D_003D - (float)Mathf.FloorToInt(_0023_003DqBjusK3_80dlSFdROA_0024qoWA_003D_003D);
		float num4;
		if (true)
		{
			num4 = num3;
		}
		return (1f - num4) / _0023_003DqKNZgBu9LGdmbG_0024vIhkpEhg_003D_003D;
	}

	public static Vector3 _0023_003DqOMwcp0kY_0024je6LJafj_00248YVQ_003D_003D(Vector3 _0023_003DqDhyHqT0G4jEsuNmOdYRbyQ_003D_003D, Vector3 _0023_003DqmiNCkyqPzDgLs0yVIHdukg_003D_003D)
	{
		return new Vector3(_0023_003DqDhyHqT0G4jEsuNmOdYRbyQ_003D_003D.x / _0023_003DqmiNCkyqPzDgLs0yVIHdukg_003D_003D.x, _0023_003DqDhyHqT0G4jEsuNmOdYRbyQ_003D_003D.y / _0023_003DqmiNCkyqPzDgLs0yVIHdukg_003D_003D.y, _0023_003DqDhyHqT0G4jEsuNmOdYRbyQ_003D_003D.z / _0023_003DqmiNCkyqPzDgLs0yVIHdukg_003D_003D.z);
	}

	public static byte[] _0023_003Dqr3yXatEl0R0yBJJKkd8lFoMAysz2TXfXQOBjfZvdDck_003D(IEnumerable<byte[]> _0023_003DqVUJqwz4zQhFcfC6EFWwY5w_003D_003D)
	{
		long num = 0L;
		long num2;
		if (7u != 0)
		{
			num2 = num;
		}
		IEnumerator<byte[]> enumerator = _0023_003DqVUJqwz4zQhFcfC6EFWwY5w_003D_003D.GetEnumerator();
		IEnumerator<byte[]> enumerator2;
		if (5u != 0)
		{
			enumerator2 = enumerator;
		}
		try
		{
			while (enumerator2.MoveNext())
			{
				byte[] current = enumerator2.Current;
				byte[] array;
				if (7u != 0)
				{
					array = current;
				}
				num2 += array.Length;
			}
		}
		finally
		{
			if (enumerator2 != null)
			{
				enumerator2.Dispose();
			}
		}
		byte[] array2 = new byte[num2];
		long num3 = 0L;
		foreach (byte[] item in _0023_003DqVUJqwz4zQhFcfC6EFWwY5w_003D_003D)
		{
			item.CopyTo(array2, num3);
			num3 += item.Length;
		}
		return array2;
	}

	public static V _0023_003DqkEx5PlAIRPNp1xer2GvRlQ_003D_003D<K, V>(this Dictionary<K, V> _0023_003Dqd_QuSayj2a8iiLcNPQguxA_003D_003D, K _0023_003Dq2jIKVXvjVhCW5ZLGuI8odw_003D_003D, V _0023_003DqWkYy8fzB5nB8TBYdxpJtIA_003D_003D)
	{
		int num = 2;
		if (2 == 0)
		{
		}
		int num2 = 6;
		if (2 == 0)
		{
		}
		V value;
		if (_0023_003Dqd_QuSayj2a8iiLcNPQguxA_003D_003D.TryGetValue(_0023_003Dq2jIKVXvjVhCW5ZLGuI8odw_003D_003D, out value))
		{
			V result = value;
			int num3 = 3;
			if (4 == 0)
			{
			}
			return result;
		}
		_0023_003Dqd_QuSayj2a8iiLcNPQguxA_003D_003D.Add(_0023_003Dq2jIKVXvjVhCW5ZLGuI8odw_003D_003D, _0023_003DqWkYy8fzB5nB8TBYdxpJtIA_003D_003D);
		return _0023_003DqWkYy8fzB5nB8TBYdxpJtIA_003D_003D;
	}

	public static string _0023_003DqdoV0QN6Pzdj46C_e2h8bvIbGkemuz65uG2_l17yfSzU_003D()
	{
		return _0023_003DqMuax2R_00241K_xWFnMjKF4QoVMyLJdbKwr3U7yJtcyjFqw_003D(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694022226), new object[1] { DateTime.Now });
	}

	public static Vector2 _0023_003Dqpox8eDfChM2FPXjKYsZI2w_003D_003D(this Vector3 _0023_003DqGvTtRqoc_TSzR5lsRsa8YQ_003D_003D)
	{
		return new Vector2(_0023_003DqGvTtRqoc_TSzR5lsRsa8YQ_003D_003D.x, _0023_003DqGvTtRqoc_TSzR5lsRsa8YQ_003D_003D.y);
	}

	public static Vector2 _0023_003DqvRntLZry458DLRTaB0zBbA_003D_003D(this Vector3 _0023_003Dqs3Un9FdWoTYLA__0024YQyBGjQ_003D_003D)
	{
		return new Vector2(_0023_003Dqs3Un9FdWoTYLA__0024YQyBGjQ_003D_003D.x, _0023_003Dqs3Un9FdWoTYLA__0024YQyBGjQ_003D_003D.z);
	}

	public static Vector2 _0023_003DqCThPAA47Ju3Lt5OPDzk8hA_003D_003D(this Vector3 _0023_003DqAxFELmEWLSfPLFblY0KDpA_003D_003D)
	{
		return new Vector2(_0023_003DqAxFELmEWLSfPLFblY0KDpA_003D_003D.y, _0023_003DqAxFELmEWLSfPLFblY0KDpA_003D_003D.z);
	}

	public static float _0023_003Dq2PjMZjjrt9MGsHmBt40_hQyGMRvdavDAkjuDMOEJlM0_003D(Ray _0023_003DqQfkn9IpDMwlJ89egSjbrYA_003D_003D, float _0023_003DqaIayQhgBfiSSESG6tNb2iA_003D_003D, Ray _0023_003DqND1LGVkvCCBX_0024Tbah4Foww_003D_003D, float _0023_003DqPXepkFDjVzSb9GuiOtHVyQ_003D_003D, out Vector3 _0023_003DqgQ6Of7jJ6eVoke_Edy32aw_003D_003D, out Vector3 _0023_003DqRCsriIvoUdkjR3O4D3MU1Q_003D_003D)
	{
		Vector3 vector = _0023_003DqQfkn9IpDMwlJ89egSjbrYA_003D_003D.direction * _0023_003DqaIayQhgBfiSSESG6tNb2iA_003D_003D;
		Vector3 vector2;
		if (7u != 0)
		{
			vector2 = vector;
		}
		Vector3 vector3 = _0023_003DqND1LGVkvCCBX_0024Tbah4Foww_003D_003D.direction * _0023_003DqPXepkFDjVzSb9GuiOtHVyQ_003D_003D;
		Vector3 vector4;
		if (4u != 0)
		{
			vector4 = vector3;
		}
		Vector3 vector5 = _0023_003DqQfkn9IpDMwlJ89egSjbrYA_003D_003D.origin - _0023_003DqND1LGVkvCCBX_0024Tbah4Foww_003D_003D.origin;
		Vector3 vector6;
		if (true)
		{
			vector6 = vector5;
		}
		float num = Vector3.Dot(vector2, vector2);
		float num2;
		if (5u != 0)
		{
			num2 = num;
		}
		float num3 = Vector3.Dot(vector4, vector4);
		float num4;
		if (8u != 0)
		{
			num4 = num3;
		}
		float num5 = Vector3.Dot(vector2, vector4);
		float num6;
		if (2u != 0)
		{
			num6 = num5;
		}
		float num7 = Vector3.Dot(vector2, vector6);
		float num8 = Vector3.Dot(vector4, vector6);
		float num9 = num2 * num4 - num6 * num6;
		float num10 = num9;
		float num11 = num9;
		float num12;
		float num13;
		if (num9 < 1E-06f)
		{
			num12 = 0f;
			num10 = 1f;
			num13 = num8;
			num11 = num4;
		}
		else
		{
			num12 = num6 * num8 - num4 * num7;
			num13 = num2 * num8 - num6 * num7;
			if ((double)num12 < 0.0)
			{
				num12 = 0f;
				num13 = num8;
				num11 = num4;
			}
			else if (num12 > num10)
			{
				num12 = num10;
				num13 = num8 + num6;
				num11 = num4;
			}
		}
		if ((double)num13 < 0.0)
		{
			num13 = 0f;
			if (0f - num7 < 0f)
			{
				num12 = 0f;
			}
			else if (0f - num7 > num2)
			{
				num12 = num10;
			}
			else
			{
				num12 = 0f - num7;
				num10 = num2;
			}
		}
		else if (num13 > num11)
		{
			num13 = num11;
			if (0f - num7 + num6 < 0f)
			{
				num12 = 0f;
			}
			else if (0f - num7 + num6 > num2)
			{
				num12 = num10;
			}
			else
			{
				num12 = 0f - num7 + num6;
				num10 = num2;
			}
		}
		float num14 = ((!(Mathf.Abs(num12) < 1E-06f)) ? (num12 / num10) : 0f);
		float num15 = ((!(Mathf.Abs(num13) < 1E-06f)) ? (num13 / num11) : 0f);
		_0023_003DqgQ6Of7jJ6eVoke_Edy32aw_003D_003D = _0023_003DqQfkn9IpDMwlJ89egSjbrYA_003D_003D.origin + num14 * vector2;
		_0023_003DqRCsriIvoUdkjR3O4D3MU1Q_003D_003D = _0023_003DqND1LGVkvCCBX_0024Tbah4Foww_003D_003D.origin + num15 * vector4;
		return (vector6 + num14 * vector2 - num15 * vector4).magnitude;
	}

	public static Vector3 _0023_003DqN3NSdR2fYyDpbw6F4lXxiA_003D_003D(Vector3 _0023_003DquGWem7h0IVGXlqRIg6Y_0024Rg_003D_003D, Vector3 _0023_003DqYa7ecoGJThob4pYI7kxXOw_003D_003D)
	{
		return new Vector3(_0023_003DquGWem7h0IVGXlqRIg6Y_0024Rg_003D_003D.x * _0023_003DqYa7ecoGJThob4pYI7kxXOw_003D_003D.x, _0023_003DquGWem7h0IVGXlqRIg6Y_0024Rg_003D_003D.y * _0023_003DqYa7ecoGJThob4pYI7kxXOw_003D_003D.y, _0023_003DquGWem7h0IVGXlqRIg6Y_0024Rg_003D_003D.z * _0023_003DqYa7ecoGJThob4pYI7kxXOw_003D_003D.z);
	}

	public static Vector2 _0023_003DqdKPPc_0024WeE0OqDW8wGY9C4g_003D_003D(Font _0023_003Dq5SBodD5g9NRijGBQO3r4BQ_003D_003D, string _0023_003DqYhoaPYjEIAuZDL_3a_hmjg_003D_003D)
	{
		GUIStyle gUIStyle = _0023_003DqYpFooVPZWJ9GsUdtX3kpLwmXd5FOF9w48qhqJFOgYwE_003D;
		int num = 2;
		if (false)
		{
		}
		gUIStyle.font = _0023_003Dq5SBodD5g9NRijGBQO3r4BQ_003D_003D;
		GUIStyle gUIStyle2 = _0023_003DqYpFooVPZWJ9GsUdtX3kpLwmXd5FOF9w48qhqJFOgYwE_003D;
		int num2 = 2;
		if (-1 == 0)
		{
		}
		return gUIStyle2.CalcSize(new GUIContent(_0023_003DqYhoaPYjEIAuZDL_3a_hmjg_003D_003D));
	}

	public static string _0023_003DqMuax2R_00241K_xWFnMjKF4QoVMyLJdbKwr3U7yJtcyjFqw_003D(string _0023_003Dq78Mga_VljAVGHCR7GPbPVw_003D_003D, object[] _0023_003DqtLy4YEePEd2_0024QSxxkQ6JYA_003D_003D)
	{
		CultureInfo invariantCulture = CultureInfo.InvariantCulture;
		int num = 7;
		if (-1 == 0)
		{
		}
		int num2 = 1;
		if (6 == 0)
		{
		}
		return string.Format(invariantCulture, _0023_003Dq78Mga_VljAVGHCR7GPbPVw_003D_003D, _0023_003DqtLy4YEePEd2_0024QSxxkQ6JYA_003D_003D);
	}

	public static string _0023_003DqiTR0E_8AuAp9oLWON4G7DA14dgkJu7ogl5O7bZN_0024qZI_003D(this bool _0023_003Dq3DjxdExpGXQrXguYXmWNyg_003D_003D)
	{
		return _0023_003Dq3DjxdExpGXQrXguYXmWNyg_003D_003D.ToString(CultureInfo.InvariantCulture);
	}

	public static string _0023_003DqqsDhldGsWEKAcTChWQDx2lPaXQULMKr21v_0024NUCLhy0c_003D(this int _0023_003Dqh3Ers5qcY5V_00245oHOyHxfjA_003D_003D)
	{
		return _0023_003Dqh3Ers5qcY5V_00245oHOyHxfjA_003D_003D.ToString(CultureInfo.InvariantCulture);
	}

	public static string _0023_003Dqfz_0024b73OOIN4BiRtrCSfANeAgJQugzNPmhClpYKVayTw_003D(this uint _0023_003Dqcp0djzRQNndDeEAPtUlIdA_003D_003D)
	{
		return _0023_003Dqcp0djzRQNndDeEAPtUlIdA_003D_003D.ToString(CultureInfo.InvariantCulture);
	}

	public static string _0023_003DqCKgWsxmTkJe6DSsXqO8231xG79vL8nxDTd_0024sVXiwWVg_003D(this long _0023_003Dq_002417Byhgk1WrdnLVIrZN9WA_003D_003D)
	{
		return _0023_003Dq_002417Byhgk1WrdnLVIrZN9WA_003D_003D.ToString(CultureInfo.InvariantCulture);
	}

	public static string _0023_003DqJ5OMoAYDkQwtCqIZUJLNY_XRWGvrE_yPbmudfZ9_F7U_003D(this ulong _0023_003DqaDrDPpLETrQIMSCo9JMNBw_003D_003D)
	{
		return _0023_003DqaDrDPpLETrQIMSCo9JMNBw_003D_003D.ToString(CultureInfo.InvariantCulture);
	}

	public static string _0023_003DqaZC944CP6PptG0A_0024RZeKWogZYqbCjvqTpaFIfeanPwk_003D(this float _0023_003DqMBGoL1UI5sxOMvNSKJaAYA_003D_003D)
	{
		return _0023_003DqMBGoL1UI5sxOMvNSKJaAYA_003D_003D.ToString(CultureInfo.InvariantCulture);
	}

	public static string _0023_003DqksuGrOYZwXuG_0Gt6g4b6lD7WpLLwCWpb8ACLiePEWg_003D(this DateTime _0023_003DqD7rkKN8jtzchgYEKKwt76g_003D_003D)
	{
		return _0023_003DqD7rkKN8jtzchgYEKKwt76g_003D_003D.ToString(CultureInfo.InvariantCulture);
	}

	public static string _0023_003DqANnFPnoD_rEo89jpqqhEG32gHAcgF7l5cJApsvZTQzw_003D(this DateTime _0023_003DqOwMkjJi4Y7KUJYR_0024HcxLiA_003D_003D, string _0023_003DqQq2jsQ3VL3KHufHGH6hK2w_003D_003D)
	{
		int num = 5;
		if (3 == 0)
		{
		}
		return _0023_003DqOwMkjJi4Y7KUJYR_0024HcxLiA_003D_003D.ToString(_0023_003DqQq2jsQ3VL3KHufHGH6hK2w_003D_003D, CultureInfo.InvariantCulture);
	}

	public static string _0023_003DqjGsdTWofjv4MxPL5jeMgGN4ribI5DTYrlVk4M6TOFJk_003D(string _0023_003DqfyfhpI6tdf8sBrIiAS8Y2w_003D_003D, Text _0023_003Dqavo8ptFLwiLTAFT4htPlpg_003D_003D, int _0023_003DqRr_00244jePuVdRiV1xAn_nbew_003D_003D)
	{
		Rect rect = _0023_003Dqavo8ptFLwiLTAFT4htPlpg_003D_003D.rectTransform.rect;
		Rect rect2;
		if (3u != 0)
		{
			rect2 = rect;
		}
		int num = (int)(rect2.width - (float)(_0023_003DqRr_00244jePuVdRiV1xAn_nbew_003D_003D * 2));
		int num2;
		if (4u != 0)
		{
			num2 = num;
		}
		Vector2 vector = _0023_003DqdKPPc_0024WeE0OqDW8wGY9C4g_003D_003D(_0023_003Dqavo8ptFLwiLTAFT4htPlpg_003D_003D.font, _0023_003DqfyfhpI6tdf8sBrIiAS8Y2w_003D_003D);
		Vector2 vector2;
		if (7u != 0)
		{
			vector2 = vector;
		}
		if (vector2.x < (float)num2)
		{
			return _0023_003DqfyfhpI6tdf8sBrIiAS8Y2w_003D_003D;
		}
		while (vector2.x >= (float)num2)
		{
			_0023_003DqfyfhpI6tdf8sBrIiAS8Y2w_003D_003D = _0023_003DqfyfhpI6tdf8sBrIiAS8Y2w_003D_003D.Remove(_0023_003DqfyfhpI6tdf8sBrIiAS8Y2w_003D_003D.Length - 1);
			vector2 = _0023_003DqdKPPc_0024WeE0OqDW8wGY9C4g_003D_003D(_0023_003Dqavo8ptFLwiLTAFT4htPlpg_003D_003D.font, _0023_003DqfyfhpI6tdf8sBrIiAS8Y2w_003D_003D + _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694022581));
		}
		return _0023_003DqfyfhpI6tdf8sBrIiAS8Y2w_003D_003D + _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694022581);
	}

	public static bool _0023_003Dq2YHKVbJtx0_0024m8twqOGhOTw_003D_003D<T>(this T[] _0023_003DqabcgvxPQBkEcYT2GACIBdQ_003D_003D, T _0023_003DqBShdvdPsdO_0024vILBWGNvQEw_003D_003D)
	{
		int num;
		if (4u != 0)
		{
			num = 0;
		}
		while (num < _0023_003DqabcgvxPQBkEcYT2GACIBdQ_003D_003D.Length)
		{
			if (_0023_003DqabcgvxPQBkEcYT2GACIBdQ_003D_003D[num].Equals(_0023_003DqBShdvdPsdO_0024vILBWGNvQEw_003D_003D))
			{
				return true;
			}
			int num2 = num + 1;
			if (5u != 0)
			{
				num = num2;
			}
		}
		return false;
	}

	public static float _0023_003DqiXbqI5dfJ2lyKoO1gw9quHIyhpQCcFXb7CFX1chwo5s_003D(float _0023_003DqRFAepps4ldhrknOZhw76_0024Q_003D_003D)
	{
		float num = _0023_003DqRFAepps4ldhrknOZhw76_0024Q_003D_003D % 360f;
		if (0 == 0)
		{
			_0023_003DqRFAepps4ldhrknOZhw76_0024Q_003D_003D = num;
		}
		if (_0023_003DqRFAepps4ldhrknOZhw76_0024Q_003D_003D > 180f)
		{
			float num2 = _0023_003DqRFAepps4ldhrknOZhw76_0024Q_003D_003D - 360f;
			if (uint.MaxValue != 0)
			{
				_0023_003DqRFAepps4ldhrknOZhw76_0024Q_003D_003D = num2;
			}
		}
		return _0023_003DqRFAepps4ldhrknOZhw76_0024Q_003D_003D;
	}

	public static string _0023_003DqDBSJxMvtzKohrR7KxvDPWg_003D_003D(_0023_003DqtE5dCfOZj8_1IhhKA33gZw_003D_003D _0023_003DqeBLrk2OFds2iANmE0aSL_0024w_003D_003D)
	{
		_0023_003DqtE5dCfOZj8_1IhhKA33gZw_003D_003D _0023_003DqtE5dCfOZj8_1IhhKA33gZw_003D_003D2;
		if (5u != 0)
		{
			_0023_003DqtE5dCfOZj8_1IhhKA33gZw_003D_003D2 = _0023_003DqeBLrk2OFds2iANmE0aSL_0024w_003D_003D;
		}
		switch (_0023_003DqtE5dCfOZj8_1IhhKA33gZw_003D_003D2)
		{
		case (_0023_003DqtE5dCfOZj8_1IhhKA33gZw_003D_003D)0:
			return _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693977153);
		case (_0023_003DqtE5dCfOZj8_1IhhKA33gZw_003D_003D)1:
			return _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693977167);
		case (_0023_003DqtE5dCfOZj8_1IhhKA33gZw_003D_003D)2:
			return _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693977174);
		case (_0023_003DqtE5dCfOZj8_1IhhKA33gZw_003D_003D)3:
			return _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693977506);
		case (_0023_003DqtE5dCfOZj8_1IhhKA33gZw_003D_003D)4:
			return _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693977519);
		case (_0023_003DqtE5dCfOZj8_1IhhKA33gZw_003D_003D)5:
			return _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693977526);
		case (_0023_003DqtE5dCfOZj8_1IhhKA33gZw_003D_003D)6:
			return _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693977476);
		case (_0023_003DqtE5dCfOZj8_1IhhKA33gZw_003D_003D)7:
			return _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693977487);
		default:
			throw new _0023_003DqCXPLWqEX4vtUiAsgg5SRsQ_003D_003D(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693977385));
		}
	}

	public static string _0023_003DqoDg82eMF7y1XgQQVEkLbwwARI0mNSpWGgWmRz1Pwodk_003D(_0023_003Dq4BWKE_0024HJbqrIy5dzTFARMQ_003D_003D _0023_003DqAXvyL6zO2Wf2STL3YBkSqA_003D_003D)
	{
		_0023_003DqRFFYw_0024eibYGgy3esh1cI_Df1v53yY0R_0024IYJXlfD2RN0_003D _0023_003Dq4Lf5XGxq8cLFovJ7sfLY5w_003D_003D = _0023_003DqAXvyL6zO2Wf2STL3YBkSqA_003D_003D._0023_003Dq4Lf5XGxq8cLFovJ7sfLY5w_003D_003D;
		_0023_003DqRFFYw_0024eibYGgy3esh1cI_Df1v53yY0R_0024IYJXlfD2RN0_003D _0023_003DqRFFYw_0024eibYGgy3esh1cI_Df1v53yY0R_0024IYJXlfD2RN0_003D2;
		if (6u != 0)
		{
			_0023_003DqRFFYw_0024eibYGgy3esh1cI_Df1v53yY0R_0024IYJXlfD2RN0_003D2 = _0023_003Dq4Lf5XGxq8cLFovJ7sfLY5w_003D_003D;
		}
		switch (_0023_003DqRFFYw_0024eibYGgy3esh1cI_Df1v53yY0R_0024IYJXlfD2RN0_003D2)
		{
		case (_0023_003DqRFFYw_0024eibYGgy3esh1cI_Df1v53yY0R_0024IYJXlfD2RN0_003D)0:
			return _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694022531);
		case (_0023_003DqRFFYw_0024eibYGgy3esh1cI_Df1v53yY0R_0024IYJXlfD2RN0_003D)1:
			return _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694022538);
		case (_0023_003DqRFFYw_0024eibYGgy3esh1cI_Df1v53yY0R_0024IYJXlfD2RN0_003D)2:
			return _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694022552);
		case (_0023_003DqRFFYw_0024eibYGgy3esh1cI_Df1v53yY0R_0024IYJXlfD2RN0_003D)3:
			return _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694022627);
		default:
			throw new _0023_003DqCXPLWqEX4vtUiAsgg5SRsQ_003D_003D(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694022634));
		}
	}

	public static _0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D _0023_003DqfBAl_00245JMA22Tbf4bm7xJXQ_003D_003D(this _0023_003DqtE5dCfOZj8_1IhhKA33gZw_003D_003D _0023_003DqYPx7IByjHDv_0024SxF2506qiA_003D_003D)
	{
		_0023_003DqtE5dCfOZj8_1IhhKA33gZw_003D_003D _0023_003DqtE5dCfOZj8_1IhhKA33gZw_003D_003D2;
		if (7u != 0)
		{
			_0023_003DqtE5dCfOZj8_1IhhKA33gZw_003D_003D2 = _0023_003DqYPx7IByjHDv_0024SxF2506qiA_003D_003D;
		}
		switch (_0023_003DqtE5dCfOZj8_1IhhKA33gZw_003D_003D2)
		{
		case (_0023_003DqtE5dCfOZj8_1IhhKA33gZw_003D_003D)1:
			return (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)2;
		case (_0023_003DqtE5dCfOZj8_1IhhKA33gZw_003D_003D)2:
			return (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)3;
		case (_0023_003DqtE5dCfOZj8_1IhhKA33gZw_003D_003D)3:
			return (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)0;
		case (_0023_003DqtE5dCfOZj8_1IhhKA33gZw_003D_003D)4:
			return (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)1;
		default:
			throw new _0023_003DqCXPLWqEX4vtUiAsgg5SRsQ_003D_003D(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694022601));
		}
	}

	public static _0023_003DqtE5dCfOZj8_1IhhKA33gZw_003D_003D _0023_003Dq1xNke6ZQ8wSlE_0024TLziUJBw_003D_003D(this _0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D _0023_003DqCTeNw_0024q_0024sa9OWKeHeiFZGg_003D_003D)
	{
		_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D _0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D2;
		if (7u != 0)
		{
			_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D2 = _0023_003DqCTeNw_0024q_0024sa9OWKeHeiFZGg_003D_003D;
		}
		switch (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D2)
		{
		case (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)2:
			return (_0023_003DqtE5dCfOZj8_1IhhKA33gZw_003D_003D)1;
		case (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)3:
			return (_0023_003DqtE5dCfOZj8_1IhhKA33gZw_003D_003D)2;
		case (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)0:
			return (_0023_003DqtE5dCfOZj8_1IhhKA33gZw_003D_003D)3;
		case (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)1:
			return (_0023_003DqtE5dCfOZj8_1IhhKA33gZw_003D_003D)4;
		default:
			throw new _0023_003DqCXPLWqEX4vtUiAsgg5SRsQ_003D_003D(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694022456));
		}
	}

	public static _0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D _0023_003Dqk59JnnZzpOXkUvEx1be_0024EQ_003D_003D(this _0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D _0023_003DqJAUmwW_TNxSeaNhiSIdpwA_003D_003D)
	{
		_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D _0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D2;
		if (5u != 0)
		{
			_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D2 = _0023_003DqJAUmwW_TNxSeaNhiSIdpwA_003D_003D;
		}
		switch (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D2)
		{
		case (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)2:
			return (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)3;
		case (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)3:
			return (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)2;
		case (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)0:
			return (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)1;
		case (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)1:
			return (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)0;
		default:
			throw new _0023_003DqCXPLWqEX4vtUiAsgg5SRsQ_003D_003D(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694022499));
		}
	}

	public static Index2 _0023_003DqamKqiG20eyFZUkKrBFv2UQ_003D_003D(this _0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D _0023_003DqidBHO6TITPYFamW_QyuNlg_003D_003D)
	{
		_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D _0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D2;
		if (true)
		{
			_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D2 = _0023_003DqidBHO6TITPYFamW_QyuNlg_003D_003D;
		}
		switch (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D2)
		{
		case (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)2:
			return new Index2(-1, 0);
		case (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)3:
			return new Index2(1, 0);
		case (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)0:
			return new Index2(0, -1);
		case (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)1:
			return new Index2(0, 1);
		default:
			throw new _0023_003DqCXPLWqEX4vtUiAsgg5SRsQ_003D_003D(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694022480));
		}
	}

	public static void _0023_003DqYxFMmhsqZi6cr9Tma9_0024P7Q_003D_003D<T>(object _0023_003DqT5lIrE5e_M_Ka3_0024QXqEnzw_003D_003D, Action<T> _0023_003DqR5kDEiaOCXcvBNUtrUohdA_003D_003D) where T : class
	{
		T obj = _0023_003DqT5lIrE5e_M_Ka3_0024QXqEnzw_003D_003D as T;
		T val;
		if (5u != 0)
		{
			val = obj;
		}
		if (val != null)
		{
			_0023_003DqR5kDEiaOCXcvBNUtrUohdA_003D_003D(val);
		}
	}

	public static void _0023_003DqHr_00245ZvTBDaJu5XGvmQ9w7aiy6eVigVCd5adMqclkOc0_003D(string _0023_003DqC3aOXBf0LIPk9XQe9qBXNg_003D_003D)
	{
	}

	public static string _0023_003Dq2Y4wP0FDiGxQAwy70IJQ9HABiTWL0A2H2V_ugTa0IjU_003D(this string _0023_003Dq0kQo3fVfrxzMpQNKw3KKrg_003D_003D, int _0023_003DqLVZ1Wz2s_1QuTaAe_9_0024Qyw_003D_003D)
	{
		int num = 3;
		if (2 == 0)
		{
		}
		int num2 = 6;
		if (5 == 0)
		{
		}
		int num3 = 0;
		if (4 == 0)
		{
		}
		return _0023_003Dq0kQo3fVfrxzMpQNKw3KKrg_003D_003D.Substring(0, Mathf.Min(_0023_003DqLVZ1Wz2s_1QuTaAe_9_0024Qyw_003D_003D, _0023_003Dq0kQo3fVfrxzMpQNKw3KKrg_003D_003D.Length)).PadRight(_0023_003DqLVZ1Wz2s_1QuTaAe_9_0024Qyw_003D_003D);
	}

	public static string _0023_003DqWWtF88ZMpeoNKim49FC53Q_003D_003D(this string _0023_003DqoLST1MCwOxGsoPXzhAABfg_003D_003D, int _0023_003DqxgIlpFj4J_piLyKTsGNitQ_003D_003D, int _0023_003DqUb75BDq_0024LnEb65q6Ryb_Mg_003D_003D)
	{
		try
		{
			string result = _0023_003DqoLST1MCwOxGsoPXzhAABfg_003D_003D.Remove(_0023_003DqxgIlpFj4J_piLyKTsGNitQ_003D_003D, _0023_003DqUb75BDq_0024LnEb65q6Ryb_Mg_003D_003D);
			if (4u != 0)
			{
				return result;
			}
		}
		catch
		{
			throw new Exception(string.Format(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694022837), _0023_003DqoLST1MCwOxGsoPXzhAABfg_003D_003D, _0023_003DqxgIlpFj4J_piLyKTsGNitQ_003D_003D, _0023_003DqUb75BDq_0024LnEb65q6Ryb_Mg_003D_003D));
		}
		string result2;
		return result2;
	}

	public static void _0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D(this AudioClip _0023_003Dq5COgxX0OVjEb52u3vJb0gg_003D_003D)
	{
		AudioSource audioSource = _0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.AudioSource;
		int num = 1;
		if (-1 == 0)
		{
		}
		audioSource.PlayOneShot(_0023_003Dq5COgxX0OVjEb52u3vJb0gg_003D_003D);
	}
}
