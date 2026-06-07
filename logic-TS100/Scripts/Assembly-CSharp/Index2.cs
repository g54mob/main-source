using System;
using UnityEngine;

[Serializable]
public struct Index2
{
	public static readonly Index2 Zero;

	public int X;

	public int Y;

	public Index2(int _0023_003Dqh3Ers5qcY5V_00245oHOyHxfjA_003D_003D, int _0023_003DqTFAa0NIAJU_0024685gawXmSvA_003D_003D)
	{
		if (0 == 0)
		{
			X = _0023_003Dqh3Ers5qcY5V_00245oHOyHxfjA_003D_003D;
		}
		if (0 == 0)
		{
			Y = _0023_003DqTFAa0NIAJU_0024685gawXmSvA_003D_003D;
		}
	}

	static Index2()
	{
		Index2 zero = new Index2(0, 0);
		if (4u != 0)
		{
			Zero = zero;
		}
	}

	public static Index2 _0023_003Dqn8sYZpPXqXGbS51ItD4p4Q_003D_003D(Vector2 _0023_003Dq6zftbSqZkz9mnoAkuCxeVQ_003D_003D)
	{
		return new Index2((int)Mathf.Round(_0023_003Dq6zftbSqZkz9mnoAkuCxeVQ_003D_003D.x), (int)Mathf.Round(_0023_003Dq6zftbSqZkz9mnoAkuCxeVQ_003D_003D.y));
	}

	public bool _0023_003DqwUChfFBq1St8KL1zk3U00w_003D_003D(Index2 _0023_003Dqg_0024pY0LYxWF3XfPUnmLh35Q_003D_003D)
	{
		int num = -1;
		if (3 == 0)
		{
		}
		int result;
		if (X == _0023_003Dqg_0024pY0LYxWF3XfPUnmLh35Q_003D_003D.X)
		{
			int num2 = 5;
			if (7 == 0)
			{
			}
			result = ((Y == _0023_003Dqg_0024pY0LYxWF3XfPUnmLh35Q_003D_003D.Y) ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public override bool Equals(object _0023_003DqWgpDn6bqY6Ulf0633vn_0024CQ_003D_003D)
	{
		Index2? obj = _0023_003DqWgpDn6bqY6Ulf0633vn_0024CQ_003D_003D as Index2?;
		Index2? index;
		if (2u != 0)
		{
			index = obj;
		}
		if (index.HasValue)
		{
			return _0023_003DqwUChfFBq1St8KL1zk3U00w_003D_003D(index.Value);
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num;
		if (7u != 0)
		{
			num = 17;
		}
		int num2 = num * 23 + X.GetHashCode();
		if (5u != 0)
		{
			num = num2;
		}
		int result = num * 23 + Y.GetHashCode();
		if (-1 == 0)
		{
			return num;
		}
		return result;
	}

	public override string ToString()
	{
		string _0023_003Dq78Mga_VljAVGHCR7GPbPVw_003D_003D = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693991919);
		object[] array = new object[2];
		int num = 6;
		if (6 == 0)
		{
		}
		array[0] = X;
		int num2 = 8;
		if (5 == 0)
		{
		}
		array[1] = Y;
		return _0023_003DqVrXiDsAi2V_0024fw1Bak8WNsA_003D_003D._0023_003DqMuax2R_00241K_xWFnMjKF4QoVMyLJdbKwr3U7yJtcyjFqw_003D(_0023_003Dq78Mga_VljAVGHCR7GPbPVw_003D_003D, array);
	}

	public Index2 _0023_003DqNtfJ1_zVos4aZ21XOXVzlg_003D_003D(int _0023_003Dqn_BlHRo_00241r_0024C7BONsN1UHw_003D_003D, int _0023_003DqnbmMHZViHfk78srqRC0G0A_003D_003D)
	{
		int num = 0;
		if (2 == 0)
		{
		}
		int x = X;
		int num2 = 7;
		if (8 == 0)
		{
		}
		int num3 = 7;
		if (8 == 0)
		{
		}
		return new Index2(Mathf.Clamp(x, _0023_003Dqn_BlHRo_00241r_0024C7BONsN1UHw_003D_003D, _0023_003DqnbmMHZViHfk78srqRC0G0A_003D_003D), Mathf.Clamp(Y, _0023_003Dqn_BlHRo_00241r_0024C7BONsN1UHw_003D_003D, _0023_003DqnbmMHZViHfk78srqRC0G0A_003D_003D));
	}

	public int _0023_003Dqnk9_00249onjIdc9iw_0024uRd7bW7BvPkUihNjvB_WhKqkMLfw_003D()
	{
		int num2 = 0;
		if (false)
		{
		}
		int num = Math.Abs(X);
		int num3 = 4;
		if (-1 == 0)
		{
		}
		return num + Math.Abs(Y);
	}

	public int _0023_003DqoJXf_G8HGgFa_uBwn6BxiP38efZhSZvpXK7ZUDguNPQ_003D(Index2 _0023_003DqRDb1OBfQBnMNgs8YbW21mw_003D_003D)
	{
		Index2 index = this - _0023_003DqRDb1OBfQBnMNgs8YbW21mw_003D_003D;
		Index2 index2;
		if (3u != 0)
		{
			index2 = index;
		}
		return index2._0023_003Dqnk9_00249onjIdc9iw_0024uRd7bW7BvPkUihNjvB_WhKqkMLfw_003D();
	}

	public static explicit operator Vector3(Index2 _0023_003Dqo1exHkjxf7vr_0024hU2W7mUzw_003D_003D)
	{
		return new Vector3(_0023_003Dqo1exHkjxf7vr_0024hU2W7mUzw_003D_003D.X, _0023_003Dqo1exHkjxf7vr_0024hU2W7mUzw_003D_003D.Y);
	}

	public static Index2 operator +(Index2 _0023_003DqdCGSHQz6FUW40cg2SVJUww_003D_003D, Index2 _0023_003Dq8mnqM1G62Z6ldCJVjuJrDA_003D_003D)
	{
		return new Index2(_0023_003DqdCGSHQz6FUW40cg2SVJUww_003D_003D.X + _0023_003Dq8mnqM1G62Z6ldCJVjuJrDA_003D_003D.X, _0023_003DqdCGSHQz6FUW40cg2SVJUww_003D_003D.Y + _0023_003Dq8mnqM1G62Z6ldCJVjuJrDA_003D_003D.Y);
	}

	public static Index2 operator -(Index2 _0023_003DqgPCuoIjPq45ZcyyaIjpLeg_003D_003D, Index2 _0023_003DqrmKlPUsRD3ahAVAbD7HBwQ_003D_003D)
	{
		return new Index2(_0023_003DqgPCuoIjPq45ZcyyaIjpLeg_003D_003D.X - _0023_003DqrmKlPUsRD3ahAVAbD7HBwQ_003D_003D.X, _0023_003DqgPCuoIjPq45ZcyyaIjpLeg_003D_003D.Y - _0023_003DqrmKlPUsRD3ahAVAbD7HBwQ_003D_003D.Y);
	}

	public static Index2 operator *(int _0023_003DqTIFPQX1R5j7zUitb6MaXXw_003D_003D, Index2 _0023_003DqYEV6buakhEdPTuWLt6a4tQ_003D_003D)
	{
		int num = 3;
		if (3 == 0)
		{
		}
		int _0023_003Dqh3Ers5qcY5V_00245oHOyHxfjA_003D_003D = _0023_003DqTIFPQX1R5j7zUitb6MaXXw_003D_003D * _0023_003DqYEV6buakhEdPTuWLt6a4tQ_003D_003D.X;
		int num2 = 8;
		if (6 == 0)
		{
		}
		return new Index2(_0023_003Dqh3Ers5qcY5V_00245oHOyHxfjA_003D_003D, _0023_003DqTIFPQX1R5j7zUitb6MaXXw_003D_003D * _0023_003DqYEV6buakhEdPTuWLt6a4tQ_003D_003D.Y);
	}

	public static bool operator ==(Index2 _0023_003Dq7cLqm0hf4ytKoYd_0024ImYREA_003D_003D, Index2 _0023_003DqPnQieWMA8KAvhqfSA421QQ_003D_003D)
	{
		int num = 5;
		if (5 == 0)
		{
		}
		return _0023_003Dq7cLqm0hf4ytKoYd_0024ImYREA_003D_003D._0023_003DqwUChfFBq1St8KL1zk3U00w_003D_003D(_0023_003DqPnQieWMA8KAvhqfSA421QQ_003D_003D);
	}

	public static bool operator !=(Index2 _0023_003DqDXlxfkyEMo4WYQCpxYpFCQ_003D_003D, Index2 _0023_003DqFP2m1o35y2stM1AlrqEI0Q_003D_003D)
	{
		int num = 3;
		if (6 == 0)
		{
		}
		return !_0023_003DqDXlxfkyEMo4WYQCpxYpFCQ_003D_003D._0023_003DqwUChfFBq1St8KL1zk3U00w_003D_003D(_0023_003DqFP2m1o35y2stM1AlrqEI0Q_003D_003D);
	}
}
