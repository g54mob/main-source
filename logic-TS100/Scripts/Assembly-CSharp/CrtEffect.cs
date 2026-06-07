using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public sealed class CrtEffect : MonoBehaviour
{
	private static readonly float _0023_003Dqi5lx6icEFkGXn5rdBTGJvg_003D_003D;

	private static readonly float _0023_003DqxSTbebyohYRF4qPRQPSV2pJ_yxuyMbZful_0024elufas0Y_003D;

	private static readonly float _0023_003DqDau2ttnAr3OQSBn8hqOq9aNcEJx6nUj1xXulVSA2MrP7GiSamun8IB161jtzScPI;

	private static readonly float _0023_003Dqc8_fPLp0xrtdIrzfKZzXjOVCUnMuTCCLCgvE1lRfhx4_003D;

	public Material Effect;

	private float _0023_003DqT1Q_0024kXIerPOrq3w_PaPH8w_003D_003D;

	private Action _0023_003Dqq495Infpuaqk3R3ycC6iJymJs1ri0LrriWUUP7QaBUw_003D;

	private _0023_003DqrZFcxScBWPdMP1Zk8vOliw_003D_003D _0023_003Dq8DaNr9zeKu3PFAoG_Ps244AUditGT_00245lJxwVlC28_0024_0024w_003D;

	public _0023_003DqrZFcxScBWPdMP1Zk8vOliw_003D_003D State
	{
		[CompilerGenerated]
		get
		{
			int num = 0;
			if (6 == 0)
			{
			}
			return _0023_003Dq8DaNr9zeKu3PFAoG_Ps244AUditGT_00245lJxwVlC28_0024_0024w_003D;
		}
		[CompilerGenerated]
		private set
		{
			if (4u != 0)
			{
				_0023_003Dq8DaNr9zeKu3PFAoG_Ps244AUditGT_00245lJxwVlC28_0024_0024w_003D = value;
			}
		}
	}

	public CrtEffect()
	{
		int num = 3;
		if (5 == 0)
		{
		}
		base._002Ector();
	}

	static CrtEffect()
	{
		if (2u != 0)
		{
			_0023_003Dqi5lx6icEFkGXn5rdBTGJvg_003D_003D = 2.5f;
		}
		if (4u != 0)
		{
			_0023_003DqxSTbebyohYRF4qPRQPSV2pJ_yxuyMbZful_0024elufas0Y_003D = 0.5f;
		}
		if (0 == 0)
		{
			_0023_003DqDau2ttnAr3OQSBn8hqOq9aNcEJx6nUj1xXulVSA2MrP7GiSamun8IB161jtzScPI = 1.5f;
		}
		_0023_003Dqc8_fPLp0xrtdIrzfKZzXjOVCUnMuTCCLCgvE1lRfhx4_003D = 1f;
	}

	private void Start()
	{
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundBoot._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
		State = (_0023_003DqrZFcxScBWPdMP1Zk8vOliw_003D_003D)0;
		if (2u != 0)
		{
			_0023_003DqT1Q_0024kXIerPOrq3w_PaPH8w_003D_003D = 0f;
		}
	}

	public void ManualUpdate()
	{
		float num = _0023_003DqT1Q_0024kXIerPOrq3w_PaPH8w_003D_003D + Time.deltaTime;
		if (3u != 0)
		{
			_0023_003DqT1Q_0024kXIerPOrq3w_PaPH8w_003D_003D = num;
		}
		_0023_003DqrZFcxScBWPdMP1Zk8vOliw_003D_003D state = State;
		_0023_003DqrZFcxScBWPdMP1Zk8vOliw_003D_003D _0023_003DqrZFcxScBWPdMP1Zk8vOliw_003D_003D2 = default(_0023_003DqrZFcxScBWPdMP1Zk8vOliw_003D_003D);
		if (0 == 0)
		{
			_0023_003DqrZFcxScBWPdMP1Zk8vOliw_003D_003D2 = state;
		}
		switch (_0023_003DqrZFcxScBWPdMP1Zk8vOliw_003D_003D2)
		{
		case (_0023_003DqrZFcxScBWPdMP1Zk8vOliw_003D_003D)0:
			base.enabled = true;
			Effect.SetFloat(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693988115), 0f);
			Effect.SetFloat(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693988195), _0023_003DqT1Q_0024kXIerPOrq3w_PaPH8w_003D_003D / _0023_003Dqi5lx6icEFkGXn5rdBTGJvg_003D_003D);
			if (_0023_003DqT1Q_0024kXIerPOrq3w_PaPH8w_003D_003D >= _0023_003Dqi5lx6icEFkGXn5rdBTGJvg_003D_003D)
			{
				State = (_0023_003DqrZFcxScBWPdMP1Zk8vOliw_003D_003D)1;
				if (true)
				{
					_0023_003DqT1Q_0024kXIerPOrq3w_PaPH8w_003D_003D = 0f;
				}
			}
			break;
		case (_0023_003DqrZFcxScBWPdMP1Zk8vOliw_003D_003D)1:
			base.enabled = false;
			break;
		case (_0023_003DqrZFcxScBWPdMP1Zk8vOliw_003D_003D)2:
			base.enabled = true;
			Effect.SetFloat(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693988115), _0023_003DqT1Q_0024kXIerPOrq3w_PaPH8w_003D_003D / _0023_003DqxSTbebyohYRF4qPRQPSV2pJ_yxuyMbZful_0024elufas0Y_003D);
			Effect.SetFloat(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693988195), 1f);
			if (_0023_003DqT1Q_0024kXIerPOrq3w_PaPH8w_003D_003D >= _0023_003DqxSTbebyohYRF4qPRQPSV2pJ_yxuyMbZful_0024elufas0Y_003D + _0023_003DqDau2ttnAr3OQSBn8hqOq9aNcEJx6nUj1xXulVSA2MrP7GiSamun8IB161jtzScPI)
			{
				State = (_0023_003DqrZFcxScBWPdMP1Zk8vOliw_003D_003D)3;
				_0023_003DqT1Q_0024kXIerPOrq3w_PaPH8w_003D_003D = 0f;
				_0023_003Dqq495Infpuaqk3R3ycC6iJymJs1ri0LrriWUUP7QaBUw_003D();
			}
			break;
		case (_0023_003DqrZFcxScBWPdMP1Zk8vOliw_003D_003D)3:
			base.enabled = true;
			Effect.SetFloat(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693988115), 0f);
			Effect.SetFloat(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693988195), 0f);
			if (_0023_003DqT1Q_0024kXIerPOrq3w_PaPH8w_003D_003D >= _0023_003Dqc8_fPLp0xrtdIrzfKZzXjOVCUnMuTCCLCgvE1lRfhx4_003D)
			{
				_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundBoot._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
				State = (_0023_003DqrZFcxScBWPdMP1Zk8vOliw_003D_003D)0;
				_0023_003DqT1Q_0024kXIerPOrq3w_PaPH8w_003D_003D = 0f;
			}
			break;
		}
	}

	private void OnRenderImage(RenderTexture _0023_003DqHsx7msIE4t2qN64LS0ZiWw_003D_003D, RenderTexture _0023_003DqAb8Bd85hdR0w6jmgxDFdiw_003D_003D)
	{
		int num = 3;
		if (5 == 0)
		{
		}
		int num2 = 3;
		if (4 == 0)
		{
		}
		int num3 = 2;
		if (8 == 0)
		{
		}
		Graphics.Blit(_0023_003DqHsx7msIE4t2qN64LS0ZiWw_003D_003D, _0023_003DqAb8Bd85hdR0w6jmgxDFdiw_003D_003D, Effect);
	}

	public void TurnOff(Action _0023_003Dqvt3EtI3STbrhHIDMCKOBnDCNzkqb7u_0024uo_00249_k4cNyKA_003D)
	{
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundPowerDown._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
		State = (_0023_003DqrZFcxScBWPdMP1Zk8vOliw_003D_003D)2;
		if (7u != 0)
		{
			_0023_003DqT1Q_0024kXIerPOrq3w_PaPH8w_003D_003D = 0f;
		}
		if (2u != 0)
		{
			_0023_003Dqq495Infpuaqk3R3ycC6iJymJs1ri0LrriWUUP7QaBUw_003D = _0023_003Dqvt3EtI3STbrhHIDMCKOBnDCNzkqb7u_0024uo_00249_k4cNyKA_003D;
		}
	}
}
