using System.Linq;
using UnityEngine;

public sealed class ImageBleed : MonoBehaviour
{
	private static readonly Index2 _0023_003DqO8SttkJSjGrWAMJBIAGEEw_003D_003D;

	private static readonly float _0023_003DqJpHxEBEgA8gy6DrlUwdbng_003D_003D;

	private static readonly float _0023_003DqG3in2Njg7ldZu_sX1dVWVQ_003D_003D;

	public Material Effect;

	private float _0023_003DqFb823mHIacqV5c8496TnLQ_003D_003D;

	private float _0023_003DqRKpuqGa1eLANLEwuZ750LA_003D_003D;

	private Texture2D _0023_003DqRHU08frA6iNgbkPRcNQqTA_003D_003D;

	private bool[] _0023_003Dq04dgfRFEqXvN5t1zXGahqg_003D_003D;

	private _0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D[] _0023_003DqNmwwjDyDUqFb5qXU90sohFmttPqOafDn4RlH0vEL4Nc_003D;

	public ImageBleed()
	{
		int num = 2;
		if (6 == 0)
		{
		}
		base._002Ector();
	}

	static ImageBleed()
	{
		Index2 index = new Index2(171, 64);
		if (3u != 0)
		{
			_0023_003DqO8SttkJSjGrWAMJBIAGEEw_003D_003D = index;
		}
		if (4u != 0)
		{
			_0023_003DqJpHxEBEgA8gy6DrlUwdbng_003D_003D = 0.015f;
		}
		if (3u != 0)
		{
			_0023_003DqG3in2Njg7ldZu_sX1dVWVQ_003D_003D = 5f;
		}
	}

	public void Start()
	{
		int num = 1;
		if (2 == 0)
		{
		}
		if (_0023_003DqRHU08frA6iNgbkPRcNQqTA_003D_003D == null)
		{
			int num2 = 6;
			if (2 == 0)
			{
			}
			_0023_003DqPRe3T2k_Mv6wrgB_0024nGO7Ag_003D_003D();
		}
	}

	public void Update()
	{
		bool flag;
		if (5u != 0)
		{
			flag = false;
		}
		float num = _0023_003DqFb823mHIacqV5c8496TnLQ_003D_003D + Time.deltaTime;
		if (true)
		{
			_0023_003DqFb823mHIacqV5c8496TnLQ_003D_003D = num;
		}
		while (_0023_003DqFb823mHIacqV5c8496TnLQ_003D_003D >= _0023_003DqJpHxEBEgA8gy6DrlUwdbng_003D_003D)
		{
			float num2 = _0023_003DqFb823mHIacqV5c8496TnLQ_003D_003D - _0023_003DqJpHxEBEgA8gy6DrlUwdbng_003D_003D;
			if (3u != 0)
			{
				_0023_003DqFb823mHIacqV5c8496TnLQ_003D_003D = num2;
			}
			bool[] array = _0023_003Dq04dgfRFEqXvN5t1zXGahqg_003D_003D.ToArray();
			bool[] array2;
			if (uint.MaxValue != 0)
			{
				array2 = array;
			}
			for (int i = 0; i < array2.Length; i++)
			{
				if (array2[i])
				{
					if (_0023_003DqNmwwjDyDUqFb5qXU90sohFmttPqOafDn4RlH0vEL4Nc_003D[i] == (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)3 || Random.Range(0, 2) == 0)
					{
						int num3 = i;
						Index2 index = _0023_003DqO8SttkJSjGrWAMJBIAGEEw_003D_003D;
						int _0023_003Dqh3Ers5qcY5V_00245oHOyHxfjA_003D_003D = num3 % index.X;
						int num4 = i;
						Index2 index2 = _0023_003DqO8SttkJSjGrWAMJBIAGEEw_003D_003D;
						Index2 _0023_003DqCAdUspIAQJd4hzdHRHqEWA_003D_003D = new Index2(_0023_003Dqh3Ers5qcY5V_00245oHOyHxfjA_003D_003D, num4 / index2.X) + _0023_003DqNmwwjDyDUqFb5qXU90sohFmttPqOafDn4RlH0vEL4Nc_003D[i]._0023_003DqamKqiG20eyFZUkKrBFv2UQ_003D_003D();
						_0023_003DqEzeNnm_0024jOvX91h8cVGc6Kg_003D_003D(_0023_003DqCAdUspIAQJd4hzdHRHqEWA_003D_003D, _0023_003DqNmwwjDyDUqFb5qXU90sohFmttPqOafDn4RlH0vEL4Nc_003D[i]);
						flag = true;
					}
					if (Random.Range(0, 20) == 0)
					{
						_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D _0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D2 = ((_0023_003DqNmwwjDyDUqFb5qXU90sohFmttPqOafDn4RlH0vEL4Nc_003D[i] == (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)2 || _0023_003DqNmwwjDyDUqFb5qXU90sohFmttPqOafDn4RlH0vEL4Nc_003D[i] == (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)3) ? ((Random.Range(0, 2) != 0) ? ((_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)1) : ((_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)0)) : ((Random.Range(0, 2) != 0) ? ((_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)3) : ((_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)2)));
						_0023_003DqNmwwjDyDUqFb5qXU90sohFmttPqOafDn4RlH0vEL4Nc_003D[i] = _0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D2;
					}
				}
			}
		}
		if (flag)
		{
			_0023_003DqRHU08frA6iNgbkPRcNQqTA_003D_003D.Apply();
		}
		_0023_003DqRKpuqGa1eLANLEwuZ750LA_003D_003D += Time.deltaTime;
		if (_0023_003DqRKpuqGa1eLANLEwuZ750LA_003D_003D >= _0023_003DqG3in2Njg7ldZu_sX1dVWVQ_003D_003D)
		{
			base.gameObject.SetActive(false);
			_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.CrtEffect.TurnOff(_0023_003DqHHcYOzWpsCU_0024BtLsYZaaPw_003D_003D._0023_003DqIUTIGYZ9u21W0_u0ztqeVA_003D_003D);
		}
	}

	private void _0023_003DqPRe3T2k_Mv6wrgB_0024nGO7Ag_003D_003D()
	{
		Index2 index = _0023_003DqO8SttkJSjGrWAMJBIAGEEw_003D_003D;
		Index2 index2;
		if (4u != 0)
		{
			index2 = index;
		}
		int x = index2.X;
		Index2 index3 = _0023_003DqO8SttkJSjGrWAMJBIAGEEw_003D_003D;
		Index2 index4;
		if (2u != 0)
		{
			index4 = index3;
		}
		Texture2D texture2D = new Texture2D(x, index4.Y, TextureFormat.ARGB32, false);
		if (0 == 0)
		{
			_0023_003DqRHU08frA6iNgbkPRcNQqTA_003D_003D = texture2D;
		}
		_0023_003DqRHU08frA6iNgbkPRcNQqTA_003D_003D.filterMode = FilterMode.Point;
		Index2 index5 = _0023_003DqO8SttkJSjGrWAMJBIAGEEw_003D_003D;
		int x2 = index5.X;
		Index2 index6 = _0023_003DqO8SttkJSjGrWAMJBIAGEEw_003D_003D;
		_0023_003Dq04dgfRFEqXvN5t1zXGahqg_003D_003D = new bool[x2 * index6.Y];
		Index2 index7 = _0023_003DqO8SttkJSjGrWAMJBIAGEEw_003D_003D;
		int x3 = index7.X;
		Index2 index8 = _0023_003DqO8SttkJSjGrWAMJBIAGEEw_003D_003D;
		_0023_003DqNmwwjDyDUqFb5qXU90sohFmttPqOafDn4RlH0vEL4Nc_003D = new _0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D[x3 * index8.Y];
		Effect.SetTexture(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693991858), _0023_003DqRHU08frA6iNgbkPRcNQqTA_003D_003D);
	}

	public void StartAnimation()
	{
		if (_0023_003DqRHU08frA6iNgbkPRcNQqTA_003D_003D == null)
		{
			_0023_003DqPRe3T2k_Mv6wrgB_0024nGO7Ag_003D_003D();
		}
		if (8u != 0)
		{
			_0023_003DqFb823mHIacqV5c8496TnLQ_003D_003D = 0f;
		}
		if (2u != 0)
		{
			_0023_003DqRKpuqGa1eLANLEwuZ750LA_003D_003D = 0f;
		}
		Texture2D texture2D = _0023_003DqRHU08frA6iNgbkPRcNQqTA_003D_003D;
		Color black = Color.black;
		Index2 index = _0023_003DqO8SttkJSjGrWAMJBIAGEEw_003D_003D;
		Index2 index2;
		if (true)
		{
			index2 = index;
		}
		int x = index2.X;
		Index2 index3 = _0023_003DqO8SttkJSjGrWAMJBIAGEEw_003D_003D;
		texture2D.SetPixels(Enumerable.Repeat(black, x * index3.Y).ToArray());
		for (int i = 0; i < _0023_003Dq04dgfRFEqXvN5t1zXGahqg_003D_003D.Length; i++)
		{
			_0023_003Dq04dgfRFEqXvN5t1zXGahqg_003D_003D[i] = false;
		}
		_0023_003DqEzeNnm_0024jOvX91h8cVGc6Kg_003D_003D(new Index2(39, 10), (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)3);
		_0023_003DqRHU08frA6iNgbkPRcNQqTA_003D_003D.Apply();
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundImageBleed._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
		base.gameObject.SetActive(true);
	}

	private void _0023_003DqEzeNnm_0024jOvX91h8cVGc6Kg_003D_003D(Index2 _0023_003DqCAdUspIAQJd4hzdHRHqEWA_003D_003D, _0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D _0023_003Dqmy3TaOmuYpq_0024bzrxYRR92w_003D_003D)
	{
		int x = _0023_003DqCAdUspIAQJd4hzdHRHqEWA_003D_003D.X;
		int num;
		if (3u != 0)
		{
			num = x;
		}
		int y = _0023_003DqCAdUspIAQJd4hzdHRHqEWA_003D_003D.Y;
		int num2;
		if (4u != 0)
		{
			num2 = y;
		}
		if (num < 0)
		{
			return;
		}
		Index2 index = _0023_003DqO8SttkJSjGrWAMJBIAGEEw_003D_003D;
		Index2 index2;
		if (4u != 0)
		{
			index2 = index;
		}
		if (num >= index2.X || num2 < 0)
		{
			return;
		}
		Index2 index3 = _0023_003DqO8SttkJSjGrWAMJBIAGEEw_003D_003D;
		if (num2 < index3.Y)
		{
			bool[] array = _0023_003Dq04dgfRFEqXvN5t1zXGahqg_003D_003D;
			Index2 index4 = _0023_003DqO8SttkJSjGrWAMJBIAGEEw_003D_003D;
			if (!array[num + index4.X * num2])
			{
				bool[] array2 = _0023_003Dq04dgfRFEqXvN5t1zXGahqg_003D_003D;
				Index2 index5 = _0023_003DqO8SttkJSjGrWAMJBIAGEEw_003D_003D;
				array2[num + index5.X * num2] = true;
				_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D[] array3 = _0023_003DqNmwwjDyDUqFb5qXU90sohFmttPqOafDn4RlH0vEL4Nc_003D;
				Index2 index6 = _0023_003DqO8SttkJSjGrWAMJBIAGEEw_003D_003D;
				array3[num + index6.X * num2] = _0023_003Dqmy3TaOmuYpq_0024bzrxYRR92w_003D_003D;
				_0023_003DqRHU08frA6iNgbkPRcNQqTA_003D_003D.SetPixel(num, num2, Color.white);
			}
		}
	}
}
